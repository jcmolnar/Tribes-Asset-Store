//--------------------------------------
BulletData SniperBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = SniperExp;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.5;
	damageType         = $SniperDamageType;
	aimDeflection      = 0.0;
	muzzleVelocity     = 2500.0;
	totalTime          = 3.0;
	inheritedVelocityScale = 2.0;
	isVisible          = true;
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

RocketData SniperRocket
{
	bulletShapeName = "bullet.dts";
	explosionTag    = SniperExp;
	collisionRadius = 0.0;
	mass            = 0.05;
	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 0.5;
	damageType       = $SniperDamageType;
	explosionRadius  = 0.1;
	kickBackStrength = 150.0;
	muzzleVelocity   = 2500.0;
	terminalVelocity = 2500.0;
	acceleration     = 5.0;
	totalTime        = 6.5;
	liveTime         = 8.0;
	lightRange       = 0.01;
	lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType   = 1;
	trailLength = 1;
	trailWidth  = 0.05;
	rotationPeriod = 50;
	soundId = SoundJetLight;
};

//--------------------------------------

ItemData SRAmmo
{
	description = "Sniper Bullets";
   	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

//--------------------------------------

ItemImageData ScopeImage
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.18 }; //-  left-right, back-front, up-down
	mountRotation = { 1.55, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Scope
{
	description = "Scope";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = ScopeImage;
	showWeaponBar = false;
};

ItemImageData SRImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = SRAmmo;
	//projectileType = SniperRocket;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.15;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundWeaponSelect;
	sfxReload = SoundWeaponSelect;
};

ItemData SR
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "reticle";
   	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = SRImage;
	price = 175;
	showWeaponBar = true;
};

//--------------------------------------//
//------------FUNCTION-STUFF------------//
//--------------------------------------//

function SR::onMount(%player,%item)
{
	Player::mountItem(%player,Scope,7);
}

function SR::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}