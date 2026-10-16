
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Laser Rifle (LaserRifle)
//  By Dynamix
//  xxxx.xx.xx : Mjolnir : Alliance port
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[LaserRifle] = 1;
$RemoteInvList[LaserRifle] = 1;
$AutoUse[LaserRifle] = True;
$WeaponAmmo[LaserRifle] = "";

addWeapon(LaserRifle);

LaserData sniperLaser 
{
  laserBitmapName = "laserPulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.007;
  baseDamageType = $LaserDamageType;
  beamTime = 0.5;
  lightRange = 2.0;
  lightColor = { 1.0, 0.25, 0.25 } ;
  detachFromShooter = false;
  hitSoundId = SoundLaserHit;
};

ItemImageData LaserRifleImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  projectileType = SniperLaser;
  accuFire = true;
  reloadTime = 0.1;
  fireTime = 0.5;
  minEnergy = 10;
  maxEnergy = 60;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = { 1, 0, 0 };
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle 
{
  description = "Laser Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "sniper";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = LaserRifleImage;
  price = 200;
  showWeaponBar = true;
};

function LaserRifle::onUse(%player,%item)
{
  if (Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
    Weapon::onUse(%player,%item);
  else
    Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Laser Rifle.");
}

function LaserRifle::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Laser Rifle.  Snipes targets at a long distance.");
}

