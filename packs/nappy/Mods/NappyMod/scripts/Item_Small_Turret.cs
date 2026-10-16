
//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Camera
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

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
   heading = "iSmall Turrets";
   imageType = CameraPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 100;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
};

function CameraPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function CameraPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Camera#" @ $totalNumCameras[%client]++;
	%shape = CameraTurret;
	if (SmallTurret::deployShape(%player,%name,%shape,%item)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "CameraPack"]++;
		}
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Laser Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData LaserTurretPackImage
{
   shapeFile = "camera";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData LaserTurretPack
{
   description = "Laser Turret";
   shapeFile = "camera";
   className = "Backpack";
   heading = "iSmall Turrets";
   imageType = LaserTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Laser Turret#" @ $totalNumLaserTurrets[%client]++;
	%shape = DeployableLaser;
	if (SmallTurret::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurretPack"]++;
		}
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Ion Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData IonTurretPackImage
{
   shapeFile = "remoteturret";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData IonTurretPack
{
   description = "Ion Turret";
   shapeFile = "remoteturret";
   className = "Backpack";
   heading = "iSmall Turrets";
   imageType = IonTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function IonTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function IonTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Ion Turret#" @ $totalNumIonTurrets[%client]++;
	%shape = IonTurret;
	if (SmallTurret::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "IonTurretPack"]++;
		}
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Indoor Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData IndoorTurretPackImage
{
   shapeFile = "indoorgun";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData IndoorTurretPack
{
   description = "Indoor Turret";
   shapeFile = "indoorgun";
   className = "Backpack";
   heading = "iSmall Turrets";
   imageType = IndoorTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function IndoorTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function IndoorTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Indoor Turret#" @ $totalNumIndoorTurrets[%client]++;
	%shape = DeployableIndoor;
	if (SmallTurret::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "IndoorTurretPack"]++;
		}
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Shock Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData ShockTurretPackImage
{
   shapeFile = "indoorgun";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData ShockTurretPack
{
   description = "Shock Turret";
   shapeFile = "indoorgun";
   className = "Backpack";
   heading = "iSmall Turrets";
   imageType = ShockTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function ShockTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ShockTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Shock Turret#" @ $totalNumShockTurrets[%client]++;
	%shape = DeployableShock;
	if (SmallTurret::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "ShockTurretPack"]++;
		}
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              AntiAir Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData AntiAirTurretPackImage
{
   shapeFile = "remoteturret";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData AntiAirTurretPack
{
   description = "AntiAir Turret";
   shapeFile = "remoteturret";
   className = "Backpack";
   heading = "iSmall Turrets";
   imageType = AntiAirTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function AntiAirTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AntiAirTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "AntiAir Turret#" @ $totalNumAntiAirTurrets[%client]++;
	%shape = AntiAirTurret;
	if (SmallTurret::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "AntiAirTurretPack"]++;
		}
	}
}




//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{
//                              Deploy
//}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------


function SmallTurret::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,$Nappy::SmallTurretDeployDistance)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || $Nappy::DeployOnAnything)  {				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,%shape,%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,%shape,%num);
					deleteObject(%set);
					if(0 == %num) {
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
						if(checkDeployArea(%client,$los::position)){
							%turret = newObject("","Turret",%shape,true);
 	        			   		addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,%name @ " " @ Nappy::getName(%client));
							Client::sendMessage(%client,0,%item.description @ " deployed");
							playSound(SoundPickupBackpack,$los::position);
							echo("MSG: ",%client," deployed a ",%name);
							if ($Nappy::SetOwnerToTurrets){
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
							}
							return true;
						}
					}
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
				else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");

			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");		
	}
	else																						  
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}


