$InvList[QRL] = 1; // Modded from War40k's Cyclone Launcher
$InvList[QuadRocket] = 1;
$RemoteInvList[QRL] = 1;
$RemoteInvList[QuadRocket] = 1;
$AutoUse[QRL] = False;
$SellAmmo[QuadRocket] = 5;
$WeaponAmmo[QRL] = QuadRocket;

addWeapon(QRL);
addAmmo(QRL, QuadRocket, 2);


ItemData QuadRocket
{
	description = "Quad Rockets";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData QRLImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = QuadRocket;
	projectileType = QuadRocket;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundRMTurret;
	sfxReload = SoundMortarReload;
};

ItemData QRL
{
	description = "Quad Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = QRLImage;
	price = 1500;
	showWeaponBar = true;
};

function QRLImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[QRL]);
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
					Client::sendMessage(%client,0,"HUD-PC: Missile lock acquired "@ %targetP @"~wpda_on.wav");
					Client::sendMessage(%targeted,0,"HUD-PC: Missile lock detected - " @ %clientId @ "~waccess_denied.wav");
					Projectile::spawnProjectile("QuadRocket1",%trans,%player,%vel,$los::object);
					Projectile::spawnProjectile("QuadRocket2",%trans,%player,%vel,$los::object);
					Projectile::spawnProjectile("QuadRocket3",%trans,%player,%vel,$los::object);
					Projectile::spawnProjectile("QuadRocket4",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[QRL],1);
				}
		else
			{
			Projectile::spawnProjectile("QuadRocketK",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("QuadRocketK",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("QuadRocketK",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("QuadRocketK",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[QRL],1);
			}
		}
	else
		{
		Projectile::spawnProjectile("QuadRocketK",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("QuadRocketK",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("QuadRocketK",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("QuadRocketK",%trans,%player,%vel,%player);
		Player::decItemCount(%player,$WeaponAmmo[QRL],1);
		}
	}
	else Client::sendMessage(Player::getClient(%player),0,"Quad Rocket Launcher out of ammo.");
}

SeekingMissileData QuadRocket1
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 10.5;
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
   
   trailType = 2;          // smoke trail
   trailString = "rsmoke.dts";
   smokeDist = 1.4;

   soundId = SoundJetHeavy;
};

SeekingMissileData QuadRocket2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 10.5;
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

   trailType = 2;          // smoke trail
   trailString = "rsmoke.dts";
   smokeDist = 1.4;

   soundId = SoundJetHeavy;
};

SeekingMissileData QuadRocket3
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 10.5;
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

   trailType = 2;          // smoke trail
   trailString = "rsmoke.dts";
   smokeDist = 1.4;

   soundId = SoundJetHeavy;
};

SeekingMissileData QuadRocket4
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 10.5;
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
   
   trailType = 2;          // smoke trail
   trailString = "rsmoke.dts";
   smokeDist = 1.4;

   soundId = SoundJetHeavy;
};

BulletData QuadRocketK
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
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

function QRL::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>QRL = Quad Rocket Launcher");
}

