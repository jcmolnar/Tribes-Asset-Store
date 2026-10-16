$InvList[StealthShieldPack] = 1;
$RemoteInvList[StealthShieldPack] = 1;
$VehicleInvList[StealthShieldPack] = 1;

ItemImageData StealthShieldPackImage 
{
  shapeFile = "jetPack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 6;
  maxEnergy = 9;
  sfxFire = SoundShieldOn;
  firstPerson = false;
}
;
ItemData StealthShieldPack 
{
  description = "Sensor Shield Pack";
  shapeFile = "jetPack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = StealthShieldPackImage;
  price = 275;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;
function StealthShieldPackImage::onActivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Jamming enemy sensors/shield on..");
  %player.shieldStrength = 0.012;
  %rate = Player::getSensorSupression(%player) + 20;
  Player::setSensorSupression(%player,%rate);
}
function StealthShieldPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Sensor Shield off");
  Player::trigger(%player,$BackpackSlot,false);
  %player.shieldStrength = 0;
  %rate = Player::getSensorSupression(%player) - 20;
  Player::setSensorSupression(%player,%rate);
}
