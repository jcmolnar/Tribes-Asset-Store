//================================================================
// t2 chaingun
//================================================================
$AutoUse[Chaingun] = False;
//===============================================================
$InvList[Chaingun] = 1;
$InvList[chaingunAmmo] = 1;
$RemoteInvList[Chaingun] = 1;
$RemoteInvList[chaingunAmmo] = 1;
//================================================================
$DamageScale[larmor, $chaingunDamageType] = 0.5;
$DamageScale[lfemale, $chaingunDamageType] = 0.5;
$DamageScale[marmor, $chaingunDamageType] = 0.5;
$DamageScale[mfemale, $chaingunDamageType] = 0.5;
$DamageScale[harmor, $chaingunDamageType] = 0.5;

$ItemMax[larmor, Chaingun] = 1;
$ItemMax[lfemale, Chaingun] = 1;
$ItemMax[marmor, Chaingun] = 1;
$ItemMax[mfemale, Chaingun] = 1;
$ItemMax[harmor, Chaingun] = 1;

$ItemMax[larmor, ChaingunAmmo] = 150;
$ItemMax[lfemale, chaingunAmmo] = 150;
$ItemMax[marmor, chaingunAmmo] = 300;
$ItemMax[mfemale, chaingunAmmo] = 300;
$ItemMax[harmor, chaingunAmmo] = 500;
//================================================================

SoundData SoundWPNCgact
{
   wavFileName = "wpn_cg_act.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNCg
{
   wavFileName = "wpn_cg.wav";
   profile = Profile3dNearloop;
};
SoundData SoundWPNCgSpinUp
{
   wavFileName = "wpn_cg_up.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNCgSpinDown
{
   wavFileName = "wpn_cg_down.wav";
   profile = Profile3dNear;
};

//================================================================
// relocated in wpn_ix... due to spam bug
//====================================================================
BulletData ChaingunProj
{
   bulletShapeName    = "bullet.dts";
   //validateShape      = true;
   explosionTag       = ChaingunExp;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $ChaingunDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 700.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//================================================================
ItemData chaingunAmmo
{
	description = "Chaingun Bullets";
	className = "Ammo";
	shapeFile = "ammo_chain";
        heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "wpn_chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3.0;
	fireTime = 0.15;

	ammoType = chaingunAmmo;
	projectileType = ChaingunProj;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundWPNCg;
	sfxActivate = SoundWPNCgAct;
	sfxSpinUp = SoundWPNCgSpinUp;
	sfxSpinDown = SoundWPNCGSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "wpn_chaingun";
   //validateShape = true;
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

/////////////////////////////////////////////////////////
//echo("Chaingun Loaded");