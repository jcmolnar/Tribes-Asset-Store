
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Tractor Device (TractorDevice) *** Under development
//  By Alazane,
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt & Contrib.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[TractorDevice] = 1;
$RemoteInvList[TractorDevice] = 1;
$AutoUse[TractorDevice] = False;
$WeaponAmmo[TractorDevice] = "";

addWeapon(TractorDevice);

LightningData TractorBeam
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 300.0; // 120
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
   segmentDivisions = 5;
   numSegments      = 1;
   beamWidth        = 0.5;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };

   soundId = SoundELFFire;
};

$TractorPower = 50;

function TractorBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
  %obj1 = %target;
  %obj2 = %shooterId;

   // Get object's mass  
  if (getObjectType(%obj1) == "Player") 
    %obj1mass = Player::getArmor(%obj1).mass;
  else
    %obj1mass = 10000;

  %obj2mass = Player::getArmor(%obj2).mass;

   // 
  %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%obj1), GameBase::getPosition(%obj2)));

  if (getObjectType(%obj1) == "Player")
  {
    %mul = $TractorPower - ($TractorPower * %obj1mass) / (%obj1mass + %obj2mass);
    %nvec = (getWord(%vec, 0) * %mul * -1) @ " " @
            (getWord(%vec, 1) * %mul * -1) @ " " @
            (getWord(%vec, 2) * %mul * -1);
    //Player::applyImpulse(%obj1, %nvec);
    Item::setVelocity(%obj1, %nvec);
  }

   // obj2 is always a player
  %mul = $TractorPower - ($TractorPower * %obj2mass) / (%obj1mass + %obj2mass);
  %nvec = (getWord(%vec, 0) * %mul) @ " " @
          (getWord(%vec, 1) * %mul) @ " " @
          (getWord(%vec, 2) * %mul);
  //Player::applyImpulse(%obj2, %nvec);
  Item::setVelocity(%obj2, %nvec);
}

ItemImageData TractorDeviceImage
{
   shapeFile = "mortargun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   projectileType = TractorBeam;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
			
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.85, 0.85, 0.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData TractorDevice
{
  className = "Weapon";
  description = "Tractor Device";
  heading = $InvHead[ihWea];
  hudIcon = "energyRifle";
  imageType = TractorDeviceImage;
  price = 125;
  shadowDetailMask = 4;
  shapeFile = "mortargun";
  showWeaponBar = true;
};

function TractorDevice::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Tractor Device.  Sucks target toward you.");
}

