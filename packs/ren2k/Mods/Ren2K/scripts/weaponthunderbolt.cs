$InvList[Bolt] = 1;
$RemoteInvList[Bolt] = 1;
$AutoUse[Bolt] = True;
$WeaponAmmo[Bolt] = "";

addWeapon(Bolt);

LightningData boltCharge 
{
  bitmapName = "lightningNew.bmp";
  damageType = $ElectricityDamageType;
  boltLength = 40.0;
  coneAngle = 35.0;
  damagePerSec = 0.20;
  energyDrainPerSec = 60.0;
  segmentDivisions = 4;
  numSegments = 5;
  beamWidth = 0.125;
  updateTime = 120;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.25, 0.25, 0.85 };
  soundId = SoundELFFire;
};

ItemImageData BoltImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = boltCharge;
  minEnergy = 15;
  maxEnergy = 20;
  reloadTime = 0.2;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = { 0.25, 0.25, 0.85 };
  sfxActivate = SoundPickUpWeapon;
  sfxFire = SoundELFIdle;
};

ItemData Bolt 
{
  description = "Thunderbolt";
  shapeFile = "shotgun";
  hudIcon = "energyRifle";
  className = "Weapon";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = BoltImage;
  showWeaponBar = true;
  price = 750;
};
