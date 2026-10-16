$InvList[RegenerationPack] = 1;
$RemoteInvList[RegenerationPack] = 1;

ItemImageData RegenerationPackImage 
{
  shapeFile = "armorKit";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 8;
  maxEnergy = 14;
  sfxFire = SoundRepairItem;
  projectileType = AutoBolt;
lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 1, 0, 0 };
}
;
ItemData RegenerationPack 
{
  description = "Regeneration Pack";
  shapeFile = "armorKit";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = RegenerationPackImage;
  price = 275;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;
function RegenerationPackImage::onActivate(%player,%imageSlot) 
{
  %clientId = Player::getClient(%player);
}
function RegenerationPackImage::onDeactivate(%player,%imageSlot) 
{
  Player::trigger(%player,$BackpackSlot,false);
}
