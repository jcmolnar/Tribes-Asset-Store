//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Cyclone Missile Launcher
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Cyclone] = 1;
$InvList[CycloneAmmo] = 1;
$RemoteInvList[Cyclone] = 1;
$RemoteInvList[CycloneAmmo] = 1;
$AutoUse[Cyclone] = False;
$SellAmmo[CycloneAmmo] = 5;
$WeaponAmmo[Cyclone] = CycloneAmmo;

addWeapon(Cyclone);
addAmmo(Cyclone, CycloneAmmo, 2);


ItemData CycloneAmmo
{
	description = "Cyclone Missile";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData CycloneImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = CycloneAmmo;
	projectileType = CycloneMissile;
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

ItemData Cyclone
{
	description = "Cyclone Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = $InvHead[ihWma];
	shadowDetailMask = 4;
	imageType = CycloneImage;
	price = 1450;
	showWeaponBar = true;
};

function Cyclone::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "The Cyclone Launcher is a useful beast of a weapon. It's rockets fire in bursts, and are capable of locking onto a target.");
}

function CycloneImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Cyclone]);
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
					Client::sendMessage(%client,0,"HUD-CPU: Cyclone lock acquired "@ %targetP @"~wpda_on.wav");
					Client::sendMessage(%targeted,0,"HUD-CPU: Missile lock detected - " @ %clientId @ "~waccess_denied.wav");
					Projectile::spawnProjectile("CycloneMissile1",%trans,%player,%vel,$los::object);
					Projectile::spawnProjectile("CycloneMissile2",%trans,%player,%vel,$los::object);
					Projectile::spawnProjectile("CycloneMissile3",%trans,%player,%vel,$los::object);
					Projectile::spawnProjectile("CycloneMissile4",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[Cyclone],1);
				}
		else
			{
			Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[Cyclone],1);
			}
		}
	else
		{
		Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
		Player::decItemCount(%player,$WeaponAmmo[Cyclone],1);
		}
	}
	else Client::sendMessage(Player::getClient(%player),0,"Cyclone out of ammo.");
}

SeekingMissileData CycloneMissile1
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
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

SeekingMissileData CycloneMissile2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 85.0;
   totalTime         = 20;
   liveTime          = 20;
   seekingTurningRadius    = 8;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

SeekingMissileData CycloneMissile3
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 85.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 7;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

SeekingMissileData CycloneMissile4
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 85.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 10;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

BulletData CycloneMissileK
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
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
