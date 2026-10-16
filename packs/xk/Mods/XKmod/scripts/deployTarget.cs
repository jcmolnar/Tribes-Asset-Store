$ItemMax[armormSniper, TargetPack] = 0;
$ItemMax[armorfSniper, TargetPack] = 0;
$ItemMax[armormScout, TargetPack] = 0;
$ItemMax[armormMercenary, TargetPack] = 0;
$ItemMax[armorfMercenary, TargetPack] = 0;
$ItemMax[armormBurster, TargetPack] = 0;
$ItemMax[armorCyborg, TargetPack] = 0;
$ItemMax[armorfScout, TargetPack] = 0;
$ItemMax[armorfBurster, TargetPack] = 0;
$ItemMax[armormSpy, TargetPack] = 0;
$ItemMax[armorfSpy, TargetPack] = 0;
$ItemMax[armormEngineer, TargetPack] = 0;
$ItemMax[armorfEngineer, TargetPack] = 0;
$ItemMax[armormAlien, TargetPack] = 0;
$ItemMax[armorfAlien, TargetPack] = 0;
$ItemMax[dmarmor, TargetPack] = 0;
$ItemMax[dmfemale, TargetPack] = 0;
$ItemMax[armormLoader, TargetPack] = 1;
$ItemMax[armorfLoader, TargetPack] = 1;
$ItemMax[armormSprint, TargetPack] = 0;
$ItemMax[armorfSprint, TargetPack] = 0;

$TeamItemMax[TargetPack] = 5;
$InvList[TargetPack] = 1;
$RemoteInvList[TargetPack] = 1;

$CanAlwaysTeamDestroy[DeployableTarget] = 1;

function deployTarget::Initialize()
{
  $TeamItemCount[0 @ TargetPack] = 0;
  $TeamItemCount[1 @ TargetPack] = 0;
  $TeamItemCount[2 @ TargetPack] = 0;
  $TeamItemCount[3 @ TargetPack] = 0;
  $TeamItemCount[4 @ TargetPack] = 0;
  $TeamItemCount[5 @ TargetPack] = 0;
  $TeamItemCount[6 @ TargetPack] = 0;
  $TeamItemCount[7 @ TargetPack] = 0;
}

LaserData sniperLaser3
{
  laserBitmapName = "paintPulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.0;
  beamTime = 0.1;
  lightRange = 2.0;
  lightColor = { 1.0, 0.25, 0.25 } ;
  detachFromShooter = false;
};

ItemImageData TargetPackImage 
{
  shapeFile = "camera";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData TargetPack 
{
  description = "Targeting Turret";
  shapeFile = "camera";
  className = "Backpack";
  heading = $InvHead[ihDSe];
  imageType = TargetPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 300;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function TargetPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}


function TargetPack::onDeploy(%player,%item,%pos)
{
	if (TargetPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TargetPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
			%obj = getObjectType($los::object);
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
					%camera = newObject("Camera","Turret",DeployableTarget,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Targeting Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Targeting Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "TargetPack"]++;
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

function sniperLaser3::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
	if (%shooterId.LaunchAt != %target)
	{
	%shooterID.LaunchAt=%target;

	// Get preferred name
	if (getObjectType(%target) == "Player") 
	%n = Client::getName(Player::getClient(%target));
		else
		%n = GameBase::getMapName(%target);
		// If better names are blank, grab the data name
		if (%n == "")
		%n = GameBase::getDataName(%target);
		Client::sendMessage(%shooterId, 0, "Marked " @ %n);
	}
}

//-------------------------------
TurretData DeployableTarget 
{
  className = "Turret";
  shapeFile = "camera";
  projectileType = sniperLaser3;
  maxDamage = 5.0;
  maxEnergy = 95;
  minGunEnergy = 0;
  maxGunEnergy = 0;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadTime = 1.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 80;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = "";
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = flashExpMedium;
  description = "Remote Targeting Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableTarget::onAdd(%this) 
{
  schedule("DeployableTarget::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Remote Targeting Turret");
}

function DeployableTarget::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableTarget::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableTarget::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--;
}

function DeployableTarget::onPower(%this,%power,%generator) 
{
}

function DeployableTarget::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}
