$InvList[EnergyPack] = 1;
$RemoteInvList[EnergyPack] = 1;
$VehicleInvList[EnergyPack] = 1;

ItemImageData EnergyPackImage 
{
  shapeFile = "rocket";
  weaponType = 2;
  mountPoint = 2;
  mountoffset={ 0, -0.05, 0 };
  mountRotation = { 3.141592/2, 0, 0 };
  minEnergy = -3;
  maxEnergy = -5;
  firstPerson = false;

lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 0.13, 0.25, 1 };
};

ItemData EnergyPack 
{
  description = "Flyer Pack";
  shapeFile = "rocket";
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
}
