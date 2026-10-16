$ItemMax[armormSniper, OpticPack] = 1;
$ItemMax[armorfSniper, OpticPack] = 1;
$ItemMax[armormScout, OpticPack] = 0;
$ItemMax[armormMercenary, OpticPack] = 0;
$ItemMax[armorfMercenary, OpticPack] = 0;
$ItemMax[armormBurster, OpticPack] = 0;
$ItemMax[armorCyborg, OpticPack] = 0;
$ItemMax[armorfScout, OpticPack] = 0;
$ItemMax[armorfBurster, OpticPack] = 0;
$ItemMax[armormSpy, OpticPack] = 0;
$ItemMax[armorfSpy, OpticPack] = 0;
$ItemMax[armormEngineer, OpticPack] = 1;
$ItemMax[armorfEngineer, OpticPack] = 1;
$ItemMax[armormAlien, OpticPack] = 0;
$ItemMax[armorfAlien, OpticPack] = 0;
$ItemMax[dmarmor, OpticPack] = 1;
$ItemMax[dmfemale, OpticPack] = 1;
$ItemMax[armormLoader, OpticPack] = 0;
$ItemMax[armorfLoader, OpticPack] = 0;
$ItemMax[armormSprint, OpticPack] = 0;
$ItemMax[armorfSprint, OpticPack] = 0;



$InvList[OpticPack] = 1;
$RemoteInvList[OpticPack] = 1;

LaserData OpticLaser 
{
  laserBitmapName = "laserpulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.007;
  baseDamageType = $LaserDamageType;
  beamTime = 0.8;
  lightRange = 2.0;
  lightColor = { 1.0, 0.25, 0.25 } ;
  detachFromShooter = false;
  hitSoundId = SoundLaserHit;
};

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
  projectileType = OpticLaser;
  accuFire = true;
  reloadTime = 3.5;
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
  description = "Laser Pack";
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
