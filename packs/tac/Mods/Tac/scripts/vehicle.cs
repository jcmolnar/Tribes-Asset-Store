//----------------------------------------------------------------------------
//

//-- Start MOD -- //

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 18.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.35;
	maxPitch = 0.25;
	maxSpeed = 35;
	minSpeed = -10;
	lift = 0.85;
	maxAlt = 15;
	maxVertical = 8;
	maxDamage = 0.8;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 120;
	accel = 0.35;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "FLPC";
};

//-- End   MOD -- //

FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 18.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.25;
	maxPitch = 0.175;

//-- Start MOD -- //

	maxSpeed = 30;

//-- End   MOD -- //

	minSpeed = -10;
	lift = 0.65;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 150;
	accel = 0.25;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "LPC";
};

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc";
	shieldShapeName = "shield_large";
	mass = 18.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.25;
	maxPitch = 0.175;
	maxSpeed = 25;
	minSpeed = -7;
	lift = 0.45;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 2.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 180;
	accel = 0.25;

	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "HPC";
};


//----------------------------------------------------------------------------

//-- Start MOD -- //

$Vehicle[Scout, Score] = 2;
$Vehicle[LPC, Score] = 2;
$Vehicle[HPC, Score] = 2;

//-- End   MOD -- //

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 1.0;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 1.0;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;


//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
	if(GameBase::getDataName(%this) == Scout)
		Schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.1, %this);
	//Reset vehicle slots.
	%this.hasPilot = false;
	%this.objectLastMount = "";
	%this.clLastMount = "";
	if(GameBase::getDataName(%this) == HAPC)
			%numSlots = 4;
		else
			%numSlots = 2;
	for(%i=0;%i<%numSlots;%i++)
		%this.Seat[%i] = "";
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
	{
		if(getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{
	        if( Player::isAiControlled(%object) )
        			return;

// - BW Admin Mod - Bug Fix
               if(%object.Station != "")
               {
               		Client::sendMessage(Player::getClient(%object),0,"You must leave the Inventory Station to pilot the vehicles.~wError_Message.wav");
               		return;
               }
// - BW Admin Mod - Bug Fix End

            %armor = Player::getArmor(%object);
		    %client = Player::getClient(%object);
			%CurrentBackpack = Player::getMountedItem(%client,$BackpackSlot);

			if (((!%this.hasPilot) && (%armor == "marmor" || %armor == "mfemale") && Vehicle::canMount (%this, %object) && (%CurrentBackpack != "DeployableAmmoPack") && (%CurrentBackpack != "DeployableInvPack") && (%CurrentBackpack != "TurretPack")) || ((%client.isTester == "true") && Vehicle::canMount (%this, %object)))
			{

				%this.hasPilot = true;
				Vehicle::TACReturnFlag(%object);

				if(!%this.powerless)
				{
					%weapon = Player::getMountedItem(%object,$WeaponSlot);
					if(%weapon != -1)
					{
						%object.lastWeapon = %weapon;
						Player::unMountItem(%object,$WeaponSlot);
					}
					Client::setControlObject(%client, %this);
				}
				else
				{
					Client::sendMessage(%client,0,"This vehicle's electrical system has been disabled.");
				}
				Player::setMountObject(%object, %this, 1);
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%object.driver= 1;
		        %object.vehicle = %this;
		        %this.objectLastMount = %object;
				%this.clLastMount = %client;
				UpdateHUDPlayerData(%object,%this,"pilot mount");
			}
			else if(GameBase::getDataName(%this) != temp)
			{

			 	%mountSlot= Vehicle::findEmptySeat(%this,%client);
				if(%mountSlot)
				{
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
					UpdateHUDPlayerData(%object,%this,"passenger mount");
				}
				//-----------------autowaypoint pilot------------
				if(%object.carryflag != "")
				{
					%pilotclientId = GameBase::getControlClient(%this);
					%flag = %client.flagnumber;
					Flag::setWaypoint(%pilotclientId, %flag);
					%flag.lastpilot = %this.clLastMount;
				}
				//=================================================
			}
			// - BW Admin Mod - Long Walk Home Mod
			else if (%object.carryflag != "" && $TAC::walk)
				Client::sendMessage(Player::getClient(%object),0,"You cannot pilot vehicles while carrying the flag!~wError_Message.wav");
			// - BW Admin Mod - End
			else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be in Medium Armor and not carrying stations to pilot the vehicles.~wError_Message.wav");
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1) {
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++) {
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") {
	  		%distance = %newDistance;
			%closePos = %i;
		}
	}
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	if(%passenger.driver == 1)
	{
		Vehicle::dismount(%this,%mom);
		return;
	}
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   %passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
		UpdateHUDPlayerData(%passenger,%this,"passenger dismount");
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
   Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
   	%cl = GameBase::getControlClient(%this);
	if((%cl == -1) && (%this.hasPilot == true))
		%cl = %this.clLastMount;
	if(%cl != -1)
   	{
      	%pl = Client::getOwnedObject(%cl);
      	if(getObjectType(%pl) == "Player")
      	{
		   // dismount the player
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0)))
			{
				Client::setControlObject(%cl, %this);
				%this.hasPilot = false;
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 	Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				UpdateHUDPlayerData(%pl,%this,"pilot dismount");
				if(%pl.lastWeapon != "")
				{
					Player::useItem(%pl,%pl.lastWeapon);
					%pl.lastWeapon = "";
      			}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   	}
}



function Vehicle::onDestroyed (%this,%mom)
{
	Vehicle::TACPoints(%this,%mom);
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1)
	{
		if(%this.hasPilot)
		{
			UpdateHUDPlayerData(%pl,0,"passenger dismount");
		}
		Player::setMountObject(%pl, -1, 0);
		Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "")
		{
			Player::useItem(%pl,%pl.lastWeapon);
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
		%pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "")
		{
			%pl = Client::getOwnedObject(%this.Seat[%i]);
			UpdateHUDPlayerData(%pl,%this,"passenger dismount");
			Player::setMountObject(%pl, -1, 0);
			Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
			%pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
}



function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%pilotclient = GameBase::getControlClient(%this);
	$Vehicle::[%this, LastDamaged] = %object;
	if (%type == $ImpactDamageType)
		$Vehicle::[%this, LastDamaged] = %this;

	%shooterClient = %object;
	if((GameBase::getTeam(%shooterClient) == GameBase::getTeam(%this)) && ((%shooterClient.rd == true) || ($TAC::ReverseDamageModeOn == true)))
	{
		Admin::ReverseDamage(%object,%type,%value,%pos,%vec,%mom,"torso","front_left");
		Client::sendMessage(%shooterClient,0,"You just harmed you teams apc and took " @ $TAC::ReverseFactor @ "x the damage you caused!");
	}


	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	APCHUDDamage(%this);

	if(GameBase::getEnergy(%this) < 10)
	{
		Vehicle::shutdown(%this);
	}
}


function Vehicle::shutdown(%this)
{
	if(!%this.powerless)
	{
		//--plays custom sound SoundAPCShutDown.wav----------
		playSound (SoundAPCShutDown, GameBase::getPosition(%this));

		%cl = GameBase::getControlClient(%this);

		//--display message of shutdown to apc clients--
		if(GameBase::getDataName(%this) == HAPC)
			%numSlots = 4;
		else
			%numSlots = 2;
		%count=0;
		for(%i=0;%i<%numSlots;%i++)
			if(%this.Seat[%i] != "")
				Client::sendMessage(%this.Seat[%i],0,"Power system overloaded. System shutting down.");
		Client::sendMessage(%cl,0,"Power system overloaded. System shutting down.");
		GameBase::setRechargeRate (%this, 0);
		schedule("Vehicle::powerup(" @ %this @ ");",15);
		%this.powerless = true;
		if(%cl != -1)
		{
			%pl = Client::getOwnedObject(%cl);
			if(getObjectType(%pl) == "Player")
			{
				Client::setControlObject(%cl, %pl);
				if(%pl.lastWeapon != "")
				{
					Player::useItem(%pl,%pl.lastWeapon);
					%pl.lastWeapon = "";
				}
			}
		}
	}
}


function Vehicle::powerup(%this)
{
	if(%this.powerless)
	{
		//--plays custom sound SoundAPCPowerup.wav----------
		if(GameBase::getDataName(%this) == HAPC)
			%numSlots = 4;
		else
			%numSlots = 2;
		%count=0;
		for(%i=0;%i<%numSlots;%i++)
			if(%this.Seat[%i] != "")
				Client::sendMessage(%this.Seat[%i],0,"Power system restored. Powering up.");
		playSound (SoundAPCPowerup, GameBase::getPosition(%this));
		GameBase::setRechargeRate (%this, 10);
		%this.powerless = false;
		%client = %this.clLastMount;
		%object = %this.objectLastMount;
		if((%object.driver == 1) && (%object.vehicle = %this))
		{
			Client::sendMessage(%client,0,"Power system restored. Powering up.");
			Client::setControlObject(%client, %this);
			%weapon = Player::getMountedItem(%client,$WeaponSlot);
			if(%weapon != -1)
			{
				%object.lastWeapon = %weapon;
				Player::unMountItem(%object,$WeaponSlot);
			}
		}
	}
}


function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}




function Vehicle::TACPoints(%this,%mom)
{
	if($Vehicle::[%this, LastDamaged] == "false")
		return;

	%VehicleTeam = GameBase::getTeam(%this);
	%desc = GameBase::getDataName(%this).description;

	if($Vehicle::[%this, LastDamaged] == %this)
	{
		// Pilot Crashed APC
		%playerClient = %this.clLastMount;
		%playerTeam = GameBase::getTeam(%playerClient);
		%playerName = Client::getName(%playerClient);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else
			%enemyTeam = 0;
		if (%playerName != "")
		{
			Client::sendMessage(%playerClient, 0, "You crashed a " @ %desc @ " and lost 5 points from your score!");
			TeamMessages(1, %playerTeam, "Your team lost 2 points because " @ %playerName @ " crashed a " @ %desc @ ".~wSniper2.wav", %enemyTeam, "The " @ getTeamName(%VehicleTeam) @ " lost 2 points because " @ %playerName @ " crashed a " @ %desc @ ".~wmine_act.wav","The " @ getTeamName(%VehicleTeam) @ " lost 2 points because " @ %playerName @ " crashed a " @ %desc @ ".~wmine_act.wav");
		}
		else
			TeamMessages(1, %playerTeam, "The " @ getTeamName(%VehicleTeam) @ " team lost 2 points from crashing a " @ %desc @ ".~wSniper2.wav", %enemyTeam, "The " @ getTeamName(%VehicleTeam) @ " lost 2 points from crashing a " @ %desc @ ".~wmine_act.wav","The " @ getTeamName(%VehicleTeam) @ " lost 2 points from crashing a " @ %desc @ ".~wmine_act.wav");

		$teamScore[%playerTeam] -= 2;
		%playerClient.score -= 5;
		ObjectiveMission::checkScoreLimit();
		Game::refreshClientScore(%playerClient);
		ObjectiveMission::refreshTeamScores();
	}
	else
	{
		%playerClient = $Vehicle::[%this, LastDamaged];
		%playerTeam = GameBase::getTeam(%playerClient);
		%playerName = Client::getName(%playerClient);
		if(%VehicleTeam != %playerTeam)
		{
			if (%playerName != "")
			{
				// Vehicle Destroyed by Another Team
				Client::sendMessage(%playerClient, 0, "You destroyed a " @ getTeamName(%VehicleTeam) @ " " @ %desc @ " and scored 2 points!");
				TeamMessages(1, %playerTeam, "Your team scored 2 points because " @ %playerName @ " destroyed an enemy " @ %desc @ ".~wmine_act.wav", %VehicleTeam, "One of your team's " @ %desc @ " was destroyed by " @ %playerName @ " whos team gained 2 points.~wSniper2.wav", %playerName @ "'s team scored 2 points because " @ %playerName @ " destroyed an enemy " @ %desc @ ".~wmine_act.wav");
			}
			else
				TeamMessages(1, %playerTeam, "Your team scored 2 points because your enemy lost a " @ %desc @ ".~wmine_act.wav", %VehicleTeam, "One of your team's " @ %desc @ " was destroyed.~wSniper2.wav","One of the " @ getTeamName(%VehicleTeam) @ " team's " @ %desc @ " was destroyed.~wmine_act.wav");
			$teamScore[%playerTeam] += 2;
			%playerClient.score += 2;
			ObjectiveMission::checkScoreLimit();
			Game::refreshClientScore(%playerClient);
			ObjectiveMission::refreshTeamScores();

			//is player on an apc....give points to driver for kill as well
			%playerId = Client::getOwnedObject(%playerClient);

			if(%playerId.vehicle)
			{
				%vehicle = %playerId.vehicle;
				if(%vehicle.hasPilot)
				{
					%pilotcl = %vehicle.clLastMount;
					%pilotId = Client::getOwnedObject(%pilotcl);
					if((%pilotcl > 0) && (%pilotId.driver > 0))
					{
						%pilotcl.score += 1;
						Game::refreshClientScore(%pilotcl);
					}
				}
			}
		}
		else
		{
			if(%VehicleTeam == %playerTeam)
			{
				if (%playerName != "")
				{
					// Vehicle Destroyed by your Team
					Client::sendMessage(%playerClient, 0, "You destroyed one of your own team's " @ %desc @ " and have lost 5 points!");
					TeamMessages(1, %playerTeam, %playerName @ " lost your team 2 team points for destroying own team's " @ %desc @ ".~wSniper2.wav", %enemyTeam, %playerName @ " lost the " @ getTeamName(%VehicleTeam) @ "2 team points for destroying own team's " @ %desc @ ".~wmine_act.wav",%playerName @ " lost the " @ getTeamName(%VehicleTeam) @ " 2 team points for destroying own team's " @ %desc @ ".~wmine_act.wav");
				}
				else
					TeamMessages(1, %playerTeam, "Your teammate destroyed your own " @ %desc @ ".~wSniper2.wav", %enemyTeam, "Your enemy destroyed their own " @ %desc @ ".~wmine_act.wav", getTeamName(%VehicleTeam) @ " destroyed their own " @ %desc @ ".~wmine_act.wav");
				$teamScore[%playerTeam] -= 2;
				%playerClient.score -= 5;
				ObjectiveMission::checkScoreLimit();
				Game::refreshClientScore(%playerClient);
				ObjectiveMission::refreshTeamScores();
			}
		}
	}
}

function Vehicle::TACReturnFlag(%object)
{
	%client = Player::getClient(%object);
	if(%object.carryFlag != "")
	{
		%playerTeam = GameBase::getTeam(%object);
		%playerClient = Player::getClient(%object);
		%touchClientName = Client::getName(%playerClient);

		%flag = %object.carryFlag;
		%name = Item::getItemData(%flag);
		%flagTeam = GameBase::getTeam(%flag);

		// return flag
		%flag.atHome = true;
		%flag.carrier = -1;
		%flag.lastpilot = 0;
		Item::hide(%flag, false);
		$flagAtHome[1] = true;
		GameBase::setPosition(%flag, %flag.originalPosition);
		Item::setVelocity(%flag, "0 0 0");

		// player loses the flag
		Player::setItemCount(%object, Flag, 0);
		%object.carryFlag = "";
		Flag::clearWaypoint(%playerClient, false);

		// message players
		MessageAllExcept(%playerClient, 0, %touchClientName @ " tried to pilot an APC and carry the flag!~wflagreturn.wav");
		Client::sendMessage(%playerClient, 0, "You can NOT carry the flag and pilot an APC!~wflagreturn.wav");
		teamMessages(1, %flagTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");

		// unknown..
		%flag.pickupSequence++;
		ObjectiveMission::ObjectiveChanged(%flag);
	}
}


//================================================================================
//====================Vehicle Smoke Trails Data===================================
//================================================================================
//
ExplosionData vehiclesmokeExp
{
	shapeName = "smoke.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	lightRange = 0;
	timeZero = 0.250;
	timeOne = 0.35;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

MineData VehicleDummy
{
	className = "Mine";
    shapeFile = "breath";
    shadowDetailMask = 1;
    explosionId = mineExp;
	explosionRadius = 0;
	damageValue = 0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.0001;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
	mass = 0;
	drag = 100.0;
};

GrenadeData VehicleSmokeGren
{
	explosionTag       = vehiclesmokeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 0.0;
	elasticity         = 0.0;
	damageClass        = 1;
	damageValue        = 0;
	damageType         = $MineDamageType;
	explosionRadius    = 0;
	kickBackStrength   = 0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
};

function VehicleDummy::Detonate(%this,%ismoving)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	if (!%player)
		return;
	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);
	%padd = "0 0 2.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	if(!%ismoving)
		schedule ("Projectile::spawnProjectile(VehicleSmokeGren, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
	else
	{
		%velX = getWord(%ismoving, 0);
		%velY = getWord(%ismoving, 1);
		if(%velX >= %velY)
			%topvel = %velX;
		else
			%topvel = %velY;

		%timeperiod = ((%topvel/(%this.maxSpeed))*-0.20);
		if(%timeperiod > 0)
			%timeperiod = %timeperiod * -1;
		%timeperiod = %timeperiod + 1;
		schedule ("Projectile::spawnProjectile(VehicleSmokeGren, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",%timeperiod);
	}
}

function Vehicle::SetSmoke(%this)
{
	if(%this.fading != "")
	{
		Schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.3, %this);
		return;
	}
	Vehicle::CheckSmoke(%this);
}


function Vehicle::CheckSmoke(%this)
{
	%vel = Item::getVelocity(%this);
	%velX = getWord(%vel, 0);
	%velY = getWord(%vel, 1);
	//moving jet smoke
	if(%velX > 4 || %velX < -4 || %velY > 4 || %velY < -4)
	{
		%thisPos = GameBase::getPosition(%this);
		%xcoord = getWord(%thisPos,0);
		%ycoord = getWord(%thisPos,1);
		%zcoord = getWord(%thisPos,2) - 1;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],%vel);
		deleteObject(%obj[%this]);

		Schedule("Vehicle::CheckSmoke(" @ %this @ ");", 0.10, %this);
	}
	//slow moving or still jet smoke
	else if(%this)
	{
		%thisPos = GameBase::getPosition(%this);
		%xcoord = getWord(%thisPos,0) - 1.5;
		%ycoord = getWord(%thisPos,1) - 1.5;
		%zcoord = getWord(%thisPos,2) - 3;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],false);
		deleteObject(%obj[%this]);

		%xcoord = getWord(%thisPos,0) + 1.5;
		%ycoord = getWord(%thisPos,1) - 1.5;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],false);
		deleteObject(%obj[%this]);

		%xcoord = getWord(%thisPos,0) + 1.5;
		%ycoord = getWord(%thisPos,1) + 1.5;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],false);
		deleteObject(%obj[%this]);

		%xcoord = getWord(%thisPos,0) - 1.5;
		%ycoord = getWord(%thisPos,1) + 1.5;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],false);
		deleteObject(%obj[%this]);

		Schedule("Vehicle::CheckSmoke(" @ %this @ ");", 0.4, %this);
	}
	else
		return;
}


