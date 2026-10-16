
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Camera
//  By Unknown (xxx@xxx.com)
//  Cleaned up by Alazane (alazane@rkeng.com)
//
//  Installation:
//
//**Add the line 
//    exec(deployCamera);
//  in the file "server.cs" in the procedure 
//  "createServer" (just look for the other "exec"s--
//  must at least be before call to 
//  "preloadServerDataBlocks").
//  
//**Add the line 
//    deployCamera::Initialize();
//  also in the file "server.cs" in the procedure 
//  "Server::finishMissionLoad" right after
//  "Mission::reinitData".
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

 // Adjust this to adjust the number a team can have
$TeamItemMax[CameraPack] = 15;
$InvList[CameraPack] = 1;
$RemoteInvList[CameraPack] = 1;

$CanAlwaysControl[CameraTurret] = 1;
$CanAlwaysTeamDestroy[CameraTurret] = 1;

 //-=-=-=-

function deployCamera::Initialize()
{
	$TeamItemCount[0 @ CameraPack] = 0; 
	$TeamItemCount[1 @ CameraPack] = 0; 
	$TeamItemCount[2 @ CameraPack] = 0; 
	$TeamItemCount[3 @ CameraPack] = 0; 
	$TeamItemCount[4 @ CameraPack] = 0; 
	$TeamItemCount[5 @ CameraPack] = 0; 
	$TeamItemCount[6 @ CameraPack] = 0; 
	$TeamItemCount[7 @ CameraPack] = 0; 
}

 //-=-=-=-

ItemImageData CameraPackImage 
{
  shapeFile = "camera";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData CameraPack 
{
  description = "Camera";
  shapeFile = "camera";
  className = "Backpack";
  heading = $InvHead[ihDSe];
  imageType = CameraPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 100;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function CameraPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function CameraPack::onDeploy(%player,%item,%pos) 
{
  if (CameraPack::deployShape(%player,%item)) 
    Player::decItemCount(%player,%item);
}

function CameraPack::deployShape(%player,%item) 
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
          %camera = newObject("Camera","Turret",CameraTurret,true);
          addToSet("MissionCleanup", %camera);
          GameBase::setTeam(%camera,GameBase::getTeam(%player));
          GameBase::setRotation(%camera,%rot);
          GameBase::setPosition(%camera,$los::position);
          Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
          Client::sendMessage(%client,0,"Camera deployed");
          playSound(SoundPickupBackpack,$los::position);
          $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
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

TurretData CameraTurret 
{
  className = "Turret";
  shapeFile = "camera";
  maxDamage = 0.25;
  maxEnergy = 10;
  speed = 20;
  speedModifier = 1.0;
  range = 50;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  visibleToSensor = true;
  shadowDetailMask = 4;
  castLOS = true;
  supression = false;
  supressable = false;
  mapFilter = 2;
  mapIcon = "M_camera";
  debrisId = defaultDebrisSmall;
  FOV = 0.707;
  pinger = false;
  explosionId = debrisExpMedium;
  description = "Camera";
};

function CameraTurret::onAdd(%this) 
{
  schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Camera");
}

function CameraTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function CameraTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function CameraTurret::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
}
