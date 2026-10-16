///Bunker Thumper

RocketData BazookaShell
{	bulletShapeName = "mortar.dts";
	explosionTag = BazookaExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 5.0;
	damageType = $BlasterDamageType;
	explosionRadius = 6.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 4.0;
	liveTime = 5.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "snowplume.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};


ItemData BunkerAmmo
{
	description = "Bunker Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData Bazooka1Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Bazooka1
{
	description = "Bazooka1";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = Bazooka1Image;
	showWeaponBar = false;
};

ItemImageData Bazooka2Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Bazooka2
{
	description = "Bazooka2";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = Bazooka2Image;
	showWeaponBar = false;
};


ItemImageData BunkerImage
{
	shapeFile = "mortar";
	mountPoint = 0;
	mountOffset = { 0, 0.6, 0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	ammoType = BunkerAmmo;
	projectileType = BazookaShell;
	accuFire = false;
	reloadTime = 3.0;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Bunker
{
	description = "AWTP Bunker Thumper";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = BunkerImage;
	price = 0;
	showWeaponBar = true;
   validateShape = true;
};

function Bunker::onMount(%player,%item)
{
	Player::mountItem(%player,bazooka2,7);
	Player::mountItem(%player,bazooka1,6);
}

function Bunker::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
}

//Important Stuff
$ItemMax[larmor, Bunker] = 1;
$ItemMax[larmor, BunkerAmmo] = 6;
$ItemMax[lfemale, Bunker] = 1;
$ItemMax[lfemale, BunkerAmmo] = 6;
$InvList[Bunker] = 1;
$InvList[BunkerAmmo] = 0;	