// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
 
addPluginWeapon(MineLauncher, Famas); 
$AutoUse[Famas] = true; 
$SellAmmo[Famas] = 50; 
$AmmoPackMax[Famas] = 0; 
$WeaponAmmo[Famas] = FamasAmmo; 
 
$ItemMax[hlarmor, Famas] = 0; 
$ItemMax[hlfemale, Famas] = 0; 
$ItemMax[larmor, Famas] = 1; 
$ItemMax[lfemale, Famas] = 1; 
$ItemMax[earmor, Famas] = 0; 
$ItemMax[efemale, Famas] = 0; 
$ItemMax[marmor, Famas] = 1; 
$ItemMax[mfemale, Famas] = 1; 
$ItemMax[harmor, Famas] = 0; 
$ItemMax[uharmor, Famas] = 0; 
 
$ItemMax[hlarmor, FamasAmmo] = 30; 
$ItemMax[hlfemale, FamasAmmo] = 30; 
$ItemMax[larmor, FamasAmmo] = 30; 
$ItemMax[lfemale, FamasAmmo] = 30; 
$ItemMax[earmor, FamasAmmo] = 30; 
$ItemMax[efemale, FamasAmmo] = 30; 
$ItemMax[marmor, FamasAmmo] = 30; 
$ItemMax[mfemale, FamasAmmo] = 30; 
$ItemMax[harmor, FamasAmmo] = 30; 
$ItemMax[uharmor, FamasAmmo] = 30; 
 
$InvList[Famas] = 1; 
$RemoteInvList[Famas] = 1; 
$InvList[FamasAmmo] = 1; 
$RemoteInvList[FamasAmmo] = 1; 
 
$HelpMessage[Famas] = "A French made machinegun with decent accuracy and fire rate"; 
 
 
ItemData FamasAmmo 
{ 
	description = "FA-MAS Ammo"; 
	classname = "Ammo"; 
	shapefile = "ammo2"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemData DummyAmmo 
{ 
	description = "Dummy Ammo"; 
	classname = "Ammo"; 
	shapefile = "ammo2"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 
 
BulletData FamasBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp0; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.35; 
	damageType = $BulletDmgType28;
     	soundId = SoundJetHeavy;
	aimDeflection = 0.003; 
	muzzleVelocity = 1000; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = False; 
 
	tracerPercentage = 0.1; 
	tracerLength = 10; 
}; 
 
ItemImageData FamasImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = FamasBullet; 
	ammotype = FamasAmmo; 
	aimDeflection = 0.001; 
	accuFire = True; 
	reloadTime = 0; 
	fireTime = 0.1; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = bigExplosion3; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData Famas 
{ 
	description = "FA-MAS Machinegun"; 
	className = "priweapon"; 
	shapefile = "sniper"; 
	hudIcon = "sniper"; 
	heading = "bPrimary Weapons"; 
	shadowDetailMask = 4; 
	imageType = FamasImage; 
	price = 0; 
	showWeaponBar = true; 
}; 
 
function Famas::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>FA-MAS - C'est la bang bang!", 2); 
	} 
} 
// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 

ItemImageData FamasScopeImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	mountRotation = { 0, 0, 3.14 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.0, 0.0 };

	ammoType = DummyAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};


ItemData FamasScope
{
	heading = "cSecondary Weapons";
	description = "FamasScope";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FamasScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData FamasClipImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	mountRotation = {0, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.0, 0.2 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FamasClip
{
	heading = "cSecondary Weapons";
	description = "FamasClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FamasClipImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData FamasMountImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	mountRotation = {0, 0, 3.14 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.2, 0.2 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FamasMount
{
	heading = "cSecondary Weapons";
	description = "FamasClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FamasMountImage;
	price = 50;
	showWeaponBar = true;
};

function Famas::onMount(%player,%item)
{
	Player::MountItem(%player,FamasMount,5);
	Player::MountItem(%player,FamasScope,7);
	Player::MountItem(%player,FamasClip,6);
}
function Famas::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
	Player::UnMountItem(%player,5);
}
