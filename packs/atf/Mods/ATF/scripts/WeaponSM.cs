//--------------------------------------

$AutoUse[SM] = True;
$WeaponAmmo[SM] = "";

//--------------------------------------

$InvList[SM] = 1;
$RemoteInvList[SM] = 1;

$InvList[SMLASER2] = 1;
$RemoteInvList[SMLASER2] = 1;

//--------------------------------------

RocketData SmLaser2s
{
   bulletShapeName = "Bullet.dts";
   explosionTag    = Plasmaexp;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $LaserDamageType;

   explosionRadius  = 3.5;
   kickBackStrength = 0.0;

   muzzleVelocity   = 500.0;
   terminalVelocity = 6000.0;
   acceleration     = 0;

   totalTime        = 35.5;
   liveTime         = 35.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 650;
   trailWidth  = 5.3;

   soundId = SoundDiscSpin;
};

LaserData SMLaser
{
   laserBitmapName   = "LaserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

   lightRange        = 10.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = False;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------

ItemImageData SMImage
{
	shapeFile = "Plasma";
	mountPoint = 0;
                 mountoffset = { 0, 0, 0 };
                 mountrotation = { 0, 0, 0 };
	weaponType = 0; // Single Shot
	projectileType = Idea;
	accuFire = true;
	reloadTime = 0.9;
	fireTime = 0.9;
	minEnergy = 40;
	maxEnergy = 50;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

function SmImage::onFire(%player, %slot)
{
if (Player::getItemCount(%Player,"EnergyPack2") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	
	for(%pelletCount=0; %pelletCount<=1; %pelletCount++)
		{
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity);
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity+1);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity+1);
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity-1);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity-1);
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity+2);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity+2);
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity-2);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity-2);
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity+3);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity+3);
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity-3);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity-3);
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity+4);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity+4);
	Projectile::spawnProjectile("SmLaser",%transform,%player,%velocity-4);
	Projectile::spawnProjectile("SmLaser2s",%transform,%player,%velocity-4);
	}
	}
}

ItemData SM
{
	description = "Heavy Laser";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "sniper";
   heading = "h:(Snipers Gear:(";
	shadowDetailMask = 4;
	imageType = SMImage;
	price = 400;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

//--------------------------------------
function SM::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Heavy laser is a large heavy only weapon...it is a strong beam that does much damage", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher9] = EnergyAmmo;

//--------------------------------------

$InvList[RocketLauncher9] = 1;
$InvList[EnergyAmmo] = 1;
$RemoteInvList[RocketLauncher9] = 1;
$RemoteInvList[EnergyAmmo] = 1;

//--------------------------------------
SeekingMissileData M
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = RocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 60.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 60.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
    seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 0.2;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shockwave_Large.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData M2
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = rocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 60.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
   seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 0.2;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shockwave_Large.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

SeekingMissileData M3
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = RocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 60.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
   seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 0.2;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shockwave_Large.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

SeekingMissileData M4
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = RocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 60.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
   seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 0.2;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shockwave_Large.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

SeekingMissileData M6
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = RocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 60.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
   seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 0.2;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shockwave_Large.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

SeekingMissileData M7
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = RocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 60.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
   seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 0.2;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shockwave_Large.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

SeekingMissileData M8
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = RocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 60.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
   seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 0.2;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shockwave_Large.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

RocketData M5
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = RocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 10.0;

   muzzleVelocity   = 103.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------


ItemData EnergyAmmo 
{
	description = "Energy Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "Mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData RocketImage9
{
	shapeFile = "Mortargun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImage9::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher9]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher9],4);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape" || %object == "Sensor" || %object == "Station") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker9(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						
Projectile::spawnProjectile("M",%trans,%player,%vel+50,$los::object);
Projectile::SpawnProjectile("M2",%trans,%player,%vel+70,$los::object);	Projectile::spawnProjectile("M3",%trans,%player,%vel+80,$los::object);
Projectile::SpawnProjectile("M4",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("M6",%trans,%player,%vel-50,$los::object);	
Projectile::spawnProjectile("M7",%trans,%player,%vel-70,$los::object);
Projectile::SpawnProjectile("M8",%trans,%player,%vel-80,$los::object);		
			}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
				Projectile::SpawnProjectile("m5",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("m5",%trans,%player,%vel+20,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel+25,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-20,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-25,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-10,$los::object);	
Projectile::SpawnProjectile("m5",%trans,%player,%vel+15,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel+18,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-12,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-23,$los::object);
}
				 }
				 else
				 {
Projectile::SpawnProjectile("m5",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("m5",%trans,%player,%vel+20,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel+25,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-20,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-25,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-10,$los::object);	
Projectile::SpawnProjectile("m5",%trans,%player,%vel+15,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel+18,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-12,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-23,$los::object);
				 }
		 	}
			else
			{
Projectile::SpawnProjectile("m5",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("m5",%trans,%player,%vel+20,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel+25,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-20,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-25,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-10,$los::object);	
Projectile::SpawnProjectile("m5",%trans,%player,%vel+15,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel+18,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-12,$los::object);
Projectile::SpawnProjectile("m5",%trans,%player,%vel-23,$los::object);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Multi-Rocket Launcher");


} //=== End standard missile fire.


ItemData RocketLauncher9
{
	description = "Multi-Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "bRocket Launchers";
	shadowDetailMask = 4;
	imageType = RocketImage9;
	price = 1375;
	showWeaponBar = true;
};

function Tracker9(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - I would advise you to run... " @ %name @ " has fired many rockets that are headed your way!!!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher9::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Multi-Rocket Launcher fires 10 rockets in normal mode...when it has a lockon it fires off 7 missiles to chase your target!!!", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

