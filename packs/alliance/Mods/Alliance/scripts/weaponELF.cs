
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  ELF Gun (EnergyRifle)
//  By Dynamix
//  xxxx.xx.xx : Alazane : Alliance port
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[EnergyRifle] = 1;
$RemoteInvList[EnergyRifle] = 1;
$AutoUse[EnergyRifle] = True;
$WeaponAmmo[EnergyRifle] = "";

addWeapon(EnergyRifle);

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
  className = "Weapon";
  description = "ELF Gun";
  heading = $InvHead[ihWea];
  hudIcon = "energyRifle";
  imageType = EnergyRifleImage;
  price = 125;
  shadowDetailMask = 4;
  shapeFile = "shotgun";
  showWeaponBar = true;
};

function EnergyRifle::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "ELF Gun.  Sucks target's energy.");
}

