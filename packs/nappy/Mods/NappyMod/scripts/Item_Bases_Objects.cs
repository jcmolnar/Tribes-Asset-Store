//%base = newObject("","InteriorShape","acommand.0.dis",false);

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Jail Cell                                           
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData jailpackImage
{
   shapeFile = "ammopack";
   mountPoint = 2;
   mountOffset = { 0, 0, 0 };
   mountRotation = { 0, 0, 0 };
   firstPerson = false;
};
ItemData jailpack
{
   description = "Jail Cell";
   shapeFile = "shieldpack";
   className = "Backpack";
   heading = "qDeployable Bases";
   imageType = jailpackImage;
   shadowDetailMask = 4;
   mass = 5.0;
   elasticity = 0.2;
   price = 9000;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function jailpack::onUse(%player,%item)
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

function jailpack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Jail#" @ $totalNumjailpacks[%client]++;
	//%shape = CameraTurret;
	if (jailpack::deployShape(%player,%name,%item)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "jailpack"]++;
		}
	}
}


function CreatejailportSimSet()
{
	%teleset = nameToID("MissionCleanup/jailports");
	if(%teleset == -1){
		newObject("jailports",SimSet);
		addToSet("MissionCleanup","jailports");
	}
}

function jailpack::deployshape(%player,%name,%item)
{
	GameBase::getLOSInfo(%player,$Nappy::BaseDeployDistance);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] >= $TeamItemMax[jailpack]){
		Client::sendMessage(%client,0,"Can Not Deploy Jail Cell Already In Place");
		return false;
	}
	%playerPos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = gamebase::getPosition(%flag);
	if(Vector::getDistance(%flagpos, %playerpos) < 15){
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return ;
	}
	%obj = getObjectType($los::object);
	%set = newObject("Jail",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
	%num = CountObjects(%set,"Jail",%num);
	   %objDevice =   newObject("Jail","Staticshape",LLargeForceField,true);
	   %objDevice.objSide1 = newObject("Jail","Staticshape",LLargeForceField,true);
	   %objDevice.objSide2 = newObject("Jail","Staticshape",LLargeForceField,true);
	   %objDevice.objSide3 = newObject("Jail","Staticshape",LLargeForceField,true);
	   %objDevice.objSide4 = newObject("Jail","Staticshape",LLargeForceField,true);
	   %objDevice.objSide5 = newObject("Jail","StaticShape",LLargeForceField,true);
	   %objDevice.objSide6 = newObject("Jail","StaticShape",LLargeForceField,true);
	   %objDevice.objSide7 = newObject("Jail","StaticShape",LLargeForceField,true);
	   %objDevice.objSide8 = newObject("Jail","StaticShape",JailSwitchOpen,true);
	   %objDevice.objSide9 = newObject("Jail","StaticShape",LLargeForceField,true);
	   %objDevice.objSide10 = newObject("Jail","StaticShape",JailSwitchClose,true);
		%objDevice.objSide1.objParent = %objDevice;
		%objDevice.objSide2.objParent = %objDevice;
		%objDevice.objSide3.objParent = %objDevice;
		%objDevice.objSide4.objParent = %objDevice;
		%objDevice.objSide5.objParent = %objDevice;
		%objDevice.objSide6.objParent = %objDevice;
		%objDevice.objSide7.objParent = %objDevice;
		%objDevice.objSide8.objParent = %objDevice;
		%objDevice.objSide9.objParent = %objDevice;
		%objDevice.objSide10.objParent = %objDevice;
		   addToSet(MissionCleanup, %objDevice);
		   addToSet(MissionCleanup, %objDevice.objSide1);
		   addToSet(MissionCleanup, %objDevice.objSide2);
		   addToSet(MissionCleanup, %objDevice.objSide3);
		   addToSet(MissionCleanup, %objDevice.objSide4);
		   addToSet(MissionCleanup, %objDevice.objSide5);
		   addToSet(MissionCleanup, %objDevice.objSide6);
		   addToSet(MissionCleanup, %objDevice.objSide7);
		   addToSet(MissionCleanup, %objDevice.objSide8);
		   addToSet(MissionCleanup, %objDevice.objSide9);
		   addToSet(MissionCleanup, %objDevice.objSide10);
	%pos = Vector::add(GameBase::getPosition(%player), "0 1 80");
		GameBase::setRotation(%objDevice.objSide1,"0 0 0");
		GameBase::setPosition(%objDevice.objSide1,%pos);
		GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "-5.5 6.5 80");
		GameBase::setRotation(%objDevice.objSide2,"0 0 4.71339");
		GameBase::setPosition(%objDevice.objSide2,%pos);
		GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "5.5 6.5 80");
		GameBase::setRotation(%objDevice.objSide3,"0 0 4.71339");
		GameBase::setPosition(%objDevice.objSide3,%pos);
		GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 86");
		GameBase::setRotation(%objDevice.objSide4,"-4.71339 0 0");
		GameBase::setPosition(%objDevice.objSide4,%pos);
		GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 86");
		GameBase::setRotation(%objDevice,"4.71339 0 0");
		GameBase::setPosition(%objDevice,%pos);
		GameBase::setTeam(%objDevice,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 80");
		GameBase::setRotation(%objDevice.objSide6,"-4.71339 0 0");
		GameBase::setPosition(%objDevice.objSide6,%pos);
		GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 80");
		GameBase::setRotation(%objDevice.objSide7,"4.71339 0 0");
		GameBase::setPosition(%objDevice.objSide7,%pos);
		GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "-5 13 80.00");
		GameBase::setRotation(%objDevice.objSide8,"0 0 0");
		GameBase::setPosition(%objDevice.objSide8,%pos);
		GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 18 80");
		GameBase::setRotation(%objDevice.objSide9,"-4.71339 0 0");
		GameBase::setPosition(%objDevice.objSide9,%pos);
		GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "5 13 80.00");
		GameBase::setRotation(%objDevice.objSide10,"0 0 0");
		GameBase::setPosition(%objDevice.objSide10,%pos);
		GameBase::setTeam(%objDevice.objSide10,GameBase::getTeam(%player));
	playSound(SoundPickupBackpack,$los::position);
	newObject("jaildoor",SimSet);
	addToSet("MissionCleanup","jaildoor");
	%sensor = newObject("jaildoor","StaticShape",jLargeForceField,true);
		addToSet("MissionCleanup/jaildoor", %sensor);
		addToSet("MissionCleanup", %sensor);
		GameBase::setTeam(%sensor,GameBase::getTeam(%player));
		%pos = Vector::add(GameBase::getPosition(%player), "0 12 80");
			GameBase::setPosition(%sensor,%pos);
			GameBase::setRotation(%sensor,"0 0 0");
			%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	%sensor = newObject("Teleport Pad","StaticShape","jailStand",true);
		CreatejailportSimSet();
		addToSet("MissionCleanup/jailports", %sensor);
		addToSet("MissionCleanup", %sensor);
		GameBase::setTeam(%sensor,GameBase::getTeam(%player));
		%pos = Vector::add(GameBase::getPosition(%player), "0 3 81");
			GameBase::setPosition(%sensor,%pos);
			Gamebase::setMapName(%sensor,%name);
			%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	%beam = newObject("","StaticShape",ElectricalBeamBig,true);
		addToSet("MissionCleanup", %beam);
		GameBase::setTeam(%beam,GameBase::getTeam(%player));
		GameBase::setPosition(%beam,%pos);
		%sensor.beam1 = %beam;
	playSound(SoundPickupBackpack,$los::position);
	newObject("releasepad",SimSet);
	CreatereleasepadSimSet();
	addToSet("MissionCleanup/releasepad", %sensor);
	addToSet("MissionCleanup", %sensor);
	%sensor = newObject("releasepad","StaticShape","jailStandTop",true);
		addToSet("MissionCleanup/releasepad", %sensor);
		addToSet("MissionCleanup", %sensor);
		GameBase::setTeam(%sensor,GameBase::getTeam(%player));
		%pos = Vector::add(GameBase::getPosition(%player), "0 3 86.30");
			GameBase::setPosition(%sensor,%pos);
			Gamebase::setMapName(%sensor,%name);
			%sensor.disabled = false;
	//$TeamItemCount[GameBase::getTeam(%sensor) @ "jailpack"]++;
	echo("MSG: ",%client," deployed a Jail Cell");
	Client::sendMessage(%client,0,%item.description @ " deployed 250' Up");
	return true;
}


function CreatereleasepadSimSet()
{
	%teleset = nameToID("MissionCleanup/releasepad");
	if(%teleset == -1){
		newObject("releasepad",SimSet);
		addToSet("MissionCleanup","releasepad");
		//addToSet("MissionCleanup/releasepad","releasepad");
	}
}










//=============================================================================================================
//=================================================================================== Remote Base =============
//=============================================================================================================

ItemImageData RemoteBaseImage 
{ 
   shapeFile = "discammo"; 
   mountPoint = 2; 
   mountOffset = { 0, 0, 0.125 };
   mountRotation = { 90, 0, 0 }; 
   mass = 2.5;
   firstPerson = false;
}; 

ItemData RemoteBase 
{ 
   description = "Remote Base"; 
   shapeFile = "discammo"; 
   className = "Backpack"; 
   heading = "qDeployable Bases"; 
   imageType = RemoteBaseImage; 
   shadowDetailMask = 4; 
   mass = 2.5; 
   elasticity = 0.2; 
   price = 420; 
   hudIcon = "deployable"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function RemoteBase::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		%client = Player::getClient(%player);
		%teamposa = ($teamFlag[0]).originalPosition;
		%teamposb = ($teamFlag[1]).originalPosition;
		%deplteam = GameBase::getTeam(%player);
		%deplpos = GameBase::getPosition(%player);
		if (Vector::getDistance(%deplpos, %teamposa) < 300 || Vector::getDistance(%deplpos, %teamposb) < 300 ){
			Client::sendMessage(%client,0,"You are too close to the base!");
			Player::mountItem(%player,%item,$BackpackSlot);
			return;
		} 
		else 
			Player::deployItem(%player,%item);
	}
}

function RemoteBase::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Remote Base#" @ $totalNumRemoteBases[%client]++;
	//%shape = CameraTurret;
	if (RemoteBase::deployShape(%player,%name,%item)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "RemoteBase"]++;
		}
	}
}


function RemoteBase::deployShape(%player,%name,%item) 
{ 
	%client = Player::getClient(%player);
	%playpos = GameBase::getPosition(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,$Nappy::BaseDeployDistance)) { 
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "Large Platform") { 
				if(Vector::GetDistance(%playpos,$los::position) > 9 ) {
					%base = newObject("Remotebase",InteriorShape,"bunker4.dis",false);
					%base.basebackwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
					%base.baseleftwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
					%base.baserightwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
					%base.baseturret = newObject("Remotebase","Turret",DeployableRocket,false);
					%base.basestation = newObject("Remotebase","StaticShape",basestation,false);
					%base.basedoor = newObject("Remotebase","Staticshape",bdForceField,true);
					   %base.basedoor.objParent = %base;
					   %base.basebackwall.objParent = %base;
					   %base.baseleftwall.objParent = %base;
					   %base.baserightwall.objParent = %base;
					   %base.baseturret.objParent = %base;
					   %base.basestation.objParent = %base;
						addToSet("MissionCleanup", %base);
						addToSet("MissionCleanup", %base.basebackwall);
						addToSet("MissionCleanup", %base.baseleftwall);
						addToSet("MissionCleanup", %base.baserightwall);
						addToSet("MissionCleanup", %base.baseturret);
						addToSet("MissionCleanup", %base.basedoor);
						addToSet("MissionCleanup", %base.basestation);
					GameBase::setTeam(%base,GameBase::getTeam(%player));
					GameBase::setPosition(%base,$los::position);
					GameBase::setRotation(%base,"0 0 0");
				%pos = Vector::add($los::position, "0 5.875 0");
					GameBase::setRotation(%base.basebackwall,"0 0 0");
					GameBase::setPosition(%base.basebackwall,%pos);
					GameBase::setTeam(%base.basebackwall,GameBase::getTeam(%player));
				%pos = Vector::add($los::position, "0 -5.875 0");
					GameBase::setRotation(%base.basedoor,"0 0 0");
					GameBase::setPosition(%base.basedoor,%pos);
					GameBase::setTeam(%base.basedoor,GameBase::getTeam(%player));
				%pos = Vector::add($los::position, "-5.875 0 0");
					GameBase::setRotation(%base.baseleftwall,"0 0 4.7125");
					GameBase::setPosition(%base.baseleftwall,%pos);
					GameBase::setTeam(%base.baseleftwall,GameBase::getTeam(%player));
				%pos = Vector::add($los::position, "5.875 0 0");
					GameBase::setRotation(%base.baserightwall,"0 0 4.7125");
					GameBase::setPosition(%base.baserightwall,%pos);
					GameBase::setTeam(%base.baserightwall,GameBase::getTeam(%player));
				%pos = Vector::add($los::position, "0 0 9.77");
					GameBase::setRotation(%base.baseturret,"0 0 0");
					GameBase::setPosition(%base.baseturret,%pos);
					GameBase::setTeam(%base.baseturret,GameBase::getTeam(%player));
				%pos = Vector::add($los::position, "0 3 1");
					GameBase::setRotation(%base.basestation,"0 0 0");
					GameBase::setPosition(%base.basestation,%pos);
					GameBase::setTeam(%base.basestation,GameBase::getTeam(%player));
				//$TeamItemCount[GameBase::getTeam(%sensor) @ "RemoteBase"]++;
				Gamebase::setMapName(%base,"Remote Base " @ Nappy::getName(%client));
				Client::setOwnedObject(%client, %base);
				Client::setOwnedObject(%client, %player);
				Client::sendMessage(%client,0,"Remote base deployed"); 
				playSound(SoundPickupBackpack,$los::position); 
				echo("MSG: ",%client," deployed a Remote Base"); 
				return true; 
				}
				else 
					Client::sendMessage(%client,0,"You are too close to the deploy position."); 
			} 
			else 
				Client::sendMessage(%client,0,"Can only be deployed on terrain."); 
		} 
		else 
			Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 

//========================================================================================================
//============================================================================== Sniper Hut ==============
//========================================================================================================

ItemImageData SniperHutImage 
{ 
   shapeFile = "discammo"; 
   mountPoint = 2; 
   mountOffset = { 0, 0, 0.125 };
   mountRotation = { 90, 0, 0 }; 
   mass = 2.5;
   firstPerson = false;
};

ItemData SniperHut
{
   description = "Sniper Hut"; 
   shapeFile = "discammo"; 
   className = "Backpack"; 
   heading = "qDeployable Bases";
   imageType = SniperHutImage;
   shadowDetailMask = 4; 
   mass = 2.5;
   elasticity = 0.1;
   price = 420;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function SniperHut::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		%client = Player::getClient(%player);
		%teamposa = ($teamFlag[0]).originalPosition;
		%teamposb = ($teamFlag[1]).originalPosition;
		%deplteam = GameBase::getTeam(%player);
		%deplpos = GameBase::getPosition(%player);
		if (Vector::getDistance(%deplpos, %teamposa) < 300 || Vector::getDistance(%deplpos, %teamposb) < 300 ){
			Client::sendMessage(%client,0,"You are too close to the base!");
			Player::mountItem(%player,%item,$BackpackSlot);
			return;
		} 
		else 
			Player::deployItem(%player,%item);
	}
}

function SniperHut::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Sniper Hut#" @ $totalNumSniperHuts[%client]++;
	//%shape = CameraTurret;
	if (SniperHut::deployShape(%player,%name,%item)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "SniperHut"]++;
		}
	}
}




function SniperHut::deployShape(%player,%name,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,$Nappy::BaseDeployDistance)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					%prot = GameBase::getRotation(%player); 
					%zRot = getWord(%prot,2);
					%xRot = %zRot + 9.44;
					%rot = "0 0 " @ %xRot;
					%pos = Vector::add($los::position, "0 0 0.5"); 
					%hut = newObject("","InteriorShape","eround.dis",false);
					addToSet("MissionCleanup", %hut);
					GameBase::setTeam(%hut,GameBase::getTeam(%player));
					GameBase::setPosition(%hut,%pos);
					GameBase::setRotation(%hut,%rot);
					Gamebase::setMapName(%hut,"Sniper Hut" @ Nappy::getName(%client));
					Client::sendMessage(%client,0,"Sniper Hut deployed");
					playSound(SoundPickupBackpack,$los::position);
					//$TeamItemCount[GameBase::getTeam(%player) @ "SniperHut"]++;
					echo("MSG: ",%client," deployed a sniper hut");
					return true;
				}	
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
return false;
}











