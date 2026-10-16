//=======================Roma's super server security===================
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function Security::checkmessage(%msg)
{
if(string::getsubstr(%msg, 512, 1) != "") 	
{
	$SERVERISGONNABLOWUP = true;
	return;
	}
else {
	
if(string::getsubstr(%msg, 45, 1) != "") //more than 25 invalid chars result in crash attempt
	{
	
	%r1 = floor(getrandom() * 40);
	%r2 = floor(getrandom() * 40);
	%r3 = floor(getrandom() * 40);  //make random nums from 40 char nums that EXIST
	%r4 = floor(getrandom() * 40);
	%r5 = floor(getrandom() * 40);
	
	%s1 = string::getsubstr(%msg, %r1, 1);
	%s2 = string::getsubstr(%msg, %r2, 1);
	%s3 = string::getsubstr(%msg, %r3, 1);   //get the char defined by random num
	%s4 = string::getsubstr(%msg, %r4, 1);
	%s5 = string::getsubstr(%msg, %r5, 1);
	
	%a1 = escapestring(%s1);
	%a2 = escapestring(%s2);
	%a3 = escapestring(%s3);  //escapestring * 5, less lag, no crash. convert hex to readable
	%a4 = escapestring(%s4);
	%a5 = escapestring(%s5);

	if(string::findsubstr(%a1, "\\x") != -1 || string::findsubstr(%a1, "\\t") != -1 || string::findsubstr(%a1, "\\n") != -1) %chance++;
	if(string::findsubstr(%a2, "\\x") != -1 || string::findsubstr(%a2, "\\t") != -1 || string::findsubstr(%a2, "\\n") != -1) %chance++;
	if(string::findsubstr(%a3, "\\x") != -1 || string::findsubstr(%a3, "\\t") != -1 || string::findsubstr(%a3, "\\n") != -1) %chance++;
	if(string::findsubstr(%a4, "\\x") != -1 || string::findsubstr(%a4, "\\t") != -1 || string::findsubstr(%a4, "\\n") != -1) %chance++;
	if(string::findsubstr(%a5, "\\x") != -1 || string::findsubstr(%a5, "\\t") != -1 || string::findsubstr(%a5, "\\n") != -1) %chance++;
	//search for newlines,tabs and hexes. 	


	if(%chance == 5) $SERVERISGONNABLOWUP = true; //all random chars are invalid, destroy message
	}
		
}	
}

function Security::CrashDetected(%crasher)
{
Ban(%crasher, 3, "", 1); 
$SERVERISGONNABLOWUP = false; //All quiet now...
}

function Security::AntiSpam(%cl, %function)
{
%cl.tries++;
if(%cl.tries > 5) 
	{
	%cl.critical = true;
	ban(%cl, 4);
	messageall(1, client::getname(%cl) @ " was kicked for trying to use an exploit.");
	dbecho(1, "EXPLOIT: " @ %function @ " spam. id = " @ %cl);
	}
schedule(%cl @ ".tries = 0;", 0.5);
}

function Security::MenuHack(%cl)
{
echo(1, "EXPLOIT: Menu hack. id = " @ %cl);
messageall(1, client::getname(%cl) @ " was kicked for playing with the menu.");
ban(%cl, 4, "");
}

function Security::NameExploit(%cl)
{
echo(1, "NAME EXPLOIT: " @ Stats::StringFix(client::getname(%cl)) @ " name. id = " @ %cl);
messageall(1, Stats::StringFix(client::getname(%cl)) @ " was banned for using invalid name.");
ban(%cl, 4, "");
}



//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//**************************************************************************************
//============================DANGER!! ROMA'S CLIENT CRASH FUNCTION=====================
//--------------------------------------------------------------------------------------
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function Server::TerminateClient(%targetId, %admin)
{
// PORT FIX: removed. This sent a player 256-byte strings of 0x98 to crash their game, and only
// worked for whoever was named "*|BFW|* Roma".
echo("WWII PORT: Server::TerminateClient is removed.");
}

function remoteheartbeat(%cl) { messageall(1, "error 032"); }

function Server::ClearBuffer()
{
deletevariables("Termination*");
}

$SpawnGlitch::List = "remotemenuntict remotemenussauct remotemenucoutct remotemenuntitct remotemenunginct remotemenuase remotemenuapchct"; 

function FixSpawnGlitch()
{
for(%x = 0; 1; %x++)
	{
	%curword = getword($SpawnGlitch::List, %x);
	if(%curword == -1) break;
	eval("function " @ %curword @ "(%a) { schedule(\"Game::SpawnInterface(%a);\",0.3); echo(\"SPAWN GLITCH FIXED! ROMA IS THE BEST!!!\"); }");
	}
}

FixSpawnGlitch();


function Security::InvalidMenu(%cl, %opt)
{
messageall(2, "Menu Error!");
kick(%cl, "Menu Error! please reconnect...");
}