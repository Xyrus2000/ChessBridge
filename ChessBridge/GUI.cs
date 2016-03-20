/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/19/2016
 * Time: 9:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ChessBridge
{
	/// <summary>
	/// Description of Engine.
	/// </summary>
	public interface GUI
	{
		string getId();
		
		string parsePersonality(string file);
		
		void dumpPersonalities(string engineDst, string inputDir, string outputDir);
		
		string translatePersonalityFrom(string engineDst, string personality);
		
		string translateToEngine(string input);
		
		string translateFromEngine(string output);
	}
}
