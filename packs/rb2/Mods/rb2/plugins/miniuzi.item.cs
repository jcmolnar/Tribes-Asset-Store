// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
 
addPluginWeapon(LaserRifle, MiniUzi); 
$AutoUse[MiniUzi] = true; 
$SellAmmo[MiniUzi] = 50; 
$AmmoPackMax[MiniUzi] = 0; 
$WeaponAmmo[MiniUzi] = MiniUziAmmo; 
 
$ItemMax[hlarmor, MiniUzi] = 1; 
$ItemMax[hlfemale, MiniUzi] = 1; 
$ItemMax[larmor, MiniUzi] = 1; 
$ItemMax[lfemale, MiniUzi] = 1; 
$ItemMax[earmor, MiniUzi] = 1; 
$ItemMax[efemale, MiniUzi] = 1; 
$ItemMax[marmor, MiniUzi] = 1; 
$ItemMax[mfemale, MiniUzi] = 1; 
$ItemMax[harmor, MiniUzi] = 1; 
$ItemMax[uharmor, MiniUzi] = 1; 
 
$ItemMax[hlarmor, MiniUziAmmo] = 20; 
$ItemMax[hlfemale, MiniUziAmmo] = 20; 
$ItemMax[larmor, MiniUziAmmo] = 20; 
$ItemMax[lfemale, MiniUziAmmo] = 20; 
$ItemMax[earmor, MiniUziAmmo] = 20; 
$ItemMax[efemale, MiniUziAmmo] = 20; 
$ItemMax[marmor, MiniUziAmmo] = 20; 
$ItemMax[mfemale, MiniUziAmmo] = 20; 
$ItemMax[harmor, MiniUziAmmo] = 20; 
$ItemMax[uharmor, MiniUziAmmo] = 20; 
 
$InvList[MiniUzi] = 1; 
$RemoteInvList[MiniUzi] = 1; 
$InvList[MiniUziAmmo] = 1; 
$RemoteInvList[MiniUziAmmo] = 1; 
 
$HelpMessage[MiniUzi] = "A compact version of the well known Uzi"; 
 
 
ItemData MiniUziAmmo 
{ 
	description = "Mini Uzi Ammo"; 
	classname = "Ammo"; 
	shapefile = "plasammo"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 0; 
}; 
 
BulletData MiniUziBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp0; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.15; 
	damageType = $BulletDmgType27;
     	soundId = SoundJetHeavy;
	aimDeflection = 0.018; 
	muzzleVelocity = 1000; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = False; 
 
	tracerPercentage = 0.0; 
	tracerLength = 10; 
}; 
 
ItemImageData MiniUziImage 
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
 	mountOffset = { -0.0, 0.1, -0.0 };
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = MiniUziBullet; 
	ammotype = MiniUziAmmo; 
	aimDeflection = 0.01; 
	accuFire = True; 
	reloadTime = 0; 
	fireTime = 0.04; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = shockExplosion; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData MiniUzi 
{ 
	description = "Mini Uzi"; 
	className = weapon; 
	shapefile = "rocket"; 
	hudIcon = "chain"; 
	heading = "cSecondary Weapons"; 
	shadowDetailMask = 4; 
	imageType = MiniUziImage; 
	price = 0; 
	showWeaponBar = true; 
}; 
 
function MiniUzi::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>Mini Uzi - Isn't exactly an accurate weapon, but at least it paints the sky lead gray.", 2); 
	} 
} 
// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 

// ---------extra model info -------------

ItemImageData MiniUziScopeImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	mountRotation = { 0, 0, 3.14 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.2, -0.1 };

	ammoType = MiniUziAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData MiniUziScope
{
	heading = "cSecondary Weapons";
	description = "MiniUziScope";
	className = "Weapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = MiniUziScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData MiniUziClipImage
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

ItemData MiniUziClip
{
	heading = "cSecondary Weapons";
	description = "MiniUziClip";
	className = "Weapon";
	shapeFile  = "grenadel";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = MiniUziClipImage;
	price = 50;
	showWeaponBar = true;
};

function MiniUzi::onMount(%player,%item)
{
	Player::MountItem(%player,MiniUziScope,7);
	Player::MountItem(%player,MiniUziClip,6);
}
function MiniUzi::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}
