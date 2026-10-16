
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Rapidfire Laser (DeathLaser)
//  By Alazane
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[DeathLaser] = 1;
$RemoteInvList[DeathLaser] = 1;
$AutoUse[DeathLaser] = True;
$WeaponAmmo[DeathLaser] = "";
AddWeapon(DeathLaser);

LaserData DeathLaserBeam
{
  laserBitmapName = "laserPulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.012;
  baseDamageType = $LaserDamageType;
  beamTime = 0.4;
  lightRange = 4.0;
  lightColor = { 1.0, 0.25, 0.25 } ;
  detachFromShooter = false;
};

ItemImageData DeathLaserImage 
{
  shapeFile = "Sniper";
  mountPoint = 0;
  weaponType = 0;
  projectileType = DeathLaserBeam;
  accuFire = true;
  minEnergy = 1;
  maxEnergy = 5;
  reloadTime = 0.001;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 1, 0, 0 };
  sfxFire = SoundGeneratorPower;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DeathLaser
{
  description = "Rapidfire Laser";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "sniper";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = DeathLaserImage;
  price = 500;
  showWeaponBar = true;
};

function DeathLaser::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Rapidfire Laser.  Shoots rapid, high power laser shots at target.");
}

