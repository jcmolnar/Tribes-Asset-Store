// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
 
addPluginWeapon(LaserRifle, saw); 
$AutoUse[saw] = true; 
$SellAmmo[saw] = 50; 
$AmmoPackMax[saw] = 100; 
$WeaponAmmo[saw] = sawAmmo; 
 
$ItemMax[hlarmor, saw] = 0; 
$ItemMax[hlfemale, saw] = 0; 
$ItemMax[larmor, saw] = 0; 
$ItemMax[lfemale, saw] = 0; 
$ItemMax[earmor, saw] = 1; 
$ItemMax[efemale, saw] = 1; 
$ItemMax[marmor, saw] = 1; 
$ItemMax[mfemale, saw] = 1; 
$ItemMax[harmor, saw] = 1; 
$ItemMax[uharmor, saw] = 1; 
 
$ItemMax[hlarmor, sawAmmo] = 100; 
$ItemMax[hlfemale, sawAmmo] = 100; 
$ItemMax[larmor, sawAmmo] = 100; 
$ItemMax[lfemale, sawAmmo] = 100; 
$ItemMax[earmor, sawAmmo] = 100; 
$ItemMax[efemale, sawAmmo] = 100; 
$ItemMax[marmor, sawAmmo] = 100; 
$ItemMax[mfemale, sawAmmo] = 100; 
$ItemMax[harmor, sawAmmo] = 100; 
$ItemMax[uharmor, sawAmmo] = 100; 
 
$InvList[saw] = 1; 
$RemoteInvList[saw] = 1; 
$InvList[sawAmmo] = 1; 
$RemoteInvList[sawAmmo] = 1; 
 
$HelpMessage[saw] = "Standard infantry light machinegun that carries large ammo drums"; 
 
 
ItemData sawAmmo 
{ 
	description = "SAW Ammo"; 
	classname = "Ammo"; 
	shapefile = "tracer"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 0; 
}; 
 
BulletData sawBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp0; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.2; 
	damageType = $BulletDmgType30;
     	soundId = SoundJetHeavy;
	aimDeflection = 0.0025; 
	muzzleVelocity = 1000; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = False; 
 
	tracerPercentage = 0.2; 
	tracerLength = 10; 
}; 
 
ItemImageData sawImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = sawBullet; 
	ammotype = sawAmmo; 
	aimDeflection = 0.004; 
	accuFire = True; 
	reloadTime = 0; 
	fireTime = 0.1; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = debrisMediumExplosion; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData saw 
{ 
	description = "M249 SAW"; 
	className = "Priweapon"; 
	shapefile = "sniper"; 
	hudIcon = "sniper"; 
	heading = "bPrimary Weapons"; 
	shadowDetailMask = 4; 
	imageType = sawImage; 
	price = 0; 
	showWeaponBar = true; 
}; 
 
function saw::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>SAW - Used to mow down the bad guys.  Light machinegun but fast firing.", 2); 
	} 
} 
// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 




// --------------------------------------extended model info--------------------------------------









ItemImageData sawScopeImage
{
	shapeFile  = "grenadel";
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


ItemData sawScope
{
	heading = "cSecondary Weapons";
	description = "sawScope";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = sawScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData sawClipImage
{
	shapeFile  = "jetpack";
	mountPoint = 0;
	mountRotation = {0, 3.14, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.1, 0.1 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData sawClip
{
	heading = "cSecondary Weapons";
	description = "sawClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = sawClipImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData sawMountImage
{
	shapeFile  = "shotgun";
	mountPoint = 0;
	mountRotation = {0, 0, 3.14 };
	weaponType = 0; // Single Shot
	mountOffset = { 0, 0.0, -0.2 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData sawMount
{
	heading = "cSecondary Weapons";
	description = "sawClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = sawMountImage;
	price = 50;
	showWeaponBar = true;
};

function saw::onMount(%player,%item)
{
	Player::MountItem(%player,sawMount,5);
	Player::MountItem(%player,sawScope,7);
	Player::MountItem(%player,sawClip,6);
}
function saw::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
	Player::UnMountItem(%player,5);
}
