function ThrowTwig(%this,%object)
{
	%obj = newObject("","Item","Themrtwig",1,false);
	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%object,15,false);
	gamebase::setposition(%obj, vector::add(gamebase::getposition(%this), "0 0 15"));
	echo(%obj@"  - "@gamebase::getposition(%obj));
}
function TreeShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	echo(getObjectType(%object));
	//if(getObjectType(%object) == "Player")
	//{
		%object.TreeSlayer++;
	//}
	if(%object.TreeSlayer > 10)
	{
		ThrowTwig(%this, %object);
	}
}
function TreeShape::onDestroyed(%this)
{
	if(getObjectType(%this.lastDamageObject) == "Player")
	{
		%this.TreeSlayer++;
	}
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $ShrapnelDamageType, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
		0.0, 0.0, 0.0);
}
function TreeShapeTwo::onDestroyed(%this)
{
	if(getObjectType(%this.lastDamageObject) == "Player")
	{
		%this.TreeSlayer++;
	}
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $ShrapnelDamageType, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
		0.0, 0.0, 0.0);
}
function TeamDuelSpawn(%clientId, %spot)
{
	Score::ResetRoundStats(%clientId);
	%zit = Client::getOwnedObject(%clientId);
	if(isobject(%zit))
	{
		deleteobject(%zit);
		$Roaming[%clientId] = false;

	}

	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TeamDuelSpawn);
	}
	if($Dueling[%clientId])
	{
		Client::onKilled(%clientId, %clientId, 1);
	}
	if(Client::getGender(%clientId) == "Female")
	{
		%armor = "lfemale";
	}
	else
	{
		%armor = "larmor";
	}
	if($ArmorToggle && $TeamDuel::Arena[%clientId.Team] == "None" || $TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team])
	{
		if($TeamDuel::Armor[%clientId.Team] == "Player's Choice")
		{
			%armor = $DuelRealArmor[%clientId.armor];
		}
		else
		{
			%armor = $TeamDuel::Armor[%clientId.Team];
		}
		if(%armor == "larmor")
		{
			if (Client::getGender(%clientId) == "Female")
			{
				%armor = "lfemale";
			}
		}
		if(%armor == "marmor")
		{
			if(Client::getGender(%clientId) == "Female")
			{
				%armor = "mfemale";
			}
		}
	}
	%rot = "0 0 0";
	if($TeamDuel::Spawn[%clientId.Team, %spot] == "")
	{
		%spot = 1;
		if($TeamDuel::Spawn[%clientId.Team, %spot] == "")
		{
			%spot = 2;
		}
	}
	$TeamDuel::SpawnRot[%clientId.Team, %spot] = "0 0 "@getword($TeamDuel::SpawnRot[%clientId.Team, %spot], 2);
	%pl = spawnPlayer(%armor, $TeamDuel::Spawn[%clientId.Team, %spot], $TeamDuel::SpawnRot[%clientId.Team, %spot]);
	%pl.owner = %clientId;
	Gamebase::setMapName(%pl,"ArenaGuy");
	while($TeamDuel::Spawn[%clientId.Team, %spot] == "" || $TeamDuel::Spawn[%clientId.Team, %spot] == "-1 -1 -1")
	{
		%spot++;
	}
	gamebase::setposition(%pl, $TeamDuel::Spawn[%clientId.Team, %spot]);
	//messageall(0, $TeamDuel::Spawn[%clientId.Team, %spot] @" "@ $TeamDuel::SpawnRot[%clientId.Team]);
	if(%pl != -1)
	{
	   Client::setOwnedObject(%clientId, %pl);
	   Client::setSkin(%clientId, $Client::info[%clientId, 0]);
		if($TeamDuel::Skin[%clientId.Team] != "")
		{
			Client::setSkin(%clientId, $TeamDuel::Skin[%clientId.Team]);

		}

		if($TeamDuel::Arena[%clientId.Team] == "None" && $TeamDuel::Packs[%clientId.Team] == "Player's Choice" || $TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team])
		{
			%pack = $DuelRealPack[%clientId.pack];
			Player::SetItemCount(%clientId, %pack, 1);
			Player::UseItem(%clientId, %pack);
		}
		if($TeamDuel::Packs[%clientId.Team] != "Player's Choice" && $TeamDuel::Arena[%clientId.Team] == "None" || $TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team] && $TeamDuel::Packs[%clientId.Team] != "Player's Choice")
		{
			if($TeamDuel::Packs[%clientId.Team] == "None")
			{
				%pack = "";
			}
			if($TeamDuel::Packs[%clientId.Team] == "Energy")
			{
				%pack = "EnergyPack";
			}
			if($TeamDuel::Packs[%clientId.Team] == "Repair")
			{
				%pack = "RepairPack";
			}
			if($TeamDuel::Packs[%clientId.Team] == "Ammo")
			{
				%pack = "AmmoPack";
			}
			if($TeamDuel::Packs[%clientId.Team] == "Shield")
			{
				%pack = "ShieldPack";
			}
			if(%pack != "")
			{
				Player::SetItemCount(%clientId, %pack, 1);
				Player::UseItem(%clientId, %pack);
			}
		}
		if($TeamDuel::Arena[%clientId.Team] == "None" && $TeamDuel::Weapons[%clientId.Team] == "Player's Choice" || $TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team] && $TeamDuel::Weapons[%clientId.Team] == "Player's Choice")
		{
			Player::AssignLoadout(%clientId);

				if($TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team] == "false")
				{
					Game::playerSpawned(%pl, %clientId, %armor);
				}
			%clientId.Owns = %pl;
			%clientId.DM = false;

			resetLOS();
			%distance = "1000";
			//%rot = "1.57 0 0";
			//GameBase::getLOSInfo(%pl, %distance, %rot);
			%rot = "-1.57 0 0";
			GameBase::getLOSInfo(%pl, %distance, %rot);

			if($los::position != "")
			{
				gamebase::setposition(%pl, $los::position);
			}
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
				if (Client::GetTeam(%cl) == -1) {
					if (%cl.observerTarget == %clientId)
						Observer::setTargetClient(%cl, %clientId);
				}
			}
			%pl.StartCode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl);
			return %pl;
		}
		if($TeamDuel::Arena[%clientId.Team] == "None" || $TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team])
		{
			if($TeamDuel::Weapons[%clientId.Team] != "Blaster")
			{
				if($TeamDuel::Mines[%clientId.Team] == "On" && $TeamDuel::Arena[%clientId.Team] == "None")
				{
					Player::SetItemCount(%clientId, MineAmmo, 3);
				}
				Player::SetItemCount(%clientId, Grenade, 5);
			}

			if(Player::getItemCount(%clientId,"AmmoPack") == 1)
			{
				Player::setItemCount(%clientId, Beacon, ($AmmoPackMax[Beacon] + $ItemMax[larmor, Beacon]));
				if($TeamDuel::Weapons[%clientId.Team] != "DiscOnly")
				{
					Player::setItemCount(%clientId, Grenade, ($AmmoPackMax[Grenade] + $ItemMax[larmor, Grenade]));
				}
			}
		}
		if($TeamDuel::Arena[%clientId.Team] == "None" && $TeamDuel::Weapons[%clientId.Team] != "Player's Choice" || $TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team])
		{
			$TeamDuel::Weapon[%clientId.Team, 1] = "";
			$TeamDuel::Weapon[%clientId.Team, 2] = "";
			$TeamDuel::Weapon[%clientId.Team, 3] = "";

			if($TeamDuel::Weapons[%clientId.Team] == "Custom")
			{
				$TeamDuel::Weapon[%clientId.Team, 1] = $DuelRealWeapon[gw($TeamDuel::CustomWeapons[%clientId.Team, 0], 0)];    //$TeamDuel::CustomWeapons[%clientId.Team, %extra2]
				$TeamDuel::Weapon[%clientId.Team, 2] = $DuelRealWeapon[gw($TeamDuel::CustomWeapons[%clientId.Team, 1], 0)];
				$TeamDuel::Weapon[%clientId.Team, 3] = $DuelRealWeapon[gw($TeamDuel::CustomWeapons[%clientId.Team, 2], 0)];
			}

			if($TeamDuel::Weapons[%clientId.Team] == "DPN")
			{
				$TeamDuel::Weapon[%clientId.Team, 1] = "DiscLauncher";
				$TeamDuel::Weapon[%clientId.Team, 2] = "PlasmaGun";
				$TeamDuel::Weapon[%clientId.Team, 3] = "GrenadeLauncher";
			}
			if($TeamDuel::Weapons[%clientId.Team] == "DCN")
			{
				$TeamDuel::Weapon[%clientId.Team, 1] = "DiscLauncher";
				$TeamDuel::Weapon[%clientId.Team, 2] = "ChainGun";
				$TeamDuel::Weapon[%clientId.Team, 3] = "GrenadeLauncher";
			}
			if($TeamDuel::Weapons[%clientId.Team] == "DEN")
			{
				$TeamDuel::Weapon[%clientId.Team, 1] = "DiscLauncher";
				$TeamDuel::Weapon[%clientId.Team, 2] = "EnergyRifle";
				$TeamDuel::Weapon[%clientId.Team, 3] = "GrenadeLauncher";
			}
			if($TeamDuel::Weapons[%clientId.Team] == "DLN")
			{
				$TeamDuel::Weapon[%clientId.Team, 1] = "DiscLauncher";
				$TeamDuel::Weapon[%clientId.Team, 2] = "LaserRifle";
				$TeamDuel::Weapon[%clientId.Team, 3] = "GrenadeLauncher";
			}
			if($TeamDuel::Weapons[%clientId.Team] == "DiscOnly")
			{
				$TeamDuel::Weapon[%clientId.Team, 1] = "DiscLauncher";
				$TeamDuel::Weapon[%clientId.Team, 2] = "";
				$TeamDuel::Weapon[%clientId.Team, 3] = "";
			}
			for(%i = 1; %i < 4; %i++)
			{
				%name = $TeamDuel::Weapon[%clientId.Team, %i];
				if(%name != "")
				{

					if(%name == "DiscLauncher" && %clientId.isKing || %name == "DiscLauncher" && %clientId.customweap != "")
					{
						Player::AssignCustomWeapon(%clientId);
					}
					else
					{
						Player::SetItemCount(%clientId, %name, 1);
					}
					%player = Client::getOwnedObject(%clientId);
					%armor = Player::getArmor(%player);
					%ammo = %name.imageType.ammoType;
					if(%ammo != "")
					{
						%ammoAmount = $ItemMax[%armor, %ammo];
						if($TeamDuel::Weapons[%clientId.Team] == "Custom")
						{
							%ammoAmount = %ammoAmount * gw($TeamDuel::CustomWeapons[%clientId.Team, %i-1], 1) ;
							//both("Ammo adjust to "@%ammoAmount@" for "@$TeamDuel::Weapon[%clientId.Team, %i]);
						}
						if($TeamDuel::Weapons[%clientId.Team] == "DiscOnly")
						{
							%ammoAmount=666;
						}
						if(Player::getItemCount(%clientId,"AmmoPack") == 1)
						{
							%ammoAmount = ($AmmoPackMax[%ammo] + $ItemMax[%armor, %ammo]) ;
							Player::setItemCount(%clientId, Beacon, ($AmmoPackMax[Beacon] + $ItemMax[larmor, Beacon]));
							if($TeamDuel::Weapons[%clientId.Team] != "DiscOnly")
							{
								Player::setItemCount(%clientId, Grenade, ($AmmoPackMax[Grenade] + $ItemMax[larmor, Grenade]));
							}
						}
						Player::setItemCount(%clientId, %ammo, %ammoAmount);
					}
				}
			}
			if(%clientId.isKing || %clientId.customweap != "")
			{
				Player::useItem(%clientId,%clientId.customweap);
			}
			else
			{
				echo($DuelRealWeapon[%clientId.weapon[0]]);
				Player::UseItem(%clientId, $TeamDuel::Weapon[%clientId.Team, 1]);
			}

		}
		if($TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team] == "false")
		{
			Game::playerSpawned(%pl, %clientId, %armor);
		}
	}
	%clientId.Owns = %pl;
	%clientId.DM = false;

	resetLOS();
	%distance = "400";
	%rot = "-1.57 0 0";
	GameBase::getLOSInfo(%pl, %distance, %rot);
	if($los::position != "")
	{
		gamebase::setposition(%pl, $los::position);
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if (Client::GetTeam(%cl) == -1) {
			if (%cl.observerTarget == %clientId)
				Observer::setTargetClient(%cl, %clientId);
		}
	}
	Player::SetItemCount(%clientId, Beacon, 3);
	Player::SetItemCount(%clientId, RepairKit,1);
	Player::SetItemCount(%clientId, TargetingLaser,1);

	%pl.StartCode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl);
return %pl;
}


function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if(%client.awesome)
	{
		remoteSay(%client, 0, "#makemarker");
		return;
	}
	if(%client.thrown)
	{
		echo("rep remote activated");
		Flaggy::Detonate(%client);
		return;
	}

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else {
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}


function Backpack::onUse(%player,%item)
{
	//echo(hey);

	%cl = player::getclient(%player);
	if(%cl.thrown)
	{
		Flaggy::Detonate(%cl);
	}
	if(%cl.awesome)
	{
		remoteSay(%cl, 0, "#makemarker");
		return;
	}
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
}

function Game::onPlayerConnected(%client)
{
	%client.justConnected = true;
	$menuMode[%client] = "None";

	//Duel Variable Resets...
	$Dueling[%client] = "";
	$DuelLineup[%client] = "";
	$DuelLastEnemy[%client] = "";
	$DuelBest[%client] = 9999;
	$DuelBestDisplay[%client] = "00:00";//need to replace
	$Roaming[%client] = false;

	//Prefs, Not Saved
	$SpeedDuel[%client] = "False";
	$DuelarmorType[%client] = "larmor";
	%client.MovementType = "Free Move";
	%client.guiLock = false;
	%client.Team = "";
	%client.canjump = true;
	%client.cantrigger = true;
	%client.debug = "";

	//prefs saved...
	Client::PrefDefaults(%client);

	Game::refreshClientScore(%client);
}

function listplayers()
{
	echo(getNumClients() @" Clients");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%status = GetPlayType(%cl);
		eval( "%kills = %cl." @ %status @ "scoreKills;");
		eval( "%deaths = %cl." @ %status @ "scoreDeaths;");
		echo(%cl@": "@client::getname(%cl)@" Playing: "@%status@" - "@%kills@"/"@%deaths @" - Admin: "@%cl.isSuperAdmin@" "@client::getTransportAddress(%cl));
	}
}
function remoteToggleCommandMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		Client::setGuiMode(%clientId, $GuiModePlay);
}

function remoteToggleInventoryMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else
		Client::setGuiMode(%clientId, $GuiModePlay);
}

function remoteToggleObjectivesMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		Client::setGuiMode(%clientId, $GuiModePlay);
}
function remoteObjectivesMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeObjectives);
   }
}
function remoteCommandMode(%clientId)
{
   // can't switch to command mode while a server menu is up
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
   }
}

function remoteInventoryMode(%clientId)
{
   if(!%clientId.guiLock)// && !Observer::isObserver(%clientId))
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeInventory);
   }
}
function remoteVoteYes(%clientId)
{
	if(%clientId.followsuit != "")
	{
		%option = getword(%clientId.followsuit, 0)@" "@getword(%clientId.followsuit, 1) ;
		processMenummisc(%clientId, %option);
		%clientId.followsuit = "";
	}
	if($Winners::Wants[%clientId] && %clientId.Team == "" && $Winners::On[%clientId] == "")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if($Winners::Requesting[%cl] && GetWord($Winners::RequestingID[%cl], 0) == %clientId || $Winners::Requesting[%cl] && GetWord($Winners::RequestingID[%cl], 1) == %clientId)
			{
			   if($Dueling[%clientId])
			   {
				   %other = $Dueling[%clientId];
			   }
			   else if(!$Dueling[%clientId] && $DuelLastEnemy[%clientId] != "" && $DuelLineup[%clientId] != $DuelLastEnemy[%clientId] && %clientId.Team == "")
			   {
				   %other = $DuelLastEnemy[%clientId] ;
			   }
			   else {
				   return;
				   //echo("failed");
			   }
			   %target = %cl;
			   $Winners::On[%clientId] = true;
			   $Winners::On[%other] = true;
			   client::sendmessage(%other, $Green, client::getname(%clientId)@" has enabled winners with you."@$beep);

			//	if($Winners::On[%other])
			//	{
					$SpeedDuel[%other] = "False";
					$SpeedDuel[%target] = "False";
					$SpeedDuel[%clientId] = "False";
					$Winners::On[%target] = true;
					$Winners::List[%clientId] = %clientId@" "@%target@" "@%other;
					$Winners::List[%target] = %clientId@" "@%target@" "@%other;
					$Winners::List[%other] = %clientId@" "@%target@" "@%other;
					$Winners::Wants[%clientId] = "";
					$Winners::Wants[%other] = "";
					$Winners::Requesting[%target] = "";
					client::sendmessage(%target, $white, "You are now playing winners mode with "@client::getname(%clientId)@" and "@client::getname(%other));
					client::sendmessage(%clientId, $white, "You are now playing winners mode with "@client::getname(%target)@" and "@client::getname(%other));
					client::sendmessage(%other, $white, "You are now playing winners mode with "@client::getname(%clientId)@" and "@client::getname(%target));
					//both("Winners list : "@$Winners::List[%clientId]);
			//	}
				break;
			}
		}
	}
	%clientId.LastAction = floor(getSimTime());
   centerprint(%clientId, "", 0);
   if($curVoteTopic != "")
   {
	   %clientId.vote = "yes";
   }

}

function remoteVoteNo(%clientId)
{
	%clientId.LastAction = floor(getSimTime());
   centerprint(%clientId, "", 0);
   if($curVoteTopic != "")
   {
	   %clientId.vote = "no";
   }

}
function ClearMines(%clientId) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(ClearMines);
	}
	if ($DuelMine1[%clientId] != "" && isObject($DuelMine1[%clientId])) {
		if (GameBase::getDataName(%object) == "AntipersonelMine")
			GameBase::setDamageLevel($DuelMine1[%clientId], 2);
		$DuelMine1[%clientId] = "";
	}
	if ($DuelMine2[%clientId] != "" && isObject($DuelMine2[%clientId])) {
		if (GameBase::getDataName(%object) == "AntipersonelMine")
			GameBase::setDamageLevel($DuelMine2[%clientId], 2);
		$DuelMine2[%clientId] = "";
	}
	if ($DuelMine3[%clientId] != "" && isObject($DuelMine3[%clientId])) {
		if (GameBase::getDataName(%object) == "AntipersonelMine")
			GameBase::setDamageLevel($DuelMine3[%clientId], 2);
		$DuelMine3[%clientId] = "";
	}
}

function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		Game::menuRequest(%clientId);

		if(%selId.Team == "" && %clientId.selClient.private == "")
		{
			remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
			remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
			remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
			remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
			remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
			remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
		}
		else {
			if(%clientId.Team != %selId.Team && %clientId.selClient.private == "")
			{
				remoteEval(%clientId, "setInfoLine", 1, $TeamDuel::Name[%selId.Team]@" Stats");
				remoteEval(%clientId, "setInfoLine", 2, $TeamDuel::Line2[%selId.Team]);
				remoteEval(%clientId, "setInfoLine", 3, $TeamDuel::Line3[%selId.Team]);
				remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
				remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
				remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
			}
		}
	}
}
function setObsOrbit(%c, %t, %x, %y, %z)
{
	echo(setobsorbit);
	if(%c.dm) {   return;	}
	Client::setGuiMode(%c, $GuiModePlay);
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(setObsOrbit);
	}
	%c.observertarget = %t;
	%extramsg = "";
	if(%c.Team != "" && %t.Team != "" && %c.Team == %t.Team)
	{
		%extramsg = "<F1>";
	}
	if(%c.Team != "" && %t.Team != "" && %c.Team != %t.Team  && $TeamDuel::Challenging[%c.Team] == %t.Team)
	{
		%extramsg = "<F0>";
	}
	%msg = "";
//	both("msg... "@%msg);
	if(%t.team != "" && %t.isalive == "True")
	{
		//both("msg... "@%msg@" hits... "@%t.ThisRoundTotalHitsDone);
		if(%t.ThisRoundTotalHitsDone > 0)
		{

			%msg = " \n<F2>Hits:<F3> "@%t.ThisRoundTotalHitsDone@" <F2>Damage: <F3>"@MyRound(%t.ThisRoundTotalDamageDone);
			//both("msg... "@%msg);
			if(%t.ThisRoundTotalMidAirs > 0)
			{
				%msg = %msg@" <F2>Midairs: <F3>"@%t.ThisRoundTotalMidAirs;
			}
		}
	}
   	bottomprint(%c, "<jc><F2>Observing "@%extramsg@"" @ Client::getName(%t) @ "."@%msg, 5);
   	bottomprint(%t, "<jc><F2>Being Observed by<F2> " @ GetObservedList(%t), 5);
	%pl = Client::getOwnedObject(%t);
	%newcode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl) ;
	if(%t.team == %c.team && %newcode == %pl.StartCode)
	{
		//client::sendmessage(%c, $Green, client::getname(%t) @" is idle! You may take control via the tab menu!");
	}
	if(%c.prefs["obsmode"] == "1stPerson")
	{
		Observer::setOrbitObject(%c, %t, -1, -1, -1);
		Client::setControlObject(%c, Client::getObserverCamera(%c));
		return;
	}
	if(%c.prefs["obsmode"] == "Fixed")
	{
		Observer::setOrbitObject(%c, %t, -5, -5, -5);
		Client::setControlObject(%c, Client::getObserverCamera(%c));
		return;
	}
	if(%c.prefs["obsmode"] == "Free")
	{
		Observer::setOrbitObject(%c, %t, 5, 5, 5);
		Client::setControlObject(%c, Client::getObserverCamera(%c));
		return;
	}
	Observer::setOrbitObject(%c, %t, %x, %y, %z);
	Client::setControlObject(%c, Client::getObserverCamera(%c));
}
function Game::refreshClientScore(%clientId) {
	%star = " ";
	%team = %clientId.Team + 0 ;
	%flag = "TD ("@%clientId.Team@")";
	%playtype = GetPlayType(%clientId);
	//%scorestring = %clientId.


	// %killerId.score++;


	if(GetPlayType(%clientId) != "")
	{
		%scorestr = %clientId.score[%playtype, "scoreKillsTotal"];
		%deathstr = %clientId.score[%playtype, "scoreDeathsTotal"];
		//eval( "%scorestr = %clientId." @ %scorestr @ ";");
		//eval( "%deathstr = %clientId." @ %deathstr @ ";");
		%fullstr = %scorestr@"/"@%deathstr ;
	}
	else {
		%scorestr = %clientId.score ;
		%deathstr = %clientId.scoreDeaths ;
		%fullstr = %scorestr@"/"@%deathstr ;
	}

	if($Dueling[%clientId] == "false" && %clientId.Team == "" || $Dueling[%clientId] == "" && %clientId.Team == "" )
	{
		%team = 1000;
		%flag = "Observer";
		if(%clientId.DM)
		{
			%team = %team-100 ;
			%flag = "DeathMatch";
			if($FlagHunter::Master)
			{
				%flag = "Hunter";
				%fullstr = %clientId.score ;
			}
		}
	}
	if($Dueling[%clientId])
	{
		%team = floor((($Dueling[%clientId] + $Dueling[$Dueling[%clientId]]) / 100) + 0.5) ;
		%flag = "Duel";
	}
	if(%clientId.prefs["DuelModeOff"] && %clientId.Team == "")
	{
		%flag = "Duels Off";
		%team = 5;
	}
	if($TeamDuel::Leader[%clientId.Team] == %clientId && %clientId.Team != "")
	{
		%flag = "TD ("@%clientId.Team@")+";
	}
   if(%clientId.IsAlive == "True")
   {
	   %team = Vector::neg(%team);
	   %star = "*";
   }
	%time = Time::getMinutes((floor(getSimTime()) - %clientId.LastAction));
	if(%time > 0)
	{
		%team = ((%team*2) + (%time *2))+19 ;
		%flag = "[Idle "@%time@"]";
	}
	//echo(%fullstr);
	if(%clientId.private)
	{
		Client::setScore(%clientId, "", -1000);
	}
	else
	{
		if(%clientId.smurfin)
		{
		 	Client::setScore(%clientId, %star @" %n\t" @ %flag @ "\t" @ %fullstr @ "\t420\t%l", %team);
	 	}
	 	else
	 	{
			Client::setScore(%clientId, %star @" %n\t" @ %flag @ "\t" @ %fullstr @ "\t%p\t%l", %team);
		}
 	}
   //DuelMOD::missionObjectives();
}
function remoteKill(%client)
{
	%clientId.LastAction = floor(getSimTime());
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(remoteKill);
	}

	if(!$matchStarted)
	return;

	if(%client.Team != "" && $TeamDuel::CanHurt[%client.Team] == "True" ||%client.DM && !$DeathMatch::CountDown)
	{
		%player = Client::getOwnedObject(%client);
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
		{
			playNextAnim(%client);
			Player::kill(%client);
			Client::onKilled(%client,%client);
		}
	}
}
function Player::onKilled(%this) {
	echo("Player::onKilled");

	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Player::onKilled);
	}


       %cl = GameBase::getOwnerClient(%this);
       %cl.IsAlive = "";
       %cl.dead = 1;

       Player::setDamageFlash(%this,0.75);

		playNextAnim(%cl);

	if(%cl.DM && $FlagHunter::Master)
	{
		echo(thanks);
		FlagHunter::onDrop(%this, unused);
	}


	for (%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1)
		{
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2")
			Player::dropItem(%this,%type);
		}
	}

  if(%cl != -1)
  {
	   if(%this.vehicle != "")
	   {
		   if(%this.driver != "")
		   {
				%this.driver = "";
		   		Client::setControlObject(Player::getClient(%this), %this);
		   		Player::setMountObject(%this, -1, 0);
		   }
		   else
		   {
				   %this.vehicle.Seat[%this.vehicleSlot-2] = "";
				   %this.vehicleSlot = "";
		   }
		   %this.vehicle = "";
   		}
	   $timee = 0.2;
	   %corpsetime = 2;
	   if(%cl.Team != "" || %cl.DM)
	   {
		   %corpsetime = 20;
	   }
         schedule("GameBase::startFadeOut(" @ %this @ ");", %corpsetime, %this);
     Client::setOwnedObject(%cl, -1);
     Client::setControlObject(%cl, Client::getObserverCamera(%cl));
     Observer::setOrbitObject(%cl, %this, 5, 5, 5);
     schedule("deleteObject(" @ %this @ ");", %corpsetime+1, %this);
     %cl.observerMode = "dead";
     %cl.dieTime = getSimTime();
  }
  else
{
  	echo("BAD CL");
}
}
function remoteNextWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
		selectValidWeapon(%client);
	else {
		for (%weapon = $NextWeapon[%item]; %weapon != %item;
				%weapon = $NextWeapon[%weapon]) {
			if (isSelectableWeapon(%client,%weapon)) {
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
}

function remotePrevWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $PrevWeapon[%item] == "")
		selectValidWeapon(%client);
	else {
		for (%weapon = $PrevWeapon[%item]; %weapon != %item;
				%weapon = $PrevWeapon[%weapon]) {
			if (isSelectableWeapon(%client,%weapon)) {
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at leas				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
}


//going to try base item.cs
//function selectValidWeapon(%client)
//{
//	%item = EnergyRifle;
//	for (%weapon = $NextWeapon[%item]; %weapon != %item;
//			%weapon = $NextWeapon[%weapon]) {
//		if (isSelectableWeapon(%client,%weapon)) {
//			Player::useItem(%client,%weapon);
//			break;
//		}
//	}
//}

//function isSelectableWeapon(%client,%weapon)
//{
//	if (Player::getItemCount(%client,%weapon)) {
//		%ammo = $WeaponAmmo[%weapon];
//		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
//			return true;
//	}
//	return false;
//}
function Game::playerSpawned(%pl, %clientId, %armor)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Game::playerSpawned);
	}

	if($TeamDuel::Arena[%clientId.Team] != "None" && %clientId.Team != "")
	{
		%clientId.spawn= 1;
		%max = getNumItems();
	   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
	   {
			buyItem(%clientId,%item);
			if(%item.className == Weapon)
				%clientId.spawnWeapon = %item;
		}
		%clientId.spawn= "";
		if(%clientId.spawnWeapon != "") {
			Player::useItem(%pl,%clientId.spawnWeapon);
		%clientId.spawnWeapon="";
		}
	}
		%angle = "-1.57 0 0";
		GameBase::getLOSinfo(%pl, 9000, %angle);
		gamebase::setposition(%pl, $los::position);
}
function Projectile::onCollision(%this,%object)
{
	//both("DiscShell "@%this@" "@%object);
}
function SimProjectile::onCollision(%this,%object)
{
	//both("DiscShell "@%this@" "@%object);
}
function SimProjectileObject::onCollision(%this,%object)
{
	//both("DiscShell "@%this@" "@%object);
}
function DiscShell::onCollision(%this,%object)
{
	//both("DiscShell "@%this@" "@%object);
}
function RocketData::onCollision(%this,%object,%other1,%other2,%other3)
{
	//both("This:RD");
}
function Rocket::onCollision(%this,%object,%other1,%other2,%other3)
{
	//both("This:R");
	//both("This: "@%this@" = "@getObjectType(%this)@"; Object: "@%object@": "@getObjectType(%object));
	//both("vel1 "@%vel1@" LC "@Player::getLastContactCount(%player));
}
function remoteGMAa(%cl) { $testcheats = true; remoteGiveAll(%cl); $testcheats = ""; $TeamItemMax[Beacon] = 9999; }


function Player::HeightTracker(%this, %HeightTrackerLastContactTime)
{
	//both(%this@", "@%HeightTrackerLastContactTime@" LC: "@%this.LastContactTime@" subb: "@%this.LastContactTime-%HeightTrackerLastContactTime);
	%zVelocity = gw(item::getvelocity(%this), 2);
	if(%this.LastContactTime - %HeightTrackerLastContactTime < 0.1 && %zVelocity > -20)//(%zVelocity > 0.1 || %zVelocity < -0.1) )
	{
		if(GameBase::getLOSinfo(%this, 5000, "-1.57 0 0"))
		{
			%currentPosition = gamebase::getposition(%this);
			%currentHeight = Vector::getDistance($los::position, %currentPosition);
			if(%currentHeight > 0)
			{
				if(%zVelocity < 10 && %zVelocity > -10)
				{
					%timer = 0.2;
				}
				else
				{
					%timer = 0.6;
				}
				//BOTH((%currentHeight - %this.HeightTrackerLastHeight));
				if(%currentHeight - %this.HeightTrackerLastHeight > 300)
				{
					return;
				}
				%this.HeightTrackerLastHeight = %currentHeight;
				schedule("Player::HeightTracker("@%this@", "@%HeightTrackerLastContactTime@");", %timer, %this);

				Score::CompareStat(GameBase::getOwnerClient(%this), "GreatestHeightReached", %currentHeight, GetPlayType(GameBase::getOwnerClient(%this)));
				//bottomprint(GameBase::getOwnerClient(%this), "<jc><f1>Current Height: <f2>" @ %currentHeight@" <f1>Current Velocity: <f2>" @%zVelocity@" <f1>Timer: <f2>"@%timer , 2);
			}
		}
		else
		{
			//both("under map??");
		}


	}
	else
	{
		//both("cancelling");
	}
}

function Player::onCollision(%this,%object) {
	%vel1 = Vector::normalize(item::getvelocity(%this));
	%vel2 = item::getvelocity(%object);

	%objectType = getObjectType(%object);
	//both("This: "@%this@" = "@getObjectType(%this)@"; Object: "@%object@": "@getObjectType(%object)@" LC: "@(getSimTime() - %this.LastContactTime));
	if( (%objectType == "InteriorShape" || %objectType == "SimTerrain" || %objectType == "StaticShape") && !Player::isDead(%this) )
	{

		%ownerClient = Gamebase::getOwnerClient(%this);
		%playType = getPlayType(%ownerClient);
		if(%this.LastPosition == "")
		{
			%this.LastPosition = gamebase::getposition(%this);
			%this.LastContactTime = getSimTime();
		}
		%DistanceTravelled = vector::getDistance(%this.LastPosition, gamebase::getposition(%this));
		if(%DistanceTravelled > 0)
		{
			%flyTime = (getSimTime() - %this.LastContactTime);
			if(%flyTime > 0.4)
			{
				Score::IncreaseStat(%ownerClient, "FlightTime", %flyTime, %playType);
				Score::CompareStat(%ownerClient, "LongestFlightTime", %flyTime, %playType);
			}
			%speed = vector::getdistance("0 0 0", item::getvelocity(%this));
			Score::IncreaseStat(%ownerClient, "DistanceTravelled", %DistanceTravelled, %playType);

			Score::CompareStat(%ownerClient, "FurthestDistanceJumped", %DistanceTravelled, %playType);

			Score::CompareStat(%ownerClient, "FastestSkiSpeed", %speed, %playType);
			//Client::LastActionUpdate(%ownerClient, "Travelled");
		}
		%this.LastPosition = gamebase::getposition(%this);
		%this.LastContactTime = getSimTime() + 1;
		//both("This: "@%this@" = "@getObjectType(%this)@"; Object: "@%object@": "@getObjectType(%object));
		//zboth("vel1 "@%vel1@" LC "@Player::getLastContactCount(%player));
		%this.LastHeightTrackerRun = getSimTime();
		schedule("Player::HeightTracker("@%this@", "@%this.LastContactTime@");", 2, %this);
		return;
	}

	if(!Player::isDead(%object) && !Player::isDead(%this) && getObjectType(%this) == "Player" && getObjectType(%object) == "Player")
	{
		//both("both alive...");
	}
	if(Player::getClient(%object).Team != "" && !Player::isDead(%object) || Player::getClient(%object).DM && !Player::isDead(%object))
	{
		if (Player::isDead(%this)) {
			if (getObjectType(%object) == "Player")
			{
				%thisclient = %this.owner;
				%objectclient = %object.owner;
				%playtype = GetPlayType(%objectclient);
				//%thisclient.score[%playtype, "CorpseTouched"]++;
				Score::IncreaseStat(%objectclient, "CorpsesTouched", 1, %playType);
				if(Player::isCrouching(%object))
				{
					//%objectclient.score[%playtype, "CorpseHumper"]++;

					//%thisclient.score[%playtype, "CorpseHumped"]++;

					resetlos();
					gamebase::getlosinfo(%this, 2, "-1.57 0 0");
					if(Player::getLastContactCount(%object) > 4 && $los::object == "")
					{
						//%objectclient.score[%playtype, "MACorpseHumper"]++;
						Score::IncreaseStat(%objectclient, "MACorpseHumper", 1, %playType);

						//%thisclient.score[%playtype, "MACorpseHumped"]++;
						Score::IncreaseStat(%thisclient, "MACorpseHumped", 1, %playType);
						//both("corpse MA humped by "@client::Getname(%objectclient));
					}
					else {
						Score::IncreaseStat(%objectclient, "CorpseHumper", 1, %playType);
						Score::IncreaseStat(%thisclient, "CorpseHumped", 1, %playType);
						//both("regular humped "@%playtype@" "@%objectclient@" "@%objectclient.score[%playtype, "CorpseHumper"]);
					}
				}
				// Transfer all our items to the player
				%sound = false;
				%max = getNumItems();
				//echo("Player::onCollision Count");
				for (%i = 0; %i < %max; %i = %i + 1) {
					%count = Player::getItemCount(%this,%i);
					if (%count) {
						if(getItemData(%i) != "mineammo")
						{
							%delta = Item::giveItem(%object,getItemData(%i),%count);
							if (%delta > 0) {
								Player::decItemCount(%this,%i,%delta);
								%sound = true;
							}
						}
					}
				}
				if (%sound) {
					// Play pickup if we gave him anything
					playSound(SoundPickupItem,GameBase::getPosition(%this));
					//%thisclient.score[%playtype, "CorpseLooted"]++;
					//both(sound);
					//both(%thisclient@" PT "@%playType);
					if(!%objectclient.DM && !%thisclient.DM && %thisclient.Team != "" && %objectclient.Team != "")
					{
						if(%thisclient.Team == %objectclient.Team)
						{
							Score::IncreaseStat(%objectclient, "FriendlyCorpseLooted", 1, %playType);
						}
						else
						{
							Score::IncreaseStat(%objectclient, "EnemyCorpseLooted", 1, %playType);
						}
					}
					Score::IncreaseStat(%objectclient, "CorpseLooted", 1, %playType);
				}
			}
		}
	}
}



//tried fixing the odd objective screen behavior
//
function formattedbest(%secs) {
	if($TDebug && $TeamDuel::Master)
	{
		//LogFunction(formattedbest);
	}

	if(%secs == 9999)
	{
		%boo = "00:00";
		return %boo;
	}
	//return Time::getSeconds(%secs);
	%zero = "";
	%zerow = "";
	if(Time::getMinutes(%secs) < 10)
	{
		%zerow = "0";
	}
	if(Time::getSeconds(%secs) < 10)
	{
		%zero = "0";
	}
	%blah = %zerow@""@ Time::getMinutes(%secs) @":"@%zero@""@ Time::getSeconds(%secs);

	return %blah;
//    |
//old |
//    V
       //if(%secs == 9999)
       //        return escapestring("00:00");
       //%mins = floor(%secs / 60);
       //if(%mins < 0)
       //        %mins = -%mins;
       //%secs = floor(%secs - (%mins * 60));
       //if(%secs < 0)
       //        %secs = -%secs;
       //if(%mins < 10)
       //        %str = "0" @ %mins @ ":";
       //else
       //        %str = %mins @ ":";
       //if(%secs < 10)
       //        %str = %str @ "0" @ %secs;
       //else
       //        %str = %str @ %secs;
       //return escapestring(%str);
}
function getEfficiencyRatio(%clientId, %mode) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(getEfficiencyRatio);
	}

		%ratio = floor((%clientId.score[%mode, "scoreKillsTotal"]/(%clientId.score[%mode, "scoreKillsTotal"] + %clientId.score[%mode, "scoreDeathsTotal"]))*100);
		if (%ratio > 0)
			return %ratio;
		else
			return "0";

}

function Teamduel::Client::OnKilled(%playerId, %killerId, %damageType, %check)
{
	//schedule("ForceOneObs("@ %playerId @","@ %killerId @");", 0.9);
	ForceOneObs(%playerId,%killerId);
	%bleah = AmountAlive(%playerId.Team);
	%alive = getword(%bleah, 0);
	//echo(%alive);
	echo("Players still alive on the "@ $TeamDuel::Name[%playerId.Team] @" team: "@ %alive);
	if(%alive == "1")
	{
		%message = $TeamDuel::Name[%playerId.Team] @ " has one member left.";

		schedule("OneLeftMessage("@ %playerId.Team @");",2.0);
		//WayPointThem(%playerId.Team, $TeamDuel::Challenging[%playerId.Team], 1);
	}
	if(%alive == "0" && $TeamDuel::RoundEnded[%playerId.Team] != "true" && $TeamDuel::RoundEnded[$TeamDuel::Challenging[%playerId.Team]] != "true")
	{
		$TeamDuel::RoundEnded[%playerId.Team] = true;
		$TeamDuel::RoundEnded[$TeamDuel::Challenging[%playerId.Team]] = true;
		$TeamDuel::MatchesWon[$TeamDuel::Challenging[%playerId.Team]]++;
		$TeamDuel::MatchesLost[%playerId.Team]++;
		%message = "<jc>" @ $TeamDuel::Name[$TeamDuel::Challenging[%playerId.Team]] @ " has won the round!\n\n\n" @ Arena::GetTeamScoresString($TeamDuel::Challenging[%playerId.Team], $TeamDuel::Challenging[%playerId.Team], %playerId.Team) @".";
		%message2 = $TeamDuel::Name[$TeamDuel::Challenging[%playerId.Team]] @ " has won the round! " @ Arena::GetTeamScoresString($TeamDuel::Challenging[%playerId.Team], $TeamDuel::Challenging[%playerId.Team], %playerId.Team) @".";
		TMessage(%playerId.Team, %killerId.Team, $White, %message2);
		PrintTeam(%playerId.Team@" "@$TeamDuel::Challenging[%playerId.Team], %message, center);//top, center, bottom
		$TeamDuel::Score[$TeamDuel::Challenging[%playerId.Team]]++;
		$TeamDuel::CanHurt[%playerId.Team] = "";
		$TeamDuel::CanHurt[$TeamDuel::Challenging[%playerId.Team]] = "";
		schedule("EndRound($TeamDuel::Challenging["@ %playerId.Team @"], "@ %playerId.Team @");", 5.0);
		$TeamDuel::Start[%playerId.Team] = "";
		$TeamDuel::Start[$TeamDuel::Challenging[%playerId.Team]] = "";
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.ThisRoundDamagedDoneID[%playerId] > 0.33 && %cl != %killerId && %cl.ThisRoundDamagedDoneID[%playerId].team != %playerId.team  && %cl.team != "" && %cl != %playerID  && %cl != %KillerID || %cl.ThisRoundHitsDoneID[%playerId] > 3 && %cl != %killerId && %cl.ThisRoundDamagedDoneID[%playerId].team != %playerId.team  && %cl.team != "" && %cl != %playerID  && %cl != %KillerID)
		{
			if(%cl.team == %playerId.team)
			{
				%color = $Red;
				%message =  client::Getname(%cl)@" is awarded a TK assist!";
				Score::IncreaseStat(%cl, "TKAssists", 1, "TD");
			}
			else
			{
				%color = $Green;
				%message =  client::Getname(%cl)@" is awarded an assist!";
				Score::IncreaseStat(%cl, "Assists", 1, "TD");
			}
			TMessage(%playerId.Team, %killerId.Team, %color, %message);
		}
	}
}
function Client::onKilled(%playerId, %killerId, %damageType, %check) {
	if(%playerId.isKing)
	{
		%killerId.score["KingKills"]++;
	}
	else if(%killerId.isKing)
	{
		%playerId.score["KingKills"] = 0;
	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Client::onKilled);
	}
	if(getWord(client::getname(%playerId), 0) == "Tower")
	{
		$botsdide++;
		item::pop(Client::getOwnedObject(%playerId));
		messageall(0, "Bots Dead: "@$botsdide);
		return;
	}

	//%scoreKills = GetPlayType(%killerId)@"scoreKills";
	//%scoreDeaths = GetPlayType(%killerId)@"scoreDeaths";
	%PlayType = GetPlayType(%killerId);
	//echo(%scorekills@"    "@%scoredeaths);
	 //eval( "%killerId." @ %scoreKills @ "++;");
	 //eval( "%playerId." @ %scoreDeaths @ "++;");
	 //%killerId.score++;
	 //%playerId.scoreDeaths++;
	LogDeath(%damageType);

	%message = "";
	%playerId.IsAlive = "";
	//messageall(1, Client::getName(%playerId) @"'s Team: "@ %playerId.Team @"  "@ Client::getName(%killerId) @"'s Team: "@ %killerId.Team);
	if(%playerId.Team != "" && %killerId.Team != "" || %playerId.DM || %killerId.DM)
	{
		if(%playerId.DM != "true" && %killerId.DM != "true" && $TeamDuel::Challenging[%playerId.Team] != "0")
		{
			//both("reg td on kill");
			Teamduel::Client::OnKilled(%playerId, %killerId, %damageType, %check);
		}
		if(%playerId.DM != "true" && %killerId.DM != "true" && $TeamDuel::Challenging[%playerId.Team] == "0")
		{
			//both("multi on kill");
			MultiTeamduel::Client::OnKilled(%playerId, %killerId, %damageType, %check);
		}


		echo("TeamDuel: " @ %killerId @ "("@Client::GetName(%killerId)@") killed " @ %playerId @ "("@Client::GetName(%playerId)@") " @ %damageType);


   %playerId.guiLock = false;
   Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male"))
   {
      %playerGender = "his";
   }
	else
	{
		%playerGender = "her";
	}
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);


   if(!%killerId)
   {
	   %message = strcat(%victimName, " dies.") @""@ $DeathMessageMask ;
	   //TMessage(%playerId.Team, $TeamDuel::Challenging[%playerId.Team], $White, %message);
      //%playerId.scoreDeaths++;
      //eval( "%playerId." @ %scoreDeaths @ "++;");//old

      Score::IncreaseStat(%playerId, "scoreDeaths", 1, %PlayType, %damageType);
      Score::IncreaseStat(%playerId, "scoreDeathsTotal", 1, %PlayType);
  }
   else if(%killerId == %playerId)
   {
	  // echo(aw);
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
	   %message = %oopsMsg @""@ $DeathMessageMask ;
	   //TMessage(%playerId.Team, $TeamDuel::Challenging[%playerId.Team], $White, %message);
      //%playerId.scoreDeaths++;
      //eval( "%playerId." @ %scoreDeaths @ "++;");//old
	  //%playerId.score[%PlayType, "scoreDeaths", %damageType]++;
      //%playerId.score[%PlayType, "scoreDeathsTotal"]++;
      Score::IncreaseStat(%playerId, "scoreDeaths", 1, %PlayType, %damageType);
      Score::IncreaseStat(%playerId, "scoreDeathsTotal", 1, %PlayType);
      //%playerId.score[%PlayType, "scoreSuicide"]++;
      Score::IncreaseStat(%playerId, "scoreSuicide", 1, %PlayType);
      //%playerId.score--;
   }
   else
   {
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}
      if($teamplay && %killerId.Team == %playerId.Team && %killerid.team != "" && %playerId.DM != "true" && %killerId.DM != "true" || $DeathMatch::Teams && %killerId.Team == %playerId.Team && %killerid.team != "" && %playerId.DM && %killerId.DM)
      {
		if(%damageType != $MineDamageType)
		{
			   %message = strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName) @""@ $DeathMessageMask ;
			   //TMessage(%playerId.Team, $TeamDuel::Challenging[%playerId.Team], $White, %message);
		}
		else
		{
			   %message = strcat(Client::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine.") @""@ $DeathMessageMask ;
			   //TMessage(%playerId.Team, $TeamDuel::Challenging[%playerId.Team], $White, %message);
		 }

		 //%killerId.scoreDeaths++;
		 //eval( "%killerId." @ %scoreDeaths @ "++;");
      // %killerId.score--;scoreDeaths[%PlayType,
      Score::IncreaseStat(%killerId, "TKs", 1, %PlayType);
      Score::IncreaseStat(%playerId, "TKed", 1, %PlayType);
       //Game::refreshClientScore(%killerId);
       Game::refreshClientScore(%playerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
		   %message = %obitMsg @""@ $DeathMessageMask ;
		   //TMessage(%playerId.Team, $TeamDuel::Challenging[%playerId.Team], $White, %message);

         //%killerId.scoreKills++;
         //%playerId.scoreDeaths++;  // test play mode
         //eval( "%killerId." @ %score @ "++;");
         //eval( "%killerId." @ %scoreKills @ "++;");
         //eval( "%playerId." @ %scoreDeaths @ "++;");
         Score::IncreaseStat(%killerId, "scoreKills", 1, %PlayType, %damageType);
         Score::IncreaseStat(%playerId, "scoreDeaths", 1, %PlayType, %damageType);
         Score::IncreaseStat(%killerId, "scoreKillsTotal", 1, %PlayType);
         Score::IncreaseStat(%playerId, "scoreDeathsTotal", 1, %PlayType);
        // %killerId.score++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
	if(%playerId.Team != "" && %killerId.Team != "" && %playerId.DM != "true" && %killerId.DM != "true")
	{
  		 TMessage(%playerId.Team, $TeamDuel::Challenging[%playerId.Team], $White, %message);
	 }
	 else {
		 %playerId.observerMode = "dead";
		 DeathMatch::Message($White, %message);
	 }

   //Game::refreshClientScore(%playerId);
   Game::clientKilled(%playerId, %killerId);
//   %playerId.score[%PlayType, "KillStreak"] = 0;
   Score::SetStat(%playerId, "KillStreak", 0, %PlayType);
   if(%playerId != %killerId)
   {
   		Score::IncreaseStat(%killerId, "KillStreak", 1, %PlayType);
   		Score::CompareStat(%killerId, "BestKillStreak", Score::GetStat(%killerId, "KillStreak", %playType), %playType);
	}
//   %killerId.score[%PlayType, "KillStreak"]++;

//	if(%killerId.score[%PlayType, "KillStreak"] > %killerId.score[%PlayType, "BestKillStreak"])
//	{
//		%killerId.score[%PlayType, "BestKillStreak"] = %killerId.score[%PlayType, "KillStreak"];
//	}
   return;
}
      // echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
        echo("DUEL: " @ %killerId @ "("@Client::GetName(%killerId)@") killed " @ %playerId @ "("@Client::GetName(%playerId)@") " @ %damageType);
        %playerId.dead = true;
        if(%killerId != %playerId)
        {
         	//eval( "%killerId." @ %scoreKills @ "++;");
		 }
        // eval( "%playerId." @ %scoreDeaths @ "++;");
         if(%killerId == %playerId)
         {
			// eval( "$Dueling[%playerId]." @ %scoreKills @ "++;");
		 }
       %playerId.guiLock = true;
       Client::setGuiMode(%playerId, $GuiModePlay);
       if(!%killerId)
               messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
       Game::clientKilled(%playerId, %killerId);
       if(%damageType == $LandingDamageType)
               %damageType = 0;
       if($DuelCanHurt[%playerId])
       {
		   if(!$Dueling[%playerId].dead)
		   {
		   		schedule("WaitForTie("@%playerId@","@$Dueling[%playerId]@","@%damagetype@");", 1);
			}
		   //EndDuel(%playerId, %damageType);
	   }
	   //%killerId.health = gethealth(%killerId);
}

function remoteCKC(%cl)
{
	%numItems = Group::objectCount(MissionCleanup);
	both(%numitems);
	//%z=0;
	for(%i = 0 ; %i<%numItems ; %i++)
	{
		%obj = Group::getObject(MissionCleanup, %i);
		%type = getObjectType(%obj);
		both(%obj@" "@%type);

	}
}

function WaitForTie(%playerId, %killerId, %damagetype)
{
	if(%killerId.dead && %playerId.dead)
	{
		$DuelStreak[%killerId] = 0;
		$DuelStreak[%playerId] = 0;
		%t = getSimTime() - $DuelStartTime[$DuelSpotIndex[%playerId]];
		%t = formattedbest(%t);
		MessageAll($white, "The duel between "@Client::GetName(%killerId) @ " and " @ Client::GetName(%playerId) @ " ended in a tie. (" @ %t @ ")");


	   if($SpeedDuel[%killerId] == "True" && $SpeedDuel[%playerId] == "True")
	   {
			   schedule("FinalizeDuel(" @ %killerId @ "," @ %playerId @ ");", 0.5);
			   schedule("DuelInit(" @ %killerId @ "," @ %playerId @ ");", 1);
	   }
	   if($Winners::On[%killerId] && $Winners::On[%playerId])
	   {
			   schedule("FinalizeDuel(" @ %killerId @ "," @ %playerId @ ");", $DuelDelayTime-1);
			   schedule("DuelInit(" @ %killerId @ "," @ %playerId @ ");", $DuelDelayTime);
		   return;
	   }
	   if($SpeedDuel[%killerId] == "False" || $SpeedDuel[%playerId] == "False" || $SpeedDuel[%killerId] == "EndOfD" || $SpeedDuel[%playerId] == "EndOfD")
	   {
			   schedule("FinalizeDuel(" @ %killerId @ "," @ %playerId @ ");", $DuelDelayTime-1);
	   }

		return;
	}


	EndDuel(%playerId, %damageType);

}
function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
			if(GameBase::getControlClient(%player) != -1) {
			//	echo("Throw item: " @ %type @ " " @ %strength);
				%item = getItemData(%type);
				if (%item == Grenade || %item == MineAmmo) {
					if (%strength < 0)
						%strength = 0;
					else
						if (%strength > 100)
							%strength = 100;
					%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
					Player::useItem(%client,%item);
				}
			}
		}
	}
}
//item.cs
function MineAmmo::onUse(%player,%item) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(MineAmmo::onUse);
	}
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			if ($DuelMine1[%client] == "")
				$DuelMine1[%client] = %obj;
			else if ($DuelMine2[%client] == "")
				$DuelMine2[%client] = %obj;
			else if ($DuelMine3[%client] == "")
				$DuelMine3[%client] = %obj;
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
//item.cs
function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Target Beacon");
   			   		Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Bacon deployed");
					%time = "1.0";
					if(%client.Team != "" || %client.DM)
					{
						%time = "60.0";
					}
					schedule("KillBeacon("@%beacon@");",%time,%beacon);
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}
function BeginDuel(%clientId, %foeId, %clientPl, %foePl) {
	%time = Time::getMinutes((floor(getSimTime()) - %clientId.LastAction));
	if(%time > 0.9)
	{
		Game::refreshClientScore(%clientId);
		%clientId.LastAction = floor(getSimTime());
	}
	else
	{
		%clientId.LastAction = floor(getSimTime());
	}
//	Item::Setvelocity(%clientId, "-50 0 15");
	//Item::Setvelocity(%foeId, "-50 0 15");
	%time = Time::getMinutes((floor(getSimTime()) - %foeId.LastAction));
	if(%time > 0.9)
	{
		%foeId.LastAction = floor(getSimTime());
		Game::refreshClientScore(%foeId);
	}
	else
	{
		%foeId.LastAction = floor(getSimTime());
	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(BeginDuel);
	}

	%clientId.shotsFired[Duel]=0;
	%foeId.shotsFired[Duel]=0;
	%clientId.shotsHit[Duel]=0;
	%foeId.shotsHit[Duel]=0;
	%clientId.dead = false;
	%foeId.dead = false;

	schedule("DuelStartHurt(" @ %clientId @ "," @ %foeId @ ");", $DuelHurtDelay);

	GameBase::SetDamageLevel(%clientPl, 0);
	GameBase::SetDamageLevel(%foePl, 0);

	Client::sendMessage(%clientId, 0, "~wduelfight.wav");
	Client::sendMessage(%foeId, 0, "~wduelfight.wav");
	BottomPrint(%clientId, "<jc><f1>----- <f2>FIGHT! <f1>-----", 3);
	BottomPrint(%foeId, "<jc><f1>----- <f2>FIGHT! <f1>-----", 3);

	for (%i = 0; %i < 3; %i++) {
		if($DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}
	for (%i = 0; %i < 3; %i++) {
		if($DuelWeaponAmmo[$DuelWeaponSetup[%foeId, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}


	Client::setControlObject(%clientId, client::getownedobject(%clientId));
	Client::setControlObject(%foeId, client::getownedobject(%foeId));

	$DuelStartTime[$DuelSpotIndex[%clientId]] = getSimTime();

	%time = floor($DuelStartTime[$DuelSpotIndex[%clientId]]);

	if(!%hasenergy) schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ "," @ %time @ ");", 30);

	//remoteEval(%clientId, "setTime", 0);
	//remoteEval(%foeId, "setTime", 0);
	schedule("DuelIntegrity("@%clientId@","@%foeId@");", 2);
	//both("wat");
	Start::TimeTracker(%clientId, "DuelTime");
	Start::TimeTracker(%foeId, "DuelTime");
}

$dd=5;
function loopme(%c)
{
	resetlos();
	gamebase::getlosinfo(Client::getOwnedObject(%c),$dd,"-1.57 0 0");
	both($los::object);
	schedule("loopme("@%c@");",1);
}


function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%clientId = GameBase::GetControlClient(%target);
	if(CanDamage(%clientId, %shooterId))
	{
		//both(%clientId@" "@%shooterId);
		//%shooterClient = Player::getClient(%shooterId);
		//%playtype = getplaytype(%shooterId);
		Score::IncreaseStat(%shooterClient, "EnergyDrained", %enDrainPerSec, %playType);
		//%shooterClient.score[%playtype, "HitsDone",  $ElectricityDamageType]++;
		//Player::getClient(%target).score[%playtype, "HitsReceived", $ElectricityDamageType]++;
		//Score::IncreaseStat(Player::getClient(%target), "HitsReceived", 1, %playType, $ElectricityDamageType);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;

		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

		%energy = GameBase::getEnergy(%target);
		%energy = %energy - %enVal;
		if (%energy < 0)
		{
			%energy = 0;
		}
		GameBase::setEnergy(%target, %energy);
	}
}


function Admin::countVotes(%curVote)
{
	if($Veto == "False")
	{
	   // if %end is true, cancel the vote either way
	   if(%curVote != $curVoteCount)
		  return;

	   %votesFor = 0;
	   %votesAgainst = 0;
	   %votesAbstain = 0;
	   %totalClients = 0;
	   %totalVotes = 0;

	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   {
		   if(Time::getMinutes((floor(getSimTime()) - %cl.LastAction)) < 0.9)
		   {
			  %totalClients++;
			  if(%cl.vote == "yes")
			  {
				 %votesFor++;
				 %totalVotes++;
			  }
			  else if(%cl.vote == "no")
			  {
				 %votesAgainst++;
				 %totalVotes++;
			  }
			  else
				 %votesAbstain++;
			}
	   }
	   if(%votesAbstain > %totalClients/2.5)
	   {
		   %plural = "";
		   if(%totalVotes > 1 || %totalVotes == "0")
		   {
			   %plural = "s";
		   }
		   messageAll(0, "Vote to " @ $curVoteTopic @ " failed.(Only "@%totalVotes@" vote"@%plural@")");
		   Admin::voteFailed();
		   $curVoteTopic = "";
		   return;
	   }
	   if((%votesFor / %totalVotes) >= 0.525)
	   {
		  messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions.");
		  Admin::voteSucceded();
		  $curVoteTopic = "";
		  return;
	   }
		  messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
		  Admin::voteFailed();
		  $curVoteTopic = "";
		  return;

	}
$Veto = "False";
Admin::voteFailed();
$curVoteTopic = "";
}
$loaded["TDOverWriting.cs"] = true;