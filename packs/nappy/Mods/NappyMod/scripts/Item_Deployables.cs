

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Arbitor
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData ArbitorPackImage
{
   shapeFile = "magcargo";
   mountPoint = 2;
   mountOffset = { 0, -0.1, -0.06 };
   mountRotation = { 0, 0, 0 };
   firstPerson = false;
};

ItemData ArbitorPack
{
   description = "Arbitor";
   shapeFile = "magcargo";
   className = "Backpack";
   heading = "lDeployable Objects";
   imageType = ArbitorPackImage;
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

function ArbitorPack::onUse(%player,%item)
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

function ArbitorPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Arbitor Box#" @ $totalNumArbitors[%client]++;
	%shape = ArbitorBox;
	%type = "Turret"; //"StaticShape"||"Turret"||"StaticShape"||"flier"
	if (Object::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "ArbitorPack"]++;
		}
	}
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                           Teleport Pad
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData TeleportPackImage 
{ 
   shapeFile = "flagstand"; 
   mountPoint = 2; 
   mountOffset = { 0, 0, 0.1 }; 
   mountRotation = { 1.57, 0, 0 }; 
   firstPerson = false; 
}; 

ItemData TeleportPack 
{ 
   description = "Teleport Pad"; 
   shapeFile = "flagstand"; 
   className = "Backpack"; 
   heading = "lDeployable Objects"; 
   imageType = TeleportPackImage; 
   shadowDetailMask = 4; 
   mass = 5.0; 
   elasticity = 0.2; 
   price = 3200; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function TeleportPack::onUse(%player,%item)
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

function TeleportPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Teleport Pad#" @ $totalNumTeleportPacks[%client]++;
	%shape = DeployableTeleport;
	//%type = "Turret"; //"StaticShape"||"Turret"||"StaticShape"||"flier"
	if (teleportPack::deployShape(%player,%name,%shape,%item)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"]++;
		}
	}
}


function CreateteleportSimSet() 
{ 
%teleset = nameToID("MissionCleanup/Teleports"); 
	if(%teleset == -1) { 
		newObject("Teleports",SimSet); 
		addToSet("MissionCleanup","Teleports"); 
	} 
} 







function TeleportPack::deployShape(%player,%name,%shape,%item) 
{ 
%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"] < $TeamItemMax[TeleportPack]){ 
		if (GameBase::getLOSInfo(%player,$Nappy::ObjectDeployDistance)){ 
			if (Vector::dot($los::normal,"0 0 1") > 0.7){ 
				%pad = newObject("Teleport Pad","StaticShape",%shape,true); 
				CreateteleportSimSet(); 
				addToSet("MissionCleanup/Teleports", %pad); 
				addToSet("MissionCleanup", %pad); 
				GameBase::setTeam(%pad,GameBase::getTeam(%player)); 
				%pos = Vector::add($los::position,"0 0 0.1"); 
				echo("LOS pos " @ $los::position @ " " @ %pos); 
				GameBase::setPosition(%pad,%pos); 
				Gamebase::setMapName(%pad,%name); 
				Client::sendMessage(%client,0,%item.description @ " deployed"); 
				%pad.disabled = false; 
				playSound(SoundPickupBackpack,$los::position);
				   %beam = newObject("","StaticShape",TeleportBeam,true); 
				   addToSet("MissionCleanup", %beam); 
				   GameBase::setTeam(%beam,GameBase::getTeam(%player)); 
				   GameBase::setPosition(%beam,%pos); 
				   %pad.beam1 = %beam;
				%team = GameBase::getTeam(%player);
				$NumOfTeamTeleports[%team] = $TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"];
				if(!$BuilderMode){
					for(%i = 0; (%i < $TeamItemMax[TeleportPack]); %i++){
						if($TeamTeleNum[%team,%i] != 1){
							$TeamTeleNum[%team,%i] = 1;
							%pad.teleNum = %i;
							return true;
						}
					}
				}
				else{
					for(%i = 0; (%i < 9999); %i++){
						if($TeamTeleNum[%team,%i] != 1){
							$TeamTeleNum[%team,%i] = 1;
							%pad.teleNum = %i;
							%i = 9999;
							%teleNumSet = 1;
						}
					}
					if(%teleNumSet)
						return true;
					else
						return false;
				}
			} 
			else 
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
		} 
		else 
			Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); 
return false; 
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                            DeployableFlagStand
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData FlagstandPackImage
{
   shapeFile = "ammopack";
   mountPoint = 2;
   mountOffset = { 0, 0, 0 };
   mountRotation = { 0, 0, 0 };
   firstPerson = false;
};

ItemData FlagstandPack
{	
   description = "Flag Stand";
   shapefile = "ammopack";
   classname = "Backpack";
   heading = "lDeployable Objects";
   imageType = FlagstandPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.1;
   price = 100;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function FlagstandPack::onUse(%player,%item)
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

function FlagstandPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Flagstand#" @ $totalNumDeployableFlagstands[%client]++;
	%shape = DeployableFlagstand;
	%type = "StaticShape"; //"StaticShape"||"Turret"||"StaticShape"||"flier"
	if (Object::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "FlagstandPack"]++;
		}
	}
}


function DeployableFlagstand::onCollision(%this,%object)
{
	if(%object.enterTime > getSimTime() - 3)
		return;
	%standTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%object);
	%playerClient = Player::getClient(%object);
	if(getObjectType(%object) != "Player" || %playerTeam != %standTeam || %object.carryflag == "") // %standteam == -1 ||
		return;
	%flag = %object.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	if(%this.carryflag != "")
		return;
	%this.carryflag = %flag;
	%flag.carrier = -1;
	Item::hide(%flag, false);
	GameBase::setPosition(%flag, GameBase::getPosition(%this)); 
	playSound(SoundPickupBackpack, GameBase::getPosition(%this));
	%flag.flagStand = %this;
	%flag.atflagstand = 1;//[][][][]][][][][[][[][][][][][][][][[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]][
	Player::setItemCount(%object, Flag, 0);
	%object.carryFlag = "";
	%playerClient = Player::getClient(%object);
	Flag::clearWaypoint(%playerClient, true);
	//if(getTeamName(%flag) == %playerTeam){
	if(%flagTeam == %playerTeam){
		MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " flag has been moved to a new position");
		Client::sendMessage(%playerClient, 0, "You moved your flag.");
	}
	else {
		MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " have set an enemy flag on a flagstand");
		Client::sendMessage(%playerClient, 0, "You placed the enemy flag down.");
	}	
	%object.enterTime = getSimTime();
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Springboard                                           
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData SpringPackImage 
{ 
   shapeFile = "AmmoPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.03, 0 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData SpringPack 
{ 
   description = "Springboard"; 
   shapeFile = "AmmoPack"; 
   className = "Backpack"; 
   heading = "lDeployable Objects"; 
   imageType = SpringPackImage; 
   shadowDetailMask = 4; 
   mass = 1.0; 
   elasticity = 0.2; 
   price = 500; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 



function SpringPack::onUse(%player,%item)
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

function SpringPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Springboard#" @ $totalNumSpringPacks[%client]++;
	%shape = DeployableSpring;
	%type = "StaticShape"; //"StaticShape"||"Turret"||"StaticShape"||"flier"
	if (Object::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++;
		}
	}
}




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                            Hologram                                            
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================


ItemImageData HoloPackImage 
{ 
   shapeFile = "ShieldPack"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.03, 0 }; 
   mass = 1.0; firstPerson = false; 
}; 

ItemData HoloPack 
{ 
   description = "Hologram"; 
   shapeFile = "larmor"; 
   className = "Backpack"; 
   heading = "lDeployable Objects"; 
   imageType = HoloPackImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 900; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function HoloPack::onUse(%player,%item)
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

function HoloPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Hologram#" @ $totalNumHolograms[%client]++;
	%type = "StaticShape"; //"StaticShape"||"Turret"||"StaticShape"||"flier"
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 6) 
		%shape = Hologram1;
	else if((%rnd > 2) && (%rnd < 7)) 
		%shape = Hologram2; 
	else 
		%shape = Hologram3; 
	if (Object::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "HoloPack"]++;
		}
	}
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                            Mechanical Tree                                            
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData TreePackImage 
{ 
   shapeFile = "tree1"; 
   mountPoint = 2; 
   mountOffset = { 0, 0.15, -1 }; 
   mass = 2.5; 
   firstPerson = false; 
}; 

ItemData TreePack 
{ 
   description = "Mechanical Tree"; 
   shapeFile = "grenade"; 
   className = "Backpack"; 
   heading = "lDeployable Objects"; 
   imageType = TreePackImage; 
   shadowDetailMask = 4; 
   mass = 1.5; 
   elasticity = 0.2; 
   price = 600; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function TreePack::onUse(%player,%item)
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

function TreePack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Tree#" @ $totalNumTreePacks[%client]++;
	%type = "StaticShape"; //"StaticShape"||"Turret"||"StaticShape"||"flier"
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 5) 
		%shape = DeployableTree;
	else 
		%shape = DeployableTree2; 
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//==================================================================================

//				NOT WORKING

//	%pos = GameBase::getPosition(%player);
//	%BoxLength = $Nappy::TreeServerCrashDistance::BoxLength;
//	%BoxWidth = $Nappy::TreeServerCrashDistance::BoxWidth;
//	%BoxHeight = $Nappy::TreeServerCrashDistance::BoxHeight;

//	%set = newObject("ATScrash" @ %this,SimSet);
//	%num = containerBoxFillSet(%set, $StaticObjectType, %pos, %BoxLength, %BoxWidth, %BoxHeight, 0);
//	%trees = CountObjects(%set,"DeployableTree",%num);
//	%tree2s = CountObjects(%set,"DeployableTree2",%num);
//	%treeCount = %trees + %tree2s;
//messageall(0,"Tree count = " @ %treeCount);
//	if(%treeCount > 9){
//			Nappy::Tree::Delete(%set, %num, %treeCount);
//	}
//	else
//		deleteObject(%set);


//==================================================================================
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	if (Object::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
		}
	}
}


function Nappy::Tree::Delete(%set, %num, %treeCount, %count)
{
	if(!%count)
		%count = 0;
	if(GameBase::getDataName(Group::getObject(%set,%count)) == "DeployableTree" || GameBase::getDataName(Group::getObject(%set,%count)) == "DeployableTree2"){
		deleteObject(Group::getObject(%set,%count));
		%treeCount--;
	}
	%count++;
	if(%treeCount && (%count > %num))
		schedule("Nappy::Tree::Delete(" @ %set @ ", " @ %num @ ", " @ %treeCount @ ", " @ %count @ ");",0.2);
	else
		messageall(0,"Trees all cleared.");
}
//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                            Jail Capture Pad                                            
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData JailCapPackImage
{
   shapeFile = "AmmoPack";
   mountPoint = 2;
   mountOffset = { 0, -0.5, -0.3 };
   mass = 2.5;
   firstPerson = false;
};

ItemData JailCapPack
{
   description = "Jail Capture Pad";
   shapeFile = "AmmoPack";
   className = "Backpack";
   heading = "lDeployable Objects";
   imageType = JailCapPackImage;
   shadowDetailMask = 4;
   mass = 1.0;
   elasticity = 0.2;
   price = 500;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function JailCapPack::onUse(%player,%item)
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

function JailCapPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Jail Pad#" @ $totalNumJailCapPacks[%client]++;
	%shape = jailpad;
	%type = "StaticShape"; //"StaticShape"||"Turret"||"StaticShape"||"flier"
	%playerPos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = gamebase::getPosition(%flag);
	if(Vector::getDistance(%flagpos, %playerpos) < 10){
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return;
	}
	if (Object::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"]++;
		}
	}
}


//=============================================================================================================
//================================================================================== Builder Pole =============
//=============================================================================================================

ItemImageData BuilderPoleImage 
{ 
shapeFile = "discammo"; 
mountPoint = 2; 
mountOffset = { 0, 0, 0.125 };
mountRotation = { 90, 0, 0 }; 
mass = 2.5;
firstPerson = false;
}; 

ItemData BuilderPole 
{ 
description = "Builder Pole"; 
shapeFile = "discammo"; 
className = "Backpack"; 
heading = "lDeployable Objects"; 
imageType = BuilderPoleImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 420; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function BuilderPole::onUse(%player,%item)
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

function BuilderPole::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Builder Pole#" @ $totalNumBuilderPoles[%client]++;
	%shape = BuilderPoleShape;
	%type = "StaticShape"; //"StaticShape"||"Turret"||"StaticShape"||"flier"
	if (Object::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "BuilderPole"]++;
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



function Object::deployShape(%player,%name,%shape,%item,%type)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,$Nappy::ObjectDeployDistance)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape" || $Nappy::DeployOnAnything) {
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
						%object = newObject("",%type,%shape,true); 
						addToSet("MissionCleanup", %object); 
						GameBase::setTeam(%object,GameBase::getTeam(%player)); 
						GameBase::setPosition(%object,$los::position); 
						GameBase::setRotation(%object,%rot); 
						Gamebase::setMapName(%object,%name @ " " @ Nappy::getName(%client));
						Client::sendMessage(%client,0,%item.description @ " deployed"); 
						GameBase::startFadeIn(%object); 
						playSound(SoundPickupBackpack,$los::position); 
						playSound(ForceFieldOpen,$los::position);
						echo("MSG: ",%client," deployed a ",%item.description); 
						return true;
				}
				else if(%obj != "SimTerrain" && (%shape == "DeployableTree" || %shape == "DeployableTree2")){
					Client::sendMessage(%client,0,"Can only deploy " @ %shape.description @ " on terrain.");
				}
				else{
					if(Vector::dot($los::normal,"0 0 1") > 0.7){
						if(checkDeployArea(%client,$los::position)){
							if(%obj != "Player"){
								%rot = GameBase::getRotation(%player); 
								%object = newObject("",%type,%shape,true); 
								addToSet("MissionCleanup", %object); 
								GameBase::setTeam(%object,GameBase::getTeam(%player)); 
								GameBase::setPosition(%object,$los::position); 
								GameBase::setRotation(%object,%rot); 
								Gamebase::setMapName(%object,%name @ " " @ Nappy::getName(%client));
								Client::sendMessage(%client,0,%item.description @ " deployed"); 
								GameBase::startFadeIn(%object); 
								playSound(SoundPickupBackpack,$los::position); 
								playSound(ForceFieldOpen,$los::position);
								echo("MSG: ",%client," deployed a ",%item.description); 
								return true;
							}
							else
								Client::sendMessage(%client,0,"Can't be deployed on players.");
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


