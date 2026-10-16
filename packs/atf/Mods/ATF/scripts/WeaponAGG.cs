//--------------------------------------

$AutoUse[AGG] = True;

$WeaponAmmo[Agg] = MortarAmmo;

//--------------------------------------

$InvList[AGG] = 1;

$RemoteInvList[AGG] = 1;


$InvList[ChargeGun] = 1;

$RemoteInvList[ChargeGun] = 1;


//--------------------------------------

BulletData AGGShell
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = Debrisexpmedium;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0;
   elasticity         = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 3.0;
   kickBackStrength   = 0;
   muzzleVelocity    = 34.0; //90
   terminalVelocity = 40.0;
  
     totalTime        = 6.5;
   liveTime         = 8.0;
   
   aimDeflection      = 0.03;//0.03;
   inheritedVelocityScale = 0.5;
   
};


GrenadeData AckBurnies
{
   bulletShapeName    = "Tumult_small.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Tumult_small.dts";
};

GrenadeData Magic
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 9.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "FusionEx.dts";
};

GrenadeData ZombieRevive
{
   bulletShapeName    = "Rsmoke.dts";
   explosionTag       = RocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PoisonDamageType;

   explosionRadius    = 18.0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Smoke.dts";
};


GrenadeData Smoky
{
   bulletShapeName    = "Smoke.dts";
   explosionTag       = debrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 3.0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.03;
   liveTime           = 0.03;
   projSpecialTime    = 0.03;

   inheritedVelocityScale = 0.5;
   smokeName              = "Smoke.dts";
};



GrenadeData Thunders
{
   bulletShapeName    = "Fusionex.dts";
   explosionTag       = PlasmaSlowExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 3.0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 4.23;
   liveTime           = 4.23;
   projSpecialTime    = 0.03;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmaex.dts";
};

GrenadeData Esd
{
   bulletShapeName    = "Enex.dts";
   explosionTag       = TurretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.005;
   damageType         = $ElectricityDamageType;

   explosionRadius    = 6.0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "FusionEx.dts";
};

GrenadeData HaCk
{
   bulletShapeName    = "Fusionex.dts";
   explosionTag       = TurretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -10;
   damageType         = $SuperDamageType;

   explosionRadius    = 5.0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "FusionEx.dts";
};
//--------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AGGImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = inyuyasha;
	accuFire = false;
	reloadTime = 1.7;
	fireTime = 1.7;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function AGGImage::onFire(%player, %slot)
{

	
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
		Player::decItemCount(%player,$WeaponAmmo[AGG],1);
	
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 
Projectile::spawnProjectile("AGGshell",%transform,%player,%velocity); 

}


ItemData AGG
{
	description = "I.R.S.";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eTrajectoryGuns";
	shadowDetailMask = 4;
	imageType = AGGImage;
	price = 475;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function AGG::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "<jc>Look kids its the U.S.'s crazy revenue service....or just an Impact Rocket Shotgun...I guess they are both equally as scary...", 10);Weapon::onUse(%player,%item);
}
//**************************************************************************************
//--------------------------------------
//--------------------------------------

$AutoUse[BlasterM] = True;
$Use[BlasterM] = True;
$WeaponAmmo[BlasterM] = "";

//--------------------------------------

$InvList[BlasterM] = 1;
$RemoteInvList[BlasterM] = 1;

//--------------------------------------


BulletData BlasterBoltNorm
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.125;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 130.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 10;
};


RocketData BlasterBoltFire
{
   bulletShapeName = "PlasmaBolt.dts";
   explosionTag    = AcidExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $BurnDamageType;

   explosionRadius  = 3.5;
   kickBackStrength = 2.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   acceleration     = 0;

   totalTime        = 2.0;
   liveTime         = 1.125;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Tumult_Small.dts";
   smokeDist   = 20.8;


   soundId = SoundJetHeavy;
};
BulletData BlasterBoltPoison
{
   bulletShapeName = "Paint.dts";
   explosionTag    = CloudExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.077;
   damageType       = $PoisonDamageType;

   explosionRadius  = 3.5;
   kickBackStrength = 2.0;

   muzzleVelocity   = 110.0;
   terminalVelocity = 110.0;
   acceleration     = 0;

   totalTime        = 2.0;
   liveTime         = 1.125;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Tumult_small.dts";
   smokeDist   = 30.8;
};


RocketData BlasterBoltEmp
{
   bulletShapeName = "Fusionbolt.dts";
   explosionTag    = TurretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $ShockDamageType;

   explosionRadius  = 3.5;
   kickBackStrength = 2.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 0;

   totalTime        = 2.0;
   liveTime         = 1.125;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "FusionEx.dts";
   smokeDist   = 25.8;


   soundId = SoundJetHeavy;
};

RocketData BlasterBoltFlash
{
   bulletShapeName = "Paint.dts";
   explosionTag    = TurretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $BlindDamageType;

   explosionRadius  = 8;
   kickBackStrength = 2.0;

   muzzleVelocity   = 130.0;
   terminalVelocity = 130.0;
   acceleration     = 0;

   totalTime        = 2.0;
   liveTime         = 1.125;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Paint.dts";
   smokeDist   = 3.8;


   soundId = SoundJetHeavy;
};

RocketData BlasterBoltEnergy
{
   bulletShapeName = "Plasmabolt.dts";
   explosionTag    = PlasmaExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;      // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $BlasterDamageType;

   explosionRadius  = 8;
   kickBackStrength = 30;

   muzzleVelocity   = 130.0;
   terminalVelocity = 130.0;
   acceleration     = 0;

   totalTime        = 2.0;
   liveTime         = 1.125;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "PlasmaBolt.dts";
   smokeDist   = 3.8;


   soundId = SoundJetHeavy;
};
//--------------------------------------



ItemImageData BlasterImageM
{
   ShapeFile  = "energygun";
	mountPoint = 0;
	mountoffset = { -0.2, 0.0, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { 0, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0.2;
	minEnergy = 10;
	maxEnergy = 30;

	projectileType = MultiFire;
	accuFire = False;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};
//Little bit of scripting that deals a certain kind of damage when you wear certain packs -HaCk
function BlasterImageM::onFire(%player, %slot)
{
if (GameBase::getEnergy(%player) > 10)
{

if (Player::getItemCount(%Player,"EmpPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("BlasterBoltEmp",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 5);
	}
if (Player::getItemCount(%Player,"FirePack") == 1)
	{
		
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("BlasterBoltFire",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 10);	
	}
if (Player::getItemCount(%Player,"PoisonPack") == 1)
	{
		
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("BlasterBoltPoison",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 9);	
	}
	if (Player::getItemCount(%Player,"FlashPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("BlasterBoltFlash",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 1);
	}

	if (Player::getItemCount(%Player,"EnerBurstPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	for(%ener=((GameBase::getEnergy(%player))/10);%ener>0;%ener--)
	{
	Projectile::spawnProjectile("BlasterBoltEnergy",%transform,%player,%velocity);
	GameBase::setEnergy(%player, (GameBase::getEnergy(%player)-1));
	}
	GameBase::setEnergy(%player, 0);
	}
	
}

else
	Client::sendMessage(Player::getClient(%player), 0,"Not Enough Energy");
}


ItemData BlasterM
{
   heading = "gMulti Shot Guns";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImageM;
	price = 185;
	showWeaponBar = true;
};

//--------------------------------------
function BlasterM::onUse(%Client,%item)
{
	bottomprint(Player::getClient(%Client), "Multi Shot Blaster: Get  Modifier packs to use this gun", 10);Weapon::onUse(%Client,%item);
}
