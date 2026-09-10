addPluginWeapon(LaserRifle, Gasser);
 $AutoUse[Gasser] = True;

 $SellAmmo[GasserAmmo] = 5;
 $AmmoPackMax[GasserAmmo] = 6;
 $WeaponAmmo[Gasser] = GasserAmmo;

$InvList[Gasser] = 1;
$RemoteInvList[Gasser] = 1;
$InvList[GasserAmmo] = 1;
$RemoteInvList[GasserAmmo] = 1;
$HelpMessage[Gasser] = "A revolving tear gas launcher that holds 6 teargas grenades.";


SoundData SoundGasser
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

GrenadeData GasserGrenade
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.61;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $PacificationDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 150;
   totalTime          = 3.0;    // special meaning for grenades...
   liveTime           = 3.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};


$ItemMax[hlarmor, Gasser] = 0;
$ItemMax[hlfemale, Gasser] = 0;
$ItemMax[marmor, Gasser] = 1;
$ItemMax[mfemale, Gasser] = 1;
$ItemMax[larmor, Gasser] = 1;
$ItemMax[lfemale, Gasser] = 1;
$ItemMax[earmor, Gasser] = 1;
$ItemMax[efemale, Gasser] = 1;
$ItemMax[harmor, Gasser] = 1;
$ItemMax[uharmor, Gasser] = 1;

$ItemMax[hlarmor, GasserAmmo] = 6;
$ItemMax[hlfemale, GasserAmmo] = 6;
$ItemMax[marmor, GasserAmmo] = 6;
$ItemMax[mfemale, GasserAmmo] = 6;
$ItemMax[larmor, GasserAmmo] = 6;
$ItemMax[lfemale, GasserAmmo] = 6;
$ItemMax[earmor, GasserAmmo] = 6;
$ItemMax[efemale, GasserAmmo] = 6;
$ItemMax[harmor, GasserAmmo] = 6;
$ItemMax[uharmor, GasserAmmo] = 6;

ItemData GasserAmmo
{
	description = "Teargas Ammo";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData GasserImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = GasserGrenade;
	ammoType = GasserAmmo;
	accuFire = True;
	reloadTime = 0.0;
	fireTime = 1.0;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Gasser
{
	description = "M5 Teargas Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "plasma";
	heading = "cSecondary Weapons";
	shadowDetailMask = 4;
	imageType = GasserImage;
	price = 250;
	showWeaponBar = true;
};

function Gasser::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Teargas Launcher - Usually used for crowd control or pissing off your neighbors.", 2);
	}
}


ItemImageData GasserScopeImage
{
	shapeFile  = "discammo";
	mountPoint = 0;
	mountRotation = { 1.5, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.0, -0.1 };

	ammoType = GasserAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData GasserScope
{
	heading = "cSecondary Weapons";
	description = "GasserScope";
	className = "Weapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = GasserScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData GasserClipImage
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

ItemData GasserClip
{
	heading = "cSecondary Weapons";
	description = "GasserClip";
	className = "Weapon";
	shapeFile  = "grenadel";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = GasserClipImage;
	price = 50;
	showWeaponBar = true;
};

function Gasser::onMount(%player,%item)
{
	Player::MountItem(%player,GasserScope,7);
	Player::MountItem(%player,GasserClip,6);
}
function Gasser::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}
