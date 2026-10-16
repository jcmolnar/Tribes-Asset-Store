//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Rocket);
$InvList[Rocket] = 1;
$InvList[RPGAmmo] = 1;

$SellAmmo[RPGAmmo] = 10;
$AutoUse[Rocket] = True;
$WeaponAmmo[Rocket] = RPGAmmo;

$ItemMax[larmor, Rocket] = 0;		//Seraph
$ItemMax[lfemale, Rocket] = 0;		//Seraph
$ItemMax[earmor, Rocket] = 1;		//Slave
$ItemMax[efemale, Rocket] = 1;		//Slave
$ItemMax[marmor, Rocket] = 1;		//Pawn
$ItemMax[aarmor, Rocket] = 0;		//Navigator
$ItemMax[darmor, Rocket] = 1;		//Atomizer
$ItemMax[barmor, Rocket] = 0;		//Paladin

$ItemMax[larmor, RPGAmmo] = 0;		//Seraph
$ItemMax[lfemale, RPGAmmo] = 0;		//Seraph
$ItemMax[earmor, RPGAmmo] = 10;		//Slave
$ItemMax[efemale, RPGAmmo] = 10;	//Slave
$ItemMax[marmor, RPGAmmo] = 20;		//Pawn
$ItemMax[aarmor, RPGAmmo] = 0;		//Navigator
$ItemMax[darmor, RPGAmmo] = 20;		//Atomizer
$ItemMax[barmor, RPGAmmo] = 0;		//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

RocketData RPGrenade
{	bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.5;
	damageType = $ExplosionDamageType;
	explosionRadius = 20.5;
	kickBackStrength = 300.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 2000.0;
	acceleration = 200.0;
	totalTime = 8.5;
	liveTime = 18.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};



ItemData RPGAmmo
{
	description = "Grenade Rockets";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData RocketImage 
{	shapeFile = "mortargun";
	mountRotation = { 0, 0.785, 0 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = RPGAmmo;
	projectileType = RPGrenade;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;//SoundFireFlierRocket
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Rocket
{	description = "RPG Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 77;
	showWeaponBar = true;
};


function Rocket::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "<jc><f2>RPG Launcher");
}