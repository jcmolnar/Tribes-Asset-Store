
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Engineer Repair-Gun (Fixit)
//  By Renegades
//  xxxx.xx.xx : Mjolnir : Alliance port
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

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

function Fixit::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Repair-Gun.  Target gets repaired.");
}

