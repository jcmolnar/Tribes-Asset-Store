//lightningNewSub

$InvList[Bolt] = 1;
$RemoteInvList[Bolt] = 1;
$AutoUse[Bolt] = True;
$WeaponAmmo[Bolt] = "";

addWeapon(Bolt);

LightningData boltCharge 
{
  bitmapName = "mtrl07.bmp";
  damageType = $ElectricityDamageType;
  boltLength = 130.0;
  coneAngle = 65.0;
  damagePerSec = 0.20;
  energyDrainPerSec = 60.0;
  segmentDivisions = 4;
  numSegments = 8;
  beamWidth = 0.125;
  updateTime = 120;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0, 2, 0.123439 };
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
  lightColor = { 0, 2, 0.123439 };
  sfxActivate = SoundElectricShock;
  sfxFire = SoundELFIdle;
};

ItemData Bolt 
{
  description = "(HDR)Health-Drain Rifle";
  shapeFile = "shotgun";
  hudIcon = "energyRifle";
  className = "Weapon";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = BoltImage;
  showWeaponBar = true;
  price = 750;
};

function Bolt::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "(<jc><f2>(HDR)Health-Drain Rifle");
}
