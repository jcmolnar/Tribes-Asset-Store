//==== Explosion Data Blocks ====//
ExplosionData PlasmaCannonExp0
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;
   timeZero = 0.450;
   timeOne  = 0.750;
   colors[0]  = { 0.0, 0.25, 1.0 };
   colors[1]  = { 0.0, 0.25, 1.0 };
   colors[2]  = { 0.0,  0.75,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData PlasmaCannonExp1
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData PlasmaCannonExp2
{
   shapeName = "fiery.dts";
   soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData PlasmaCannonExp3
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 0.25, 1.0 };
   colors[1]  = { 0.0, 0.25, 1.0 };
   colors[2]  = { 0.0,  0.75,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

//==== Projectile Data Blocks ====//
BulletData PlasmaCannonBlast
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = PlasmaCannonExp0;
   mass            = 0.05;
   damageClass     = 1;       
   damageValue     = 5.0;
   damageType      = $PlasmaCannonDamageType;
   explosionRadius = 1.5;
   muzzleVelocity  = 200.0;
   totalTime       = 3.0;
   liveTime        = 2.0;
   isVisible       = true;
   rotationPeriod  = 0.5;
};

RocketData PlasmaCannonBlastlvl1
{
	bulletShapeName = "grenade.dts";
	explosionTag = PlasmaCannonExp1;
	collisionRadius = 0.0;
	mass = 4;
	damageClass = 1;
	damageValue = 10.0;
	damageType = $PlasmaCannonDamageType;
	explosionRadius = 5;
	kickBackStrength = 5;
	muzzleVelocity = 150;
	terminalVelocity = 150;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0;
	trailType = 1;
	trailString = "plasmatrail.dts";
	smokeDist = 1.0;
	soundId = SoundJetLight;
};

RocketData PlasmaCannonBlastlvl2
{
	bulletShapeName = "plasmatrail.dts";
	explosionTag = PlasmaCannonExp2;
	collisionRadius = 0.0;
	mass = 4;
	damageClass = 1;
	damageValue = 20.0;
	damageType = $PlasmaCannonDamageType;
	explosionRadius = 5;
	kickBackStrength = 5;
	muzzleVelocity = 150;
	terminalVelocity = 150;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0;
	trailType = 2;
	trailString = "enex.dts";
	smokeDist = 2;
	soundId = SoundJetLight;
};

BulletData PlasmaCannonBlastlvl3
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp;
   mass            = 0.05;
   damageClass     = 1;       
   damageValue     = 25.0;
   damageType      = $PlasmaCannonDamageType;
   explosionRadius = 5;
   muzzleVelocity  = 150.0;
   totalTime       = 3.0;
   liveTime        = 2.0;
   isVisible       = true;
   rotationPeriod  = 0.5;
};

RocketData PlasmaCannonBlastlvl3Add
{
	bulletShapeName = "enbolt.dts";
	explosionTag = PlasmaCannonExp3;
	collisionRadius = 0.0;
	mass = 4;
	damageClass = 1;
	damageValue = 25.0;
	damageType = $PlasmaCannonDamageType;
	explosionRadius = 15;
	kickBackStrength = 5;
	muzzleVelocity = 150;
	terminalVelocity = 150;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0;
	trailType = 2;
	trailString = "paint.dts";
	smokeDist = 1.8;
	soundId = SoundJetLight;
};

//==== Item Data Blocks ====//
ItemImageData PlasmaCannon2Image
{
	shapeFile = "mortargun"; 
	mountPoint = 0;  
	weaponType = 0; 
	reloadTime = 0; 
	fireTime   = 0.0;
	minEnergy = 5;	
	maxEnergy = 6; 
	accuFire = true; 
	sfxFire = SoundPlasmaTurretFire;
};

ItemData PlasmaCannon2
{
	description = "Plasma Cannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun";
	hudIcon	= "plasma";
	heading = $InvHeading[EnergyWeapons];
	shadowDetailMask = 4; 
	imageType = PlasmaCannon2Image; 
	price = 25; 
	showWeaponBar = false;
	showinventory = false;
};

ItemImageData PlasmaCannonImage
{
	shapeFile  = "breath";
	mountPoint = 0;
	mountOffset = { 0, 1, 0 };
	weaponType = 0;
	reloadTime = 0;
	fireTime   = 0;
	minEnergy  = 5;
	maxEnergy  = 6;
	accuFire   = true;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PlasmaCannon
{
	description = "Plasma Cannon";
	className = "Weapon";
	shapeFile  = "mortargun";
	hudIcon = "plasma";
	heading = $InvHeading[EnergyWeapons];
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 100;
	showWeaponBar = true;
};

function PlasmaCannon::onMount(%player, %item)
{ Player::mountItem(%player, PlasmaCannon2, $XtraSlotA); }

function PlasmaCannon::onUnMount(%player, %item)
{ Player::unmountItem(%player, $XtraSlotA); }

function PlasmaCannonImage::onFire(%player, %slot)
{
	if(%player.ChargeStatus == 0)
	{
		%player.curCharge = 0;
		%energy = GameBase::getEnergy(%player);
		PlasmaCannon::Charge(%player, %energy);
	}
}

// Original code by ProtoManX, modified by [TG]-X-Ecutioner
function PlasmaCannon::Charge(%player, %energy)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	%state = Player::getItemState(%player, $WeaponSlot);
	if(%state == "Fire"){
		%player.ChargeStatus = 1;
		if(%energy >= 1 && %player.ChargeLvl < 3){
			%energy -= 2.5;
			if(%energy < 0)
			{ %energy = 0; }
			GameBase::setEnergy(%player, %energy);
			%player.curCharge += 2;
		}
		if(%player.curCharge > %armor.maxEnergy)
		{ %player.curCharge = %armor.maxEnergy; }
		
		if(%player.curCharge >= 75){
			%player.ChargeLvl = 3;
		}else if(%player.curCharge >= 35){
			%player.ChargeLvl = 2;
		}else if(%player.curCharge >= 10){
			%player.ChargeLvl = 1;
		}else{
			%player.ChargeLvl = 0;
		}
		%energy = GameBase::getEnergy(%player);
		if(%player.ChargeLvl != 0){
			XBottomprint(%client, "<jc><f1>Charge Level: <f2>"@ %player.ChargeLvl @".", 2.5);
		}else if(%player.ChargeLvl == 3){
			Client::sendMessage(%client, 0, "~wbuysellsound.WAV");
			XBottomprint(%client, "<jc><f1>Charge Level: <f2>Max Charge.", 2.5);
		}
		Schedule("PlasmaCannon::Charge("@ %player @", "@ %energy @");", 0.1);
		playSound(SoundCannonCharge, GameBase::getPosition(%player));
		return;
	}else{
		Bottomprint(%client, "", 1);
		%player.ChargeStatus = 0;
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Player::trigger(%player, $XtraSlotA, true);
		Player::trigger(%player, $XtraSlotA, false);
		if(%player.ChargeLvl == 3){
			Projectile::spawnProjectile("PlasmaCannonBlastlvl3Add", %trans, %player, %vel);
			Projectile::spawnProjectile("PlasmaCannonBlastlvl3", %trans, %player, %vel);
		}else{
			if(%player.ChargeLvl != 0)
			{ Projectile::spawnProjectile("PlasmaCannonBlastlvl"@ %player.ChargeLvl, %trans, %player, %vel); }
			else
			{ Projectile::spawnProjectile("PlasmaCannonBlast", %trans, %player, %vel); }
		}
	}
}

function PlasmaCannon::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }