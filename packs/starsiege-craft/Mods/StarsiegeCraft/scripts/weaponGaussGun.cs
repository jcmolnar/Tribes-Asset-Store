//Gauss Pistol, terran, L

$InvList[Pist] = 1;
$RemoteInvList[Pist] = 1;
$VehicleInvList[Pist] = 1;
$AutoUse[Pist] = True;

addWeapon(Pist);

LaserData PistBolt
{
   laserBitmapName   = "fx_lensflare_0.bmp";
   hitName           = "chainspk.dts";
   damageConversion  = 0.033;
   baseDamageType    = $ShellDamageType;
   beamTime          = 0.1;
   detachFromShooter = true;
   hitSoundId        = ricochet2;
};

ItemImageData PistImage
{
  shapeFile = "energygun";
  mountPoint = 0;
  weaponType = 0;
  projectileType = PistBolt;
  accuFire = true;
  reloadTime = 0.2;
  fireTime = 0.1;
  minEnergy = 5;
  maxEnergy = 6;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = { 4, 6, 2 };
  sfxFire = SoundFireBlaster;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Pist 
{
  description = "Gauss Pistol";
  className = "Weapon";
  shapeFile = "energygun";
  hudIcon = "blaster";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = PistImage;
  price = 225;
  showWeaponBar = true;
};

function Pist::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Gauss Gun: <f2>fires super-heated ballistics with nearly no spread due to recent modifications.");
}