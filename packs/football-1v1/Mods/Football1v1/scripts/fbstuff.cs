//The "Tricon-friendly fbstuff.cs" script for Tribes 1 Football servers.
//Fbstuff modified for the Tribes Football mod - GSL ladder version 1.2
//Available from the Tribes Football files archive; http://amishrabbit.com/tribes/files/
//Place in the Tribes\Football folder for each server and restart the server to initiate this script.
//Will display name of person who scores a touchdown in Tricon.
//This version changes other descriptive text, including spawn and halftime announcements.
//edited 19 January 2001
//Changed ball spawn text 6 Feb 2001
//Patched Mod to Fix Inventory Screen Ball Drop Bug 03 May 2001
//       See code at bottom of file (LN2)
//Disabled Tackle After touchdown 8/29/03 - taserman
$footballExists = "";
$currentFootball = "";

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

ItemData Football
{
	description = "Football";
	className = "Football";
	shapeFile = "ammo2";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 0;

	lightType = 1;
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemImageData FootballThrowerImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = "";
	projectileType = NoProjectile;
	accuFire = false;
	reloadTime = 0;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = NoSound;
	sfxActivate = NoSound;
	sfxReload = NoSound;
};
ItemData FootballThrower
{
	description = "Football Thrower";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "grenade";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FootballThrowerImage;
	price = 0;
	showWeaponBar = true;
};
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

function Cap(%n, %lb, %ub)
{
	if(%lb != "inf")
	{
		if(%n < %lb)
			%n = %lb;
	}

	if(%ub != "inf")
	{
		if(%n > %ub)
			%n = %ub;
	}

	return %n;
}

function GetPlayerIdList()
{
	%list = "";
	for(%c = Client::getFirst(); %c != -1; %c = Client::getNext(%c))
	{
		%list = %list @ %c @ " ";
	}
	return %list;
}
function GetPlayerNameList()
{
	%list = "";
	for(%c = Client::getFirst(); %c != -1; %c = Client::getNext(%c))
	{
		%list = %list @ Client::getName(%c) @ " ";
	}
	return %list;
}

function Boost(%clientId)
{
	%mom = Vector::getFromRot(GameBase::getRotation(%clientId), 70, 35);
	Player::applyImpulse(%clientId, %mom);
}

function getVelocity(%clientId)
{
	%v = Item::getVelocity(%clientId);
	%cv = round(getWord(%v, 0)) @ " " @ round(getWord(%v, 1)) @ " " @ round(getWord(%v, 2));
	if(%cv == "0 0 0")
		%v = %clientId.velocity;

	return %v;
}
//triggers for client audio on touchdown -- added TD sound for client without pack 6/25/02
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

function String::len(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++;

	return %length;
}

function GetPlayerIdList()
{
	%list = "";
	for(%c = Client::getFirst(); %c != -1; %c = Client::getNext(%c))
	{
		%list = %list @ %c @ " ";
	}
	return %list;
}

function Football::oldRound(%n)
{
	if(%n < 0)
	{
		%t = -1;
		%n = -%n;
	}	
	else if(%n >= 0)
		%t = 1;

	%f = floor(%n);
	%a = %n - %f;
	if(%a < 0.5)
		%b = 0;
	else if(%a >= 0.5)
		%b = 1;

	return (%f + %b) * %t;
}

function OppositeTeam(%t)
{
	%r = -1;
	if(%t == 0)
		%r = 1;
	else if(%t == 1)
		%r = 0;

	return %r;
}

function AppropriateSide(%t)
{
	%r = -1;
	if($matchStep == 0)
		%r = %t;
	else if($matchStep == 1)
		%r = OppositeTeam(%t);

	return %r;
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
