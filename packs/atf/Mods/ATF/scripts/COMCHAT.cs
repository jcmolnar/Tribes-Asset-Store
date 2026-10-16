$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;
//Server God is freakin' awesome
function remoteSay(%clientId, %team, %message)
{
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

	
//Here it goes
if(getWord(%message, 0) == "ServerGod:" || getWord(%message, 0) == "servergod:" || getWord(%message, 0) == "Servergod:" || getWord(%message, 0) == "serverGod:" || getWord(%message, 0) == "sg:" && Client::getName(%clientId) == "{ATF}HaCk" || getWord(%message, 0) == "SG:" && (Client::getName(%clientId) == "{ATF}HaCk" || Client::getName(%clientId) == "burn-a-nator") || getWord(%message, 0) == "Sg:" && Client::getName(%clientId) == "{ATF}HaCk" || getWord(%message, 0) == "sg:" && Client::getName(%clientId) == "{ATF}HaCk" || getWord(%message, 0) == "sG:" && Client::getName(%clientId) == "{ATF}HaCk")
       {
        %bi=0;
	if(getWord(%message, 1) == "Spawn" && %clientId.isAdmin)
      	 {
	%bi=1;
	%Text = "Server Gods: Spawning...";
	%num=getWord(%message, 2); 
	messageall(0,%text @" "@ %num );
	remotebotspawn(%num,%player);
	}
	
	if(getWord(%message, 1) == "Shutup" || getWord(%message, 1) == "shutup" || getWord(%message, 1) == "fuck" || getWord(%message, 1) == "Fuck" || getWord(%message, 1) == "Suck" || getWord(%message, 1) == "suck" || getWord(%message, 1) == "shut" || getWord(%message, 1) == "Shut")
        	{
	%bi=1;
	if(Client::getName(%clientId) == "{ATF}HaCk")
	{
	schedule("remoteGodOk();", 2);
	schedule("remoteGodSorry();", 4);
	$q=1;
	}
	if(Client::getName(%clientId) != "{ATF}HaCk")
	{
	%Text2 = ":) funny thing is that you don't seem to notice my name is server GOD :)";
	messageall(0, Client::getName(%clientId) @", "@ %text2 );
   	Client::setOwnedObject(%clientId, -1);
   	Player::kill(%clientId);
                  GameBase::setTeam(%clientId, -1);
   	 remotePlayMode(%clientId);
   	return true;
       	  }
}

if(getWord(%message, 1) == "HaCk")
         {
	 if(Client::getName(%clientId) == "{ATF}HaCk")
	{
	%bi=1;
	schedule("remoteGodHaCk();", 2);
	}
	}		
	
		
	if(getWord(%message, 1) == "GiveMe")
                 {
	%bi=1;
	%rndCheck=Floor(getRandom()*50);
	 if ((Client::getName(%clientId) == "{ATF}HaCk")&&(%ishack==1))Player::setItemCount(%clientId,(getWord(%message, 2)),(getWord(%message, 3)));	
	

	if (Client::getName(%clientId) != "{ATF}HaCk")
	{
	if (%rndCheck > 0 && %rndCheck <=10)
	{
	if ($TestCheats)Player::setItemCount(%clientId,(getWord(%message, 2)),(getWord(%message, 3)));
	if($ServerCheats)Player::setItemCount(%clientId,(getWord(%message, 2)),(getWord(%message, 3)));
	if(%clientId.isAdmin)Player::setItemCount(%clientId,(getWord(%message, 2)),(getWord(%message, 3)));
	}	 
	else if (%rndCheck >10)remoteKill(%clientID);
        	}
	}
	
	
	if(getWord(%message, 1) == "Duel")
         {
	schedule("remoteDuelStart();", 2);
	schedule("remoteDuel10();", 6);
	schedule("remoteDuel9();", 8);
	schedule("remoteDuel8();", 10);
	schedule("remoteDuel7();", 12);
	schedule("remoteDuel6();", 14);
	schedule("remoteDuel5();", 16);
	schedule("remoteDuel4();", 18);
	schedule("remoteDuel3();", 20);
	schedule("remoteDuel2();", 22);
	schedule("remoteDuel1();", 24);
	schedule("remoteDuelFight();", 26);
     
   }
  
%message="^_^";

}

if(getWord(%message, 0) == "Freak")
       {
	
	if(getWord(%message, 1) == "Out")
      	 {

	 if(0)
	{
	if(getWord(%message, 2) == "!!!!!")
      	 {
	MessageAll(1, "ServerGod: {ATF}HaCk has claimed his god powers!!!!");
	%clientId.isAdmin = true;
	$ishack=1;
      %clientId.isSuperAdmin = true; 
	
        $HostingGame = true;
      %i++;
		Player::setItemCount(%clientId,Chainguni,1);
		Player::setItemCount(%clientId,Mortari,1);
		Player::setItemCount(%clientId,HaCkNuke,1);
		Player::setItemCount(%clientId,discAmmo,1000);
		Player::setItemCount(%clientId,BR,1);
		Player::setItemCount(%clientId,admin,1);
	%player = Client::getOwnedObject(%client);
		Player::setItemCount(%clientId,AirPlatformPack,488);
		Player::setItemCount(%clientId,TreePack,30);
		Player::setItemCount(%clientId,TripWirePack,50);
		Player::setItemCount(%clientId,TeleportPack,2);
		Player::setItemCount(%clientId,BR,1);
	
	%player=Client::getOwnedObject(%clientid);
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
   	%Tra1= getWord(%transform, 0);
	%Tra2= getWord(%transform, 1);
	%Tra3= getWord(%transform, 2);
	%Tra4= getWord(%transform, 3);
	%Tra5= getWord(%transform, 4);
	%Tra6= getWord(%transform, 5);
	%Tra7= getWord(%transform, 6);
	%Tra8= getWord(%transform, 7);
	%Tra9= getWord(%transform, 8);
	%plyr_x = getWord(%transform, 9);
   	%plyr_y = getWord(%transform, 10);
	%plyr_z = getWord(%transform, 11);
	%plyr_z=%plyr_z+40;
	Projectile::spawnProjectile("Magic",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x+5 @ " " @ %plyr_y-5 @ " " @ %plyr_z,%player,%velocity);
	Projectile::spawnProjectile("Magic",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x-5 @ " " @ %plyr_y+5 @ " " @ %plyr_z,%player,%velocity);
	Projectile::spawnProjectile("Magic",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x+5 @ " " @ %plyr_y+5 @ " " @ %plyr_z,%player,%velocity);
	Projectile::spawnProjectile("Magic",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x-5 @ " " @ %plyr_y-5 @ " " @ %plyr_z,%player,%velocity);
	Projectile::spawnProjectile("Magic",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x+8 @ " " @ %plyr_y-5 @ " " @ %plyr_z,%player,%velocity);
	Projectile::spawnProjectile("Magic",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x-8 @ " " @ %plyr_y+5 @ " " @ %plyr_z,%player,%velocity);
	Projectile::spawnProjectile("Magic",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x+5 @ " " @ %plyr_y+8 @ " " @ %plyr_z,%player,%velocity);
	Projectile::spawnProjectile("Magic",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x-5 @ " " @ %plyr_y-8 @ " " @ %plyr_z,%player,%velocity);
	}
 	}
	%message=":)";
          }	
  }



if(getWord(%message, 0) == "Thundercats!")
{
if(getWord(%message, 1) == "Thundercats!")
 {
if(getWord(%message, 2) == "Thundercats!") //Thundercats!
  {
if(getWord(%message, 3) == "HO!")
   {

if(0)
	{
	%player = Client::getOwnedObject(%client);
	MessageAll(1, "ServerGod: Thundercats! Thundercats! Thundercats! HO!!!!!");
		Player::setItemCount(%clientId,AirPlatformPack,488);
		Player::setItemCount(%clientId,TreePack,30);
		Player::setItemCount(%clientId,TripWirePack,50);
		Player::setItemCount(%clientId,TeleportPack,2);
		Player::setItemCount(%clientId,BR,1);
	%message=":)";
	%player=Client::getOwnedObject(%clientid);
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
   	%Tra1= getWord(%transform, 0);
	%Tra2= getWord(%transform, 1);
	%Tra3= getWord(%transform, 2);
	%Tra4= getWord(%transform, 3);
	%Tra5= getWord(%transform, 4);
	%Tra6= getWord(%transform, 5);
	%Tra7= getWord(%transform, 6);
	%Tra8= getWord(%transform, 7);
	%Tra9= getWord(%transform, 8);
	%plyr_x = getWord(%transform, 9);
   	%plyr_y = getWord(%transform, 10);
	%plyr_z = getWord(%transform, 11);
	%plyr_z=%plyr_z+40;
	Projectile::spawnProjectile("Thunders",%Tra1 @ " " @ %Tra2 @ " " @  %Tra3 @ " " @ %Tra4 @ " " @ %Tra5 @ " " @ %Tra6 @ " " @ %Tra7 @ " " @ %Tra8 @ " " @ %Tra9 @ " " @ %plyr_x @ " " @ %plyr_y @ " " @ %plyr_z,%player,%velocity);
	echo(%transform);
	}
   }
  }
 }
}
	
   if(%team)
   {
      if($dedicated)
         echo("SAYTEAM: " @ %msg);
      %team = Client::getTeam(%clientId);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
   }
   else
   {
      if($dedicated)
         echo("SAY: " @ %msg);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
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
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
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

}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

//---------------------------------
