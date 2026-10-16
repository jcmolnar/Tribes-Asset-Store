
$GuiModeCommand    = 2;
$LastControlObject = 0;

function Observer::triggerDown(%client)
{
}

function Observer::orbitObjectDeleted(%cl)
{
}

function Observer::leaveMissionArea(%cl)
{
}

function Observer::enterMissionArea(%cl)
{
}

function Observer::triggerUp(%client)
{
   if(%client.observerMode == "dead")
   {
      if(%client.dieTime + $Server::respawnTime < getSimTime())
      {
         if(Game::playerSpawn(%client, true))
         {
            %client.observerMode = "";
            Observer::checkObserved(%client);
         }
      }
   }
   else if(%client.observerMode == "observerOrbit")
      Observer::nextObservable(%client);
   else if(%client.observerMode == "observerFly")
   {
      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   }
   else if(%client.observerMode == "justJoined")
   {
      %client.observerMode = "";
      Game::playerSpawn(%client, false);
   }
   else if(%client.observerMode == "pregame" && $Server::TourneyMode)
   {
      if($CountdownStarted)
         return;

      if(%client.notready)
      {
         %client.notready = "";
         MessageAll(0, Client::getName(%client) @ " is READY.");
         if(%client.notreadyCount < 3)
            bottomprint(%client, "<f1><jc>Waiting for match start (FIRE if not ready).", 0);
         else 
            bottomprint(%client, "<f1><jc>Waiting for match start.", 0);
      }
      else
      {
         %client.notreadyCount++;
         if(%client.notreadyCount < 4)
         {
            %client.notready = true;
            MessageAll(0, Client::getName(%client) @ " is NOT READY.");
            bottomprint(%client, "<f1><jc>Press FIRE when ready.", 0);
         }
         return;
      }
      Game::CheckTourneyMatchStart();
   }
}

function Observer::jump(%client)
{
   if(%client.observerMode == "observerFly")
   {
      %client.observerMode = "observerOrbit";
      %client.observerTarget = %client;
      Observer::nextObservable(%client);
   }
   else if(%client.observerMode == "observerOrbit")
   {
		bottomprint(%client, "", 0);
      %client.observerTarget = "";
      %client.observerMode = "observerFly";

      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   }
}

function Observer::isObserver(%clientId)
{
   return %clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly";
}

function Observer::enterObserverMode(%clientId)
{
   if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
      return false;
   Client::clearItemShopping(%clientId);
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   Client::setOwnedObject(%clientId, -1);
   Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %clientId.observerMode = "observerOrbit";
   GameBase::setTeam(%clientId, -1);
   Observer::jump(%clientId);
   remotePlayMode(%clientId);
   return true;
}

function Observer::checkObserved(%client) {
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
      if(%cl.observerTarget == %client) {
         if(%cl.observerMode == "observerOrbit")
			setObsOrbit(%cl, %client, 5, 5, 5);
         else if(%cl.observerMode == "commander")
   		    Observer::setOrbitObject(%cl, %client, -3, -3, -3);
      }
   }
}

function setObsOrbit(%c, %t, %x, %y, %z) {
	if(%c.obsmode == "Fixed")
		Observer::setOrbitObject(%c, %t, %x, %y, %z);
	else if(%c.obsmode == "1stPerson")
		Observer::setOrbitObject(%c, %t, -3, -1, -0);
	else 
		Observer::setOrbitObject(%c, %t, -%x, -%y, -%z);
}

function Observer::setTargetClient(%client, %target) {
   if(%client.observerMode != "observerOrbit") return false;
   %owned = Client::getOwnedObject(%target);
   if(%owned == -1) return false;
	setObsOrbit(%client, %target, 5, 5, 5);
   	bottomprint(%client, "<jc><f2>Observing " @ Client::getName(%target) @ ".", 0);
   	%client.observerTarget = %target;
   return true;
}

function Observer::nextObservable(%client)
{
   %lastObserved = %client.observerTarget;
   %nextObserved = Client::getNext(%lastObserved);
   %ct = 128;  // just in case
   while(%ct--)
   {
      if(%nextObserved == -1)
      {
         %nextObserved = Client::getFirst();
         continue;
      }
      %owned = Client::getOwnedObject(%nextObserved);
      if(%nextObserved == %lastObserved && %owned == -1)
      {
         Observer::jump(%client);
         return;
      }
      if(%owned == -1)
      {
         %nextObserved = Client::getNext(%nextObserved);
         continue;
      }
      Observer::setTargetClient(%client, %nextObserved);
      return;
   }
   Observer::jump(%client);
}

function Observer::prevObservable(%client)
{
}

function remoteSCOM(%clientId, %observeId)
{
   if (%observeId != -1)
   {
      if (Client::getTeam(%clientId) == Client::getTeam(%observeId) &&
         (%clientId.observerMode == "" || %clientId.observerMode == "commander") && Client::getGuiMode(%clientId) == $GuiModeCommand)
      {
         Client::limitCommandBandwidth(%clientId, true);
         if(%clientId.observerMode != "commander")
         {
            %clientId.observerMode = "commander";
	         %clientId.lastControlObject = Client::getControlObject(%clientId);
         }
	      Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		   Observer::setOrbitObject(%clientId, %observeId, -3, -3, -3);
         %clientId.observerTarget = %observeId;
         Observer::setDamageObject(%clientId, %clientId);
      }
   }
   else
   {
      Client::limitCommandBandwidth(%clientId, false);
      if(%clientId.observerMode == "commander")
      {
         Client::setControlObject(%clientId, %clientId.lastControlObject);
		   %clientId.lastControlObject = "";
         %clientId.observerMode = "";
         %clientId.observerTarget = "";
	   }
   }
}


function Admin::changeMissionMenu(%clientId) { 
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = 1; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > 8) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more 8"); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
			%index++; 
		} 
	}
} 

function processMenuCMType(%clientId, %options)
{

   if(getWord(%options, 0) == "more") { %first = getWord(%options, 1); processMenuCMoo(%clientId, %first); return; }

   %curItem = 0;
   %option = getWord(%options, 0);
   %first = getWord(%options, 1);
   Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
   
   for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
   {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
         break;
      }
      Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
   }
}

function processMenuCMoo(%clientId, %first) {

	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = %first; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > %first + %index) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more " @ %first + %index); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
			%index++; 
		} 
	}
}


function processMenummisc(%clientId, %option) { 
	%o = getWord(%option, 0); 
	%extra = getWord(%option, 1); 
	if(%o == "obsm") {
		if(%clientId.obsmode == "") %clientId.obsmode = "Free";
		Client::buildMenu(%clientId, "Current mode: " @ %clientId.obsmode, "mmisc", true); 
		Client::addMenuItem(%clientId, "1Free", "setmode Free"); 
		Client::addMenuItem(%clientId, "2Fixed", "setmode Fixed"); 
		Client::addMenuItem(%clientId, "31st Person", "setmode 1stPerson"); 
	} else if(%o == "setmode") {
		if(%clientId.obsmode == %extra)
			Client::sendMessage(%clientId, 0,"Your Observer Mode is already set to " @ %extra @ "."); 		
		else {
			%clientId.obsmode = %extra;
			if(%clientId.observerMode == "observerOrbit") setObsOrbit(%clientId, %clientId.observerTarget, 5, 5, 5);
			Client::sendMessage(%clientId, 0,"Your Observer Mode has been set to " @ %extra @ "."); 
		}		
	} else if(%o == "toggled") {
		if ($DuelModeOff[%clientId]) {
			client::sendmessage(%clientId,0,"You have turned on duels.");
			$DuelModeOff[%clientId] = false;
		} else {
			client::sendmessage(%clientId,0,"You have turned off duels.");
			$DuelModeOff[%clientId] = true;
		}
	} else if(%o == "toggledt") {
		$DuelAlive[%clientId] = false;
		if ($DuelTModeOff[%clientId]) {
			if($DuelStart) {
				centerprint(%clientId, "<jc><f1>You have enabled Duel Tournament Mode.\n\n<f2>A tournament is currently in progress, please wait and you will join in when it is complete.", 20);
				Client::sendMessage(%clientId,0,"You have enabled Duel Tournament Mode. A tournament is currently in progress, please wait and you will join in when it is complete.");
			} else {
				Client::sendMessage(%clientId,0,"You have enabled Duel Tournament Mode.");
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f1>Choose your weapons from the TAB menu.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
				$DuelAlive[%clientId] = true;
				%clientId.notready = true;
			}
			$DuelTModeOff[%clientId] = false;
		} else {
			if($DuelStart) {
				centerprint(%clientId, "<jc><f2>You have been removed from the current tournament!\n\n<f1>You have disabled Duel Tournament Mode. You will not be entered in any tournaments.", 20);
				messageall(1, Client::getName(%clientId) @ " has chosen to be removed from the tournament!~waccess_denied.wav");
			} else
				centerprint(%clientId, "<jc><f1>You have disabled Duel Tournament Mode. You will not be entered in any tournaments.", 20);
			client::sendmessage(%clientId,0,"You have disabled Duel Tournament Mode. You will not be entered in any tournaments.~waccess_denied.wav");
			$DuelTModeOff[%clientId] = true;
			CheckPartners();
		}
	}
}
