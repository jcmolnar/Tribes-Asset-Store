
$InvList[Remington] = 1;
$RemoteInvList[Remington] = 1;
$InvList[RemingtonAmmo] = 1;
$RemoteInvList[RemingtonAmmo] = 1;
$HelpMessage[Remington] = "A sniper rifle with medium damage and high fire rate.";


SoundData SoundRemington
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

BulletData RemingtonPellet
{
   bulletShapeName    = "breath.dts";
   explosionTag       = BigBulletExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.65;
   damageType         = $BulletDmgType14;

   aimDeflection      = 0.0;
   muzzleVelocity     = 3000.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 0.0;
   isVisible          = False;
    	soundId = SoundJetHeavy;
   tracerPercentage   = 0.1;
   tracerLength       = 1;


};


ExplosionData RemingtonExp
{
   shapeName = "bluex.dts";
   soundId   = SoundRemington;

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

$ItemMax[hlarmor, Remington] = 0;
$ItemMax[hlfemale, Remington] = 0;
$ItemMax[marmor, Remington] = 0;
$ItemMax[mfemale, Remington] = 0;
$ItemMax[larmor, Remington] = 1;
$ItemMax[lfemale, Remington] = 1;
$ItemMax[earmor, Remington] = 0;
$ItemMax[efemale, Remington] = 0;
$ItemMax[harmor, Remington] = 0;
$ItemMax[uharmor, Remington] = 0;

$ItemMax[hlarmor, RemingtonAmmo] = 15;
$ItemMax[hlfemale, RemingtonAmmo] = 15;
$ItemMax[marmor, RemingtonAmmo] = 15;
$ItemMax[mfemale, RemingtonAmmo] = 15;
$ItemMax[larmor, RemingtonAmmo] = 15;
$ItemMax[lfemale, RemingtonAmmo] = 15;
$ItemMax[earmor, RemingtonAmmo] = 15;
$ItemMax[efemale, RemingtonAmmo] = 15;
$ItemMax[harmor, RemingtonAmmo] = 15;
$ItemMax[uharmor, RemingtonAmmo] = 15;



 addPluginWeapon(LaserRifle, Remington);
 $AutoUse[Remington] = True;

 $SellAmmo[RemingtonAmmo] = 5;
 $AmmoPackMax[RemingtonAmmo] = 0;
 $WeaponAmmo[Remington] = RemingtonAmmo;


ItemData RemingtonAmmo
{
	description = "Remington Ammo";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData RemingtonImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = RemingtonPellet;
	ammoType = RemingtonAmmo;
	accuFire = True;
	reloadTime = 0.0;
	fireTime = 1.0;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = shockexplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Remington
{
	description = "Remington 7.62 Snipe";
	className = "PriWeapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = RemingtonImage;
	price = 250;
	showWeaponBar = true;
};

function Remington::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Remington - a semi-automatic sniper rifle with decent damage.", 2);
	}
}


ItemImageData RemingtonScopeImage
{
	shapeFile  = "force";
	mountPoint = 0;
	mountRotation = { 1.5, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.05, 0.225 };

	ammoType = RemingtonAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RemingtonScope
{
	heading = "cSecondary Weapons";
	description = "RemingtonScope";
	className = "Weapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = RemingtonScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData RemingtonClipImage
{
	shapeFile  = "shotgun";
	mountPoint = 0;
	mountRotation = {0, 3.1, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.07, 0.0 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RemingtonClip
{
	heading = "cSecondary Weapons";
	description = "RemingtonClip";
	className = "Weapon";
	shapeFile  = "shotgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = RemingtonClipImage;
	price = 50;
	showWeaponBar = true;
};


function Remington::onMount(%player,%item)
{
	Player::MountItem(%player,RemingtonScope,7);
	Player::MountItem(%player,RemingtonClip,6);
}
function Remington::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}