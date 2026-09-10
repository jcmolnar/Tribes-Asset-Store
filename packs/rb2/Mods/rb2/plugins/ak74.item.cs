addPluginWeapon(LaserRifle, Klashnikov); 
$AutoUse[Klashnikov] = true; 
$SellAmmo[Klashnikov] = 50; 
$AmmoPackMax[Klashnikov] = 0; 
$WeaponAmmo[Klashnikov] = KlashnikovAmmo; 
 
$ItemMax[hlarmor, Klashnikov] = 0; 
$ItemMax[hlfemale, Klashnikov] = 0; 
$ItemMax[larmor, Klashnikov] = 1; 
$ItemMax[lfemale, Klashnikov] = 1; 
$ItemMax[earmor, Klashnikov] = 1; 
$ItemMax[efemale, Klashnikov] = 1; 
$ItemMax[marmor, Klashnikov] = 1; 
$ItemMax[mfemale, Klashnikov] = 1; 
$ItemMax[harmor, Klashnikov] = 1; 
$ItemMax[uharmor, Klashnikov] = 1; 
 
$ItemMax[hlarmor, KlashnikovAmmo] = 30; 
$ItemMax[hlfemale, KlashnikovAmmo] = 30; 
$ItemMax[larmor, KlashnikovAmmo] = 30; 
$ItemMax[lfemale, KlashnikovAmmo] = 30; 
$ItemMax[earmor, KlashnikovAmmo] = 30; 
$ItemMax[efemale, KlashnikovAmmo] = 30; 
$ItemMax[marmor, KlashnikovAmmo] = 30; 
$ItemMax[mfemale, KlashnikovAmmo] = 30; 
$ItemMax[harmor, KlashnikovAmmo] = 30; 
$ItemMax[uharmor, KlashnikovAmmo] = 30; 
 
$InvList[Klashnikov] = 1; 
$RemoteInvList[Klashnikov] = 1; 
$InvList[KlashnikovAmmo] = 1; 
$RemoteInvList[KlashnikovAmmo] = 1; 
 
$HelpMessage[Klashnikov] = "An AK74.  Fires 7.62mm rounds that can be quite deadly.  Fairly good accuracy as well."; 
 
 
ItemData KlashnikovAmmo 
{ 
	description = "Klashnikov Ammo"; 
	classname = "Ammo"; 
	shapefile = "mrtwig"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 
 
BulletData KlashnikovBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp0; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.35; 
	damageType = $BulletDmgType22; 
 
	aimDeflection = 0.003; 
	muzzleVelocity = 1000; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = False; 
    	soundId = SoundJetHeavy;
	tracerPercentage = 0.1; 
	tracerLength = 10; 
}; 
 
ItemImageData KlashnikovImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = KlashnikovBullet; 
	ammotype = KlashnikovAmmo; 
	aimDeflection = 0.02; 
	accuFire = True; 
	reloadTime = 0; 
	fireTime = 0.14; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = bigExplosion2; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData Klashnikov 
{ 
	description = "Klashnikov AK74"; 
	className = "PriWeapon"; 
	shapefile = "sniper"; 
	hudIcon = "plasma"; 
	heading = "bPrimary Weapons"; 
	shadowDetailMask = 4; 
	imageType = KlashnikovImage; 
	price = 200; 
	showWeaponBar = true; 
}; 
 
function Klashnikov::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>Klashnikov - Developed by the Russian Military, it's the world's most used machinegun.", 2); 
	} 
} 

ItemImageData KlashnikovScopeImage
{
	shapeFile  = "force";
	mountPoint = 0;
	mountRotation = { 1.5, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.0, 0.0 };

	ammoType = null;
	reloadTime = 0.08;
	fireTime = 0.05;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData KlashnikovScope
{
	heading = "cSecondary Weapons";
	description = "KlashnikovScope";
	className = "Weapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = KlashnikovScopeImage;
	price = 50;
	showWeaponBar = true;
};


function Klashnikov::onMount(%player,%item)
{
	Player::MountItem(%player,KlashnikovScope,7);

}
function Klashnikov::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);

}

$InvList[KlashnikovScope] = 0; 
$RemoteInvList[KlashnikovScope] = 0; 
