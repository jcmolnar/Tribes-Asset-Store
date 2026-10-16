//*************************
// TRIBAL COMBAT DEPLOYABLE
//*************************

$FSBoxMaxWidth = 3;
$FSBoxMaxLength = 3;
$FSBoxMaxHeight = 3;
$FSBoxMinWidth = 2;
$FSBoxMinLength = 2;
$FSBoxMinHeight = 2;
$MaxNumFSBox = 1;
$BarBoxMaxWidth = 2;
$BarBoxMaxLength = 2;
$BarBoxMaxHeight = 1;
$MaxNumBarBox = 3;

function checkFSDeploy(%client,%pos)
{
  	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "StaticShape") 
	{ 
		%obj = Group::getObject(%set,0);
		%objname = GameBase::getDataName(%obj);
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{ 
		%obj = Group::getObject(%set,0);
		%objname = GameBase::getDataName(%obj);
		if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
    else if(%num == 2)
	{
	 %obj = Group::getObject(%set,0);
	 %obj2 = Group::getObject(%set,1);
     if(getObjectType(%obj) == "StaticShape" || getObjectType(%obj2) == "StaticShape")
	 {
		deleteObject(%set);
		return 1;
	 }
 	 else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;
}

function horzDeployShape(%player,%item,%shape,%data,%name,%sound)
{
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  if(GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
    %rot = GameBase::getRotation(%player);
    %obj = newObject(%name,%data,%shape,true);
    addToSet("MissionCleanup", %obj);
    GameBase::setTeam(%obj,GameBase::getTeam(%player));
    GameBase::setPosition(%obj,$los::position);
    GameBase::setRotation(%obj,%rot);
    Gamebase::setMapName(%obj,%name);
    Client::sendMessage(%client,0,%name@" Deployed");
    GameBase::startFadeIn(%obj);
    playSound(SoundPickupBackpack,$los::position);
    if(%sound != "") playSound(%sound,$los::position);
    $TeamItemCount[GameBase::getTeam(%player) @ %name]++;
    return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
  }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}

function radDeployShape(%player,%item,%shape,%data,%name,%sound)
{
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
 {
  if(GameBase::getLOSInfo(%player,3)) 
  {
   %obj = getObjectType($los::object);
   %objname = GameBase::getDataName($los::object);
   if(%obj == "SimTerrain" || %obj == "InteriorShape" || %objname == "ssFloatingPad" || %objname == "ssBarricade") 
   {
	   %prot = GameBase::getRotation(%player);
	   %zRot = getWord(%prot,2);
	   if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 "@%zRot;
	   else
	   {
	    if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 "@%zRot;
		else %rot = Vector::getRotation($los::normal);
       }
	   if(checkDeployArea(%client,$los::position))
	   {
	    %object = newObject(%name,%data,%shape,true);
	   	addToSet("MissionCleanup",%object);
		GameBase::setTeam(%object,GameBase::getTeam(%player));
		GameBase::setRotation(%object,%rot);
		GameBase::setPosition(%object,$los::position);
		Gamebase::setMapName(%object,%name);
		Client::sendMessage(%client,0,%name@" deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%object)@%name]++;
		echo("MSG: ",%client," deployed a "@%name);
		return true;
	   }
   }
   else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
  }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}

//**********************************
ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
    heading = "hDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
{
 if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
 else Player::deployItem(%player,%item);
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
 if(horzDeployShape(%player,%item,DeployableInvStation,StaticShape,DeployableInvPack)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}	

//***********************************
ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableAmmoPack
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
    heading = "hDeployables";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableAmmoPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
 if(horzDeployShape(%player,%item,DeployableAmmoStation,StaticShape,DeployableAmmoPack)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//****************************
ItemImageData ForceScreenImage
{
shapeFile = "ammopack";
mountPoint = 2;
mountOffset = { 0, -0.03, 0 };
mass = 2.0;
firstPerson = false;
};

ItemData ForceScreen
{
description = "Force Screen";
shapeFile = "AmmoPack";
className = "Backpack";
heading = "gDefense";
imageType = ForceScreenImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 800;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

function ForceScreen::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function ForceScreen::onDeploy(%player,%item,%pos)
{
 if(deployForceScreen(%player,%item,ssFSGenerator,StaticShape,ForceScreen,ForceFieldOpen)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
// if(horzDeployShape(%player,%item,ssForceScreen,StaticShape,ForceScreen,ForceFieldOpen)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

function deployForceScreen(%player,%item,%shape,%data,%name,%sound)
{
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  if(GameBase::getLOSInfo(%player,3))
  {
   %obj = getObjectType($los::object);
    %objname = GameBase::getDataName($los::object);
	if(%obj == "SimTerrain" || %obj == "InteriorShape" || %objname == "ssFloatingPad" || %objname == "flagstand") 
   {
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$FSBoxMaxLength,$FSBoxMaxWidth,$FSBoxMaxHeight,0);
	%num = CountObjects(%set,%shape,%num);
	deleteObject(%set);
	if($MaxNumFSBox > %num)
	{
	 %set = newObject("set",SimSet);
	 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$FSBoxMinLength,$FSBoxMinWidth,$FSBoxMinHeight,0);
	 %num = CountObjects(%set,%shape,%num);
	 deleteObject(%set);
	 if(0 == %num)
	 {
	  if(Vector::dot($los::normal,"0 0 1") > 0.7)
	  {
	   if(checkFSDeploy(%client,$los::position))
	   {
		%rot = GameBase::getRotation(%player); 
		%object = newObject(%name,%data,%shape,true);
	    addToSet("MissionCleanup",%object);
		GameBase::setTeam(%object,GameBase::getTeam(%player));
		GameBase::setPosition(%object,$los::position);
		GameBase::setRotation(%object,%rot);
		Gamebase::setMapName(%object,"Force Screen Generator");
		Client::sendMessage(%client,0,%name@" deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%player)@%name]++;
        echo("MSG: ",%client," deployed a "@%name);
	    return true;
	   }
	  }
      else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
     } 
     else Client::sendMessage(%client,0,"Frequency Overload - Too close to other "@%name@"s");
    }
    else Client::sendMessage(%client,0,"Interference from other "@%name@"s in the area");
   }
   else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
  }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for "@%name@"s");
 return false;
}

//**************************
ItemImageData BarricadeImage
{
shapeFile = "ammopack";
mountPoint = 2;
mountOffset = { 0, -0.03, 0};
mass = 2.0;
firstPerson = false;
};

ItemData Barricade
{
description = "Barricade";
shapeFile = "ammopack";
className = "Backpack";
heading = "gDefense";
imageType = BarricadeImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 700;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

function Barricade::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function Barricade::onDeploy(%player,%item,%pos)
{
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  if(GameBase::getLOSInfo(%player,3))
  {
   %obj = getObjectType($los::object);
   %objname = GameBase::getDataName($los::object);
   if(%obj == "SimTerrain" || %obj == "InteriorShape" || %objname == "ssFloatingPad" || %objname == "ssBarricade") 
   {
    %set = newObject("set",SimSet);
    %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$BarBoxMaxLength,$BarBoxMaxWidth,$BarBoxMaxHeight,0);
    %bnum = CountObjects(%set,ssBarricade,%num);
	%fsnum = CountObjects(%set,ssFSGenerator,%num);
    deleteObject(%set);
	if(%fsnum)
	{
     Client::sendMessage(%client,0,"Too close to a force screen");
	 return false;
	}
    if($MaxNumBarBox > %bnum)
    {
      if(Vector::dot($los::normal,"0 0 1") > 0.7)
      {
	   if(checkFSDeploy(%client,$los::position))
	   {
       %rot = GameBase::getRotation(%client);
       %newRot = adjustRot(%rot,-1);
       %pos = GameBase::getPosition(%client);
       %posX = getWord(%pos,0);
       %posY = getWord(%pos,1);
       %posZ = getWord(%pos,2);
       %vec = Vector::getFromRot(%newRot,3);
       %newPosX = (getWord(%vec,0) * 1) + %posX;		 
       %newPosY = (getWord(%vec,1) * 1) + %posY;
       %obj = newObject("Barricade",StaticShape,ssBarricade,true);
       addToSet("MissionCleanup", %obj);
       %newPosX = (getWord(%vec,0) * 1) + %posX;
       %newPosY = (getWord(%vec,1) * 1) + %posY;
       GameBase::setPosition(%obj,%newPosX @ " " @ %newPosY @ " " @ %posZ);
       GameBase::setRotation(%obj,%rot);
       GameBase::setTeam(%obj,GameBase::getTeam(%player));
       Gamebase::setMapName(%obj,"Barricade");
       Client::sendMessage(%client,0,"Barricade Deployed");
       GameBase::startFadeIn(%obj);
       playSound(SoundPickupBackpack,$los::position);
       $TeamItemCount[GameBase::getTeam(%player) @ Barricade]++;
       if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
       return true;
	   }
      }
      else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
     }
     else Client::sendMessage(%client,0,"Too close to other "@%item.description@"s");
   }
   else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
  }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}

//****************************
ItemImageData TeleportPadImage
{
shapeFile = "ammopack";
mountPoint = 2;
mountOffset = { 0, -0.03, 0 };
mass = 2.0;
firstPerson = false;
};

ItemData TeleportPad
{
description = "Teleport Pad";
shapeFile = "flagstand";
className = "Backpack";
heading = "hDeployables";
imageType = TeleportPadImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 2500;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

function TeleportPad::onUse(%player,%item)
{
 if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
 else Player::deployItem(%player,%item);
}

function TeleportPad::onDeploy(%player,%item,%pos)
{
if(TeleportPad::deployShape(%player,%item))
 {
  if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
  TeamMessages(1,GameBase::getTeam(%player),"A Teleport Pad has been deployed - Teleport Packs are now enabled.");
 }
}

//Needs custom deploy
function TeleportPad::deployShape(%player,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  if (GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %screen = newObject("TeleportPad","StaticShape",ssTeleportPad,true);
   %group = nameToID("MissionCleanup/TeleportPads");
   if(%group == -1)
   {
	newObject("TeleportPads",SimSet); 
	addToSet("MissionCleanup","TeleportPads");
   }
   addToSet("MissionCleanup/TeleportPads",%screen);
   addToSet("MissionCleanup", %screen);
   GameBase::setTeam(%screen,GameBase::getTeam(%player));
   GameBase::setPosition(%screen,$los::position);
   GameBase::setRotation(%screen,%rot);
   Gamebase::setMapName(%screen,%name);
   Client::sendMessage(%client,0,"Teleport Pad Deployed");
   GameBase::startFadeIn(%screen);
   playSound(SoundPickupBackpack,$los::position);
   playSound(ForceFieldOpen,$los::position);
   $TeamItemCount[GameBase::getTeam(%player) @ "TeleportPad"]++;
   %screen.enable = true;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
  }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}

//******************************
ItemImageData TeleportFieldImage
{
shapeFile = "jetPack";
mountPoint = 2;
mountOffset = { 0, -0.03, 0 };
mass = 2.0;
firstPerson = false;
};

ItemData TeleportField
{
description = "Teleport Field";
shapeFile = "jetPack";
className = "Backpack";
heading = "hDeployables";
imageType = TeleportFieldImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 2500;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

function TeleportField::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function TeleportField::onDeploy(%player,%item,%pos)
{
if(TeleportField::deployShape(%player,%item)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//Needs custom deploy
function TeleportField::deployShape(%player,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  if (GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %screen = newObject("TeleportField","StaticShape",ssTeleportField,true);
   %group = nameToID("MissionCleanup/Teleport");
   if(%group == -1)
   {
	newObject("Teleport",SimSet); 
	addToSet("MissionCleanup","Teleport");
   }
   addToSet("MissionCleanup/Teleport",%screen);
   addToSet("MissionCleanup", %screen);

   //Set GLOBAL position 
   $teleportPos[%screen] = GameBase::getPosition(%player);

   GameBase::setTeam(%screen,GameBase::getTeam(%player));
   GameBase::setPosition(%screen,$los::position);
   GameBase::setRotation(%screen,%rot);
   Gamebase::setMapName(%screen,%name);
   Client::sendMessage(%client,0,"Teleport Field Deployed ");
   GameBase::startFadeIn(%screen);
   playSound(SoundPickupBackpack,$los::position);
   playSound(ForceFieldOpen,$los::position);
   $TeamItemCount[GameBase::getTeam(%player) @ "TeleportField"]++;
   %screen.enable = true;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
  }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}

//*********************************
ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
    heading = "kSensors";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
 if(radDeployShape(%player,%item,DeployableMotionSensor,Sensor,MotionSensorPack,ForceFieldOpen)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//********************************
ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
    heading = "kSensors";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) 
	{
		if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}

//********************************
ItemImageData DGNPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DGNPack
{
	description = "Defense Grid Node";
	shapeFile = "radar_small";
	className = "Backpack";
    heading = "kSensors";
	imageType = DGNPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DGNPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function DGNPack::onDeploy(%player,%item,%pos)
{
	if(Item::deployShape(%player,"Defense Grid Node",DefenseGridNode,%item)) 
	{
	 if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
 	 $TeamItemCount[GameBase::getTeam(%player)@"DefenseGridNode"]++;
	}
}

//****************************************
ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
    heading = "kSensors";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)	Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if(Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) 
	{
		if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}

//****************************************************
function DeployDrone(%player,%item,%shape,%data,%name)
{
 %client = Player::getClient(%player);
 if(GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %obj = newObject(%name,%data,%shape,true);
   if($TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"] >= $TeamItemMax[%item])
    {
		centerprint(%client,"<jc>Maximum number of "@%name@"s deployed.");
		deleteObject(%obj);
		return;
	}
   addToSet("MissionCleanup",%obj);
   GameBase::setTeam(%obj,GameBase::getTeam(%player));
   GameBase::setPosition(%obj,$los::position);
   GameBase::setRotation(%obj,%rot);
   Gamebase::setMapName(%obj,%name);
   Client::sendMessage(%client,0,%name@" Deployed ");
   GameBase::startFadeIn(%obj);
   playSound(SoundPickupBackpack,$los::position);
   Client::setControlObject(%client,%obj);
   %player.vehicle = %obj;
   $TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"]++;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 return false;
}

ItemImageData DronePackImage
{
	shapeFile = "jetpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 8;
 	maxEnergy = 9;
	firstPerson = false;
};

ItemData DronePack
{
	description = "Drone";
	shapeFile = "jetpack";
	className = "Backpack";
    heading = "uRemote Vehicles";
	shadowDetailMask = 4;
	imageType = DronePackImage;
	mass = 0.5;
	price = 2000;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DronePack::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function DronePack::onDeploy(%player,%item,%pos)
{
 if(DeployDrone(%player,%item,Drone,flier,Drone)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//***********************
ItemImageData GBPackImage
{
	shapeFile = "jetpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 8;
 	maxEnergy = 9;
	firstPerson = false;
};

ItemData GuidedBombPack
{
	description = "Guided Bomb";
	shapeFile = "jetpack";
	className = "Backpack";
    heading = "uRemote Vehicles";
	shadowDetailMask = 4;
	imageType = GBPackImage;
	mass = 1.0;
	price = 5000;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GuidedBombPack::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function GuidedBombPack::onDeploy(%player,%item,%pos)
{
 if(DeployDrone(%player,%item,GuidedBomb,flier,GuidedBomb)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//********************************
ItemImageData SurveyDronePackImage
{
	shapeFile = "jetpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 8;
 	maxEnergy = 9;
	firstPerson = false;
};

ItemData SurveyDronePack
{
	description = "Survey Drone";
	shapeFile = "jetpack";
	className = "Backpack";
    heading = "uRemote Vehicles";
	shadowDetailMask = 4;
	imageType = SurveyDronePackImage;
	mass = 0.5;
	price = 2000;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SurveyDronePack::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function SurveyDronePack::onDeploy(%player,%item,%pos)
{
 if(DeployDrone(%player,%item,SurveyDrone,flier,SurveyDrone)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//********************************
ItemImageData ADPackImage
{
	shapeFile = "jetpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 8;
 	maxEnergy = 9;
	firstPerson = false;
};

ItemData AttackDronePack
{
	description = "Attack Drone";
	shapeFile = "jetpack";
	className = "Backpack";
    heading = "uRemote Vehicles";
	shadowDetailMask = 4;
	imageType = ADPackImage;
	mass = 0.5;
	price = 3000;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AttackDronePack::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function AttackDronePack::onDeploy(%player,%item,%pos)
{
 if(DeployDrone(%player,%item,AttackDrone,flier,AttackDrone)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}