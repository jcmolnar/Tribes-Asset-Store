//----------------------------------------------------------------------------
FlierData ShortCoolProj 
{ 
	description = "ArrowIV Missile"; 
	explosionId = bulletExpHV;
	className = "Vehicle"; 
	shapeFile = "rocket"; 
	shieldShapeName = "shield_medium"; 
	mass = 9.0; 
	drag = 1.5; 
	density = 1.2; 
	maxBank = 50; 
	maxPitch = 5000; 
	maxSpeed = 51; 
	minSpeed = 50; 
	lift = 0; 
	maxAlt = 90000; 
	maxVertical = 10; 
	destroyDamage = 0.001; 
	maxDamage = 0.001; 
	damageLevel = {0.001, 0.001}; 
	maxEnergy = 10; 
	accel = 100.0; 

	groundDamageScale = 1.0; 

	repairRate = 0; 
	damageSound = SoundFlierCrash; 
	ramDamage = 0.01; 
	ramDamageType = $MissileDamageType; 
	visibleToSensor = true; 
	shadowDetailMask = 2; 

	idleSound = SoundWindGust; 
	moveSound = SoundWindGust; 
	visibleDriver = true; 
	driverPose = 22; 
};
function ShortCoolProj::onAdd(%this)//+++++++++ FIX ++++++++
{
	schedule("DeployKill(" @ %this @ " , 1);",8.0,%this);
}
function DeployKill(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","DogVomit2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeployKill(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
function DeploySmoke2(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","DogVomit");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeploySmoke2(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
//++++++++++++++++++++++
FlierData ShortCoolProj2
{ 
	description = "ArrowIV Missile"; 
	explosionId = bulletExpHV;
	className = "Vehicle"; 
	shapeFile = "rocket"; 
	shieldShapeName = "shield_medium"; 
	mass = 9.0; 
	drag = 1.5; 
	density = 1.2; 
	maxBank = 50; 
	maxPitch = 5000; 
	maxSpeed = 51; 
	minSpeed = 50; 
	lift = 0; 
	maxAlt = 90000; 
	maxVertical = 10; 
	destroyDamage = 0.001; 
	maxDamage = 0.001; 
	damageLevel = {0.001, 0.001}; 
	maxEnergy = 10; 
	accel = 100.0; 

	groundDamageScale = 1.0; 

	repairRate = 0; 
	damageSound = SoundFlierCrash; 
	ramDamage = 0.01; 
	ramDamageType = $Inferno2DamageType; 
	visibleToSensor = true; 
	shadowDetailMask = 2; 

	idleSound = SoundWindGust; 
	moveSound = SoundWindGust; 
	visibleDriver = true; 
	driverPose = 22; 
};
function ShortCoolProj2::onAdd(%this)//+++++++++ FIX ++++++++
{
	schedule("DeployKillINF(" @ %this @ " , 1);",8.0,%this);
}
function DeployKillINF(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","DogVomitINF");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeployKillINF(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
function DeploySmokeINF(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","DogVomitINF");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeploySmokeINF(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData ScoutDroneProj 
{ 
	description = "Scout Drone"; 
	explosionId = BangExp;
	className = "Vehicle"; 
	shapeFile = "camera"; 
	shieldShapeName = "shield_medium"; 
	mass = 9.0; 
	drag = 1.5; 
	density = 1.2; 
	maxBank = 70; 
	maxPitch = 5000; 
	maxSpeed = 25; 
	minSpeed = -10; 
	lift = 0.75; 
	maxAlt = 90000; 
	maxVertical = 15; 
	destroyDamage = 0.001; //++++needed???++++++
	maxDamage = 0.15; 
	damageLevel = {0.001, 0.001}; 
	maxEnergy = 10; 
	accel = 0.5; 

	groundDamageScale = 1.0; 

//	projectileType = LRM5Rocket;
	reloadDelay = 0.5;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash; 
	ramDamage = 0.01; 
	ramDamageType = $ImpactDamageType; 
	visibleToSensor = true; 
	shadowDetailMask = 2; 

	idleSound = SoundWindGust; 
	moveSound = SoundWindGust; 
	visibleDriver = true; 
	driverPose = 22; 
};
function ScoutDroneProj::onAdd(%this)//+++++++++ FIX ++++++++
{
	schedule("DeployKillINF2(" @ %this @ " , 1);",60.0,%this);
}
function DeployKillINF2(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","DogVomitINF2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeployKillINF2(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
function DeploySmokeINF2(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","DogVomitINF2");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeploySmokeINF2(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}

//+++++++++++++++++++++++++++++++++++
FlierData Riever
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
   maxSpeed = 45; //55;+++++++++
   minSpeed = -5;
	lift = 0.75;
	maxAlt = 90000;
	maxVertical = 10;
	maxDamage = 1.1; //2.2;+++++++++++
	damageLevel = {1.0, 1.0};
	maxEnergy = 160;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = ArrowIVMissile;
	reloadDelay = 4.0;
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
	description = "Riever";
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData PH
{
	explosionId = PHExp;
	className = "Vehicle";
   shapeFile = "rocket";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.4; //0.55;++++
   maxPitch = 0.4; //0.55;++++
   maxSpeed = 40; //45;+++++++++
   minSpeed = -5;
	lift = 0.75;
	maxAlt = 90000;
	maxVertical = 15;
	maxDamage = 1.2; //1.8;+++++++++++
	damageLevel = {1.0, 1.0};
	maxEnergy = 125;
	accel = 0.4;

	groundDamageScale = 1.0;

//	projectileType = MedLaserTurretShell; //AC10Tracer;+++++
	reloadDelay = 0.75;
	repairRate = 0;
	fireSound = debrisMediumExplosion;
	damageSound = SoundFlierCrash;
	ramDamage = 0.5; //1.5;
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
	description = "Phoenix Hawk";
};

function PH::OnFire(%this)
{
%enVal  = 20.0;
%energy2 = GameBase::getEnergy(%this);
%energy = %energy2 - %enVal;
if (%energy2 > 124.0)
	{
	%trans = GameBase::getMuzzleTransform(%this);
	%loc = Vector::add(GameBase::getPosition(%this), "0 0 -2.5");
	%trans = getWord(%trans,0) @ " " @getWord(%trans,1) @ " " @getWord(%trans,2) @ " " @getWord(%trans,3) @ " " @getWord(%trans,4) @ " " @getWord(%trans,5) @ " " @getWord(%trans,6) @ " " @getWord(%trans,7) @ " " @getWord(%trans,8) @ " " @ %loc;//++++thanks to KtA{Strike++++++++++++++
 	GameBase::setEnergy(%this,%energy);
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%forwarddist = 15;
	%offset = Vector::getFromRot(%rot, %forwarddist);
	%poss = Vector::add(%pos, %offset);
	playSound(SoundFireFlierRocket,GameBase::getPosition(%this));
	%vel = Item::getVelocity(%this);
	Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
	Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
	Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
	Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
	Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
	}
else
	{
	Player::trigger(%this,$WeaponSlot,false);
	} 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData Corsair
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.45;//0.65;+++++++
   maxPitch = 0.65;
   maxSpeed = 65;//75;+++++++
   minSpeed = -5;
	lift = 0.75;
	maxAlt = 90000;
	maxVertical = 15;
	maxDamage = 0.9; //1.8;+++++++++++
	damageLevel = {1.0, 1.0};
	maxEnergy = 130;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = AC10Tracer;
	reloadDelay = 0.15;
	repairRate = 0;
	fireSound = debrisMediumExplosion;
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
	description = "Corsair";
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData Stingray
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.6; //0.8;++++
   maxPitch = 0.6; //0.8;++++
   maxSpeed = 55;//65;+++++++
   minSpeed = -5;
	lift = 0.75;
	maxAlt = 90000;
	maxVertical = 15;
	maxDamage = 0.75; //1.5;++++++++++++
	damageLevel = {1.0, 1.0};
	maxEnergy = 125;
	accel = 0.4;

	groundDamageScale = 1.0;

//	projectileType = PPCBolt;
	reloadDelay = 1.0; //1.75;+++++++++++++
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
	description = "Stingray";
};

function Stingray::OnFire(%this)
{
%enVal  = 17.0;
%energy2 = GameBase::getEnergy(%this);
%energy = %energy2 - %enVal;
if (%energy2 > 124.0)
	{
	%trans = GameBase::getMuzzleTransform(%this);
	%loc = Vector::add(GameBase::getPosition(%this), "0 0 -2.5");
	%trans = getWord(%trans,0) @ " " @getWord(%trans,1) @ " " @getWord(%trans,2) @ " " @getWord(%trans,3) @ " " @getWord(%trans,4) @ " " @getWord(%trans,5) @ " " @getWord(%trans,6) @ " " @getWord(%trans,7) @ " " @getWord(%trans,8) @ " " @ %loc;//++++thanks to KtA{Strike++++++++++++++
 	GameBase::setEnergy(%this,%energy);
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%forwarddist = 15;
	%offset = Vector::getFromRot(%rot, %forwarddist);
	%poss = Vector::add(%pos, %offset);
	playSound(SoundFireFlierRocket,GameBase::getPosition(%this));
	%vel = Item::getVelocity(%this);
	Projectile::spawnProjectile("PPCBolt3",%trans,%poss,%vel);
	Projectile::spawnProjectile("PPCBolt3",%trans,%poss,%vel);
	}
else
	{
//	%cl = GameBase::getControlClient(%this);
//	%pl = Client::getOwnedObject(%cl);
//	Player::trigger(%cl,$WeaponSlot,false);
//	Client::sendMessage(Player::getClient(%pl), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	return;
	} 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData Leopard
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
   maxPitch = 0.3;
   maxSpeed = 30;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 90000;
	maxVertical = 8;
	maxDamage = 2.0; //3.0;++++++++++++++++++
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 125; //300;
	accel = 0.25;

	groundDamageScale = 0.50;

//	projectileType = STR2Missile;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundMissileTurretFire;
	reloadDelay = 0.5;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Leopard Class";
};

//++++Add ammo counter later++++
function Leopard::OnFire(%this)
{
%enVal  = 30.0;
%energy2 = GameBase::getEnergy(%this);
%energy = %energy2 - %enVal;
if (%energy2 > 124.0)
	{
 	GameBase::setEnergy(%this,%energy);
	for(%i = 2;  %i > 0; %i--)
		{
		schedule("Leopard::Shoot(" @ %this @ ");", %timedelay);
		%timedelay = %timedelay + 0.4;
		}
	}
else
	{
	Player::trigger(%this,$WeaponSlot,false);
	} 
}
function Leopard::Shoot(%this)
{
%trans = GameBase::getMuzzleTransform(%this);
%loc = Vector::add(GameBase::getPosition(%this), "0 0 -2.5");
%trans = getWord(%trans,0) @ " " @getWord(%trans,1) @ " " @getWord(%trans,2) @ " " @getWord(%trans,3) @ " " @getWord(%trans,4) @ " " @getWord(%trans,5) @ " " @getWord(%trans,6) @ " " @getWord(%trans,7) @ " " @getWord(%trans,8) @ " " @ %loc;//++++thanks to KtA{Strike++++++++++++++
%pos = GameBase::getPosition(%this);
%rot = GameBase::getRotation(%this);
%forwarddist = 15;
%offset = Vector::getFromRot(%rot, %forwarddist);
%poss = Vector::add(%pos, %offset);
playSound(SoundFireFlierRocket,GameBase::getPosition(%this));
%vel = Item::getVelocity(%this);
Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
Projectile::spawnProjectile("LRM5Rocket",%trans,%poss,%vel);
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData Union
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.2;
   maxPitch = 0.2;
   maxSpeed = 25;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 90000;
	maxVertical = 6;
	maxDamage = 3.0; //4.6;+++++++++++++++++++++++
	damageLevel = {1.0, 1.0};
	maxEnergy = 500;
	accel = 0.25;

	groundDamageScale = 0.125;

	projectileType = MortarTurretShell;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = bigExplosion1;
	reloadDelay = 4.0; //3.5;+++++++++++++++++++++++++
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Union Class";
};

//----------------------------------------------------------------------------
$DamageScale[Riever, $LandingDamageType] = 1.0;
$DamageScale[Riever, $ImpactDamageType] = 1.0;
$DamageScale[Riever, $CrushDamageType] = 1.0;
$DamageScale[Riever, $DebrisDamageType] = 1.0;
$DamageScale[Riever, $ExplosionDamageType] = 1.0;
$DamageScale[Riever, $ShrapnelDamageType] = 1.0;
$DamageScale[Riever, $BulletDamageType] = 1.0;
$DamageScale[Riever, $FlamerDamageType] = 1.0;
$DamageScale[Riever, $ElectricityDamageType] = 1.0;
$DamageScale[Riever, $PPCDamageType] = 1.0;
$DamageScale[Riever, $GaussDamageType] = 1.0;
$DamageScale[Riever, $LaserDamageType] = 1.0;
$DamageScale[Riever, $ACDamageType] = 1.0;
$DamageScale[Riever, $SniperDamageType] = 1.0;
$DamageScale[Riever, $STRDamageType] = 1.0;
$DamageScale[Riever, $LRMDamageType] = 1.0;
$DamageScale[Riever, $MissileDamageType] = 1.0;
$DamageScale[Riever, $MineDamageType] = 1.0;
$DamageScale[Riever, $InfernoDamageType] = 1.0;
$DamageScale[Riever, $Inferno2DamageType] = 1.0;
$DamageScale[Riever, $FlashDamageType] = 1.0;

$DamageScale[PH, $LandingDamageType] = 1.0;
$DamageScale[PH, $ImpactDamageType] = 1.0;
$DamageScale[PH, $CrushDamageType] = 1.0;
$DamageScale[PH, $DebrisDamageType] = 1.0;
$DamageScale[PH, $ExplosionDamageType] = 1.0;
$DamageScale[PH, $ShrapnelDamageType] = 1.0;
$DamageScale[PH, $BulletDamageType] = 1.0;
$DamageScale[PH, $FlamerDamageType] = 1.0;
$DamageScale[PH, $ElectricityDamageType] = 1.0;
$DamageScale[PH, $PPCDamageType] = 1.0;
$DamageScale[PH, $GaussDamageType] = 1.0;
$DamageScale[PH, $LaserDamageType] = 1.0;
$DamageScale[PH, $ACDamageType] = 1.0;
$DamageScale[PH, $SniperDamageType] = 1.0;
$DamageScale[PH, $STRDamageType] = 1.0;
$DamageScale[PH, $LRMDamageType] = 1.0;
$DamageScale[PH, $MissileDamageType] = 1.0;
$DamageScale[PH, $MineDamageType] = 1.0;
$DamageScale[PH, $InfernoDamageType] = 1.0;
$DamageScale[PH, $Inferno2DamageType] = 1.0;
$DamageScale[PH, $FlashDamageType] = 1.0;

$DamageScale[Corsair, $LandingDamageType] = 1.0;
$DamageScale[Corsair, $ImpactDamageType] = 1.0;
$DamageScale[Corsair, $CrushDamageType] = 1.0;
$DamageScale[Corsair, $DebrisDamageType] = 1.0;
$DamageScale[Corsair, $ExplosionDamageType] = 1.0;
$DamageScale[Corsair, $ShrapnelDamageType] = 1.0;
$DamageScale[Corsair, $BulletDamageType] = 1.0;
$DamageScale[Corsair, $FlamerDamageType] = 1.0;
$DamageScale[Corsair, $ElectricityDamageType] = 1.0;
$DamageScale[Corsair, $PPCDamageType] = 1.0;
$DamageScale[Corsair, $GaussDamageType] = 1.0;
$DamageScale[Corsair, $LaserDamageType] = 1.0;
$DamageScale[Corsair, $ACDamageType] = 1.0;
$DamageScale[Corsair, $SniperDamageType] = 1.0;
$DamageScale[Corsair, $STRDamageType] = 1.0;
$DamageScale[Corsair, $LRMDamageType] = 1.0;
$DamageScale[Corsair, $MissileDamageType] = 1.0;
$DamageScale[Corsair, $MineDamageType] = 1.0;
$DamageScale[Corsair, $InfernoDamageType] = 1.0;
$DamageScale[Corsair, $Inferno2DamageType] = 1.0;
$DamageScale[Corsair, $FlashDamageType] = 1.0;

$DamageScale[Stingray, $LandingDamageType] = 1.0;
$DamageScale[Stingray, $ImpactDamageType] = 1.0;
$DamageScale[Stingray, $CrushDamageType] = 1.0;
$DamageScale[Stingray, $DebrisDamageType] = 1.0;
$DamageScale[Stingray, $ExplosionDamageType] = 1.0;
$DamageScale[Stingray, $ShrapnelDamageType] = 1.0;
$DamageScale[Stingray, $BulletDamageType] = 1.0;
$DamageScale[Stingray, $FlamerDamageType] = 1.0;
$DamageScale[Stingray, $ElectricityDamageType] = 1.0;
$DamageScale[Stingray, $PPCDamageType] = 1.0;
$DamageScale[Stingray, $GaussDamageType] = 1.0;
$DamageScale[Stingray, $LaserDamageType] = 1.0;
$DamageScale[Stingray, $ACDamageType] = 1.0;
$DamageScale[Stingray, $SniperDamageType] = 1.0;
$DamageScale[Stingray, $STRDamageType] = 1.0;
$DamageScale[Stingray, $LRMDamageType] = 1.0;
$DamageScale[Stingray, $MissileDamageType] = 1.0;
$DamageScale[Stingray, $MineDamageType] = 1.0;
$DamageScale[Stingray, $InfernoDamageType] = 1.0;
$DamageScale[Stingray, $Inferno2DamageType] = 1.0;
$DamageScale[Stingray, $FlashDamageType] = 1.0;

$DamageScale[Leopard, $LandingDamageType] = 1.0;
$DamageScale[Leopard, $ImpactDamageType] = 1.0;
$DamageScale[Leopard, $CrushDamageType] = 1.0;
$DamageScale[Leopard, $DebrisDamageType] = 1.0;
$DamageScale[Leopard, $ExplosionDamageType] = 1.0;
$DamageScale[Leopard, $ShrapnelDamageType] = 1.0;
$DamageScale[Leopard, $BulletDamageType] = 1.0;
$DamageScale[Leopard, $FlamerDamageType] = 1.0;
$DamageScale[Leopard, $ElectricityDamageType] = 1.0;
$DamageScale[Leopard, $PPCDamageType] = 1.0;
$DamageScale[Leopard, $GaussDamageType] = 1.0;
$DamageScale[Leopard, $LaserDamageType] = 1.0;
$DamageScale[Leopard, $ACDamageType] = 1.0;
$DamageScale[Leopard, $SniperDamageType] = 1.0;
$DamageScale[Leopard, $STRDamageType] = 1.0;
$DamageScale[Leopard, $LRMDamageType] = 1.0;
$DamageScale[Leopard, $MissileDamageType] = 1.0;
$DamageScale[Leopard, $MineDamageType] = 1.0;
$DamageScale[Leopard, $InfernoDamageType] = 1.0;
$DamageScale[Leopard, $Inferno2DamageType] = 1.0;
$DamageScale[Leopard, $FlashDamageType] = 1.0;

$DamageScale[Union, $LandingDamageType] = 1.0;
$DamageScale[Union, $ImpactDamageType] = 1.0;
$DamageScale[Union, $CrushDamageType] = 1.0;
$DamageScale[Union, $DebrisDamageType] = 1.0;
$DamageScale[Union, $ExplosionDamageType] = 1.0;
$DamageScale[Union, $ShrapnelDamageType] = 1.0;
$DamageScale[Union, $BulletDamageType] = 1.0;
$DamageScale[Union, $FlamerDamageType] = 1.0;
$DamageScale[Union, $ElectricityDamageType] = 1.0;
$DamageScale[Union, $PPCDamageType] = 1.0;
$DamageScale[Union, $GaussDamageType] = 1.0;
$DamageScale[Union, $LaserDamageType] = 1.0;
$DamageScale[Union, $ACDamageType] = 1.0;
$DamageScale[Union, $SniperDamageType] = 1.0;
$DamageScale[Union, $STRDamageType] = 1.0;
$DamageScale[Union, $LRMDamageType] = 1.0;
$DamageScale[Union, $MissileDamageType] = 1.0;
$DamageScale[Union, $MineDamageType] = 1.0;
$DamageScale[Union, $InfernoDamageType] = 1.0;
$DamageScale[Union, $Inferno2DamageType] = 1.0;
$DamageScale[Union, $FlashDamageType] = 1.0;

$DamageScale[ShortCoolProj, $LandingDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ImpactDamageType] = 1.0;
$DamageScale[ShortCoolProj, $CrushDamageType] = 1.0;
$DamageScale[ShortCoolProj, $DebrisDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ExplosionDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ShrapnelDamageType] = 1.0;
$DamageScale[ShortCoolProj, $BulletDamageType] = 1.0;
$DamageScale[ShortCoolProj, $FlamerDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ElectricityDamageType] = 1.0;
$DamageScale[ShortCoolProj, $PPCDamageType] = 1.0;
$DamageScale[ShortCoolProj, $GaussDamageType] = 1.0;
$DamageScale[ShortCoolProj, $LaserDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ACDamageType] = 1.0;
$DamageScale[ShortCoolProj, $SniperDamageType] = 1.0;
$DamageScale[ShortCoolProj, $STRDamageType] = 1.0;
$DamageScale[ShortCoolProj, $LRMDamageType] = 1.0;
$DamageScale[ShortCoolProj, $MissileDamageType] = 1.0;
$DamageScale[ShortCoolProj, $InfernoDamageType] = 1.0;
$DamageScale[ShortCoolProj, $Inferno2DamageType] = 1.0;
$DamageScale[ShortCoolProj, $FlashDamageType] = 1.0;

$DamageScale[ShortCoolProj2, $LandingDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $ImpactDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $CrushDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $DebrisDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $ExplosionDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $ShrapnelDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $BulletDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $FlamerDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $ElectricityDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $PPCDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $GaussDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $LaserDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $ACDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $SniperDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $STRDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $LRMDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $MissileDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $InfernoDamageType] = 1.0;
$DamageScale[ShortCoolProj2, $Inferno2DamageType] = 1.0;
$DamageScale[ShortCoolProj2, $FlashDamageType] = 1.0;

$DamageScale[ScoutDroneProj, $LandingDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $ImpactDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $CrushDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $DebrisDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $ExplosionDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $ShrapnelDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $BulletDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $FlamerDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $ElectricityDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $PPCDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $GaussDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $LaserDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $ACDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $SniperDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $STRDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $LRMDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $MissileDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $InfernoDamageType] = 1.0;
$DamageScale[ScoutDroneProj, $Inferno2DamageType] = 1.0;
$DamageScale[ScoutDroneProj, $FlashDamageType] = 1.0;

//----------------------------------------------------------------------------
function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function Vehicle::onCollision (%this, %object)
{
if(GameBase::getDataName(%this) == ScoutDroneProj)
	{
//		%what = GameBase::getDataName(%this);//++++returns ScoutDroneProj++++
//		%what2 = GameBase::getDataName(%object);//++++returns larmor++++
//		%what = Client::getOwnedObject(%this);//++++ -1 ++++
//		%what2 = Client::getOwnedObject(%object);//++++ -1 ++++
//		%what = GameBase::getOwnerClient(%this);//++++ -1 ++++
//		%what2 = GameBase::getOwnerClient(%object);//++++ 2049 ++++
//		%what = GameBase::getControlClient(%this);//++++ -1 ++++
		%what2 = GameBase::getControlClient(%object);//++++ 2049 ++++
	      %client = Player::getClient(%object);
//		%what = $hvWhat[%client];//++++ 2049 ++++
//Client::sendMessage(Player::getClient(%object), 1, "what:"@%what@" what2:"@%what2@"");
	if(%what2 = $hvWhat[%client])
		{
		%ply = Client::getOwnedObject(%client);
		Player::setItemCount(%ply, ScoutDroneAmmo,1);
		Client::sendMessage(%client, 0, "Scout Drone retrieved~wC_BuySell.wav");
		playSound (SoundRadarDeploy, GameBase::getPosition(%this));
		GameBase::setPosition(%this, "-1000 -1000 -1000");
		GameBase::applyRadiusDamage($MineDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
		return;
		}
	else
		{
		DeployKillINF2(%this);
		return;
		}
	}
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
			%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if (((%armor == "larmor" || %armor == "xarmor") && (GameBase::getDataName(%this) != PH) && Vehicle::canMount (%this, %object)) || ((%armor == "driver") && (GameBase::getDataName(%this) == PH) && Vehicle::canMount (%this, %object)))//+++++++++++++++++++++++
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      	Client::setControlObject(%client, %this);
					      doneposs(%client);
					if (%armor == "driver")//++++++++++++++
						{
						%PHdamage2 = GameBase::getDamageLevel(%object);
						GameBase::setDamageLevel(%this, %PHdamage2);
						%PHenergy2 = GameBase::getEnergy(%object);
						GameBase::setEnergy(%this, %PHenergy2);
						$hvPHLAM[%client] = 0;
						Client::sendMessage(%client, 0,"-Pheonix Hawk transforming to FLIGHT MODE-~welevator2.wav");
//		Client::sendMessage(Player::getClient(%object), 1,"new:"@%new@" this:"@%this@" rot:"@%rot@" markerPos:"@%markerPos@" mom2:"@%mom2@" this:"@%this@" PHdamage2:"@%PHdamage2@" PHenergy2:"@%PHenergy2@"");
						playSound (SoundRadarDeploy, GameBase::getPosition(%this));
						}
					else
					{
						Client::sendMessage(%client, 0,"-Piloting a "@ GameBase::getDataName(%this) @ "-Class Aerotech Vehicle-~wpda_on.wav");
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					} 
				}//+++++++++++++++++++
				else if(GameBase::getDataName(%this) != Riever && GameBase::getDataName(%this) != Corsair && GameBase::getDataName(%this) != Stingray) 
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
					Client::sendMessage(Player::getClient(%object),1,"-Only the Wasp and Commando are small enough to pilot Aerotech Vehicles-~wError_Message.wav");
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
	if(%armor == "larmor" || %armor == "xarmor" || %armor == "parmor" || %armor == "dmarmor") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "driver") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "carmor" ||  %armor == "hbarmor" || %armor == "aarmor" ||  %armor == "warmor") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor" || %armor == "rarmor" || %armor == "yarmor" || %armor == "barmor") {
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
		Client::sendMessage(Player::getClient(%passanger),1,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
	if(GameBase::getDataName(%this) == PH)
		{
		%cl = GameBase::getControlClient(%this);//++++2049++++
		%pl = Client::getOwnedObject(%cl); //++++8362++++
//		%xxx = GameBase::getDamageState(%this);//++++enabled++++
		// %this = 8372++++

//		if($hvTrigger[%cl] == 1)//+++++++++++
//		{
//	Player::onDamage(%pl,$NULLDamageType,"1000",GameBase::getPosition(%pl),"0 0 0","0 0 0","head","middle_back",0);
//	Player::kill(%pl);
//	Player::blowUp(%pl);
//			GameBase::setPosition(%this, "-1000 -1000 -1000");
//			GameBase::applyRadiusDamage($MineDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
//		}//++++++



		%rot = GameBase::getRotation(%this);
		%rotZ = getWord(%rot,2);
		GameBase::setRotation(%pl, "0 0 " @ %rotZ);
 		%mom2 = %mom*-0.2;
		Vehicle::dismount(%this, %mom2);
		%markerPos = GameBase::getPosition(%this);
		GameBase::setPosition(%pl,%markerPos);
		%PHdamage =	GameBase::getDamageLevel(%this);
		GameBase::setDamageLevel(%pl, %PHdamage);
		%PHenergy =	GameBase::getEnergy(%this);
		GameBase::setEnergy(%pl, %PHenergy);
//		%something = %this.lastmount; //returns nothing++++
//		%COpl = Client::setControlObject(%cl,%something);
//		%OOpl = Client::setOwnedObject(%cl,%something);
//		schedule("deleteObject(" @ %this @ ");",0.1);
//		$hvPHLAM[%cl] = 1;
		GameBase::setPosition(%this, "-1000 -1000 -1000");
		GameBase::applyRadiusDamage($MineDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
		playSound (SoundRadarDeploy, GameBase::getPosition(%this));
//		deleteObject(%this);
		Client::sendMessage(Player::getClient(%cl), 0,"-Phoenix Hawk transforming to MECH MODE-~welevator2.wav");
//		Client::sendMessage(Player::getClient(%cl), 1,"pl:"@%pl@" cl:"@%cl@" COpl:"@%COpl@" OOpl:"@%OOpl@" xxx:"@%xxx@" this:"@%this@" something:"@%something@" PHenergy:"@%PHenergy@ "");

//		if(%pl != -1) 
//			{
//			Client::setControlObject(%pl, -1); 
//			}

		}	
	else
	{
	Vehicle::dismount(%this,%mom);
	}
}

function Vehicle::dismount(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
	$hvPHLAM[%cl] = 1;//++++
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
//	Client::sendMessage(Player::getClient(%pl), 1,"this:"@%this@" pl:" @ %pl@ " pldesc:" @ %pl.description @ " dataname:" @ GameBase::getDataName(%pl) @"");
			if(%pl.lastWeapon != "") 
				{
				Player::useItem(%pl,%pl.lastWeapon);		 	
				%pl.lastWeapon = "";
      			}
			%pl.driver = "";
			%pl.vehicle = "";
			}
		else if(GameBase::getDataName(%this) == "PH")//+++++++++++
			{
			return;
			}
		else if(GameBase::getDataName(%this) == "ScoutDroneProj")//+++++++++++
			{
        	 	Client::setControlObject(%cl, %pl);
			}
		else if(GameBase::getDataName(%this) == "ShortCoolProj")//+++++++++++
			{
        	 	Client::setControlObject(%cl, %pl);
			}
		else if(GameBase::getDataName(%this) == "ShortCoolProj2")//+++++++++++
			{
        	 	Client::setControlObject(%cl, %pl);
			}
		else
			{
			Client::sendMessage(%cl,1,"Can not dismount - Obstacle in the way.~wError_Message.wav");
			}
		}//+++++++++++++++++
	}
}

function Vehicle::onDestroyed(%this,%mom)
{
StaticShape::objectiveDestroyed(%this);//+++++++++++
if (GameBase::getDataName(%this) == "PH")//+++++++++++++++++++++++
	{
	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if($hvPHLAM[%cl] == 0)
		{
		Player::kill(%pl);
		Player::blowUp(%pl);
		}

	//%this = 8375++++
//	%cl = GameBase::getControlClient(%this);//++++returns 2049++++
//	%pl = Client::getOwnedObject(%cl); //++++returns 8365++++
//	%jet = Player::getMountObject(%pl); //++++returns 8375++++
//	%jet = Client::getControlObject(%cl); //++++returns 8375++++
//	$hvTrigger[%cl] = 1;
//	Player::onDamage(%pl,$NULLDamageType,"1000",GameBase::getPosition(%pl),"0 0 0","0 0 0","head","middle_back",0);
//	Vehicle::jump(%this,%mom);
//	Client::sendMessage(Player::getClient(%pl), 1,"this:"@%this@" OV:" @ %OV@ " jet:" @ %jet @ " LM:" @%LM@"");
//	if(%cl != -1) {
//	   Player::setMountObject(%cl, -1, 0); }
//	if(Client::getControlObject(%cl))
//		{
//		Player::kill(%pl);
//		Player::blowUp(%pl);
//		}
//	else
//		{
//		return;
//		}
	}
//+++++++++ ArrowIV Guidance client drop ++++++++++++++++
	if(GameBase::getDataName(%this) == ShortCoolProj)
	{
	schedule("DeploySmoke2(" @ %this @ " , 1);",0.01,%this);
	}
	if(GameBase::getDataName(%this) == ShortCoolProj2)//+++++++++++++++
	{
	schedule("DeploySmokeINF(" @ %this @ " , 1);",0.01,%this);
	}
	if(GameBase::getDataName(%this) == ScoutDroneProj)//+++++++++++++++
	{
	schedule("DeploySmokeINF2(" @ %this @ " , 1);",0.01,%this);
	}
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