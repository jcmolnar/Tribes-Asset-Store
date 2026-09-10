
$InvList[Ruger] = 1;
$RemoteInvList[Ruger] = 1;
$InvList[RugerAmmo] = 1;
$RemoteInvList[RugerAmmo] = 1;
$HelpMessage[Ruger] = "A .22 cal. pistol with excellent accuracy, but very low damage.";


SoundData SoundRuger
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

BulletData RugerPellet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.10;
   damageType         = $BulletDmgType16;

   aimDeflection      = 0.0005;
   muzzleVelocity     = 800.0;
   totalTime          = 2.5;
   inheritedVelocityScale = 0.0;
   isVisible          = False;
    	soundId = SoundJetLight;
   tracerPercentage   = 0.5;
   tracerLength       = 10;


};


ExplosionData RugerExp
{
   shapeName = "bluex.dts";
   soundId   = SoundRuger;

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

$ItemMax[hlarmor, Ruger] = 1;
$ItemMax[hlfemale, Ruger] = 1;
$ItemMax[marmor, Ruger] = 1;
$ItemMax[mfemale, Ruger] = 1;
$ItemMax[larmor, Ruger] = 1;
$ItemMax[lfemale, Ruger] = 1;
$ItemMax[earmor, Ruger] = 1;
$ItemMax[efemale, Ruger] = 1;
$ItemMax[harmor, Ruger] = 1;
$ItemMax[uharmor, Ruger] = 1;

$ItemMax[hlarmor, RugerAmmo] = 16;
$ItemMax[hlfemale, RugerAmmo] = 16;
$ItemMax[marmor, RugerAmmo] = 16;
$ItemMax[mfemale, RugerAmmo] = 16;
$ItemMax[larmor, RugerAmmo] = 16;
$ItemMax[lfemale, RugerAmmo] = 16;
$ItemMax[earmor, RugerAmmo] = 16;
$ItemMax[efemale, RugerAmmo] = 16;
$ItemMax[harmor, RugerAmmo] = 16;
$ItemMax[uharmor, RugerAmmo] = 16;



 addPluginWeapon(LaserRifle, Ruger);
 $AutoUse[Ruger] = True;

 $SellAmmo[RugerAmmo] = 5;
 $AmmoPackMax[RugerAmmo] = 0;
 $WeaponAmmo[Ruger] = RugerAmmo;


ItemData RugerAmmo
{
	description = "Ruger Ammo";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData RugerImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = RugerPellet;
	ammoType = RugerAmmo;
	accuFire = True;
	reloadTime = 0.0;
	fireTime = 0.5;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Ruger
{
	description = "Ruger .22 Cal";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "plasma";
	heading = "cSecondary Weapons";
	shadowDetailMask = 4;
	imageType = RugerImage;
	price = 250;
	showWeaponBar = true;
};

function Ruger::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Ruger .22 - a weak pistol with excellent accuracy.", 2);
	}
}


ItemImageData RugerScopeImage
{
	shapeFile  = "force";
	mountPoint = 0;
	mountRotation = { 3.0, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.0, 0.2 };

	ammoType = RugerAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RugerScope
{
	heading = "cSecondary Weapons";
	description = "RugerScope";
	className = "Weapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = RugerScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData RugerClipImage
{
	shapeFile  = "force";
	mountPoint = 0;
	mountRotation = {1.59, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { 0.0, 0.30, 0.092 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RugerClip
{
	heading = "cSecondary Weapons";
	description = "RugerClip";
	className = "Weapon";
	shapeFile  = "mortar";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = RugerClipImage;
	price = 50;
	showWeaponBar = true;
};


function Ruger::onMount(%player,%item)
{
	Player::MountItem(%player,RugerScope,7);
	Player::MountItem(%player,RugerClip,6);
}
function Ruger::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}