//HK G3A3
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
  bulletShapeName = "grenade.dts";
  explosionTag = mortarExp;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.15;
  damageClass = 1;
  damageValue = 0.45;
  damageType = $MortarDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 200.0;
  maxLevelFlightDist = 150;
  totalTime = 4.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "enex.dts";
};

RocketData FlakCRocket
{
  bulletShapeName = "mortar.dts";
  explosionTag = rocketExp;
  collideWithOwner = False;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 1;
  damageValue = 0.45;
  damageType = $MissileDamageType;
  explosionRadius = 5.0;
  kickBackStrength = 350.0;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  acceleration = 2.0;
  totalTime = 6.0;
  liveTime = 8.0;
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "shotgunex.dts";
  smokeDist = 0.6;
};

BulletData FlakCBullet
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletexp0;
  collideWithOwner = False;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 0;
  damageValue = 0.1;
  damageType = $BulletDamageType;
  kickBackStrength = 10.0;
  muzzleVelocity = 900.0;
  aimDeflection = 0.004;
  totalTime = 30.0;
  liveTime = 10.0;
  isVisible = true;
};

ItemData FlakCAmmo 
{
  description = "HK G3A3 Ammo";
  className = "Ammo";
  heading = $InvHead[ihDSe];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData FlakCImage 
{
  shapeFile = "heavy";
  mountPoint = 0;
  weaponType = 0;
  ammoType = FlakCAmmo;
  projectileType = "Undefined";
  accuFire = false;
  reloadTime = 0.1;
  fireTime = 0.1;
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
  description = "HK G3A3";
  className = "Weapon";
  shapeFile = "heavy";
  hudIcon = "mortar";
  heading = $InvHead[ihScv];
  shadowDetailMask = 4;
  imageType = FlakCImage;
  price = 425;
  showWeaponBar = true;
};

function FlakC::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "HK G3A3: <f2>Used mostly for heavy assult operations, the HK G3A3 is the soldiers best friend, supporting multiple fire modes.");
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
			}
		}
}
