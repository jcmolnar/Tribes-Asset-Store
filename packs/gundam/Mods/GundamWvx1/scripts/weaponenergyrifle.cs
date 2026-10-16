//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Wraith Cannon
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[EnergyRifle] = 1;
$RemoteInvList[EnergyRifle] = 1;
$AutoUse[EnergyRifle] = False;
$WeaponAmmo[EnergyRifle] = "";

addWeapon(EnergyRifle);

LightningData EnergyCharge 
{
  bitmapName = "lightningNew.bmp";
  damageType = $ElectricityDamageType;
  boltLength = 40.0;
  coneAngle = 35.0;
  damagePerSec = 0.25;
  energyDrainPerSec = 60.0;
  segmentDivisions = 4;
  numSegments = 5;
  beamWidth = 0.125;u
  pdateTime = 120;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = 
  { 0.25, 0.25, 0.85 };
  soundId = SoundELFFire;
};

ItemImageData EnergyRifleImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = EnergyCharge;
  minEnergy = 3;
  maxEnergy = 15;
  reloadTime = 0.2;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = { 0.25, 0.25, 0.85 };
  sfxActivate = SoundPickUpWeapon;
  sfxFire = SoundELFIdle;
};

ItemData EnergyRifle 
{
  description = "Wraith Cannon";
  shapeFile = "shotgun";
  hudIcon = "energyRifle";
  className = "Weapon";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = EnergyRifleImage;
  showWeaponBar = true;
  price = 500;
};

function EnergyRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Wraith Cannon: Shooting deadly beams of rippling energy, this weapon drains energy and melts flesh into a bubbly mass.");
}