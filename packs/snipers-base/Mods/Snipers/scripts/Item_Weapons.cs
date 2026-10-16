//----------------------------------------------------------------------------
//
//	WEAPONS DATA
//
//----------------------------------------------------------------------------
exec(sound);
//----------------------------------------------------------------------------
//--Sniper Rifle--
//----------------------------------------------------------------------------
$InvList[SniperRifle] = 1;
$InvList[SniperAmmo] = 1;
$RemoteInvList[SniperRifle] = 1;
$RemoteInvList[SniperAmmo] = 1;
$AutoUse[SniperRifle] = true;
$SellAmmo[SniperAmmo] = 25;
$WeaponAmmo[SniperRifle] = SniperAmmo;

addWeapon(SniperRifle);
addAmmo(SniperRifle, SniperAmmo, 2);

BulletData SniperBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.59;
	damageType = $LaserDamageType;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 2000.0;
	terminalVelocity = 2000.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	soundId = SoundJetHeavy;
};

ItemData SniperAmmo 
{
	description = "Sniper Bullet";
	className = "Ammo";
	heading = zAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = SniperAmmo;
	projectileType = SniperBullet;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireChainGun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	validateShape = true;
	hudIcon = "sniper";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 125;
	showWeaponBar = true;
};

function SniperRifle::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Sniper Rifle", 2);
}

//----------------------------------------------------------------------------
//--Laser Rifle--
//----------------------------------------------------------------------------
$InvList[LaserRifle] = 1;
$RemoteInvList[LaserRifle] = 1;
$AutoUse[LaserRifle] = false;
$WeaponAmmo[LaserRifle] = "";

addWeapon(LaserRifle);

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
	validateShape = true;
	validateMaterials = true;
};

function LaserRifle::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Laser Rifle", 2);
}

//----------------------------------------------------------------------------
//--Alien Laser--
//----------------------------------------------------------------------------

$InvList[AlienLaser] = 1;
$RemoteInvList[AlienLaser] = 1;
$AutoUse[AlienLaser] = false;
$WeaponAmmo[AlienLaser] = "";

addWeapon(AlienLaser);

LaserData AlienRay
{
	laserBitmapName = "warp.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.010;
	baseDamageType = $LaserDamageType;
	beamTime = 0.5;
	lightRange = 1.0;
	lightColor = { 0.0, 1.25, 1.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

ItemImageData AlienLaserImage
{
      shapeFile  = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 360.0, 0 };
      weaponType = 0; // Single Shot
	projectileType = AlienRay;
	reloadTime = 0.9;
	fireTime = 0.1;
	minEnergy = 25;
	maxEnergy = 25;
      accuFire = true;
      sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AlienLaser
{
	heading = bWeapons;
	description = "Alien Laser";
	className = "Weapon";
	shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = AlienLaserImage;
	price = 550;
	showWeaponBar = true;
};

function AlienLaser::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Alien Laser", 2);
}

//----------------------------------------------------------------------------
//--High Caliber Rifle--
//----------------------------------------------------------------------------

$InvList[HCRifle] = 1;
$InvList[HCAmmo] = 1;
$RemoteInvList[HCRifle] = 1;
$RemoteInvList[HCAmmo] = 1;
$AutoUse[HCRifle] = true;
$SellAmmo[HCAmmo] = 25;
$WeaponAmmo[HCRifle] = HCAmmo;

addWeapon(HCRifle);
addAmmo(HCRifle, HCAmmo, 2);

BulletData HighCalBullet
{
   bulletShapeName = "bullet.dts";
   validateShape = true;
   explosionTag = bulletExp0;
   expRandCycle = 3;
   mass = 0.05;
   bulletHoleIndex = 0;
   damageClass = 0;       // 0 impact, 1, radius
   damageValue = 3.5;
   damageType = $LaserDamageType;
   explosionRadius  = 0.2;
   kickBackStrength = 150.0;
   aimDeflection = 0.000;
   muzzleVelocity = 425.0;
   totalTime = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible = False;
   tracerPercentage = 1.0;
   tracerLength = 30;
};

ItemData HCAmmo 
{
	description = "High Cal. Bullet";
	className = "Ammo";
	heading = zAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData HCRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = HCAmmo;
	projectileType = HighCalBullet;
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0.0, 1.25, 1.25 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HCRifle
{
	description = "High Cal. Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	validateShape = true;
	hudIcon = "sniper";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HCRifleImage;
	price = 125;
	showWeaponBar = true;
};

function HCRifle::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>High Cal. Rifle", 2);
}

//----------------------------------------------------------------------------
//--Rail Gun--
//----------------------------------------------------------------------------

$InvList[Railgun] = 1;
$InvList[RailAmmo] = 1;
$RemoteInvList[Railgun] = 1;
$RemoteInvList[RailAmmo] = 1;
$AutoUse[Railgun] = true;
$SellAmmo[RailAmmo] = 25;
$WeaponAmmo[Railgun] = RailAmmo;

addWeapon(Railgun);
addAmmo(Railgun, RailAmmo, 2);

RocketData RailRound 
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.85;
	damageType = $LaserDamageType;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 2000.0;
	terminalVelocity = 2000.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.6;
	soundId = SoundJetHeavy;
};

ItemData RailAmmo 
{
	description = "Railgun Bolt";
	className = "Ammo";
	heading = zAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RailgunImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = RailAmmo;
	projectileType = RailRound;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0.25, 1.0, 0.25 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Railgun 
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 375;
	showWeaponBar = true;
};

function Railgun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Railgun", 2);
}

//----------------------------------------------------------------------------
//--ShotGun--
//----------------------------------------------------------------------------

$InvList[Shotgun] = 1;
$InvList[ShotgunAmmo] = 1;
$RemoteInvList[Shotgun] = 1;
$RemoteInvList[ShotgunAmmo] = 1;
$SellAmmo[ShotgunAmmo] = 5;
$WeaponAmmo[Shotgun] = ShotgunAmmo;
$AutoUse[Shotgun] = true;

addWeapon(Shotgun);
addAmmo(Shotgun, ShotgunAmmo, 2);

BulletData ShotgunBlast
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.07;
	bulletHoleIndex = 0;
	damageClass = 0;       // 0 impact, 1, radius
	damageValue = 0.05;
	damageType = $ShotgunDamageType;
	aimDeflection = 0.015;
	muzzleVelocity = 200.0;
	totalTime = 1;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 2.0;
	tracerLength = 30;
	soundId = SoundJetLight; 
};

ItemData ShotgunAmmo
{
	description = "Shotgun Shells";
	className = "Ammo";
	heading = zAmmunition;
	shapeFile = "ammo2";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ShotgunImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	ammoType = ShotgunAmmo;
	projectileType = "Undefined";
	weaponType = 0; // Single Shot
	reloadTime = 0.5;
	fireTime = 1.1;
	minEnergy = 5;
	maxEnergy = 6;                
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireShotgun;
	sfxReload = SoundMortarReload;
   
};

ItemData Shotgun
{
	description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "blaster";
	heading = bWeapons;
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	showWeaponBar = true;
	price = 500;
};


function ShotgunImage::onFire(%player, %slot) 
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
	if(%AmmoCount) 
	{
		%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);			
		}
		else Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}

function Shotgun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Shotgun", 2);
}

//----------------------------------------------------------------------------
//--Tranqgun--
//----------------------------------------------------------------------------

$InvList[TranqGun] = 1;
$InvList[TranqAmmo] = 1;
$RemoteInvList[TranqGun] = 1;
$RemoteInvList[TranqAmmo] = 1;
$AutoUse[TranqGun] = True;
$SellAmmo[TranqAmmo] = 2;
$WeaponAmmo[TranqGun] = TranqAmmo;

addWeapon(TranqGun);
addAmmo(TranqGun, TranqAmmo, 5);

BulletData TranqDart 
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;
	damageValue = 0.16;
	damageType = $PoisonDamageType;
	muzzleVelocity = 625.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 100.0;
	tracerLength = 30;
};

ItemData TranqAmmo 
{
	description = "Poison Dart";
	className = "Ammo";
	heading = zAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData TranqGunImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = TranqAmmo;
	projectileType = TranqDart;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireChainGun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TranqGun
{
	description = "Poison Dart Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = TranqGunImage;
	price = 475;
	showWeaponBar = true;
};

function TranqGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Poison Dart Rifle", 2);
}

//----------------------------------------------------------------------------
//--Hyper Laser--
//----------------------------------------------------------------------------

$InvList[HyperLaser] = 1;
$RemoteInvList[HyperLaser] = 1;
$AutoUse[HyperLaser] = True;
$WeaponAmmo[HyperLaser] = "";

AddWeapon(HyperLaser);

LaserData HyperLaserBeam
{
	laserBitmapName = "discglow1.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.03;
	baseDamageType = $LaserDamageType;
	beamTime = 0.4;
	lightRange = 4.0;
	lightColor = { 1.0, 0.25, 0.25 } ;
	detachFromShooter = false;
};

ItemImageData HyperLaserImage 
{
	shapeFile = "Sniper";
	mountPoint = 0;
	weaponType = 0;
	mountoffset = { 0, 0, 0.1 };
      mountRotation = { 0, 22.0, 0 };
	projectileType = HyperLaserBeam;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 5;
	reloadTime = 0.001;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundGeneratorPower;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HyperLaser
{
	description = "Hyper Laser";
	className = "Weapon";
	shapeFile = "Sniper";
	hudIcon = "sniper";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = HyperLaserImage;
	price = 500;
	showWeaponBar = true;
};

function HyperLaser::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Hyper Laser", 2);
}


//----------------------------------------------------------------------------
//--ELF gun--
//----------------------------------------------------------------------------

$InvList[ELF] = 1;
$RemoteInvList[ELF] = 1;
$AutoUse[ELF] = True;
$WeaponAmmo[ELF] = "";

AddWeapon(ELF);

LightningData lightningCharge1
{
	bitmapName = "lightningNew.bmp";
	damageType = $MeleeDamageType;
	boltLength = 40.0;
	coneAngle = 35.0;
	damagePerSec = 0.10;
	energyDrainPerSec = 60.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

ItemImageData ELFImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = lightningCharge1;
	minEnergy = 3;
	maxEnergy = 11;
	reloadTime = 0.2;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData ELF
{
	description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ELFImage;
	showWeaponBar = true;
	price = 500;
};

function ELF::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>ELF Gun", 2);
}

//----------------------------------------------------------------------------
//--Flame Rifle-- ~Created by Shit Jr.
//----------------------------------------------------------------------------

$InvList[FlameRifle] = 1;
$InvList[FlameAmmo] = 1;
$RemoteInvList[FlameRifle] = 1;
$RemoteInvList[FlameAmmo] = 1;
$AutoUse[FlameRifle] = True;
$SellAmmo[FlameAmmo] = 25;
$WeaponAmmo[FlameRifle] = FlameAmmo;

addWeapon(FlameRifle);
addAmmo(FlameRifle, FlameAmmo, 2);

RocketData FlameRound
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = plasmaExp;
	//collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.70;
	damageType = $PlasmaDamageType;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 1500.0;
	terminalVelocity = 1000.0;
	acceleration = 10.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	soundId = SoundJetHeavy;
};

ItemData FlameAmmo
{
	description = "Uranium Slug";
	className = "Ammo";
	heading = zAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FlameRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = FlameAmmo;
	projectileType = FlameRound;
	mountoffset = { 0.1, 0, 0 };
	mountrotation = { 0, -11, 0 };
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 4.0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData FlameRifle
{
	description = "Flame Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "Plasma";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = FlameRifleImage;
	price = 375;
	showWeaponBar = true;
};

function FlameRifle::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Flame Rifle", 2);
}

//----------------------------------------------------------------------------
//--Shock Rifle-- ~Created by Shit Jr.
//----------------------------------------------------------------------------

$InvList[ShockRifle] = 1;
$RemoteInvList[ShockRifle] = 1;
$AutoUse[ShockRifle] = True;
$WeaponAmmo[ShockRifle] = "";

addWeapon(ShockRifle);

RocketData ShockBolt
{
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.09;
	damageType = $FlashDamageType;
	explosionRadius = 0.2;
	kickBackStrength = 600.0;
	muzzleVelocity = 2000.0;
	terminalVelocity = 2000.0;
	minEnergy = 1;
	maxEnergy = 5;
	acceleration = 10.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	inheritedVelocityScale = 1.0;
	soundId = SoundJetHeavy;
	trailType = 1;
	trailLength = 850;
	trailWidth = 0.3;
};

ItemImageData ShockRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 19;
	maxEnergy = 20;
	projectileType = ShockBolt;
	accuFire = true;
	sfxFire = SoundELFFire;
	sfxActivate = SoundThrowItem;
};

ItemData ShockRifle
{
	description = "Ion Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = ShockRifleImage;
	price = 420;
	showWeaponBar = true;
};



function ShockRifle::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Ion EMP Rifle", 2);
}

//----------------------------------------------------------------------------
//--Cutting Laser--
//----------------------------------------------------------------------------

$InvList[CuttingLaser] = 1;
$RemoteInvList[CuttingLaser] = 1;
$AutoUse[CuttingLaser] = True;
$WeaponAmmo[CuttingLaser] = "";

addWeapon(CuttingLaser);

LightningData CutLaser
{
	bitmapName = "repairAdd.bmp";
	damageType = $MeleeDamageType;
	boltLength = 10.0;
	coneAngle = 90.0;
	damagePerSec = 3.0;
	energyDrainPerSec = 0;
	segmentDivisions = 0;
	numSegments = 1;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

ItemImageData CuttingLaserImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	accuFire = true;
	projectileType = CutLaser;
	minEnergy = 1;
	maxEnergy = 200;
	fireTime = 0.05;
	reloadTime = 2;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireLaser;
};

ItemData CuttingLaser
{
	description = "Cutting Laser";
	shapeFile = "repairgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = CuttingLaserImage;
	showWeaponBar = true;
	price = 600;
};

function CuttingLaser::onUse(%player,%item) 
{
	Weapon::OnUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Cutting Laser", 2);
}

//----------------------------------------------------------------------------
//--Repeater--
//----------------------------------------------------------------------------

RocketData RepeaterRound
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 1.0;
	damageType = $LaserDamageType;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 5000.0;
	terminalVelocity = 5000.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.6;
	soundId = SoundMissileTurretFire;
};

ItemData RepeaterAmmo
{
	description = "Repeater Bolt";
	className = "Ammo";
	heading = zAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RepeaterImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0.2;
	spinUpTime = 5.25;
	spinDownTime = 0;
	fireTime = 0.92;
	ammoType = RepeaterAmmo;
	projectileType = RepeaterRound;
	accuFire = true;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundRailFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundRailCharge;
	sfxSpinDown = SoundMortarReload;
};

ItemData Repeater 
{
	description = "Repeater";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RepeaterImage;
	price = 375;
	showWeaponBar = true;
};

function Repeater::onUse(%player,%item) 
{
	Weapon::OnUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Repeater:<f0>\n-=NOTE=-\n<f2> You MUST hold down the trigger for 5.25 seconds while this weapon charges.", 10);
}