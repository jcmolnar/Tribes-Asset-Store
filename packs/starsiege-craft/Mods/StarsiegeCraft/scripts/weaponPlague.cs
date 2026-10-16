//plague
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
   damagePerSec      = 0.6;
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
   shapeFile = "mrtwig";
   mountPoint = 2;
        mountOffset = 
        {
        0.2, 0.4, 0.45 }
        ;
        mountRotation = 
        {
        -1.5, 0, 0 }
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
  description = "Plague";
  heading = $InvHead[ihPsi];
  hudIcon = "energyRifle";
  imageType = PullImage;
  price = 600;
  shadowDetailMask = 4;
  shapeFile = "mrtwig";
  showWeaponBar = true;
};

function Pull::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Plague: <f2>this weapon drains the life out of any individual who might get close enough.");
}