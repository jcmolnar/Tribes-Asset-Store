// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

//=====================================
// Armor ID Packs (Visual Aid)
//=====================================
// Banshee
ItemImageData BansheePackImage
{
	shapeFile = "logo";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	firstPerson = false;
};

ItemData BansheePack
{
	description = "logo";
	className = "Addon";
	shapeFile = "mortarpack";
	shadowDetailMask = 4;
	imageType = BansheePackImage;
	showWeaponBar = false;
showInventory = false;
};

function BansheePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function BansheePack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function BansheePack::onUnmount(%player,%item)
{
		Player::unmountItem(%player,$WeaponSlot);
}
//=====================================
// Adjuc
ItemImageData AdjucPackImage
{
	shapeFile = "grenadel";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { 0.22, -0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	firstPerson = false;
};

ItemData AdjucPack
{
	description = "Adjuc";
	className = "Addon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = AdjucPackImage;
	showWeaponBar = false;
showInventory = false;
};

function AdjucPackImage::onActivate(%player,%imageSlot){}
function AdjucPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//===============================================

ItemImageData Adjuc2PackImage
{
	shapeFile = "grenadel";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { -0.25, -0.1, 0.20 };
	mountRotation = { -1.57, -2.99, 0 }; 
	firstPerson = false;
};

ItemData Adjuc2Pack
{
	description = "Adjuc2Pack";
	className = "Addon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = Adjuc2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Adjuc2PackImage::onActivate(%player,%imageSlot){}
function Adjuc2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//=====================================
// Executioner
ItemImageData ExecutionerPackImage
{
	shapeFile = "mine";
	weaponType = 0; 
	mountPoint = 2; 
  mountOffset   = { 0.5, 0, 0.5 };
  	mountRotation = { -1.57, -3.14, -3.14};
	firstPerson = false;
};

ItemData ExecutionerPack
{
	description = "M3";
	className = "Addon";
	shapeFile = "mine";
	shadowDetailMask = 4;
	imageType = ExecutionerPackImage;
	showWeaponBar = false;
showInventory = false;
};

function ExecutionerPackImage::onActivate(%player,%imageSlot){}
function ExecutionerPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Executioner2PackImage
{
	shapeFile = "mine";
	weaponType = 0; 
	mountPoint = 2; 
  mountOffset   = { -0.5, 0, 0.5 };
  	mountRotation = { -1.57, -3.14, -3.14};
	firstPerson = false;
};

ItemData Executioner2Pack
{
	description = "M4";
	className = "Addon";
	shapeFile = "mine";
	shadowDetailMask = 4;
	imageType = Executioner2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Executioner2PackImage::onActivate(%player,%imageSlot){}
function Executioner2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//==================================
// Talon

ItemImageData TalonPackImage
{
	shapeFile = "Sniper";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { 0.22, 0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	firstPerson = false;
};

ItemData TalonPack
{
	description = "logo";
	className = "Addon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = TalonPackImage;
	showWeaponBar = false;
showInventory = false;
};

function TalonPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function TalonPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function TalonPack::onUnmount(%player,%item)
{
		Player::unmountItem(%player,$WeaponSlot);
}

//====================
// Predator

ItemImageData Predator1PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { 0.22, -0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	firstPerson = false;
};

ItemData Predator1Pack
{
	description = "Predator1";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Predator1PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Predator1PackImage::onActivate(%player,%imageSlot){}
function Predator1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//===============================================

ItemImageData Predator2PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { -0.25, -0.1, 0.20 };
	mountRotation = { -1.57, -2.99, 0 }; 
	firstPerson = false;
};

ItemData Predator2Pack
{
	description = "Predator2";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Predator2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Predator2PackImage::onActivate(%player,%imageSlot){}
function Predator2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//====================
// Eagle

ItemImageData Eagle1PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 0; 
      mountOffset = { -0.1, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData Eagle1Pack
{
	description = "Eagle1";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Eagle1PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Eagle1PackImage::onActivate(%player,%imageSlot){}
function Eagle1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//===============================================

ItemImageData Eagle2PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 0; 
      mountOffset = { -1.1, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData Eagle2Pack
{
	description = "Eagle2";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Eagle2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Eagle2PackImage::onActivate(%player,%imageSlot){}
function Eagle2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//----------------------------------------------------------------------------
// Hybrid Light Armor
//----------------------------------------------------------------------------
////////////////////////////////////////////////////////
// World Damage Types                                //
//////////////////////////////////////////////////////
$DamageScale[HyLight, $LandingDamageType] 	= 1.0;
$DamageScale[HyLight, $ImpactDamageType] 	= 1.0;
$DamageScale[HyLight, $CrushDamageType] 	= 1.0;
$DamageScale[HyLight, $DebrisDamageType] 	= 1.2;
////////////////////////////////////////////////////////
// Cybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[HyLight, $EnergyDamageType]     	= 1.0;
$DamageScale[HyLight, $FusionDamageType ]    	= 1.3;
$DamageScale[HyLight, $PulseDamageType]      	= 1.0;
$DamageScale[HyLight, $RadiationDamageType]  	= 1.0;
$DamageScale[HyLight, $AntiMatterDamageType] 	= 1.2;
$DamageScale[HyLight, $IONDamageType] 		= 1.2;
////////////////////////////////////////////////////////
// Hybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[HyLight, $BulletDamageType] 	= 1.0;
$DamageScale[HyLight, $FireDamageType] 		= 1.3;
$DamageScale[HyLight, $ExplosionDamageType] 	= 1.3;
$DamageScale[HyLight, $EMPDamageType] 		= 1.0;
$DamageScale[HyLight, $NuclearDamageType] 	= 1.2;
$DamageScale[HyLight, $ThermalDamageType] 	= 1.0;
////////////////////////////////////////////////////////
// Misc/Shared Damage Types                          //
//////////////////////////////////////////////////////
$DamageScale[HyLight, $MineDamageType] 		= 1.0;
$DamageScale[HyLight, $WebDamageType] 		= 1.0;
/////////////////////////////////////////////////////\\
// End                                                \\
///////////////////////////////////////////////////////\\


///////////////////////////////////////////////////
// Cy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[HyLight, FusionRifle] = 0;
$ItemMax[HyLight, PhazerRifle] = 0;
$ItemMax[HyLight, ElectroPlasmCannon] = 0;
///////////////////////////////////////////////////
// Cy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[HyLight, EnergyPistol] = 0;
$ItemMax[HyLight, TriFusionCannon] = 0;
$ItemMax[HyLight, PulseGrenadeLauncher] = 0;
$ItemMax[HyLight, ToxicThrower] = 0;
$ItemMax[HyLight, PulseRocketGun] = 0;
///////////////////////////////////////////////////
// Cy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[HyLight, AntiMatterRocketGun] = 0;
$ItemMax[HyLight, IONCannon] = 0;
$ItemMax[HyLight, PulseGauss] = 0;
$ItemMax[HyLight, ArmageddonCannon] = 0;
$ItemMax[HyLight, EnergyBeamCannon] = 0;
$ItemMax[HyLight, SplitFissionGun] = 0;
$ItemMax[HyLight, ReverseFissionEmitter] = 0;
///////////////////////////////////////////////////
// Hy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[HyLight, Pistol] = 1;
$ItemMax[HyLight, Verminator] = 1;
$ItemMax[HyLight, SniperRifle] = 1;
$ItemMax[HyLight, ShotGun] = 1;
$ItemMax[HyLight, TalonRocketGun] = 1;
///////////////////////////////////////////////////
// Hy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[HyLight, MissileLauncher] = 0;
$ItemMax[HyLight, BlazeThrower] = 0;
$ItemMax[HyLight, BurnerGun] = 0;
$ItemMax[HyLight, MineLauncher] = 0;
$ItemMax[HyLight, RailGun] = 0;
$ItemMax[HyLight, AutoGrenadeGun] = 0;
$ItemMax[HyLight, AssaultRifle] = 0;
///////////////////////////////////////////////////
// Hy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[HyLight, HybridLaser] = 0;
$ItemMax[HyLight, HybridChain] = 0;
$ItemMax[HyLight, HybridRail] = 0;
$ItemMax[HyLight, HybridCannon] = 0;
$ItemMax[HyLight, HybridPlasma] = 0;
$ItemMax[HyLight, HybridMortar] = 0;
$ItemMax[HyLight, HybridRocketLauncher] = 0;
$ItemMax[HyLight, HybridQuadLauncher] = 0;
$ItemMax[HyLight, HybridNuke] = 0;
///////////////////////////////////////////////////
// Grenades/Mines/Beacons/Tools
///////////////////////////////////////////////////
$ItemMax[HyLight, TargetingLaser] = 0;
$ItemMax[HyLight, MineAmmo] = 1;
$ItemMax[HyLight, Grenade] = 1;
$ItemMax[HyLight, Beacon]  = 1;
$ItemMax[HyLight, RepairKit] = 1;
///////////////////////////////////////////////////
// Packs
///////////////////////////////////////////////////
//Hybrid Light
$ItemMax[HyLight, HeatSinkPack] = 1;
$ItemMax[HyLight, JammerPack] = 1;
$ItemMax[HyLight, MedicPack] = 1;
$ItemMax[HyLight, TickPack] = 1;
//Hybrid Medium
$ItemMax[HyLight, FlightPack] = 0;
$ItemMax[HyLight, StealthPack] = 0;
$ItemMax[HyLight, RepairPack] = 0;
$ItemMax[HyLight, ClaymorePack] = 0;
//Hybrid Heavy
$ItemMax[HyLight, ThrustPack] = 0;
$ItemMax[HyLight, ShieldPack] = 0;
$ItemMax[HyLight, HealthPack] = 0;
$ItemMax[HyLight, MechPack] = 0;
//Cybrid Light
$ItemMax[HyLight, VanishPack] = 0;
///////////////////////////////////////////////////
// Deployables
///////////////////////////////////////////////////
$ItemMax[HyLight, MotionSensorPack] = 1;
$ItemMax[HyLight, PulseSensorPack] = 1;
$ItemMax[HyLight, DeployableSensorJammerPack] = 1;
$ItemMax[HyLight, CameraPack] = 1;
$ItemMax[HyLight, TurretPack] = 1;
$ItemMax[HyLight, DeployableInvPack] = 1;
$ItemMax[HyLight, DeployableAmmoPack] = 1;
$ItemMax[HyLight, ElectricWeb] = 1;

$MaxWeapons[HyLight] = 5;

//----------------------------------------------------------------------------
// Medium Armor
//----------------------------------------------------------------------------
////////////////////////////////////////////////////////
// World Damage Types                                //
//////////////////////////////////////////////////////
$DamageScale[HyMedium, $LandingDamageType] 	= 1.0;
$DamageScale[HyMedium, $ImpactDamageType] 	= 1.0;
$DamageScale[HyMedium, $CrushDamageType] 	= 1.0;
$DamageScale[HyMedium, $DebrisDamageType] 	= 1.2;
////////////////////////////////////////////////////////
// Cybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[HyMedium, $EnergyDamageType]     	= 1.0;
$DamageScale[HyMedium, $FusionDamageType ]    	= 1.3;
$DamageScale[HyMedium, $PulseDamageType]      	= 1.0;
$DamageScale[HyMedium, $RadiationDamageType]  	= 1.0;
$DamageScale[HyMedium, $AntiMatterDamageType] 	= 1.2;
$DamageScale[HyMedium, $IONDamageType] 		= 1.2;
////////////////////////////////////////////////////////
// Hybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[HyMedium, $BulletDamageType] 	= 1.0;
$DamageScale[HyMedium, $FireDamageType] 	= 1.3;
$DamageScale[HyMedium, $ExplosionDamageType] 	= 1.3;
$DamageScale[HyMedium, $EMPDamageType] 		= 1.0;
$DamageScale[HyMedium, $NuclearDamageType] 	= 1.2;
$DamageScale[HyMedium, $ThermalDamageType] 	= 1.0;
////////////////////////////////////////////////////////
// Misc/Shared Damage Types                          //
//////////////////////////////////////////////////////
$DamageScale[HyMedium, $MineDamageType] 	= 1.0;
$DamageScale[HyMedium, $WebDamageType] 		= 1.0;
/////////////////////////////////////////////////////\\
// End                                                \\
///////////////////////////////////////////////////////\\


///////////////////////////////////////////////////
// Cy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[HyMedium, FusionRifle] = 0;
$ItemMax[HyMedium, PhazerRifle] = 0;
$ItemMax[HyMedium, ElectroPlasmCannon] = 0;
///////////////////////////////////////////////////
// Cy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[HyMedium, EnergyPistol] = 0;
$ItemMax[HyMedium, TriFusionCannon] = 0;
$ItemMax[HyMedium, PulseGrenadeLauncher] = 0;
$ItemMax[HyMedium, ToxicThrower] = 0;
$ItemMax[HyMedium, PulseRocketGun] = 0;
///////////////////////////////////////////////////
// Cy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[HyMedium, AntiMatterRocketGun] = 0;
$ItemMax[HyMedium, IONCannon] = 0;
$ItemMax[HyMedium, PulseGauss] = 0;
$ItemMax[HyMedium, ArmageddonCannon] = 0;
$ItemMax[HyMedium, EnergyBeamCannon] = 0;
$ItemMax[HyMedium, SplitFissionGun] = 0;
$ItemMax[HyMedium, ReverseFissionEmitter] = 0;
///////////////////////////////////////////////////
// Hy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[HyMedium, Pistol] = 0;
$ItemMax[HyMedium, Verminator] = 0;
$ItemMax[HyMedium, SniperRifle] = 0;
$ItemMax[HyMedium, ShotGun] = 0;
$ItemMax[HyMedium, TalonRocketGun] = 0;
///////////////////////////////////////////////////
// Hy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[HyMedium, MissileLauncher] = 1;
$ItemMax[HyMedium, BlazeThrower] = 1;
$ItemMax[HyMedium, BurnerGun] = 1;
$ItemMax[HyMedium, MineLauncher] = 1;
$ItemMax[HyMedium, RailGun] = 1;
$ItemMax[HyMedium, AutoGrenadeGun] = 1;
$ItemMax[HyMedium, AssaultRifle] = 1;
///////////////////////////////////////////////////
// Hy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[HyMedium, HybridLaser] = 0;
$ItemMax[HyMedium, HybridChain] = 0;
$ItemMax[HyMedium, HybridRail] = 0;
$ItemMax[HyMedium, HybridCannon] = 0;
$ItemMax[HyMedium, HybridPlasma] = 0;
$ItemMax[HyMedium, HybridMortar] = 0;
$ItemMax[HyMedium, HybridRocketLauncher] = 0;
$ItemMax[HyMedium, HybridQuadLauncher] = 0;
$ItemMax[HyMedium, HybridNuke] = 0;
///////////////////////////////////////////////////
// Grenades/Mines/Beacons/Tools
///////////////////////////////////////////////////
$ItemMax[HyMedium, TargetingLaser] = 0;
$ItemMax[HyMedium, MineAmmo] = 1;
$ItemMax[HyMedium, Grenade] = 1;
$ItemMax[HyMedium, Beacon] = 1;
$ItemMax[HyMedium, RepairKit] = 1;
///////////////////////////////////////////////////
// Packs
///////////////////////////////////////////////////
//Hybrid Light
$ItemMax[HyMedium, HeatSinkPack] = 0;
$ItemMax[HyMedium, JammerPack] = 0;
$ItemMax[HyMedium, MedicPack] = 0;
$ItemMax[HyMedium, TickPack] = 0;
//Hybrid Medium
$ItemMax[HyMedium, FlightPack] = 1;
$ItemMax[HyMedium, StealthPack] = 1;
$ItemMax[HyMedium, RepairPack] = 1;
$ItemMax[HyMedium, ClaymorePack] = 1;
//Hybrid Heavy
$ItemMax[HyMedium, ThrustPack] = 0;
$ItemMax[HyMedium, ShieldPack] = 0;
$ItemMax[HyMedium, HealthPack] = 0;
$ItemMax[HyMedium, MechPack] = 0;
//Cybrid Light
$ItemMax[HyMedium, VanishPack] = 0;
///////////////////////////////////////////////////
// Deployables
///////////////////////////////////////////////////
$ItemMax[HyMedium, MotionSensorPack] = 1;
$ItemMax[HyMedium, PulseSensorPack] = 1;
$ItemMax[HyMedium, DeployableSensorJammerPack] = 1;
$ItemMax[HyMedium, CameraPack] = 1;
$ItemMax[HyMedium, TurretPack] = 1;
$ItemMax[HyMedium, DeployableInvPack] = 1;
$ItemMax[HyMedium, DeployableAmmoPack] = 1;
$ItemMax[HyMedium, ElectricWeb] = 1;

$MaxWeapons[HyMedium] = 7;

//----------------------------------------------------------------------------
// Hybrid Heavy Armor
//----------------------------------------------------------------------------
////////////////////////////////////////////////////////
// World Damage Types                                //
//////////////////////////////////////////////////////
$DamageScale[HyHeavy, $LandingDamageType] 	= 1.0;
$DamageScale[HyHeavy, $ImpactDamageType] 	= 1.0;
$DamageScale[HyHeavy, $CrushDamageType] 	= 1.0;
$DamageScale[HyHeavy, $DebrisDamageType] 	= 1.2;
////////////////////////////////////////////////////////
// Cybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[HyHeavy, $EnergyDamageType]     	= 1.0;
$DamageScale[HyHeavy, $FusionDamageType ]    	= 1.3;
$DamageScale[HyHeavy, $PulseDamageType]      	= 1.0;
$DamageScale[HyHeavy, $RadiationDamageType]  	= 1.0;
$DamageScale[HyHeavy, $AntiMatterDamageType] 	= 1.2;
$DamageScale[HyHeavy, $IONDamageType] 		= 1.2;
////////////////////////////////////////////////////////
// Hybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[HyHeavy, $BulletDamageType] 	= 1.0;
$DamageScale[HyHeavy, $FireDamageType] 		= 1.3;
$DamageScale[HyHeavy, $ExplosionDamageType] 	= 1.3;
$DamageScale[HyHeavy, $EMPDamageType] 		= 1.0;
$DamageScale[HyHeavy, $NuclearDamageType] 	= 1.2;
$DamageScale[HyHeavy, $ThermalDamageType] 	= 1.0;
////////////////////////////////////////////////////////
// Misc/Shared Damage Types                          //
//////////////////////////////////////////////////////
$DamageScale[HyHeavy, $MineDamageType] 		= 1.0;
$DamageScale[HyHeavy, $WebDamageType] 		= 1.0;
/////////////////////////////////////////////////////\\
// End                                                \\
///////////////////////////////////////////////////////\\


///////////////////////////////////////////////////
// Cy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[HyHeavy, FusionRifle] = 0;
$ItemMax[HyHeavy, PhazerRifle] = 0;
$ItemMax[HyHeavy, ElectroPlasmCannon] = 0;
///////////////////////////////////////////////////
// Cy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[HyHeavy, EnergyPistol] = 0;
$ItemMax[HyHeavy, TriFusionCannon] = 0;
$ItemMax[HyHeavy, PulseGrenadeLauncher] = 0;
$ItemMax[HyHeavy, ToxicThrower] = 0;
$ItemMax[HyHeavy, PulseRocketGun] = 0;
///////////////////////////////////////////////////
// Cy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[HyHeavy, AntiMatterRocketGun] = 0;
$ItemMax[HyHeavy, IONCannon] = 0;
$ItemMax[HyHeavy, PulseGauss] = 0;
$ItemMax[HyHeavy, ArmageddonCannon] = 0;
$ItemMax[HyHeavy, EnergyBeamCannon] = 0;
$ItemMax[HyHeavy, SplitFissionGun] = 0;
$ItemMax[HyHeavy, ReverseFissionEmitter] = 0;
///////////////////////////////////////////////////
// Hy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[HyHeavy, Pistol] = 0;
$ItemMax[HyHeavy, Verminator] = 0;
$ItemMax[HyHeavy, SniperRifle] = 0;
$ItemMax[HyHeavy, ShotGun] = 0;
$ItemMax[HyHeavy, TalonRocketGun] = 0;
///////////////////////////////////////////////////
// Hy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[HyHeavy, MissileLauncher] = 0;
$ItemMax[HyHeavy, BlazeThrower] = 0;
$ItemMax[HyHeavy, BurnerGun] = 0;
$ItemMax[HyHeavy, MineLauncher] = 0;
$ItemMax[HyHeavy, RailGun] = 0;
$ItemMax[HyHeavy, AutoGrenadeGun] = 0;
$ItemMax[HyHeavy, AssaultRifle] = 0;
///////////////////////////////////////////////////
// Hy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[HyHeavy, HybridLaser] = 1;
$ItemMax[HyHeavy, HybridChain] = 1;
$ItemMax[HyHeavy, HybridRail] = 1;
$ItemMax[HyHeavy, HybridCannon] = 1;
$ItemMax[HyHeavy, HybridPlasma] = 1;
$ItemMax[HyHeavy, HybridMortar] = 1;
$ItemMax[HyHeavy, HybridRocketLauncher] = 1;
$ItemMax[HyHeavy, HybridQuadLauncher] = 1;
$ItemMax[HyHeavy, HybridNuke] = 1;
///////////////////////////////////////////////////
// Grenades/Mines/Beacons/Tools
///////////////////////////////////////////////////
$ItemMax[HyHeavy, TargetingLaser] = 0;
$ItemMax[HyHeavy, MineAmmo] = 1;
$ItemMax[HyHeavy, Grenade] = 1;
$ItemMax[HyHeavy, Beacon] = 1;
$ItemMax[HyHeavy, RepairKit] = 1;
///////////////////////////////////////////////////
// Packs
///////////////////////////////////////////////////
//Hybrid Light
$ItemMax[HyHeavy, HeatSinkPack] = 0;
$ItemMax[HyHeavy, JammerPack] = 0;
$ItemMax[HyHeavy, MedicPack] = 0;
$ItemMax[HyHeavy, TickPack] = 0;
//Hybrid Medium
$ItemMax[HyHeavy, FlightPack] = 0;
$ItemMax[HyHeavy, StealthPack] = 0;
$ItemMax[HyHeavy, RepairPack] = 0;
$ItemMax[HyHeavy, ClaymorePack] = 0;
//Hybrid Heavy
$ItemMax[HyHeavy, ThrustPack] = 1;
$ItemMax[HyHeavy, ShieldPack] = 1;
$ItemMax[HyHeavy, HealthPack] = 1;
$ItemMax[HyHeavy, MechPack] = 1;
//Cybrid Light
$ItemMax[HyHeavy, VanishPack] = 0;
///////////////////////////////////////////////////
// Deployables
///////////////////////////////////////////////////
$ItemMax[HyHeavy, MotionSensorPack] = 1;
$ItemMax[HyHeavy, PulseSensorPack] = 1;
$ItemMax[HyHeavy, DeployableSensorJammerPack] = 1;
$ItemMax[HyHeavy, CameraPack] = 1;
$ItemMax[HyHeavy, TurretPack] = 1;
$ItemMax[HyHeavy, DeployableInvPack] = 1;
$ItemMax[HyHeavy, DeployableAmmoPack] = 1;
$ItemMax[HyHeavy, ElectricWeb] = 1;

$MaxWeapons[HyHeavy] = 9;

//----------------------------------------------------------------------------
// light Cybrid Armor
//----------------------------------------------------------------------------
////////////////////////////////////////////////////////
// World Damage Types                                //
//////////////////////////////////////////////////////
$DamageScale[CyLight, $LandingDamageType] 	= 1.0;
$DamageScale[CyLight, $ImpactDamageType] 	= 1.0;
$DamageScale[CyLight, $CrushDamageType] 	= 1.0;
$DamageScale[CyLight, $DebrisDamageType] 	= 1.2;
////////////////////////////////////////////////////////
// Cybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[CyLight, $EnergyDamageType]     	= 1.0;
$DamageScale[CyLight, $FusionDamageType ]    	= 1.3;
$DamageScale[CyLight, $PulseDamageType]      	= 1.0;
$DamageScale[CyLight, $RadiationDamageType]  	= 1.0;
$DamageScale[CyLight, $AntiMatterDamageType] 	= 1.2;
$DamageScale[CyLight, $IONDamageType] 		= 1.2;
////////////////////////////////////////////////////////
// Hybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[CyLight, $BulletDamageType] 	= 1.0;
$DamageScale[CyLight, $FireDamageType] 		= 1.3;
$DamageScale[CyLight, $ExplosionDamageType] 	= 1.3;
$DamageScale[CyLight, $EMPDamageType] 		= 1.0;
$DamageScale[CyLight, $NuclearDamageType] 	= 1.2;
$DamageScale[CyLight, $ThermalDamageType] 	= 1.0;
////////////////////////////////////////////////////////
// Misc/Shared Damage Types                          //
//////////////////////////////////////////////////////
$DamageScale[CyLight, $MineDamageType] 		= 1.0;
$DamageScale[CyLight, $WebDamageType] 		= 1.0;
/////////////////////////////////////////////////////\\
// End                                                \\
///////////////////////////////////////////////////////\\


///////////////////////////////////////////////////
// Cy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[CyLight, FusionRifle] = 1;
$ItemMax[CyLight, PhazerRifle] = 1;
$ItemMax[CyLight, ElectroPlasmCannon] = 1;
///////////////////////////////////////////////////
// Cy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[CyLight, EnergyPistol] = 0;
$ItemMax[CyLight, TriFusionCannon] = 0;
$ItemMax[CyLight, PulseGrenadeLauncher] = 0;
$ItemMax[CyLight, ToxicThrower] = 0;
$ItemMax[CyLight, PulseRocketGun] = 0;
///////////////////////////////////////////////////
// Cy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[CyLight, AntiMatterRocketGun] = 0;
$ItemMax[CyLight, IONCannon] = 0;
$ItemMax[CyLight, PulseGauss] = 0;
$ItemMax[CyLight, ArmageddonCannon] = 0;
$ItemMax[CyLight, EnergyBeamCannon] = 0;
$ItemMax[CyLight, SplitFissionGun] = 0;
$ItemMax[CyLight, ReverseFissionEmitter] = 0;
///////////////////////////////////////////////////
// Hy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[CyLight, Pistol] = 0;
$ItemMax[CyLight, Verminator] = 0;
$ItemMax[CyLight, SniperRifle] = 0;
$ItemMax[CyLight, ShotGun] = 0;
$ItemMax[CyLight, TalonRocketGun] = 0;
///////////////////////////////////////////////////
// Hy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[CyLight, MissileLauncher] = 0;
$ItemMax[CyLight, BlazeThrower] = 0;
$ItemMax[CyLight, BurnerGun] = 0;
$ItemMax[CyLight, MineLauncher] = 0;
$ItemMax[CyLight, RailGun] = 0;
$ItemMax[CyLight, AutoGrenadeGun] = 0;
$ItemMax[CyLight, AssaultRifle] = 0;
///////////////////////////////////////////////////
// Hy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[CyLight, HybridLaser] = 0;
$ItemMax[CyLight, HybridChain] = 0;
$ItemMax[CyLight, HybridRail] = 0;
$ItemMax[CyLight, HybridCannon] = 0;
$ItemMax[CyLight, HybridPlasma] = 0;
$ItemMax[CyLight, HybridMortar] = 0;
$ItemMax[CyLight, HybridRocketLauncher] = 0;
$ItemMax[CyLight, HybridQuadLauncher] = 0;
$ItemMax[CyLight, HybridNuke] = 0;
///////////////////////////////////////////////////
// Grenades/Mines/Beacons/Tools
///////////////////////////////////////////////////
$ItemMax[CyLight, TargetingLaser] = 0;
$ItemMax[CyLight, MineAmmo] = 3;
$ItemMax[CyLight, Grenade] = 3;
$ItemMax[CyLight, Beacon] = 3;
$ItemMax[CyLight, RepairKit] = 1;
$ItemMax[CyLight, VortexGrenade] = 3;
$ItemMax[CyLight, FusionGrenade] = 3;
///////////////////////////////////////////////////
// Packs
///////////////////////////////////////////////////
//Hybrid Light
$ItemMax[CyLight, HeatSinkPack] = 0;
$ItemMax[CyLight, JammerPack] = 0;
$ItemMax[CyLight, MedicPack] = 0;
$ItemMax[CyLight, TickPack] = 0;
//Hybrid Medium
$ItemMax[CyLight, FlightPack] = 0;
$ItemMax[CyLight, StealthPack] = 0;
$ItemMax[CyLight, RepairPack] = 0;
$ItemMax[CyLight, ClaymorePack] = 0;
//Hybrid Heavy
$ItemMax[CyLight, ThrustPack] = 0;
$ItemMax[CyLight, ShieldPack] = 0;
$ItemMax[CyLight, HealthPack] = 0;
$ItemMax[CyLight, MechPack] = 0;
//Cybrid Light
$ItemMax[CyLight, VanishPack] = 1;
///////////////////////////////////////////////////
// Deployables
///////////////////////////////////////////////////
$ItemMax[CyLight, MotionSensorPack] = 1;
$ItemMax[CyLight, PulseSensorPack] = 1;
$ItemMax[CyLight, DeployableSensorJammerPack] = 1;
$ItemMax[CyLight, CameraPack] = 1;
$ItemMax[CyLight, TurretPack] = 1;
$ItemMax[CyLight, DeployableInvPack] = 1;
$ItemMax[CyLight, DeployableAmmoPack] = 1;
$ItemMax[CyLight, ElectricWeb] = 1;

$MaxWeapons[CyLight] = 3;

//----------------------------------------------------------------------------
// Medium Cybrid Armor
//----------------------------------------------------------------------------
////////////////////////////////////////////////////////
// World Damage Types                                //
//////////////////////////////////////////////////////
$DamageScale[CyMedium, $LandingDamageType] 	= 1.0;
$DamageScale[CyMedium, $ImpactDamageType] 	= 1.0;
$DamageScale[CyMedium, $CrushDamageType] 	= 1.0;
$DamageScale[CyMedium, $DebrisDamageType] 	= 1.2;
////////////////////////////////////////////////////////
// Cybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[CyMedium, $EnergyDamageType]     	= 1.0;
$DamageScale[CyMedium, $FusionDamageType ]    	= 1.3;
$DamageScale[CyMedium, $PulseDamageType]      	= 1.0;
$DamageScale[CyMedium, $RadiationDamageType]  	= 1.0;
$DamageScale[CyMedium, $AntiMatterDamageType] 	= 1.2;
$DamageScale[CyMedium, $IONDamageType] 		= 1.2;
////////////////////////////////////////////////////////
// Hybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[CyMedium, $BulletDamageType] 	= 1.0;
$DamageScale[CyMedium, $FireDamageType] 	= 1.3;
$DamageScale[CyMedium, $ExplosionDamageType] 	= 1.3;
$DamageScale[CyMedium, $EMPDamageType] 		= 1.0;
$DamageScale[CyMedium, $NuclearDamageType] 	= 1.2;
$DamageScale[CyMedium, $ThermalDamageType] 	= 1.0;
////////////////////////////////////////////////////////
// Misc/Shared Damage Types                          //
//////////////////////////////////////////////////////
$DamageScale[CyMedium, $MineDamageType] 	= 1.0;
$DamageScale[CyMedium, $WebDamageType] 		= 1.0;
/////////////////////////////////////////////////////\\
// End                                                \\
///////////////////////////////////////////////////////\\


///////////////////////////////////////////////////
// Cy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[CyMedium, FusionRifle] = 0;
$ItemMax[CyMedium, PhazerRifle] = 0;
$ItemMax[CyMedium, ElectroPlasmCannon] = 0;
///////////////////////////////////////////////////
// Cy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[CyMedium, EnergyPistol] = 1;
$ItemMax[CyMedium, TriFusionCannon] = 1;
$ItemMax[CyMedium, PulseGrenadeLauncher] = 1;
$ItemMax[CyMedium, ToxicThrower] = 1;
$ItemMax[CyMedium, PulseRocketGun] = 1;
///////////////////////////////////////////////////
// Cy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[CyMedium, AntiMatterRocketGun] = 0;
$ItemMax[CyMedium, IONCannon] = 0;
$ItemMax[CyMedium, PulseGauss] = 0;
$ItemMax[CyMedium, ArmageddonCannon] = 0;
$ItemMax[CyMedium, EnergyBeamCannon] = 0;
$ItemMax[CyMedium, SplitFissionGun] = 0;
$ItemMax[CyMedium, ReverseFissionEmitter] = 0;
///////////////////////////////////////////////////
// Hy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[CyMedium, Pistol] = 0;
$ItemMax[CyMedium, Verminator] = 0;
$ItemMax[CyMedium, SniperRifle] = 0;
$ItemMax[CyMedium, ShotGun] = 0;
$ItemMax[CyMedium, TalonRocketGun] = 0;
///////////////////////////////////////////////////
// Hy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[CyMedium, MissileLauncher] = 0;
$ItemMax[CyMedium, BlazeThrower] = 0;
$ItemMax[CyMedium, BurnerGun] = 0;
$ItemMax[CyMedium, MineLauncher] = 0;
$ItemMax[CyMedium, Railgun] = 0;
$ItemMax[CyMedium, AutoGrenadeGun] = 0;
$ItemMax[CyMedium, AssaultRifle] = 0;
///////////////////////////////////////////////////
// Hy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[CyMedium, HybridLaser] = 0;
$ItemMax[CyMedium, HybridChain] = 0;
$ItemMax[CyMedium, HybridRail] = 0;
$ItemMax[CyMedium, HybridCannon] = 0;
$ItemMax[CyMedium, HybridPlasma] = 0;
$ItemMax[CyMedium, HybridMortar] = 0;
$ItemMax[CyMedium, HybridRocketLauncher] = 0;
$ItemMax[CyMedium, HybridQuadLauncher] = 0;
$ItemMax[CyMedium, HybridNuke] = 0;
///////////////////////////////////////////////////
// Grenades/Mines/Beacons/Tools
///////////////////////////////////////////////////
$ItemMax[CyMedium, TargetingLaser] = 0;
$ItemMax[CyMedium, MineAmmo] = 1;
$ItemMax[CyMedium, Grenade] = 1;
$ItemMax[CyMedium, Beacon] = 1;
$ItemMax[CyMedium, RepairKit] = 1;
$ItemMax[CyMedium, PulseGrenade] = 5;
$ItemMax[CyMedium, RadiationGrenade] = 5;
///////////////////////////////////////////////////
// Packs
///////////////////////////////////////////////////
//Hybrid Light
$ItemMax[CyMedium, HeatSinkPack] = 0;
$ItemMax[CyMedium, JammerPack] = 0;
$ItemMax[CyMedium, MedicPack] = 0;
$ItemMax[CyMedium, TickPack] = 0;
//Hybrid Medium
$ItemMax[CyMedium, FlightPack] = 0;
$ItemMax[CyMedium, StealthPack] = 0;
$ItemMax[CyMedium, RepairPack] = 0;
$ItemMax[CyMedium, ClaymorePack] = 0;
//Hybrid Heavy
$ItemMax[CyMedium, ThrustPack] = 0;
$ItemMax[CyMedium, ShieldPack] = 0;
$ItemMax[CyMedium, HealthPack] = 0;
$ItemMax[CyMedium, MechPack] = 0;
//Cybrid Light
$ItemMax[CyMedium, VanishPack] = 0;
///////////////////////////////////////////////////
// Deployables
///////////////////////////////////////////////////
$ItemMax[CyMedium, MotionSensorPack] = 1;
$ItemMax[CyMedium, PulseSensorPack] = 1;
$ItemMax[CyMedium, DeployableSensorJammerPack] = 1;
$ItemMax[CyMedium, CameraPack] = 1;
$ItemMax[CyMedium, TurretPack] = 1;
$ItemMax[CyMedium, DeployableInvPack] = 1;
$ItemMax[CyMedium, DeployableAmmoPack] = 1;
$ItemMax[CyMedium, ElectricWeb] = 1;

$MaxWeapons[CyMedium] = 5;

//----------------------------------------------------------------------------
// Cybrid Heavy Armor
//----------------------------------------------------------------------------
////////////////////////////////////////////////////////
// World Damage Types                                //
//////////////////////////////////////////////////////
$DamageScale[CyHeavy, $LandingDamageType] 	= 1.0;
$DamageScale[CyHeavy, $ImpactDamageType] 	= 1.0;
$DamageScale[CyHeavy, $CrushDamageType] 	= 1.0;
$DamageScale[CyHeavy, $DebrisDamageType] 	= 1.2;
////////////////////////////////////////////////////////
// Cybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[CyHeavy, $EnergyDamageType]     	= 1.0;
$DamageScale[CyHeavy, $FusionDamageType ]    	= 1.3;
$DamageScale[CyHeavy, $PulseDamageType]      	= 1.0;
$DamageScale[CyHeavy, $RadiationDamageType]  	= 1.0;
$DamageScale[CyHeavy, $AntiMatterDamageType] 	= 1.2;
$DamageScale[CyHeavy, $IONDamageType] 		= 1.2;
////////////////////////////////////////////////////////
// Hybrid Damage Types                               //
//////////////////////////////////////////////////////
$DamageScale[CyHeavy, $BulletDamageType] 	= 1.0;
$DamageScale[CyHeavy, $FireDamageType] 		= 1.3;
$DamageScale[CyHeavy, $ExplosionDamageType] 	= 1.3;
$DamageScale[CyHeavy, $EMPDamageType] 		= 1.0;
$DamageScale[CyHeavy, $NuclearDamageType] 	= 1.2;
$DamageScale[CyHeavy, $ThermalDamageType] 	= 1.0;
////////////////////////////////////////////////////////
// Misc/Shared Damage Types                          //
//////////////////////////////////////////////////////
$DamageScale[CyHeavy, $MineDamageType] 		= 1.0;
$DamageScale[CyHeavy, $WebDamageType] 		= 1.0;
/////////////////////////////////////////////////////\\
// End                                                \\
///////////////////////////////////////////////////////\\


///////////////////////////////////////////////////
// Cy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[CyHeavy, FusionRifle] = 0;
$ItemMax[CyHeavy, PhazerRifle] = 0;
$ItemMax[CyHeavy, ElectroPlasmCannon] = 0;
///////////////////////////////////////////////////
// Cy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[CyHeavy, EnergyPistol] = 0;
$ItemMax[CyHeavy, TriFusionCannon] = 0;
$ItemMax[CyHeavy, PulseGrenadeLauncher] = 0;
$ItemMax[CyHeavy, ToxicThrower] = 0;
$ItemMax[CyHeavy, PulseRocketGun] = 0;
///////////////////////////////////////////////////
// Cy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[CyHeavy, AntiMatterRocketGun] = 1;
$ItemMax[CyHeavy, IONCannon] = 1;
$ItemMax[CyHeavy, PulseGauss] = 1;
$ItemMax[CyHeavy, ArmageddonCannon] = 1;
$ItemMax[CyHeavy, EnergyBeamCannon] = 1;
$ItemMax[CyHeavy, SplitFissionGun] = 1;
$ItemMax[CyHeavy, ReverseFissionEmitter] = 1;
///////////////////////////////////////////////////
// Hy-Light Weapons
///////////////////////////////////////////////////
$ItemMax[CyHeavy, Pistol] = 0;
$ItemMax[CyHeavy, Verminator] = 0;
$ItemMax[CyHeavy, SniperRifle] = 0;
$ItemMax[CyHeavy, ShotGun] = 0;
$ItemMax[CyHeavy, TalonRocketGun] = 0;
///////////////////////////////////////////////////
// Hy-Medium Weapons
///////////////////////////////////////////////////
$ItemMax[CyHeavy, MissileLauncher] = 0;
$ItemMax[CyHeavy, BlazeThrower] = 0;
$ItemMax[CyHeavy, BurnerGun] = 0;
$ItemMax[CyHeavy, MineLauncher] = 0;
$ItemMax[CyHeavy, RailGun] = 0;
$ItemMax[CyHeavy, AutoGrenadeGun] = 0;
$ItemMax[CyHeavy, AssaultRifle] = 0;
///////////////////////////////////////////////////
// Hy-Heavy Weapons
///////////////////////////////////////////////////
$ItemMax[CyHeavy, HybridLaser] = 0;
$ItemMax[CyHeavy, HybridChain] = 0;
$ItemMax[CyHeavy, HybridRail] = 0;
$ItemMax[CyHeavy, HybridCannon] = 0;
$ItemMax[CyHeavy, HybridPlasma] = 0;
$ItemMax[CyHeavy, HybridMortar] = 0;
$ItemMax[CyHeavy, HybridRocketLauncher] = 0;
$ItemMax[CyHeavy, HybridQuadLauncher] = 0;
$ItemMax[CyHeavy, HybridNuke] = 0;
///////////////////////////////////////////////////
// Grenades/Mines/Beacons/Tools
///////////////////////////////////////////////////
$ItemMax[CyHeavy, TargetingLaser] = 0;
$ItemMax[CyHeavy, MineAmmo] = 1;
$ItemMax[CyHeavy, Grenade] = 1;
$ItemMax[CyHeavy, Beacon] = 1;
$ItemMax[CyHeavy, RailGrenade] = 4;
$ItemMax[CyHeavy, RepairKit] = 1;
///////////////////////////////////////////////////
// Packs
///////////////////////////////////////////////////
//Hybrid Light
$ItemMax[CyHeavy, HeatSinkPack] = 0;
$ItemMax[CyHeavy, JammerPack] = 0;
$ItemMax[CyHeavy, MedicPack] = 0;
$ItemMax[CyHeavy, TickPack] = 0;
//Hybrid Medium
$ItemMax[CyHeavy, FlightPack] = 0;
$ItemMax[CyHeavy, StealthPack] = 0;
$ItemMax[CyHeavy, RepairPack] = 0;
$ItemMax[CyHeavy, ClaymorePack] = 0;
//Hybrid Heavy
$ItemMax[CyHeavy, ThrustPack] = 0;
$ItemMax[CyHeavy, ShieldPack] = 0;
$ItemMax[CyHeavy, HealthPack] = 0;
$ItemMax[CyHeavy, MechPack] = 0;
//Cybrid Light
$ItemMax[CyHeavy, VanishPack] = 0;
///////////////////////////////////////////////////
// Deployables
///////////////////////////////////////////////////
$ItemMax[CyHeavy, MotionSensorPack] = 1;
$ItemMax[CyHeavy, PulseSensorPack] = 1;
$ItemMax[CyHeavy, DeployableSensorJammerPack] = 1;
$ItemMax[CyHeavy, CameraPack] = 1;
$ItemMax[CyHeavy, TurretPack] = 1;
$ItemMax[CyHeavy, DeployableInvPack] = 1;
$ItemMax[CyHeavy, DeployableAmmoPack] = 1;
$ItemMax[CyHeavy, ElectricWeb] = 1;

$MaxWeapons[CyHeavy] = 7;

//------------------------------------------------------------------
// Damage Skin armor data:
//------------------------------------------------------------------

DamageSkinData armorDamageSkins
{
   bmpName[0] = "dskin1_armor";
   bmpName[1] = "dskin2_armor";
   bmpName[2] = "dskin3_armor";
   bmpName[3] = "dskin4_armor";
   bmpName[4] = "dskin5_armor";
   bmpName[5] = "dskin6_armor";
   bmpName[6] = "dskin7_armor";
   bmpName[7] = "dskin8_armor";
   bmpName[8] = "dskin9_armor";
   bmpName[9] = "dskin10_armor";
};

//------------------------------------------------------------------
// Hybrid light armor data:
//------------------------------------------------------------------
PlayerData HyLight
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "ChainSpk";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape = true;

   visibleToSensor = True;
  	mapFilter = 1;
  	mapIcon = "M_player";
     canCrouch = true;
  
     maxJetSideForceFactor = 0.8;
     maxJetForwardVelocity = 22;
     minJetEnergy = 1;
     jetForce = 236;
     jetEnergyDrain = 1.0;
  
  	maxDamage = 0.7;
     maxForwardSpeed = 15; 
     maxBackwardSpeed = 10;
     maxSideSpeed = 20; 
     groundForce = 40 * 9.0;
     mass = 9.0;
     groundTraction = 3.0;
  	maxEnergy = 250;
     drag = 1.0;
     density = 1.2;
  
  	minDamageSpeed = 35;
  	damageScale = 0.005;
  
     jumpImpulse = 75;
     jumpSurfaceMinDot = 0.2;
  
     // animation data:
     // animation name, one shot, direction
  	// firstPerson, chaseCam, thirdPerson, signalThread
     // movement animations:
     animData[0]  = { "root", none, 1, true, true, true, false, 0 };
     animData[1]  = { "run", none, 1, true, false, true, false, 3 };
     animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
     animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
     animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
     animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
     animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
     animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
     animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
     animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
     animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
     animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
     animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
     animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
     animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
     animData[19] = { "jet", none, 1, true, true, true, false, 3 };
  
     // misc. animations:
     animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
     animData[21] = { "throw", none, 1, true, false, false, false, 3 };
     animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
     animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
     animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
     
     // death animations:
     animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  
     // signal moves:
  	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
     animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
     animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
     animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
     animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
  
  
      // celebration animations:
     animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
     animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
     animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
   
      // taunt animations:
  	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
  	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
   
      // poses:
  	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
  	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
  
  	// Bonus wave
     animData[50] = { "wave", none, 1, true, false, false, true, 1 };
  
     jetSound = SoundJetLight;
     rFootSounds = 
     {
       SoundLFootRSoft,
       SoundLFootRHard,
       SoundLFootRSoft,
       SoundLFootRHard,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRHard,
       SoundLFootRSnow,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft
    }; 
     lFootSounds =
     {
        SoundLFootLSoft,
        SoundLFootLHard,
        SoundLFootLSoft,
        SoundLFootLHard,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLHard,
        SoundLFootLSnow,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft
     };
  
     footPrints = { 0, 1 };
  
     boxWidth = 0.5;
     boxDepth = 0.5;
     boxNormalHeight = 2.3;
     boxCrouchHeight = 1.8;
  
     boxNormalHeadPercentage  = 0.83;
     boxNormalTorsoPercentage = 0.53;
     boxCrouchHeadPercentage  = 0.6666;
     boxCrouchTorsoPercentage = 0.3333;
  
     boxHeadLeftPercentage  = 0;
     boxHeadRightPercentage = 1;
     boxHeadBackPercentage  = 0;
     boxHeadFrontPercentage = 1;
  };

//------------------------------------------------------------------
// Hybrid Medium Armor data:
//------------------------------------------------------------------

PlayerData HyMedium
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "plasmabolt";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = true;

   canCrouch = false;
     visibleToSensor = True;
  	mapFilter = 1;
  	mapIcon = "M_player";
  
     maxJetSideForceFactor = 0.8;
     maxJetForwardVelocity = 17;
     minJetEnergy = 1;
     jetForce = 320;
     jetEnergyDrain = 1.0;
  
  	maxDamage = 1.0;
     maxForwardSpeed = 8.0;
     maxBackwardSpeed = 7.0;
     maxSideSpeed = 7.0;
     groundForce = 35 * 13.0;
     mass = 13.0;
     groundTraction = 3.0;
  	
  	maxEnergy = 80;
     drag = 1.0;
     density = 1.5;
  
  	minDamageSpeed = 25;
  	damageScale = 0.005;
  
     jumpImpulse = 110;
     jumpSurfaceMinDot = 0.2;
  
     // animation data:
     // animation name, one shot, exclude, direction
  	// firstPerson, chaseCam, thirdPerson, signalThread
  
     // movement animations:
     animData[0]  = { "root", none, 1, true, true, true, false, 0 };
     animData[1]  = { "run", none, 1, true, false, true, false, 3 };
     animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
     animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
     animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
     animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
     animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
     animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
     animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
     animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
     animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
     animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
     animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
     animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
     animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
     animData[19] = { "jet", none, 1, true, true, true, false, 3 };
  
     // misc. animations:
     animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
     animData[21] = { "throw", none, 1, true, false, false, false, 3 };
     animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
     animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
     animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
     
     // death animations:
     animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  
     // signal moves:
  	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
     animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
     animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
     animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
     animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
  
      // celebraton animations:
     animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
     animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
     animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
  
      // taunt anmations:
     animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
     animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
  
      // poses:
     animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
     animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
  
  	// Bonus wave
     animData[50] = { "wave", none, 1, true, false, false, true, 1 };
  
     jetSound = SoundJetLight;
  
     rFootSounds = 
     {
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSnow,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft
    }; 
     lFootSounds =
     {
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSnow,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft
     };
  
     footPrints = { 2, 3 };
  
     boxWidth = 0.7;
     boxDepth = 0.7;
     boxNormalHeight = 2.4;
  
     boxNormalHeadPercentage  = 0.83;
     boxNormalTorsoPercentage = 0.49;
  
     boxHeadLeftPercentage  = 0;
     boxHeadRightPercentage = 1;
     boxHeadBackPercentage  = 0;
     boxHeadFrontPercentage = 1;
  };

//------------------------------------------------------------------
// Hybrid Heavy Armor data:
//------------------------------------------------------------------

PlayerData HyHeavy
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "plasmaex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = true;

   visibleToSensor = True;
  	mapFilter = 1;
  	mapIcon = "M_player";
  
     maxJetSideForceFactor = 0.8;
     maxJetForwardVelocity = 12;
     minJetEnergy = 1;
     jetForce = 595;
     jetEnergyDrain = 1.5;
  
  	maxDamage = 3.5;
     maxForwardSpeed = 5.5;
     maxBackwardSpeed = 5.5;
     maxSideSpeed = 4.0;
     groundForce = 35 * 18.0;
     groundTraction = 4.5;
     mass = 19.0;
  	maxEnergy = 110;
     drag = 1.0;
     density = 2.5;
     canCrouch = false;
  
  	minDamageSpeed = 25;
  	damageScale = 0.006;
  
     jumpImpulse = 150;
     jumpSurfaceMinDot = 0.2;
  
     // animation data:
     // animation name, one shot, exclude, direction,
  	// firstPerson, chaseCam, thirdPerson, signalThread
  
     // movement animations:
     animData[0]  = { "root", none, 1, true, true, true, false, 0 };
     animData[1]  = { "run", none, 1, true, false, true, false, 3 };
     animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
     animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
     animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
     animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
     animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
     animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
     animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
     animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
     animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
     animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
     animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
     animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
     animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
     animData[19] = { "jet", none, 1, true, true, true, false, 3 };
  
     // misc. animations:
     animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
     animData[21] = { "throw", none, 1, true, false, false, false, 3 };
     animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
     animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
     animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
     
     // death animations:
     animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  
     // signal moves:
  	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
     animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
     animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
     animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
     animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
  
      // celebraton animations:
     animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
     animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
     animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
  
      // taunt anmations:
     animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
     animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
  
      // poses:
     animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
     animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
  
  	// Bonus wave
     animData[50] = { "wave", none, 1, true, false, false, true, 1 };
  
     jetSound = SoundJetHeavy;
  
     rFootSounds = 
     {
       SoundHFootRSoft,
       SoundHFootRHard,
       SoundHFootRSoft,
       SoundHFootRHard,
       SoundHFootRSoft,
       SoundHFootRSoft,
       SoundHFootRSoft,
       SoundHFootRHard,
       SoundHFootRSnow,
       SoundHFootRSoft,
       SoundHFootRSoft,
       SoundHFootRSoft,
       SoundHFootRSoft,
       SoundHFootRSoft,
       SoundHFootRSoft
    }; 
     lFootSounds =
     {
        SoundHFootLSoft,
        SoundHFootLHard,
        SoundHFootLSoft,
        SoundHFootLHard,
        SoundHFootLSoft,
        SoundHFootLSoft,
        SoundHFootLSoft,
        SoundHFootLHard,
        SoundHFootLSnow,
        SoundHFootLSoft,
        SoundHFootLSoft,
        SoundHFootLSoft,
        SoundHFootLSoft,
        SoundHFootLSoft,
        SoundHFootLSoft
     };
  
     footPrints = { 4, 5 };
  
     boxWidth = 0.8;
     boxDepth = 0.8;
     boxNormalHeight = 2.6;
  
     boxNormalHeadPercentage  = 0.70;
     boxNormalTorsoPercentage = 0.45;
  
     boxHeadLeftPercentage  = 0.48;
     boxHeadRightPercentage = 0.70;
     boxHeadBackPercentage  = 0.48;
     boxHeadFrontPercentage = 0.60;
  };

//------------------------------------------------------------------
// Cybrid Light data:
//------------------------------------------------------------------

PlayerData CyLight
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "enex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = true;

   visibleToSensor = True;
  	mapFilter = 1;
  	mapIcon = "M_player";
     canCrouch = true;
  
     maxJetSideForceFactor = 0.8;
     maxJetForwardVelocity = 22;
     minJetEnergy = 37.5;
     jetForce = 236;
     jetEnergyDrain = 0;
  
  	maxDamage = 0.751;
     maxForwardSpeed = 22;
     maxBackwardSpeed = 20;
     maxSideSpeed = 10;
     groundForce = 40 * 9.0;
     mass = 9.0;
     groundTraction = 3.0;
  	maxEnergy = 50;
     drag = 1.0;
     density = 1.2;
  
  	minDamageSpeed = 25;
  	damageScale = 0.005;
  
     jumpImpulse = 75;
     jumpSurfaceMinDot = 0.2;
  
     // animation data:
     // animation name, one shot, direction
  	// firstPerson, chaseCam, thirdPerson, signalThread
     // movement animations:
     animData[0]  = { "root", none, 1, true, true, true, false, 0 };
     animData[1]  = { "run", none, 1, true, false, true, false, 3 };
     animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
     animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
     animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
     animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
     animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
     animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
     animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
     animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
     animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
     animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
     animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
     animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
     animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
     animData[19] = { "jet", none, 1, true, true, true, false, 3 };
  
     // misc. animations:
     animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
     animData[21] = { "throw", none, 1, true, false, false, false, 3 };
     animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
     animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
     animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
     
     // death animations:
     animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  
     // signal moves:
  	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
     animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
     animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
     animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
     animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
  
  
      // celebration animations:
     animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
     animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
     animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
   
      // taunt animations:




  	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
  	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
   
      // poses:
  	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
  	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
  
  	// Bonus wave
     animData[50] = { "wave", none, 1, true, false, false, true, 1 };
  
     jetSound = SoundJetLight;
     rFootSounds = 
     {
       SoundLFootRSoft,
       SoundLFootRHard,
       SoundLFootRSoft,
       SoundLFootRHard,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRHard,
       SoundLFootRSnow,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft,
       SoundLFootRSoft
    }; 
     lFootSounds =
     {
        SoundLFootLSoft,
        SoundLFootLHard,
        SoundLFootLSoft,
        SoundLFootLHard,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLHard,
        SoundLFootLSnow,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft,
        SoundLFootLSoft
     };
  
     footPrints = { 0, 1 };
  
     boxWidth = 0.5;
     boxDepth = 0.5;
     boxNormalHeight = 2.3;
     boxCrouchHeight = 1.8;
  
     boxNormalHeadPercentage  = 0.83;
     boxNormalTorsoPercentage = 0.53;
     boxCrouchHeadPercentage  = 0.6666;
     boxCrouchTorsoPercentage = 0.3333;
  
     boxHeadLeftPercentage  = 0;
     boxHeadRightPercentage = 1;
     boxHeadBackPercentage  = 0;
     boxHeadFrontPercentage = 1;
  };

//------------------------------------------------------------------
// Cybrid Medium data:
//------------------------------------------------------------------

PlayerData CyMedium
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "Fusionbolt";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = true;

   canCrouch = false;
     visibleToSensor = True;
  	mapFilter = 1;
  	mapIcon = "M_player";
  
	maxJetSideForceFactor = 35; 
	maxJetForwardVelocity = 35; 
	minJetEnergy = 1; 
	jetForce = 200; 
	jetEnergyDrain = 5.0; 
  
  	maxDamage = 1.0;
     maxForwardSpeed = 10.0;
     maxBackwardSpeed = 10.0;
     maxSideSpeed = 10.0;
     groundForce = 35 * 13.0;
     mass = 3;
     groundTraction = 1.3;
  	
  	maxEnergy = 120;
     drag = 1.0;
     density = 1.5;
  
  	minDamageSpeed = 70;
  	damageScale = 0.005;
  
     jumpImpulse = 60.0;
     jumpSurfaceMinDot = 0.2;
  
     // animation data:
     // animation name, one shot, exclude, direction
  	// firstPerson, chaseCam, thirdPerson, signalThread
  
     // movement animations:
     animData[0]  = { "root", none, 1, true, true, true, false, 0 };
     animData[1]  = { "run", none, 1, true, false, true, false, 3 };
     animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
     animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
     animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
     animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
     animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
     animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
     animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
     animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
     animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
     animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
     animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
     animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
     animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
     animData[19] = { "jet", none, 1, true, true, true, false, 3 };
  
     // misc. animations:
     animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
     animData[21] = { "throw", none, 1, true, false, false, false, 3 };
     animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
     animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
     animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
     
     // death animations:
     animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  
     // signal moves:
  	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
     animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
     animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
     animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
     animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
  
      // celebraton animations:
     animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
     animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
     animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
  
      // taunt anmations:
     animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
     animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
  
      // poses:
     animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
     animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
  
  	// Bonus wave
     animData[50] = { "wave", none, 1, true, false, false, true, 1 };
  
     jetSound = SoundJetLight;
  
     rFootSounds = 
     {
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSnow,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft
    }; 
     lFootSounds =
     {
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSnow,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft
     };
  
     footPrints = { 2, 3 };
  
     boxWidth = 0.7;
     boxDepth = 0.7;
     boxNormalHeight = 2.4;
  
     boxNormalHeadPercentage  = 0.83;
     boxNormalTorsoPercentage = 0.49;
  
     boxHeadLeftPercentage  = 0;
     boxHeadRightPercentage = 1;
     boxHeadBackPercentage  = 0;
     boxHeadFrontPercentage = 1;
  };

//------------------------------------------------------------------
// Cybrid Heavy Armor data:
//------------------------------------------------------------------

PlayerData CyHeavy
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "fusionex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = true;

   canCrouch = false;
     visibleToSensor = True;
  	mapFilter = 1;
  	mapIcon = "M_player";
  
	maxJetSideForceFactor = 20; 
	maxJetForwardVelocity = 20; 
	minJetEnergy = 1; 
	jetForce = 200; 
	jetEnergyDrain = 1.6; 
  
  	maxDamage = 1.0;
     maxForwardSpeed = 9.0;
     maxBackwardSpeed = 8.0;
     maxSideSpeed = 8.0;
     groundForce = 35 * 13.0;
     mass = 8;
     groundTraction = 20.0;
  	
  	maxEnergy = 160;
     drag = 1.0;
     density = 1.5;
  
  	minDamageSpeed = 70;
  	damageScale = 0.005;
  
     jumpImpulse = 15.0;
     jumpSurfaceMinDot = 0.2;
  
     // animation data:
     // animation name, one shot, exclude, direction
  	// firstPerson, chaseCam, thirdPerson, signalThread
  
     // movement animations:
     animData[0]  = { "root", none, 1, true, true, true, false, 0 };
     animData[1]  = { "run", none, 1, true, false, true, false, 3 };
     animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
     animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
     animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
     animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
     animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
     animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
     animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
     animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
     animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
     animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
     animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
     animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
     animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
     animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
     animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
     animData[19] = { "jet", none, 1, true, true, true, false, 3 };
  
     // misc. animations:
     animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
     animData[21] = { "throw", none, 1, true, false, false, false, 3 };
     animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
     animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
     animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
     
     // death animations:
     animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
     animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  
     // signal moves:
  	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
     animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
     animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
     animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
     animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
  
      // celebraton animations:
     animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
     animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
     animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
  
      // taunt anmations:
     animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
     animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
  
      // poses:
     animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
     animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
  
  	// Bonus wave
     animData[50] = { "wave", none, 1, true, false, false, true, 1 };
  
     jetSound = SoundElevatorRun;
  
     rFootSounds = 
     {
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRHard,
       SoundMFootRSnow,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft,
       SoundMFootRSoft
    }; 
     lFootSounds =
     {
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLHard,
        SoundMFootLSnow,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft,
        SoundMFootLSoft
     };
  
     footPrints = { 2, 3 };
  
     boxWidth = 0.7;
     boxDepth = 0.7;
     boxNormalHeight = 2.4;
  
     boxNormalHeadPercentage  = 0.83;
     boxNormalTorsoPercentage = 0.49;
  
     boxHeadLeftPercentage  = 0;
     boxHeadRightPercentage = 1;
     boxHeadBackPercentage  = 0;
     boxHeadFrontPercentage = 1;
  };