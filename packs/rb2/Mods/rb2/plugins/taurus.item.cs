addPluginWeapon(LaserRifle, Taurus); 

$AutoUse[Taurus] = true; 
$SellAmmo[Taurus] = 50; 
$AmmoPackMax[Taurus] = 0; 
$WeaponAmmo[Taurus] = TaurusAmmo; 
 
$ItemMax[hlarmor, Taurus] = 1; 
$ItemMax[hlfemale, Taurus] = 1; 
$ItemMax[larmor, Taurus] = 1; 
$ItemMax[lfemale, Taurus] = 1; 
$ItemMax[earmor, Taurus] = 1; 
$ItemMax[efemale, Taurus] = 1; 
$ItemMax[marmor, Taurus] = 1; 
$ItemMax[mfemale, Taurus] = 1; 
$ItemMax[harmor, Taurus] = 1; 
$ItemMax[uharmor, Taurus] = 1; 
 
$ItemMax[hlarmor, TaurusAmmo] = 6; 
$ItemMax[hlfemale, TaurusAmmo] = 6; 
$ItemMax[larmor, TaurusAmmo] = 6; 
$ItemMax[lfemale, TaurusAmmo] = 6; 
$ItemMax[earmor, TaurusAmmo] = 6; 
$ItemMax[efemale, TaurusAmmo] = 6; 
$ItemMax[marmor, TaurusAmmo] = 6; 
$ItemMax[mfemale, TaurusAmmo] = 6; 
$ItemMax[harmor, TaurusAmmo] = 6; 
$ItemMax[uharmor, TaurusAmmo] = 6; 
 
$InvList[Taurus] = 1; 
$RemoteInvList[Taurus] = 1; 
$InvList[TaurusAmmo] = 1; 
$RemoteInvList[TaurusAmmo] = 1; 
 
$HelpMessage[Taurus] = "A 6 shot revolver capable of dealing some serious damage"; 
 
 
ItemData TaurusAmmo 
{ 
	description = "Taurus Ammo"; 
	classname = "Ammo"; 
	shapefile = "larmor"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 
 
BulletData TaurusBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp0; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.8; 
	damageType = $BulletDmgType23;
     	soundId = SoundJetHeavy;
	aimDeflection = 0.0095; 
	muzzleVelocity = 1000; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.5; 
	isVisible = False; 
 
	tracerPercentage = 0.0; 
	tracerLength = 0; 
}; 
 
ItemImageData TaurusImage 
{ 
	shapeFile = "energygun"; 
	mountPoint = 0; 
 	mountOffset = { -0.0, 0.1, 0.0 };
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = TaurusBullet; 
	ammotype = TaurusAmmo; 
	aimDeflection = 0.01; 
	accuFire = True; 
	reloadTime = 0; 
	fireTime = 0.5; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData Taurus 
{ 
	description = "Taurus 44 magnum"; 
	className = weapon; 
	shapefile = "energygun"; 
	hudIcon = "targetlaser"; 
	heading = "cSecondary Weapons"; 
	shadowDetailMask = 4; 
	imageType = TaurusImage; 
	price = 200; 
	showWeaponBar = true; 
}; 
 
function Taurus::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>Using Taurus 44 mag - A snubnosed revolver that can punch completely through a few people without stopping", 2); 
	} 
} 
