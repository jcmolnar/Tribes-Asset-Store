//Nuclear Bigass Bomb
$InvList[NuclearPack] = 1;
$RemoteInvList[NuclearPack] = 1;
$VehicleInvList[NuclearPack] = 1;

GrenadeData GhostNuke
{
  bulletShapeName = "liqcyl.dts";
  explosionTag = LargeShockwave;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.01;
  damageClass = 1;
  damageValue = 4.0;
  damageType = $MortarDamageType;
  explosionRadius = 40;
  kickBackStrength = 800.0;
  maxLevelFlightDist = 0;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.0;
  smokeName = "plasmabolt.dts";
  smokeDist = 2.0;
};

ItemImageData NuclearPackImage 
{
  shapeFile = "plasma";
  mountPoint = 2;
  weapontype = 2;
  mountoffset={ 0, -0.05, 0 };
  mountRotation = { 3.141592/2, 0, 0 };
  firstPerson = false;
};

ItemData NuclearPack 
{
  description = "Mini Nuclear Warhead";
  shapeFile = "plasma";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = NuclearPackImage;
  price = 3000;
  hudIcon = "plasma";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function NuclearPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else
  {
	bottomPrintAll("Nuclear Launch Detected...", 10);
    Player::SetItemCount(%player,NuclearPack,0);
    %client=Player::GetClient(%player);
    Projectile::SpawnProjectile(NuclearTorpedo, GameBase::GetMuzzleTransform(%player), %player, 0, %client.LaunchAt);  
    GameBase::getLOSInfo(%player,3000)
  }
}

function NuclearPack::onDrop(%player,%item) 
{
//  echo("ImRec::OnDrop("@%player@","@%item@")");
  if($matchStarted) 
  {
    Item::onDrop(%player,%item);
  }
}

function NuclearPack::onMount(%player,%item) 
{
  //%client = Player::getClient(%player);
  //Bottomprint(%client, "The photon torpedo will only seek an object that is marked with the Target Marking Laser.");
}
