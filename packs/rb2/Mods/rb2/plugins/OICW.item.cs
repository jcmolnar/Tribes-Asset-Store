
$InvList[OICW] = 1;
$RemoteInvList[OICW] = 1;
$InvList[OICWAmmo] = 1;
$RemoteInvList[OICWAmmo] = 1;
$HelpMessage[OICW] = "Fires 5.56mm kinetic rounds and explosive grenades (bought separately).";


SoundData SoundOICW
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

BulletData OICWPellet
{
   bulletShapeName    = "breath.dts";
   explosionTag       = BigBulletExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $BulletDmgType12;
    	soundId = SoundJetHeavy;
   aimDeflection      = 0.0025;
   muzzleVelocity     = 625.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 0.1;
   tracerLength       = 1;


};

RocketData OICWGrenade
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $BulletDmgType13;

   explosionRadius  = 25.0;
   kickBackStrength = 400.0;
   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 300.0;
   totalTime        = 2.0;
   liveTime         = 1.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 2.8;

   soundId = SoundJetHeavy;
};




ExplosionData OICWExp
{
   shapeName = "bluex.dts";
   soundId   = SoundOICW;

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

$ItemMax[hlarmor, OICW] = 0;
$ItemMax[hlfemale, OICW] = 0;
$ItemMax[marmor, OICW] = 0;
$ItemMax[mfemale, OICW] = 0;
$ItemMax[larmor, OICW] = 0;
$ItemMax[lfemale, OICW] = 0;
$ItemMax[earmor, OICW] = 0;
$ItemMax[efemale, OICW] = 0;
$ItemMax[harmor, OICW] = 1;
$ItemMax[uharmor, OICW] = 1;

$ItemMax[hlarmor, OICWAmmo] = 10;
$ItemMax[hlfemale, OICWAmmo] = 10;
$ItemMax[marmor, OICWAmmo] = 30;
$ItemMax[mfemale, OICWAmmo] = 30;
$ItemMax[larmor, OICWAmmo] = 20;
$ItemMax[lfemale, OICWAmmo] = 20;
$ItemMax[earmor, OICWAmmo] = 100;
$ItemMax[efemale, OICWAmmo] = 100;
$ItemMax[harmor, OICWAmmo] = 100;
$ItemMax[uharmor, OICWAmmo] = 100;



 addPluginWeapon(LaserRifle, OICW);
 $AutoUse[OICW] = True;

 $SellAmmo[OICWAmmo] = 5;
 $AmmoPackMax[OICWAmmo] = 100;
 $WeaponAmmo[OICW] = OICWAmmo;


ItemData OICWAmmo
{
	description = "OICW Ammo";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData OICWImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = OICWPellet;
	ammoType = OICWAmmo;
	accuFire = True;
	reloadTime = 0.0;
	fireTime = 0.1;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData OICW
{
	description = "OICW";
	className = "PriWeapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = OICWImage;
	price = 250;
	showWeaponBar = true;
};

function OICW::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>OICW - Use OICW Grenades (under beacons) for extra damage.", 2);
	}
}

function OICWImage::onFire(%player, %slot)
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[OICW]);
	
	if (%AmmoCount)
	 {
   		 playSound(turretExplosion,GameBase::getPosition(%player));

	 }

}

ItemImageData OICWScopeImage
{
	shapeFile  = "grenadeL";
	mountPoint = 0;
	mountRotation = { 0, 3.1, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.0, -0.0 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData OICWScope
{
	heading = "cSecondary Weapons";
	description = "OICWScope";
	className = "Weapon";
	shapeFile  = "grenadeL";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = OICWScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData OICWClipImage
{
	shapeFile  = "grenammo";
	mountPoint = 0;
	mountRotation = { 0, 0, 3.1 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.1, 0.15 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData OICWClip
{
	heading = "cSecondary Weapons";
	description = "OICWClip";
	className = "Weapon";
	shapeFile  = "grenammo";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = OICWClipImage;
	price = 50;
	showWeaponBar = true;
};


function OICW::onMount(%player,%item)
{
	Player::MountItem(%player,OICWScope,7);
	Player::MountItem(%player,OICWClip,6);
}
function OICW::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}