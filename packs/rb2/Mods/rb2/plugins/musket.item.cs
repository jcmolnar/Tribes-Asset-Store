// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
 
addPluginWeapon(LaserRifle, Musket); 
$AutoUse[Musket] = true; 
$SellAmmo[Musket] = 50; 
$AmmoPackMax[Musket] = 0; 
$WeaponAmmo[Musket] = MusketAmmo; 
 
$ItemMax[hlarmor, Musket] = 0; 
$ItemMax[hlfemale, Musket] = 0; 
$ItemMax[larmor, Musket] = 1; 
$ItemMax[lfemale, Musket] = 1; 
$ItemMax[earmor, Musket] = 1; 
$ItemMax[efemale, Musket] = 1; 
$ItemMax[marmor, Musket] = 1; 
$ItemMax[mfemale, Musket] = 1; 
$ItemMax[harmor, Musket] = 1; 
$ItemMax[uharmor, Musket] = 1; 
 
$ItemMax[hlarmor, MusketAmmo] = 50; 
$ItemMax[hlfemale, MusketAmmo] = 50; 
$ItemMax[larmor, MusketAmmo] = 50; 
$ItemMax[lfemale, MusketAmmo] = 50; 
$ItemMax[earmor, MusketAmmo] = 50; 
$ItemMax[efemale, MusketAmmo] = 50; 
$ItemMax[marmor, MusketAmmo] = 50; 
$ItemMax[mfemale, MusketAmmo] = 50; 
$ItemMax[harmor, MusketAmmo] = 50; 
$ItemMax[uharmor, MusketAmmo] = 50; 
 
$InvList[Musket] = 1; 
$RemoteInvList[Musket] = 1; 
$InvList[MusketAmmo] = 1; 
$RemoteInvList[MusketAmmo] = 1; 
 
$HelpMessage[Musket] = "An obsolete muzzle-loaded rifle that takes forever to reload.  Use this weapon for point racking."; 
 
 
ItemData MusketAmmo 
{ 
	description = "Musket Loads"; 
	classname = "Ammo"; 
	shapefile = "tracer"; 
	heading = "xammunition"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 
 
BulletData MusketBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = BigBulletExp; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.85; 
	damageType = $BulletDmgType29;
     	soundId = SoundJetHeavy;
	aimDeflection = 0.001; 
	muzzleVelocity = 600; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = True; 
 
	tracerPercentage = 0.0; 
	tracerLength = 10; 
}; 
 
ItemImageData MusketImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = MusketBullet; 
	ammotype = MusketAmmo; 
	aimDeflection = 0.001; 
	accuFire = True; 
	reloadTime = 1; 
	fireTime = 6; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = bigExplosion4; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData Musket 
{ 
	description = "Musket"; 
	className = "Priweapon"; 
	shapefile = "sniper"; 
	hudIcon = "sniper"; 
	heading = "bPrimary Weapons"; 
	shadowDetailMask = 4; 
	imageType = MusketImage; 
	price = 0; 
	showWeaponBar = true; 
}; 
 
function Musket::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		bottomprint(Player::getClient(%player), "<jc><f2>Musket - The red coats are coming!  The red coats are coming!!! \n This weapon is extremely hard to use, and takes forever to reload.  Only use it if you're good.", 4); 
	} 
} 

function Musket::onDrop(%player,%item)
{

// messageall(1, %player @ " " @ %item @ " dropped " @ %this);

Player::setItemCount(%player, %item, 0);
Player::UnMountItem(%player,$weaponslot);
Player::setItemCount(GameBase::getControlClient(%player), %item, 0);

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rndx = (getRandom() * 15) - 15;
	%rndy = (getRandom() * 15) - 15;
	%rndz =(getRandom() * 25);
	Projectile::spawnProjectile("MuskettossProj",%trans,%player, %rndx @ " " @ %rndy @ " " @ %rndz);

}

// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
