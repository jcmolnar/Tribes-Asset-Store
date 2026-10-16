//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Adv. Shield Pack "Hard Shield"
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[SMRPack] = 1;
$RemoteInvList[SMRPack] = 1;

ItemImageData SMRPackImage 
{
  shapeFile = "shieldPack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 5;
  maxEnergy = 8;
  sfxFire = SoundShieldOn;
  firstPerson = false;
lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 0, 0.25, 3 };
}
;

ItemData SMRPack 
{
  description = "Adv. Shield Pack";
  shapeFile = "shieldPack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = SMRPackImage;
  price = 1175;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;
function SMRPackImage::onActivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Hard Shield On");
  %player.shieldStrength = 0.03;
}
function SMRPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Hard Shield Off");
  Player::trigger(%player,$BackpackSlot,false);
  %player.shieldStrength = 0;
}
