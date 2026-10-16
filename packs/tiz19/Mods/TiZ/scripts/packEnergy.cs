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
  minEnergy = -5;
  maxEnergy = -20;
  firstPerson = false;

lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 0.13, 0.25, 1 };
};

ItemData EnergyPack 
{
  description = "Energy Pack";
  shapeFile = "jetPack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = EnergyPackImage;
  price = 1500;
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
