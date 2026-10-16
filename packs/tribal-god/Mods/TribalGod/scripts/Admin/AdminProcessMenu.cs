// The admin files im guessing are about 1/3rd of the total code in this mod, 
// which means yes, thats one big mo fo. This is my attempt of splitting it
// up to make finding SHIT easier than b4. ;) - [TG]-X-Ecutioner

// OPTIONS MENU:
function processMenuOptions(%clientId, %option){
	%opt = getWord(%option, 0);
	%cl = floor(getWord(%option, 1)); // PORT: a client id is a number
	%clName = Client::getName(%cl);
	%curItem = 0;
	
	if(%opt == "fteamchange" && %clientId.isAdmin){
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
		{ Client::addMenuItem(%clientId, (%i +2) @ getTeamName(%i), %i); }
		return;
	}else if(%opt == "character"){
		Client::buildMenu(%clientId, "Character Options", "character2", true);
		Client::addMenuItem(%clientId, %curItem++ @"Weapon Options" , "weaponopts");
		Client::addMenuItem(%clientId, %curItem++ @"Pack Options"   , "packopts");
		Client::addMenuItem(%clientId, %curItem++ @"Spawn Options"  , "spawnopts");
		Client::addMenuItem(%clientId, %curItem++ @"Help Settings"  , "hlpset");
		return;
	}else if(%opt == "BAnAss" && %clientId.isGodAdmin){
		if(%cl.isX == true){
			return;
		}
		Client::buildMenu(%clientId, "Be An Ass To "@ %clName, "BAnAss", true);
		if(%cl.isPossessed){
			Client::addMenuItem(%clientId, %curItem++ @"Un Possess "@ %name, "UNposs "@ %cl);
		}else{
			Client::addMenuItem(%clientId, %curItem++ @"Possess "@ %name, "Poss "@ %cl);
		}
		Client::addMenuItem(%clientId, %curItem++ @"Strip "@ %name @"'s Weps", "Droptheshit "@ %cl);
		if(Client::getStatus(%cl) == "(Live)")
		{ Client::addMenuItem(%clientId, %curItem++ @"Kill", "KillaBitch "@ %cl); }
		if(!%cl.isFrozen){
			Client::addMenuItem(%clientId, %curItem++ @"Freeze "@ %name, "Freeze "@ %cl);
		}else{
			Client::addMenuItem(%clientId, %curItem++ @"UnFreeze "@ %name, "UnFreeze "@ %cl);
		}
		if(%cl.score != 0){
			Client::addMenuItem(%clientId, %curItem++ @"Clear His Score", "resetScore "@ %cl);
		}
		if(%cl.nosuicide == 0){
			Client::addMenuItem(%clientId, %curItem++ @"Enable No Suicide", "EnoSuicide "@ %cl);
		}else{
			Client::addMenuItem(%clientId, %curItem++ @"Disable No Suicide", "DnoSuicide "@ %cl);
		}
		if(%clientId.isSuperAdmin){
			Client::addMenuItem(%clientId, %curItem++ @"Kick "@ %name, "kick "@ %cl);
			if(%clientId.isGodAdmin){
				Client::addMenuItem(%clientId, %curItem++ @"Ban "@ %name , "ban "@ %cl);
			}
		}
		return;
	}else if (%opt == "teleopt" && %clientId.isSuperAdmin){
		Client::buildMenu(%clientId, "Teleport Options:", "MsadOp", true);
		Client::addMenuItem(%clientId, %curItem++ @"Tele. to Client", "tele "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"Tele. Client to You", "telecl "@ %cl);
		return;
	}else if(%opt == "changeteams"){
		if(%clientId.locked){
			return;
		}
		if(!$matchStarted || !$Server::TourneyMode){
			Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
			if($TG::PublicObsOn == true || %clientId.isAdmin)
			{ Client::addMenuItem(%clientId, "0Observer", -2); }
			Client::addMenuItem(%clientId, "1Automatic", -1);
			for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
			return;
		}
	}else if(%opt == "mute"){
		MessageAllExcept(%cl, 0, Client::getName(%clientId) @" is no longer listening to "@ Client::getName(%cl) @".");
		Client::sendMessage(%cl, 0, Client::getName(%clientId)@" is no longer listening to you.");
		%clientId.muted[%cl] = true;
	}else if(%opt == "unmute"){
		messageAllExcept(%cl, 0, Client::getName(%clientId) @" is listening to "@ Client::getName(%cl) @" again.");
		Client::sendMessage(%cl, 0, Client::getName(%clientId) @" is listening to you again.");
		%clientId.muted[%cl] = "";
	}else if(%opt == "vkick"&& !$NoVote){
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
	}else if(%opt == "vadmin" && !$NoVote && $TG::VoteAdmin){
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
	}else if(%opt == "vfreeze"&& !$NoVote){
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "freeze " @ Client::getName(%cl), "freeze", %cl);
	}else if(%opt == "vpoison"&& !$NoVote){
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "poison " @ Client::getName(%cl), "poison", %cl);
	}else if(%opt == "vsilence"&& !$NoVote){
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "Detongue " @ Client::getName(%cl), "silence", %cl);
	}else if(%opt == "vunsilence"&& !$NoVote){
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "UNMUTE " @ Client::getName(%cl), "unsilence", %cl);
	}else if(%opt == "vote" && !$NoVote){	
		voteMenu(%clientId);
		return;
	}else if(%opt == "eVote" && %clientId.isGodAdmin){
		ServerSwitches(%clientId, "Voting", true);
		return;
	}else if(%opt == "voteToPlayer" && !$NoVote){
		voteToPlayer(%clientId, %cl);
		return;
	}else if(%opt == "voteForce" && %clientId.isadmin){	
		voteForce(%clientId);
		return;
	}else if(%opt == "adminMenu" && %clientId.isadmin){	
		adminMenu(%clientId);
		return;
	}else if(%opt == "vcmission" && !$NoVote){
		%clientId.MissVote = true;
		Admin::changeMissionMenu(%clientId, %opt == "vcmission");
		return;
	}else if(%opt == "mapMenu" && %clientId.isadmin){
		MissMenu(%clientId,true);
		return;
	}else if(%opt == "voteMiss" && !$NoVote){
		MissMenu(%clientId,false);
		return;
	} else if(%opt == "voteTime" && !$NoVote){
		TimeMenu(%clientId,false);
		return;
	}else if(%opt == "damageMenu" && %clientId.isadmin){
		DamageMenu(%clientId,true);
		return;
	}else if(%opt == "voteDamage" && !$NoVote){
		DamageMenu(%clientId,false);
		return;
	}else if(%opt == "ServerOptions" && %clientId.isGodAdmin){
		ServerOptions(%clientId);
		return;
	}else if(%opt == "Equipment" && %clientId.isGodAdmin){
		EquipmentOptions(%clientId);
		return;
	}else if(%opt == "ModInfo"){
		TG::DisplayModInfo(%clientId);
		return;
	}else if(%opt == "cffa" && %clientId.isadmin){
		Client::buildMenu(%clientId, "Confirm Free For All Mode:", "ccffa", true);
		Client::addMenuItem(%clientId, "1Reset to Free For All Mode.", "yes" );
		Client::addMenuItem(%clientId, "2Don't switch to Free for all.", "no" );
		return;
	}else if(%opt == "ctourney" && %clientId.isadmin){
		Client::buildMenu(%clientId, "Confirm Tournament Mode:", "cctourney", true);
		Client::addMenuItem(%clientId, "1Reset to Tournament Mode.", "yes");
		Client::addMenuItem(%clientId, "2Don't switch to Tournament.", "no");
		return;
	}else if(%opt == "forceyes" && %cl == $curVoteCount && %clientId.isadmin){ 
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " forced the current vote to PASS!");
		$curVoteForce = "YES";
		return;
	}else if(%opt == "forceno" && %cl == $curVoteCount && %clientId.isadmin){ 
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " forced the current vote to FAIL!");
		$curVoteForce = "NO";
		return;
	}else if(%opt == "voteYes" && %cl == $curVoteCount){
		%clientId.vote = "yes";
		centerprint(%clientId, "", 0);
		return;
	}else if(%opt == "voteNo" && %cl == $curVoteCount){
		%clientId.vote = "no";
		centerprint(%clientId, "", 0);
		return;
	}else if(%opt == "whisper"){
		if(%clientId.whisper)
		{ Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.whisper) @"."); }
		%clientId.whisper = %cl;
		Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%cl) @ ".");
		return;
	}else if(%opt == "nowhisper"){
		%clientId.whisper = "";
		Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%cl) @ ".");
		return;
	}else if(%opt == "kick" && %clientId.isadmin){
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick "@ Client::getName(%cl), "yes "@ %cl);
		Client::addMenuItem(%clientId, "2Don't kick "@ Client::getName(%cl), "no "@ %cl);
		return;
	}else if(%opt == "admin" && %clientId.isadmin){
		Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}else if(%opt == "ban" && %clientId.isadmin && %clientId.issuperadmin){
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
		return;
	}else if(%opt == "smatch" && %clientId.isadmin){
		Admin::startMatch(%clientId);
	}else if(%opt == "cmission" && %clientId.isadmin){
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}else if(%opt == "reset" && %clientId.isSuperAdmin){
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes");
		Client::addMenuItem(%clientId, "2Don't Reset", "no");
		return;
	}else if(%opt == "observe"){
		Observer::setTargetClient(%clientId, %cl);
		return;
	}else if(%opt == "ManageMAIN" && %clientId.isAdmin){
		Client::buildMenu(%clientId, "Main Manage Menu: "@ %name, "Manage2", true);
		if(%clientId.isSuperAdmin){
			Client::addMenuItem(%clientId, "1Check Alias", "aliascheck "@ %cl);
			if(%cl.silenced)
			{ Client::addMenuItem(%clientId, "2Global UNMUTE", "unsilence "@ %cl); }
			else
			{ Client::addMenuItem(%clientId, "2Global MUTE ", "silence "@ %cl); }
			Client::addMenuItem(%clientId, "3Manage "@ %clName, "Manage "@ %cl);
			Client::addMenuItem(%clientId, "4Spawn "@ %clName, "spawn "@ %cl);
			Client::addMenuItem(%clientId, "5Flag Fun With "@ %clName , "flag "@ %cl);
			return;
		}else{
			Client::addMenuItem(%clientId, "1Spawn "@ %clName, "spawn "@ %cl);
			Client::addMenuItem(%clientId, "2Flag Fun With "@ %clName , "flag "@ %cl);
		}
	    return;
    }
	Game::menuRequest(%clientId);
}
//==========================================================================================
function processMenuBAnAss(%clientId, %option)
{
	%newOpt = getWord(%option, 0);
	%sel = getWord(%option, 1);
	%sel = floor(%sel); // PORT: client text, spliced into schedule() by Freeze / TG::Kick
	if(!%clientId.isGodAdmin) return; // PORT: this handler had no admin test at all
	%cl = %sel; // PORT: was %clientId.selClient; the menu items carry the target as their second word
	
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
		MessageAll(0, Client::getName(%clientId) @" Re-Set "@ Client::getName(%cl) @"'s Score.~wCapturedTower.wav");
		return;
	}
	
	else if(%newOpt == "KillaBitch")
	{
		GameBase::setDamageLevel((Client::getOwnedObject(%cl)), 5);
		Client::onKilled(%cl, %clientId, $AdminDamageType);
		return;
	}
	
	else if(%newOpt == "EnoSuicide")
	{ %sel.nosuicide = 1; return; }
	
	else if(%newOpt == "DnoSuicide")
	{ %sel.noSuicide = 0; return; }
	
	else if(%newOpt == "kick")
	{ TG::Kick(%clientId, %cl); return; }
	
	else if(%newOpt == "ban")
	{ TG::Bann(%clientId, %cl); return; }
}
//==========================================================================================
function processMenuMsadOp(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!%clientId.isSuperAdmin) return; // PORT
	%cl = floor(%cl);
	if (%opt == "tele") 
	{
		Client::buildMenu(%clientId, "Confirm Teleport:", "taffirm", true);
		Client::addMenuItem(%clientId, "1Teleport above " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Teleport " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if (%opt == "telecl") 
	{
		Client::buildMenu(%clientId, "Confirm Teleport:", "tcaffirm", true);
		Client::addMenuItem(%clientId, "1Teleport Client to You", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Teleport Client", "no " @ %cl);
		return;
	}
}

function processMenuTAffirm(%clientId, %opt)
{
	%cl = getWord(%opt, 1);
	if(!%clientId.isSuperAdmin) return; // PORT
	%cl = floor(%cl);
	if(getWord(%opt, 0) == "yes")
	{
		%pos = Vector::add(GameBase::getPosition(%cl), "0 2 2");
		GameBase::setPosition(%clientId,%pos);
		GameBase::startFadeIn(%clientId);
		playSound(ForceFieldOpen, %pos);
		Game::menuRequest(%clientId);
	}
}

function processMenuTCAffirm(%clientId, %opt)
{
	%cl = getWord(%opt, 1);
	if(!%clientId.isSuperAdmin) return; // PORT
	%cl = floor(%cl);
	if(getWord(%opt, 0) == "yes")
	{
		%pos = Vector::add(GameBase::getPosition(%clientId), "0 2 2");
		GameBase::setPosition(%cl,%pos);
		GameBase::startFadeIn(%cl);
		playSound(ForceFieldOpen, %pos);
		Game::menuRequest(%clientId);
	}
}

//====================================================================================
// MAIN SELECTED CLIENT MENU:
function processMenuManage2(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = floor(getWord(%option, 1)); // PORT
	%sel = %clientId.selClient;
	%name = Client::getName(%sel);
	
	if(!%clientId.isAdmin)
	{ return; }
	
	if(%opt == "aliascheck" && %clientId.isSuperAdmin)
	{ IpLogger::DisplayAlias(%clientId, %cl); }
	
	if(%opt == "silence" && %clientId.isSuperAdmin)
	{ Admin::fun(%clientId, %cl,"De-Tongued");	}
	
   	else if(%opt == "unsilence" && %clientId.isSuperAdmin)
   	{ Admin::fun(%clientId, %cl, "Un-Muted"); }
	
	else if(%opt == "Manage")
	{
		Client::buildMenu(%clientId, "Managing "@ %name, "TGshizzle", true);
		if(%sel.locked)
		{ Client::addMenuItem(%clientId, "2Disable "@ %name @"'s Team Lock", "unlock "@ %cl); }
		else 
		{ Client::addMenuItem(%clientId, "2Lock "@ %name @" To Team", "lock "@ %cl); }
		
		if(%cl.observerMode != "observerFly" && %cl.observerMode != "observerOrbit")
		{ Client::addMenuItem(%clientId, "4Observe(in game)", "obsingame "@ %cl); }
		
		if(!%cl.isAdmin)
		{ Client::addMenuItem(%clientId, "5Admin "@ %name , "Admin "@ %cl); }
		
		if(%cl.isGodAdmin || $TG::PAStripAdmin != true && %clientId.isAdmin && !%clientId.isSuperAdmin && !%clientId.isGodAdmin)
		{ return; }
		
		if(%cl.isAdmin && (!%cl.isGodAdmin))
		{ Client::addMenuItem(%clientId, "6Strip Admin -"@ %name , "stripAdmin "@ %cl); }
		return;
	}
	else if(%opt == "flag" && %clientId.isadmin)
	{ PlayerFlag(%clientId, %cl); return; }
	else if(%opt == "spawn")
	{	
		playNextAnim(%cl);
		Player::kill(%cl);
		centerprint(%cl, "<jc><f1>"@ Client::getName(%clientId) @" respawned you.", 5);		
		messageAll(0, Client::getName(%clientId) @" respawned "@ %name);		
		Game::playerSpawn(%cl, true);
		return;
	}
}
//====================================================================================

//====================================================================================
function processMenuTGAdmin(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%cl == ""){ %cl = %clientId.selClient; }
	%cl = floor(%cl); if(!%clientId.isAdmin){ return; } // PORT: was if(%clientId.selClient = ""), an assignment that tested nothing
	
	if(%opt == "publicadmin")
	{ TG::AdminGive(%clientId, %cl, "Public"); return; }
	
	else if(%opt == "superadmin")
	{ TG::AdminGive(%clientId, %cl, "Super"); return; }
	
	else if(%opt == "godadmin")
	{ TG::AdminGive(%clientId, %cl, "God"); return; }
}
//====================================================================================


// MANAGE PLAYER: 2
function processMenuTGshizzle(%clientId, %opt)
{
	%newOpt = getWord(%opt, 0);
	%cl = getWord(%opt, 1);
	%cl = floor(%cl); // PORT
	%name = Client::getName(%cl); // PORT: %name was never set here (blank in the lock / score messages)
	if(!%clientId.isAdmin) return; // PORT: this handler had no admin test
	
	if(%newOpt == "fteamchange")
	{
		%clientId.ptc = %cl;
		%teamnow = Client::getTeam(%cl);
		%tname = getTeamName(%teamnow);
		if (%tname == unnamed) 
		%tname = "Observer";
		
		Client::buildMenu(%clientId, Client::getName(%cl) @", "@ %tname, "FPickTeam", true);
		if(Client::getTeam(%cl) != -1)
		Client::addMenuItem(%clientId, "0Observer", -2);
		
		if(Game::assignClientTeam(%clientId, true) != %teamnow)
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
		{
			if(Client::getTeam(%cl) != %i)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		}
		return;
	}
	// lock team	
	else if(%newOpt == "lock")
	{
		%cl.locked = true;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId) @" removed your team changing privileges.", 5);		
		messageAll(0, Client::getName(%clientId) @" locked "@ %name @" to his current team.~wCapture_Tower.Wav");		
		return;
	}	
	
	else if(%newOpt == "unlock")
	{
		%cl.locked = false;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" restored your team changing privileges.", 5);		
		messageAll(0, Client::getName(%clientId) @ " unlocked "@ %name @"'s team.");	
		return;
	}
	
	// ClearScore
   	else if(%newOpt == "ClearScore")
	{
		%cl.score = 0;
		Game::refreshClientScore(%cl);
		Centerprint(%cl, "<jc><f1>"@ Client::getName(%clientId) @" Cleared your score.", 5);		
		MessageAll(0, Client::getName(%clientId) @" cleared "@ %name @"'s score.~wCapture_Tower.Wav");		
		return;
	}
	
	// mute   
   	else if(%newOpt == "silence")
   	{ Admin::fun(%clientId, %cl,"De-Tongued"); }
   	
   	else if(%newOpt == "unsilence")
   	{ Admin::fun(%clientId, %cl,"Un-Muted"); }
   	
   	if(%newOpt == "obsingame")
	{ Admin::observe(%clientId, %cl); return; }
	
	else if(%newOpt == "Admin")
	{ 
		Client::buildMenu(%clientId, "SelectAdminLevel ", "TGAdmin", true);
		
		Client::addMenuItem(%clientId, "1Grant Public Admin ", "publicadmin "@ %cl); 
		Client::addMenuItem(%clientId, "2Grant Super Admin ", "superadmin "@ %cl);
		Client::addMenuItem(%clientId, "3Grant God Admin ", "godadmin "@ %cl);
		return;
	}
	
	else if(%newOpt == "stripAdmin")
	{ if(%cl.isGodAdmin || (%cl.isSuperAdmin && !%clientId.isGodAdmin) || (!%clientId.isSuperAdmin && $TG::PAStripAdmin != true)) return; Admin::fun(%clientId, %cl, "De -admined"); return; }
}
//====================================================================================

function Client::getStatus(%Id)
{
	if(Client::getOwnedObject(%Id) == -1 && Client::getTeam(%Id) != -1)
	%status = "(Dead)";
	
	else if(Client::getOwnedObject(%Id) != -1 && Client::getTeam(%Id) != -1)
	%status = "(Live)";
	
	else if(Client::getTeam(%Id) == -1)
	%status = "(Observing)";
	
	return %status;
}

function ccm(%client, %msg)
{ Client::sendMessage(%client, 0, %msg); }

function TG::DisplayModInfo(%clientId){
	%message = "<jc><f2>© <f1>Tribal_God_Mod v6.6 <f2>©\n<f1>Author: <f2>Dustin 'X-Ecutioner' Bruce.\n<f1>Email: <f2>dustin84@tribal-gods.com\n<f1>Aim: <f2>Dustin8420\n<f1>WebSite: <f2>www.tribal-gods.com";
	BottomPrint(%clientId, %message, 10);
}

//---------------------------------------------------------------------------------------------------------------------
function processmenuDamage(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	//Client::sendMessage(%clientId, 0, "processMenuDamage, "@ %opt);
	//team damage
	if(%opt == "vetd") Admin::startVote(%clientId, "enable team damage", "etd", 0);
	
	else if(%opt == "vdtd") Admin::startVote(%clientId, "disable team damage", "dtd", 0);
	else if(%opt == "etd")
	{
		Admin::setTeamDamageEnable(%clientId, true);
		%ip = Client::getTransportAddress(%client); 
		%name = Client::getName(%client);
		$Admin = %name @ " enabled team damage. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
	}
	else if(%opt == "dtd")
	{
		Admin::setTeamDamageEnable(%clientId, false);
		%ip = Client::getTransportAddress(%client); 
		%name = Client::getName(%client);
		$Admin = %name @ " disabled team damage. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
	}
	
	// base/gen damage
	if(%opt == "veBaseD") Admin::startVote(%clientId, "Enable gen/ station damage", "eBaseD", 0);
	
	else if(%opt == "vdBaseD") Admin::startVote(%clientId, "Disable gen/ station damage", "dBaseD", 0);
	
	else if(%opt == "eBaseD")
	{
		Admin::setBaseDamageEnable(%clientId, true);
		%ip = Client::getTransportAddress(%client); 
		%name = Client::getName(%client);
		$Admin = %name @ " enabled base damage. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
	}
	else if(%opt == "dBaseD")
	{
		Admin::setBaseDamageEnable(%clientId, false);
		%ip = Client::getTransportAddress(%client); 
		%name = Client::getName(%client);
		$Admin = %name @ " disabled base damage. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
	}
	// base healing
	if(%opt == "veBaseH") Admin::startVote(%clientId, "Enable base healing", "eBaseH", 0);
	else if(%opt == "vdBaseH") Admin::startVote(%clientId, "Disable base healing", "dBaseH", 0);
	else if(%opt == "eBaseH")
	{
		Admin::setBaseHealingEnable(%clientId, true);
		%ip = Client::getTransportAddress(%client); 
		%name = Client::getName(%client);
		$Admin = %name @ " enabled base healing. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true); 
	}
	else if(%opt == "dBaseH")
	{
		Admin::setBaseHealingEnable(%clientId, false);
		%ip = Client::getTransportAddress(%client); 
		%name = Client::getName(%client);
		$Admin = %name @ " disabled base healing. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
	}
	
	//Out of area damage
	if(%opt == "veOutAreaD") Admin::startVote(%clientId, "Enable out of area damage", "eOutAreaD", 0);
	
	else if(%opt == "vdOutAreaD") Admin::startVote(%clientId, "Disable out of area damage", "dOutAreaD", 0);
	
	else if(%opt == "eOutAreaD")
	{
		Admin::setAreaDamageEnable(%clientId, true);
		%ip = Client::getTransportAddress(%client); 
		%name = Client::getName(%client);
		$Admin = %name @ " enabled out of area damage. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
	}
	
	else if(%opt == "dOutAreaD")
	{
		Admin::setAreaDamageEnable(%clientId, false);
		%ip = Client::getTransportAddress(%client); 
		%name = Client::getName(%client);
		$Admin = %name @ " disabled out of area damage. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
		}
		// player damage
		if(%opt == "vePlayerD") Admin::startVote(%clientId, "Enable player damage", "ePlayerD", 0);
		else if(%opt == "vdPlayerD") Admin::startVote(%clientId, "Disable player damage", "dPlayerD", 0);
		else if(%opt == "ePlayerD")
		{
			Admin::setPlayerDamageEnable(%clientId, true);
			%ip = Client::getTransportAddress(%client); 
			%name = Client::getName(%client);
		}
		else if(%opt == "dPlayerD")
		{
			Admin::setPlayerDamageEnable(%clientId, false);
			%ip = Client::getTransportAddress(%client); 
			%name = Client::getName(%client);
		}
	}

function ProcessMenuPlayer(%clientId, %option)
{
	if(!%clientid.isadmin)
	return;
	%opt = getWord(%option, 0);
	%cl = floor(getWord(%option, 1)); // PORT
	%player = Client::getOwnedObject(%cl);
	%name = Client::getName(%cl);
	
	// StripFlag
	if(%opt == "StripFlag")
	{
		%type = Player::getMountedItem(%cl, $FlagSlot);
		if(%type != -1)
		Player::dropItem(%cl, %type);
		Centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" stripped your flag.", 5);
		MessageAll(0, Client::getName(%clientId) @ " stripped "@ %name @"'s flag.~wCapturedTower.wav");		
		return;
	}
	
	// ReturnFlag
	else if(%opt == "ReturnFlag")
	{
		%player = Client::getOwnedObject(%cl);
		%this = %player.carryFlag;
		%type = Player::getMountedItem(%cl, $FlagSlot);
		if(%type != -1)
		{
			Player::dropItem(%cl, %type);
			echo("flag id "@ %type);
			Echo("%this = "@ %this);
			// the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
			Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
			%this.atHome = true;
			%cl.flagcarried = "";
			centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" returned your flag.", 5);		
			messageAll(0, Client::getName(%clientId) @ " returned "@ %name @"'s flag.~wCapturedTower.wav");
		return;
		}
	}
	
	// FlagCurse
	else if(%opt == "FlagCurse")
	{
		%cl.FlagCurse = true;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" gave you the dreaded Flag Curse.", 5);		
		messageAll(0, Client::getName(%clientId) @ " gave "@ %name @" the flag curse.");
		%type = Player::getMountedItem(%cl, $FlagSlot);
		if(%type != -1)	schedule("PlayerFlagCurse("@ %cl @");",2);	
		return;
	}
	else if(%opt == "NoFlagCurse")
	{
		%cl.FlagCurse = false;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" removed the flag curse.", 5);
		messageAll(0, Client::getName(%clientId) @ " removed "@ %name @"'s flag curse.");	
		return;
	}
	// na -plasmatic
	else if(%opt == "return")
	Game::menuRequest(%clientId);
	
	// return to flag menu
	else if(%opt == "Freturn")
	PlayerFlag(%clientId, %cl);
	
	// kill
	else if(%opt == "respawn")
	{	
		playNextAnim(%cl);
		Player::kill(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId) @" respawned you.", 5);		
		messageAll(0, Client::getName(%clientId) @" respawned "@ %name);		
		Game::playerSpawn(%cl, true);
		return;
	}
	
	else if(%opt == "BlowUp")
	{
		%player = Client::getOwnedObject(%cl);
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
		{
			%Pos = GameBase::getPosition(%player); 
			%vel = Item::getVelocity(%player);
			%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
			%obj = Projectile::spawnProjectile("suicideShell", %trans, %player, %vel);
			Projectile::spawnProjectile(%obj);
			Item::setVelocity(%obj, %vel);
			Player::blowUp(%cl);
			playNextAnim(%cl);   
			Player::kill(%cl); 
		}
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" blew you up", 5);
		messageAll(0, Client::getName(%clientId) @ " blew up "@ %name@".");
		return;
	}
	
	else if(%opt == "Sniper")
	{
		GameBase::playSound(%cl, ricochet1, 0);
		%curDie = radnomItems(3, $PlayerAnim::DieHead, $PlayerAnim::DieBack,$PlayerAnim::DieForward);
		Player::setAnimation(%this, %curDie);
		playNextAnim(%cl);
		Player::kill(%cl);
		messageAll(0, Client::getName(%clientId) @" Helps "@ %name@" realize that no, you can't catch a bullet with your teeth.");
		return;
	}	
	else if(%opt == "Burn")
	{
		BurnUp(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" set you on fire.", 5);
		messageAll(0, Client::getName(%clientId) @ " set "@ %name@" on fire.");		
		return;
	}
	else if(%opt == "Poison")
	{
		KillRatDead(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" poisoned you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " fed "@ %name@" some rat poison.");	
		return;
	}
	
	// annoy	
	else if(%opt == "Disarm")
	{
		%player = Client::getOwnedObject(%cl);
		%item = Player::getMountedItem(%cl, $WeaponSlot);
		Player::trigger(%player, $WeaponSlot, false);
		Player::dropItem(%cl,%item);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" disarmed you.", 5);
		messageAll(0, Client::getName(%clientId) @ " stole "@ %name@"'s weapon.");		
		return;
	}
	
	else if(%opt == "Moon")
	{
		%rotZ = getWord(GameBase::getRotation(%cl),2);
		GameBase::setRotation(%cl, "0 0 " @ %rotZ);
		%forceDir = Vector::getFromRot(GameBase::getRotation(%cl),0,3000);
		Player::applyImpulse(%cl,%forceDir);
		schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wbye.wav\");", 2);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" sent you to the moon!", 5);
		messageAll(0, Client::getName(%clientId) @ " sent "@ %name@" to the moon.");		
		return;
	}
	
	else if(%opt == "Slap")
	{
		%rotZ = getWord(GameBase::getRotation(%cl),2);
		GameBase::setRotation(%cl, "0 0 " @ %rotZ);
		%forceDir = Vector::getFromRot(GameBase::getRotation(%cl),3000,1000);
		Player::applyImpulse(%cl,%forceDir);
		schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wbye.wav\");", 2);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Slapped you.", 5);
		messageAll(0, Client::getName(%clientId) @ " slapped "@ %name@".");		
		return;
	}	
	else if(%opt == "Blind")
	{
		%player.blind = true;
		HotPoker(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" poked your eyes out.", 5);		
		messageAllExcept(%cl, 0, Client::getName(%clientId) @ " scooped "@ %name@"'s eyes out with a spoon.");		
		return;
	}	

	else if(%opt == "UnBlind")
	{
		%player.blind = false;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" restored your sight.", 5);		
		messageAll(0, Client::getName(%clientId) @ " restored "@ %name@"'s sight.");
		logAdminAction(%clientId," restored " @ %name@" eyes.");		
		return;
	}
	// Penalty	
	else if(%opt == "15Penalty")
	{
		Penalty(%cl,false,15);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" sent you to the penalty box for 15 seconds.", 5);		
		messageAll(0, Client::getName(%clientId) @ " sent "@ %name@" to the penalty box for 15 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
	else if(%opt == "30Penalty")
	{
		Penalty(%cl,false,30);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" sent you to the penalty box for 30 seconds.", 5);		
		messageAll(0, Client::getName(%clientId) @ " sent "@ %name@" to the penalty box for 30 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
	else if(%opt == "60Penalty")
	{
		Penalty(%cl,false,60);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" sent you to the penalty box for 60 seconds.", 5);		
		messageAll(0, Client::getName(%clientId) @ " sent "@ %name@" to the penalty box for 60 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
}




	
	
function processMenuCMoo(%clientId, %first, %voteit)
{
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = %first; %type < $MLIST::TypeCount; %type++)
	{
		if($MLIST::Type[%type] != "Training")
		{
			if(%index == 8 && $MLIST::TypeCount > %first + %index)
			{
				Client::addMenuItem(%clientId, %index @ "More Types...", "more " @ %first + %index @ " " @ %voteit); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %voteit); 
			%index++; 
		} 
	}
}


//---------------------------------------------------------------------------------------------------------------------

function processMenuCMType(%clientId, %options)
{
	%option = getWord(%options, 0); 
	%first = getWord(%options, 1); 
	%voteit = getWord(%options, 2);
	if(%option == "more")
	{
		processMenuCMoo(%clientId, %first, %voteit); 
		return; 
	}
	%curItem = 0;
	Client::buildMenu(%clientId, "Select Mission", "cmission", true); 
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
	{
		if(%i > 6)
		{
			Client::addMenuItem(%clientId, %i+1 @ "More Missions...", "more " @ %first + %i @ " " @ %option @ " " @ %voteit); 
			break; 
		} 
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option @ " " @ %voteit); 
	} 
} 


//---------------------------------------------------------------------------------------------------------------------

function processMenuCMission(%clientId, %option)
{
	if(getWord(%option, 0) == "more")
	{
		%first = getWord(%option, 1);
		%type = getWord(%option, 2);
		processMenuCMType(%clientId, %type @ " " @ %first);
		return;
	}
	%mi = getWord(%option, 0);
	%mt = getWord(%option, 1);

	%misName = $MLIST::EName[%mi];
	%misType = $MLIST::Type[%mt];

	// verify that this is a valid mission:
	if(%misType == "" || %misType == "Training")
		return;
	for(%i = 0; true; %i++)
	{
		%misIndex = getWord($MLIST::MissionList[%mt], %i);
		if(%misIndex == %mi)
			break;
		if(%misIndex == -1)
			return;
	}
	if(%clientId.isAdmin && !%clientId.MissVote)
	{
		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")~wCapturedTower.wav");
		Vote::changeMission();
		Server::loadMission(%misName);
	}
	else
	{
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		Game::menuRequest(%clientId);
		%clientId.MissVote = "";
	}
}

//==========================================================================================
// PICK TEAM FUNCTS
function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
   {
      if(Observer::enterObserverMode(%clientId))
      {
         %clientId.notready = "";
         if(%adminClient == "") 
            messageAll(0, Client::getName(%clientId) @ " became an observer.");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
		   Game::refreshClientScore(%clientId);
		}
      return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");

   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

   Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;
   if($Server::TourneyMode && !$CountdownStarted)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
}
//==========================================================================================
//---------------------------------------------------------------------------------------------------------------------
function processMenuccffa(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
	Admin::setModeFFA(%clientId);
	Game::menuRequest(%clientId);
}


//---------------------------------------------------------------------------------------------------------------------
function processMenucctourney(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
	Admin::setModeTourney(%clientId);
	Game::menuRequest(%clientId);
}


//---------------------------------------------------------------------------------------------------------------------
function processMenuKAffirm(%clientId, %opt)
{
	%newOpt = getWord(%opt, 0);
	%cl = getWord(%opt, 1);
	%cl = floor(%cl); // PORT
	if(!%clientId.isAdmin || %cl.isGodAdmin || (%cl.isAdmin && !%clientId.isGodAdmin)) return; // PORT: the rule PlayerManage draws the Kick entry with
	Echo("Option 1 = "@ %newOpt);
	Echo("Option 2 = "@ %cl);
	
	if(%newOpt == "yes" && %cl != "" && %cl != -1)
	{ TG::Kick(%clientId, %cl); return; }
}

function TG::Kick(%admin, %cl)
{
	%cl = floor(%cl); // PORT: spliced into the schedule() strings below
	TG::PlayPinBall(%cl);
	%adminName = Client::getName(%admin);
	if(%admin == -1){ %adminName = "The Server"; }
	BottomPrint(%cl, "<jc><f1>You Pissed Off The Wrong Guy.", 3);
	Schedule("BottomPrint("@ %cl @", \"<jc><f1>G\", 3);", 3.5);
	Schedule("BottomPrint("@ %cl @", \"<jc><f1>Go\", 3);", 4);
	Schedule("BottomPrint("@ %cl @", \"<jc><f1>Goo\", 3);", 4.5);
	Schedule("BottomPrint("@ %cl @", \"<jc><f1>Good\", 3);", 5);
	Schedule("BottomPrint("@ %cl @", \"<jc><f1>Good B\", 3);", 5.5);
	Schedule("BottomPrint("@ %cl @", \"<jc><f1>Good By\", 3);", 6);
	Schedule("BottomPrint("@ %cl @", \"<jc><f1>Good Bye\", 3);", 6.5);
	Schedule("BottomPrint("@ %cl @", \"<jc><f1>Good Bye!\", 3);", 7);
	Schedule("Net::Kick("@ %cl @", \"Report Admin Abuse At dustin84@tribal-gods.com\");", 8);
	Schedule("MessageAll(0, \""@ escapeString(Client::getName(%cl)) @" Was Kicked By "@ escapeString(%adminName) @".\");", 6.5);
}

function TG::Bann(%admin, %cl)
{
	TG::Kick(%admin, %cl);
	%ip = Client::getTransportAddress(%cl);
	
	BanList::add(%ip, 999999);
	BanList::export("config\\banlist.cs");
}

function TG::PlayPinBall(%ballId)
{
	%ball = Client::getOwnedObject(%ballId);
	if(Client::getStatus(%ballId) == "(Live)")
	{
		%ball.shieldStrength = 10.0;
		Schedule(%ball @".shieldStrength = 0.0;", 5.5);
		Pinball::Sequence1(%ballId);
		Schedule("Pinball::Sequence2("@ %ballId @");", 1);
		Schedule("Pinball::Sequence3("@ %ballId @");", 1.5);
		Schedule("Pinball::Sequence4("@ %ballId @");", 2);
		Schedule("Pinball::Sequence5("@ %ballId @");", 2.5);
		Schedule("Pinball::Sequence6("@ %ballId @");", 3);
		Schedule("Pinball::Sequence7("@ %ballId @");", 3.5);
		Schedule("Pinball::Sequence8("@ %ballId @");", 4);
		Schedule("Pinball::Sequence9("@ %ballId @");", 4.5);
		Schedule("Pinball::Sequence10("@ %ballId @");", 5);
		Schedule("Pinball::Sequence1("@ %ballId @");", 5.5);
		Schedule("Pinball::Sequence2("@ %ballId @");", 6);
		Schedule("Pinball::Sequence3("@ %ballId @");", 6.5);
		Schedule("Pinball::Sequence4("@ %ballId @");", 7);
	}
}

function Pinball::Sequence1(%ballId)
{ Player::applyimpulse(%ballId, "1000 1000 0"); }
function Pinball::Sequence2(%ballId)
{ Player::applyimpulse(%ballId, "-1000 0 0"); }
function Pinball::Sequence3(%ballId)
{ Player::applyimpulse(%ballId, "1000 -1000 0"); }
function Pinball::Sequence4(%ballId)
{ Player::applyimpulse(%ballId, "-1000 0 1000"); }
function Pinball::Sequence5(%ballId)
{ Player::applyimpulse(%ballId, "1000 1000 -1000"); }
function Pinball::Sequence6(%ballId)
{ Player::applyimpulse(%ballId,"-1000 -1000 0"); }
function Pinball::Sequence7(%ballId)
{ Player::applyimpulse(%ballId, "1000 0 1000"); }
function Pinball::Sequence8(%ballId)
{ Player::applyimpulse(%ballId, "-1000 -1000 0"); }
function Pinball::Sequence9(%ballId)
{ Player::applyimpulse(%ballId, "0 0 -1000"); }
function Pinball::Sequence10(%ballId)
{ Player::applyimpulse(%ballId, "1000 1000 0"); }
//---------------------------------------------------------------------------------------------------------------------
function processMenuBAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
	Admin::kick(%clientId, getWord(%opt, 1), true);
	Game::menuRequest(%clientId);
}
//---------------------------------------------------------------------------------------------------------------------
function processMenuAAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
	{
		if(%clientId.isSuperAdmin)
		{
			Client::buildMenu(%clientId, "Admin Level", "AAffirmcontinued", true);
			Client::addMenuItem(%clientId, "1Public Admin", "pubAdminlvl");
			Client::addMenuItem(%clientId, "2Super Admin", "supAdminlvl");
			Client::addMenuItem(%clientId, "3God Admin", "godAdminlvl");
			messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.~wCapturedTower.wav");
			
		}
	}
}

function processMenuAAffirm(%clientId, %opt)
{
	%sel = %clientId.selClient;
	if(%opt == "pubAdminlvl")
	{ if(%clientId.isAdmin) %sel.isAdmin = true; return; }
	
	else if(%opt == "supAdminlvl")
	{ if(%clientId.isSuperAdmin){ %sel.isAdmin = true; %sel.isSuperAdmin = true; } return; }
	
	else if(%opt == "godAdminlvl")
	{ if(%clientId.isGodAdmin){ %sel.isAdmin = true; %sel.isSuperAdmin = true; %sel.isGodAdmin = true; } return; }
}
	
//---------------------------------------------------------------------------------------------------------------------
function processMenuRAffirm(%clientId, %opt)
{
	if(%opt == "yes" && %clientId.isSuperAdmin)
	{
		messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.~wCapturedTower.wav");
		Server::refreshData();
	}
	Game::menuRequest(%clientId);
}


//---------------------------------------------------------------------------------------------------------------------
function processMenuCTLimit(%clientId, %opt)
{
	if(!%clientId.isAdmin) return; // PORT
	remoteSetTimeLimit(%clientId, %opt);
}


//---------------------------------------------------------------------------------------------------------------------
function processMenuVTime(%clientId, %opt)
{
	%opt = floor(%opt); // PORT: client text went into the vote topic shown to everyone
  Admin::startVote(%clientId, "change the time to " @ %opt @" minute(s).", "VTime", %opt);

	//remoteSetTimeLimit(%clientId, %opt);
}


//---------------------------------------------------------------------------------------------------------------------
function processMenuPickVote(%clientId, %opt)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
}


//---------------------------------------------------------------------------------------------------------------------
function processMenuMission(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	echo("processMenuMission", %opt);
	
	if(%opt == "cmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
	if(%opt == "vcmission")
	{
		%clientId.MissVote = true;
		Admin::changeMissionMenu(%clientId, %opt == "vcmission");
		return;
	}
	else if(%opt == "VnextMiss")
	{
		Admin::startVote(%clientId, "start next mission ", "NextMap" ,0);
		return;
	}
	else if(%opt == "ReplayMap" && %clientId.isAdmin)
	{
		ReplayMap(%clientId);
		return;
	}
	else if(%opt == "VReplayMap")
	{
		Admin::startVote(%clientId, "restart mission ", "ReplayMap" ,0);
		return;
	}
	else if(%opt == "VrandomMiss")
	{
		Admin::startVote(%clientId, "pick random mission ", "RandomMap" ,0);
		return;
	}
	else if(%opt == "nextMiss" && %clientId.isAdmin)
	{
		nextmap(%clientId);
		return;
	}
	else if(%opt == "randomMiss" && %clientId.isAdmin)
	{
		randommap(%clientId);
		return;
	}
}
//---------------------------------------------------------------------------------------------------------------------
function processMenuVoteforfun(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "cmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
}


//---------------------------------------------------------------------------------------------------------------------
function processMenuVote(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if(%opt == "voteMiss")
	{
		MissMenu(%clientId,false);
		return;
	}

	else if(%opt == "voteTime")
	{
		TimeMenu(%clientId,false);
		return;
	}
	else if(%opt == "voteDamage")
	{
		DamageMenu(%clientId,false);
		return;
	}   
   	if(!%clientId.isSuperAdmin) return; // PORT: the four switches below had no admin test
   	if(%opt == "dVote" && %clientId.isGodAdmin) ServerSwitches(%clientId,"Voting",false);
	else if(%opt == "eVote" && %clientId.isGodAdmin) ServerSwitches(%clientId,"Voting",true); 
	
   	else if(%opt == "dVoteAdmin")  ServerSwitches(%clientId,"Voting Admin",false);
	else if(%opt == "eVoteAdmin")  ServerSwitches(%clientId,"Voting Admin",true);

}


//---------------------------------------------------------------------------------------------------------------------

// process server options in a less painfull way -Plasmatic
function processMenuServer(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if(!%clientId.isGodAdmin) return; // PORT: no admin test in this handler; both menus that lead here are God Admin menus
//Fair teams   
   	if(%opt == "dFair")  ServerSwitches(%clientId,"Fair Teams",false);
	else if(%opt == "eFair")  ServerSwitches(%clientId,"Fair Teams",true);
//time   
   	else if(%opt == "time")  TimeMenu(%clientId,true);
   	
// turrets  
   	else if(%opt == "turret") 
   		{
   		Client::buildMenu(%clientId, "Turret Options:", "Server", true);
   	//deployable turret points		
		if($TurretPoints == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable turret points", "dTurretPoints");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable turret points", "eTurretPoints");
//deployable turrets			
		if($NoDeploybleTurret == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable new deployable turrets", "ePlayerTurret");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "no new deployable turrets", "dPlayerTurret");			
	// destroy turrets
	Client::addMenuItem(%clientId, %curItem++ @ "Destroy deployable turrets", "rPlayerTurret");
	Client::addMenuItem(%clientId, %curItem++ @ "Destroy map turrets", "DamMapTurrets");	
					
	
	//map turrets					
		if($NoMapTurrets == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable map turrets", "eMapTurrets");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable map turrets", "dMapTurrets");
	if($NoMapTurrets != 1)			
	Client::addMenuItem(%clientId, %curItem++ @ "fix map turrets", "FixMapTurrets");							
  		return;	   			
   	}
   	
//process turrets   			
    	if(%opt == "dTurretPoints")  ServerSwitches(%clientId,"turret points",false);
	else if(%opt == "eTurretPoints")  ServerSwitches(%clientId,"turret points",true); 
	 	
    	if(%opt == "dPlayerTurret")  ServerSwitches(%clientId,"deployable turrets",false);
	else if(%opt == "ePlayerTurret")  ServerSwitches(%clientId,"deployable turrets",true); 
	 	
    	if(%opt == "dMapTurrets")  {KillMapTurrets(%clientId,true,true);ServerSwitches(%clientId,"map turrets",false);}
	else if(%opt == "eMapTurrets")  ServerSwitches(%clientId,"map turrets",true); 
	
    	if(%opt == "rPlayerTurret")  KillMapTurrets(%clientId,false,true);
    	
	else if(%opt == "DamMapTurrets")  KillMapTurrets(%clientId,true,true); 
	else if(%opt == "FixMapTurrets")  KillMapTurrets(%clientId,true,false); 	 	 	


	
// station menu
   	else if(%opt == "Station") 
   		{
   		Client::buildMenu(%clientId, "Station options:", "Server", true);
   		
	Client::addMenuItem(%clientId, %curItem++ @ "Kill deployable Inventories", "rPlayerInvs");
	Client::addMenuItem(%clientId, %curItem++ @ "Kill map Inventories", "DamMapInvs");	
	   		
	if($NoInv == 1)
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Inventory stations", "eInv");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Inventory stations", "dInv");	
	
//vehicle stations	
	Client::addMenuItem(%clientId, %curItem++ @ "Kill vehicle stations", "KillVehicle");	
	
	if($NoVehicle == 1)
		Client::addMenuItem(%clientId, %curItem++ @ "Enable vehicle stations", "eVehicle");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Disable vehicle stations", "dVehicle");
	if($NoInv != 1)		
	Client::addMenuItem(%clientId, %curItem++ @ "fix map Inventories", "FixMapInvs");
	if($NoVehicle != 1)		
	Client::addMenuItem(%clientId, %curItem++ @ "fix vehicle stations", "FixVehicle");		
						
  		return;	   			
   	}
   	
   
// Generator menu
   	else if(%opt == "Generator") 
   		{
   		Client::buildMenu(%clientId, "Generator options:", "Server", true);
   		
	Client::addMenuItem(%clientId, %curItem++ @ "Kill deployable Generators", "rPlayerGens");
	Client::addMenuItem(%clientId, %curItem++ @ "Kill all Generators", "DamMapGens");
	
	if($NoGenerator == 1)
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Generators", "eGenerators");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Generators", "dGenerators");		
	if($NoGenerator != 1)		
	Client::addMenuItem(%clientId, %curItem++ @ "fix all Generators", "FixMapGens");
					
  		return;	   			
   	}
   	
  // Generator menu
   	else if(%opt == "Combined") 
   		{
   		Client::buildMenu(%clientId, "Combination Options:", "Server", true);
   		
	Client::addMenuItem(%clientId, %curItem++ @ "Kill deployables", "killDeployables");
	Client::addMenuItem(%clientId, %curItem++ @ "Kill all stations", "killStat");	
	Client::addMenuItem(%clientId, %curItem++ @ "Kill stations/ gens", "KillstatGen");
	Client::addMenuItem(%clientId, %curItem++ @ "NEUTRON BOMB", "Purge");		
	Client::addMenuItem(%clientId, %curItem++ @ "Fix all stations", "FixStat");
	Client::addMenuItem(%clientId, %curItem++ @ "fix stations/ gens", "FixstatGen");	
// fix everything, you benevolent bastard!
	Client::addMenuItem(%clientId, %curItem++ @ "FIX ALL, restore", "dePurge");	   							
  		return;	   			
   	} 	
   	
//purge		
   else if(%opt == "Purge")
         KillPurge(%clientId,true);
//unpurge		
   else if(%opt == "dePurge")
         KillPurge(%clientId,false);
//kill deployables		
   else if(%opt == "killDeployables")
         AdminKillDeploy(%clientId);


	//Inventory stations	
// KillClass(%clientId,%kill,%classname)
	else if(%opt == "KillstatGen"){ KillClass(%clientId,true,Generator); 
				schedule("KillClass("@%clientId@",true,Station);",2);
		}
	else if(%opt == "FixstatGen") { KillClass(%clientId,false,Generator); 
				schedule("KillClass("@%clientId@",false,Station);",2);
		}	
		
	else if(%opt == "DamMapGens")  KillClass(%clientId,true,Generator); 
   	if(%opt == "dGenerators")  {KillClass(%clientId,true,Generator);ServerSwitches(%clientId,"Generators",false);}	
	if(%opt == "eGenerators")  {KillClass(%clientId,true,Generator);ServerSwitches(%clientId,"Generators",true);}
	else if(%opt == "FixMapGens")  KillClass(%clientId,false,Generator); 
	else if(%opt == "FixStat")  KillClass(%clientId,false,Station); 	
	else if(%opt == "killStat")  KillClass(%clientId,true,Station); 
// could clean up code by using killclass to kill/fix invs/turrets/vehicle also but would need 
// deployable counterparts like killDepGen for each.
	else if(%opt == "rPlayerGens")  KillDepGen(%clientId); 

// inv   
   	if(%opt == "dInv")  {KillMapInv(%clientId,true,true);ServerSwitches(%clientId,"Inventories",false);}
	else if(%opt == "eInv")  ServerSwitches(%clientId,"Inventories",true);
	
    	if(%opt == "rPlayerInvs")  KillMapInv(%clientId,false,true);
	else if(%opt == "DamMapInvs")  KillMapInv(%clientId,true,true); 
	else if(%opt == "FixMapInvs")  KillMapInv(%clientId,true,false); 	
// obs alert
	else if(%opt == "obsAlertOn")  ServerSwitches(%clientId,"Observer Alert",true);
	else if(%opt == "obsAlertOff")  ServerSwitches(%clientId,"Observer Alert",false);
// skins	
	else if(%opt == "skinsOn")  {
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i++)
		{
		%cl = getClientByIndex(%i);
		echo(%cl);
		Client::setSkin(%cl, $Client::info[%cl, 0]);
		}
		ServerSwitches(%clientId,"personal skins",true);
		}
	
	
	
	else if(%opt == "skinsOff")  {
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i++)
		{
		%cl = getClientByIndex(%i);
		echo(%cl);		
		Client::setSkin(%cl, $Server::teamSkin[Client::getTeam(%cl)]);
		}
		ServerSwitches(%clientId,"personal skins",false);
		}	
		
// vehicles   

	else if(%opt == "KillVehicle")  KillMapVehicle(%clientId,true,true); 
	else if(%opt == "FixVehicle")  KillMapVehicle(%clientId,true,false); 

   	if(%opt == "dVehicle")  {KillMapVehicle(%clientId,true,true);ServerSwitches(%clientId,"Vehicle Stations",false);}
	else if(%opt == "eVehicle")  ServerSwitches(%clientId,"Vehicle Stations",true);
// flag caps   
   	if(%opt == "dFlag")  ServerSwitches(%clientId,"Flag captures",false);
	else if(%opt == "eFlag")  ServerSwitches(%clientId,"Flag captures",true);
// reset server
  	else if(%opt == "reset") 
  		{
  		Client::buildMenu(%clientId, "Reset Server?", "Server", true);	
  		Client::addMenuItem(%clientId, %curItem++ @ "yes, Reset server", "resetYes");
  		Client::addMenuItem(%clientId, %curItem++ @ "no, Don't reset", "resetNo");
  		return;
  		}
  	else if(%opt == "resetYes") 
  		{
		messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.~wCapturedTower.wav");
		Server::refreshData();
  		}		
    	else if(%opt == "resetNo") return;		
}