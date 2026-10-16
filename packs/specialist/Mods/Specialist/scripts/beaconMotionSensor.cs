$InvList[MotionSensor] = 1;
$RemoteInvList[MotionSensor] = 1;
$AutoUse[MotionSensor] = 0;
$Object2Item[DeployableMotionSensor] = MotionSensor;
$CoreType[MotionSensor] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = MotionSensor;
$DeployedObject[DeployableMotionSensor] = true;

$SellAmmo[MotionSensor] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, MotionSensor] = 2;
$ItemMax[reconfemalearmor, MotionSensor] = 2;
$ItemMax[espionagearmor, MotionSensor] = 3;
$ItemMax[espionagefemalearmor, MotionSensor] = 3;
$ItemMax[engineerarmor, MotionSensor] = 3;
$ItemMax[engineerfemalearmor, MotionSensor] = 3;
$ItemMax[infantryarmor, MotionSensor] = 3;
$ItemMax[infantryfemalearmor, MotionSensor] = 3;
$ItemMax[falloutarmor, MotionSensor] = 0;
$ItemMax[falloutfemalearmor, MotionSensor] = 0;
$ItemMax[demolitionsarmor, MotionSensor] = 3;
$ItemMax[assaultarmor, MotionSensor] = 3;
$ItemMax[artilleryarmor, MotionSensor] = 3;
$ItemMax[commanderarmor, MotionSensor] = 3;

$TeamItemMax[MotionSensor] = 15;

ItemData MotionSensor
{
   description = "* Motion Sensor Core";
   shapeFile = "Camera";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 125;
   className = "HandAmmo";
};

function MotionSensor::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// We try to deploy it
		if (MotionSensor::deployShape(%player, %item)) {
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player,Beacon);
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}


function MotionSensor::deployShape(%player, %item)
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
					%camera = newObject("","Sensor",DeployableMotionSensor,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"MotionSensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "MotionSensor"]++;
					echo("MSG: ",%client," deployed a Motion Sensor");
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
