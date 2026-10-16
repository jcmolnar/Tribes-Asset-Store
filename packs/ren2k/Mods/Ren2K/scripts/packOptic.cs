$InvList[OpticPack] = 1;
$RemoteInvList[OpticPack] = 1;

ItemImageData OpticPackImage 
{
  shapeFile = "repairgun";
  mountPoint = 2;
  mountOffset = 
  {
    0.2, 0.4, 0.45 }
  ;
  mountRotation = 
  {
    0, 0, 0 }
  ;
  weaponType = 0;
  projectileType = SniperLaser;
  accuFire = true;
  reloadTime = 6.5;
  fireTime = 0.0;
  minEnergy = 10;
  maxEnergy = 60;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = 
  {
    1, 0, 0 }
  ;
  sfxFire = SoundFireLaser;
}
;
ItemData OpticPack 
{
  description = "Cybernetic Laser";
  shapeFile = "repairgun";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = OpticPackImage;
  price = 275;
  hudIcon = "sniper";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;
function OpticPackImage::onActivate(%player,%imageSlot) 
{
  schedule("use(\"backpack\");", 0.5);
}
function OpticPackImage::onDeactivate(%player,%imageSlot) 
{
  Player::trigger(%player,$BackpackSlot,false);
}
