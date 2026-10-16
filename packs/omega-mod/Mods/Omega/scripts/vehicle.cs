//----------------------------------------------------------------------------
//

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
    mass = 2.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 20.0;
   maxPitch = 20.0;
   maxSpeed = 200;
   minSpeed = -20;
	lift = 0.5;
	maxAlt = 4000;
	maxVertical = 10;
	maxDamage = 60;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100000000000000000000;
	accel = 2.0;

	groundDamageScale = 1.0;

	projectileType = HyperLaser;
	reloadDelay = 0.1;
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

	visibleDriver = false;
	driverPose = 22;
	description = "Hyper Laser fighter";
};

FlierData LAPC
{
	explosionId = grenadeExp;
	debrisId = MyFireyDebris;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
    mass = 5.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 20.0;
   maxPitch = 20.0;
   maxSpeed = 75;
   minSpeed = -20;
	lift = 0.5;
	maxAlt = 4000;
	maxVertical = 10;
	maxDamage = 60;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100000000000000000000;
	accel = 1.0;

	groundDamageScale = 0.50;

                projectileType = BomberShell;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 0.1;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 23;
	description = "Bomber";
};

FlierData HAPC
{
	explosionId = LargeShockwave;
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

           
     	projectileType = DevBlast;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 0.1;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Heavy Transport";
};


//----------------------------------------------------------------------------

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.2;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.3;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.2;
$DamageScale[Scout, $ShrapnelDamageType] = 1.2;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.3;
$DamageScale[Scout, $BlasterDamageType] = 1.3;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType] = 1.2;
$DamageScale[Scout, $VDamageType] = 1;
$DamageScale[Scout, $PlasLaserDamageType] = 1;
$DamageScale[Scout, $CSDamageType] = 1;
$DamageScale[Scout, $DevDamageType] = 1;
$DamageScale[Scout, $SRDamageType] = 1;
$DamageScale[Scout, $RGDamageType] = 1;
$DamageScale[Scout, $IonDamageType] = 1;
$DamageScale[Scout, $FlakDamageType] = 1;
$DamageScale[Scout, $AnniCDamageType] = 1;
$DamageScale[Scout, $MethaneDamageType] = 1;
$DamageScale[Scout, $MRDamageType] = 1;

$DamageScale[LAPC, $ImpactDamageType] = 0.7;
$DamageScale[LAPC, $BulletDamageType] = 0.84;
$DamageScale[LAPC, $PlasmaDamageType] = 0.7;
$DamageScale[LAPC, $EnergyDamageType] = 0.91;
$DamageScale[LAPC, $ExplosionDamageType] = 0.7;
$DamageScale[LAPC, $MissileDamageType] = 0.7;
$DamageScale[LAPC, $DebrisDamageType] = 0.84;
$DamageScale[LAPC, $ShrapnelDamageType] = 0.84;
$DamageScale[LAPC, $LaserDamageType] = 0.84;
$DamageScale[LAPC, $MortarDamageType] = 0.91;
$DamageScale[LAPC, $BlasterDamageType] = 0.91;
$DamageScale[LAPC, $ElectricityDamageType] = 0.7;
$DamageScale[LAPC, $MineDamageType] = 0.84;
$DamageScale[LAPC, $VDamageType] = 0.7;
$DamageScale[LAPC, $PlasLaserDamageType] = 0.7;
$DamageScale[LAPC, $CSDamageType] = 0.7;
$DamageScale[LAPC, $DevDamageType] = 0.7;
$DamageScale[LAPC, $SRDamageType] = 0.7;
$DamageScale[LAPC, $RGDamageType] = 0.7;
$DamageScale[LAPC, $IonDamageType] = 0.7;
$DamageScale[LAPC, $FlakDamageType] = 0.7;
$DamageScale[LAPC, $AnniCDamageType] = 0.7;
$DamageScale[LAPC, $MethaneDamageType] = 0.7;
$DamageScale[LAPC, $MRDamageType] = 0.7;

$DamageScale[HAPC, $ImpactDamageType] = 0.49;
$DamageScale[HAPC, $BulletDamageType] = 0.588;
$DamageScale[HAPC, $PlasmaDamageType] = 0.49;
$DamageScale[HAPC, $EnergyDamageType] = 0.637;
$DamageScale[HAPC, $ExplosionDamageType] = 0.49;
$DamageScale[HAPC, $MissileDamageType] = 0.49;
$DamageScale[HAPC, $DebrisDamageType] = 0.588;
$DamageScale[HAPC, $ShrapnelDamageType] = 0.588;
$DamageScale[HAPC, $LaserDamageType] = 0.588;
$DamageScale[HAPC, $MortarDamageType] = 0.637;
$DamageScale[HAPC, $BlasterDamageType] = 0.637;
$DamageScale[HAPC, $ElectricityDamageType] = 0.49;
$DamageScale[HAPC, $MineDamageType] = 0.588;
$DamageScale[HAPC, $VDamageType] = 0.49;
$DamageScale[HAPC, $PlasLaserDamageType] = 0.49;
$DamageScale[HAPC, $CSDamageType] =  0.49;
$DamageScale[HAPC, $DevDamageType] =  0.49;
$DamageScale[HAPC, $SRDamageType] =  0.49;
$DamageScale[HAPC, $RGDamageType] =  0.49;
$DamageScale[HAPC, $IonDamageType] =  0.49;
$DamageScale[HAPC, $FlakDamageType] =  0.49;
$DamageScale[HAPC, $AnniCDamageType] = 0.49;
$DamageScale[HAPC, $MethaneDamageType] =  0.49;
$DamageScale[HAPC, $MRDamageType] =  0.49;

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