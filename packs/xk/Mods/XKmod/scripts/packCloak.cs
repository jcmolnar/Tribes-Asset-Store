$ItemMax[armormSniper, CloakingDevice] = 1;
$ItemMax[armorfSniper, CloakingDevice] = 1;
$ItemMax[armormScout, CloakingDevice] = 0;
$ItemMax[armormMercenary, CloakingDevice] = 0;
$ItemMax[armorfMercenary, CloakingDevice] = 0;
$ItemMax[armormBurster, CloakingDevice] = 0;
$ItemMax[armorCyborg, CloakingDevice] = 0;
$ItemMax[armorfScout, CloakingDevice] = 0;
$ItemMax[armorfBurster, CloakingDevice] = 0;
$ItemMax[armormSpy, CloakingDevice] = 1;
$ItemMax[armorfSpy, CloakingDevice] = 1;
$ItemMax[armormEngineer, CloakingDevice] = 0;
$ItemMax[armorfEngineer, CloakingDevice] = 0;
$ItemMax[armormAlien, CloakingDevice] = 0;
$ItemMax[armorfAlien, CloakingDevice] = 0;
$ItemMax[dmarmor, CloakingDevice] = 1;
$ItemMax[dmfemale, CloakingDevice] = 1;
$ItemMax[armormLoader, CloakingDevice] = 0;
$ItemMax[armorfLoader, CloakingDevice] = 0;
$ItemMax[armormSprint, CloakingDevice] = 0;
$ItemMax[armorfSprint, CloakingDevice] = 0;

$InvList[CloakingDevice] = 1;
$RemoteInvList[CloakingDevice] = 1;

ItemImageData CloakingDeviceImage 
{
  shapeFile = "sensorjampack";
  mountPoint = 2;
  weaponType = 2;
  maxEnergy = 10;
  sfxFire = SoundJammerOn;
  mountOffset = { 0, -0.05, 0 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData CloakingDevice 
{
  description = "Invisible Device";
  shapeFile = "sensorjampack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = CloakingDeviceimage;
  price = 600;
  hudIcon = "sensorjamerpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot) 
{
  GameBase::startFadeout(%player);
  Client::sendMessage(Player::getClient(%player),0,"Invisible Device On");
  %rate = Player::getSensorSupression(%player) + 5;
  Player::setSensorSupression(%player,%rate);
  %player.guiLock = true;
  %c = Player::getClient(%player);
  %c.guiLock = true;
  %clientId.ghostDoneFlag = true;
  startGhosting(%cl);
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot) 
{
  GameBase::startFadein(%player);
  Client::sendMessage(Player::getClient(%player),0,"Invisible Device Off");
  %rate = Player::getSensorSupression(%player) - 5;
  Player::setSensorSupression(%player,%rate);
  Player::trigger(%player,$BackpackSlot,false);
  %player.guiLock = "";
  %c = Player::getClient(%player);
  %c.guiLock = "";
}
