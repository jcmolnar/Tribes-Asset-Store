//--------------------------------------

RocketData BlastCBlast
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $PCDamageType;

   explosionRadius  = 8.5;
   kickBackStrength = 150.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmaex.dts";
   smokeDist   = 7.0;

   soundId = SoundJetHeavy;
};

//--------------------------------------

ItemImageData BlastC1Image
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.1}; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	projectiletype = BlastCBlast;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.7;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundWeaponSelect;
};

ItemData BlastC1
{
	description = "Blast Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "reticle";
   	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = BlastC1Image;
	price = 175;
	showWeaponBar = true;
};

ItemImageData BlastC2Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { -0.1, 0, 0.05 }; //- left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.7;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundWeaponSelect;
};

ItemData BlastC2
{
	description = "Blast Part2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = BlastC2Image;
	showWeaponBar = false;
};

function BlastC2Image::onFire(%player, %slot)
{
	Gamebase::setEnergy(%player,Gamebase::getEnergy(%player)-10);
	Weapon::onFire(%player,LaserPointer);
}

ItemImageData BlastC3Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0.1, 0, 0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-rightleft-right
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.7;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundWeaponSelect;
};

ItemData BlastC3
{
	description = "Blast Part3";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = BlastC3Image;
	showWeaponBar = false;
};

function BlastC3Image::onFire(%player, %slot)
{
	Gamebase::setEnergy(%player,Gamebase::getEnergy(%player)-10);
	Weapon::onFire(%player,LaserPointer);
}

ItemImageData BlastC4Image
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0}; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	projectiletype = BlastCBlast;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.7;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundWeaponSelect;
};

ItemData BlastC4
{
	description = "Blast Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "reticle";
   	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = BlastC4Image;
	price = 175;
	showWeaponBar = true;
};

ItemImageData BlastCImage
{
	shapeFile = "breath";
	mountPoint = 0;
	mountOffset = { 0, 0, 0}; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	accuFire = false;
//	reloadTime = 1.0;
	reloadTime = 0.05;
	fireTime = 0.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundWeaponSelect;
};

ItemData BlastC
{
	description = "Blast Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "reticle";
   	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = BlastCImage;
	price = 175;
	showWeaponBar = true;
};

function BlastC::onMount(%player,%item)
{
	Player::mountItem(%player, BlastC1, 4);
	Player::mountItem(%player, BlastC2, 5);
	Player::mountItem(%player, BlastC3, 6);
	Player::mountItem(%player, BlastC4, 7);
}

function BlastC::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

function BlastCImage::onFire(%player,%slot)
{
//	Player::trigger(%player,4,true);
//	Player::trigger(%player,5,true);
//	Player::trigger(%player,6,true);
//	Player::trigger(%player,7,true);
//	Player::trigger(%player,4,false);
//	Player::trigger(%player,5,false);
//	Player::trigger(%player,6,false);
//	Player::trigger(%player,7,false);
	Weapon::onFire(%player);
}

//-------------------------------------//
//-----------INVENTORY-STUFF-----------//
//-------------------------------------//

	$InvList[BlastC] = 0;
	$RemoteInvList[BlastC] = 0;

	$ItemMax[larmor, BlastC] = 0;
	$ItemMax[marmor, BlastC] = 0;
	$ItemMax[harmor, BlastC] = 0;
	$ItemMax[qarmor, BlastC] = 0;
	$ItemMax[tarmor, BlastC] = 0;
	$ItemMax[sarmor, BlastC] = 1;
	$ItemMax[srarmor, BlastC] = 0;
	$ItemMax[parmor, BlastC] = 0;
	$ItemMax[lfemale, BlastC] = 0;
	$ItemMax[mfemale, BlastC] = 0;
	$ItemMax[qfemale, BlastC] = 0;
	$ItemMax[sfemale, BlastC] = 1;
	$ItemMax[srfemale, BlastC] = 0;
	$ItemMax[pfemale, BlastC] = 0;
	$ItemMax[psarmor, BlastC] = 0;