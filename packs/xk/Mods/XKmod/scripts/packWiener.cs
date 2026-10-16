$InvList[WienerPack] = 1;
$RemoteInvList[WienerPack] = 1;

ItemImageData WienerPackImage 
{
	shapeFile = "cactus1";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, 0.1, -0.2 }; 
	mountRotation = { -1.572, 0, 0 };
	minEnergy = -3;
	maxEnergy = -5;
	firstPerson = false;
};

ItemData WienerPack 
{
  description = "A Big One!";
  shapeFile = "cactus1";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = WienerPackImage;
  price = 150;
  hudIcon = "energypack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function WienerPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else 
  {
    Player::deployItem(%player,%item);
  }
  }
function WienerPack::onUnmount(%player,%item) 
{
} // PORT: the closing brace was missing
function WienerPack::onPlayerContact(%targetPlayer, %sourcePlayer)
{
  Steal(%targetPlayer, %sourcePlayer);
}