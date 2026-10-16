//Irradiation Rocket
$InvList[PhotonPack] = 1;
$RemoteInvList[PhotonPack] = 1;
$VehicleInvList[PhotonPack] = 1;

SeekingMissileData PhotonTorpedo
{
  bulletShapeName = "rocket.dts";
  explosionTag = mortarExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 10;
  damageType = $MissileDamageType;
  explosionRadius = 50.0;
  kickBackStrength = 175.0;
  muzzleVelocity = 45.0;
  terminalVelocity = 45.0;
  totalTime = 100;
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
  shapeFile = "grenadeL";
  mountPoint = 2;
  weapontype = 2;
  mountoffset={ 0, -0.05, 0 };
  mountRotation = { 3.141592/2, 0, 0 };
  firstPerson = false;
};

ItemData PhotonPack 
{
  description = "Irradiation Rocket";
  shapeFile = "grenadeL";
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

function PhotonPack::onDrop(%player,%item) 
{
//  echo("ImRec::OnDrop("@%player@","@%item@")");
  if($matchStarted) 
  {
    Item::onDrop(%player,%item);
  }
}

function PhotonPack::onMount(%player,%item) 
{
  //%client = Player::getClient(%player);
  //Bottomprint(%client, This thing shoots a realy powerfull rocket when you hit "P". Carefull! You only have one shot.");
}
