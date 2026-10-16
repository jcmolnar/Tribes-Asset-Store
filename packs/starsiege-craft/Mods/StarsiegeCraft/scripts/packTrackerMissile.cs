//RPG battery
$InvList[TrackerMissilePack] = 1;
$RemoteInvList[TrackerMissilePack] = 1;
$SellAmmo[TrackerMissileAmmo] = 5;
$InvList[TrackerMissileAMmo] = 1;
$RemoteInvList[TrackerMissileAmmo] = 1;
$VehicleInvList[TrackerMissilePack] = 1;

addAmmo(TrackerMissilePack, TrackerMissileAmmo, 1);

ItemData TrackerMissileAmmo 
{
  description = "RPGz";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "rocket";
  shadowDetailMask = 4;
  price = 50;
};

SeekingMissileData TrackerMissile2
{
  bulletShapeName = "mortar.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 1.0;
  baseDamageType = $MissileDamageType;
  explosionRadius = 9.5;
  kickBackStrength = 175.0;
  muzzleVelocity = 72.0;
  totalTime = 10;
  liveTime = 10;
  seekingTurningRadius = 4;
  nonSeekingTurningRadius = 20.0;
  proximityDist = 1.5;
  trailType = 2;
  trailString = "chainspk.dts";
  smokeDist = 50;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 0.5;
};

ItemImageData TrackerMissilePackImage
{
  shapeFile = "mortargun";
  mountPoint = 2;
  mountOffset = { 0.0, -0.05, 0.0 };
  mountRotation = { 3.141592/2, 0, 0 };
  weaponType = 0;
  ammoType = TrackerMissileAmmo;
  projectileType = TrackerMissile2;
  accuFire = true;
  reloadTime = 3.0;
  fireTime = 1.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundMissileTurretFire;
  sfxReload = SoundMortarReload;
};

ItemData TrackerMissilePack 
{
  description = "RPG pack";
  shapeFile = "mortargun";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = TrackerMissilePackImage;
  price = 350;
  hudIcon = "mortar";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function TrackerMissilePack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else if (Player::getItemCount(%player, TrackerMissileAmmo) > 0 && !%player.TrackerMissileAirborn)
  {
    %player.TrackerMissileAirborn = True;
    Player::decItemCount(%player, TrackerMissileAmmo);
    %client=Player::GetClient(%player);
    Projectile::SpawnProjectile(TrackerMissile2, GameBase::GetMuzzleTransform(%player), %player, 0, %client.LaunchAt);  
    schedule(%player @ ".TrackerMissileAirborn = False;", 2, %player);
  }
}

function TrackerMissilePack::onMount(%player,%item) 
{
  //%client = Player::getClient(%player);
  //Bottomprint(%client, "Image Recognition Missiles will only seek an object that is marked with the Target Marking Laser.");
}
