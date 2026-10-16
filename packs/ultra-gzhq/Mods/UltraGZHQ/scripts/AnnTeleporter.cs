
// Annihilation Teleporter
// copyright July, 2002 Steve Madden aka Plasmatic

// This file is included in Annihilation mod, and needs to be included with 
// any map created with Annihilation mod that uses teleporters
// created with the map editor.

// Annihilation teleporters feature possible multiple random drop points, 
// visible or invisible tele entry points,
// and painless integration into the mission editor.
//

// www.annihilation.info
// ziptiezmail@netscape.net
// -Plasmatic

$UsingAnnTeleCS = true;
//========================= stuff needed for other mods.. -plasmatic


//function modified to work with UltraGZHQ, yet still compatable with base, and other mods.
function GroupTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		if(%this.TeleTrigger == true)
		{
			// Teleporters created with UltraGZHQ mod have a TeleTrigger field
			// for the object in the .mis file -plasmatic
			TeleTrigger::onTrigEnter(%this, %object);
		}
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
 			
	// pick a random tele point within the set -plasmatic
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

