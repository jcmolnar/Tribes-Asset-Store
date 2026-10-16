$ItemMax[armormSniper, Laptop] = 0;
$ItemMax[armorfSniper, Laptop] = 0;
$ItemMax[armormScout, Laptop] = 0;
$ItemMax[armormMercenary, Laptop] = 0;
$ItemMax[armorfMercenary, Laptop] = 0;
$ItemMax[armormBurster, Laptop] = 0;
$ItemMax[armorCyborg, Laptop] = 0;
$ItemMax[armorfScout, Laptop] = 0;
$ItemMax[armorfBurster, Laptop] = 0;
$ItemMax[armormSpy, Laptop] = 1;
$ItemMax[armorfSpy, Laptop] = 1;
$ItemMax[armormEngineer, Laptop] = 1;
$ItemMax[armorfEngineer, Laptop] = 1;
$ItemMax[armormAlien, Laptop] = 0;
$ItemMax[armorfAlien, Laptop] = 0;
$ItemMax[dmarmor, Laptop] = 0;
$ItemMax[dmfemale, Laptop] = 0;
$ItemMax[armormLoader, Laptop] = 1;
$ItemMax[armorfLoader, Laptop] = 1;
$ItemMax[armormSprint, Laptop] = 0;
$ItemMax[armorfSprint, Laptop] = 0;

$InvList[Laptop] = 1;
$RemoteInvList[Laptop] = 1;

ItemImageData LaptopImage 
{
  shapeFile = "AmmoPack";
  mountPoint = 2;
  mountOffset = { 0, -0.03, 0 };
  weaponType = 2;
  minEnergy = -1;
  maxEnergy = -3;
  mass = 0.5;
  firstPerson = false;
};

ItemData Laptop 
{
  description = "Laptop";
  shapeFile = "ammounit_remote";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = LaptopImage;
  price = 650;
  hudIcon = "energypack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function Laptop::IsAvailable(%player)
{
  return (Player::getMountedItem(%player, $BackpackSlot) == Laptop);
}

function Laptop::Error(%client, %msg)
{
  Client::sendMessage(%client, 0, "Laptop Err: " @ %msg @ "~waccess_denied.wav");
}

function Laptop::Output(%client, %msg)
{
  Client::sendMessage(%client, 0, "Laptop: " @ %msg);
}

function Laptop::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
}

function Laptop::onMount(%player,%item) 
{
  Player::trigger(%player,$BackpackSlot,true);
  Bottomprint(%client, "The Laptop will allow you to control turrets without being at a command station... among other things.");
}

function Laptop::onUnmount(%player,%item) 
{
}
