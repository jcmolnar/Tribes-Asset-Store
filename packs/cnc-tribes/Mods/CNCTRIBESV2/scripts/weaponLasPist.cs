
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Las Pistol
//  By <[DC]>Paladin
//
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[Pist] = 1;
$RemoteInvList[Pist] = 1;
$AutoUse[Pist] = False;
$WeaponAmmo[Pist] = "";

addWeapon(Pist);
 
LaserData PistBolt
{
   laserBitmapName   = "discglow1.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 1.0;
   lightColor        = { 0.0, 0.0, 1.2 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

ItemImageData PistImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 0;
  projectileType = PistBolt;
  accuFire = true;
  reloadTime = 0.2;
  fireTime = 0.2;
  minEnergy = 6;
  maxEnergy = 12;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = { 4, 6, 2 };
  sfxFire = SoundFireTargetingLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Pist 
{
  description = "Las Pistol";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "sniper";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = PistImage;
  price = 40;
  showWeaponBar = true;
};

function Pist::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Las Pistol: A weak, but accurate laser pistol.");
}


