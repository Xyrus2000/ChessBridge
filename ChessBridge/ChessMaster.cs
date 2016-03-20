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
		* Chessmaster 9000, X, XI Personality file offsets
		**************************************************/
		private const int CM_PROPERTY_SIZE = 0x04; //Unless otherwise noted, all properties are ints (4 bytes
		
		private const int CM_HEADER_OFFSET = 0;
		private const int CM_HEADER_SIZE = 0x20;
		
		private const int CM_WINBOARD_OR_CM_OFFSET = 0x20; //0x1A for personality, 0 for winboard
		
		private const int CM_VERSION_OFFSET = 0x24;
		
		private const int CM_SHOW_ELO_OFFSET = 0x28; //Shows or hides the ELO in the CM GUI (0xB# shows, 0x81 hides)
		
		private const int CM_PONDER_OFFSET = 0x2C; //1 or 0
		
		private const int CM_TABLESIZE_OFFSET = 0x30; //Values of 0 to 10-> 0,512K,1MB,2MB,4MB,8MB,16MB,32MB,64MB,128MB,256MB
		
		private const int CM_ENDGAMEDB_OFFSET = 0x34; //1 or 0
		
		private const int CM_ELO_OFFSET = 0x38; //User entered ELO
		
		private const int CM_GM_GROUP_OFFSET = 0x3C; //Part of GM group or not. Value of 1600 is GM.
		
		private const int CM_ATTACKDEFENSE_OFFSET = 0x40; //Attack defense value (-100 to 100)
		
		private const int CM_STRENGTH_OFFSET = 0x44; //Strength (0 to 100)
		
		private const int CM_RANDOMNESS_OFFSET = 0x48; //Positional or material (-100 to 100)
		
		private const int CM_UNKNOWN_OFFSET = 0x4C; //Unchangeable, always set to 100
		
		private const int CM_MAXSEARCHDEPTH_OFFSET = 0x50; //Max search depth (1-99)
		
		private const int CM_SELECTIVESEARCH_OFFSET = 0x54; //Max search depth (1-99)
		
		private const int CM_CONTEMPT_OFFSET = 0x58; //Contempt for draws (-500 to 500)
		
		private const int CM_MATERIALPOSITIONAL_OFFSET = 0x5C; //Positional or material (-100 to 100)
		
		private const int CM_OWNCONTROLOFCENTER_OFFSET = 0x60; //Own control of center (0 to 200)
		private const int CM_OPPCONTROLOFCENTER_OFFSET = 0x64; //Opponet control of center (0 to 200)
		
		private const int CM_OWNMOBILITY_OFFSET = 0x68; //Own mobility (0 to 200)
		private const int CM_OPPMOBILITY_OFFSET = 0x6C; //Opponet mobility (0 to 200)
		
		private const int CM_OWNKINGSAFETY_OFFSET = 0x70; //Own king safety (0 to 200)
		private const int CM_OPPKINGSAFETY_OFFSET = 0x74; //Opponet king safety (0 to 200)
		
		private const int CM_OWNPASSEDPAWNS_OFFSET = 0x78; //Own passed pawns (0 to 200)
		private const int CM_OPPPASSEDPAWNS_OFFSET = 0x7C; //Opponet passed pawns (0 to 200)
		
		private const int CM_OWNPAWNWEAKNESS_OFFSET = 0x80; //Own pawn weakness (0 to 200)
		private const int CM_OPPPAWNWEAKNESS_OFFSET = 0x84; //Opponet pawn weakness (0 to 200)
		
		private const int CM_OWNQUEEN_OFFSET = 0x88; //Own queen 0x0 to 0x96 (0 to 15.0)
		private const int CM_OPPQUEEN_OFFSET = 0x8C; //Opponet queen 0x0 to 0x96 (0 to 15.0)
		
		private const int CM_OWNROOK_OFFSET = 0x90; //Own queen 0x0 to 0x96 (0 to 15.0)
		private const int CM_OPPROOK_OFFSET = 0x94; //Opponet queen 0x0 to 0x96 (0 to 15.0)
		
		private const int CM_OWNBISHOP_OFFSET = 0x98; //Own queen 0x0 to 0x96 (0 to 15.0)
		private const int CM_OPPBISHOP_OFFSET = 0x9C; //Opponet queen 0x0 to 0x96 (0 to 15.0)
		
		private const int CM_OWNKNIGHT_OFFSET = 0xA0; //Own queen 0x0 to 0x96 (0 to 15.0)
		private const int CM_OPPKNIGHT_OFFSET = 0xA4; //Opponet queen 0x0 to 0x96 (0 to 15.0)
		
		private const int CM_OWNPAWN_OFFSET = 0xA8; //Own queen 0x0 to 0x96 (0 to 15.0)
		private const int CM_OPPPAWN_OFFSET = 0xAC; //Opponet queen 0x0 to 0x96 (0 to 15.0)
		
		private const int CM_OPENINGBOOK_OFFSET = 0xC0; //Opening book name
		
		private const int CM_IMAGE_OFFSET = 0x1C4; //Image/portrait for personality
		
		private const int CM_PLAYINGSTYLEDESC_OFFSET = 0x1E2; //Description of playstyle
		
		private const int CM_BIOGRAPHY_OFFSET = 0x246; //The biography of the personality
		
		private const int CM_LONGPLAYSTYLE_OFFSET = 0x62E; //Engine specification string (CM Only)
		
		private const int CM_WINBOARDENGINEPATH_OFFSET = 0xA16; //Path for the winboard engine used by the personality
		
		
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
		 * Parses a Chessmaster personality to a string that can be used by
		 * other GUIs to init the chessmaster chess engine.
		 */
		public string parsePersonality(String personalityFile)
		{
			byte[] bytes = File.ReadAllBytes(personalityFile);
			
			Program.log("\n**************************************************");
			Program.log("Parsing Chessmaster Personality "+personalityFile);
			Program.log("**************************************************");
			
			byte[] header = new byte[CM_HEADER_SIZE];
			Array.Copy(bytes, 0, header, 0, CM_HEADER_SIZE);
			Program.log("Header:"+System.Text.Encoding.Default.GetString(header));
			
			if (bytes[CM_WINBOARD_OR_CM_OFFSET] == 0)
			{
				Program.log("WARNING: Personality is Winboard. No values will be present for parameters.");
			}
			
			int v = Program.getIntFromByteArray(bytes,CM_VERSION_OFFSET);
			Program.log("Version: "+v);
			
		    v = Program.getIntFromByteArray(bytes,CM_SHOW_ELO_OFFSET);
		    if (v == 0xB3)
		    {
				Program.log("Show ELO: "+true);
		    }
		    else
		    {
		    	Program.log("Show ELO: "+false);
		    }
		    
			v = Program.getIntFromByteArray(bytes,CM_PONDER_OFFSET);
			Program.log("Ponder: "+v);
			bool ponder= false;
			if (v != 0)
			{
				ponder = true;
			}
			
			v = Program.getIntFromByteArray(bytes,CM_TABLESIZE_OFFSET);
			if (v > 0)
			{
				v = (int)Math.Pow(2,18+v);
			}
			int tableSize = v;
			Program.log("Table Size: "+tableSize);
			
			v = Program.getIntFromByteArray(bytes,CM_ENDGAMEDB_OFFSET);
			Program.log("Use Endgame DB: "+v);
			bool isEndgameDB = false;
			if (v > 0)
			{
				isEndgameDB = true;
			}
			
			v = Program.getIntFromByteArray(bytes,CM_ELO_OFFSET);
			int pELO = v;
			Program.log("Personality ELO: "+v);
				
			v = Program.getIntFromByteArray(bytes,CM_GM_GROUP_OFFSET);
			int gmGroup = v;
			if (gmGroup == 0x640)
			{
				Program.log("GM Group: "+true);
			}
			else
			{
				Program.log("GM Group: "+false);
			}
			
			v = Program.getIntFromByteArray(bytes,CM_ATTACKDEFENSE_OFFSET);
			int attackDefense = v;
			Program.log("Attacker/Defender: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_STRENGTH_OFFSET);
			int strength = v;
			Program.log("Strength: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_RANDOMNESS_OFFSET);
			int randomness = v;
			Program.log("Randomness: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_UNKNOWN_OFFSET);
			int unknown = v;
			Program.log("Unknown: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_MAXSEARCHDEPTH_OFFSET);
			int maxSearchDepth = v;
			Program.log("Max Search Depth: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_SELECTIVESEARCH_OFFSET);
			int selectiveSearch = v;
			Program.log("Selective Search: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_CONTEMPT_OFFSET);
			int contempt = v;
			Program.log("Contempt: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_MATERIALPOSITIONAL_OFFSET);
			int materialPositional = v;
			Program.log("Material or Positional: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNCONTROLOFCENTER_OFFSET);
			int ownControlOfCenter = v;
			Program.log("Own Control of Center: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPCONTROLOFCENTER_OFFSET);
			int oppControlOfCenter = v;
			Program.log("Opponent Control of Center: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNMOBILITY_OFFSET);
			int ownMobility = v;
			Program.log("Own Mobility: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPMOBILITY_OFFSET);
			int oppMobility = v;
			Program.log("Opponent Mobility: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNKINGSAFETY_OFFSET);
			int ownKingSafety = v;
			Program.log("Own King Safety: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPKINGSAFETY_OFFSET);
			int oppKingSafety = v;
			Program.log("Opponent King Safety: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNPASSEDPAWNS_OFFSET);
			int ownPassedPawns = v;
			Program.log("Own Passed Pawns: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPPASSEDPAWNS_OFFSET);
			int oppPassedPawns = v;
			Program.log("Opponent Passed Pawns: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNPAWNWEAKNESS_OFFSET);
			int ownPawnWeakness = v;
			Program.log("Own Pawn Weakness: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPPAWNWEAKNESS_OFFSET);
			int oppPawnWeakness = v;
			Program.log("Opponent Pawn Weakness: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNQUEEN_OFFSET);
			int ownQueen = v;
			Program.log("Own Queen: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPQUEEN_OFFSET);
			int oppQueen = v;
			Program.log("Opponent Queen: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNROOK_OFFSET);
			int ownRook = v;
			Program.log("Own Rook: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPROOK_OFFSET);
			int oppRook = v;
			Program.log("Opponent Rook: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNBISHOP_OFFSET);
			int ownBishop = v;
			Program.log("Own Bishop: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPBISHOP_OFFSET);
			int oppBishop = v;
			Program.log("Opponent Bishop: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNKNIGHT_OFFSET);
			int ownKnight = v;
			Program.log("Own Knight: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPKNIGHT_OFFSET);
			int oppKnight = v;
			Program.log("Opponent Knight: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNPAWN_OFFSET);
			int ownPawn = v;
			Program.log("Own Pawn: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPPAWN_OFFSET);
			int oppPawn = v;
			Program.log("Opponent Pawn: "+v);
			
			string openingBook = Program.getStringFromByteArray(bytes,CM_OPENINGBOOK_OFFSET);
			Program.log("Opening Book: "+openingBook);
			
			string image = Program.getStringFromByteArray(bytes,CM_IMAGE_OFFSET);
			Program.log("Image: "+image);
			
			string playingStyle = Program.getStringFromByteArray(bytes,CM_PLAYINGSTYLEDESC_OFFSET);
			Program.log("Playing Style: "+playingStyle);
			
			string biography = Program.getStringFromByteArray(bytes,CM_BIOGRAPHY_OFFSET);
			Program.log("Biography: "+biography);
			
			string longPlayStyle = Program.getStringFromByteArray(bytes,CM_LONGPLAYSTYLE_OFFSET);
			longPlayStyle = longPlayStyle.Replace("%d",pELO.ToString());
			Program.log("Long Play Style: "+longPlayStyle);
			
			string wbEnginePath = Program.getStringFromByteArray(bytes,CM_WINBOARDENGINEPATH_OFFSET);
			Program.log("Winboard Engine: "+wbEnginePath);
			
			//Ok, got all the info, now write out a string that can be used for an external GUI
			StringBuilder sb = new StringBuilder();
			
			/*
			 * 	cm_parm default
				cm_parm opp=100 opn=100 opb=100 opr=100 opq=100
				cm_parm myp=100 myn=100 myb=100 myr=100 myq=100
				cm_parm mycc=100 mymob=100 myks=100 mypp=100 mypw=100
				cm_parm opcc=100 opmob=100 opks=100 oppp=100 oppw=100
				cm_parm cfd=0 sop=100 avd=0 rnd=0 sel=14 md=99
				cm_parm tts=2097152
			 */ 
			
			
			//must have an opk number
			sb.AppendLine("cm_parm opk=586126");
			//weather or not to perform analysis
			//sb.AppendLine("cm_parm ana=1");
			//always included
			sb.AppendLine("cm_parm default");
			
			sb.AppendLine("cm_parm mycc="+ownControlOfCenter);
			sb.AppendLine("cm_parm opcc="+oppControlOfCenter);
			
			sb.AppendLine("cm_parm mymob="+ownMobility);
			sb.AppendLine("cm_parm opmob="+oppMobility);
			
			sb.AppendLine("cm_parm myks="+ownKingSafety);
			sb.AppendLine("cm_parm opks="+oppKingSafety);
			
			sb.AppendLine("cm_parm mypp="+ownPassedPawns);
			sb.AppendLine("cm_parm oppp="+oppPassedPawns);
			
			sb.AppendLine("cm_parm mypp="+ownPawnWeakness);
			sb.AppendLine("cm_parm oppp="+oppPawnWeakness);
			
			sb.AppendLine("cm_parm cfd="+contempt);
			sb.AppendLine("cm_parm sop="+strength);
			sb.AppendLine("cm_parm avd="+attackDefense);
			sb.AppendLine("cm_parm rnd="+randomness);
			sb.AppendLine("cm_parm sel="+selectiveSearch);
			sb.AppendLine("cm_parm md="+maxSearchDepth);
			sb.AppendLine("cm_parm tts="+tableSize);
			
			sb.AppendLine("cm_parm myp="+ownPawn);
			sb.AppendLine("cm_parm opp="+oppPawn);
			
			sb.AppendLine("cm_parm myn="+ownKnight);
			sb.AppendLine("cm_parm opn="+oppKnight);
			
			sb.AppendLine("cm_parm myb="+ownBishop);
			sb.AppendLine("cm_parm opb="+oppBishop);
			
			sb.AppendLine("cm_parm myr="+ownRook);
			sb.AppendLine("cm_parm opr="+oppRook);
			
			sb.AppendLine("cm_parm myq="+ownQueen);
			sb.AppendLine("cm_parm opq="+oppQueen);
			
			return sb.ToString();
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
			//These have to be stripped off to worjk with chessmaster
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
