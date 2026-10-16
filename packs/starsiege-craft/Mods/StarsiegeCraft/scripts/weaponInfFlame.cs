//Flame Thrower, Terran, L
$InvList[InfFlame] = 1;
//$InvList[InfFlameAmmo] = 1;
$RemoteInvList[InfFlame] = 1;
//$RemoteInvList[InfFlameAmmo] = 1;
$VehicleInvList[InfFlame] = 1;
//$VehicleInvList[InfFlameAmmo] = 1;
$AutoUse[InfFlame] = False;
//$SellAmmo[InfFlameAmmo] = 50;
$WeaponAmmo[InfFlame] = "";

addWeapon(InfFlame);

GrenadeData InfFlamegren
{
  bulletShapeName = "MortarTrail.dts";
  explosionTag = PlasmaExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.4;
  damageType = $PsiDamageType;
  explosionRadius = 8;
  kickBackStrength = 10;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 0.001;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "Mortartrail.dts";
  smokeDist = 5;
};

ItemData InfFlameAmmo 
{
  description = "Flame Cartridges";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData InfFlameImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 0;
//  ammoType = InfFlameAmmo;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 0.1;
  fireTime = 0.1;
  minEnergy = 1;
  maxEnergy = 1;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData InfFlame 
{
  description = "Infested Flamer";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihPsi];
  shadowDetailMask = 4;
  imageType = InfFlameImage;
  price = 450;
  showWeaponBar = true;
};

function InfFlame::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Infested Flame Thrower: <f2>Uses blood for napalm, so using this weapon will harm it's user, but is extremely strong when used correctly.");
}

function InfFlameImage::onFire(%player, %slot) 
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

          Projectile::spawnProjectile("InfFlamegren",%trans,%player,%vel);

  %lev = GameBase::getDamageLevel(%player);
    GameBase::setDamageLevel(%player,%lev+0.01);
}
