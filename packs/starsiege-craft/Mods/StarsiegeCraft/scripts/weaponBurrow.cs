//burrow, zerg, H
$InvList[Burrow] = 1;
$InvList[BurrowAmmo] = 1;
$RemoteInvList[Burrow] = 1;
$RemoteInvList[BurrowAmmo] = 1;
$VehicleInvList[Burrow] = 1;
$VehicleInvList[BurrowAmmo] = 1;
$AutoUse[Burrow] = True;
$SellAmmo[BurrowAmmo] = 5;
$WeaponAmmo[Burrow] = BurrowAmmo;

addWeapon(Burrow);
addAmmo(Burrow, BurrowAmmo, 2);

GrenadeData BurrowShot
{
  bulletShapeName = "ammounit_remote.dts";
  explosionTag = clawExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.33;
  damageType = $PsiDamageType;
  explosionRadius = 10.0;
  kickBackStrength = 50.0;
  maxLevelFlightDist = 100;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.2;
  smokeName = "dustplume.dts";
  smokeDist = 4;
};

ItemData BurrowAmmo 
{
  description = "Burrowing Strength";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 300;
};

ItemImageData BurrowImage 
{
  shapeFile = "mortar";
  mountPoint = 0;
  weaponType = 0;
  ammoType = BurrowAmmo;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 1.5;
  fireTime = 1.5;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData Burrow 
{
  description = "Lurker Burrow";
  className = "Weapon";
  shapeFile = "mortar";
  hudIcon = "mortar";
  heading = $InvHead[ihPsi];
  shadowDetailMask = 4;
  imageType = BurrowImage;
  price = 325;
  showWeaponBar = true;
};

function Burrow::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Burrow: <f2> A Lurker weapon at heart, this weapon throws the debris from its burrowing in all directions.");
}

function BurrowImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Burrow]);
	 if(%AmmoCount) 
  {
  Player::decItemCount(%player,$WeaponAmmo[Burrow],1);
  %client = GameBase::getOwnerClient(%player);
  %trans = GameBase::getMuzzleTransform(%player);
  %vel = Item::getVelocity(%player);
	
                Projectile::spawnProjectile("BurrowShot",%trans,%player,%vel-3);
                Projectile::spawnProjectile("BurrowShot",%trans,%player,%vel+3);
                Projectile::spawnProjectile("BurrowShot",%trans,%player,%vel-9);
                Projectile::spawnProjectile("BurrowShot",%trans,%player,%vel+9);
                Projectile::spawnProjectile("BurrowShot",%trans,%player,%vel);
  }
  return;
}
