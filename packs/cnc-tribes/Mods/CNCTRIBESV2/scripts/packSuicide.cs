//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Adv. Sensor Jammer Pack
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[LRSensorJammerPack] = 1;
$RemoteInvList[LRSensorJammerPack] = 1;

ItemImageData LRSensorJammerPackImage 
{
  shapeFile = "sensorjampack";
  mountPoint = 2;
  weaponType = 2;
  maxEnergy = 10;
  sfxFire = SoundJammerOn;
  mountOffset = 
  {
    0, -0.05, 0 }
  ;
  mountRotation = 
  {
    0, 0, 0 }
  ;
  firstPerson = false;
};

ItemData LRSensorJammerPack 
{
  description = "Adv. Jammer Pack";
  shapeFile = "sensorjampack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = LRSensorJammerPackImage;
  price = 1200;
  hudIcon = "sensorjamerpack";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;
function LRSensorJammerPackImage::onActivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
  %rate = Player::getSensorSupression(%player) + 60;
  Player::setSensorSupression(%player,%rate);
}
function LRSensorJammerPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
  %rate = Player::getSensorSupression(%player) - 60;
  Player::setSensorSupression(%player,%rate);
  Player::trigger(%player,$BackpackSlot,false);
}
