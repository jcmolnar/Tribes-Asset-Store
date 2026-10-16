// MiniMod Plugin...
// Fusion Blaster Created/ported by Dewy

MiniMod::MonitorFile(start, "FusionBlaster.CodeFusion.cs", "Fusion Blaster Plugin");

ExplosionData FusionGunExp
{
   shapeName = "shockwave.dts";
   soundId = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 0.5;

   timeZero = 0.0;
   timeOne  = 2.5;

   colors[0]  = { 0.15, 0.15, 1.0 };
   colors[1]  = { 0.015, 0.015, 0.1 };
   colors[2]  = { 0.0015, 0.0015, 0.01 };
   radFactors = { 0.15, 0.15, 1.0 };
};

BulletData FusionGunBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = FusionGunExp;
   collisionRadius    = 2.0;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   explosionRadius    = 3.0;
   muzzleVelocity     = 5.0;
   terminalVelocity = 75.0;
   acceleration     = 5.0;
   totalTime          = 15.0;
   liveTime           = 15.0;
   lightRange         = 5.0;
   lightColor         = { 0.15, 0.15, 1 };
   inheritedVelocityScale = 1.5;
   isVisible          = True;

   rotationPeriod = 0.05;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundJetHeavy;
};

RocketData FusionShell
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = FusionGunExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 10.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor         = { 0.15, 0.15, 1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 50;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

MiniMod::Turbo::Class(FusionGun, 5);
MiniMod::Turbo::Class(FusionGun, 6);

MiniMod::WeaponCycle(Blaster, FusionGun, PlasmaGun);

$AutoUse[FusionGun] = True; 

ItemImageData FusionGunImage
{
        shapeFile  = "energygun";
	mountPoint = 0;

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.1;
        minEnergy = 6;
        maxEnergy = 7;

        projectileType = FusionShell;
	accuFire = true;

	sfxFire = SoundRemoteTurretFire;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundMortarReload;
	sfxReady = SoundUseAmmoStation ;
};

ItemData FusionGun
{
   heading = "bWeapons";
        description = "Fusion Blaster";
	className = "Weapon";
        shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
        imageType = FusionGunImage;
        price = 115;
	showWeaponBar = true;
};

$InvList[FusionGun] = 1;
$RemoteInvList[FusionGun] = 1;

MiniMod::MonitorFile(stop, "FusionBlaster.CodeFusion.cs", "Fusion Blaster Plugin");
