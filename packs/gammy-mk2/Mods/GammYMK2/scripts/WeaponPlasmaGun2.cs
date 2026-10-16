//--------------------------------------

$AutoUse[PlasmaGun2] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackItems[1] = PlasmaAmmo;
$WeaponAmmo[PlasmaGun2] = PlasmaAmmo;

//--------------------------------------

$InvList[PlasmaGun2] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaGun2] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

//--------------------------------------

RocketData PlasmaBolt2
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 60.0;
   terminalVelocity = 400.0;
   acceleration     = 50.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "PlasmaEX.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
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

ItemImageData PlasmaGun2Image
{
	shapeFile = "sensor_small";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt2;
	accuFire = true;
	reloadTime = 1.1;
	fireTime = 1.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
                sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundELFFire;
                sfxReady = SoundTankIdle;
};

ItemData PlasmaGun2
{
	description = "BFPG";
	className = "Weapon";
	shapeFile = "sensor_small";
	hudIcon = "plasma";
   heading = "fPlasma Guns";
	shadowDetailMask = 4;
	imageType = PlasmaGun2Image;
	price = 875;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function PlasmaGun2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The BFPG....or otherwise known as the Big F*cking Plasma Gun, New improvements have made this an all purpose weapon of choice for all those Heavies out there...", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------


$AutoUse[PlasmaGun3] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackItems[1] = PlasmaAmmo;
$WeaponAmmo[PlasmaGun3] = PlasmaAmmo;

//--------------------------------------

$InvList[PlasmaGun3] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaGun3] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

//--------------------------------------


SeekingMissileData M8a
{
   bulletShapeName    = "Paint.dts";
   explosionTag       = TurretExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 4.3;
   damageType       = $EnergyDamageType;

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
   trailType   = 1;                // smoke trail
   trailString = "Shockwave_Large.dts";
   smokeDist   = 1.8;
 
   soundId = SoundTankCrash;
};

RocketData M5a
{
   bulletShapeName = "Paint.dts";
   explosionTag    = TurretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 4.5;
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
   trailString = "Paint.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------

ItemImageData PlasmaImage3
{
	shapeFile = "Chaingun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = PlasmaAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.7;
	fireTime = 0.7;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function PlasmaImage3::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun3]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[PlasmaGun3],1);
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
						Tracker13(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						
Projectile::SpawnProjectile("m8a",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("m8a",%trans,%player,%vel+5,$los::object);
Projectile::SpawnProjectile("m8a",%trans,%player,%vel+7,$los::object);
Projectile::SpawnProjectile("m8a",%trans,%player,%vel-5,$los::object);
Projectile::SpawnProjectile("m8a",%trans,%player,%vel-7,$los::object);	
			}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
				Projectile::SpawnProjectile("m5a",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("m5a",%trans,%player,%vel+5,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel+7,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel-5,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel-7,$los::object);
}
				 }
				 else
				 {
Projectile::SpawnProjectile("m5a",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("m5a",%trans,%player,%vel+5,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel+7,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel-5,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel-7,$los::object);
				 }
		 	}
			else
			{
Projectile::SpawnProjectile("m5a",%trans,%player,%vel,$los::object);	
Projectile::SpawnProjectile("m5a",%trans,%player,%vel+5,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel+7,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel-5,$los::object);
Projectile::SpawnProjectile("m5a",%trans,%player,%vel-7,$los::object);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the EnergyBeam Cannon...");


} //=== End standard missile fire.


ItemData PlasmaGun3
{
	description = "EnergyBeam Cannon";
	className = "Weapon";
	shapeFile = "Chaingun";
	hudIcon = "plasma";
    heading = "fPlasma Weaponry";
	shadowDetailMask = 4;
	imageType = PlasmaImage3;
	price = 775;
	showWeaponBar = true;
};

function Tracker13(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING **~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 

//--------------------------------------
function PlasmaGun3::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The EnergyBeam Cannon.... Shoots large beams of plasma energy at a quick rate.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------