//apk ecliptici firebat fuels

$InvList[OpticPack] = 1;
$RemoteInvList[OpticPack] = 1;
$VehicleInvList[OpticPack] = 1;

ItemImageData OpticPackImage 
{
  shapeFile = "plasammo";
  mountPoint = 2;
  weaponType = 2;
  maxEnergy = 0;
  sfxFire = SoundJetLight;
  mountOffset = 
  {
    0.2, -0.05, -0.2 }
  ;
  mountRotation = 
  {
    0, 0, 0 }
  ;
  firstPerson = false;
};

ItemData OpticPack 
{
  description = "FireBat Fuel";
  shapeFile = "liqcyl";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = OpticPackImage;
  price = 200;
  hudIcon = "ammopack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

ItemImageData OpticPack2Image 
{
  shapeFile = "plasammo";
  mountPoint = 2;
  weaponType = 2;
  maxEnergy = 0;
  sfxFire = SoundJetLight;
  mountOffset = 
  {
    -0.2, -0.05, -0.2 }
  ;
  mountRotation = 
  {
    0, 0, 0 }
  ;
  firstPerson = false;
};

ItemData OpticPack2
{
  description = "FireBat Fuels";
  shapeFile = "liqcyl";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = OpticPack2Image;
  price = 200;
  hudIcon = "ammopack";
  showWeaponBar = false;
  hiliteOnActive = false;
}
;

function OpticPack::onUse(%player,%item) 
{
  player::setitemcount(%player,Opticpack2,1);
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
    Player::mountItem(%player,Opticpack2,5);
  }
}

function OpticPack::onMount(%player,%item) 
{
  %playerId = Player::getClient(%player);
  %playerId.mountedFuel = "true";
  Player::trigger(%player,$BackpackSlot,true);
  Player::trigger(%player,5,true);
}

function OpticPack::onUnmount(%player,%item) 
{
  player::setitemcount(%player,Opticpack2,0);
  %playerId.mountedFuel = 0;
}
