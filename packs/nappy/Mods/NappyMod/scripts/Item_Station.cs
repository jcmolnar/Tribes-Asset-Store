//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Inventory Station
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData DeployableInvPackImage
{
   shapeFile = "invent_remote";
   mountPoint = 2;
   mountOffset = { 0, -0.12, -0.3 };
   mountRotation = { 0, 0, 0 };
   mass = 2.5;
   firstPerson = false;
};

ItemData DeployableInvPack
{
   description = "Inventory Station";
   shapeFile = "invent_remote";
   className = "Backpack";
   heading = "hStations";
   shadowDetailMask = 4	;
   imageType = DeployableInvPackImage;
   mass = 2.0;
   elasticity = 0.2;
   price = $Nappy::RemoteInvPrice;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item){
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Inventory Station#" @ $totalNumInventoryStations[%client]++;
	%shape = DeployableInvStation;
	if (DeployableStation::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "DeployableInvPack"]++;
		}
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Ammo Station
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData DeployableAmmoPackImage
{
   shapeFile = "ammounit_remote";
   mountPoint = 2;
   mountOffset = { 0, -0.1, -0.3 };
   mountRotation = { 0, 0, 0 };
   mass = 1.0;
   firstPerson = false;
};

ItemData DeployableAmmoPack
{
   description = "Ammo Station";
   shapeFile = "ammounit_remote";
   className = "Backpack";
   heading = "hStations";
   shadowDetailMask = 4;
   imageType = DeployableAmmoPackImage;
   mass = 2.0;
   elasticity = 0.2;
   price = $Nappy::RemoteAmmoPrice;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function DeployableAmmoPack::onUse(%player,%item)
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

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Ammo Station#" @ $totalNumAmmoStations[%client]++;
	%shape = DeployableAmmoStation;
	if (DeployableStation::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "DeployableAmmoPack"]++;
		}
	}
}

//=================================================================================
//=================================================================================
//============================Command Station======================================
//=================================================================================
//=================================================================================

ItemImageData DeployableComPackImage 
{ 
   shapeFile = "ammounit_remote"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.12, -0.3 }; 
   mountRotation = { 0, 0, 0 }; 
   mass = 4.5; 
   firstPerson = false; 
}; 

ItemData DeployableComPack 
{ 
   description = "Command Station"; 
   shapeFile = "ammounit_remote"; 
   className = "Backpack"; 
   heading = "hStations"; 
   shadowDetailMask = 4 ; 
   imageType = DeployableComPackImage; 
   mass = 4.0; 
   elasticity = 0.2; 
   price = 2000; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function DeployableComPack::onUse(%player,%item)
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

function DeployableComPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Command Station#" @ $totalNumCommandStations[%client]++;
	%shape = "DeployableComStation";
	if (DeployableStation::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "DeployableComPack"]++;
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

//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]

function DeployableStation::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,$Nappy::StationDeployDistance)) {
			%obj = getObjectType($los::object);
			if(((%obj == "SimTerrain" || %obj == "InteriorShape") || $Nappy::DeployOnAnything) && %obj != "Flier"){
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%station = newObject("ammounit_remote","StaticShape",%shape,true);
 	 		         		addToSet("MissionCleanup", %station);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%station,GameBase::getTeam(%player));
						GameBase::setPosition(%station,$los::position);
						GameBase::setRotation(%station,%rot);
						Gamebase::setMapName(%station,%name @ " " @ Nappy::getName(%client));
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a " @ %item.description);
						return true;
					}
				}
				else {
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
			}
			else {
				Client::sendMessage(%client,0,"Can't deploy station here");
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

//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]


