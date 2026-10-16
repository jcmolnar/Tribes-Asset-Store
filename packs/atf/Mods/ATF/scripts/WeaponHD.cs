//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 45;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[HD] = DiscAmmo;

//--------------------------------------

$InvList[HD] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[HD] = 1;
$RemoteInvList[DiscAmmo] = 1;

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


RocketData HDShell
{
   bulletShapeName = "Discb.dts";
   explosionTag    = Rocketexp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 250.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 310.0;
   acceleration     = 0.01;

   totalTime        = 16.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData HDImage
{
	shapeFile = "MortarGun";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = HDShell;
	accuFire = true;
	reloadTime = 0.06;
	fireTime = 0.06;
	
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData HD
{
	description = "Heavy DiscLauncher";
	className = "Weapon";
	shapeFile = "discb";
	hudIcon = "disk";
   heading = "cDisc Launchers";
	shadowDetailMask = 4;
	imageType = HDImage;
	price = 450;
	showWeaponBar = true;
};

//--------------------------------------
function HD::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Heavy Disc Launcher, Devised and created by a Newbie from sector 21012..after creation, this weapon became a favorite of most heavies out there", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher2] = EnergyAmmo;

//--------------------------------------

$InvList[RocketLauncher2] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[RocketLauncher2] = 1;
$RemoteInvList[DiscAmmo] = 1;

//--------------------------------------
SeekingMissileData KH2
{
   bulletShapeName    = "PlasmaBolt.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.9;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 45.0;
   terminalVelocity = 50.0;
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
   trailString = "PlasmaTrail.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData SWAWave2
{
   bulletShapeName    = "Shield_large.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 45.0;
   terminalVelocity = 50.0;
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

RocketData StingerMissile2
{
   bulletShapeName = "Shield.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.9;
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
   smokeDist   = 5;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData StingerMissileTracker2
{
bulletShapeName = "Shield_large.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1.9;
damageValue = 0.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 45.0;
terminalVelocity = 50.0;
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
//--------------------------------------


ItemImageData RocketImage2 
{
	shapeFile = "plasmatrail";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 1;
	spinUpTime = 4.5;
	spinDownTime = 3;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 4.3;
	fireTime = 1.8;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundLandOnGround;
	sfxReload = SoundLandonGround;
	sfxReady = SoundTankIdle;
	sfxSpinUp = SoundPlayerDeath;
	sfxSpinDown = SoundPlayerDeath;
};

function RocketImage2::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher2]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher2],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker2(%client,%targetId);
						Client::sendMessage(%client,0,"** Target Marked");
						Projectile::spawnProjectile("StingerMissileTracker2",%trans,%player,%vel,$los::object);
						Projectile::SpawnProjectile("SWAWave2",%trans,%player,%vel,$los::object);
						Projectile::SpawnProjectile("KH2",%trans,%player,%vel,$los::object);	
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("StingerMissile2",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("StingerMissile2",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("StingerMissile2",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Kama-Ha-Ma-Ha");


} //=== End standard missile fire.


ItemData RocketLauncher2
{
	description = "Kama-Ha-Ma-Ha";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = RocketImage2;
	price = 2375;
	showWeaponBar = true;
};

function Tracker2(%clientId, %targetId, %delay) 
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
function RocketLauncher2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Kama-Ha-Ma-Ha Upgrade...another innovation from DBZ...Difference is this KHMH wave can chase a target if aimed right. Saiyan Charge time 4.5 seconds", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------


$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher2SS] = EnergyAmmo;

//--------------------------------------


//--------------------------------------
SeekingMissileData KH2SS
{
   bulletShapeName    = "PlasmaBolt.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.9;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 80.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 1.5;
    seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 0.0;
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 1;                // smoke trail
   trailString = "PlasmaEx.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData SWAWave2SS
{
   bulletShapeName    = "Shield_large.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 80.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 1.5;
   seekingTurningRadius = 0.0;
   nonSeekingTurningRadius = 0.0;
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 1;                // smoke trail
   trailString = "shield_medium.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};

RocketData StingerMissile2SS
{
   bulletShapeName = "Shield.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.9;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 1.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shield_large.dts";
   smokeDist   = 5;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData StingerMissileTracker2ss
{
bulletShapeName = "Shield_large.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 1.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 75.0;
terminalVelocity = 80.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 1.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 0.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 1;
trailString = "PlasmaTrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;

};
//--------------------------------------


ItemImageData RocketImage2ss
{
	shapeFile = "Plasmaex";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 1;
	spinUpTime = 3.5;
	spinDownTime = 3;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = True;
	reloadTime = 1.3;
	fireTime = 0.7;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundLandOnGround;
	sfxReload = SoundLandonGround;
	sfxReady = SoundTankIdle;
	sfxSpinUp = SoundPlayerDeath;
	sfxSpinDown = SoundPlayerDeath;
};

function RocketImage2SS::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher2ss]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher2ss],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker2ss(%client,%targetId);
						Client::sendMessage(%client,0,"** Target Marked");
						Projectile::spawnProjectile("StingerMissileTracker2ss",%trans,%player,%vel,$los::object);
						Projectile::SpawnProjectile("SWAWave2ss",%trans,%player,%vel,$los::object);
						Projectile::SpawnProjectile("KH2ss",%trans,%player,%vel,$los::object);	
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("StingerMissile2ss",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("StingerMissile2ss",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("StingerMissile2ss",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Kama-Ha-Ma-Ha");


} //=== End standard missile fire.


ItemData RocketLauncher2ss
{
	description = "Kame-Ha-Me-Ha";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = RocketImage2SS;
	price = 2375;
	showWeaponBar = true;
};

function Tracker2ss(%clientId, %targetId, %delay) 
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
function RocketLauncher2SS::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "<jc> Super Saiyan Kamehameha", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------