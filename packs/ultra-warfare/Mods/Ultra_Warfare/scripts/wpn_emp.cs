//================================================================
//ShockWave Cannon
//================================================================
$AutoUse[Shock] = False;
//================================================================
$InvList[Shock] = 1;
$InvList[ShockAmmo] = 1;
$RemoteInvList[Shock] = 1;
$RemoteInvList[ShockAmmo] = 1;
//================================================================
$DamageScale[larmor, $EMPDamageType] = 0.25;
$DamageScale[lfemale, $EMPDamageType] = 0.25;
$DamageScale[marmor, $EMPDamageType] = 0.25;
$DamageScale[mfemale, $EMPDamageType] = 0.25;
$DamageScale[harmor, $EMPDamageType] = 0.25;

$ItemMax[larmor, Shock] = 0;				
$ItemMax[lfemale, Shock] = 0;					
$ItemMax[marmor, Shock] = 0;				
$ItemMax[mfemale, Shock] = 0;	
$ItemMax[harmor, Shock] = 1;							

$ItemMax[larmor, ShockAmmo] = 0;
$ItemMax[lfemale, ShockAmmo] = 0;		
$ItemMax[marmor, ShockAmmo] = 0;
$ItemMax[mfemale, ShockAmmo] = 0;
$ItemMax[harmor, ShockAmmo] = 25;
//================================================================
SoundData SoundWPNEmp
{
   wavFileName = "wpn_emp.wav";
   profile = Profile3dMedium;
};
SoundData SoundWPNShockLoad
{
   wavFileName = "wpn_emp_load.wav";
   profile = Profile3dNear;
};
SoundData ShockWaveExplosion
{
   wavFilename = "exp_emp.wav";
   profile = Profile3dLudicrouslyFar;
};
SoundData SoundWhizShock
{
   wavFileName = "whiz_emp.wav";
   profile = Profile3dNearLoop;
};
//================================================================
ExplosionData ShockExp
{
   shapeName = "shockwave_large.dts";
   soundId   = ShockwaveExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 15.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 0.0, 1.0, 0.0 };
};
//================================================================
RocketData Shockproj
{ 
   bulletShapeName = "proj_emp.dts";
   explosionTag = ShockExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 5.0;
   damageType = $EMPDamageType;
   explosionRadius = 25;
   kickBackStrength = 0;
   
   muzzleVelocity = 75.0;
   
   terminalVelocity = 250.0;
   acceleration = 3.0;
   
   totalTime = 20.0;
   liveTime = 21.0;

   trailType = 2; 
   trailString = "breath.dts";
   

   inheritedVelocityScale = 0.76;
   
   soundId = SoundWhizShock;
}; 
//================================================================
ItemData ShockAmmo
{
        description = "Shockwave Cell";
       className = "Ammo";
        shapeFile = "plasammo";
   heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 0;
};
ItemImageData ShockImage
{
	shapeFile = "wpn_shockcan";
	mountPoint = 0;

	weaponType = 1; // Single Shot
	ammoType = ShockAmmo;
	projectileType = Shockproj;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 1.5;
	spinUpTime = 1.0;
 	spinDownTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundWPNEMP;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundWPNShockLoad;
};
ItemData Shock
{
	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "wpn_shockcan";
	hudIcon = "shock";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ShockImage;
	price = 0;
	showWeaponBar = true;
};
