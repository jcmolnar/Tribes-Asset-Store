// ----------------------------------------------------------------------------
// Paintball Mod
//
// Mod gutted by KingTomato
// Original coding by |K0RN|, with help from [RR]MisterPibb
// ----------------------------------------------------------------------------

// Settings File
exec("KT_Paintball.cs");

exec("Writer_Events.cs");	// Events 
exec("KT_Login.cs");		// Login System
exec("KT_CloneScan.cs");	// Clone Scanner
exec("KT_SpawnArmor.cs");	// Spawn Choices
exec("KT_Money.cs");		// Handles Money

// ----------------------------------------------------------------------------
// Settings based off information found in the KT_paintball file
// ----------------------------------------------------------------------------

if ($PB::Logging)
	$Console::LogMode = 2;

for (%a = 1; (%ip = $PB::Admin::BanList[%a]) != ""; %a++)
	BanList::addAbsolute("IP:"@%ip@":*",1085056735);

// ----------------------------------------------------------------------------

// Voting
$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

// ----------------------------------------------------------------------------
// Selected Client
// Makes a cool teletype print when a user is clicked on in the tab menu.

function remoteSelectClient(%clientId, %selId)
{
	if ($PB::Debug)
		echo(sprintf("%1 has selected %2 from the TAB menu.", %clientId, %selId));

	for (%a = 1; %a < 7; %a++)
	{
		remoteEval(%clientId, setInfoLine, %a, "");
		%infoLine[%a] = "";
	}

	// First selection
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		%clientId.selPage = 1;
	}

	if(%clientId.menuMode == "options")
		Game::menuRequest(%clientId);

	%name = Client::GetName(%selId);
	%page = %clientId.selPage;
	%p = 0;

	// --------------- Page 1
	%curItem = 0;
	%p++;

	%infoLine[%p, %curItem++] = "Player Info for " @ %name @ ":";
	%infoLine[%p, %curItem++] = "Real Name: " @ $Client::info[%selId, 1];
	%infoLine[%p, %curItem++] = "Email Addr: " @ $Client::info[%selId, 2];
	%infoLine[%p, %curItem++] = "Tribe: " @ $Client::info[%selId, 3];
	%infoLine[%p, %curItem++] = "URL: " @ $Client::info[%selId, 4];
	//PORT-OFF: %infoLine[%p, %curItem++] = "Other: " @ $Client::info[%selId, 5];

	// --------------- Page 2 (Admins only)
	if (%clientId.isAdmin)
	{
		%curItem = 0;
		%p++;

		%admin = "No Admin";
		if (%selId.isSuperAdmin) %admin = "Super Admin";
		else if (%selId.isAdmin) %admin = "Admin";

		%infoLine[%p, %curItem++] = "Extended Info for " @ %name @ ":";
		%infoLine[%p, %curItem++] = "Admin Status: " @ %admin;

		if (%clientId.isSuperAdmin)
		{
			%ip      = Clones::IpOnly(Client::GetTransportAddress(%selId));
			%address = Clones::RepIp(%ip);

			%infoLine[%p, %curItem++] = "IP: " @ Client::GetTransportAddress(%selId);
			%infoLine[%p, %curItem++] = "Clones: " @ $Clones::List[%address];
		}

		%infoLine[%p, %curItem++] = "Weapon/Backpack: " @ Money::Get(%selId, Weapon) @ "/" @ Money::Get(%selId, Backpack);
	}

	// --------------- Page 3
	%curItem = 0;
	%p++;

	if ($Money::Enabled)
	{
		%infoLine[%p, %curItem++] = "Account Information for " @ %name @ ":";
		%infoLine[%p, %curItem++] = "Account Balance: $" @ Money::Get(%selId, Money) @ ".00";
		%infoLine[%p, %curItem++] = "Kills/Deaths: " @ Money::Get(%selId, Kills) @ "(" @ Money::Get(%selId, HeadShot)@"HS)/" @ Money::Get(%selId, Deaths);
		%infoLine[%p, %curItem++] = "Suicides: " @ Money::Get(%selId, Suicides);
		%infoLine[%p, %curItem++] = "Captures/Returns: " @ Money::Get(%selId, Captures) @ "/" @ Money::Get(%selId, Returns);
	}

	// --------------- Print Information

	PB::Menu::Type(%clientId, %infoLine[%page, 1], %infoLine[%page, 2], %infoLine[%page, 3], %infoLine[%page, 4], %infoLine[%page, 5], %infoLine[%page, 6]);

	// --------------- Advance Pages

	%clientId.selPage++;

	if (%infoLine[%clientId.selPage, 1] == "")
		%clientId.selPage = 1;
}

// This is my attempt at making the client menu "type" what it wants. Its either a win or lose,
// but it should make the client information appear to be typed.
function PB::Menu::Type(%clientId, %infoLine1, %infoLine2, %infoLine3, %infoLine4, %infoLine5, %infoLine6)
{
	// This is kind of like how the voting system works. Since schedules cannot be 'killed' per-say,
	// i am just going to check for the number match. If the number is below the menu Typing number,
	// then the schedules will die off one by one.
	if ($PB::Menu::Typing[%clientId] == "")
		$PB::Menu::Typing[%clientId] = 0;
	$PB::Menu::Typing[%clientId]++;

	if (!$PB::Menu::Teletype)
	{
		for (%lineNum = 1; (%line = %infoLine[%lineNum]) != ""; %lineNum++)
			remoteEval(%clientId, setInfoLine, %lineNum, %line);
		return;
	}

	%delay     = 0;		// Don't need to touch, just keeps incrementing
	%delayTime = 0.02;	// Adjust for typing speed

	// Now, we go through each info line and process it.
	for (%lineNum = 1; (%line = %infoLine[%lineNum]) != ""; %lineNum++)
	{
		// get length of string
		for (%len = 0; String::getSubStr(%line, %len, 1) != ""; %len++)
		{}

		// Add a letter each line
		for (%a = 1; %a <= %len; %a++)
		{
			schedule("PB::Menu::SetLine(" @ %clientId @ "," @ $PB::Menu::Typing[%clientId] @ "," @ %lineNum @ ",\"" @ escapeString(String::getSubStr(%line, 0, %a)) @ "\");", %delay); // PORT: escaped
			%delay += %delayTime;
		}
	}
}

// Typing function that will check the number
function PB::Menu::SetLine(%clientId, %checkSum, %line, %text)
{
	if (%checkSum == $PB::Menu::Typing[%clientId])
		remoteEval(%clientId, setInfoLine, %line, %text);
}

// ----------------------------------------------------------------------------
// main menu

function Game::menuRequest(%clientId)
{
	%curItem = 0;
	Client::buildMenu(%clientId, $PB::Menu::Title, "options", true);
	if ((!$matchStarted || !$Server::TourneyMode) && (!%clientId.teamLock))
	{
		if ($PB::RecruitMode)
			Client::addMenuItem(%clientId, %curItem++ @ "Recruit options", "recruiting");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	}

	if(%clientId.selClient)
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);

		if($curVoteTopic == "" && !%clientId.isAdmin)
			Client::AddMenuItem(%clientId, %curItem++ @ "Vote options for " @ %name, "votemenu " @ %sel);
		if(%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Admin options for " @ %name, "adminmenu " @ %sel);
		}
		if(%clientId.muted[%sel])
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);

		if (%clientId.speakTo == %sel)
			Client::AddMenuItem(%clientId, %curItem++ @ "Cancel speak to " @ %name, "-speak " @ %sel);
		else
			Client::AddMenuItem(%clientId, %curItem++ @ "Speak to " @ %name, "speak " @ %sel);
	}
	else
	{
		%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
		if ($LCDName[%CurWeap,1] != "")
			Client::addMenuItem(%clientId, %curItem++ @ "LCD Switch","triggergroup");
		if (!$Money::Enabled)
			Client::AddMenuItem(%clientId, %curItem++ @ "Spawn buy list", "spawnbuy");
		else if (%clientId.userId != -1)
			Client::AddMenuItem(%clientId, %curItem++ @ "Client spending options", "clientspending");
		if(%clientId.observerMode == "observerOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "Observe options", "observeopts");
		if(%clientId.isAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Admin options", "adminmenu");
	}
	if ($curVoteTopic != "" && %clientId.vote == "")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}
	else if($curVoteTopic == "" && !%clientId.isAdmin)
		Client::addMenuItem(%clientId, %curItem++ @ "Voting options", "votemenu");
}

// ----------------------------------------------------------------------------
// options

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if ((%opt == "changeteams") && (!%clientId.teamLock))
	{
		if(!$matchStarted || !$Server::TourneyMode)
		{
			Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
			Client::addMenuItem(%clientId, "0Observer", -2);
			Client::addMenuItem(%clientId, "1Automatic", -1);
			for(%i = 0; %i < getNumTeams(); %i = %i + 1)
				Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
			return;
		}
	}
	else if ((%opt == "recruiting") && ($PB::RecruitMode))
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Recruit Options", "RecruitMenu", true);
		if (%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Exit recruit mode", "-recruitmode");

			if (%clientId.recruiter)
				Client::addMenuItem(%clientId, %curItem++ @ "Stop recruiting", "stop");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Start recruiting", "start");
		}
		if (%clientId.recruit)
			Client::addMenuItem(%clientId, %curItem++ @ "Exit recruit queue", "exit");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enter recruit queue", "enter");
		return;
	}
	else if(%opt == "mute")
		%clientId.muted[%cl] = true;
	else if(%opt == "unmute")
		%clientId.muted[%cl] = "";
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
	else if (%opt == "votemenu")
	{
		Client::buildMenu(%clientId, "Voting options", "votemenu", true);

		%curItem = 0;

		// no client being selected
		if (%cl == -1)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
					
			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
				if(!$CountdownStarted && !$matchStarted)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			}
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
		}
		else
		{
			//Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %cl);
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %cl);
		}
		return;
	}
	else if (%opt == "adminmenu")
	{
		if (!%clientId.isAdmin)
		{
			PB::Hacker(%clientId, "access admin menu");
			return;
		}

		%curItem = 0;

		// no client being selected
		if (%cl == -1)
		{
			Client::BuildMenu(%clientId, "Admin options:", "adminmenu", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
				if(!$CountdownStarted && !$matchStarted)
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
			}
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
			Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
			Client::addMenuItem(%clientId, %curItem++ @ "Client Spending", "clspend");
			if ($curVoteTopic != "")
				Client::addMenuItem(%clientId, %curItem++ @ "Force vote to fail", "failvote");
		}

		// client options
		else
		{
			%name = Client::getName(%cl);

			Client::buildMenu(%clientId, "Admin options (" @ %name @ "):", "adminmenu", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %cl);
			if(%clientId.isSuperAdmin)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %cl);

				if ((%sel.isAdmin) && (!%sel.isSuperAdmin))
					Client::addMenuItem(%clientId, %curItem++ @ "Strip " @ %name @ "'s admin", "-admin " @ %cl);
				else if (!%sel.isAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %cl);
			}
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %cl);
			Client::addMenuItem(%clientId, %curItem++ @ "Manipulate " @ %name, "manip " @ %cl);
			if (($Money::Enabled) && (%cl.userId != -1))
				Client::addMenuItem(%clientId, %curItem++ @ "Manage money", "money " @ %cl);
			Client::addMenuItem(%clientId, %curItem++ @ "Statistical Data", "stats " @ %cl);
		}
		return;
	}
	else if(%opt == "observeopts")
	{
		Client::buildMenu(%clientId, "Observer Options","observe",true);
		Client::addMenuItem(%clientId, "1Observe first person", "dist -1");
		Client::addMenuItem(%clientId, "2Observe third person", "dist 5");
		return;
	}
        else if(%opt == "triggergroup")
	{
		%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
		%curItem = 0;
		Client::buildMenu(%clientId,"LCD Switch:","LCD",true);
		for (%a = 1; %a < 6; %a++)
			if ($LCDGroup[%CurWeap] >= %a)
				Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,%a],"LCD " @ %a);
		return;
	} 
	else if (%opt == "spawnbuy")
	{
		processMenuSpawnArmor(%clientId, "Weapon", true);
		return;
	}
	else if (%opt == "speak")
	{
		%clientId.speakTo = %cl;
		Client::sendMessage(%clientId, 0, "To speak to " @ Client::GetName(%cl) @ " prefix your message with \".pm\".");
		Client::sendMessage(%clientId, 0, "Example: .pm Hello, this is a private message!");
		return;
	}
	else if (%opt == "-speak")
	{
		%cl = %clientId.speakTo;
		%clientId.speakTo = "";
		Client::sendMessage(%clientId, 0, "You are no longer speaking with to " @ Client::GetName(%cl));
		return;
	}
	else if (%opt == "clientspending")
	{
		processMenuClientSpending(%clientId, "options");
		return;
	}
	Game::menuRequest(%clientId);
}

// ----------------------------------------------------------------------------
// menu subfunctions

function processMenuAAffirm(%clientId, %opt)
{
	if(%clientId.isSuperAdmin)
	{
		if(getWord(%opt, 0) == "add")
		{

			%cl = getWord(%opt, 1);
			%cl.isAdmin = true;
			messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
		}
		else if (getWord(%opt,0) == "remove")
		{
			%cl = getWord(%opt, 1);
			%cl.isAdmin = false;
			messageAll(0, Client::getName(%clientId) @ " removed " @ Client::getName(%cl) @ "'s admin.");
		}
	}
	Game::menuRequest(%clientId);
}

function processMenuAdminManip(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%name = Client::getName(%cl);
	%admin = Client::GetName(%clientId);
	%color = $PB::Menu::ManipColor;
	%sound = $PB::Menu::ManipSound;

	if (%opt == "menu")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Manipulations for " @ %name, "adminmanip", true);
		
		if (getWord(%option, 2) == -1)
		{
			if (!%cl.isSuperAdmin)
			{
				if (%cl.isGagged)
					Client::addMenuitem(%clientId, %curItem++ @ "Ungag", "-gag " @ %cl);
				else
					Client::addMenuitem(%clientId, %curItem++ @ "Gag", "gag " @ %cl);
				if (%cl.noVoice)
					Client::addMenuitem(%clientId, %curItem++ @ "Allow voicepack", "voice " @ %cl);
				else
					Client::addMenuitem(%clientId, %curItem++ @ "Restrict voicepack", "-voice " @ %cl);
				if (%cl.teamChat)
					Client::addMenuItem(%clientId, %curItem++ @ "Allow global chat", "global " @ %cl);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Restrict to team chat", "-global " @ %cl);
				if (%cl == %clientId.spoofing)
					Client::addMenuitem(%clientId, %curItem++ @ "Stop spoofing", "-spoof " @ %cl);
				else
					Client::addMenuitem(%clientId, %curItem++ @ "Spoof", "spoof " @ %cl);
				if (%cl.teamLock)
					Client::addMenuitem(%clientId, %curItem++ @ "Allow team changing", "teams " @ %cl);
				else
					Client::addMenuitem(%clientId, %curItem++ @ "Restrict team changing", "-teams " @ %cl);

				if (%cl.manipAim)
					Client::addMenuItem(%clientId, %curItem++ @ "Lift accuracy curse", "aiming " @ %cl);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Take away accuracy", "-aiming " @ %cl);
			}
			else
				Client::AddMenuItem(%clientId, %curItem++ @ "(No Options For Admin)", "menu " @ %cl @ " 1");
			Client::addMenuItem(%clientId, %curItem++ @ "More Options", "menu " @ %cl @ " 1");
		}
		else
		{
			if (%cl.godMode)
				Client::addMenuitem(%clientId, %curItem++ @ "Enable damage", "damage " @ %cl);
			else
				Client::addMenuitem(%clientId, %curItem++ @ "Disable damage", "-damage " @ %cl);
			Client::addMenuitem(%clientId, %curItem++ @ "Clear Score", "clrscore " @ %cl);
		}
		return;

		//Client::addMenuitem(%clientId, %curItem++ @ "", "" @ %cl);
	}

	else if (%opt == "aiming")
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.manipAim = false;

		Client::SendMessage(%clientId, %color, "You have lifted " @ %name @ "'s accuracy curse."@%sound);
		Client::SendMessage(%cl, %color, %admin @ " has removed your accuracy curse."@%sound);
	}
	else if (%opt == "-aiming")
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.manipAim = true;

		Client::SendMessage(%clientId, %color, "You have cursed " @ %name @ " with bad accuracy."@%sound);
		Client::SendMessage(%cl, %color, %admin @ " has cursed you with bad accuracy."@%sound);
	}
	else if (%opt == "clrscore")
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.score = 0;
		Game::refreshClientScore(%cl);
		Client::SendMessage(%clientId, %color, "You have reset " @ %name @ "'s score."@%sound);
		Client::SendMessage(%cl, %color, %admin @ " has just reset your score."@%sound);
	}
	else if (%opt == "damage")
	{
		%cl.godMode = false;
		Client::SendMessage(%clientId, %color, "You have enabled player damage for " @ %name @ ".");
		if (%clientId != %cl)
			Client::SendMessage(%cl, %color, %admin @ " has enabled your player damage.");
		messageAll(%color, %admin @ " has enabled " @ %name @ "'s player damage."@%sound);
	}
	else if (%opt == "-damage")
	{
		%cl.godMode = true;
		PLayer::DropItem(%cl, Flag);
		Client::SendMessage(%clientId, %color, "You have disabled player damage for " @ %name @ ".");
		if (%clientId != %cl)
			Client::SendMessage(%cl, %color, %admin @ " has disabled your player damage.");
		messageAll(%color, %admin @ " has disabled " @ %name @ "'s player damage."@%sound);
	}
	else if ((%opt == "gag") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.isGagged = true;
		Client::sendMessage(%clientId, %color, "You have gagged " @ %name @ ".");
		messageAllExcept(%cl, %color, %name @ " has been gagged by " @ %admin @ ", and is unable to speak."@%sound);
		Client::sendMessage(%cl, %color, "You have been gagged by " @ %admin @ ", and are unable to speak."@%sound);
	}
	else if ((%opt == "-gag") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.isGagged = false;
		Client::sendMessage(%clientId, %color, "You have removed " @ %name @ "'s gag.");
		messageAllExcept(%cl, %color, %name @ " has been ungagged by " @ %admin @ ", and is now allowed to speak."@%sound);
		Client::sendMessage(%cl, %color, "You have been ungagged by " @ %admin @ ", and are allowed to speak."@%sound);
	}
	else if ((%opt == "global") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.teamChat = false;
		Client::sendMessage(%clientId, %color, %name @ " is now allowed to use global chat.");
		Client::SendMessage(%cl, %color, "You have been allowed the use of global chat by " @ %admin @ ".");
		messageAll(%color, %admin @ " has allowed " @ %name @ " to use global chat."@%sound);
	}
	else if ((%opt == "-global") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.teamChat = true;
		Client::sendMessage(%clientId, %color, %name @ " is now restricted to using team chat.");
		Client::SendMessage(%cl, %color, "You have been restricted to using team chat by " @ %admin @ ".");
		messageAll(%color, %admin @ " has forced " @ %name @ " to use only team chat."@%sound);
	}
	else if ((%opt == "spoof") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%clientId.spoofing = %cl;
		for (%client = Client::GetFirst(); %client != -1; %client = Client::GetNext(%client))
		{
			if (%client == %clientId)
			{
				Client::sendMessage(%client, %color, "You are now spoofing " @ %name @ "."@%sound);
				Client::sendMessage(%client, %color, "Prefix your message with .spoof to talk as them (Ex: .spoof Hello everyone)");
			}
			else if (%client.isSuperAdmin)
				Client::sendMessage(%client, %color, %admin @ " is now spoofing " @ %name @ "."@%sound);
		}
	}
	else if ((%opt == "-spoof") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%clientId.spoofing = "";
		for (%client = Client::GetFirst(); %client != -1; %client = Client::GetNext(%client))
		{
			if (%client == clientId)
			{
				if (%name)
					Client::sendMessage(%client, %color, "You are no longer spoofing " @ %name @ "."@%sound);
				else
					Client::sendMessage(%client, %color, "You are no longer spoofing a player."@%sound);
			}
			else if (%client.isSuperAdmin)
				Client::sendMessage(%client, %color, %admin @ " is no longer spoofing."@%sound);
		}
	}
	else if ((%opt == "teams") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.teamLock = false;
		Client::SendMessage(%clientId, %color, "You have allowed " @ %name @ " to switch teams.");
		Client::SendMessage(%cl, %color, %admin @ " has allowed you to switch teams.");
	}
	else if ((%opt == "-teams") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.teamLock = true;
		Client::SendMessage(%clientId, %color, "You have restricted " @ %name @ " from switching teams.");
		Client::SendMessage(%cl, %color, %admin @ " has restricted you from switching teams.");
	}
	else if ((%opt == "voice") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.noVoice = false;
		Client::sendMessage(%clientId, %color, "You have allowed " @ %name @ " the use of their voice pack.");
		messageAllExcept(%cl, %color, %name @ " has been allowed the use of their voice pack by " @ %admin @ "."@%sound);
		Client::sendMessage(%cl, %color, %admin @ " has allowed you to use your voice pack."@%sound);
	}
	else if ((%opt == "-voice") && (!%cl.isSuperAdmin))
	{
		if (%cl.isSuperAdmin)
			return;

		%cl.noVoice = true;
		Client::sendMessage(%clientId, %color, "You have restricted " @ %name @ " the use of their voice pack.");
		messageAllExcept(%cl, %color, %name @ " has been restricted of their voice pack by " @ %admin @ "."@%sound);
		Client::sendMessage(%cl, %color, %admin @ " has restricted you from using your voice pack."@%sound);
	}
	processMenuAdminManip(%clientId, "menu " @ %cl);
}

function processMenuAdminMenu(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

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
	else if(%opt == "kick")
	{
		if (!%clientId.isAdmin)
		{
			PB::Hacker(%clientId, "kick " @ Client::GetName(%cl));
			return;
		}
		Client::buildMenu(%clientId, "Select kick reason:", "kaffirm", true);

		%start = getWord(%option, 2);
		if (%start == -1)
			%start = 1;

		%counter = 0;
		for (%a = %start; (%reason = $PB::Menu::KTitle[%a]) != ""; %a++)
		{
			%reason = sprintf(%reason, Client::getName(%clientId), Client::getName(%cl));
			Client::addMenuItem(%clientId, %counter++ @ %reason, "yes " @ %cl @ " " @ %a);
			if ((%counter == 6) && ($PB::Menu::KTitle[%a+1] != ""))
			{
				Client::addMenuItem(%clientId, %counter++ @ "More reasons...", "list " @ %cl @ " " @ %a+1);
				break;
			}
		}

		if ($PB::Menu::KTitle[1] == "")
			Client::AddMenuItem(%clientId, %counter++ @ "Generic Kick", "yes " @ %cl @ " -1");
		Client::addMenuItem(%clientId, %counter++ @ "Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "admin")
	{
		if (!%clientId.isSuperAdmin)
		{
			PB::Hacker(%clientId, "admin " @ Client::GetName(%cl));
			return;
		}
		Client::buildMenu(%clientId, "Confirm admin:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "add " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "-admin")
	{
		if ((!%clientId.isSuperAdmin) || (%cl.isSuperAdmin))
		{
			PB::Hacker(%clientId, "strip admin from " @ Client::GetName(%cl));
			return;
		}
		Client::buildMenu(%clientId, "Confirm strip:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Strip " @ Client::getName(%cl) @ "'s admin", "remove " @ %cl);
		Client::addMenuItem(%clientId, "2Don't strip" @ Client::getName(%cl) @ "'s admin", "no " @ %cl);
		return;
	}
	else if(%opt == "ban")
	{
		if (!%clientId.isSuperAdmin)
		{
			PB::Hacker(%clientId, "ban " @ Client::GetName(%cl));
			return;
		}
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if (%opt == "manip")
	{
		processMenuAdminManip(%clientId, "menu " @ %cl);
		return;
	}
	else if ((%opt == "money") && ($Money::Enabled) && (%cl.userId != -1))
	{
		Client::buildMenu(%clientId, "Money Managing for " @ %name, "MoneyMenu", true);
		Client::addMenuItem(%clientId, "1Increase account balance", "+bal " @ %cl);
		Client::addMenuItem(%clientId, "2Decrease account balance", "-bal " @ %cl);
		Client::addMenuItem(%clientId, "3Clear account", "clear " @ %cl);
		Client::addMenuItem(%clientId, "4Reset account", "reset " @ %cl);
		return;
	}
	else if (%opt == "clspend")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Client spending options", "ClientSpend", true);
		if ($Money::Enabled)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable spending", "disable");
			if ($Money::StrictLogin)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable strict login", "-strict");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Enable strict login", "strict");			
		}
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable spending", "enable");
		return;
	}
	else if(%opt == "etd")
		Admin::setTeamDamageEnable(%clientId, true);
	else if(%opt == "dtd")
		Admin::setTeamDamageEnable(%clientId, false);
	else if(%opt == "cffa")
		Admin::setModeFFA(%clientId);
	else if(%opt == "ctourney")
		Admin::setModeTourney(%clientId);
	else if(%opt == "smatch")
		Admin::startMatch(%clientId);
	else if(%opt == "cmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
	else if(%opt == "ctimelimit")
	{
		if (!%clientId.isAdmin)
		{
			PB::Hacker(%clientId, "change time limit");
			return;
		}
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
	else if(%opt == "reset")
	{
		if (!%clientId.isSuperAdmin)
		{
			PB::Hacker(%clientId, "reset the server");
			return;
		}
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes");
		Client::addMenuItem(%clientId, "2Don't Reset", "no");
		return;
	}
	else if (%opt == "failvote")
	{
		$curVoteCount++;
		$curVoteTopic = "";
		messageAll(0, Client::GetName(%clientId) @ " has forced the current vote to fail.");
	}
	else if (%opt == "stats")
	{
		%curItem = 0;
		%name = Client::getName(%cl);
		Client::buildMenu(%clientId, "Statistical Info for " @ %name, "AdminStats", true);	
		if (%clientId.obsFiring == %cl)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Fire Watch", "-firewatch " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Watch Firing Pattern", "firewatch " @ %cl);
		return;
	}
}

function processMenuAdminStats(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%name = Client::getName(%cl);

	if (%opt == "firewatch")
	{
		%clientId.obsFiring = %cl;
		Client::sendMessage(%clientId, 0, "Now observing " @ %name @ "'s firing pattern.");
	}
	else if (%opt == "-firewatch")
	{
		%clientId.obsFiring = "";
		Client::sendMessage(%clientId, 0, "You are no longer watching " @ %name @ "'s firing pattern.");
		
	}
	processMenuAdminMenu(%clientId, "stats " @ %cl);
}

function processMenuBAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
		Admin::kick(%clientId, getWord(%opt, 1), true);
	Game::menuRequest(%clientId);
}

function processMenuClientSpend(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%admin = Client::GetName(%clientId);

	if (%opt == "enable")
		Money::Activate(true);
	else if (%opt == "disable")
		Money::Activate(false);
	else if (%opt == "strict")
	{
		$Money::StrictLogin = true;
		messageAll(0, "Strict login has been enabled by " @ %admin @ ". User password and ip/name must match.");
	}
	else if (%opt == "-strict")
	{
		$Money::StrictLogin = false;
		messageAll(0, "Strict login has been disabled by " @ %admin @ ". User password is now sufficient for login.");
	}
	processMenuAdminMenu(%clientId, "clspend");
}

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
	if(%clientId.isAdmin)
	{
		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
		Server::loadMission(%misName);
	}
	else
	{
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		Game::menuRequest(%clientId);
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
			Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
			break;
		}
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
	}
}

function processMenuCTLimit(%clientId, %opt)
{
	remoteSetTimeLimit(%clientId, %opt);
}

function processMenuFPickTeam(%clientId, %team)
{
	if(%clientId.isAdmin)
		processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}

function processMenuKAffirm(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%rsn = getWord(%option, 2);

	if(%opt == "yes")
	{
		%cl.kickReason = %rsn;
		Admin::kick(%clientId, %cl);
	}
	else if (%opt == "list")
	{
		processMenuAdminMenu(%clientId, "kick " @ %cl @ " " @ %rsn);
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuLCD(%clientId,%opt)
{
	%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
	if(getWord(%opt,0) == "LCD")
		%clientId.LCDMode[%CurWeap] = getWord(%opt, 1);
		//$LCDMode[%clientId,%CurWeap] = getWord(%opt, 1);
}

function processMenuMoneyMenu(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%amount = getWord(%option, 2);
	%name = Client::getName(%cl);
	%admin = Client::GetName(%clientId);
	%color = $PB::Menu::ManipColor;
	%sound = $PB::Menu::ManipSound;

	if (%opt == "+bal")
	{
		if (%amount == -1)
		{
			Client::BuildMenu(%clientId, "Increase account balance", "MoneyMenu", true);
			Client::addMenuItem(%clientId, "1By $1.00", "+bal " @ %cl @ " 1");
			Client::addMenuItem(%clientId, "2By $5.00", "+bal " @ %cl @ " 5");
			Client::addMenuItem(%clientId, "3By $10.00", "+bal " @ %cl @ " 10");
			Client::addMenuItem(%clientId, "4By $50.00", "+bal " @ %cl @ " 50");
			Client::addMenuItem(%clientId, "5By $100.00", "+bal " @ %cl @ " 100");
			return;
		}
		else
		{
			%bal = Money::Inc(%cl, Money, %amount);
			Client::sendMessage(%cl, %color, %admin @ " has just increased your account balance to $" @ %bal @ %sound);
			Client::sendMessage(%clientId, %color, "You have just increased " @ %name @ "'s account balance to $" @ %bal @ %sound);
			processMenuMoneyMenu(%clientId, "+bal " @ %cl);
			return;
		}
	}
	else if (%opt == "-bal")
	{
		if (%amount == -1)
		{
			Client::BuildMenu(%clientId, "Decrease account balance", "MoneyMenu", true);
			Client::addMenuItem(%clientId, "1By $1.00", "-bal " @ %cl @ " 1");
			Client::addMenuItem(%clientId, "2By $5.00", "-bal " @ %cl @ " 5");
			Client::addMenuItem(%clientId, "3By $10.00", "-bal " @ %cl @ " 10");
			Client::addMenuItem(%clientId, "4By $50.00", "-bal " @ %cl @ " 50");
			Client::addMenuItem(%clientId, "5By $100.00", "-bal " @ %cl @ " 100");
			return;
		}
		else
		{
			%bal = Money::Dec(%cl, Money, %amount);
			Client::sendMessage(%cl, %color, %admin @ " has just increased your account balance to $" @ %bal @ %sound);
			Client::sendMessage(%clientId, %color, "You have just increased " @ %name @ "'s account balance to $" @ %bal @ %sound);
			processMenuMoneyMenu(%clientId, "-bal " @ %cl);
			return;
		}
	}
	else if (%opt == "clear")
	{
		%bal = Money::Set(%cl, Money, "0.00");
		Client::sendMessage(%cl, %color, %admin @ " has just cleared your account account balance to $" @ %bal @ %sound);
		Client::sendMessage(%clientId, %color, "You have just cleared " @ %name @ "'s account balance to $" @ %bal @ %sound);
	}
	else if (%opt == "reset")
	{
		%bal = Money::Set(%cl, Money, "200.00");
		Client::sendMessage(%cl, %color, %admin @ " has just reset your account account balance to $" @ %bal @ %sound);
		Client::sendMessage(%clientId, %color, "You have just reset " @ %name @ "'s account balance to $" @ %bal @ %sound);
	}
	processMenuAdminMenu(%clientId, "money " @ %cl);
}

function processMenuObserve(%clientId, %opt)
{
	%menu = getWord(%opt, 0);
	%o = getWord(%opt, 1);
	if (%menu == "obs")
		Observer::setTargetClient(%clientId, %o);
	else if (%menu == "dist")
	{
		%clientId.observerDist = %o;
		if (%clientId.observerTarget != "")
			Observer::setTargetClient(%clientId, %clientId.observerTarget);
	}
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	if ($PB::RecruitMode)
		return;

	checkPlayerCash(%clientId);

	if(%team != -1 && %team == Client::getTeam(%clientId))
		return;

	if(%clientId.observerMode == "justJoined")
	{
		%clientId.observerMode = "";
		centerprint(%clientId, "");
	}

	if ((%team < -2) || (%team >= getNumTeams())) // PORT: was >, which let team index == team count through
	{
		Client::SendMessage(%clientId, 1, "Invalid menu selection.~waccess_denied.wav");
		return;
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

function processMenuRAffirm(%clientId, %opt)
{
	if(%opt == "yes" && %clientId.isAdmin)
	{
		messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
		Server::refreshData();
	}
	Game::menuRequest(%clientId);
}

function processMenuVoteMenu(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if(%opt == "vkick")
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
	}
	//else if(%opt == "vadmin")
	//{
	//	%cl.voteTarget = true;
	//	Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
	//}
	else if(%opt == "vsmatch")
		Admin::startVote(%clientId, "start the match", "smatch", 0);
	else if(%opt == "vetd")
		Admin::startVote(%clientId, "enable team damage", "etd", 0);
	else if(%opt == "vdtd")
		Admin::startVote(%clientId, "disable team damage", "dtd", 0);
	else if(%opt == "vcffa")
		Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
	else if(%opt == "vctourney")
		Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
	else if(%opt == "vcmission")
	{
		Admin::changeMissionMenu(%clientId, false);
		return;
	}
}

// ----------------------------------------------------------------------------
// admin options

function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
	//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2) $TypeStart = 0;
	else $TypeStart = 1;
	for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
		if($MLIST::Type[%type] == "Paintball")
		{
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
			%index++;
		}
}

function Admin::countVotes(%curVote)
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
		%minVotes = $Server::MinVotes;

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
			%totalVotes = %minVotes;
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
						%votesFor++;
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
		messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
		Admin::voteFailed();
	}
	$curVoteTopic = "";
}

//PORT-OFF: $PB::Menu::KTitle[1]	= "Generic Kick";
//PORT-OFF: $PB::Menu::KTitle[1]	= "You were kicked by %1";
//$PB::Menu::KTime[1]	= 0;

function Admin::kick(%admin, %client, %ban)
{
	if(%admin != %client && (%admin == -1 || %admin.isAdmin))
	{
		if(%ban && !%admin.isSuperAdmin)
			return;
			
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
				messageAll(0, "A super admin cannot be " @ %word @ ".");
			else
				Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
			return;
		}
		%ip = Client::getTransportAddress(%client);

		echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

		if(%ip == "")
			return;
		if(%ban)
			BanList::add(%ip, 1800);
		else
		{
			if ((%admin == -1) || ($PB::Menu::KTime[%client.kickReason] == "")) // PORT: was %admin.kickReason
				BanList::add(%ip, 180);
			else
				BanList::add(%ip, $PB::Menu::KTime[%client.kickReason]);
		}

		%name = Client::getName(%client);

		if(%admin == -1)
		{
			MessageAll(0, %name @ " was " @ %word @ " from vote.");
			Net::kick(%client, "You were " @ %word @ " by  consensus.");
		}
		else
		{
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
			if ($PB::Menu::KReason[%client.kickReason] != "")
			{
				messageAll(0, "Reason Specified: " @ sprintf($PB::Menu::KReason[%client.kickReason], Client::getName(%admin), Client::getname(%client)));
				Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin) @ "\n\n" @
					"Reason: " @ $PB::Menu::KReason[%client.kickReason]);
			}
			else
				Net::Kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
		}
	}
}

function Admin::setModeFFA(%clientId)
{
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 0;
		if(%clientId == -1)
			messageAll(0, "Server switched to Free-For-All Mode.");
		else
			messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");

		$Server::TourneyMode = false;
		centerprintall(); // clear the messages
		if(!$matchStarted && !$countdownStarted)
		{
			if($Server::warmupTime)
				Server::Countdown($Server::warmupTime);
			else	
				Game::startMatch();
		}
	}
}

function Admin::setModeTourney(%clientId)
{
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 1;
		if(%clientId == -1)
			messageAll(0, "Server switched to Tournament Mode.");
		else
			messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");

		$Server::TourneyMode = true;
		Server::nextMission();
	}
}

function Admin::setTeamDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Server::TeamDamageScale = 1;
			if(%admin == -1)
				messageAll(0, "Team damage set to ENABLED by consensus.");
			else
				messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
		}
		else
		{
			$Server::TeamDamageScale = 0;
			if(%admin == -1)
				messageAll(0, "Team damage set to DISABLED by consensus.");
			else
				messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
		}
	}
}

function Admin::startMatch(%admin)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(!$CountdownStarted && !$matchStarted)
		{
			if(%admin == -1)
				messageAll(0, "Match start countdown forced by vote.");
			else
				messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));
		
			Game::ForceTourneyMatchStart();
		}
	}
}

function Admin::startVote(%clientId, %topic, %action, %option)
{
	if(%clientId.lastVoteTime == "")
		%clientId.lastVoteTime = -$Server::MinVoteTime;

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
			%time += %clientId.numFailedVotes * $Server::VoteFailTime;

		%clientId.lastVoteTime = %time;
		$curVoteInitiator = %clientId;
		$curVoteTopic = %topic;
		$curVoteAction = %action;
		$curVoteOption = %option;
		if(%action == "kick")
			$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
		$curVoteCount++;
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
		messageAll(0, Client::GetName(%clientId) @ " initiated a vote to " @ $curVoteTopic);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			%cl.vote = "";
		%clientId.vote = "yes";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(%cl.menuMode == "options")
				Game::menuRequest(%clientId);
		schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
	}
	else
	{
		Client::sendMessage(%clientId, 0, "Voting already in progress.");
	}
}

function Admin::voteFailed()
{
	$curVoteInitiator.numVotesFailed++;

	if($curVoteAction == "kick" || $curVoteAction == "admin")
		$curVoteOption.voteTarget = "";
}

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
				Game::menuRequest($curVoteOption);
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
		Admin::setModeTourney(-1);
	else if($curVoteAction == "ffa")
		Admin::setModeFFA(-1);
	else if($curVoteAction == "etd")
		Admin::setTeamDamageEnable(-1, true);
	else if($curVoteAction == "dtd")
		Admin::setTeamDamageEnable(-1, false);
	else if($curVoteOption == "smatch")
		Admin::startMatch(-1);
}

// ----------------------------------------------------------------------------
// Client Functions

// replaces by kt_login
// function remoteAdminPassword(%client, %password)

function remoteSetPassword(%client, %password)
{
	if (%client.isSuperAdmin)
	{
		$Server::Password = %password;
		if ($Server::Password != "")
			messageAll(1, "Super Admin " @ Client::getName(%client) @ " has changed the server password to \"" @ %password @ "\".");
		else
			messageAll(1, "Super Admin " @ Client::getName(%client) @ " has removed the server password.");
	}
}

function remoteSetTimeLimit(%client, %time)
{
	%time = floor(%time);

	if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
		return;

	if(%client.isAdmin)
	{
		$Server::timeLimit = %time;

		if(%time)
			messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
		else
			messageAll(0, Client::getName(%client) @ " disabled the time limit.");
	}
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
	if(%team >= 0 && %team < 8 && %client.isAdmin)
	{
		$Server::teamName[%team] = %teamName;
		$Server::teamSkin[%team] = %skinBase;
		messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
		@ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
	}
}

function remoteVoteYes(%clientId)
{
	%clientId.vote = "yes";
	centerprint(%clientId, "", 0);
}

function remoteVoteNo(%clientId)
{
	%clientId.vote = "no";
	centerprint(%clientId, "", 0);
}

// ----------------------------------------------------------------------------
// Hacker Triggering

function PB::Hacker(%clientId, %obj)
{
	%name = Client::GetName(%clientId);
	%ip = Client::GetTransportAddress(%clientId);

	if ($PB::Menu::HackAlert)
	{
		$PB::HackerName = %name;
		$PB::HackerDate = timestamp();
		$PB::HackerIP	= %ip;
		$PB::HackerTarget = %obj;
		export("$PB::Hacker*","config\\hackerLog.cs",true);
		deleteVariables("$PB::Hacker*");

		for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if (%cl.isSuperAdmin)
				Client::sendMessage(%cl, 1, "Warning: " @ %name @ " attempted to " @ %obj @ "!");
	}
}