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
   damageValue        = 3;
   damageType         = $MortarDamageType;

   explosionRadius    = 100;
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
	reloadTime = 1;
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
	description = "Heavy Decoy Launcher";
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
	bottomprint(Player::getClient(%player), "The Heavy Decoy Launcher....Fool your enemies into investigating it...then watch them go boom!!! Man, this one is twice as strong as the Medium Armor Decoy and you can tell....Packed with C-4, run cause you got  40 Seconds till detonation...", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$InvList[BlasterD] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[BlasterD] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

//--------------------------------------

RocketData BlasterBoltd
{
   bulletShapeName = "paint.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.40;
   damageType       = $BlasterDamageType;

   explosionRadius  = 40.5;
   kickBackStrength = 100.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 600.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionex.dts";
   smokeDist   = 50.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------
ItemImageData BlasterImaged
{
   ShapeFile  = "EnergyGun";
	mountPoint = 0;
	mountoffset = { -0.2, 0.0, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { 0, 0.3, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	reloadTime = 0.6;
	fireTime = 0;
	minEnergy = 40;
	maxEnergy = 50;

	projectileType = BlasterBoltd;
	accuFire = False;

	sfxFire = SoundTankCrash;
	sfxActivate = SoundPickUpWeapon;
};


ItemData BlasterD
{
   heading = "fPlasma Guns";
	description = "Anti-UFO Gun";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImageD;
	price = 185;
	showWeaponBar = true;
};

//--------------------------------------
function Blasterd::onUse(%Client,%item)
{
	bottomprint(Player::getClient(%Client), "This gun was made to only effect non human.....hmmm i am not sure if it will help you much...I mean what aliens would just be flying around outside your base", 10);Weapon::onUse(%Client,%item);
}