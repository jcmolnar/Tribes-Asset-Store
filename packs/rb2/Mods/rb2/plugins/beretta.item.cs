// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
 
addPluginWeapon(LaserRifle, berettaSMG); 
$AutoUse[berettaSMG] = true; 
$SellAmmo[berettaSMG] = 50; 
$AmmoPackMax[berettaSMG] = 0; 
$WeaponAmmo[berettaSMG] = berettaSMGAmmo; 
 
$ItemMax[hlarmor, berettaSMG] = 1; 
$ItemMax[hlfemale, berettaSMG] = 1; 
$ItemMax[larmor, berettaSMG] = 1; 
$ItemMax[lfemale, berettaSMG] = 1; 
$ItemMax[earmor, berettaSMG] = 1; 
$ItemMax[efemale, berettaSMG] = 1; 
$ItemMax[marmor, berettaSMG] = 1; 
$ItemMax[mfemale, berettaSMG] = 1; 
$ItemMax[harmor, berettaSMG] = 1; 
$ItemMax[uharmor, berettaSMG] = 1; 
 
$ItemMax[hlarmor, berettaSMGAmmo] = 30; 
$ItemMax[hlfemale, berettaSMGAmmo] = 30; 
$ItemMax[larmor, berettaSMGAmmo] = 30; 
$ItemMax[lfemale, berettaSMGAmmo] = 30; 
$ItemMax[earmor, berettaSMGAmmo] = 30; 
$ItemMax[efemale, berettaSMGAmmo] = 30; 
$ItemMax[marmor, berettaSMGAmmo] = 30; 
$ItemMax[mfemale, berettaSMGAmmo] = 30; 
$ItemMax[harmor, berettaSMGAmmo] = 30; 
$ItemMax[uharmor, berettaSMGAmmo] = 30; 
 
$InvList[berettaSMG] = 1; 
$RemoteInvList[berettaSMG] = 1; 
$InvList[berettaSMGAmmo] = 1; 
$RemoteInvList[berettaSMGAmmo] = 1; 
 
$HelpMessage[berettaSMG] = "An Italian submachinegun that fires 9mm rounds"; 
 
 
ItemData berettaSMGAmmo 
{ 
	description = "Beretta M12 Ammo"; 
	classname = "Ammo"; 
	shapefile = "plasammo"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 0; 
}; 
 
BulletData berettaSMGBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp0; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.15; 
	damageType = $BulletDmgType26;
 
	aimDeflection = 0.01; 
	muzzleVelocity = 1000; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = False; 
     	soundId = SoundJetHeavy;
	tracerPercentage = 0.0; 
	tracerLength = 10; 
}; 
 
ItemImageData berettaSMGImage 
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = berettaSMGBullet; 
	mountOffset = { -0.0, 0.3, -0.0 };
	ammotype = berettaSMGAmmo; 
	aimDeflection = 0.0035; 
	accuFire = True; 
	reloadTime = 0; 
	fireTime = 0.08; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = shockExplosion; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData berettaSMG 
{ 
	description = "Beretta M12 SMG"; 
	className = "Priweapon";
	shapefile = "paintgun"; 
	hudIcon = "chain"; 
	heading = "bPrimary Weapons"; 
	shadowDetailMask = 4; 
	imageType = berettaSMGImage; 
	price = 0; 
	showWeaponBar = true; 
}; 
 
function berettaSMG::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>Beretta M12 SMG - A good all-around submachine gun", 2); 
	} 
} 
// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 


ItemImageData berettaSMGScopeImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.0, -0.0 };

	ammoType = berettaSMGAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};


ItemData berettaSMGScope
{
	heading = "cSecondary Weapons";
	description = "berettaSMGScope";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = berettaSMGScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData berettaSMGClipImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	mountRotation = {3.1, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.1, 0.0 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData berettaSMGClip
{
	heading = "cSecondary Weapons";
	description = "berettaSMGClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = berettaSMGClipImage;
	price = 50;
	showWeaponBar = true;
};

function berettaSMG::onMount(%player,%item)
{
	Player::MountItem(%player,berettaSMGScope,7);
	Player::MountItem(%player,berettaSMGClip,6);
}
function berettaSMG::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}

 
$InvList[berettaSMGScope] = 0; 
$RemoteInvList[berettaSMGScope] = 0; 
$InvList[berettaSMGClip] = 0; 
$RemoteInvList[berettaSMGClip] = 0; 
