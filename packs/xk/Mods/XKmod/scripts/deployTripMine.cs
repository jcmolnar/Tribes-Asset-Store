$TeamItemMax[TripMine] = 3;
$InvList[TripMine] = 1;
$RemoteInvList[TripMine] = 1;

$CanAlwaysTeamDestroy[DeployableTripMine] = 1;

function deployTripMine::Initialize()
{  
  $TeamItemCount[0 @ TripMine] = 0;
  $TeamItemCount[1 @ TripMine] = 0;
  $TeamItemCount[2 @ TripMine] = 0;
  $TeamItemCount[3 @ TripMine] = 0;
  $TeamItemCount[4 @ TripMine] = 0;
  $TeamItemCount[5 @ TripMine] = 0;
  $TeamItemCount[6 @ TripMine] = 0;
  $TeamItemCount[7 @ TripMine] = 0;
}

ItemImageData TripMineImage
{
  shapeFile = "camera";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData TripMine
{
  description = "Trip Mine";
  shapeFile = "camera";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = TripMineImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 100;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function TripMine::onUse(%player,%item)
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    Player::mountItem(%player,%item,$BackpackSlot);
  else
    Player::deployItem(%player,%item);
}

function TripMine::onDeploy(%player,%item,%pos)
{
	if (TripMine::deployShape(%player,%item))
{
		Player::decItemCount(%player,%item);
	}
}

function TripMine::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
{
		if (GameBase::getLOSInfo(%player,10))
{
			%obj = getObjectType($los::object);
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
					%camera = newObject("camera","Turret",DeployableTripMine,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Trip Mine#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Trip Mine deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "TripMine"]++;
                              Client::setOwnedObject(%client, %camera);
                              Client::setOwnedObject(%client, %player);
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else				  
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}

 //-=-=-=- 

TurretData DeployableTripMine
{
  className = "Turret";
  shapeFile = "camera";
  projectileType = satchelshell;
  maxDamage = 0.65;
  maxEnergy = 60;
  minGunEnergy = 6;
  maxGunEnergy = 5;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.10;
  speed = 4.0;
  speedModifier = 1.5;
  range = 5;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundActivateBeacon;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = flashExpMedium;
  description = "Trip Mine";
  damageSkinData = "objectDamageSkins";
};

function DeployableTripMine::onAdd(%this)
{
  schedule("DeployableTripMine::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Remote Turret");
}

function DeployableTripMine::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableTripMine::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableTripMine::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "TripMine"]--;
}

function DeployableTripMine::onPower(%this,%power,%generator) 
{
}

function DeployableTripMine::onEnabled(%this)
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}


