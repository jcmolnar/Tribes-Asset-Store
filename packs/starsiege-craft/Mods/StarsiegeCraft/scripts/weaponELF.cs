//emp, generic, all
$InvList[ELF] = 1;
$RemoteInvList[ELF] = 1;
$AutoUse[ELF] = False;
$WeaponAmmo[ELF] = "";
$VehicleInvList[ELF] = 1;

addWeapon(ELF);

LightningData lightningCharge
{
   bitmapName       = "plasmabolt.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 55.0;
   damagePerSec      = 0.3;
   energyDrainPerSec = 120.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.3;//10;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };
   soundId = SoundELFFire;
};

ItemImageData ELFImage
{
   shapeFile = "energygun";
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
   sfxReady    = SoundJammerOn;
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData ELF
{
  className = "Weapon";
  description = "EMP Generator";
  heading = $InvHead[ihWea];
  hudIcon = "blaster";
  imageType = ELFImage;
  price = 350;
  shadowDetailMask = 4;
  shapeFile = "energygun";
  showWeaponBar = true;
};

function ELF::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "EMP Generator: <f2>This 'weapon' serves more to drain a target's energy than to harm, rendering shields, jetpacks, and energy weapons useless.");
}
