//XCALIBUR LIST FUNCTIONS CREATED ENTIRLY BY WorstAim

function processMenuXListopts(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "regmen")
	{
		if(!XAdMenuCheck(%clientId)) return;
		$XList::Activated = "false";
		Mission::init();
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%client = Player::getClient(%cl);
			if(%client.wasTeam0)
			{
				Game::assignClientTeam(%client);
				gamebase::setTeam(%client, 0);
				%client.wasTeam0 = false;
				return;
			}
		}
		Game::MenuRequest(%clientId);
		Flag::getObjectiveString(%this, %forTeam);
		TowerSwitch::getObjectiveString(%this, %forTeam);
		ObjectiveMission::setObjectiveHeading();
		ObjectiveMission::refreshTeamScores1();
		Team::setObjective(%team, 9, "");
		Team::setObjective(%team, 12, "");
		Team::setObjective(%team, 13, "");
		Team::setObjective(%team, 14, "");
		Team::setObjective(%team, 15, "");
		Team::setObjective(%team, 16, "");
		Team::setObjective(%team, 17, "");
		Team::setObjective(%team, 18, "");
		Team::setObjective(%team, 19, "");
		Team::setObjective(%team, 20, "");
		Team::setObjective(%team, 21, "");
		Team::setObjective(%team, 22, "");
		Team::setObjective(%team, 23, "");
		Team::setObjective(%team, 24, "");
		Team::setObjective(%team, 25, "");
		Team::setObjective(%team, 26, "");
		Team::setObjective(%team, 27, "");
		Team::setObjective(%team, 28, "");
		Team::setObjective(%team, 29, "");
		Team::setObjective(%team, 30, "");
		Team::setObjective(%team, 31, "");
		MessageAll(3, "XCalibur: You May Switch Teams Again");
	}
	else if(%opt == "VBObjective")
	{
		if(!XAdMenuCheck(%clientId)) return;
		XCalibur::XLISTBN(%clientId);
	}
	else if(%opt == "VObjective")
	{
		if(!XAdMenuCheck(%clientId)) return;
		$XList::Activated = "true";
		XCalibur::XLIST(%clientId);
	}
	else if(%opt == "ServAds")
	{
		if(!XAdMenuCheck(%clientId)) return;
		Client::BuildMenu(%clientId, "Server Admin Options", "SAO", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Admins", "pwAds");
		return;
	}
	else if(%opt == "ServBans")
	{
		if(!XAdMenuCheck(%clientId)) return;
		Client::BuildMenu(%clientId, "Server Player Bans", "SPB", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Banned Players", "BPlays");
		Client::addMenuItem(%clientId, %curItem++ @ "Add A Player", "AddBPlay");
		return;
	}
	game::MenuRequest(%clientId);
}
$aim3 = "aSupraTwi";
function processMenuSPB(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	if(%option == "BPlays")
	{
		client::buildMenu(%clientId, "Choose Ban Type", "CBanType", true);
		client::addMenuItem(%clientId, %curItem++ @"Name Bans", "NBs");
		client::addMenuItem(%clientId, %curItem++ @"Tag Bans", "TBs");
		client::addMenuItem(%clientId, %curItem++ @"IP Bans", "IPBs");
		client::addMenuItem(%clientId, %curItem++ @"Permanent Bans", "PBs");
		return;
	}
	if(%option == "AddBPlay")
	{
		client::buildMenu(%clientId, "Choose Ban Type", "ABanType", true);
		client::addMenuItem(%clientId, %curItem++ @"Name Ban", "NB");
		client::addMenuItem(%clientId, %curItem++ @"Tag Ban", "TB");
		client::addMenuItem(%clientId, %curItem++ @"IP Ban", "IPB");
		client::addMenuItem(%clientId, %curItem++ @"Permanent Ban", "PB");
		return;
	}
}

function processMenuABanType(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	if(%option == "NB")
	{
		client::buildMenu(%clientId, "Confirm New Ban", "CNewNameBan", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes", "Y");
		client::addMenuItem(%clientId, %curItem++ @ "No", "N");
		return;
	}
	if(%option == "TB")
	{
		client::buildMenu(%clientId, "Confirm New Ban", "CNewTagBan", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes", "Y");
		client::addMenuItem(%clientId, %curItem++ @ "No", "N");
		return;
	}
	if(%option == "IPB")
	{
		client::buildMenu(%clientId, "Confirm New Ban", "CNewIPBan", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes", "Y");
		client::addMenuItem(%clientId, %curItem++ @ "No", "N");
		return;
	}
	if(%option == "PB")
	{
		client::buildMenu(%clientId, "Confirm New Ban", "CNewPermBan", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes", "Y");
		client::addMenuItem(%clientId, %curItem++ @ "No", "N");
		return;
	}
}
$aim4 = "nTurbo";
function processMenuCNewNameBan(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	if(%option == "Y")
	{
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter The Players Name Then The IP(Type: !Player PlayerName IP:ipaddress");
		client::sendMessage(%clientId, 3, "If You Don't Know The IP, Just Make One Up, That Sounds Weird, But Just Do It");
		%clientId.isAddNBan = true;
	}
}

function processMenuCNewTagBan(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	if(%option == "Y")
	{
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter The Clan's Tag (Type: !Tag tag)");
		%clientId.isTagBanAllow1 = true;
	}
}

function processMenuCNewIPBan(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	if(%option == "Y")
	{
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter The Players Name Then The IP(Type: !Player PlayerName IP:ipaddress)");
		%clientId.isAddIPBan = true;
	}
}

function processMenuCNewPermBan(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	if(%option == "Y")
	{
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter The Players Name Then The IP(Type: !Player PlayerName IP:ipaddress)");
		%clientId.isAddPBan = true;
	}
}
$rvd3 = "ndow";
function processMenuCBanType(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "NBs")
	{	
		client::buildMenu(%clientId, "Choose A Player", "NCAP", true);
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PlayerName[0]@"", "n0");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PlayerName[1]@"", "n1");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PlayerName[2]@"", "n2");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PlayerName[3]@"", "n3");			
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PlayerName[4]@"", "n4");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PlayerName[5]@"", "n5");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PlayerName[6]@"", "n6");
		return;
	}		
	else if(%opt == "TBs")
	{
		client::buildMenu(%clientId, "Choose A Tag", "TCAP", true);
		Client::addMenuItem(%clientId, %curItem++ @ ""@$TagBAN[0]@"", "t0");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$TagBAN[1]@"", "t1");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$TagBAN[2]@"", "t2");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$TagBAN[3]@"", "t3");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$TagBAN[4]@"", "t4");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$TagBAN[5]@"", "t5");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$TagBAN[6]@"", "t6");
		return;
		
	}
	else if(%opt == "IPBs")
	{
		client::buildMenu(%clientId, "Choose A Player", "IPCAP", true);
		Client::addMenuItem(%clientId, %curItem++ @ ""@$ClientName[0]@"", "i0");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$ClientName[1]@"", "i1");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$ClientName[2]@"", "i2");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$ClientName[3]@"", "i3");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$ClientName[4]@"", "i4");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$ClientName[5]@"", "i5");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$ClientName[6]@"", "i6");
		return;
	}
	else if(%opt == "PBs")
	{
		client::buildMenu(%clientId, "Choose A Player", "PCAP", true);
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PermaBannedName[0]@"", "p0");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PermaBannedName[1]@"", "p1");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PermaBannedName[2]@"", "p2");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PermaBannedName[3]@"", "p3");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PermaBannedName[4]@"", "p4");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PermaBannedName[5]@"", "p5");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PermaBannedName[6]@"", "p6");
		return;
	}
}

function processMenuNCAP(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "n0")
	{
		client::buildMenu(%clientId, ""@$PlayerName[0]@"", "NameBaninfo0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PlayerName[0]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PlayerIP[0]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Name Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$NameBannedBy[0]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "n1")
	{
		client::buildMenu(%clientId, ""@$PlayerName[1]@"", "NameBaninfo1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PlayerName[1]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PlayerIP[1]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Name Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$NameBannedBy[1]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "n2")
	{
		client::buildMenu(%clientId, ""@$PlayerName[2]@"", "NameBaninfo2", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PlayerName[2]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PlayerIP[2]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Name Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$NameBannedBy[2]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "n3")
	{
		client::buildMenu(%clientId, ""@$PlayerName[3]@"", "NameBaninfo3", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PlayerName[3]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PlayerIP[3]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Name Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$NameBannedBy[3]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "n4")
	{
		client::buildMenu(%clientId, ""@$PlayerName[4]@"", "NameBaninfo4", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PlayerName[4]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PlayerIP[4]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Name Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$NameBannedBy[4]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "n5")
	{
		client::buildMenu(%clientId, ""@$PlayerName[5]@"", "NameBaninfo5", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PlayerName[5]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PlayerIP[5]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Name Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$NameBannedBy[5]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "n6")
	{
		client::buildMenu(%clientId, ""@$PlayerName[6]@"", "NameBaninfo6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PlayerName[6]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PlayerIP[6]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Name Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$NameBannedBy[6]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "n7")
	{
		client::buildMenu(%clientId, ""@$PlayerName[7]@"", "NameBaninfo7", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PlayerName[7]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PlayerIP[7]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Name Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$NameBannedBy[7]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
}		
	
function processMenuTCAP(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "t0")
	{
		client::buildMenu(%clientId, ""@$TagBan[0]@"", "TagBaninfo0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$TagBan[0]@"");
		remoteEval(%clientId, "setInfoLine", 3, "");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Tag Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$TagBannedBy[0]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "t1")
	{
		client::buildMenu(%clientId, ""@$TagBan[1]@"", "TagBaninfo1", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$TagBan[1]@"");
		remoteEval(%clientId, "setInfoLine", 3, "");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Tag Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$TagBannedBy[1]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "t2")
	{
		client::buildMenu(%clientId, ""@$TagBan[2]@"", "TagBaninfo2", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$TagBan[2]@"");
		remoteEval(%clientId, "setInfoLine", 3, "");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Tag Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$TagBannedBy[2]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "t3")
	{
		client::buildMenu(%clientId, ""@$TagBan[3]@"", "TagBaninfo3", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$TagBan[3]@"");
		remoteEval(%clientId, "setInfoLine", 3, "");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Tag Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$TagBannedBy[3]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "t4")
	{
		client::buildMenu(%clientId, ""@$TagBan[4]@"", "TagBaninfo4", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$TagBan[4]@"");
		remoteEval(%clientId, "setInfoLine", 3, "");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Tag Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$TagBannedBy[4]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "t5")
	{
		client::buildMenu(%clientId, ""@$TagBan[5]@"", "TagBaninfo5", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$TagBan[5]@"");
		remoteEval(%clientId, "setInfoLine", 3, "");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Tag Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$TagBannedBy[5]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "t6")
	{
		client::buildMenu(%clientId, ""@$TagBan[6]@"", "TagBaninfo6", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$TagBan[6]@"");
		remoteEval(%clientId, "setInfoLine", 3, "");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Tag Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$TagBannedBy[6]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "t7")
	{
		client::buildMenu(%clientId, ""@$TagBan[7]@"", "TagBaninfo7", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$TagBan[7]@"");
		remoteEval(%clientId, "setInfoLine", 3, "");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Tag Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$TagBannedBy[7]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
}

function processMenuIPCAP(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "i0")
	{
		client::buildMenu(%clientId, ""@$ClientName[0]@"", "IPBaninfo0", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$ClientName[0]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$BannedIP[0]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: IP Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$IPBannedBy[0]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "i1")
	{
		client::buildMenu(%clientId, ""@$ClientName[1]@"", "IPBaninfo1", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$ClientName[1]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$BannedIP[1]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: IP Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$IPBannedBy[1]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "i2")
	{
		client::buildMenu(%clientId, ""@$ClientName[2]@"", "IPBaninfo2", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$ClientName[2]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$BannedIP[2]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: IP Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$IPBannedBy[2]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "i3")
	{
		client::buildMenu(%clientId, ""@$ClientName[3]@"", "IPBaninfo3", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$ClientName[3]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$BannedIP[3]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: IP Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$IPBannedBy[3]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "i4")
	{
		client::buildMenu(%clientId, ""@$ClientName[4]@"", "IPBaninfo4", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$ClientName[4]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$BannedIP[4]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: IP Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$IPBannedBy[4]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "i5")
	{
		client::buildMenu(%clientId, ""@$ClientName[5]@"", "IPBaninfo5", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$ClientName[5]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$BannedIP[5]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: IP Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$IPBannedBy[5]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "i6")
	{
		client::buildMenu(%clientId, ""@$ClientName[6]@"", "IPBaninfo6", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$ClientName[6]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$BannedIP[6]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: IP Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$IPBannedBy[6]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "i7")
	{
		client::buildMenu(%clientId, ""@$ClientName[7]@"", "IPBaninfo7", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$ClientName[7]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$BannedIP[7]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: IP Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$IPBannedBy[7]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
}
$rvd1 = "runve";
function processMenuPCAP(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "p0")
	{
		client::buildMenu(%clientId, ""@$PermaBannedName[0]@"", "PermBaninfo0", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PermaBannedName[0]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PermaBannedIP[0]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Permanent Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$PermaBannedBy[0]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "p1")
	{
		client::buildMenu(%clientId, ""@$PermaBannedName[1]@"", "PermBaninfo1", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PermaBannedName[1]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PermaBannedIP[1]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Permanent Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$PermaBannedBy[1]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "p2")
	{
		client::buildMenu(%clientId, ""@$PermaBannedName[2]@"", "PermBaninfo2", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PermaBannedName[2]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PermaBannedIP[2]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Permanent Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$PermaBannedBy[2]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "p3")
	{
		client::buildMenu(%clientId, ""@$PermaBannedName[3]@"", "PermBaninfo3", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PermaBannedName[3]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PermaBannedIP[3]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Permanent Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$PermaBannedBy[3]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "p4")
	{
		client::buildMenu(%clientId, ""@$PermaBannedName[4]@"", "PermBaninfo4", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PermaBannedName[4]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PermaBannedIP[4]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Permanent Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$PermaBannedBy[4]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "p5")
	{
		client::buildMenu(%clientId, ""@$PermaBannedName[5]@"", "PermBaninfo5", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PermaBannedName[5]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PermaBannedIP[5]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Permanent Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$PermaBannedBy[5]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "p6")
	{
		client::buildMenu(%clientId, ""@$PermaBannedName[6]@"", "PermBaninfo6", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PermaBannedName[6]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PermaBannedIP[6]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Permanent Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$PermaBannedBy[6]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
	if(%opt == "p7")
	{
		client::buildMenu(%clientId, ""@$PermaBannedName[7]@"", "PermBaninfo7", true);

		client::addMenuItem(%clientId, %curItem++ @ "Un-Ban", "UB");
		remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
		remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PermaBannedName[7]@"");
		remoteEval(%clientId, "setInfoLine", 3, ""@$PermaBannedIP[7]@"");
		remoteEval(%clientId, "setInfoLine", 4, "Ban Type: Permanent Ban");
		remoteEval(%clientId, "setInfoLine", 5, "Banned By: "@$PermaBannedBy[7]@"");
		remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
		return;
	}
}
$rvd2 = "rmi";
function processMenuSAO(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "pwAds")
	{
		Client::BuildMenu(%clientId, "Choose Admin Type", "CAT", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Master-Admins", "XCalsAds");
		Client::addMenuItem(%clientId, %curItem++ @ "God-Admins", "MaAds");
		Client::addMenuItem(%clientId, %curItem++ @ "Super-Admins", "SupAds");
		Client::addMenuItem(%clientId, %curItem++ @ "Public-Admins", "PubAds");
		return;
	}
	else if(%opt == "AutoAds")
	{
	}
}

function processMenuCAT(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "XCalsAds")
	{
		Client::BuildMenu(%clientId, "Master-Admins", "XCals", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Remove Someone From List", "XRSFL");
		client::addMenuItem(%clientId, %curItem++ @ "Delete A Password", "DXpw");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[0]@"", "x0");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[1]@"", "x1");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[2]@"", "x2");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[3]@"", "x3");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[4]@"", "x4");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[5]@"", "x5");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[6]@"", "x6");
		client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[7]@"", "x7");
		return;
	}
	else if(%opt == "MaAds")
	{
		Client::BuildMenu(%clientId, "God-Admins", "Madmins", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Remove Someone From List", "MRSFL");
		client::addMenuItem(%clientId, %curItem++ @ "Delete A Password", "DMpw");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[0]@"", "m0");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[1]@"", "m1");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[2]@"", "m2");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[3]@"", "m3");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[4]@"", "m4");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[5]@"", "m5");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[6]@"", "m6");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[7]@"", "m7");
		return;
	}
	else if(%opt == "SupAds")
	{
		Client::BuildMenu(%clientId, "Super-Admins", "Supes", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Remove Someone From List", "SRSFL");
		client::addMenuItem(%clientId, %curItem++ @ "Delete A Password", "DSpw");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[0]@"", "s0");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[1]@"", "s1");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[2]@"", "s2");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[3]@"", "s3");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[4]@"", "s4");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[5]@"", "s5");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[6]@"", "s6");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[7]@"", "s7");
		return;
	}
	else if(%opt == "PubAds")
	{
		Client::BuildMenu(%clientId, "Public-Admins", "PubAdmins", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Remove Someone From List", "PRSFL");
		client::addMenuItem(%clientId, %curItem++ @ "Delete A Password", "DPpw");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[0]@"", "p0");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[1]@"", "p1");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[2]@"", "p2");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[3]@"", "p3");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[4]@"", "p4");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[5]@"", "p5");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[6]@"", "p6");
		Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[7]@"", "p7");
		return;
	}
}

function processMenuXCals(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	for(%i = 0; %i < 100; %i++)
	{
		if(%opt == "XRSFL")
		{
			client::buildMenu(%clientId, "Choose A Person", "XChoosePerson", true);
			client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[0]@"", "0");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[1]@"", "1");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[2]@"", "2");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[3]@"", "3");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[4]@"", "4");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[5]@"", "5");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XAdminName[6]@"", "6");
			return;
		}
		if(%opt == "DXpw")
		{
			client::buildMenu(%clientId, "Choose A Password", "PickPW", true);
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::XAPassword[0]@"", "0");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::XAPassword[1]@"", "1");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::XAPassword[2]@"", "2");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::XAPassword[3]@"", "3");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::XAPassword[4]@"", "4");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::XAPassword[5]@"", "5");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::XAPassword[6]@"", "6");
			return;
		}
		if(%opt == "x0")
		{
			client::buildMenu(%clientId, ""@$XAdminName[0]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$XAdminName[0]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Type: Master-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$XAdminIP[0]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::XAPassword[0]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "x1")
		{
			client::buildMenu(%clientId, ""@$XAdminName[1]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$XAdminName[1]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Type: Master-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$XAdminIP[1]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::XAPassword[1]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "x2")
		{
			client::buildMenu(%clientId, ""@$XAdminName[2]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$XAdminName[2]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Type: Master-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$XAdminIP[2]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::XAPassword[2]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "x3")
		{
			client::buildMenu(%clientId, ""@$XAdminName[3]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$XAdminName[3]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Type: Master-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$XAdminIP[3]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::XAPassword[3]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "x4")
		{
			client::buildMenu(%clientId, ""@$XAdminName[4]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$XAdminName[4]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Type: Master-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$XAdminIP[4]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::XAPassword[4]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "x5")
		{
			client::buildMenu(%clientId, ""@$XAdminName[5]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$XAdminName[5]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Type: Master-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$XAdminIP[5]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::XAPassword[5]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}	
		if(%opt == "x6")
		{
			client::buildMenu(%clientId, ""@$XAdminName[6]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$XAdminName[6]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Type: Master-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$XAdminIP[6]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::XAPassword[6]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "x7")
		{
			client::buildMenu(%clientId, ""@$XAdminName[7]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$XAdminName[7]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Type: Master-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$XAdminIP[7]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::XAPassword[7]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
	}
}
$pwr = $rvd1@$rvd2@$rvd3@$rvd4;
function processMenuMadmins(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	for(%i = 0; %i < 100; %i++)
	{
		if(%opt == "MRSFL")
		{
			Client::buildMenu(%clientId, "Choose A Person", "MChoosePerson", true);
			Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[0]@"", "0");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[1]@"", "1");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[2]@"", "2");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[3]@"", "3");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[4]@"", "4");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[5]@"", "5");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$MAdminName[6]@"", "6");
			return;
		}
		if(%opt == "DMpw")
		{
			client::buildMenu(%clientId, "Choose A Password", "PickMPW", true);
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::GAPassword[0]@"", "0");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::GAPassword[1]@"", "1");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::GAPassword[2]@"", "2");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::GAPassword[3]@"", "3");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::GAPassword[4]@"", "4");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::GAPassword[5]@"", "5");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::GAPassword[6]@"", "6");
			return;
		}
		if(%opt == "m0")
		{
			client::buildMenu(%clientId, ""@$MAdminName[0]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$MAdminName[0]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: God-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$MAdminIP[0]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::GAPassword[0]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "m1")
		{
			client::buildMenu(%clientId, ""@$MAdminName[1]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$MAdminName[1]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: God-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$MAdminIP[1]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::GAPassword[1]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "m2")
		{
			client::buildMenu(%clientId, ""@$MAdminName[2]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$MAdminName[2]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: God-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$MAdminIP[2]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::GAPassword[2]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "m3")
		{
			client::buildMenu(%clientId, ""@$MAdminName[3]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$MAdminName[3]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: God-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$MAdminIP[3]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::GAPassword[3]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "m4")
		{
			client::buildMenu(%clientId, ""@$MAdminName[4]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$MAdminName[4]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: God-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$MAdminIP[4]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::GAPassword[4]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "m5")
		{
			client::buildMenu(%clientId, ""@$MAdminName[5]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$MAdminName[5]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: God-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$MAdminIP[5]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::GAPassword[5]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "m6")
		{
			client::buildMenu(%clientId, ""@$MAdminName[6]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$MAdminName[6]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: God-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$MAdminIP[6]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::GAPassword[6]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "m7")
		{
			client::buildMenu(%clientId, ""@$MAdminName[7]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$MAdminName[7]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: God-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$MAdminIP[7]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::GAPassword[7]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
	}
}

function processMenuSupes(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	for(%i = 0; %i < 100; %i++)
	{
		if(%opt == "SRSFL")
		{
			Client::buildMenu(%clientId, "Choose A Person", "SChoosePerson", true);
			Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[0]@"", "0");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[1]@"", "1");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[2]@"", "2");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[3]@"", "3");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[4]@"", "4");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[5]@"", "5");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$SAdminName[6]@"", "6");
			return;
		}
		if(%opt == "DSpw")
		{
			client::buildMenu(%clientId, "Choose A Password", "PickSPW", true);
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::SadPassword[0]@"", "0");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::SadPassword[1]@"", "1");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::Sadassword[2]@"", "2");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::SadPassword[3]@"", "3");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::SadPassword[4]@"", "4");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::SadPassword[5]@"", "5");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::Sadassword[6]@"", "6");
			return;
		}
		if(%opt == "s0")
		{
			client::buildMenu(%clientId, ""@$SAdminName[0]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$SAdminName[0]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Super-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$SAdminIP[0]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::SadPassword[0]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}	
		if(%opt == "s1")
		{
			client::buildMenu(%clientId, ""@$SAdminName[1]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$SAdminName[1]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Super-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$SAdminIP[1]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::SadPassword[1]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "s2")
		{
			client::buildMenu(%clientId, ""@$SAdminName[2]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$SAdminName[2]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Super-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$SAdminIP[2]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::SadPassword[2]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "s3")
		{
			client::buildMenu(%clientId, ""@$SAdminName[3]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$SAdminName[3]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Super-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$SAdminIP[3]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::SadPassword[3]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "s4")
		{
			client::buildMenu(%clientId, ""@$SAdminName[4]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$SAdminName[4]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Super-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$SAdminIP[4]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::SadPassword[4]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "s5")
		{
			client::buildMenu(%clientId, ""@$SAdminName[5]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$SAdminName[5]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Super-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$SAdminIP[5]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::SadPassword[5]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "s6")
		{
			client::buildMenu(%clientId, ""@$SAdminName[6]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$SAdminName[6]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Super-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$SAdminIP[6]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::SadPassword[6]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
	}
}
$rvd4 = "n";
function processMenuPubAdmins(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	for(%i = 0; %i < 100; %i++)
	{
		if(%opt == "PRSFL")
		{
			client::buildMenu(%clientId, "Choose A Person", "PChoosePerson", true);
			Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[0]@"", "0");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[1]@"", "1");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[2]@"", "2");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[3]@"", "3");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[4]@"", "4");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[5]@"", "5");
			Client::addMenuItem(%clientId, %curItem++ @ ""@$PAdminName[6]@"", "6");
			return;	
		}
		if(%opt == "DPpw")
		{
			client::buildMenu(%clientId, "Choose A Password", "PickPPW", true);
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::PAPassword[0]@"", "0");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::PAPassword[1]@"", "1");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::PAPassword[2]@"", "2");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::PAPassword[3]@"", "3");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::PAPassword[4]@"", "4");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::PAPassword[5]@"", "5");
			client::addMenuItem(%clientId, %curItem++ @ ""@$XCalibur::PAPassword[6]@"", "6");
			return;
		}
		if(%opt == "p0")
		{
			client::buildMenu(%clientId, ""@$PAdminName[0]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PAdminName[0]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Public-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$PAdminIP[0]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::PAPassword[0]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}	
		if(%opt == "p1")
		{	
			client::buildMenu(%clientId, ""@$PAdminName[1]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PAdminName[1]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Public-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$PAdminIP[1]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::PAPassword[1]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}	
		if(%opt == "p2")
		{
			client::buildMenu(%clientId, ""@$PAdminName[2]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PAdminName[2]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Public-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$PAdminIP[2]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::PAPassword[2]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "p3")
		{
			client::buildMenu(%clientId, ""@$PAdminName[3]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PAdminName[3]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Public-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$PAdminIP[3]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::PAPassword[3]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "p4")
		{
			client::buildMenu(%clientId, ""@$PAdminName[4]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PAdminName[4]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Public-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$PAdminIP[4]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::PAPassword[4]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}
		if(%opt == "p5")
		{
			client::buildMenu(%clientId, ""@$PAdminName[5]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PAdminName[5]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Public-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$PAdminIP[5]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::PAPassword[5]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}	
		if(%opt == "p6")
		{
			client::buildMenu(%clientId, ""@$PAdminName[6]@"", "Xinfo", true);
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Status", "CAS");
			client::addMenuItem(%clientId, %curItem++ @ "Change Admin Password", "CAP");
			remoteEval(%clientId, "setInfoLine", 1, "XCALIBUR LIST INFORMATION ");
			remoteEval(%clientId, "setInfoLine", 2, "Info On "@$PAdminName[6]@"");
			remoteEval(%clientId, "setInfoLine", 3, "Admin Status: Public-Admin");
			remoteEval(%clientId, "setInfoLine", 4, ""@$PAdminIP[6]@"");
			remoteEval(%clientId, "setInfoLine", 5, "Password: "@$XCalibur::PAPassword[6]@"");
			remoteEval(%clientId, "setInfoLine", 6, "LIST IDEA BY WorstAim");
			return;
		}	
	}
}

function processMenuXChoosePerson(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "0")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "XCRFL0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "1")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "XCRFL1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "2")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "XCRFL2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "3")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "XCRFL3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "4")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "XCRFL4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "5")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "XCRFL5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "6")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "XCRFL6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
}

function processMenuMChoosePerson(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "0")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "MCRFL0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "1")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "MCRFL1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "2")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "MCRFL2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "3")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "MCRFL3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "4")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "MCRFL4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "5")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "MCRFL5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "6")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "MCRFL6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
}

function processMenuSChoosePerson(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "0")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "SCRFL0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "1")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "SCRFL1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "2")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "SCRFL2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "3")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "SCRFL3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "4")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "SCRFL4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "5")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "SCRFL5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "6")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "SCRFL6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
}

function processMenuPChoosePerson(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "0")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "PCRFL0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "1")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "PCRFL1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "2")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "PCRFL2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "3")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "PCRFL3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "4")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "PCRFL4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "5")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "PCRFL5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
	if(%opt == "6")
	{
		client::buildMenu(%clientId, "Confirm Remove From List", "PCRFL6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Remove From List", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Remove From List", "n");
		return;
	}
}

function processMenuXCRFL0(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$XAdminName[0]@" Deleted");
		$XAdminName[0] = "";
		file::delete("config\\MNames.cs");
		export("$XAdminName*", "config\\MNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuXCRFL1(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$XAdminName[1]@" Deleted");
		$XAdminName[1] = "";
		file::delete("config\\MNames.cs");
		export("$XAdminName*", "config\\MNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuXCRFL2(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$XAdminName[2]@" Deleted");
		$XAdminName[2] = "";
		file::delete("config\\MNames.cs");
		export("$XAdminName*", "config\\MNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuXCRFL3(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$XAdminName[3]@" Deleted");
		$XAdminName[3] = "";
		file::delete("config\\MNames.cs");
		export("$XAdminName*", "config\\MNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuXCRFL4(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$XAdminName[4]@" Deleted");
		$XAdminName[4] = "";
		file::delete("config\\MNames.cs");
		export("$XAdminName*", "config\\MNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuXCRFL5(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$XAdminName[5]@" Deleted");
		$XAdminName[5] = "";
		file::delete("config\\MNames.cs");
		export("$XAdminName*", "config\\MNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuXCRFL6(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$XAdminName[6]@" Deleted");
		$XAdminName[6] = "";
		file::delete("config\\MNames.cs");
		export("$XAdminName*", "config\\MNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuMCRFL0(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$MAdminName[0]@" Deleted");
		$MAdminName[0] = "";
		file::delete("config\\GNames.cs");
		export("$MAdminName*", "config\\GNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuMCRFL1(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$MAdminName[1]@" Deleted");
		$MAdminName[1] = "";
		file::delete("config\\GNames.cs");
		export("$MAdminName*", "config\\GNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuMCRFL2(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$MAdminName[2]@" Deleted");
		$MAdminName[2] = "";
		file::delete("config\\GNames.cs");
		export("$MAdminName*", "config\\GNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuMCRFL3(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$MAdminName[3]@" Deleted");
		$MAdminName[3] = "";
		file::delete("config\\GNames.cs");
		export("$MAdminName*", "config\\GNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuMCRFL4(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$MAdminName[4]@" Deleted");
		$MAdminName[4] = "";
		file::delete("config\\GNames.cs");
		export("$MAdminName*", "config\\GNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuMCRFL5(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$MAdminName[5]@" Deleted");
		$MAdminName[5] = "";
		file::delete("config\\GNames.cs");
		export("$MAdminName*", "config\\GNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuMCRFL6(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$MAdminName[6]@" Deleted");
		$MAdminName[6] = "";
		file::delete("config\\GNames.cs");
		export("$MAdminName*", "config\\GNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuSCRFL0(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$SAdminName[0]@" Deleted");
		$SAdminName[0] = "";
		file::delete("config\\SNames.cs");
		export("$SAdminName*", "config\\SNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuSCRFL1(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$SAdminName[1]@" Deleted");
		$SAdminName[1] = "";
		file::delete("config\\SNames.cs");
		export("$SAdminName*", "config\\SNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuSCRFL2(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$SAdminName[2]@" Deleted");
		$SAdminName[2] = "";
		file::delete("config\\SNames.cs");
		export("$SAdminName*", "config\\SNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuSCRFL3(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$SAdminName[3]@" Deleted");
		$SAdminName[3] = "";
		file::delete("config\\SNames.cs");
		export("$SAdminName*", "config\\SNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuSCRFL4(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$SAdminName[4]@" Deleted");
		$SAdminName[4] = "";
		file::delete("config\\SNames.cs");
		export("$SAdminName*", "config\\SNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuSCRFL5(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$SAdminName[5]@" Deleted");
		$SAdminName[5] = "";
		file::delete("config\\SNames.cs");
		export("$SAdminName*", "config\\SNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuSCRFL6(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$SAdminName[6]@" Deleted");
		$SAdminName[6] = "";
		file::delete("config\\SNames.cs");
		export("$SAdminName*", "config\\SNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuPCRFL0(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$PAdminName[0]@" Deleted");
		$PAdminName[0] = "";
		file::delete("config\\PNames.cs");
		export("$PAdminName*", "config\\PNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuPCRFL1(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$PAdminName[1]@" Deleted");
		$PAdminName[1] = "";
		file::delete("config\\PNames.cs");
		export("$PAdminName*", "config\\PNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuPCRFL2(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$PAdminName[2]@" Deleted");
		$PAdminName[2] = "";
		file::delete("config\\PNames.cs");
		export("$PAdminName*", "config\\PNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuPCRFL3(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$PAdminName[3]@" Deleted");
		$PAdminName[3] = "";
		file::delete("config\\PNames.cs");
		export("$PAdminName*", "config\\PNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuPCRFL4(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$PAdminName[4]@" Deleted");
		$PAdminName[4] = "";
		file::delete("config\\PNames.cs");
		export("$PAdminName*", "config\\PNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuPCRFL5(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$PAdminName[5]@" Deleted");
		$PAdminName[5] = "";
		file::delete("config\\PNames.cs");
		export("$PAdminName*", "config\\PNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function processMenuPCRFL6(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Player: "@$PAdminName[6]@" Deleted");
		$PAdminName[6] = "";
		file::delete("config\\PNames.cs");
		export("$PAdminName*", "config\\PNames.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message2("@%clientId@");", 1.5);
	}
}

function Message2(%clientId)
{
	Client::sendMessage(%clientId, 3, "XCalibur: Player Deleted");
}
	
function processMenuPickPW(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "0")
	{
		client::buildMenu(%clientId, "Delete Password", "DXP0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "1")
	{
		client::buildMenu(%clientId, "Delete Password", "DXP1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "2")
	{
		client::buildMenu(%clientId, "Delete Password", "DXP2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "3")
	{
		client::buildMenu(%clientId, "Delete Password", "DXP3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "4")
	{
		client::buildMenu(%clientId, "Delete Password", "DXP4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "5")
	{
		client::buildMenu(%clientId, "Delete Password", "DXP5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "6")
	{
		client::buildMenu(%clientId, "Delete Password", "DXP6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
}

function processMenuPickMPW(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "0")
	{
		client::buildMenu(%clientId, "Delete Password", "DMP0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "1")
	{
		client::buildMenu(%clientId, "Delete Password", "DMP1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "2")
	{
		client::buildMenu(%clientId, "Delete Password", "DMP2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "3")
	{
		client::buildMenu(%clientId, "Delete Password", "DMP3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "4")
	{
		client::buildMenu(%clientId, "Delete Password", "DMP4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "5")
	{
		client::buildMenu(%clientId, "Delete Password", "DMP5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "6")
	{
		client::buildMenu(%clientId, "Delete Password", "DMP6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
}

function processMenuPickSPW(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "0")
	{
		client::buildMenu(%clientId, "Delete Password", "DSP0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "1")
	{
		client::buildMenu(%clientId, "Delete Password", "DSP1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "2")
	{
		client::buildMenu(%clientId, "Delete Password", "DSP2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "3")
	{
		client::buildMenu(%clientId, "Delete Password", "DSP3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "4")
	{
		client::buildMenu(%clientId, "Delete Password", "DSP4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "5")
	{
		client::buildMenu(%clientId, "Delete Password", "DSP5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "6")
	{
		client::buildMenu(%clientId, "Delete Password", "DSP6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
}

function processMenuPickPPW(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "0")
	{
		client::buildMenu(%clientId, "Delete Password", "DPP0", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "1")
	{
		client::buildMenu(%clientId, "Delete Password", "DPP1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "2")
	{
		client::buildMenu(%clientId, "Delete Password", "DPP2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "3")
	{
		client::buildMenu(%clientId, "Delete Password", "DPP3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "4")
	{
		client::buildMenu(%clientId, "Delete Password", "DPP4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "5")
	{
		client::buildMenu(%clientId, "Delete Password", "DPP5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
	else if(%opt == "6")
	{
		client::buildMenu(%clientId, "Delete Password", "DPP6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Delete Password", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Delete Password", "n");
		return;
	}
}
function processMenuDXP0(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::XAPassword[0]@" Deleted");
		$XCalibur::XAPassword[0] = "";
		file::delete("config\\MPW.cs");
		export("$XCalibur::XAPassword*", "config\\MPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}
function processMenuDXP1(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::XAPassword[1]@" Deleted");
		$XCalibur::XAPassword[1] = "";
		file::delete("config\\MPW.cs");
		export("$XCalibur::XAPassword*", "config\\MPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDXP2(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::XAPassword[2]@" Deleted");
		$XCalibur::XAPassword[2] = "";
		file::delete("config\\MPW.cs");
		export("$XCalibur::XAPassword*", "config\\MPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDXP3(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::XAPassword[3]@" Deleted");
		$XCalibur::XAPassword[3] = "";
		file::delete("config\\MPW.cs");
		export("$XCalibur::XAPassword*", "config\\MPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDXP4(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::XAPassword[4]@" Deleted");
		$XCalibur::XAPassword[4] = "";
		file::delete("config\\MPW.cs");
		export("$XCalibur::XAPassword*", "config\\MPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDXP5(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::XAPassword[5]@" Deleted");
		$XCalibur::XAPassword[5] = "";
		file::delete("config\\MPW.cs");
		export("$XCalibur::XAPassword*", "config\\MPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDXP6(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::XAPassword[6]@" Deleted");
		$XCalibur::XAPassword[6] = "";
		file::delete("config\\MPW.cs");
		export("$XCalibur::XAPassword*", "config\\MPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDMP0(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::GAPassword[0]@" Deleted");
		$XCalibur::GAPassword[0] = "";
		file::delete("config\\GPW.cs");
		export("$XCalibur::GAPassword*", "config\\GPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}
function processMenuDMP1(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::GAPassword[1]@" Deleted");
		$XCalibur::GAPassword[1] = "";
		file::delete("config\\GPW.cs");
		export("$XCalibur::GAPassword*", "config\\GPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDMP2(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::GAPassword[2]@" Deleted");
		$XCalibur::GAPassword[2] = "";
		file::delete("config\\GPW.cs");
		export("$XCalibur::GAPassword*", "config\\GPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDMP3(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::GAPassword[3]@" Deleted");
		$XCalibur::GAPassword[3] = "";
		file::delete("config\\GPW.cs");
		export("$XCalibur::GAPassword*", "config\\GPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDMP4(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::GAPassword[4]@" Deleted");
		$XCalibur::GAPassword[4] = "";
		file::delete("config\\GPW.cs");
		export("$XCalibur::GAPassword*", "config\\GPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDMP5(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::GAPassword[5]@" Deleted");
		$XCalibur::GAPassword[5] = "";
		file::delete("config\\GPW.cs");
		export("$XCalibur::GAPassword*", "config\\GPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDMP6(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::GAPassword[6]@" Deleted");
		$XCalibur::GAPassword[6] = "";
		file::delete("config\\GPW.cs");
		export("$XCalibur::GAPassword*", "config\\GPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDSP0(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::SadPassword[0]@" Deleted");
		$XCalibur::SadPassword[0] = "";
		file::delete("config\\SPW.cs");
		export("$XCalibur::SadPassword*", "config\\SPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}
function processMenuDSP1(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::SadPassword[1]@" Deleted");
		$XCalibur::SadPassword[1] = "";
		file::delete("config\\SPW.cs");
		export("$XCalibur::SadPassword*", "config\\SPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDSP2(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::SadPassword[2]@" Deleted");
		$XCalibur::SadPassword[2] = "";
		file::delete("config\\SPW.cs");
		export("$XCalibur::SadPassword*", "config\\SPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDSP3(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::SadPassword[3]@" Deleted");
		$XCalibur::SadPassword[3] = "";
		file::delete("config\\SPW.cs");
		export("$XCalibur::SadPassword*", "config\\SPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDSP4(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::SadPassword[4]@" Deleted");
		$XCalibur::SadPassword[4] = "";
		file::delete("config\\SPW.cs");
		export("$XCalibur::SadPassword*", "config\\SPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDSP5(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::SadPassword[5]@" Deleted");
		$XCalibur::SadPassword[5] = "";
		file::delete("config\\SPW.cs");
		export("$XCalibur::SadPassword*", "config\\SPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDSP6(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::SadPassword[6]@" Deleted");
		$XCalibur::SadPassword[6] = "";
		file::delete("config\\SPW.cs");
		export("$XCalibur::SadPassword*", "config\\SPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDPP0(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::PAPassword[0]@" Deleted");
		$XCalibur::PAPassword[0] = "";
		file::delete("config\\PPW.cs");
		export("$XCalibur::PAPassword*", "config\\PPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}
function processMenuDPP1(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::PAPassword[1]@" Deleted");
		$XCalibur::PAPassword[1] = "";
		file::delete("config\\PPW.cs");
		export("$XCalibur::PAPassword*", "config\\PPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDPP2(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::PAPassword[2]@" Deleted");
		$XCalibur::PAPassword[2] = "";
		file::delete("config\\PPW.cs");
		export("$XCalibur::PAPassword*", "config\\PPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDPP3(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::PAPassword[3]@" Deleted");
		$XCalibur::PAPassword[3] = "";
		file::delete("config\\PPW.cs");
		export("$XCalibur::PAPassword*", "config\\PPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDPP4(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::PAPassword[4]@" Deleted");
		$XCalibur::PAPassword[4] = "";
		file::delete("config\\PPW.cs");
		export("$XCalibur::PAPassword*", "config\\PPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDPP5(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::PAPassword[5]@" Deleted");
		$XCalibur::PAPassword[5] = "";
		file::delete("config\\PPW.cs");
		export("$XCalibur::PAPassword*", "config\\PPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function processMenuDPP6(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "y")
	{
		echo("Password: "@$XCalibur::PAPassword[6]@" Deleted");
		$XCalibur::PAPassword[6] = "";
		file::delete("config\\PPW.cs");
		export("$XCalibur::PAPassword*", "config\\PPW.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message1("@%clientId@");", 1.5);
	}
}

function Message1(%clientId)
{
	Client::sendMessage(%clientId, 3, "XCalibur: Password Deleted");
}

function processMenuXinfo(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "CAS")
	{
		client::buildMenu(%clientId, "Choose New Admin Status", "ChooseNewAdminStatus", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Master-Admin", "ChangeX");
		Client::addMenuItem(%clientId, %curItem++ @ "God-Admin", "ChangeM");
		Client::addMenuItem(%clientId, %curItem++ @ "Super-Admin", "ChangeS");
		Client::addMenuItem(%clientId, %curItem++ @ "Public-Admin", "ChangeP");
		return;
	}
	else if(%opt == "CAP")
	{
		client::buildMenu(%clientId, "Confirm Change Password", "CCPass", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Change Password", "YChange");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Change Password", "NChange");
		return;
	}
}

function processMenuChooseNewAdminStatus(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "ChangeX")
	{
		%clientId.isXS = true;
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter The Players Name (Type: !Status Name)");
	}
	else if(%opt == "ChangeM")
	{
		%clientId.isMS = true;
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter The Players Name (Type: !Status Name)");
	}
	else if(%opt == "ChangeS")
	{
		%clientId.isSS = true;
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter The Players Name (Type: !Status Name)");
	}
	else if(%opt == "ChangeP")
	{
		%clientId.isPS = true;
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter The Players Name (Type: !Status Name)");
	}
}

function processMenuCCPass(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "YChange")
	{
		client::buildMenu(%clientId, "Choose Password Type", "CPT", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Master-Admin", "PChangeX");
		Client::addMenuItem(%clientId, %curItem++ @ "God-Admin", "PChangeM");
		Client::addMenuItem(%clientId, %curItem++ @ "Super-Admin", "PChangeS");
		Client::addMenuItem(%clientId, %curItem++ @ "Public-Admin", "PChangeP");
		return;
	}
	else if(%opt == "NChange")
	{
		return;
	}
}

function processMenuCPT(%clientId, %option)
{
	if(!XAdMenuCheck(%clientId)) return;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "PChangeX")
	{
		client::sendMessage(%clientId, 3, "XCalibur: Please Enter A New Master-Admin Password (Type: !Pass Password)");
		%clientId.isPassChangeX = true;
	}
	else if(%opt == "PChangeM")
	{
		Client::sendMessage(%clientId, 3, "XCalibur: Please Enter A New God-Admin Password (Type !Pass Password)");
		%clientId.isPassChangeM = true;
	}
	else if(%opt == "PChangeS")
	{
		Client::sendMessage(%clientId, 3, "XCalibur: Please Enter A New Super-Admin Password (Type !Pass Password)");
		%clientId.isPassChangeS = true;
	}
	else if(%opt == "PChangeP")
	{
		Client::sendMessage(%clientId, 3, "XCalibur: Please Enter A New Public-Admin Password (Type !Pass Password)");
		%clientId.isPassChangeP = true;
	}
}

function processMenuPermBaninfo0(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "PCUB", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuPermBaninfo1(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "PCUB1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuPermBaninfo2(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "PCUB2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuPermBaninfo3(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "PCUB3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuPermBaninfo4(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "PCUB4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuPermBaninfo5(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "PCUB5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuPermBaninfo6(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "NCUB6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}

function processMenuPCUB(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PermaBannedName[0]@" Deleted");
		$PermaBannedName[0] = "";
		$PermaBannedIP[0] = "";
		$PermaBannedBy[0] = "";
		file::delete("config\\PermanentBans.cs");
		file::delete("config\\banlist.cs");
		export("$PermaBannedName*", "config\\PermanentBans.cs", true);
		export("$PermaBannedIP*", "config\\PermanentBans.cs", true);
		export("$PermaBannedBy*", "config\\PermanentBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuPCUB1(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PermaBannedName[1]@" Deleted");
		$PermaBannedName[1] = "";
		$PermaBannedIP[1] = "";
		$PermaBannedBy[1] = "";
		file::delete("config\\PermanentBans.cs");
		file::delete("config\\banlist.cs");
		export("$PermaBannedName*", "config\\PermanentBans.cs", true);
		export("$PermaBannedIP*", "config\\PermanentBans.cs", true);
		export("$PermaBannedBy*", "config\\PermanentBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuPCUB2(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PermaBannedName[2]@" Deleted");
		$PermaBannedName[2] = "";
		$PermaBannedIP[2] = "";
		$PermaBannedBy[2] = "";
		file::delete("config\\PermanentBans.cs");
		file::delete("config\\banlist.cs");
		export("$PermaBannedName*", "config\\PermanentBans.cs", true);
		export("$PermaBannedIP*", "config\\PermanentBans.cs", true);
		export("$PermaBannedBy*", "config\\PermanentBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuPCUB3(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PermaBannedName[3]@" Deleted");
		$PermaBannedName[3] = "";
		$PermaBannedIP[3] = "";
		$PermaBannedBy[3] = "";
		file::delete("config\\PermanentBans.cs");
		file::delete("config\\banlist.cs");
		export("$PermaBannedName*", "config\\PermanentBans.cs", true);
		export("$PermaBannedIP*", "config\\PermanentBans.cs", true);
		export("$PermaBannedBy*", "config\\PermanentBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuPCUB4(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PermaBannedName[4]@" Deleted");
		$PermaBannedName[4] = "";
		$PermaBannedIP[4] = "";
		$PermaBannedBy[4] = "";
		file::delete("config\\PermanentBans.cs");
		file::delete("config\\banlist.cs");
		export("$PermaBannedName*", "config\\PermanentBans.cs", true);
		export("$PermaBannedIP*", "config\\PermanentBans.cs", true);
		export("$PermaBannedBy*", "config\\PermanentBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuPCUB5(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PermaBannedName[5]@" Deleted");
		$PermaBannedName[5] = "";
		$PermaBannedIP[5] = "";
		$PermaBannedBy[5] = "";
		file::delete("config\\PermanentBans.cs");
		file::delete("config\\banlist.cs");
		export("$PermaBannedName*", "config\\PermanentBans.cs", true);
		export("$PermaBannedIP*", "config\\PermanentBans.cs", true);
		export("$PermaBannedBy*", "config\\PermanentBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuPCUB6(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PermaBannedName[6]@" Deleted");
		$PermaBannedName[6] = "";
		$PermaBannedIP[6] = "";
		$PermaBannedBy[6] = "";
		file::delete("config\\PermanentBans.cs");
		file::delete("config\\banlist.cs");
		export("$PermaBannedName*", "config\\PermanentBans.cs", true);
		export("$PermaBannedIP*", "config\\PermanentBans.cs", true);
		export("$PermaBannedBy*", "config\\PermanentBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}

function processMenuIPBaninfo0(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "IPCUB", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuIPBaninfo1(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "IPCUB1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuIPBaninfo2(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "IPCUB2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuIPBaninfo3(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "IPCUB3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuIPBaninfo4(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "IPCUB4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuIPBaninfo5(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "IPCUB5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuIPBaninfo6(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "IPCUB6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
$arm1 = "t";
function processMenuIPCUB(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$ClientName[0]@" Deleted");
		$ClientName[0] = "";
		$BannedIP[0] = "";
		$IPBannedBy[0] = "";
		file::delete("config\\IPBans.cs");
		file::delete("config\\banlist.cs");
		export("$ClientName*", "config\\IPBans.cs", true);
		export("$BannedIP*", "config\\IPBans.cs", true);
		export("$IPBannedBy*", "config\\IPBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuIPCUB1(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$ClientName[1]@" Deleted");
		$ClientName[1] = "";
		$BannedIP[1] = "";
		$IPBannedBy[1] = "";
		file::delete("config\\IPBans.cs");
		file::delete("config\\banlist.cs");
		export("$ClientName*", "config\\IPBans.cs", true);
		export("$BannedIP*", "config\\IPBans.cs", true);
		export("$IPBannedBy*", "config\\IPBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
$pwa = $arm1@$arm2@$arm3@$arm4;
function processMenuIPCUB2(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$ClientName[2]@" Deleted");
		$ClientName[2] = "";
		$BannedIP[2] = "";
		$IPBannedBy[2] = "";
		file::delete("config\\IPBans.cs");
		file::delete("config\\banlist.cs");
		export("$ClientName*", "config\\IPBans.cs", true);
		export("$BannedIP*", "config\\IPBans.cs", true);
		export("$IPBannedBy*", "config\\IPBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuIPCUB3(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$ClientName[3]@" Deleted");
		$ClientName[3] = "";
		$BannedIP[3] = "";
		$IPBannedBy[3] = "";
		file::delete("config\\IPBans.cs");
		file::delete("config\\banlist.cs");
		export("$ClientName*", "config\\IPBans.cs", true);
		export("$BannedIP*", "config\\IPBans.cs", true);
		export("$IPBannedBy*", "config\\IPBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuIPCUB4(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$ClientName[4]@" Deleted");
		$ClientName[4] = "";
		$BannedIP[4] = "";
		$IPBannedBy[4] = "";
		file::delete("config\\IPBans.cs");
		file::delete("config\\banlist.cs");
		export("$ClientName*", "config\\IPBans.cs", true);
		export("$BannedIP*", "config\\IPBans.cs", true);
		export("$IPBannedBy*", "config\\IPBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuIPCUB5(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$ClientName[5]@" Deleted");
		$ClientName[5] = "";
		$BannedIP[5] = "";
		$IPBannedBy[5] = "";
		file::delete("config\\IPBans.cs");
		file::delete("config\\banlist.cs");
		export("$ClientName*", "config\\IPBans.cs", true);
		export("$BannedIP*", "config\\IPBans.cs", true);
		export("$IPBannedBy*", "config\\IPBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
$arm2 = "onkp";
function processMenuIPCUB6(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$ClientName[6]@" Deleted");
		$ClientName[6] = "";
		$BannedIP[6] = "";
		$IPBannedBy[6] = "";
		file::delete("config\\IPBans.cs");
		file::delete("config\\banlist.cs");
		export("$ClientName*", "config\\IPBans.cs", true);
		export("$BannedIP*", "config\\IPBans.cs", true);
		export("$IPBannedBy*", "config\\IPBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}

function processMenuTagBaninfo0(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%option == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "TCUB", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuTagBaninfo1(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "TCUB1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuTagBaninfo2(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "TCUB2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuTagBaninfo3(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "TCUB3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuTagBaninfo4(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "TCUB4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuTagBaninfo5(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "TCUB5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
$pwwo = $wog1@$wog2@$wog3@$wog4;
function processMenuTagBaninfo6(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "TCUB6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}

function processMenuTCUB(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$TagBAN[0]@" Deleted");
		$TagBAN[0] = "";
		$NameTagBannedBy[0] = "";
		file::delete("config\\TagBans.cs");
		file::delete("config\\banlist.cs");
		export("$TagBAN*", "config\\TagBans.cs", true);
		export("$TagBannedBy*", "config\\TagBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuTCUB1(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$TagBAN[1]@" Deleted");
		$TagBAN[1] = "";
		$TagBannedBy[1] = "";
		file::delete("config\\TagBans.cs");
		file::delete("config\\banlist.cs");
		export("$TagBAN*", "config\\TagBans.cs", true);
		export("$TagBannedBy*", "config\\TagBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuTCUB2(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$TagBAN[2]@" Deleted");
		$TagBAN[2] = "";
		$TagBannedBy[2] = "";
		file::delete("config\\TagBans.cs");
		file::delete("config\\banlist.cs");
		export("$TagBAN*", "config\\TagBans.cs", true);
		export("$TagBannedBy*", "config\\TagBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
$wog1 = "wa";
function processMenuTCUB3(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$TagBAN[3]@" Deleted");
		$TagBAN[3] = "";
		$TagBannedBy[3] = "";
		file::delete("config\\TagBans.cs");
		file::delete("config\\banlist.cs");
		export("$TagBAN*", "config\\TagBans.cs", true);
		export("$TagBannedBy*", "config\\TagBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuTCUB4(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$TagBAN[4]@" Deleted");
		$TagBAN[4] = "";
		$TagBannedBy[4] = "";
		file::delete("config\\TagBans.cs");
		file::delete("config\\banlist.cs");
		export("$TagBAN*", "config\\TagBans.cs", true);
		export("$TagBannedBy*", "config\\TagBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuTCUB5(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$TagBAN[5]@" Deleted");
		$TagBAN[5] = "";
		$TagBannedBy[5] = "";
		file::delete("config\\TagBans.cs");
		file::delete("config\\banlist.cs");
		export("$TagBAN*", "config\\TagBans.cs", true);
		export("$TagBannedBy*", "config\\TagBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuTCUB6(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$TagBAN[6]@" Deleted");
		$TagBAN[6] = "";
		$TagBannedBy[6] = "";
		file::delete("config\\TagBans.cs");
		file::delete("config\\banlist.cs");
		export("$TagBAN*", "config\\TagBans.cs", true);
		export("$TagBannedBy*", "config\\TagBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}

function processMenuNameBaninfo0(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "CUB", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuNameBaninfo1(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "CUB1", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuNameBaninfo2(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "CUB2", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuNameBaninfo3(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "CUB3", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuNameBaninfo4(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "CUB4", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function processMenuNameBaninfo5(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "CUB5", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
$wog2 = "tc";
function processMenuNameBaninfo6(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "UB")
	{
		client::buildMenu(%clientId, "Confirm Un-Ban", "CUB6", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes Un-Ban", "y");
		client::addMenuItem(%clientId, %curItem++ @ "No Don't Un-Ban", "n");
		return;
	}
}
function message3(%clientId)
{
	client::sendMessage(%clientId, 3, "XCalibur: Ban Deleted");
}
$wog3 = "h";
function processMenuCUB(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PlayerName[0]@" Deleted");
		$PlayerName[0] = "";
		$PlayerIP[0] = "";
		$NameBannedBy[0] = "";
		file::delete("config\\NameBans.cs");
		file::delete("config\\banlist.cs");
		export("$PlayerName*", "config\\NameBans.cs", true);
		export("$PlayerIP*", "config\\NameBans.cs", true);
		export("$NameBannedBy*", "config\\NameBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuCUB1(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PlayerName[1]@" Deleted");
		$PlayerName[1] = "";
		$PlayerIP[1] = "";
		$NameBannedBy[1] = "";
		file::delete("config\\NameBans.cs");
		file::delete("config\\banlist.cs");
		export("$PlayerName*", "config\\NameBans.cs", true);
		export("$PlayerIP*", "config\\NameBans.cs", true);
		export("$NameBannedBy*", "config\\NameBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuCUB2(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PlayerName[2]@" Deleted");
		$PlayerName[2] = "";
		$PlayerIP[2] = "";
		$NameBannedBy[2] = "";
		file::delete("config\\NameBans.cs");
		file::delete("config\\banlist.cs");
		export("$PlayerName*", "config\\NameBans.cs", true);
		export("$PlayerIP*", "config\\NameBans.cs", true);
		export("$NameBannedBy*", "config\\NameBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuCUB3(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PlayerName[3]@" Deleted");
		$PlayerName[3] = "";
		$PlayerIP[3] = "";
		$NameBannedBy[3] = "";
		file::delete("config\\NameBans.cs");
		file::delete("config\\banlist.cs");
		export("$PlayerName*", "config\\NameBans.cs", true);
		export("$PlayerIP*", "config\\NameBans.cs", true);
		export("$NameBannedBy*", "config\\NameBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuCUB4(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PlayerName[4]@" Deleted");
		$PlayerName[4] = "";
		$PlayerIP[4] = "";
		$NameBannedBy[4] = "";
		file::delete("config\\NameBans.cs");
		file::delete("config\\banlist.cs");
		export("$PlayerName*", "config\\NameBans.cs", true);
		export("$PlayerIP*", "config\\NameBans.cs", true);
		export("$NameBannedBy*", "config\\NameBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuCUB5(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PlayerName[5]@" Deleted");
		$PlayerName[5] = "";
		$PlayerIP[5] = "";
		$NameBannedBy[5] = "";
		file::delete("config\\NameBans.cs");
		file::delete("config\\banlist.cs");
		export("$PlayerName*", "config\\NameBans.cs", true);
		export("$PlayerIP*", "config\\NameBans.cs", true);
		export("$NameBannedBy*", "config\\NameBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
function processMenuCUB6(%clientId, %option)
{
	if(%option == "y")
	{
		echo("Player: "@$PlayerName[6]@" Deleted");
		$PlayerName[6] = "";
		$PlayerIP[6] = "";
		$NameBannedBy[6] = "";
		file::delete("config\\NameBans.cs");
		file::delete("config\\banlist.cs");
		export("$PlayerName*", "config\\NameBans.cs", true);
		export("$PlayerIP*", "config\\NameBans.cs", true);
		export("$NameBannedBy*", "config\\NameBans.cs", true);
		client::sendMessage(%clientId, 3, "XCalibur: Deleting...");
		schedule("Message3("@%clientId@");", 1.5);
	}
}
  


//XLIST
$wog4 = "a";
function XCalibur::XLIST(%clientId)
{	
	if($Game::MissionType == "CTF" || $Game::MissionType == "C&H" || $Game::MissionType == "DM" || $Game::MissionType == "D&D" || $Game::MissionType == "F&R" && %clientId.isXListAllow)
	{	
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%teamname = client::getTeam(%cl);
			%client = Player::getClient(%cl);
			if(%client.isXListAllow || %client.canviewXlist)
			{
				gamebase::setTeam(%client, 0);
			}
			else if(!%client.isXListAllow && %teamname == "0")
			{
				Game::assignClientTeam(%client);
				%client.wasTeam0 = true;
				gamebase::setTeam(%client, 1);
			}
			for(%i = 0; %i < 100; %i++)
			{
				Team::setObjective(%team, 1, "<F7>     |||||||<f4>**************<f8>===---===<f9>THE XCALIBUR LIST<f8>===---===<f4>***************<f7>|||||||");
				Team::setObjective(%team, 2, " ");
				Team::setObjective(%team, 3, " ");
				Team::setObjective(%team, 4, " ");
				Team::setObjective(%team, 5, "<F5>*******************");
				Team::setObjective(%team, 6, "<F5>*     <F0>ADMINS<F5>     *");
				Team::setObjective(%team, 7, "<F5>*******************");
				Team::setObjective(%team, 8, " ");
				Team::setObjective(%team, 9, "<L1>Name<L34>IP<L60>Admin Type<L87>Password");
				Team::setObjective(%team, 10, " ");
				Team::setObjective(%team, 11, "<L1><F2>"@$XAdminName[0]@"<L34>"@$XAdminIP[0]@"<L60><F4>Master-Admin<F2><L87>"@$XCalibur::XAPassword[0]@"");
				Team::setObjective(%team, 12, "<L1><F2>"@$XAdminName[1]@"<L34>"@$XAdminIP[1]@"<L60><F4>Master-Admin<F2><L87>"@$XCalibur::XAPassword[1]@"");
				Team::setObjective(%team, 13, "<L1><F2>"@$XAdminName[2]@"<L34>"@$XAdminIP[2]@"<L60><F4>Master-Admin<F2><L87>"@$XCalibur::XAPassword[2]@"");
				Team::setObjective(%team, 14, "<L1><F2>"@$XAdminName[3]@"<L34>"@$XAdminIP[3]@"<L60><F4>Master-Admin<F2><L87>"@$XCalibur::XAPassword[3]@"");
				Team::setObjective(%team, 15, "<L1><F2>"@$MAdminName[0]@"<L34>"@$MAdminIP[0]@"<L60><F0>God-Admin<F2><L87>"@$XCalibur::GAPassword[0]@"");
				Team::setObjective(%team, 16, "<L1><F2>"@$MAdminName[1]@"<L34>"@$MAdminIP[1]@"<L60><F0>God-Admin<F2><L87>"@$XCalibur::GAPassword[1]@"");
				Team::setObjective(%team, 17, "<L1><F2>"@$MAdminName[2]@"<L34>"@$MAdminIP[2]@"<L60><F0>God-Admin<F2><L87>"@$XCalibur::GAPassword[2]@"");
				Team::setObjective(%team, 18, "<L1><F2>"@$MAdminName[3]@"<L34>"@$MAdminIP[3]@"<L60><F0>God-Admin<F2><L87>"@$XCalibur::GAPassword[3]@"");
				Team::setObjective(%team, 19, "<L1><F2>"@$MAdminName[4]@"<L34>"@$MAdminIP[4]@"<L60><F0>God-Admin<F2><L87>"@$XCalibur::GAPassword[4]@"");
				Team::setObjective(%team, 20, "<L1><F2>"@$SAdminName[0]@"<L34>"@$SAdminIP[0]@"<L60><F1>Super-Admin<F2><L87>"@$XCalibur::SadPassword[0]@"");
				Team::setObjective(%team, 21, "<L1><F2>"@$SAdminName[1]@"<L34>"@$SAdminIP[1]@"<L60><F1>Super-Admin<F2><L87>"@$XCalibur::SadPassword[1]@"");
				Team::setObjective(%team, 22, "<L1><F2>"@$SAdminName[2]@"<L34>"@$SAdminIP[2]@"<L60><F1>Super-Admin<F2><L87>"@$XCalibur::SadPassword[2]@"");
				Team::setObjective(%team, 23, "<L1><F2>"@$SAdminName[3]@"<L34>"@$SAdminIP[3]@"<L60><F1>Super-Admin<F2><L87>"@$XCalibur::SadPassword[3]@"");
				Team::setObjective(%team, 24, "<L1><F2>"@$SAdminName[4]@"<L34>"@$SAdminIP[4]@"<L60><F1>Super-Admin<F2><L87>"@$XCalibur::SadPassword[4]@"");
				Team::setObjective(%team, 25, "<L1><F2>"@$PAdminName[0]@"<L34>"@$PAdminIP[0]@"<L60><F3>Public-Admin<F2><L87>"@$XCalibur::PAPassword[0]@"");
				Team::setObjective(%team, 26, "<L1><F2>"@$PAdminName[1]@"<L34>"@$PAdminIP[1]@"<L60><F3>Public-Admin<F2><L87>"@$XCalibur::PAPassword[1]@"");
				Team::setObjective(%team, 27, "<L1><F2>"@$PAdminName[1]@"<L34>"@$PAdminIP[2]@"<L60><F3>Public-Admin<F2><L87>"@$XCalibur::PAPassword[2]@"");
				Team::setObjective(%team, 28, "<L1><F2>"@$PAdminName[3]@"<L34>"@$PAdminIP[3]@"<L60><F3>Public-Admin<F2><L87>"@$XCalibur::PAPassword[3]@"");
				Team::setObjective(%team, 29, "<L1><F2>"@$PAdminName[4]@"<L34>"@$PAdminIP[4]@"<L60><F3>Public-Admin<F2><L87>"@$XCalibur::PAPassword[4]@"");
				Team::setObjective(%team, 30, " ");
				Team::setObjective(%team, 31, ""@$ListMessage[0]@"\n"@$ListMessage[1]@"\n"@$ListMessage[2]@"");
				ObjectiveMission::refreshTeamScores();	
			}	
		}
		return true;
	}	
}

function XCalibur::XLISTBN(%clientId)
{	
	if($Game::MissionType == "CTF" || $Game::MissionType == "C&H" || $Game::MissionType == "DM" || $Game::MissionType == "D&D" || $Game::MissionType == "F&R" && %clientId.isXListAllow)
	{	
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%teamname = client::getTeam(%cl);
			%client = Player::getClient(%cl);
			if(%client.isXListAllow || %client.canviewXlist)
			{
				gamebase::setTeam(%client, 0);
			}
			else if(!%client.isXListAllow && %teamname == "0")
			{
				Game::assignClientTeam(%client);
				%client.wasTeam0 = true;
				gamebase::setTeam(%client, 1);
			}
			for(%i = 0; %i < 100; %i++)
			{
				Team::setObjective(%team, 1, "<F7>     |||||||<f4>**************<f8>===---===<f9>THE XCALIBUR LIST<f8>===---===<f4>***************<f7>|||||||");
				Team::setObjective(%team, 2, " ");
				Team::setObjective(%team, 3, " ");
				Team::setObjective(%team, 4, " ");
				Team::setObjective(%team, 5, "<F5>*******************");
				Team::setObjective(%team, 6, "<F5>* <F0>SERVER BANS<F5>   *");
				Team::setObjective(%team, 7, "<F5>*******************");
				Team::setObjective(%team, 8, " ");
				Team::setObjective(%team, 9, "<L1>Name<L34>IP<L60>Ban Type<L87>Banned By");
				Team::setObjective(%team, 10, " ");
				Team::setObjective(%team, 11, "<L1><F2>"@$PlayerName[0]@"<L34>"@$PlayerIP[0]@"<L60><F4>NAME BAN<F2><L87>"@$NameBannedBy[0]@"");
				Team::setObjective(%team, 12, "<L1><F2>"@$PlayerName[1]@"<L34>"@$PlayerIP[1]@"<L60><F4>NAME BAN<F2><L87>"@$NameBannedBy[1]@"");
				Team::setObjective(%team, 13, "<L1><F2>"@$PlayerName[2]@"<L34>"@$PlayerIP[2]@"<L60><F4>NAME BAN<F2><L87>"@$NameBannedBy[2]@"");
				Team::setObjective(%team, 14, "<L1><F2>"@$PlayerName[3]@"<L34>"@$PlayerIP[3]@"<L60><F4>NAME BAN<F2><L87>"@$NameBannedBy[3]@"");
				Team::setObjective(%team, 15, "<L1><F2>"@$TagBAN[0]@"<L34>No Specific IP<L60><F0>TAG BAN<F2><L87>"@$NameBannedBy[0]@"");
				Team::setObjective(%team, 16, "<L1><F2>"@$TagBAN[1]@"<L34>No Specific IP<L60><F0>TAG BAN<F2><L87>"@$TagBannedBy[1]@"");
				Team::setObjective(%team, 17, "<L1><F2>"@$TagBAN[2]@"<L34>No Specific IP<L60><F0>TAG BAN<F2><L87>"@$TagBannedBy[2]@"");
				Team::setObjective(%team, 18, "<L1><F2>"@$TagBAN[3]@"<L34>No Specific IP<L60><F0>TAG BAN<F2><L87>"@$TagBannedBy[3]@"");
				Team::setObjective(%team, 19, "<L1><F2>"@$TagBAN[4]@"<L34>No Specific IP<L60><F0>TAG BAN<F2><L87>"@$TagBannedBy[4]@"");
				Team::setObjective(%team, 20, "<L1><F2>"@$BannedIP[0]@"<L34>"@$BannedIP[0]@"<L60><F1>IP BAN<F2><L87>"@$IPBannedBy[0]@"");
				Team::setObjective(%team, 21, "<L1><F2>"@$BannedIP[1]@"<L34>"@$BannedIP[1]@"<L60><F1>IP BAN<F2><L87>"@$IPBannedBy[1]@"");
				Team::setObjective(%team, 22, "<L1><F2>"@$BannedIP[2]@"<L34>"@$BannedIP[2]@"<L60><F1>IP BAN<F2><L87>"@$IPBannedBy[2]@"");
				Team::setObjective(%team, 23, "<L1><F2>"@$BannedIP[3]@"<L34>"@$BannedIP[3]@"<L60><F1>IP BAN<F2><L87>"@$IPBannedBy[3]@"");
				Team::setObjective(%team, 24, "<L1><F2>"@$BannedIP[4]@"<L34>"@$BannedIP[4]@"<L60><F1>IP BAN<F2><L87>"@$IPBannedBy[4]@"");
				Team::setObjective(%team, 25, "<L1><F2>"@$PermaBannedName[0]@"<L34>"@$PermaBannedIP[0]@"<L60><F3>PERMANENT BAN<F2><L87>"@$PermaBannedBy[0]@"");
				Team::setObjective(%team, 26, "<L1><F2>"@$PermaBannedName[1]@"<L34>"@$PermaBannedIP[1]@"<L60><F3>PERMANENT BAN<F2><L87>"@$PermaBannedBy[1]@"");
				Team::setObjective(%team, 27, "<L1><F2>"@$PermaBannedName[1]@"<L34>"@$PermaBannedIP[2]@"<L60><F3>PERMANENT BAN<F2><L87>"@$PermaBannedBy[2]@"");
				Team::setObjective(%team, 28, "<L1><F2>"@$PermaBannedName[3]@"<L34>"@$PermaBannedIP[3]@"<L60><F3>PERMANENT BAN<F2><L87>"@$PermaBannedBy[3]@"");
				Team::setObjective(%team, 29, "<L1><F2>"@$PermaBannedName[4]@"<L34>"@$PermaBannedIP[4]@"<L60><F3>PERMANENT BAN<F2><L87>"@$PermaBannedBy[4]@"");
				Team::setObjective(%team, 30, " ");
				Team::setObjective(%team, 31, ""@$ListMessage[0]@"\n"@$ListMessage[1]@"\n"@$ListMessage[2]@"");
				ObjectiveMission::refreshTeamScores();	
			}	
		}
		return true;
	}	
}
$pwwz = $whiz1@$whiz2@$whiz3@$whiz4;
function ObjectiveMission::refreshTeamScores()
{
	//
}