// I searched for 20 minutes and finally found this is where i stashed the multi shot guns...or atleast 2 of them :(

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
	%rndCheck=Floor(getRandom()*3);
		Projectile::spawnProjectile("BlasterBolt",%transform,%player,%velocity+%rndCheck); 
		 Projectile::spawnProjectile("BlasterBolt",%transform,%player,%velocity-%rndCheck); 
		Projectile::spawnProjectile("BlasterBolt",%transform,%player,%velocity);
		GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 5);

	}
}

ItemData Blaster
{
   heading = "fPlasma Guns";
	description = "Energy Blaster";
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
	bottomprint(Player::getClient(%Client), " The Energy Blaster is a plasma energy blast with that extra little kick that makes arsonist smile :) handle with care cause it is easy to blow your self to little charred pieces  :)", 10);Weapon::onUse(%Client,%item);
}
//================================ GodHammerCannon...from shifter.....well a little bit of it

//--------------------------------------

SeekingMissileData Bulletic
{
   bulletShapeName = "rocket.dts";
   explosionTag    = PlasmaExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};


//--------------------------------------



ItemImageData Hammer1PackImage
{ 
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0.5, 0.0, 0.0 }; 
	mountRotation = { 0, 0, -0.01 }; 
	weaponType = 0; 
	projectileType = Candice; 
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
	description = "SMBlast";
	shapeFile = "paintgun";
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
{
}

function Hammer1PackImage::onDeactivate(%player,%imageSlot)
{ Player::trigger(%player,$BackPackSlot,false); 
}

ItemImageData Hammer2PackImage
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
	mountOffset = { -0.5, 0.0, 0.0 };
	mountRotation = { 0, 0, 0.01 };
	weaponType = 0;
	projectileType = Crystal; 
	accuFire = true; 
	reloadTime = 0.1;
	fireTime = 2.2;
	ammoType = EnergyAmmo;
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 1.0 }; 
}; 

ItemData Hammer2Pack 
{ 
	description = "SMBlast 2";
	shapeFile = "paintgun";
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




function Hammer1PackImage::onFire(%player) 
{

%energy=GameBase::getEnergy(%player);
			if(%energy>49){
				client::sendMessage(%client,2,"Main power re-routed to Mini-Sentinel");
				GameBase::setRechargeRate(%player, 4);
				%client = Player::getClient(%player);
				%Sensor2 = newObject("remoteTurret","Turret",RocketTurret2i,true); 
	   			GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 50);
				addToSet("MissionCleanup", %sensor2);
				Client::setOwnedObject(%client, %Sensor2); 
				Client::setOwnedObject(%client, %player);				      
				gameBase::setTeam(%sensor2,GameBase::getTeam(%player));
				gameBase::setRotation(%sensor2,"0 0 0");// %rot
				gameBase::setPosition(%sensor2,GameBase::getPosition(%player));
				gamebase::setMapName(%sensor2,"Mini Sentinel#" @ $totalNumPlatforms++ @ " " @  Client::getName(%client));
				client::sendMessage(%client,2,"Main power re-routed to Mini-Sentinel");
				GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player)-4);
				client::sendMessage(%client,3,"Mini Sentinel Placed");
				playSound(SoundPickupBackpack,$los::position);
				
				}
			else{
			client::sendMessage(%client,2,"Not enough power to manufacture a turret");
			}

}


function Hammer2PackImage::onActivate(%player,%imageSlot)
{

}
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
   damageValue      = 0.02;
   damageType       = $ShockDamageType;

   muzzleVelocity    = 60.0;
   terminalVelocity = 70.0;
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
   damageValue      = 0.05;
   damageType       = $BurnDamageType;

   muzzleVelocity    = 40.0;
   terminalVelocity = 50.0;
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


BulletData ChaingunBulletEnergy
{
   bulletShapeName = "Bullet.dts";
   explosionTag    = Acidexp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $BlasterDamageType;

   muzzleVelocity    = 60.0;
   terminalVelocity = 70.0;
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

   muzzleVelocity    = 100.0;
   terminalVelocity = 110.0;
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
   damageValue      = 0.03;
   damageType       = $PoisonDamageType;

   muzzleVelocity    = 50.0;
   terminalVelocity = 60.0;
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
	reloadTime = 0.3;
	spinUpTime = 0.5;
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
if (Player::getItemCount(%Player,"EnerBurstPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	for(%ener=GameBase::getEnergy(%player);%ener>0;%ener--)
	{
	Projectile::spawnProjectile("ChaingunBulletEnergy",%transform,%player,%velocity);
	GameBase::setEnergy(%player, (GameBase::getEnergy(%player)-1));
	}
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

RocketData EnergyShot
{
   bulletShapeName = "PlasmaBolt.dts";
   explosionTag    = AcidExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $BlasterDamageType;

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
   trailString = "plasmabolt.dts";
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

	sfxFire = SoundPlasmaFire;
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
	if (Player::getItemCount(%Player,"EnerBurstPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	for(%ener=((GameBase::getEnergy(%player))/10);%ener>0;%ener--)
	{
	Projectile::spawnProjectile("EnergyShot",%transform,%player,%velocity);
	GameBase::setEnergy(%player, (GameBase::getEnergy(%player)-1));
	}
	GameBase::setEnergy(%player, 0);
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
