//weapon for Ball
//$InvList[penis] = 1;
//$RemoteInvList[penis] = 1;
//$VehicleInvList[penis] = 1;

RepairEffectData BOLray
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 15.0;
//   damagePerSec      = -0.1;
   segmentDivisions = 4;
   numSegments      = 20;
   beamWidth        = 0.3;//075

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
};

 ItemImageData PenisImage
 {
 	shapeFile = "repairgun";
 	mountPoint = 0;
      mountRotation = 
  {
   0, 2.0, 0 }
  ;


 	mass = 1.0;
 	firstPerson = true;
	projectileType = BOLray;
	weaponType = 2;
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = false;
 };
 
 ItemData Penis
 {
 	description = "Ball Gun";
 	shapeFile = "repairgun";
 	className = "Backpack";
 	imageType = PenisImage;
 	shadowDetailMask = 4;
 	mass = 1.0;
 	elasticity = 0.2;
 	price = 1;
 	showWeaponBar = false;
 	hiliteOnActive = false;
	weaponType = 2;
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = false;
	projectileType = BOLray;
 };

function BOLray::onAcquire(%this, %player, %target) 
{
  %client = Player::getClient(%player);
  if (%target == %player) 
  {
    %player.repairTarget = -1;
    if (GameBase::getDamageLevel(%player) != 0) 
    {
      %player.repairRate = 0.03;
      %player.repairTarget = %player;
      Client::sendMessage(%client, 0, "Using Ball Gun");
    }
    else 
    {
      Client::sendMessage(%client,0,"Nothing in range to repair");
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
      Client::sendMessage(%client,0,%name @ " has full Ball Gun power");
      Player::trigger(%player,$WeaponSlot,false);
      %player.repairTarget = -1;
      return;
    }
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      Client::sendMessage(%rclient,0," You have been repaired by " @ Client::getName(%client));
    }
    Client::sendMessage(%client,0,"Using Ball Gun on " @ %name);
  }
  %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
  GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function BOLray::onRelease(%this, %player) 
{
  %object = %player.repairTarget;
  if (%object != -1) 
  {
    %client = Player::getClient(%player);
    if (%object == %player) 
    {
      Client::sendMessage(%client,0,"Ball Gun deactivated");
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Client::sendMessage(%client,0,"The Ball as finished this job");
      }
      else 
      {
        Client::sendMessage(%client,0,"Ball Gun deactivated");
      }
    }
    %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
    if (%rate < 0) %rate = 0;
    GameBase::setAutoRepairRate(%object,%rate);
  }
}

function BOLray::checkDone(%this, %player) 
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

function Penis::OnDrop(%player,%item)
{
//
}