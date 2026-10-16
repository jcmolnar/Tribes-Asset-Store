//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Scout Vehicle Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData ScoutVehiclePackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData ScoutVehiclePack
 
{ 
description = "Scout Vehicle Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "vDeployable Vehicles"; 
imageType = ScoutVehiclePackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true;
}; 

function ScoutVehiclePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ ScoutVehicle] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[ScoutVehicle]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ScoutVehiclePack::onDeploy(%player,%item,%pos)
{
%shape = Scout;
%itemName = ScoutVehicle;
	if (VehiclePack::deployShape(%player,%shape,%item,%itemName)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++;
		}
	}
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Wraith Vehicle Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData WraithVehiclePackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData WraithVehiclePack
 
{ 
description = "Wraith Vehicle Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "vDeployable Vehicles"; 
imageType = WraithVehiclePackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true;
}; 

function WraithVehiclePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ WraithVehicle] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[WraithVehicle]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function WraithVehiclePack::onDeploy(%player,%item,%pos)
{
%shape = Wraith;
%itemName = WraithVehicle;
	if (VehiclePack::deployShape(%player,%shape,%item,%itemName)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "WraithVehicle"]++;
		}
	}
}




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Jet Vehicle Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData JetVehiclePackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData JetVehiclePack
 
{ 
description = "Jet Vehicle Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "vDeployable Vehicles"; 
imageType = JetVehiclePackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true;
}; 

function JetVehiclePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ JetVehicle] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[JetVehicle]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function JetVehiclePack::onDeploy(%player,%item,%pos)
{
%shape = Jet;
%itemName = JetVehicle;
	if (VehiclePack::deployShape(%player,%shape,%item,%itemName)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"]++;
		}
	}
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             LAPC Vehicle Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData LAPCVehiclePackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData LAPCVehiclePack
 
{ 
description = "LAPC Vehicle Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "vDeployable Vehicles"; 
imageType = LAPCVehiclePackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true;
}; 

function LAPCVehiclePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ LAPCVehicle] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[LAPCVehicle]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LAPCVehiclePack::onDeploy(%player,%item,%pos)
{
%shape = LAPC;
%itemName = LAPCVehicle;
	if (VehiclePack::deployShape(%player,%shape,%item,%itemName)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "LAPCVehicle"]++;
		}
	}
}




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             HAPC Vehicle Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData HAPCVehiclePackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData HAPCVehiclePack
 
{ 
description = "HAPC Vehicle Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "vDeployable Vehicles"; 
imageType = HAPCVehiclePackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true;
}; 

function HAPCVehiclePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ HAPCVehicle] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[HAPCVehicle]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function HAPCVehiclePack::onDeploy(%player,%item,%pos)
{
%shape = HAPC;
%itemName = HAPCVehicle;
	if (VehiclePack::deployShape(%player,%shape,%item,%itemName)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++;
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

function VehiclePack::deployShape(%player,%shape,%item,%itemName) 
{ 
%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %itemName] < $TeamItemMax[%itemName]){ 
		%playerPos = GameBase::getPosition(%player);
		if(Nappy::CheckVehicleClearance(%playerPos)){
			%rot = GameBase::getRotation(%player); 
			%vehicle = newObject("",flier,%shape,true); 
			addToSet("MissionCleanup", %vehicle); 
			GameBase::setTeam(%vehicle,GameBase::getTeam(%player)); 
			GameBase::setPosition(%vehicle,%playerPos); 
			GameBase::setRotation(%vehicle,%rot); 
			Client::sendMessage(%client,0,"Piloting " @ %shape); 
			GameBase::startFadeIn(%vehicle); 
			playSound(SoundPickupBackpack,$los::position); 
			echo("MSG: ",%client," deployed a " @ %shape);  
			return true; 
		}
		else
			Client::sendMessage(%client,0,"CANNOT DEPLOY VEHICLE::Too close to objects");
	} 
	else 
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 







function Nappy::CheckVehicleClearance(%pos)
{
	%BoxLength = $Nappy::VehicleCheckDistance::BoxLength;
	%BoxWidth = $Nappy::VehicleCheckDistance::BoxWidth;
	%BoxHeight = $Nappy::VehicleCheckDistance::BoxHeight;

	%set = newObject("VehicleCheck",SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType, %pos, %BoxLength, %BoxWidth, %BoxHeight, 0);
	deleteObject(%set);
	if(%num > 3){
		return false;
	}
	else{
		return true;
	}
}











