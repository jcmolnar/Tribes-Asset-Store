exec(combatDrones);

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
      maxPitch = 0.7;	// 0.5;
      maxSpeed = 52;
      minSpeed = -2;
	lift = 0.75;
	maxAlt = 37;
	maxVertical = 10;
	// maxDamage = 0.6;
	maxDamage = 1.2;
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

//***************
FlierData Speeder
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
        shapeFile = "flyer";
        shieldShapeName = "shield_medium";
        mass = 8.0;
        drag = 0.9;
        density = 1.2;
        maxBank = 0.8;
        maxPitch = 0.9;
        maxSpeed = 45;
        minSpeed = -5;
	lift = 0.8;
	maxAlt = 60.0;
	maxVertical = 20;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 120;
	accel = 0.7;

	groundDamageScale = 1.0;

	projectileType = SpeederBullet;
	reloadDelay = 0.16;
	repairRate = 0;
	fireSound = shockExplosion;
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
        maxPitch = 0.8;
        maxSpeed = 22;
        minSpeed = -3;
	lift = 0.25;
	maxAlt = 5;
	maxVertical = 3;
	// maxDamage = 4.0;
        maxDamage = 2.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 90;
	accel = 0.4;

	groundDamageScale = 0.05;

	projectileType = HEAPShell;
	reloadDelay = 0.7;
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
        maxBank = 0.30;
        maxPitch = 0.50;
        maxSpeed = 30;
        minSpeed = -7;
        lift = 0.2;
	maxAlt = 40;
	maxVertical = 15;
	maxDamage = 2.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	// accel = 0.5;
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
        maxBank = 0.25;
        maxPitch = 0.35;
        maxSpeed = 25;
        minSpeed = -1;
	lift = 0.55;
        maxAlt = 50;
        maxVertical = 12;
        maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
        accel = 0.3;

        groundDamageScale = 0.125;

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
        maxPitch = 0.4;
        maxSpeed = 25;                                                                 
        minSpeed = -6;
        // lift = 0.55;
        lift = 0.1;
        maxAlt = 40;
	maxVertical = 10;
	maxDamage = 4.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.22;

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

$DamageScale[Scout, $ImpactDamageType] = 1.2;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.2;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;
$DamageScale[Scout, $DrainDamageType]        = 1.0;

$DamageScale[Speeder, $ImpactDamageType] = 1.4;
$DamageScale[Speeder, $BulletDamageType] = 0.7;
$DamageScale[Speeder, $PlasmaDamageType] = 0.6;
$DamageScale[Speeder, $EnergyDamageType] = 0.7;
$DamageScale[Speeder, $ExplosionDamageType] = 0.6;
$DamageScale[Speeder, $ShrapnelDamageType] = 0.7;
$DamageScale[Speeder, $DebrisDamageType] = 0.7;
$DamageScale[Speeder, $MissileDamageType] = 1.4;
$DamageScale[Speeder, $LaserDamageType] = 0.5;
$DamageScale[Speeder, $MortarDamageType] = 0.7;
$DamageScale[Speeder, $BlasterDamageType] = 0.3;
$DamageScale[Speeder, $ElectricityDamageType] = 0.5;
$DamageScale[Speeder, $MineDamageType]        = 0.3;
$DamageScale[Speeder, $DrainDamageType]        = 1.0;

$DamageScale[HoverTank, $ImpactDamageType] = 0.8;
$DamageScale[HoverTank, $BulletDamageType] = 0.5;
$DamageScale[HoverTank, $PlasmaDamageType] = 0.4;
$DamageScale[HoverTank, $EnergyDamageType] = 0.5;
$DamageScale[HoverTank, $ExplosionDamageType] = 0.4;
$DamageScale[HoverTank, $ShrapnelDamageType] = 0.5;
$DamageScale[HoverTank, $DebrisDamageType] = 0.5;
$DamageScale[HoverTank, $MissileDamageType] = 1.0;
$DamageScale[HoverTank, $LaserDamageType] = 0.3;
$DamageScale[HoverTank, $MortarDamageType] = 0.5;
$DamageScale[HoverTank, $BlasterDamageType] = 0.2;
$DamageScale[HoverTank, $ElectricityDamageType] = 0.3;
$DamageScale[HoverTank, $MineDamageType]        = 0.3;
$DamageScale[HoverTank, $DrainDamageType]        = 1.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 0.9;
$DamageScale[LAPC, $PlasmaDamageType] = 0.9;
$DamageScale[LAPC, $EnergyDamageType] = 0.9;
$DamageScale[LAPC, $ExplosionDamageType] = 0.9;
$DamageScale[LAPC, $ShrapnelDamageType] = 0.9;
$DamageScale[LAPC, $DebrisDamageType] = 0.9;
$DamageScale[LAPC, $MissileDamageType] = 1.3;
$DamageScale[LAPC, $LaserDamageType] = 0.45;
$DamageScale[LAPC, $MortarDamageType] = 0.9;
$DamageScale[LAPC, $BlasterDamageType] = 0.45;
$DamageScale[LAPC, $ElectricityDamageType] = 0.9;
$DamageScale[LAPC, $MineDamageType]        = 0.9;
$DamageScale[LAPC, $DrainDamageType]        = 0.9;

$DamageScale[Bomber, $ImpactDamageType] = 1.0;
$DamageScale[Bomber, $BulletDamageType] = 0.6;
$DamageScale[Bomber, $PlasmaDamageType] = 0.6;
$DamageScale[Bomber, $EnergyDamageType] = 0.7;
$DamageScale[Bomber, $ExplosionDamageType] = 0.7;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 1.5;
$DamageScale[Bomber, $LaserDamageType] = 0.5;
$DamageScale[Bomber, $MortarDamageType] = 0.9;
$DamageScale[Bomber, $BlasterDamageType] = 0.2;
$DamageScale[Bomber, $ElectricityDamageType] = 0.8;
$DamageScale[Bomber, $MineDamageType]        = 0.9;
$DamageScale[Bomber, $DrainDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 0.8;
$DamageScale[HAPC, $PlasmaDamageType] = 0.9;
$DamageScale[HAPC, $EnergyDamageType] = 0.9;
$DamageScale[HAPC, $ExplosionDamageType] = 0.9;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.2;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 0.8;
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
	if (GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType(%object) == "Player" && %object.vehicle == "" && 
		   (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") {

			if(Player::isAiControlled(%object)) return;

			// - BW Admin Mod - Bug Fix
			if(%object.Station != "") {
				Client::sendMessage(Player::getClient(%object),0,"You must leave the Inventory Station to pilot the vehicles.~wError_Message.wav");
				return;
			}
			// - BW Admin Mod - Bug Fix End

			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);

			if (%armor == "darmor") {
				Client::sendMessage(Player::getClient(%object),0,"Access denied. Defender armor may not use a vehicle.~wError_Message.wav");
				return;
			}

			if (GameBase::getDataName(%this) == HoverTank) {
				%type = Player::getMountedItem(%client,$FlagSlot);
				if(%type != -1) {
					Client::sendMessage(Player::getClient(%object),0,"Flags can not fit inside assault crafts.~wError_Message.wav");
					Player::dropItem(%client,%type);
				}
			}

			if ((%armor == "larmor" || %armor == "lfemale" || %armor == "carmor" || %armor == "fcarmor") && 
				Vehicle::canMount(%this, %object) && (!$bwadmin::walk || %object.carryflag == "")) {

				%weapon = Player::getMountedItem(%object,$WeaponSlot);
				if (%weapon != -1) {
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
					bwadmin::isWeaponChangeInfoActive(%client, "none");
				}

				Player::setMountObject(%object, %this, 1);
				Client::setControlObject(%client, %this);
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%object.driver= 1;
				%object.vehicle = %this;
				%this.clLastMount = %client;
				bwadmin::isPilotInfoActive(%client, true);
			} else if (GameBase::getDataName(%this) != Scout && 
				     GameBase::getDataName(%this) != Speeder && 
				     GameBase::getDataName(%this) != HoverTank) {

				%mountSlot = Vehicle::findEmptySeat(%this,%client); 
				if (%mountSlot) {
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				}
			}

			// - BW Admin Mod - Long Walk Home Mod
			else if (%object.carryflag != "" && $bwadmin::walk)
				Client::sendMessage(Player::getClient(%object),0,"You cannot pilot vehicles while carrying the flag!~wError_Message.wav");
			// - BW Admin Mod - End

			else if (GameBase::getControlClient(%this) == -1) 
				Client::sendMessage(Player::getClient(%object),0,"You must be in Light or Combat Armor to pilot the vehicles.~wError_Message.wav");
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
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "scvarmor") 
	{
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else // if(%armor == "harmor") 
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
				if(!%pl.invulnerable && %pl.lastWeapon != "") 
				{
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		    }
	      			bwadmin::isPilotInfoActive(%cl, false);
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
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100,%this); 
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

