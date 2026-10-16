
//================================================================
// Minigun 
//================================================================
$AutoUse[Minigun] = False;
//===============================================================
$InvList[Minigun] = 1;
$InvList[MinigunAmmo] = 1;
$RemoteInvList[Minigun] = 1;
$RemoteInvList[MinigunAmmo] = 1;
//================================================================
$DamageScale[larmor, $MinigunDamageType] = 0.35;
$DamageScale[lfemale, $MinigunDamageType] = 0.35;
$DamageScale[marmor, $MinigunDamageType] = 0.35;
$DamageScale[mfemale, $MinigunDamageType] = 0.35;
$DamageScale[harmor, $MinigunDamageType] = 0.35;

$ItemMax[larmor, Minigun] = 1;
$ItemMax[lfemale, Minigun] = 1;
$ItemMax[marmor, Minigun] = 1;
$ItemMax[mfemale, Minigun] = 1;
$ItemMax[harmor, Minigun] = 1;

$ItemMax[larmor, MinigunAmmo] = 500;
$ItemMax[lfemale, MinigunAmmo] = 500;
$ItemMax[marmor, MinigunAmmo] = 500;
$ItemMax[mfemale, MinigunAmmo] = 500;
$ItemMax[harmor, MinigunAmmo] = 500;
//================================================================
SoundData SoundWPNMinigun
{
   wavFileName = "wpn_minigun.wav";
   profile = Profile3dNearloop;
};
SoundData SoundWPNMinigunSpinUp
{
   wavFileName = "wpn_minigun_up.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNMinigunSpinDown
{
   wavFileName = "wpn_minigun_down.wav";
   profile = Profile3dNear;
};

SoundData SoundWhizMini
{
   wavFileName = "whiz_mini.wav";
   profile = Profile3dCloseLoop;
};
//=============================================================
// relocated in wpn_ix... due to spam bug
//================================================================


BulletData Minigunproj
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = MinigunExp;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.1;
	damageType         = $MinigunDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = true;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//-------------------------------------------------------


//================================================================
ItemData MinigunAmmo
{
	description = "Minigun Ammo";
	className = "Ammo";
	shapeFile = "ammo_chain";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData MinigunImage
{
	shapeFile = "wpn_minigun";
	mountPoint = 0;
	
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 1.0;
	fireTime = 0.15;
	
	ammoType = MinigunAmmo;
	projectileType = MinigunProj;
	accuFire = false;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	
	sfxFire = SoundWPNMinigun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundWPNMinigunSpinUp;
	sfxSpinDown = SoundWPNMinigunSpinDown;
};

ItemData Minigun
{
	description = "Minigun";
	className = "Weapon";
	shapeFile = "wpn_Minigun";
	hudIcon = "Minigun";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MinigunImage;
	price = 0;
	showWeaponBar = true;
};

function Minigun::onUse(%player,%item)
{
	//Checks for Minigun Ammo Pack
	if(Player::getMountedItem(%player,$BackpackSlot) == MinigunAmmoPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Minigun Ammo Pack to use the Minigun.");
}

//================================================================
////////////////////////////////////////////////////////////////////
//echo("Minigun Loaded");