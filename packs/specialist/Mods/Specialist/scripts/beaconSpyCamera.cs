$InvList[SpyCamera] = 1;
$RemoteInvList[SpyCamera] = 1;
$AutoUse[SpyCamera] = 0;
$Object2Item[SpyCameraTurret] = SpyCamera;
$CoreType[SpyCamera] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = SpyCamera;
$DeployedObject[SpyCameraTurret] = true;

$SellAmmo[SpyCamera] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, SpyCamera] = 2;
$ItemMax[reconfemalearmor, SpyCamera] = 2;
$ItemMax[espionagearmor, SpyCamera] = 3;
$ItemMax[espionagefemalearmor, SpyCamera] = 3;
$ItemMax[engineerarmor, SpyCamera] = 3;
$ItemMax[engineerfemalearmor, SpyCamera] = 3;
$ItemMax[infantryarmor, SpyCamera] = 0;
$ItemMax[infantryfemalearmor, SpyCamera] = 0;
$ItemMax[falloutarmor, SpyCamera] = 0;
$ItemMax[falloutfemalearmor, SpyCamera] = 0;
$ItemMax[demolitionsarmor, SpyCamera] = 0;
$ItemMax[assaultarmor, SpyCamera] = 0;
$ItemMax[artilleryarmor, SpyCamera] = 0;
$ItemMax[commanderarmor, SpyCamera] = 3;

$TeamItemMax[SpyCamera] = 10;

ItemData SpyCamera
{
   description = "* Spy Camera Core";
   shapeFile = "Camera";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 200;
   className = "HandAmmo";
};

function SpyCamera::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// We try to deploy it
		if (SpyCameraBeacon::deployShape(%player, %item)) {
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player,Beacon);
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}

TurretData SpyCameraTurret
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
	description = "Spy Camera";
};

function SpyCameraTurret::onAdd(%this)
{
	schedule("SpyCameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Spy Camera");
	}
}

function SpyCameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function SpyCameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	GameBase::startFadeout(%this);
}

function SpyCameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	GameBase::startFadein(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SpyCamera"]--;
}	

StaticShapeData SpyCameraBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "camera";
	maxDamage = 0.1;
	maxEnergy = 200;

	castLOS = true;
	supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 
function SpyCameraBeacon::onEnabled(%this)
{
}

function SpyCameraBeacon::onDisabled(%this)
{
}

function SpyCameraBeacon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);

	$TeamItemCount[GameBase::getTeam(%this) @ "SpyCamera"]--;
}

function SpyCameraBeacon::deployShape(%player, %item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
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
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",SpyCameraTurret,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"SpyCamera#"@ $totalNumSpyCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Spy Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "SpyCamera"]++;
					echo("MSG: ",%client," deployed a Spy Camera");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
