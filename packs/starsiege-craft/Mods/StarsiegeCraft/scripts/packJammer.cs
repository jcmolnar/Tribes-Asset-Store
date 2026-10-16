//Firebat fuel by }APK{Ecliptici

$InvList[SensorJammerPack] = 1;
$RemoteInvList[SensorJammerPack] = 1;
$VehicleInvList[SensorJammerPack] = 1;

ItemImageData SensorJammerPackImage 
{
  shapeFile = "plasammo";
  mountPoint = 2;
  weaponType = 2;
  maxEnergy = 5;
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

ItemData SensorJammerPack 
{
  description = "FireBat Fuel";
  shapeFile = "liqcyl";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = SensorJammerPackImage;
  price = 200;
  hudIcon = "ammopack";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;

ItemImageData SensorJammerPack2Image 
{
  shapeFile = "plasammo";
  mountPoint = 2;
  weaponType = 2;
  maxEnergy = 5;
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

ItemData SensorJammerPack2
{
  description = "FireBat Fuels";
  shapeFile = "liqcyl";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = SensorJammerPack2Image;
  price = 200;
  hudIcon = "ammopack";
  showWeaponBar = false;
  hiliteOnActive = true;
}
;

function SensorJammerPack::onUse(%player,%item) 
{
  player::setitemcount(%player,sensorjammerpack2,1);
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
    Player::mountItem(%player,Sensorjammerpack2,7);
  }
}

function SensorJammerPack::onMount(%player,%item) 
{
  %playerId = Player::getClient(%player);
  %playerId.mountedFuel = "true";
  Player::trigger(%player,$BackpackSlot,true);
  Player::trigger(%player,7,true);
}

function SensorJammerPack::onUnmount(%player,%item) 
{
  player::setitemcount(%player,sensorjammerpack2,0);
  %playerId.mountedFuel = 0;
}

// Here's the code for mounting the firebat fuel pack.