$ItemMax[armormSniper, StealthShieldPack] = 0;
$ItemMax[armorfSniper, StealthShieldPack] = 0;
$ItemMax[armormScout, StealthShieldPack] = 0;
$ItemMax[armormMercenary, StealthShieldPack] = 1;
$ItemMax[armorfMercenary, StealthShieldPack] = 1;
$ItemMax[armormBurster, StealthShieldPack] = 1;
$ItemMax[armorCyborg, StealthShieldPack] = 1;
$ItemMax[armorfScout, StealthShieldPack] = 0;
$ItemMax[armorfBurster, StealthShieldPack] = 1;
$ItemMax[armormSpy, StealthShieldPack] = 0;
$ItemMax[armorfSpy, StealthShieldPack] = 0;
$ItemMax[armormEngineer, StealthShieldPack] = 0;
$ItemMax[armorfEngineer, StealthShieldPack] = 0;
$ItemMax[armormAlien, StealthShieldPack] = 0;
$ItemMax[armorfAlien, StealthShieldPack] = 0;
$ItemMax[dmarmor, StealthShieldPack] = 1;
$ItemMax[dmfemale, StealthShieldPack] = 1;
$ItemMax[armormLoader, StealthShieldPack] = 0;
$ItemMax[armorfLoader, StealthShieldPack] = 0;
$ItemMax[armormSprint, StealthShieldPack] = 0;
$ItemMax[armorfSprint, StealthShieldPack] = 0;

$InvList[StealthShieldPack] = 1;
$RemoteInvList[StealthShieldPack] = 1;

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
  description = "StealthShield Pack";
  shapeFile = "shieldPack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = StealthShieldPackImage;
  price = 275;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};
function StealthShieldPackImage::onActivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
  %player.shieldStrength = 0.012;
  %rate = Player::getSensorSupression(%player) + 20;
  Player::setSensorSupression(%player,%rate);
}
function StealthShieldPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
  Player::trigger(%player,$BackpackSlot,false);
  %player.shieldStrength = 0;
  %rate = Player::getSensorSupression(%player) - 20;
  Player::setSensorSupression(%player,%rate);
}
