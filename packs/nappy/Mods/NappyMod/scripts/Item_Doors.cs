//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Blast Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData BlastDoorImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData BlastDoor 
{ 
   description = "Blast Door"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "mDoors"; 
   imageType = BlastDoorImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function BlastDoor::onUse(%player,%item)
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

function BlastDoor::onDeploy(%player,%item,%pos)
{
%client = Player::getClient(%player);
%name = "Blast Door#" @ $totalNumBlastDoors[%client]++;
%shape = BlastDoorShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "BlastDoor"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             3 by 4 Force Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData doorthreebyfourForceFieldImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData doorthreebyfourForceField 
{ 
   description = "3 by 4 Force Field Door"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "mDoors"; 
   imageType = doorthreebyfourForceFieldImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function doorthreebyfourForceField::onUse(%player,%item)
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

function doorthreebyfourForceField::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "3 by 4 Force Field Door#" @ $totalNumdoorthreebyfourForceFields[%client]++;
	%shape = doorthreebyfourForceFieldShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "doorthreebyfourForceField"]++;
		}
	}
}






//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             4 by 8 Force Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData doorfourbyeightForceFieldImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData doorfourbyeightForceField 
{ 
   description = "4 by 8 Force Field Door"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "mDoors"; 
   imageType = doorfourbyeightForceFieldImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function doorfourbyeightForceField::onUse(%player,%item)
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

function doorfourbyeightForceField::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "4 by 8 Force Field Door#" @ $totalNumdoorfourbyeightForceFields[%client]++;
	%shape = doorfourbyeightForceFieldShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "doorfourbyeightForceField"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             4 by 14 Force Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData doorfourbyfourteenForceFieldImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData doorfourbyfourteenForceField 
{ 
   description = "4 by 14 Force Field Door"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "mDoors"; 
   imageType = doorfourbyfourteenForceFieldImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function doorfourbyfourteenForceField::onUse(%player,%item)
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

function doorfourbyfourteenForceField::onDeploy(%player,%item,%pos)
{
%client = Player::getClient(%player);
%name = "4 by 14 Force Field Door#" @ $totalNumdoorfourbyfourteenForceFields[%client]++;
%shape = doorfourbyfourteenForceFieldShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "doorfourbyfourteenForceField"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             4 by 17 Force Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData doorfourbyseventeenForceFieldImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData doorfourbyseventeenForceField 
{ 
   description = "4 by 17 Force Field Door"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "mDoors"; 
   imageType = doorfourbyseventeenForceFieldImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function doorfourbyseventeenForceField::onUse(%player,%item)
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

function doorfourbyseventeenForceField::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "4 by 17 Force Field Door#" @ $totalNumdoorfourbyseventeenForceFields[%client]++;
	%shape = doorfourbyseventeenForceFieldShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "doorfourbyseventeenForceField"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             5 by 5 Force Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData doorfivebyfiveForceFieldImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData doorfivebyfiveForceField 
{ 
   description = "5 by 5 Force Field Door"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "mDoors"; 
   imageType = doorfivebyfiveForceFieldImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function doorfivebyfiveForceField::onUse(%player,%item)
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

function doorfivebyfiveForceField::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "5 by 5 Force Field Door#" @ $totalNumdoorfivebyfiveForceFields[%client]++;
	%shape = doorfivebyfiveForceFieldShape;
	if (Wall::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "doorfivebyfiveForceField"]++;
		}
	}
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Large Platform Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData LargePlatformDoorImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.1, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData LargePlatformDoor 
{ 
   description = "Large Platform Door"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "mDoors"; 
   imageType = LargePlatformDoorImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function LargePlatformDoor::onUse(%player,%item)
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

function LargePlatformDoor::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Large Platform Door#" @ $totalNumLargePlatformDoors[%client]++;
	%shape = LargePlatformDoorShape;
	if (DeployablePlatform::deployShape(%player,%name,%shape,%item)){
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "LargePlatformDoor"]++;
		}
	}
}


