//----------------------------------------------------------------------------
//

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
   maxSpeed = 60;
   minSpeed = -5;
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

FlierData Apollo11
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "rocket";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.8;
   maxPitch = 0.6;
   maxSpeed = 80;
   minSpeed = -10;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 1.2;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.8;

	groundDamageScale = 6.0;

	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 8;
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
	description = "Apollo 11";
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
   maxBank = 0.3;
   maxPitch = 0.2;
   maxSpeed = 40;
   minSpeed = -4;
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
   maxBank = 0.3;
   maxPitch = 0.2;
   maxSpeed = 30;								   
   minSpeed = -3;
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

$DamageScale[Scout, $AirDamageType] = 1.5;
$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $FireDamageType] = 1.0;
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
$DamageScale[Scout, $NukeDamageType]        = 1.0;
$DamageScale[Scout, $FireDamageType]        = 1.0;
$DamageScale[Scout, $FlagMineDamageType]        = 1.0;
$DamageScale[Scout, $WrathDamageType]        = 1.0;
$DamageScale[Scout, $SniperDamageType]        = 1.0;

$DamageScale[Apollo11, $AirDamageType] = 1.5;
$DamageScale[Apollo11, $ImpactDamageType] = 5.0;
$DamageScale[Apollo11, $BulletDamageType] = 5.0;
$DamageScale[Apollo11, $FireDamageType] = 5.0;
$DamageScale[Apollo11, $PlasmaDamageType] = 5.0;
$DamageScale[Apollo11, $EnergyDamageType] = 5.0;
$DamageScale[Apollo11, $ExplosionDamageType] = 5.0;
$DamageScale[Apollo11, $ShrapnelDamageType] = 5.0;
$DamageScale[Apollo11, $DebrisDamageType] = 5.0;
$DamageScale[Apollo11, $MissileDamageType] = 5.0;
$DamageScale[Apollo11, $LaserDamageType] = 5.0;
$DamageScale[Apollo11, $MortarDamageType] = 5.0;
$DamageScale[Apollo11, $BlasterDamageType] = 2.5;
$DamageScale[Apollo11, $ElectricityDamageType] = 5.0;
$DamageScale[Apollo11, $MineDamageType]        = 5.0;
$DamageScale[Apollo11, $NukeDamageType]        = 1.0;
$DamageScale[Apollo11, $FireDamageType]        = 1.0;
$DamageScale[Apollo11, $FlagMineDamageType]        = 1.0;
$DamageScale[Apollo11, $WrathDamageType]        = 1.0;
$DamageScale[Apollo11, $SniperDamageType]        = 1.0;

$DamageScale[LAPC, $AirDamageType] = 1.5;
$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $FireDamageType] = 1.0;
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
$DamageScale[LAPC, $NukeDamageType]        = 1.0;
$DamageScale[LAPC, $FireDamageType]        = 1.0;
$DamageScale[LAPC, $FlagMineDamageType]        = 1.0;
$DamageScale[LAPC, $WrathDamageType]        = 1.0;
$DamageScale[LAPC, $SniperDamageType]        = 1.0;

$DamageScale[HAPC, $AirDamageType] = 1.5;
$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $FireDamageType] = 1.0;
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
$DamageScale[HAPC, $NukeDamageType]        = 1.0;
$DamageScale[HAPC, $FireDamageType]        = 1.0;
$DamageScale[HAPC, $FlagMineDamageType]        = 1.0;
$DamageScale[HAPC, $WrathDamageType]        = 1.0;
$DamageScale[HAPC, $SniperDamageType]        = 1.0;

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}


function Vehicle::onCollision (%this, %object)
{
if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
{
    if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
    {
        if(Player::isAiControlled(%object))
        return;
        %armor = Player::getArmor(%object);
        %client = Player::getClient(%object);
        if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object) && GameBase::getDataName(%this) != Apollo11)
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
	    %this.clLastMount = %client;
	}
	else if(GameBase::getDataName(%this) == Apollo11) 
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
	    %this.clLastMount = %client;
	}
	else if(GameBase::getDataName(%this) == LAPC || GameBase::getDataName(%this) == HAPC) 
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
	else
	    Client::sendMessage(Player::getClient(%object),0,"You can not pilot this vehicle.~wError_Message.wav");
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
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "rarmor" || %armor == "rfemale") {
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
	if(GameBase::getDataName(%this) != Apollo11)
	{
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
	    }
	    else
		Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
	    }
	else
	    %pl.lastMount = %this;
	    %pl.newMountTime = getSimTime() + 3.0;
	    Player::setMountObject(%pl, %this, 0);
            Player::setMountObject(%pl, -1, 0);
	    %rot = GameBase::getRotation(%this);
	    %rotZ = getWord(%rot,2);
		%pos = GameBase::getPosition(%this);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2) + 0.1;
		GameBase::setPosition(%pl, %posX @ " " @ %posY @ " " @ %posZ);
	    GameBase::setRotation(%pl, "0 0 " @ %rotZ);
	    Player::applyImpulse(%pl,%mom);
            Client::setControlObject(%cl, %pl);
	    playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
	    if(%pl.lastWeapon != "")
	    {
		Player::useItem(%pl,%pl.lastWeapon);		 	
		%pl.lastWeapon = "";
	    }
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
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
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
