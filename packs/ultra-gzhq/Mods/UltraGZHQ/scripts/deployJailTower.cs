$InvList[JailTower] = 1;
$MobileInvList[JailTower] = 1;
$RemoteInvList[JailTower] = 0;
AddItem(JailTower);

function deployJailTower::Initialize()
{	
	$TeamItemCount[0 @ JailTower] = 0;
	$TeamItemCount[1 @ JailTower] = 0;
	$TeamItemCount[2 @ JailTower] = 0;
	$TeamItemCount[3 @ JailTower] = 0;
	$TeamItemCount[4 @ JailTower] = 0;
	$TeamItemCount[5 @ JailTower] = 0;
	$TeamItemCount[6 @ JailTower] = 0;
	$TeamItemCount[7 @ JailTower] = 0;
}

ItemImageData JailTowerImage
{	
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData JailTower
{	
	description = "Jail Tower";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = $InvHead[ihDob];
	imageType = JailTowerImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 9000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData JailWall
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
//	description = "Jail Tower";
};

StaticShapeData JailStand
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 50000;
	description = "Jail Stand";
};

StaticShapeData JailReleasePad
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 50000;
	description = "Jail Release Pad";
};

StaticShapeData JailReleaseSwitch
{
	className = "towerSwitch";
	shapeFile = "tower";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	maxDamage = 50000;
	description = "Jail Release Switch";
};

function JailTower::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function JailTower::onDeploy(%player,%item,%pos)
{	if(JailTower::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CreateJailSimSet(%team)
{
	%teleset = nameToID("MissionCleanup/JailTower" @ %team);
	if(%teleset == -1)
	{	newObject("JailTower" @ %team,SimSet);
		addToSet("MissionCleanup","JailTower" @ %team);
	}
	%teleset = nameToID("MissionCleanup/JailRelease" @ %team);
	if(%teleset == -1)
	{
		newObject("JailRelease" @ %team,SimSet);
		addToSet("MissionCleanup","JailRelease" @ %team);
	}
	%teleset = nameToID("MissionCleanup/JailWalls" @ %team);
	if(%teleset == -1)
	{
		newObject("JailWalls" @ %team,SimSet);
		addToSet("MissionCleanup","JailWalls" @ %team);
	}
}





function JailTower::deployshape(%player,%item)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	%playerPos = GameBase::getPosition(%player);
	%prot =GameBase::getRotation(%player);	
	
	if(!GameBase::getLOSInfo(%player,2))
	{
		Client::sendMessage(%client,0,"Deploy position too far away");
		return false;
	}	
	
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
		
//
	if(%player.outArea)
	{
		Client::sendMessage(%client,0,"Can Not Deploy Jail Tower out of bounds");
		return false;
	}

	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Can Not Deploy, Jail Tower Already In Place");
		return false;
	}

//check how close to flag 
	%flagpos = $teamFlag[%team].originalPosition;	
	if(Vector::getDistance(%flagpos, %playerpos) < 100)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return false;
	}
	

// check for deployed ships. 
	for(%i = -1; %i<$ship+1; %i++)
//	{
//	%shipPos = getword($DropShipPosition[%i],0) @" "@ getword($DropShipPosition[%i],1)@" "@getword(%playerPos,2);	
//	if(Vector::getDistance(%shipPos,%playerPos)< 50){
//		Client::sendMessage(%client,0,"You are too close to a ships landing position~waccess_denied.wav");
//		return false;
//		}
//	}

// check for deployed ships.
	for(%i = 0; %i < getNumTeams()-1; %i = %i + 1)
	{
		%loc2 = getword($los::position,2);
		%posa = $DropShipPos[%i @ "CommandShip"];	//CommandShip,GunShip,SupplyShip
		%posb = $DropShipPos[%i @ "GunShip"];
		%posc = $DropShipPos[%i @ "SupplyShip"];
		
		// deal with extreme terrain grades or altered terrain rotations 
		%Pos1 = getword(%posa,0) @" "@ getword(%posa,1)@" "@%loc2;	
		%Pos2 = getword(%posb,0) @" "@ getword(%posb,1)@" "@%loc2;	
		%Pos3 = getword(%posc,0) @" "@ getword(%posc,1)@" "@%loc2;	
		
		%dist1 = Vector::getDistance(%Pos1,$los::position);
		%dist2 = Vector::getDistance(%Pos2,$los::position);
		%dist3 = Vector::getDistance(%Pos3,$los::position);

		//echo("shippos ",%posa,%posb,%posc);

		if((%dist1 < 50 && %posa != "") || (%dist2 < 60 && %posb != "" ) || ( %dist3 < 50 && %posc != ""))
		{
			Client::sendMessage(%client,0,"You are too close to a ships landing position~waccess_denied.wav");
			return false;
		}
	}


		
// check for landing beacons... 
	%set = newObject("JailCheck",SimSet);
	addToSet("MissionCleanup", %set);
	containerBoxFillSet(%set, $StaticObjectType | $ItemObjectType, %playerPos, 120, 120, 120,0);
	%num = Group::objectCount(%set);
	for(%i = 0; %i < %num; %i++)
	{
		%obj = Group::getObject(%set, %i);
		%name = GameBase::getDataName(%obj);
		//echo(%obj@" checking "@%name);
		if(%name == "ShipAntenna") 
		{
			%dis = Vector::getDistance(%playerPos,GameBase::getPosition(%obj));
			%mapName = Gamebase::getMapName(%obj);
			%type = string::getsubstr(%mapName, 0, 4); 
			if((%type == "GunS" && %dis < 55) || (%type == "Comm" && %dis < 45) || (%type == "Supp" && %dis < 40))
				%checkShip = true;			
		}
	}
	deleteObject(%set);
	if(%checkShip)
	{
	Client::sendMessage(%client,0,"You are too close to a ships landing position~waccess_denied.wav");
	return false;		
	}
	

// and other objects.. sigh.. 
	%set = newObject("JailCheck",SimSet);
	addToSet("MissionCleanup", %set);
	containerBoxFillSet(%set, $StaticObjectType | $ItemObjectType, %playerPos, 27, 27, 27,0);
	%num = Group::objectCount(%set);
	//echo("checking area for other objects "@%num@" set # "@%set);
	if(%num){
		Client::sendMessage(%client,0,"Other objects in the way~waccess_denied.wav");
		deleteObject(%set);
		return false;
		}
	else deleteObject(%set);

//check ceiling  	
	%camera = newObject("Camera","Turret",cameraturret,true);
	GameBase::setPosition(%camera,Vector::add(%playerPos,"0 0 2"));
	if(GameBase::getLOSInfo(%camera,35,"1.5708 0 0"))
		{
		%name = GameBase::getDataName($los::object);
		if(!%name) %name = getObjectType($los::object);
		Client::sendMessage(%client,0,%name@" in way, "@Vector::getDistance($los::position, GameBase::getPosition(%camera))@" meters up.");
		DeleteObject(%camera);
		return false;			
		}
	else DeleteObject(%camera);	
	
// looks ok to set this up.
	CreateJailSimSet(%team);

	// Tower Floor
	%object = newObject("Jail Tower","InteriorShape", "BESfloatingPad.dis");
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/JailTower" @ %team, %object);
	%pos = rotateVector("0 0 -1.5",%prot);
	%pos = Vector::add(%playerPos,%pos);	
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	%object.inmotion = true;
	GameBase::startFadeIn(%object);

	// Tower Roof
	%object = newObject("Jail Tower","InteriorShape", "BESfloatingPad.dis");
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/JailTower" @ %team, %object);
	%pos = rotateVector("0 0 39.5219",%prot);
	%pos = Vector::add(%playerPos,%pos);	
	%rot = "0 3.14159 0";	
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	%object.inmotion = true;
	GameBase::startFadeIn(%object);
	
	// Tower Base
	%object = newObject("Jail Tower","InteriorShape","mis_ob1.0.dis");
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/JailTower" @ %team, %object);
	%pos = rotateVector("0 0 15",%prot);
	%pos = Vector::add(%playerPos,%pos);	
	%rot = "0 3.14159 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	%object.inmotion = true;
	GameBase::startFadeIn(%object);

	// Force Field Wall
	%object = newObject("Jail Tower","StaticShape",JailWall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/JailWalls" @ %team, %object);
	%pos = rotateVector("5.8746 0 16.0111",%prot);
	%pos = Vector::add(%playerPos,%pos);	
	%rot = "0 0 1.570796";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::startFadeIn(%object);
	
	// Force Field Wall
	%object = newObject("Jail Tower","StaticShape",JailWall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/JailWalls" @ %team, %object);
	%pos = rotateVector("-5.8746 0 16.0111",%prot);
	%pos = Vector::add(%playerPos,%pos);
	%rot = "0 0 1.570796";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::startFadeIn(%object);
	
	// Force Field Wall
	%object = newObject("Jail Tower","StaticShape",JailWall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/JailWalls" @ %team, %object);
	%pos = rotateVector("0 5.8746 16.0111",%prot);
	%pos = Vector::add(%playerPos,%pos);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::startFadeIn(%object);
	
	// Force Field Wall
	%object = newObject("Jail Tower","StaticShape",JailWall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/JailWalls" @ %team, %object);
	%pos = rotateVector("0 -5.8746 16.0111",%prot);
	%pos = Vector::add(%playerPos,%pos);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::startFadeIn(%object);

	// Release Switch
	%name = "Jail Tower";
	%object = newObject("Release Swicth","StaticShape",JailReleaseSwitch,false);
	addToSet("MissionCleanup", %object);
	addToSet("MissionCleanup/JailTower" @ %team, %object);
	%pos = rotateVector("0 0 14.15",%prot);
	%pos = Vector::add(%playerPos,%pos);
	%rot = "0 3.14159 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	GameBase::startFadeIn(%object);

	%posX = getWord(%playerpos, 0);
	%posY = getWord(%playerpos, 1);
	%posZ = getWord(%playerpos, 2) + 16;
	$JailPosition[%team] = %posX@" "@%posY@" "@%posZ;

	$TeamItemCount[%team @ %item]++;
	echo("MSG: ",%client," deployed a Jail Tower");
	Client::sendMessage(%client,0,%item.description @ " deployed.");
	DropshipTeamMessage(%team, 3, "A Jail Tower has been deployed by "@Client::getName(%client)@".");	//	
	playSound(SoundPickupBackpack,%playerPos);
	return true;
}

function JailReleaseSwitch::onCollision(%this,%obj)
{	
	if($debug) 
		event::collision(%this,%obj);

	if(!%this.wait)
	{
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.01);
		%this.wait = true;
		%this.Jailup = 60;
		%this.Jaildown = 60;
		schedule("JailWall::move(" @ %this @ ",true);",0.1);
		schedule("JailWall::move(" @ %this @ ");",10);	
	}
}



//
function ToJail(%client,%team)
{
	
	%player = Client::getOwnedObject(%client);
//	echo("jailed pl# "@%player);
	//%player.invulnerable = true;
 	//%player.jailed = true;	

	//	schedule("prisonguard("@%client@");",1);
		prisonguard(%client);
		%name = Client::getName(%Client);
		GameBase::SetPosition(%client, $JailPosition[%Team]);		
		Client::SendMessage(%client,0,"Your jail sentence will last 30 seconds.");
		schedule("JailBreak(" @ %client @ ", " @ %team @ ");",30);
		schedule("JailBird(" @ %client @ ", " @ %team @ ");",1);		
		if(GameBase::getControlClient(%player) != %client){
		//yank em outa that turret or vehicle NYPD style!
			if(%player.ManualCommandTag)
				{	
				%player.ManualCommandTag = False;
				%player.CommandTag = "";
				}
			Player::setMountObject(%player, -1,0);
			Client::setControlObject(%client, %player);	
		
		}

}

function prisonguard(%client)
{
	%player = Client::getOwnedObject(%client);
	$jailed[%player] = "True";
	echo(%client,%player," jailed ",$jailed[%player]);
}

//check to see if they're still in jail, or if someone hit switch and released them..
function JailBird(%client, %team)
{	
	%player = Client::getOwnedObject(%client);
	if(Player::isDead(%player)) return;
	%playerPos = GameBase::getPosition(%player);
	%playerdist = Vector::getDistance($JailPosition[%Team], %playerpos);
	if(%playerdist > 10 && !$released[%player])
		{
		Client::SendMessage(%client, 0, "You've escaped! Run Forrest Run!!!!");	
		Messageallexcept(%client,0,Client::getName(%client)@" escaped from jail.");				
		$jailed[%player] = "";
		%player = Client::getOwnedObject(%client);	
		}
	if($jailed[%player] && !$released[%player])  schedule("JailBird(" @ %client @ ", " @ %team @ ");",0.25);
}






//
function JailBreak(%client, %team)
{
	%player = Client::getOwnedObject(%client);
//	echo("jail client "@%client@" player# "@%player@" in team's "@ %team@" jail");
	%playerPos = GameBase::getPosition(%player);
	%playerdist = Vector::getDistance($JailPosition[%Team], %playerpos);
	schedule("ParoleGrace("@%client@");",5);
//	echo("%playerdist "@%playerdist);
	if(%playerdist < 10){	
		%posX = getWord($JailPosition[%Team], 0);
		%posY = getWord($JailPosition[%Team], 1);
		%posZ = getWord($JailPosition[%Team], 2) + 10;
		%freeplayerpos = %posX@" "@%posY@" "@%posZ;
		GameBase::SetPosition(%client, %freeplayerpos);
		$released[%player] = true;
		schedule("$released[" @ %player @ "] = false;",5);
		Client::SendMessage(%client, 0, "You Have Been Released, now get outa here!!!!~wshieldhit.wav");
		Messageallexcept(%client,0,Client::getName(%client)@" Was paroled early from jail.");
		
	}
}

function ParoleGrace(%client){
	%player = Client::getOwnedObject(%client);
	$jailed[%player] = "";
	//echo("jail grace over");
}


//
function JailWall::move(%this, %up)
{
	//echo("up "@%this.Jailup@" down "@%this.Jaildown);
	if(%up)
	{
		%team = GameBase::getTeam(%this);
		%teleset = nameToID("MissionCleanup/JailWalls" @ %team);
		for(%i = 0; (%object = Group::getObject(%teleset, %i)) != -1; %i++)
		{	
			%pos = GameBase::getPosition(%object);
			%pos = Vector::add(%pos,"0 0 0.1");
			GameBase::setPosition(%object,%pos);
		}
		%this.Jailup = %this.Jailup -1;
		if(%this.Jailup)schedule("JailWall::move(" @ %this @ ",true);",0.05);
		
	}
	else
	{
		%team = GameBase::getTeam(%this);
		%teleset = nameToID("MissionCleanup/JailWalls" @ %team);		
		for(%i = 0; (%object = Group::getObject(%teleset, %i)) != -1; %i++)
		{	
			%pos = GameBase::getPosition(%object);
			%pos = Vector::add(%pos,"0 0 -0.1");
			GameBase::setPosition(%object,%pos);
		}
		%this.Jaildown = %this.Jaildown -1;
		%Limit = Vector::add(getWord($JailPosition[%team],2),"0 0 0.1");	//make sure tribes rounding doesnt thwart us..
		if(%this.Jaildown && getWord(%pos,2) > %Limit)schedule("JailWall::move(" @ %this @ ",false);",0.05);	
		else %this.wait = false;	
	}
	
}

//whew..