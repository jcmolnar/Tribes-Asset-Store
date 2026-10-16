//Energy Wip
$InvList[Pull] = 1;
$RemoteInvList[Pull] = 1;
$AutoUse[Pull] = False;
$WeaponAmmo[Pull] = "";
$VehicleInvList[Pull] = 1;

addWeapon(Pull);

LightningData PullShot
{
   bitmapName       = "warp.bmp";
   baseDamageType   = $ElectricityDamageType;
   boltLength       = 50.0; // 120
   coneAngle        = 35.0;
   damagePerSec      = 0.45;
   energyDrainPerSec = 40;
   segmentDivisions = 5;
   numSegments      = 3;
   beamWidth        = 0.1;//0.125//0.15;
   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };
   soundId = SoundELFFire;
};

ItemImageData PullImage
{
   shapeFile = "energygun";
   mountPoint = 0;
  mountRotation = 
  {
   -0.6, 0, 0 }
  ;

   
   weaponType = 2;  // Sustained
   projectileType = PullShot;
   minEnergy = 15;
   maxEnergy = 20;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
   accufire = True;
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.85, 0.85, 0.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Pull
{
  className = "Weapon";
  description = "Energy Wip";
  heading = $InvHead[ihWet];
  hudIcon = "energyRifle";
  imageType = PullImage;
  price = 600;
  shadowDetailMask = 4;
  shapeFile = "energygun";
  showWeaponBar = true;
};

function Pull::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Energy Wip: <f2>Melee weapon that drains the enemy's energy.");
}