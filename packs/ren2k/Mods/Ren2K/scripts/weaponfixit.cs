$InvList[Fixit] = 1;
$RemoteInvList[Fixit] = 1;
$AutoUse[Fixit] = False;

addWeapon(Fixit);

ItemImageData FixitImage 
{
  shapeFile = "repairgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = RepairBolt;
  minEnergy = 5;
  maxEnergy = 15;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundRepairItem;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit 
{
  description = "Engineer Repair-Gun";
  className = "Tool";
  shapeFile = "repairgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = FixitImage;
  price = 50;
  showWeaponBar = false;
};

