$InvList[Camera] = 1;
$RemoteInvList[Camera] = 1;
$AutoUse[Camera] = 0;
$Object2Item[CameraTurret] = Camera;
$CoreType[Camera] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = Camera;
$DeployedObject[CameraTurret] = true;

$SellAmmo[Camera] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, Camera] = 2;
$ItemMax[reconfemalearmor, Camera] = 2;
$ItemMax[espionagearmor, Camera] = 3;
$ItemMax[espionagefemalearmor, Camera] = 3;
$ItemMax[engineerarmor, Camera] = 3;
$ItemMax[engineerfemalearmor, Camera] = 3;
$ItemMax[infantryarmor, Camera] = 3;
$ItemMax[infantryfemalearmor, Camera] = 3;
$ItemMax[falloutarmor, Camera] = 0;
$ItemMax[falloutfemalearmor, Camera] = 0;
$ItemMax[demolitionsarmor, Camera] = 3;
$ItemMax[assaultarmor, Camera] = 3;
$ItemMax[artilleryarmor, Camera] = 3;
$ItemMax[commanderarmor, Camera] = 3;

$TeamItemMax[Camera] = 15;

ItemData Camera
{
   description = "* Camera Core";
   shapeFile = "Camera";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 100;
   className = "HandAmmo";
};

function Camera::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// We try to deploy it
		if (Camera::deployShape(%player, %item)) {
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player,Beacon);
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}

function Camera::deployShape(%player, %item)
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
					%camera = newObject("Camera","Turret",CameraTurret,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "Camera"]++;
					echo("MSG: ",%client," deployed a Camera");
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
