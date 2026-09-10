
$InvList[TommyGun] = 1;
$RemoteInvList[TommyGun] = 1;
$InvList[TommyGunAmmo] = 1;
$RemoteInvList[TommyGunAmmo] = 1;
$HelpMessage[TommyGun] = "An old classic machinegun that likes to spray the badguys.";


SoundData SoundTommyGun
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

BulletData TommyGunPellet
{
   bulletShapeName    = "breath.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
    	soundId = SoundJetHeavy;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $BulletDmgType17;

   aimDeflection      = 0.007;
   muzzleVelocity     = 1000.0;
   totalTime          = 2.5;
   inheritedVelocityScale = 0.5;
   isVisible          = False;

   tracerPercentage   = 0.1;
   tracerLength       = 1;


};


ExplosionData TommyGunExp
{
   shapeName = "bluex.dts";
   soundId   = SoundTommyGun;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;
   timeScale = 1.5;
   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

$ItemMax[hlarmor, TommyGun] = 0;
$ItemMax[hlfemale, TommyGun] = 0;
$ItemMax[marmor, TommyGun] = 1;
$ItemMax[mfemale, TommyGun] = 1;
$ItemMax[larmor, TommyGun] = 1;
$ItemMax[lfemale, TommyGun] = 1;
$ItemMax[earmor, TommyGun] = 1;
$ItemMax[efemale, TommyGun] = 1;
$ItemMax[harmor, TommyGun] = 1;
$ItemMax[uharmor, TommyGun] = 1;

$ItemMax[hlarmor, TommyGunAmmo] = 50;
$ItemMax[hlfemale, TommyGunAmmo] = 50;
$ItemMax[marmor, TommyGunAmmo] = 50;
$ItemMax[mfemale, TommyGunAmmo] = 50;
$ItemMax[larmor, TommyGunAmmo] = 50;
$ItemMax[lfemale, TommyGunAmmo] = 50;
$ItemMax[earmor, TommyGunAmmo] = 50;
$ItemMax[efemale, TommyGunAmmo] = 50;
$ItemMax[harmor, TommyGunAmmo] = 50;
$ItemMax[uharmor, TommyGunAmmo] = 50;



 addPluginWeapon(LaserRifle, TommyGun);
 $AutoUse[TommyGun] = True;

 $SellAmmo[TommyGunAmmo] = 5;
 $AmmoPackMax[TommyGunAmmo] = 0;
 $WeaponAmmo[TommyGun] = TommyGunAmmo;


ItemData TommyGunAmmo
{
	description = "TommyGun Ammo";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData TommyGunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = TommyGunPellet;
	ammoType = TommyGunAmmo;
	accuFire = True;
	reloadTime = 0.0;
	fireTime = 0.1;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData TommyGun
{
	description = "Tommy Gun";
	className = "PriWeapon";
	shapeFile = "paintgun";
	hudIcon = "plasma";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = TommyGunImage;
	price = 250;
	showWeaponBar = true;
};

function TommyGun::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>TommyGun - a classic machinegun.  Go mafia.", 2);
	}
}


ItemImageData TommyGunScopeImage
{
	shapeFile  = "discammo";
	mountPoint = 0;
	mountRotation = { 1.5, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.0, -0.1 };

	ammoType = TommyGunAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TommyGunScope
{
	heading = "cSecondary Weapons";
	description = "TommyGunScope";
	className = "Weapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = TommyGunScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData TommyGunClipImage
{
	shapeFile  = "grenadel";
	mountPoint = 0;
	mountRotation = {3.1, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.0, 0.0 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TommyGunClip
{
	heading = "cSecondary Weapons";
	description = "TommyGunClip";
	className = "Weapon";
	shapeFile  = "grenadel";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = TommyGunClipImage;
	price = 50;
	showWeaponBar = true;
};

function TommyGun::onMount(%player,%item)
{
	Player::MountItem(%player,TommyGunScope,7);
	Player::MountItem(%player,TommyGunClip,6);
}
function TommyGun::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}
