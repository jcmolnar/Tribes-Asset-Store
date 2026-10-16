//--------------------------------------

$VehicleInvList[HAPCVehicle] = 1;

$DataBlockName[HAPCVehicle] = HAPC;
$VehicleToItem[HAPC] = HAPCVehicle;

//--------------------------------------

$TeamItemMax[HAPCVehicle] = 8;

//-------------------------------------

GrenadeData PlaneDead3
{
   bulletShapeName    = "flyer.dts";
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 550.0;
   maxLevelFlightDist = 50;
   totalTime          = 30.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "tumult_medium.dts";
};

GrenadeData PlaneBurner1
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = mineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 5.0;
   density = 5.0;
   elasticity         = 1.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.32;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.01;
   totalTime          = 0.2;
   liveTime           = 0.3;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";

};

GrenadeData Bomb
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.1;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "breath.dts";
   
soundId = SoundWindAmbient; // This makes the bullet hiss
			 // if it passes by your head.
			 // Adds to the realism of the
			 // bullet.  --Deadtaco

};

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 999.0;
   drag = 999.5;
   density = 999.2;
   maxBank = 999.5;
   maxPitch = 999.5;
   maxSpeed = 30;
   minSpeed = -3.0;
	lift = 90.0;
	maxAlt = 180;
	maxVertical = 10;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 3.0;
	maxEnergy = 100;
	accel = 0.08;

	groundDamageScale = 1.0;

	projectileType = Bomb;
	reloadDelay = 5.0;
	repairRate = 0;
	fireSound = SoundPDAButtonHard;
	damageSound = ricochet3;
	ramDamage = 0.0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFireChaingun;

	visibleDriver = false;
	driverPose = 22;
	description = "Bomber Plane";
};


//--------------------------------------

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 0.5;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 0.6;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;

//--------------------------------------

function HAPC::onDestroyed(%this)

{
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("PlaneBurner1",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("PlaneDead3",%trans,%this,0);
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