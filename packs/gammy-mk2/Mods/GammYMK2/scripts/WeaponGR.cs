//--------------------------------------

$SellAmmo[GhostAmmo] = 5;
$AmmoPackMax[GhostAmmo] = 15;
$AmmoPackItems[2] = GhostAmmo;
$WeaponAmmo[RocketLauncher5] = GhostAmmo;

//--------------------------------------

$InvList[RocketLauncher5] = 1;
$InvList[GhostAmmo] = 1;
$RemoteInvList[RocketLauncher5] = 1;
$RemoteInvList[GhostAmmo] = 1;
//--------------------------------------------------------------
ExplosionData CloudExp
{
   shapeName = "tumult_large.dts";
   soundId   = SoundFireGrenade;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 15.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};
//--
RocketData FakeMissile
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = SCloudExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 0.0;

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
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData FakeMissileTracker
{
bulletShapeName = "Rocket.dts";
explosionTag = SCloudExp;
collisionRadius = 5.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.0;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 0.0;
muzzleVelocity = 80.0;
terminalVelocity = 150.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.0;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "plasmatrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

SeekingMissileData RealMissileTracker
{
bulletShapeName = "Laserhit.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 1.5;
damageType = $MissileDamageType;
explosionRadius = 11.5;
kickBackStrength = 1000.0;
muzzleVelocity = 25.0;
terminalVelocity = 27.0;
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
trailType = 1;
trailString = "";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};
//--------------------------------------


ItemData GhostAmmo 
{
	description = "Hunter Rockets";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "Rocket";
	shadowDetailMask = 4;
	price = 250;
};

ItemImageData Rocket5Image 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = GhostAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 1.8;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function Rocket5Image::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher5]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher5],1);
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
						Tracker5(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("FakeMissileTracker",%trans,%player,%vel,$los::object);
Projectile::spawnProjectile("RealMissileTracker",%trans,%player,%vel,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("FakeMissile",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("FakeMissile",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("FakeMissile",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Ghost Rocket Launcher");
	} //=== End standard missile fire.


ItemData RocketLauncher5
{
	description = "HuNtErRocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "bRocket Launchers";
	shadowDetailMask = 4;
	imageType = Rocket5Image;
	price = 3375;
	showWeaponBar = true;
};

function Tracker5(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " has a target lock on you!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 
//--------------------------------------
function RocketLauncher5::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The HuNtErRocket Launcher fires off a rocket filled with a substance which upon impact will make clouds of smoke, upon lock on it will fire to missiles, one non damaging ghost missile and one Nuke Missile", 10);Weapon::onUse(%player,%item);
}
