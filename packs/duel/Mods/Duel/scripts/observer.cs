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
	//echo("triggerred");
	if(%client.follow[0] != "")
	{
		ProjectileUnFollow(%client);
		//both("cancel");
		return;
	}
	%time = Time::getMinutes((floor(getSimTime()) - %client.LastAction));
	if(%time > 0.9)
	{
		%client.LastAction = floor(getSimTime());
		Game::refreshClientScore(%client);
	}
	else
	{
		%client.LastAction = floor(getSimTime());
	}
	if(%client.cantrigger || %client.cantrigger == "")
	{
		%client.cantrigger = false;
		schedule("cantrigger("@%client@");", 0.7);
		if(%client.cmd != "") {
			if(%client.trigger == "move2")
			{
				if(%client.zoom < 56)
				{
					%client.zoom = %client.zoom+5;
				}
				else
				{
					%client.zoom = %client.zoom+10;
				}
				if(%client.zoom > 200)
				{
					%client.zoom = 0;
				}
				%objpos = gamebase::getposition(%client.cmd);
				%camrot = gamebase::getrotation(%client.cmd);
				%camrot = GetWord(%camrot, 0)@" 0 "@GetWord(%camrot, 2) ;
				%offset = vector::getfromrot(%camrot, %client.zoom);
				%offset = Vector::neg(%offset);
				%campos = Vector::add(%objpos, %offset);

				Observer::setFlyMode(%client,%campos,%camrot,true,true);
				return;
			}
			if(%client.trigger == "move")
			{
				%client.trigger = "none1";
				BottomPrint(%client,"Observing", 2);
				return;
			}
			if(%client.trigger == "none1")
			{
				%client.trigger = "rot";
				return;
			}
			if(%client.trigger == "rot")
			{
				%client.trigger = "none2";
				BottomPrint(%client,"Observing", 2);
				return;
			}
			if(%client.trigger == "none2")
			{
				%client.trigger = "move";
				return;
			}
			return;
		}
		if(%client.notready)
		{
			%client.notready = "";
			%message = client::getname(%client) @ " is READY!";
			TMessage(%client.Team, $TeamDuel::Challenging[%client.Team], $Green, %message);
			return;
		}

   if(%client.observerMode == "dead" && %client.DM || %client.observerMode == "observerFly" && %client.DM && %client.isalive == "" || %client.observerMode == "dead"  && %client.DM && $Game::missionType == "BooT CamP" || %client.observerMode == "observerFly" && %client.DM && %client.isalive == ""  && $Game::missionType == "BooT CamP" )
   {
	   //echo(%client.observerMode@" "@%client.DM@" "@%client.isalive@" "@%client.DM@" "@%client.DM@" "@%client.DM);
	   //echo("dead dmer clickin");
      if(%client.dieTime + $Server::respawnTime < getSimTime())
      {
		   //echo("dead dmer clickin_time passed");
		%pl = Deathmatch::Spawn(%client);
		Client::setControlObject(%client, %client.Owns);
		GameBase::SetDamageLevel(%client.Owns, 0);
		%client.guiLock = false;
		Client::setGuiMode(%client, $GuiModePlay);
		%client.observerMode = "";
		Observer::checkObserved(%client);
		if(%client.GoToSpecialMap)
		{
			GoToSpecialMap(%client);
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
			 %client.cantrigger = false;
			 return;
		  }
		  Game::CheckTourneyMatchStart();
	   }
   }
    %client.cantrigger = false;
	   if(%client.observerMode == "justJoined"  &&  $Game::missionType == "Uber" || %client.observerMode == "observerFly" &&  $Game::missionType == "Uber" || %client.observerMode == "dead" &&  $Game::missionType == "Uber")
	   {
		  %client.observerMode = "";
		  Game::playerSpawn(%client, false);
	   }
}
function canjump(%client)
{
	%client.canjump = true;
}
function cantrigger(%client)
{
	%client.cantrigger = true;
}
function Observer::jump(%client, %balls)
{
	if(%client.canjump || %client.canjump == "")
	{
		%time = Time::getMinutes((floor(getSimTime()) - %client.LastAction));
		if(%time > 0.9)
		{
			%client.LastAction = floor(getSimTime());
			Game::refreshClientScore(%client);
		}
		else
		{
			%client.LastAction = floor(getSimTime());
		}
		if(%client.cmd != "") {
			if(%client.trigger == "move" && %client.canjump)
			{
				if(%client.zoom == "")
				{
					%client.zoom = "50";
				}

				%objpos = gamebase::getposition(%client.cmd);
				%camrot = gamebase::getrotation(%client.cmd);
				%offset = vector::getfromrot(%objrot, %client.zoom);
				%offset = Vector::neg(%offset);
				%campos = Vector::add(%objpos, %offset);

				Observer::setFlyMode(%client,%campos,%camrot,true,true);


				%client.trigger = "move2";
			}
			if(%client.trigger == "move2" && %client.canjump)
			{
				%client.trigger = "move";
			}
			if(%client.trigger == "rot" && %client.canjump)
			{
				//%client.trigger = "rot1";
			}
			if(%client.trigger == "rot1" && %client.canjump)
			{
				%client.trigger = "rot2";
			}
			if(%client.trigger == "rot2" && %client.canjump)
			{
				%client.trigger = "rot";

			}
			%client.canjump = false;
			schedule("canjump("@%client@");", 1);
			return;
		}
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
	   schedule("canjump("@%client@");", 1);
   }
   %client.canjump = false;

}

function Observer::isObserver(%clientId)
{
   return %clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly";
}

function Observer::enterObserverMode(%clientId)
{
   if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
   {
	  // both("returning false on enterobservermode "@%clientId.observerMode);
      //return false;
  }
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
   Observer::jump(%clientId, balls);
   remotePlayMode(%clientId);
   return true;
}

function Observer::checkObserved(%client) {
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
      if(%cl.observerTarget == %client && %cl.dm != true) {
         if(%cl.observerMode == "observerOrbit")
			setObsOrbit(%cl, %client, 5, 5, 5);
         else if(%cl.observerMode == "commander")
   		    Observer::setOrbitObject(%cl, %client, -3, -3, -3);
      }
   }
}
function Observer::setTargetClient(%client, %target) {
	if(%client.cmd != "") {
		return;
	}
   if(%client.observerMode != "observerOrbit") return false;
   %owned = Client::getOwnedObject(%target);
   if(%owned == -1) return false;
	setObsOrbit(%client, %target, 5, 5, 5);
	//TD
   	//bottomprint(%client, "<jc><f2>Observing " @ Client::getName(%target) @ ".", 0);
   	//TD
   	%client.observerTarget = %target;
   return true;
}
function Observer::NextTder(%cur)
{
	//messageall(1, "Next TDER called, current: "@Client::getname(%cur));
	%nextObserved = Client::getNext(%lastObserved);

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		//messageall(0, "CLIENT: "@%cl@" CURRENT: "@%cur);
		if(%cl == %cur)
		{
			%flag = true;
			//messageall(1, "Flag Set To True");
		}
		if(%cl.Team == %cur.Team || %cl.Team == $TeamDuel::Challenging[%cur.Team] || $TeamDuel::Challenging[%cl.Team] == "0" || $TeamDuel::Challenging[%cur.Team] == "0")
		{
			if(%flag && %cl != %cur && %cl != "-1" && %cl.isAlive == "True")
			{
				//messageall(1, "Next TDER found: "@Client::getname(%cl));
				return %cl;
			}
		}
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{

			if(%cl == %cur)
			{
				return false;
			}
			if(%cl.Team == %cur.Team || %cl.Team == $TeamDuel::Challenging[%cur.Team] || $TeamDuel::Challenging[%cl.Team] == "0" || $TeamDuel::Challenging[%cur.Team] == "0")
			{
				if(%flag && %cl != %cur && %cl != "-1" && %cl.isAlive == "True")
				{
					//messageall(1, "Next TDER found: "@Client::getname(%cl));
					return %cl;
				}
			}

	}
	echo("Next TDER NOT FOUND");
	return false;
}
function GetTotalAlive(%a, %b)
{
	%count = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		//if(%cl.Team == %a || %cl.Team == %b)
		//{
			if(%cl.isAlive == "True")
			{
				%count++;
			}
		//}
	}
	return %count;
}
function Observer::nextObservable(%client)
{
	if(%client.cmd != "") {
		return;
	}
	if(%client.Team != "" && %client.prefs["obsTDonly"])
	{
		%alive = GetTotalAlive(%client.Team, $TeamDuel::Challenging[%client.Team]);
		//messageall(2, "alive "@%alive);
		if(%alive > 1)
		{
			%cur = %client.observerTarget;
			%next = Observer::NextTder(%cur);
			if(!%next)
			{
				Observer::jump(%client);
				return;
			}
			else {
				Observer::setTargetClient(%client, %next);
			}
		}
		return;
	}
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
      if(%owned == -1 || %nextObserved.private)
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