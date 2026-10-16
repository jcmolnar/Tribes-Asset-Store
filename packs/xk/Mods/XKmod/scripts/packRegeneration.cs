$ItemMax[armormSniper, RegenerationPack] = 1;
$ItemMax[armorfSniper, RegenerationPack] = 1;
$ItemMax[armormScout, RegenerationPack] = 0;
$ItemMax[armormMercenary, RegenerationPack] = 0;
$ItemMax[armorfMercenary, RegenerationPack] = 0;
$ItemMax[armormBurster, RegenerationPack] = 0;
$ItemMax[armorCyborg, RegenerationPack] = 0;
$ItemMax[armorfScout, RegenerationPack] = 0;
$ItemMax[armorfBurster, RegenerationPack] = 0;
$ItemMax[armormSpy, RegenerationPack] = 1;
$ItemMax[armorfSpy, RegenerationPack] = 1;
$ItemMax[armormEngineer, RegenerationPack] = 0;
$ItemMax[armorfEngineer, RegenerationPack] = 0;
$ItemMax[armormAlien, RegenerationPack] = 1;
$ItemMax[armorfAlien, RegenerationPack] = 1;
$ItemMax[dmarmor, RegenerationPack] = 1;
$ItemMax[dmfemale, RegenerationPack] = 1;
$ItemMax[armormLoader, RegenerationPack] = 0;
$ItemMax[armorfLoader, RegenerationPack] = 0;
$ItemMax[armormSprint, RegenerationPack] = 1;
$ItemMax[armorfSprint, RegenerationPack] = 1;


$InvList[RegenerationPack] = 1;
$RemoteInvList[RegenerationPack] = 1;

ItemImageData RegenerationPackImage 
{
  shapeFile = "shieldPack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 8;
  maxEnergy = 14;
  sfxFire = SoundRepairItem;
  projectileType = AutoBolt;
}
;
ItemData RegenerationPack 
{
  description = "Healing Pack";
  shapeFile = "shieldPack";
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
