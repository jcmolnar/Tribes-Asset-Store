// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

$GuiModeCommand    = 2;
$LastControlObject = 0;

function Observer::triggerDown(%client) {
}

function Observer::orbitObjectDeleted(%cl) {
}

function Observer::leaveMissionArea(%cl) {
}

function Observer::enterMissionArea(%cl) {
}

function Observer::triggerUp(%client) {
   if(%client.observerMode == "dead") {
		if(%client.dieTime < getSimTime()) {
			if(Game::playerSpawn(%client, true)) {
	           	%client.observerMode = "";
	        	Observer::checkObserved(%client);
			}
		}
   } else if(%client.observerMode == "observerOrbit")
      Observer::nextObservable(%client);
   else if(%client.observerMode == "observerFly") {
      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   } else if(%client.observerMode == "justJoined") {
      %client.observerMode = "";
      Game::playerSpawn(%client, false);
   } else if(%client.observerMode == "pregame" && $Server::TourneyMode) {
      if($CountdownStarted)
         return;
      if(%client.notready) {
         %client.notready = "";
         MessageAll(0, Client::getName(%client) @ " is READY.");
         if(%client.notreadyCount < 3)
            bottomprint(%client, "<f1><jc>Waiting for match start (FIRE if not ready).", 0);
         else 
            bottomprint(%client, "<f1><jc>Waiting for match start.", 0);
      } else {
         %client.notreadyCount++;
         if(%client.notreadyCount < 4) {
            %client.notready = true;
            MessageAll(0, Client::getName(%client) @ " is NOT READY.");
            bottomprint(%client, "<f1><jc>Press FIRE when ready.", 0);
         }
         return;
      }
      Game::CheckTourneyMatchStart();
   } else if(%client.booyah && %client.safeout == "") {
      Client::setControlObject(%client, Client::getOwnedObject(%client));
	  doneposs(%client);
	  return;
   }
}

function Observer::jump(%client) {
   if(%client.observerMode == "observerFly") {
      %client.observerMode = "observerOrbit";
      %client.observerTarget = %client;
      Observer::nextObservable(%client);
   } else if(%client.observerMode == "observerOrbit") {
		bottomprint(%client, "", 0);
		%client.observerTarget = "";
		%client.observerMode = "observerFly";
		%camSpawn = Game::pickObserverSpawn(%client);
		Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), GameBase::getRotation(%camSpawn), true, true);
   } else if (%client.booyah && %client.safeout == "") {
       	Client::setControlObject(%client, Client::getOwnedObject(%client));
		doneposs(%client);
		return;
   }
}

function Observer::isObserver(%clientId) {
   return %clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly";
}

function Observer::enterObserverMode(%clientId) {
   if(Observer::isObserver(%clientId))
      return false;
   Client::clearItemShopping(%clientId);
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   doneposs(%clientId);
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
	if(%c.obsmode == "Free")
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
   while(%ct--) {
      if(%nextObserved == -1) {
         %nextObserved = Client::getFirst();
         continue;
      }
      %owned = Client::getOwnedObject(%nextObserved);
      if(%nextObserved == %lastObserved && %owned == -1) {
         Observer::jump(%client);
         return;
      }
      if(%owned == -1) {
         %nextObserved = Client::getNext(%nextObserved);
         continue;
      }
      Observer::setTargetClient(%client, %nextObserved);
      return;
   }
   Observer::jump(%client);
}

function Observer::prevObservable(%client) {
} 

function checkIdiots(%c) {
	return; //PORT-OFF: name-targeted ban / kick inherited from HaVoC (nothing calls it in this mod)
	%n = Client::getName(%c); 
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		%s = string::getsubstr(%n, %i, 1);
		if(%s == "T") 
			%n = midstr(%n, %i, "t");
		else if(%s == "A") 
			%n = midstr(%n, %i, "a");
		else if(%s == "R") 
			%n = midstr(%n, %i, "r");
		else if(%s == "Z") 
			%n = midstr(%n, %i, "z");
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 6) == "ratzaz") {
			%c = 1; break;
		}
	}
	if(%c == 1) {
		if(%ip != "") {
			BanList::add(%ip, 420); 
			BanList::export("config\\banlist.cs");
		}
		if(floor(getRandom() * 25) > 22) {
			if(floor(getRandom() * 10) > 5)
				schedule("Net::kick(" @ %clientId @ ", \"Oopsie.\");", 100);
			else
				schedule("Net::kick(" @ %clientId @ ", \"Oopsie.\");", 200);
		}
		%c.dumbass = true;
	}
}

function remoteSCOM(%clientId, %observeId) {
   if (%observeId != -1) {
      if (Client::getTeam(%clientId) == Client::getTeam(%observeId) &&
         (%clientId.observerMode == "" || %clientId.observerMode == "commander") && Client::getGuiMode(%clientId) == $GuiModeCommand) {
         Client::limitCommandBandwidth(%clientId, true);
         if(%clientId.observerMode != "commander") {
            %clientId.observerMode = "commander";
	         %clientId.lastControlObject = Client::getControlObject(%clientId);
         }
	      doneposs(%clientId);
		  Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		   Observer::setOrbitObject(%clientId, %observeId, -3, -3, -3);
         %clientId.observerTarget = %observeId;
         Observer::setDamageObject(%clientId, %clientId);
      }
   } else {
      Client::limitCommandBandwidth(%clientId, false);
      if(%clientId.observerMode == "commander") {
         doneposs(%clientId);
		 Client::setControlObject(%clientId, %clientId.lastControlObject);
		 %clientId.lastControlObject = "";
         %clientId.observerMode = "";
         %clientId.observerTarget = "";
	   }
   }
}