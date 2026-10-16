
//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Deployable Platform
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData DeployablePlatformImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData DeployablePlatform 
{ 
   description = "Deployable Platform"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "oPlatforms"; 
   imageType = DeployablePlatformImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function DeployablePlatform::onUse(%player,%item)
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

function DeployablePlatform::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Deployable Platform#" @ $totalNumDeployablePlatforms[%client]++;
	%shape = DeployablePlatformShape;
	if (DeployablePlatform::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "DeployablePlatform"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Medium Platform
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData MediumPlatformImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData MediumPlatform 
{ 
   description = "Medium Platform"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "oPlatforms"; 
   imageType = MediumPlatformImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function MediumPlatform::onUse(%player,%item)
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

function MediumPlatform::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Medium Platform#" @ $totalNumMediumPlatforms[%client]++;
	%shape = MediumPlatformShape;
	if (DeployablePlatform::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "MediumPlatform"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Large Platform
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData LargePlatformImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData LargePlatform 
{ 
   description = "Large Platform"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "oPlatforms"; 
   imageType = LargePlatformImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function LargePlatform::onUse(%player,%item)
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

function LargePlatform::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Large Platform#" @ $totalNumLargePlatforms[%client]++;
	%shape = LargePlatformShape;
	if (DeployablePlatform::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "LargePlatform"]++;
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

function DeployablePlatform::deployShape(%player,%name,%shape,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,$Nappy::PlatformDeployDistance)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || $Nappy::DeployOnAnything)  {
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

 	 		         		%platform = newObject("","StaticShape",%shape,true);
 	 		         		addToSet("MissionCleanup", %platform);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%platform,GameBase::getTeam(%player));
						GameBase::setPosition(%platform,$los::position);
						GameBase::setRotation(%platform,%rot);
						Gamebase::setMapName(%platform,%name @ " " @ Nappy::getName(%client));
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a " @ %item.description);
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



