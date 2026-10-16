
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Drainer
//  By <[DC]>Paladin
//
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[ELF] = 1;
$RemoteInvList[ELF] = 1;
$AutoUse[ELF] = False;
$WeaponAmmo[ELF] = "";

addWeapon(ELF);

LightningData lightningCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 90.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.03;
   energyDrainPerSec = 150.0;
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

ItemImageData ELFImage
{
   shapeFile = "shotgun";
   mountPoint = 0;
   weaponType = 2;  // Sustained
   projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
   reloadTime = 0.1;
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData ELF
{
  className = "Weapon";
  description = "ELF Gun";
  heading = $InvHead[ihWea];
  hudIcon = "energyRifle";
  imageType = ELFImage;
  price = 125;
  shadowDetailMask = 4;
  shapeFile = "shotgun";
  showWeaponBar = true;
};

function ELF::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "ELF Gun: While not truly a weapon, but a tool, this item drains the energy from its target VERY rapidly.");
}