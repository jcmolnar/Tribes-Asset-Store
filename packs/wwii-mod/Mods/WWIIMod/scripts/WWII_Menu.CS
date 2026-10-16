
exec(M_Voting);
// PORT FIX: exec(string) removed, there is no string.cs.

function newmenu(%client, %name, %sname)
{
Client::buildMenu(%client, %name, %sname, true);
}

function addoption(%client, %num, %name, %sname, %sel)
{
if(%sel) Client::addMenuItem(%client, %num @ %name, %sname @ " " @ %sel);
else client::addmenuItem(%client, %num @ %name, %sname);
}

function Game::menuRequest(%cl)
{
//========================================MENU SETUP

if(%cl.selClient) 
	{
	OptionsOnClient(%cl.selClient, %cl);
	return;
	}
else {
//------------------
%x = 0;
newmenu(%cl, "\xa4----------Main Menu----------\xa4", "mainmenu");
//addoption(%cl, %x++, "RTS Menu", "RTS");
if($Game::MissionType == "Conquest") addoption(%cl, %x++, "Change Team", "A");
addoption(%cl, %x++, "Voting Options", "B");
if(%cl.adminLVL > 2) addoption(%cl, %x++, "Mission Options", "D");
if(%cl.adminLVL == 5) addoption(%cl, %x++, "Server Options", "EH");
	}
addoption(%cl, %x++, "Mod information", "C");   
addoption(%cl, %x++, "Personal Settings", "F");   

}

function M::MainMenu(%cl, %opt)
{
%x = 0;
if(%opt == "RTS") { CMD::Menu(%cl); return; }
if(%opt == "A") 
	{
if(%cl.cantchangeteam) { centerprint(%cl, "<jc>Sorry, that option is locked for you.", 5,MENU); return; }
	newmenu(%cl, "\xa5----------Pick a team:----------\xa5", "PickTeam");
        if(gamebase::getteam(%cl) != -1) addoption(%cl, %x++, "Observer", -2);
         addoption(%cl, %x++, "Automatic", -1);
        for(%i = 0; %i < getNumTeams(); %i = %i + 1)
          addoption(%cl, %x++, getTeamName(%i), %i);
         return;
	}

else if(%opt == "B")
	{
	if(%cl.cantvote) { centerprint(%cl, "<jc>Sorry, that option is locked for you.", 5,MENU); return; }
	newmenu(%cl, "\xd7----------Vote for:----------\xd7", "Votingopts");
	if(!%cl.voted && $Vote::CurVoteStatus == "voting") 
		{
		addoption(%cl, %x++, "Vote YES", "voteyes");
		addoption(%cl, %x++, "Vote NO", "voteno");
		//return;
		}
	if($Vote::CurVoteStatus == "voting" && %cl.adminLVL >= 3) 
		{
		addoption(%cl, %x++, "Force vote success", "forcevotepass");
		addoption(%cl, %x++, "Cancel vote", "forcevotefail");
		return;
		}
	if($Vote::CurVoteStatus != "voting") 
		{
		addoption(%cl, %x++, "Mission change", "Mapchange");
		addoption(%cl, %x++, "Random mission", "Maprandom");
		addoption(%cl, %x++, "Stretch this game!", "addpoints");
		}
	return;
	}
else if(%opt == "D")
	{
	if(%cl.adminlvl <= 2) { WWIIPort::deny(%cl, "D"); return; } // PORT FIX: was a message with no return
	newmenu(%cl, "\xd9----------Mission Options----------\xd9", "mapopts");
	addoption(%cl, %x++, "Change Mission", "missionchange");
	addoption(%cl, %x++, "Restart Mission", "missionrestart");
	addoption(%cl, %x++, "Next/Random Mission", "missionrandom");
	addoption(%cl, %x++, "Fix Spawn-Killing", "spawnkillfix");
	addoption(%cl, %x++, "Stretch this game", "addpoints");
	return;
	}


else if(%opt == "EH") 
	{ if(%cl.adminLVL != 5) { WWIIPort::deny(%cl, "EH"); return; } // PORT FIX: was a message with no return
	newmenu(%cl, "\xa4----------Server Controls----------\xa4", "serveropts");
	addoption(%cl, %x++, "Restart", "reboot");
	addoption(%cl, %x++, "Shut Down", "destroy");
	addoption(%cl, %x++, "Trace players", "traceplayers");
	addoption(%cl, %x++, "Reload Addons", "addons");
	return;
	}
else if(%opt == "C")
	{
	WWII::ModInfo(%cl, 0);
	return;
	}
else if(%opt == "F")
	{
	newmenu(%cl, "\xd4----------Personal----------\xd4", "personal");
	addoption(%cl, %x++, "Scout advanced", "scoutopts");
	addoption(%cl, %x++, "Spawn options", "spawnopts");
	addoption(%cl, %x++, "Leave comment", "noteforbfw");
	addoption(%cl, %x++, "TNet Menu", "tnetmenu");
	return;
	}

else Security::InvalidMenu(%cl, %opt);
Game::menuRequest(%cl);
}

function m::personal(%cl, %opt)
{
%x = 0;
if(%opt == "scoutopts")
	{
	newmenu(%cl, "\xc4----------Scout----------\xc4", "scoutopts");
	addoption(%cl, %x++, "Normal setup", "default");
	addoption(%cl, %x++, "Cactus camo", "cactus");
	addoption(%cl, %x++, "Green skin", "greenskin");
	addoption(%cl, %x++, "Plant camo", "blackplant");
	return;
	}
else if(%opt == "spawnopts")
	{
	newmenu(%cl, "\xc4----------Spawn----------\xc4", "spawnopts");
		if(%cl.lockspawnclass)
	addoption(%cl, %x++, "Unlock Spawn Class", "unlockspawnclass");
		else
	addoption(%cl, %x++, "Lock Spawn Class", "lockspawnclass");
		if(%cl.lockspawnpoint)
	addoption(%cl, %x++, "Unlock Spawn Point", "unlockspawnpoint");
		else
	addoption(%cl, %x++, "Lock Spawn Point", "lockspawnpoint");
	return;
	}
else if(%opt == "noteforbfw")
	{
	if(%cl.notes > 5) 
		{
		client::sendmessage(%cl, 2, "--You cannot leave more than six comments.~wmale1.wsorry.wav");
		return;
		}
	client::sendmessage(%cl, 2, "--Type your message in global chat and it will be saved for Roma and the developers. Your anonymousness is guaranteed. ~wwind1.wav");
	%cl.givingnote = 1;
	%cl.notes++;
	return;
	}
else if(%opt == "tnetmenu")
	{
	newmenu(%cl, "\xc4----------TNet----------\xc4", "tnet");
	addoption(%cl, %x++, "Change identification", "changelogin");
	addoption(%cl, %x+4, "Terminate Account", "deleteuser");
	return;
	}

}

function m::TNet(%cl, %opt)
{
if(%opt == "deleteuser") Menu::ConfirmClient(%cl, "TNet::DeleteAccount(" @ %cl @ ");", "removal");
else if(%opt == "changelogin") 
	{
	newmenu(%cl, "\xc4----------TNet Login----\xc4", "tnetlogin");
	addoption(%cl, %x++, "By IP (default)", "ip");
	addoption(%cl, %x++, "By Custom Info", "udpass");
	}
}

function m::TnetLogin(%cl, %opt)
{
TNet::SetIDMode(%cl, %opt);
}

function m::scoutopts(%cl, %opt)
{
%cl.scoutspecial = %opt;
}

function m::SpawnOpts(%cl, %opt)
{
if(%opt == lockspawnclass) %cl.lockspawnclass = 1;
if(%opt == unlockspawnclass) %cl.lockspawnclass = 0;
if(%opt == lockspawnpoint) %cl.lockspawnpoint = 1;
if(%opt == unlockspawnpoint) %cl.lockspawnpoint = 0;
// PORT FIX: these four options gave no sign that anything had happened.
if(%cl.lockspawnclass) %a = "locked"; else %a = "free";
if(%cl.lockspawnpoint) %b = "locked"; else %b = "free";
Client::sendMessage(%cl, 0, "Spawn class: " @ %a @ ".  Spawn point: " @ %b @ ".");
echo("WWII: spawn options for client " @ %cl @ ": class " @ %a @ ", point " @ %b);
}

function m::serveropts(%cl, %opt)
{
if(%cl.adminLVL != 5) { WWIIPort::deny(%cl, "serveropts " @ %opt); return; } // PORT FIX
if(%opt == "reboot") menu::confirmclient(%cl, "WWII::ServerReboot();");
if(%opt == "destroy") menu::confirmclient(%cl, "WWII::ServerShutDown();");
if(%opt == "traceplayers") menu::confirmclient(%cl, "WWII::TraceClients(" @ %cl @ ");");
if(%opt == "addons") LoadAddons();
}

//----------Alternate functions

function m::mapopts(%cl, %opt)
{
if(%cl.adminLVL <= 2) { WWIIPort::deny(%cl, "mapopts " @ %opt); return; } // PORT FIX
if(%opt == "missionchange") 
	{
	M::Votingopts(%cl, "Mapchange");
	%cl.cm = true;
	return;
	}
if(%opt == "missionrestart")
	{
	menu::confirmclient(%cl, "resmap(" @ %cl @ ");");
	return;
	}
if(%opt == "missionrandom")
	{
	menu::confirmclient(%cl, "server::nextmission();");
	return;
	}
if(%opt == "spawnkillfix")
	{
	menu::confirmclient(%cl, "WWII::SpawnKill(" @ %cl @ ");");
	return;
	}
if(%opt == "addpoints")
	{
	newmenu(%cl, "\xa3----------Free Points!----------\xa3", "freepoints");
	addoption(%cl, %x++, "Add 50", "50");
	addoption(%cl, %x++, "Add 100", "100");
	addoption(%cl, %x++, "Add 200", "200");
	addoption(%cl, %x++, "Add 400", "400");
	addoption(%cl, %x++, "Add 800", "800");
	addoption(%cl, %x++, "Add 1600", "1600");
	return;
	}
}

function resmap(%cl)
{
messageall(1, client::getname(%cl) @ " restarted the mission."); 
vote::changemission(); 
server::loadmission($missionname);
}

function m::freepoints(%cl, %opt)
{
if(%cl.adminLVL <= 2) { WWIIPort::deny(%cl, "freepoints " @ %opt); return; } // PORT FIX
if(%opt >= 800) { Centerprint(%cl, "<jc><f2>Sorry, you want too much!",SORRY); return; }

messageall(1,Client::GetName(%cl) @ " added " @ %opt @ " points to the scores! ~wcapturedtower.wav"); 
$WWII::TeamPoints[Allied] += %opt;
if($game::Missiontype != "Objective") $WWII::TeamPoints[Axis] += %opt;
} 
		
function m::pickteam(%clientId, %team)
{
if(%team != -1 && %team == Client::getTeam(%clientId)) return;
if(gamebase::getteam(%clientId) == -1) schedule("game::spawninterface(" @ %clientId @ ");", 0.1);
if(%team == -2)
	{
	if(Observer::enterObserverMode(%clientId)) messageAll(0, Client::getName(%clientId) @ " is now observing."); return;
	return;
	}
%player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	player::setdamageflash(%clientId, 1);
	}
   %clientId.observerMode = "";
if(!%obs) messageAll(0, Client::getName(%clientId) @ " changed teams.");

if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
  
else if(%team > -1) {
 Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, client::getobservercamera(%clientId));
client::setownedobject(%clientId, -1);
GameBase::setTeam(%clientId, %team);
	


   
}
}





//===================================Options on client
function optionsonclient(%sel, %cl)
{
%selname = client::getname(%sel);
newmenu(%cl, "Options on " @ %selname, "optsonclient");

addoption(%cl, %x++, "Start vote on " @ %selname, "voteonpl ", %sel);
if(%cl.adminLVL >= 2) 
	{
	addoption(%cl, %x++, "Manage " @ %selname, "managepl", %sel);
	addoption(%cl, %x++, "Give cookie to " @ %selname, "cookiepl", %sel);
	}
if(%cl.adminLVL >= 3) 
	{
	addoption(%cl, %x++, "Annoy " @ %selname, "annoypl", %sel);
	addoption(%cl, %x++, "Disconnect " @ %selname, "disconnectpl", %sel);
	}
if(%cl.adminLVL >= 4) addoption(%cl, %x++, "Punish " @ %selname, "punishpl", %sel);
// PORT FIX: "Terminate <player>" (the client-crash option) is not offered any more.
}

function m::optsonclient(%cl, %opt)
{
%sel = getword(%opt, 1);
%selname = client::getname(%sel);
%opt = getword(%opt, 0);
// PORT FIX: the menu only LISTS what your admin level allows, but nothing checked what came
// back, so any player could send "punishpl <id>" and jail, blind or freeze anybody.
%need = 1;
if(%opt == "managepl" || %opt == "cookiepl") %need = 2;
if(%opt == "annoypl" || %opt == "disconnectpl") %need = 3;
if(%opt == "punishpl") %need = 4;
if(%opt == "crashpl") %need = 5;
if(%cl.adminLVL < %need) { WWIIPort::deny(%cl, "optsonclient " @ %opt); return; }

if(%opt == "voteonpl") 
	{
	Menu::VoteOnClient(%sel, %cl);
	return;
	}
else if(%opt == "managepl") 
	{
	Menu::Manageclient(%sel, %cl);
	return;
	}
else if(%opt == "annoypl") 
	{
	menu::annoyclient(%sel, %cl);
	return;
	}
else if(%opt == "disconnectpl")
	{
	menu::disconnectclient(%sel, %cl);
	return;
	}
else if(%opt == "punishpl")
	{
	menu::punishclient(%sel, %cl);
	return;
	}
else if(%opt == "crashpl")
	{
	menu::confirmclient(%cl, "Server::TerminateClient(" @ %sel @ ", " @ %cl @ ");");
	return;
	} 
else if(%opt == "cookiepl") 
	{
	bottomprint(%sel, "<jc>" @ client::getname(%cl) @ " gave you a cookie.",5, COOKIE);
	messageall(3, client::getname(%cl) @ " gave " @ client::getname(%sel) @ " a cookie.");
	} 
}

//===============================MANAGE CLIENT======================================
function menu::manageclient(%cl, %admin)
{
newmenu(%admin, "\xb8----------Management Options----------\xb8", "managecl");
addoption(%admin, %x++, "Change team", "changeclteam", %cl);
if(%cl.cantchangeteam) addoption(%admin, %x++, "Unlock Team Changing", "unlockclteam", %cl);
else addoption(%admin, %x++, "Lock on team", "lockclteam", %cl);
addoption(%admin, %x++, "Reset score", "resetclscore", %cl);
if(%cl.cantvote) addoption(%admin, %x++, "Unlock voting", "unlockclvoting", %cl);
addoption(%admin, %x++, "Lock voting", "lockclvoting", %cl);
if(%admin.adminLVL >= 3) 
	{
	addoption(%admin, %x++, "Change score", "changeclscore", %cl);
	if(%cl.canttalk) addoption(%admin, %x++, "Unmute global", "unmuteclglobal", %cl);
	else addoption(%admin, %x++, "Mute global", "muteclglobal", %cl);
	}
} 

function m::managecl(%cl, %opt)
{
%sel = getword(%opt, 1);
%opt = getword(%opt, 0);
%need = 2; // PORT FIX: no admin check
if(%opt == "changeclscore" || %opt == "muteclglobal" || %opt == "unmuteclglobal") %need = 3;
if(%cl.adminLVL < %need) { WWIIPort::deny(%cl, "managecl " @ %opt); return; }

if(%opt == "changeclteam")
	{
	newmenu(%cl, "\xa2----------Select Team----------\xa2", "selclteam");
	addoption(%cl, %x++, "Observer", -2 @ " " @ %sel);
	addoption(%cl, %x++, "Automatic", -1 @ " " @ %sel);
	addoption(%cl, %x++, "Allied", 0 @ " " @ %sel);
	addoption(%cl, %x++, "Axis", 1 @ " " @ %sel);
	return;
	}
else if(%opt == "lockclteam")
	{
	menu::confirmclient(%cl, %sel @ ".cantchangeteam = true;");
	}
else if(%opt == "unlockclteam")
	{
	menu::confirmclient(%cl, %sel @ ".cantchangeteam = false;");
	}
else if(%opt == "resetclscore")
	{
	menu::confirmclient(%cl, %sel @ ".score = 0; Game::refreshClientScore(" @ %sel @ ");");
	}
else if(%opt == "lockclvoting")
	{
	menu::confirmclient(%cl, %sel @ ".cantvote = true;");
	}
else if(%opt == "unlockclvoting")
	{
	menu::confirmclient(%cl, %sel @ ".cantvote = false;");
	}
else if(%opt == "changeclscore")
	{
	menu::confirmclient(%cl, "admin::changeclientscore(" @ %cl @ "," @ %sel @ ");");
	}
else if(%opt == "muteclglobal")
	{
	menu::confirmclient(%cl, %sel @ ".canttalk = true;");
	}
else if(%opt == "unmuteclglobal")
	{
	menu::confirmclient(%cl, %sel @ ".canttalk = false;");
	}

}

//====================================Annoy client================================
function menu::annoyclient(%cl, %admin)
{
newmenu(%admin, "\x88----------Annoy Options----------\x88", "annoycl");
addoption(%admin, %x++, "Next weapon", "nextweap", %cl);
addoption(%admin, %x++, "Boost to sky", "boostup", %cl);
addoption(%admin, %x++, "Disarm", "disarm", %cl);
addoption(%admin, %x++, "Remove weapon", "removeweap ", %cl);
addoption(%admin, %x++, "Bad words", "badwords", %cl);
}

function m::annoycl(%cl, %opt)
{
%sel = getword(%opt, 1);
%opt = getword(%opt, 0);
if(%cl.adminLVL < 3) { WWIIPort::deny(%cl, "annoycl " @ %opt); return; } // PORT FIX: no admin check

if(%opt == "nextweap")
	{
	menu::confirmclient(%cl, "nextweap(" @ %sel @ "," @ %cl @ ");");
	}
else if(%opt == "boostup")
	{
	menu::confirmclient(%cl, "boostup(" @ %sel @ "," @ %cl @ ");");
	}
else if(%opt == "disarm")
	{
	menu::confirmclient(%cl, "disarm(" @ %sel @ "," @ %cl @ ");");
	}
else if(%opt == "removeweap")
	{
	menu::confirmclient(%cl, "removeweapon(" @ %sel @ "," @ %cl @ ");");
	}
else if(%opt == "badwords")
	{
	menu::confirmclient(%cl, "badwords(" @ %sel @ ");");
	}
} 

//==============================Disconnect client=======================
function menu::disconnectclient(%cl,%admin)
{
newmenu(%admin, "\xd6----------Disconnect Way----------\xd6", "disconnectcl");
if(%admin.adminLVL >= 3) addoption(%admin, %x++, "Disconnect " @ client::getname(%cl), 0, %cl);
if(%admin.adminLVL >= 3) addoption(%admin, %x++, "Kick", 1, %cl);
if(%admin.adminLVL >= 4) addoption(%admin, %x++, "30 min ban", 2, %cl);
if(%admin.adminLVL >= 4) addoption(%admin, %x++, "4 hour ban", 3, %cl);
if(%admin.adminLVL >= 5) addoption(%admin, %x++, "1 day ban", 4, %cl);
if(%admin.adminLVL >= 5) addoption(%admin, %x++, "Total ban", 5, %cl);
}

function m::disconnectcl(%cl, %opt)
{
%level = getword(%opt, 0);
%client = getword(%opt, 1);
%need = 3; // PORT FIX: no admin check; the ban length came straight from the client
if(%level >= 2) %need = 4;
if(%level >= 4) %need = 5;
if(%cl.adminLVL < %need || %level < 0 || %level > 5) { WWIIPort::deny(%cl, "disconnectcl " @ %level); return; }

menu::confirmclient(%cl, "ban(" @ %client @ "," @ %level @ "," @ %cl @ ");");
}

//===============================Punish client==========================
function menu::punishclient(%cl, %admin)
{
newmenu(%admin, "\xe2----------Punish way----------\xe2", "punishcl");
if(%cl.blind) addoption(%admin, %x++, "Unblind", "unblind", %cl);
else addoption(%admin, %x++, "Blind", "blind", %cl);
if(%cl.frozen) addoption(%admin, %x++, "Unfreeze", "unfreeze", %cl);
else addoption(%admin, %x++, "Freeze", "freeze", %cl);
if(%cl.jailed) addoption(%admin, %x++, "Release", "unjail", %cl);
else addoption(%admin, %x++, "Jail", "jail", %cl);
}

function m::punishcl(%admin, %opt)
{
%cl = getword(%opt, 1);
%opt = getword(%opt, 0);
if(%admin.adminLVL < 4) { WWIIPort::deny(%admin, "punishcl " @ %opt); return; } // PORT FIX: no admin check

if(%opt == "blind") 
	{
	menu::confirmclient(%admin, "blind(" @ %cl @ "," @ %admin @ ");");
	return;
	}
if(%opt == "unblind") 
	{
	menu::confirmclient(%admin, "unblind(" @ %cl @ "," @ %admin @ ");");
	return;
	}
else if(%opt == "freeze")
	{
	menu::confirmclient(%admin, "freeze(" @ %cl @ "," @ %admin @ ");");
	return;
	}
else if(%opt == "unfreeze")
	{
	menu::confirmclient(%admin, "unfreeze(" @ %cl @ "," @ %admin @ ");");
	return;
	}
else if(%opt == "jail")
	{
	menu::confirmclient(%admin, "jail(" @ %cl @ "," @ %admin @ ");");
	return;
	}
else if(%opt == "unjail")
	{
	menu::confirmclient(%admin, "unjail(" @ %cl @ "," @ %admin @ ");");
	return;
	}
}
//---------------------------------------------------------------

function nextweap(%cl, %admin)
{
centerprint(%cl, "<jc>" @ client::getname(%admin) @ " switched your weapon", 5, SWEAP);
remotenextweapon(%cl);
}
function boostup(%cl, %admin)
{
centerprint(%cl, "<jc>" @ client::getname(%admin) @ " gave you a boost to the sky", 5, BOOST);
player::applyimpulse(%cl, "0 0 900");
}
function disarm(%cl, %admin)
{
centerprint(%cl, "<jc>" @ client::getname(%admin) @ " disarmed you", 5,DISARM);
player::unmountitem(%cl, $weaponslot);
}
function removeweapon(%cl, %admin)
{
centerprint(%cl, "<jc>" @ client::getname(%admin) @ " removed your weapon", 5,REMWEP);
%item = player::getmounteditem(%cl, $weaponslot);
player::unmountitem(%cl, $weaponslot);
player::setitemcount(%cl, %item, 0);
}
function badwords(%cl, %admin)
{
%rand = floor(getrandom() * 4);
if(%rand == 0) messageall(5, client::getname(%cl) @ ": I am a fucking idiot and last night I had sex with my mom.");
else if(%rand == 1) messageall(5, client::getname(%cl) @ ": I am a cat fucking bastard and I'm very gay.");
else if(%rand == 2) messageall(5, client::getname(%cl) @ ": I'm a crazy bitch! I suck a dick every day.");
else if(%rand == 3) messageall(5, client::getname(%cl) @ ": I fuck my dad every day in the ass.");
}
//-------------------------------------------------------------------------------------
function menu::voteonclient(%client, %voter)
{
%name = client::getname(%client);

newmenu(%voter, "\xe6----------Vote Options----------\xe6", "voteoncl");
addoption(%voter, %x++, "Vote to kick " @ %name, "votetokick", %client);
addoption(%voter, %x++, "Vote to freeze " @ %name, "votetofreeze", %client);
}
function M::voteoncl(%client, %opt)
{
%sel = getword(%opt, 1);
%opt = getword(%opt, 0);

if(%opt == "votetokick")
	{
	votesystem::startvote(%client, "kick " @ client::getname(%sel), "ban(" @ %sel @ ", 1);");
	return;
	}
else if(%opt == "votetofreeze")
	{
	votesystem::startvote(%client, "freeze " @ client::getname(%sel), "freeze(" @ %sel @ ");");
	return;
	}
}
//--------------------------------------------------------

function menu::confirmclient(%cl, %command,%text)
{
newmenu(%cl, "\xe3---------Confirm: " @ %text, "confirm");
// PORT FIX: the command used to travel to the client inside the menu code and come back to be
// eval()ed, so any player who reached a confirm menu could send back a command of their own.
// It now stays on the server; the client only answers true or false.
%cl.confirmCommand = %command;
addoption(%cl, %x++, "Confirm", "true");
addoption(%cl, %x++, "Cancel", "false");

}

function m::confirm(%cl, %opt)
{
%command = %cl.confirmCommand;
%cl.confirmCommand = "";
if(%opt == "true" && %command != "") eval(%command);


}

function remoteSelectClient(%clientId, %selId)
{
if($WWII::TraceClients) %clientId.remotecall++;	
security::AntiSpam(%clientId, "RemoteSelectClient");
if(%clientId.critical) return;

   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "mainmenu")
         Game::menuRequest(%clientId);
      remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, "Name: " @ $Client::info[%selId, 1]);
      remoteEval(%clientId, "setInfoLine", 3, "Email: " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
	  remoteEval(%clientId, "setInfoLine", 6, "Misc: " @ WWII::InfoClient(%selId));
   //   remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
   }
}

function WWII::InfoClient(%cl)
{
if(%cl.WWIICS != "") %str = %str @ " WWII CS v" @ %cl.WWIICS @ ". ";
if(%cl.adminLVL > 1) %str = %str @ " Admin " @ %cl.adminLVL @ ". ";
if(%cl.adminLVL > 1 && getword(client::getname(%cl), 0) == "*|BFW|*") %str = %str @ "BFW confirmed. ";
return %str;
}

function freeze(%clientId, %admin,%special)
{
if(%special)
	{
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
	Centerprint(%clientId, "<jc>You are being naughty.");
	return;
	}
if(!%admin) 
	{
	centerprint(%clientId, "<jc><f2>You were frozen by the consensus. You got 1 minute, take your time.", 10);
	%clientId.frozen = 1;
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
	schedule("unfreeze(" @ %clientId @ ");", 60);
	}
else 
	{
	messageall(1, client::getname(%admin) @ " gave " @ client::getname(%clientId) @ " a time-out.");
	centerprint(%clientId, "<jc><f2>You were frozen by " @ client::getname(%admin), 10);
	%clientId.frozen = 1;
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
	}	
}

function unfreeze(%clientID)
{
%clientId.frozen = false;
Client::setControlObject(%clientId, %clientId);
messageall(1, client::getname(%clientId) @ " has returned to the action after a brake.");
}

function admin::changeclientscore(%admin, %sel)
{
%admin.enteringscore = true;
%admin.sel = %sel;
centerprint(%admin, "<jc>Type in the score (global chat)", 5);
}


function ban(%cl, %level, %admin, %crash)
{
//if(%cl == %admin) {
//centerprint(%admin, "<jc>Go fuck yourself!", 5);
//return;
//}
%adminname = client::getname(%admin);
if(%admin == "") { %admin = 2048; %adminname = "Server"; }
%clname = client::getname(%cl);
 
if(%admin.adminLVL <= %cl.adminLVL)
	{
	centerprint(%admin, "<jc><f2>Go fuck yourself!", 5,MENU);
	echo(%adminname @ " tried ban option on " @ %clname @ " ------------");
	return;
	} 

if(%level == 0) 
	{
	%export = false;
	kick(%cl, "You were disconnected from the game by admin.");
	messageall(1, %adminname @ " disconnected " @ %clname @ " from the server");
	}
else if(%level == 1)
	{
	%export = true;
	kick(%cl, "You were kicked from the game by admin.");
	banlist::add(filterip(client::gettransportaddress(%cl)), 60);
	messageall(1, %adminname @ " kicked " @ %clname @ " from the server");
	Jail::Add(%cl, 1);
	}
else if(%level == 2)
	{
	%export = true;
	kick(%cl, "You were banned by admin.");
	banlist::add(trimip(%cl), (60 * 30));
	messageall(1, %adminname @ " banned " @ %clname @ " from the server");
	Jail::Add(%cl, 2);
	}
else if(%level == 3)
	{
	%export = true;
	kick(%cl, "You were banned by admin.", %crash);
	banlist::add(trimip(%cl), (60 * 60 * 4));
	messageall(1, %adminname @ " banned " @ %clname @ " from the server for 4 hours");
	Jail::Add(%cl, 2);
	}
else if(%level == 4)
	{
	%export = true;
	kick(%cl, "You were banned by admin.");
	banlist::add(trimip(%cl), (60 * 60 * 24));
	messageall(1, %adminname @ " banned " @ %clname @ " from the server for 1 DAY");
	Jail::Add(%cl, 4);
	}
else if(%level == 5)
	{
	%export = true;
	kick(%cl, "You were banned FOREVER by server leader");
	//banlist::addAbsolute(%ip, 0);	
	banlist::add(trimip(%cl), (60 * 60 * 1000));
	messageall(1, %adminname @ " banned " @ %clname @ " FOREVER!!");
	Jail::Add(%cl, 5);
	}
if(%export)
	{
	%clientip = client::trimip(%cl);
	banlist::export("config\\banlist.cs");
	
	}

dbecho(1, "BAN: banned = " @ %cl @ "(" @ %clname @ "), admin = " @ %admin @ "(" @ %adminname @ ")");
}

function kick(%cl, %reason, %crash)
{
if(%crash) %reason = "Server went down..";
schedule("damnit(" @ %cl @ ",\"" @ %reason @ "\");", 0);
}

function damnit(%cl, %reason)
{
net::kick(%cl, %reason);
}

function blind(%cl, %admin)
{
messageall(1, client::getname(%admin) @ " poked " @ client::getname(%cl) @ "'s eyes with a spoon");
centerprint(%cl, "<jc><f2>You are blind!");
%cl.blind = true;
redscreen(%cl);
}

function redscreen(%cl)
{
if(!%cl.blind) return;
player::setdamageflash(%cl, 2.5);
schedule("redscreen(" @ %cl @ ");", 1);
}

function unblind(%cl, %admin)
{
messageall(1, client::getname(%admin) @ " pushed new eyes in " @ client::getname(%cl) @ "'s head");
%cl.blind = false;
}

function jail(%cl, %admin, %nomsg)
{
if(!%nomsg) messageall(1, client::getname(%admin) @ " arrested " @ client::getname(%cl));
%cl.jailed = true;
%clpos = gamebase::getposition(%cl);
if(!%nomsg) centerprint(%cl, "<jc>" @ client::getname(%admin) @ " arrested you and thrown you into jail.", 5,JAIL);
else centerprint(%cl, "<jc>Welcome back! This place missed you very much!", 5,JAIL);

//------------creating jail
%jailfloorpos = vector::add(%clpos, "0 0 1200");
%jailfloor = newObject("Jail",InteriorShape,"BELfloatingpad.dis");
addtoset("MissionCleanup", %jailfloor);
%jailfloorrot = gamebase::getrotation(%jailfloor);
gamebase::setposition(%jailfloor, %jailfloorpos);

%jailroofpos = vector::add(%clpos, "0 0 1220");
%jailroof = newObject("Jail",InteriorShape,"BELfloatingpad.dis");
addtoset("MissionCleanup", %jailroof);
%jailroofrot = gamebase::getrotation(%jailroof);
gamebase::setposition(%jailroof, %jailroofpos);

%jailwall1pos = vector::add(%jailfloorpos, "0 5 30");
%jailwall1rot = "80 0 0";
%jailwall1 = newObject("Jail",InteriorShape,"BELfloatingpad.dis");
addtoset("MissionCleanup", %jailwall1);
gamebase::setposition(%jailwall1, %jailwall1pos);
gamebase::setrotation(%jailwall1, %jailwall1rot);

%jailwall2pos = vector::add(%jailfloorpos, "0 -25 30");
%jailwall2rot = "80 0 0";
%jailwall2 = newObject("Jail",InteriorShape,"BELfloatingpad.dis");
addtoset("MissionCleanup", %jailwall2);
gamebase::setposition(%jailwall2, %jailwall2pos);
gamebase::setrotation(%jailwall2, %jailwall2rot);

%jailwall3pos = vector::add(%jailfloorpos, "25 0 30");
%jailwall3rot = "0 80 0";
%jailwall3 = newObject("Jail",InteriorShape,"BELfloatingpad.dis");
addtoset("MissionCleanup", %jailwall3);
gamebase::setposition(%jailwall3, %jailwall3pos);
gamebase::setrotation(%jailwall3, %jailwall3rot);

%jailwall4pos = vector::add(%jailfloorpos, "-5 0 30");
%jailwall4rot = "0 80 0";
%jailwall4 = newObject("Jail",InteriorShape,"BELfloatingpad.dis");
addtoset("MissionCleanup", %jailwall4);
gamebase::setposition(%jailwall4, %jailwall4pos);
gamebase::setrotation(%jailwall4, %jailwall4rot);

//-------------------------JAIL CREATED

$jailpart[%cl, 1] = %jailfloor;
$jailpart[%cl, 6] = %jailroof;
$jailpart[%cl, 2] = %jailwall1;
$jailpart[%cl, 3] = %jailwall2;
$jailpart[%cl, 4] = %jailwall3;
$jailpart[%cl, 5] = %jailwall4;

gamebase::setposition(%cl, vector::add(%jailfloorpos, "0 0 20"));
gamebase::setrotation(%jailfloor, "0 0 0");
}

function unjail(%cl, %admin)
{
%cl.jailed = false;
if(getrandom() > 0.5) bottomprint(%cl, "<jc><f2>You are free to go...\n\nSpam-press 9 key to open the parachute.", 5, ADMIN);
messageall(1, client::getname(%admin) @ " released " @ client::getname(%cl) @ " from prison.");
deleteobject($jailpart[%cl, 1]);
for(%x = 2; %x < 6; %x++)
	{
	schedule("deleteobject(" @ $jailpart[%cl, %x] @ ");", 5);
	}
deletevariables("jailpart" @ %cl @ "*");
}

function trimip(%cl) { return Client::TrimIp(%cl); }

function Client::trimIP(%clientId)
{
   
   %ipstr = client::getTransportAddress(%clientId);
   %ip = string::getSubStr(%ipstr, 0, 15);
   for(%i = 0; string::getSubStr(%ip, %i, 1) != ""; %i++)
   {
	%num = string::getSubStr(%ip, %i, 1);
	if(!String::ICompare(%num, "."))
	{
		%dot++;
		if(%dot == "3")
		{
			%finalIp = string::getSubStr(%ip, 0, %i++);
			%finalIP = %finalIP@"*";
			return %finalIP;
		}
	}
	
   }
   return %ip;
}

function M::selclteam(%cl, %opt)
{
if(%cl.adminLVL < 2) { WWIIPort::deny(%cl, "selclteam"); return; } // PORT FIX: no admin check
%team = getword(%opt, 0);
%target = getword(%opt, 1);
messageall(1, client::getname(%target) @ "'s team was changed by " @ client::getname(%cl) @ ".");
player::kill(client::getownedobject(%target));
client::setownedobject(%target, -1);
gamebase::setteam(%target, %team);
}





//------------------------------------------------------

function WWII::TraceClients(%admin)
{
$WWII::TraceClients = true;
for(%x = 2049; %x < 2060; %x++) %x.remotecall = 0;
schedule("WWII::TraceStop(" @ %admin @ ");", 10);
}

function WWII::TraceStop(%admin)
{
%text = "<jc>";

for(%x = Client::getFirst(); %x != -1; %x = Client::getNext(%x))
	{
	%text = %text @ "<f2>" @ Client::GetName(%x) @ "<f1>: " @ %x.remotecall @ "\n\n";
	}
centerprint(%admin, %text, 10);
$WWII::TraceClients = false;
}

function WWII::ServerReboot()
{
centerprintall("<jc><f2>SERVER IS GOING TO REBOOT.\n <f1>YOU WILL BE DISCONNECTED FROM SERVER IN 5 SECONDS", 4);
schedule("WWII::ClientLiquidation(1);", 5);
schedule("quit();", 5);
}

function WWII::ServerShutDown()
{
exec(Net_Database);
$TNet::ServerLaunches++;
export("tnet*", "Config\\Net_Database.cs", false);
deletevariables("tnet*");
centerprintall("<jc><f2>SERVER IS GOING TO SHUT DOWN.\n <f1>YOU WILL BE DISCONNECTED FROM SERVER IN 5 SECONDS", 4);
schedule("WWII::ClientLiquidation(0);", 5);
schedule("$server::hostPublicGame = false; echo(\"--SERVER SHUTDOWN ENGAGED--\");", 5);
}

function WWII::ClientLiquidation(%restart)
{
for(%x = Client::getFirst(); %x != -1; %x = Client::getNext(%x))
	{
	if(%restart) schedule("Net::Kick(" @ %x @ ", \"Server restarting... \\nReconnect in 10 seconds.\");", 0);
	else schedule("Net::Kick(" @ %x @ ", \"WWII Server was shut down by admin. \\nHope you enjoyed the game and come again.\");", 0);
	}

}

function WWII::ModInfo(%cl, %round)
{
if(%round == 0)
	{
	%cl.frames = 0;
	centerprint(%cl, "<jc>Press Q(next weapon button) to move to next frame.", 7);
	}
%msg1 = "<jc><f1>MOD INFORMATION\n<f3> This 2-minute introduction will explain the mod and its basics.";
%msg2 = "<jc><f1>--The History--\n<f2>The mod idea was developed in 2004 by the mod's author, Roma. The mod was coded from scratch many times\nand always had bugs, glitches, suffered lag etc...\nAlthough there were huge plans on the mod, "; 
%msg3 = "<jc><f1>--The History--\n<f2>the project was always interrupted.\nThis version is the final one and is invincible!";
%msg4 = "<jc><f1>--About The Mod--\n<f2>This is a new mod to the family of *non-jetting* mods, and should be the main one. It is transformed into World War 2, WWII-looking like weapons who's data was taken from other games like BattleField 1942, Call Of Duty ";
%msg5 = "<jc><f1>--About The Mod--\n<f2>and more. The game is now more realistic and for some people - fun.\nThe game mode (objectives) was taken from the game BattleField 1942. Press 'O' to see it.";
%msg6 = "<jc><f1>--Did You Know?--\n<f2>1.'B'(Beacon) key is now an advanced key, which is used in different ways in different situations (you will be notified).\n2.'H'(repair kit) key is used for manual reloading, very usefull.\n";
%msg7 = "<jc><f1>--Did You Know?--\n<f2>3.If you see a box that looks like chaingun ammo somewhere, standing near it resupplies the player (healing too).\n4.Crouching doesnt give you accuracy, but your height gets twice smaller!";
%msg8 = "<jc><f1>+--CREDITS--+\n\nRoma - Project's author, lead coding, mapping, hosting, gameplay editing.\n\nI AM BOB - Little coding help, suggestions.\n\nV@n$ - Gameplay testing, suggestions.\n\nEdik - Gameplay testing, suggestions.\n\n";
%msg9 = "<jc><f1>+--CREDITS--+\n\nSpyMod community (http://spymod.proboards57.com) - for support all the way.\n\nPlasmatic(Annihilation mod) - Little coding help";
%msg10 = "<jc><f1><b0:H_reticle.bmp>http://wwii-tribes.dgmproductions.org/<b0:H_reticle.bmp>\n\nVisit to check player rankings and other stuff";
%msg11 = "<jc><f1>The Rules!\n\n-Respect admins\n-No teamkilling. Keep the game fun.\n-No badwords\n-No Spawn-Killing";

if(%round == 1) { centerprint(%cl, %msg1, 15,MODINFO);  }
if(%round == 2) { centerprint(%cl, %msg2, 15,MODINFO);  }
if(%round == 3) { centerprint(%cl, %msg3, 15,MODINFO);  }
if(%round == 4) { centerprint(%cl, %msg4, 15,MODINFO);  }
if(%round == 5) { centerprint(%cl, %msg5, 15,MODINFO);  }
if(%round == 6) { centerprint(%cl, %msg6, 15,MODINFO);  }
if(%round == 7) { centerprint(%cl, %msg7, 15,MODINFO);  }
if(%round == 8) { centerprint(%cl, %msg8, 15,MODINFO);  }
if(%round == 9) { centerprint(%cl, %msg9, 15,MODINFO);  }
if(%round == 10) { centerprint(%cl, %msg10, 15,MODINFO);  }
if(%round == 11) centerprint(%cl, %msg11, 10,MODINFO);
}
