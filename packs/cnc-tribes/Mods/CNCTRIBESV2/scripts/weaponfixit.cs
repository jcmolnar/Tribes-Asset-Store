$InvList[Fixit] = 1;
$RemoteInvList[Fixit] = 1;
$VehicleInvList[Fixit] = 1;
$AutoUse[Fixit] = False;

addWeapon(Fixit);

ItemImageData FixitImage 
{
  shapeFile = "repairgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = FixitBolt;
  minEnergy = 15;
  maxEnergy = 20;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundRepairItem;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit 
{
  description = "Wrench";
  className = "Tool";
  shapeFile = "repairgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihMis];
  shadowDetailMask = 4;
  imageType = FixitImage;
  price = 50;
  showWeaponBar = false;
};

function Fixit::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Wrench: <f2>Used mostly for repairing structures, this unit has a built in Medi-pack that can be used to heal infantry.");
}
