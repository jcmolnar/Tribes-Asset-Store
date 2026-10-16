//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Psy Healing
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Heal] = 1;
$RemoteInvList[Heal] = 1;
$AutoUse[Heal] = True;

addWeapon(Heal);

ItemImageData HealImage 
{
  shapeFile = "sensor_small";
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
  description = "Regenerate";
  className = "Tool";
  shapeFile = "sensor_small";
  hudIcon = "targetlaser";
  heading = $InvHead[ihPsi];
  shadowDetailMask = 4;
  imageType = HealImage;
  price = 950;
  showWeaponBar = false;
};

function Heal::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "This psionic ability heals targets.");
}
