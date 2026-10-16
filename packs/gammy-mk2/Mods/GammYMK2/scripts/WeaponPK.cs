//--------------------------------------

$AutoUse[FlameGun2] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackItems[1] = PlasmaAmmo;
$WeaponAmmo[FlameGun2] = PlasmaAmmo;

//--------------------------------------

$InvList[FlameGun2] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[FlameGun2] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

//--------------------------------------

BulletData Flame2Bolt
{
   bulletShapeName    = "Fusionex.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 1.65;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 80.0;
   totalTime          = 5.0;
   liveTime           = 14.0;
   lightRange         = 10.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = PlayerDeath;
};

//--------------------------------------


ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData FlameGun2Image
{
	shapeFile = "Plasmaex";
	mountPoint = 0;
	mountoffset = { 0, 0, 0 };
                mountrotation = { 3, 3, 3 };
	weaponType = 0; // Single Shot
	spinUpTime = 1.9;
	spinDownTime = 3;
	ammoType = PlasmaAmmo;
	projectileType = Flame2Bolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;

	lightType = 1;  // Weapon Fire
	lightRadius = 20;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundLandonground;
	sfxReload = SoundJetMedium;
	sfxReady = SoundTankIdle;
};

ItemData FlameGun2
{
	description = "Beam Attack";
	className = "Weapon";
	shapeFile = "PlasmaBolt";
	hudIcon = "plasma";
   heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = FlameGun2Image;
	price = 1095;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function FlameGun2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " Beam Attack....This upgrade let's you turn regular plasma bolts into Super Beams of fire formed in your hands... DBZ Charge Time 1.5 seconds", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------
$AutoUse[XRad] = True;

//--------------------------------------

GrenadeData XradShell
{
   bulletShapeName    = "Plasmaex.dts";
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.9;
   damageType         = $AlienDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};

GrenadeData XradShellX2
{
   bulletShapeName    = "Mortar.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.3;
   damageType         = $AlienDamageType;

   explosionRadius    = 18.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Mortarex.dts";
};

//--------------------------------------


ItemImageData XradImage
{
	shapeFile = "Force";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	mountoffset = { 0, -0.3, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { 0, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	projectileType = Cartman;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;
	minEnergy = 200;
	maxEnergy = 200;
	lightType = 3;  // Weapon Fire
	lightRadius = 20;
	lightTime = 4;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMortarFire;
	sfxActivate = SoundLandOnGround;
	sfxReload = SoundLandOnGround;
	sfxReady = SoundMortarIdle;
};

function XradImage::onFire(%player, %slot)
{
if (Player::getItemCount(%Player,"EnergyPack5") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	
	for(%pelletCount=0; %pelletCount<=1; %pelletCount++)
		{
	Projectile::spawnProjectile("XradShellX2",%transform,%player,%velocity);
		}
	}
if (Player::getItemCount(%Player,"EnergyPack4") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	
	for(%pelletCount=0; %pelletCount<=1; %pelletCount++)
		{
	Projectile::spawnProjectile("Xradshell",%transform,%player,%velocity);
	        }
	}
}


ItemData Xrad
{
	description = "-=Radiate=-";
	className = "Weapon";
	shapeFile = "Force";
	hudIcon = "mortar";
   heading = "wAttacks";
	shadowDetailMask = 4;
	imageType = XradImage;
	price = 3075;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function Xrad::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "-=Radiate=- this is an attack all Aliens have, It releases the energy in their Nuclear Core, Short range but very powerful. Energy needed to fire: 2/3 and Core Generator", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
$SellAmmo[StrikeXAmmo] = 2;
$AmmoPackMax[StikeXAmmo] = 10000;
$AmmoPackItems[2] = StrikeXAmmo;
$WeaponAmmo[RocketLauncher2x] = StrikeXAmmo;

$InvList[StrikeXAmmo] = 1;
$RemoteInvList[StrikeXAmmo] = 1;


SeekingMissileData KH2x
{
   bulletShapeName    = "ShotgunEx.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $AlienDamageType;

   explosionRadius  = 5.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 30.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
    seekingTurningRadius = 5.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 1;                // smoke trail
   trailString = "Plasmaex.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData KH2x2
{
   bulletShapeName    = "MortarEx.dts";
   explosionTag       = MortarExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $AlienDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 60.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
    seekingTurningRadius = 5.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 1;                // smoke trail
   trailString = "Plasmaex.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

//--------------------------------------
ItemData StrikeXAmmo
{
	description = "Core Power";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "ammo2";
	shadowDetailMask = 4;
	price = 500;
};


ItemImageData RocketImage2X
{
	shapeFile = "Force";
	mountPoint = 0;
	mountOffset = { 0, 0, 250 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	projectileType = "Undefined";
	accuFire = True;
	ammoType = StikeXammo;
	minEnergy = 200; //100
	maxEnergy = 299; //150
	reloadTime = 3.2; //0.2
	fireTime = 0; //6.3
	lightType = 3;
	lightRadius = 30;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundTankActive;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundTankActive;
	sfxReady = SoundFlyerActive;
};

function RocketImage2X::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher2X]);
	 %armor = Player::getArmor(%player);
	
		
	   if(Player::getItemCount(%player,"EnergyPack4") == 1) 
		{			 
		if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher2X],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape" || %object == "SimTerrain") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker2X(%client,%targetId);
						Client::sendMessage(%client,0,"** Target Accepted - " @ %name @ "~wmine_act.wav");


Projectile::SpawnProjectile("KH2X",%trans,%player,%vel+50,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel+60,$los::object);
Projectile::spawnProjectile("KH2X",%trans,%player,%vel+70,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel+80,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel+90,$los::object);
Projectile::spawnProjectile("KH2X",%trans,%player,%vel+100,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel+110,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel+120,$los::object);
Projectile::spawnProjectile("KH2X",%trans,%player,%vel+130,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel+140,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel+150,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel-50,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel-60,$los::object);
Projectile::spawnProjectile("KH2X",%trans,%player,%vel-70,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel-80,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel-90,$los::object);
Projectile::spawnProjectile("KH2X",%trans,%player,%vel-100,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel-110,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel-120,$los::object);
Projectile::spawnProjectile("KH2X",%trans,%player,%vel-130,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel-140,$los::object);
Projectile::SpawnProjectile("KH2X",%trans,%player,%vel-150,$los::object);	
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");
						
					}
				 }
				 else
				 {
Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");					 
				 }
		 	}
			else
			{
Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");				
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"Not enough energy for the Cosmic Plasma Attack ~waccess_denied.wav");

	}
	
	 if(Player::getItemCount(%Player,"EnergyPack5") == 1) 
		{			 
		if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher2X],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape" || %object == "SimTerrain") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker2X(%client,%targetId);
						Client::sendMessage(%client,0,"** Target Accepted - " @ %name @ "~wmine_act.wav");


Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel+50,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel+60,$los::object);
Projectile::spawnProjectile("KH2X2",%trans,%player,%vel+70,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel+80,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel+90,$los::object);
Projectile::spawnProjectile("KH2X2",%trans,%player,%vel+100,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel+110,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel+120,$los::object);
Projectile::spawnProjectile("KH2X2",%trans,%player,%vel+130,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel+140,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel+150,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel-50,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel-60,$los::object);
Projectile::spawnProjectile("KH2X2",%trans,%player,%vel-70,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel-80,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel-90,$los::object);
Projectile::spawnProjectile("KH2X2",%trans,%player,%vel-100,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel-110,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel-120,$los::object);
Projectile::spawnProjectile("KH2X2",%trans,%player,%vel-130,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel-140,$los::object);
Projectile::SpawnProjectile("KH2X2",%trans,%player,%vel-150,$los::object);	
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");
						
					}
				 }
				 else
				 {
Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");					 
				 }
		 	}
			else
			{
Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");				
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"Not enough energy for the Cosmic Assault ~waccess_denied.wav");

	}	


} //=== End standard missile fire.


ItemData RocketLauncher2X
{
	description = "Cosmic Assault";
	className = "Weapon";
	shapeFile = "Tumult_Large";
	hudIcon = "mortar";
    heading = "wAttacks";
	shadowDetailMask = 4;
	imageType = RocketImage2X;
	price = 2375;
	showWeaponBar = true;
};

function Tracker2X(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " Computer systems have detected an unknown Energy on a collision course with your armor!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher2x::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Cosmic Assault draws plasma energy from space to attack the target. Once called it can't be stopped. Energy Needed to fire: Must have Core Power, Core Generator, and 3/3 energy", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------