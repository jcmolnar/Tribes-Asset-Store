exec(combatDrones);

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 8.0;
	drag = -0.1;
	density = 0.1;
	maxBank = 3.95;
	maxPitch = 0.95;
	maxSpeed = 45;
	minSpeed = -20;
	lift = 0.95;
	maxAlt = 325;
	maxVertical = 10;
	maxDamage = 20.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.95;
	groundDamageScale = 1.0;
	reloadDelay = 1.0;
	repairRate = 0;
	fireSound = ricochet1;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Apache";
};

FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 15.0;
	drag = 0.0;
	density = 1.2;
	maxBank = 3.95;
	maxPitch = 1.5;
	maxSpeed = 35;
	minSpeed = -20;
	lift = 0.75;
	maxAlt = 120;
	maxVertical = 30;
	maxDamage = 28.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.5;

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
	description = "Huey";
};

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc";
	shieldShapeName = "shield_large";
	mass = 18.0;
	drag = 0.0;
	density = 1.2;
	maxBank = 3.9;
	maxPitch = 1.5;
	maxSpeed = 30;								   
	minSpeed = -20;
	lift = 0.6;
	maxAlt = 120;
	maxVertical = 30;
	maxDamage = 45.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

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
	description = "Blackhawk";
};


//----------------------------------------------------------------------------

$DamageScale[Scout, $ImpactDamageType] = 6.0;
$DamageScale[Scout, $BulletDamageType] = 0.7;
$DamageScale[Scout, $BBDamageType] = 10.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.27;
$DamageScale[Scout, $ExplosionDamageType] = 2.0;
$DamageScale[Scout, $ShrapnelDamageType] = 5.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 35.0;
$DamageScale[Scout, $LaserDamageType] = 0.7;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.7;
$DamageScale[Scout, $ElectricityDamageType] = 1000.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;
$DamageScale[Scout, $FighterGunDamageType] = 1.5;
$DamageScale[Scout, $KamikazeDamageType] = 5.0;
$DamageScale[Scout, $ElectricDamageType] = 1.0;
$DamageScale[Scout, $RocketDamageType] = 30.0;
$DamageScale[Scout, $SniperDamageType] = 0.2;
$DamageScale[Scout, $EMPDamageType]	= 20.0;
$DamageScale[Scout, $PlasmaCannonDamageType] = 1.27;
$DamageScale[Scout, $FlameDamageType] = 1.0;
$DamageScale[Scout, $AntiMatterDamageType] = 1.0;
$DamageScale[Scout, $SatchelDamageType] = 1.0;
$DamageScale[Scout, $BombDamageType] = 1.0;
$DamageScale[Scout, $DroneDamageType] = 2.0;
$DamageScale[Scout, $SurpriseDamageType] = 1.0;
$DamageScale[Scout, $BulletDmgType1] = 1.0;
$DamageScale[Scout, $BulletDmgType2] = 1.0;
$DamageScale[Scout, $BulletDmgType3] = 1.0;
$DamageScale[Scout, $BulletDmgType4] = 1.0;
$DamageScale[Scout, $BulletDmgType5] = 1.0;
$DamageScale[Scout, $BulletDmgType6] = 1.0;
$DamageScale[Scout, $BulletDmgType7] = 1.0;
$DamageScale[Scout, $BulletDmgType8] = 1.0;
$DamageScale[Scout, $BulletDmgType9] = 1.0;


$DamageScale[LAPC, $ImpactDamageType] = 6.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $BBDamageType] = 10.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 6.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 15.5;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 1.0;
$DamageScale[LAPC, $ElectricityDamageType] = 100.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;
$DamageScale[LAPC, $FighterGunDamageType] = 1.0;
$DamageScale[LAPC, $KamikazeDamageType] = 5.0;
$DamageScale[LAPC, $ElectricDamageType] = 1.0;
$DamageScale[LAPC, $RocketDamageType] = 30.5;
$DamageScale[LAPC, $SniperDamageType] = 0.2;
$DamageScale[LAPC, $EMPDamageType]	= 20.0;
$DamageScale[LAPC, $PlasmaCannonDamageType] = 1.0;
$DamageScale[LAPC, $FlameDamageType] = 1.0;
$DamageScale[LAPC, $AntiMatterDamageType] = 1.0;
$DamageScale[LAPC, $SatchelDamageType] = 1.0;
$DamageScale[LAPC, $BombDamageType] = 1.0;
$DamageScale[LAPC, $DroneDamageType] = 1.0;
$DamageScale[LAPC, $SurpriseDamageType] = 1.0;
$DamageScale[LAPC, $BulletDmgType1] = 1.0;
$DamageScale[LAPC, $BulletDmgType2] = 1.0;
$DamageScale[LAPC, $BulletDmgType3] = 1.0;
$DamageScale[LAPC, $BulletDmgType4] = 1.0;
$DamageScale[LAPC, $BulletDmgType5] = 1.0;
$DamageScale[LAPC, $BulletDmgType6] = 1.0;
$DamageScale[LAPC, $BulletDmgType7] = 1.0;
$DamageScale[LAPC, $BulletDmgType8] = 1.0;
$DamageScale[LAPC, $BulletDmgType9] = 1.0;


$DamageScale[HAPC, $ImpactDamageType] = 6.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $BBDamageType] = 10.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 6.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 15.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 1.0;
$DamageScale[HAPC, $ElectricityDamageType] = 100.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;
$DamageScale[HAPC, $FighterGunDamageType] = 1.0;
$DamageScale[HAPC, $KamikazeDamageType] = 5.0;
$DamageScale[HAPC, $ElectricDamageType] = 1.0;
$DamageScale[HAPC, $RocketDamageType] = 30.0;
$DamageScale[HAPC, $SniperDamageType] = 0.2;
$DamageScale[HAPC, $EMPDamageType]	= 20.0;
$DamageScale[HAPC, $PlasmaCannonDamageType] = 1.0;
$DamageScale[HAPC, $FlameDamageType] = 1.0;
$DamageScale[HAPC, $AntiMatterDamageType] = 1.0;
$DamageScale[HAPC, $SatchelDamageType] = 1.0;
$DamageScale[HAPC, $BombDamageType] = 1.0;
$DamageScale[HAPC, $DroneDamageType] = 1.0;
$DamageScale[HAPC, $SurpriseDamageType] = 1.0;
$DamageScale[HAPC, $BulletDmgType1] = 1.0;
$DamageScale[HAPC, $BulletDmgType2] = 1.0;
$DamageScale[HAPC, $BulletDmgType3] = 1.0;
$DamageScale[HAPC, $BulletDmgType4] = 1.0;
$DamageScale[HAPC, $BulletDmgType5] = 1.0;
$DamageScale[HAPC, $BulletDmgType6] = 1.0;
$DamageScale[HAPC, $BulletDmgType7] = 1.0;
$DamageScale[HAPC, $BulletDmgType8] = 1.0;
$DamageScale[HAPC, $BulletDmgType9] = 1.0;


//----------------------------------------------------------------------------

$ItemMax[hlarmor, FighterGun] = 1;
$ItemMax[hlfemale, FighterGun] = 1;
$ItemMax[larmor, FighterGun] = 1;
$ItemMax[lfemale, FighterGun] = 1;
$ItemMax[earmor, FighterGun] = 1;
$ItemMax[efemale, FighterGun] = 1;
$ItemMax[marmor, FighterGun] = 1;
$ItemMax[mfemale, FighterGun] = 1;
$ItemMax[harmor, FighterGun] = 1;
$ItemMax[uharmor, FighterGun] = 1;

$ItemMax[hlarmor, VehicleRocket] = 1;
$ItemMax[hlfemale, VehicleRocket] = 1;
$ItemMax[larmor, VehicleRocket] = 1;
$ItemMax[lfemale, VehicleRocket] = 1;
$ItemMax[earmor, VehicleRocket] = 1;
$ItemMax[efemale, VehicleRocket] = 1;
$ItemMax[marmor, VehicleRocket] = 1;
$ItemMax[mfemale, VehicleRocket] = 1;
$ItemMax[harmor, VehicleRocket] = 1;
$ItemMax[uharmor, VehicleRocket] = 1;

$ItemMax[hlarmor, VehicleBomb] = 1;
$ItemMax[hlfemale, VehicleBomb] = 1;
$ItemMax[larmor, VehicleBomb] = 1;
$ItemMax[lfemale, VehicleBomb] = 1;
$ItemMax[earmor, VehicleBomb] = 1;
$ItemMax[efemale, VehicleBomb] = 1;
$ItemMax[marmor, VehicleBomb] = 1;
$ItemMax[mfemale, VehicleBomb] = 1;
$ItemMax[harmor, VehicleBomb] = 1;
$ItemMax[uharmor, VehicleBomb] = 1;

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
	%this.weaponry = "";
	%this.module = "";
	%this.leftpad = "false";
	%this.shielded = 0;
	%this.armoured = 0;
	%this.sped = 0;
	%this.loaded = 0;

}

function CheckModules(%this,%object)
{
	if (%this.module != "")
	{
		if (%this.module == ShieldModule)
		{
			%this.shieldStrength = 0.03;	// Damage Modifier
			%this.shielded = 1;
		}
		if (%this.module == ArmorModule)
		{
			if (!%this.armoured)
			{
				%this.accel *= 0.8;
				%this.maxSpeed *= 0.8;
			}
			%this.armoured = 1;
		}
		if (%this.module == RepairModule)
		{
			GameBase::setAutoRepairRate(%this,0.03);
			%this.autorep = 1;
		}
		if (%this.module == SpeedModule)
		{
			if (!%this.sped)
			{
				%this.accel *= 1.5;
				%this.maxSpeed *= 1.5;
			}
			%this.sped = 1;
		}
		if (%this.module == KamikazeModule)
		{
			if (!%this.loaded)
			{
				%this.accel *= 1.2;
				%this.maxSpeed *= 1.2;
			}
			%this.loaded = 1;
		}
	}
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
	{
		if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{
//		if( Player::isAiControlled(%object) )
//		return;

			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);
			if ((GameBase::getDataName(%this) != Scout) && (%armor != "uharmor") && Vehicle::canMount (%this, %object))
			{
				if (!Player::isAiControlled(%object))  //No bots allowed as drivers!! Only as passengers!
				{
					%weapon = Player::getMountedItem(%object,$WeaponSlot);
					if(%weapon != -1)
					{
						%object.lastWeapon = %weapon;
						Player::unMountItem(%object,$WeaponSlot);
					}
					Player::setMountObject(%object, %this, 1);
					Client::setControlObject(%client, %this);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
					%object.driver= 1;
					%object.vehicle = %this;
					%this.leftpad = "true";
					%this.pilot = %client;
					CheckModules(%this,%object);
					if (%this.shielded)
					{
						if (%object.shieldStrength < 0)
							%object.shieldStrength = 0;
						%object.shieldStrength += 0.012;
					}
					if (%this.autorep)
					{
						%rate = GameBase::getAutoRepairRate(%object) + 0.03;
						GameBase::setAutoRepairRate(%object,%rate);
					}
					%this.clLastMount = %client;
				}
			}
			else if ((%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor"  || %armor == "hlfemale") && Vehicle::canMount (%this, %object))
			{
				if (!Player::isAiControlled(%object))  //No bots allowed as drivers!! Only as passengers!
				{
					%weapon = Player::getMountedItem(%object,$WeaponSlot);
					if(%weapon != -1)
					{
						%object.lastWeapon = %weapon;
						Player::unMountItem(%object,$WeaponSlot);
					}
					Player::setMountObject(%object, %this, 1);
					Client::setControlObject(%client, %this);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
					%object.driver= 1;
					%object.vehicle = %this;
					%this.leftpad = "true";
					%this.pilot = %client;
					CheckModules(%this,%object);
					if (%this.shielded)
					{
						if (%object.shieldStrength < 0)
							%object.shieldStrength = 0;
						%object.shieldStrength += 0.012;
					}
					if (%this.autorep)
					{
						%rate = GameBase::getAutoRepairRate(%object) + 0.03;
						GameBase::setAutoRepairRate(%object,%rate);
					}
					%this.clLastMount = %client;

				}
			}
			else if(GameBase::getDataName(%this) != Scout) 
			{
			 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) 
				{
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				}
			}
			else if (GameBase::getControlClient(%this) == -1)
			{
				if (%armor == "uharmor")
					Client::sendMessage(Player::getClient(%object),0,"Heavy gunners cannot pilot vehicles.~wError_Message.wav");
				else
					Client::sendMessage(Player::getClient(%object),0,"You must be in recon or sniper Armor to pilot the Fighter.~wError_Message.wav");
			}
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	%player = Client::getOwnedObject(%client);
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "")
		{
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1)
	{
		%this.Seat[%lastEmpty-2] = %client;
		%client.passenger = 1;
		Player::setItemCount(%client,QuadCannon,1);
		Player::useItem(%client,QuadCannon);

		if (%this.shielded)
		{
			if (%player.shieldStrength < 0)
				%player.shieldStrength = 0;
			%player.shieldStrength += 0.012;
		}
		if (%this.autorep)
		{
			%rate = GameBase::getAutoRepairRate(%object) + 0.03;
			GameBase::setAutoRepairRate(%object,%rate);
		}

		return %lastEmpty;
	}
	else if (%count > 1)
	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		%client.passenger = 1;
		Player::setItemCount(%client,QuadCannon,1);
		Player::useItem(%client,QuadCannon);

		
		if (%this.shielded)
		{
			if (%player.shieldStrength < 0)
				%player.shieldStrength = 0;
			%player.shieldStrength += 0.012;
		}
		if (%this.autorep)
		{
			%rate = GameBase::getAutoRepairRate(%object) + 0.03;
			GameBase::setAutoRepairRate(%object,%rate);
		}

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
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor"  || %armor == "hlfemale")
	{
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
	{	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
		%passenger.vehicle= "";
		%client.passenger = 0;
		Player::setItemCount(%client,QuadCannon,0);


		if (%this.shielded)
		{
			%passenger.shieldStrength -= 0.012;
			if (%passenger.shieldStrength < 0)
				%passenger.shieldStrength = 0;
		}
		if (%this.autorep)
		{
			%rate = GameBase::getAutoRepairRate(%passenger) - 0.03;
			if(%rate < 0)
				%rate = 0;
			GameBase::setAutoRepairRate(%passenger,%rate);
		}
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);


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
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		if(getObjectType(%pl) == "Player")
		{
			// dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) 
			{
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
				if(%pl.lastWeapon != "")
				{
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";

		      		}
				%pl.driver = "";
				%pl.vehicle = "";
				%this.pilot = "";
				// Unremark these lines to make plane point down when you bail
				// GameBase::setRotation(%this, "0 0 3");
				%spin = GameBase::getRotation(%this);
				schedule("Spinout(" @ %this @ " , 10);",0.1,%this);

				if (%this.shielded)
				{
					%pl.shieldStrength -= 0.12;
					if (%pl.shieldStrength < 0)
						%pl.shieldStrength = 0;
				}
				if (%this.autorep)
				{
					%rate = GameBase::getAutoRepairRate(%pl) - 0.03;
					if(%rate < 0)
						%rate = 0;
					GameBase::setAutoRepairRate(%pl,%rate);
				}
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
	}
}



function Spinout(%this, %count) // Cool aircraft spinout when you eject
{
	if(%count && %this)
	{
       
	%spin = GameBase::getRotation(%this);
	
	%xRot = getWord(%spin,0);
	%yRot = getWord(%spin,1);
	%zRot = getWord(%spin,2);
	
	%this.maxVertical = -30;
	
	%vel = Item::getVelocity(%this); //For some reason, you can't control vehicle velocity with these controls
	%xSpd = getWord(%vel,0) * 1.1;
	%ySpd = getWord(%vel,1) * 1.1;
	%zSpd = getWord(%vel,2) * 1.1;
		
	%rot = " " @ %xrot @ " " @ %yrot + 0.1 @ " " @ %zRot;

	%offset = "0.1 0.0 0.0";
	GameBase::setRotation(%this,Vector::add(%rot, %offset));

	// Item::setVelocity(%this, xSpd @ " " @ ySpd @ " " @ zspd);
	// GameBase::setVelocity(%this, xSpd @ " " @ ySpd @ " " @ zspd);

	%count -= 1;
	if(%count == 1)
	{
	
	}

	schedule("spinout(" @ %this @ " , " @ %count @ ");",0.07,%this);//0.5++++++++
	}
}


function Vehicle::onDestroyed (%this,%mom)
{
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;

// ------------------------------------------DEADTACO MAKE BIG PLANE BOOM!

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);


	 for(%i = 1; %i < 5; %i++)
	 {
	
	%rndx = (getRandom() * 8) - 8;
	%rndy = (getRandom() * 8) - 8;
	%rndz =(getRandom() * 25) - 8;
	Projectile::spawnProjectile("VehiclePart",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);

	 }

	 for(%i = 1; %i < 12; %i++)
	 {
	
	%rndx = (getRandom() * 3) - 3;
	%rndy = (getRandom() * 3) - 3;
	%rndz =(getRandom() * 15) - 5;
	Projectile::spawnProjectile("VehiclePart",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);

	 }

	 for(%i = 1; %i < 5; %i++)
	 {
	
	%rndx = (getRandom() * 4) - 4;
	%rndy = (getRandom() * 4) - 4;
	%rndz =(getRandom() * 15) - 5;
	Projectile::spawnProjectile("TurretPart",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);

	 }

	
	%cl = GameBase::getControlClient(%this);

	if (GameBase::getControlClient(%this) != -1)
	{
		player::blowUp(%cl);
		%rndx = (getRandom() * 1) - 1;
		%rndy = (getRandom() * 1) - 1;
		%rndz =(getRandom() * 15) - 5;
		Projectile::spawnProjectile("deadguyproj",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);
	}

		Player::setItemCount(%cl,QuadCannon,0);

		if(GameBase::getDataName(%this) != Scout) //From deadtaco - makes plane to appear to crash
			{
			 %trans = GameBase::getMuzzleTransform(%this);
		 	 %vel = Item::getVelocity(%this);
		 	 Projectile::spawnProjectile("Planedead2",%trans,%this,%vel);
			}


// ------------------------------------------



	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1)
	{
		Player::setMountObject(%pl, -1, 0);
		Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") 
		{
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
		%pl.vehicle = "";
		%this.pilot = "";
		if (%this.shielded)
		{
			%pl.shieldStrength -= 0.12;
			if (%pl.shieldStrength < 0)
				%pl.shieldStrength = 0;
		}

		if (%this.autorep)
		{
			%rate = GameBase::getAutoRepairRate(%pl) - 0.03;
			if(%rate < 0)
				%rate = 0;
			GameBase::setAutoRepairRate(%pl,%rate);
		}
	}

	for(%i = 0 ; %i < 4 ; %i++)
	{
		if(%this.Seat[%i] != "")
		{
			%pl = Client::getOwnedObject(%this.Seat[%i]);
			%cl = Player::getClient(%pl);
			Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
			%pl.vehicle= "";
			%cl.passenger = 0;
		Player::setItemCount(%cl,QuadCannon,1);


			if (%this.shielded)
			{
				%pl.shieldStrength -= 0.012;
				if (%pl.shieldStrength < 0)
					%pl.shieldStrength = 0;
			}
			if (%this.autorep)
			{
				%rate = GameBase::getAutoRepairRate(%pl) - 0.03;
				if(%rate < 0)
					%rate = 0;
				GameBase::setAutoRepairRate(%pl,%rate);
			}
		}
	}
	if (%this.impacted)
		calcRadiusDamage(%this, $KamikazeDamageType, 10, 5, 50, 30, 20, 25, 15, 450, 200);
	else
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	if (%this.armoured)
		%value *= 0.20;
	if (%type == $ImpactDamageType && %this.loaded)
	{
		%value *= 5.0;
		%this.impacted = 1;
	}
	else
		%this.impacted = 0;
	if (%this.shieldstrength > 0)
		StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	else
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
	return 1.0;
}

function Vehicle::onFire(%this,%slot)
{
	%this.firecount--;
	if (%this.firecount <= 0)
	{
		if (%this.weaponry != "")
		{
			%AmmoMinimum = %this.AmmoMinimum;
			%firesound = %this.firesound;
			%AmmoCost = %this.AmmoCost;
			%AmmoCount = Gamebase::getEnergy(%this);
			if(%AmmoCount >= %AmmoMinimum) 
			{
				%client = GameBase::getOwnerClient(%this);
				%trans = GameBase::getMuzzleTransform(%this);
				playSound(%firesound,GameBase::getPosition(%this));
				%vel = Item::getVelocity(%player);
				if (%this.multi > 1)
				{
					for(%i=0; %i < %this.multi; %i++)
					{
						Projectile::spawnProjectile(%this.attacktype,%trans,%this,%vel);
					}
				}
				else 
				{
					Projectile::spawnProjectile(%this.attacktype,%trans,%this,%vel);
				}
				%AmmoCount -= %AmmoCost;
				if (%AmmoCount < 0) %AmmoCount = 0;
				Gamebase::setEnergy(%this,%AmmoCount);
				%this.firecount = %this.firedelay;
			}
			else
				Client::sendMessage(GameBase::getOwnerClient(%this), 0,"Not enough energy to fire.");
		}
	}
}

