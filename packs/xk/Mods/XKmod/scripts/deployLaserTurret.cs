$ItemMax[armormSniper, LaserTurretPack] = 0;
$ItemMax[armorfSniper, LaserTurretPack] = 0;
$ItemMax[armormScout, LaserTurretPack] = 0;
$ItemMax[armormMercenary, LaserTurretPack] = 0;
$ItemMax[armorfMercenary, LaserTurretPack] = 0;
$ItemMax[armormBurster, LaserTurretPack] = 0;
$ItemMax[armorCyborg, LaserTurretPack] = 0;
$ItemMax[armorfScout, LaserTurretPack] = 0;
$ItemMax[armorfBurster, LaserTurretPack] = 0;
$ItemMax[armormSpy, LaserTurretPack] = 0;
$ItemMax[armorfSpy, LaserTurretPack] = 0;
$ItemMax[armormEngineer, LaserTurretPack] = 0;
$ItemMax[armorfEngineer, LaserTurretPack] = 0;
$ItemMax[armormAlien, LaserTurretPack] = 0;
$ItemMax[armorfAlien, LaserTurretPack] = 0;
$ItemMax[dmarmor, LaserTurretPack] = 0;
$ItemMax[dmfemale, LaserTurretPack] = 0;
$ItemMax[armormLoader, LaserTurretPack] = 1;
$ItemMax[armorfLoader, LaserTurretPack] = 1;
$ItemMax[armormSprint, LaserTurretPack] = 0;
$ItemMax[armorfSprint, LaserTurretPack] = 0;

$TeamItemMax[LaserTurretPack] = 5;
$InvList[LaserTurretPack] = 1;
$RemoteInvList[LaserTurretPack] = 1;

$CanAlwaysTeamDestroy[DeployableLaserTurret] = 1;

function deployLaserTurret::Initialize()
{
  $TeamItemCount[0 @ LaserTurretPack] = 0;
  $TeamItemCount[1 @ LaserTurretPack] = 0;
  $TeamItemCount[2 @ LaserTurretPack] = 0;
  $TeamItemCount[3 @ LaserTurretPack] = 0;
  $TeamItemCount[4 @ LaserTurretPack] = 0;
  $TeamItemCount[5 @ LaserTurretPack] = 0;
  $TeamItemCount[6 @ LaserTurretPack] = 0;
  $TeamItemCount[7 @ LaserTurretPack] = 0;
}

ItemImageData LaserTurretPackImage 
{
  shapeFile = "camera";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData LaserTurretPack 
{
  description = "Laser Turret";
  shapeFile = "camera";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = LaserTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 300;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}


function LaserTurretPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function LaserTurretPack::deployShape(%player,%item) 
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
				%camera = newObject("Camera","Turret",DeployableLaserTurret,true); 
				addToSet("MissionCleanup", %camera); 
				GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
				GameBase::setRotation(%camera,%rot); 
				GameBase::setPosition(%camera,$los::position); 
				Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); 
				Client::sendMessage(%client,0,"Laser Turret deployed"); 
				playSound(SoundPickupBackpack,$los::position); 
				$TeamItemCount[GameBase::getTeam(%camera) @ "LaserTurretPack"]++; 
				echo("MSG: ",%client," deployed a Laser Turret"); 
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

//-------------------------------
TurretData DeployableLaserTurret
{
  className = "Turret";
  shapeFile = "camera";
  projectileType = SniperLaser;
  maxDamage = 0.45;
  maxEnergy = 95;
  minGunEnergy = 10;
  maxGunEnergy = 55;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 10.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 50;
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
  explosionId = flashExpMedium;
  description = "Remote Laser Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableLaserTurret::onAdd(%this) 
{
  schedule("DeployableLaserTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Remote Laser Turret");
}

function DeployableLaserTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaserTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableLaserTurret::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--;
}

function DeployableLaserTurret::onPower(%this,%power,%generator) 
{
}

function DeployableLaserTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}

