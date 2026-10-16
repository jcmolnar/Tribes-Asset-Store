$TeamItemMax[SatchelPack] = 25;
// Satchel charges cannot be purchased at an inventory station

$CanAlwaysControl[DeployableSatchel] = 1;
$CanAlwaysTeamDestroy[DeployableSatchel] = 1;

function deploySatchelCharge::Initialize()
{  
  $TeamItemCount[0 @ SatchelPack] = 0;
  $TeamItemCount[1 @ SatchelPack] = 0;
  $TeamItemCount[2 @ SatchelPack] = 0;
  $TeamItemCount[3 @ SatchelPack] = 0;
  $TeamItemCount[4 @ SatchelPack] = 0;
  $TeamItemCount[5 @ SatchelPack] = 0;
  $TeamItemCount[6 @ SatchelPack] = 0;
  $TeamItemCount[7 @ SatchelPack] = 0;
}

function DeploySatchel( %clientId, %player, %bec) 
{
  %item = "SatchelPack";
  %client = Player::getClient(%player);
  if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
  {
    if (GameBase::getLOSInfo(%player,3)) 
    {
      %obj = getObjectType($los::object);
      %prot = GameBase::getRotation(%player);
      %zRot = getWord(%prot,2);
      if (Vector::dot($los::normal,"0 0 1") > 0.6) 
        %rot = "0 0 " @ %zRot;
      else 
      {
        if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
          %rot = "3.14159 0 " @ %zRot;
        else 
          %rot = Vector::getRotation($los::normal);
      }
      if(checkDeployArea(%client,$los::position)) 
      {
        %camera = newObject("Camera","Turret",DeployableSatchel,true);
        addToSet("MissionCleanup", %camera);
        GameBase::setTeam(%camera,GameBase::getTeam(%player));
        GameBase::setRotation(%camera,%rot);
        GameBase::setPosition(%camera,$los::position);
        Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
        Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen.");
        playSound(SoundPickupBackpack,$los::position);
        $TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++;
        reportDeploy(%camera, %client);
        Player::decItemCount(%player,%bec);
        return true;
      }
    }
    else 
      Client::sendMessage(%client,0,"Deploy position out of range");
  }
  else 
    Client::sendMessage(%client,0,"Deployable Item limit reached for Satchel Charges");
  return false;
}

 //-=-=-=- 

TurretData DeployableSatchel 
{
  className = "Turret";
  shapeFile = "camera";
  projectileType = SatchelShell;
  maxDamage = 0.4;
  maxEnergy = 75;
  minGunEnergy = 10;
  maxGunEnergy = 60;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 10.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 0;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundFireLaser;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = rocketExp;
  description = "Satchel Charge";
  damageSkinData = "objectDamageSkins";
};

function DeployableSatchel::onAdd(%this) 
{
  schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Satchel Charge");
}

function DeployableSatchel::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableSatchel::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableSatchel::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
  calcRadiusDamage(%this, $DebrisDamageType, 20.0, 1.5, 25, 9, 3, 0.20,0.1, 200, 100);
  $TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--;
}

function DeployableSatchel::onPower(%this,%power,%generator) 
{
}

function DeployableSatchel::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}
