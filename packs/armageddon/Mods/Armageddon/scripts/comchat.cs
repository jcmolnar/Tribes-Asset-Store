//=== PRAYER ===//
// God please   //
// help grey    //
// become damn  //  <--- :'( - VRWarper
// neater in    //
// his work...  //
//==============//

//==============//
// DIZZY!! ??:O //
//==============//

//== Grey i would nearly consider ur horrible style a sin against nature itself... No offence...

exec("comchatfuncs.cs");

$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function timeupdate()
{
	showcurrenttime();
	messageall(3, $adminbotname@": Current Server Time :- "@$CurrentTime@"~wmine_act.wav");
	messageall(3, $adminbotname@": Current Date :- "@$CurrentDate);
}
function updatetime()
{
	showcurrenttime();
}
function helpmore(%clientId)
{
	//== Dont you think this [ V V V ] is much easier to read?

	%String[0] = "<jl><f1>* * *<f0> H E L P<f1> * * *\n<f0>The functions are as follows:\n";
	%String[1] = "<jl><f1>4. <f2>!overall <f1>- Retrieves your total saved scores from my database.\n";
	%String[2] = "<f1>5. <f2>!renew <f1>- Sets your Overall scores to 0\n";
	%String[3] = "<f1>5. <f2>!delete <f1>- Deletes your account.";

	%final = %String[0] @ %String[1] @ %String[2] @ %String[3];
	centerprint(%clientId,%final, 15);
}

function passwordinform(%clientId)
{
	%clname = Client::getName(%clientId);
	messageallExcept(%clientId, 1, $adminbotname@ ": "@%clname@", I have checked your status and you need to place a password in your 'Other Info' section in player setup.");
	client::sendMessage(%clientId, 1, $adminbotname@ ": I have checked YOUR status and you need to place a password in your 'Other Info' section in player setup.");
}			

function welcome(%clientId)
{
	%clname = Client::getName(%clientId);
	messageall(1, $adminbotname@ ": Welcome "@%clname@" I have now begun to track your scores. ~wmale1.whello.wav");
}			

//== Remodeled... VRWarper
function judge(%ratio, %clientId)
{
	%clname = Client::getName(%clientId);
	if(%ratio < 10)
		%msg = radnomItems(2, "Get off my server you IDIOT ~wmale1.wdsgst2.wav", "Remember, try shooting once in a while ~wmale3.wdsgst2.wav");
	else if (%ratio >= 10 && %ratio < 20)
		%msg = radnomItems(2, "<--ROFL look at his ratio !~wfall_scream.wav", "Try aiming at something once in a while!~wfemale3.wdsgst2.wav");
	else if(%ratio >= 20 && %ratio < 30)
		%msg = radnomItems(2, "Sure your playin' Tribes?~wmale1.wneedrep.wav", "Sure you can handle this alone?~wmale1.wneedrep.wav");
	else if(%ratio >=30 && %ratio < 40)
		%msg = radnomItems(2, "What a Lame Ass player~wmale1.whelp.wav", "Newbie attack!~wfemale1.whelp.wav");
	else if(%ratio >=40 && %ratio < 50)
		%msg = radnomItems(2, "Distinctly Average~wmale1.wdsgst5.wav", "Too good to be a sucker, too bad to be a winner...~wmale3.wdsgst5.wav");
	else if(%ratio >=50 && %ratio < 60)
		%msg = radnomItems(2, "Need some practice~wmale1.woops1.wav", "Practice makes perfect =D~wfemale1.woops1.wav");
	else if(%ratio >=60 && %ratio < 70)
		%msg = radnomItems(2, "Keep goin' to the Shootin Range~wmale1.wwshoot.wav", "Keep on going till you hit the TOP!~wfemale3.wwshoot.wav");
	else if(%ratio >=70 && %ratio < 80)
		%msg = radnomItems(2, "Good Shootin' Cowboy ~wmale1.wcheer2.wav", "Sharp Shootin' Cowboy ~wmale1.wcheer2.wav");
	else
		%msg = radnomItems(2, "Top Gun ~wmale1.wcheer3.wav", "Your THE ONE!!! ~wmale3.wcheer3.wav");

	messageall(3, $adminbotname@ " Rating for "@%clname@": "@%msg);
}
function judge2(%ratio2, %clientId)
{
	%clname = Client::getName(%clientId);
	if(%ratio2 < 10)
		%msg = radnomItems(2, "Get off my server you IDIOT ~wmale1.wdsgst2.wav", "Remember, try shooting once in a while ~wmale3.wdsgst2.wav");
	else if (%ratio2 >= 10 && %ratio2 < 20)
		%msg = radnomItems(2, "<--ROFL look at his ratio !~wfall_scream.wav", "Try aiming at something once in a while!~wfemale3.wdsgst2.wav");
	else if(%ratio2 >= 20 && %ratio2 < 30)
		%msg = radnomItems(2, "Sure your playin' Tribes?~wmale1.wneedrep.wav", "Sure you can handle this alone?~wmale1.wneedrep.wav");
	else if(%ratio2 >=30 && %ratio2 < 40)
		%msg = radnomItems(2, "What a Lame Ass player~wmale1.whelp.wav", "Newbie attack!~wfemale1.whelp.wav");
	else if(%ratio2 >=40 && %ratio2 < 50)
		%msg = radnomItems(2, "Distinctly Average~wmale1.wdsgst5.wav", "Too good to be a sucker, too bad to be a winner...~wmale3.wdsgst5.wav");
	else if(%ratio2 >=50 && %ratio2 < 60)
		%msg = radnomItems(2, "Need some practice~wmale1.woops1.wav", "Practice makes perfect =D~wfemale1.woops1.wav");
	else if(%ratio2 >=60 && %ratio2 < 70)
		%msg = radnomItems(2, "Keep goin' to the Shootin Range~wmale1.wwshoot.wav", "Keep on going till you hit the TOP!~wfemale3.wwshoot.wav");
	else if(%ratio2 >=70 && %ratio2 < 80)
		%msg = radnomItems(2, "Good Shootin' Cowboy ~wmale1.wcheer2.wav", "Sharp Shootin' Cowboy ~wmale1.wcheer2.wav");
	else
		%msg = radnomItems(2, "Top Gun ~wmale1.wcheer3.wav", "Your THE ONE!!! ~wmale3.wcheer3.wav");

	messageall(3, $adminbotname@ ": Rating for "@%clname@": "@%msg);
}

function checkMessage(%clientId, %team, %message)
{
	//== Specify NEEDED varibles
	%numClients = getNumClients();
	%cl = Player::getClient(%clientId);	
	%kills = %clientId.scoreKills;
	%deaths = %clientId.scoreDeaths;
	if((%clientId.scoreKills + %clientId.scoreDeaths) >= 1)
		%ratio = floor((%clientId.scoreKills/(%clientId.scoreKills + %clientId.scoreDeaths))*100);
   	else
   		%ratio = "0";

	//== Umm.. God help grey.... :P
	%score2 = %clientId.TotalScore + %clientId.score;	
	%kills2 = %clientId.TotalKills + %clientId.scoreKills;
	%deaths2 = %clientId.TotalDeaths + %clientId.scoreDeaths;
	if((%kills2 + %deaths2) >= 1)
		%ratio2 = floor((%kills2/(%kills2 + %deaths2))*100);
   	else
   		%ratio2 = "0";

	%clname = Client::getName(%clientId);

	//== Start checking for special commands -- VRWarper ( <<-- He thinks He is SOOOO Special hehe Likes his own name)
	if(string::getsubstr(%message, 0, 10) == "!register") 
    		{
	    if((Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId))) 
		{
	      	client::sendmessage(%clientId,1, $adminbotname @": You cannot use this function while you are not in control of your body! ~waccess_denied.wav");
			return;
		}
		   if(!%clientId.isregistered)
		   {
			if ($Client::info[%clientId, 5] == "")
			{
				SaveCharacter(%clientId);
				messageall(1, $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav");
				schedule("passwordinform("@%clientId@");", 3);
			}
			else
			{
				if(isFile("config\\" @ hashname(Client::getName(%clientId)) @ ".cs")) // PORT (2026-10-12): a saved profile already exists under this name and its password did not match
				{
					client::sendmessage(%clientId,1, $adminbotname @": That name is already registered under another password. ~waccess_denied.wav");
					return;
				}
				messageall(1,  $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav");
				schedule("welcome("@%clientId@");", 6);
				%clientId.isregistered = true;
				schedule("DisplaySmurfbot("@%clientId@");", 3);
				SaveCharacter(%clientId, %bot);
				centerprint(%clientId,"<jc><f1>* * *<f0> W E L C O M E<f1> * * *\n<f1>Congradulations your scores have been added to my DataBase and will be tracked. \nType <f2>!help <f1>for info");
			}
		}
		else 
		{
			messageall(1,  $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav");
			messageall(1, $adminbotname@ ": You are already registered in my DataBase "@%clname@"~waccess_denied.wav");
		}
	}
	else if(string::getsubstr(%message, 0, 8) == "!rating")
	{
		messageall(3, "Mission Rating for "@%clname@" : [ "@%kills@" ] Kills, [ "@%deaths@" ] Death(s). ~wbxplo2.wav");
		messageall(3, "Mission Efficiency for "@%clname@" : [ "@%ratio@"% ]");
		schedule("judge(" @%ratio@ ", " @%clientId@ ");", 5);
	}
	else if(string::getsubstr(%message, 0, 4) == "!afk" && %clientId.isSuperAdmin)
      {
		messageall(1, $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav");
		messageall(1, $adminbotname@ ": "@%clname@" - Is A.F.K and in my Protection.~wmine_act.wav");
		%clientId.isafk = true;
	}
	else if(string::getsubstr(%message, 0, 6) == "!cloak" && %clientId.isSuperAdmin)
      {
		%time = getWord(%message, 1);
		%client = Player::getClient(%clientId);
		if(%time == "-1")
			%time = 60;
		Admin::Cloak(%clientId, %client, %time);
		GameBase::playSound(%clientId,ForceFieldOpen,0);
		return true;
	}
	else if(string::getsubstr(%message, 0, 13) == "!clearbanlist" && %clientId.isGrey)
      {
		%type = getWord(%message,  1);
		if(%type == "sh")
		{
			SHClearBanlist();
			Client::sendMessage(%clientId,1,$adminbotname@": All IP Bans Are now cleared. Except manual host preset ones.");
			return true;
		}
		else if(%type == "tag")
		{
			GBClearTagBanList();
			Client::sendMessage(%clientId,1,$adminbotname@": All TAG Bans Are now cleared. Except manual host preset ones.");
			return true;
		}
		else if(%type == "name")
		{
			GBClearNameBanList();
			Client::sendMessage(%clientId,1,$adminbotname@": All NAME Bans Are now cleared. Except manual host preset ones.");
			return true;
		}
	}

	else if(String::findSubStr(getWord(%message, 0), "!kick") != "-1" && %clientId.isSuperAdmin) 
	{
		%name = getWord(%message,  1);
		for(%i = 2; getWord(%message,  %i) != "-1"; %i++)
		{
			%name = %name @ " " $+ getWord(%message,  %i);
		}
		if(%name != "")
		{
			botkick(%clientId, %name);
			return true;
		}
	}
	else if(String::findSubStr(getWord(%message, 0), "!ban") != "-1" && %clientId.isSuperAdmin) 
	{
		%name = getWord(%message,  1);
		for(%i = 2; getWord(%message,  %i) != "-1"; %i++)
		{
			%name = %name @ " " $+ getWord(%message,  %i);
		}
		if(%name != "")
		{
			aquirebotban(%name, %clientId);
			return true;
		}
	}
	else if(String::findSubStr(getWord(%message, 0), "!mode") != "-1" && %clientId.isSuperAdmin) 
	{
		%mode = getWord(%message,  1);
		if(%mode != "")
		{
			if(%mode == "-m")
			{
				$ScanMode = false;
				messageall(1,$adminbotname@": Scan Mode is Now inactive. ~wshieldhit.wav");
				return true;
			}
			else if(%mode == "+m")
			{
				$ScanMode = true;
		   		messageall(1,$adminbotname@": Scan Mode is Now ACTIVE. Only Allowed Clan Tags will be permitted to join. ~wmine_act.wav");
				return true;
			}
			else
			{
				client::sendmessage(%clientId,1,$adminbotname@": Wrong function called. !mode is only +m (To Scan Connections) or -m (To stop scans).");
				return true;
			}
		
		}
	}

	else if(String::findSubStr(getWord(%message, 0), "!tagban") != "-1" && %clientId.isSuperAdmin) 
	{
		%name = getWord(%message,  1);
		for(%i = 2; getWord(%message,  %i) != "-1"; %i++)
		{
			%name = %name @ " " $+ getWord(%message,  %i);
		}
		if(%name != "")
		{
			bottagban(%name, %clientId);
			return true;
		}
	}
	else if(String::findSubStr(getWord(%message, 0), "!nameban") != "-1" && %clientId.isSuperAdmin) 
	{
		%name = getWord(%message,  1);
		for(%i = 2; getWord(%message,  %i) != "-1"; %i++)
		{
			%name = %name @ " " $+ getWord(%message,  %i);
		}
		if(%name != "")
		{
			botnameban(%name, %clientId);
			return true;
		}
	}
	else if(String::findSubStr(getWord(%message, 0), "!giveme") != "-1" && %clientId.isSuperAdmin) 
	{
		%item = getWord(%message,  1);
		%give = CheckItem(%item);
		%amount = getWord(%message, 2);
		if($ItemExist)
		{
			Player::setItemCount(%clientId,%give,%amount);
			client::sendMessage(%clientId,3,$adminbotname@": You now have "@%amount@" "@%give@"'s. ~wmine_act.wav");
			return true;
		}
		else if(!$ItemExist && %item != "favs")
		{
			client::sendMessage(%clientId,1,$adminbotname@": "@%item@" is not in my DataBase ~waccess_denied.wav");
			return true;
		}
		else if(%item == "favs")
		{
			%person = %amount;
			gimmefavs(%clientId, %person);
			return true;
		}
		else if(%item == "-1" || %amount == "-1")
		{
			client::Sendmessage(%clientId,1,$adminbotname@": You have not selected either and Item or an amount. ~waccess_denied.wav");
		}
	}
	else if(String::findSubStr(getWord(%message, 0), "!playerlimit") != "-1" && %clientId.isAdmin) 
	{
		if(getWord(%message, 0) != "-1")
		{
			%amount = floor(getWord(%message, 1)); // PORT: was any text
			$Server::MaxPlayers = %amount;
			server::storedata();
			messageall(3,$adminbotname@": The Server Is now limited to "@%amount@" players. ~wmine_act.wav");
		}
		return true;
	}
	else if(String::findSubStr(getWord(%message, 0), "!cleanup") != "-1" && %clientId.isAdmin) 
	{
		echo("KICK ALL CALLED :- "@Client::getName(%clientId));
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.isAdmin)
			{
				%name = Client::getName(%cl);
				echo("Admin Found Not Kicking - "@%name);
				%yes = false;
			}
			else
			{
				%client = Player::getClient(%cl);
				client::sendmessage(%client,1,$adminbotname @": You are kicked by order of a Super-Admin with my authorisation");
				client::sendmessage(%clientId,1,$adminbotname @": Authorised... kicking All NON-Admins");
				echo($adminbotname @": -->>WARNING<<-- ComChatKickAll");
				HaVoCKick(%client);
				%yes = true;
			}
		}
		if(%yes)
		{
				client::sendmessage(%clientId,1,$adminbotname @": Authorised... kicking All NON-Admins ~wmine_act.wav");
		}
		return true;
	}
	else if(string::getsubstr(%message, 0, 7) == "!renew")
	{
		messageall(1, $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav");
		messageall(1, $adminbotname@ ": "@%clname@" - Renewing Scores ~wmine_act.wav");
		schedule("Renew("@%clientId@");", 3);
	}
	else if(string::getsubstr(%message, 0, 5) == "!time")
	{
		showclienttime(%cl);
		return true;
		
	}
	else if(string::getsubstr(%message, 0, 10) == "!viewadmin")
	{
		%supers = 0;
		%admins = 0;
		%masters = 0;

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
		      if(%cl.isGrey)
			{
				%adminstat = %adminstat @ "\n<f1>Master - <f0>" @ Client::GetName(%cl);
				%masters = %masters + 1;
			}
			else if(%cl.isSuperAdmin == true)
			{
				%adminstat = %adminstat @ "\n<f1>Super - <f0>" @ Client::GetName(%cl);
				%supers = %supers + 1;
			}
			else if(%cl.isAdmin)
			{
				%adminstat = %adminstat @ "\n<f1>Admin - <f0>" @ Client::GetName(%cl);
				%admins = %admins + 1;
			}
			
		}
		if(%clientId.isSuperAdmin)
		{
				centerprint(%clientId, "<jc><f0>= <f2>* <f1>= <f2>ADMIN LIST <f1>= <f2>* <f0>=\n" @ %adminstat, 10);
				return;
		} 
		else 
		{
				centerprint(%clientId, "<jc><f0>= <f2>* <f1>= <f2>ADMIN STATS <f1>= <f2>* <f0>=\n\n<f2>- Currently -<f1>\n" @%masters @ " <f0> Master-Admins <f1>\n" @ %supers @ " <f0> Super-Admins<f1>\n" @ %admins @ " <f0> Public-Admins", 10);
				return;
		}
		
	}
	else if(string::getsubstr(%message, 0, 8) == "!greybot")
	{
		echo("Outputting Spec.");
		OutPutBotInfo();
	}
	else if(string::getsubstr(%message, 0, 10) == "!retrieve")
	{
		messageall(1, $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav");
		messageall(1, $adminbotname@ ": "@%clname@" - Retrieving Scores ~wmine_act.wav");
		schedule("Retrieve("@%clientId@");", 3);

	}

	else if(string::getsubstr(%message, 0, 6) == "!help")
	{
		centerprint(%clientId,"<jl><f1>* * *<f0> H E L P<f1> * * *\n<f0>The functions are as follows: \n<f1>1. <f2>!register <f1>- Allows me to track your scores.\n<f1>2. <f2>!w00 <f1>- Gives a server update. \n<f1>3. <f2>!rating <f1>- Retrieves your mission scores from my database.", 0);
		schedule("helpmore("@%clientId@");", 10);
	}
	else if(string::getsubstr(%message, 0, 8) == "!delete")
	{
		messageall(1, $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav");
		messageall(1, $adminbotname@ ": "@%clname@" - Deleting Account ~wmine_act.wav");
		schedule("DeleteAcc("@%clientId@");", 3);
	}
	else if(string::getsubstr(%message, 0, 6) == "!stop" && %clientId.isAdmin) 
	{
		messageall(1, $adminbotname@ ": Ok "@%clname@"... I am applying Gravitron Brakes to you ~wteleport2.wav");
		Item::setVelocity(%clientId, "0 0 0"); 
	}

	else if(string::getsubstr(%message, 0, 8) == "!deltry" && %clientId.isSuperAdmin)
	{
		Client::sendMessage(%clientId,1, $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav");
		Client::sendMessage(%clientId,1, $adminbotname@ ": "@%clname@" - Deleting Password Attempts ~wmine_act.wav");
		schedule("DeletePassAcc("@%clientId@");", 3);
	}
	else if(string::getsubstr(%message, 0, 9) == "!overall")
	{
		if(%clientId.isregistered)
		{
			messageall(3, "OverAll Rating for "@%clname@" : [ "@%kills2@" ] Kills, [ "@%deaths2@" ] Death(s). ~wbxplo2.wav");
			messageall(3, "OverAll Efficiency for "@%clname@" : [ "@%ratio2@"% ]");
			schedule("judge2(" @%ratio2@ ", " @%clientId@ ");", 5);
		}
		else
			Client::SendMessage(%clientId,3, "You must register to have your scores tracked. Type: !register");
	}
	else if(string::getsubstr(%message, 0, 4) == "!msg"  && %clientId.isSuperAdmin)
	{
		%message = string::getsubstr(%message, 4, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%message = string::getsubstr(%message, 1, 999);
			messageall(1, $adminbotname @": "@%message);
			echo($adminbotname @": Admin voice control -" @Client::getName(%clientId));
			return true;
		}
	}
	else if(string::getsubstr(%message, 0, 5) == "!anon"  && %clientId.isSuperAdmin)
	{
		%message = string::getsubstr(%message, 5, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%type = getWord(%message,  0);
			%mes = getWord(%message, 1); 
               	for(%i = 2; getWord(%message, %i) != "-1"; %i++)
                { 
                    %mes = %mes$+" "$+getWord(%message, %i); 
                }
	
			if(%type == "0" || %type == "1" || %type == "2" || %type == "3" || %type == "4")
			{
				%message = string::getsubstr(%message, 3, 999);
				messageall(%type, ""@%message@"");
			}
			else if(%type != "")
			{
			
				impersonate(%clientId, %type, %mes);
			
			}
			
		}
		return true;
	}
	else if(string::getsubstr(%message, 0, 6) == "!admin" && %clientId.isAdmin)
	{
		%message = string::getsubstr(%message, 6, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%message = string::getsubstr(%message, 1, 999);
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.isAdmin)
				{
					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": Admin] "@%message@"~wmine_act.wav");
				}
			}
			return true;
		}
	}
	else if(string::getsubstr(%message, 0, 5) == "!pmsg")
	{
		%message = string::getsubstr(%message, 5, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%person = getWord(%message,  0);
			%mes = getWord(%message, 1); 
               	for(%i = 2; getWord(%message, %i) != "-1"; %i++)
                	{ 
                    %mes = %mes$+" "$+getWord(%message, %i); 
                	}
			if(%person != "")
			{
				private(%clientId, %person, %mes);
			
			}
			
		}
		return true;
	}

	else if(string::getsubstr(%message, 0, 6) == "!super" && %clientId.isSuperAdmin)
	{
		%message = string::getsubstr(%message, 6, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%message = string::getsubstr(%message, 1, 999);
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.isSuperAdmin)
				{
					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": SuperChat] "@%message@"~wmine_act.wav");
				}
			}
			return true;
		}
	}
	else if(string::getsubstr(%message, 0, 7) == "!urgent")
	{
		%message = string::getsubstr(%message, 7, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%message = string::getsubstr(%message, 1, 999);
			$Urgent = Client::getName(%clientId)@": "@%message;
			echo("URGENT MESSAGE - "@$Urgent);
			export("$Urgent", "config\\urgent.txt" , true);
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.isSuperAdmin)
				{
					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": URGENT] "@%message@"~wmine_act.wav");
				}
			}
			return true;
		}
	}

	else if(string::getsubstr(%message, 0, 7) == "!master" && %clientId.isGrey)
	{
		%message = string::getsubstr(%message, 7, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%message = string::getsubstr(%message, 1, 999);
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.isGrey)
				{
					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": Master] "@%message@"~wmine_act.wav");
				}
			}
			return true;
		}
	}

	else if(string::getsubstr(%message, 0, 1) == "=" && string::getsubstr(%message, 2, 1) != "")
	{
		%message = string::getsubstr(%message, 1, 999);
		if(string::getsubstr(%message, 0, 1) == ">" && %clientId.isSuperAdmin)
		{
			%message = string::getsubstr(%message, 1, 999);
			centerprintall("<jc><f2>"@%message, 7);
			return true;
		}
		if(%clientId.speakto != "")
		{
			if(%clientId.isSuperAdmin)
			{
				if(string::getsubstr(%message, 0, 1) == "=" && %clientId.isSuperAdmin)
				{
					%message = string::getsubstr(%message, 1, 999);
					centerprint(%clientId.speakto, "<jc><f0>"@Client::getName(%clientID)@" (private):\n<f1>"@%message, 8);
				}
				Client::sendMessage(%clientId.speakto,3, Client::getName(%clientID)@" (private): "@%message);
				Client::sendMessage(%clientId,1, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message);
			}
			else if((Client::getTeam(%clientId) != -1 || $Game::missionType == "Duel") && !(%clientId.speakto).muted[%clientId])
			{
				if(!(%clientId.speakto).isSuperAdmin && Client::getTeam(%clientId) != Client::getTeam(%clientId.speakto))
					cheatAdminMsg(Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message);
				if(!(%clientId.speakto).isSuperAdmin && $listen[%clientId] != "")
					Client::sendMessage($listen[%clientId], 1, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message);
	
				Client::sendMessage(%clientId.speakto,3, Client::getName(%clientID)@" (private): "@%message);
				Client::sendMessage(%clientId, 1, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message);
			}
			%message = escapeString(%message);
			echo("SAY: " @ %clientId @ " \""@Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message@"\"");
			return true;
		}
	}
	else if(String::findSubStr(getWord(%message, 0), "#id") != "-1" && %clientId.isSuperAdmin) // PORT: was open to every player 
	{
		%name = getWord(%message,  1);
		for(%i = 2; getWord(%message,  %i) != "-1"; %i++)
		{
			%name = %name @ " " $+ getWord(%message,  %i);
		}
		if(%name != "")
		{
			outPutSpecInfo(%clientId, %name);
			return true;
		}
	}
	else if(string::getsubstr(%message, 0, 5) == "!w00")
		centerprint(%clientId,"<jc><f1>* * * <f2>U P D A T E <f1>* * * \n<f0>Server Name: <f1>"@ $Server::HostName@"\n<f0>Number of Players Connected: <f1>" @%numclients@"\n <f0>Current Modification: <f1>"@$Meltdown::Version@"\n <f0>=(w00)= HomePage: <f1>www.w00.cjb.net");

	return false;
}

//== OMG GOD HELP ME!!!  -- VRWarper

function remoteSay(%clientId, %team, %message)
{
   %message = String::getSubStr(%message, 0, 240); // PORT: stock 1.11 length cap, missing from this older copy
	
	%bug = %message;
	%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

	if(%clientId.isafk){
		%clientId.isafk = false;
		messageall(1, $adminbotname @": "@Client::getName(%clientId)@" is now back and may be hurt");
		
	}

	if(%clientId.gag) 
	{
		Client::sendMessage(%clientId, 1, "You are gagged by order of a Super-Admin.~waccess_denied.wav");
		centerprint(%clientId, "<jc><f1>Damn dont you hate it when your mouth doesn't work!!??", 0);
		return;
	}

	

	// check for flooding if it's a broadcast OR if it's team in FFA
	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
	{
		// we use getIntTime here because getSimTime gets reset.
		// time is measured in 32 ms chunks... so approx 32 to the sec
		%time = getIntegerTime(true) >> 5;
		if(%clientId.floodMute)
		{
			%delta = %clientId.muteDoneTime - %time;
			if(%delta > 0)
			{
				Client::sendMessage(%clientId, $MSGTypeGame, $adminbotname@": Foo!!! You cannot talk for " @ %delta @ " seconds. ~wacess_denied.wav");
				return;
			}
			%clientId.floodMute = "";
			%clientId.muteDoneTime = "";
		}
		%clientId.floodMessageCount++;
		// funky use of schedule here:
		schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
		if(%clientId.floodMessageCount > 4)
		{
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 20;
			Client::sendMessage(%clientId, $MSGTypeGame, $adminbotname@": Foo!!! You cannot talk for 20 seconds.");
			return;
		}
		

	}
	if(checkMessage(%clientId, %team, %message))
		return;

	if(%team)
	{
		if($dedicated)
			echo("SAYTEAM: " @ %msg);

		%team = Client::getTeam(%clientId);
		NearBug(%clientId, %bug);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if((Client::getTeam(%cl) == %team && !%cl.muted[%clientId]) || (Client::getTeam(%cl) != %team && %cl.isSuperAdmin))
		{
			if(Client::getTeam(%cl) != %team && %cl.isSuperAdmin)
			{
				Client::sendMessage(%cl, $MsgTypeGame, %message, %clientId);
			}
			else
			{
				Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
			}
		}
		else if(Player::getMountedItem(%cl, $BackpackSlot) == BugPack)
		{
			Client::sendMessage(%cl, $MsgTypeGame, %message, %clientId);
		}
	}
	else
	{
		if($dedicated)
			echo("SAY: " @ %msg);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(!%cl.muted[%clientId])
				Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
	}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if($dedicated)
		echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
	// issueCommandI takes waypoint 0-1023 in x,y scaled mission area
	// issueCommand takes float mission coords.
	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
		if(!%dest[%i].muted[%commander])
		{
			issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
			//echo("Dest: " @ %dest[%i]);
			%waypoint= %WayX @ " " @ %WayY;   
			//Client::sendMessage(%dest[%i],1,"Dest: " @ %dest[%i] @ " " @ %i);
			%commandee = %dest[%i];
			$point[%commandee] = %waypoint;
			//Client::sendMessage(%dest[%i],1,"Waypoint: " @ $point[%commandee]);
		}	    
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if($dedicated)
		echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
		if(!%dest[%i].muted[%commander])
			issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
	// setCommandStatus returns false if no status was changed.
	// in this case these should just be team says.
	if(setCommandStatus(%clientId, %status, %message))
	{
		if($dedicated)
		echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\"");
	}
	else
		remoteSay(%clientId, true, %message);
}

function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%id = getClientByIndex(%i);
      	if(Client::getTeam(%id) == %team1)
      	{
      		Client::sendMessage(%id, %mtype, %message1);
		}
		else if(%message2 != "" && Client::getTeam(%id) == %team2)
		{
			Client::sendMessage(%id, %mtype, %message2);
		}
		else if(%message3 != "")
		{
			Client::sendMessage(%id, %mtype, %message3);
		}
	}
}

function messageAll(%mtype, %message, %filter)
{
	if(%filter == "")
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			Client::sendMessage(%cl, %mtype, %message);
	else
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.messageFilter & %filter)
				Client::sendMessage(%cl, %mtype, %message);
		}
	}
}

function messageAllExcept(%except, %mtype, %message)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(%cl != %except)
			Client::sendMessage(%cl, %mtype, %message);
}

function NearBug(%clientId, %message)
{
	%player = Client::getTeam(%clientId);
	%pos = GameBase::getPosition(%clientId);
	%set = newObject("set",SimSet);
	%mask = $StaticObjectType;
	%num = containerBoxFillSet(%set,%mask,%pos,300,300,300,0);
	%num = CountObjects(%set,"DeployableBug",%num);

	if(%num > 0)
	{
		for(%count = 0; %index != -1; %count++)
		{
			%index = Group::getObject(%set, %count);
			if(%index != -1)
		 	{
				%name = GameBase::getDataName(%index);
				%team = GameBase::getTeam(%index);
				if(%name == "DeployableBug")
				{
					if(%team != %player)
					{
						for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					      if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
					            Client::sendMessage(%cl,1,"Enemy Transmission: "@ %message @"~waccess_denied.wav");
					}
				}
			}
		}
	}
	deleteObject(%set);
}
exec("saveinfo.cs");
exec("TagBanList.cs");
exec("NameBanList.cs");
exec("givemefuncs.cs");

