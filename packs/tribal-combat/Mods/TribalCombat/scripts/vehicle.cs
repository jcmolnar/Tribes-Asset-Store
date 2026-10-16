exec(combatDrones);

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "flyer";
    shieldShapeName = "shield_medium";
    mass = 8.0;
    drag = 1.0;
    density = 1.2;
    maxBank = 0.5;
    maxPitch = 0.6;
    maxSpeed = 120;
    minSpeed = -10;
	lift = 0.85;
	maxAlt = 50;
	maxVertical = 50;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 120;
	accel = 1.3;

	groundDamageScale = 1.0;

	projectileType = MiniFusionBolt;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = SoundFireLaser;
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

//***************
FlierData Speeder
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "flyer";
    shieldShapeName = "shield_medium";
    mass = 6.0;
    drag = 0.8;
    density = 1.2;
    maxBank = 0.75;
    maxPitch = 1.0;
    maxSpeed = 80;
    minSpeed = -20;
	lift = 0.8;
	maxAlt = 30.0;
	maxVertical = 30;
	maxDamage = 1.3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 120;
	accel = 1.1;

	groundDamageScale = 1.0;

	projectileType = HvyChaingunBullet;
	reloadDelay = 0.08;
	repairRate = 0;
	fireSound = SoundFireMortar;
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

//***************
FlierData HoverTank
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "flyer";
    shieldShapeName = "shield_medium";
    mass = 20.0;
    drag = 1.0;
    density = 1.2;
    maxBank = 0.4;
    maxPitch = 1.0;
    maxSpeed = 18;
    minSpeed = -2;
	lift = 0.25;
	maxAlt = 5;
	maxVertical = 3;
	maxDamage = 4.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 90;
	accel = 0.45;

	groundDamageScale = 0.05;

	projectileType = HEAPShell;
	reloadDelay = 0.75;
	repairRate = 0;
	fireSound = shockExplosion;
//	damageSound = SoundFlierCrash;
	ramDamage = 0.75;
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
	description = "Assault Craft";
};

//function HoverTank::onAdd(%this)
//{
//	%this.shieldStrength = 0.0;
//	GameBase::setRechargeRate (%this, 10);
//	GameBase::setMapName (%this, "Vehicle");
//	schedule("HoverTank::hover("@%this@");",0.1,%this);
//}

//function HoverTank::hover(%this)
//{
// if(GameBase::getLOSInfo(%this,7))
// {
//  %position = GameBase::getPosition(%this);
//  %posX = getWord(%position,0);
//  %posY = getWord(%position,1);
//  %posZ = getWord(%position,2);
//  GameBase::setPosition(%this,%posX@" "@%posY@" "@%posZ + 0.01); 
// }
//echo(%position);
//  schedule("HoverTank::hover("@%this@");",0.001,%this);
//}

//************
FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "hover_apc_sml";
    shieldShapeName = "shield_large";
    mass = 16.0;
    drag = 1.0;
    density = 1.2;
    maxBank = 0.35;
    maxPitch = 0.55;
    maxSpeed = 50;
    minSpeed = -7;
	lift = 0.75;
	maxAlt = 20;
	maxVertical = 15;
	maxDamage = 2.5;
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
	description = "LPC";
};

//**************
FlierData Bomber
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "hover_apc_sml";
    shieldShapeName = "shield_large";
    mass = 20.0;
    drag = 1.0;
    density = 1.2;
    maxBank = 0.4;
    maxPitch = 0.4;
    maxSpeed = 30;
    minSpeed = -1;
	lift = 0.55;
	maxAlt = 30;
	maxVertical = 30;
	maxDamage = 3.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 0.50;

	projectileType = Bomb;
	reloadDelay = 10.0;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireMortar;
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

//************
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
    maxBank = 0.35;
    maxPitch = 0.35;
    maxSpeed = 25;								   
    minSpeed = -6;
	lift = 0.55;
	maxAlt = 30;
	maxVertical = 30;
	maxDamage = 3.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";

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
$DamageScale[Scout, $DrainDamageType]        = 1.0;

$DamageScale[Speeder, $ImpactDamageType] = 0.8;
$DamageScale[Speeder, $BulletDamageType] = 0.7;
$DamageScale[Speeder, $PlasmaDamageType] = 0.6;
$DamageScale[Speeder, $EnergyDamageType] = 0.7;
$DamageScale[Speeder, $ExplosionDamageType] = 0.6;
$DamageScale[Speeder, $ShrapnelDamageType] = 0.7;
$DamageScale[Speeder, $DebrisDamageType] = 0.7;
$DamageScale[Speeder, $MissileDamageType] = 0.6;
$DamageScale[Speeder, $LaserDamageType] = 0.5;
$DamageScale[Speeder, $MortarDamageType] = 0.7;
$DamageScale[Speeder, $BlasterDamageType] = 0.3;
$DamageScale[Speeder, $ElectricityDamageType] = 0.5;
$DamageScale[Speeder, $MineDamageType]        = 0.3;
$DamageScale[Speeder, $DrainDamageType]        = 1.0;

$DamageScale[HoverTank, $ImpactDamageType] = 0.4;
$DamageScale[HoverTank, $BulletDamageType] = 0.5;
$DamageScale[HoverTank, $PlasmaDamageType] = 0.4;
$DamageScale[HoverTank, $EnergyDamageType] = 0.5;
$DamageScale[HoverTank, $ExplosionDamageType] = 0.4;
$DamageScale[HoverTank, $ShrapnelDamageType] = 0.5;
$DamageScale[HoverTank, $DebrisDamageType] = 0.5;
$DamageScale[HoverTank, $MissileDamageType] = 0.4;
$DamageScale[HoverTank, $LaserDamageType] = 0.3;
$DamageScale[HoverTank, $MortarDamageType] = 0.5;
$DamageScale[HoverTank, $BlasterDamageType] = 0.2;
$DamageScale[HoverTank, $ElectricityDamageType] = 0.3;
$DamageScale[HoverTank, $MineDamageType]        = 0.3;
$DamageScale[HoverTank, $DrainDamageType]        = 1.0;

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
$DamageScale[LAPC, $DrainDamageType]        = 1.0;

$DamageScale[Bomber, $ImpactDamageType] = 1.0;
$DamageScale[Bomber, $BulletDamageType] = 0.6;
$DamageScale[Bomber, $PlasmaDamageType] = 0.6;
$DamageScale[Bomber, $EnergyDamageType] = 0.7;
$DamageScale[Bomber, $ExplosionDamageType] = 0.7;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 0.8;
$DamageScale[Bomber, $LaserDamageType] = 0.5;
$DamageScale[Bomber, $MortarDamageType] = 0.9;
$DamageScale[Bomber, $BlasterDamageType] = 0.2;
$DamageScale[Bomber, $ElectricityDamageType] = 0.8;
$DamageScale[Bomber, $MineDamageType]        = 0.9;
$DamageScale[Bomber, $DrainDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 0.8;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 0.9;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 0.8;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;
$DamageScale[HAPC, $DrainDamageType]        = 1.0;


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
  if(getObjectType(%object) == "Player" && 
      %object.vehicle == "" && 
	 (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
  {
   if(Player::isAiControlled(%object)) return;
   %armor = Player::getArmor(%object);
   %client = Player::getClient(%object);
   if(%armor == "darmor")
   {
    Client::sendMessage(Player::getClient(%object),0,"Access denied. Defender armor may not use a vehicle.~wError_Message.wav");
	return;
   }
   if((%armor == "larmor" || %armor == "lfemale" || %armor == "carmor" || %armor == "fcarmor") && Vehicle::canMount(%this, %object))
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
   else if(GameBase::getDataName(%this) != Scout && GameBase::getDataName(%this) != Speeder && GameBase::getDataName(%this) != HoverTank) 
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
   else if(GameBase::getControlClient(%this) == -1) Client::sendMessage(Player::getClient(%object),0,"You must be in Light or Combat Armor to pilot the vehicles.~wError_Message.wav");
  }
 }
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC) %numSlots = 4;
	else %numSlots = 2;
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
		return %lastEmpty;
	}
	else if (%count > 1)	
	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else return "False";
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
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "carmor" || %armor == "fcarmor") 
	{
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale") 
	{
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") 
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
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
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
			}
			else Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
   %name = GameBase::getDataName(%this);
   if(%name == "Drone") $TeamItemCount[GameBase::getTeam(%this) @ DronePack]--;
   else if(%name == "GuidedBomb")   $TeamItemCount[GameBase::getTeam(%this) @ GuidedBombPack]--;
   else if(%name == "SurveyDrone")   $TeamItemCount[GameBase::getTeam(%this) @ SurveyDronePack]--;
   else if(%name == "AttackDrone")   $TeamItemCount[GameBase::getTeam(%this) @ AttackDronePack]--;
   else $TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[%name]]--;

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
	%pl.vehicle= "";
   }

	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") 
		{
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
 //DAMAGE MODE
 if($Combat::DamageMode == "custom") %value = CustomDamageMode(%value,%type);
 else %value *= $Combat::DamageScale;

 %value *= $damageScale[GameBase::getDataName(%this), %type];
 if(%type == $DrainDamageType) GameBase::setEnergy(%this,0);

 %name = GameBase::getDataName(%this);
 if(%name == "Drone" || %name == "GuidedBomb" || %name == "SurveyDrone" || %name == "AttackDrone")
 {
  if(%type == $ElectricityDamageType) %value *= 5;
  if(%type == $ExplosionDamageType) %value *= 2;
 }
 StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}