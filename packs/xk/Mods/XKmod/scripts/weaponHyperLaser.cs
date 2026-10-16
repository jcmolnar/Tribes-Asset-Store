$InvList[HyperLaser] = 1;
$RemoteInvList[HyperLaser] = 1;
$AutoUse[HyperLaser] = True;
$WeaponAmmo[HyperLaser] = "";
AddWeapon(HyperLaser);

LaserData HyperLaserBeam
{
  laserBitmapName = "paintpulse.bmp";
  firePosition = { 0.0, 0.0, 1.0 };
  hitName = "laserhit.dts";
  damageConversion = 0.02;
  baseDamageType = $LaserDamageType;
  beamTime = 0.2;
  lightRange = 4.0;
  lightColor = { 1.0, 0.25, 0.25 } ;
  detachFromShooter = false;
};

ItemImageData HyperLaserImage
{
  shapefile = "chaingun";
  mountRotation = { 0.0, 160.0, 0.0 };
  mountpoint = 0;
  weaponType = 0;
  projectileType = HyperLaserBeam;
  accuFire = true;
  minEnergy = 1;
  maxEnergy = 5;
  reloadTime = 0.001;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = {1, 0, 0 };
  sfxFire = SoundGeneratorPower;
  sfxActivate = SoundPickUpWeapon;
};

ItemData HyperLaser
{
  description = "ChainGun-Laser";
  className = "Weapon";
  shapeFile = "chaingun";
  hudIcon = "sniper";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = HyperLaserImage;
  price = 300;
  showWeaponBar = true;
};

function HyperLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>ChainGun-Laser");
}


  
  