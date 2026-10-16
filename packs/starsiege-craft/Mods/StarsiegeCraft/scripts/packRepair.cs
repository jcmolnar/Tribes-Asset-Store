$InvList[RepairPack] = 1;
$RemoteInvList[RepairPack] = 1;
$VehicleInvList[RepairPack] = 1;

RepairEffectData RepairBolt 
{
  bitmapName = "shock.bmp";
  boltLength = 20.0;
  segmentDivisions = 4;
  beamWidth = 0.125;
  updateTime = 450;
  skipPercent = 0.6;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target) 
{
  %client = Player::getClient(%player);
  if (%target == %player) 
  {
    %player.repairTarget = -1;
    if (GameBase::getDamageLevel(%player) != 0) 
    {
      %player.repairRate = 0.08;
      %player.repairTarget = %player;
      Client::sendMessage(%client, 0, "AutoRepair On");
    }
    else 
    {
      Client::sendMessage(%client,0,"Nothing in range");
      Player::trigger(%player, $WeaponSlot, false);
      return;
    }
  }
  else 
  {
    %player.repairTarget = %target;
    %player.repairRate = 0.2;
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      %rclient = Player::getClient(%player.repairTarget);
      %name = Client::getName(%rclient);
    }
    else 
    {
      %name = GameBase::getMapName(%target);
      if(%name == "") 
      {
        %name = (GameBase::getDataName(%player.repairTarget)).description;
      }
    }
    if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
    {
      Client::sendMessage(%client,0,%name @ " is not damaged");
      Player::trigger(%player,$WeaponSlot,false);
      %player.repairTarget = -1;
      return;
    }
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
    }
    Client::sendMessage(%client,0,"Repairing " @ %name);
  }
  %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
  GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player) 
{
  %object = %player.repairTarget;
  if (%object != -1) 
  {
    %client = Player::getClient(%player);
    if (%object == %player) 
    {
      Client::sendMessage(%client,0,"AutoRepair Off");
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Client::sendMessage(%client,0,"Repair Done");
      }
      else 
      {
        Client::sendMessage(%client,0,"Repair Stopped");
      }
    }
    %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
    if (%rate < 0) %rate = 0;
    GameBase::setAutoRepairRate(%object,%rate);
  }
}

function RepairBolt::checkDone(%this, %player) 
{
  if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
  {
    %object = %player.repairTarget;
    if (%object == %player) 
    {
      if (GameBase::getDamageLevel(%player) == 0) 
      {
        Player::trigger(%player,$WeaponSlot,false);
        return;
      }
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Player::trigger(%player,$WeaponSlot,false);
        return;
      }
    }
  }
}

ItemImageData RepairGunImage 
{
//  shapeFile = "repairgun";
  shapeFile = "mortarpack";
  mountPoint = 0;
  weaponType = 2;
   mountOffset = 
   {
   0.1, 0, -0.2 }
   ;
        mountRotation = 
        {
        -1.5, 0, 0 }
        ;
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
  description = "Repair Gun";
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
  shapeFile = "armorPack";
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
  shapeFile = "armorPack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = RepairPackImage;
  price = 125;
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
