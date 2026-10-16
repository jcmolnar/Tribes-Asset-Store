//Laser Pistol
$InvList[Omega] = 1;
$RemoteInvList[Omega] = 1;
$VehicleInvList[Omega] = 1;
$AutoUse[Omega] = False;
$WeaponAmmo[Omega] = "";

addWeapon(Omega);

LaserData OmegaBolt
{
   laserBitmapName   = "warp.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.023;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.7;

   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

ItemImageData OmegaImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.5;
  fireTime = 0.1;
  minEnergy = 3;
  maxEnergy = 4;
  projectileType = OmegaBolt;
  accuFire = false;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Omega 
{
  heading = $InvHead[ihWet];
  description = "Laser Pistol";
  className = "Weapon";
  shapeFile = "Paintgun";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = OmegaImage;
  price = 185;
  showWeaponBar = true;
};

function Omega::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Laser Pistol: <f2>Laser pistol used by the Gundam Pilot.");
}
