StaticShapeData TGBlastDoorShape {
	className = "AAODDep";
	shapeFile = "NewDoor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Mobile Bunker Wall";
	shieldShapeName = "shield";
};
function TGBlastDoorShape::onDestroyed(%this){}

function TGBlastDoorShape::onCollision(%this,%obj){
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj)){ return; }
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){ return; }
	%c = Player::getClient(%obj);
	if(%this.isSliding != true){
		%this.origPos = GameBase::getPosition(%this); 
		%this.SlideUpCount = 0; 
		TG::SlideDoor::Up(%this);
	}
}

function TG::SlideDoor::Up(%this){
//	Echo("TG SLIDE DOOR UP");
//	Echo("Slide Up Count = "@ %this.SlideUpCount);
	%this.isSliding = true;
	if(%this.SlideUpCount == 6){  
		%this.SlideUpCount = 0; 
		%this.SlideDownCount = 0; 
		Schedule("TG::SlideDoor::Down("@ %this @");", 1.0);
		return; 
	}
	%pos = GameBase::getPosition(%this);
	%nPos = Vector::add(%pos, "0 0 1");
	GameBase::setPosition(%this, %nPos);
	%this.SlideUpCount++;
	if(%this.SlideUpCount == 1){ playSound(SoundDoorOpen, %pos); }
	Schedule("TG::SlideDoor::Up("@ %this @");", 0.15);
}

function TG::SlideDoor::Down(%this){
//	ECHO("TG SLIDE DOOR DOWN");
//	Echo("Slide Down Count = "@ %this.SlideDownCount);
	%this.isSliding = true;
	if(%this.SlideDownCount == 6){
		%this.SlideDownCount = 0;
		%this.isSliding = false;
		GameBase::setPosition(%this, %this.origPos);
		return; 
	}
	%pos = GameBase::getPosition(%this);
	%nPos = Vector::add(%pos, "0 0 -1");
	GameBase::setPosition(%this, %nPos);
	%this.SlideDownCount++;
	if(%this.SlideDownCount == 1){ playSound(SoundDoorOpen, %pos); }
	Schedule("TG::SlideDoor::Down("@ %this @");", 0.15);
}

ItemImageData TGBlastDoorPackImage {	
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
ItemData TGBlastDoorPack {	
	description = "[TG] WALL";
	shapeFile   = "AmmoPack";
	className   = "Backpack";
	imageType   = TGBlastDoorPackImage;
	shadowDetailMask = 4;
	mass        = 2.5;
	elasticity  = 0.2;
	price       = 500;
	hudIcon     = "deployable";
	showWeaponBar  = true;
	hiliteOnActive = true;
};

function TGBlastDoorPack::onUse(%player,%item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item){ Player::mountItem(%player, %item, $BackpackSlot); }
	else{ Player::deployItem(%player, %item); }
}
function TGBlastDoorPack::onDeploy(%player,%item,%pos){
	if(TGBlastDoorPack::deployShape(%player, %item)){ Player::decItemCount(%player,%item); }
}
function TGBlastDoorPack::deployShape(%player,%item){	
	%client = Player::getClient(%player);
	%pTeam = GameBase::getTeam(%player);
	if($TeamItemCount[%pTeam @ %item] >= $TeamItemMax[%item]){ Client::sendMessage(%client, 0, "Deployable Item limit reached for "@ %item.description @"s"); return false; }
	if(!GameBase::getLOSInfo(%player,3)){ Client::sendMessage(%client, 0, "Deploy Closer.~wAccess_Denied.wav"); return false; }
	%rot = GameBase::getRotation(%player);
	%obj = newObject("TGBlastDoorPack", "StaticShape", TGBlastDoorShape, false);
	%obj.cloakable = true;
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj, GameBase::getTeam(%player));
	GameBase::setRotation(%obj, %rot);
	GameBase::setPosition(%obj, $los::position);
	Gamebase::setMapName(%obj, "~Blast Wall~");
	Client::sendMessage(%client, 0, "[TG]'s Blast Wall Deployed");
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[GameBase::getTeam(%obj) @"ForceFieldDoorPack"]++;
	echo("MSG: "@ %client @" deployed a TG Blast Wall");
	return true;
}