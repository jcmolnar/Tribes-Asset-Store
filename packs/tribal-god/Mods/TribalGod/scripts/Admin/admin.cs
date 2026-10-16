// Admin.cs
// Originally By Plasmatic in his Annihilation Mod,
// Changed to better fit my mod. -]KyA[X-Ecutioner

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

//==========================================================================================
// INITIAL MENU:
function Game::menuRequest(%clientId){
	if(!%clientId.isGodAdmin && %clientId.isPossessed){
		return;
	}
	%clientIdName = Client::getName(%clientId);
	%curItem = 0;
	%clientId.MissVote = "";
	
	if(%clientId.selClient){
		%cl = %clientId.selClient;
		%clName = Client::getName(%cl);
		%status = Client::getStatus(%cl);
		Client::buildMenu(%clientId, ""@ %clName @"", "Options", true);
		if(%clientId.isAdmin){
			Client::addMenuItem(%clientId, %curItem++ @"Change Their Team", "fteamchange "@ %cl);
			if(%clientId.isGodAdmin)
			{ Client::addMenuItem(%clientId, %curItem++ @"Torture", "BAnAss "@ %cl); }
			Client::addMenuItem(%clientId, %curItem++ @"Manage", "ManageMAIN "@ %cl);
			if(%clientId.isSuperAdmin)
			{ Client::addMenuItem(%clientId, %curItem++ @"TelePort", "teleopt "@ %cl); }
		}
		if(%clientId != %clientId.selClient){
			if(%clientId.whisper == "") Client::addMenuItem(%clientId, %curItem++ @"Whisper", "whisper "@ %cl);
			else Client::addMenuItem(%clientId, %curItem++ @"Cancel Whisper", "nowhisper "@ %cl);
		}
		if(%cl.isGodAdmin != true || %clientId.isGodAdmin == true && %cl.isGodAdmin != true){
			if(%clientId.muted[%cl]) Client::addMenuItem(%clientId, %curItem++ @"Personal Unmute", "unmute "@ %cl);
			else Client::addMenuItem(%clientId, %curItem++ @"Personal Mute", "mute "@ %cl);
		}
		if(%clientId.observerMode == "observerOrbit" && !%clientId.issuperAdmin && !%clientId.isAdmin)
		{ Client::addMenuItem(%clientId, %curItem++ @"Observe", "observe "@ %cl); }
		if($curVoteTopic == "" && !$NoVote && !%clientId.isAdmin)
		{ Client::addMenuItem(%clientId, %curItem++ @"Vote To..", "voteToPlayer "@ %cl); }
		return;
	}else{
		Client::buildMenu(%clientId, "[TG] Server Opts","options",true);
		if($curVoteTopic != "" && %clientId.vote == "" && !%clientId.isAdmin){
			Client::addMenuItem(%clientId, %curItem++ @"Vote YES to "@ $curVoteTopic, "voteYes "@ $curVoteCount);
			Client::addMenuItem(%clientId, %curItem++ @"Vote NO to "@ $curVoteTopic , "voteNo "@ $curVoteCount);
			return;
		}else{
			if(!$matchStarted || !$Server::TourneyMode){
				Client::addMenuItem(%clientId, %curItem++ @"Change Teams/Observe", "changeteams");
				Client::addMenuItem(%clientId, %curItem++ @"Customize Character" , "character");
			}
			if($curVoteTopic == "" && %clientId.isGodAdmin){
				if($NoVote == 1) 
				{ Client::addMenuItem(%clientId, %curItem++ @"Enable voting", "eVote"); }
				else 
				{ Client::addMenuItem(%clientId, %curItem++ @"[TG] Voting Options", "vote"); }
			}
			else if($curVoteTopic == "" && !%clientId.isAdmin && !$NoVote){
				Client::addMenuItem(%clientId, %curItem++ @"Vote Mission ", "voteMiss");
				Client::addMenuItem(%clientId, %curItem++ @"Vote Time "   , "voteTime");
				Client::addMenuItem(%clientId, %curItem++ @"Vote Damage " , "voteDamage");
			}
			if($curVoteTopic != "" && %clientId.isGodAdmin && !$curVoteForce)
			{ Client::addMenuItem(%clientId, %curItem++ @"Force Vote", "voteForce"); }
			if(%clientId.isAdmin){
				Client::addMenuItem(%clientId, %curItem++ @"Mission Menu", "mapMenu");
				if(%clientId.isSuperAdmin)
				{ Client::addMenuItem(%clientId, %curItem++ @"Damage Menu", "damageMenu"); }
				if(%clientId.isGodAdmin){
					Client::addMenuItem(%clientId, %curItem++ @"Server Opts Menu", "ServerOptions");
					Client::addMenuItem(%clientId, %curItem++ @"Destroy/Repair Opts", "Equipment");
				}
			}
			Client::addMenuItem(%clientId, %curItem++ @"Mod Info", "ModInfo");
		}
	}
}

function remoteAdminPassword(%client, %password){
	%ip = Client::getTransportAddress(%client);
	%clientName = Client::getName(%client);
	
	if(%client.passprotect == true){
		return;
	}else{
		%client.passprotect = true;
		Schedule(%client @".passprotect = false;", 3);// Only One Pass Every 3 Seconds.
	}
	if($TG::GodPassword != "" && %password == $TG::GodPassword){ 
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		%client.isGodAdmin = true;
		MessageAll(0, %clientname @" became a GodAdmin by force.~wForceOpen.wav");
		echo("---------------------------------------------------------------------------");
		echo("-----------Admin Login Successful");
		echo("-----------Name:     "@ %clientName);
		echo("-----------Ip:       "@ %ip);
		//PORT-OFF: echo("-----------PASSWORD: "@ %password);
		echo("---------------------------------------------------------------------------");
	}
	for(%x = 0; %x < 10; %x += 1){
		if($TG::SADPassword[%x] != "" && %password == $TG::SADPassword[%x]){
			%client.isAdmin = true;
			%client.isSuperAdmin = true;
			MessageAll(0, %clientname @ " became a SuperAdmin by force.~wForceOpen.wav");
			echo("---------------------------------------------------------------------------");
			echo("-----------Admin Login Successful");
			echo("-----------Name:     "@ %clientName);
			echo("-----------Ip:       "@ %ip);
			//PORT-OFF: echo("-----------PASSWORD: "@ %password);
			echo("---------------------------------------------------------------------------");
			break;
		}
		else if($TG::PAPassword[%x] != "" && %password == $TG::PAPassword[%x]){
			%client.isAdmin = true;
			MessageAll(0, %clientname @ " became a PublicAdmin by force.~wForceOpen.wav");
			echo("---------------------------------------------------------------------------");
			echo("-----------Admin Login Successful");
			echo("-----------Name:     "@ %clientName);
			echo("-----------Ip:       "@ %ip);
			//PORT-OFF: echo("-----------PASSWORD: "@ %password);
			echo("---------------------------------------------------------------------------");
			break;
		}
	}
	if(%client.isAdmin == true){
		return;
	}
	//PORT-OFF: $console::logmode = "1";
	echo("---------------------------------------------------------------------------");
	echo("-----------ADMIN LOGIN FAILURE");
	echo("-----------Name:     "@ %clientName);
	echo("-----------Ip:       "@ %ip);
	//PORT-OFF: echo("-----------PASSWORD: "@ %password);
	echo("-----------ADMIN LOGIN FAILURE");
	echo("---------------------------------------------------------------------------");
	MessageAllAdmins(0, %clientName @" has just failed to force admin.");
}
//---------------------------------------------------------------------------------------------------------------------
function MissMenu(%clientId, %admin){
	Client::buildMenu(%clientId, "Mission Options:", "Mission", true);
	if(%admin){
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		Client::addMenuItem(%clientId, %curItem++ @ "Start next mission", "nextMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Restart mission", "ReplayMap");
		Client::addMenuItem(%clientId, %curItem++ @ "Random mission", "randomMiss");
	}else{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote start next mission", "VnextMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to restart mission", "VReplayMap");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote random mission", "VrandomMiss");
	}
}
//---------------------------------------------------------------------------------------------------------------------
function TimeMenu(%clientId, %admin){
	if(%admin){
		Client::buildMenu(%clientId, "Time Options:", "CTLimit"  , true);
		Client::addMenuItem(%clientId, %curItem++ @ "10 minutes" , "10");
		Client::addMenuItem(%clientId, %curItem++ @ "15 minutes" , "15");
		Client::addMenuItem(%clientId, %curItem++ @ "20 minutes" , "20");
		Client::addMenuItem(%clientId, %curItem++ @ "30 minutes" , "30");
		Client::addMenuItem(%clientId, %curItem++ @ "45 minutes" , "45");
		Client::addMenuItem(%clientId, %curItem++ @ "60 minutes" , "60");
		Client::addMenuItem(%clientId, %curItem++ @ "120 minutes", "120");
		Client::addMenuItem(%clientId, %curItem++ @ "unlimited"  , "0");
	}else{
		Client::buildMenu(%clientId, "Vote Time Options:", "VTime", true);
		Client::addMenuItem(%clientId, %curItem++ @ "10 minutes"  , "10");
		Client::addMenuItem(%clientId, %curItem++ @ "15 minutes"  , "15");
		Client::addMenuItem(%clientId, %curItem++ @ "20 minutes"  , "20");
		Client::addMenuItem(%clientId, %curItem++ @ "30 minutes"  , "30");
		Client::addMenuItem(%clientId, %curItem++ @ "45 minutes"  , "45");
		Client::addMenuItem(%clientId, %curItem++ @ "60 minutes"  , "60");
		Client::addMenuItem(%clientId, %curItem++ @ "120 minutes" , "120");
		Client::addMenuItem(%clientId, %curItem++ @ "unlimited"   , "0");
	}
}

function DamageMenu(%clientId, %admin){	
	if(%admin){
		Client::buildMenu(%clientId, "Damage Options:", "Damage", true);
		// team damage
		if($Server::TeamDamageScale == 1.0)
		{ Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd"); }
		//player damage		
		if($NoPlayerDamage  == 1)
		{ Client::addMenuItem(%clientId, %curItem++ @ "Enable player damage", "ePlayerD"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @ "Disable player damage", "dPlayerD"); }
	}else{
		Client::buildMenu(%clientId, "Vote Damage Options:", "Damage", true);
		if($Server::TeamDamageScale == 1.0)
		{ Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "vdtd"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "vetd"); }
		//player damage		
		if($NoPlayerDamage  == 1)
		{ Client::addMenuItem(%clientId, %curItem++ @ "Enable player damage", "vePlayerD"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @ "Disable player damage", "vdPlayerD"); }
	}
}

function voteMenu(%clientId){
	Client::buildMenu(%clientId, "Mission Options:", "Vote", true);
	if(%clientId.isSuperAdmin){
		// vote admin	
		if(!$TG::VoteAdmin)
		{ Client::addMenuItem(%clientId, %curItem++ @"Enable vote admin", "eVoteAdmin"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Disable vote admin", "dVoteAdmin"); }		
		if(%clientId.isGodAdmin){
			if($NoVote == 1)
			{ Client::addMenuItem(%clientId, %curItem++ @"Enable voting", "eVote"); }
			else
			{ Client::addMenuItem(%clientId, %curItem++ @"Disable voting", "dVote"); }
		}
	}else{
		Client::addMenuItem(%clientId, %curItem++ @"Vote Mission ", "voteMiss");
		Client::addMenuItem(%clientId, %curItem++ @"Vote Time "   , "voteTime");
		Client::addMenuItem(%clientId, %curItem++ @"Vote Damage " , "voteDamage");
	}
}

function PlayerManage(%clientId, %sel){
	if(%clientId.isadmin){
		%name = Client::getName(%sel);
		Client::buildMenu(%clientId, "Manage "@ %name, "player", true);
		Client::addMenuItem(%clientId, %curItem++ @"Change team", "fteamchange "@ %sel);
		if(%sel.locked) Client::addMenuItem(%clientId, %curItem++ @"Unlock team", "unlock "@ %sel);
		else Client::addMenuItem(%clientId, %curItem++ @"Lock team"  , "lock "@ %sel);	 
		Client::addMenuItem(%clientId, %curItem++ @"Clear score", "ClearScore "@ %sel);
		if(%sel.silenced) Client::addMenuItem(%clientId, %curItem++ @"Global UNMUTE", "unsilence "@ %sel);
		else Client::addMenuItem(%clientId, %curItem++ @"Global MUTE ", "silence "@ %sel);
		if(%sel.observerMode != "observerFly" && %sel.observerMode != "observerOrbit") Client::addMenuItem(%clientId, %curItem++ @"Observe (in game) ", "obsingame "@ %sel);
		if(!%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @"Admin " @ %name , "Admin "@ %sel);  
		if($TG::PAStripAdmin != true && %clientId.isAdmin && !%clientId.isSuperAdmin && !%clientId.isGodAdmin) return;
		if(%sel.isGodAdmin) return;
		if(%sel.isAdmin && !%sel.isSuperAdmin) Client::addMenuItem(%clientId, %curItem++ @"Strip Admin -"@ %name , "stripAdmin "@ %sel);
		if(!%sel.isAdmin || (%clientId.isGodAdmin && !%sel.isGodAdmin)) Client::addMenuItem(%clientId, %curItem++ @"Kick "@ %name, "kick "@ %sel);
		if(%clientId.isSuperAdmin && !%sel.isSuperAdmin) Client::addMenuItem(%clientId, %curItem++ @"Ban "@ %name , "ban "@ %sel); 
	 } 
}

function PlayerFlag(%clientId, %sel){
	if(%clientId.isAdmin){
		%name = Client::getName(%sel);
		%type = Player::getMountedItem(%sel, $FlagSlot);	
		Client::buildMenu(%clientId, "Flag Fun with "@ %name, "player", true);
		if(Client::getStatus(%sel) == "(Live)" && %type != -1){
			Client::addMenuItem(%clientId, %curItem++ @"Strip Flag", "StripFlag " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @"Return Flag", "ReturnFlag " @ %sel);
		}else{
			Client::addMenuItem(%clientId, %curItem++ @"Strip Flag -NA "@ player::status(%sel), "Freturn " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @"Return Flag -NA "@ player::status(%sel), "Freturn " @ %sel);	 
		}
		if(%sel.FlagCurse) Client::addMenuItem(%clientId, %curItem++ @"Remove Happy Flag Curse", "NoFlagCurse "@ %sel);
		else Client::addMenuItem(%clientId, %curItem++ @"Happy Flag Curse", "FlagCurse "@ %sel);
	}
}

function PlayerKill(%clientId, %sel){
	if(%clientId.isadmin){
		echo("Player::isDead(%sel) "@Player::isDead(Client::getOwnedObject(%sel)));
		%name = Client::getName(%sel);
		Client::buildMenu(%clientId, "Kill "@%name, "player", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Blow up " @ %name, "BlowUp " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Sniper kill " @ %name, "Sniper " @ %sel);	 
		Client::addMenuItem(%clientId, %curItem++ @ "Poison " @ %name, "Poison " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Set on fire " @ %name, "Burn " @ %sel);
		if(Player::isDead(Client::getOwnedObject(%sel)) || Client::getOwnedObject(%sel) == -1 && Client::getTeam(%sel) != -1)
		Client::addMenuItem(%clientId, %curItem++ @ "Spawn " @ %name, "spawn " @ %sel);
		else if (Client::getOwnedObject(%sel) != -1 && Client::getTeam(%sel) != -1)
		Client::addMenuItem(%clientId, %curItem++ @ "Respawn " @ %name, "respawn " @ %sel);
	}
}

function voteToPlayer(%clientId, %sel){
	%name = Client::getName(%sel);
	Client::buildMenu(%clientId, "Start Vote on "@ %name, "options", true);
	if(Client::getStatus(%sel) == "(Live)"){
		Client::addMenuItem(%clientId, %curItem++ @"Vote to freeze ", "vfreeze "@ %sel);
		Client::addMenuItem(%clientId, %curItem++ @"Vote to poison ", "vpoison "@ %sel);
	}else{
		Client::addMenuItem(%clientId, %curItem++ @"Freeze -NA, "@ Client::getStatus(%sel), "voteToPlayer "@ %sel);
		Client::addMenuItem(%clientId, %curItem++ @"Poison -NA, "@ Client::getStatus(%sel), "voteToPlayer "@ %sel); 	
	}
	if(%sel.silenced){
		Client::addMenuItem(%clientId, %curItem++ @"vote Global UNMUTE", "vunsilence "@ %sel);
	}else{
		Client::addMenuItem(%clientId, %curItem++ @"vote to silence ", "vsilence " @ %sel); 		 
		Client::addMenuItem(%clientId, %curItem++ @"Vote to kick ", "vkick " @ %sel);
	}
	if($TG::VoteAdmin){
		Client::addMenuItem(%clientId, %curItem++ @"Vote to admin ", "vadmin "@ %sel);
	}
}

function voteForce(%clientId){
	Client::buildMenu(%clientId, "Force Vote:", "options", true);
	Client::addMenuItem(%clientId, %curItem++ @ "PASS " @ $curVoteTopic, "forceyes " @ $curVoteCount); 
	Client::addMenuItem(%clientId, %curItem++ @ "FAIL " @ $curVoteTopic, "forceno " @ $curVoteCount); 
}

function ServerOptions(%clientId){
	if(!%clientId.isadmin) return;
	Client::buildMenu(%clientId, "Server Options:", "Server", true);
	if($TG::FairTeams == 1) Client::addMenuItem(%clientId, %curItem++ @"Disable fair teams", "dFair");
	else Client::addMenuItem(%clientId, %curItem++ @"Enable fair teams", "eFair");
	Client::addMenuItem(%clientId, %curItem++ @"Change Time", "time");		
	if($NoFlagCaps == 1) Client::addMenuItem(%clientId, %curItem++ @"Enable Flag captures", "eFlag");
	else Client::addMenuItem(%clientId, %curItem++ @"Disable Flag captures", "dFlag");
	if(%clientId.isSuperAdmin){
		if($TG::obsAlert != true) Client::addMenuItem(%clientId, %curItem++ @ "Observer alert on ", "obsAlertOn");
		else Client::addMenuItem(%clientId, %curItem++ @ "Observer alert off ", "obsAlertOff");
		if($TG::UsePersonalSkin != true) Client::addMenuItem(%clientId, %curItem++ @"Allow custom skins ", "skinsOn");
		else Client::addMenuItem(%clientId, %curItem++ @"Custom skins off ", "skinsOff");
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	}
}

function EquipmentOptions(%clientId){
	if(!%clientId.isadmin) return;
	Client::buildMenu(%clientId, "Equipment Options:", "Server", true);
	Client::addMenuItem(%clientId, %curItem++ @"Turret menu", "turret");
	Client::addMenuItem(%clientId, %curItem++ @"Generators", "Generator");
	Client::addMenuItem(%clientId, %curItem++ @"Stations", "Station");
	Client::addMenuItem(%clientId, %curItem++ @"Combination", "Combined");	
}

function Admin::observe(%clientId, %cl){
	%clientId.AdminobserverMode = "AdminObserve";
	%clientId.observerTarget = %cl;	
	bottomprint(%clientId, "<jc>Observing "@ Client::getName(%cl) @", Press Space bar (Jump) to return to game.", 25);
	%player = Client::getOwnedObject(%clientId);
	%clientId.observerTarget = %cl;
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %cl, 5, 5, 5);	
	if($debug)
	echo("observer "@ %clientId @" observeee "@ %cl);	
}