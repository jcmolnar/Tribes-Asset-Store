
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Spotlight (SpotlightPack)
//  By Alazane,
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[SpotlightPack] = 1;
$RemoteInvList[SpotlightPack] = 1;
$ItemMax[armormScout, SpotlightPack] = 1;
$ItemMax[armorfScout, SpotlightPack] = 1;

// LaserProjectile::LaserData
// LaserProjectile::BeamRenderImage
// Projectile::ProjectileData
// Projectile::spawnProjectile
// Persistent::TaggedClass<LaserProjectile>
 // ChatMenu
 // DataBlockEvent
 // PlayerTeamChangeEvent 
// Persistent::AbstractTaggedClass
// Persistent::VersionedBase
// Persistent::Base
// Persistent::AbstractClass
// %x=projectile::spawnProjectile("spotlightbeam", %trans, 8393, "000");

//LaserData SpotlightBeam
//{
//  laserBitmapName = "lightningNew.bmp"; //"laserPulse.bmp";
//  damageConversion = 0;
//  baseDamageType = 0;
////  beamTime = 1;
//  lightRange = 5.0;
//  lightColor = { 0.8, 1.0, 0.8 } ;  
//  detachFromShooter = false;
//};

LightningData bbb
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 120.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
   segmentDivisions = 10;
   numSegments      = 1;
   beamWidth        = 0.5;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };

   soundId = SoundELFFire;
};


RepairEffectData Scramble
{
   // Note, there are always only two segments
  bitmapName = "lightningNew.bmp";
  boltLength = 400.0; // Distance in meters that it is effective
  segmentDivisions = 10; //Number of divisions in the beams (0=straight, 1=two part beam, etc).
  beamWidth = 1; //Width of beam (0=none, 0.125=repair, etc).
  updateTime = 100;
  skipPercent = 0; // Percent of the time that the beam will skip from rotating left to right or right to left? 0=never)
  displaceBias = 30;  // How wide the arcs range outside their target line (0=straight, 0.15=repairpack)
  lightRange = 5.0;
  lightColor = { 0.8, 1.0, 0.8 } ;  
  detachFromShooter = false;
};

RepairEffectData SlowWaves
{
   // Note, there are always only two segments
  bitmapName = "lightningNew.bmp";
  boltLength = 400.0; // Distance in meters that it is effective
  segmentDivisions = 10; //Number of divisions in the beams (0=straight, 1=two part beam, etc).
  beamWidth = 1; //Width of beam (0=none, 0.125=repair, etc).
  updateTime = 1000;
  skipPercent = 0; // Percent of the time that the beam will skip from rotating left to right or right to left? 0=never)
  displaceBias = 30;  // How wide the arcs range outside their target line (0=straight, 0.15=repairpack)
  lightRange = 5.0;
  lightColor = { 0.8, 1.0, 0.8 } ;  
  detachFromShooter = false;
};

LightningData SpotlightBeam
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 400.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 5;
   numSegments      = 3;
   beamWidth        = 1;

   updateTime   = 1000;
   skipPercent  = 0;
   displaceBias = 0.5;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

ItemImageData SpotlightPackImage 
{
  shapeFile = "repairgun";
  mountPoint = 2;
  mountOffset = { 0.2, 0.4, 0.45 };
  mountRotation = { 0, 0, 0 };
  weaponType = 2;
  projectileType = SpotlightBeam;
  accuFire = true;
//  reloadTime = 0.5;  //Commenting out causes it to continuously fire
//  fireTime = 0.0;
  minEnergy = 0;
  maxEnergy = 0;
//  lightType = 3;
//  lightRadius = 2;
//  lightTime = 1;
//  lightColor = { 1, 0, 0 };
//  sfxFire = SoundFireLaser;
};

ItemData SpotlightPack 
{
  description = "Spotlight";
  shapeFile = "repairgun";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = SpotlightPackImage;
  price = 275;
  hudIcon = "sniper";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function SpotlightPackImage::onActivate(%player,%imageSlot) 
{
  schedule("use(\"backpack\");", 0.5);
  Player::trigger(%player,%imageslot,false);
}

//function SpotlightPackImage::onDeactivate(%player,%imageSlot) 
//{
//  Player::trigger(%player,$BackpackSlot,false);
//}
