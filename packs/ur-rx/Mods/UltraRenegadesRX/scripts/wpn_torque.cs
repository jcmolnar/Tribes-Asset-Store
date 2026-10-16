//================================================================
// Torque 
//================================================================

SoundData SoundFireTorque
{
   wavFileName = "plasma2.wav";
   profile = Profile3dNear;
};

SoundData SoundTorqueReload
{
   wavFileName = "mortar_reload.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionTorque
{
   wavFileName = "shieldhit.wav";
   profile = Profile3dFar;
};

//================================================================
ExplosionData TorqueExp
{
   shapeName = "shield.dts";
   soundId   = ExplosionTorque;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};
//================================================================
RocketData ProjTorque
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = TorqueExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $TorqueDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 1.8;

   //soundId = SoundJetHeavy;
};

//================================================================
ItemData TorqueAmmo 
{ 
        description = "Torque Cell";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "grenammo";
        shadowDetailMask = 4;
        price = 5;
}; 

ItemImageData PlasmaGunImage 
{ 
        shapeFile = "plasma";
        mountPoint = 0;
        weaponType = 0;
        ammoType = TorqueAmmo;
        projectileType = ProjTorque;
        accuFire = false;
        reloadTime = 0.2;
        fireTime = 0;
        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
	sfxFire = SoundFireTorque;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundTorqueReload;
};

ItemData PlasmaGun
{ 
        description = "Torque";
        className = "Weapon";
        shapeFile = "plasma";
        hudIcon = "plasma";
        heading = "BWeapons";
        shadowDetailMask = 4;
        imageType = PlasmaGunImage;
        price = 100;
        showWeaponBar = true;
};

//=================================================================
echo("Item Loaded");