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
	maxSpeed = 70;
	minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.65;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 0.6;

	groundDamageScale = 1.0;

	projectileType = ScoutRocket;
	reloadDelay = 0.25;
	repairRate = 0;
	fireSound = SoundMissileTurretFire;
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

};



FlierData Jet
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.6;
	maxPitch = 0.6;
	maxSpeed = 80;
	minSpeed = -2;
	lift = 0.95;
	maxAlt = 30;
	maxVertical = 12;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.2;

	groundDamageScale = 1.0;

      targetableFovRatio = 0.5;
	projectileType = IonBolt;
	reloadDelay = 0.05;
	repairRate = 0;
	fireSound = SoundFireBlaster;
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

};

FlierData MarauderJet
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   	shapeFile = "flyer";
   	shieldShapeName = "shield_medium";
   	mass = 9.0;
   	drag = 1.0;
   	density = 1.2;
   	maxBank = 0.8;
   	maxPitch = 0.8;
   	maxSpeed = 80;
   	minSpeed = -10;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = JetFusionBolt;
	reloadDelay = 0.40;
	repairRate = 0;
	fireSound = SoundPlasmaTurretFire;
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
	description = "Marauder";
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
   	maxSpeed = 35;
   	minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 9;
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
	
	projectileType = BomberShell;
	fireSound = SoundFireMortar;
	reloadDelay = 1.5;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
};

FlierData GunshipJet
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
   	maxSpeed = 35;
   	minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 9;
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
	
	projectileType = JetBullet;
	fireSound = SoundFireMortar;
	reloadDelay = 0.03;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
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
   	maxSpeed = 30;								   
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
};


//----------------------------------------------------------------------------

$DamageScale[Scout, $ImpactDamageType] 	  = 1.0;
$DamageScale[Scout, $BulletDamageType] 	  = 1.0;
$DamageScale[Scout, $EnergyDamageType] 	  = 1.0;
$DamageScale[Scout, $PlasmaDamageType] 	  = 1.0;
$DamageScale[Scout, $ExplosionDamageType]   = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] 	  = 1.0;
$DamageScale[Scout, $LaserDamageType] 	  = 1.0;
$DamageScale[Scout, $MortarDamageType] 	  = 1.0;
$DamageScale[Scout, $BlasterDamageType] 	  = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $CrushDamageType] 	  = 1.0;
$DamageScale[Scout, $DebrisDamageType] 	  = 1.0;
$DamageScale[Scout, $MissileDamageType] 	  = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;
$DamageScale[Scout, $EMPDamageType] 	  = 1.0;
$DamageScale[Scout, $NukeGrenadeDamageType] = 1.0;
$DamageScale[Scout, $SniperDamageType]      = 1.0;
$DamageScale[Scout, $AAMissileDamageType]   = 1.0;
$DamageScale[Scout, $ShellDamageType] 	  = 1.0;

$DamageScale[Jet, $ImpactDamageType] 	  = 1.0;
$DamageScale[Jet, $BulletDamageType] 	  = 1.0;
$DamageScale[Jet, $EnergyDamageType] 	  = 1.0;
$DamageScale[Jet, $PlasmaDamageType] 	  = 1.0;
$DamageScale[Jet, $ExplosionDamageType]	  = 1.0;
$DamageScale[Jet, $ShrapnelDamageType] 	  = 1.0;
$DamageScale[Jet, $LaserDamageType] 	  = 1.0;
$DamageScale[Jet, $MortarDamageType] 	  = 1.0;
$DamageScale[Jet, $BlasterDamageType] 	  = 0.5;
$DamageScale[Jet, $ElectricityDamageType]   = 1.0;
$DamageScale[Jet, $CrushDamageType] 	  = 1.0;
$DamageScale[Jet, $DebrisDamageType] 	  = 1.0;
$DamageScale[Jet, $MissileDamageType] 	  = 1.0;
$DamageScale[Jet, $MineDamageType]		  = 1.0;
$DamageScale[Jet, $EMPDamageType]		  = 1.0;
$DamageScale[Jet, $NukeGrenadeDamageType]	  = 1.0;
$DamageScale[Jet, $SniperDamageType]	  = 1.0;
$DamageScale[Jet, $AAMissileDamageType]	  = 1.0;
$DamageScale[Jet, $ShellDamageType] 	  = 1.0;

$DamageScale[MarauderJet, $ImpactDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $BulletDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $EnergyDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $PlasmaDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $ExplosionDamageType]   = 1.0;
$DamageScale[MarauderJet, $ShrapnelDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $LaserDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $MortarDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $BlasterDamageType] 	  = 0.5;
$DamageScale[MarauderJet, $ElectricityDamageType] = 1.0;
$DamageScale[MarauderJet, $CrushDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $DebrisDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $MissileDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $MineDamageType]        = 1.0;
$DamageScale[MarauderJet, $EMPDamageType] 	  = 1.0;
$DamageScale[MarauderJet, $NukeGrenadeDamageType] = 1.0;
$DamageScale[MarauderJet, $SniperDamageType]      = 1.0;
$DamageScale[MarauderJet, $AAMissileDamageType]   = 1.0;
$DamageScale[MarauderJet, $ShellDamageType] 	  = 1.0;

$DamageScale[LAPC, $ImpactDamageType] 	 = 1.0;
$DamageScale[LAPC, $BulletDamageType] 	 = 1.0;
$DamageScale[LAPC, $EnergyDamageType] 	 = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] 	 = 1.0;
$DamageScale[LAPC, $ExplosionDamageType]   = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] 	 = 1.0;
$DamageScale[LAPC, $LaserDamageType] 	 = 0.5;
$DamageScale[LAPC, $MortarDamageType] 	 = 0.7;
$DamageScale[LAPC, $BlasterDamageType] 	 = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $CrushDamageType] 	 = 1.0;
$DamageScale[LAPC, $DebrisDamageType] 	 = 1.0;
$DamageScale[LAPC, $MissileDamageType] 	 = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;
$DamageScale[LAPC, $EMPDamageType]		 = 1.0;
$DamageScale[LAPC, $NukeGrenadeDamageType] = 1.0;
$DamageScale[LAPC, $SniperDamageType]      = 1.0;
$DamageScale[LAPC, $AAMissileDamageType]   = 1.0;
$DamageScale[LAPC, $ShellDamageType] 	 = 1.0;

$DamageScale[GunshipJet, $ImpactDamageType] 	 = 1.0;
$DamageScale[GunshipJet, $BulletDamageType] 	 = 1.0;
$DamageScale[GunshipJet, $EnergyDamageType] 	 = 1.0;
$DamageScale[GunshipJet, $PlasmaDamageType] 	 = 1.0;
$DamageScale[GunshipJet, $ExplosionDamageType]   = 1.0;
$DamageScale[GunshipJet, $ShrapnelDamageType] 	 = 1.0;
$DamageScale[GunshipJet, $LaserDamageType] 	 = 0.5;
$DamageScale[GunshipJet, $MortarDamageType] 	 = 0.7;
$DamageScale[GunshipJet, $BlasterDamageType] 	 = 0.5;
$DamageScale[GunshipJet, $ElectricityDamageType] = 1.0;
$DamageScale[GunshipJet, $CrushDamageType] 	 = 1.0;
$DamageScale[GunshipJet, $DebrisDamageType] 	 = 1.0;
$DamageScale[GunshipJet, $MissileDamageType] 	 = 1.0;
$DamageScale[GunshipJet, $MineDamageType]        = 1.0;
$DamageScale[GunshipJet, $EMPDamageType]	 = 1.0;
$DamageScale[GunshipJet, $NukeGrenadeDamageType] = 1.0;
$DamageScale[GunshipJet, $SniperDamageType]      = 1.0;
$DamageScale[GunshipJet, $AAMissileDamageType]   = 1.0;
$DamageScale[GunshipJet, $ShellDamageType] 	 = 1.0;


$DamageScale[HAPC, $ImpactDamageType] 	 = 1.0;
$DamageScale[HAPC, $BulletDamageType] 	 = 1.0;
$DamageScale[HAPC, $EnergyDamageType] 	 = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] 	 = 1.0;
$DamageScale[HAPC, $ExplosionDamageType]   = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] 	 = 1.0;
$DamageScale[HAPC, $LaserDamageType] 	 = 0.5;
$DamageScale[HAPC, $MortarDamageType] 	 = 0.7;
$DamageScale[HAPC, $BlasterDamageType] 	 = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $CrushDamageType] 	 = 1.0;
$DamageScale[HAPC, $DebrisDamageType] 	 = 1.0;
$DamageScale[HAPC, $MissileDamageType] 	 = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;
$DamageScale[HAPC, $EMPDamageType]		 = 1.0;
$DamageScale[HAPC, $NukeGrenadeDamageType] = 1.0;
$DamageScale[HAPC, $SniperDamageType]      = 1.0;
$DamageScale[HAPC, $AAMissileDamageType]   = 1.0;
$DamageScale[HAPC, $ShellDamageType] 	 = 1.0;

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
				if ((%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale") && Vehicle::canMount (%this, %object))
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
					Client::sendMessage(Player::getClient(%object),0,"You must be in Scout Armor or Light Armor to pilot the vehicles.~wError_Message.wav");
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
	if(%armor == "sarmor" || %armor == "fsarmor" || %armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor" || %armor == "aarmor") {
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