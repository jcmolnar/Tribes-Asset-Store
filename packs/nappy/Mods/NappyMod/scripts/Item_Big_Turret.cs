

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Elf Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData ElfTurretPackImage
{
   shapeFile = "remoteturret";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData ElfTurretPack
{
   description = "Elf Turret";
   shapeFile = "remoteturret";
   className = "Backpack";
   heading = "jBig Turrets";
   imageType = ElfTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function ElfTurretPack::onUse(%player,%item)
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

function ElfTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Elf Turret#" @ $totalNumElfTurrets[%client]++;
	%shape = DeployableElf;
	if($BuilderMode){
		SmallTurret::deployShape(%player,%name,%shape,%item);
	}
	else if (BigTurret::deployShape(%player,%name,%shape,%item)){
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "ElfTurretPack"]++;
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Mortar Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData MortarTurretPackImage
{
   shapeFile = "remoteturret";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData MortarTurretPack
{
   description = "Mortar Turret";
   shapeFile = "remoteturret";
   className = "Backpack";
   heading = "jBig Turrets";
   imageType = MortarTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function MortarTurretPack::onUse(%player,%item)
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

function MortarTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Mortar Turret#" @ $totalNumMortarTurrets[%client]++;
	%shape = DeployableMortar;
	if($BuilderMode){
		SmallTurret::deployShape(%player,%name,%shape,%item);
	}
	else if (BigTurret::deployShape(%player,%name,%shape,%item)){
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MortarTurretPack"]++;
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Plasma Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData PlasmaTurretPackImage
{
   shapeFile = "remoteturret";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData PlasmaTurretPack
{
   description = "Plasma Turret";
   shapeFile = "remoteturret";
   className = "Backpack";
   heading = "jBig Turrets";
   imageType = PlasmaTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function PlasmaTurretPack::onUse(%player,%item)
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

function PlasmaTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Plasma Turret#" @ $totalNumPlasmaTurrets[%client]++;
	%shape = DeployablePlasma;
	if($BuilderMode){
		SmallTurret::deployShape(%player,%name,%shape,%item);
	}
	else if (BigTurret::deployShape(%player,%name,%shape,%item)){
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PlasmaTurretPack"]++;
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Rail Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData RailTurretPackImage
{
   shapeFile = "remoteturret";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData RailTurretPack
{
   description = "Rail Turret";
   shapeFile = "remoteturret";
   className = "Backpack";
   heading = "jBig Turrets";
   imageType = RailTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function RailTurretPack::onUse(%player,%item)
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

function RailTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Rail Turret#" @ $totalNumRailTurrets[%client]++;
	%shape = DeployableRail;
	if($BuilderMode){
		SmallTurret::deployShape(%player,%name,%shape,%item);
	}
	else if (BigTurret::deployShape(%player,%name,%shape,%item)){
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "RailTurretPack"]++;
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Rocket Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData RocketTurretPackImage
{
   shapeFile = "remoteturret";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData RocketTurretPack
{
   description = "Rocket Turret";
   shapeFile = "remoteturret";
   className = "Backpack";
   heading = "jBig Turrets";
   imageType = RocketTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function RocketTurretPack::onUse(%player,%item)
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

function RocketTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Rocket Turret#" @ $totalNumRocketTurrets[%client]++;
	%shape = DeployableRocket;
	if($BuilderMode){
		SmallTurret::deployShape(%player,%name,%shape,%item);
	}
	else if (BigTurret::deployShape(%player,%name,%shape,%item)){
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "RocketTurretPack"]++;
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Vulcan Turret
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData VulcanTurretPackImage
{
   shapeFile = "remoteturret";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.1 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData VulcanTurretPack
{
   description = "Vulcan Turret";
   shapeFile = "remoteturret";
   className = "Backpack";
   heading = "jBig Turrets";
   imageType = VulcanTurretPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 350;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function VulcanTurretPack::onUse(%player,%item)
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

function VulcanTurretPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Vulcan Turret#" @ $totalNumVulcanTurrets[%client]++;
	%shape = DeployableVulcan;
	if($BuilderMode){
		SmallTurret::deployShape(%player,%name,%shape,%item);
	}
	else if (BigTurret::deployShape(%player,%name,%shape,%item)){
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "VulcanTurretPack"]++;
	}
}




//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{
//                              Deploy
//}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

function BigTurret::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,$Nappy::WallDeployDistance)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || $Nappy::DeployOnAnything) {	    		%set = newObject("set",SimSet);
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
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("","Turret",%shape,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,%name @ " " @ Nappy::getName(%client));
								Client::sendMessage(%client,0,%item.description @ " deployed"); 
								GameBase::startFadeIn(%turret); 
								playSound(SoundPickupBackpack,$los::position); 
								playSound(ForceFieldOpen,$los::position);
								echo("MSG: ",%client," deployed a ",%item.description);
								if ($Nappy::SetOwnerToTurrets){
									Client::setOwnedObject(%client, %turret); 
									Client::setOwnedObject(%client, %player);
								}
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}


