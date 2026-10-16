//Hellfire Missile Pack-Goliath
//script for hellfire lock from cyclone launcher from wh40K mod
$InvList[Cyclone] = 1;
$InvList[CycloneAmmo] = 1;
$RemoteInvList[Cyclone] = 1;
$RemoteInvList[CycloneAmmo] = 1;
$AutoUse[Cyclone] = False;
$SellAmmo[CycloneAmmo] = 5;
$WeaponAmmo[Cyclone] = CycloneAmmo;
$VehicleInvList[Cyclone] = 1;
$VehicleInvList[CycloneAmmo] = 1;

addWeapon(Cyclone);
addAmmo(Cyclone, CycloneAmmo, 2);


ItemData CycloneAmmo
{
	description = "Hellfire Packs";
	className = "Ammo";
	shapeFile = "mortarpack";
   heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData CycloneImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = CycloneAmmo;
	projectileType = CycloneMissile;
	accuFire = false;
	reloadTime = 2.0;
	fireTime = 2.0;

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
	description = "Hellfire Missile Pack";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "grenade";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = CycloneImage;
	price = 900;
	showWeaponBar = true;
};

function Cyclone::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Hellfire Missile Pack: <f2>Firing missiles aided with the charon boosters for greater distance, this weapon is a contender.");
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
					Client::sendMessage(%client,0,"Hellfire lock acquired "@ %targetP @"~wtaunt10.wav");
					Client::sendMessage(%targeted,0,"Hellfire lock detected - " @ %clientId @ "~wono.wav");
					Projectile::spawnProjectile("CycloneMissile1",%trans,%player,%vel,$los::object);
					Projectile::spawnProjectile("CycloneMissile2",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[Cyclone],1);
				}
		else
			{
			Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("CycloneMissileM",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[Cyclone],1);
			}
		}
	else
		{
		Projectile::spawnProjectile("CycloneMissileK",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("CycloneMissileM",%trans,%player,%vel,%player);
		Player::decItemCount(%player,$WeaponAmmo[Cyclone],1);
		}
	}
	else Client::sendMessage(Player::getClient(%player),0,"Hellfire Launcher out of ammo.");
}

SeekingMissileData CycloneMissile1
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $MissileDamageType;
   explosionRadius  = 15;
   kickBackStrength = 25.0;

   muzzleVelocity    = 150.0;
   terminalVelocity  = 150.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   trailType   = 2;                // smoke trail
   trailString = "HFlame.dts";
   smokeDist   = 1.8;

};

SeekingMissileData CycloneMissile2
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 100.0;
   terminalVelocity  = 100.0;
   totalTime         = 20;
   liveTime          = 20;
   seekingTurningRadius    = 8;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   trailType   = 2;                // smoke trail
   trailString = "HFlame.dts";
   smokeDist   = 1.8;

};

RocketData CycloneMissileK
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = rocketexp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $DeathDamageType;
   explosionRadius  = 10;
   kickBackStrength = 30.0;

   aimDeflection    = 0.006;
   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   totalTime        = 6.0;
   liveTime         = 6.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionbolt.dts";
   smokeDist   = 4.0;

};

RocketData CycloneMissileM
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = rocketexp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
   damageType       = $MissileDamageType;
   explosionRadius  = 20;
   kickBackStrength = 30.0;

   aimDeflection    = 0.006;
   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   totalTime        = 6.0;
   liveTime         = 6.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 3.0;

};
