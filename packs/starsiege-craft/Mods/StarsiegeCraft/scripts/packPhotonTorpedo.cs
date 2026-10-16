//Irrad. Missile, from photon torp
$InvList[PhotonPack] = 1;
$RemoteInvList[PhotonPack] = 1;
$VehicleInvList[PhotonPack] = 1;

SeekingMissileData PhotonTorpedo
{
  bulletShapeName = "plasmaex.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 5;
  damageType = $MissileDamageType;
  explosionRadius = 45;
  kickBackStrength = 175.0;
  muzzleVelocity = 45.0;
  terminalVelocity = 45.0;
  totalTime = 10;
  liveTime = 10;
  seekingTurningRadius = 10.0;
  nonSeekingTurningRadius = 10.0;
  proximityDist = 1.5;
  trailType = 2;
  trailString = "bluex.dts";
  smokeDist = 0.6;
  lightRange = 50.0;
  lightColor = { 1.0, 1.0, 1.0 };
  inheritedVelocityScale = 0.0;
  soundId = SoundJetHeavy;
};

ItemImageData PhotonPackImage 
{
  shapeFile = "plasma";
  mountPoint = 2;
  weapontype = 2;
  mountoffset={ 0, -0.05, 0 };
  mountRotation = { 3.141592/2, 0, 0 };
  firstPerson = false;
};

ItemData PhotonPack 
{
  description = "Irradiation Missile";
  shapeFile = "plasma";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = PhotonPackImage;
  price = 500;
  hudIcon = "plasma";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function PhotonPack::onUse(%player,%item) 
{
//  echo(%item@" "@Player::getMountedItem(%player,$BackpackSlot));
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else
  {
    Player::SetItemCount(%player,PhotonPack,0);
    %client=Player::GetClient(%player);
    Projectile::SpawnProjectile(PhotonTorpedo, GameBase::GetMuzzleTransform(%player), %player, 0, %client.LaunchAt);  
//    echo(%player@" fired at "@%player.launchat);
  }
}
