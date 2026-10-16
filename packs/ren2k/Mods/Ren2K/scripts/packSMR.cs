$InvList[SMRPack] = 1;
$RemoteInvList[SMRPack] = 1;

addAmmo(SMRPack, RocketAmmo, 1);

ItemImageData SMRPackImage 
{
  shapeFile = "mortargun";
  mountPoint = 2;
  mountOffset = { -0.4, 0.1, 0.4 };
  mountRotation = { 0.2, 0, 0 };
  weaponType = 0;
  ammoType = RocketAmmo;
  projectileType = StingerMissile;
  accuFire = true;
  reloadTime = 5.0;
  fireTime = 0.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundMissileTurretFire;
  sfxReload = SoundMortarReload;
};

ItemData SMRPack 
{
  description = "Auto-Rocket Cannon";
  shapeFile = "mortargun";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = SMRPackImage;
  price = 350;
  hudIcon = "mortar";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function SMRPackImage::onActivate(%player,%imageSlot) 
{
  schedule("use(\"backpack\");", 0.5);
}

function SMRPackImage::onDeactivate(%player,%imageSlot) 
{
  Player::trigger(%player,$BackpackSlot,false);
}
