//=======================================================
// FBW Rocket
//==========================================================
$TeamItemMax[FBW] = 5;
//==========================================================
$VehicleToItem[FBWRocket] = FBW;
//==========================================================
FlierData FBWRocket
{
	explosionId = slayerExp;
	debrisId = NoDebris;
	className = "Vehicle";
	shapeFile = "proj_rocket";
	shieldShapeName = "breath";
	mass = 1.0;
	drag = 1.0;
	density = 1.0;
	maxBank = 7.5;
	maxPitch = 7.5;
	maxSpeed = 100;
	minSpeed = 75;
	lift = 0.0;
	maxAlt = 2500;
	maxVertical = 1000;
	maxDamage = 0.1;
	damageLevel = {1.0, 1.0};
	maxEnergy = 15;
	accel = 25.0;
	
	groundDamageScale = 5.0;
	
	repairRate = 0;
	ramDamage = 0.5;
	ramDamageType = 21;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = NoSound;
	dismountSound = NoSound;
	idleSound = SoundWhizSlayer;
	moveSound = NoSound;
	
	visibleDriver = false;
	driverPose = 23;
	description = "FBW Rocket";
};

function FBWRocket::onAdd(%this)
{
	schedule("checkOperator("@%this@");",5.0,%this);
	GameBase::setRechargeRate(%this, -1);
}
///////////////////////////////////////////////////////////////////////////

	$DamageScale[FBWRocket, $TurretSonicDamageType] = 5.0;
	$DamageScale[FBWRocket, $TurretLaserDamageType] = 2.0;
	$DamageScale[FBWRocket, $TurretMissileDamageType] = 3.0;
	$DamageScale[FBWRocket, $TurretFusionDamageType] = 1.0;
	$DamageScale[FBWRocket, $TurretRailDamageType] = 1.0;
	//-------------------------------------------------deployables
	$DamageScale[FBWRocket, $TurretRocketDamageType] = 3.0;
	$DamageScale[FBWRocket, $TurretTrojaxDamageType] = 2.0;
	$DamageScale[FBWRocket, $TurretFlamerDamageType] = 1.0;
	$DamageScale[FBWRocket, $TurretAssassinDamageType] = 5.0;
	$DamageScale[FBWRocket, $TurretPhotonDamageType] = 1.5;
	$DamageScale[FBWRocket, $TurretSentryDamageType] = 1.0;
	//-------------------------------------------------natural
	$DamageScale[FBWRocket, $LandingDamageType] = 1.0;
	$DamageScale[FBWRocket, $ImpactDamageType] = 3.0;
	$DamageScale[FBWRocket, $CrushDamageType] = 0.25;
	$DamageScale[FBWRocket, $DebrisDamageType] = 0.5;
	//---------------------------------------------------vehicle
	$DamageScale[FBWRocket, $VehicleLaserDamageType] = 5.0;
	$DamageScale[FBWRocket, $VehicleBombDamageType] = 5.0;
	$DamageScale[FBWRocket, $VehicleReaperDamageType] = 1.0;
	$DamageScale[FBWRocket, $VehicleSlayerDamageType] = 5.0;
	$DamageScale[FBWRocket, $VehicleDevastDamageType] = 5.0;
	$DamageScale[FBWRocket, $VehicleWraithDamageType] = 5.0;
	$DamageScale[FBWRocket, $VehicleChopperDamageType] = 1.0;
	$DamageScale[FBWRocket, $VehicleOspreyDamageType] = 1.0;
	//--------------------------------------------------weapons
	$DamageScale[FBWRocket, $SoulDamageType] = 1.0;
	$DamageScale[FBWRocket, $FarSightDamageType] = 7.0;  
	$DamageScale[FBWRocket, $AtomDamageType] = 3.0;
	$DamageScale[FBWRocket, $FusionDamageType] = 3.0;		
	$DamageScale[FBWRocket, $PhaserDamageType] = 1.25;
	$DamageScale[FBWRocket, $MaulerDamageType] = 1.5;
	$DamageScale[FBWRocket, $EMPDamageType] = 3.0;
	$DamageScale[FBWRocket, $FissionDamageType] = 2.0;
	$DamageScale[FBWRocket, $PlasmaticDamageType] = 5.0;
	$DamageScale[FBWRocket, $PulseDamageType] = 1.25;
	$DamageScale[FBWRocket, $PhotonDamageType] = 2.0;
	$DamageScale[FBWRocket, $PhotonRifleDamageType] = 4.0;
	$DamageScale[FBWRocket, $LaserCanDamageType] = 5.0;
	$DamageScale[FBWRocket, $LaserDamageType] = 1.0;
	$DamageScale[FBWRocket, $RaptorDamageType] = 6.0;
	$DamageScale[FBWRocket, $DesertDamageType] = 2.0;
	$DamageScale[FBWRocket, $MagDamageType] = 2.0;
	$DamageScale[FBWRocket, $FGLDamageType] = 1.0; 
	$DamageScale[FBWRocket, $FlakDamageType] = 5.0;
	$DamageScale[FBWRocket, $CMPDamageType] = 1.5;
	$DamageScale[FBWRocket, $ShotgunDamageType] = 1.25;
	$DamageScale[FBWRocket, $SMGDamageType] = 1.0;
	$DamageScale[FBWRocket, $SniperDamageType] = 5.0;
	$DamageScale[FBWRocket, $ARDamageType] = 1.5;
	$DamageScale[FBWRocket, $AssaultDamageType] = 1.5; 
	$DamageScale[FBWRocket, $MiniDamageType] = 1.0;
	$DamageScale[FBWRocket, $DiscDamageType] = 5.0;
	$DamageScale[FBWRocket, $RailDamageType] = 7.0;
	$DamageScale[FBWRocket, $FireStormDamageType] = 2.0;
	$DamageScale[FBWRocket, $ReaperDamageType] = 2.0;
	$DamageScale[FBWRocket, $TrojaxDamageType] = 5.0;		
	$DamageScale[FBWRocket, $SonicDamageType] = 7.0;	
	$DamageScale[FBWRocket, $FlamerDamageType] = 1.5;
	$DamageScale[FBWRocket, $MineDamageType] = 3.0;
	$DamageScale[FBWRocket, $RocketDamageType] = 5.0;
	$DamageScale[FBWRocket, $DevastDamageType] = 6.0;			
	$DamageScale[FBWRocket, $NapalmDamageType] = 7.0;
	$DamageScale[FBWRocket, $PFMDamageType] = 7.0;