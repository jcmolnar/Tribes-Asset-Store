//TRIBAL COMBAT DRONES
//********************
FlierData Drone
{
//	explosionId = flashExpLarge;
//	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "camera";
    shieldShapeName = "shield_medium";
    mass = 0.01;
    drag = 0.6;
    density = 0.3;
    maxBank = 1.5;
    maxPitch = 1.0;
    maxSpeed = 12;
    minSpeed = -10;
	lift = 0.75;
	maxAlt = 30;
	maxVertical = 10;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 0.6;

	groundDamageScale = 0.001;

	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.0001;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundDiscSpin;

	visibleDriver = false;
	driverPose = 22;
	description = "Drone";

	deployed = false;
};

function Drone::onCollision (%this, %object)
{
}

function Drone::jump(%this,%mom)
{
	GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function Drone::onFire(%this,%slot)
{
 %client = GameBase::getControlClient(%this);
 if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
  {
	if(GameBase::getLOSInfo(%this,3))
	 {
		%obj = getObjectType($los::object);
		if(%obj == "SimTerrain" || %obj == "InteriorShape")
		 {
		    %this.deployed = true;
			%prot = GameBase::getRotation(%this);
			%zRot = getWord(%prot,2);
			if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
			else
			{
				if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
				else %rot = Vector::getRotation($los::normal);
			}
			%camera = newObject("Camera","Turret",CameraTurret,true);
            addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera,GameBase::getTeam(%this));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,$los::position);
			Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Camera deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
			echo("MSG: Drone deployed a Camera");
			Drone::removeDrone(%this);
		}
	 }
  }
}

function Drone::removeDrone(%this)
{
 %client = GameBase::getControlClient(%this);
 %player = Client::getOwnedObject(%client);

  Player::setMountObject(%player, -1, 0);
  Client::setControlObject(%client,%player);
  %player.vehicle = "";

  Client::sendMessage(%client,0,"Drone camera deployed successfully");
 
  $TeamItemCount[GameBase::getTeam(%this) @ "DronePack"]--;
  GameBase::startFadeOut(%this);
  GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

//******************
FlierData GuidedBomb
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "rocket";
    shieldShapeName = "shield_medium";
    mass = 0.1;
    drag = 1.0;
    density = 1.2;
    maxBank = 0.60;
    maxPitch = 1.15;
    maxSpeed = 20;
    minSpeed = -1;
	lift = 0.85;
	maxAlt = 20;
	maxVertical = 20;
	maxDamage = 0.1;
	damageLevel = {1.0, 1.0};
	maxEnergy = 60;
	accel = 1.0;

	groundDamageScale = 1.0;

	repairRate = 0;
	damageSound = rocketExplosion;
	ramDamage = 4.0;
	ramDamageType = $MissileDamageType;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundJetHeavy;
	moveSound = SoundJetHeavy;

	visibleDriver = false;
	driverPose = 22;
	description = "Guided Bomb";
};

function GuidedBomb::onAdd(%this)
{
	GameBase::setRechargeRate (%this,0);
    schedule("GuidedBomb::exhaustFuel("@%this@");",1,%this);
}

function GuidedBomb::onCollision(%this,%object)
{
}

function GuidedBomb::jump(%this,%mom)
{
	GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function GuidedBomb::exhaustFuel(%this)
{
  %fuel = GameBase::getEnergy(%this);
  if(%fuel < 1) GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
  else 
  {
   GameBase::setEnergy(%this,%fuel - 4);
   schedule("GuidedBomb::exhaustFuel("@%this@");",5,%this);
  }
}

//*********************
FlierData GuidedMissile
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "rocket";
    shieldShapeName = "shield_medium";
    mass = 0.1;
    drag = 1.0;
    density = 1.2;
    maxBank = 0.5;
    maxPitch = 1.15;
    maxSpeed = 40;
    minSpeed = 40;
	lift = 0.85;
	maxAlt = 20;
	maxVertical = 20;
	maxDamage = 0.01;
	damageLevel = {1.0, 1.0};
	maxEnergy = 30;
	accel = 2.0;

	groundDamageScale = 2.0;

	repairRate = 0;
	damageSound = rocketExplosion;
	ramDamage = 0.1;
	ramDamageType = $MissileDamageType;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundJetHeavy;
	moveSound = SoundJetHeavy;

	visibleDriver = false;
	driverPose = 22;
	description = "Guided Missile";
};

function GuidedMissile::onAdd(%this)
{
 GameBase::setRechargeRate (%this,0);
 schedule("GuidedMissile::exhaustFuel("@%this@");",1,%this);
}

function GuidedMissile::onCollision(%this,%object)
{
 GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function GuidedMissile::jump(%this,%mom)
{
 GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function GuidedMissile::onDestroyed (%this,%mom)
{
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
   calcRadiusDamage(%this,$MissileDamageType, 30, 0.5, 20, 10, 8, 1.2, 0.7, 300, 200); 
}

function GuidedMissile::exhaustFuel(%this)
{
  %fuel = GameBase::getEnergy(%this);
  if(%fuel < 1) GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
  else 
  {
   GameBase::setEnergy(%this,%fuel - 8);
   schedule("GuidedMissile::exhaustFuel("@%this@");",5,%this);
  }
}

//*******************
FlierData SurveyDrone
{
//	explosionId = flashExpSmall;
//	debrisId = flashDebrisSmall;
	className = "Vehicle";
    shapeFile = "camera";
    shieldShapeName = "shield_medium";
    mass = 0.1;
    drag = 1.0;
    density = 1.2;
    maxBank = 0.3;
    maxPitch = 1.15;
    maxSpeed = 60;
    minSpeed = -20;
	lift = 1.0;
	maxAlt = 50;
	maxVertical = 50;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 1.0;

	groundDamageScale = 0.001;

	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.0001;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundDiscSpin;

	visibleDriver = false;
	driverPose = 22;
	description = "Survey Drone";
};

function SurveyDrone::onCollision(%this,%object)
{
}

function SurveyDrone::jump(%this,%mom)
{
	GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function SurveyDrone::onFire(%this,%slot)
{
 %client = GameBase::getControlClient(%this);
 if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
  {
	if(GameBase::getLOSInfo(%this,3))
	 {
		%obj = getObjectType($los::object);
		if(%obj == "SimTerrain" || %obj == "InteriorShape")
		 {
		    %this.deployed = true;
			%prot = GameBase::getRotation(%this);
			%zRot = getWord(%prot,2);
			if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
			else
			{
				if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
				else %rot = Vector::getRotation($los::normal);
			}
			%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
            addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%this));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,$los::position);
			Gamebase::setMapName(%beacon,"Target Beacon");
		    Beacon::onEnabled(%beacon);
			Client::sendMessage(%client,0,"Beacon deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
			echo("MSG: Survey Drone deployed a Beacon");
			SurveyDrone::removeDrone(%this);
		}
	 }
  }
}

function SurveyDrone::removeDrone(%this)
{
 %client = GameBase::getControlClient(%this);
 %player = Client::getOwnedObject(%client);

  Player::setMountObject(%player, -1, 0);
  Client::setControlObject(%client,%player);
  %player.vehicle = "";

  Client::sendMessage(%client,0,"Drone beacon deployed successfully");
 
  $TeamItemCount[GameBase::getTeam(%this) @ "SurveyDronePack"]--;
  GameBase::startFadeOut(%this);
  GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

//*******************
FlierData AttackDrone
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "remoteturret";
    shieldShapeName = "shield_medium";
    mass = 0.1;
    drag = 1.0;
    density = 1.2;
    maxBank = 1.1;
    maxPitch = 1.15;
    maxSpeed = 30;
    minSpeed = -5;
	lift = 0.85;
	maxAlt = 20;
	maxVertical = 20;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 0.8;

    projectileType = VRPBullet;
    reloadDelay = 0.12;
	fireSound = SoundFireMortar;

	groundDamageScale = 0.05;

	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.01;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundDiscSpin;

	visibleDriver = false;
	driverPose = 22;
	description = "Attack Drone";
};

function AttackDrone::onCollision(%this,%object)
{
}

function AttackDrone::jump(%this,%mom)
{
	GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

//function AttackDrone::onFire(%this,%slot)
//{
// %client = GameBase::getControlClient(%this);
//echo(%this@" "@%client);
//}

//*******************************************
$DamageScale[Drone, $ImpactDamageType] = 1.0;
$DamageScale[Drone, $BulletDamageType] = 2.0;
$DamageScale[Drone, $PlasmaDamageType] = 2.0;
$DamageScale[Drone, $EnergyDamageType] = 2.0;
$DamageScale[Drone, $ExplosionDamageType] = 2.0;
$DamageScale[Drone, $ShrapnelDamageType] = 2.0;
$DamageScale[Drone, $DebrisDamageType] = 2.0;
$DamageScale[Drone, $MissileDamageType] = 2.0;
$DamageScale[Drone, $LaserDamageType] = 2.0;
$DamageScale[Drone, $MortarDamageType] = 2.0;
$DamageScale[Drone, $BlasterDamageType] = 2.0;
$DamageScale[Drone, $ElectricityDamageType] = 2.0;
$DamageScale[Drone, $MineDamageType]        = 2.0;
$DamageScale[Drone, $DrainDamageType]        = 2.0;

$DamageScale[GuidedBomb, $ImpactDamageType] = 1.0;
$DamageScale[GuidedBomb, $BulletDamageType] = 2.0;
$DamageScale[GuidedBomb, $PlasmaDamageType] = 2.0;
$DamageScale[GuidedBomb, $EnergyDamageType] = 2.0;
$DamageScale[GuidedBomb, $ExplosionDamageType] = 2.0;
$DamageScale[GuidedBomb, $ShrapnelDamageType] = 2.0;
$DamageScale[GuidedBomb, $DebrisDamageType] = 2.0;
$DamageScale[GuidedBomb, $MissileDamageType] = 2.0;
$DamageScale[GuidedBomb, $LaserDamageType] = 2.0;
$DamageScale[GuidedBomb, $MortarDamageType] = 2.0;
$DamageScale[GuidedBomb, $BlasterDamageType] = 2.0;
$DamageScale[GuidedBomb, $ElectricityDamageType] = 2.0;
$DamageScale[GuidedBomb, $MineDamageType]        = 2.0;
$DamageScale[GuidedBomb, $DrainDamageType]        = 2.0;

$DamageScale[GuidedMissile, $ImpactDamageType] = 1.0;
$DamageScale[GuidedMissile, $BulletDamageType] = 2.0;
$DamageScale[GuidedMissile, $PlasmaDamageType] = 2.0;
$DamageScale[GuidedMissile, $EnergyDamageType] = 2.0;
$DamageScale[GuidedMissile, $ExplosionDamageType] = 2.0;
$DamageScale[GuidedMissile, $ShrapnelDamageType] = 2.0;
$DamageScale[GuidedMissile, $DebrisDamageType] = 2.0;
$DamageScale[GuidedMissile, $MissileDamageType] = 2.0;
$DamageScale[GuidedMissile, $LaserDamageType] = 2.0;
$DamageScale[GuidedMissile, $MortarDamageType] = 2.0;
$DamageScale[GuidedMissile, $BlasterDamageType] = 2.0;
$DamageScale[GuidedMissile, $ElectricityDamageType] = 2.0;
$DamageScale[GuidedMissile, $MineDamageType]        = 2.0;
$DamageScale[GuidedMissile, $DrainDamageType]        = 2.0;

$DamageScale[SurveyDrone, $ImpactDamageType] = 1.0;
$DamageScale[SurveyDrone, $BulletDamageType] = 2.0;
$DamageScale[SurveyDrone, $PlasmaDamageType] = 2.0;
$DamageScale[SurveyDrone, $EnergyDamageType] = 2.0;
$DamageScale[SurveyDrone, $ExplosionDamageType] = 2.0;
$DamageScale[SurveyDrone, $ShrapnelDamageType] = 2.0;
$DamageScale[SurveyDrone, $DebrisDamageType] = 2.0;
$DamageScale[SurveyDrone, $MissileDamageType] = 2.0;
$DamageScale[SurveyDrone, $LaserDamageType] = 2.0;
$DamageScale[SurveyDrone, $MortarDamageType] = 2.0;
$DamageScale[SurveyDrone, $BlasterDamageType] = 2.0;
$DamageScale[SurveyDrone, $ElectricityDamageType] = 2.0;
$DamageScale[SurveyDrone, $MineDamageType]        = 2.0;
$DamageScale[SurveyDrone, $DrainDamageType]        = 2.0;

$DamageScale[AttackDrone, $ImpactDamageType] = 1.0;
$DamageScale[AttackDrone, $BulletDamageType] = 2.0;
$DamageScale[AttackDrone, $PlasmaDamageType] = 2.0;
$DamageScale[AttackDrone, $EnergyDamageType] = 2.0;
$DamageScale[AttackDrone, $ExplosionDamageType] = 2.0;
$DamageScale[AttackDrone, $ShrapnelDamageType] = 2.0;
$DamageScale[AttackDrone, $DebrisDamageType] = 2.0;
$DamageScale[AttackDrone, $MissileDamageType] = 2.0;
$DamageScale[AttackDrone, $LaserDamageType] = 2.0;
$DamageScale[AttackDrone, $MortarDamageType] = 2.0;
$DamageScale[AttackDrone, $BlasterDamageType] = 2.0;
$DamageScale[AttackDrone, $ElectricityDamageType] = 2.0;
$DamageScale[AttackDrone, $MineDamageType]        = 2.0;
$DamageScale[AttackDrone, $DrainDamageType]        = 2.0;
