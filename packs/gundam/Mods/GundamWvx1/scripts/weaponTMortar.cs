//Nuke Launcher
$InvList[TMortar] = 1;
$InvList[TMortarAmmo] = 1;
$RemoteInvList[TMortar] = 1;
$RemoteInvList[TMortarAmmo] = 1;
$VehicleInvList[TMortar] = 1;
$VehicleInvList[TMortarAmmo] = 1;
$AutoUse[TMortar] = True;
$SellAmmo[TMortarAmmo] = 5;
$WeaponAmmo[TMortar] = TMortarAmmo;

addWeapon(TMortar);
addAmmo(TMortar, TMortarAmmo, 2);

GrenadeData TMortarShell
{
  bulletShapeName = "mortar.dts";
  explosionTag = DCannonBoom;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 10.3;
  mass = 3.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 2.5;
  damageType = $MortarDamageType;
  explosionRadius = 150.0;
  kickBackStrength = 600.0;
  maxLevelFlightDist = 200;
  totalTime = 30.0;
  liveTime = 2.0;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "enex.dts";
};

RocketData TMortarRocket
{
  bulletShapeName = "mortar.dts";
  explosionTag = rocketExp;
  collideWithOwner = False;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 1;
  damageValue = 1.35;
  damageType = $MissileDamageType;
  explosionRadius = 50.0;
  kickBackStrength = 250.0;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  acceleration = 2.0;
  totalTime = 30.0;
  liveTime = 5.0;
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "laserhit.dts";
  smokeDist = 1.6;
};

BulletData TMortarBullet
{
  bulletShapeName = "paint.dts";
  explosionTag = energyExp;
  collideWithOwner = False;
  collisionRadius = 2.0;
  mass = 5.0;
  damageClass = 0;
  damageValue = 0.12;
  damageType = $DeathDamageType;
  explosionRadius = 300.0;
  kickBackStrength = 100.0;
  muzzleVelocity = 450.0;
  aimDeflection = 0.004;
  totalTime = 30.0;
  liveTime = 2.0;
};

ItemData TMortarAmmo 
{
  description = "Mini Nuke Canisters";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData TMortarImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  mountRotation = 
  {
   0, 2.0, 0 }
  ;
  weaponType = 0;
  ammoType = TMortarAmmo;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 4.0;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 600;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData TMortar 
{
  description = "Nuke Launcher";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "remoteturret";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = TMortarImage;
  price = 725;
  showWeaponBar = true;
};

function TMortar::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Nuke Launcher: <f2>Shoots mini nukes that have a big exploding radius.");
}

function TMortarImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[TMortar]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[TMortar],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);


			if (%playerId.AMOpt == 0)
			{
				Projectile::spawnProjectile("TMortarShell",%trans,%player,%vel);
			}
			else if (%playerId.AMOpt == 1)
			{
				Projectile::spawnProjectile("TMortarRocket",%trans,%player,%vel);
			}
			else if (%playerId.AMOpt == 2)
			{
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("TMortarBullet",%trans,%player,%vel);
			}
		}
}
