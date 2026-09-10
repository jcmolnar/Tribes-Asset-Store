// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
 
addPluginWeapon(LaserRifle, ingram); 
$AutoUse[ingram] = true; 
$SellAmmo[ingram] = 50; 
$AmmoPackMax[ingram] = 0; 
$WeaponAmmo[ingram] = ingramAmmo; 
 
$ItemMax[hlarmor, ingram] = 1; 
$ItemMax[hlfemale, ingram] = 1; 
$ItemMax[larmor, ingram] = 1; 
$ItemMax[lfemale, ingram] = 1; 
$ItemMax[earmor, ingram] = 1; 
$ItemMax[efemale, ingram] = 1; 
$ItemMax[marmor, ingram] = 1; 
$ItemMax[mfemale, ingram] = 1; 
$ItemMax[harmor, ingram] = 1; 
$ItemMax[uharmor, ingram] = 1; 
 
$ItemMax[hlarmor, ingramAmmo] = 32; 
$ItemMax[hlfemale, ingramAmmo] = 32; 
$ItemMax[larmor, ingramAmmo] = 32; 
$ItemMax[lfemale, ingramAmmo] = 32; 
$ItemMax[earmor, ingramAmmo] = 32; 
$ItemMax[efemale, ingramAmmo] = 32; 
$ItemMax[marmor, ingramAmmo] = 32; 
$ItemMax[mfemale, ingramAmmo] = 32; 
$ItemMax[harmor, ingramAmmo] = 32; 
$ItemMax[uharmor, ingramAmmo] = 32; 
 
$InvList[ingram] = 1; 
$RemoteInvList[ingram] = 1; 
$InvList[ingramAmmo] = 1; 
$RemoteInvList[ingramAmmo] = 1; 
 
$HelpMessage[ingram] = "A very compact submachinegun that sprays 9mm bullets everywhere"; 
 
 
ItemData ingramAmmo 
{ 
	description = "Ingram Ammo"; 
	classname = "Ammo"; 
	shapefile = "plasammo"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 0; 
}; 
 
BulletData ingramBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp0; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.15; 
	damageType = $BulletDmgType25;
     	soundId = SoundJetHeavy;
	aimDeflection = 0.015; 
	muzzleVelocity = 1000; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = True; 
 
	tracerPercentage = 0.1; 
	tracerLength = 10; 
}; 
 
ItemImageData ingramImage 
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
 	mountOffset = { -0.0, 0.20, -0.0 };
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = ingramBullet; 
	ammotype = ingramAmmo; 
	aimDeflection = 0.014; 
	accuFire = True; 
	reloadTime = 0; 
	fireTime = 0.05; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = debrisMediumExplosion; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData ingram 
{ 
	description = "Ingram MAC 10"; 
	className = "priweapon"; 
	shapefile = "paintgun"; 
	hudIcon = "chain"; 
	heading = "bPrimary Weapons"; 
	shadowDetailMask = 4; 
	imageType = ingramImage; 
	price = 0; 
	showWeaponBar = true; 
}; 
 
function ingram::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>Ingram MAC 10 - Great for up close and personal lead injections", 2); 
	} 
} 
// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 


// ---------extra model info -------------

ItemImageData ingramScopeImage
{
	shapeFile  = "repairgun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.15, -0.0 };

	ammoType = ingramAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ingramScope
{
	heading = "cSecondary Weapons";
	description = "ingramScope";
	className = "Weapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ingramScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData ingramClipImage
{
	shapeFile  = "breath";
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

ItemData ingramClip
{
	heading = "cSecondary Weapons";
	description = "ingramClip";
	className = "Weapon";
	shapeFile  = "grenadel";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ingramClipImage;
	price = 50;
	showWeaponBar = true;
};

function ingram::onMount(%player,%item)
{
	Player::MountItem(%player,ingramScope,7);
	Player::MountItem(%player,ingramClip,6);
}
function ingram::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}
