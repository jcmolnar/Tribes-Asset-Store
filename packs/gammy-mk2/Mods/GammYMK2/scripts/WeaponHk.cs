//--------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher6] = EnergyAmmo;

//--------------------------------------

$InvList[RocketLauncher6] = 1;
$InvList[EnergyAmmo] = 1;
$RemoteInvList[RocketLauncher6] = 1;
$RemoteInvList[EnergyAmmo] = 1;

//--------------------------------------
RocketData SWAWaveH
{
   bulletShapeName    = "FusionEx.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "FUsionbolt.dts";
   smokeDist   = 1.8;
 
   soundId = SoundTankCrash;
};


RocketData BFG5H
{
   bulletShapeName = "FusionEX.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "FusionEx.dts";
   smokeDist   = 1.8;


   soundId = SoundMissileTurretFire;
};

SeekingMissileData Hk
{
   bulletShapeName    = "Fiery.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 30.0;
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
   trailString = "PlasmaEx.dts";
   smokeDist   = 1.8;

   
   soundId = SoundMissileTurretFire;
};

SeekingMissileData Hk2
{
   bulletShapeName    = "Mortarex.dts";
   explosionTag       = GrenadeExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 30.0;
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
   trailString = "Plasmaex.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

RocketData Hk3
{
   bulletShapeName = "Enex.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Enex.dts";
   smokeDist   = 1.8;


   soundId = SoundMissileTurretFire;
};

RocketData Hk4
{
   bulletShapeName = "FusionEX.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Enex.dts";
   smokeDist   = 1.8;


   soundId = SoundMissileTurretFire;
};

RocketData Hk5
{
   bulletShapeName = "Paint.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "ENEX.dts";
   smokeDist   = 1.8;


   soundId = SoundMissileTurretFire;
};

//--------------------------------------

SeekingMissileData Hk6
{
bulletShapeName = "enex.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 2.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 15.0;
terminalVelocity = 30.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 0.2;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "PlasmaTrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
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

ItemImageData RocketImage6
{
	shapeFile = "Mortargun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 1.3;
	fireTime = 3.8;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImage6::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher6]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher6],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker6(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("BFG",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("BFG2",%trans,%player,%vel,$los::object);	
Projectile::spawnProjectile("Hk",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("Hk2",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Hk6",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("SWAWave2",%trans,%player,%vel,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("BFG3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("BFG5H",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("BFG6",%trans,%player,%vel,$los::object);	
Projectile::spawnProjectile("Hk3",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("Hk4",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Hk5",%trans,%player,%vel,$los::object);	
//Projectile::SpawnProjectile("SWAWaveH",%trans,%player,%vel,$los::object);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("BFG3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("BFG5H",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("BFG6",%trans,%player,%vel,$los::object);	
Projectile::spawnProjectile("Hk3",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("Hk4",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Hk5",%trans,%player,%vel,$los::object);	
//Projectile::SpawnProjectile("SWAWaveH",%trans,%player,%vel,$los::object);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("BFG3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("BFG5H",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("BFG6",%trans,%player,%vel,$los::object);	
Projectile::spawnProjectile("Hk3",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("Hk4",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Hk5",%trans,%player,%vel,$los::object);	
//Projectile::SpawnProjectile("SWAWaveH",%trans,%player,%vel,$los::object);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for PimpMo Special");


} //=== End standard missile fire.


ItemData RocketLauncher6
{
	description = "PimpMo Hoes Special";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "iMass Destruction";
	shadowDetailMask = 4;
	imageType = RocketImage6;
	price = 5375;
	showWeaponBar = true;
};

function Tracker6(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ "  Just sent u the PimpMo Special ur WAY!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher6::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "PimpMO Hoe Cannon, This little bitch launches 5 bolts each with its own carnage.. I feel afraid for the goddam target:( NOT!", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher8] = EnergyAmmo;

//--------------------------------------

$InvList[RocketLauncher8] = 1;
$InvList[EnergyAmmo] = 1;
$RemoteInvList[RocketLauncher8] = 1;
$RemoteInvList[EnergyAmmo] = 1;

//--------------------------------------
SeekingMissileData ss
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 45.0;
   terminalVelocity = 30.0;
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

SeekingMissileData ss2
{
   bulletShapeName    = "Plasmaex.dts";
   explosionTag       = GrenadeExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3.6;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 43.0;
   terminalVelocity = 30.0;
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

RocketData ss3
{
   bulletShapeName = "plasmaex.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Enex.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

RocketData ss4
{
   bulletShapeName = "plasmaex.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 97.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

RocketData ss5
{
   bulletShapeName = "plasmaex.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

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
   trailString = "Fusionex.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData ss6
{
bulletShapeName = "plasmaex.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 2.6;
damageType = $PlasmaDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 48.0;
terminalVelocity = 30.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 0.2;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "Shockwave_Large.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
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

ItemImageData RocketImage8
{
	shapeFile = "Mortargun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 3.0;
	fireTime = 3.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImage8::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher8]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher8],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker6(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						
Projectile::spawnProjectile("ss",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("ss2",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("ss6",%trans,%player,%vel,$los::object);	
Projectile::spawnProjectile("Hk",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("Hk2",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Hk6",%trans,%player,%vel,$los::object);		
			}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						
Projectile::spawnProjectile("ss3",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("ss4",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("ss5",%trans,%player,%vel,$los::object);	
					}
				 }
				 else
				 {
					 
Projectile::spawnProjectile("ss3",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("ss4",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("ss5",%trans,%player,%vel,$los::object);	

				 }
		 	}
			else
			{
				Projectile::spawnProjectile("ss3",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("ss4",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("ss5",%trans,%player,%vel,$los::object);	
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the **DiSrUpTeR**");


} //=== End standard missile fire.


ItemData RocketLauncher8
{
	description = "<<PARTICLE DiSrUpTeR>>";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "iMass Destruction";
	shadowDetailMask = 4;
	imageType = RocketImage8;
	price = 15375;
	showWeaponBar = true;
};

function Tracker8(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - I would advise you to run...Someone has a **DiSrUpTeR** blast headed your way!!!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher8::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "This weapon uses Particle energy to disrupt airspace around it so it was given the name Disrupter....very powerful....very deadly", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------


