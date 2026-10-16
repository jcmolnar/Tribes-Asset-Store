//--------------------------------------

ExplosionData MultiBoom
{
	shapeName = "plasmaex.dts";
	soundId   = debrisSmallExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 5.0;
	timeScale = 1.5;
	timeZero = 0.150;
	timeOne  = 0.500;

	colors[0]  = { 1.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 0.0, 0.0 };
	colors[2]  = { 1.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.0, 0.0 };
};

BulletData MultiBolt
{
	bulletShapeName    = "rocket.dts";
	explosionTag       = MultiBoom;
	mass               = 0.75;
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.5;
	damageType         = $MultiDamageType;
	aimDeflection      = 0.005;
	muzzleVelocity     = 70.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 0.75;
	isVisible          = True;
	rotationPeriod     = 2.5;
};

ItemData MultiAmmo
{
	description = "3 Stingers";
	className = "Ammo";
	shapeFile = "mortarammo";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 300;
};

ItemImageData M1Image
{
	shapeFile = "grenadeL";
	mountPoint = 0; 
	mountOffset = { -0.1, 0.0, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -2.25, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	ammoType = MultiAmmo;
	projectileType = MultiBolt;
	reloadTime = 0.5;
	fireTime = 0.3;
	accuFire = false;
};

ItemData M1
{
	description = "M1";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = M1Image;
	showWeaponBar = false;
};

ItemImageData M2Image
{
	shapeFile = "grenadeL";
	mountPoint = 0; 
	mountOffset = { 0.1, 0.0, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 2.25, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	ammoType = MultiAmmo;
	projectileType = MultiBolt;
	reloadTime = 0.5;
	fireTime = 0.3;
	accuFire = false;
};

ItemData M2
{
	description = "M2";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = M2Image;
	showWeaponBar = false;
};

ItemImageData MultiImage
{
	shapeFile = "grenadeL";
	mountPoint = 0; 
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	reloadTime = 0.6;
	fireTime = 0.3;
	ammoType = MultiAmmo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = bigExplosion2;
	sfxActivate = SoundMortarReload;
};

ItemData Multi
{
	description = "Multi-Rocket";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "chain";
   	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = MultiImage;
	price = 900;
	showWeaponBar = true;
};

function Multi::onMount(%player,%item)
{
	Player::mountItem(%player,M1,7);
	Player::mountItem(%player,M2,6);
}

function Multi::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
}

function MultiImage::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player,"MultiAmmo");
	if(%AmmoCount > 0) {
		Weapon::onFire(%player,MultiBolt);
		Player::trigger(%player,6,true);
		Player::trigger(%player,7,true);
		Player::trigger(%player,6,false);
		Player::trigger(%player,7,false);
	}
}

//--------------------------------------------------------------------------------
// INVENTORY STUFF
//--------------------------------------------------------------------------------

$ItemMax[larmor, Multi] = 0;
$ItemMax[qarmor, Multi] = 0;
$ItemMax[srarmor, Multi] = 0;
$ItemMax[sarmor, Multi] = 0;
$ItemMax[marmor, Multi] = 1;
$ItemMax[parmor, Multi] = 0;

$ItemMax[harmor, Multi] = 1;
$ItemMax[tarmor, Multi] = 1;

$ItemMax[lfemale, Multi] = 0;
$ItemMax[qfemale, Multi] = 0;
$ItemMax[srfemale, Multi] = 0;
$ItemMax[sfemale, Multi] = 0;
$ItemMax[mfemale, Multi] = 1;
$ItemMax[pfemale, Multi] = 0;

$ItemMax[larmor, MultiAmmo] = 4;
$ItemMax[qarmor, MultiAmmo] = 10;
$ItemMax[srarmor, MultiAmmo] = 0;
$ItemMax[sarmor, MultiAmmo] = 4;
$ItemMax[marmor, MultiAmmo] = 10;
$ItemMax[parmor, MultiAmmo] = 10;

$ItemMax[harmor, MultiAmmo] = 20;
$ItemMax[tarmor, MultiAmmo] = 20;

$ItemMax[lfemale, MultiAmmo] = 4;
$ItemMax[qfemale, MultiAmmo] = 10;
$ItemMax[srfemale, MultiAmmo] = 0;
$ItemMax[sfemale, MultiAmmo] = 4;
$ItemMax[mfemale, MultiAmmo] = 10;
$ItemMax[pfemale, MultiAmmo] = 10;

$AutoUse[Multi] = True;
$SellAmmo[MultiAmmo] = 2;
$InvList[Multi] = 1;
$RemoteInvList[Multi] = 1;
$InvList[MultiAmmo] = 1;
$RemoteInvList[MultiAmmo] = 1;

