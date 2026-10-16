//particle bomb
$InvList[FlakC] = 1;
$InvList[FlakCAmmo] = 1;
$RemoteInvList[FlakC] = 1;
$RemoteInvList[FlakCAmmo] = 1;
$VehicleInvList[FlakC] = 1;
$VehicleInvList[FlakCAmmo] = 1;
$AutoUse[FlakC] = True;
$SellAmmo[FlakCAmmo] = 5;
$WeaponAmmo[FlakC] = FlakCAmmo;

addWeapon(FlakC);
addAmmo(FlakC, FlakCAmmo, 2);

GrenadeData FlakCShell
{
  bulletShapeName = "mortartrail.dts";
  explosionTag = mortarExp;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.15;
  damageClass = 1;
  damageValue = 0.75;
  damageType = $MortarDamageType;
  explosionRadius = 15.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 150;
  totalTime = 30.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "paint.dts";
};

RocketData FlakCRocket
{
  bulletShapeName = "mortartrail.dts";
  explosionTag = RocketExp;
  collideWithOwner = False;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 1;
  damageValue = 0.9;
  damageType = $MissileDamageType;
  explosionRadius = 12.0;
  kickBackStrength = 250.0;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  acceleration = 2.0;
  totalTime = 30.0;
  liveTime = 5.0;
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "paint.dts";
  smokeDist = 2.0;
  rotationPeriod = 1;
};

BulletData FlakCBullet
{
  bulletShapeName = "paint.dts";
  explosionTag = blasterExp;
  collideWithOwner = False;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 0;
  damageValue = 0.1;
  damageType = $DeathDamageType;
  kickBackStrength = 10.0;
  muzzleVelocity = 900.0;
  aimDeflection = 0.004;
  totalTime = 30.0;
  liveTime = 2.0;
  isVisible = false;
};

ItemData FlakCAmmo 
{
  description = "Particle Bombs";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData FlakCImage 
{
  shapeFile = "grenadel";
  mountPoint = 0;
  weaponType = 0;
  ammoType = FlakCAmmo;
  projectileType = "Undefined";
  accuFire = false;
  reloadTime = 1.0;
  fireTime = 1.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundMortarIdle;
};

ItemData FlakC 
{
  description = "Particle Cannon";
  className = "Weapon";
  shapeFile = "grenadel";
  hudIcon = "mortar";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = FlakCImage;
  price = 425;
  showWeaponBar = true;
};

function FlakC::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Particle Cannon: <f2>A versatile weapon sporting multiple modes of firing in the tab menu.");
}

function FlakCImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[FlakC]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[FlakC],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.PCOpt == 0)
			{
				Projectile::spawnProjectile("FlakCShell",%trans,%player,%vel);
			}
			else if (%playerId.PCOpt == 1)
			{
				Projectile::spawnProjectile("FlakCRocket",%trans,%player,%vel);
			}
			else if (%playerId.PCOpt == 2)
			{
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakCBullet",%trans,%player,%vel);
			}
		}
}
