//regen, zurg,
$InvList[Heal] = 1;
$RemoteInvList[Heal] = 1;
$VehicleInvList[Heal] = 1;
$AutoUse[Heal] = True;

addWeapon(Heal);

ItemImageData HealImage 
{
  shapeFile = "bullet";
  mountPoint = 0;
  weaponType = 2;
  projectileType = HealBolt;
  minEnergy = 5;
  maxEnergy = 10;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundRepairItem;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Heal 
{
  description = "Regeneration";
  className = "Tool";
  shapeFile = "bullet";
  hudIcon = "targetlaser";
  heading = $InvHead[ihPsi];
  shadowDetailMask = 4;
  imageType = HealImage;
  price = 100;
  showWeaponBar = false;
};

function Heal::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Regeneration: <f2>The infamous ability of the Zerg to heal themselves and others at their will.");
}
