//Creep generator
$InvList[Cloak] = 1;
$RemoteInvList[Cloak] = 1;
$VehicleInvList[Cloak] = 1;

ItemImageData CloakImage 
{
  shapeFile = "mortarpack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = -1;
  maxEnergy = -1;
  sfxFire = SoundJammerOn;
  mountOffset = { 0, -0.05, 0 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData Cloak 
{
  description = "Creep Generator";
  shapeFile = "mortarpack";
  className = "Backpack";
  heading = $InvHead[ihPsi];
  shadowDetailMask = 4;
  imageType = CloakImage;
  price = 800;
  hudIcon = "sensorjamerpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function CloakImage::onActivate(%player,%imageSlot) 
{
  GameBase::startFadeout(%player);
  Client::sendMessage(Player::getClient(%player),0,"Creep metabolizing");
  %rate = Player::getSensorSupression(%player) + 5;
  Player::setSensorSupression(%player,%rate);
  %player.guiLock = true;
  %c = Player::getClient(%player);
  %c.guiLock = true;
  %clientId.ghostDoneFlag = true;
  startGhosting(%cl);
}

function CloakImage::onDeactivate(%player,%imageSlot) 
{
  GameBase::startFadein(%player);
  Client::sendMessage(Player::getClient(%player),0,"Creep demetabolizing");
  %rate = Player::getSensorSupression(%player) - 5;
  Player::setSensorSupression(%player,%rate);
  Player::trigger(%player,$BackpackSlot,false);
  %player.guiLock = "";
  %c = Player::getClient(%player);
  %c.guiLock = "";
}

function Cloak::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Creep Generation: A 'skin' of creep will form around the user, and form him invisible to the eye. Used like a pack 'P'");
}