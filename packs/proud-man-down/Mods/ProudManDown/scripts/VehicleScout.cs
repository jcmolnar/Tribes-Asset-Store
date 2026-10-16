//--------------------------------------

$VehicleInvList[ScoutVehicle] = 1;

$DataBlockName[ScoutVehicle] = Scout;
$VehicleToItem[Scout] = ScoutVehicle;

//--------------------------------------

$TeamItemMax[ScoutVehicle] = 10;

//--------------------------------------

RocketData Flierbullet
{	
	bulletShapeName = "tracer.dts";
	explosionTag = BulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 2.15;
	damageType = $BulletDamageType;
	explosionRadius = 2;
	kickBackStrength = 0.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundWindGust;
};

BulletData SparkFlame
{
   bulletShapeName    = "fiery.dts";
   explosionTag       = GrenadeExp;


   damageClass        = 1;
   damageValue        = 0.20;
   damageType         = $ExplosionDamageType;
   explosionRadius    = 5.0;


   aimDeflection      = 3.0;
   muzzleVelocity     = 25.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   
// soundId = SoundJetLight;

};

GrenadeData PlaneDead2
{
   bulletShapeName    = "flyer.dts";
   explosionTag       = FireExp;
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
   maxLevelFlightDist = 100;
   totalTime          = 30.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "fiery.dts";
};
//--------------------------------------

FlierData Scout
{
	explosionId = SmokayExp;
	debrisId = flashPlaneLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 0.0001;
   drag = 0.5;
   density = 0.5;
   maxBank = 999.5;
   maxPitch = 99.5;
   maxSpeed = 45;
   minSpeed = -3.0;
	lift = 99.0;
	maxAlt = 240;
	maxVertical = 9;
	maxDamage = 4.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 4.0;
	maxEnergy = 100;
	accel = 0.08;

	groundDamageScale = 4.0;
	projectileType = Flierbullet;
	reloadDelay = 0.12;
	repairRate = 0;
	fireSound = debrisSmallExplosion;
	damageSound = ricochet3;
	ramDamage = 4.5;
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
	description = "Fighter Plane";
};
//--------------------------------------

$DamageScale[Scout, $ImpactDamageType] = 4.0;
$DamageScale[Scout, $BulletDamageType] = 0.6;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 0.1;
$DamageScale[Scout, $MissileDamageType] = 0.8;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;

//-------------------------------------
function Scout::onDestroyed(%this)

{
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("SparkFlame",%trans,%this,0);
		 Projectile::spawnProjectile("PlaneDead2",%trans,%this,0);
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