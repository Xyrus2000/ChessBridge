/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 5:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ChessBridge
{
    /// <summary>
    /// Description of Personality.
    /// </summary>
    public class Personality
    {
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
		
		
		private const int CM_UNKNOWN_B0_OFFSET = 0xB0; //always 0
		private const int CM_UNKNOWN_B4_OFFSET = 0xB4; //always 0
		
		private const int CM_SEX_OFFSET = 0xB8; //1 male, 0 female
		private const int CM_AGE_OFFSET = 0xBC;
		
		private const int CM_OPENINGBOOK_OFFSET = 0xC0; //Opening book name
		
		private const int CM_IMAGE_OFFSET = 0x1C4; //Image/portrait for personality
		
		private const int CM_SHORTPLAYSTYLE_OFFSET = 0x1E2; //Description of playstyle
		
		private const int CM_BIOGRAPHY_OFFSET = 0x246; //The biography of the personality
		
		private const int CM_LONGPLAYSTYLE_OFFSET = 0x62E; //Engine specification string (CM Only)
		
		private const int CM_WINBOARDENGINEPATH_OFFSET = 0xA16; //Path for the winboard engine used by the personality
		
		/*************************************
		 * Defined Values
		 **************************************/
		public const int CM_MALE = 1;
		public const int CM_FEMALE = 0;
		public const int CM_SHOWELO = 0xB3;
		public const int CM_GROUP = 0x640;    //indicates is a native personality to the game.
		
		
	
		//variable
        private byte[] header = new Byte[CM_HEADER_SIZE];
        
        public byte[] Header {
            get { return header; }
        }
        
        private int isWinboard; //0 means winboard
        
        public int IsWinboard {
            get { return isWinboard; }
            set { isWinboard = value; }
        }
        
        private int version;
        
        public int Version {
            get { return version; }
        }
        
        private int showElo;
        
        public int ShowElo {
            get { return showElo; }
            set { showElo = value; }
        }
        
        private int opk = 586126;
        
        public int Opk {
            get { return opk; }
            set { opk = value; }
        }
        
        private int elo = 0;
        
        public int Elo {
            get { return elo; }
            set { elo = value; }
        }
        
        private int isGM = 0;
        
        public int IsGM {
            get { return isGM; }
            set { isGM = value; }
        }
        
        private int sex;
        
        public int Sex {
            get { return sex; }
            set { sex = value; }
        }
        
        private int age;
        
        public int Age {
            get { return age; }
            set { age = value; }
        }
        
        private string image;
        
        public string Image {
            get { return image; }
            set { image = value; }
        }
        
        
        private string openingBook = "";
        
        public string OpeningBook {
            get { return openingBook; }
            set { openingBook = value; }
        }
        
        private int attackDefense = 0;
        
        public int AttackDefense {
            get { return attackDefense; }
            set { attackDefense = value; }
        }
        
        private int sop = 100;
        
        public int Sop {
            get { return sop; }
            set { sop = value; }
        }
        
        private int matPos = 0;
        
        public int MatPos {
            get { return matPos; }
            set { matPos = value; }
        }
        
        private int rand = 0;
        
        public int Rand {
            get { return rand; }
            set { rand = value; }
        }
        
        private int maxDepth = 0;
        
        public int MaxDepth {
            get { return maxDepth; }
            set { maxDepth = value; }
        }
        
        private int selSearch = 0;
        
        public int SelSearch {
            get { return selSearch; }
            set { selSearch = value; }
        }
        
        private int contempt = 0;
        
        public int Contempt {
            get { return contempt; }
            set { contempt = value; }
        }
        
        private int ttSize = 0;
        
        public int TtSize {
            get { return ttSize; }
            set { ttSize = value; }
        }
        
        private int ponder = 0;
        
        public int Ponder {
            get { return ponder; }
            set { ponder = value; }
        }
        
        private int useEGT = 0;
        
        public int UseEGT {
            get { return useEGT; }
            set { useEGT = value; }
        }
        
        private int ownCoC = 0;
        
        public int OwnCoC {
            get { return ownCoC; }
            set { ownCoC = value; }
        }
        
        private int oppCoC = 0;
        
        public int OppCoC {
            get { return oppCoC; }
            set { oppCoC = value; }
        }
        
        private int ownMob = 0;
        
        public int OwnMob {
            get { return ownMob; }
            set { ownMob = value; }
        }
        
        private int oppMob = 0;
        
        public int OppMob {
            get { return oppMob; }
            set { oppMob = value; }
        }
        
        private int ownKS = 0;
        
        public int OwnKS {
            get { return ownKS; }
            set { ownKS = value; }
        }
        
        private int oppKS = 0;
        
        public int OppKS {
            get { return oppKS; }
            set { oppKS = value; }
        }
        
        private int ownPP = 0;
        
        public int OwnPP {
            get { return ownPP; }
            set { ownPP = value; }
        }
        
        private int oppPP = 0;
        
        public int OppPP {
            get { return oppPP; }
            set { oppPP = value; }
        }
        
        private int ownPW = 0;
        
        public int OwnPW {
            get { return ownPW; }
            set { ownPW = value; }
        }
        
        private int oppPW = 0;
        
        public int OppPW {
            get { return oppPW; }
            set { oppPW = value; }
        }
        
        private int ownQ = 0;
        
        public int OwnQ {
            get { return ownQ; }
            set { ownQ = value; }
        }
        
        private int oppQ = 0;
        
        public int OppQ {
            get { return oppQ; }
            set { oppQ = value; }
        }
        
        private int ownR = 0;
        
        public int OwnR {
            get { return ownR; }
            set { ownR = value; }
        }
        
        private int oppR = 0;
        
        public int OppR {
            get { return oppR; }
            set { oppR = value; }
        }
        
        private int ownB = 0;
        
        public int OwnB {
            get { return ownB; }
            set { ownB = value; }
        }
        
        private int oppB = 0;
        
        public int OppB {
            get { return oppB; }
            set { oppB = value; }
        }
        
        private int ownN = 0;
        
        public int OwnN {
            get { return ownN; }
            set { ownN = value; }
        }
        
        private int oppN = 0;
        
        public int OppN {
            get { return oppN; }
            set { oppN = value; }
        }
        
        private int ownP = 0;
        
        public int OwnP {
            get { return ownP; }
            set { ownP = value; }
        }
        
        private int oppP = 0;
        
        public int OppP {
            get { return oppP; }
            set { oppP = value; }
        }
        
        private string shortPlayingStyle = "";
        
        public string ShortPlayingStyle {
            get { return shortPlayingStyle; }
            set { shortPlayingStyle = value; }
        }
        
        private string biography = "";
        
        public string Biography {
            get { return biography; }
            set { biography = value; }
        }
        
        private string longPlayingStyle = "";
        
        public string LongPlayingStyle {
            get { return longPlayingStyle; }
            set { longPlayingStyle = value; }
        }
        
        private string winboard = "";
        
        public string Winboard {
            get { return winboard; }
            set { winboard = value; }
        }
        
        /**
		 * Converts this personality into a basic string containing
		 * the properties that are usually passed to the chessmaster
		 * engine.
		 */
		public string toIniString()
		{
			//text
	        StringBuilder sb = new StringBuilder();
	        
	        //must have an opk number
	        //sb.AppendLine("cm_parm opk=204414");//("cm_parm opk=586126");
			
			sb.AppendLine("cm_parm default");
			//sb.AppendLine("cm_parm debug=true");
			//sb.AppendLine("cm_parm verbose=true");
			
	        //
			sb.AppendLine("cm_parm opp="+this.oppP+" opn="+this.oppN+" opb="+this.oppB+" opr="+this.oppR+" opq="+this.oppQ);
			sb.AppendLine("cm_parm myp="+this.ownP+" myn="+this.ownN+" myb="+this.ownB+" myr="+this.ownR+" myq="+this.ownQ);
			sb.AppendLine("cm_parm mycc="+this.ownCoC+" mymob="+this.ownMob+" myks="+this.ownKS+" mypp="+this.ownPP+" mypw="+this.ownPW);
			sb.AppendLine("cm_parm opcc="+this.oppCoC+" opmob="+this.oppMob+" opks="+this.oppKS+" oppp="+this.oppPP+" oppw="+this.oppPW);
			sb.AppendLine("cm_parm cfd="+this.contempt+" sop="+this.sop+" avd="+this.attackDefense+
			             " rnd="+this.rand+" sel="+this.selSearch+" md="+this.maxDepth);
			sb.AppendLine("cm_parm tts="+Math.Pow(2,18+this.TtSize));
			
            //must have an opk number
			//sb.AppendLine("cm_parm opk=586126");
			//weather or not to perform analysis
			//sb.AppendLine("cm_parm ana=1");
			//always included
			/*sb.AppendLine("cm_parm default");
			
			sb.AppendLine("cm_parm mycc="+this.OwnCoC);
			sb.AppendLine("cm_parm opcc="+this.OppCoC);
			
			sb.AppendLine("cm_parm mymob="+this.OwnMob);
			sb.AppendLine("cm_parm opmob="+this.OppMob);
			
			sb.AppendLine("cm_parm myks="+this.OwnKS);
			sb.AppendLine("cm_parm opks="+this.OppKS);
			
			sb.AppendLine("cm_parm mypp="+this.OwnPP);
			sb.AppendLine("cm_parm oppp="+this.OppPP);
			
			sb.AppendLine("cm_parm mypw="+this.OwnPW);
			sb.AppendLine("cm_parm oppw="+this.OppPW);
			
			sb.AppendLine("cm_parm cfd="+this.Contempt);
			sb.AppendLine("cm_parm sop="+this.Sop);
			sb.AppendLine("cm_parm avd="+this.AttackDefense);
			sb.AppendLine("cm_parm rnd="+this.Rand);
			sb.AppendLine("cm_parm sel="+this.SelSearch);
			sb.AppendLine("cm_parm md="+this.MaxDepth);
			
			
			sb.AppendLine("cm_parm myp="+this.OwnP);
			sb.AppendLine("cm_parm opp="+this.OppP);
			
			sb.AppendLine("cm_parm myn="+this.OwnN);
			sb.AppendLine("cm_parm opn="+this.OppN);
			
			sb.AppendLine("cm_parm myb="+this.OwnB);
			sb.AppendLine("cm_parm opb="+this.OppB);
			
			sb.AppendLine("cm_parm myr="+this.OwnR);
			sb.AppendLine("cm_parm opr="+this.OppR);
			
			sb.AppendLine("cm_parm myq="+this.OwnQ);
			sb.AppendLine("cm_parm opq="+this.OppQ);
    		
            sb.AppendLine("cm_parm tts="+Math.Pow(2,18+this.TtSize));*/			
			return sb.ToString();
		}
		
		/**
		 * Parses a Chessmaster personality.
		 */
		public void parsePersonality(String personalityFile)
		{
		    Personality personality = this;
		    
			byte[] bytes = File.ReadAllBytes(personalityFile);
			
			Program.log("\n**************************************************");
			Program.log("Parsing Chessmaster Personality "+personalityFile);
			Program.log("**************************************************");
			
			Array.Copy(bytes, 0, personality.Header, 0, CM_HEADER_SIZE);
			Program.log("Header:"+System.Text.Encoding.Default.GetString(header));
			
			int v = Program.getIntFromByteArray(bytes,CM_WINBOARD_OR_CM_OFFSET);
			this.IsWinboard = v;
			if (v == 0)
			{
				Program.log("WARNING: Personality is Winboard. No values will be present for parameters.");
			}
			
			v = Program.getIntFromByteArray(bytes,CM_VERSION_OFFSET);
			Program.log("Version: "+v);
			this.version = v;
			
			v = Program.getIntFromByteArray(bytes,CM_SEX_OFFSET);
			if (v != 0)
			{
			    Program.log("Sex: Male");
			}
			else
			{
			    Program.log("Sex: Female");
			}
			this.Sex = v;
			
			v = Program.getIntFromByteArray(bytes,CM_AGE_OFFSET);
			Program.log("Age: "+v);
			this.Age = v;
			
		    v = Program.getIntFromByteArray(bytes,CM_SHOW_ELO_OFFSET);
		    this.ShowElo = v;
		    if (v == 0xB3)
		    {
				Program.log("Show ELO: "+true);
		    }
		    else
		    {
		    	Program.log("Show ELO: "+false);
		    }
		    
			v = Program.getIntFromByteArray(bytes,CM_PONDER_OFFSET);
			this.Ponder = v;
			Program.log("Pondering: "+v);
						
			v = Program.getIntFromByteArray(bytes,CM_TABLESIZE_OFFSET);
			if (v > 0)
			{
				personality.TtSize = v;
			}
			Program.log("Transposition Table: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_ENDGAMEDB_OFFSET);
			this.UseEGT = v;
			Program.log("Use End Game Table: "+v);
						
			v = Program.getIntFromByteArray(bytes,CM_ELO_OFFSET);
			personality.Elo = v;
			Program.log("ELO: "+v);
				
			v = Program.getIntFromByteArray(bytes,CM_GM_GROUP_OFFSET);
			this.IsGM = v;
			Program.log("GM Group: "+v);
						
			v = Program.getIntFromByteArray(bytes,CM_ATTACKDEFENSE_OFFSET);
			personality.AttackDefense = v;
			Program.log("Attack/Defense: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_STRENGTH_OFFSET);
			personality.Sop = v;
			Program.log("Strength: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_RANDOMNESS_OFFSET);
			personality.Rand = v;
			Program.log("Randomness: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_UNKNOWN_OFFSET);
			int unknown = v;
			Program.log("Unknown: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_MAXSEARCHDEPTH_OFFSET);
			personality.MaxDepth = v;
			Program.log("Max Depth: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_SELECTIVESEARCH_OFFSET);
			personality.SelSearch = v;
			Program.log("Selective Search: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_CONTEMPT_OFFSET);
			personality.Contempt = v;
			Program.log("Contempt for Draw: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_MATERIALPOSITIONAL_OFFSET);
			personality.MatPos = v;
			Program.log("Material/Positional: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNCONTROLOFCENTER_OFFSET);
			personality.OwnCoC = v;
			Program.log("Own Control of Center: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPCONTROLOFCENTER_OFFSET);
			personality.OppCoC = v;
			Program.log("Opp. Control of Center: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNMOBILITY_OFFSET);
			personality.OwnMob = v;
			Program.log("Own Mobility: "+v);
			
			
			v = Program.getIntFromByteArray(bytes,CM_OPPMOBILITY_OFFSET);
			personality.OppMob = v;
			Program.log("Opp. Mobility: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNKINGSAFETY_OFFSET);
			personality.OwnKS = v;
			Program.log("Own King Safety: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPKINGSAFETY_OFFSET);
			personality.OppKS = v;
			Program.log("Opp. King Safety: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNPASSEDPAWNS_OFFSET);
			personality.OwnPP = v;
			Program.log("Own Passed Pawns: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPPASSEDPAWNS_OFFSET);
			personality.OppPP = v;
			Program.log("Opp. Passed Pawns: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNPAWNWEAKNESS_OFFSET);
			personality.OwnPW = v;
			Program.log("Own Pawn Weakness: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPPAWNWEAKNESS_OFFSET);
			personality.OppPW = v;
			Program.log("Opp. Pawn Weakness: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNQUEEN_OFFSET);
			personality.OwnQ = v;
			Program.log("Own Queen: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPQUEEN_OFFSET);
			personality.OppQ = v;
			Program.log("Opp. Queen : "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNROOK_OFFSET);
			personality.OwnR = v;
			Program.log("Own Rooks: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPROOK_OFFSET);
			personality.OppR = v;
			Program.log("Opp. Rooks: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNBISHOP_OFFSET);
			personality.OwnB = v;
			Program.log("Own Bishops: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPBISHOP_OFFSET);
			personality.OppB = v;
			Program.log("Opp. Bishops: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNKNIGHT_OFFSET);
			personality.OwnN = v;
			Program.log("Own Knights: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPKNIGHT_OFFSET);
			personality.OppN = v;
			Program.log("Opp. Knights: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OWNPAWN_OFFSET);
			personality.OwnP = v;
			Program.log("Own Pawns: "+v);
			
			v = Program.getIntFromByteArray(bytes,CM_OPPPAWN_OFFSET);
			personality.OppP = v;
			Program.log("Opp. Pawns: "+v);
			
			string openingBook = Program.getStringFromByteArray(bytes,CM_OPENINGBOOK_OFFSET);
			personality.OpeningBook = openingBook;
			Program.log("Opening Book: "+v);
			
			string image = Program.getStringFromByteArray(bytes,CM_IMAGE_OFFSET);
			personality.Image = image;
			Program.log("Image: "+image);
			
			string playingStyle = Program.getStringFromByteArray(bytes,CM_SHORTPLAYSTYLE_OFFSET);
			personality.ShortPlayingStyle = playingStyle;
			Program.log("Short Playing Style: "+v);
			
			string biography = Program.getStringFromByteArray(bytes,CM_BIOGRAPHY_OFFSET);
			personality.Biography = biography;
			Program.log("Biography: "+v);
			
			string longPlayStyle = Program.getStringFromByteArray(bytes,CM_LONGPLAYSTYLE_OFFSET);
			longPlayStyle = longPlayStyle.Replace("%d",personality.Elo.ToString());
			personality.LongPlayingStyle = longPlayStyle;
			Program.log("Long Playing Style: "+v);
			
			string wbEnginePath = Program.getStringFromByteArray(bytes,CM_WINBOARDENGINEPATH_OFFSET);
			personality.Winboard = wbEnginePath;
			Program.log("Winboard Engine Path: "+v);
			
		}
		
		/**
		 * Saves the personality to a file. If the extension is "CMP", then
		 * it will save to a chessmaster personality file. Otherwise, it will save to a text
		 * based file.
		 */ 
		public void savePersonalityToFile(string fileName)
		{
		    string ext = Path.GetExtension(fileName);
		    ext = ext.ToLower();
		    if (ext.Contains("cmp"))
	        {
	            //binary
	            //all profiles are exactly 4 k
	            Stream stream = new FileStream(fileName, FileMode.OpenOrCreate);
	            BinaryWriter writer = new BinaryWriter(stream);
	            writer.Write(new byte[4096]);
	            writer.Flush();
	            
	            writer.Seek(0,SeekOrigin.Begin);
	            writer.Write(this.Header, 0, CM_HEADER_SIZE);
	            
	            writer.Seek(CM_WINBOARD_OR_CM_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.IsWinboard);
	            
	            writer.Seek(CM_VERSION_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.Version);
	            
	            writer.Seek(CM_SHOW_ELO_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.ShowElo);
	            
	            writer.Seek(CM_PONDER_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.Ponder);
	            
	            //convert to 0-9
	            writer.Seek(CM_TABLESIZE_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.TtSize);
	            
	            writer.Seek(CM_ENDGAMEDB_OFFSET,SeekOrigin.Begin);
	            writer.Write(1);
	            
	            writer.Seek(CM_ELO_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.Elo);
	            
	            writer.Seek(CM_GM_GROUP_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.IsGM);
	            
	            writer.Seek(CM_ATTACKDEFENSE_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.AttackDefense);
	            
	            writer.Seek(CM_STRENGTH_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.Sop);
	            
	            writer.Seek(CM_RANDOMNESS_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.Rand);
	            
	            //this value is unknown but never changes
	            writer.Seek(CM_UNKNOWN_OFFSET,SeekOrigin.Begin);
	            writer.Write(0x00000064);
	            
	            writer.Seek(CM_MAXSEARCHDEPTH_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.MaxDepth);
	            
	            writer.Seek(CM_SELECTIVESEARCH_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.SelSearch);
	            
	            writer.Seek(CM_CONTEMPT_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.Contempt);
	            
	            writer.Seek(CM_MATERIALPOSITIONAL_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.MatPos);
	            
	            writer.Seek(CM_OWNCONTROLOFCENTER_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnCoC);
	            
	            writer.Seek(CM_OPPCONTROLOFCENTER_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppCoC);
	            
	            writer.Seek(CM_OWNMOBILITY_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnMob);
	            
	            writer.Seek(CM_OPPMOBILITY_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppMob);
	            
	            writer.Seek(CM_OWNKINGSAFETY_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnKS);
	            
	            writer.Seek(CM_OPPKINGSAFETY_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppKS);
	            
	            writer.Seek(CM_OWNPASSEDPAWNS_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnPP);
	            
	            writer.Seek(CM_OPPPASSEDPAWNS_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppPP);
	            
	            writer.Seek(CM_OWNPAWNWEAKNESS_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnPW);
	            
	            writer.Seek(CM_OPPPAWNWEAKNESS_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppPW);
	            
	            writer.Seek(CM_OWNQUEEN_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnQ);
	            
	            writer.Seek(CM_OPPQUEEN_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppQ);
	            
	            writer.Seek(CM_OWNROOK_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnR);
	            
	            writer.Seek(CM_OPPROOK_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppR);
	            
	            writer.Seek(CM_OWNBISHOP_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnB);
	            writer.Seek(CM_OPPBISHOP_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppB);
	            
	            writer.Seek(CM_OWNKNIGHT_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnN);
	            writer.Seek(CM_OPPKNIGHT_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppN);
	            
	            writer.Seek(CM_OWNPAWN_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OwnP);
	            
	            writer.Seek(CM_OPPPAWN_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.OppP);
	            
	            writer.Seek(CM_SEX_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.Sex);
	            
	            writer.Seek(CM_AGE_OFFSET,SeekOrigin.Begin);
	            writer.Write(this.Age);
	            
	            writer.Seek(CM_OPENINGBOOK_OFFSET,SeekOrigin.Begin);
	            byte[] b = Program.getBytesFromString(this.OpeningBook);
	            writer.Write(b);
	            
	            writer.Seek(CM_IMAGE_OFFSET,SeekOrigin.Begin);
	            b = Program.getBytesFromString(this.Image);
	            writer.Write(b);
	            
	            writer.Seek(CM_SHORTPLAYSTYLE_OFFSET,SeekOrigin.Begin);
	            b = Program.getBytesFromString(this.ShortPlayingStyle);
	            writer.Write(b);
	            
	            writer.Seek(CM_BIOGRAPHY_OFFSET,SeekOrigin.Begin);
	            b = Program.getBytesFromString(this.Biography);
	            writer.Write(b);
	            
	            writer.Seek(CM_LONGPLAYSTYLE_OFFSET,SeekOrigin.Begin);
	            b = Program.getBytesFromString(this.LongPlayingStyle);
	            writer.Write(b);
	            
	            writer.Seek(CM_WINBOARDENGINEPATH_OFFSET,SeekOrigin.Begin);
	            b = Program.getBytesFromString(this.Winboard);
	            writer.Write(b);
	            
	            writer.Flush();
	            writer.Close();
	        }
		    else
		    {
		        //text
		        string str = this.toIniString();
    			
    			StreamWriter writer = new StreamWriter(fileName);
    			writer.WriteLine(str);
    			writer.Flush();
    			writer.Close();
    	    }
		}
    }
}
