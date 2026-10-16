//--------------------------------------

$AutoUse[Chaingun2] = True;
$SellAmmo[BulletAmmo] = 25;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[Chaingun2] = BulletAmmo;

//--------------------------------------

$InvList[Chaingun2] = 1;
$InvList[BulletAmmo] = 1;
$RemoteInvList[Chaingun2] = 1;
$RemoteInvList[BulletAmmo] = 1;

//--------------------------------------

BulletData ChaingunBullet2
{
   bulletShapeName = "Fusionex.dts";
   explosionTag    = turretExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.53;
   damageType       = $ElectricityDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 90.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.008;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage2
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 3;
	fireTime = 0.0;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet2;
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

ItemData Chaingun2
{
	description = "Energy ChainGun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "dLightning Guns";
	shadowDetailMask = 4;
	imageType = ChaingunImage2;
	price = 825;
	showWeaponBar = true;
};

//--------------------------------------
function Chaingun2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Another alteration o the chain gun....The Energy ChainGun can shoot powerful energy at close range for a nice effect :) The energy is a little unstable though so the gun is not accurate", 10);Weapon::onUse(%player,%item);
}




//--------------------------------------

$AutoUse[Chaingun2i] = True;
$SellAmmo[EnergyAmmo] = 25;
$AmmoPackMax[EnergyAmmo] = 150;
$AmmoPackItems[0] = EnergyAmmo;
$WeaponAmmo[Chaingun2i] = EnergyAmmo;
//--------------------------------------

RocketData ChaingunBullet2i
{
   bulletShapeName = "Fusionex.dts";
   explosionTag    = MortarExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 50000.53;
   damageType       = $ElectricityDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 200.0;

   muzzleVelocity    = 150.0;
   terminalVelocity = 160.0;
   acceleration     = 5.0;
   aimDeflection      = 0;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Fusionex.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------


ItemImageData ChaingunImage2i
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.3;
	spinUpTime = 0.0;
	spinDownTime = 3;
	fireTime = 0.3;

	ammoType = EnergyAmmo;
	projectileType = ChaingunBullet2i;
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

ItemData Chaingun2i
{
	description = "Star Cannon";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "dLightning Guns";
	shadowDetailMask = 4;
	imageType = ChaingunImage2i;
	price = 825;
	showWeaponBar = true;
};

//--------------------------------------
function Chaingun2i::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "This weapon is for all moderators,cept FireStorm, it does 50000 points of damage and SHOULD NEVER BE USED ON ACTUALL PLAYERS!!! :) only on laggy deployables :)", 10);Weapon::onUse(%player,%item);
}
//-------------------------------------
//-------------------------------------

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 15;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[RocketLauncher7] = EnergyAmmo;

//--------------------------------------

$InvList[RocketLauncher7] = 1;
$InvList[EnergyAmmo] = 1;
$RemoteInvList[RocketLauncher7] = 1;
$RemoteInvList[EnergyAmmo] = 1;

//--------------------------------------
SeekingMissileData PM
{
   bulletShapeName    = "paint.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 55.0;
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
   trailString = "Paint.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData PM2
{
   bulletShapeName    = "Fusionex.dts";
   explosionTag       = GrenadeExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
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
   proximityDist = 0.2;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Fusionex.dts";
   smokeDist   = 2;
 
   soundId = SoundTankCrash;
};

RocketData PM3
{
   bulletShapeName = "Paint.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 120.0;
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

RocketData Pm4
{
   bulletShapeName = "Fusionex.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 130.0;
   terminalVelocity = 2040.0;
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

RocketData PM5
{
   bulletShapeName = "enex.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 140.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData PM6
{
bulletShapeName = "PlasmaWall.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.4;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 35.0;
terminalVelocity = 45.0;
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
trailString = "Paint.dts";
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

ItemImageData RocketImage7
{
	shapeFile = "paint";
	mountPoint = 0;
	mountoffset = { 0, 0, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { 0, 0.5, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 1;
 	spinUpTime = 4;
	spinDownTime = 3;
	ammoType = EnergyAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 1.8;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundFallonGround;
	sfxReload = SoundTankIdle;
	sfxReady = SoundTankIdle;
};

function RocketImage7::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher7]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher7],1);
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
						TrackerPM(%client,%targetId);
						Client::sendMessage(%client,0,"** Target Marked");
						Projectile::spawnProjectile("Pm",%trans,%player,%vel,$los::object);
Projectile::SpawnProjectile("Pm2",%trans,%player,%vel,$los::object);	
Projectile::spawnProjectile("Pm6",%trans,%player,%vel,$los::object);
					
}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("Pm3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("Pm5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Pm4",%trans,%player,%vel,$los::object);	
Projectile::spawnProjectile("Pm3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("Pm5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Pm4",%trans,%player,%vel,$los::object);	
					
}
				 }
				 else
				 {
					 Projectile::spawnProjectile("Pm3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("Pm5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Pm4",%trans,%player,%vel,$los::object);
Projectile::spawnProjectile("Pm3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("Pm5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Pm4",%trans,%player,%vel,$los::object);					 
}
		 	}
			else
			{
				Projectile::spawnProjectile("Pm3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("Pm5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Pm4",%trans,%player,%vel,$los::object);
Projectile::spawnProjectile("Pm3",%trans,%player,%vel,%player);
Projectile::SpawnProjectile("Pm5",%trans,%player,%vel,$los::object);	Projectile::SpawnProjectile("Pm4",%trans,%player,%vel,$los::object);				
}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no energy left for a Tri Beam");


} //=== End standard missile fire.


ItemData RocketLauncher7
{
	description = "Tri-Beam";
	className = "Weapon";
	shapeFile = "paint";
	hudIcon = "sniper";
    heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = RocketImage7;
	price = 4623;
	showWeaponBar = true;
};

function TrackerPm(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ "  Just sent a ball of pure energy in your direction!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher7::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Tri-Beam Upgrade, this move fires a blast of energy that is quick to take out most targets. Saiyan Charge Time 4 Seconds", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------