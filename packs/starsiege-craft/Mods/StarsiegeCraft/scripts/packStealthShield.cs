$InvList[StealthShieldPack] = 1;
$RemoteInvList[StealthShieldPack] = 1;
$VehicleInvList[StealthShieldPack] = 1;

ItemImageData StealthShieldPackImage 
{
  shapeFile = "shieldPack";
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
  description = "Solar Shield Pack";
  shapeFile = "shieldPack";
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
  Client::sendMessage(Player::getClient(%player),0,"Bending nearby light rays..");
  %player.shieldStrength = 0.012;
  %rate = Player::getSensorSupression(%player) + 20;
  Player::setSensorSupression(%player,%rate);
}
function StealthShieldPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Solar Shield off");
  Player::trigger(%player,$BackpackSlot,false);
  %player.shieldStrength = 0;
  %rate = Player::getSensorSupression(%player) - 20;
  Player::setSensorSupression(%player,%rate);
}
