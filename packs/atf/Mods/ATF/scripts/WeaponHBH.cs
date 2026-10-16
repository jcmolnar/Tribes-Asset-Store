//--------------------------------------

$AutoUse[HBH] = True;
$SellAmmo[GrenadeAmmo] = 5;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackItems[3] = GrenadeAmmo;
$WeaponAmmo[HBH] = GrenadeAmmo;
//--------------------------------------

$InvList[HBH] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[HBH] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

//--------------------------------------

GrenadeData HumanHeavy
{
   bulletShapeName    = "Harmor.dts";
   explosionTag       = Rocketexp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 5;
   damageType         = $MortarDamageType;

   explosionRadius    = 200;
   kickBackStrength   = 800.0;
   maxLevelFlightDist = 400;
   totalTime          = 140.0;    // special meaning for grenades...
   liveTime           = 40.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.9;

   smokeName              = "PlasmaTrail.dts";
};
//--------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData HBHImage
{
	shapeFile = "MortarGun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = HumanHeavy;
	accuFire = false;
	reloadTime = 9;
	fireTime = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData HBH
{
	description = "H Decoy Launcher";
	className = "Weapon";
	shapeFile = "MortarGun";
	hudIcon = "grenade";
   heading = "eTrajectoryGuns";
	shadowDetailMask = 4;
	imageType = HBHImage;
	price = 1050;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function HBH::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Heavy Armor Decoy Launcher....Fool your enemies into investigating it...then watch them go boom!!! Man, this one is twice as strong as the Medium Armor Decoy and you can tell....Packed with C-4, run cause you got  40 Seconds till detonation...", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$InvList[BlasterD] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[BlasterD] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

//--------------------------------------


GrenadeData BlasterBoltDBoost
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 10;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};



GrenadeData BlasterBoltDllll
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 10;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.1;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.3;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};


GrenadeData BlasterBoltDlllll
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 10;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.3;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5;
   maxLevelFlightDist = 0;
   totalTime          = 0.5;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};

GrenadeData BlasterBoltDllllll
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 10.7;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.7;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};

GrenadeData BlasterBoltDlllllll
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 10;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.9;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.9;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};



GrenadeData BlasterBoltDlll
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 10;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.1;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};


GrenadeData BlasterBoltD
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 10;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.3;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5;
   maxLevelFlightDist = 0;
   totalTime          = 0.3;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};

GrenadeData BlasterBoltDL
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 10;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.5;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 0;
   totalTime          = 1.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};

GrenadeData BlasterBoltDLL
{
   bulletShapeName    = "PlasmaEx.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 10;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.7;
   damageType         = $MachDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 0;
   totalTime          = 1.7;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};

//--------------------------------------
ItemImageData BlasterImaged
{
   ShapeFile  = "PlasmaEx";
	 mass = 10.0;
	mountPoint = 0;
	mountoffset = { -0.2, 0.0, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { 0, 0.3, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	reloadTime = 0.1;
	fireTime = 0.3;
	minEnergy = 10;
	maxEnergy = 20;

	projectileType = MrHand;
	accuFire = False;

	sfxFire = SoundTankActive;
	sfxActivate = SoundPickUpWeapon;
};

function BlasterImaged::onFire(%player, %slot)
{
if (GameBase::getEnergy(%player) > 5)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	%rndCheck=Floor(getRandom()*20);
		Projectile::spawnProjectile("BlasterBoltd",%transform,%player,%velocity); 
		 Projectile::spawnProjectile("BlasterBoltdl",%transform,%player,%velocity); 
		 Projectile::spawnProjectile("BlasterBoltdlll",%transform,%player,%velocity); 
		Projectile::spawnProjectile("BlasterBoltdll",%transform,%player,%velocity);
		Projectile::spawnProjectile("BlasterBoltdllll",%transform,%player,%velocity); 
		 Projectile::spawnProjectile("BlasterBoltdllll",%transform,%player,%velocity); 
		 Projectile::spawnProjectile("BlasterBoltdlllll",%transform,%player,%velocity); 
		Projectile::spawnProjectile("BlasterBoltdllllll",%transform,%player,%velocity);
		Projectile::spawnProjectile("BlasterBoltdBoost",%transform,%player,%velocity);
		GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 5);

	}
}


ItemData BlasterD
{
   heading = "fPlasma Guns";
	description = "Mach Boost";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImageD;
	price = 285;
	showWeaponBar = true;
};

//--------------------------------------
function Blasterd::onUse(%Client,%item)
{
	bottomprint(Player::getClient(%Client), "This weapon can only be used by Mach 5 armor.....As you run hold down fire to recieve a speed boost....and anyone near you will be damaged :)", 10);Weapon::onUse(%Client,%item);
}