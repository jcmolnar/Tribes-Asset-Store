//--------------------------------------
//L:0.66/Q:0.5/SR:0.66/S:0.66/M:1.0/P:1.0
//H:1.32/T:1.5/PS:1.0 /Ice:1.0
RocketData ELBolt
{
	bulletShapeName  = "plasmaex.dts";
	explosionTag     = LargeShockwave2;
	collisionRadius  = 0.0;
	mass             = 1.0;

	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 1.5;
	damageType       = $NukeDamageType;

	explosionRadius  = 20.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 5.0;
	terminalVelocity = 8.0;
	acceleration     = 0.0;
	totalTime        = 20.0;
	liveTime         = 21.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;

	// rocket specific
	trailType   = 2;                // smoke trail
	trailString = "shockwave_large.dts";
	smokeDist   = 1.0;
};

RocketData ELTail
{
//	bulletShapeName  = "shield_large.dts";
	bulletShapeName  = "fusionbolt.dts";
	explosionTag     = LargeShockwave2;
	collisionRadius  = 0.0;
	mass             = 1.0;

	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 1.5;
	damageType       = $NukeDamageType;

	explosionRadius  = 30.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 5.0;
	terminalVelocity = 8.0;
	acceleration     = 0.0;
	totalTime        = 20.0;
	liveTime         = 21.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;

	// rocket specific
	trailType   = 2;                // smoke trail
	trailString = "fusionex.dts";
	smokeDist   = 0.1;
};
function ELTail::onAdd(%this) { GetNukePOS(%this); }
function ELTail::onRemove(%this) { NuclearExplosion($NukePOS[%this]); }
function GetNukePOS(%this)
{
	$NukePOS[%this] = GameBase::getPosition(%this);
	schedule("GetNukePOS("@%this@");",0.1,%this);
}
//----------------------------------------------------------------------------

ItemData ELAmmo
{
	description = "Energy Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mflame";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ELBigImage
{
	shapeFile = "liqcyl";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { -1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData ELBig
{
	description = "EL part";
	className = "Weapon";
	shapeFile = "liqcyl";
	shadowDetailMask = 4;
	imageType = ELBigImage;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData ELImage
{
	shapeFile = "mortargun";
  	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = ELAmmo;
	accuFire = true;
	reloadTime = 25.0;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
};

ItemData EL
{
	description = "Nuclear Fission Emitter";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "Mortar";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = ELImage;
	price = 375;
	showWeaponBar = true;
};

function EL::onMount(%player,%item)
{
	Player::mountItem(%player, ELBig, 7);
}

function EL::onUnmount(%player,%item)
{
	Player::unmountItem(%player, 7);
}

function ELImage::onFire(%player, %slot)
{
	Weapon::onFire(%player,ELBolt,False);
	Weapon::onFire(%player,ELTail);
}
