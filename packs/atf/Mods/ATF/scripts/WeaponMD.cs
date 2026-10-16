//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[RocketLauncher] = DiscAmmo;

//--------------------------------------

$InvList[RocketLauncher] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[RocketLauncher] = 1;
$RemoteInvList[DiscAmmo] = 1;

//--------------------------------------
RocketData StingerMissile
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
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
   trailString = "Plasmabolt.dts";
   smokeDist   = 37.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData StingerMissileTracker
{
bulletShapeName = "Discb.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 2.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 15.0;
terminalVelocity = 2.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 1.0;
nonSeekingTurningRadius = 1.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "plasmatrail.dts";
smokeDist = 10.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};
//--------------------------------------


ItemData DiscAmmo 
{
	description = "DiscAmmo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "Discammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData RocketImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = DiscAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 0.8;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
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
						Tracker(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Rocket Launcher");
	} //=== End standard missile fire.


ItemData RocketLauncher
{
	description = "Misanka DiscLauncher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "cDisc Launchers";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 375;
	showWeaponBar = true;
};

function Tracker(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ "  Just sent a Masanka Disc at you!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 
//--------------------------------------
function RocketLauncher::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "<jc> Masanka Disc's...for all ya'll DBZ fan's this is for you..It shoots high speed discs unless you are pointing your reticle at someone...then it shoots a lower speed disc that will chase the enemy you Locked on until !!BOOM!!", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

$SellAmmo[ESAmmo] = 5;
$AmmoPackMax[ESAmmo] = 15;
$AmmoPackItems[2] = ESAmmo;
$WeaponAmmo[RocketLauncherHG] = ESAmmo;

$SellAmmo[Money] = 1;
$AmmoPackMax[Money] = 1;
$AmmoPackItems[2] = money;
//--------------------------------------

$InvList[RocketLauncherHG] = 1;
$InvList[ESAmmo] = 1;
$RemoteInvList[ESAMMO] = 1;

$RemoteInvList[RocketLauncherHG] = 1;


//--------------------------------------

SeekingMissileData BarrageBolt
{
	bulletShapeName  = "Shield.dts";
	explosionTag     = MortarExp;
	collisionRadius  = 0.0;
	mass             = 1.5;

	damageClass      = 1;
	damageValue      = 0.65;
	damageType       = $BlasterDamageType;

	explosionRadius  = 4.0;
	kickBackStrength = 10.0;
	muzzleVelocity   = 90.0;
	terminalVelocity = 210.0;
	acceleration     = 400.0;
	totalTime        = 20.0;
	liveTime         = 21.0;
	seekingTurningRadius = 1;
	nonSeekingTurningRadius = 1.1;
	proximityDist 	 = 0.3;
	smokeDist 	 = 20.5;
	lightRange       = 1.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

function BarrageBolt::verifyTarget(%this,%target)
{

   if (GameBase::virtual(%target, "getHeatFactor") >= 0.4)
      	return "True";
   else
      	return "False";
}

//--------------------------------------


SeekingMissileData TargetGuided
{
	bulletShapeName  = "Shield.dts";
	explosionTag     = MortarExp;
	collisionRadius  = 0.0;
	mass             = 1.5;

	damageClass      = 1;
	damageValue      = 0.85;
	damageType       = $BlasterDamageType;

	explosionRadius  = 4.0;
	kickBackStrength = 10.0;
	muzzleVelocity   = 80.0;
	terminalVelocity = 210.0;
	acceleration     = 400.0;
	totalTime        = 20.0;
	liveTime         = 21.0;
	seekingTurningRadius = 1;
	nonSeekingTurningRadius = 1.1;
	proximityDist 	 = 0.3;
	smokeDist 	 = 20.5;
	lightRange       = 1.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
function TargetGuided::verifyTarget(%target, %this) { return "True"; }
//--------------------------------------


ItemData ESAmmo 
{
	description = "ELectro Static Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "Shield";
	shadowDetailMask = 4;
	price = 300;
};



ItemData Money 
{
	description = "Credit Disk";
	className = "Ammo";
	heading = "zWallet";
	shapeFile = "Discb";
	shadowDetailMask = 4;
	price = 5000;
};



ItemImageData RocketImageHG 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = ESAmmo;
	projectileType = "Undefined";
	accuFire = True;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImageHG::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncherHG]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncherHG],1);
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
						TrackerHG(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("TargetGuided",%trans,%player,%vel,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("BarrageBolt",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("BarrageBolt",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("BarrageBolt",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the E.S. Ball Launcher");
	} //=== End standard missile fire.


ItemData RocketLauncherHG
{
	description = "E.S. Ball Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "iMass Destruction";
	shadowDetailMask = 4;
	imageType = RocketImageHG;
	price = 2375;
	showWeaponBar = true;
};

function TrackerHG(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ "  has an electro ball sent your way. ~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 
//--------------------------------------
function RocketLauncherHG::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Electro-Static Ball Launcher fires charged Blaster energy in a rapid ball blast. ", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------