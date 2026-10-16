//=====================================================================
//=======================BioWasteland HelpScreen File
//=======================Mod by Bïohazard
//=======================www.exploratoriums.com
//=======================biohazard@exploratoriums.com
//=====================================================================

function HelpRequest(%clientId)
{
	Client::sendMessage(%clientId,3," ");
	Client::sendMessage(%clientId,3,"-------------Help Screen -------------");
	Client::sendMessage(%clientId,3,"@name - Whisper to the named player.");
	Client::sendMessage(%clientId,3,"#armor - Get your armor's description.");
	Client::sendMessage(%clientId,3,"#center - Locate the map's center.");
	Client::sendMessage(%clientId,3,"#elim - See who remains (Elimination Missions).");
	Client::sendMessage(%clientId,3,"#flag - Locate your flag.");
	Client::sendMessage(%clientId,3,"#object - Get help with new map objectives.");
	Client::sendMessage(%clientId,3,"#pack - Get your pack's description.");
	Client::sendMessage(%clientId,3,"#rules - Read the rules.");
	Client::sendMessage(%clientId,3,"#score - Get Unity Duel Score.");
	Client::sendMessage(%clientId,3,"#spawn - Configure spawn options.");
	Client::sendMessage(%clientId,3,"#titan - Find your Titan (Titan Missions).");
	Client::sendMessage(%clientId,3,"#weapon - Get your weapon's description.");
	Client::sendMessage(%clientId,3,"---------------------------------------------");
	Client::sendMessage(%clientId,3," ");
}

function ObjHelp(%clientId)
{
	if($TestMissionType == "CTF") centerprint(%clientId, "<f1>Capture the Flag<f2> - Grab the enemy's flag and bring it to your own flag to score team points.", 10);
	else if($TestMissionType == "C&H") centerprint(%clientId, "<f1>Capture and Hold<f2> - Take control of the Tower Switches for team points.", 10);
	else if($TestMissionType == "D&D") centerprint(%clientId, "<f1>Defend and Destroy<f2> - Destroy the enemy's objective items while defending your own.", 10);
	else if($TestMissionType == "F&R") centerprint(%clientId, "<f1>Find and Retrieve<f2> - Grab the neutral flags and bring them back to an empty flag stand.", 10);
	else if($TestMissionType == "DM") centerprint(%clientId, "<f1>Death Match & Team DM<f2> - Kill or be killed.  Pure DM missions, your individual kill ratio is the key to winning.  In Team DM, the team's kill ratio is what counts.", 10);
	else if($TestMissionType == "CTB") centerprint(%clientId, "<f1>Bone Collector<f2> - Grab bones from the enemy's ancestral sarcophagus, and bring them back to your own for victory.", 10);
	else if($TestMissionType == "VeC") centerprint(%clientId, "<f1>Vehicle Capture<f2> - Park the objective vehicle in your teams hanger for team points.", 10);
	else if($Game::MissionType == "ELIM") centerprint(%clientId, "<f1>Eliminator<f2> - Kill or be eliminated.  When an entire team is out, they loose that round, and a new round begins.", 10);
	else if($TestMissionType == "CTE")centerprint(%clientId, "<f1>Energy Capture<f2> - Stand in the enemy's Energy Beam and collect as much energy as you dare, then return to your Energy Beam for points.", 10);
	else if($TestMissionType == "RACE") centerprint(%clientId, "<f1>Racing<f2> - Complete the race without missing any check points, and win the round.", 10);
	else if($TestMissionType == "SMR") centerprint(%clientId, "<f1>Smear the Flag<f2> - Hold onto the Scoring Flag for points.  Smear the player with the Flag if you don't have it.", 10);
	else if($TestMissionType == "DUEL") centerprint(%clientId, "<f1>DUEL<f2> - Use the [tab] menu to select a duel opponent.  1st player to die 10 times loses the match.", 10);
	else if($TestMissionType == "TIT") centerprint(%clientId, "<f1>TITAN<f2> - Each team has one Titan.  The first Titan to reach his opponents Titan Switch scores for the team.", 10);
	else centerprint(%clientId, "<f1>Objective Unknown<f2> - Unable to determine map's objective, so you best just get busy.", 10);
	schedule("centerprint(" @ %clientId @ ", \"To make your own maps with BioWasteland's new objectives visit my website for instructions at www.exploratoriums.com\", 8);", 10);
}

function ElimHelp(%clientId)
{
  if($Game::MissionType == "ELIM")
  {
	for(%i = 0; %i < getNumTeams() ; %i++)
	{
		for(%j = 0; %j < getNumClients(); %j = %j + 1)
		{
			%id = getClientByIndex(%j);
			if (%id.elim != "true" && %i == Client::getTeam(%id))
			{
				%f = %i;
				if (%f>2)%f=0;
				%left = %left @ "<f"@%f@"> " @ Client::getName(%id);
			}
		}
	}
	bottomprint(%clientId, "<jc>"@%left, 3);
  }
  else  bottomprint(%clientId, "<jc>This is not an Elimination mission.", 3);
}
function echoall(%obj)
{
 echo ("obj = "@%obj);
if (getObjectType(%obj) == "Player")echo ("obj = "@%obj@" Player "@Client::getName(Player::getClient(%obj)));
}
function TitanHelp(%clientId)
{
  if ($Game::missionType == "Titan")
  {
	%team = Client::getTeam(%clientId);
	%titan = $TeamTitan[%team];
	if (%titan == "" || getObjectType(%titan) != "Player"  || Player::isDead(%titan))
	{
		%pl = Client::getOwnedObject(%clientId);
		$TeamTitan[%team] = %pl;
		systemMessage(%clientId,3,"You become your team's Titan!~wflyer_mount.wav");
		playSound(SoundFlagReturned,gamebase::getposition(%pl));
		centerprint(%clientId, "                   <Btower_enemycontrol.bmp> Attack the Enemy's Titan Switch! <Btower_enemycontrol.bmp>");
		Player::setArmor(%clientId, tarmor);
		%item = Player::getMountedItem(%pl,$BackpackSlot);
		Player::dropItem(%clientId,%item);
		Player::mountItem(%clientId, TitanPack, $BackpackSlot);
		TeamMessages(3, %team, Client::getName(%clientId) @ " has become your team's Titan!");
	}
	else
	{
		%numPlayers = getNumClients();
		for(%j = 0; %j < %numPlayers; %j = %j + 1)
			if(getClientByIndex(%j) == Player::getClient(%titan))
				issueTargCommand(%clientId, %clientId, 1, "Cover Titan "@Client::getName(getClientByIndex(%j))@"~wescfr", %j+1);
	}
  }
  else  bottomprint(%clientId, "<jc>This is not a Titan mission.", 3);
}

function RuleHelp(%clientId)
{
	schedule("centerprint(" @ %clientId @ ", \"<jc>House Rules: #1 Honorable play.\", 3);", 0);
	schedule("centerprint(" @ %clientId @ ", \"<jc>Bases: base wrecking is fair game, so be sure to lay an emergency inventory early in the mission.\", 8);", 3);
	schedule("centerprint(" @ %clientId @ ", \"<jc>Turrets: offensive turrets are fair game.  This mod won't allow spawn-turrets except near the Base Invasion Marker, which is a legal means of defending an invasive outpost.\", 8);", 11);
	schedule("centerprint(" @ %clientId @ ", \"<jc>Weapons: if a weapon is available, it's legal.  Locking weapons exist, but at a cost, so they are balanced.\", 8);", 19);
	schedule("centerprint(" @ %clientId @ ", \"<jc>Newbies: welcome them, because we all started there once too.\", 8);", 27);
	schedule("centerprint(" @ %clientId @ ", \"<jc>Fighting: no hair pulling, eye gouging, or hitting below the belt, and have a clean tribal war!  Be excellent to each other.\", 8);", 35);
	schedule("centerprint(" @ %clientId @ ", \"<jc>oh yeah, almost forgot...\", 3);", 48);
	schedule("centerprint(" @ %clientId @ ", \"<jc>NO WHINING!\", 5);", 51);
}

function HelpArmorList()
{
	%max = getNumItems();
	%num=0;
	for (%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
		if(%item.className == Armor && %item != RunnerArmor )
		{
			$HelpArmor[%num] = %item;
			%num++;
		}
	}
	return %num;
}
function StartArmorSetup(%clientId)
{
	Client::buildMenu(%clientId, "Armor Setup:", "armorselect", true);
	%num = HelpArmorList();
	if (%num > 7) %num = 7;
	for (%i = 0;%i <= %num; %i++)
	{
		Client::addMenuItem(%clientId, "" @ %i+1 @ ($HelpArmor[%i]).description, %i);
	} 
}

function processMenuArmorSelect(%clientId, %option)
{               
	%item = $HelpArmor[%option];
	$spawnBuyList[0, %clientId] = %item;
	StartPackSetup(%clientId);
}
function HelpPackList(%clientId,%buyarmor)
{
	%max = getNumItems();
	%num=0;
	for (%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
		if($InvList[%item] != "" && $InvList[%item] && %item.className == BackPack && $ItemMax[%buyarmor,%item] > 0)
		{
			$HelpPack[%num] = %item;
			%num++;
		}
	}
	return %num;
}
function StartPackSetup(%clientId)
{
	if ($spawnBuyList[0, %clientId] !="") %armor = $spawnBuyList[0, %clientId];
	else %armor = Player::getarmor(%clientId);
	%buyarmor = $ArmorType[Client::getGender(%clientId), %armor];
	%num = HelpPackList(%clientId,%buyarmor);
	if (%num > 7) %num = 7;
	Client::buildMenu(%clientId, "Pack Setup:", "packselect", true);
	for (%i = 0;%i <= %num; %i++)
	{
		Client::addMenuItem(%clientId, "" @ %i+1 @ ($HelpPack[%i]).description, %i);
	} 
}

function processMenuPackSelect(%clientId, %option)
{               
	%item = $HelpPack[%option];
	$spawnBuyList[1, %clientId] = %item;
	StartWeaponSetup(%clientId);
}

function HelpWeaponList(%clientId,%buyarmor)
{
	%max = getNumItems();
	%num=0;
	for (%i = 0; %i < %max; %i = %i + 1)
	{
		%item = getItemData(%i);
		if($InvList[%item] != "" && $InvList[%item] && %item.className == Weapon && $ItemMax[%buyarmor,%item] > 0)
		{
			$HelpWeapon[%num] = %item;
			%num++;
		}
	}
	return %num;
}

function StartWeaponSetup(%clientId)
{
	%clientId.num =1;
	if ($spawnBuyList[0, %clientId] !="") %armor = $spawnBuyList[0, %clientId];
	else %armor = Player::getarmor(%clientId);
	%buyarmor = $ArmorType[Client::getGender(%clientId), %armor];
	%num = HelpWeaponList(%clientId, %buyarmor);
	if (%num > 7) %num = 7;
	%max = $MaxWeapons[%buyarmor];
	Client::buildMenu(%clientId, %buyarmor.description@" Weapons (Pick "@%max@"):", "weaponselect1", true);
	for (%i = 0;%i <= %num;%i++)
	{
		Client::addMenuItem(%clientId, "" @ %i+1 @ $HelpWeapon[%i], %i);
	} 
}

function processMenuWeaponSelect1(%clientId, %option)
{
	$spawnBuyList[%clientId.num+1, %clientId] = $HelpWeapon[%option];
	if ($spawnBuyList[0, %clientId] =="") $spawnBuyList[0, %clientId] = Player::getarmor(%clientId);
	%armor = $spawnBuyList[0, %clientId];
	%buyarmor = $ArmorType[Client::getGender(%clientId), %armor];
	%max = $MaxWeapons[%buyarmor];
	if (%clientId.num < %max)
	{
		Client::buildMenu(%clientId, %armor.description@" Weapons ("@(%max-%clientId.num)@" more):", "weaponselect1", true);
		%num = HelpWeaponList(%clientId, %buyarmor);
		for (%i = 0;%i <= %num;%i++)
		{
			Client::addMenuItem(%clientId, "" @ %i+1 @ $HelpWeapon[%i], %i);
		}
		%clientId.num++;
	}
	else processMenuWeaponSelect2(%clientId, %option);
}

function processMenuWeaponSelect2(%clientId, %option)
{               
	$spawnBuyList[%clientId.num+1, %clientId] = $HelpWeapon[%option];
	for (%i = (%clientId.num+2);%i < 20;%i++)
	{
		$spawnBuyList[%i, %clientId] = "";
	}
	bottomprint(%clientId,"<jc>Your setup is complete, and will take effect next spawn.");
	%clientId.spawntype = "favs";
}
                                    
function ItemHelp(%clientId, %opt)
{
	if (%opt == "nmeflag")
	{
		%playerteam = GameBase::getTeam(%clientId);
		%playerpos = GameBase::getPosition(%clientId);
		if (%playerteam == 0) %team = 1;
		else %team = 0;
		%pos = GameBase::getPosition($teamFlag[%team]);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%distance = Vector::getDistance(%pos, %playerpos);

		issueCommand(%clientId, %clientId, 0,"Waypoint set to enemy flag. ", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The enemy flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}
	else if (%opt == "flag")
	{
		%playerteam = GameBase::getTeam(%clientId);
		%playerpos = GameBase::getPosition(%clientId);
		%pos = GameBase::getPosition($teamFlag[%playerteam]);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%distance = Vector::getDistance(%pos, %playerpos);
		issueCommand(%clientId, %clientId, 0,"Way point set to your flag", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}
   	else if (%opt == "armor")
   	{
		%armor = Player::getArmor(%clientId);
		if (%armor == "-1")
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You are either dead or in observer mode.\", 10);", 0);
		}
		else if (%armor == "spyarmor" || %armor == "spyfemale") 		//== spy
   		{
   			   centerprint(%clientId, "  Spy Armor\n  <f1>Special Touch<f2> - assumes the skin of opponents.\n<f1>  Mines<f2> - cloaking anti-personel mines.\n  <f1>Grenades<f2> - Plastique (set plastique options in [tab] menu.\n  <f1>Beacons<f2> - \n  <f1>Other<f2> - Can use the Laptop to hack.", 10);
   		}
   		else if (%armor == "sarmor" || %armor == "sfemale") 			//== Recon
   		{
   			   centerprint(%clientId, "  Recon Armor\n  <f1>Special Touch<f2> - disarms opponents.\n  <f1>Mines<f2> - standard anti-personel mines.\n  <f1>Grenades<f2> - concussion\n  <f1>Beacons<f2> - small pulse sensors for scouting enemy locations.\n  <f1>Other<f2> - Can use the Laptop to waypoint enemy items.", 10);
   		}
   		else if (%armor == "larmor" || %armor == "lfemale") 			//== Assasin
   		{
   			   centerprint(%clientId, "  Assassin Armor\n  <f1>Special Touch<f2> - administers a deadly poinson.\n  <f1>Mines<f2> - explosive flag decoys.\n  <f1>Grenades<f2> - explosive repair pack decoys.\n  <f1>Beacons<f2> - detbug traps which must be dropped or the victim will be killed.", 10);
   		}
   		else if (%armor == "aarmor" || %armor == "afemale")			//== Stealth
   		{
   			   centerprint(%clientId, "  Stealth Armor\n  <f1>Special Touch<f2> - drains opponents, and also powers friendly stations.\n  <f1>Mines<f2> - cloaking mines.\n  <f1>Grenades<f2> - EMP grenades.\n  <f1>Beacons<f2> - used once provide cloaking, used twice provide special cloaking.", 10);
   		}
   		else if (%armor == "marmor" || %armor == "mfemale")			//== Patriot
   		{
   			   centerprint(%clientId, "  Patriot Armor\n  <f1>Special Touch<f2> - none.\n  <f1>Mines<f2> - standard anti-personel mines.\n  <f1>Grenades<f2> - fire bombs.\n<f1>  Beacons<f2> - booster jets for rapid transport.", 10);
   		}
   		else if (%armor == "earmor" || %armor == "efemale")			//== Engineer
   		{
   			   centerprint(%clientId, "  Engineer Armor\n  <f1>Special Touch<f2> - healing, repairing, and disarming.\n  <f1>Mines<f2> - (see [tab] menu) include proximity alarms, anti-personel, and laser mine.\n  <f1>Grenades<f2> - EMP blast.\n  <f1>Beacons<f2> - options (see [tab] menu).", 10);
   		}
   		else if (%armor == "barmor" || %armor == "bfemale")			//== Goliath
   		{
   			   centerprint(%clientId, "  Goliath Armor\n  <f1>Special Touch<f2> - none\n  <f1>Mines<f2> - standard anti-personel mines.\n  <f1>Grenades<f2> - .\n  <f1>Beacons<f2> - .", 10);
   		}
   		else if (%armor == "harmor")						//== Dreadnaught
   		{
   			   centerprint(%clientId, "  Dreadnauhght Armor\n  <f1>Special Touch<f2> -.\n  <f1>Mines<f2> - options (see [tab] menu) include anti-personel and laser mines.\n  <f1>Grenades<f2> - Mortar grenades.\n  <f1>Beacons<f2> - active his enery shield barrier for added protection.", 10);
   		}
   		else if (%armor == "jarmor")						//== Juggernaught
   		{
   			   centerprint(%clientId, "  Juggernaught Armor\n  <f1>Special Touch<f2> - the jugg hug repels lighter armors.\n  <f1>Mines<f2> - toggles the Plasma and Laser Cannons.\n  <f1>Grenades<f2> - fires the GodHammer Cannons.\n  <f1>Beacons<f2> - charges the Plasma and Laser Cannons.", 10);
   		}
   		else if (%armor == "tarmor")						//== Titan
   		{
   			   centerprint(%clientId, "  Titan Armor\n  <f1>Special Touch<f2> - crushes objects in its path.\n  <f1>Mines<f2> - anti-personel.\n  <f1>Grenades<f2> - fire bombs.\n  <f1>Beacons<f2> - summon teammates to your aid.\n <f1>  Special<f2> - touch the enemy's switch to score.", 10);
   		}
   		else centerprint( %clientId , "<f2>Your "@%armor@" armor is unrecognized.", 10);
   	}
}

function PackHelp(%clientId)
{
	%pack = Player::getMountedItem (%clientId, $BackPackSlot);
	if (%pack == "-1")
	{
  			schedule("centerprint(" @ %clientId @ ", \"<jc><f1> You do not currently have a pack.\", 10);", 0);
	}
	else if (%pack == "AmmoPack")
	{
		centerprint(%clientId, "<f2>Ammo Pack: gives you an extra supplt of ammo for those long trips.", 10);
	}
	else if (%pack == "BattlePack")
	{
		centerprint(%clientId, "<f2>BattlePack: upgrades the Patriot to heavy armor upon demand.", 10);
	}
	else if (%pack == "CloakingDevice")
	{
		centerprint(%clientId, "<f2>Cloak Pack: will make you invisable.  Stealth Armors also use it to emit a damaging Cloaking Blast.", 10);
	}
	else if (%pack == "EnergyPack")
	{
		centerprint(%clientId, "<f2>Energy Pack: will regenerate your energy quicker and you will use less.", 10);
	}
	else if (%pack == "FlightPack")
	{
		centerprint(%clientId, "<f2>Flight Pack: gives lighter armors a much greater energy supply and quicker regeneration time.", 10);
	}
	else if (%pack == "Laptop")
	{
		centerprint(%clientId, "<f2>LapTop: backpackable command station\nSpy Armor: also uses it to touch-hack turrets and to intercept even encrypted enemy chat.\nRecon Armor: also uses it to locate enemy items.", 10);
	}
	else if (%pack == "LeechPack")
	{
		centerprint(%clientId, "<f2>The Leech Pack can leech life from enemy items to repair yourself and deal damage simultaneously.  It also can power freindly items.", 10);
	}
	else if (%pack == "FgcPack")
	{
		centerprint(%clientId, "<f2>Containment Pack: contains nuclear material.\nDreadnaught: mounts the Tactical Nuke Launcher when activated.\Goliath: establishes a nuclear generator, or activated for explosive results.", 10);
	}
	else if (%pack == "MechPack")
	{
		centerprint(%clientId, "<f2>Interceptor Pack: a deployable ultralight flier.", 10);
	}
	else if (%pack == "RepairPack")
	{
		centerprint(%clientId, "<f2>Repair Pack: gives you the ability to repair items and other players.", 10);
	}
	else if (%pack == "SensorJammerPack")
	{
		centerprint(%clientId, "<f2>Sensor Jammer: will dampen your sensor signal with in a certain radius.", 10);
	}
	else if (%pack == "ShieldPack")
	{
		centerprint(%clientId, "<f2>Shield Pack: will convert your energy into shielding to resist damage.", 10);
	}
	else if (%pack == "StealthShieldPack")
	{
		centerprint(%clientId, "<f2>Stealth Shield: will hide you from turrets and locking missles.", 10);
	}
	else if (%pack == "WarpPack")
	{
		centerprint(%clientId, "<f2>Warp Pack: can be set (see [tab] menu) to warp the player thru walls forward, up, or down (sometimes at a price).", 10);
	}
	else BuilderPack(%clientId,%pack);
}

function BuilderPack(%clientId,%pack)
{
	if (%pack == "LightningPack")
	{
		centerprint(%clientId, "<f2>Teleport Pack: teleports you to your telebeacon, which you drop the first time you use it.", 10);
	}
	else if (%pack == "DeployableInvPack")
	{
		centerprint(%clientId, "<f2>Inventroy Station: Deploys an Inventory Station.", 10);
	}
	else if (%pack == "DeployableAmmoPack")
	{
		centerprint(%clientId, "<f2>Ammo Station: Deploys an Ammo Station.", 10);
	}
	else if (%pack == "MotionSensorPack")
	{
		centerprint(%clientId, "<f2>Motion Sensor: allows your turrets to see targets that are cloaked or shielded by sensor surpression", 10);
	}
	else if (%pack == "PulseSensorPack")
	{
		centerprint(%clientId, "<f2>Pulse Sensor: is a deployable version of the Base Pulse Sensors.", 10);
	}
	else if (%pack == "DeployableSensorJammerPack")
	{
		centerprint(%clientId, "<f2>Sensor Jammer: jams nearby enemy pulse sensors.", 10);
	}
	else if (%pack == "DeployableComPack")
	{
		centerprint(%clientId, "<f2>Command Staion: Deploys an Ammo Station.", 10);
	}
	else if (%pack == "ForceFieldPack" || %pack == "LargeForceFieldPack")
	{
		centerprint(%clientId, "<f2>Force Field: deployable transparent barrier.", 10);
	}
	else if (%pack == "TeleportPack")
	{
		centerprint(%clientId, "<f2>Teleport Pad: transports players between them.", 10);
	}
	else if (%pack == "BlastWallPack")
	{
		centerprint(%clientId, "<f2>Blast Wall: a defensive barrier.", 10);
	}
	else if (%pack == "TreePack")
	{
		centerprint(%clientId, "<f2>Poison Oak: is carniverous tree for natural defenses.", 10);
	}
	else if (%pack == "HoloPack")
	{
		centerprint(%clientId, "<f2>The HoloGram is just that, a Holo of a friendly player.", 10);
	}
	else if (%pack == "PlantPack")
	{
		centerprint(%clientId, "<f2>Healing Plant: has a healing touch.", 10);
	}
	else if (%pack == "LaunchPack")
	{
		centerprint(%clientId, "<f2>Launch Pad: is a small spring platform.", 10);
	}
	else if (%pack == "BlastFloorPack")
	{
		centerprint(%clientId, "<f2>Blast Floor: can seal openings and serve as a base to build items upon.", 10);
	}
	else if (%pack == "ReconPack")
	{
		centerprint(%clientId, "<f2>Chat Encryptor: will scramble your team's chat so enemy Antennas can't intercept your private messages.", 10);
	}
	else if (%pack == "SeedPack")
	{
		centerprint(%clientId, "<f2>SeedPack: plants a variety of poisonous cacti.", 10);
	}
	else if (%pack == "EmergencyInvPack")
	{
		centerprint(%clientId, "<f2>Emergency Inventory: cannot be destroyed or hacked, and is best when deployed BEFORE your base is wrecked.", 10);
	}
	else if (%pack == "TrapPack1")
	{
		centerprint(%clientId, "<f2>Punji Spike Trap: will impale the victim and hold them in place.", 10);
	}
	else if (%pack == "TrapPack2")
	{
		centerprint(%clientId, "<f2>Morph Trap: will alter your enemy in undesirable ways.", 10);
	}
	else if (%pack == "TrapPack3")
	{
		centerprint(%clientId, "<f2>Scary Trap: will frighten the Bajeebee's out of opponents.", 10);
	}
	else if (%pack == "TrapPack4")
	{
		centerprint(%clientId, "<f2>Quicksand: will send the enemy underground.", 10);
	}
	else if (%pack == "HolePack")
	{
		centerprint(%clientId, "<f2>Portable Hole: allows players to step thru it and walk through walls.", 10);
	}
	else if (%pack == "ElectricWeb" || %pack == "ElectricFloor")
	{
		centerprint(%clientId, "<f2>Webs: allow teammates to pass, but will entangle the enemy, leaving their belongings hanging.", 10);
	}
	else if (%pack == "Elevator")
	{
		centerprint(%clientId, "<f2>Elevtator: Helps get heavies back up to the base, even through base floors.", 10);
	}
	else if (%pack == "LargeShockForceFieldPack" || %pack == "ShockFloorPack")
	{
		centerprint(%clientId, "<f2>Shock Force Field: an electrified force field, which spys can't open.", 10);
	}
	else if (%pack == "CoolLauncher")
	{
		centerprint(%clientId, "<f2>Missle Control Station: must be loaded with a missle to do its thing.", 10);
	}
	else if (%pack == "ShieldBeaconPack")
	{
		centerprint(%clientId, "<f2>Missile Defense Beacon: creates a bubble of defense against incoming missles.", 10);
	}
	else if (%pack == "InveiglerPack")
	{
		centerprint(%clientId, "<f2>Inveigler: flies to its victim, and either spits a poisonous dart, or can possess their body upon contact.", 10);
	}
	else if (%pack == "SkyEyePack")
	{
		centerprint(%clientId, "<f2>SkyEye Satellite: uplink will reveal the entire map to your team.", 10);
	}
	else if (%pack == "AntennaPack")
	{
		centerprint(%clientId, "<f2>AntennaPack: will intercept enemy transmissions (if they aren't scrambling their messages with the Encryptor).", 10);
	}
	else if (%pack == "TrapPack5")
	{
		centerprint(%clientId, "<f2>Stun Trap: momentarily stuns its target.", 10);
	}
	else if (%pack == "TrapPack6")
	{
		centerprint(%clientId, "<f2>Energy Snare: will encase and crush its victim if they don't kill its power-source in time.", 10);
	}
	else if (%pack == "BalloonPack")
	{
		centerprint(%clientId, "<f2>Zepplin and Parachute: can be set (see [tab] menu) for rising, hovering, or parachuting.", 10);
	}
	else if (%pack == "ZepplinPack")
	{
		centerprint(%clientId, "<f2>Zepplin Pad: will equip your teammates with a Parachute or a Zepplin depending upon it's setting (see [tab] menu).", 10);
	}
	else if (%pack == "MagBridgePack")
	{
		centerprint(%clientId, "<f2>Magneto Bridge: once deployed, will stay with you while you run across the sky.", 10);
	}
	else if (%pack == "SwitchPack")
	{
		centerprint(%clientId, "<f2>Base Control Switch: when laid near an enemy power source, will insert its control over the entire base's network.", 10);
	}
	else if (%pack == "LockOutPack")
	{
		centerprint(%clientId, "<f2>Switch Security System: will lock a nearby switch's network, so the enemy cannot capture it.", 10);
	}
	else TurretHelp(%clientId, %pack);
}

function TurretHelp(%clientId,%pack)
{
	if (%pack == "LaserPack") centerprint(%clientId, "Deployable Laser Turret:<f2> is the pinacle of turrets, they can be attached to nearly any surface for devistating results.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "ShockPack") centerprint(%clientId, "EMP turret:<f2> will drop an EMP blasting shell that will knock out a target's energy and shields.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "TargetPack") centerprint(%clientId, "Mortar turret:<f2> can be deployed but will only fire when it is being commanded.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "CameraPack") centerprint(%clientId, "Dart Turret:<f2> blows poison darts.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "TurretPack") centerprint(%clientId, "Ion Turret:<f2> fires Ion Bolts.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "PlasmaTurretPack") centerprint(%clientId, "Deployable Plasma Turret:<f2> basic area defense.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "RocketPack") centerprint(%clientId, "Deployable Rocket Turret:<f2> a smaller version of the large base rocket turret.\n<f1>Sensor:<f2> thrusters.", 10);
	else if (%pack == "Sentry") centerprint(%clientId, "Sentry:<f2> requires a jail to put its prisoners into.\n<f1>Sensor:<f2> motion.", 10);
	else if (%pack == "RailTurretPack") centerprint(%clientId, "Rail Turret: the sniper among turrets.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "FlameTurretPack") centerprint(%clientId, "Flame Turret:<f2> is for the pyro in us all.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "ConPack") centerprint(%clientId, "Concussion Turret:<f2> will blow the enemy away... far away.\n<f1>Sensor:<f2> motion", 10);
	else if (%pack == "ChaingunTurretPack") centerprint(%clientId, "Target Acquision Turret: will point out those intruders as far as the eye can see.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "VulcanTurretPack") centerprint(%clientId, "<f2>Vulcan Turret:<f2> a close range but massively lethal defender.\n<f1>Sensor:<f2> pulse.", 10);
	else if (%pack == "FlakPack") centerprint(%clientId, "Flak Turret:<f2> fires upon aircraft and jetting players, and is best laid outdoors.\n<f1>Sensor:<f2> thrust.", 10);
	else centerprint(%clientId, "<f2>Your " @ %pack @ " pack is unrecognized.", 10);
}
