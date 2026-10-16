function GroupTrigger::onTrigger(%object, %this)
{
	%clientId = Player::getClient(%this);

	%pteam = GameBase::getTeam(%clientId);
	%gteam = AppropriateSide(GameBase::getTeam(%object));

	if(%pteam != %gteam && Player::getItemCount(%clientId, Football))
	{
		%name = Client::getName(%clientId);
		MessageAllExcept(%clientId, $MsgWhite, %name @ " scored a touchdown!~wflagcapture.wav");
            echo("ADMINMSG: **** " @ %name @ " scored a touchdown.");//for TRICON compatibility
		Client::sendMessage(%clientId, $MsgWhite, "~wflagcapture.wav");
		Client::sendMessage(%clientId, $MsgWhite, "You scored a touchdown!~wtouchdowncheer.wav");
		TeamMessages($MsgRed, %pteam, "Your team scored a touchdown.", %gteam, "The other team scored a touchdown.~wtouchdownboo.wav");

		LoseFootball(%clientId);
		$footballExists = "";
		$teamScore[%pteam] += 1;
		ObjectiveMission::checkScoreLimit();

		%clientId.score += 5;
		Game::refreshClientScore(%clientId);
		messageAll(0, %name @ " receives a 5 point touchdown bonus.");
		$NoTackle = true;
		schedule("DoSpawnFootball(" @ %gteam @ ");", 10);
		schedule("SendPlayersToStart();", 6);
	}
}

function ThrowFootball(%clientId, %vel)
{
	%rot = GameBase::getRotation(%clientId);
	%playervel = Item::getVelocity(%clientId);

	%zoffset = 0.25;

	%football = newObject("", "Item", Football, 1, false);
	%football.owner = %clientId;
	%football.rot = %rot;
	$CurrentFootball = %football;

	addToSet("MissionCleanup/ObjectivesSet", %football);

	%newrot = GetWord(%rot, 0) - %zoffset @ " " @ GetWord(%rot, 1) @ " " @ GetWord(%rot, 2);
	GameBase::setRotation(%clientId, %newrot);

	Item::setVelocity(%clientId, "0 0 0");
	GameBase::throw(%football, Client::getOwnedObject(%clientId), %vel, false);
	Item::setVelocity(%clientId, %playervel);

	GameBase::setRotation(%football, %rot);
	GameBase::setRotation(%clientId, %rot);
}

function GroupTrigger::onTrigLeave(%object, %this)
{
	%clientId = Player::getClient(%this);

	%pteam = GameBase::getTeam(%clientId);
	%gteam = GameBase::getTeam(%object);
}

function SpawnFootball(%team)
{
	if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 0;
		else
			%team = 1;
	}

	%football = newObject("", "Item", Football, 1, false);
	%football.owner = -1;
	%football.rot = "0 0 0";
	$CurrentFootball = %football;

	addToSet("MissionCleanup/ObjectivesSet", %football);

	%marker = nameToId("MissionGroup/Teams/team" @ AppropriateSide(%team) @ "/FootballSpawn");
	GameBase::setPosition(%football, GameBase::getPosition(%marker));

	RefreshObserveFootball();
}

function Item::onCollision(%this,%object)
{
	%clientId = Player::getClient(%object);

	if(getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);

            if(%item == Football)
            {
			if(!%clientId.tackled)
			{
				%armor = GameBase::getDataName(%object);
				%vel = Vector::getDistance(Item::getVelocity(%this), "0 0 0") * 2.0;
				%mom = Vector::getFromRot( %this.rot, %vel * (6.5 / %armor.mass), 1 );
				Player::applyImpulse(%clientId, %mom);
	
				GainFootball(%clientId);
				Item::playPickupSound(%this);
	
				%fteam = GameBase::getTeam(%this.owner);
				%pteam = GameBase::getTeam(%clientId);
				%name = Client::getName(%clientId);
	
				if(%fteam == -1 || floor(%vel / 2.2) == 0)
					TeamMessages($MsgWhite, %pteam, %name @ " picks up the football.", %fteam, %name @ " picked up the football.");
				else if(%fteam != %pteam)
					TeamMessages($MsgRed, %pteam, %name @ " intercepts the football!~wflagreturn.wav", %fteam, %name @ " intercepted the ball.");
				else
					TeamMessages($MsgWhite, %pteam, %name @ " catches the ball.", %fteam, %name @ " caught the football.");
	
				deleteObject(%this);
			}
		}
		else
		{
			if(Item::giveItem(%object,%item,Item::getCount(%this)))
			{
				Item::playPickupSound(%this);
				Item::respawn(%this);
			}
		}
	}
}

function DropFootball(%clientId, %random)
{
	//This function should only be invoked by LoseFootball.

	if(Player::getItemCount(%clientId, Football))
	{
		%oldrot = GameBase::getRotation(%clientId);

		if(%random)
			%rot = "0 -0 " @ (getRandom() * 6.28) - 3.14;
		else
			%rot = GameBase::getRotation(%clientId);
	
		%football = newObject("", "Item", Football, 1, false);
		%football.owner = %clientId;
		%football.rot = %rot;
		$CurrentFootball = %football;
	
		addToSet("MissionCleanup/ObjectivesSet", %football);

		GameBase::setRotation(%clientId, %rot);	
		GameBase::throw(%football, Client::getOwnedObject(%clientId), 10, false);
		Player::decItemCount(%clientId, Football);
		Item::playPickupSound(%football);
		GameBase::setRotation(%clientId, %oldrot);
	}
}

function GainFootball(%clientId)
{
	Player::incItemCount(%clientId, Football);
	$CurrentFootball = "";

	if(Player::getItemCount(%clientId, Football))
	{
		%player = Client::getOwnedObject(%clientId);

		Player::mountItem(%player, Flag, $FlagSlot, 0);

		%e = GameBase::getEnergy(%player);
		if(Client::getGender(%clientId) == "Male")
			Player::setArmor(%clientId, clarmor);
		else if(Client::getGender(%clientId) == "Female")
			Player::setArmor(%clientId, clfemale);
		GameBase::setEnergy(%player, %e);
	}

	RefreshObserveFootball();
}

function LoseFootball(%clientId, %action)
{
	if(Player::getItemCount(%clientId, Football))
	{
		if(%action == drop)
			DropFootball(%clientId, False);
		else if(%action == fumble)
			DropFootball(%clientId, True);
		else
			Player::decItemCount(%clientId, Football);

		if(Player::getItemCount(%clientId, Football) == 0)
		{
			%player = Client::getOwnedObject(%clientId);

			Player::unMountItem(%player, $FlagSlot);

			%e = GameBase::getEnergy(%player);
			if(Client::getGender(%clientId) == "Male")
				Player::setArmor(%clientId, larmor);
			else if(Client::getGender(%clientId) == "Female")
				Player::setArmor(%clientId, lfemale);
			GameBase::setEnergy(%player, %e);

			//Getting weird ghosting, maybe this could be a solution...
			Player::mountItem(%player, Flag, $FlagSlot, 0);
			Player::unMountItem(%player, $FlagSlot);
		}
	}

	RefreshObserveFootball();
}

function DoSpawnFootball(%team)
{
	if(!$footballExists)
	{
		SpawnFootball(%team);
		$footballExists = True;
		messageAll($MsgWhite, "The heavens spew forth a new ball.~wshortwhistle.wav");
		$NoTackle = false;
		return True;
	}
	else
		return False;
}

function SendPlayersToStart()
{
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		%dp = Game::pickRandomSpawn(%team);

		Item::setVelocity(%id, "0 0 0");
		GameBase::setPosition(%id, GameBase::getPosition(%dp));
		GameBase::startFadeIn(%id);
		Player::setDamageFlash(%id, 0.35);

		%armor = GameBase::getDataName(%id);
		%pl = Client::getOwnedObject(%id);
		GameBase::setEnergy(%pl, %armor.maxEnergy);
		GameBase::setDamageLevel(%pl, 0);
	}
}

function Player::onCollision(%this, %object)
{
	if (Player::isDead(%this)) {
		if(getObjectType(%object) == "Player") {
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) {
				%count = Player::getItemCount(%this,%i);
				if (%count) {
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0) {
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			if (%sound) {
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	else
	{
		if(getObjectType(%object) == "Player")
		{
			%id1 = Player::getClient(%this);
			%id2 = Player::getClient(%object);

			if(GameBase::getTeam(%id1) != GameBase::getTeam(%id2))
			{
				//The .SecondEventCall is a little workaround so only the second event
				//of onCollision between two players gets called.
				if( %id1.SecondEventCall == %id2 && %id2.SecondEventCall == %id1 )
				{
					if( !(%id1.tackled || %id2.tackled) )
					{
						%vel[%id1] = getVelocity(%id1);
						%vel[%id2] = getVelocity(%id2);

						%totalVel = round(Vector::getDistance("0 0 0", Vector::sub(%vel[%id1], %vel[%id2])));

						//exchange vectors
						if($elasticity == "")
							%e = 1.0;
						else
							%e = $elasticity;
						%newvel1 = GetWord(%vel[%id2], 0) * %e @ " " @ GetWord(%vel[%id2], 1) * %e @ " " @ GetWord(%vel[%id2], 2) * %e;
						%newvel2 = GetWord(%vel[%id1], 0) * %e @ " " @ GetWord(%vel[%id1], 1) * %e @ " " @ GetWord(%vel[%id1], 2) * %e;
						Item::setVelocity(%id1, %newvel1);
						Item::setVelocity(%id2, %newvel2);

						//determine who hit hardest
						%absvel[%id1] = round(Vector::getDistance("0 0 0", %vel[%id1]));
						%absvel[%id2] = round(Vector::getDistance("0 0 0", %vel[%id2]));

						if(%absvel[%id1] > %absvel[%id2])
						{
							%status[%id1] = "tackle";
							%status[%id2] = "q0wned";
						}
						else if(%absvel[%id1] < %absvel[%id2])
						{
							%status[%id1] = "q0wned";
							%status[%id2] = "tackle";
						}
						else if(%absvel[%id1] == %absvel[%id2])
						{
							%status[%id1] = "q0wned";
							%status[%id2] = "q0wned";
						}
						
						%involved[1] = %id1;
						%involved[2] = %id2;
						%otherId[%id1] = %id2;
						%otherId[%id2] = %id1;

						for(%i = 1; %i <= 2; %i++)
						{
							%id = %involved[%i];
							%oid = %otherId[%id];
							//messageAll($MsgGreen, "Abs Vel for " @ Client::getName(%id) @ ": " @ %absvel[%id]);
							//messageAll($MsgGreen, "Abs Vel for " @ Client::getName(%oid) @ ": " @ %absvel[%oid]);
							//messageAll($MsgGreen, "Status for " @ Client::getName(%id) @ ": " @ %status[%id]);
							//messageAll($MsgGreen, "Status for " @ Client::getName(%oid) @ ": " @ %status[%oid]);
							//messageAll($MsgGreen, "Total Vel: " @ %totalVel);

							if(%status[%id] == "q0wned")
							{
								if(Player::getItemCount(%id, Football))
								{
									//-----------------
									//  FUMBLE
									//-----------------
									if(%totalVel >= 2 && %totalVel < 15)
									{
										LoseFootball(%id, fumble);
			
										Client::sendMessage(%id, $MsgRed, Client::getName(%oid) @ " made you fumble!~wgrunt.wav");
										Client::sendMessage(%oid, $MsgWhite, "You made " @ Client::getName(%id) @ " fumble!");
									}
								}
								if(%totalVel >= 15)
								{
								if(!$NoTackle) {
									//-----------------
									//  TACKLE
									//-----------------


									if(Player::getItemCount(%id, Football))
									{
										LoseFootball(%id, fumble);
										%oid.score += 1;
										Game::refreshClientScore(%oid);
									}

									%pid = Client::getOwnedObject(%id);
			
									//cause damage
							                %dlevel = GameBase::getDamageLevel(%pid) + 0.2;
									GameBase::setDamageLevel(%pid, %dlevel);
									%flash = Player::getDamageFlash(%pid) + %value * 2;
									Player::setDamageFlash(%pid, %flash);


									Player::setAnimation(%id, 33);
									if(!Player::isDead(%pid))
									{
										%id.tackled = True;
										Client::setControlObject(%id, Client::getObserverCamera(%id));
										Observer::setOrbitObject(%id, %pid, -8, -8, -8);

										schedule("Client::setControlObject(" @ %id @ ", " @ %id @ ");", 2);
										schedule(%id @ ".tackled = \"\";", 2);
										schedule("GameBase::setEnergy(" @ %pid @ ", 0);", 2);
									}
			
									Client::sendMessage(%id, $MsgRed, Client::getName(%oid) @ " tackled you!");
									Client::sendMessage(%oid, $MsgWhite, "You tackled " @ Client::getName(%id) @ "!");
								}
								else
									Client::sendMessage(%oid, $MsgRed, "Tackling is not allowed after the touchdown.");
								}
							}
						}
					}
				}
				else
				{
					%id1.SecondEventCall = %id2;
					%id2.SecondEventCall = %id1;
					schedule(%id1 @ ".SecondEventCall = \"\";", 0.1);
					schedule(%id2 @ ".SecondEventCall = \"\";", 0.1);
				}
			}
		}
	}
}

function GetNESW(%pos1, %pos2)
{
	%v1 = Vector::sub(%pos1, %pos2);
	%v2 = Vector::getRotation(%v1);
	%a = GetWord(%v2, 2);

	if(%a >= 2.7475 && %a <= 3.15 || %a >= -3.15 && %a <= -2.7475)
		%d = "North";
	else if(%a >= 1.9625 && %a <= 2.7475)
		%d = "North East";
	else if(%a >= 1.1775 && %a <= 1.9625)
		%d = "East";
	else if(%a >= 0.3925 && %a <= 1.1775)
		%d = "South East";
	else if(%a >= -0.3925 && %a <= 0.3925)
		%d = "South";
	else if(%a >= -1.1775 && %a <= -0.3925)
		%d = "South West";
	else if(%a >= -1.9625 && %a <= -1.1775)
		%d = "West";
	else if(%a >= -2.7475 && %a <= -1.9625)
		%d = "North West";

	return %d;
}

function WhereIsFootball(%clientId)
{
	if($currentFootball)
	{
		%pos1 = GameBase::getPosition(%clientId);
		%pos2 = GameBase::getPosition($currentFootball);
		%dist = Vector::getDistance(%pos1, %pos2);
		%d = GetNESW(%pos1, %pos2);
		Client::sendMessage(%clientId, 0, "The football is " @ %dist @ " yards " @ %d @ " of you.");
	}
	else
		Client::sendMessage(%clientId, 0, "A player has the ball.");
}

function RecursiveWorld(%seconds)
{
	$ticker[1] = floor($ticker[1]+1);
	$ticker[2] = floor($ticker[2]+1);
	$ticker[3] = floor($ticker[3]+1);
	$ticker[4] = floor($ticker[4]+1);

	if($ticker[1] >= 1)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
			%id.velocity = Item::getVelocity(%id);

		$ticker[1] = 0;
	}
	if($ticker[2] >= 150)
	{
		if(GetWord(Item::getVelocity($CurrentFootball), 2) < -500)
		{
			%team = OppositeTeam(GameBase::getTeam($CurrentFootball.owner));
			deleteObject($CurrentFootball);
			$CurrentFootball = "";
			$footballExists = "";
			DoSpawnFootball(%team);
			SendPlayersToStart();
		}
		$ticker[2] = 0;
	}
	if($ticker[3] >= 10)
	{
		if($CurrentFootball)
		{
			if(GameBase::getPosition($CurrentFootball) == $footballLastPos)
			{
				$internalTicker[3]++;
				
				%delay = 20;
				if($internalTicker[3] >= %delay)
				{
					messageAll($MsgWhite, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav");

					%team = OppositeTeam(GameBase::getTeam($CurrentFootball.owner));
					deleteObject($CurrentFootball);
					$CurrentFootball = "";
					$footballExists = "";
					DoSpawnFootball(%team);
					SendPlayersToStart();

					$internalTicker[3] = 0;
				}
			}
			else
			{
				$footballLastPos = GameBase::getPosition($CurrentFootball);
				$internalTicker[3] = 0;
			}
		}
		$ticker[3] = 0;
	}
	if($ticker[4] >= 10)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
			%player = Client::getOwnedObject(%id);
			if(%player.outArea == 1)
			{
				Client::sendMessage(%id, $MsgRed, "You're out of bounds!~woob.wav");
				%value = 0.065;

		            %dlevel = GameBase::getDamageLevel(%player) + %value;
				GameBase::setDamageLevel(%player, %dlevel);
				%flash = Player::getDamageFlash(%player) + %value * 2;
				Player::setDamageFlash(%player, %flash);

				if(Player::isDead(%player)) {
					%id.tackled = false;
					Player::blowUp(%player);
				}
			}
		}

		$ticker[4] = 0;
	}
	schedule("RecursiveWorld(" @ %seconds @ ");", %seconds);
}

function WhoHasFootball()
{
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		if(Player::getItemCount(%id, Football))
			return %id;
	}
	return -1;
}

function ObserveFootball(%clientId)
{
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));

	if($CurrentFootball)
		Observer::setOrbitObject(%clientId, $CurrentFootball, 10, 10, 10);
	else
		Observer::setOrbitObject(%clientId, WhoHasFootball(), 10, 10, 10);

}

function RefreshObserveFootball()
{
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		if(%id.observerMode == "observerFootball")
			ObserveFootball(%id);
	}
}

function NEWgetClientByName(%name)
{
	%list = GetPlayerIdList();
	for(%i = 0; GetWord(%list, %i) != -1; %i++)
	{
		%id = GetWord(%list, %i);
		%displayName = Client::getName(%id);
		if(String::ICompare(%name, %displayName) == 0)
			return %id;
	}
	return -1;
}
function Item::onDrop(%player,%item)
{
	if($matchStarted) {
		if((%item.className != Armor) && (%item.className != Football)) {
			//echo("Item dropped: ",%player," ",%item);
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else {
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}
function Game::pickRandomSpawn(%team)
{
	%group = nameToID("MissionGroup/Teams/team" @ AppropriateSide(%team) @ "/DropPoints");
	%count = Group::objectCount(%group);
	if(!%count)
		return -1;
	%spawnIdx = floor(getRandom() * (%count - 0.1));
	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++)
	{
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
		{
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1)
		{
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
	return false;
}

function Game::pickStartSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ AppropriateSide(%team) @ "\\DropPoints");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = %client.lastObserverSpawn + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}
function Game::notifyMatchStart(%time)
{
   messageAll(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
	$matchStarted = true;
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");
	Game::resetScores();	

	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
		{
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		}
		Game::refreshClientScore(%cl);
	}

	if($Server::timeLimit == "") $Server::timeLimit = 15;
	
	$matchStep = 0;
	Game::checkTimeLimit();
}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      bottomprint(%clientId, "<jc><f0>Stadium: <f1>" @ $missionName @ "   <f0>Stadium Class: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives and mod rules.", 5);
   }
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "larmor";
	   else
	      %armor = "lfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	%clientId.spawn= 1;
	%max = getNumItems();
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon="";
	}

	GameBase::setRechargeRate(%pl, $rechargeRate[Player::getArmor(%clientId)]);

	bottomprint(%clientId, "To locate a football on the loose, type #where. Hit the 'o' key for full game instructions.", 10);
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else
   {
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
      {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   if(Client::getTeam(%clientId) == -1)
   {
      %clientId.observerMode = "pickingTeam";

      if($Server::TourneyMode && ($matchStarted || $matchStarting))
      {
         %clientId.observerMode = "observerFly";
         return;
      }
      else if($Server::TourneyMode)
      {
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Tournament Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
       for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";
   }
   else 
   {
      Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
         centerprint(%clientId, $Server::JoinMOTD, 0);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
      }
      else if(%clientId.observerMode == "justJoined")
      {
         centerprint(%clientId, "");
         %clientId.observerMode = "";
         Game::playerSpawn(%clientId, false);
      }
      else
         Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}
function Game::onPlayerConnected(%playerId)
{
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
	%playerId.score = 0;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}
function Game::checkTimeLimit()
{
	// if no timeLimit set or timeLimit set to 0,
	// just reschedule the check for a minute hence
	$timeLimitReached = false;
	ObjectiveMission::setObjectiveHeading();

	if(!$Server::timeLimit)
	{
		schedule("Game::checkTimeLimit();", 60);
		return;
	}

	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	if(%curTimeLeft <= 0 && $matchStarted)
	{
	if($halftimeDelay >= 5) {
		if($matchStep == 0)
		{
			$matchStep++;

			//second half thing happens here
			messageAll($MsgRed, "FIRST HALF OVER, " @ $halftimeDelay @ " SECOND BREAK~whalftime.wav");
			%curTimeLeft = $halftimeDelay;

			if($CurrentFootball != "")
			{
				%team = OppositeTeam(GameBase::getTeam($CurrentFootball.owner));
				deleteObject($CurrentFootball);
				$CurrentFootball = "";
			}
			else
			{
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
				{
					if(Player::getItemCount(%cl, Football))
					{
						LoseFootball(%cl);
						%team = OppositeTeam(GameBase::getTeam(%cl));
					}
				}
			}
			$footballExists = "";

			%t = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
			$NoTackle = true;
			schedule("SendPlayersToStart();", $halftimeDelay - 3);
			schedule("messageAll($MsgRed, \"SECOND HALF STARTING...~wlongwhistle.wav\");", $halftimeDelay - 2);
			schedule("messageAll($MsgRed, \"...NOW!\");", $halftimeDelay);
			schedule("DoSpawnFootball(" @ %team @ ");", $halftimeDelay);
			schedule("$missionStartTime = getSimTime();", $halftimeDelay);
			schedule("UpdateClientTimes(" @ %t @ ");", $halftimeDelay);

		}
		else if($matchStep == 1)
		{
			$matchStep++;

			echo("GAME: timelimit");
			$timeLimitReached = true;
			messageAll($MsgRed, "GAME OVER!~wendcrowd.wav");
			%set = nameToID("MissionCleanup/ObjectiveSet");
			for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
				GameBase::virtual(%obj, "timeLimitReached", %clientId);
			ObjectiveMission::missionComplete();

			return;
		}
	}
	}

	if(%curTimeLeft >= 20)
		schedule("Game::checkTimeLimit();", 20);
	else
		schedule("Game::checkTimeLimit();", %curTimeLeft + 1);

	UpdateClientTimes(%curTimeLeft);
}
function Mission::init()
{
	setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL");
//	setClientScoreHeading("Player Name\t\x6FTeam\t\xD6Score");//\t\xFFPing\t\xFFPL");
	setTeamScoreHeading("Team Name\t\xD6Score");

	$firstTeamLine = 7;
	$firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
	for(%i = -1; %i < getNumTeams(); %i++)
	{
		$teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
		Team::setObjective(%i, $firstTeamLine - 1, " ");
		Team::setObjective(%i, $firstObjectiveLine - 1, " ");
		Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
		$firstObjectiveLine++;
		$deltaTeamScore[%i] = 0;
		$teamScore[%i] = 0;
		newObject("TeamDrops" @ %i, SimSet);
		addToSet(MissionCleanup, "TeamDrops" @ %i);
		%dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints");
		for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
			addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
	}
	$numObjectives = 0;
	newObject(ObjectivesSet, SimSet);
	addToSet(MissionCleanup, ObjectivesSet);
   
	Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
	%group = nameToID("MissionCleanup/ObjectivesSet");

	ObjectiveMission::setObjectiveHeading();
	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
	{
		%obj.objectiveLine = %i + $firstObjectiveLine;
		ObjectiveMission::objectiveChanged(%obj);
	}
	ObjectiveMission::refreshTeamScores();
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%cl.score = 0;
		Game::refreshClientScore(%cl);
	}
	schedule("ObjectiveMission::checkPoints();", 5);

	if($TestMissionType == "")
	{
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}
	AI::setupAI();
	RecursiveWorld(0.1);

	schedule("DoSpawnFootball();", 15);
}
function ObjectiveMission::setObjectiveHeading()
{
	if($missionComplete)
	{
		%curLeader = 0;
		%tieGame = false;
		%tie = 0;
		%tieTeams[%tie] = %curLeader; 
		for(%i = 0; %i < getNumTeams() ; %i++) 
			echo("GAME: teamfinalscore " @ %i @ " " @ $teamScore[%i]);
      
		for(%i = 1; %i < getNumTeams() ; %i++) 
		{
			if($teamScore[%i] == $teamScore[%curLeader])
			{
				%tieGame = true;
				%tieTeams[%tie++] = %i;
			}
			else if($teamScore[%i] > $teamScore[%curLeader])
			{
				%curLeader = %i;	   
				%tieGame = false;
				%tie = 0;
				%tieTeams[%tie] = %curLeader; 
			}
		}
		if(%tieGame)
		{
			for(%g = 0; %g <= %tie; %g++)
			{
				%names = %names @ getTeamName(%tieTeams[%g]);
				if(%g == %tie-1)
					%names = %names @ " and "; 
				else if(%g != %tie)
					%names = %names @ ", "; 
			}
			if(%tie > 1) 
				%names = %names @ " all"; 
		}
		for(%i = -1; %i < getNumTeams(); %i++)
		{
			objective::displayBitmap(%i,0);
			if(!%tieGame)
			{
				if(%i == %curLeader)
				{
					if($teamScore[%curLeader] == 1)
						Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
					else
						Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
				else
				{
					if($teamScore[%curLeader] == 1)
						Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
					else
						Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
			}	
			else
			{
				if(getNumTeams() > 2)
				{
					Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
				}
				else
					Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
			}
			Team::setObjective(%i, 2, " ");
		}
	}
	else
	{
		for(%i = -1; %i < getNumTeams(); %i++)
		{
			objective::displayBitmap(%i,0);
			Team::setObjective(%i,1, "<f5>Mission Completion:");
			Team::setObjective(%i, 2,"<f1>   - " @ $teamScoreLimit @ " points needed to win the mission.");
		}
	}
	if(!$Server::timeLimit)
		%str = "<f1>   - No time limit on the game.";
	else if($timeLimitReached)
		%str = "<f1>   - Time limit reached.";
	else if($missionComplete)
	{
		%time = getSimTime() - $missionStartTime;
		%minutes = Time::getMinutes(%time);
		%seconds = Time::getSeconds(%time);
		if(%minutes < 10)
			%minutes = "0" @ %minutes;
		if(%seconds < 10)
			%seconds = "0" @ %seconds;
		%str = "<f1>   - Total match time: " @ %minutes @ ":" @ %seconds;
	}
	else
		%str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";

	for(%i = -1; %i < getNumTeams(); %i++)
	{
		Team::setObjective(%i, 3, " ");
		Team::setObjective(%i, 4, "<f5>Mission Information:");
		Team::setObjective(%i, 5, "<f1>   - Mission Name: " @ $missionName); 
		Team::setObjective(%i, 6, %str);

		%k = 19;
		Team::setObjective(%i, %k++, "\n\nAs in 'real' football, the object is for your team to run the ball into the endzone to score---more times than the other team.\n");
		Team::setObjective(%i, %k++, "\n\nHow to tackle:\n");
		Team::setObjective(%i, %k++, "\n- The concept is simple, but execution can be difficult. To attempt a tackle, simply run into another player.\n");
		Team::setObjective(%i, %k++, "\n- You can only tackle members of the other team. High velocity determines how likely you will tackle; a combination of skiing (fast jumping while running, which also speeds up simple runs) and jump-jetting yields the best results.\n");
		Team::setObjective(%i, %k++, "\n- There is a knack to tackling: try to get your player's feet to hit the other player in the head. Don't be discouraged if at first you can't tackle. Keep at it and you'll eventually get it.\n");
		Team::setObjective(%i, %k++, "\n\nHow to pass:\n");
		Team::setObjective(%i, %k++, "\n- When you have the football, fire your Football Thrower (Blaster) to pass.\n");
		Team::setObjective(%i, %k++, "\n- If you line up a player in your crosshairs when you pass, the football will go to this player's exact position.\n");
		Team::setObjective(%i, %k++, "\n- If your crosshair does not line up with a player, but there are still players in your FOV (Field of Vision), the MOD will detect the nearest player to you within your FOV, and will toss the ball to this player.\n");
		Team::setObjective(%i, %k++, "\n- To aim past your target, place your crosshair above the target's head.  The higher the angle, the further it will go.  To throw the football short, aim your crosshairs below your target.\n");
		Team::setObjective(%i, %k++, "\n- To pass properly, the trick is to place your crosshairs RIGHT on the target, make sure no other players are in your FOV, and click fire. DON'T aim far above or below the receiver.\n");
		Team::setObjective(%i, %k++, "\n- Also, unlike with Disc Launchers, the Football does NOT inherit your momentum.  Wherever your crosshair is pointed when you pass is where the football goes. [Quote from Greasey: BAH!! YA RIGHT!!]");
	}
}

function FootballThrowerImage::onFire(%player, %slot)
{
	%clientId = Player::getClient(%player);

	if(Player::getItemCount(%clientId, "Football"))
	{
		%clientpos = GameBase::getPosition(%clientId);

		$los::object = 0;
		GameBase::getLOSinfo(%player, 8000, "0 0 0");
		if(getObjectType($los::object) == "Player")
		{
			%closestId = Player::getClient($los::object);
			%tpos = GameBase::getPosition(%closestId);
			%closest = Vector::getDistance(%tpos, %clientpos);

			%factor = sqrt(%closest) / 6.454;
			%vel = %closest / %factor;
		}
		else
		{
			%FOVpan = 0.15;
			%clientrot = GetWord(GameBase::getRotation(%clientId), 2);
			for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
			{
				if(%id != %clientId && GameBase::getPosition(%id) != "0 0 0")
				{
					%vec = Vector::sub(GameBase::getPosition(%id), %clientpos);
					%vecRot = GetWord(Vector::getRotation(%vec), 2);
			
					if(%vecRot >= %clientrot - %FOVpan && %vecRot <= %clientrot + %FOVpan)
						%idList[%c++] = %id;
				}
			}
			if(%idList[1] != "")
			{
				%closest = 500000;
				for(%i = 1; %idList[%i] != ""; %i++)
				{
					%dist = Vector::getDistance(%clientpos, GameBase::getPosition(%idList[%i]));
					if(%dist < %closest)
					{
						%closest = %dist;
						%closestId = %idList[%i];
					}
				}
				%factor = sqrt(%closest) / 6.454;
				%vel = %closest / %factor;
			}
			else
				%vel = 35;
		}

		ThrowFootball(%clientId, %vel);
		LoseFootball(%clientId);

		%name = Client::getName(%clientId);
		if(%closestId)
		{
			%tname = Client::getName(%closestId);
			messageAll($MsgWhite, %name @ " passes the football in " @ %tname @ "'s direction.");
			Client::sendMessage(%closestId, $MsgWhite, "~wflag1.wav");
		}
		else
			messageAll($MsgWhite, %name @ " throws the football.");
	}
}