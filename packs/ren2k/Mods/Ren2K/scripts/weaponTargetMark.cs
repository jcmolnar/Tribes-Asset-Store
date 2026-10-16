$InvList[TargetMarkLaser] = 1;
$RemoteInvList[TargetMarkLaser] = 1;
$AutoUse[TargetMarkLaser] = False;

addWeapon(TargetMarkLaser);

LightningData TargetMarkLaserBeam
{
  boltLength = 400.0;
  coneAngle = 35.0;
  damagePerSec = 0.0;
  energyDrainPerSec = 0.0;
  segmentDivisions = 0;	
  numSegments = 1;
  beamWidth = 0.100;
  updateTime = 2000;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.25, 0.25, 0.85 };
  soundId = SoundELFFire;
};

function TargetMarkLaserBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
  if (%shooterId.LaunchAt != %target)
  {
    %shooterID.LaunchAt=%target;

     // Get preferred name
    if (getObjectType(%target) == "Player") 
      %n = Client::getName(Player::getClient(%target));
    else
      %n = GameBase::getMapName(%target);
     // If better names are blank, grab the data name
    if (%n == "")
      %n = GameBase::getDataName(%target);
    Client::sendMessage(%shooterId, 0, "Marked " @ %n);
  }
}

ItemImageData TargetMarkLaserImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = TargetMarkLaserBeam;
  accuFire = true;
  minEnergy = 5;
  maxEnergy = 15;
  reloadTime = 1.0;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundFireTargetingLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData TargetMarkLaser 
{
  description = "Target Marking Laser";
  className = "Tool";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihGui];
  shadowDetailMask = 4;
  imageType = TargetMarkLaserImage;
  price = 100;
  showWeaponBar = true;
};

function TargetMarkLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Target Marking Laser is used to paint a target for the user's seeking weapons.");
}

