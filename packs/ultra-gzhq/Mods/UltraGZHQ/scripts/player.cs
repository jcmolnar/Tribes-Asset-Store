$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
}

function Player::onRemove(%this)
{
	// Drop anything left at the players pos
	for(%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if(%type != -1)
		{
			// Note: Player::dropItem ius not called here.
			%item = newObject("","Item",%type,1,false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	//echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onKilled(%this)
{
	%this.Station = "";
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for(%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if(%type != -1)
		{
			if(%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2") 
				Player::dropItem(%this,%type);
		}
	}

	if(%cl != -1)
	{
		if(%this.vehicle != "")	
		{
			if(%this.driver != "") 
			{
				%this.driver = "";
				%this.vehicle.Pilot = "";
				Client::setControlObject(Player::getClient(%this), %this);
				Player::setMountObject(%this, -1, 0);
			}
			else 
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";
		}
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.AdminobserverMode = "";
		%cl.dieTime = getSimTime();
	}
}

// spawn some grenades for the hell of it.. -plasmatic 
function player::blood(%this)
{
	%Pos = GameBase::getPosition(%this); 
	%vel = Item::getVelocity(%this);
	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%this);	
	%xvel = getWord(%vel,0);
	%yvel = getWord(%vel,1);
	%zvel = getWord(%vel,2);

// Spawn butterflies
	for(%i=0; %i < 15; %i += 1) 
	{
		%xrnd = %xvel + floor(getRandom() * 20) -10;
		%yrnd = %yvel + floor(getRandom() * 20) -10;
		%zrnd = %zvel + floor(getRandom() * 20) -10;
		%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;
		%obj = Projectile::spawnProjectile("FieryBlood", %trans, %this, %vel);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	}	
}


//plasmatic
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	
	//%obj.deployer = %client;
	%isturret = %object.deployer;
	//echo(%object);
	%targetTeam = GameBase::getTeam(Player::getClient(%this));
	%shooterTeam = GameBase::getTeam(%object);
	//echo("type damage "@%type@"object "@%object);
	if(!Player::isExposed(%this)  || Player::isDead(%this)) return;
	
//	if(Player::isExposed(%this) && !Player::isDead(%this)) //added dead check -plasmatic
//	{
		%damagedClient = Player::getClient(%this);
		%armor = Player::getArmor(%this);
		
		
	//start special bullet animation -plasmatic
	if(%type == $SniperMkiDamageType || %type == $LaserDamageType) 
	{
		if(%vec != "0 0 0")
		{
			
			%vel = Item::getVelocity(%this);			
			%vecPos = getBoxCenter(%this);		
			%zpos = ((getWord(%pos,2))-(getWord(%vecPos,2)));
			%thispos =  vector::add("0 0 "@%zpos,%vecpos);		
			%trans =  "0 0 1 0 0 0 0 0 1 " @ %thispos;		
			%objb = Projectile::spawnProjectile("blood", %trans, %this, %vel);
	//		%objf = Projectile::spawnProjectile("blood", %trans, %this, %vel);
			GameBase::setPosition(%obj, %thispos);			
			%back = Vector::Multiply(vector::normalize(%vec), "15 15 1");
	//		%front = Vector::neg(%back);
	//		Item::setVelocity(%objf, %front);
			Item::setVelocity(%objb, %back);	
				
		}
	}
	//ending special bullet damage	
		
		if(!%object)%object = Player::getClient(%this).AIkiller;
		%shooterClient = %object;
	
	//something for inv discing wankers.. -plasmatic	
	%station = %this.Station;
	if(%targetTeam == %shooterTeam && %station && %type == $ExplosionDamageType)
	{
		%shooterObject = Client::getOwnedObject(%object);		
		Player::trigger(%shooterObject, $WeaponSlot, false);
		%weaponType = Player::getMountedItem(%shooterObject,$WeaponSlot);
		if(%weaponType == DiscLauncher)
		{
			Player::unmountItem(%shooterObject,$WeaponSlot);
			//Player::dropItem(%shooterObject,%weaponType);		
			Client::sendMessage(%shooterClient,0,"~wfemale2.wdsgst2.wav");
			schedule("client::sendmessage("@%shooterClient@",0,\"~wfemale1.wwshoot.wav\");",0.8);
			return;
		}
		
	}
	else	
	{
		%mult = $ArmorKickback[$ArmorName[%armor]];
		if(%mult != 0)
		{	
			%mom = (getWord(%mom, 0) * %mult) @ " " @ (getWord(%mom, 1) * %mult) @ " " @ (getWord(%mom, 2) * %mult);
		}
		Player::applyImpulse(%this,%mom);
		
	}
	//assassins absorb mine damage, lose energy
	if(%type == $MineDamageType && ($ArmorName[%armor] == iAssassin))	
	{
		%energy = GameBase::getEnergy(%this);	
		GameBase::setEnergy(%this,%energy - 40);
	}
	if($build && %type == 6)
	{
		%shooterObject = Client::getOwnedObject(%object);
		%weaponType = Player::getMountedItem(%shooterObject,$WeaponSlot);
		if(%weaponType == CuttingLaser)
		{	
			return;	//they're using a builder cutting laser, do nothing -plasmatic
		}		
	}	
	
//starting normal damage..
	if($debug) 
		echo("?? EVENT player damage "@Client::getName(%damagedClient)@" damaged by "@Client::getName(%shooterClient)@" damage type = "@%type);

	// special damage types -----------------			
		//stasis
			if(%type == $StasisDamageType)
			{
				//no stasis yerself or team members when td is off 
				if (Player::getClient(%this) == %object || (%shooterTeam == %targetTeam && !$Server::TeamDamageScale))
					return;
				Client::SendMessage(%damagedClient,1,"You've been hit with Stasis!");
				if(%armor == harmor1 || %armor == harmor2 || %armor == harmor3)
					return;
				if(%armor == LightArmor || %armor == LightFArmor || %armor == Assassin || %armor == FAssassin || %armor == Warlock || %armor == FWarlock)
					Player::setArmor(%damagedClient, "harmor1");
				else if(%armor == Assault || %armor == FAssault || %armor == Deffence || %armor == FDeffence || %armor == armormDM || %armor == armorfDM)
					Player::setArmor(%damagedClient, "harmor2");
				else if(%armor == Borg || %armor == Heavy || %armor == Destroyer)
					Player::setArmor(%damagedClient, "harmor3");
				%damagedClient.isStasis = true;
				schedule("Stasis::resetArmor("@ %damagedClient @", "@ %armor @");",10);
				//schedule("Player::setArmor("@ %damagedClient @", "@ %armor @");",5);
				//schedule("UnstasisMsg("@ %damagedClient @");",5);
			}
		//end stasis	
			if(Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) || $Deathmatch)
			{
				if(%type == $DisarmDamageType) 
				{
					Player::trigger(%this, $WeaponSlot, false);
					%weaponType = Player::getMountedItem(%this,$WeaponSlot);
					if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
					Client::sendMessage(Player::getClient(%damagedClient),0,"Your have been hit by a disarm spell!");
				}
			}
//-----------	other special damage			
			if(%shooterTeam != %targetTeam || $Server::TeamDamageScale || Player::getClient(%this) == %object)
			{	
				if(%type == $PlasmaDamageType)
					eval(%armor @ "::onBurn(" @ %damagedClient @ ", " @ %this @ ");");							
				else if(%type == $ShockDamageType)
					eval(%armor @ "::onShock(" @ %damagedClient @ ", " @ %this @ ");");
				else if(%type == $DartDamageType)
					eval(%armor @ "::onDart(" @ %damagedClient @ ", " @ %this @ ");");
				else if(%type == $BeamOfPainDamageType)
					eval(%armor @ "::onBeam(" @ %damagedClient @ ", " @ %this @ ");");
				else if(%type == $AcidDamageType)
					eval(%armor @ "::onAcid(" @ %damagedClient @ ", " @ %this @ ");");
				else if(%type == $PoisonDamageType && !$NoPlayerDamage)
					eval(%armor @ "::onPoison(" @ %damagedClient @ ", " @ %this @ ");");
			}
// end special ----------------------------------------- 

	//==== yep, more stuff for invulnerability, jail, and admin -Plasmatic
		
		if($debug)
			echo("damage? cl ",%damagedClient," pl ",%this," inv ",%this.invulnerable ," no dam ", $NoPlayerDamage, " frozen ",%this.frozen ," jailed ",$jailed[%player]);

		if(%this.invulnerable || $NoPlayerDamage || %this.frozen || $jailed[%this])
		{
			if($debug)
				echo("No Damage");
				
			// no damage, just play a shield.
			%thisPos = getBoxCenter(%this);
			%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
			GameBase::activateShield(%this,%vec,%offsetZ);
			return;
		}
		//================

		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) 
		{
			if(%shooterClient != -1) 
			{
				%curTime = getSimTime();
				if((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) 
				{
					if(%type != $MineDamageType) 
					{
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
					}
					else
					{
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
			%friendFire = $Server::TeamDamageScale;
		else
			%friendFire = 1.0;
		if(!Player::isDead(%this)) 
		{
			//More damage applyed to head shots sniper rifle
			if(%vertPos == "head" && %type == $LaserDamageType) 
			{
				if(%armor == "Borg" || %armor == "Heavy" ||  %armor == "Destroyer") 	// -plasmatic
				{
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") 
					{
						%value += (%value * 0.45);	//0.3
					}
				}
				else 
				{
					%value += (%value * 0.55);	//0.3
				}
			}
			//rail and pbeam do more damage to players than objects, + more for head shot.. -plasmatic
			if(%type == $SniperMkiDamageType) 
			{
				if(%vertPos == "head")
				{
					if(%armor == "Borg" || %armor == "Heavy" ||  %armor == "Destroyer") 	// -plasmatic
					{
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") 
						{
							%value += (%value * 0.3);	//head shot to heavy
						}
					}
					else 
					{
						%value += (%value * 0.35);	//med/ light head shots
					}
				}
				else %value += (%value * 0.27);// adding 27% to any other shot
			}			
			
			
			//If Shield Pack is on
			if(%type != -1 && %this.shieldStrength) 
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if(%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				if(%type == $ElectricityDamageType)
					%strength *= 0.0;
				%absorb = %energy * %strength;
				if(%value < %absorb) 
				{
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else 
				{
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}			
			if(%value) 
			{
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
				%dlevel = GameBase::getDamageLevel(%this) + %value;
				%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if(%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this))
				{
					if(%damagedClient.lastDamage < getSimTime())
					{
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else
				{
					
					//added pbeam massive kills also
					if(%spillOver > 0.35 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType) || %spillOver > 1.5 && %type == $SniperMkiDamageType)
					{
						Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
						player::blood(%this);	
						Player::blowUp(%this);
					}
					else
					{
						if((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) )
						{
							if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this)) 
							%curDie = $PlayerAnim::Crouching;
						else if(%vertPos=="head")
						{
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
							else
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if(%vertPos == "torso")
						{
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if(%vertPos == "legs")
						{
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" || %quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")
						%shooterClient = %object.clLastMount;
					if(%damagedClient != -1)
						Client::onKilled(%damagedClient,%shooterClient, %type);
					else schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);	//necro bot..
				}
			}
		}
//	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	//if(GameBase::getMapName(%this) == "ProbeDroid")
	//	return;
	//echo("player collision",%this);
	

	if(getObjectType(%object) != "Player" && !Player::isDead(%this) && GameBase::getTeam(%object) == GameBase::getTeam(%this) && $ArmorName[Player::getArmor(%this)] == iDeffence)
	{
		if(GameBase::getDamageLevel(%object))
		{
			GameBase::repairDamage(%object, 0.07);
			GameBase::playSound(%this, ForceFieldOpen,0);
		}			
	}
	if(Player::isDead(%this)) 
	{
		if(getObjectType(%object) == "Player") 
		{
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for(%i = 0; %i < %max; %i = %i + 1) 
			{
				%count = Player::getItemCount(%this,%i);
				if(%count) 
				{
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if(%delta > 0) 
					{
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			if(%sound) 
			{
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	if(getObjectType(%object) == "Player" && !Player::isDead(%this))
	{
		%cliendId = Player::getClient(%object);
		%thisId = Player::getClient(%this);
		%armor = Player::getArmor(%object);
		eval(%armor @ "::onPlayerContact(" @ %this @ ", " @ %object @ ");");
		if(%this.cloaked > 0 && GameBase::getTeam(%object) == GameBase::getTeam(%this)){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this player visible for a second -plasmatic
	}

}

function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	
	//overhauled by Plasmatic to remove faulty droid/ OSMissile/ observer targeting
	%client = Player::getClient(%this);
	%control = Client::getControlObject(%client);
	if(%control != %this)
	{
		%data = gamebase::getdataname(%control);
		if(%client.AdminobserverMode == "AdminObserve")		return 0.0;

		if(%data == OSMissile || %data == ProbeDroid || %data == SuicideDroid || %data == SurveyDroid)
			return 0.0;
				
		else	return 1.0;
	}
	
	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;

	if((%lastTime + 1.5) < %time) 
	{
		return 0.0;
	}
	else 
	{
		%diff = %time - %lastTime;
		%heat = 1.0 - (%diff / 1.5);
		return %heat;
	}
}

function Player::jump(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%vehicle = Player::getMountObject (%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
	}
}


//----------------------------------------------------------------------------

function remoteKill(%client)
{

	if(!$matchStarted)
		return;
//plasmatic		
//echo(%client);
	%player = Client::getOwnedObject(%client);
	if(%player.frozen == true || $jailed[%player] == true)
	{
		client::sendmessage(%client,2,"WARDEN: Not on my watch son...");
		return;
	}
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack) 
		{
			Player::unmountItem(%player,$BackpackSlot);
			%obj = newObject("","Mine","Suicidebomb");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
		}
		else 
		{
			//%mass = Player::getArmor(%player).mass;.maxEnergy
			if(GameBase::getEnergy(%Player)*1.05 >= Player::getArmor(%player).maxEnergy)
			{
				GameBase::playSound(%player, shockExplosion, 0);
				Player::trigger(%player, $WeaponSlot, false);
				%weaponType = Player::getMountedItem(%player,$WeaponSlot);
				if(%weaponType != -1)
					Player::dropItem(%player,%weaponType);
				Player::blowUp(%player);	
				player::blood(%player);			
			}
			else		
				playNextAnim(%client);
				
			Player::kill(%client);
			Client::onKilled(%client,%client);
		}
	}
	schedule("Client::clearItemShopping("@%client@");",0.5);	

}

$animNumber = 25;
function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;
	Player::setAnimation(%client,$animNumber++);
}
function Client::takeControl(%clientId, %objectId)
{
	// remote control
	if(%objectId == -1)
	{
		//echo("objectId = " @ %objectId);
		return;
	}

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
	{
		//echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
		return;
	}
	if(GameBase::getControlClient(%objectId) != -1)
	{
		//echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	if(GameBase::getDamageState(%objectId) != "Enabled")
		return;

	Turret::onAttemptControl(%objectId, %clientId);

	//%name = GameBase::getDataName(%objectId);
	//if(%name != CameraTurret && %name != DeployableTurret)
	//{
	//	if(!GameBase::isPowered(%objectId)) 
	//	{
	//		// echo("Turret " @ %objectId @ " not powered.");
	//		return;
	//	}
	//}
	//if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
	//	!$TestCheats) {
	//	Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
	//		return;
	//}
	//if(GameBase::getDamageState(%objectId) == "Enabled") {
	//	Client::setControlObject(%clientId, %objectId);
	//	Client::setGuiMode(%clientId, $GuiModePlay);
	//}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
	Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
	%ownedObject = Client::getOwnedObject(%clientId);
	%ctrlObject = Client::getControlObject(%clientId);
	if(%ownedObject != %ctrlObject)
	{
		if(%ownedObject == -1 || %ctrlObject == -1)
			return;
		if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
			return;
		Client::setControlObject(%clientId, %ownedObject);
	}
	GameBase::virtual(%ctrlObject, onDismount, %ctrlObject, %clientID);
}

function UnstasisMsg(%damagedClient)
{
	Client::SendMessage(%damagedClient,1,"You are free from Stasis.");
}

function Shock_Damage(%clientId, %player) 
{
	Client::sendMessage(%clientId,1,"Your energy systems are fried!");
	Player::unmountItem(%player,$WeaponSlot);
	if($shockTime[%clientId] == 0) 
	{
		GameBase::setEnergy(%player,0);
		GameBase::setRechargeRate(%player,0);
		$shockTime[%clientId] = 14;
		checkPlayerShock(%clientId, %player);
	}
	else 
		$shockTime[%clientId] = 14;
}

function checkPlayerShock(%clientId, %player) 
{
	if($shockTime[%clientId] > 0) 
	{
		$shockTime[%clientId] -= 2;
		schedule("checkPlayerShock(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else 
	{
		Client::sendMessage(%clientId,1,"Your energy systems are back to normal.");
		GameBase::setRechargeRate(%player,8);
	}
}

function Tank_Hover(%clientId, %player)
{
	if ($tankhover[%clientId])
	{
		%velocity = 0;
		%zVec = 1.75;
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%player),%velocity,%zVec);
		Player::applyImpulse(%player,%jumpDir);
		schedule("Tank_Hover(" @ %clientId @ ", " @ %player @");",0.01,%player);
	}
}


