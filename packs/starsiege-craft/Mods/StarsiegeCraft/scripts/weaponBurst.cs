//burst laser, terran, L-m
$InvList[Omega] = 1;
$RemoteInvList[Omega] = 1;
$VehicleInvList[Omega] = 1;
$AutoUse[Omega] = False;
$WeaponAmmo[Omega] = "";

addWeapon(Omega);

LaserData OmegaBolt
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0225;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 1.0;
   lightColor        = { 4.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

ItemImageData OmegaImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
        mountRotation = 
        {
        0, 0, 0.01 }
        ;
  reloadTime = 0.01;
  fireTime = 0.19;
  minEnergy = 3;
  maxEnergy = 4;
  projectileType = OmegaBolt;
  accuFire = true;
  sfxFire = energyExplosion;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Omega 
{
  heading = $InvHead[ihWea];
  description = "Burst Laser";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = OmegaImage;
  price = 225;
  showWeaponBar = true;
};

function Omega::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Burst Laser: <f2>Also a small version of the Wraith's armament, this rifle utilizes the laser aspect of the Wraith.");
}
