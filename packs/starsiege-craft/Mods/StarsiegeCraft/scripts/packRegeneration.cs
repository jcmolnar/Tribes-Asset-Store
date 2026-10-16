//shield battery, toss, constant healing
$InvList[RegenerationPack] = 1;
$RemoteInvList[RegenerationPack] = 1;
$VehicleInvList[RegenerationPack] = 1;

RepairEffectData DefLight
{
   bitmapName       = "discglow1.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 20.0;
   coneAngle        = 15.0;
//   damagePerSec      = -0.1;
   segmentDivisions = 4;
   numSegments      = 20;
   beamWidth        = 0.3;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
};
function DefLight::onAcquire(%this, %player, %target) 
{
  %client = Player::getClient(%player);
  if (%target == %player) 
  {
    %player.repairTarget = -1;
    if (GameBase::getDamageLevel(%player) != 0) 
    {
      %player.repairRate = 0.03;
      %player.repairTarget = %player;
      Client::sendMessage(%client, 0, "Shield Battery ON");
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
    %player.repairRate = 0.1;
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
      Client::sendMessage(%client,0,%name @ " has full shields");
      Player::trigger(%player,$WeaponSlot,false);
      %player.repairTarget = -1;
      return;
    }
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      Client::sendMessage(%rclient,0,"Shields being powered by " @ Client::getName(%client));
    }
    Client::sendMessage(%client,0,"Shielding " @ %name);
  }
  %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
  GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function DefLight::onRelease(%this, %player) 
{
  %object = %player.repairTarget;
  if (%object != -1) 
  {
    %client = Player::getClient(%player);
    if (%object == %player) 
    {
      Client::sendMessage(%client,0,"Shield Battery OFF");
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Client::sendMessage(%client,0,"External shield power-up finished");
      }
      else 
      {
        Client::sendMessage(%client,0,"Shield Battery stopped");
      }
    }
    %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
    if (%rate < 0) %rate = 0;
    GameBase::setAutoRepairRate(%object,%rate);
  }
}

function DefLight::checkDone(%this, %player) 
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

ItemImageData RegenerationPackImage 
{
  shapeFile = "mortarpack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 0;
  maxEnergy = 0;
  sfxFire = SoundRepairItem;
  projectileType = DefLight;
lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 1, 0, 0 };
}
;
ItemData RegenerationPack 
{
  description = "Shield Battery";
  shapeFile = "mortarpack";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = RegenerationPackImage;
  price = 175;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;
function RegenerationPackImage::onActivate(%player,%imageSlot) 
{
  %clientId = Player::getClient(%player);
}
function RegenerationPackImage::onDeactivate(%player,%imageSlot) 
{
  Player::trigger(%player,$BackpackSlot,false);
}
