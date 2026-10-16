$InvList[RepairPack] = 1;
$RemoteInvList[RepairPack] = 1;
$VehicleInvList[RepairPack] = 1;

$NumDepend[RepairPack] = 1;
$Depends[RepairPack, 0] = iarmorSprint;

ItemImageData RepairGunImage 
{
  shapeFile = "commpack";
  mountPoint = 0;
  weaponType = 2;
  projectileType = RepairBolt;
  minEnergy = 3;
  maxEnergy = 10;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxActivate = SoundPickUpWeapon;
  sfxFire = SoundRepairItem;
};

ItemData RepairGun 
{
  description = "commpack";
  shapeFile = "repairgun";
  className = "Weapon";
  shadowDetailMask = 4;
  imageType = RepairGunImage;
  showInventory = false;
  price = 125;
};

function RepairGun::onMount(%player,%imageSlot) 
{
  Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot) 
{
  Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData RepairPackImage 
{
  shapeFile = "retro_utilpack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 0;
  maxEnergy = 0;
  mountOffset = 
  {
    0, -0.05, 0 }
  ;
  mountRotation = 
  {
    0, 0, 0 }
  ;
  firstPerson = false;
}
;
ItemData RepairPack 
{
  description = "Repair Pack";
  shapeFile = "retro_utilpack";
  className = "Backpack";
  heading = $InvHead[ihMis];
  shadowDetailMask = 4;
  imageType = RepairPackImage;
  price = 25;
  hudIcon = "repairpack";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;
function RepairPack::onUnmount(%player,%item) 
{
  if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) 
  {
    Player::unmountItem(%player,$WeaponSlot);
  }
  }
function RepairPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else 
  {
    Player::mountItem(%player,RepairGun,$WeaponSlot);
  }
  }
function RepairPack::onDrop(%player,%item) 
{
  if($matchStarted) 
  {
    %mounted = Player::getMountedItem(%player,$WeaponSlot);
    if (%mounted == RepairGun) 
    {
      Player::unmountItem(%player,$WeaponSlot);
    }
    else 
    {
      Player::mountItem(%player,%mounted,$WeaponSlot);
    }
    Item::onDrop(%player,%item);
  }
  }
