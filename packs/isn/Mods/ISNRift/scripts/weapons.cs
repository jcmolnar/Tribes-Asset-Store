//=========================================================================================================================================
// Weapons.cs
//=========================================================================================================================================
$AutoUse[FlamerGun] = True;
$AutoUse[LightFlamer] = True;
$AutoUse[ConCun] =True;
$AutoUse[GravGun] =True;
$AutoUse[RocketLauncher] =True;
$AutoUse[BoltRifle] =True;
$AutoUse[MultiPlasma] =True;
$AutoUse[Fusion] =True;
$AutoUse[DisCannon] =True;


$WeaponAmmo[FlamerGun] = "";
$WeaponAmmo[LightFlamer] = "";
$WeaponAmmo[ConCun] = "";
$WeaponAmmo[GravGun] = "";
$WeaponAmmo[RocketLauncher] = "";
$WeaponAmmo[BoltRifle] = "";
$WeaponAmmo[MultiPlasma] = "";
$WeaponAmmo[Fusion] = "";
$WeaponAmmo[DisCannon] = "";

$InvList[FlamerGun] = 1;
$InvList[LightFlamer] = 1;
$InvList[ConCun] = 1;
$InvList[GravGun] = 1;
$InvList[RocketLauncher] = 1;
$InvList[BoltRifle] = 1;
$InvList[MultiPlasma] = 1;
$InvList[FlamerGun] = 1;
$InvList[Fusion] = 1;
$InvList[DisCannon] = 1;

$RemoteInvList[LightFlamer] = 1;
$RemoteInvList[ConCun] = 1;
$RemoteInvList[GravGun] = 1;
$RemoteInvList[RocketLauncher] = 1;
$RemoteInvList[BoltRifle] = 1;
$RemoteInvList[MultiPlasma] = 1;
$RemoteInvList[Fusion] = 1;
$RemoteInvList[FlamerGun] = 1;
$RemoteInvList[DisCannon] = 1;

$NextWeapon[RepairTool] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = MultiPlasma;
$NextWeapon[MultiPlasma] = LightFlamer;
$NextWeapon[LightFlamer] = FlamerGun;
$NextWeapon[FlamerGun] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = RocketLauncher;
$NextWeapon[RocketLauncher] = DiscLauncher;
$NextWeapon[DiscLauncher] = DisCannon;
$NextWeapon[DisCannon] = Fusion;
$NextWeapon[Fusion] = ConCun;
$NextWeapon[ConCun] = GravGun;
$NextWeapon[GravGun] = EnergyRifle;
$NextWeapon[EnergyRifle] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = BoltRifle;
$NextWeapon[BoltRifle] = RepairTool;

$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[EnergyRifle] = LaserRifle;

//======================================================================== Heavy FlamerGun

ItemImageData FlamerGunImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
 mountRotation = { 0,3.14, 0 };
	weaponType = 0; // Single Shot
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.08;
	fireTime = 0.010;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

 	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlamerGun
{
	description = "Heavy Flamer";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlamerGunImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

//======================================================================== Light FlamerGun

RocketData LightFlamerBolt
{
	bulletShapeName  = "plasmabolt.dts";
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 0;
	damageValue      = 0.65;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 0;
	
	muzzleVelocity   = 65.0;
	terminalVelocity = 65.0;
	acceleration     = 15.0;
	totalTime        = 2.0;
	liveTime         = 1.0;
	lightRange       = 1.0;
	lightColor       = { 10, 3, 8 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 10.0;
	soundId = SoundJetHeavy;
};

ItemImageData LightFlamerImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
 mountRotation = { 0,3.14, 0 };
	weaponType = 0; // Single Shot
	projectileType = LightFlamerBolt;
	accuFire = true;
	reloadTime = 0.12;
	fireTime = 0.06;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

 	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LightFlamer
{
	description = "Light Flamer";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LightFlamerImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

//======================================================================== Fusion Launcher

RocketData FusionShock
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.15;
   damageType       = $EnergyDamageType;

   explosionRadius  = 50.0;
   kickBackStrength = 200.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 0.15, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

};

ItemImageData FusionImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; 
    	minEnergy = 40;
	maxEnergy = 45;
	projectileType = FusionShock;
	accuFire = true;
	fireTime = 0.9;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData Fusion
{
	description = "Fusion Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FusionImage;
	price = 250;
	showWeaponBar = true;
};

//======================================================================== GravGun

LightningData gravCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 100.0;
   coneAngle        = 40.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 1.0;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.5;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function gravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{

	%playerId = %shooterId;
	if (%playerId.GravBolt == "0")
	{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = -25;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
	else
	{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = 25;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		
		
		%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
		Player::applyImpulse(%obj,%vec);
		
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

ItemImageData GravGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = gravCharge;
	minEnergy = 3;
	maxEnergy = 20;
	reloadTime = 0.2;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.15, 0.85, 0.15 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData GravGun
{
	description = "Grav Gun";
	shapeFile = "repairgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GravGunImage;
	showWeaponBar = true;
	price = 900;
};


//======================================================================== ConCun

RocketData Shock
{
   bulletShapeName  = "shield.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.15;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 150.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType   = 2;
   trailString = "shield.dts";
   smokeDist   = 1.8;
   soundId = SoundJetHeavy;
};

ItemImageData ConCunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; 
    	minEnergy = 40;
	maxEnergy = 45;
	projectileType = Shock;
	accuFire = true;
	fireTime = 0.9;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ConCun
{
	description = "Shock Launcher";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ConCunImage;
	price = 250;
	showWeaponBar = true;
};

//======================================================================== Rocket Launcher

RocketData GreenRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
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
   trailString = "mortartrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

ItemImageData RocketLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = GreenRocket;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData RocketLauncher
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketLauncherImage;
	price = 150;
	showWeaponBar = true;
};

//======================================================================== IX Bolt Rifle

BulletData RifleBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   mass             = 2.0;

   damageClass      = 0;
   damageValue      = 0.75;
   damageType         = $LaserDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 1.0;

   trailType   = 1;         
   trailLength = 3000;
   trailWidth  = 0.6;

   isVisible          = True;

   rotationPeriod = 1;
};

ItemImageData BoltRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

 mountRotation = { 0,3.14, 0 };

	weaponType = 0; // Single Shot
	projectileType = RifleBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 5;
	maxEnergy = 6;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BoltRifle
{
	description = "IX Bolt Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = BoltRifleImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Rifle"); 
}

//======================================================================== Multi Plasma

RocketData PlasmaBoltMulti
{
	bulletShapeName  = "plasmaex.dts";
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.20;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 0;
	
	muzzleVelocity   = 30.0;
	terminalVelocity = 30.0;
	acceleration     = 20.0;
	totalTime        = 6.0;
	liveTime         = 4.0;
	lightRange       = 6.0;
	lightColor       = { 5, 8, 2 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmaex.dts";
	smokeDist   = 9.0;
	soundId = SoundJetHeavy;
};

ItemImageData MultiPlasmaImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = PlasmaBoltMulti;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MultiPlasma
{
	description = "Multi Plasma";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MultiPlasmaImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;

};

//======================================================================== Disruptor-Cannon

LaserData GatlingLaser
{
	laserBitmapName   = "lightningNew.bmp";
	hitName           = "shield.dts";
	damageConversion  = 0.10;
	baseDamageType    = $LaserDamageType;
	beamTime          = 2.5;
	lightRange        = 5.0;
	lightColor        = { 0.01, 0.01, 1.25 };
	detachFromShooter = true;
	hitSoundId        = SoundLaserHit;
};

ItemImageData DisImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.2, -0.8, 0.4 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	projectileType = "GatlingLaser";
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 140;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	mass = 2.5;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DisCannon
{
	description = "LasCannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DisImage;
	price = 2000;
	mass = 2.5;
	showWeaponBar = true;
};