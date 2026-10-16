
ExplosionData Burn
{
	shapeName = "plasmatrail.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 1.0;
	timeZero = 0.450;
	timeOne  = 0.500;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

//----------------------------------------------------------------------------

BulletData Flames
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = Burn;
	mass               = 0.75;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.025;
	damageType         = $FlameDamageType;

	aimDeflection      = 0.004;
	muzzleVelocity     = 50.0;
	totalTime          = 0.35;
	inheritedVelocityScale = 0.5;
	isVisible          = true;
};

GrenadeData Burning
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = FireExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0.5;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.013;
	damageType         = $MortarDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 1;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = -0.5;
	smokeName              = "plasmatrail.dts";
};

function Fire::onAdd(%this)
{
	Fire::BurnCheck(%this);
}

function Fire::BurnCheck(%this)
{
	if(GameBase::getPosition(%this) != GameBase::getPosition(%this.victim))
		GameBase::setPosition(%this,Vector::add(GameBase::getPosition(%this.victim),"0 0 "@$FlameBurnElevation));
	schedule("Fire::BurnCheck("@%this@");",0.5,%this);
}

//----------------------------------------------------------------------------

ItemImageData FlamethrowerImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 1; // Spinning
	reloadTime = 0;
	minEnergy = 4;
	maxEnergy = 0.75;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.01;
	projectileType = Flames;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundJetHeavy;
	sfxSpinUp = SoundFireFlierRocket;
	sfxSpinDown = SoundFlyerActive;
};

ItemData Flamethrower
{
	description = "Flamethrower";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = FlamethrowerImage;
	price = 175;
	showWeaponBar = true;
};

function Flamethrower::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == FtPack)
		Weapon::onUse(%player,%item);
	else if(IsIce(Player::getClient(%player)))
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Fuel Tank Pack to use the Flamethrower."); 
}