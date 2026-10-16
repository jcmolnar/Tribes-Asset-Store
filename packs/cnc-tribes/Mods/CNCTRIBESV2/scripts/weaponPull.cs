//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Psy Vampire
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Pull] = 1;
$RemoteInvList[Pull] = 1;
$AutoUse[Pull] = False;
$WeaponAmmo[Pull] = "";

addWeapon(Pull);

LightningData PullShot
{
   bitmapName       = "lightningTemp.bmp";

   damageType       = $PsiDamageType;
   boltLength       = 90.0; // 120
   coneAngle        = 35.0;
   damagePerSec      = 0.15;
   energyDrainPerSec = 30.0;
   segmentDivisions = 5;
   numSegments      = 5;
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
   shapeFile = "sensor_small";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   projectileType = PullShot;
   minEnergy = 9;
   maxEnergy = 14;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
			
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
  description = "Drain";
  heading = $InvHead[ihPsi];
  hudIcon = "energyRifle";
  imageType = PullImage;
  price = 2125;
  shadowDetailMask = 4;
  shapeFile = "sensor_small";
  showWeaponBar = true;
};

function Pull::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "This power sucks the soul and life from its unfortunate victim.");
}