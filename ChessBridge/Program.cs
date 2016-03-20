﻿/*
 * Simple "bridge" to allow modification of input/output commands between
 * one application and another, specifically chess GUI's and engines. This can also
 * be used in instances where commercial engines are less than forthcoming about their parameters (like chessmaster).
 * 
 * This application has been used successfully as a bridge for chessmaster and arena.
 */
using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Management;

namespace ChessBridge
{
	class Program
	{
		/********************************************
		 * Configuration paramaters
		 ********************************************/
		private const string DEFAULT_LOG_BASE_FILENAME = "chessbridge-log";
		private const string DEFAULT_ENGINE = "theking350.exe";
		private const string DEFAULT_GUI = "chessmaster";
		
		public const string GENERIC_WINBOARD = "winboard";
		public const string GENERIC_XBOARD = "xboard";
		//TODO: UCI
		public const string GENERIC_UCI = "uci";
		
		
		
		/***************************************************************************
 		* Modes. If a mode is not specified, then the default "bridge" mode is run.
 		****************************************************************************/
		
		//Dumps personality files to text based ini files for use in other GUIs
		private const string PERSONALITY_DUMP = "personality.dump";
		
		/************************************************************************
		 * Config keys
		 ************************************************************************/ 
		private const string MODE_KEY = "mode";
		
		//Directory conatianing chessmaster personalities.
		//NOTE: This is ONLY used when the mode is CM_PERSONALITY_DUMP
		private const string PERSONALITY_INPUT_DIR_KEY = "personality.input.dir";
		//Directory to output personality dumps to. The deault is the current directory.
		//NOTE: This is ONLY used when the mode is CM_PERSONALITY_DUMP.
		private const string PERSONALITY_OUTPUT_DIR_KEY = "personality.output.dir";
		
		//The gui to run with. The default is chessmaster (winboard compatible).
		private const string GUI_KEY = "gui";
		//The engine executable to bridge to
		private const string ENGINE_KEY = "engine";
		//The personality to run the engine with
		private const string PERSONALITY_KEY = "personality";
		//To run with or without logging
		private const string LOGGING_KEY = "logging";
		//Base file name for generated logs
		private const string LOG_BASE_FILENAME_KEY = "logging.base_filename";
		
		/**
		 * Log file writer.
		 */
		private static StreamWriter chessLogWriter = null;
		
		private static bool logToFile = false;
		private static string logBaseFilename = DEFAULT_LOG_BASE_FILENAME;
		
		private static string guiName = DEFAULT_GUI;
		private static GUI gui = null;
		private static string engine = null;
		private static Process engineProcess = null;
		
		private static ManualResetEvent run = new ManualResetEvent(true);
		
		/**
		 * Kills a process and all of it's children.
		 */
		private static void KillProcessAndChildren(int pid)
		{
		    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
		    ManagementObjectCollection moc = searcher.Get();
		    foreach (ManagementObject mo in moc)
		    {
		        KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
		    }
		    try
		    {
		        Process proc = Process.GetProcessById(pid);
		        proc.Kill();
		    }
		    catch (ArgumentException ex)
		    {
		    	log("INFO: "+ex.ToString());
		    }
		 }
		
		

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);                
        private delegate bool EventHandler(CtrlType sig);
        static EventHandler exitHandler;
        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
        
        /**
         * Handle crashes and closes
         */ 
        private static bool ExitHandler(CtrlType sig)
        {
            log("Shutting down: " + sig.ToString());
            KillProcessAndChildren(engineProcess.Id);
            //engineProcess.Kill();
            run.Reset();
            Thread.Sleep(2000);
            return false; 
            // If the function handles the control signal, it should return TRUE. If it returns FALSE, the next handler function in the list of handlers for this process is used (from MSDN).
        }
		
		
		
		
		/**
		 * Simple logging method. If logging is enabled, will write messages to the log.
		 */ 
		public static void log(string message)
		{
			if (logToFile && chessLogWriter != null)
			{
				chessLogWriter.WriteLine(message);
				chessLogWriter.Flush();
			}
		}
		
		/**
		 * Helper method that gets an int value from a byte array at the specified offset
		 */
		public static int getIntFromByteArray(byte[] bytes, int offset)
		{
			return bytes[offset+3] << 24 | bytes[offset+2] << 16 | bytes[offset+1] << 8 | bytes[offset];
		}
		
		/**
		 * Gets a string from the specified byte array at the specified offset. This method keeps
		 * reading bytes until it hits a terminator (0x0)
		 */ 
		public static string getStringFromByteArray(byte[] bytes, int offset)
		{
			int inc = offset;
			byte b = bytes[inc++];
			
			StringBuilder sb = new StringBuilder();
			while(b != 0)
			{
				sb.Append((char)b);
				b = bytes[inc++];
			}
			return sb.ToString();		
		}
		
		/**
		 * Handler for data coming from the engine. 
		 */
		private static void ChessEngineDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            // Collect the net view command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                string data = gui.translateFromEngine(outLine.Data);
                if (data != null)
                {
                	log("OUT: "+data);
               		Console.WriteLine(data);
            		Console.Out.Flush();
                }
            }
        }
		
		/**
		 * Handler for error data coming from the engine. 
		 */
        private static void ChessEngineErrorDataHandler(object sendingProcess, DataReceivedEventArgs errLine)
        {
            // Write the error text to the file if there is something
            // to write and an error file has been specified.

            if (!String.IsNullOrEmpty(errLine.Data))
            {
            	log("ERROR:"+errLine.Data);
            	chessLogWriter.Flush();
            	Console.Error.WriteLine(errLine.Data);
            	Console.Error.Flush();
            }          
		}
		
        /**
         * Parses the config file and reutrns a dictionary of key-values from the file.
         */ 
        private static Dictionary<string,string> parseConfig(string configFile)
        {
        	Dictionary<string,string> configMap = new Dictionary<string,string>();
        	
        	StreamReader confReader = new StreamReader(configFile);
        	
        	string confLine = null;
        	while ((confLine = confReader.ReadLine()) != null) 
			{
        		//skip comments
        		if (!confLine.StartsWith("#") && confLine.Trim().Length > 0)
    		    {
					string[] tokens = confLine.Split('=');
					
					string key = tokens[0];
					string value = null;
					if (tokens.Length >= 2)
					{
						value = tokens[1];
					}
					key = key.ToLower().Trim();
					configMap.Add(key,value);
    		    }
			}
        	
        	return configMap;
        }
        
		/**
		 * The main application. 
		 */
		public static void Main(string[] args)
		{
			exitHandler += new EventHandler(ExitHandler);
            SetConsoleCtrlHandler(exitHandler, true);
            
			long millis = (long)DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
			
			Dictionary<string,string> configParams = parseConfig("chessbridge.cfg");
			
			try
			{
				string str = configParams[LOGGING_KEY];
				if (str == null)
				{
					logToFile = false;
				}
				else
				{
					logToFile = true;
					str = configParams[LOG_BASE_FILENAME_KEY];
					if (str != null)
					{
						logBaseFilename = str;
					}
					chessLogWriter = new StreamWriter(logBaseFilename+"-"+millis+".log");
				}
			}
			catch(Exception ex)
			{
				//do nothing
			}
			
			string tg = configParams[GUI_KEY];
			if (tg != null && tg.Trim().Length > 0)
			{
				guiName = tg;
			}
			
			guiName = guiName.ToLower().Trim();
			
			if (guiName.Equals(ChessMaster.Instance.getId()))
		    {
		    	gui = ChessMaster.Instance;
		    }
			
			engine = configParams[ENGINE_KEY];
			if (engine == null || engine.Trim().Length == 0)
			{
				engine = DEFAULT_ENGINE;
			}
			
			string mode = configParams[MODE_KEY];
			if (mode != null)
			{
				mode = mode.ToLower();
			}
			
			if (mode.Equals(PERSONALITY_DUMP))
			{
				string inputDir = configParams[PERSONALITY_INPUT_DIR_KEY];
								
				string outputDir = configParams[PERSONALITY_OUTPUT_DIR_KEY];
				if (outputDir != null && outputDir.Length != 0)
				{
					Directory.CreateDirectory(outputDir);
				}
				
				gui.dumpPersonalities(engine, inputDir, outputDir);
				
				//we're done
				return;
			}
			
			if (mode == null || !mode.Equals(PERSONALITY_DUMP))
			{
				engine = configParams[ENGINE_KEY];
				if (engine == null || engine.Length == 0)
				{
					Console.WriteLine("ERROR: Chess engine is null! Cannot proceed!");
					return;
				}
			}
			
			string gamePersonality = null;
			
			foreach (string key in configParams.Keys)
			{
				if (key.Equals(PERSONALITY_KEY))
				{
					//attempt to read in personality file
					string value = configParams[key];
					try
					{
						string personalityName = Path.GetFileNameWithoutExtension(value);
						
						if (!Path.GetExtension(value).ToLower().Equals(".ini"))
						{
							//parse binary file
							gamePersonality = gui.parsePersonality(value);
							
							//store for the future as an ini
							StreamWriter personalityFile = new StreamWriter(personalityName+".ini");
							personalityFile.WriteLine(gamePersonality);
							personalityFile.Flush();
							personalityFile.Close();
						}
						else
						{
							gamePersonality = File.ReadAllText(value);
						}
					}
					catch(Exception ex)
					{
						log("An exception occurred trying to read Chessmaster personality file "+value+". Will use defaults.");
						log(ex.ToString());
					}
				}
			}
			
			log("***PROGRAM ARGUMENTS***");
			foreach(string arg in args)
			{
				log(arg);
			}
			
			//Start the engine
		 	engineProcess = new Process();
	     	engineProcess.StartInfo.FileName = engine;
	     	//p.StartInfo.Arguments = "/c "+engineName;
	     	engineProcess.StartInfo.UseShellExecute = false;
	     	engineProcess.StartInfo.CreateNoWindow = true;
	     	engineProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
	     	engineProcess.StartInfo.RedirectStandardInput = true;
	     	engineProcess.StartInfo.RedirectStandardOutput = true;
	     	engineProcess.StartInfo.RedirectStandardError = true;
	     	engineProcess.OutputDataReceived += new DataReceivedEventHandler(ChessEngineDataHandler);
	     	engineProcess.ErrorDataReceived += new DataReceivedEventHandler(ChessEngineErrorDataHandler);
	     	
	     	try
	     	{
	        	engineProcess.Start();
	        	engineProcess.BeginOutputReadLine();
                engineProcess.BeginErrorReadLine();
	     	}
	     	catch(Exception ex)
	     	{
	     		log("Exception occurred trying to start engine "+engine+"!");
	     		log(ex.ToString());
	     	}
	
			//Now the bridge. Read in and record commands from GUI and pass them on to the engine.
			string line;
			log("***ENGINE COMS***");
			
			//if a personality was specified, use it first
			if (gamePersonality != null)
			{
				log("IN: "+gamePersonality);
				//pass to engine
				engineProcess.StandardInput.WriteLine(gamePersonality);
				engineProcess.StandardInput.Flush();
			}
			
			string[] nl = new string[]{"\\n"};
			while ((line = Console.ReadLine()) != null && line != "") 
			{
				//if this parameter is found, we're running from the chessmaster gui and require
				//special handling of analysis output so the chessmaster mentor works
				line = gui.translateToEngine(line);
				
				//make sure there are no unparsed newlines
				string[] tokens = line.Split(nl, StringSplitOptions.None);
				
				//record
				foreach(string tok in tokens)
				{
					if (tok.Trim().Length > 0)
					{
						log("IN: "+tok);
						//pass to engine
						engineProcess.StandardInput.WriteLine(tok);
						engineProcess.StandardInput.Flush();
					}
				}
			}
			
			engineProcess.WaitForExit();
			return;
		}
		
	}
}