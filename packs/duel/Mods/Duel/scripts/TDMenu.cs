$Weather::LushSky[0] = "lushdayclear.dml";
$Weather::LushSky[1] = "litesky.dml";
$Weather::LushSky[2] = "lushsky_night.dml";
$Weather::LushSky[3] = "";//starfield";

$Weather::SkyColor = "0 0 0";
$Weather::SkyInc = "0.02";

$Weather::Storm[0, 0] = "Blizzard";
$Weather::Storm[1, 0] = "Snow";
$Weather::Storm[2, 0] = "Rain";
$Weather::Storm[3, 0] = "Heavy Rain";

//$Weather::Storm[0, 1] = NewObject("Blizzard", "Snowfall", 1, 30, 0, 0);
//$Weather::Storm[1, 1] = NewObject("Snow", "Snowfall", 1, 0, 0, 0);
//$Weather::Storm[2, 1] = NewObject("Rain", "Snowfall", 1, 0, 0, 1);
//$Weather::Storm[3, 1] = NewObject("Heavy Rain", "Snowfall", 1, 40, 0, 1);

$Weather::Storm[0, 1] = ",1, 30, 0, 0";
$Weather::Storm[1, 1] = ",1, 0, 0, 0";
$Weather::Storm[2, 1] = ",1, 0, 0, 1";
$Weather::Storm[3, 1] = ",1, 40, 0, 1";

function processMenuweather(%client, %option)
{
	%o = getWord(%option, 0);
	%extra = getWord(%option, 1);
	%extra2 = getWord(%option, 2);
	%extra3 = getWord(%option, 3);
	%i=-1;
	if(%o == "main")
	{
		Client::buildMenu(%client, "Weather Options", "weather", true);
		Client::addMenuItem(%client, %i++ @ "Change Sky", "changesky");
		Client::addMenuItem(%client, %i++ @ "Change Sky Color", "changeskycolor");
		Client::addMenuItem(%client, %i++ @ "Change Weather", "changeweather");
		Client::addMenuItem(%client, %i++ @ "Change Lights", "changesky");

		Client::addMenuItem(%client, %i++ @ "Quick Flash", "changesky");
		Client::addMenuItem(%client, %i++ @ "Flash Forever: "@$Weather::Flashing, "changesky");
		return;

	}
	if(%o == "changeskycolor")
	{
		if(%extra == "increase")
		{
			for(%k = 0; %k < 3; %k++)
			{
				if(%k == %extra2)
				{
					%newweather = %newweather@" "@getword($Weather::SkyColor, %k)+$Weather::SkyInc ;
				}
				else {
					%newweather = %newweather@" "@getword($Weather::SkyColor, %k) ;
				}
			}
			$Weather::SkyColor = %newweather ;
			%group = nameToId("MissionGroup\\Lights");

			if(%group != "-1")
			{
				%place = "MissionGroup\\Lights";
				%count = Group::objectCount(%group);
				for(%i = 0; %i <= %count-1; %i++)
				{
					%object = Group::getObject(%group, %i);
					if(isobject(%object))
					{
						echo(%OBJECT@" "@getObjectType(%object)@" "@Object::getName(%object));
						if(getObjectType(%object) == "Sky")
						{
							deleteobject(%object);
							echo("Deleted sky");
						}
					}
				}
			}
			%group = nameToId("MissionGroup\\LandScape");

			if(%group != "-1")
			{
				%place = "MissionGroup\\LandScape";
				%count = Group::objectCount(%group);
				for(%i = 0; %i <= %count-1; %i++)
				{
					%object = Group::getObject(%group, %i);
					if(isobject(%object))
					{
						echo(%OBJECT@" "@getObjectType(%object)@" "@Object::getName(%object));
						if(getObjectType(%object) == "Sky")
						{
							deleteobject(%object);
							echo("Deleted sky");
						}
					}
				}
			}


			%newsky = newObject(Sky, Sky, getword($Weather::SkyColor, 0), getword($Weather::SkyColor, 1), getword($Weather::SkyColor, 2), %sky, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
			addToSet("MissionGroup\\LandScape", %newsky);
		}
		Client::buildMenu(%client, "Sky Color: ", "weather", true);
		Client::addMenuItem(%client, %i++ @ "Red: ", "changeskycolor increase 0");
		Client::addMenuItem(%client, %i++ @ "Green: ", "changeskycolor increase 1");
		Client::addMenuItem(%client, %i++ @ "Blue: ", "changeskycolor increase 2");
		Client::addMenuItem(%client, %i++ @ "Reset Sky Color", "resetskycolor");
		Client::addMenuItem(%client, %i++ @ "Increments: "@$Weather::SkyInc, "changeskyinc");
		Client::addMenuItem(%client, "bBack", "main");
		return;
	}
	if(%o == "resetskycolor")
	{
		$Weather::SkyColor = "0 0 0";
		processMenuweather(%client, "changeskycolor increase 5");
		return;
	}
	if(%o == "changeskyinc")
	{
		//client::sendmessage(%client, $Green, "Type the number as you would using your number keys and decimal and then hit S to set the number.");
		if(%extra == -1 || %extra2 == -1)
		{
			%extra = "";
			%extra2 = false;
		}
		Client::buildMenu(%client, "Increments: "@%extra, "weather", true);
		Client::addMenuItem(%client, "sSet Increments", "setTheSkyIncrements "@%extra);

		for(%i = 0; %i <= 10; %i++)
		{
			Client::addMenuItem(%client, %i@%i, "changeskyinc "@%extra@%i@" "@%extra2);
		}
		if(!%extra2)
		{
			Client::addMenuItem(%client, ".dot", "changeskyinc "@%extra@". "@true);
		}
		//String::GetSubStr(%cmd, 0, 1)

		if($Weather::SkyInc > 0)
		{
			Client::addMenuItem(%client, %i++ @ "Subtract", "changeskyincsub");
		}
		else {
			Client::addMenuItem(%client, %i++ @ "Add", "changeskyincadd");
		}
		return;

	}
	if(%o == "setTheSkyIncrements")
	{
		$Weather::SkyInc = %extra;
		processMenuweather(%client, "changeskycolor");
		return;
	}
	if(%o == "changeweather")
	{
		Client::buildMenu(%client, "Weather Options", "weather", true);

		%x = 0;
		while($Weather::Storm[%x, 0] != "")
		{
			Client::addMenuItem(%client, %i++ @ $Weather::Storm[%x, 0], "addstorm "@%x);
			%x++;
		}
		if($Weather::StormRunning)
		{
			Client::addMenuItem(%client, %i++ @ "Stop "@$Weather::StormType, "stopstorm");
		}
		Client::addMenuItem(%client, "bBack", "main");
		return;
	}
	if(%o == "stopstorm")
	{
		deleteobject($Weather::Storm);
		$Weather::Storm = "";
		$Weather::StormRunning = "";
		$Weather::StormType = "";
	}
	if(%o == "addstorm")
	{
		if($Weather::StormRunning)
		{
			deleteobject($Weather::Storm);
			$Weather::Storm = "";
			$Weather::StormRunning = "";
			$Weather::StormType = "";
		}
		if(%extra == "0")
		{
			%type = "Blizzard";
			%weather = NewObject(%type, "Snowfall", 1, 30, 0, 0);
		}
		else if(%extra == "1")
		{
			%type = "Snow";
			%weather = NewObject(%type, "Snowfall", 1, 0, 0, 0);
		}
		else if(%extra == "2")
		{
			%type = "Rain";
			%weather = NewObject(%type, "Snowfall", 1, 0, 0, 1);
		}
		else if(%extra == "3")
		{
			%type = "Heavy Rain";
			%weather = NewObject(%type, "Snowfall", 1, 40, 0, 1);
		}
		AddToSet("MissionCleanup", %weather);
		for (%k = 0; $Weather::Storm[%k] != ""; %k++)
		{
		}
		echo(%k@" "@$Weather::Storm[%k]@" status-----Current Weather Object: "@%weather);
		$Weather::Storm = %weather;
		$Weather::StormRunning = true;
		$Weather::StormType = %type;
		processMenuweather(%client, "changeweather");
		return;
	}
	if(%o == "changesky")
	{
		Client::buildMenu(%client, "Lush Skies", "weather", true);
		for (%k = 0; $Weather::LushSky[%k] != ""; %k++)
		{
			Client::addMenuItem(%client, %i++ @ $Weather::LushSky[%k], "setsky "@$Weather::LushSky[%k]);
		}
		Client::addMenuItem(%client, "bBack", "main");
		return;
	}
	if(%o == "setsky")
	{
		%sky = %extra;
		%group = nameToId("MissionGroup\\LandScape");
		if(%group != -1)
		{
			%count = Group::objectCount(%group);
			for(%i = 0; %i <= %count-1; %i++)
			{
				%object = Group::getObject(%group, %i);
				if(getObjectType(%object) == "Sky")
				{
					deleteobject(%object);
				}
			}
		}
		%newsky = newObject(Sky, Sky, 0, 0, 0, %sky, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
		addToSet("MissionGroup\\LandScape", %newsky);
		processMenuweather(%client, "changesky");
		return;
	}
	processMenuweather(%client, "main");
}
function processMenuchooseweapon(%clientId, %opt) {
	%weap = getword(%opt, 0);
	%num = getword(%opt, 1);
	if(%weap == "more") {
		%i = getword(%opt, 2);
		WeaponSetup(%clientId, %num, %i);
		return;
	}
	if(%weap == "5" && %clientId.pack != "1" || %weap == "5" && %clientId.armor != "1")
	{
		%clientId.pack = 1;
		%clientId.armor = 1;
		client::sendmessage(%clientId, $Green, "Your armor and pack has been automatically set to: "@$DuelArmor[%clientId.armor]@": "@$DuelPack[%clientId.pack]);
	}
	%clientId.tempweapon[%num] = %weap;
	%num++;
	if(%num == 5) {

		for(%x=0; %x < 5; %x++)
		{
			%clientId.weapon[%x] = %clientId.tempweapon[%x] ;
			%clientId.tempweapon[%x] = "";
		}
		WeaponSetupBottomPrintString(%clientId);
		processMenuOptions(%clientId, "loadoutsetup");
		return;
	}
	WeaponSetup(%clientId, %num, -1);
}
function WeaponSetupBottomPrintString(%clientId)
{
	bottomprint(%clientId, "<jc><f1>Your weapon setup is <f2>" @
	$DuelArmor[%clientId.armor] @ "<f1>, <f2>" @
	$DuelWeapon[%clientId.weapon[0]] @ "<f1>, <f2>" @
	$DuelWeapon[%clientId.weapon[1]] @ "<f1>, <f2>" @
	$DuelWeapon[%clientId.weapon[2]] @ "<f1>, <f2>" @
	$DuelWeapon[%clientId.weapon[3]] @ "<f1>, and <f2>" @
	$DuelWeapon[%clientId.weapon[4]] @ "<f1>.\nYour pack setup is a <f2>" @
	$DuelPack[%clientId.pack] @ "<f1>.", 10);
}
function WeaponSetup(%clientId, %num, %i) {
	for(%x=0; %x < 5; %x++)
	{
		if(%num) {
		%w[%x] = %clientId.tempweapon[%x];
		}
		else
		{
			%w[%x] = "";
			%clientId.tempweapon[%x] = "";
		}
	}
	if(!%num) %num=0;
	Client::buildMenu(%clientId, "Select your weapons (" @ (5 - %num) @ " left):", "chooseweapon", true);
	%t=0;
	while(true)
	{
		%i++;
		if(%i != %w0 && %i != %w1 && %i != %w2 && %i != %w3 && %i != %w4 && $DuelWeapon[%i] != "Mortar")
		{
			if(%i == "5" && %num > 2 || %i == "5" && %clientId.armor == "2") {
			}
			else {
				%t++;
				Client::addMenuItem(%clientId, %t-1 @ $DuelWeapon[%i], %i @ " " @ %num);
			}
		}
		if(%num == 4 && %t == 4)
		{
			Client::addMenuItem(%clientId, %num @ $DuelWeapon[8], 8 @ " " @ %num);
		}
		if(%t > 8) break;
	}
}
function gw(%g, %w)
{
	if(GetWord(%g, %w) == -1)
	{
		//echo("Bad GetWord string: "@%g@" Place: "@%w);
	}
	return GetWord(%g, %w);
}
function processMenummisc(%clientId, %option) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction("processMenummisc "@%option);
	}
	%time = Time::getMinutes((floor(getSimTime()) - %clientId.LastAction));
	if(%option != "checkinvites")
	{
		if(%time > 0.9)
		{
			%clientId.LastAction = floor(getSimTime());
			Game::refreshClientScore(%clientId);
		}
		else
		{
			%clientId.LastAction = floor(getSimTime());
		}
	}

	%o = getWord(%option, 0);
	%extra = getWord(%option, 1);
	//edited in v
	%extra2 = getWord(%option, 2);
	%extra3 = getWord(%option, 3);
	%extra4 = getWord(%option, 4);
	%extra5 = getWord(%option, 5);
	%extra6 = getWord(%option, 6);
	%extra7 = getWord(%option, 7);

	if(%o == "viewsmurfs" && %extra.AboveAdmin || %o == "gmutetoggle" && %extra.AboveAdmin || %o == "removeadmin" && %extra.AboveAdmin || %o == "removehimfromteam" && %extra.AboveAdmin || %o == "mute" && %extra.AboveAdmin || %o == "vkick" && %extra.AboveAdmin || %o == "kickplayerteamaffirm" && %extra.AboveAdmin || %o == "ban" && %extra.AboveAdmin)
	{
		return;
	}


    %curItem = 0;
	for(%x = 0; (gw(%option, %x) != "-1"); %x++)	{ %opt[%x] = gw(%option, %x);	}
	if(%opt[0] == "loadoutsetup")
	{
		Client::buildMenu(%clientId, "Loadout Setup", "mmisc", true);
		if(%clientId.weapon[0] == "" || %clientId.weapon[1] == "" || %clientId.weapon[2] == "") {	%clientId.weapon[0] = "3"; %clientId.weapon[1] = "4"; %clientId.weapon[2] = "2"; }
		Client::addMenuItem(%clientId, "sSetup All", "PackSetup");
		%x=0; %weap = String::getSubStr($DuelWeapon[%clientId.weapon[%x]], 0, 1) @" "@String::getSubStr($DuelWeapon[%clientId.weapon[%x++]], 0, 1) @" "@String::getSubStr($DuelWeapon[%clientId.weapon[%x++]], 0, 1) @" "@String::getSubStr($DuelWeapon[%clientId.weapon[%x++]], 0, 1) @" "@String::getSubStr($DuelWeapon[%clientId.weapon[%x++]], 0, 1) ;
		Client::addMenuItem(%clientId, %curItem++@"Weapons: "@%weap, "weaponsetup "@%curItem);
		Client::addMenuItem(%clientId, %curItem++@"Pack: "@$DuelPack[%clientId.pack], "PackSetup Go");
		Client::addMenuItem(%clientId, %curItem++@"Armor: "@$DuelArmor[%clientId.armor], "ArmorSetup Go");
		if(%clientId.prefs["flash"] == "1")
		{
			Client::addMenuItem(%clientId, %curItem++@"Damage Flash: Full", "flashtoggle");
		}
		else {
			Client::addMenuItem(%clientId, %curItem++@"Damage Flash: Soft", "flashtoggle");
		}
		Client::addMenuItem(%clientId, "bBack", "back");
		return;
	}
	if(%opt[0] == "flashtoggle")
	{
		if(%clientId.prefs["flash"] == "1")
		{
			%clientId.prefs["flash"] = 1.5;
		}
		else {
			%clientId.prefs["flash"] = 1;
		}
		processMenummisc(%clientId, "loadoutsetup");
	}
	if(%opt[0] == "weaponsetup")
	{
		processMenuchooseweapon(%clientId);
		return;
	}
	if(%opt[0] == "PackSetup")
	{
		Client::buildMenu(%clientId, "Pack Select: ", "mmisc", true);
		for(%x=1; %x < 6; %x++)
		{
			Client::addMenuItem(%clientId, %curItem++@$DuelPack[%x], "setpack "@%x@" "@%opt1);
		}
		return;
	}
	if(%opt[0] == "ArmorSetup")
	{
		Client::buildMenu(%clientId, "Armor Select: ", "mmisc", true);
		for(%x=1; %x < 4; %x++)
		{
			Client::addMenuItem(%clientId, %curItem++@$DuelArmor[%x], "setarmor "@%x@" "@%opt1);
		}
		return;
	}
	//echo(%opt[1]@"---"@%opt[2]);
	if(%opt[0] == "setarmor")
	{
		%count=0;
		if(%opt1 != "1")
		{
			for(%x=0; %x < 3; %x++)
			{
				if(%clientId.weapon[%x] == "5")
				{
					%weap = %x;
					break;
				}
			}
			for(%x=1; %x < 8; %x++)
			{
				if(%x != %clientId.weapon[0] && %x != %clientId.weapon[1] && %x != %clientId.weapon[2] && %x != %clientId.weapon[3] && %x != %clientId.weapon[4] && %x != "5")
				{
					client::sendmessage(%clientId, $red, "Cannot use Laser Rifle with "@$DuelArmor[%opt1]@"! Replacing with "@$DuelWeapon[%x]);
					%clientId.weapon[%weap] = %x;
					break;
				}
			}
		}

		%clientId.armor = %opt1;
		WeaponSetupBottomPrintString(%clientId);

		if(%opt2 != "Go")
		processMenuchooseweapon(%clientId);
		else
		processMenummisc(%clientId, "loadoutsetup");
		return;
	}
	if(%opt[0] == "setpack")
	{
		%clientId.pack = %opt1;
		WeaponSetupBottomPrintString(%clientId);

		if(%opt2 != "Go")
		processMenummisc(%clientId, "ArmorSetup");
		else
		processMenummisc(%clientId, "loadoutsetup");
		return;
	}
	if(%opt[0] == "back")
	{
		game::menurequest(%clientId);
		return;
	}
	if(%o == "toggleSpeed")
	{
		Client::buildMenu(%clientId, "Automatic request last duel", "mmisc", true);
		Client::addMenuItem(%clientId, "1Disable", "setSpeed False");
		Client::addMenuItem(%clientId, "2Request at end of duel", "setSpeed EndOfD");
		Client::addMenuItem(%clientId, "3Fast Mode", "setSpeed True");
		return;
	}
	if(%o == "togglevgraph")
	{
		if(%clientId.prefs["VoteGraphic"])
		{
			%clientId.prefs["VoteGraphic"] = false;
		}
		else {
			%clientId.prefs["VoteGraphic"] = true;
		}
		if(%clientId.Team != "")
		{
			//%opt = "prefs";
			processMenummisc(%clientId, "prefs");
			//echo("what");
			return;
		}
		%opt = "misc";
		processMenuOptions(%clientId, %opt);
		return;
	}
	if(%o == "toggleMADEBUG")
	{
		if(%clientId.debug)
		{
			%clientId.debug = "";
			client::sendmessage(%clientId, $White, "MA debug messages turned off");
		}
		else {
			%clientId.debug = true;
			client::sendmessage(%clientId, $White, "MA debug messages turned on");
		}
		%opt = "misc";
		processMenuOptions(%clientId, %opt);
		return;
	}
	if(%o == "Veto")
	{
		Veto(%clientId);
	}
	if(%o == "statssetup")
	{
		%clientId.pwsetup = true;
		client::sendmessage(%clientId, $White, "Type in your new password.");
	}
	if(%o == "haha")
	{
		client::sendmessage(%clientId, $White, "!~werror_message.wav");
		client::sendmessage(%clientId, $White, "~wmine_act.wav");
		client::sendmessage(%clientId, $White, "~werror_message.wav");
		client::sendmessage(%clientId, $White, "~wmine_act.wav");
		client::sendmessage(%clientId, $White, "~werror_message.wav");
		client::sendmessage(%clientId, $White, "~wmine_act.wav");
		client::sendmessage(%clientId, $White, "~werror_message.wav");
		client::sendmessage(%clientId, $White, "~wmine_act.wav");
		client::sendmessage(%clientId, $White, "~werror_message.wav");
		client::sendmessage(%clientId, $White, "~wmine_act.wav");
		client::sendmessage(%clientId, $White, "~werror_message.wav");
		client::sendmessage(%clientId, $White, "~wmine_act.wav");
		client::sendmessage(%clientId, $White, "~werror_message.wav");
		client::sendmessage(%clientId, $White, "~wmine_act.wav");
	}
	if(%o == "SSS")
	{
		if(%clientId.CanLoad || %clientId.isSuperAdmin)
		{
			Client::buildMenu(%clientId, "Stats Setup", "mmisc", true);
			if(CheckSavedStats(%clientId))
			{
				if(%clientId.password != "")
				{
					Client::addMenuItem(%clientId, %i++ @ "Change Password", "statssetup");
				}
				Client::addMenuItem(%clientId, %i++ @ "Load Stats", "loadmestats");
				if(%clientId.marked)
				{
					Client::addMenuItem(%clientId, %i++ @ "Cannot Save", "haha");
				}
				else {
					if(%clientId.password != "")
					{
						Client::addMenuItem(%clientId, %i++ @ "Save Stats", "savemestats");
					}
				}
				if(%clientId.password != "")
				{
					Client::addMenuItem(%clientId, %i++ @ "Delete Stats", "deletemestats");
				}
			}
			else {

				//if(%clientId.password == "")
				//{
					Client::addMenuItem(%clientId, %i++ @ "Stats Setup", "statssetup");
				//}
				return;
			}
		}
		else {
			client::sendmessage(%clientId, $White, "You don't have access for that!~werror_message.wav");
		}
		return;
	}
	if(%o == "savemestats")
	{
		client::sendmessage(%clientId, $White, "Stats Saved.~wmine_act.wav");
		%clientId.scorerestore = "";
		%clientId.scorecheck = "";
		%clientId.tick = "";
		SaveStats(%clientId);
		return;
	}
	if(%o == "loadmestats")
	{

		if(%clientId.loaded)
		{
			client::sendmessage(%clientId, $Red, "Your stats are already loaded.~werror_message.wav");
			return;
		}
		%clientId.loaded = true;
		%clientId.scorerestore = "";
		%clientId.scorecheck = "";
		%clientId.marked = false;
		%clientId.tick = "";
		client::sendmessage(%clientId, $White, "Stats Loaded.~wmine_act.wav");
		LoadStats(%clientId, true);

		return;
	}
	if(%o == "deletemestats")
	{
		Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
		Client::addMenuItem(%clientId, X @ "Delete Saved Stats?", "deletemestats2");
		return;
	}
	if(%o == "deletemestats2")
	{
		%clientId.scorerestore = "";
		%clientId.scorecheck = "";
		%clientId.tick = "";
		Stats::DeleteProfile(%clientId);
	}
    if(%o == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%clientId.selClient), "yes " @ %clientId.selClient);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%clientId.selClient), "no " @ %clientId.selClient);
      return;
   }
    if(%o == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%clientId.selClient), "yes " @ %clientId.selClient);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%clientId.selClient), "no " @ %clientId.selClient);
      return;
   }
    if(%o == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      //Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%clientId.selClient), "yes " @ %clientId.selClient);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%clientId.selClient), "no " @ %clientId.selClient);
      return;
   }
	if(%o == "removeadmin") {
		%clientId.selClient.isAdmin = "";
		%clientId.selClient.isSuperAdmin = "";
		if(%clientId.selClient == %clientId)
			Client::sendMessage(%clientId.selClient,1,"You have revoked your Admin Status.");
		else {
			Client::sendMessage(%clientId.selClient,1,"Your Admin Status has been revoked.");
			hvcAdminMsg("Admin Status stripped from: " @ Client::getName(%clientId.selClient) @ ".");
		}
	}
	if(%o == "aaa")
	{
		processMenuOptions(%clientId, %extra@" "@%extra2@" "@%extra3);
		return;
	}
	if(%o == "weather")
	{
		processMenuweather(%clientId, "main");
		return;
	}
	if(%o == "AdminStuff")
	{
		if(%clientId.isSuperAdmin)
		{
   			%cl = getWord(%option, 1);
			Client::buildMenu(%clientId, "Admin Options", "mmisc", true);
			//Client::addMenuItem(%clientId, %i++ @ "Weather Channel", "weather");
			if(%clientId.selClient)
			{
				%name = client::getname(%clientId.selClient);
				Client::addMenuItem(%clientId, %i++ @ "Smurfs", "viewsmurfs "@%clientId.selClient@" -1");
				//if(%clientId.AboveAdmin)
				//{

					Client::addMenuItem(%clientId, %i++ @ "Kick " @ %name, "aaa kick " @ %clientId.selClient);
					Client::addMenuItem(%clientId, %i++ @ "Ban " @ %name, "aaa ban " @ %clientId.selClient);
			//	}
				Client::addMenuItem(%clientId, %i++ @ "Admin", "aaa admin " @ %clientId.selClient);
				Client::addMenuItem(%clientId, %i++ @ "Remove Admin Status", "aaa removeadmin " @ %clientId.selClient);

			}
		   if($curVoteTopic != "")
		   {
				   Client::addMenuItem(%clientId, %i++ @ "Veto "@ $curVoteTopic , "Veto");
		   }
			if($ArmorToggle)
			{
				Client::addMenuItem(%clientId, %i++ @ "Disable Armor Setup", toggleArmor);
			}
			else
			{
				Client::addMenuItem(%clientId, %i++ @ "Enable Armor Setup", toggleArmor);
			}



			Client::addMenuItem(%clientId, %i++ @ "TD Toggles", tdtoggles);
			//if(Authorization(%clientId))
			//{
				Client::addMenuItem(%clientId, %i++ @ "Building", building);

			//}
			Client::addMenuItem(%clientId, %i++ @ "Restart Server", RestartServer);
			if(%clientId.AboveAdmin)
			{
				Client::addMenuItem(%clientId, %i++ @ "Set SAD Password", SetSAD);
			}
			if($Goldeneye)
			{
				Client::addMenuItem(%clientId, %i++ @ "Toggle GE & PD: OFF", GEPDTOGGLE);
			}
			else {
				Client::addMenuItem(%clientId, %i++ @ "Toggle GE & PD: ON", GEPDTOGGLE);
			}
		}
		return;
	}
	if(%o == "GEPDTOGGLE")
	{

		if($goldeneye)
		{
			$goldeneye =0;
			both(client::Getname(%clientId)@" has disabled the classic Goldeneye and Perfect Dark maps.");
		}
		else {
			$goldeneye = 1;
			GEINIT();
			both(client::Getname(%clientId)@" has enabled the classic Goldeneye and Perfect Dark maps.");
		}
		processMenummisc(%clientId, "AdminStuff");
	}
	if(%o == "building")
	{
		Client::buildMenu(%clientId, "Building Options", "mmisc", true);
		if(%clientId.workingproject == "")
		{
			Client::addMenuItem(%clientId, %i++ @ "Start Project", "StartProject");
			Client::addMenuItem(%clientId, %i++ @ "Load Project", "LoadProject");
		}

		if(%clientId.workingproject && %clientId.projectnaming == "")
		{
			Client::addMenuItem(%clientId, %i++ @ "Abort Project", "AbortProject");
			Client::addMenuItem(%clientId, %i++ @ "Rename Project", "RenameProject");
			Client::addMenuItem(%clientId, %i++ @ "Save Project", "SaveProject");
			Client::addMenuItem(%clientId, %i++ @ "Load DM", "LoadDMProject");
		}

		Client::addMenuItem(%clientId, %i++ @ "List Buildings", "FullList");
		Client::addMenuItem(%clientId, %i++ @ "Delete Buildings", "dbuildings");
		return;
	}
	if(%o == "RenameProject")
	{
		client::sendmessage(%clientId, 1, "Type the name you wish to change "@%clientId.projectname@" to.");
		%clientId.projectrenaming = true;
		%clientId.projectnaming = true;


	}
	if(%o == "FullList")
	{
		%numItems = Group::objectCount($BuildGroup);
		for(%i = 0 ; %i<%numItems ; %i++)
		{
			%obj = Group::getObject($BuildGroup,%i);
			%name = GameBase::getDataName(%obj);
			%name = getObjectType(%obj);
			%name = object::getname(%obj);
			ADDTODB(%obj);
			client::sendmessage(%clientId, 1, "List :"@%i+1 @"-"@%numitems@" "@%name@" Project:"@%obj.project);
		}
		return processMenummisc(%clientId, "building");
	}
	if(%o == "AbortProject")
	{
		Client::buildMenu(%clientId, "Delete Project?", "mmisc", true);
		Client::addMenuItem(%clientId, %i++ @ "Yes", "AbortYes");
		Client::addMenuItem(%clientId, %i++ @ "No", "AbortNo");
		return;
	}
	if(%o == "AbortYes")
	{
		%numItems = Group::objectCount($BuildGroup);
		%z=0;
		for(%i = 0 ; %i<%numItems ; %i++)
		{
			%obj = Group::getObject($BuildGroup, %i-%z);
			//both(%obj.project@"  "@%clientId.projectname);
			if(%obj.project == %clientId.projectname)
			{
				%z++;
				deleteobject(%obj);
			}
		}
		%clientId.workingproject = "";
		%clientId.projectname = "";
		return processMenummisc(%clientId, "building");
	}
	if(%o == "AbortNo")
	{
		//%numItems = Group::objectCount($BuildGroup);
		//for(%i = 0 ; %i<%numItems ; %i++)
		//{
		//	%obj = Group::getObject($BuildGroup, %i);
		//	if(%obj.project == %clientId.projectname)
		//	{
		//		%obj.project = "";
		//	}
		//}
		%clientId.workingproject = "";
		%clientId.projectname = "";
		return processMenummisc(%clientId, "building");
	}
	if(%o == "LoadProject")
	{
		if(%clientId.workingproject || %clientId.projectnaming)
		return client::sendmessage(%clientId, 0, "Please end your current project first.");

		client::sendmessage(%clientId, 0, "Please type the name for your project.");
		%clientId.projectloading = true;
	}
	if(%o == "StartProject")
	{
		if(%clientId.workingproject || %clientId.projectnaming)
		return client::sendmessage(%clientId, 0, "Please end your current project first.");

		client::sendmessage(%clientId, 0, "Please type a name for your project.");
		%clientId.projectnaming = true;
		return;
	}
	if(%o == "SetSAD")
	{
		client::sendmessage(%clientId, 0, "Please type the new admin password. Current admin password: "@$Adminpassword);
		%clientId.SetSAD = true;
		return;
	}
	if(%o == "LoadDMProject")
	{
		//client::sendmessage(%clientId, 0, "Please type a name of the DM you want to load.");
		DeathMatch::changeMissionMenu(%clientId);
		%clientId.DMLoading = true;
		return;
	}
	if(%o == "SaveProject")
	{
		%numItems = Group::objectCount($BuildGroup);
		%y=-1;
		deletevariables("$project*");
		for(%i = 0 ; %i<%numItems ; %i++)
		{
			%obj = Group::getObject($BuildGroup, %i);
			if(%obj.project == %clientId.projectname)
			{
				%name = object::getname(%obj);
				both("Name.. "@%name);
				%type = getObjectType(%obj);
				%pos = gamebase::getposition(%obj);
				//%pos = MyRound(getword(%pos, 0))@" "@MyRound(getword(%pos, 1))@" "@MyRound(getword(%pos, 2));
				%rot = gamebase::getrotation(%obj);
				//%rot = getword(%rot, 0)@" "@getword(%rot, 1)@" "@getword(%rot, 2);
				$project[%y+=1] = %type@" "@%name@" "@%pos@" "@%rot@" "@GameBase::getMapName(%obj);
				//addtodb(%obj);
			}

		}
		export("$project*", "temp\\" @ %clientId.projectname @ ".cs", false);
		client::sendmessage(%clientId, 0, "Successfully saved."@$beep);
		return processMenummisc(%clientId, "building");
	}
	if(%o == "dbuildings")
	{
		%numItems = Group::objectCount($BuildGroup);
		%z=0;
		for(%i = 0 ; %i<%numItems ; %i++)
		{
			%obj = Group::getObject($BuildGroup, %i-%z);
			if(%obj.project == "")
			{
				%z++;
				deleteobject(%obj);
			}
		}
		return processMenummisc(%clientId, "building");
	}
	if(%o == "toggleArmor")
	{
		if(%clientId.isSuperAdmin)
		{
			if($ArmorToggle)
			{
				messageAll(1, Client::getName(%clientId) @ " disabled armor change.");
				$ArmorToggle = false;
			}
			else
			{
				messageAll(1, Client::getName(%clientId) @ " enabled armor change.");
				messageAll(0, "You can now choose your armor from the tab menu");
				$ArmorToggle = true;
			}
			%option = "AdminStuff";
			processMenummisc(%clientId, %option);
		}
		return;
	}
	if(%o == "toggledbuse")
	{
		if(%clientId.prefs["allowabuse"])
		{
			%clientId.prefs["allowabuse"]=false;
		}
		else
		{
			%clientId.prefs["allowabuse"]=true;
		}
		processMenummisc(%clientId, "prefs");

	}
	if(%o == "toggleViewScoreDebug")
	{
		%clientId.prefs["ViewScoreDebug"] = !%clientId.prefs["ViewScoreDebug"];
		processMenummisc(%clientId, "prefs");
	}
	if(%o == "toggleautoWaypoint")
	{
		if(%clientId.prefs["autoWaypoint"])
		{
			%clientId.prefs["autoWaypoint"]=false;
		}
		else
		{
			%clientId.prefs["autoWaypoint"]=true;
		}
		processMenummisc(%clientId, "prefs");
	}

		//edited in ^
	if(%o == "obsm") {
		if(%clientId.prefs["obsmode"] == "") %clientId.prefs["obsmode"] = "Free";
		Client::buildMenu(%clientId, "Current mode: " @ %clientId.prefs["obsmode"], "mmisc", true);
		if(%clientId.prefs["obsmode"] != "Free")	{	Client::addMenuItem(%clientId, "1Free", "setmode Free"); }
		if(%clientId.prefs["obsmode"] != "Fixed")	{	Client::addMenuItem(%clientId, "2Fixed", "setmode Fixed"); }
		if(%clientId.prefs["obsmode"] != "1stPerson")	{	Client::addMenuItem(%clientId, "31st Person", "setmode 1stPerson"); }
		//Client::addMenuItem(%clientId, "4Only Obs TD: "@%clientId.prefs["obsTDonly"], "obsTDtoggled");
		return;
	} else if(%o == "setmode") {
		if(%clientId.prefs["obsmode"] == %extra)
			Client::sendMessage(%clientId, 0,"Your Observer Mode is already set to " @ %extra @ ".");
		else {
			%clientId.prefs["obsmode"] = %extra;
			if(%clientId.observerMode == "observerOrbit") setObsOrbit(%clientId, %clientId.observerTarget, 5, 5, 5);
			Client::sendMessage(%clientId, 0,"Your Observer Mode has been set to " @ %extra @ ".");
		}
		processMenummisc(%clientId, "prefs");
		return;
	} else if(%o == "toggled") {
		if (%clientId.prefs["DuelModeOff"]) {
			client::sendmessage(%clientId,0,"You have turned on duels.");
			%clientId.prefs["DuelModeOff"] = false;
			Game::refreshClientScore(%clientId);
		} else {
			client::sendmessage(%clientId,0,"You have turned off duels.");
			%clientId.prefs["DuelModeOff"] = true;
			Game::refreshClientScore(%clientId);
		}
		if(%clientId.Team != "")
		{
			//%opt = "prefs";
			processMenummisc(%clientId, "prefs");
			return;
		}
		%opt = "misc";
		processMenuOptions(%clientId, %opt);
		return;
	} else if(%o == "toggledt") {
		$DuelAlive[%clientId] = false;
		if ($DuelTModeOff[%clientId]) {
			if($DuelStart) {
				centerprint(%clientId, "<jc><f1>You have enabled Duel Tournament Mode.\n\n<f2>A tournament is currently in progress, please wait and you will join in when it is complete.", 20);
				Client::sendMessage(%clientId,0,"You have enabled Duel Tournament Mode. A tournament is currently in progress, please wait and you will join in when it is complete.");
			} else {
				Client::sendMessage(%clientId,0,"You have enabled Duel Tournament Mode.");
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f1>Choose your weapons from the TAB menu.\n\n<f2>PRESS FIRE WHEN READY!", 0);
				$DuelAlive[%clientId] = true;
				%clientId.notready = true;
			}
			$DuelTModeOff[%clientId] = false;
		} else {
			if($DuelStart) {
				centerprint(%clientId, "<jc><f2>You have been removed from the current tournament!\n\n<f1>You have disabled Duel Tournament Mode. You will not be entered in any tournaments.", 20);
				messageall(1, Client::getName(%clientId) @ " has chosen to be removed from the tournament!~waccess_denied.wav");
			} else
				centerprint(%clientId, "<jc><f1>You have disabled Duel Tournament Mode. You will not be entered in any tournaments.", 20);
			client::sendmessage(%clientId,0,"You have disabled Duel Tournament Mode. You will not be entered in any tournaments.~waccess_denied.wav");
			$DuelTModeOff[%clientId] = true;
			CheckPartners();
		}
	}
		else if(%o == "toggleprojcam")
		{
			if(%clientId.prefs["SuperCam"])
			{
				%clientId.prefs["SuperCam"] = "";
				client::sendmessage(%clientId,0,"You have turned projectile camera off.");

			}
			else {

				%clientId.prefs["SuperCam"] = 1;
				client::sendmessage(%clientId,0,"You have turned projectile camera on.");
			}
			processMenummisc(%clientId, "prefs");
		}
       if(%o == "setSpeed")
       {
			$SpeedDuel[%clientId] = %extra;

			if($SpeedDuel[%clientId] == "True")
			{
			   Client::sendMessage(%clientId, 0,"You enabled faster dueling. If your partner doesn't switch modes you will auto request at the end of duels.");
			  // Client::sendMessage(%clientId, 1,"Warning: You won't have time to scratch your balls.");
			   if($SpeedDuel[$DuelLastEnemy[%clientId]] != "True")
			   {
			  	 	client::sendmessage($DuelLastEnemy[%clientId], 0, client::getname(%clientId) @" has set his autorequest to Fast mode. Vote Yes within 5 seconds to set yours the same.");
			   		$DuelLastEnemy[%clientId].followsuit = %o@" "@%extra ;
			   		schedule("resetSuit($DuelLastEnemy["@%clientId@"]);", 5);
				}
			}
			if($SpeedDuel[%clientId] == "False")
			{
			   Client::sendMessage(%clientId, 0,"You disabled faster dueling.");
			}
			if($SpeedDuel[%clientId] == "EndOfD")
			{
			   Client::sendMessage(%clientId, 0,"You will now auto request last duel after the duel has finalized.");
			   if($SpeedDuel[$DuelLastEnemy[%clientId]] != "EndOfD")
			   {
			  	 	client::sendmessage($DuelLastEnemy[%clientId], 0, client::getname(%clientId) @" has set his autorequest to Normal mode. Vote Yes within 5 seconds to set yours the same.");
			   		$DuelLastEnemy[%clientId].followsuit = %o@" "@%extra ;
				}
			}
		if(!$dueling[%clientId])
		{
			%opt = "misc";
			processMenuOptions(%clientId, %opt);
		}
		return;
		}
       if(%o == "obsTDtoggled")
       {
		   if(%clientId.prefs["obsTDonly"])
		   {
			   %clientId.prefs["obsTDonly"] = false;
			 //  echo(%clientId.prefs["obsTDonly"]);
		   }
		   else {
			   %clientId.prefs["obsTDonly"] = true;
			  // echo(%clientId.prefs["obsTDonly"]);
		   }
		//   echo(%clientId.prefs["obsTDonly"]);
		if(%clientId.Team == "")
		{
			client::sendmessage(%clientId, 1, "This option only affects you if you're on a team.");
		}
		   %opt = "prefs";
		   processmenummisc(%clientId, %opt);
	   }
	  // echo(%o);
       if(%o == "obsoptspage")
       {
		   Client::buildMenu(%clientId, "Observer Prefs", "mmisc", true);
		   %p=0;
		   Client::addMenuItem(%clientId, %p++ @ "Observer Mode", "obsm");

			if(%clientId.prefs["SuperCam"])
				Client::addMenuItem(%clientId, %p++ @ "Disable Projectile Camera", "toggleprojcam");
			else
				Client::addMenuItem(%clientId, %p++ @ "Enable Projectile Camera", "toggleprojcam");

			Client::addMenuItem(%clientId, %p++ @ "Observe TD Only: "@%clientId.prefs["obsTDonly"], "obsTDtoggled");

	   }
       if(%o == "prefs")
       {
		   %p = 0;
		   Client::buildMenu(%clientId, "Preferences", "mmisc", true);
		   Client::addMenuItem(%clientId, %p++ @ "Observer Options", "obsoptspage");

		   //if(%clientId.Team == "")
		  // {
				if(%clientId.prefs["DuelModeOff"])
					Client::addMenuItem(%clientId, %p++ @ "Enable Duels", "toggled");
				else
					Client::addMenuItem(%clientId, %p++ @ "Disable Duels", "toggled");


		 //  }
		 //  if(%clientId.Team != "")
		 //  {
			   //Client::addMenuItem(%clientId, %p++ @ "Disable Duels", "toggled");
			   if($Winners::On[%clientId] == "")
			   {
			  	 Client::addMenuItem(%clientId, %p++ @ "Auto Request Last Duel", toggleSpeed);
			 }


		//   }

			if(%clientId.prefs["VoteGraphic"])
			{
				Client::addMenuItem(%clientId, %p++ @ "Disable Vote Meter", togglevgraph);
			}
			else {
				Client::addMenuItem(%clientId, %p++ @ "Enable Vote Meter", togglevgraph);
			}

			if(%clientId.prefs["allowabuse"])
			{
				Client::addMenuItem(%clientId, %p++ @ "Disable Admin Intervention", toggledbuse);
			}
			else {
				Client::addMenuItem(%clientId, %p++ @ "Enable Admin Intervention", toggledbuse);
			}

			if(%clientId.prefs["autoWaypoint"])
			{
				Client::addMenuItem(%clientId, %p++ @ "Disable Auto Waypoint", toggleautoWaypoint);
			}
			else {
				Client::addMenuItem(%clientId, %p++ @ "Enable Auto Waypoint", toggleautoWaypoint);
			}

			if(%clientId.prefs["ViewScoreDebug"])
			{
				Client::addMenuItem(%clientId, %p++ @ "Disable Score Debug Messages", toggleViewScoreDebug);
			}
			else {
				Client::addMenuItem(%clientId, %p++ @ "Enable Score Debug Messages", toggleViewScoreDebug);
			}

		if(%clientId.isSuperAdmin)
		{
			Client::addMenuItem(%clientId, %p++ @ "Admin Stuff", AdminStuff);
		}
		//Client::addMenuItem(%clientId, %p++ @ "Amin Intervention: "@%clientId.prefs["allowabuse"], "toggledbuse");
		if(%clientId.isSuperAdmin || %clientId.CanLoad)
		{
			//Client::addMenuItem(%clientId, %p++ @ "Saved Stats Setup", "SSS");
		}
		if (!$Dueling[%clientId] && $TeamDuel::Master)
		{
			Client::addMenuItem(%clientId, %p++ @ "Team Duel Setup", teamduelsetup);
		}
	}
	//T
	// E
	//  A
	//   M
	//    D
	//     U
	//      E
	//       L
	if(%clientId.DM)
	{
		//Game::menuRequest(%clientId, 2);
		//return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "teamduelsetup")
	{
		if(%clientId.selClient != "")
		{
			Game::menuRequest(%clientId, 2);
			return;
		}
		Client::buildMenu(%clientId, "Team Duel Setup", "mmisc", true);
		%p = 0;
		if(%clientId.Team != "")
		{
			if(%clientId.observertarget.team == %clientId.team && !%clientId.IsAlive)
			{
				%pl = Client::getOwnedObject(%clientId.observertarget);
				%newcode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl) ;
				if(%newcode == %pl.StartCode)
				{
					Client::addMenuItem(%clientId,  %p @"*Possess "@client::getname(%clientId.observertarget), "possess "@%clientId.observertarget);
				}
			}
			if($TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId))
			{
				%chlng = CheckChallenges(%clientId.Team);
				Client::addMenuItem(%clientId, x @ "*Leader Options", "leaderoptions");
				if(CheckJoiners(%clientId.Team) > 0)
				{
					Client::addMenuItem(%clientId, %p++ @ "*Join Requests: " @ CheckJoiners(%clientId.Team), "SeeJoiners");
				}
				if(CheckTradeStatus(%clientId.Team, 1))
				{
					Client::addMenuItem(%clientId, %p++ @ "***Trade Request***", "checktraderequests");
				}
				if($TeamDuel::InMatch[%clientId.Team] == "" && TeamDuel::TeamsNotInMatch() > 1 && $TeamDuel::Abort[%clientId.Team] == false)
				{
					Client::addMenuItem(%clientId, %p++ @ "*Challenge a team", "challengeteam");
				}
				if($TeamDuel::InMatch[%clientId.Team] == "" && $MultiTeamDuel::Teams != "")
				{
					Client::addMenuItem(%clientId, %p++ @ "Join Multi-TD", "checkchallengedetails 0");
				}
				if(%chlng > 0 && $TeamDuel::InMatch[%clientId.Team] == "" && $TeamDuel::Abort[%clientId.Team] == false ||%chlng > 0 && Authorization(%clientId) && $TeamDuel::InMatch[%clientId.Team] == "" && $TeamDuel::Abort[%clientId.Team] == "false")
				{
					Client::addMenuItem(%clientId, %p++ @ "*Challenge Requests: " @ CheckChallenges(%clientId.Team), "seechallengers");
				}
				Client::addMenuItem(%clientId, %p++ @ "*Invite Player", "seeInvitees");
			}
				Client::addMenuItem(%clientId, %p++ @ "Change Teams", "changeteam");
		}






		if(%clientId.Team == "")
		{
			Client::addMenuItem(%clientId, %p++ @ "Create a team", "createteam");
			if(%clientId.hasInvite && %clientId.Team == "")
			{
				Client::addMenuItem(%clientId, %p++ @ "**Accept Invite Into TeamDuel**", "checkinvites");
			}
		}
		if(%clientId.Team != "")
		{
			Client::addMenuItem(%clientId, %p++ @ "Prefs", "prefs");

			Client::addMenuItem(%clientId, %p++ @ "Loadout Setup", "loadoutsetup");
		}
		if(Authorization(%clientId) && $TeamDuel::TotalTeams > 0)
		{
			Client::addMenuItem(%clientId, %p++ @ "Team Control", "teamcontrol");
		}
		if($TeamDuel::TotalTeams > 0)
		{
			Client::addMenuItem(%clientId, %p++ @ "View Teams", "NEWjointeam");
		}
		if(%clientId.Team != "" && %clientId.selClient == "")
		{
			//if($TeamDuel::Leader[%ClientId.Team] == %clientId)
			//{
				Client::addMenuItem(%clientId, %p++ @ "Default Menu", "defaultmenu");
		//	}
			schedule("Blah("@%clientId@");", 0.1);
		}

		  if(%clientId.dm != "true" && !$Dueling[%clientId] && %clientId.IsAlive == "" && $DeathMatch::Master)
		  {
			  Client::addMenuItem(%clientId, %p++ @ "Join Deathmatch", "JoinDM");
		  }
		  if(%clientId.dm && $DeathMatch::Master)
		  {
			  if($Game::missionType == "Uber")
			  {
				  Client::addMenuItem(%clientId, %p++ @ "Go Uber!", "GoUber!");
			  }
			  if($Game::missionType == "BooT CamP")
			  {
					Client::addMenuItem(%clientId, %p++ @ "Go BooT CamP!", "GoBooTCamP");
			  }
			  Client::addMenuItem(%clientId, %p++ @ "Leave Death Match", "LeaveDM");
		  }
		if($curVoteTopic == "") {
			if(%clientId.DM)
			{
				Client::addMenuItem(%clientId, %p++ @ "DM Voting", "vcarena");
			}
			else {
				if(%clientId.Team != "" && !%clientId.isAdmin)
				{
					Client::addMenuItem(%clientId, %p++ @ "Vote to change mission", "vcmission");
				}
			}
		}
		return;
	}
   if(%o == "vcmission" || %o == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %o == "cmission");
      return;
   }
   if(%o == "vcarena")
   {
	   if(%clientId.DM)
	   {
      		//DeathMatch::changeMissionMenu(%clientId);
      		processMenuDMMenu(%clientId, "base");
		}
      return;
   }
	if(%o == "JoinDM" || %o == "LeaveDM")
	{
		processMenuDMenu(%clientId, %o);
		return;
	}
	if(%o == "teamcontrol" && Authorization(%clientId))
	{
		Client::buildMenu(%clientId, "Select Team", "mmisc", true);
		%p = -1;
		%cnt = 0;
		for(%x = 0; %x < 10; %x++)
		{
			if($TeamDuel::Name[%x] != "")
			{
				%cnt++;
				Client::addMenuItem(%clientId, %p++ @ $TeamDuel::Name[%x], "teamcontrolmenu "@%x);
			}
		}
		if(%clientId.Team != "")
		{
			%cnt--;
		}
		if(%cnt < 2)
		{
			for(%x = 0; %x < 10; %x++)
			{
				if($TeamDuel::Name[%x] != "" && %clientId.Team != %x)
				{
					%option = "teamcontrolmenu "@%x ;
					processMenummisc(%clientId, %option);
					return;
				}
			}
		}
		return;
	}
	if(%o == "readyup" && Authorization(%clientId))
	{
		if(%extra != "" && %extra != "-1" && %extra != "FALSE")
		{
			$TeamDuel::Leader[%extra].notready = "";
			%message = client::getname($TeamDuel::Leader[%extra]) @ " is READY!";
			TMessage($TeamDuel::Challenging[%extra], %extra, $Green, %message);
		}
		return;
	}
	if(%o == "teamcontrolmenu" && Authorization(%clientId))
	{
		Client::buildMenu(%clientId, $TeamDuel::Name[%extra]@" Control", "mmisc", true);
		%chlng = CheckChallenges(%extra);
		%p = 0;
//messageall(1, "extra "@%extra);
		if(CheckJoiners(%extra) > 0)
		{
			Client::addMenuItem(%clientId, %p++ @ "*Join requests: " @ CheckJoiners(%extra), "SeeJoiners "@%extra);
		}
		//if(CheckTradeStatus(%extra, 1))
		//{
		//	Client::addMenuItem(%clientId, %p++ @ "***Trade Request***", "checktraderequests");
		//}
		//messageall(1, "Match '"@$TeamDuel::InMatch[%extra]@"' Total Teams: '"@$TeamDuel::TotalTeams@"' Abort: '"@$TeamDuel::Abort[extra]@"'");
		//if($TeamDuel::InMatch[%extra] == "" && $TeamDuel::TotalTeams > 1 && $TeamDuel::Abort[extra] == "false" || $TeamDuel::InMatch[%extra] == "" && $TeamDuel::TotalTeams > 1 && $TeamDuel::Abort[extra] == "" )
		//{
		//	messageall(1, "work");
		//	Client::addMenuItem(%clientId, %p++ @ "*Challenge a team", "challengeteam "@%extra);
		//}
		if(%chlng > 0 && $TeamDuel::InMatch[extra] == "" && $TeamDuel::Abort[extra] == false ||%chlng > 0 && Authorization(%clientId) && $TeamDuel::InMatch[%extra] == "" && $TeamDuel::Abort[%extra] == "false")
		{
			Client::addMenuItem(%clientId, %p++ @ "*Challenge requests: " @ CheckChallenges(%extra), "seechallengers "@%extra);
		}
		Client::addMenuItem(%clientId, %p++ @ "*Invite Player", "seeInvitees butter "@%extra);
		//if(GetTeamPlayerCount(%extra) > 1)
		//{
			//Client::addMenuItem(%clientId, %p++ @ "*Choose new leader", "passleader");
			//Client::addMenuItem(%clientId, %p++ @ "*Kick player off your team", "kickplayerteam");
		//}
		//if($TeamDuel::TotalTeams > 1)
		//{
			//Client::addMenuItem(%clientId, %p++ @ "*Trade a player", "tradethisforthat None None");
		//}
		if(!$TeamDuel::Leader[%extra].notready && $TeamDuel::InMatch[%clientId.Team] == "True") //!%clientId.notready
		{
			Client::addMenuItem(%clientId, %p++ @ "*Timeout", "timeout "@%extra);
		}
		else {
			if($TeamDuel::InMatch[%clientId.Team] == "True")
			{
				Client::addMenuItem(%clientId, %p++ @ "*Ready Up", "readyup "@%extra);
			}
		}
		//Client::addMenuItem(%clientId, %p++ @ "*Set Team Skin", "setteamskin "@%extra);
		if($TeamDuel::InMatch[%extra] == "True")
		{
			if($TeamDuel::Challenging[%clientId.Team] == "0")
			Client::addMenuItem(%clientId, %p++ @ "*Leave Match", "leavematch "@%extra);
			else
			Client::addMenuItem(%clientId, %p++ @ "*Abort Match", "abortmatch "@%extra);
		}
		if($TeamDuel::Locked[%extra])
		{
			Client::addMenuItem(%clientId, %p++ @ "*Team Lock: True", "locktoggle "@%extra);
		}
		else	{
			Client::addMenuItem(%clientId, %p++ @ "*Team Lock: False", "locktoggle "@%extra);
		}

		Client::addMenuItem(%clientId, x @ "*Disband team", "disbandteam "@%extra);

		Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");

		return;


	}

	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "leaderoptions" && $TeamDuel::Leader[%clientId.Team] == %clientId || Authorization(%clientId) && %o =="leaderoptions")
	{
		Client::buildMenu(%clientId, "Team Duel Setup", "mmisc", true);
		%p = 0;
		if(GetTeamPlayerCount(%clientId.Team) > 1)
		{
			Client::addMenuItem(%clientId, %p @ "*Choose new leader", "passleader");
			Client::addMenuItem(%clientId, %p++ @ "*Kick player off your team", "kickplayerteam");
		}
		if($TeamDuel::TotalTeams > 1)
		{
			Client::addMenuItem(%clientId, %p++ @ "*Trade a player", "tradethisforthat None None "@%clientId.Team@" -1 false");
		}
		if(!%clientId.notready && $TeamDuel::InMatch[%clientId.Team] == "True")
		{
			Client::addMenuItem(%clientId, %p++ @ "*Timeout", "timeout");
		}
		Client::addMenuItem(%clientId, %p++ @ "*Set Team Skin", "setteamskin");
		if($TeamDuel::InMatch[%clientId.Team] == "True")
		{
			if($TeamDuel::Challenging[%clientId.Team] == "0")
			Client::addMenuItem(%clientId, %p++ @ "*Leave Match", "leavematch");
			else
			Client::addMenuItem(%clientId, %p++ @ "*Abort Match", "abortmatch");
		}
		if($TeamDuel::Locked[%clientId.Team])
		{
			Client::addMenuItem(%clientId, %p++ @ "*Team Lock: True", "locktoggle");
		}
		else	{
			Client::addMenuItem(%clientId, %p++ @ "*Team Lock: False", "locktoggle");
		}

		Client::addMenuItem(%clientId, x @ "*Disband your team", "disbandteam");

		Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "tradethisforthat" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="tradethisforthat")
	{
		//TeamDuel::SendTradeRequest(%RequestingTeam, %RequestingTeamClient, %EnemyTeam, %EnemyTeamClient, %Requester)
		//%option = "tradethisforthat "@%EnemyTeamClient@" "@%RequestingTeamClient@" "@%EnemyTeam@" "@%RequestingTeam@" Confirm";
		//processMenummisc($TeamDuel::Leader[%EnemyTeam], %option);
		//declare this
		%teammateClient = %extra;
		%enemyClient = %extra2;
		%teammateTeam = %extra3;
		%enemyTeam = %extra4;
		if(%extra5 == -1)
			%extra5 = false;

		%Confirm = %extra5;
		//both(%confirm@" teammate team: "@%teammateTeam);


		//zoooop
		//echo(%o@" "@%extra@" "@%extra2@" "@%extra3@" "@%extra4);

		Client::buildMenu(%clientId, "Confirm. (click to change)", "mmisc", true);
		%p = 0;


		if(%teammateClient == "None")
			%teammateName = "None";
		else
			%teammateName = client::getname(%teammateClient);

		if(%enemyClient == "None")
			%enemyName = "None";
		else
			%enemyName = client::getname(%enemyClient);


		//Client::addMenuItem(%clientId, %p++ @ "Trade: " @ %teammateName, "tradeplayer "@%teammateClient@" "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@"");
		Client::addMenuItem(%clientId, %p++ @ "Trade: " @ %teammateName, "TradeTeammate "@%teammateClient@" "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@"");
		Client::addMenuItem(%clientId, %p++ @ "For: " @ %enemyName, "TradeForEnemy "@%teammateClient@" "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@"");
		//Client::addMenuItem(%clientId, %p++ @ "For: " @ %enemyName, "tradethis "@%teammateClient@" "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@"");
		if(%enemyTeam != -1 && !(%teammateClient == "None" && %enemyClient == "None") || %teammateClient != "None" && %enemyClient != "None")
		{
			//if(%extra3 != "False" && %extra3 != "-1" && %extra4 != "False" && %extra4 != "-1")
			//{
				//if($TeamDuel::Leader[%teammateT] != %teammate || $TeamDuel::Leader[%otherteamT] != %otherteam)
				//{
			if(%Confirm)
			{
				Client::addMenuItem(%clientId, %p++ @ "Confirm", "CompleteTheTrade "@%teammateClient@" "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@"");

			}
			else
			{
				Client::addMenuItem(%clientId, %p++ @ "Confirm", "SendTheTrade "@%teammateClient@" "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@"");

			}
				//}
				//echo("Menu: "@%extra@" "@%extra2@" "@%extra3@" "@%extra4);
			//}
		}
		Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");
		return;
	}

	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "CompleteTheTrade" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="dothetrade")
	{
		%teammateClient = %extra;
		%enemyClient = %extra2;
		%teammateTeam = %extra3;
		%enemyTeam = %extra4;

		TeamDuel::ProcessTradeRequest(%teammateClient, %enemyClient, %teammateTeam, %enemyTeam, %clientId);
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "SendTheTrade" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="dothetrade")
	{
		%teammateClient = %extra;
		%enemyClient = %extra2;
		%teammateTeam = %extra3;
		%enemyTeam = %extra4;

		//both("send the trade");

		TeamDuel::SendTradeRequest(%teammateClient, %enemyClient, %teammateTeam, %enemyTeam, %clientId);

		schedule("TradeCheck("@%extra@","@%extra2@","@%extra3@","@%extra4@");", 30);
		//echo("boo "@%extra3@" "@%extra4);
		//TradeRequest(%extra3, %extra4);
		return;
	}


	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "checktraderequests" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="checktraderequests")
	{
		Client::buildMenu(%clientId, "Check Offer.", "mmisc", true);
		%p = 0;
		for(%i= 0 ; %i < 19; %i++)
		{
			if($TeamDuel::Trading::OfferStatusCheck[%i, %clientId.Team])
			{
				Client::addMenuItem(%clientId, %p++ @ client::getname($TeamDuel::Leader[%i])@" - "@$TeamDuel::Name[%i], "viewdeal "@ %i);
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "viewdeal" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="viewdeal")
	{
		$TeamDuel::Trading::Offer[%RequestingTeam, %EnemyTeam] = %RequestingTeamClient@" "@%EnemyTeamClient;

		%teammateClient = gw($TeamDuel::Trading::Offer[%extra, %clientId.Team], 1);
		%enemyClient = gw($TeamDuel::Trading::Offer[%extra, %clientId.Team], 0);
		%teammateTeam = %clientId.Team;
		%enemyTeam = %extra;

		%option = "tradethisforthat "@%teammateClient@" "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@" true";
		//%option = "tradethisforthat "@%player1@" "@%player2@" "@%player1T@" "@%player2T@"";
		processMenummisc(%clientId, %option);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "TradeTeammate" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="tradeplayer")
	{
		//declare this
		%teammateClient = %extra;
		%enemyClient = %extra2;
		%teammateTeam = %extra3;
		%enemyTeam = %extra4;
		//zoooop
		//echo(%o@" "@%extra@" "@%extra2@" "@%extra3@" "@%extra4);
		Client::buildMenu(%clientId, "Choose a player from your team.", "mmisc", true);
		%p = 0;
		Client::addMenuItem(%clientId, %p @ "None", "tradethisforthat None "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@"");

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.Team == %clientId.Team)
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ Client::GetName(%cl), "tradethisforthat "@%cl@" "@%enemyClient@" "@%teammateTeam@" "@%enemyTeam@"");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "TradeForEnemy" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="tradethis")
	{
		//declare this
		%teammateClient = %extra;
		%enemyClient = %extra2;
		%teammateTeam = %extra3;
		%enemyTeam = %extra4;

		//zoooop
		//echo(%o@" "@%extra@" "@%extra2@" "@%extra3@" "@%extra4);
		//echo(%o@","@%extra@","@client::getname(%extra)@","@%extra);
		Client::buildMenu(%clientId, "Choose a team to request from", "mmisc", true);
		%p = 0;
		for(%i= 1 ; %i < 19; %i++)
		{
			if($TeamDuel::Name[%i] != "" && %i != %clientId.Team)
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ $TeamDuel::Name[%i] @ " (" @ GetTeamPlayerCount(%i) @ ")", "listtradeteam "@ %teammateClient @" "@ %enemyClient @" "@ %teammateTeam @" "@ %enemyTeam @" "@ %i @"");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "listtradeteam" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="listtradeteam")
	{
		//declare this
		%teammateClient = %extra;
		%enemyClient = %extra2;
		%teammateTeam = %extra3;
		%enemyTeam = %extra4;

		//zoooop
		%TeamSelected = %extra5;
		//echo(%o@" "@%extra@" "@%extra2@" "@%extra3@" "@%extra4);

		%string = "None";
		if(%teammateClient != "None")
		{
			%string = client::getname(%tradethis);
		}
		Client::buildMenu(%clientId, "Trade "@%string@" for:", "mmisc", true);
		%p = 0;
		Client::addMenuItem(%clientId, %p++ @ "None", "tradethisforthat "@%teammateClient@" None "@%teammateTeam@" "@%TeamSelected@"");
		//Client::addMenuItem(%clientId, %p++ @ "*" @ client::getname($TeamDuel::Leader[%TeamHighlighted]), "tradethisforthat "@%teammate@" "@$TeamDuel::Leader[%TeamHighlighted]@" "@%clientId.Team@" "@%TeamHighlighted@"");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.Team == %TeamSelected)
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ Client::GetName(%cl), "tradethisforthat "@%teammateClient@" "@%cl@" "@%teammateTeam@" "@%cl.Team@"");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "setteamskin" && %clientId == $TeamDuel::Leader[%clientId.Team]  || Authorization(%clientId) && %o =="setteamskin")
	{
		if(%extra == "" || %extra == "-1")
		{
			%extra = %clientId.Team;
		}
		%string = $TeamDuel::Skin[%extra];
		if($TeamDuel::Skin[%extra] == "")
		{
			%string = "None";
		}
		%p = 0;
		Client::buildMenu(%clientId, "Current Skin: ("@%string@")", "mmisc", true);
		Client::addMenuItem(%clientId, %p @ "None", "setteamskin2 None None");
		Client::addMenuItem(%clientId, %p++ @ "Base", "setteamskin2 base Base");
		Client::addMenuItem(%clientId, %p++ @ "Blood Eagle", "setteamskin2 beagle Blood Eagle");
		Client::addMenuItem(%clientId, %p++ @ "Children of the Phoenix", "setteamskin2 cphoenix Children of the Phoenix");
		Client::addMenuItem(%clientId, %p++ @ "Diamond Sword", "setteamskin2 dsword Diamond Sword");
		Client::addMenuItem(%clientId, %p++ @ "Green", "setteamskin2 green Green");
		Client::addMenuItem(%clientId, %p++ @ "Orange", "setteamskin2 orange Orange");
		Client::addMenuItem(%clientId, %p++ @ "Purple", "setteamskin2 purple Purple");
		Client::addMenuItem(%clientId, %p++ @ "Starwolf", "setteamskin2 swolf Starwolf");
		Client::addMenuItem(%clientId, %p++ @ "Blue", "setteamskin2 blue Blue");
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "setteamskin2" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="setteamskin2")
	{
		//echo(%o@" "@%extra@" "@%extra2@" "@%extra3@" "@%extra4@" "@%extra5);
		if(%extra6 == "-1")
		{
			%extra6 = %clientId.Team;
		}
		if(%extra == "None")
		{
			$TeamDuel::Skin[%extra6] = "";
		}
		else
		{
			$TeamDuel::Skin[%extra6] = %extra;
		}
		if(%extra3 == "-1")
		{
			%extra3 = "";
		}
		if(%extra4 == "-1")
		{
			%extra4 = "";
		}
		if(%extra5 == "-1")
		{
			%extra5 = "";
		}


		%name = %extra2@" "@%extra3@" "@%extra4@" "@%extra5 ;

		%option = "leaderoptions";
		processMenummisc(%clientId, %option);
		%message = client::getname(%clientId)@" set the team skin to <F1>"@%name ;
		PrintTeam(%extra6,  %message, top);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			if(%cl.team == %clientId.team)
			{

			}
	}
		return;
	}














	//tohere
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "leavematchaffirm")
	{
		if(%extra == "-1")
		{
			%extra = %clientId.Team;
		}
		if(%clientId == $TeamDuel::Leader[%extra] && $TeamDuel::InMatch[%extra] == "True" || Authorization(%clientId) && $TeamDuel::InMatch[%extra] == "True" )
		{
			%message = client::getname(%clientId) @" has left the Multi-TD match.";
			TMessage(666, 666,  $Red, %message, 1);
			$TeamDuel::Abort[%extra] = true;
			Multiteam::RemoveTeam(%extra);

		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "leavematch" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="abortmatch")
	{
		Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
		Client::addMenuItem(%clientId, X @ "Leave Match", "leavematchaffirm "@%extra);
		Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "abortmatch" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="abortmatch")
	{
		Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
		Client::addMenuItem(%clientId, X @ "Abort Match?", "abortmatchaffirm "@%extra);
		Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "abortmatchaffirm")
	{
		if(%extra == "-1")
		{
			%extra = %clientId.Team;
		}
		if(%clientId == $TeamDuel::Leader[%extra] && $TeamDuel::InMatch[%extra] == "True" || Authorization(%clientId) && $TeamDuel::InMatch[%extra] == "True" )
		{
			%message = client::getname(%clientId) @" has aborted the match between "@$TeamDuel::Name[%extra]@" and "@$TeamDuel::Name[$TeamDuel::Challenging[%extra]] @".";
			TMessage(666, 666,  $Red, %message, 1);
			$TeamDuel::Abort[%extra] = true;
			$TeamDuel::Abort[$TeamDuel::Challenging[%extra]] = true;
			SecondaryClear(%extra, $TeamDuel::Challenging[%extra] , 1);
		}
		return;
	}

	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "timeout" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="timeout")
	{
		if(%extra > 0)
		{
			%clientId = $TeamDuel::Leader[%extra];
			//messageall(1, "what what "@%clientID@" "@%extra);
		}
		$TeamDuel::Leader[%clientId.Team].notready = true;
		%msg = client::getname(%clientId)@" used a timeout. Match will be suspended on next countdown.~wmine_act.wav" ;
		TMessage(%clientId.Team, $TeamDuel::Challenging[%clientId.Team], $Red, %msg);
		%option = "leaderoptions";
		processMenummisc(%clientId, %option);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "locktoggle" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="locktoggle")
	{
		if(%extra == "-1")
		{
			%extra = %clientId.Team;
		}
		else {
			%flag = true;
		}
		if($TeamDuel::Locked[%extra])
		{
			$TeamDuel::Locked[%extra] = "";
			%message = client::getname(%clientId) @" has unlocked the "@$TeamDuel::Name[%extra]@" team. You can now join without an invite.";
			TMessage(666, 666,  $Red, %message, 1);
		}
		else {
			$TeamDuel::Locked[%extra] = true;
			%message = client::getname(%clientId) @" has locked the "@$TeamDuel::Name[%extra]@" team. You will now need an invite to join.";
			TMessage(666, 666,  $Red, %message, 1);
		}

		%option = "leaderoptions";
		if(%flag)
		{
			%option = "teamcontrolmenu "@%extra;
		}
		processMenummisc(%clientId, %option);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "readytoggle")
	{
		if(%clientId.notready)
		{
			%clientId.notready = "";
			client::sendmessage(%clientId, $Green, "Ready status changed to: Ready");
		}
		else
		{
			%clientId.notready = true;
			client::sendmessage(%clientId, $Green, "Ready status changed to: Not Ready");
		}
			%option = "leaderoptions";
			processMenummisc(%clientId, %option);
			return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "loadoutsetup")
	{
		Client::buildMenu(%clientId, "Team Duel Setup", "mmisc", true);
		%p = 0;
       Client::addMenuItem(%clientId, %p++ @ "Weapons Setup", "weaponsetup");
       Client::addMenuItem(%clientId, %p++ @ "Pack Setup", "packsetup");
	   if($ArmorToggle)
	   {
			   Client::addMenuItem(%clientId, %p++ @ "Armor Setup", "armorsetup");
	   }
	   Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");
       return;
   }
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "defaultmenu")
	{
		Game::menuRequest(%clientId, 2);
		return;
	}
    if (!$Dueling[%clientId] && $TeamDuel::Master && %o == "weaponsetup")
    {
		$DuelWeaponSetup[%clientId, 0] = 0;
		$DuelWeaponSetup[%clientId, 1] = 0;
		$DuelWeaponSetup[%clientId, 2] = 0;
		WeaponSetup(%clientId, 0, 0);
		return;
	}
	if (!$Dueling[%clientId] && $TeamDuel::Master && %o == "packsetup")
	{
		PackSetup(%clientId);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "seechallengers" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="seechallengers")
	{
		%p = 0;
		if(%extra == "-1")
		{
			%extra = %clientId.Team;
		}
		else {
			%flag = true;
		}
			Client::buildMenu(%clientId, "Teams challenging "@$TeamDuel::Name[%extra], "mmisc", true);
		for(%i= 1 ; %i < 9; %i++)
		{
			if($TeamDuel::Challenging[%i] == %extra)
			{
				if(%flag)
				{
					Client::addMenuItem(%clientId, %p++ @ "Accept: " @ $TeamDuel::Name[%i], "acceptit "@ %i @" "@%extra@"");
				}
				else {
					Client::addMenuItem(%clientId, %p++ @ "Check details: " @ $TeamDuel::Name[%i], "checkchallengedetails "@ %i @"");
				}
			}
		}
		Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");
		return;
	}
	if(%o == "acceptit" && Authorization(%clientId))
	{
		$TeamDuel::Time[%extra2] = $TeamDuel::Time[%extra];
		$TeamDuel::Rounds[%extra2] = $TeamDuel::Rounds[%extra];
		$TeamDuel::Weapons[%extra2] = $TeamDuel::Weapons[%extra];
		if($TeamDuel::Weapons[%extra] == "Custom")
		{
			$TeamDuel::Weapons[%extra2] = "Custom";
			$TeamDuel::CustomWeapons[%extra2, 0] = $TeamDuel::CustomWeapons[%extra, 0];
			$TeamDuel::CustomWeapons[%extra2, 1] = $TeamDuel::CustomWeapons[%extra, 1];
			$TeamDuel::CustomWeapons[%extra2, 2] = $TeamDuel::CustomWeapons[%extra, 2];
		}
		$TeamDuel::Packs[%extra2] = $TeamDuel::Packs[%extra];
		$TeamDuel::Arena[%extra2] = $TeamDuel::Arena[%extra];
		$TeamDuel::Mines[%extra2] = $TeamDuel::Mines[%extra];
		$TeamDuel::Armor[%extra2] = $TeamDuel::Armor[%extra];
		$TeamDuel::ArenaSpawn[%extra2] = $TeamDuel::ArenaSpawn[%extra];
		$TeamDuel::NewSpawns[%extra2] = $TeamDuel::NewSpawns[%extra];
		$TeamDuel::RealTeam[%extra2] = 0;
		$TeamDuel::RealTeam[%extra] = 1;
		MatchSetup(%extra2, %extra);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "checkchallengedetails" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="checkchallengedetails")
	{
		$TeamDuel::Time[%clientId.Team] = $TeamDuel::Time[%extra];
		$TeamDuel::Rounds[%clientId.Team] = $TeamDuel::Rounds[%extra];
		$TeamDuel::Weapons[%clientId.Team] = $TeamDuel::Weapons[%extra];
		if($TeamDuel::Weapons[%extra] == "Custom")
		{
			$TeamDuel::Weapons[%clientId.Team] = "Custom";
			$TeamDuel::CustomWeapons[%clientId.Team, 0] = $TeamDuel::CustomWeapons[%extra, 0];
			$TeamDuel::CustomWeapons[%clientId.Team, 1] = $TeamDuel::CustomWeapons[%extra, 1];
			$TeamDuel::CustomWeapons[%clientId.Team, 2] = $TeamDuel::CustomWeapons[%extra, 2];
		}
		$TeamDuel::Packs[%clientId.Team] = $TeamDuel::Packs[%extra];
		$TeamDuel::Arena[%clientId.Team] = $TeamDuel::Arena[%extra];
		$TeamDuel::Mines[%clientId.Team] = $TeamDuel::Mines[%extra];
		$TeamDuel::Armor[%clientId.Team] = $TeamDuel::Armor[%extra];
		$TeamDuel::ArenaSpawn[%clientId.Team] = $TeamDuel::ArenaSpawn[%extra];
		$TeamDuel::NewSpawns[%clientId.Team] = $TeamDuel::NewSpawns[%extra];
		$TeamDuel::Multi[%clientId.Team] = $TeamDuel::Multi[%extra];
		//$TeamDuel::Challenging[%extra]
		//both($TeamDuel::Rounds[%extra]@" rounds, extra "@%extra);
		Client::buildMenu(%clientId, "Challenge Details: click to modify", "mmisc", true);
		%p = 0;
		if($TeamDuel::Time[%extra] != "Disabled")
		{
			//Client::addMenuItem(%clientId, %p++ @ "Time: " @ $TeamDuel::Time[%extra] @ " Minutes", "timedetails "@ %extra @"");
		}
		if($TeamDuel::Time[%extra] == "Disabled")
		{
			//Client::addMenuItem(%clientId, %p++ @ "Time: " @ $TeamDuel::Time[%extra], "timedetails "@ %extra @"");
		}
		Client::addMenuItem(%clientId, %p++ @ "Rounds: " @ $TeamDuel::Rounds[%extra], "roundsdetails "@ %extra @"");
		if($TeamDuel::Weapons[%extra] == "Player's Choice")
		{
			Client::addMenuItem(%clientId, %p++ @ "Weapons: Player's Choice", "weaponsdetails "@ %extra @"");
		}
		if($TeamDuel::Weapons[%extra] == "Custom")
		{
			Client::addMenuItem(%clientId, %p++ @ "Weapons: Custom", "weaponsdetails "@ %extra @"");
		}
		if($TeamDuel::Weapons[%extra] == "DiscOnly")
		{
			Client::addMenuItem(%clientId, %p++ @ "Weapons: Disc Only", "weaponsdetails "@ %extra @"");
		}
		if($TeamDuel::Packs[%extra] != "Player's Choice")
		{
			Client::addMenuItem(%clientId, %p++ @ "Packs: " @ $TeamDuel::Packs[%extra], "packdetails "@ %extra @"");
		}
		if($TeamDuel::Packs[%extra] == "Player's Choice")
		{
			Client::addMenuItem(%clientId, %p++ @ "Packs: Player's Choice", "packdetails "@ %extra @"");
		}
		//uncomment
	//	if($ArmorToggle)
		//{
			//echo("armor extra: "@%extra@" - Extra2: "@%extra2);
			if($TeamDuel::Armor[%extra] != "Player's Choice")
			{
				Client::addMenuItem(%clientId, %p++ @ "Armor: "@GetArmorString($TeamDuel::Armor[%extra]), "armordetails "@ %extra@"");
			}
			else
			{
				Client::addMenuItem(%clientId, %p++ @ "Armor: Player's Choice", "armordetails "@ %extra@"");
			}
		//}
		if($TeamDuel::Arena)
		{
			Client::addMenuItem(%clientId, %p++ @ "Arena: " @ $TeamDuel::Arena[%extra], "arenadetails "@ %extra @"");
		}
		if($TeamDuel::Arena && $TeamDuel::Arena[%clientId.Team] != "None")
		{
			Client::addMenuItem(%clientId, %p++ @ "Loadout Spawn: " @ $TeamDuel::ArenaSpawn[%clientId.Team], "arenaweapons "@ %extra @"");
		}
		if($TeamDuel::Arena[%clientId.Team] == "None")
		{
			Client::addMenuItem(%clientId, %p++ @ "Random Spawns: " @ $TeamDuel::NewSpawns[%clientId.Team], "NewSpawnToggle "@ %extra @"");
		}

		//Client::addMenuItem(%clientId, %p++ @ "Mines: "@$TeamDuel::Mines[%clientId.Team], "minedetails "@ %extra @"");
		Client::addMenuItem(%clientId, %p++ @ "Multi Team: "@$TeamDuel::Multi[%clientId.Team], "multidetails "@ %extra @"");

		if(%extra == 0)
		{
			Client::addMenuItem(%clientId, %p++ @ "Join Multi-TD", "RequestAcceptedMTD "@ %extra @" "@ %clientId.Team @"");
		}
		else {
			Client::addMenuItem(%clientId, %p++ @ "Accept Request", "RequestAccepted "@ %extra @" "@ %clientId.Team @"");
		}
		Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "RequestAcceptedMTD"&& $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="RequestAcceptedMTD")
	{
		echo("REQ ACCEPTED MTD!!!");
		Multiteam::SetTeamsDefaults(%ClientId.Team);
		Multiteam::AddTeam(%ClientId.Team);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "RequestAccepted"&& $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="RequestAccepted")
	{
		$TeamDuel::Time[%extra] = $TeamDuel::Time[%clientId.Team];
		$TeamDuel::Rounds[%extra] = $TeamDuel::Rounds[%clientId.Team];
		$TeamDuel::Weapons[%extra] = $TeamDuel::Weapons[%clientId.Team];
		if($TeamDuel::Weapons[%clientId.Team] == "Custom")
		{
			$TeamDuel::Weapons[%extra] = "Custom";
			$TeamDuel::CustomWeapons[%extra, 0] = $TeamDuel::CustomWeapons[%clientId.Team, 0];
			$TeamDuel::CustomWeapons[%extra, 1] = $TeamDuel::CustomWeapons[%clientId.Team, 1];
			$TeamDuel::CustomWeapons[%extra, 2] = $TeamDuel::CustomWeapons[%clientId.Team, 2];
		}
		$TeamDuel::Packs[%extra] = $TeamDuel::Packs[%clientId.Team];
		$TeamDuel::Arena[%extra] = $TeamDuel::Arena[%clientId.Team];
		$TeamDuel::Mines[%extra] = $TeamDuel::Mines[%clientId.Team];
		$TeamDuel::Armor[%extra] = $TeamDuel::Armor[%clientId.Team];
		$TeamDuel::Multi[%extra] = $TeamDuel::Multi[%clientId.Team];
		//if($TeamDuel::ArenaStatus[$TeamDuel::Arena[%extra]] != "Free" && $TeamDuel::Arena[%extra] != "None")
		//{
//			client::sendMessage($TeamDuel::Leader[%extra], 1, $TeamDuel::Arena[%extra] @ " is currently in use, pick a diferent one.~wError_Message.wav");
//			client::sendMessage($TeamDuel::Leader[%extra2], 1, $TeamDuel::Arena[%extra] @ " is currently in use, pick a diferent one.~wError_Message.wav");
//			%option = "details " @ %extra @ "";
//			processMenummisc(%clientId, %option);
//			return;
//		}
		if($TeamDuel::Challenging[%extra] == %extra2 || $TeamDuel::Challenging[%extra2] == %extra)
		{
			$TeamDuel::RealTeam[%extra] = 0;
			$TeamDuel::RealTeam[%extra2] = 1;
			if($TeamDuel::Multi[%extra])
			{
				$MultiTeamDuel::Teams = %extra@" "@%extra2;
				Multiteam::SetDefaults(%clientId.Team);
				Multiteam::MatchSetup();
			}
			else
			{
				MatchSetup(%extra, %extra2);
			}
		}
		else
		{
			client::sendMessage(%clientId, client::getname($TeamDuel::Leader[%extra]) @ " has withdrawn his challenge.~wError_Message.wav");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "checkinvites")
	{
		Client::buildMenu(%clientId, "Click to accept invite", "mmisc", true);
		%p = 0;
		for(%i= 1 ; %i < 9; %i++)
		{
			if($TeamDuel::Name[%i] != "")
			{
				for(%j= 1 ; %j < 9; %j++)
				{
					if($TeamDuel::Inviting[%i, %j] == %clientId)
					{
						Client::addMenuItem(%clientId, %p++ @ "Team: " @ $TeamDuel::Name[%i], "acceptinvite1 "@ %i @"");
					}
				}
			}
		}
		if(%p == "0")
		{
			client::sendmessage(%clientId, 1, "Invite expired~werror_message.wav");
			%clientId.hasInvite = false;
			Game::menuRequest(%clientId);
		}
		return;
	}
	if(%o == "tdtoggles")
	{
		if(%clientId.isSuperAdmin)
		{
			Client::buildMenu(%clientId, "Options Menu", "mmisc", true);
			%p = 0;
			if($TeamDuel::Arena)
			{
				Client::addMenuItem(%clientId, %p++ @ "Team Duel Arenas are: ON", "TDARENA");
			}
			else
			{
				Client::addMenuItem(%clientId, %p++ @ "Team Duel Arenas are: OFF", "TDARENA");
			}
			if($TeamDuel::Master)
			{
				Client::addMenuItem(%clientId, %p++ @ "Team Duel Master is: ON", "TDOFF");
			}
			else
			{
				Client::addMenuItem(%clientId, %p++ @ "Team Duel Master is: OFF", "TDON");
			}
			if($Duel::Master)
			{
				Client::addMenuItem(%clientId, %p++ @ "Duel Master is: ON", "DOFF");
			}
			else
			{
				Client::addMenuItem(%clientId, %p++ @ "Duel Master is: OFF", "DON");
			}
			if($DeathMatch::Master)
			{
				Client::addMenuItem(%clientId, %p++ @ "DeathMatch Master is: ON", "DeathMatchToggle");
			}
			else
			{
				Client::addMenuItem(%clientId, %p++ @ "DeathMatch Master is: OFF", "DeathMatchToggle");
			}
			//if(Client::GetName(%clientId) == "Lestat" || Client::GetName(%clientId) == "=Argh!=" && %clientId.isSuperAdmin)
			//{
			//	Client::addMenuItem(%clientId, %p++ @ "Team Duel Reset", "TDreset");
			//}
		}
		return;
	}
	//if(%o == "TDreset")
	//{
	//	%p = 0;
	//	Client::buildMenu(%clientId, "TD Reset Menu", "mmisc", true);
	//	Client::addMenuItem(%clientId, %p++ @ "Confirm Reset", "TDreset2");
	//	return;
	//}
	if(%o == "TDreset2")
	{
		if(Authorization(%clientId))
		{
			TeamsReset();
			%option = "tdtoggles";
			processMenummisc(%clientId, %option);
		}
		return;
	}
	if(%o == "DeathMatchToggle")
	{
		if(Authorization(%clientId))
		{
			$DeathMatch::Master = !$DeathMatch::Master;
		}
		%option = "tdtoggles";
		processMenummisc(%clientId, %option);
		return;
	}
	if(%o == "TDOFF")
	{
		if(Authorization(%clientId))
		{
			$TeamDuel::Master = false;
			$TeamDuel::Arena = false;
			if(CheckTotalTeams(1))
			{
				TeamsReset();
			}
		}
		%option = "tdtoggles";
		processMenummisc(%clientId, %option);
		return;
	}
	if(%o == "TDON")
	{
		if(Authorization(%clientId))
		{
			$TeamDuel::Master = true;
		}
		%option = "tdtoggles";
		processMenummisc(%clientId, %option);
		return;
	}
	if(%o == "DOFF")
	{
	//	if(Authorization(%clientId))
		//{
			$Duel::Master = false;
		//}
		%option = "tdtoggles";
		processMenummisc(%clientId, %option);
		return;
	}
	if(%o == "DON")
	{
		//if(Authorization(%clientId))
		//{
			$Duel::Master = true;
		//}
		%option = "tdtoggles";
		processMenummisc(%clientId, %option);
		return;
	}
	if(%o == "TDARENA")
	{
		if($TeamDuel::Arena)
		{
			$TeamDuel::Arena = false;
		}
		else
		{
			$TeamDuel::Arena = true;
		}
		%option = "tdtoggles";
		processMenummisc(%clientId, %option);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "passleader" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="passleader")
	{
		Client::buildMenu(%clientId, "Choose a new leader", "mmisc", true);
		%p = 0;
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   {
			if(%cl.team == %clientId.Team && %cl != $TeamDuel::Leader[%cl.Team])
			{
				Client::addMenuItem(%clientId, %p++ @ ""@client::getname(%cl), "passthestick "@%cl@"");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "passthestick" && %clientId == $TeamDuel::Leader[%clientId.Team] || Authorization(%clientId) && %o =="passthestick")
	{
		%message = client::getname(%clientId)@" made "@client::getname(%extra)@" the leader of "@$TeamDuel::Name[%clientId.Team]@"." ;
		TMessage(666,666,$Green,%message,1);
		$TeamDuel::Leader[%clientId.Team] = %extra;
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "acceptinvite1")
	{
		%extramsg = ".";
		%clientId.Team = %extra;

	   if($Winners::On[%clientId] == "" && $Winners::On[%foeId])
	   {
		   processMenuOptions(%clientId, "disablewinners");
	   }

		%clientId.hasInvite = false;
		SetStats(%extra);
		if($TeamDuel::Ticker[%clientId.Team] == "false" && $TeamDuel::InMatch[%clientId.Team] == "True" && $TeamDuel::CanHurt[%clientId.team] == "True")
		{
			//%extramsg = " and will spawn after this round.";
		}

		%clientId.TeamJoining = "";
		%clientId.Naming = "";
		%message = Client::GetName(%clientId) @ " has joined the " @ $TeamDuel::Name[%extra] @" team"@%extramsg ;
		TMessage(666, 666,  $White, %message, 1);
		//ClearInvites(%clientId);
		Game::refreshClientScore(%clientId);

		if($TeamDuel::Ticker[%clientId.Team] && $TeamDuel::InMatch[%clientId.Team] == "True" || $TeamDuel::Ticker[%clientId.Team] == "false" && $TeamDuel::CanHurt[%clientId.Team] == "" && $TeamDuel::InMatch[%clientId.Team] == "True")
		{
			if($TeamDuel::Challenging[%extra] == "0")
			{
				return MultiTeamDuel::TickerSpawn(%clientId);
			}
			else
			{

				if($TeamDuel::Arena[%clientId.Team] == "None")
				{
					//delete($TeamDuel::Leader[%clientId.Team]);
					SpawnNoArena($TeamDuel::Leader[%clientId.Team], %clientId);
					if($TeamDuel::CanHurt[%clientId.Team] == "")
					{
						Client::setOwnedObject(%clientId, %clientId.owns);
						Client::setControlObject(%clientId, %clientId.Owns);
						GameBase::SetDamageLevel(%clientId.Owns, 0);
						%clientId.guiLock = false;
						Client::setGuiMode(%clientId, $GuiModePlay);
						%clientId.oob = false;
					}

					//SpawnNoObjects($TeamDuel::Leader[%clientId.Team]);
				}
				else
				{
					SetupTeamSpawn(%clientId.Team, %clientId);
					if($TeamDuel::CanHurt[%clientId.Team] == "")
					{
						Client::setOwnedObject(%clientId, %clientId.owns);
						Client::setControlObject(%clientId, %clientId.Owns);
						GameBase::SetDamageLevel(%clientId.Owns, 0);
						%clientId.guiLock = false;
						Client::setGuiMode(%clientId, $GuiModePlay);
						%clientId.oob = false;
					}
				}
			}
			//SetupTeamSpawn(%clientId.Team, %clientId);
			//TeamDuelSpawn(%extra, $TeamDuel::LeftOff[%extra2.Team]);
		}

		for(%i= 1 ; %i < 9; %i++)
		{
			if($TeamDuel::Inviting[%extra, %i] == %clientId)
			{
				$TeamDuel::Inviting[%extra, %i] = "";
			}
			for(%j= 1 ; %j < 9; %j++)
			{
				if($TeamDuel::Inviting[%i, %j] == %clientId)
				{
					client::sendmessage($TeamDuel::Leader[%i], Client::GetName(%clientId) @ " has accepted an invite into " @ $TeamDuel::Name[%extra]);
					$TeamDuel::Inviting[%i, %j] = "";
				}
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "seeInvitees" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="seeInvitees")
	{
		%leftoff = %extra;
		if(%extra2 == "-1")
		{
			%extra2 = %clientId.Team;
		}
		%count = 0;
		if(%leftoff == "-1" || %leftoff == "butter")
		{
			%leftoff = Client::getFirst();
		}
		Client::buildMenu(%clientId, "Select Player To Invite", "mmisc", true);
		for(%cl = %leftoff ; %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%count == "6")
			{
				%count = 0;
				Client::addMenuItem(%clientId, %p++ @ "More...", "seeInvitees "@ %cl @" "@%extra2@"");

				return;
			}
			if(%cl.Team == "" && %cl != %clientId && NotInviting(%extra2, %cl))
			{
				%count++;
				Client::addMenuItem(%clientId, %p++ @ "" @ Client::GetName(%cl), "InviteHim " @ %cl @" "@%extra2@"");
			}
		}
		Client::addMenuItem(%clientId, B @ "<- Back", "teamduelsetup");
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "InviteHim" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="InviteHim")
	{
		if(%extra2 == "-1")
		{
			%extra2 = %clientId.Team ;
		}
		if(%extra.Team == "")
		{
			for(%i= 1 ; %i < 9; %i++)
			{
				if($TeamDuel::Inviting[%extra2, %i] == %extra)
				{
					client::sendMessage(%clientId, 1, "You are already inviting " @ client::getname(%extra) @ "!");
					return;
				}
			}
			for(%i= 1 ; %i < 9; %i++)
			{
				if($TeamDuel::Inviting[%extra2, %i] == "")
				{
					$TeamDuel::Inviting[%extra2, %i] = %extra;
					%extra.hasInvite = true;
					schedule("InviteCheck("@%clientId.Team@","@%i@","@%extra@");", 30);
					client::sendMessage(%extra, 1, "You have received an invite to join " @ $TeamDuel::Name[%extra2]);
					client::sendMessage(%clientId, 1, "Invite sent to " @ client::getname(%extra));
					%option = "seeInvitees";
					processMenummisc(%clientId, %option);
					if($Dueling[%extra] == "")
					{
						%option = "checkinvites";
						processMenummisc(%extra, %option);
						client::sendMessage(%extra, 1, "~wmine_act.wav");
					}
					break;
				}
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "challengeteam" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="challengeteam")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "" && $TeamDuel::Abort[%clientId.Team] == false)
		{
			%count = 0;
			Client::buildMenu(%clientId, "Teams", "mmisc", true);
			for(%i= 1 ; %i < 9; %i++)
			{
				if($TeamDuel::Name[%i] != "")
				{
					if($TeamDuel::Name[%i] == "")
					{
						return;
					}
					if(%i != %clientId.Team && $TeamDuel::InMatch[%i] == "")
					{
						Client::addMenuItem(%clientId, %count++ @ "Team: " @ $TeamDuel::Name[%i], "details "@ %i @"");
					}
				}
			}
			Client::addMenuItem(%clientId, %count++ @ "<- Back", "teamduelsetup");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "challengeteam2" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="challengeteam2")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			%p = 0;
			Client::buildMenu(%clientId, $TeamDuel::Name[%extra] @ " Members", "mmisc", true);
			Client::addMenuItem(%clientId, %p++ @ "*" @ client::getname($TeamDuel::Leader[%extra]), "teamduelsetup");
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.Team == %extra && $TeamDuel::Leader[%extra] != %cl)
				{
					Client::addMenuItem(%clientId, %p++ @ "" @ Client::GetName(%cl), "teamduelsetup");
				}
			}
				Client::addMenuItem(%clientId, %p++ @ "Challenge Details - " @ $TeamDuel::Name[%extra], "details "@ %extra @"");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "challengeteam3" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="challengeteam3")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "" && $TeamDuel::InMatch[%extra] == "")
		{
			%option = "teamduelsetup";
			processMenummisc(%clientId, %option);
			%option = "checkchallengedetails "@ %clientId.Team ;
			processMenummisc($TeamDuel::Leader[%extra], %option);
			client::sendmessage($TeamDuel::Leader[%extra], 0, "~wmine_act.wav");
			$TeamDuel::Challenging[%clientId.Team] = %extra;

			ChallengeSentM(%clientId.Team);
			ChallengeReceivedM(%extra, %clientId.Team);
			//ChallengeSentM(%clientId.Team);

		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "details" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="details")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			$TeamDuel::Challenging[%extra] = "";
			Client::buildMenu(%clientId, "Challenge Details", "mmisc", true);
			%p = 0;
			//UNCOMMENT
			if($TeamDuel::Time[%clientId.Team] != "Disabled")
			{
			//	Client::addMenuItem(%clientId, %p++ @ "Time: " @ $TeamDuel::Time[%clientId.Team] @ " Minutes", "timedetails "@ %extra @"");
			}
			if($TeamDuel::Time[%clientId.Team] == "Disabled")
			{
			//	Client::addMenuItem(%clientId, %p++ @ "Time: " @ $TeamDuel::Time[%clientId.Team], "timedetails "@ %extra @"");
			}
			Client::addMenuItem(%clientId, %p++ @ "Rounds: " @ $TeamDuel::Rounds[%clientId.Team], "roundsdetails "@ %extra @"");
			if($TeamDuel::Weapons[%clientId.Team] == "Player's Choice")
			{
				Client::addMenuItem(%clientId, %p++ @ "Weapons: Player's Choice", "weaponsdetails "@ %extra @"");
			}
			if($TeamDuel::Weapons[%clientId.Team] == "Custom")
			{
				Client::addMenuItem(%clientId, %p++ @ "Weapons: Custom", "weaponsdetails "@ %extra @"");
			}
			if($TeamDuel::Weapons[%clientId.Team] == "DiscOnly")
			{
				Client::addMenuItem(%clientId, %p++ @ "Weapons: Disc Only", "weaponsdetails "@ %extra @"");
			}
			if($TeamDuel::Packs[%clientId.Team] != "Player's Choice")
			{
				Client::addMenuItem(%clientId, %p++ @ "Packs: " @ $TeamDuel::Packs[%clientId.Team], "packdetails "@ %extra @"");
			}
			if($TeamDuel::Packs[%clientId.Team] == "Player's Choice")
			{
				Client::addMenuItem(%clientId, %p++ @ "Packs: Player's Choice", "packdetails "@ %extra @"");
			}
			//if($ArmorToggle)
			//{
				if($TeamDuel::Armor[%clientId.Team] != "Player's Choice")
				{
					Client::addMenuItem(%clientId, %p++ @ "Armor: "@GetArmorString($TeamDuel::Armor[%clientId.Team]), "armordetails "@ %extra @"");
				}
				else
				{
					Client::addMenuItem(%clientId, %p++ @ "Armor: Player's Choice", "armordetails "@ %extra@"");
				}
			//}
			if($TeamDuel::Arena)
			{
				Client::addMenuItem(%clientId, %p++ @ "Arena: " @ $TeamDuel::Arena[%clientId.Team], "arenadetails "@ %extra @"");
			}
			if($TeamDuel::Arena && $TeamDuel::Arena[%clientId.Team] != "None")
			{
				Client::addMenuItem(%clientId, %p++ @ "Loadout Spawn: " @ $TeamDuel::ArenaSpawn[%clientId.Team], "arenaweapons "@ %extra @"");
			}
			if($TeamDuel::Arena[%clientId.Team] == "None" && !$TeamDuel::Multi[%clientId.Team])
			{
				Client::addMenuItem(%clientId, %p++ @ "Random Spawns: " @ $TeamDuel::NewSpawns[%clientId.Team], "NewSpawnToggle "@ %extra @"");
			}
			Client::addMenuItem(%clientId, %p++ @ "Multi Team: "@$TeamDuel::Multi[%clientId.Team], "multidetails "@ %extra @"");
			//Client::addMenuItem(%clientId, %p++ @ "Mines: "@$TeamDuel::Mines[%clientId.Team], "minedetails "@ %extra @"");
			Client::addMenuItem(%clientId, %p++ @ "Send Request", "challengeteam3 "@ %extra @"");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "arenaweapons" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="arenaweapons")
	{
		if($TeamDuel::ArenaSpawn[%clientId.Team])
		{
			$TeamDuel::ArenaSpawn[%clientId.Team] = false;
		}
		else {
			$TeamDuel::ArenaSpawn[%clientId.Team] = true;
		}
		%option = "details " @ %extra @ "";
		processMenummisc(%clientId, %option);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "NewSpawnToggle" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="NewSpawnToggle")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			if($TeamDuel::NewSpawns[%clientId.Team])
			{
				$TeamDuel::NewSpawns[%clientId.Team] = false;
			}
			else {
				$TeamDuel::NewSpawns[%clientId.Team] = true;
			}
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "multidetails" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="multidetails")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{

			if($TeamDuel::Multi[%clientId.Team])
			{
				$TeamDuel::Multi[%clientId.Team] = false;
			}
			else {
				$TeamDuel::Multi[%clientId.Team] = true;
			}
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
		}
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "minedetails" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="minedetails")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{

			if($TeamDuel::Mines[%clientId.Team] == "On")
			{
				$TeamDuel::Mines[%clientId.Team] = "Off";
			}
			else {
				$TeamDuel::Mines[%clientId.Team] = "On";
			}
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "setMines" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="setMines")
	{
			$TeamDuel::Mines[%clientId.Team] = %extra2;
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
			return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "weaponsdetails" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="weaponsdetails")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			Client::buildMenu(%clientId, "Loadouts:", "mmisc", true);
			%p = 0;
			//Client::addMenuItem(%clientId, %p++ @ "Disc Plas Nade", "setweapons "@ %extra @" DPN");
			Client::addMenuItem(%clientId, %p++ @ "Custom", "setweapons "@ %extra @" Custom");
			Client::addMenuItem(%clientId, %p++ @ "Disc Only", "setweapons "@ %extra @" DiscOnly");
			Client::addMenuItem(%clientId, %p++ @ "Player's Choice", "setweapons "@ %extra @" Player's Choice");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "TDWeaps" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="TDWeaps")
	{
		//both("o: "@%o@" extra: "@%extra@" extra2: "@%extra2@" extra3: "@%extra3@" extra4: "@%extra4);
		if(%extra3 == "start")
		{
			//both("clearing");
			$TeamDuel::CustomWeapons[%clientId.Team, 0] = "";
			$TeamDuel::CustomWeapons[%clientId.Team, 1] = "";
			$TeamDuel::CustomWeapons[%clientId.Team, 2] = "";
		}

		if(%extra == "setweap")
		{
			$TeamDuel::CustomWeapons[%clientId.Team, %extra2] = %extra3@" "@%extra4;
			//both("weapon set "@$Duelweapon[gw($TeamDuel::CustomWeapons[%clientId.Team, %extra2],0)]@" Ammo: x"@gw($TeamDuel::CustomWeapons[%clientId.Team, %extra2],1));
			%extra = "pickweap";
			%extra2++;
			if(%extra2 == "3")
			{
				%extra = "Done";
			}

		}
		if(%extra == "pickweap")
		{
			//both("eureka");
			Client::buildMenu(%clientId, "Choose Weapon #"@%extra2+1, "mmisc", true);
			%p = 0;
			for(%i = 1; %i < 9+1; %i++)
			{
				if(gw($TeamDuel::CustomWeapons[%clientId.Team, 0],0) != %i && gw($TeamDuel::CustomWeapons[%clientId.Team, 1],0) != %i)
				{
					Client::addMenuItem(%clientId, %p++ @ $DuelWeapon[%i]@" x", "TDWeaps pickammo "@%extra2@" "@ %i);
				}

			}
			Client::addMenuItem(%clientId, %p++ @ "Done", "TDWeaps Done "@%extra2);
		}
		if(%extra == "Done")
		{
			%extra = %clientId.challenging;
			%clientId.challenging = "";
			$TeamDuel::Weapons[%clientId.Team] = "Custom";
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);

		}
		if(%extra == "pickammo")
		{//extra3 is the actual weap picked extra2 is the current weap number
			if(%extra3 == "5" || %extra3 == "6" || %extra3 == "7")
			{
				%option = "TDWeaps setweap "@ %extra2@" "@%extra3@" 1";
				processMenummisc(%clientId, %option);
			}
			else
			{
				Client::buildMenu(%clientId, "Ammo Multiplier: "@$DuelWeapon[%extra3], "mmisc", true);
				%p = 0;
				Client::addMenuItem(%clientId, %p++ @ "Half", "TDWeaps setweap "@ %extra2@" "@%extra3@" 0.5");
				Client::addMenuItem(%clientId, %p++ @ "Normal", "TDWeaps setweap "@ %extra2@" "@%extra3@" 1");
				Client::addMenuItem(%clientId, %p++ @ "x2", "TDWeaps setweap "@ %extra2@" "@%extra3@" 2");
				Client::addMenuItem(%clientId, %p++ @ "x5", "TDWeaps setweap "@ %extra2@" "@%extra3@" 5");
				Client::addMenuItem(%clientId, %p++ @ "x10", "TDWeaps setweap "@ %extra2@" "@%extra3@" 10");
				Client::addMenuItem(%clientId, %p++ @ "x100", "TDWeaps setweap "@ %extra2@" "@%extra3@" 100");
			}
		}


	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "setweapons" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="setweapons")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			if(%extra2 == "Custom")
			{
				client::sendmessage(%clientId, 0, "Choose each weapon followed by ammo multiplier.");
				%option = "TDWeaps pickweap 0 start";
				%clientId.challenging = %extra;
				return processMenummisc(%clientId, %option);
			}
			$TeamDuel::Weapons[%clientId.Team] = %extra2;//cum back
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);

			if(%extra2 == "DCN")
			{
				client::sendmessage(%clientId, 0, "Weapons set to: Disc CG Nade");
			}
			if(%extra2 == "DEN")
			{
				client::sendmessage(%clientId, 0, "Weapons set to: Disc Elf Nade");
			}
			if(%extra2 == "DLN")
			{
				client::sendmessage(%clientId, 0, "Weapons set to: Disc Laser Nade");
			}
			//echo(%extra3@" h");
			if(%extra2 @" "@%extra3 == "Player's Choice")
			{
				$TeamDuel::Weapons[%clientId.Team] = "Player's Choice";
				client::sendmessage(%clientId, 0, "Weapons set to: Player's Choice");
				%option = "details " @ %extra @ "";
				processMenummisc(%clientId, %option);
			}

		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "roundsdetails" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="roundsdetails")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			Client::buildMenu(%clientId, "First to win:", "mmisc", true);
			%p = 0;
			Client::addMenuItem(%clientId, %p++ @ "1 round", "setrounds "@ %extra @" 1");
			Client::addMenuItem(%clientId, %p++ @ "2 rounds", "setrounds "@ %extra @" 2");
			Client::addMenuItem(%clientId, %p++ @ "3 rounds", "setrounds "@ %extra @" 3");
			Client::addMenuItem(%clientId, %p++ @ "4 rounds", "setrounds "@ %extra @" 4");
			Client::addMenuItem(%clientId, %p++ @ "5 rounds", "setrounds "@ %extra @" 5");
			Client::addMenuItem(%clientId, %p++ @ "10 rounds", "setrounds "@ %extra @" 10");
			Client::addMenuItem(%clientId, %p++ @ "20 rounds", "setrounds "@ %extra @" 20");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "setrounds"  && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="setrounds")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			$TeamDuel::Rounds[%clientId.Team] = %extra2;
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
			client::sendmessage(%clientId, 0, "Rounds set to " @ %extra2);
		}
		return;
	}
	//if($ArmorToggle)
	//{
		if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "armordetails" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="armordetails")
		{
			Client::buildMenu(%clientId, "Armor Menu", "mmisc", true);
			%p = 0;
			Client::addMenuItem(%clientId, %p++ @ "Light Armor", "TDsetarmor "@ %extra @" larmor");
			Client::addMenuItem(%clientId, %p++ @ "Medium Armor", "TDsetarmor "@ %extra @" marmor");
			Client::addMenuItem(%clientId, %p++ @ "Heavy Armor", "TDsetarmor "@ %extra @" harmor");
			Client::addMenuItem(%clientId, %p++ @ "Player's Choice", "TDsetarmor "@ %extra @" Player's Choice");
			return;
		}
		if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "TDsetarmor" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="setarmor")
		{
			//client::sendmessage(%clientId, 0, "0: "@%extra@" 1: "@%extra1@" 2: "@%extra2@" 3: "@%extra3@" 4: "@%extra4@" 5: "@%extra5);
			if(%extra2 == "Player's" || %extra2 == "Player's ")
			{
				echo("fixing...");
				%extra2 = "Player's Choice";
			}
			$TeamDuel::Armor[%clientId.Team] = %extra2;
			client::sendmessage(%clientId, 0, "Armor set to: "@GetArmorString(%extra2@" "@%extra3));
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
			return;
		}
	//}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "packdetails" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="packdetails")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			Client::buildMenu(%clientId, "Packs Menu", "mmisc", true);
			%p = 0;
			Client::addMenuItem(%clientId, %p++ @ "None", "setpacks "@ %extra @" None");
			Client::addMenuItem(%clientId, %p++ @ "Energy", "setpacks "@ %extra @" Energy");
			Client::addMenuItem(%clientId, %p++ @ "Repair", "setpacks "@ %extra @" Repair");
			Client::addMenuItem(%clientId, %p++ @ "Ammo", "setpacks "@ %extra @" Ammo");
			Client::addMenuItem(%clientId, %p++ @ "Shield", "setpacks "@ %extra @" Shield");
			Client::addMenuItem(%clientId, %p++ @ "Player's Choice", "setpacks "@ %extra @" Player's Choice");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "setpacks" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="setpacks")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			$TeamDuel::Packs[%clientId.Team] = %extra2;

			if(%extra2@" "@%extra3 != "Player's Choice")
			{
				client::sendmessage(%clientId, 0, "Packs set to " @ %extra2);
			}
			if(%extra2@" "@%extra3 == "Player's Choice")
			{
				client::sendmessage(%clientId, 0, "Packs set to Player's Choice");
				$TeamDuel::Packs[%clientId.Team] = "Player's Choice";
			}
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "arenadetails" && $TeamDuel::Arena && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="arenadetails")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			if(%extra2 == "")
			{
				%extra2 = -1;
				//%extra = 0;
			}
			Client::buildMenu(%clientId, "Arena Menu", "mmisc", true);
			%p = 0;
			//echo("Extra2 "@%extra2@" "@
			for(%x = %extra2; %x < $Arenas; %x++)
			{
				if(%x == "0") { %x++; }
				Client::addMenuItem(%clientId, %p++ @ $Arena[%x], "setarena "@ %extra @" "@$Arena[%x]);
				if(%p > 5)
				{
					Client::addMenuItem(%clientId, %p++ @ "more...", "arenadetails "@ %extra @" "@%x+1);
					break;
				}
			}


			//Client::addMenuItem(%clientId, %p++ @ "None", "setarena "@ %extra @" None");
			//Client::addMenuItem(%clientId, %p++ @ "Arena Under The Hill (" @ $TeamDuel::ArenaStatus[Auth] @ ")", "setarena "@ %extra @" Auth");
			//Client::addMenuItem(%clientId, %p++ @ "ArenaMadness (" @ $TeamDuel::ArenaStatus[ArenaMadness] @ ")", "setarena "@ %extra @" ArenaMadness");
			//Client::addMenuItem(%clientId, %p++ @ "A Safe Warm Place (" @ $TeamDuel::ArenaStatus[ASWP] @ ")", "setarena "@ %extra @" ASWP");
			//Client::addMenuItem(%clientId, %p++ @ "BF-Neighbor (" @ $TeamDuel::ArenaStatus[Neighbor] @ ")", "setarena "@ %extra @" Neighbor");
			//Client::addMenuItem(%clientId, %p++ @ "BF-Discord (" @ $TeamDuel::ArenaStatus[Discord] @ ")", "setarena "@ %extra @" Discord");
			//Client::addMenuItem(%clientId, %p++ @ "BF-CaX (" @ $TeamDuel::ArenaStatus[CaX] @ ")", "setarena "@ %extra @" CaX");
			//Client::addMenuItem(%clientId, %p++ @ "BF-AirArena (" @ $TeamDuel::ArenaStatus[CaX] @ ")", "setarena "@ %extra @" Air");
			//Client::addMenuItem(%clientId, %p++ @ "NewYorkerArena (" @ $TeamDuel::ArenaStatus[NewYork] @ ")", "setarena "@ %extra @" NewYork");
			//Client::addMenuItem(%clientId, %p++ @ "OldMilwaukee (" @ $TeamDuel::ArenaStatus[OldMilwaukee] @ ")", "setarena "@ %extra @" OldMilwaukee");
			//Client::addMenuItem(%clientId, %p++ @ "Gonrena (" @ $TeamDuel::ArenaStatus[Gonrena] @ ")", "setarena "@ %extra @" Gonrena");

		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "setarena" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="setarena")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			$TeamDuel::Arena[%clientId.Team] = %extra2;
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
			if(%extra2 != "None")
			{
				client::sendmessage(%clientId, 0, "Arena set to " @ %extra2);
			}
			if(%extra2 == "None")
			{
				client::sendmessage(%clientId, 0, "Match will be fought on the duel terrain.");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "timedetails" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="timedetails")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			Client::buildMenu(%clientId, "Time Setup", "mmisc", true);
			%p = 0;
			Client::addMenuItem(%clientId, %p++ @ "1 Minutes", "settime "@ %extra @" 1");
			Client::addMenuItem(%clientId, %p++ @ "2 Minutes", "settime "@ %extra @" 2");
			Client::addMenuItem(%clientId, %p++ @ "3 Minutes", "settime "@ %extra @" 3");
			Client::addMenuItem(%clientId, %p++ @ "4 Minutes", "settime "@ %extra @" 4");
			Client::addMenuItem(%clientId, %p++ @ "5 Minutes", "settime "@ %extra @" 5");
			Client::addMenuItem(%clientId, %p++ @ "6 Minutes", "settime "@ %extra @" 6");
			Client::addMenuItem(%clientId, %p++ @ "7 Minutes", "settime "@ %extra @" 7");
			Client::addMenuItem(%clientId, %p++ @ "8 Minutes", "settime "@ %extra @" 8");
			Client::addMenuItem(%clientId, %p++ @ "Disable", "settime "@ %extra @" Disabled");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "settime" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="settime")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			$TeamDuel::Time[%clientId.Team] = %extra2;
			%option = "details " @ %extra @ "";
			processMenummisc(%clientId, %option);
			if(%extra2 != "Disabled")
			{
				client::sendmessage(%clientId, 0, "Match time set to " @ %extra2 @ " minutes.");
			}
			if(%extra2 == "Disabled")
			{
				client::sendmessage(%clientId, 0, "Match time disabled.");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "challengethem")
	{
		if($TeamDuel::InMatch[%clientId.Team] == "")
		{
			client::sendmessage($TeamDuel::Leader[%extra], 3, "The " @ $TeamDuel::Name[%clientId.Team] @ " have challenged your team. Check the details in the tab menu.");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "NEWjointeam")
	{
		%p = 0;
		Client::buildMenu(%clientId, "Teams (Members)", "mmisc", true);
		for(%i= 1 ; %i < 9; %i++)
		{
			if($TeamDuel::Name[%i] != "" && $TeamDuel::Locked[%i] == "")
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ $TeamDuel::Name[%i] @ "@ (" @ GetTeamPlayerCount(%i) @ ") "@TotalKD(%i)@"", "listteam "@ %i @"");
			}
			if($TeamDuel::Name[%i] != "" && $TeamDuel::Locked[%i])
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ $TeamDuel::Name[%i] @ " (" @ GetTeamPlayerCount(%i) @ ") "@TotalKD(%i)@" *locked*", "listteam "@ %i @"");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "jointeam")
	{
		%p = 0;
		Client::buildMenu(%clientId, "Teams (Members)", "mmisc", true);
		for(%i= 1 ; %i < 9; %i++)
		{
			if($TeamDuel::Name[%i] != "")
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ $TeamDuel::Name[%i] @ " (" @ GetTeamPlayerCount(%i) @ ") "@TotalKD(%i)@"", "listteam "@ %i @"");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "changeteam")
	{
		%p = 0;
		Client::buildMenu(%clientId, "Teams (Members)", "mmisc", true);
		if(%clientId.Team != "")
		{
			Client::addMenuItem(%clientId, %p++ @ "Leave your team", "leaveteam2");
		}
		for(%i= 1 ; %i < 9; %i++)
		{
			if($TeamDuel::Name[%i] != "" && $TeamDuel::Locked[%i] == "" && %i != %clientId.Team)
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ $TeamDuel::Name[%i] @ " (" @ GetTeamPlayerCount(%i) @ ") "@TotalKD(%i)@"", "listteam "@ %i @" Pass");
			}
			if($TeamDuel::Name[%i] != "" && $TeamDuel::Locked[%i])
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ $TeamDuel::Name[%i] @ " (" @ GetTeamPlayerCount(%i) @ ") "@TotalKD(%i)@" *locked*", "listteam "@ %i @" Pass");
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "listteam")
	{
		//both(%o@" extra: "@%extra@" 2: "@%extra2@" 3: "@%extra3);
		if(%extra2 == "Pass" && %extra == %clientId.Team || $TeamDuel::Locked[%extra])
		{
			client::sendmessage(%clientId, 0, "~wError_Message.wav");
			//%option = "changeteam";
			//processMenummisc(%clientId, %option);
			//return;
		}
		%p = 0;
		Client::buildMenu(%clientId, $TeamDuel::Name[%extra] @ " Members", "mmisc", true);
		Client::addMenuItem(%clientId, %p++ @ "*" @ client::getname($TeamDuel::Leader[%extra]), "teamduelsetup");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.Team == %extra && $TeamDuel::Leader[%extra] != %cl)
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ Client::GetName(%cl), "teamduelsetup");
			}
		}
		if(%clientId.Team == "" && $TeamDuel::Locked[%extra])
		{
			Client::addMenuItem(%clientId, %p++ @ "Request - " @ $TeamDuel::Name[%extra], "join "@ %extra @" Pass");
		}
		if(%clientId.Team == "" && $TeamDuel::Locked[%extra] == "" || %extra2 == "Pass")
		{
			Client::addMenuItem(%clientId, %p++ @ "Join - " @ $TeamDuel::Name[%extra], "join "@ %extra @" Pass");
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "SeeJoiners" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="SeeJoiners")
	{
		//echo("extra "@%extra);
		if(%extra == "" || %extra == "-1")
		{
			//echo(what);
			%extra = %clientId.Team;
		}
		Client::buildMenu(%clientId, "Click to add to your team", "mmisc", true);
		%p = 0;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if($TeamDuel::Leader[%extra] == %clientId || Authorization(%clientId))
			{
				if(%cl.TeamJoining == %extra)
				{
					Client::addMenuItem(%clientId, %p++ @ "Add: " @ Client::GetName(%cl), "allowin "@ %cl @" "@ $TeamDuel::Leader[%extra] @"");
				}
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "allowin" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="allowin")
	{
	   if($Winners::On[%extra])
	   {
		   processMenuOptions(%extra, "disablewinners");
	   }
		if($Dueling[%extra])
		{
			client::sendmessage(%clientId, 1, client::getname(%extra) @" is currently in a duel~werror_message.wav");
			return;
		}
		if(%extra.TeamJoining != %clientId.Team && !Authorization(%clientId))
		{
			client::sendmessage(%clientId, 1, client::getname(%extra) @" is no longer asking to join your team~werror_message.wav");
			return;
		}
		%extramsg = ".";
		if($TeamDuel::Ticker[%clientId.Team] == "false" && $TeamDuel::InMatch[%clientId.Team] == "True")
		{
			//%extramsg = " and will spawn after this round.";
		}
		%message = Client::GetName(%extra) @ " was added to the "@ $TeamDuel::Name[%extra2.Team] @" team"@%extramsg ;
		%extra.Team = %extra2.Team;
		%extra.hasInvite = false;
		SetStats(%extra2.Team);
		%extra.TeamJoining = "";
		%extra.Naming = "";
		TMessage(666, 666,  $White, %message, 1);
		ClearInvites(%extra);
		Game::refreshClientScore(%extra);
		if($TeamDuel::Ticker[%extra2.Team] || $TeamDuel::CanHurt[%extra2.Team] == "" || $TeamDuel::CanHurt[%extra2.Team] == "False")
		{
			if($TeamDuel::Challenging[%extra] == "0")
			{
				return MultiTeamDuel::TickerSpawn(%extra);
			}
			else
			{
				if($TeamDuel::Arena[%clientId.Team] == "None")
				{
					delete($TeamDuel::Leader[%extra2.Team]);
					SpawnNoArena($TeamDuel::Leader[%extra2.Team], %extra);
				}
				else
				{
					SetupTeamSpawn(%extra2.Team, %extra);
				}
			}
		}




		%clientId = %extra;
		if($TeamDuel::Ticker[%clientId.Team] && $TeamDuel::InMatch[%clientId.Team] == "True" && $TeamDuel::Challenging[%clientId.Team] != "0" || $TeamDuel::Ticker[%clientId.Team] == "false" && $TeamDuel::CanHurt[%clientId.Team] == "" && $TeamDuel::InMatch[%clientId.Team] == "True" && $TeamDuel::Challenging[%clientId.Team] != "0")
		{
			if($TeamDuel::Arena[%clientId.Team] == "None")
			{
				//delete($TeamDuel::Leader[%clientId.Team]);
				SpawnNoArena($TeamDuel::Leader[%clientId.Team], %clientId);
				if($TeamDuel::CanHurt[%clientId.Team] == "")
				{
					Client::setOwnedObject(%clientId, %clientId.owns);
					Client::setControlObject(%clientId, %clientId.Owns);
					GameBase::SetDamageLevel(%clientId.Owns, 0);
					%clientId.guiLock = false;
					Client::setGuiMode(%clientId, $GuiModePlay);
					%clientId.oob = false;
				}

				//SpawnNoObjects($TeamDuel::Leader[%clientId.Team]);
			}
			else
			{
				SetupTeamSpawn(%clientId.Team, %clientId);
				if($TeamDuel::CanHurt[%clientId.Team] == "")
				{
					Client::setOwnedObject(%clientId, %clientId.owns);
					Client::setControlObject(%clientId, %clientId.Owns);
					GameBase::SetDamageLevel(%clientId.Owns, 0);
					%clientId.guiLock = false;
					Client::setGuiMode(%clientId, $GuiModePlay);
					%clientId.oob = false;
				}
			}
			//SetupTeamSpawn(%clientId.Team, %clientId);
			//TeamDuelSpawn(%extra, $TeamDuel::LeftOff[%extra2.Team]);
		}






		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "possess")
	{
		TeamDuel::Possess(%clientId,%extra);
		return;
	}

	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "join")
	{
		if(%clientId.Team == "" || %extra2 == "Pass")
		{
			JoinRequest(%clientId, %extra);
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "kickplayerteam" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="kickplayerteam")
	{
		if($TeamDuel::Leader[%clientId.Team] == %clientId || Authorization(%clientId))
		{
			Client::buildMenu(%clientId, "Team Duel Setup", "mmisc", true);
			%z = 0;
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.Team == %clientId.Team)
				{
					if(%clientId != %cl)
					{
						Client::addMenuItem(%clientId, %z++ @ "Kick: " @ Client::GetName(%cl), "kickplayerteam2 "@ %cl @"");
					}
				}
			}
		}
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "kickplayerteam2" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="kickplayerteam2")
	{
		Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
		Client::addMenuItem(%clientId, X @ "Kick: " @ Client::GetName(%extra) @"?", "kickplayerteamaffirm "@ %extra @"");
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "kickplayerteamaffirm" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="kickplayerteamaffirm")
	{
		%message =  Client::GetName(%extra) @ " has been kicked off the "@ $TeamDuel::Name[%extra.Team] @" team." ;
		kickcheck(%extra);
		if($TeamDuel::Leader[%extra.Team] == %extra)
		{
			NextLeader(%extra.Team);
		}
		TMessage(666, 666,  $Red, %message, 1);
		LeaveTeam(%extra);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "leaveteam2")
	{
		Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
		Client::addMenuItem(%clientId, X @ "Leave your team?", "leaveteam");
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "leaveteam")
	{
		%message = Client::GetName(%clientId) @ " has left the "@ $TeamDuel::Name[%clientId.Team] @" team." ;
		if($TeamDuel::Leader[%ClientId.Team] == %clientId)
		{
			NextLeader(%clientId.Team);
		}
		TMessage(666, 666,  $Green, %message, 1);
		LeaveTeam(%clientId);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "disbandteam" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="disbandteam")
	{
		Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
		Client::addMenuItem(%clientId, X @ "Disband your team?", "disbandIT "@%extra);
		return;
	}
	if(!$Dueling[%clientId] && $TeamDuel::Master && %o == "disbandIT" && $TeamDuel::Leader[%ClientId.Team] == %clientId || Authorization(%clientId) && %o =="disbandIT")
	{
		if(%extra == "-1")
		{
			%extra = %clientId.Team;
		}
		if($Teamduel::Leader[%extra] == %clientId)
		{
			messageall(1, Client::GetName(%ClientId) @ " disbanded the " @ $TeamDuel::Name[%extra] @ " team.");
			DeleteTeam(%extra);
		}
		else
		{
			messageall($Red, Client::GetName(%ClientId) @ " attempted to disbanded the " @ $TeamDuel::Name[%extra] @ " team.");
		}
		return;
	}
	if(%o == "createteam")
	{
		%clientId.Naming = "true";
		Client::sendMessage(%clientId, 1, "Please type the name of your team.");
		return;
	}
	if(%o == "changehisteam")
	{
		Client::buildMenu(%clientId, client::getname(%extra)@" Team Set", "mmisc", true);
		if(%extra.Team != "")
		{
			Client::addMenuItem(%clientId, %p++ @ "None", "removehimfromteam "@ %extra);
		}
		for(%i= 1 ; %i < 9; %i++)
		{
			if($TeamDuel::Name[%i] != "" && $TeamDuel::Locked[%i] == "" && %i != %extra.Team)
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ $TeamDuel::Name[%i] @ " (" @ GetTeamPlayerCount(%i) @ ") "@TotalKD(%i)@"", "changehisteam2 "@ %extra@" "@%i);
			}
			if($TeamDuel::Name[%i] != "" && $TeamDuel::Locked[%i] && %i != %extra.Team)
			{
				Client::addMenuItem(%clientId, %p++ @ "" @ $TeamDuel::Name[%i] @ " (" @ GetTeamPlayerCount(%i) @ ") "@TotalKD(%i)@" *locked*", "changehisteam2 "@ %extra@" "@%i);
			}
		}
		return;
	}
	if(%o == "changehisteam2")
	{
		if(%clientId.isSuperAdmin)
		{
			%message = client::getname(%clientId)@" placed "@client::getname(%extra)@" on the "@$TeamDuel::Name[%extra2]@" team";
			TMessage(666, 666,  $Green, %message, 1);
			SwapTeam(%extra, %extra2);
		}
		return;
	}
	if(%o == "removehimfromteam")
	{
		Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
		Client::addMenuItem(%clientId, X @ "Remove "@client::getname(%extra)@" from "@$TeamDuel::Name[%extra.Team]@"", "removehimfromteam2 "@ %extra);
		return;
	}
	if(%o == "removehimfromteam2")
	{
		if(%clientId.isSuperAdmin)
		{
			%message = client::getname(%extra)@" was removed from his team by "@client::getname(%clientId) ;
			TMessage(666, 666,  $Green, %message, 1);
			LeaveTeam(%extra);
		}
		return;
	}
	if(%o == "makethisdudeleader")
	{
		Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
		Client::addMenuItem(%clientId, X @ "Make "@client::getname(%extra)@" leader of "@$TeamDuel::Name[%extra.Team]@"", "makethisdudeleader2 "@ %extra);
		return;
	}
	if(%o == "makethisdudeleader2")
	{
		if(%clientId.isSuperAdmin)
		{
			%message = client::getname(%clientId)@" made "@client::getname(%extra)@" leader of "@$TeamDuel::Name[%extra.Team] ;
			TMessage(666, 666,  $Green, %message, 1);
			$TeamDuel::Leader[%extra.Team] = %extra;
		}
		return;
	}
	if(%o == "RestartServer")
	{
		if(%clientId.isSuperAdmin)
		{
			Client::buildMenu(%clientId, "Are You Sure?", "mmisc", true);
			Client::addMenuItem(%clientId, X @ "Restart Server", RestartServer2);
		}
	}
	if(%o == "RestartServer2")
	{
		//if(Authorization(%clientId))
		//{
			RestartServer(11);
		//}
		//else {
		//	client::sendmessage(%clientId, $White, "You don't have access for that!~werror_message.wav");
		//}
	}
   if(%o == "armorsetup")
   {
		ArmorSetup(%clientId);
		return;
   }
   if(%o == "scorerestore")
   {
		if(%extra == "yes" && %clientId.scorecheck && %clientId.scorerestore != "")
		{
			RestoreScore(%clientId, %clientId.scorerestore);
			%clientId.scorerestore = "";
			%clientId.scorecheck = "";
			client::sendmessage(%clientId, $White, "You score has been restored.");
		}
		if(%extra == "no")
		{
			%clientId.scorerestore = "";
			%clientId.scorecheck = "";
			%clientId.tick = "";
			client::sendmessage(%clientId, $White, "Your previous score has been erased.");
		}
		game::menurequest(%clientId);
		return;
   }
   if(%o == "viewsmurfs")
   {
	   viewsmurfs(%clientId, %extra, %extra2);
   }
}


function SetStats(%Team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(SetStats);
	}
	if($TeamDuel::Name[%Team] != "")
	{
		$TeamDuel::Line2[%Team] = $TeamDuel::Name[%Team]@" Players: "@GetTeamPlayerCount(%Team)@", "@TotalKD(%Team)@", MA's "@TotalMA(%Team) ;
		$TeamDuel::Line3[%Team] = "Win-Loss, Rounds: "@$TeamDuel::MatchesWon[%Team]@"/"@$TeamDuel::MatchesLost[%Team]@", Matches: "@$TeamDuel::Wins[%Team]@"/"@$TeamDuel::Losses[%Team] ;
		if($TeamDuel::InMatch[%Team] == "True")
		{
			$TeamDuel::Line4[%Team] = "Current Score: You: "@$TeamDuel::Score[%Team]@"/"@$TeamDuel::Rounds[%Team]@", Them: "@$TeamDuel::Score[$TeamDuel::Challenging[%Team]]@"/"@$TeamDuel::Rounds[%Team] ;
		}	else {
			$TeamDuel::Line4[%Team] = "";
		}

		if($TeamDuel::Challenging[%Team] != "")
		{
			%Team1 = %Team;
			%Team = $TeamDuel::Challenging[%Team];
			$TeamDuel::Line5[%Team1] = $TeamDuel::Name[%Team]@" Players: "@GetTeamPlayerCount(%Team)@", "@TotalKD(%Team)@", MA's "@TotalMA(%Team) ;
			$TeamDuel::Line6[%Team1] = "Win-Loss, Rounds: "@$TeamDuel::MatchesWon[%Team]@"/"@$TeamDuel::MatchesLost[%Team]@", Matches: "@$TeamDuel::Wins[%Team]@"/"@$TeamDuel::Losses[%Team] ;
		}	else {
			$TeamDuel::Line5[%Team1] = "";
			$TeamDuel::Line6[%Team1] = "";
		}
	}
}

function JoinRequest(%clientId, %team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(JoinRequest);
	}
	if($TeamDuel::Locked[%team])
	{
		if(%clientId.TeamJoining == %team)
		{
			client::sendmessage(%clientId, $Red, "You are already asking to join this team.");
			return;
		}
			%cl = $TeamDuel::Leader[%team];
			client::sendMessage(%clientId, 0, "Your request to join " @ $TeamDuel::Name[%team] @ " has been sent to " @ Client::getName($TeamDuel::Leader[%team]));
			client::sendMessage(%cl, 0, Client::GetName(%clientId) @ " is requesting permission to join your team.");
			%clientId.TeamJoining = %team;
			if($TeamDuel::InMatch[%cl.Team] != "True")
			{
				%option = "SeeJoiners";
				processMenummisc(%cl, %option);
				client::sendMessage(%cl, 0, "~wmine_act.wav");
			}
			return;
	}
	else
	{
		if($TeamDuel::Name[%team] != "")
		{
			SwapTeam(%clientId, %team);
		}
	}
}

function TeamDuel::ProcessTradeRequest(%RequestingTeamClient, %EnemyTeamClient, %RequestingTeam, %EnemyTeam, %Requester)
{
	if(%RequestingTeamClient != "None")
	{
		SwapTeam(%RequestingTeamClient, %EnemyTeam);
		%message = client::getname(%Requester) @" switched "@client::getname(%RequestingTeamClient)@" to his team." ;
	}
	if(%EnemyTeamClient != "None")
	{
		SwapTeam(%EnemyTeamClient, %RequestingTeam);
		%message = client::getname(%Requester) @" switched "@client::getname(%EnemyTeamClient)@" to his team." ;
	}
	if(%EnemyTeamClient != "None" && %RequestingTeamClient != "None")
	{
		%message = client::getname(%Requester) @" has traded "@client::getname(%RequestingTeamClient)@" for "@client::getname(%EnemyTeamClient)@"." ;
	}
	//both("TRADE COMPLETED!");
	TMessage(%RequestingTeam, %EnemyTeam,  $Green, %message);
	$TeamDuel::Trading::OfferStatusCheck[%RequestingTeam, %EnemyTeam] = "";
	$TeamDuel::Trading::OfferStatusCheck[%EnemyTeam, %RequestingTeam] = "";
	$TeamDuel::Trading::Offer[%EnemyTeam, %RequestingTeam] = "";
	$TeamDuel::Trading::Offer[%RequestingTeam, %EnemyTeam] = "";
}
//indicate team wants to trade $Teamduel::Trade
function TeamDuel::SendTradeRequest(%RequestingTeamClient, %EnemyTeamClient, %RequestingTeam, %EnemyTeam, %Requester)
{
	//echo("Trade req "@%RequestingTeamClient@", "@ %EnemyTeamClient@", "@ %RequestingTeam@", "@ %EnemyTeam@", "@ %Requester);
	if($TeamDuel::Locked[%EnemyTeam] == "" || Authorization(%Requester) || %Requester.isSuperAdmin)
	{
		%reason = "(unlocked team)";
		if((Authorization(%Requester) || %Requester.isSuperAdmin) && $TeamDuel::Locked[%EnemyTeam] != "")
		{
			%reason = "(admin)";
		}
		TeamDuel::ProcessTradeRequest(%RequestingTeamClient, %EnemyTeamClient, %RequestingTeam, %EnemyTeam, %Requester);
		TMessage(%RequestingTeam, %EnemyTeam,  $Green, "Trade auto-completed. "@%reason);
	}
	else
	{
		$TeamDuel::Trading::Offer[%RequestingTeam, %EnemyTeam] = %RequestingTeamClient@" "@%EnemyTeamClient;
		$TeamDuel::Trading::OfferStatusCheck[%RequestingTeam, %EnemyTeam] = true;

		if(%RequestingTeamClient == "None")
		{
			%message = client::getname(%Requester) @" wants "@client::getname(%EnemyTeamClient)@" traded to his team." ;
		}
		if(%EnemyTeamClient == "None")
		{
			%message = client::getname(%Requester) @" has offered to give "@client::getname(%RequestingTeamClient)@" to the "@$TeamDuel::Name[%EnemyTeam]@" team." ;
		}
		if(%RequestingTeamClient != "None" && %EnemyTeamClient != "None")
		{
			%message = client::getname(%Requester) @" offered to trade "@client::getname(%RequestingTeamClient)@" for "@client::getname(%EnemyTeamClient)@"." ;
		}

		TMessage(%RequestingTeam, %EnemyTeam, $Red, %message);

		%option = "tradethisforthat "@%EnemyTeamClient@" "@%RequestingTeamClient@" "@%EnemyTeam@" "@%RequestingTeam@" true";
		if($TeamDuel::Leader[%EnemyTeam].menumode != "")
		{
			remoteScoresOff($TeamDuel::Leader[%EnemyTeam]);
		}
		processMenummisc($TeamDuel::Leader[%EnemyTeam], %option);
		client::sendmessage($TeamDuel::Leader[%EnemyTeam], 0, "~wmine_act.wav");
	}
}



function SwapTeam(%clientId, %team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(SwapTeam);
	}
	if(%clientId.Team != "")
	{
		LeaveTeam(%clientId);
	}
	%option = "acceptinvite1 "@ %team @"" ;
	processMenummisc(%clientId, %option);
}
function TradeCheck(%client1, %client2, %client1T, %client2T)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TradeCheck);
	}
	if($TeamDuel::Trade[%client1T, %client2T] == %client1@" "@%client2@" "@%client1T@" "@%client2T)
	{
		$TeamDuel::Trade[%client1T, %client2T] = "";
	}
}
function processMenuWhisper(%clientId, %option)
{
	Client::buildMenu(%clientId, "Private", "Whisper", true);
}
 $loaded["TDMenu.cs"] = true;
