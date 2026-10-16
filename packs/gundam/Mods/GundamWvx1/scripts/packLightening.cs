//Flare pack
$InvList[LightningPack] = 1;
$RemoteInvList[LightningPack] = 1;
$VehicleInvList[LightningPack] = 1;

ItemImageData LightningPackImage 
{
  shapeFile = "shieldPack";
  mountPoint = 2;
  weaponType = 2;
  projectileType = lightningCharge;
  minEnergy = 2;
  maxEnergy = 3;
  reloadTime = 0.2;
  sfxFire = SoundELFIdle;

lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 10, 10, 10 };
};

ItemData LightningPack 
{
  description = "Flare Pack";
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
  Client::sendMessage(Player::getClient(%player),0,"Flare Field On");
}

function LightningPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Flare Field Off");
  Player::trigger(%player,$BackpackSlot,false);
}
