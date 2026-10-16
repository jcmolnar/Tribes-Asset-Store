$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;


//==== Initial Menu ====//
function Game::menuRequest(%clientId)
{
	%curItem = 0;
	Client::buildMenu(%clientId, "Options", "options", true);

	if(%clientId.selClient)
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);

		if($curVoteTopic == "" && !%clientId.isAdmin)
		{
			if($Apocalypse::VoteAdmin == true)
			{ Client::addMenuItem(%clientId, %curItem++ @"Vote to admin "@ %name, "vadmin "@ %sel); }
			if($Apocalypse::VoteKick == true)
			{ Client::addMenuItem(%clientId, %curItem++ @"Vote to kick "@ %name, "vkick "@ %sel); }
		}
		if(%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @"Change "@ %name @"'s team", "fteamchange "@ %sel);
			if($Apocalypse::PublicKick == true)
			{ Client::addMenuItem(%clientId, %curItem++ @"Kick "@ %name, "kick "@ %sel); }
			if(%clientId.isSuperAdmin)
			{
				Client::addMenuItem(%clientId, %curItem++ @"Manage "@ %name, "ManageMAIN "@ %sel);
				Client::addMenuItem(%clientId, %curItem++ @"Fun With "@ %name, "BMeanMAIN "@ %sel);
			}
		}
		if(%clientId.muted[%sel])
		{ Client::addMenuItem(%clientId, %curItem++ @"Unmute "@ %name, "unmute "@ %sel); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Mute "@ %name, "mute "@ %sel); }
		if(%clientId.observerMode == "observerOrbit")
		{ Client::addMenuItem(%clientId, %curItem++ @"Observe "@ %name, "observe "@ %sel); }
	}
	else
	{
		if(!$matchStarted || !$Server::TourneyMode)
		{ Client::addMenuItem(%clientId, %curItem++ @"Change Teams/Observe", "changeteams"); }

		Client::addMenuItem(%clientId, %curItem++ @"Personal Settings", "poptsMain");

		if($curVoteTopic != "" && %clientId.vote == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @"Vote YES to "@ $curVoteTopic, "voteYes "@ $curVoteCount);
			Client::addMenuItem(%clientId, %curItem++ @"Vote NO to "@ $curVoteTopic, "voteNo "@ $curVoteCount);
		}
		else if($curVoteTopic == "" && !%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @"Vote to change mission", "vcmission");
			if($Server::TeamDamageScale == 1.0)
			{ Client::addMenuItem(%clientId, %curItem++ @"Vote to disable team damage", "vdtd"); }
			else
			{ Client::addMenuItem(%clientId, %curItem++ @"Vote to enable team damage", "vetd"); }

			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @"Vote to enter FFA mode", "vcffa");
				if(!$CountdownStarted && !$matchStarted)
				{ Client::addMenuItem(%clientId, %curItem++ @"Vote to start the match", "vsmatch"); }
			}
			else
			{ Client::addMenuItem(%clientId, %curItem++ @"Vote to enter Tournament mode", "vctourney"); }
		}
		else if(%clientId.isAdmin)
		{
			if($Apocalypse::PublicChngMission == true || %clientId.isSuperAdmin == true)
			{ Client::addMenuItem(%clientId, %curItem++ @"Change mission", "cmission"); }
			if($Apocalypse::PublicSvrOpts == true || %clientId.isSuperAdmin == true)
			{ Client::addMenuItem(%clientId, %curItem++ @"Server Options", "serveropts"); }
			if($Apocalypse::PublicEDWepMode == true || %clientId.isSuperAdmin == true)
			{
				if($Apocalypse::Modules == true)
				{ Client::addMenuItem(%clientId, %curItem++ @"Disable Modules", "dmodules"); }
				else
				{ Client::addMenuItem(%clientId, %curItem++ @"Enable Modules", "emodules"); }
			}
			if($Apocalypse::PublicMelee == true || %clientId.isSuperAdmin == true)
			{
				if($Apocalypse::SlugFest == true)
				{ Client::addMenuItem(%clientId, %curItem++ @"Disable Melee", "dmelee"); }
				else
				{ Client::addMenuItem(%clientId, %curItem++ @"Enable Melee", "emelee"); }
			}
		}
	}
}

//==== Process Main Menu ====//
// PORT: Tab-menu codes arrive from the client, so each privileged code is tested here the way
// Game::menuRequest lists it (and the way apocConfig.cs switches it).
function ApocPort::optAllowed(%clientId, %opt)
{
	if(%opt == "vadmin")
		return ($Apocalypse::VoteAdmin == true && !%clientId.isAdmin);
	if(%opt == "vkick")
		return ($Apocalypse::VoteKick == true && !%clientId.isAdmin);
	if(%opt == "fteamchange")
		return %clientId.isAdmin;
	if(%opt == "kick")
		return (%clientId.isSuperAdmin || (%clientId.isAdmin && $Apocalypse::PublicKick == true));
	if(%opt == "ManageMAIN" || %opt == "BMeanMAIN")
		return %clientId.isSuperAdmin;
	if(%opt == "cmission")
		return (%clientId.isAdmin && ($Apocalypse::PublicChngMission == true || %clientId.isSuperAdmin));
	if(%opt == "serveropts")
		return (%clientId.isAdmin && ($Apocalypse::PublicSvrOpts == true || %clientId.isSuperAdmin));
	if(%opt == "dmodules" || %opt == "emodules")
		return (%clientId.isAdmin && ($Apocalypse::PublicEDWepMode == true || %clientId.isSuperAdmin));
	if(%opt == "dmelee" || %opt == "emelee")
		return (%clientId.isAdmin && ($Apocalypse::PublicMelee == true || %clientId.isSuperAdmin));
	return true;
}

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!ApocPort::optAllowed(%clientId, %opt)) { Game::menuRequest(%clientId); return; }

	if(%opt == "fteamchange")
	{
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
		Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		return;
	}
	else if(%opt == "changeteams")
	{
		if(!$matchStarted || !$Server::TourneyMode)
		{
			Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
			Client::addMenuItem(%clientId, "0Observer", -2);
			Client::addMenuItem(%clientId, "1Automatic", -1);
			for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			{ Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i); }
			return;
		}
	}
	else if(%opt == "mute")
	{ %clientId.muted[%cl] = true; }

	else if(%opt == "unmute")
	{ %clientId.muted[%cl] = ""; }

	else if(%opt == "vkick")
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
	}
	else if(%opt == "vadmin")
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
	}
	else if(%opt == "vsmatch")
	{ Admin::startVote(%clientId, "start the match", "smatch", 0); }

	else if(%opt == "vetd")
	{ Admin::startVote(%clientId, "enable team damage", "etd", 0); }

	else if(%opt == "vdtd")
	{ Admin::startVote(%clientId, "disable team damage", "dtd", 0); }

	else if(%opt == "vcffa")
	{ Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0); }

	else if(%opt == "vctourney")
	{ Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0); }

	else if(%opt == "voteYes" && %cl == $curVoteCount)
	{
		%clientId.vote = "yes";
		centerprint(%clientId, "", 0);
	}
	else if(%opt == "voteNo" && %cl == $curVoteCount)
	{
		%clientId.vote = "no";
		centerprint(%clientId, "", 0);
	}
	else if(%opt == "kick")
	{
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "vcmission" || %opt == "cmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
	else if(%opt == "observe")
	{
		Observer::setTargetClient(%clientId, %cl);
		return;
	}

	else if(%opt == "ManageMAIN")
	{
		%name = Client::getName(%cl); // PORT: the labels below use %name, which this function never set
		Client::buildMenu(%clientId, "Managing "@ Client::getName(%cl), "Manage1", true);
		Client::addMenuItem(%clientId, "1Ban "@ %name, "ban "@ %cl);
		Client::addMenuItem(%clientId, "2Admin "@ %name, "admin "@ %cl);
		if($ArmorName[Player::getArmor(%cl)] != UltimaArmor)
		{ Client::addMenuItem(%clientId, "3Give "@ %name @" Ultima Armor", "giarmor "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, "3Take "@ %name @"'s Ultima Armor", "tkarmor "@ %cl); }
		return;
	}
	else if(%opt == "BMeanMAIN")
	{
		%name = Client::getName(%cl); %clName = %name; // PORT: neither was set in this function
		Client::buildMenu(%clientId, "Be An Ass To "@ %clName, "BAnAss", true);
		if(%cl.isPossessed)
		{ Client::addMenuItem(%clientId, %curItem++ @"Un Possess "@ %name, "UNposs "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Possess "@ %name, "Poss "@ %cl); }
		Client::addMenuItem(%clientId, %curItem++ @"Strip "@ %name @"'s Weps", "Droptheshit "@ %cl);
		if(!%cl.isFrozen)
		{ Client::addMenuItem(%clientId, %curItem++ @"Freeze "@ %name, "Freeze "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"UnFreeze "@ %name, "UnFreeze "@ %cl); }
		if(%cl.score != 0)
		{ Client::addMenuItem(%clientId, %curItem++ @"Clear His Score", "resetScore "@ %cl); }
		if(Client::getStatus(%cl) == "(Live)")
		{ Client::addMenuItem(%clientId, %curItem++ @"Kill", "KillaBitch "@ %cl); }
		if(%cl.noSuicide == 0)
		{ Client::addMenuItem(%clientId, %curItem++ @"Enable No Suicide", "EnoSuicide "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Disable No Suicide", "DnoSuicide "@ %cl); }
		return;
	}
	else if(%opt == "serveropts")
	{
		Client::buildMenu(%clientId, "Apocalypse Options:", "ServerOptions", true);
		if($Server::TeamDamageScale == 1.0)
		{ Client::addMenuItem(%clientId, %curItem++ @"Disable team damage", "dtd"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Enable team damage", "etd"); }

		if($Apocalypse::customSkins == true)
		{ Client::addMenuItem(%clientId, %curItem++ @"Disable CustomSkins", "DCSkins"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Enable CustomSkins", "ECSkins"); }

		if($Server::TourneyMode)
		{
			Client::addMenuItem(%clientId, %curItem++ @"Change to FFA mode", "cffa");
			if(!$CountdownStarted && !$matchStarted)
			{ Client::addMenuItem(%clientId, %curItem++ @"Start the match", "smatch"); }
		}
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Change to Tournament mode", "ctourney"); }

		Client::addMenuItem(%clientId, %curItem++ @"Set Time Limit", "ctimelimit");
		Client::addMenuItem(%clientId, %curItem++ @"Reset Server Defaults", "reset");
		return;
	}
	else if(%opt == "dmodules")
	{ $Apocalypse::Modules = false; return; }
	else if(%opt == "emodules")
	{ $Apocalypse::Modules = true; return; }
	else if(%opt == "dmelee")
	{ $Apocalypse::SlugFest = false; return; }
	else if(%opt == "emelee")
	{ $Apocalypse::SlugFest = true; return; }
	else if(%opt == "poptsMain")
	{
		Client::buildMenu(%clientId, "Prefs Directory:", "popts", true);
		if($Apocalypse::Modules == false)
		{
			Client::addMenuItem(%clientId, %curItem++ @"Weapons", "poptsWep");
			Client::addMenuItem(%clientId, %curItem++ @"Packs", "poptsPack");
		}
		Client::addMenuItem(%clientId, %curItem++ @"Spawn Opts", "poptsSpawn");
		return;
	}
	Game::menuRequest(%clientId);
}


function processMenupopts(%clientId, %option)
{
	%opt = getWord(%option, 0);
	// Note: none of these options will require adding a cl to the end of the 'option'
	// But it never hurts to be prepared eh? ;)
	%cl = getWord(%option, 1);
	// PORT: with Modules on, the Weapons / Packs entries are not listed (modules are bought); the codes are client text
	if($Apocalypse::Modules != false && (%opt == "poptsWep" || %opt == "poptsPack")) { return; }
	
	if(%opt == "poptsWep")
	{
		Client::buildMenu(%clientId, "Modules Directory:", "poptsWep", true);
		Client::addMenuItem(%clientId, %curItem++ @"Shotgun Choke", "shotchoke");
		Client::addMenuItem(%clientId, %curItem++ @"Flame Thower", "flameonoff");
		Client::addMenuItem(%clientId, %curItem++ @"Grenade", "grentypes");
		Client::addMenuItem(%clientId, %curItem++ @"Mortar", "mortartypes");
		Client::addMenuItem(%clientId, %curItem++ @"Force Cannon", "forcecannon");
		Client::addMenuItem(%clientId, %curItem++ @"Apocalypse Cannon", "apoccannon");
		return;
	}
	else if(%opt == "poptsPack")
	{
		Client::buildMenu(%clientId, "Packs Directory:", "poptsPack", true);
		Client::addMenuItem(%clientId, %curItem++ @"Elemental Barrier", "ebarrier");
		return;
	}
	else if(%opt == "poptsSpawn")
	{
		Client::buildMenu(%clientId, "Spawn Prefs", "poptsSpawn", true);
		Client::addMenuItem(%clientId, %curItem++ @"Rush(Defualt)", "Rush");
		Client::addMenuItem(%clientId, %curItem++ @"Pilot", "Pilot");
		Client::addMenuItem(%clientId, %curItem++ @"Repair", "Repair");
		Client::addMenuItem(%clientId, %curItem++ @"Power", "Power");
		return;
	}
}


//===========================================================================================
// Functions For Spawn Sets:
function processMenupoptsSpawn(%clientId, %opt)
{ if(%opt == "Rush" || %opt == "Pilot" || %opt == "Repair" || %opt == "Power") { $SpawnType[%clientId] = ""@ %opt @""; } } // PORT: the four menu entries only


// Functions For Pack Modes:
function processMenupoptsPack(%clientId, %option)
{
	%opt = getWord(%option, 0);
	// Note: none of these options will require adding a cl to the end of the 'option'
	// But it never hurts to be prepared eh? ;)
	%cl = getWord(%option, 1);
	
	if(%opt == "ebarrier")
	{
		Client::buildMenu(%clientId, "Elemental Barrier:", "ebarrier", true);
		Client::addMenuItem(%clientId, %curItem++ @"Fire", "1");
		Client::addMenuItem(%clientId, %curItem++ @"Wind", "2");
		Client::addMenuItem(%clientId, %curItem++ @"Earth", "3");
		Client::addMenuItem(%clientId, %curItem++ @"Electrical", "4");
		return;
	}
}

function processMenuebarrier(%clientId, %opt)
{ %opt = floor(%opt); if(%opt >= 1 && %opt <= 4) $WeapMode[%clientId, ElementPack] = %opt; } // PORT: a mode is a number; the reply is client text


// Functions For Weapon Modes:
function processMenupoptsWep(%clientId, %option)
{
	%opt = getWord(%option, 0);
	// Note: none of these options will require adding a cl to the end of the 'option'
	// But it never hurts to be prepared eh? ;)
	%cl = getWord(%option, 1);
	
	if(%opt == "shotchoke")
	{
		Client::buildMenu(%clientId, "Shotgun Choke:", "shotchoke", true);
		Client::addMenuItem(%clientId, %curItem++ @"Full", "1");
		Client::addMenuItem(%clientId, %curItem++ @"Improved", "2");
		Client::addMenuItem(%clientId, %curItem++ @"Modified", "3");
		Client::addMenuItem(%clientId, %curItem++ @"Skeet", "4");
		return;
	}
	else if(%opt == "flameonoff")
	{
		Client::buildMenu(%clientId, "Flame Thower:", "flameonoff", true);
		Client::addMenuItem(%clientId, %curItem++ @"Ignitor On", "1");
		Client::addMenuItem(%clientId, %curItem++ @"Ignitor Off", "2");
		return;
	}
	else if(%opt == "grentypes")
	{
		Client::buildMenu(%clientId, "Grenade:", "grentypes", true);
		Client::addMenuItem(%clientId, %curItem++ @"Concussion", "1");
		Client::addMenuItem(%clientId, %curItem++ @"Napalm", "2");
		Client::addMenuItem(%clientId, %curItem++ @"EMP", "3");
		return;
	}
	else if(%opt == "mortartypes")
	{
		Client::buildMenu(%clientId, "Mortar:", "mortartypes", true);
		Client::addMenuItem(%clientId, %curItem++ @"Explosion", "1");
		Client::addMenuItem(%clientId, %curItem++ @"Implosion", "2");
		return;
	}
	else if(%opt == "forcecannon")
	{
		Client::buildMenu(%clientId, "Force Cannon:", "forcecannon", true);
		Client::addMenuItem(%clientId, %curItem++ @"Wind", "1");
		Client::addMenuItem(%clientId, %curItem++ @"Gravity", "2");
		return;
	}
	else if(%opt == "apoccannon")
	{
		Client::buildMenu(%clientId, "Apocalypse Cannon:", "apoccannon", true);
		Client::addMenuItem(%clientId, %curItem++ @"Nuclear Warhead", "1");
		Client::addMenuItem(%clientId, %curItem++ @"Scatter Bomb", "2");
		return;
	}
}

function processMenushotchoke(%clientId, %opt)
{
	%player = Client::getOwnedObject(%clientId);
	%handgun = Player::getMountedItem(%player,$WeaponSlot);
	%opt = floor(%opt); // PORT: a mode is a number; the reply is client text
	$WeapMode[%clientId, Shotgun] = %opt;
	if(%handgun == Shotgun) {
		Player::unmountItem(%player,$WeaponSlot);
		Player::unmountItem(%player,$ExtraSlotA);
		Player::unmountItem(%player,$ExtraSlotB);
		Player::mountItem(%player,Shotgun,$WeaponSlot);
		printMessage(%player,Shotgun);
	}
}

function processMenuflameonoff(%clientId, %opt)
{
	%player = Client::getOwnedObject(%clientId);
	%handgun = Player::getMountedItem(%player,$WeaponSlot);
	%opt = floor(%opt); // PORT: a mode is a number; the reply is client text
	$WeapMode[%clientId,FlameThrower] = %opt;
	if(%handgun == FlameThrower) {
		Player::unmountItem(%player,$WeaponSlot);
		Player::unmountItem(%player,$ExtraSlotA);
		Player::unmountItem(%player,$ExtraSlotB);
		Player::mountItem(%player,FlameThrower,$WeaponSlot);
		printMessage(%player,FlameThrower);
	}
}

function processMenugrentypes(%clientId, %opt)
{
	%player = Client::getOwnedObject(%clientId);
	%handgun = Player::getMountedItem(%player,$WeaponSlot);
	%opt = floor(%opt); // PORT: a mode is a number; the reply is client text
	$WeapMode[%clientId,GrenadeLauncher] = %opt;
	if(%handgun == GrenadeLauncher) {
		Player::unmountItem(%player,$WeaponSlot);
		Player::unmountItem(%player,$ExtraSlotA);
		Player::unmountItem(%player,$ExtraSlotB);
		Player::mountItem(%player,GrenadeLauncher,$WeaponSlot);
		printMessage(%player,GrenadeLauncher);
	}
}

function processMenumortartypes(%clientId, %opt)
{
	%player = Client::getOwnedObject(%clientId);
	%handgun = Player::getMountedItem(%player,$WeaponSlot);
	%opt = floor(%opt); // PORT: a mode is a number; the reply is client text
	$WeapMode[%clientId, Mortar] = %opt;
	$WeapMode[%clientId, RangerMortar] = %opt;
	if(%handgun == Mortar || %handgun == RangerMortar) {
		Player::unmountItem(%player,$WeaponSlot);
		Player::unmountItem(%player,$ExtraSlotA);
		Player::unmountItem(%player,$ExtraSlotB);
		Player::mountItem(%player,%handgun,$WeaponSlot);
		printMessage(%player,%handgun);
	}
}

function processMenuforcecannon(%clientId, %opt)
{
	%player = Client::getOwnedObject(%clientId);
	%handgun = Player::getMountedItem(%player,$WeaponSlot);
	%opt = floor(%opt); // PORT: a mode is a number; the reply is client text
	$WeapMode[%clientId, RepulseGun] = %opt;
	if(%handgun == RepulseGun) {
		Player::unmountItem(%player,$WeaponSlot);
		Player::unmountItem(%player,$ExtraSlotA);
		Player::unmountItem(%player,$ExtraSlotB);
		Player::mountItem(%player,RepulseGun,$WeaponSlot);
		printMessage(%player,RepulseGun);
	}
}

function processMenuapoccannon(%clientId, %opt)
{
	%player = Client::getOwnedObject(%clientId);
	%handgun = Player::getMountedItem(%player,$WeaponSlot);
	%opt = floor(%opt); // PORT: a mode is a number; the reply is client text
	$WeapMode[%clientId, ApocGun] = %opt;
	if(%handgun == ApocGun) {
		Player::unmountItem(%player,$WeaponSlot);
		Player::unmountItem(%player,$ExtraSlotA);
		Player::unmountItem(%player,$ExtraSlotB);
		Player::mountItem(%player,ApocGun,$WeaponSlot);
		printMessage(%player,ApocGun);
	}
}
//===========================================================================================

function processMenuServerOptions(%clientId, %option)
{
	if(!%clientId.isAdmin || ($Apocalypse::PublicSvrOpts != true && !%clientId.isSuperAdmin)) { return; } // PORT: same test as the menu entry
	if(%option == "etd")
	{ Admin::setTeamDamageEnable(%clientId, true); return; }
	
	else if(%option == "dtd")
	{ Admin::setTeamDamageEnable(%clientId, false); return; }
	
	else if(%option == "cffa")
	{ Admin::setModeFFA(%clientId); return; }
	
	else if(%option == "ctourney")
	{ Admin::setModeTourney(%clientId); return; }
	
	else if(%option == "smatch")
	{ Admin::startMatch(%clientId); return; }
	
	else if(%option == "ctimelimit")
	{
		Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
		Client::addMenuItem(%clientId, "110 Minutes", 10);
		Client::addMenuItem(%clientId, "215 Minutes", 15);
		Client::addMenuItem(%clientId, "320 Minutes", 20);
		Client::addMenuItem(%clientId, "425 Minutes", 25);
		Client::addMenuItem(%clientId, "530 Minutes", 30);
		Client::addMenuItem(%clientId, "645 Minutes", 45);
		Client::addMenuItem(%clientId, "760 Minutes", 60);
		Client::addMenuItem(%clientId, "8No Time Limit", 0);
		return;
	}
	else if(%option == "reset")
	{
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes");
		Client::addMenuItem(%clientId, "2Don't Reset", "no");
		return;
	}
	else if(%option == "ECSkins") 
	{
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i++)
		{
			%cl = getClientByIndex(%i);
			Client::setSkin(%cl, $Client::info[%cl, 0]);
		}
		$Apocalypse::customSkins = true;
		MessageAll(0, "~wCapturedTower.Wav");
		CenterPrintAll("<jl><BSkull_Big.Bmp><jc><f1>Custom Skins Have Been <f2>Enabled <f1>By "@ Client::getName(%clientId) @".<jr><BSkull_Big.Bmp>", 5);
		return;
	}
	
	else if(%option == "DCSkins") 
	{
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i++)
		{
			%cl = getClientByIndex(%i);		
			Client::setSkin(%cl, $Server::teamSkin[Client::getTeam(%cl)]);
		}
		$Apocalypse::customSkins = false;
		MessageAll(0, "~wCapturedTower.Wav");
		CenterPrintAll("<jl><BSkull_Big.Bmp><jc><f1>Custom Skins Have Been <f2>Disabled <f1>By "@ Client::getName(%clientId) @".<jr><BSkull_Big.Bmp>", 5);
		return;
	}
}
	

function processMenuManage1(%clientId, %option)
{
	if(!%clientId.isSuperAdmin) { return; } // PORT: the Manage menu is a super-admin entry
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	
	if(%opt == "ban")
	{
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1Ban "@ Client::getName(%cl), "yes "@ %cl);
		Client::addMenuItem(%clientId, "2Don't ban "@ Client::getName(%cl), "no "@ %cl);
		return;
	}
	
	else if(%opt == "admin")
	{
		Client::buildMenu(%clientId, "Admin LvL", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Public Admin "@ Client::getName(%cl), "pub "@ %cl);
		Client::addMenuItem(%clientId, "2Don't admin "@ Client::getName(%cl), "no "@ %cl);
		return;
	}
	
	else if(%opt == "giarmor")
	{ MakeTester(%cl); return; }
	
	else if(%opt == "tkarmor")
	{ StripArmor(%cl); return; }
}

function processMenuBAnAss(%clientId, %option)
{
	%newOpt = getWord(%option, 0);
	%sel = getWord(%option, 1);
	%cl = %clientId.selClient;
	// PORT: super admins only (it is a super-admin menu entry), and the target must be a connected client
	if(!%clientId.isSuperAdmin) { return; }
	%found = -1;
	for(%c = Client::getFirst(); %c != -1; %c = Client::getNext(%c))
	{ if(%c == %sel) { %found = %c; } }
	if(%found == -1) { return; }
	%sel = %found;
	%cl = %found;
	
	if(%newOpt == "UNposs")
	{ Posses(%clientId, %sel, "UNPoss"); return; }
	
	else if(%newOpt == "Poss")
	{ Posses(%clientId, %sel, "Poss"); return; }
	
	else if(%newOpt == "Droptheshit")
	{
		%wepCount = Player::getItemClassCount(%sel, "Weapon");
		%max = getNumItems();
		for (%i = 0; %i < %max; %i = %i + 1)
		{ 
			%item = getItemData(%i);
			%count = Player::getItemCount(%sel, %item); 
			if(%count)
			Player::setItemCount(%sel, %item, 0);
		}
		MessageAll(0, Client::getName(%clientId) @", MD. Descides That "@ Client::getName(%sel) @" Shouldn't Be Around Sharp Objects.~wCapturedTower.wav");
		return;
	}
	
	else if(%newOpt == "Freeze")
	{ Freeze(%sel, "on"); return; }
	
	else if(%newOpt == "UnFreeze")
	{ Freeze(%sel, "off"); return; }
	
	else if(%newOpt == "resetScore")
	{
		%cl.score = 0;
		Game::RefreshClientScore(%cl);
		MessageAllExcept(%cl, 0, Client::getName(%clientId) @" Re-Set "@ Client::getName(%cl) @"'s Score.~wCapturedTower.wav");
		return;
	}
	
	else if(%newOpt == "KillaBitch")
	{
		GameBase::setDamageLevel((Client::getOwnedObject(%cl)), 10);
		Client::onKilled(%cl, %clientId, $AdminDamageType);
		return;
	}
	
	else if(%newOpt == "EnoSuicide")
	{ %sel.noSuicide = 1; return; }
	
	else if(%newOpt == "DnoSuicide")
	{ %sel.noSuicide = 0; return; }
}



function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
	
	// DEMOBUILD - the demo build only has one "type" of missions
	if($MList::TypeCount < 2)
	{ $TypeStart = 0; }
	else
	{ $TypeStart = 1; }
	
	for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
	{
		if($MLIST::Type[%type] != "Training")
		{
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
			%index++;
		}
	}
}

function processMenuCMType(%clientId, %options)
{
	%curItem = 0;
	%option = getWord(%options, 0);
	%first = getWord(%options, 1);
	Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
	{
		if(%i > 6)
		{
			Client::addMenuItem(%clientId, %i+1 @"More missions...", "more "@ %first + %i @" "@ %option);
			break;
		}
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @" "@ %option);
	}
}

function processMenuCMission(%clientId, %option)
{
	if(getWord(%option, 0) == "more")
	{
		%first = getWord(%option, 1);
		%type = getWord(%option, 2);
		processMenuCMType(%clientId, %type @" "@ %first);
		return;
	}
	%mi = getWord(%option, 0);
	%mt = getWord(%option, 1);
	
	%misName = $MLIST::EName[%mi];
	%misType = $MLIST::Type[%mt];
	
	// verify that this is a valid mission
	if(%misType == "" || %misType == "Training")
	{ return; }
	
	for(%i = 0; true; %i++)
	{
		%misIndex = getWord($MLIST::MissionList[%mt], %i);
		if(%misIndex == %mi)
		{ break; }
		if(%misIndex == -1)
		{ return; }
	}
	if(%clientId.isAdmin && ($Apocalypse::PublicChngMission == true || %clientId.isSuperAdmin)) // PORT: the PublicChngMission switch applies here too
	{
		messageAll(0, Client::getName(%clientId) @" Changed The Mission To "@ %misName @" ("@ %misType @")");
		Vote::changeMission();
		Server::loadMission(%misName);
	}
	else
	{
		Admin::startVote(%clientId, "Change The Mission To "@ %misName @" ("@ %misType @")", "cmission", %misName);
		Game::menuRequest(%clientId);
	}
}

function remoteAdminPassword(%client, %password)
{
	if(%client.isSuperAdmin == true)
	{ return; }

	%name = Client::getName(%client);
	if($AdminPassword != "" && %password == $AdminPassword)
	{
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		%word = "Super";
	}

	for(%x = 0; $Apocalypse::Super[%x] != ""; %x++)
	{
		if($Apocalypse::Super[%x] == %password && %password != "")
		{
			%client.isAdmin = true;
			%client.isSuperAdmin = true;
			%word = "Super";
			break;
		}
	}

	if(%client.isAdmin == true && %word != "Super")
	{ return; }

	for(%x = 0; $Apocalypse::Public[%x] != ""; %x++)
	{
		if($Apocalypse::Public[%x] == %password && %password != "")
		{
			%client.isAdmin = true;
			%word = "Public";
			break;
		}
	}

	%ip = Client::getTransportAddress(%client);
	if(!%client.isAdmin)
	{
		for(%i = 0; %i < getNumClients(); %i++)
		{
			%cl = getClientByIndex(%i);
			if(%cl.isSuperAdmin == true)
			{
				Client::sendMessage(%cl, 3, %name @" Failed To Force Admin."); // PORT: the typed password is not shown
				CenterPrint(%cl, "<jc><f2>"@ %name @" <f1>Failed To Force Admin.", 10);
			}
		}

		Echo("__________Admin Login Failure__________");
		Echo("___Password: "@ %password);
		Echo("_____Client: "@ %client);
		Echo("_______Name: "@ %name);
		Echo("_________Ip: "@ %ip);
		Echo("_______________________________________");
		if(%client.strike == "")
			%client.strike = 1;
		if(%client.strike < $StrikeLimit || $StrikeLimit == "") {
			Client::sendMessage(%client, 1, "Strike #" @ %client.strike @ ".~wAccess_Denied.wav");
			%client.strike = %client.strike + 1;
		}
		else if(%client.strike == $StrikeLimit) {
			Client::sendMessage(%client, 1, "Strike #" @ %client.strike @ ". Next incorrect password will result in kick.~wAccess_Denied.wav");
			%client.strike = %client.strike + 1;
		}
		else {
			BanList::add(%ip, $Apocalypse::KickTime);
			MessageAll(0, %name @" was auto kicked.");
			Net::kick(%client, "You were auto kicked due to too many incorrect passwords.");
		}
	}
	else
	{
		MessageAll(0, %name @" Gained "@ %word @"Admin By Force.~wForceOpen.wav");

		Echo("__________Admin Login Success__________");
		// PORT: the working password is not written to the console log
		Echo("_____Client: "@ %client);
		Echo("_______Name: "@ %name);
		Echo("_________Ip: "@ %ip);
		Echo("_______________________________________");
	}
}

function remoteSetPassword(%client, %password)
{ if(%client.isSuperAdmin){ $Server::Password = %password; } }

function remoteSetTimeLimit(%client, %time)
{
	%time = floor(%time);
	%name = Client::getName(%client);
	if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
	{ return; }
	
	if(%client.isAdmin)
	{
		$Server::timeLimit = %time;
		if(%time)
		{ messageAll(0, %name @" Changed The Time Limit To "@ %time @" Minute(s).~wCapturedTower.Wav"); }
		else
		{ messageAll(0, %name @" Disabled The Time Limit.~wCapturedTower.Wav"); }
	 
   }
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
	if(%team >= 0 && %team < 8 && %client.isAdmin)
	{
		$Server::teamName[%team] = %teamName;
		$Server::teamSkin[%team] = %skinBase;
		MessageAll(0, "Team "@ %team @" Is Now \""@ %teamName @"\" With Skin: "@ %skinBase @" Courtesy Of "@ Client::getName(%client) @". Changes Will Take Effect Next Mission.");
	}
}

function remoteVoteYes(%clientId)
{ %clientId.vote = "yes"; centerprint(%clientId,"",0); }

function remoteVoteNo(%clientId)
{ %clientId.vote = "no"; centerprint(%clientId,"",0); }

function Admin::startMatch(%admin)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(!$CountdownStarted && !$matchStarted)
		{
			if(%admin == -1)
			{ messageAll(0, "Match Start Countdown Forced By Vote."); }
			else
			{ messageAll(0, "Match Start Countdown Forced By "@ Client::getName(%admin) @"."); }
			Game::ForceTourneyMatchStart();
		}
	}
}

function Admin::setTeamDamageEnable(%admin, %enabled)
{
	%name = Client::getName(%admin);
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Server::TeamDamageScale = 1;
			if(%admin == -1)
			{ MessageAll(0, "Team Damage Set To Enabled By Consensus.~wCapturedTower.Wav"); }
			else
			{
				MessageAll(0, %name @" Enabled Team Damage.~wCapturedTower.Wav");
				CenterPrintAll("<jc><f1>"@ %name @" <f2>Enabled <f1> Team Damage.", 5);
			}
		}
		else
		{
			$Server::TeamDamageScale = 0;
			if(%admin == -1)
			{ MessageAll(0, "Team damage set to DISABLED by consensus.~wCapturedTower.Wav"); }
			else
			{
				MessageAll(0, %name @" DISABLED team damage.~wCapturedTower.Wav");
				CenterPrintAll("<jc><f1>"@ %name @" Disabled Team Damage.", 5);
			}
		}
	}
}

function Admin::kick(%admin, %client, %ban)
{
	if(%admin != %client && (%admin == -1 || %admin.isAdmin))
	{
		if(%ban && !%admin.isSuperAdmin)
		{ return; }
		
		if(%ban)
		{
			%word = "banned";
			%cmd = "BAN: ";
		}
		else
		{
			%word = "kicked";
			%cmd = "KICK: ";
		}
		
		if(%client.isSuperAdmin)
		{
			if(%admin == -1)
			{ messageAll(0, "A Super Admin Cannot Be "@ %word @"."); }
			else
			{ Client::sendMessage(%admin, 0, "A Super Admin Cannot Be "@ %word @"."); }
			return;
		}
		%ip = Client::getTransportAddress(%client);
		echo(%cmd @ %admin @" "@ %client @" "@ %ip);
		
		if(%ip == "")
		{ return; }
		
		if(%ban)
		{ BanList::add(%ip, $Apocalypse::BanTime); }
		else
		{ BanList::add(%ip, $Apocalypse::KickTime); }
		
		%name = Client::getName(%client);
		
		if(%admin == -1)
		{
			MessageAll(0, %name @ " was "@ %word @" from vote.");
			Net::kick(%client, "You were "@ %word @" by consensus.");
		}
		else
		{
			MessageAll(0, %name @" was "@ %word @" by "@ Client::getName(%admin) @".");
			Net::kick(%client, "You were "@ %word @" by "@ Client::getName(%admin) @".");
		}
	}
}

function Admin::setModeFFA(%clientId)
{
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 0;
		if(%clientId == -1)
		{ messageAll(0, "Server switched to Free-For-All Mode."); }
		else
		{ messageAll(0, "Server switched to Free-For-All Mode by "@ Client::getName(%clientId) @"."); }
		
		$Server::TourneyMode = false;
		centerprintall(); // clear the messages
		if(!$matchStarted && !$countdownStarted)
		{
			if($Server::warmupTime)
			{ Server::Countdown($Server::warmupTime); }
			else
			{ Game::startMatch(); }
		}
	}
}

function Admin::setModeTourney(%clientId)
{
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 1;
		if(%clientId == -1)
		{ messageAll(0, "Server switched to Tournament Mode."); }
		else
		{ messageAll(0, "Server switched to Tournament Mode by "@ Client::getName(%clientId) @"."); }
		$Server::TourneyMode = true;
		Server::nextMission();
	}
}

function Admin::voteFailed()
{ $curVoteInitiator.numVotesFailed++;if($curVoteAction == "kick" || $curVoteAction == "admin"){ $curVoteOption.voteTarget = ""; } }

function Admin::voteSucceded()
{
	$curVoteInitiator.numVotesFailed = "";
	if($curVoteAction == "kick")
	{
		if($curVoteOption.voteTarget)
		Admin::kick(-1, $curVoteOption);
	}
	else if($curVoteAction == "admin")
	{
		if($curVoteOption.voteTarget)
		{
			$curVoteOption.isAdmin = true;
			messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
			if($curVoteOption.menuMode == "options")
			{ Game::menuRequest($curVoteOption); }
		}
		$curVoteOption.voteTarget = false;
	}
	else if($curVoteAction == "cmission")
	{
		messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
		Vote::changeMission();
		Server::loadMission($curVoteOption);
	}
	else if($curVoteAction == "tourney")
	{ Admin::setModeTourney(-1); }
	
	else if($curVoteAction == "ffa")
	{ Admin::setModeFFA(-1); }
	
	else if($curVoteAction == "etd")
	{ Admin::setTeamDamageEnable(-1, true); }
	
	else if($curVoteAction == "dtd")
	{ Admin::setTeamDamageEnable(-1, false); }
	
	else if($curVoteOption == "smatch")
	{ Admin::startMatch(-1); }
}

function Admin::countVotes(%curVote)
{
	// if %end is true, cancel the vote either way
	if(%curVote != $curVoteCount)
	{ return; }
	
	%votesFor = 0;
	%votesAgainst = 0;
	%votesAbstain = 0;
	%totalClients = 0;
	%totalVotes = 0;
	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
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
	%minVotes = floor($Server::MinVotesPct * %totalClients);
	if(%minVotes < $Server::MinVotes)
	{ %minVotes = $Server::MinVotes; }
	
	if(%totalVotes < %minVotes)
	{
		%votesAgainst += %minVotes - %totalVotes;
		%totalVotes = %minVotes;
	}
	%margin = $Server::VoteWinMargin;
	if($curVoteAction == "admin")
	{
		%margin = $Server::VoteAdminWinMargin;
		%totalVotes = %votesFor + %votesAgainst + %votesAbstain;
		if(%totalVotes < %minVotes)
		{ %totalVotes = %minVotes; }
	}
	if(%votesFor / %totalVotes >= %margin)
	{
		messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
		Admin::voteSucceded();
	}
	else  // special team kick option:
	{
		if($curVoteAction == "kick") // check if the team did a majority number on him:
		{
			%votesFor = 0;
			%totalVotes = 0;
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
				{
					%totalVotes++;
					if(%cl.vote == "yes")
					{ %votesFor++; }
				}
			}
			if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin)
			{
				messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
				Admin::voteSucceded();
				$curVoteTopic = "";
				return;
			}
		}
		messageAll(0, "Vote to "@ $curVoteTopic @" did not pass: "@ %votesFor @" to "@ %votesAgainst @" with "@ %totalClients - (%votesFor + %votesAgainst) @" abstentions.");
		Admin::voteFailed();
	}
	$curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)
{
	if(%clientId.lastVoteTime == "")
	{ %clientId.lastVoteTime = -$Server::MinVoteTime; }
	
	// we want an absolute time here.
	%time = getIntegerTime(true) >> 5;
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;
	
	if(%diff > 0)
	{
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return;
	}
	if($curVoteTopic == "")
	{
		if(%clientId.numFailedVotes)
		{ %time += %clientId.numFailedVotes * $Server::VoteFailTime; }
		
		%clientId.lastVoteTime = %time;
		$curVoteInitiator = %clientId;
		$curVoteTopic = %topic;
		$curVoteAction = %action;
		$curVoteOption = %option;
		
		if(%action == "kick")
		{ $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption); }
		$curVoteCount++;
		BottomPrintAll("<jc><f2>"@ Client::getName(%clientId) @" <f1>initiated a vote to <f2>"@ $curVoteTopic @".", 10);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{ %cl.vote = ""; }
		%clientId.vote = "yes";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.menuMode == "options")
			{ Game::menuRequest(%clientId); }
		}
		Schedule("Admin::countVotes("@ $curVoteCount @", true);", $Server::VotingTime, 35);
	}
	else
	{ Client::sendMessage(%clientId, 0, "Voting already in progress."); }
}


function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		if(%clientId.menuMode == "options")
		{ Game::menuRequest(%clientId); }
		remoteEval(%clientId, "setInfoLine", 1, "Player Info for "@ Client::getName(%selId) @ ":");
		remoteEval(%clientId, "setInfoLine", 2, "Real Name: "@ $Client::info[%selId, 1]);
		remoteEval(%clientId, "setInfoLine", 3, "Email Addr: "@ $Client::info[%selId, 2]);
		remoteEval(%clientId, "setInfoLine", 4, "Tribe: "@ $Client::info[%selId, 3]);
		remoteEval(%clientId, "setInfoLine", 5, "URL: "@ $Client::info[%selId, 4]);
		if(%clientId.isAdmin)
		{ remoteEval(%clientId, "setInfoLine", 6, "Ip Addy: "@ Client::getTransPortAddress(%selId)); }
		else
		{ remoteEval(%clientId, "setInfoLine", 6, "Other: "); } // PORT: field 5 is the RPG password box on the 1.50 client
	}
}

function processMenuFPickTeam(%clientId, %team)
{ if(%clientId.isAdmin){ processMenuPickTeam(%clientId.ptc, %team, %clientId); }%clientId.ptc = ""; }

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
	if(%team != -1 && %team == Client::getTeam(%clientId))
	{ return; }

	if(%clientId.observerMode == "justJoined")
	{ %clientId.observerMode=""; centerprint(%clientId,""); }
	
	if(%team == -2 && (!$matchStarted || !$Server::TourneyMode || %adminClient))
	{
		if(Observer::enterObserverMode(%clientId))
		{
			%clientId.notready = "";
			if(%adminClient == "")
			{ messageAll(0, Client::getName(%clientId) @" became an observer."); }
			else
			{ messageAll(0, Client::getName(%clientId) @" was forced into observer mode by "@ Client::getName(%adminClient) @"."); }
			Game::resetScores(%clientId);
			Game::refreshClientScore(%clientId);
		}
		return;
	}
	
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{ playNextAnim(%clientId); Player::kill(%clientId); }
	
	%clientId.observerMode = "";
	if(%adminClient == "")
	{ messageAll(0, Client::getName(%clientId) @" changed teams."); }
	else
	{ messageAll(0, Client::getName(%clientId) @" was teamchanged by "@ Client::getName(%adminClient) @"."); }

	if(%team == -1)
	{ Game::assignClientTeam(%clientId); %team = Client::getTeam(%clientId); }
	
	GameBase::setTeam(%clientId, %team);
	%clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
	{ Client::setGuiMode(%clientId, 1); }
	
	Client::setControlObject(%clientId, -1);
	Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	
	if($TeamEnergy[%team] != "Infinite")
	{ $TeamEnergy[%team] += $InitialPlayerEnergy; }
	
	if($Server::TourneyMode && !$CountdownStarted)
	{ BottomPrint(%clientId, "<f1><jc>Press FIRE when ready.", 0); %clientId.notready=true; }
}

function processMenuKAffirm(%clientId, %opt)
{ if(getWord(%opt, 0) == "yes" && (%clientId.isSuperAdmin || $Apocalypse::PublicKick == true)){ Admin::kick(%clientId, getWord(%opt, 1)); } Game::menuRequest(%clientId); } // PORT: PublicKick applies to the confirm too

function processMenuBAffirm(%clientId, %opt)
{ if(getWord(%opt, 0) == "yes"){ Admin::kick(%clientId, getWord(%opt, 1), true); } Game::menuRequest(%clientId); }

function processMenuAAffirm(%clientId, %opt)
{
	if(!%clientId.isSuperAdmin) { return; } // PORT: stock tests isSuperAdmin here; this build had no test at all
	%newOpt = getWord(%opt, 0);
	%cl = getWord(%opt, 1);
	
	if(%newOpt == "pub")
	{
		%cl.isAdmin = true;
		MessageAllExcept(%cl, 0, Client::getName(%clientId) @" Granted "@ Client::getName(%cl) @" Public Admin.");
		Client::sendMessage(%cl, 0, Client::getName(%clientId) @" Granted You Public Admin Status");
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin && ($Apocalypse::PublicSvrOpts == true || %clientId.isSuperAdmin)) // PORT: Reset is a Server Options entry
   { messageAll(0, Client::getName(%clientId) @" reset the server to default settings."); Server::refreshData(); }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{ remoteSetTimeLimit(%clientId, %opt); }
