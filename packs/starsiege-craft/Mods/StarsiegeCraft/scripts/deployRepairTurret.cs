//RepairTurret
$TeamItemMax[RepairTurretPack] = 1;
$InvList[RepairTurretPack] = 1;
$RemoteInvList[RepairTurretPack] = 0;

$CanAlwaysControl[RepairTurret] = 1;
$CanAlwaysTeamDestroy[RepairTurret] = 1;

 //-=-=-=-

function deployRepairTurret::Initialize()
{
	$TeamItemCount[0 @ RepairTurretPack] = 0; 
	$TeamItemCount[1 @ RepairTurretPack] = 0; 
	$TeamItemCount[2 @ RepairTurretPack] = 0; 
	$TeamItemCount[3 @ RepairTurretPack] = 0; 
	$TeamItemCount[4 @ RepairTurretPack] = 0; 
	$TeamItemCount[5 @ RepairTurretPack] = 0; 
	$TeamItemCount[6 @ RepairTurretPack] = 0; 
	$TeamItemCount[7 @ RepairTurretPack] = 0; 
}

 //-=-=-=-

LightningData Repaircharge
{
   bitmapName       = "fx_lensflare_2.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 15.0;
   damagePerSec      = -0.5;
   energyDrainPerSec = 100.0;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 0.3;//10;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };
};

ItemImageData RepairTurretPackImage 
{
  shapeFile = "camera";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData RepairTurretPack 
{
  description = "Repair Turret";
  shapeFile = "camera";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = RepairTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 2000;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function RepairTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function RepairTurretPack::onDeploy(%player,%item,%pos) 
{
  if (RepairTurretPack::deployShape(%player,%item)) 
    Player::decItemCount(%player,%item);
}

function RepairTurretPack::deployShape(%player,%item) 
{
  %client = Player::getClient(%player);
  if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
  {
    if (GameBase::getLOSInfo(%player,3)) 
    {
      %obj = getObjectType($los::object);
      if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
      {
        %prot = GameBase::getRotation(%player);
        %zRot = getWord(%prot,2);
        if (Vector::dot($los::normal,"0 0 1") > 0.6) 
        {
          %rot = "0 0 " @ %zRot;
        }
        else 
        {
          if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
          {
            %rot = "3.14159 0 " @ %zRot;
          }
          else 
          {
            %rot = Vector::getRotation($los::normal);
          }
        }
        if(checkDeployArea(%client,$los::position)) 
        {
          %camera = newObject("Camera","Turret",RepairTurret,true);
          addToSet("MissionCleanup", %camera);
          GameBase::setTeam(%camera,GameBase::getTeam(%player));
          GameBase::setRotation(%camera,%rot);
          GameBase::setPosition(%camera,$los::position);
          Gamebase::setMapName(%camera,"RepairTurret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
          Client::sendMessage(%client,0,"RepairTurret deployed");
          playSound(SoundPickupBackpack,$los::position);
          $TeamItemCount[GameBase::getTeam(%camera) @ "RepairTurretPack"]++;
          reportDeploy(%camera, %client);
          return true;
        }
      }
      else 
      {
        Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
      }
    }
    else 
    {
      Client::sendMessage(%client,0,"Deploy position out of range");
    }
  }
  else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
  return false;
}

 //-=-=-=-

TurretData RepairTurret 
{
  className = "Turret";
  shapeFile = "camera";
  maxDamage = 10.0;
  maxEnergy = 200;
  minGunEnergy = 50;
  maxGunEnergy = 5;
  speed = 20;
  speedModifier = 1.0;
  range = 10;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  visibleToSensor = true;
  shadowDetailMask = 4;
  castLOS = true;
  projectileType = Repaircharge;
  supression = false;
  supressable = false;
  mapFilter = 2;
  mapIcon = "M_camera";
  debrisId = defaultDebrisSmall;
  FOV = 0.707;
  reloadDelay = 0.3;
  pinger = false;
  explosionId = debrisExpMedium;
  description = "Repair Turret";
  isSustained = true;
  firingTimeMS = 750;
};

function RepairTurret::onAdd(%this) 
{
  schedule("RepairTurret::deploy(" @ %this @ ");",1,%this);
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "RepairTurret");
}

function RepairTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function RepairTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function RepairTurret::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "RepairTurretPack"]--;
}
