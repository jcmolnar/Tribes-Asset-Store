
// Code Copyright July 2002, Plasmatic 
// plasmatica.cjb.net
// ziptiezmail@netscape.net
// icq# 77161332

// This file contains Annihilation specific map editor code
// and will export this code to the maps .mis file to make
// maps created with Annihilation compatable with all mods..

// Annihilation teleporters feature possible multiple random drop points, 
// visible or invisible tele entry points,
// and painless integration into the mission editor.
// 

// www.annihilation.info
// ziptiezmail@netscape.net
// -Plasmatic



function AnnME::AddTeleGroup()
{

	%obj = MissionCreateObject("TeleGroup", SimGroup);
// going to make sure this gets added only once to the .mis -plasmatic
	if($AnnMeAddedTeleportText == "" && $UsingAnnTeleCS == "")
	{

// exporting the whole damn AnnTeleporter.cs file here, idiot proofing -Plasmatic

addExportText("															");
addExportText("// This code has been placed here by UltraGZHQ mod Map editor,							");
addExportText("// to make teleporters created with the UltraGZHQ map editor work.						");
addExportText("// For more information, go to http://www.annihilation.info							");
addExportText("// Code will not interfere with other mods, or base mod.								");
addExportText("															");
addExportText("// UltraGZHQ Teleporter											");
addExportText("// copyright July, 2002 Steve Madden aka Plasmatic								");
addExportText("															");
addExportText("// UltraGZHQ teleporters feature possible multiple random drop points, 					");
addExportText("// visible or invisible tele entry points,									");
addExportText("// and painless integration into the mission editor.								");
addExportText("															");
addExportText("// www.annihilation.info												");
addExportText("// ziptiezmail@netscape.net											");
addExportText("// -Plasmatic													");
addExportText("															");
addExportText("//========================= Beginning Teleport Code.. -plasmatic						");
addExportText("$UsingAnnTeleCS = true;												");
addExportText("															");
addExportText("//function modified to work with UltraGZHQ, yet still compatable with base, and other mods.			");
addExportText("function GroupTrigger::onEnter(%this,%object)									");
addExportText("{														");
addExportText("	%type = getObjectType(%object);											");
addExportText("	if(%type == \"Player\" || %type == \"Vehicle\") {								");
addExportText("		if(%this.TeleTrigger == true)										");
addExportText("		{													");
addExportText("			// Teleporters created with UltraGZHQ mod have a TeleTrigger field				");
addExportText("			// for the object in the .mis file -plasmatic							");
addExportText("			TeleTrigger::onTrigEnter(%this, %object);							");
addExportText("		}													");
addExportText("		else													");
addExportText("		{													");
addExportText("			%group = getGroup(%this); 									");
addExportText(" 			%count = Group::objectCount(%group);							");
addExportText(" 			for (%i = 0; %i < %count; %i++) 							");
addExportText(" 				GameBase::virtual(Group::getObject(%group,%i),\"onTrigEnter\",%object,%this);	");
addExportText(" 		}												");
addExportText("	}														");
addExportText("}														");
addExportText("															");
addExportText("//searches group for drop points, If more than one, picks random. -plasmatic					");
addExportText("function TeleTrigger::onTrigEnter(%this,%object)									");
addExportText("{														");
addExportText("															");
addExportText("	%type = getObjectType(%object);											");
addExportText("	if(%type == \"Player\" || %type == \"Vehicle\" || %type == \"Flier\")						");
addExportText("	{														");
addExportText("		%client = Player::getclient(%object);									");
addExportText("		if(GameBase::getControlClient(%object) != %client) %client = GameBase::getControlClient(%object);	");
addExportText("		if(Client::getTeam(%client) != GameBase::getTeam(%this) && GameBase::getTeam(%this) != -1) return;	");
addExportText("		%group = getGroup(%this);										");
addExportText(" 		%count = Group::objectCount(%group);								");
addExportText(" 		for(%i = 0; %i < %count; %i++)									");
addExportText(" 			{ 											");
addExportText(" 			%data = GameBase::getDataName(Group::getObject(%group,%i));				");
addExportText(" 			if(%data == DropPointMarker) 								");
addExportText(" 				{										");
addExportText(" 				%DropCount++;									");
addExportText(" 				%droppos = Group::getObject(%group,%i);						");
addExportText(" 				%teleset = nameToID(\"MissionCleanup/TeleportSet\"@%this);			");
addExportText("				if(%teleset == -1)									");
addExportText("				{											");
addExportText("					%group = newObject(\"TeleportSet\"@%this, SimSet);				");
addExportText("					addToSet(MissionCleanup, %group);						");
addExportText("				}											");
addExportText(" 				addToSet(\"MissionCleanup/TeleportSet\"@%this, %droppos);			");
addExportText(" 				}										");
addExportText(" 			}											");
addExportText(" 														");
addExportText("	// pick a random tele point within the set -plasmatic								");
addExportText(" 			%spawnIdx = floor(getRandom() * (%DropCount - 0.1));					");
addExportText("			%group = nameToID(\"MissionCleanup/TeleportSet\"@%this);					");	
addExportText(" 			%newpos = Group::getObject(%group,%spawnIdx);						");
addExportText(" 														");
addExportText(" 		if(GameBase::GetPosition(%newpos) != \"0 0 0\")							");
addExportText(" 			{											");
addExportText(" 			GameBase::playSound(%object, ForceFieldOpen, 0);					");
addExportText("			GameBase::playSound(%this, ForceFieldOpen, 0);							");
addExportText("			Client::sendMessage(%client, 0, \"You have been teleported.~wshieldhit.wav\");			");
addExportText("			GameBase::SetPosition(%object, GameBase::GetPosition(%newpos));					");
addExportText("			%Trot = GameBase::getRotation(%newpos); 							");
addExportText("			GameBase::setRotation(%object,%Trot);								");
addExportText("			GameBase::startFadeIn(%object);									");
addExportText(" 			} 											");
addExportText(" 		else echo(\"!! WARNING !! No matching teleport drop point in group!!\");				");	
addExportText("	}														");
addExportText("}														");
addExportText("//========================= Ending Teleport Code.. -plasmatic 														");
addExportText("															");

		
		
		$AnnMeAddedTeleportText = true;
	}
	

}


function AnnME::AddTeleTrigger()
{
	%obj = MissionCreateObject(Teletrigger, Trigger, GroupTrigger);
   focusServer();
	%obj.TeleTrigger = true;	// would like to set name, but tribes doesnt like that.. -plasmatic
   focusClient();	
}


function AnnME::AddTeleBeam()
{
	//setting up a trigger at beam -collisions are disabled for base electro beam -plasmatic
	%obj = MissionCreateObject(ElectrBeam, StaticShape, ElectricalBeam);
	%Trig = MissionCreateObject(Teletrigger, Trigger, GroupTrigger);
   focusServer();
	%obj.TeleTrigger = true;	//not needed but we'll go ahead and set this...
	%Trig.TeleTrigger = true;	//not needed but we'll go ahead and set this...
   focusClient();	
	%pos = gamebase::getposition(%Trig);	
	gamebase::setposition(%Trig,vector::add(%pos, "0 0 2"));
	gamebase::setmapname(%obj,TeleTrigger);		//setting map name for electro here, doesnt work with trigger though.
   
}

//========================= stuff needed for other mods.. -plasmatic
//
//base function modified to work with UltraGZHQ, yet still compatable with base, and other mods. -plasmatic

function GroupTrigger::onEnter(%this,%object)
{
	echo("tele?"@%this.TeleTrigger);
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		if(%this.TeleTrigger == true)
			TeleTrigger::onTrigEnter(%this, %object);
		else
		{
			%group = getGroup(%this); 
 			%count = Group::objectCount(%group);
 			for (%i = 0; %i < %count; %i++) 
 				GameBase::virtual(Group::getObject(%group,%i),"onTrigEnter",%object,%this);
 		}
	}
}

//searches group for drop points, If more than one, picks random. -plasmatic

function TeleTrigger::onTrigEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle" || %type == "Flier")
	{
		%client = Player::getclient(%object);
		if(GameBase::getControlClient(%object) != %client) %client = GameBase::getControlClient(%object);
		if(Client::getTeam(%client) != GameBase::getTeam(%this) && GameBase::getTeam(%this) != -1) return;
		%group = getGroup(%this);
 		%count = Group::objectCount(%group);
 		for(%i = 0; %i < %count; %i++)
 			{ 
 			%data = GameBase::getDataName(Group::getObject(%group,%i));
 			if(%data == DropPointMarker)  
 				{
 				%DropCount++;	
 				%droppos = Group::getObject(%group,%i);
 				%teleset = nameToID("MissionCleanup/TeleportSet"@%this);
				if(%teleset == -1)
					{
					%group = newObject("TeleportSet"@%this, SimSet);
					addToSet(MissionCleanup, %group);
					}
 				addToSet("MissionCleanup/TeleportSet"@%this, %droppos);	
 				}
 			}
 		%spawnIdx = floor(getRandom() * (%DropCount - 0.1));
		%group = nameToID("MissionCleanup/TeleportSet"@%this);		
 		%newpos = Group::getObject(%group,%spawnIdx);	
 		if(GameBase::GetPosition(%newpos) != "0 0 0")
 			{
 			GameBase::playSound(%object, ForceFieldOpen, 0);
			GameBase::playSound(%this, ForceFieldOpen, 0);
			Client::sendMessage(%client, 0, "You have been teleported.~wshieldhit.wav");
			GameBase::SetPosition(%object, GameBase::GetPosition(%newpos));
			%Trot = GameBase::getRotation(%newpos); 
			GameBase::setRotation(%object,%Trot);
			GameBase::startFadeIn(%object);	
 			} 
 		else echo("!! WARNING !! No matching teleport drop point in group!!");		
	}
}

