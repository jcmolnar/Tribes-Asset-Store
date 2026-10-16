createMisc(Beacon, "", 1, 0, 3, 3, 3, 5, 40);
AmmoPack::addAmmo(Beacon, 10);

ItemData Beacon {
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	validateShape = true;
	validateMaterials = true;
};

function Beacon::onUse(%player, %item){
	if(Beacon::deployShape(%player, %item)) Player::decItemCount(%player, %item);
}

function Beacon::deployShape(%player, %item){
	%client = Player::getClient(%player);
 	if(!GameBase::getLOSInfo(%player, 3)){
	 	Client::sendMessage(%client,0,"Deploy position out of range");
	 	return false;
 	}
	// GetLOSInfo sets the following globals:
	// 	los::position
	// 	los::normal
	// 	los::object
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape"){
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
	// Try to stick it straight up or down, otherwise
	// just use the surface normal
	if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 0";
	else{
		if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 0";
		else %rot = Vector::getRotation($los::normal);
	}
  	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
	deleteObject(%set);
	if(%num){
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		return false;
	}
	%team = GameBase::getTeam(%player);
	if($TeamItemMax[%item] <= $TeamItemCount[%team @ %item] && !$TestCheats){
		Client::sendMessage(%client, 0, "Deployable Item limit reached");
		return false;
	}
	%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon, GameBase::getTeam(%player));
	GameBase::setRotation(%beacon, %rot);
	GameBase::setPosition(%beacon, $los::position);
	Gamebase::setMapName(%beacon, "Target Beacon");
	Beacon::onEnabled(%beacon);
	Client::sendMessage(%client, 0, "Beacon deployed");
	$TeamItemCount[GameBase::getTeam(%beacon) @"Beacon"]++;
	return true;
}