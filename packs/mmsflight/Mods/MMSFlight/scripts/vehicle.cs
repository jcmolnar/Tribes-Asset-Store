//----------------------------------------------------------------------------
//
// See EOF for more Vehicle Data
//
//----------------------------------------------------------------------------



FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = FlierRocket;
	reloadDelay = 2.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
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
	description = "Scout";
};

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
   maxSpeed = 25;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
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
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
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
$DamageScale[LAPC, $LaserDamageType] = 0.5;
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
$DamageScale[HAPC, $LaserDamageType] = 0.5;
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
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
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
					Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
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
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
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
				if(%pl.lastWeapon != "") {
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
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
	   %pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}




//----------------------------------------------------------------------------
//
// NEW VEHICLES!
//
// MMS Flight Academy Extra Data
//
//----------------------------------------------------------------------------
// Destroyer
//----------------------------------------------------------------------------

FlierData Destroyer
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 12.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = FusionBolt;
	reloadDelay = 0.5;
	repairRate = 0;
	fireSound = SoundFirePlasma;
	damageSound = SoundFlierCrash;
	ramDamage = 1.8;
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
	description = "Destroyer";
};

$DamageScale[Destroyer, $ImpactDamageType] = 1.5;
$DamageScale[Destroyer, $BulletDamageType] = 1.0;
$DamageScale[Destroyer, $PlasmaDamageType] = 1.0;
$DamageScale[Destroyer, $EnergyDamageType] = 1.0;
$DamageScale[Destroyer, $ExplosionDamageType] = 1.1;
$DamageScale[Destroyer, $ShrapnelDamageType] = 1.1;
$DamageScale[Destroyer, $DebrisDamageType] = 1.1;
$DamageScale[Destroyer, $MissileDamageType] = 1.1;
$DamageScale[Destroyer, $LaserDamageType] = 1.0;
$DamageScale[Destroyer, $MortarDamageType] = 1.1;
$DamageScale[Destroyer, $BlasterDamageType] = 0.5;
$DamageScale[Destroyer, $ElectricityDamageType] = 1.0;
$DamageScale[Destroyer, $MineDamageType]        = 1.1;

$VehicleInvList[DestroyerVehicle] = 1;
$DataBlockName[DestroyerVehicle] = Destroyer;
$VehicleToItem[Destroyer] = DestroyerVehicle;
$TeamItemMax[DestroyerVehicle] = 12;

$TeamItemCount[0 @ DestroyerVehicle] = 0;
$TeamItemCount[1 @ DestroyerVehicle] = 0;
$TeamItemCount[2 @ DestroyerVehicle] = 0;
$TeamItemCount[3 @ DestroyerVehicle] = 0;
$TeamItemCount[4 @ DestroyerVehicle] = 0;
$TeamItemCount[5 @ DestroyerVehicle] = 0;
$TeamItemCount[6 @ DestroyerVehicle] = 0;
$TeamItemCount[7 @ DestroyerVehicle] = 0;

ItemData DestroyerVehicle
{
	description = "Destroyer";
	className = "Vehicle";
   heading = "aVehicle";
	price = 650;
};





// Interceptor
//----------------------------------------------------------------------------

FlierData Interceptor
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 5.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.9;
   maxPitch = 0.9;
   maxSpeed = 200;
   minSpeed = -50;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.9;

	groundDamageScale = 1.0;

	projectileType = ChaingunBullet;
	reloadDelay = 0.05;
	repairRate = 0;
	fireSound = SoundChainTurretFire;
	damageSound = SoundTankCrash;
	ramDamage = 1.8;
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
	description = "Interceptor";
};

$DamageScale[Interceptor, $ImpactDamageType] = 2.0;
$DamageScale[Interceptor, $BulletDamageType] = 1.0;
$DamageScale[Interceptor, $PlasmaDamageType] = 1.5;
$DamageScale[Interceptor, $EnergyDamageType] = 1.5;
$DamageScale[Interceptor, $ExplosionDamageType] = 1.0;
$DamageScale[Interceptor, $ShrapnelDamageType] = 1.0;
$DamageScale[Interceptor, $DebrisDamageType] = 1.0;
$DamageScale[Interceptor, $MissileDamageType] = 1.0;
$DamageScale[Interceptor, $LaserDamageType] = 1.5;
$DamageScale[Interceptor, $MortarDamageType] = 1.0;
$DamageScale[Interceptor, $BlasterDamageType] = 1.5;
$DamageScale[Interceptor, $ElectricityDamageType] = 1.5;
$DamageScale[Interceptor, $MineDamageType]        = 1.0;

$VehicleInvList[IcptVehicle] = 1;
$DataBlockName[IcptVehicle] = Interceptor;
$VehicleToItem[Icpt] = IcptVehicle;
$TeamItemMax[IcptVehicle] = 15;

$TeamItemCount[0 @ IcptVehicle] = 0;
$TeamItemCount[1 @ IcptVehicle] = 0;
$TeamItemCount[2 @ IcptVehicle] = 0;
$TeamItemCount[3 @ IcptVehicle] = 0;
$TeamItemCount[4 @ IcptVehicle] = 0;
$TeamItemCount[5 @ IcptVehicle] = 0;
$TeamItemCount[6 @ IcptVehicle] = 0;
$TeamItemCount[7 @ IcptVehicle] = 0;

ItemData IcptVehicle
{
	description = "Interceptor";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
};







// Bomber
//----------------------------------------------------------------------------

GrenadeData BomberBomb
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = False;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 50.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.8;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 60;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.1;

   smokeName              = "smoke.dts";
};

FlierData Bomber
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer"; 
   shieldShapeName = "shield_medium";
   mass = 12.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

        projectileType = BomberBomb;
	reloadDelay = 0.3;
	repairRate = 0;
	fireSound = SoundFireGrenade;

	damageSound = SoundFlierCrash;
	ramDamage = 1.8;
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
	description = "Bomber";
};

$DamageScale[Bomber, $ImpactDamageType] = 1.0;
$DamageScale[Bomber, $BulletDamageType] = 1.0;
$DamageScale[Bomber, $PlasmaDamageType] = 1.0;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $ExplosionDamageType] = 1.0;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 1.0;
$DamageScale[Bomber, $LaserDamageType] = 0.5;
$DamageScale[Bomber, $MortarDamageType] = 1.0;
$DamageScale[Bomber, $BlasterDamageType] = 0.5;
$DamageScale[Bomber, $ElectricityDamageType] = 1.0;
$DamageScale[Bomber, $MineDamageType]        = 1.0;

$VehicleInvList[BomberVehicle] = 1;
$DataBlockName[BomberVehicle] = Bomber;
$VehicleToItem[Bomber] = BomberVehicle;
$TeamItemMax[BomberVehicle] = 10;

$TeamItemCount[0 @ BomberVehicle] = 0;
$TeamItemCount[1 @ BomberVehicle] = 0;
$TeamItemCount[2 @ BomberVehicle] = 0;
$TeamItemCount[3 @ BomberVehicle] = 0;
$TeamItemCount[4 @ BomberVehicle] = 0;
$TeamItemCount[5 @ BomberVehicle] = 0;
$TeamItemCount[6 @ BomberVehicle] = 0;
$TeamItemCount[7 @ BomberVehicle] = 0;

ItemData BomberVehicle
{
	description = "Bomber";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1500;
};








// Small Fortress
//----------------------------------------------------------------------------

FlierData SFortress
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
   maxSpeed = 10;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 5.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";	

        projectileType = GrenadeShell;
	reloadDelay = 0.9;
	repairRate = 0;
	fireSound = SoundFireGrenade;

	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Small Fortress";
};

$DamageScale[SFortress, $ImpactDamageType] = 1.0;
$DamageScale[SFortress, $BulletDamageType] = 1.0;
$DamageScale[SFortress, $PlasmaDamageType] = 1.0;
$DamageScale[SFortress, $EnergyDamageType] = 1.0;
$DamageScale[SFortress, $ExplosionDamageType] = 1.0;
$DamageScale[SFortress, $ShrapnelDamageType] = 1.0;
$DamageScale[SFortress, $DebrisDamageType] = 1.0;
$DamageScale[SFortress, $MissileDamageType] = 1.0;
$DamageScale[SFortress, $LaserDamageType] = 0.5;
$DamageScale[SFortress, $MortarDamageType] = 1.0;
$DamageScale[SFortress, $BlasterDamageType] = 0.5;
$DamageScale[SFortress, $ElectricityDamageType] = 1.0;
$DamageScale[SFortress, $MineDamageType]        = 1.0;

$VehicleInvList[SFortressVehicle] = 1;
$DataBlockName[SFortressVehicle] = SFortress;
$VehicleToItem[SFortress] = SFortressVehicle;
$TeamItemMax[SFortressVehicle] = 5;

$TeamItemCount[0 @ SFortressVehicle] = 0;
$TeamItemCount[1 @ SFortressVehicle] = 0;
$TeamItemCount[2 @ SFortressVehicle] = 0;
$TeamItemCount[3 @ SFortressVehicle] = 0;
$TeamItemCount[4 @ SFortressVehicle] = 0;
$TeamItemCount[5 @ SFortressVehicle] = 0;
$TeamItemCount[6 @ SFortressVehicle] = 0;
$TeamItemCount[7 @ SFortressVehicle] = 0;

ItemData SFortressVehicle
{
	description = "Small Fortress";
	className = "Vehicle";
   heading = "aVehicle";
	price = 2000;
};





// Large Fortress 
//----------------------------------------------------------------------------

SeekingMissileData MortarMissile
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;
   smokeName              = "mortartrail.dts";

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

FlierData LFortress
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
   maxSpeed = 7;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 10.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";

        projectileType = MortarMissile;
	reloadDelay = 0.6;
	repairRate = 0;
	fireSound = SoundFireMortar;

	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Large Fortress";
};

$DamageScale[LFortress, $ImpactDamageType] = 1.0;
$DamageScale[LFortress, $BulletDamageType] = 1.0;
$DamageScale[LFortress, $PlasmaDamageType] = 1.0;
$DamageScale[LFortress, $EnergyDamageType] = 1.0;
$DamageScale[LFortress, $ExplosionDamageType] = 1.0;
$DamageScale[LFortress, $ShrapnelDamageType] = 1.0;
$DamageScale[LFortress, $DebrisDamageType] = 1.0;
$DamageScale[LFortress, $MissileDamageType] = 1.0;
$DamageScale[LFortress, $LaserDamageType] = 0.5;
$DamageScale[LFortress, $MortarDamageType] = 1.0;
$DamageScale[LFortress, $BlasterDamageType] = 0.5;
$DamageScale[LFortress, $ElectricityDamageType] = 1.0;
$DamageScale[LFortress, $MineDamageType]        = 1.0;

$VehicleInvList[LFortressVehicle] = 1;
$DataBlockName[LFortressVehicle] = LFortress; 
$VehicleToItem[LFortress] = LFortressVehicle;
$TeamItemMax[LFortressVehicle] = 3;

$TeamItemCount[0 @ LFortressVehicle] = 0;
$TeamItemCount[1 @ LFortressVehicle] = 0;
$TeamItemCount[2 @ LFortressVehicle] = 0;
$TeamItemCount[3 @ LFortressVehicle] = 0;
$TeamItemCount[4 @ LFortressVehicle] = 0;
$TeamItemCount[5 @ LFortressVehicle] = 0;
$TeamItemCount[6 @ LFortressVehicle] = 0;
$TeamItemCount[7 @ LFortressVehicle] = 0;

ItemData LFortressVehicle
{
	description = "Large Fortress";
	className = "Vehicle";
   heading = "aVehicle";
	price = 3000;
};




// Advanced Interceptor
//----------------------------------------------------------------------------



RocketData XBShell
{
   bulletShapeName = "bullet.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};


FlierData AInterceptor
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 5.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.9;
   maxPitch = 0.9;
   maxSpeed = 100;
   minSpeed = -10;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.9;

	groundDamageScale = 1.0;

	projectileType = XBShell;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = SoundChainTurretFire;
	damageSound = SoundTankCrash;
	ramDamage = 1.8;
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
	description = "Adv. Interceptor";
};

$DamageScale[AInterceptor, $ImpactDamageType] = 2.0;
$DamageScale[AInterceptor, $BulletDamageType] = 1.0;
$DamageScale[AInterceptor, $PlasmaDamageType] = 1.5;
$DamageScale[AInterceptor, $EnergyDamageType] = 1.5;
$DamageScale[AInterceptor, $ExplosionDamageType] = 1.0;
$DamageScale[AInterceptor, $ShrapnelDamageType] = 1.0;
$DamageScale[AInterceptor, $DebrisDamageType] = 1.0;
$DamageScale[AInterceptor, $MissileDamageType] = 1.0;
$DamageScale[AInterceptor, $LaserDamageType] = 1.5;
$DamageScale[AInterceptor, $MortarDamageType] = 1.0;
$DamageScale[AInterceptor, $BlasterDamageType] = 1.5;
$DamageScale[AInterceptor, $ElectricityDamageType] = 1.5;
$DamageScale[AInterceptor, $MineDamageType]        = 1.0;

$VehicleInvList[AIcptVehicle] = 1;
$DataBlockName[AIcptVehicle] = AInterceptor;
$VehicleToItem[AIcpt] = AIcptVehicle;
$TeamItemMax[AIcptVehicle] = 15;

$TeamItemCount[0 @ AIcptVehicle] = 0;
$TeamItemCount[1 @ AIcptVehicle] = 0;
$TeamItemCount[2 @ AIcptVehicle] = 0;
$TeamItemCount[3 @ AIcptVehicle] = 0;
$TeamItemCount[4 @ AIcptVehicle] = 0;
$TeamItemCount[5 @ AIcptVehicle] = 0;
$TeamItemCount[6 @ AIcptVehicle] = 0;
$TeamItemCount[7 @ AIcptVehicle] = 0;

ItemData AIcptVehicle
{
	description = "Adv. Interceptor";
	className = "Vehicle";
   heading = "aVehicle";
	price = 3000;
};





// Kamikaze
//----------------------------------------------------------------------------


ExplosionData KamikazeNuke
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

DebrisData NukeExplosionDebris
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 5000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = flashExpLarge;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

FlierData Kamikaze
{
	explosionId = KamikazeNuke;
	debrisId = NukeExplosionDebris;
	className = "Vehicle";
   shapeFile = "flyer"; 
   shieldShapeName = "shield_medium";
   mass = 50.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.9;
   maxPitch = 0.9;
   maxSpeed = 300;
   minSpeed = -30;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.01;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;
	
	// No Weapons, Just Explosion

	damageSound = SoundFlierCrash;
	ramDamage = 1.8;
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
	description = "Kamikaze";
};

$DamageScale[Kamikaze, $ImpactDamageType] = 10.0;
$DamageScale[Kamikaze, $BulletDamageType] = 1.0;
$DamageScale[Kamikaze, $PlasmaDamageType] = 1.0;
$DamageScale[Kamikaze, $EnergyDamageType] = 1.0;
$DamageScale[Kamikaze, $ExplosionDamageType] = 1.0;
$DamageScale[Kamikaze, $ShrapnelDamageType] = 1.0;
$DamageScale[Kamikaze, $DebrisDamageType] = 1.0;
$DamageScale[Kamikaze, $MissileDamageType] = 1.0;
$DamageScale[Kamikaze, $LaserDamageType] = 1.0;
$DamageScale[Kamikaze, $MortarDamageType] = 1.0;
$DamageScale[Kamikaze, $BlasterDamageType] = 1.0;
$DamageScale[Kamikaze, $ElectricityDamageType] = 1.0;
$DamageScale[Kamikaze, $MineDamageType]        = 1.0;

$VehicleInvList[KamikazeVehicle] = 1;
$DataBlockName[KamikazeVehicle] = Kamikaze;
$VehicleToItem[Kamikaze] = KamikazeVehicle;
$TeamItemMax[KamikazeVehicle] = 10;

$TeamItemCount[0 @ KamikazeVehicle] = 0;
$TeamItemCount[1 @ KamikazeVehicle] = 0;
$TeamItemCount[2 @ KamikazeVehicle] = 0;
$TeamItemCount[3 @ KamikazeVehicle] = 0;
$TeamItemCount[4 @ KamikazeVehicle] = 0;
$TeamItemCount[5 @ KamikazeVehicle] = 0;
$TeamItemCount[6 @ KamikazeVehicle] = 0;
$TeamItemCount[7 @ KamikazeVehicle] = 0;

ItemData KamikazeVehicle
{
	description = "Kamikaze";
	className = "Vehicle";
   heading = "aVehicle";
	price = 100;
};

//----------------------------------------------------------------------------
//
// Old Types, New Values
//
//----------------------------------------------------------------------------

$TeamItemMax[ScoutVehicle] = 10;
$TeamItemMax[LAPCVehicle] = 7;
$TeamItemMax[HAPCVehicle] = 5;

ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
   heading = "aVehicle";
	price = 500;
};

ItemData LAPCVehicle
{
	description = "LPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 750;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 900;
};

TurretData MortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = MortarMissile;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Mortar Turret";
};

SeekingMissileData AirMines
{
   bulletShapeName = "grenade.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 25.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = AirMines;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
	speedModifier = 1.5;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote AirMine Turret";
	damageSkinData = "objectDamageSkins";
};