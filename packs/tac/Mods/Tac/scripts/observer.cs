// - BW Admin Mod -
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
// - BW Admin Mod - Next Objective
   else if(%client.observerMode == "observerObjectiveOrbit")
      TAC::nextObsObj(%client);
// - BW Admin Mod -
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
// - BW Admin Mod - No more annoying ready messages
   else if(%client.observerMode == "pregame" && $Server::TourneyMode && !$TAC::controlledTourneyMode)
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
   else if(%client.observerMode == "observerOrbit" || %client.observerMode == "observerObjectiveOrbit")
   {
      %client.observerTarget = "";
      %client.observerMode = "observerFly";

      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), GameBase::getRotation(%camSpawn), true, true);
// - BW Admin Mod -
      if(%client.reg)
         TAC::setObserved(%client);
   }
}

function Observer::isObserver(%clientId)
{
   return %clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" || %clientId.observerMode == "observerObjectiveOrbit";
}

function Observer::enterObserverMode(%clientId)
{
   if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" || %clientId.observerMode == "observerObjectiveOrbit")
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
   %clientId.PilotView = "";
   Observer::jump(%clientId);
   remotePlayMode(%clientId);
   return true;
}

function Observer::checkObserved(%client)
{
   // this function loops through all the clients and checks
   // if anyone was observing %client... if so, it updates that
   // observation to reflect the new %client owned object.

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerTarget == %client)
      {
         if(%cl.observerMode == "observerOrbit")
         {
// - BW Admin Mod - Various spec modes.
	    if(%cl.zoom == "")
	       %cl.zoom = 5;
	    Observer::setOrbitObject(%cl, %client, %cl.zoom, -1, 30);
	    if(%cl.reg)
	       TAC::setObserved(%cl);
// - BW Admin Mod - End
         }
         else if(%cl.observerMode == "commander")
	   Observer::setOrbitObject(%cl, %client, -3, -3, -3);
      }
   }
}


// - BW Admin Mod - Various spec modes.

function Observer::setTargetClient(%client, %target)
{
   if(%client.observerMode != "observerOrbit" && %client.observerMode != "observerObjectiveOrbit")
      return false;
   %owned = Client::getOwnedObject(%target);
   if(%owned == -1 && %client.observerMode == "observerOrbit")
      return false;
   if(%client.zoom == "")
      %client.zoom = 5;
   if(%client.observerMode == "observerObjectiveOrbit")
   {
      if(getObjectType(%target) != "Player")
      {
         if(%client.zoom < 5)
            %client.zoom = 5;
         %team = GameBase::getTeam(%target);
         %teamName = getTeamName(%team);
         if(%teamName == "unnamed")
            bottomprint(%client, "<jc>Observing " @ %target.objectiveName, 5);
         else if(getObjectType(%target) != "Item")
            bottomprint(%client, "<jc>Observing " @ %target.objectiveName @ " (" @ %teamName @ ")", 5);
         else
            bottomprint(%client, "<jc>Observing " @ %teamName @ " " @ gamebase::getdataname(%target), 5);
         Observer::setOrbitObject(%client, %target, %client.zoom, 5, 30);
      }
      else
      {
         %flag = %target.carryFlag;
         %team = GameBase::getTeam(%flag);
         %teamName = getTeamName(%team);
         %cl = Player::getClient(%target);
         %name = Client::getName(%cl);
         if(%teamName == "unnamed")
            bottomprint(%client, "<jc>Observing " @ %flag.objectiveName @ " (" @ %name @ ")", 5);
         else
            bottomprint(%client, "<jc>Observing " @ %teamName @ " " @ gamebase::getdataname(%flag) @ " (" @ %name @ ")", 5);
         if(%client.zoom == -3)
            Observer::setOrbitObject(%client, %target, %client.zoom, -10, -3);
         else
            Observer::setOrbitObject(%client, %target, %client.zoom, -1, 30);
      }
   }
   else if(%client.zoom == -3)
   {
      bottomprint(%client, "<jc>Observing " @ Client::getName(%target), 5);
      Observer::setOrbitObject(%client, %target, %client.zoom, -10, -3);
   }
   else
   {
      bottomprint(%client, "<jc>Observing " @ Client::getName(%target), 5);
      Observer::setOrbitObject(%client, %target, %client.zoom, -1, 30);
   }
   %client.observerTarget = %target;
   if(%client.reg)
      TAC::setObserved(%client);
   return true;
}
// - BW Admin Mod - End

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