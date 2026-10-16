$InvList[EnergyPack] = 1;
$RemoteInvList[EnergyPack] = 1;

ItemImageData EnergyPackImage 
{
  shapeFile = "jetPack";
  weaponType = 2;
  mountPoint = 2;
  mountOffset = 
  {
    0, -0.1, 0 }
  ;
  minEnergy = -3;
  maxEnergy = -5;
  firstPerson = false;
};

ItemData EnergyPack 
{
  description = "Energy Pack";
  shapeFile = "jetPack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = EnergyPackImage;
  price = 150;
  hudIcon = "energypack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function EnergyPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
}

function EnergyPack::onMount(%player,%item) 
{
  Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item) 
{
  if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) Player::unmountItem(%player,$WeaponSlot);
  if (Player::getMountedItem(%player,$WeaponSlot) == AlienLaser) Player::unmountItem(%player,$WeaponSlot);
}
