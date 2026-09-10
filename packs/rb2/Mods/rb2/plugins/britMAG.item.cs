// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
 
addPluginWeapon(LaserRifle, britMag); 
$AutoUse[britMag] = true; 
$SellAmmo[britMag] = 50; 
// $AmmoPackMax[britMagAmmo] = 100; 
$WeaponAmmo[britMag] = britMagAmmo; 
 
$ItemMax[hlarmor, britMag] = 0; 
$ItemMax[hlfemale, britMag] = 0; 
$ItemMax[larmor, britMag] = 0; 
$ItemMax[lfemale, britMag] = 0; 
$ItemMax[earmor, britMag] = 0; 
$ItemMax[efemale, britMag] = 0; 
$ItemMax[marmor, britMag] = 0; 
$ItemMax[mfemale, britMag] = 0; 
$ItemMax[harmor, britMag] = 1; 
$ItemMax[uharmor, britMag] = 1; 
 
$ItemMax[hlarmor, britMagAmmo] = 50; 
$ItemMax[hlfemale, britMagAmmo] = 50; 
$ItemMax[larmor, britMagAmmo] = 50; 
$ItemMax[lfemale, britMagAmmo] = 50; 
$ItemMax[earmor, britMagAmmo] = 50; 
$ItemMax[efemale, britMagAmmo] = 50; 
$ItemMax[marmor, britMagAmmo] = 50; 
$ItemMax[mfemale, britMagAmmo] = 50; 
$ItemMax[harmor, britMagAmmo] = 100; 
$ItemMax[uharmor, britMagAmmo] = 100; 
 
$InvList[britMag] = 1; 
$RemoteInvList[britMag] = 1; 
$InvList[britMagAmmo] = 1; 
$RemoteInvList[britMagAmmo] = 1; 
 
$HelpMessage[britMag] = "Heavy machinegun designed to take out light aircraft.  Fires heavy 7.62mm-HE rounds"; 
 
 
ItemData britMagAmmo 
{ 
	description = "M177 Ammo"; 
	classname = "Ammo"; 
	shapefile = "ammopack"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 
 
BulletData britMagBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = BritBulletExp; 
	mass = 0.05; 
	damageClass = 1; 
   	explosionRadius = 5;
	damageValue = 0.5; 
	damageType = $BulletDmgType24;
     	soundId = SoundJetHeavy;
	aimDeflection = 0.0035; 
	muzzleVelocity = 300; 
	totaltime = 4.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = True; 
 
	tracerPercentage = 1.0; 
	tracerLength = 100; 
}; 

ItemImageData britMagImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = britMagBullet; 
	ammotype = britMagAmmo; 
	aimDeflection = 0.008; 
	accuFire = True;
	reloadTime = 0; 
	fireTime = 0.13; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = shockExplosion; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData britMag 
{ 
	description = "M177 AA Machinegun"; 
	className = "Priweapon"; 
	shapefile = "sniper"; 
	hudIcon = "deployable"; 
	heading = "bPrimary Weapons"; 
	shadowDetailMask = 4; 
	imageType = britMagImage; 
	price = 0; 
	showWeaponBar = true; 
}; 
 
function britMag::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>M177 Anti vehicle weapon.  Good against vehicles, bad against ground troops..", 2); 
	} 
} 

function britMAG::onMount(%player,%item)
{
	Player::MountItem(%player,britMAGScope,7);
	Player::MountItem(%player,britMAGClip,6);
}
function britMAG::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}





// --------------------------------------extended model info--------------------------------------









ItemImageData britMAGScopeImage
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


ItemData britMAGScope
{
	heading = "cSecondary Weapons";
	description = "britMAGScope";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = britMAGScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData britMAGClipImage
{
	shapeFile  = "energygun";
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

ItemData britMAGClip
{
	heading = "cSecondary Weapons";
	description = "britMAGClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = britMAGClipImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData britMAGMountImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	mountRotation = {0, 0, 3.14 };
	weaponType = 0; // Single Shot
	mountOffset = { 0, 0.0, 0.1 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData britMAGMount
{
	heading = "cSecondary Weapons";
	description = "britMAGClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = britMAGMountImage;
	price = 50;
	showWeaponBar = true;
};

function britMAG::onMount(%player,%item)
{
	Player::MountItem(%player,britMAGMount,5);
	Player::MountItem(%player,britMAGScope,7);
	Player::MountItem(%player,britMAGClip,6);
}
function britMAG::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
	Player::UnMountItem(%player,5);
}

$InvList[britMagMount] = 0; 
$RemoteInvList[britMagMount] = 0; 
$InvList[britMagScope] = 0; 
$RemoteInvList[britMagScope] = 0; 
$InvList[britMagClip] = 0; 
$RemoteInvList[britMagClip] = 0; 