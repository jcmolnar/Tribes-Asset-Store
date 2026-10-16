

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Blast Wall
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData BlastWallPackImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData BlastWallPack 
{ 
   description = "Blast Wall"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = BlastWallPackImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function BlastWallPack::onUse(%player,%item)
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

function BlastWallPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Blast Wall#" @ $totalNumBlastWalls[%client]++;
	%shape = BlastWall;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "BlastWallPack"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Panel Wall One Right
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData newdooroneRImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData newdooroneR 
{ 
   description = "Panel Wall One Right"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = newdooroneRImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function newdooroneR::onUse(%player,%item)
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

function newdooroneR::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Panel Wall One Right#" @ $totalNumnewdooroneR[%client]++;
	%shape = newdooroneRShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "newdooroneR"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Panel Wall One Left
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData newdooroneLImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData newdooroneL 
{ 
   description = "Panel Wall One Left"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = newdooroneLImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function newdooroneL::onUse(%player,%item)
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

function newdooroneL::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Panel Wall One Left#" @ $totalNumnewdooroneL[%client]++;
	%shape = newdooroneLShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "newdooroneL"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Panel Wall Two Right
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData newdoortwoRImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData newdoortwoR 
{ 
   description = "Panel Wall Two Right"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = newdoortwoRImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function newdoortwoR::onUse(%player,%item)
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

function newdoortwoR::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Panel Wall Two Right#" @ $totalNumnewdoortwoR[%client]++;
	%shape = newdoortwoRShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "newdoortwoR"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Panel Wall Two Left
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData newdoortwoLImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData newdoortwoL 
{ 
   description = "Panel Wall Two Left"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = newdoortwoLImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function newdoortwoL::onUse(%player,%item)
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

function newdoortwoL::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Panel Wall Two Left#" @ $totalNumnewdoortwoL[%client]++;
	%shape = newdoortwoLShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "newdoortwoL"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Panel Wall Three Right
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData newdoorthreeRImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData newdoorthreeR 
{ 
   description = "Panel Wall Three Right"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = newdoorthreeRImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function newdoorthreeR::onUse(%player,%item)
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

function newdoorthreeR::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Panel Wall Three Right#" @ $totalNumnewdoorthreeR[%client]++;
	%shape = newdoorthreeRShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "newdoorthreeR"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Panel Wall Three Left
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData newdoorthreeLImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData newdoorthreeL 
{ 
   description = "Panel Wall Three Left"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = newdoorthreeLImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function newdoorthreeL::onUse(%player,%item)
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

function newdoorthreeL::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Panel Wall Three Left#" @ $totalNumnewdoorthreeL[%client]++;
	%shape = newdoorthreeLShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "newdoorthreeL"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Panel Wall Four Right
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData newdoorfourRImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData newdoorfourR 
{ 
   description = "Panel Wall Four Right"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = newdoorfourRImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function newdoorfourR::onUse(%player,%item)
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

function newdoorfourR::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Panel Wall Four Right#" @ $totalNumnewdoorfourR[%client]++;
	%shape = newdoorfourRShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "newdoorfourR"]++;
		}
	}
}





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Panel Wall Four Left
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData newdoorfourLImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData newdoorfourL 
{ 
   description = "Panel Wall Four Left"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = newdoorfourLImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function newdoorfourL::onUse(%player,%item)
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

function newdoorfourL::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Panel Wall Four Left#" @ $totalNumnewdoorfourL[%client]++;
	%shape = newdoorfourLShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "newdoorfourL"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Force Field
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData DeployableForceFieldImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData DeployableForceField 
{ 
   description = "Force Field"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = DeployableForceFieldImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function DeployableForceField::onUse(%player,%item)
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

function DeployableForceField::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Force Field#" @ $totalNumDeployableForceFields[%client]++;
	%shape = DeployableForceFieldShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "DeployableForceField"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Large Force Field
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData LargeForceFieldImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData LargeForceField 
{ 
   description = "Large Force Field"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "nDeployableWalls"; 
   imageType = LargeForceFieldImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function LargeForceField::onUse(%player,%item)
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

function LargeForceField::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Large Force Field#" @ $totalNumLargeForceFields[%client]++;
	%shape = LargeForceFieldShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "LargeForceField"]++;
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

function Wall::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,$Nappy::WallDeployDistance)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "StaticShape" || $Nappy::DeployOnAnything) {
				if($BuilderMode){
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
					%wall = newObject("","StaticShape",%shape,true);
 	        			addToSet("MissionCleanup", %wall); 
					GameBase::setTeam(%wall,GameBase::getTeam(%player)); 
					GameBase::setPosition(%wall,$los::position); 
					GameBase::setRotation(%wall,%rot); 
					Gamebase::setMapName(%wall,%name @ " " @ Nappy::getName(%client));
					Client::sendMessage(%client,0,%item.description @ " deployed"); 
					GameBase::startFadeIn(%wall); 
					playSound(SoundPickupBackpack,$los::position); 
					playSound(ForceFieldOpen,$los::position);
					echo("MSG: ",%client," deployed a ",%item.description); 
					return true;
				}
				else{
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player); 
							%wall = newObject("","StaticShape",%shape,true); 
							addToSet("MissionCleanup", %wall); 
							GameBase::setTeam(%wall,GameBase::getTeam(%player)); 
							GameBase::setPosition(%wall,$los::position); 
							GameBase::setRotation(%wall,%rot); 
							Gamebase::setMapName(%wall,%name @ " " @ Nappy::getName(%client));
							Client::sendMessage(%client,0,%item.description @ " deployed"); 
							GameBase::startFadeIn(%wall); 
							playSound(SoundPickupBackpack,$los::position); 
							playSound(ForceFieldOpen,$los::position);
							echo("MSG: ",%client," deployed a ",%item.description); 
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
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


