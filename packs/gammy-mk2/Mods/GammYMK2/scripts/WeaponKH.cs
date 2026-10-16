//--------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher2i] = EnergyAmmo;

SeekingMissileData KH2i
{
   bulletShapeName    = "Fusionex.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.9;
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
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "PlasmaBolt.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData SWAWave2i
{
   bulletShapeName    = "PlasmaBolt.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 30.0;
   terminalVelocity = 30.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
   seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield_medium.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};

RocketData StingerMissile2i
{
   bulletShapeName = "Shield_large.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
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
   trailString = "Shield_large.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData StingerMissileTracker2i
{
bulletShapeName = "Shield.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1.9;
damageValue = 0.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 20.0;
terminalVelocity = 30.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "PlasmaTrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;

};




ItemImageData RocketImage2i
{
	shapeFile = "MortarGun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 0.2;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImage2i::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher2i]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher2i],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker2i(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("StingerMissileTracker2i",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("SWAWave2i",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("KH2i",%trans,%player,%vel,$los::object);	
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("StingerMissile2i",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("StingerMissile2i",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("StingerMissile2i",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the AutomeHa");


} //=== End standard missile fire.


ItemData RocketLauncher2i
{
	description = "Automeha";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = RocketImage2i;
	price = 1375;
	showWeaponBar = true;
};

function Tracker2i(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ "  Just sent a Kama-Ha-Ma-Ha Wave at you!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher2i::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "AutoMeHa was made for NOone and BUT ME...only he can use this gun, If you are ME then enjoy", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher2S] = EnergyAmmo;


$InvList[RocketLauncher2s] = 1;
$InvList[EnergyAmmo] = 1;
$RemoteInvList[RocketLauncher2s] = 1;
$RemoteInvList[EnergyAmmo] = 1;


SeekingMissileData KH2s
{
   bulletShapeName    = "Shield_large.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.9;
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
    seekingTurningRadius = 5.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "PlasmaTrail.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData SWAWave2s
{
   bulletShapeName    = "Shield_Medium.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3.5;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

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
   trailType   = 2;                // smoke trail
   trailString = "shield_medium.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};

RocketData StingerMissile2s
{
   bulletShapeName = "Shield_large.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
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
   trailType   = 3;                // smoke trail
   trailString = "Shield_large.dts";
   smokeDist   = 0.1;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData StingerMissileTracker2s
{
bulletShapeName = "Fusionex.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 2.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 50.0;
terminalVelocity = 30.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 5.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 30.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "Plasmabolt.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;

};




ItemImageData RocketImage2s
{
	shapeFile = "Tumult_Large";
	mountPoint = 0;
	mountOffset = { 0, 0, 250 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 1;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	minEnergy = 100; //100
	maxEnergy = 150; //150
	reloadTime = 0.2; //0.2
	spinUpTime = 10.5; //10.5
	spinDownTime = 3;
	fireTime = 6.3; //6.3
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxSpinUp = SoundRepairItem;
	sfxSpinDown = SoundPlayerInjured;
	sfxFire = SoundTankActive;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundTankActive;
	sfxReady = SoundFlyerActive;
};

function RocketImage2s::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher2s]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher2s],1);
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
						Tracker2s(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");

Projectile::spawnProjectile("StingerMissileTracker2s",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("SWAWave2s",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("KH2s",%trans,%player,%vel,$los::object);	
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
			Client::sendMessage(Player::getClient(%player), 0,"Not enough KI for the Spirit Bomb ~waccess_denied.wav");


} //=== End standard missile fire.


ItemData RocketLauncher2s
{
	description = "Spirit Bomb Attack";
	className = "Weapon";
	shapeFile = "Tumult_Large";
	hudIcon = "mortar";
    heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = RocketImage2s;
	price = 2375;
	showWeaponBar = true;
};

function Tracker2s(%clientId, %targetId, %delay) 
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
function RocketLauncher2s::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Spirit Bomb Attack, this attack pulls energy from the planet you are on and then releases a very strong blast. DBZ Charge Time 10.7 seconds", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher2Si] = EnergyAmmo;


SeekingMissileData KH2sMouse
{
   bulletShapeName    = "hover_apc.dts";
   explosionTag       = MortarExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 4.9;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
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
   trailType   = 2;                // smoke trail
   trailString = "PlasmaTrail.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData SWAWave2sMouse
{
   bulletShapeName    = "hover_apc_sml.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5.5;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
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
   trailType   = 2;                // smoke trail
   trailString = "shield_medium.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};


//--------------------------------------

SeekingMissileData StingerMissileTracker2smouse
{
bulletShapeName = "flyer.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 7.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 150.0;
terminalVelocity = 150.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 5.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 30.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "PlasmaTrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;

};




ItemImageData RocketImage2si
{
	shapeFile = "Tumult_Large";
	mountPoint = 0;
	mountOffset = { 0, 0, 750 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 1;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	minEnergy = 30; //100
	maxEnergy = 40; //150
	reloadTime = 0.2; //0.2
	spinUpTime = 2.5; //10.5
	spinDownTime = 3;
	fireTime = 2.3; //6.3
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxSpinUp = SoundRepairItem;
	sfxSpinDown = SoundPlayerInjured;
	sfxFire = SoundTankActive;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundTankActive;
	sfxReady = SoundFlyerActive;
};

function RocketImage2si::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher2si]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher2si],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape" ) 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker2si(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");

Projectile::spawnProjectile("StingerMissileTracker2sMouse",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("SWAWave2sMouse",%trans,%player,%vel-10,$los::object);
Projectile::SpawnProjectile("KH2sMouse",%trans,%player,%vel+10,$los::object);	
Projectile::spawnProjectile("StingerMissileTracker2sMouse",%trans,%player,%vel+10,$los::object);
Projectile::SpawnProjectile("SWAWave2sMouse",%trans,%player,%vel-50,$los::object);
Projectile::SpawnProjectile("KH2sMouse",%trans,%player,%vel-10,$los::object);	
Projectile::spawnProjectile("StingerMissileTracker2sMouse",%trans,%player,%vel+80,$los::object);
Projectile::SpawnProjectile("SWAWave2sMouse",%trans,%player,%vel-40,$los::object);
Projectile::SpawnProjectile("KH2sMouse",%trans,%player,%vel+20,$los::object);	
Projectile::spawnProjectile("StingerMissileTracker2sMouse",%trans,%player,%vel+40,$los::object);
Projectile::SpawnProjectile("SWAWave2sMouse",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("KH2sMouse",%trans,%player,%vel-50,$los::object);	
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
			Client::sendMessage(Player::getClient(%player), 0,"Not enough power!!! ~waccess_denied.wav");


} //=== End standard missile fire.


ItemData RocketLauncher2si
{
	description = "Mouse Strike";
	className = "Weapon";
	shapeFile = "Tumult_Large";
	hudIcon = "mortar";
    heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = RocketImage2si;
	price = 2375;
	showWeaponBar = true;
};

function Tracker2si(%clientId, %targetId, %delay) 
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
function RocketLauncher2si::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Mouse Strike....Gamma's very own admin gun :)", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------