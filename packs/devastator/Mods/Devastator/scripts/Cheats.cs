function AIEasy() {$AICHEAT = 1;}
function TurretTower()
{
	if($TeamItemMax[WingBuddyPack] == 200) {
		$TeamItemMax[WingBuddyPack] = 12;
		$Dec[WingBuddyPack] = 1;
	} else {
		$TeamItemMax[WingBuddyPack] = 200;
		$Dec[WingBuddyPack] = 0;
	}
}
function FunFloor()
{
	if($TeamItemMax[ForceFloorPack] == 200) {
		$TeamItemMax[ForceFloorPack] = 12;
		$Dec[ForceFloorPack] = 1;
	} else {
		$TeamItemMax[ForceFloorPack] = 200;
		$Dec[ForceFloorPack] = 0;
	}
}
function ZigZagFun()
{
	if($ZigZagFun != 1)
		$ZigZagFun = 1;
	else
		$ZigZagFun = 0;
}
function VehicleFunny()
{
	if($VehicleSayWTF != 1)
		$VehicleSayWTF = 1;
	else
		$VehicleSayWTF = "";
}
function TestPerfectLock()
{
	R::LockedOn(Client::getOwnedObject(2049),Client::getOwnedObject(2050),"<jc><f2>Special Lock: Direct Lock Acquired");
}
function GiveIceList(%clientId)
{
	Player::setArmor(%clientId,Icemor);
	Player::setItemCount(%clientId,RepairPack,0);
	Player::setItemCount(%clientId,RL,1);
	Player::setItemCount(%clientId,MG,1);
	Player::setItemCount(%clientId,AR,1);
	Player::setItemCount(%clientId,SR,1);
	Player::setItemCount(%clientId,TB,1);
	Player::setItemCount(%clientId,BH,1);
	Player::setItemCount(%clientId,EL,1);
	Player::setItemCount(%clientId,Keg,1);
	Player::setItemCount(%clientId,Shotgun1,1);
	Player::setItemCount(%clientId,Sword,1);
	Player::setItemCount(%clientId,EnergyRifle,1);
	Player::setItemCount(%clientId,Tazer,1);
	Player::setItemCount(%clientId,Shock,1);
	Player::setItemCount(%clientId,Funk,1);
	Player::setItemCount(%clientId,Beam,1);
	Player::setItemCount(%clientId,FlameThrower,1);
	Player::setItemCount(%clientId,FreezeGun,1);
	Player::setItemCount(%clientId,Syn,1);
	Player::setItemCount(%clientId,V,1);
	Player::setItemCount(%clientId,R,1);

	Player::setItemCount(%clientId,GrenadeAmmo,500);
	Player::setItemCount(%clientId,DiscAmmo,500);
	Player::setItemCount(%clientId,MortarAmmo,500);
	Player::setItemCount(%clientId,MultiAmmo,500);
	Player::setItemCount(%clientId,RLAmmo,500);
	Player::setItemCount(%clientId,ELAmmo,200);
	Player::setItemCount(%clientId,MGAmmo,99999);
	Player::setItemCount(%clientId,PGLAmmo,500);
	Player::setItemCount(%clientId,SRAmmo,5);
	Player::setItemCount(%clientId,ARAmmo,30);
	Player::setItemCount(%clientId,Shotgun1Ammo,2);
	Player::setItemCount(%clientId,SniperClip,999);
	Player::setItemCount(%clientId,PistolClip,900);
	Player::setItemCount(%clientId,AssaultClip,900);
	Player::setItemCount(%clientId,ShotgunClip,900);
	Player::setItemCount(%clientId,SmokeAmmo,200);
	Player::setItemCount(%clientId,RAmmo,200);
	Player::setItemCount(%clientId,SynAmmo,200);

	Player::setItemCount(%clientId,Grenade, 200);
	Player::setItemCount(%clientId,MineAmmo, 50);
//	Player::setItemCount(%clientId,AirMineAmmo,50);
	Player::setItemCount(%clientId,Beacon, 5);
	Player::setItemCount(%clientId,RepairKit,200);
	Player::setItemCount(%clientId,Antidote,200);
	Player::setItemCount(%clientId,SuperPack1,1);
	Player::setItemCount(%clientId,Perfect,1);

	Player::mountItem(%clientId,SuperPack1,1);
	GameBase::setRechargeRate(%clientId, 1.5);
}

function GiveDCList(%clientId)
{
	Player::setArmor(%clientId,Icemor);
	Player::setItemCount(%clientId,PantherArmor,0);
	Player::setItemCount(%clientId,RL,1);
	Player::setItemCount(%clientId,MG,1);
	Player::setItemCount(%clientId,PC,1);
	Player::setItemCount(%clientId,BH,1);
	Player::setItemCount(%clientId,AR,1);
	Player::setItemCount(%clientId,SR,1);
	Player::setItemCount(%clientId,TB,1);
	Player::setItemCount(%clientId,EL,1);
	Player::setItemCount(%clientId,Shotgun1,1);
	Player::setItemCount(%clientId,PGL,1);
	Player::setItemCount(%clientId,Multi,1);
	Player::setItemCount(%clientId,EnergyRifle,1);
	Player::setItemCount(%clientId,SmokeLauncher,1);
	Player::setItemCount(%clientId,Shock,1);
	Player::setItemCount(%clientId,Funk,1);
	Player::setItemCount(%clientId,V,1);
	Player::setItemCount(%clientId,R,1);
		
	Player::setItemCount(%clientId,HGAmmo,500);
	Player::setItemCount(%clientId,GrenadeAmmo,500);
	Player::setItemCount(%clientId,DiscAmmo,500);
	Player::setItemCount(%clientId,MortarAmmo,500);
	Player::setItemCount(%clientId,MultiAmmo,500);
	Player::setItemCount(%clientId,RLAmmo,500);
	Player::setItemCount(%clientId,ELAmmo,200);
	Player::setItemCount(%clientId,MGAmmo,99999);
	Player::setItemCount(%clientId,PGLAmmo,500);
	Player::setItemCount(%clientId,SRAmmo,5);
	Player::setItemCount(%clientId,ARAmmo,30);
	Player::setItemCount(%clientId,Shotgun1Ammo,2);
	Player::setItemCount(%clientId,SniperClip,999);
	Player::setItemCount(%clientId,PistolClip,900);
	Player::setItemCount(%clientId,AssaultClip,900);
	Player::setItemCount(%clientId,ShotgunClip,900);
	Player::setItemCount(%clientId,SmokeAmmo,200);
	Player::setItemCount(%clientId,RAmmo,200);

	Player::setItemCount(%clientId,Grenade,200);
	Player::setItemCount(%clientId,MineAmmo,50);
	//Player::setItemCount(%clientId,AirMineAmmo,50);
	Player::setItemCount(%clientId,Beacon,5);
	Player::setItemCount(%clientId,RepairKit,200);
	Player::setItemCount(%clientId,Antidote,200);
	Player::setItemCount(%clientId,SuperPack2,1);

	Player::mountItem(%clientId,SuperPack2,1);
	GameBase::setRechargeRate(%clientId, 1.5);
}

ExplosionData IceDebrisExp
{
	shapeName = "enex.dts";
	soundId   = SoundFireDC2;
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 3.0;
	timeZero = 0.450;
	timeOne  = 0.750;
	colors[0]  = { 0.25, 0.25, 1.0 };
	colors[1]  = { 0.25, 0.25, 1.0 };
	colors[2]  = { 1.0, 1.0,  1.0 };
	radFactors = { 1.0, 1.0,  1.0 };
	shiftPosition = True;
};

DebrisData IceDebris
{
	type      = 0;
	imageType = 0;
	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };
	animationSequence = -1;
	minTimeout = 3.0;
	maxTimeout = 6.0;
	explodeOnBounce = 0.4;
	damage          = 99.0;
	damageThreshold = 99.0;
	spawnedDebrisMask     = 2;
	spawnedDebrisStrength = 99;
	spawnedDebrisRadius   = 1.2;
	spawnedExplosionID = IceDebrisExp;
	p = 1;
	explodeOnRest   = True;
	collisionDetail = 0;
};

$DamageScale[Icemor, $LandingDamageType] = 1.0;
$DamageScale[Icemor, $ImpactDamageType] = 1.0;
$DamageScale[Icemor, $CrushDamageType] = 1.0;
$DamageScale[Icemor, $BulletDamageType] = 1.2;
$DamageScale[Icemor, $PlasmaDamageType] = 0.5;
$DamageScale[Icemor, $EnergyDamageType] = 0.7;
$DamageScale[Icemor, $ExplosionDamageType] = 1.0;
$DamageScale[Icemor, $MissileDamageType] = 1.0;
$DamageScale[Icemor, $DebrisDamageType] = 0.7;
$DamageScale[Icemor, $ShrapnelDamageType] = 1.2;
$DamageScale[Icemor, $LaserDamageType] = 1.0;
$DamageScale[Icemor, $MortarDamageType] = 1.3;
$DamageScale[Icemor, $BlasterDamageType] = 1.3;
$DamageScale[Icemor, $ElectricityDamageType] = 1.0;
$DamageScale[Icemor, $MineDamageType] = 1.2;
$DamageScale[Icemor, $SBulletDamageType] = 1.0;
$DamageScale[Icemor, $PBulletDamageType] = 1.0;
$DamageScale[Icemor, $FreezeDamageType] = 1.0;
$DamageScale[Icemor, $FlashDamageType] = 1.0; 
$DamageScale[Icemor, $MiniDamageType] = 1.0;
$DamageScale[Icemor, $FunkDamageType] = 0.0;
$DamageScale[Icemor, $ConfettiDamageType] = 0.0;
$DamageScale[Icemor, $SniperDamageType] = 0.5;
$DamageScale[Icemor, $PsychoDamageType] = 0.0;
$DamageScale[Icemor, $ProtonDamageType] = 1.0;

$ItemMax[Icemor, Blaster] = 1;
$ItemMax[Icemor, Funk] = 1;
$ItemMax[Icemor, FreezeGun] = 1;
$ItemMax[Icemor, Disclauncher] = 1;
$ItemMax[Icemor, GrenadeLauncher] = 1;
$ItemMax[Icemor, Mortar] = 1;
$ItemMax[Icemor, Flamethrower] = 1;
$ItemMax[Icemor, EnergyRifle] = 1;
$ItemMax[Icemor, LP]  = 1;
$ItemMax[Icemor, RL]  = 1;
$ItemMax[Icemor, MG]  = 1;
$ItemMax[Icemor, FL]  = 1;
$ItemMax[Icemor, FP]  = 1;
$ItemMax[Icemor, PC]  = 1;
$ItemMax[Icemor, SP]  = 1;
$ItemMax[Icemor, BH]  = 1;
$ItemMax[Icemor, Shotgun1] = 1;
$ItemMax[Icemor, AR] = 1;
$ItemMax[Icemor, SR] = 1;
$ItemMax[Icemor, TB] = 1;
$ItemMax[Icemor, F] = 1;
$ItemMax[Icemor, EL] = 1;
$ItemMax[Icemor, Beam] = 1;
$ItemMax[Icemor, Sword] = 1;
$ItemMax[Icemor, Multi] = 1;
$ItemMax[Icemor, HG] = 1;
$ItemMax[Icemor, PGL] = 1;
$ItemMax[Icemor, SmokeLauncher] = 1;
$ItemMax[Icemor, Shock] = 1;
$ItemMax[Icemor, V] = 1;
$ItemMax[Icemor, TargetingLaser] = 1;

$ItemMax[Icemor, AirMineAmmo] = 2;
$ItemMax[Icemor, MineAmmo] = 50;
$ItemMax[Icemor, Grenade] = 50;
$ItemMax[Icemor, Beacon]  = 5;
$ItemMax[Icemor, RepairKit] = 1;
$ItemMax[Icemor, Antidote] = 1;

$ItemMax[Icemor, SniperClip] = 500;
$ItemMax[Icemor, PistolClip] = 500;
$ItemMax[Icemor, AssaultClip] = 500;
$ItemMax[IceMor, ShotgunClip] = 500;

$ItemMax[Icemor, HGAmmo] = 200;
$ItemMax[Icemor, SmokeAmmo] = 200;
$ItemMax[Icemor, MultiAmmo] = 500;
$ItemMax[Icemor, DiscAmmo] = 500;
$ItemMax[Icemor, GrenadeAmmo] = 500;
$ItemMax[Icemor, MortarAmmo] = 500;
$ItemMax[Icemor, RLAmmo] = 500;
$ItemMax[Icemor, MGAmmo] = 99999;
$ItemMax[Icemor, SPAmmo] = 9;
$ItemMax[Icemor, Shotgun1Ammo] = 2;
$ItemMax[Icemor, ARAmmo] = 30;
$ItemMax[Icemor, SRAmmo] = 5;
$ItemMax[Icemor, FAmmo] = 10;
$ItemMax[Icemor, ELAmmo] = 200;
$ItemMax[Icemor, PGLAmmo] = 500;

$ItemMax[Icemor, BeamPack] = 1;
$ItemMax[Icemor, SuicidePack] = 1;
$ItemMax[Icemor, DemiPack] = 1;
$ItemMax[Icemor, SuperPack1] = 1;
$ItemMax[Icemor, SuperPack2] = 1;
$ItemMax[Icemor, BeamPack] = 1;
$ItemMax[Icemor, THPack] = 1;
$ItemMax[Icemor, ControlPack] = 1;
$ItemMax[Icemor, SolarPack] = 1;
$ItemMax[Icemor, FreezePack] = 1;
$ItemMax[Icemor, PadPack] = 1;
$ItemMax[Icemor, VehPack] = 1;
$ItemMax[Icemor, RepairPack] = 1;
$ItemMax[Icemor, ShieldPack] = 1;
$ItemMax[Icemor, SensorJammerPack] = 1;
$ItemMax[Icemor, MotionSensorPack] = 1;
$ItemMax[Icemor, PulseSensorPack] = 1;
$ItemMax[Icemor, DeployableSensorJammerPack] = 1;
$ItemMax[Icemor, CameraPack] = 1;
$ItemMax[Icemor, TurretPack] = 1;
$ItemMax[Icemor, AmmoPack] = 1;
$ItemMax[Icemor, DeployableInvPack] = 1;
$ItemMax[Icemor, DeployableAmmoPack] = 1;
$ItemMax[Icemor, LaserPack] = 1;
$ItemMax[Icemor, Laser2Pack] = 1;
$ItemMax[Icemor, CDPack] = 1;
$ItemMax[Icemor, CSDPack] = 1;
$ItemMax[Icemor, TLPack] = 1;
$ItemMax[Icemor, PCDPack] = 1;
$ItemMax[Icemor, DTurretPack] = 1;
$ItemMax[Icemor, DEPack] = 1;
$ItemMax[Icemor, ForceFieldPack] = 1;
$ItemMax[Icemor, CTurretPack] = 1;
$ItemMax[Icemor, FTPack] = 1;
$ItemMax[Icemor, TGPack] = 1;
$ItemMax[Icemor, M350Pack] = 1;
$ItemMax[Icemor, PTPack] = 1;
$ItemMax[Icemor, BlastWallPack] = 1;
$ItemMax[Icemor, BunkerPack] = 1;

$MaxWeapons[Icemor] = 25;

$ThrowStrength[Icemor] = 1.0;

PlayerData Icemor
{
	className = "Armor";
	shapeFile = "larmor";
	flameShapeName = "enex";
	shieldShapeName = "shield_large";
	damageSkinData = "armorDamageSkins";
	debrisId = IceDebris;
	shadowDetailMask = 1;
	canCrouch = true;
	visibleToSensor = True;
	mapFilter = 1;
	//mapIcon = "M_player";
	mapIcon = "M_recon";
	maxJetSideForceFactor = 1.5;
	maxJetForwardVelocity = 20;
	minJetEnergy = 1;
	jetForce = 450;
	jetEnergyDrain = 0.5;
	maxDamage = 1.0;
	maxForwardSpeed = 18.0;
	maxBackwardSpeed = 18.0;
	maxSideSpeed = 18.0;
	groundForce = 35 * 13.0 * 2;
	mass = 10.0;
	groundTraction = 4.75;
	maxEnergy = 100;
	drag = 1.0;
	density = 1.5;
	minDamageSpeed = 30;
	damageScale = 0.005;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.5;

	// animation data:
	// animation name, one shot, direction, firstPerson, chaseCam, thirdPerson, signalThread
	
	// movement animations:
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, false, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, false, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, false, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, false, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, false, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, false, false, true, false, 3 };
	animData[14] = { "fall", none, 1, true, true, true, false, 3 };
	animData[15] = { "landing", SoundLandOnGround, 1, false, false, false, false, 3 };
	animData[16] = { "landing", SoundLandOnGround, 1, false, false, false, false, 3 };
	animData[17] = { "tumble loop", none, 1, false, false, false, false, 3 };
	animData[18] = { "tumble end", none, 1, false, false, false, false, 3 };
	//animData[19] = { "jet", none, 1, false, true, true, false, 3 };
	animData[19] = { "fall", none, 1, true, true, true, false, 3 };

	// misc. animations:
	animData[20] = { "PDA access", none, 1, false, false, false, false, 3 };
	animData[21] = { "throw", none, 1, false, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, false, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

	// death animations:
	animData[25] = { "crouch die", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[26] = { "die chest", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[27] = { "die head", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[28] = { "die grab back", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[29] = { "die right side", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[30] = { "die left side", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[31] = { "die leg left", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[32] = { "die leg right", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[33] = { "die blown back", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[34] = { "die spin", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[35] = { "die forward", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[36] = { "die forward kneel", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
	animData[37] = { "die back", SoundM1PlayerDeath, 1, false, false, false, false, 4 };

	// signal moves:
	animData[38] = { "sign over here",  none, 1, false, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, false, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, false, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, false, false, false, true, 1 }; 

	// celebration animations:
	animData[43] = { "celebration 1",none, 1, false, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, false, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, false, false, false, false, 2 };

	// taunt animations:
	animData[46] = { "taunt 1", none, 1, false, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, false, false, false, false, 2 };

	// poses:
	animData[48] = { "pose kneel", none, 1, false, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, false, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, false, false, false, true, 1 };

	jetSound = SoundJetLight;
	
	rFootSounds = {SoundLFootRSoft,SoundLFootRHard,SoundLFootRSoft,
	SoundLFootRHard,SoundLFootRSoft,SoundLFootRSoft,SoundLFootRSoft,
	SoundLFootRHard,SoundLFootRSnow,SoundLFootRSoft,SoundLFootRSoft,
	SoundLFootRSoft,SoundLFootRSoft,SoundLFootRSoft,SoundLFootRSoft}; 

	lFootSounds ={SoundLFootLSoft,SoundLFootLHard,SoundLFootLSoft,
	SoundLFootLHard,SoundLFootLSoft,SoundLFootLSoft,SoundLFootLSoft,
	SoundLFootLHard,SoundLFootLSnow,SoundLFootLSoft,SoundLFootLSoft,
	SoundLFootLSoft,SoundLFootLSoft,SoundLFootLSoft,SoundLFootLSoft};

	footPrints = {0,1};

	boxWidth = 0.5;
	boxDepth = 0.5;
	boxNormalHeight = 2.3;
	boxCrouchHeight = 1.6;

	boxNormalHeadPercentage  = 0.83;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage  = 0.6666;
	boxCrouchTorsoPercentage = 0.3333;

	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};

$ArmorType[Female, IceArmor] = Icemor;
$ArmorType[Male, IceArmor] = Icemor;
$ArmorName[Icemor] = IceArmor;

ItemData IceArmor
{
	heading = "aArmor";
	description = "Ice's Armor";
	className = "Armor";
	shapeFile = "marmor";
	price = 900000;
};

//--------------------------------------

ExplosionData UltraExp
{
   shapeName = "Plasmaex.dts";
   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 0;
   timeZero = 0.450;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };
   shiftPosition = True;
};

GrenadeData Ultra
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = UltraExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = -0.5;
	smokeName              = "Fusionex.dts";
};

ItemImageData UltraPackImage
{
	shapeFile = "force";
	mountPoint = 2; 
	weaponType = 0;
	mountOffset = { 0, 0.1, 0 }; //-  left-right, back-front, up-down
	projectileType = Ultra;
	reloadTime = 0;
	minEnergy = -1;
	maxEnergy = -6;   // Energy/sec for sustained weapons
	firstPerson = false;
};

ItemData UltraPack
{
	description = "GOD 2x";
	shapeFile = "force";
	className = "GOD";
	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = UltraPackImage;
	price = 175;
	hudIcon = "fear";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$ItemMax[larmor, UltraPack] = 0;
$ItemMax[qarmor, UltraPack] = 0;
$ItemMax[sarmor, UltraPack] = 0;
$ItemMax[srarmor, UltraPack] = 0;
$ItemMax[marmor, UltraPack] = 0;
$ItemMax[parmor, UltraPack] = 0;
$ItemMax[tarmor, UltraPack] = 0;
$ItemMax[harmor, UltraPack] = 0;
$ItemMax[lfemale, UltraPack] = 0;
$ItemMax[qfemale, UltraPack] = 0;
$ItemMax[sfemale, UltraPack] = 0;
$ItemMax[srfemale, UltraPack] = 0;
$ItemMax[mfemale, UltraPack] = 0;
$ItemMax[pfemale, UltraPack] = 0;
$ItemMax[psarmor, UltraPack] = 0;
$ItemMax[psfemale, UltraPack] = 0;
$ItemMax[Icemor, UltraPack] = 1;

//--------------------------------------






























































ExplosionData PerfectExp
{
   shapeName = "shockwave_large.dts";
   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 0;
   timeZero = 0.450;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };
   shiftPosition = True;
};

GrenadeData Perfection
{
	bulletShapeName    = "shotgunex.dts";
	explosionTag       = PerfectExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = -0.5;
	smokeName              = "shotgunex.dts";
};

ItemImageData Perfect1Image
{
	shapeFile = "shockwave_large";
	mountPoint = 2; 
	weaponType = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 1.570796327, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	firstPerson = false;
};

ItemData Perfect1
{
	description = "Perfection1";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = Perfect1Image;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData Perfect2Image
{
	shapeFile = "shockwave_large";
	mountPoint = 2; 
	weaponType = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 1.570796327 }; //- X= up-down , Y= roll-left-right , Z= left-right
	firstPerson = false;
};

ItemData Perfect2
{
	description = "Perfection2";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = Perfect2Image;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData PerfectImage
{
	shapeFile = "shockwave_large";
	mountPoint = 2; 
	weaponType = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	projectileType = Perfection;
	reloadTime = 0;
	minEnergy = -10;
	maxEnergy = -20;   // Energy/sec for sustained weapons
	mass = -5.0;
	firstPerson = false;
};

ItemData Perfect
{
	description = "Perfection";
	shapeFile = "force";
	className = "GOD";
	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = PerfectImage;
	price = "Infinity";
	hudIcon = "fear";
	showWeaponBar = true;
	hiliteOnActive = true;
};
$Perfect1Slot = 6;
$Perfect2Slot = 7;
function Perfect::onMount(%player,%item)
{
	Player::mountItem(%player,Perfect1,$Perfect1Slot);
	Player::mountItem(%player,Perfect2,$Perfect2Slot);
}

function Perfect::onUnmount(%player,%item)
{
	Player::UnmountItem(%player,$Perfect1Slot);
	Player::UnmountItem(%player,$Perfect2Slot);
}

$ItemMax[larmor, Perfect] = 0;
$ItemMax[qarmor, Perfect] = 0;
$ItemMax[sarmor, Perfect] = 0;
$ItemMax[srarmor, Perfect] = 0;
$ItemMax[marmor, Perfect] = 0;
$ItemMax[parmor, Perfect] = 0;
$ItemMax[tarmor, Perfect] = 0;
$ItemMax[harmor, Perfect] = 0;
$ItemMax[lfemale, Perfect] = 0;
$ItemMax[qfemale, Perfect] = 0;
$ItemMax[sfemale, Perfect] = 0;
$ItemMax[srfemale, Perfect] = 0;
$ItemMax[mfemale, Perfect] = 0;
$ItemMax[pfemale, Perfect] = 0;
$ItemMax[psarmor, Perfect] = 0;
$ItemMax[psfemale, Perfect] = 0;
$ItemMax[Icemor, Perfect] = 1;
