$InvList[HammerPack] = 1;
$RemoteInvList[HammerPack] = 1;

ItemImageData HammerPackImage 
{
  shapeFile = "ShieldPack";
  weaponType = 2;
  mountPoint = 2;
  mountOffset = 
  {
    0, -0.1, 0 }
  ;
  minEnergy = -6;
  maxEnergy = -10;
  firstPerson = false;
};

ItemData HammerPack 
{
  description = "Cyclone Pack";
  shapeFile = "ShieldPack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = HammerPackImage;
  price = 150;
  hudIcon = "energypack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function HammerPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
}

function HammerPack::onMount(%player,%item) 
{
  Player::trigger(%player,$BackpackSlot,true);
}

function HammerPack::onUnmount(%player,%item) 
{
  if (Player::getMountedItem(%player,$WeaponSlot) == DiskHammer) Player::unmountItem(%player,$WeaponSlot);
}
