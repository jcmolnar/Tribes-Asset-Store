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
  description = "Lightning Pack";
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
