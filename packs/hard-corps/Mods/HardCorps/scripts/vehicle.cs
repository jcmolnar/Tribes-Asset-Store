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
   maxSpeed = 55;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

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
	description = "Fighter";
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
	description = "Light Carrier";
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
	description = "Heavy Carrier";
};

//----------------------------------------------------------------------------

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;
$DamageScale[Scout, $ClusterDamageType]        = 1.2;
$DamageScale[Scout, $TurretDamageType] = 1.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;
$DamageScale[LAPC, $ClusterDamageType]        = 0.8;
$DamageScale[LAPC, $TurretDamageType] = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;
$DamageScale[HAPC, $ClusterDamageType]        = 0.6;
$DamageScale[HAPC, $TurretDamageType] = 1.0;

//----------------------------------------------------------------------------

$ItemMax[larmor, RotaryChaingun] = 1;
$ItemMax[marmor, RotaryChaingun] = 1;
$ItemMax[harmor, RotaryChaingun] = 1;
$ItemMax[lfemale, RotaryChaingun] = 1;
$ItemMax[mfemale, RotaryChaingun] = 1;

$ItemMax[larmor, VehicleRocket] = 1;
$ItemMax[marmor, VehicleRocket] = 1;
$ItemMax[harmor, VehicleRocket] = 1;
$ItemMax[lfemale, VehicleRocket] = 1;
$ItemMax[mfemale, VehicleRocket] = 1;

$ItemMax[larmor, NapalmLauncher] = 1;
$ItemMax[marmor, NapalmLauncher] = 1;
$ItemMax[harmor, NapalmLauncher] = 1;
$ItemMax[lfemale, NapalmLauncher] = 1;
$ItemMax[mfemale, NapalmLauncher] = 1;

$ItemMax[larmor, VehicleClusterCannon] = 1;
$ItemMax[marmor, VehicleClusterCannon] = 1;
$ItemMax[harmor, VehicleClusterCannon] = 1;
$ItemMax[lfemale, VehicleClusterCannon] = 1;
$ItemMax[mfemale, VehicleClusterCannon] = 1;

$ItemMax[larmor, VehicleEMPLauncher] = 1;
$ItemMax[marmor, VehicleEMPLauncher] = 1;
$ItemMax[harmor, VehicleEMPLauncher] = 1;
$ItemMax[lfemale, VehicleEMPLauncher] = 1;
$ItemMax[mfemale, VehicleEMPLauncher] = 1;

$ItemMax[larmor, VehicleBomb] = 1;
$ItemMax[marmor, VehicleBomb] = 1;
$ItemMax[harmor, VehicleBomb] = 1;
$ItemMax[lfemale, VehicleBomb] = 1;
$ItemMax[mfemale, VehicleBomb] = 1;

$ItemMax[larmor, ShieldModule] = 1;
$ItemMax[marmor, ShieldModule] = 1;
$ItemMax[harmor, ShieldModule] = 1;
$ItemMax[lfemale, ShieldModule] = 1;
$ItemMax[mfemale, ShieldModule] = 1;

$ItemMax[larmor, AmmoModule] = 1;
$ItemMax[marmor, AmmoModule] = 1;
$ItemMax[harmor, AmmoModule] = 1;
$ItemMax[lfemale, AmmoModule] = 1;
$ItemMax[mfemale, AmmoModule] = 1;

$ItemMax[larmor, RepairModule] = 1;
$ItemMax[marmor, RepairModule] = 1;
$ItemMax[harmor, RepairModule] = 1;
$ItemMax[lfemale, RepairModule] = 1;
$ItemMax[mfemale, RepairModule] = 1;

$ItemMax[larmor, SpeedModule] = 1;
$ItemMax[marmor, SpeedModule] = 1;
$ItemMax[harmor, SpeedModule] = 1;
$ItemMax[lfemale, SpeedModule] = 1;
$ItemMax[mfemale, SpeedModule] = 1;

$ItemMax[larmor, StealthModule] = 1;
$ItemMax[marmor, StealthModule] = 1;
$ItemMax[harmor, StealthModule] = 1;
$ItemMax[lfemale, StealthModule] = 1;
$ItemMax[mfemale, StealthModule] = 1;


//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	//GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
	%this.weaponry = "";
	%this.leftpad = "false";
}

function StealthModule::CheckForDisable(%this)
{
	%this.stealthmoduleactive = "true";
	%this.jamdetect = "true";
	%jam = "false";
	if (%this.empeffect != 0)
		{ 
			Client::sendMessage(Player::getClient(%this),0,"Shield Module disrupted by EMP!");
			playSound(SoundEMPulseEffect,GameBase::getPosition(%this));
			%jam = "true";
		}

	if (%jam == "true")
		{
			for(%i = 0 ; %i < 4 ; %i++)
				{
					if(%this.Seat[%i] != "") 
						{
							%player = Client::getOwnedObject(%this.Seat[%i]);
							%rate = Player::getSensorSupression(%player) - 20;
							Player::setSensorSupression(%player,%rate);
							// IFF user -- possible problem?
							Player::setDetectParameters(%Targetplayer, 0.027, 0);
							%player.jamdetect = "false";
						}
				}
		}
	schedule("StealthModule::CheckForDisable(" @ %this @ ");", 0.5,%this);
}

function CheckModules(%this,%object)
{
	if (%this.module != "")
		{
			if (%this.module == ShieldModule)
				{
					%this.shieldStrength = 0.14;		// Damage Modifier
				}
			if (%this.module == AmmoModule)
				{
					GameBase::setRechargeRate (%this, 1);	
				}
			if (%this.module == RepairModule)
				{
					GameBase::setAutoRepairRate(%this,0.01);
				}
			if (%this.module == SpeedModule)
				{
					%this.accel = %this.accel * 1.25;
					%this.maxSpeed = %this.maxSpeed * 1.25;
				}
			if (%this.module == StealthModule)
				{
					%rate = Player::getSensorSupression(%object) + 20;
					Player::setSensorSupression(%object,%rate);
					%object.jamdetect = "true";
					if (%this.stealthmoduleactive != "true") StealthModule::CheckForDisable(%this);
				}
		}
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
				if (((%armor == "larmor" || %armor == "lfemale") || ((%armor == "marmor" || %armor == "mfemale") && (GameBase::getDataName(%this) == LAPC || GameBase::getDataName(%this) == HAPC)) || (%armor == "harmor" && GameBase::getDataName(%this) == HAPC)) && Vehicle::canMount (%this, %object) && %object.teamkiller != "true")
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
						%this.leftpad = "true";
						CheckModules(%this,%object);

						%this.clLastMount = %client;
					}
				else if(GameBase::getDataName(%this) != Scout) 
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								%this.leftpad = "true";
								CheckModules(%this,%object);
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"Incorrect armour to pilot this vehicle.~wError_Message.wav");
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
	if (%this.module == StealthModule)
		{
			%rate = Player::getSensorSupression(%passenger) - 20;
			Player::setSensorSupression(%passenger,%rate);
			%passenger.jamdetect = "false";
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
		if (%this.module == StealthModule)
			{
				%rate = Player::getSensorSupression(%pl) - 20;
				Player::setSensorSupression(%pl,%rate);
				%pl.jamdetect = "false";
			}

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

function VehicleExplosionDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,%rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
{
	%radius = GameBase::getRadius(%this);
	if(%radius) {
		%radius *= %radiusRatio;
		%damageValue = %radius * %damageRatio;
		%force = %radius * %forceRatio;
		if(%radius > %rMax)
			%radius = %rMax;
		else if(%radius < %rMin)
			%radius = %rMin;
		if(%damageValue > %dMax)
			%damageValue = %dMax; 
		else if(%damageValue < %dMin)
			%damageValue = %dMin;
		if(%force > %fMax)
			%force = %fMax; 
		else if(%force < %fMin)
			%force = %fMin;
		GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius,%damageValue,%force,%this.lastDamageObject);
	}
}

function Vehicle::onDestroyed (%this,%mom)
{
	if ($UseAdjustedScoring == "true") DoDestroyScoring(%this,%this.lastDamageObject,"Destroy");
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
			%pl.jamdetect = "false";
		   %pl.vehicle= "";
		}
	VehicleExplosionDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); 
	%this.leftpad = "true";
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	if ($UseAdjustedDamage == "true") %valye = (%value * $AdjustedDamageScale);
	if (%this.shieldstrength > 0) StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	 else StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);

	// WERG Possible add-on to alert pilot to his own damage...?
     // Use Error_Message.wav for sound.
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}

function Vehicle::onFire(%this,%slot)
{
	if (getSimTime() - $FireTime[%this] > %this.firedelay)
	   {
	  if (%this.weaponry != "")
		{
		  $FireTime[%this] = getSimTime();
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
					} else 
					{
						Projectile::spawnProjectile(%this.attacktype,%trans,%this,%vel);
					}

				 %AmmoCount -= %AmmoCost;
				 if (%AmmoCount < 0) %AmmoCount = 0;
				 Gamebase::setEnergy(%this,%AmmoCount);
				 %this.firecount = %this.firedelay;
			 }
			 else
				{
					Client::sendMessage(GameBase::getOwnerClient(%this), 0,"Vehicle has no ammo.");
				}
		}
	}
}