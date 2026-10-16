//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Cyclone Missile Launcher
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[RocketLauncher] = 1;
$InvList[RocketAmmo] = 1;
$RemoteInvList[RocketLauncher] = 1;
$RemoteInvList[RocketAmmo] = 1;
$AutoUse[RocketLauncher] = False;
$SellAmmo[RocketAmmo] = 5;
$WeaponAmmo[RocketLauncher] = RocketAmmo;

addWeapon(RocketLauncher);
addAmmo(RocketLauncher, RocketAmmo, 2);


ItemData RocketAmmo
{
	description = "Missile";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData RocketImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = RocketAmmo;
	projectileType = StingerMissile;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData RocketLauncher
{
	description = "Missile Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = $InvHead[ihWma];
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 650;
	showWeaponBar = true;
};

function RocketLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "The Missile Launcher locks onto targets, and soon will have variable missile types.");
}

function RocketImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	if(%AmmoCount > 0)
	{
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,3000))
		{
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
				if(%object == "Player" || %object == "Flier")
				{
					%targetP = Client::getName(%targeted);
					Client::sendMessage(%client,0,"HUD-CPU: Missile lock acquired "@ %targetP @"~wpda_on.wav");
					Client::sendMessage(%targeted,0,"HUD-CPU: Missile lock detected - " @ %clientId @ "~waccess_denied.wav");
					Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,$los::object);
									Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
				}
		else
			{
			Projectile::spawnProjectile("StingerMissileW",%trans,%player,%vel,%player);
			
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			}
		}
	else
		{
		Projectile::spawnProjectile("StingerMissileW",%trans,%player,%vel,%player);
		
	Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
		}
	}
	else Client::sendMessage(Player::getClient(%player),0,"Missile Launcher out of ammo.");
}

SeekingMissileData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.55;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 85.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

BulletData StingerMissileW
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 15.0;

   aimDeflection    = 0.006;
   muzzleVelocity   = 65.0;
   totalTime        = 6.0;
   liveTime         = 6.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//-=-=-=-=-==-NEW MARINE MISSILE LAUCNHER AMMO VARIANTS
//Haywire Rocket
SeekingMissileData RocketHaywire
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $FlashDamageType; //fucks up enemy energy sources
   explosionRadius  = 9.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 85.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 1.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//HE Rocket(High Explosive)

SeekingMissileData RocketHE
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.55;
   damageType       = $MissileDamageType; 
   explosionRadius  = 19.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 85.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 1.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//Krak Missile

SeekingMissileData RocketKrak
{
   bulletShapeName = "rocket.dts";
   explosionTag    = bulletExp0;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 2.55;
   damageType       = $MissileDamageType; 
   kickBackStrength = 25.0;
   muzzleVelocity    = 85.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;
   lightRange       = 1.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};
