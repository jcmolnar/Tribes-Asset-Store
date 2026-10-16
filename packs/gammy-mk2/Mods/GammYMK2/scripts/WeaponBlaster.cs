//--------------------------------------
$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;

$AutoUse[Blaster] = True;
$Use[Blaster] = True;
$WeaponAmmo[Blaster] = "";

$AutoUse[Hammer1Pack] = True;
$Use[Hammer1Pack] = True;
$WeaponAmmo[Hammer1Pack] = "EnergyAmmo";
//--------------------------------------

$InvList[Blaster] = 1;
$RemoteInvList[Blaster] = 1;

$InvList[Hammer1Pack] = 1;
$RemoteInvList[Hammer1Pack] = 1;
//--------------------------------------
RocketData BlasterBolt
{
   bulletShapeName = "ShotgunBolt.dts";
   explosionTag    = PlasmaExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.10;
   damageType       = $BlasterDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 60.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 60.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shotgunex.dts";
   smokeDist   = 3.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------
ItemImageData BlasterImage
{
   ShapeFile  = "Plasma";
	mountPoint = 0;
	mountoffset = { -0.2, 0.0, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { 0, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0.3;
	minEnergy = 10;
	maxEnergy = 30;

	projectileType = Timmy;
	accuFire = true;

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

function BlasterImage::onFire(%player, %slot)
{
if (GameBase::getEnergy(%player) > 5)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	%rndCheck=Floor(getRandom()*7);
		Projectile::spawnProjectile("BlasterBolt",%transform,%player,%velocity+%rndCheck); 
		 Projectile::spawnProjectile("BlasterBolt",%transform,%player,%velocity-%rndCheck); 
		Projectile::spawnProjectile("BlasterBolt",%transform,%player,%velocity);
		GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 5);

	}
else
	Client::sendMessage(Player::getClient(%player), 0,"Not Enough Energy");
}

ItemData Blaster
{
   heading = "fPlasma Guns";
	description = "Tali Wacker Special";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

//--------------------------------------
function Blaster::onUse(%Client,%item)
{
	bottomprint(Player::getClient(%Client), " The Tali Wacker Special is a plasma energy blast with that extra little kick that makes arsonist smile :) handle this with care cause it is easy to blow your self to little charred pieces  :)", 10);Weapon::onUse(%Client,%item);
}
//================================ GodHammerCannon
BulletData EnergyRocket2
{
   bulletShapeName    = "Paint.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;
   
   explosionRadius    = 9.0;
   kickBackStrength   = 50.0;
   muzzleVelocity     = 60.0;
   totalTime          = 20.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

ItemImageData Hammer1PackImage
{ 
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0.5, 0.0, 0.0 }; 
	mountRotation = { 0, 0, -0.01 }; 
	weaponType = 0; 
	projectileType = EnergyRocket2; 
	accuFire = true; 
	reloadTime = 0.1;
	fireTime = 0.2;
	ammoType = EnergyAmmo;
	lightType = 3;
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1.0, 1, 1.0 }; 
}; 

ItemData Hammer1Pack 
{ 
	description = "GammaBlast";
	shapeFile = "mortargun";
   	heading = "fPlasma Guns";
	shadowDetailMask = 4;
	imageType = Hammer1PackImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = true;
 	className = "Weapon";
}; 

function Hammer1PackImage::onActivate(%player,%imageSlot)
{}
function Hammer1PackImage::onDeactivate(%player,%imageSlot)
{ Player::trigger(%player,$BackPackSlot,false); }

ItemImageData Hammer2PackImage
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -0.5, 0.0, 0.0 };
	mountRotation = { 0, 0, 0.01 };
	weaponType = 0;
	projectileType = EnergyRocket2; 
	accuFire = true; 
	reloadTime = 0.1;
	fireTime = 0.2;
	ammoType = EnergyAmmo;
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 1.0 }; 
}; 

ItemData Hammer2Pack 
{ 
	description = "GammaBlast 2";
	shapeFile = "mortargun";
   	heading = "fPlasma Guns";
	shadowDetailMask = 4;
	imageType = Hammer2PackImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Weapon";
};

function Hammer2PackImage::onActivate(%player,%imageSlot)
{}
function Hammer2PackImage::onDeactivate(%player,%imageSlot) 
{Player::trigger(%player,$BackPackSlot,false);}



ItemImageData BlasterImage2
{
   ShapeFile  = "Plasma";
	mountPoint = 0;
	mountoffset = { -0.6, 0, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { 0, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0.3;
	minEnergy = 50;
	maxEnergy = 60;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster2
{
   heading = "bRocket Launchers";
	description = "Rocket Blaster2";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage2;
	price = 85;
	showWeaponBar = False;
};

//--------------------------------------

$AutoUse[ChaingunB] = True;
$SellAmmo[BulletAmmo] = 25;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[ChaingunB] = BulletAmmo;

//--------------------------------------

$InvList[ChaingunB] = 1;
$InvList[BulletAmmo] = 1;
$RemoteInvList[ChaingunB] = 1;
$RemoteInvList[BulletAmmo] = 1;

//--------------------------------------

BulletData ChaingunBulletB
{
   bulletShapeName = "Bullet.dts";
   explosionTag    = TurretExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ShockDamageType;

   muzzleVelocity    = 130.0;
   terminalVelocity = 140.0;
   acceleration     = 5.0;
   aimDeflection      = 0.009;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   soundId = SoundJetHeavy;
};


BulletData ChaingunBulletFlame
{
   bulletShapeName = "Bullet.dts";
   explosionTag    = Blasterexp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $BurnDamageType;

   muzzleVelocity    = 110.0;
   terminalVelocity = 120.0;
   acceleration     = 5.0;
   aimDeflection      = 0.009;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   soundId = SoundJetHeavy;
};

BulletData ChaingunBulletBf
{
   bulletShapeName = "Bullet.dts";
   explosionTag    = EnergyExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $BlindDamageType;

   muzzleVelocity    = 160.0;
   terminalVelocity = 170.0;
   acceleration     = 5.0;
   aimDeflection      = 0.009;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   soundId = SoundJetHeavy;
};


BulletData ChaingunBulletP
{
   bulletShapeName = "Bullet.dts";
   explosionTag    = CloudExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $PoisonDamageType;

   muzzleVelocity    = 120.0;
   terminalVelocity = 130.0;
   acceleration     = 5.0;
   aimDeflection      = 0.009;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   soundId = SoundJetHeavy;
};
//--------------------------------------

ItemImageData ChaingunImageb
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0; // Spinning
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 1;
	fireTime = 0.1;

	ammoType = BulletAmmo;
	projectileType = Chef;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

function ChaingunImageB::onFire(%player, %slot)
{

if (Player::getItemCount(%Player,"EmpPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("ChaingunBulletB",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 1);
	}
if (Player::getItemCount(%Player,"FirePack") == 1)
	{
		
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("ChaingunBulletflame",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 5);	
	}
if (Player::getItemCount(%Player,"PoisonPack") == 1)
	{
		
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("ChaingunBulletp",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 4);	
	}
if (Player::getItemCount(%Player,"FlashPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("ChaingunBulletBf",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 1);
	}
}



ItemData Chaingunb
{
	description = "MiniGun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "gMulti Shot Guns";
	shadowDetailMask = 4;
	imageType = ChaingunImageb;
	price = 1025;
	showWeaponBar = true;
};

//--------------------------------------
function Chaingunb::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Multi Shot Minigun: Get modifier packs to use this gun", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------


//--------------------------------------

$AutoUse[ChaingunB] = True;
$SellAmmo[BulletAmmo] = 25;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[SniperGun] = BulletAmmo;

//--------------------------------------

$InvList[SniperGun] = 1;

$RemoteInvList[SniperGun] = 1;


//--------------------------------------


RocketData EmpShot
{
   bulletShapeName = "Enex.dts";
   explosionTag    = TurretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $EmpDamageType;

   explosionRadius  = 5.5;
   kickBackStrength = 120;

   muzzleVelocity   = 320.0;
   terminalVelocity = 330.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 1;                // smoke trail
   trailString = "FusionEx.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};



RocketData BlindShot
{
   bulletShapeName = "Paint.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $BlindDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0;

   muzzleVelocity   = 450.0;
   terminalVelocity = 460.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 1;                // smoke trail
   trailString = "MortarTrail.dts";
   smokeDist   = 10000.8;


   soundId = SoundJetHeavy;
};

RocketData FireShot
{
   bulletShapeName = "Bullet.dts";
   explosionTag    = debrisExpSmall;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $BurnDamageType;

   explosionRadius  = 5.5;
   kickBackStrength = 0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 310.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 1;                // smoke trail
   trailString = "Tumult_Small.dts";
   smokeDist   = 20.8;


   soundId = SoundJetHeavy;
};

RocketData PoisonShot
{
   bulletShapeName = "Paint.dts";
   explosionTag    = AcidExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $PoisonDamageType;

   explosionRadius  = 3.5;
   kickBackStrength = 0;

   muzzleVelocity   = 350.0;
   terminalVelocity = 360.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 1;                // smoke trail
   trailString = "MortarTrail.dts";
   smokeDist   = 40.8;


   soundId = SoundJetHeavy;
};
//--------------------------------------

ItemImageData SnipeImage
{
	shapeFile = "Sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.4;
	
	fireTime = 0.4;

	ammoType = BulletAmmo;
	projectileType = Stan;
	accuFire = True;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	
};

function SnipeImage::onFire(%player, %slot)
{
if (GameBase::getEnergy(%player) > 20)
{

if (Player::getItemCount(%Player,"EmpPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("EmpShot",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 20);
	}
if (Player::getItemCount(%Player,"FirePack") == 1)
	{
		
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("FireShot",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 40);	
	}
if (Player::getItemCount(%Player,"PoisonPack") == 1)
	{
		
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("PoisonShot",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 30);	
	}
if (Player::getItemCount(%Player,"FlashPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("BlindShot",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 10);
	}

}
}



ItemData SniperGun
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "Sniper";
   validateShape = true;
	hudIcon = "chain";
   heading = "gMulti Shot Guns";
	shadowDetailMask = 4;
	imageType = SnipeImage;
	price = 1025;
	showWeaponBar = true;
};

//--------------------------------------
function SniperGun::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Multi Shot Sniper Rifle: Get modifier packs to use this gun", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
