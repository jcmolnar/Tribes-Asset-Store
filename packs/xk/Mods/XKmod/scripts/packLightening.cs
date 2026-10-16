$ItemMax[armormSniper, LightningPack] = 1; 
$ItemMax[armorfSniper, LightningPack] = 1;
$ItemMax[armormScout, LightningPack] = 1;
$ItemMax[armormMercenary, LightningPack] = 0;
$ItemMax[armorfMercenary, LightningPack] = 0;
$ItemMax[armormBurster, LightningPack] = 0;
$ItemMax[armorCyborg, LightningPack] = 0;
$ItemMax[armorfScout, LightningPack] = 1;
$ItemMax[armorfBurster, LightningPack] = 0;
$ItemMax[armormSpy, LightningPack] = 1;
$ItemMax[armorfSpy, LightningPack] = 1;
$ItemMax[armormEngineer, LightningPack] = 0;
$ItemMax[armorfEngineer, LightningPack] = 0;
$ItemMax[armormAlien, LightningPack] = 1;
$ItemMax[armorfAlien, LightningPack] = 1;
$ItemMax[dmarmor, LightningPack] = 1;
$ItemMax[dmfemale, LightningPack] = 1;
$ItemMax[armormLoader, LightningPack] = 0;
$ItemMax[armorfLoader, LightningPack] = 1;
$ItemMax[armormSprint, LightningPack] = 1;
$ItemMax[armorfSprint, LightningPack] = 1;


$InvList[LightningPack] = 1;
$RemoteInvList[LightningPack] = 1;

ItemImageData LightningPackImage 
{
  shapeFile = "shieldPack";
  mountPoint = 2;
  weaponType = 2;
  projectileType = boltCharge;
  minEnergy = 9;
  maxEnergy = 10;
  reloadTime = 0.2;
  sfxFire = SoundELFIdle;
};

ItemData LightningPack 
{
  description = "Shock Pack";
  shapeFile = "shieldPack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = LightningPackImage;
  price = 275;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function LightningPackImage::onActivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Lightning Field On");
}

function LightningPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Lightning Field Off");
  Player::trigger(%player,$BackpackSlot,false);
}
