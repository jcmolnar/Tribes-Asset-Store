//weapon for medic, the healing penis
//$InvList[penis] = 1;
//$RemoteInvList[penis] = 1;
//$VehicleInvList[penis] = 1;

RepairEffectData BOLray
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 500;
   coneAngle        = 60;
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
 	shapeFile = "cactus1";
 	mountPoint = 2;
 	mountOffset = { 0, 0.1, -0.2 };
 	mountRotation = { -1.572, 0, 0 };
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
 	description = "The Balls of Life";
 	shapeFile = "cactus1";
 	className = "Weapon";
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
      Client::sendMessage(%client, 0, "Pissing");
    }
    else 
    {
      Client::sendMessage(%client,0,"Nothing in range to use balls on");
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
      Client::sendMessage(%client,0,%name @ " has full ball power");
      Player::trigger(%player,$WeaponSlot,false);
      %player.repairTarget = -1;
      return;
    }
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      Client::sendMessage(%rclient,0,"GROSS! The Balls of Life are being used on you by " @ Client::getName(%client));
    }
    Client::sendMessage(%client,0,"Using Balls on " @ %name);
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
      Client::sendMessage(%client,0,"Balls deactivated");
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Client::sendMessage(%client,0,"The balls have finished this job");
      }
      else 
      {
        Client::sendMessage(%client,0,"Balls deactivated");
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