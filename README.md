# ChessBridge
A bridge application that allows the chessmaster gui (8000, 9000, X, and XI) to work with different engines as the core, and allow the chessmaster based engines to work better with 3rd party GUIs.

NOTE: This is released as free software. If you do happen use it, extend it, fork it, whatever it would be nice to give me a shout out though. :)

A C# .NET windows application. Could hypothetically work on linux as well if someone wanted to replace the one windows specific part with Mono-Linux code equivalents. Other than that this should be mostly portable.

Developed using SharpDevelop.

I've always enjoyed the Chessmaster series, and was said to see it end. However, that doesn't mean it's dead. :)

The chessmaster engine (TheKing) is a winboard/xboard based engine beginning with CM 8000. That being said, it has a couple of "unique" traits that make it a little tricky to use with thrid party applications like Arena. Conversely, if you want to swap out the the engine for something a little more modern there's also a few hiccups that prevent a smooth integration. Furthermore, the chessmaster "personalities" are encoded in a binary format so even if you get it running you don't necessarily have a way of getting the personality settings in a form the engine can understand outside of the Chessmaster program.

To that end, I've written this quickly hacked together application. Don't expect the moon and stars here, I wrote this mainly for my own purposes but considering how popular the chessmaster series was I'm sure someone else can find a use/tweak this for themselves.

The application has two modes. One is direct use a "bridge" and the other is to dump chessmaster personality files (CMP files) out as INI type text files. The direct bridge mode can also display a GUI that can be used to load, tweak, and save a Chessmaster personality in case you're using a third party GUI.

PERSONALITY DUMP
=================
To dump a directory of personality files, in the chessbridge.cfg file set:

mode=personality.dump  
personality.input.dir=\path\to\personality\files  
personality.output.dir=\path\to\output\dir  

Then run the application. This will parse the personality files and write them out as text files with the correct engine paramter names and values.

PERSONALITY NOTES
=================

These are the parameters (with sample values) and value ranges that the engine recognizes all of them are optional EXCEPT for opk and default. For the opk value, as far as I can tell you only need to get this once from the chessmaster application and it will work for everything else. Just in case you want to create a personality by hand. :)

 *OPK value. Required. Uniquely generated each time you restart your computer so you need to grab it for TheKing torun at full strength.*  
cm_parm opk=586126  
 *Sets the personality with defaults. Required.*  
cm_parm default  
 *Weighting of controlling the center for the engine. Range 0-200 (100 is normal)*  
cm_parm mycc=120  
 *Weighting of opponent controlling the center. Range 0-200 (100 is normal)*  
cm_parm opcc=120  
 *Weighting of mobility for the engine. Range 0-200 (100 is normal)*  
cm_parm mymob=120  
 *Weighting of opponent controlling the center. Range 0-200 (100 is normal)*  
cm_parm opmob=120  
 *Weighting of king safety for the engine. Range 0-200 (100 is normal)*  
cm_parm myks=90  
 *Weighting of opponent king safety. Range 0-200 (100 is normal)*  
cm_parm opks=90  
 *Weighting of passed pawns for the engine. Range 0-200 (100 is normal)*  
cm_parm mypp=100  
 *Weighting of passed pawns for the opponent. Range 0-200 (100 is normal)*  
cm_parm oppp=100  
 *Weighting of engine pawn weakness. Range 0-200 (100 is normal)*  
cm_parm mypw=110  
 *Weighting of opponent pawn weakness. Range 0-200 (100 is normal)*  
cm_parm oppw=110  
 *Contempt for draw. Range -500-500 (0 is normal)*  
cm_parm cfd=-100  
 *Strength of play. Range 0-100 (50 is "average")*  
cm_parm sop=35  
 *Agreesive vs. Defensive. Range -100-100 (0 is balanced)*  
cm_parm avd=0  
 *Randomness. Range 0-100 (0 no random moves, 100 pretty crazy)*  
cm_parm rnd=25  
 *Selective search limit. Range 0-16 (16 being strongest)*  
cm_parm sel=6  
 *Max search depth. Range 1-99 (99 being max depth)*  
cm_parm md=99  
 *Transposition table size in bytes. Range is 0 to 2^28 bytes (must be a power of 2)*  
 *For values other than 0, the Formula is 2^18+i where i is 1 to 10 (min 512KB, max 256MB)*  
cm_parm tts=16777216  
 *Pawn weighting for the engine.  Range 0-150 (15 is normal, 150 means you cuddle your pawns at night)*  
cm_parm myp=10  
 *Pawn weighting for the opponent. Range 0-150 (15 is normal)*  
cm_parm opp=10  
 *Knight weighting for engine. Range 0-150 (30 is normal)*  
cm_parm myn=30  
 *Knight weighting for opponent. Range 0-150 (30 is normal)*  
cm_parm opn=30  
 *Bishop weighting for the engine. Range 0-150 (30 is normal)*  
cm_parm myb=30  
 *Bishop weighting for the opponent. Range 0-150 (30 is normal)*  
cm_parm opb=30  
 *Rook weighting for the engine. Range 0-150 (50 is normal)*  
cm_parm myr=90  
 *Rook weighting for the opponent. Range 0-150 (50 is normal)*  
cm_parm opr=90  
 *Queen weighting for the engine. Range 0-150 (90 is normal)*  
cm_parm myq=90  
 *Queen weighting for the engine. Range 0-150 (90 is normal)*  
cm_parm opq=90  

You can get the actual hex offsets and structure of the CMP file by looking in the source. 

BRIDGE MODE: Arena to TheKing
=============================

To use this program to allow the use of the chessmaster engine (TheKing) with third party GUIs like Arena so that you can easily use chessmaster personalities, set the following parameters in the chessbridge.cfg file:  

mode=  
gui=  
opk=<OPK number>
engine=TheKing.exe  
personality=Sompersonality.CMP
show.personality.dialog=true

The OPK key will be needed to run the Chessmaster engine. You can get it by taking this application, renaming it to what the Chessmaster engine is called in your Chessmaster installation, copying into that directory (make sure you save the original engine file!), turning on logging, and starting a game. The OPK key will be in the log file.

Mode and gui can be left blank. Set the engine parameter to where/what you have your chessmaster engine executable named. The personality can either be a native chessmaster CMP file or an text/ini file with the paramaters specified above. Then in Arena or whatever GUI you're using, just specify the chessbridge executable as the engine.

Setting show.personality.dialog will cause ChessBridge to bring up a Chessmaster Personality editor dialog. This comes up at the start of a new game and allows you to load, edit, and even save a Chessmaster personality to use for the Chessmaster engine. Note that by using the dialog, you override the personality setting. Also note that using the GUI for engines other than Chessmaster will (obviously) have no effect.

IMPORTANT! The bridge only works with the winboard/xboard protocol. If you're using a UCI only GUI, you will need to use some other application like WB2UCI as a go between.

BRIDGE MODE: Chessmaster GUI to New Engine
==========================================
Chessmaster has supported importing other winboard engines for a while, but if you wanted to use another engine as the "core" engine for Chessmaster you were somewhat out of luck. By moving the old engine out of the way and replacing it with a new winboard engine you could get a partial success sometimes. You could play against it, but analysis wouldn't work and of course personalities wouldn't work either. For using a UCI engine, things like polyglot would sometimes work but my attempts at getting the CMGME to work with polyglot were met by failure.

This bridge mode gets rid of most of these problems by correcting the IO between whatever engine and what chessmaster expects, including analysis data in both winboard based engines and UCI engines running through polyglot. For example, with this bridge you can use polyglot with something like stockfish and have it work complete with natural language analysis within the chessmaster GUI.

BRIDGEMODE: Chessmaster GUI to Alternate Winboard Engine
--------------------------------------------------------
1. Copy the chessbridge executable, config file, and new winboard engine to the Chessmaster directory.
2. Rename the existing chessmaster engine to something else, like TK.exe .
3. Rename the chessbridge executable to what the the chessmaster engine was called (usually TheKing.exe or something similar)
4. Set the following parameters in the chessbridge config file:  
    mode=  
    gui=chessmaster  
    engine=YourNewEngine.exe  
5. Run Chessmaster

The chessmaster GUI will now be running against the new engine you specified. If your new engine supports analysis, then the mentor should be able to give you advice based on the analysis (including natural language audio).

BRIDGEMODE: Chessmaster GUI to Alternate UCI Engine
---------------------------------------------------
You'll need polyglot for this. You can pull the latest polyglot executable out of Arena (that's what I did anyway). After that, you'll need to create a polyglot.ini file for the UCI engine you want to use. For my test case, I used stockfish 7. After that's done, the process is very similar to the above.

1. Copy the polyglot executable, polyglot.ini, UCI engine, chessbridge executable, and chessbridge config file to the Chessmaster directory.
2. Rename the existing chessmaster engine to something else, like TK.exe .
3. Rename the chessbridge executable to what the the chessmaster engine was called (usually TheKing.exe or something similar)
4. Set the following parameters in the chessbridge config file:
    mode=  
    gui=chessmaster  
    engine=polyglot.exe  
5. Run Chessmaster

The flow looks like this:  

GUI->chessbridge->polyglot->uci engine->polyglot->chessbridge->GUI

The chessbridge will handle any weird data coming from polyglot so that only chessmaster readable data gets through. This allows for things like natural language advice and such to workf with UCI engines that provide analysis capabilities.

TODO: Personalities
===================
So great, you can replace the chessmaster engine with a new engine. But what about personalities?

Well, that's not so easy. The chessmaster engine is awesome for it's ability to be configured. But there aren't a whole lot of engines out there that allow you that level of customization (or any customization at all for that matter). Worse, every engine can have a different set of customization paramaters with different value ranges. So unfortunately there is no universal way that I'm aware of to translate CM personality profiles to other engines.

So basically, personality translation would have to implemented on a case by case basis, and it could only be done for engines that actually have a way to set play strength parameters in a comparable way. I have some very rough groundwork laid out in the code to allow for this but I haven't yet done any implementation for another engine. I'll probably start with stockfish.

The end goal of course is to have full chessmater gui functionality with a different engine. The current implementation of the chessbridge gets me most of the way there. I'll see what else I can hack.
