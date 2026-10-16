//--------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher3] = EnergyAmmo;

//--------------------------------------

$InvList[RocketLauncher3] = 1;
$InvList[EnergyAmmo] = 1;
$RemoteInvList[RocketLauncher3] = 1;
$RemoteInvList[EnergyAmmo] = 1;

//--------------------------------------
SeekingMissileData BFG
{
   bulletShapeName    = "FusionBolt.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 15.0;
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
   trailString = "Rsmoke.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData BFG2
{
   bulletShapeName    = "Fusionex.dts";
   explosionTag       = GrenadeExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 15.0;
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
   trailString = "shield_medium.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

RocketData BFG3
{
   bulletShapeName = "FusionBolt.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

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
   trailString = "PlasmaBolt.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

RocketData BFG5
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
   trailString = "FusionEx.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

RocketData BFG6
{
   bulletShapeName = "ENEX.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

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
   trailString = "ENEX.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData BFG4
{
bulletShapeName = "enex.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 1.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 15.0;
terminalVelocity = 30.0;
acceleration = 20.0;
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

ItemImageData RocketImage3
{
	shapeFile = "Mortargun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 2.3;
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

function RocketImage3::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher3]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher3],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "SimTerrain") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker3(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("BFG",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("BFG2",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("BFG4",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("SWAWave2",%trans,%player,%vel,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("BFG3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("BFG5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("BFG6",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("SWAWave",%trans,%player,%vel,$los::object);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("BFG3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("BFG5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("BFG6",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("SWAWave",%trans,%player,%vel,$los::object);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("BFG3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("BFG5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("BFG6",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("SWAWave",%trans,%player,%vel,$los::object);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the BFG");


} //=== End standard missile fire.


ItemData RocketLauncher3
{
	description = "BFG";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "iMass Destruction";
	shadowDetailMask = 4;
	imageType = RocketImage3;
	price = 3375;
	showWeaponBar = true;
};

function Tracker3(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ "  Just sent a BFG Blast in your direction!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher3::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "This BFG is one of the most powerful guns invented, It was designed back on Okera'eron 6 when the R&D lab was working on a new plasma gun (BFP?)", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------