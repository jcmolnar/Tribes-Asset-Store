
//==========================================================================================
//                                 JAIL CELL:
//==========================================================================================

// Jail's ForceFields
StaticShapeData Jail::FFWallShape
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 650;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Jail Cell";
};
function Jail::FFWallShape::onDestroyed(%this)
{ StaticShape::onDestroyed(%this); }

// Jail's BlastWalls
StaticShapeData Jail::BlastWallShape
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisLarge;
	maxDamage = 650;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Jail Cell";
};
function Jail::BlastWallShape::onDestroyed(%this)
{ StaticShape::onDestroyed(%this); }

// Generic Switch
StaticShapeData JailSwitch::Open
{
	description = "The Jail";
	className = "towerSwitch";
	shapeFile = "tower";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	maxDamage = 20000;
};
function JailSwitch::Open::onCollision(%this,%obj){}

// Generic Switch
StaticShapeData JailSwitch::Close
{
	description = " The Jail";
	className = "towerSwitch";
	shapeFile = "tower";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	maxDamage = 20000;
};
function JailSwitch::Close::onCollision(%this,%obj){}

// Jail's Door
StaticShapeData Jail::JailDoorShape {
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "ForceField";
	maxDamage = 1000;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId=flashDebrisLarge;
	lightRadius=12.0;
	lightType=2;
	lightColor={1.0,0.2,0.2};
	side="single";
	isTranslucent=true;
	description="Jail Cell Door";
};

function Jail::JailDoorShape::Destruct(%this)
{ Jail::JailDoorShape::doDamage(%this); }

function Jail::JailDoorShape::doDamage(%this)
{ calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); }

function Jail::JailDoorShape::CloserUp(%this)
{ %pos=GameBase::getPosition(%this); %pos=Vector::add(%pos,"0 0 -6"); GameBase::setPosition(%this,%pos); Echo("Re-Setting Position"); }

function Jail::JailDoorShape::onDestroyed(%this)
{ Jail::JailDoorShape::doDamage(%this); }

function Jail::JailDoorShape::onCollision(%this,%obj){
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) return;
	if(%fieldTeam != %playerTeam) return;
	Jail::JailDoorShape::openDoor(%this);
}
function Jail::JailDoorShape::openDoor(%this){	
	GameBase::startfadeout(%this);
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 6");
	GameBase::setPosition(%this, %pos);
	schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.15);
	schedule("Jail::JailDoorShape::closeDoor("@ %this @");", 2.5);
}
function Jail::JailDoorShape::closeDoor(%this){	
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this, %pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@ %this @", ForceFieldClose, 0);",0.15);
}
function Jail::JailDoorShape::Sesame(%obj){
	%client = GameBase::getControlClient(%obj);
	%teleset = nameToID("MissionCleanup/releasepad");
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){
		%oteam=GameBase::getTeam(%o);
		if(%oteam != GameBase::getTeam(%obj) && Vector::getDistance(GameBase::GetPosition(%obj),GameBase::GetPosition(%o)) <= 10){
			GameBase::SetPosition(%obj, GameBase::GetPosition(%o));
		}
	}
}

// Jail's Bottom Tele Pad
StaticShapeData jailStand {
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 20000.0;
	description = "POW Release Pad";
};

// This Destroys All Jail Sides When This Is Called.
function jailStand::onDestroyed(%this){
	Schedule("deleteObject("@ $JailSide1 @");", 0, $JailSide1);
	Schedule("deleteObject("@ $JailSide2 @");", 0, $JailSide2);
	Schedule("deleteObject("@ $JailSide3 @");", 0, $JailSide3);
	Schedule("deleteObject("@ $JailSide4 @");", 0, $JailSide4);
	Schedule("deleteObject("@ $JailSide5 @");", 0, $JailSide5);
	Schedule("deleteObject("@ $JailSide6 @");", 0, $JailSide6);
	Schedule("deleteObject("@ $JailSide7 @");", 0, $JailSide7);
	Schedule("deleteObject("@ $JailSide8 @");", 0, $JailSide8);
	Schedule("deleteObject("@ $JailSide9 @");", 0, $JailSide9);
	Schedule("deleteObject("@ $JailSide10 @");", 0, $JailSide10);
	Schedule("deleteObject("@ $JailSide11 @");", 0, $JailSide11);
	Schedule("deleteObject("@ $JailSide12 @");", 0, $JailSide12);
	Schedule("deleteObject("@ $JailSide13 @");", 0, $JailSide13);
	Schedule("deleteObject("@ $JailSide14 @");", 0, $JailSide14);
	$JailSide1 = "";
	$JailSide2 = "";
	$JailSide3 = "";
	$JailSide4 = "";
	$JailSide5 = "";
	$JailSide6 = "";
	$JailSide7 = "";
	$JailSide8 = "";
	$JailSide9 = "";
	$JailSide10 = "";
	$JailSide11 = "";
	$JailSide12 = "";
	$JailSide13 = "";
	$JailSide14 = "";
}

// Recoded by me when i was a lil bored.
function jailStand::onCollision(%this, %obj){
	%clientId = Player::getClient(%obj);
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj) || %clientId.needsToMove == true) return;
	Client::SendMessage(%clientId, 0, "No Escape This Way, There Might Be A Way Out Though...;)");
	CenterPrint(%client, "<jc><f1>No Escape This Way, There Might Be A Way Out Though...;)", 5);
	%clientId.needsToMove = true;
	Schedule(%clientId @".needsToMove = false;", 25);
}

StaticShapeData jailStandTop{ shapeFile = "flagstand"; debrisId = defaultDebrisSmall; maxDamage = 20000.0; description = "POW Release Pad"; };

function jailStandTop::onDestroyed(%this){ StaticShape::onDestroyed(%this); }

// Completely recoded by me to fix a few problems and do some fun shizzle too.. -Dustin "X-Ecutioner" Bruce.
function jailStandTop::onCollision(%this, %obj){
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj)){ return; }
	%clientId = Player::getClient(%obj);
	%Player = %obj;
	%obj.Rot = GameBase::getRotation(%Player);
	%clientName = Client::getName(%clientId);
	if($AdminGettinPissed[%clientId] != 0)
	Schedule("$AdminGettinPissed["@ %clientId @"]--;", 1);
	if($AdminGettinPissed[%clientId] == 10){
		Client::sendMessage(%clientId, 1, "OK MAN, Now Im Gettin Pissed Get Off The Release Pad Now!~wmale1.wwatchsh.wav");
		CenterPrint(%clientId, "<jl><BSkull_Big.BMP><jc><f1>Dude, Get The Fuck Off The ReleasePad!", 5);
		%jumpDir = Vector::getFromRot(%obj.Rot, -1000, 4);
		Player::applyImpulse(%Player, %jumpDir);
		return;
	}
	else if($AdminGettinPissed[%clientId] == 5 && $AdminGettinPissed[%clientId] != 10){
		Client::sendMessage(%clientId, 1, "Dude, Get The Fuck Off The ReleasePad!~wmale1.wwatchsh.wav");
		CenterPrint(%clientId, "<jc><f1>Dude, Get The Fuck Off The ReleasePad!", 5);
		%jumpDir = Vector::getFromRot(%obj.Rot, -100, 4);
		Player::applyImpulse(%Player, %jumpDir);
		return;
	}
	if(%clientId.isSlow){ $AdminGettinPissed[%clientId]++; return; }
	$AdminGettinPissed[%clientId] = 0;
	%clientId.isSlow = 1;
	Schedule(%clientId @".isSlow = 0;", 20);
	if(%clientId.isParoled) return;
	MessageAll(0, %clientName @" Has been paroled.");
	Client::sendMessage(%clientId, 0, "You Have Been Released! Run! Forrest! Run!~wwforrest.wav");
	%clientId.isParoled = true;
	Schedule(%clientId @".isParoled = false;", 20);
}

//--------------------------------------------------------------------------------
// I really don't think this is needed but i keep this type of shit around, just incase...
// Heres the Bottom one
StaticShapeData jailStandBottom
{ shapeFile = "flagstand"; debrisId = defaultDebrisSmall; maxDamage = 650; description = "POW Release Pad"; };

function jailStandBottom::onDestroyed(%this)
{ Jail::Destroy(%this, $Jail::DClient[%this]); }

function jailStandBottom::onCollision(%this, %obj)
{
//	Not sure on who did this, but you can't send a message to a player(%obj), you have to send it to the client.
//	Client::SendMessage(%obj, 0, "You Have Been Released. Run Forrest Run!!!!");
	Client::sendMessage(Player::getClient(%obj), 0, "You Have Been Released, Run Damnit Run!!!~wwforrest.wav");
}
//--------------------------------------------------------------------------------


// Jail Pad Static Shape:
$jailPad::jailTime = 30;

StaticShapeData JailingPad
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	maxDamage = 2.5;
	debrisId = flashDebrisSmall;
};

function JailingPad::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
	{ return; }
    
    if(%this.disabled)
	{
		Client::sendMessage(Player::getClient(%obj), 3, "Jail Pad Is Recharging...~wSensor_Deploy.wav");
		Schedule("jailpad::Reenable("@ %this @");", 5);
		return;
	}
    
    %c = Player::getClient(%obj);
    %cName = Client::getName(%c);
    %playerTeam = GameBase::getTeam(%obj);
    %teleTeam = GameBase::getTeam(%this);
    
    if(%teleTeam == %playerTeam)
    {
	    Client::SendMessage(%c,0,"You Stepped On Your Teams Jail Capture Pad");
	    return;
	}

    %teleset = nameToID("MissionCleanup/jailports");
    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
	    %oteam = GameBase::getTeam(%o);
	    
	    if(%oteam != %playerTeam)
	    {
		    GameBase::playSound(%o, ForceFieldOpen, 0);
		    GameBase::playSound(%this, ForceFieldOpen, 0);
		    GameBase::SetPosition(%obj, GameBase::GetPosition(%o));
		    schedule("Jail::JailDoorShape::Sesame("@ %obj @");", $jailPad::jailTime);
		    %c.nosuicide = 1;
		    %c.jailed = 1;
		    Schedule(%c @".jailed = 0;", $jailPad::jailTime);
		    Schedule(%c @".nosuicide = 0;", $jailPad::jailTime);
		    Client::SendMessage(%c, 0, "Welcome To Jail, "@ %cName);
		    CenterPrint(%c, "<jc><f1>Welcome to jail, "@ %cName @"\n You got <f2>"@ $jailPad::jailTime @" <f1>seconds till your gettin out...Get Comfy");
		}
	}
	Echo("jailpad::onCollision: "@ %cName @" Just Got Jailed By ");
	messageall(0, %cName @" Is now a prison bitch");
}

function jailpad::Reenable(%this)
{ %this.disabled = false; }
//======================================================================================================================
//                        End Static Shapes For Jail Shizzle, Begin Item Data.


//====BEGIN JAIL CELL====| - An original idea from the Tricon Team.

ItemImageData JailPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.5;
};

ItemData JailPack
{
	description = "Jail Cell";
	shapeFile = "forcefield";
	className = "Backpack";
	heading = $InvHeading[JailingItems];
	imageType = JailPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 6000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JailPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function JailPack::onDeploy(%player,%item,%pos)
{ if(JailPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function CreatejailportSimSet()
{ %teleset = nameToID("MissionCleanup/jailports"); if(%teleset == -1){ newObject("jailports",SimSet); addToSet("MissionCleanup","jailports"); } }

function CreatereleasepadSimSet()
{ %teleset = nameToID("MissionCleanup/releasepad"); if(%teleset == -1){ newObject("releasepad",SimSet); addToSet("MissionCleanup","releasepad"); } }

function JailPack::deployshape(%player,%item){
	if(%player.outArea == 1){
		Client::sendMessage(%client, 0, "That's Right, no more deploying outside of the mission area.~waccess_denied.wav");
		return false;
	}
	
	GameBase::getLOSInfo(%player, 3);
	%playerPos = GameBase::getPosition(%player);
	%datab  = GameBase::getDataName(%item);
	%client = Player::getClient(%player);
	%pTeam  = GameBase::getTeam(%player);
	
	if(%client.outofarea)
	{ Client::sendMessage(%client, 0, "You Have To Be In The Mission Boundries.~wAccess_Denied.Wav"); return false; }
	if($TeamItemCount[GameBase::getTeam(%player) @ "JailPackage"] >= $TeamItemMax[JailPackage])
	{ Client::sendMessage(%client, 1, "Cannot Deploy. Jail Cell Already In Place"); return false; }
	
	%obj = getObjectType($los::object);
	%set = newObject("Jail", SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 350, 350, 350,0);
	
	// New Fair Play Distance.
	for(%i; %i < %num; %i++){
		%item = Group::getObject(%set, %i);
		if(GameBase::getTeam(%item) == GameBase::getTeam(%player))
		{ %friendlyData = true; }
		else if(GameBase::getTeam(%item) != GameBase::getTeam(%player))
		{ %enemyData = true; }
	}
	deleteObject(%set);
	
	if(%enemyData == true && %friendlyData != true){
		Client::sendMessage(%client, 0, "Fair Play Distance Exceeded For Jail Cells.");
		return false;
	}
	else if(%enemyData != true && %friendlyData != true){
		Client::sendMessage(%client, 0, "Maximum Deployable Distance Exceded.~wAccess_Denied.Wav");
		return false;
	}
	
	CreatejailportSimSet();
	%object1 = newObject("Teleport Pad", "StaticShape", "jailStand", true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 81");
	addToSet("MissionCleanup/jailports", %object1);
	addToSet("MissionCleanup", %object1);
	GameBase::setTeam(%object1, GameBase::getTeam(%player));
	GameBase::setPosition(%object1, %pos);
	Gamebase::setMapName(%object1, "Jail Cell");
	$JailSide1 = %object1;
	
	%object2 = newObject("Jail", "Staticshape", Jail::FFWallShape, true);
	addToSet(MissionCleanup, %object2);
	%pos = Vector::add(GameBase::getPosition(%player), "0 1 80");
	GameBase::setRotation(%object2, "0 0 0");
	GameBase::setPosition(%object2, %pos);
	GameBase::setTeam(%object2, %pTeam);
	$JailSide2 = %object2;
	
	%object3 = newObject("Jail", "Staticshape", Jail::FFWallShape, true);
	addToSet(MissionCleanup, %object3);
	%pos = Vector::add(GameBase::getPosition(%player), "-5.1 6.5 80");
	GameBase::setRotation(%object3, "-0.15 0 4.71339");
	GameBase::setPosition(%object3, %pos);
	GameBase::setTeam(%object3, %pTeam);
	$JailSide3 = %object3;
	
	%object4 = newObject("Jail", "Staticshape", Jail::FFWallShape, true);
	addToSet(MissionCleanup, %object4);
	%pos = Vector::add(GameBase::getPosition(%player), "5.1 6.5 80");
	GameBase::setRotation(%object4, "0.15 0 4.71339");
	GameBase::setPosition(%object4, %pos);
	GameBase::setTeam(%object4, %pTeam);
	$JailSide4 = %object4;
	
	%object5 = newObject("Jail", "Staticshape", Jail::BlastWallShape, true);
	addToSet(MissionCleanup, %object5);
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 86");
	GameBase::setRotation(%object5, "-4.71339 0 0");
	GameBase::setPosition(%object5, %pos);
	GameBase::setTeam(%object5, %pTeam);
	$JailSide5 = %object5;
	
	%object6 = newObject("Jail", "StaticShape", Jail::BlastWallShape, true);
	addToSet(MissionCleanup, %object6);
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 80");
	GameBase::setRotation(%object6, "-4.71339 0 0");
	GameBase::setPosition(%object6, %pos);
	GameBase::setTeam(%object6, %pTeam);
	$JailSide6 = %object6;
	
	%object7 = newObject("Jail", "StaticShape", Jail::BlastWallShape, true);
	addToSet(MissionCleanup, %object7);
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 80");
	GameBase::setRotation(%object7, "4.71339 0 0");
	GameBase::setPosition(%object7, %pos);
	GameBase::setTeam(%object7, %pTeam);
	$JailSide7 = %object7;
	
	%object8 = newObject("Jail", "StaticShape", JailSwitch::Open, true);
	addToSet(MissionCleanup, %object8);
	%pos = Vector::add(GameBase::getPosition(%player), "-4.2 11.9 86.00");
	GameBase::setRotation(%object8, "0 0 0");
	GameBase::setPosition(%object8, %pos);
	GameBase::setTeam(%object8, %pTeam);
	$JailSide8 = %object8;
	
	%object9 = newObject("Jail", "StaticShape", Jail::BlastWallShape, true);
	addToSet(MissionCleanup, %object9);
	%pos = Vector::add(GameBase::getPosition(%player), "0 18 80");
	GameBase::setRotation(%object9, "-4.71339 0 0");
	GameBase::setPosition(%object9, %pos);
	GameBase::setTeam(%object9, %pTeam);
	$JailSide9 = %object9;
	
	%object10 = newObject("Jail", "StaticShape", JailSwitch::Close, true);
	addToSet(MissionCleanup, %object10);
	%pos = Vector::add(GameBase::getPosition(%player), "4.2 11.9 86.00");
	GameBase::setRotation(%object10, "0 0 0");
	GameBase::setPosition(%object10, %pos);
	GameBase::setTeam(%object10, %pTeam);
	$JailSide10 = %object10;
	
	%object11 = newObject("jaildoor", "StaticShape", Jail::JailDoorShape, true);
	addToSet(MissionCleanup, %object11);
	%pos = Vector::add(GameBase::getPosition(%player), "0 12 80");
	GameBase::setRotation(%object11, "0 0 0");
	GameBase::setPosition(%object11, %pos);
	GameBase::setTeam(%object11, %pTeam);
	Gamebase::setMapName(%object11, "Jail Door");
	$JailSide11 = %object11;
	
	%object12 = newObject("Jail", "Staticshape", Jail::BlastWallShape, true);
	addToSet(MissionCleanup, %object12);
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 86");
	GameBase::setRotation(%object12, "4.71339 0 0");
	GameBase::setPosition(%object12, %pos);
	GameBase::setTeam(%object12, %pTeam);
	$JailSide12 = %object12;
	
	%object13 = newObject("", "StaticShape", ElectricalBeamBig, true);
	CreatereleasepadSimSet();
	addToSet("MissionCleanup", %object13);
	GameBase::setTeam(%object13, GameBase::getTeam(%player));
	GameBase::setPosition(%object13, %pos);
	$JailSide13 = %object13;
	
	%object14 = newObject("releasepad", "StaticShape", "jailStandTop", true);
	addToSet("MissionCleanup/releasepad", %object14);
	GameBase::setTeam(%object14, GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 86.30");
	GameBase::setPosition(%object14, %pos);
	Gamebase::setMapName(%object14, "Jail Cell");
	$JailSide14 = %object14;

	
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[GameBase::getTeam(%object1) @"JailPackage"]++;
	Echo("MSG: "@ Client::getName(%client) @"("@ %client @") deployed a Jail Cell");
	Client::sendMessage(%client, 0, %item.description @" deployed~wseek_fire.wav");
	BottomPrint(%client, "<jc><f1>250m <f0>Above Your Head<f1>!");
	return true;
}
//====END JAIL CELL====|


//====BEGIN JAIL CAPTURE PAD====| - Im Guessing This Is From The Tricon Team.

ItemImageData JailCapPackImage
{
	shapeFile = "flagstand";
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData JailCapPack
{
	description = "Jail Capture Pad";
	shapeFile   = "flagstand";
	className   = "Backpack";
	heading     = $InvHeading[JailingItems];
	imageType   = JailCapPackImage;
	shadowDetailMask = 4;
	mass        = 1.0;
	elasticity  = 0.2;
	price       = 500;
	hudIcon     = "deployable";
	showWeaponBar  = true;
	hiliteOnActive = true;
};

function JailCapPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function JailCapPack::onDeploy(%player,%item,%pos)
{ if(JailCapPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function JailCapPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	
	// Check distance
	if (!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client, 0, "Try it Closer Bud..."); return false; }
	
	%obj     = getObjectType($los::object);
	%playerPos = GameBase::getPosition(%player);
	%flag    = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = gamebase::getPosition(%flag);
	
	// Check for flag dist.
	if(Vector::getDistance(%flagpos, %playerpos) < 10)
	{ Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy."); return false; }
	
	// Check Item Count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client, 1, "The "@ %item.description @"'s Maximum Limit of "@ $TeamItemMax[%item] @" has been reached"); return false; }
	
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	%rot =  "1.57079 0 "@ %zRot;
	%padd = "0 0 0";
	%pos = Vector::add($los::position, %padd);
	
	%camera = newObject("", "StaticShape", "JailingPad", true);
	addToSet("MissionCleanup", %camera);
	GameBase::setTeam(%camera, GameBase::getTeam(%player));
	GameBase::setRotation(%camera, "0 0 0");
	GameBase::setPosition(%camera, %pos);
	Gamebase::setMapName(%camera,"JailPad "@ $totalNumCameras++ @" "@ Client::getName(%client));
	Client::sendMessage(%client, 0, %item.description @" Deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"]++;
	Echo("MSG: "@ Client::getName(%client) @"("@ %client @") deployed a Jail Pad");
	return true;
}
//====END JAIL CAPTURE PAD====|