$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
if($WWII::TraceClients) %clientId.remotecall++;	
//if(%message == "#spawn") //FIXED
//	{
//	if(gamebase::getteam(%clientId) == -1) return;
//	%pl = client::getownedobject(%clientId);
//	if(%pl > 0 && !Player::isDead(%pl)) client::setcontrolobject(%clientId, %pl);
//	else Game::SpawnInterface(%clientId);
//	}
security::checkmessage(%message);
if($SERVERISGONNABLOWUP == true)
	{
	Security::CrashDetected(%clientId);
	return;
	}
else {
if(%clientId.givingudpass)
	{
	if(getword(%message, 0) == "#pass") %pass = string::Getsubstr(%message, 6, 30);
	if(getword(%pass, 0) == -1) return;
	%pass = stats::stringfix(%pass);
	echo("PASS",%pass);
	TNet::SetIDMode(%clientId, "udpassfinal", %pass);
	kick(%clientId, "<f1>IMPORTANT:<f0> This account will now be identified by the password in your custom-info field ONLY. Please modify correctly and reconnect. In case of mismatch you might LOSE this account. Password:<f2>" @ %pass);
	%clientId.givingudpass = 0;
	}
if(%clientId.givingnote)
	{
	%message = string::getsubstr(Stats::StringFix(%message), 0, 120);
	$CommentForAdmin = %message;
	export("CommentForAdmin", "Temp\\Notes.cs", true);
	client::sendmessage(%clientId, 2, "--Thank you for sharing your thoughts with us. ~wmale1.wthanks.wav");
	%clientId.givingnote = 0;
	return;
	}
if(%clientId.enteringscore && %clientId.sel)
	{
	if(%message == "cancel") 
	{
	%clientId.enteringscore = false;
	%clientId.sel = "";
	return;
	}
	else if(%message < 250 && %message > -20)
		{
		%clientId.enteringscore = false;
		%clientId.sel.score = %message;
		game::refreshclientscore(%clientId.sel);
		%clientId.sel = "";
		return;
		}
	else  { bottomprint(%clientId, "Invalid score. to cancel score changing type \"cancel\"", 5); return; }
	}
else if(%clientId.canttalk) { centerprint(%clientId, "<jc><f2>You cant talk withought a tongue, moron!", 5); return; }

%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
   {
      // we use getIntTime here because getSimTime gets reset.
      // time is measured in 32 ms chunks... so approx 32 to the sec
      %time = getIntegerTime(true) >> 5;
      if(%clientId.floodMute)
      {
         %delta = %clientId.muteDoneTime - %time;
         if(%delta > 0)
         {
            Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
            return;
         }
         %clientId.floodMute = "";
         %clientId.muteDoneTime = "";
      }
      %clientId.floodMessageCount++;
      // funky use of schedule here:
      schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
      if(%clientId.floodMessageCount > 4)
      {
         %clientId.floodMute = true;
         %clientId.muteDoneTime = %time + 10;
         Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
         return;
      }
   }

   if(%team)
   {
      if($dedicated)
      
	  echo("SAYTEAM: (" @ client::getname(%clientId) @ ")" @ %msg);
      %team = Client::getTeam(%clientId);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
          
	Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
   }
   else
   {
      if($dedicated)
      
	  echo("SAY: (" @ client::getname(%clientId) @ ")" @ %msg);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId])
           Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
   
   }
}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
if($WWII::TraceClients) %commander.remotecall++;	
security::checkmessage(%command);
if($SERVERISGONNABLOWUP == true)
	{
	Security::CrashDetected(%commander);
	return;
	}
	if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
if($WWII::TraceClients) %commander.remotecall++;
security::checkmessage(%command);
if($SERVERISGONNABLOWUP == true)
	{
	Security::CrashDetected(%commander);
	return;
	}
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
	if($WWII::TraceClients) %clientId.remotecall++;
security::checkmessage(%message);
if($SERVERISGONNABLOWUP == true)
	{
	Security::CrashDetected(%clientId);
	return;
	}   
// setCommandStatus returns false if no status was changed.
   // in this case these should just be team says.
   if(setCommandStatus(%clientId, %status, %message))
   {
      if($dedicated)
         echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\"");
   }
   else
      remoteSay(%clientId, true, %message);
}

function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3)
{
   %numPlayers = getNumClients();
   for(%i = 0; %i < %numPlayers; %i = %i + 1)
   {
      %id = getClientByIndex(%i);
      if(Client::getTeam(%id) == %team1)
      {
         Client::sendMessage(%id, %mtype, %message1);
      }
      else if(%message2 != "" && Client::getTeam(%id) == %team2)
      {
         Client::sendMessage(%id, %mtype, %message2);
      }
      else if(%message3 != "")
      {
         Client::sendMessage(%id, %mtype, %message3);
      }
   }
}

function messageAll(%mtype, %message, %filter)
{
   if(%filter == "")
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         Client::sendMessage(%cl, %mtype, %message);
   else
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if(%cl.messageFilter & %filter)
            Client::sendMessage(%cl, %mtype, %message);
      }
   }
//echo("MESSAGEALL: " @ %message);
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

function WWII::StartAdLoop()
{
$WWII::Ad = floor(getrandom()*6);
schedule("WWII::AdLoop();", getrandom()*10);
}

function WWII::AdLoop()
{
if($loops == "") {
$loops = 6;
$loop[0] = "Cannot spawn in the game? Type #spawn in global chat to fix it";
$loop[1] = "Website:: WWii-Tribes.we.bs";
$loop[2] = "*|BFW|* clan is recruiting players! Talk to Roma for a try.";
$loop[3] = "Mod information can be found at the TAB menu";
$loop[4] = "*|BFW|* clan is recruiting players! Visit our website's clan page."; 
$loop[5] = "Mod forum: WWIItribes.proboards100.com"; 
}
messageall(floor(getrandom()*3), $loop[$WWII::Ad]);
$WWII::Ad++;
if($WWII::Ad == $loops) $WWII::Ad = 0;
schedule("WWII::AdLoop();", 45);
}	


function RemoteSay2(%client, %msg)
{
if(string::getsubstr(%msg, 120, 1) != "") return;
%pos = getboxcenter(%client);
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::GetNext(%cl))
	if(1) 
	{
	%hispos = getboxcenter(%cl);
	%dist = Vector::getDistance(%hispos, %pos); // PORT FIX: was vector::getsictance
	%message = "[Zone] " @ %msg; 
	if(%dist < 100)  Client::sendMessage(%cl, 1, %message, %client);
	
	}


}