/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/19/2016
 * Time: 9:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

namespace ChessBridge
{
	/// <summary>
	/// The chessmaster class. Handles all the various nuances of chessmaster to not only allow
	/// the chessmaster engine to work with other GUIs, but allow other engines to work within the
	/// chessmaster gui as the core engine
	/// </summary>
	public sealed class ChessMaster : GUI
	{
		private const string ID = "chessmaster";
		
		
		
		/*************************************************
		 * Chessmaster properties
		 *************************************************/
		
		//Instance
		private static ChessMaster instance = new ChessMaster();
		
		/**
		 * Whether or not a chessmaster is running in analysis mode. Chessmaster's Mentor
		 * only supports raw coordinates, however some winboard engines will write numbered
		 * coordinates. If the input to an engine specifies cm_param ana=1, then
		 * the output will be stripped to raw coordinates so the chessmaster mentor can
		 * vocalize the output.
		 */ 
		private static bool isAnalysisMode = false;
		
		
		/**
		 * Returns the instance
		 */
		public static ChessMaster Instance 
		{
			get 
			{
				return instance;
			}
		}
		
		/**
		 * Private constructor
		 */ 
		private ChessMaster()
		{
		}
		
		/**
		 * Gets the ID associated with this gui.
		 */ 
		public string getId()
		{
			return ID;
		}
		
		/**
		 * Parses the specified personaility into an "ini" type string
		 * suitable for engine arguments.
		 */ 
		public string parsePersonality(string str)
		{
		    Personality p = new Personality();
		    p.parsePersonality(str);
		    return p.toIniString();
		}
		
		
		/**
		 * Does a mass dump of personality files from native to
		 * "INI" format.
		 */ 
		public void dumpPersonalities(string engineDst, string inputDir, string outputDir)
		{
			string[] files = null;
			if (inputDir != null && inputDir.Length > 0)
			{
				files = Directory.GetFiles(inputDir,"*.CMP",SearchOption.AllDirectories);
			}
			else
			{
				files = Directory.GetFiles(".","*.CMP",SearchOption.AllDirectories);
			}

			foreach (string file in files)
			{
				//attempt to read in chessmaster personality file
				try
				{
					string personalityName = Path.GetFileNameWithoutExtension(file);
					
					if (Path.GetExtension(file).ToLower().Equals(".cmp"))
					{
						//parse binary file
						string personality = parsePersonality(file);
						personality = translatePersonalityFrom(engineDst, personality);
						
						//store personality for the future as an ini
						string prefix = "cm";
						if (engineDst != null)
						{
							if (engineDst.Contains("crafty"))
							{
								prefix = "crafty";
							}
						}
						string fullPath = Path.Combine(outputDir, prefix+"_"+personalityName+".ini");
						StreamWriter personalityFile = new StreamWriter(fullPath);
						personalityFile.WriteLine(personality);
						personalityFile.Flush();
						personalityFile.Close();
					}
				}
				catch(Exception ex)
				{
					Program.log("An exception occurred trying to read Chessmaster personality file "+file+". Will use defaults.");
					Program.log(ex.ToString());
				}
			}
		}
		
		/**
		 * Translates personality from chessmaster to the destination engine.
		 */
		public string translatePersonalityFrom(string engineDst, string personality)
		{
			if (engineDst == null || engineDst.Trim().Length == 0)
		    {
			   	Program.log("INFO: Destination engine is null. Cannot translate personality!");
		    	return personality;
		    }
			
			string dst = engineDst.ToLower().Trim();
			
			if (dst.Contains("theking"))
		    {
		    	//no translation necessary
		    	return personality;
		    }
			
			string txPersonality = personality;
			
			//now go through any custom transformations from chessmaster personalities
			//to the engine's personality parmeters
			if (dst.Contains("crafty"))
			{
				//TODO: implement translator
			}
			else
			{
				Program.log("WARN: No translation from "+ID+" to "+dst+" is available. No translation will occur.");
			}
			
			return txPersonality;
		}
		
		
		/**
		 * Does any necessary translation of input to the backend engine
		 */
		public string translateToEngine(string input)
		{
			if(input.Contains("cm_parm ana=1"))
            {
            	isAnalysisMode = true;
            }
            else if (input.Contains("cm_parm ana=0"))
            {
            	isAnalysisMode = false;
            }
            
			return input;
		}
		
		/**
		 * Does any necessary translation from the engine back to the gui.
		 */ 
		public string translateFromEngine(string output)
		{
			//Polygot includes comment lines from the UCI output of engines.
			//These have to be stripped off to work with chessmaster
			if (output.StartsWith("#"))
			{
				Program.log("COMMENT: "+output);
				return null;
			}
			
			string data = output;
            if (isAnalysisMode)
            {
            	//modify output to match mentor
            	
            	//OUT: stat01:    277   2584576 10001  36  37 d4 f5 dxe5 Bb4+ Nd2 Bxd2+ Bxd2 Qh4+ g3 Rh6
				//OUT: 10001   +45    280   2632111 d4 d6 dxe5 dxe5 Qxd8+ Bxd8 Nd2 Be6 f4 Nb4 Kd1 Bb6 Bxb6 axb6 fxe5 Nxa2
				
				//OUT: stat01: 258 4058305 16 28 28 f2f4
				//OUT:  16     -21     270       4255142 1. f2f4 d7d5 2. h2h3 c7c5 3. g1f3 b8c6 4. d1e2 c8e6 5. c2c3 d5d4 6. e3d4 c5d4 7. f3e5 
				
				//Chessmaster mentor needs raw coordinates
				//replace all 1. 2. etc with spaces
				string[] tokens = data.Split(' ');
				StringBuilder sb = new StringBuilder();
				foreach(string tok in tokens)
				{
					if (tok.Trim().Length != 0)
					{
						if (!tok.Contains("."))
						{
							sb.Append(tok);
							sb.Append(" ");
						}
					}
				}
            	
				data = sb.ToString();
            }
            return data;
		}
		
		
	}
}
