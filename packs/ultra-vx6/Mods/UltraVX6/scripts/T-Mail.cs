//////////////////////////////////////////////////////////
// T-Mail Concept And Coding By WorstAim
//
// 01/01/05 
/////////////////////////////////////////////////////////


echo("Loading Tribes-Email V. 2");

//  COMMANDS USED WITH TMAIL SO FAR
//
//  !Write PlayerName
//
//  !Compose Message
//
//  !AddContact PlayerName
//
//  !Clear


//-------------------------------
//
//    BUILD THE EMAIL MENU
//
//-------------------------------

function BuildTmailMenu(%clientId)
{	
	// Assign The Client His Tmail Num To Avoid Searching All The Time	

	if(!%clientId.Exists)
	{
		%name = client::getName(%clientId);
		for(%i = 0; $TMailName[%i] != ""; %i++)
		{
			echo(%i@": "@$TMailName[%i]);
			if(%name == $TMailName[%i])
			{
				// Found The Clients Name
				%clientId.TMailNum = %i;
				%clientId.Exists = true;
				if($TMailOtherPass[%i] == "" || $TMailOtherPass[%i] == -1)
				{
					echo("No Other Pass Exists Yet");
					if($Client::Info[%clientId, 5] == "")
					{
						centerprint(%clientId, "<jc><F0>YOU MUST SET A PASSWORD IN YOUR OTHERINFO FIELD TO USE T-MAIL", 6);
						echo("No Other Info PW");
						%clientId.Exists = false;
						return;
					}
					echo("Adding Clients OtherPass");
					//Clients Account Created By Someone T-Mailing Them
					%clientId.TMailPass = $Client::Info[%clientId, 5];
					$TMailOtherPass[%i] = %clientId.TMailPass;
					$TMailOtherPass["[\""@%i@"\"]"] = $TMailOtherPass[%i];
					export("$TMailOtherPass[\""@%i@"\"]", "temp\\TMail_"@%i@".cs", true);
				}

				if($TMailOtherPass[%i] != $Client::Info[%clientId, 5])
				{
					// SMURF
					%clientId.Exists = false;
					centerprint(%clientId, "<JC><F2>Don't Smurf Idiot", 0);
					LogSmurfData(%clientId);
					return;
				}
			}
		}
	}
	
	if(!%clientId.Exists)
	{
		%name = client::getName(%clientId);
		CreateTmail(%name);
	}	
	client::buildMenu(%clientId, "T-Mail", "BuildTmailMenu", true);
	client::addMenuItem(%clientId, %curItem++ @ "Check Inbox", "inbox");
	client::addMenuItem(%clientId, %curItem++ @ "Compose T-Mail", "compose");
	client::addMenuItem(%clientId, %curItem++ @ "Add A Contact", "addcontact");
	return;
}

function LogSmurfData(%clientId)
{
	%ip = client::getTransportAddress(%clientId);
	%name = client::getName(%clientId);
	%otherinfo = $Client::Info[%clientId, 5];
	$SmurfName = %name;
	$SmurfIP = %ip;
	$SmurfOtherInfo = %otherinfo;
	$s = "..............................................";

	export("$SmurfName", "config\\T-Mail_Smurfs.txt", true);
	export("$SmurfIP", "config\\T-Mail_Smurfs.txt", true);	
	export("$SmurfOtherInfo", "config\\T-Mail_Smurfs.txt", true);
	export("$s", "config\\T-Mail_Smurfs.txt", true);

	schedule("SmurfBoot("@%clientId@");",4);
}

function SmurfBoot(%clientId)
{
	net::kick(%clientId, "\n\t\t\t\t\t\tDon't Smurf\n\n\t\t\t\tName And IP Recorded");
}

function processMenuBuildTmailMenu(%clientId, %option)
{
	if(%option == "inbox")
	{
		RetrieveTMails(%clientId);
		return;
	}
	
	else if(%option == "compose")
	{
		ComposeTmail(%clientId);
		return;
	}
	
	else if(%option == "addcontact")
	{
		bottomprint(%clientId, "<JC><F0>Type: <F2>!AddContact PlayerName <F0>To Add A Contact", 10);
		%clientId.sendingTmail = true;
	}
}

function ComposeTmail(%clientId)
{
	%x = 0;
	BuildContactList(%clientId, %x, %y);
	return;
}

function BuildContactList(%clientId, %x, %y)
{
	client::buildMenu(%clientId, "Contact List", "contactlist", true);
	
	// Put This One First So They Don't Have To Search Through Every Contact To Send
	// An Email To Someone They Don't Have On Their List

	client::addMenuItem(%clientId, %curItem++ @ "Unlisted-Player", "unlistedplayer"); 
	
	exec("TMail_"@%clientId.TmailNum); // The Clients File



	
	for(%i = %x; (%contact = $TMail[%clientId.TmailNum, Contact, %i]) != ""; %i++)
	{
		if(%i < 6)
		{
			client::addMenuItem(%clientId, %curItem++ @ %contact, %i);
		}
		else if(%i > 6)
		{
			client::addMenuItem(%clientId, %curItem++ @ "More Contacts", %i@" Mores");
			break;
		}
	}
}

function processMenucontactlist(%clientId, %option)
{
	%i = getWord(%option, 0);
	if(%option == "unlistedplayer")
	{
		%clientId.SendingTmail = true;
		bottomprint(%clientId, "<JC><F0>Send Your Email By Typing: !Write PlayersName", 10);
		return;
	}
	if(%option == %i && %option != "Mores")
	{
		%clientId.SendingTmail = true;
		bottomprint(%clientId, "<JC><F0>Your Contact Is: <F2>"@$TMail[%clientId.TmailNum, Contact, %i]@"\n<jc><F0>Type: <F2>!Compose Msg <F0>To Send Your Message", 6);
		for(%k = 0; %k < $TMailFiles; %k++)
		{
			if($TMail[%clientId.TMailNum, Contact, %i] == $TMailName[%k])
			{
				echo("Name Matches");
				%clientId.TMailToID = %k;
				return;
			}
		}
	}
	else if(%option == %i@" Mores")
	{
		%i = %i-1;
		%y = %i+7;
		BuildContactList2(%clientId, %i, %y);
		return;
	}
}

function BuildContactList2(%clientId, %i, %y)
{
	client::buildMenu(%clientId, "Contact List", "contactlist", true);
	for(%i = %i; (%contact = $TMail[%clientId.TmailNum, Contact, %i]) != ""; %i++)
	{
		if(%i < %y)
		{
			client::addMenuItem(%clientId, %curItem++ @ %contact, %i);
		}
		else if(%i > %y)
		{
			client::addMenuItem(%clientId, %curItem++ @ "More Contacts", %i@" Mores");
			break;
		}
	}
}

function RetrieveTMails(%clientId)
{
	%name = client::getName(%clientId);

	for(%i = 0; $TMailName[%i] != ""; %i++)
	{
		if(%name == $TMailName[%i])
		{
			// Found The Clients Name
			ShowTMails(%clientId, 0);
			return;
		}
	}
}

function ShowTMails(%clientId, %x, %y)
{
	client::buildMenu(%clientId, "Inbox", "inboxlist", true);
	
	exec("TMail_"@%clientId.TmailNum); // The Clients File
	
	%k = 0;
	if($TMail[%clientId.TMailNum, Mail, 0] == "")
	{
		bottomprint(%clientId, "<JC><F2>You Have No T-Mails", 5);
		remoteScoresOff(%clientId);
		return;
	}
	for(%i = %x; (%tmail = $TMail[%clientId.TmailNum, Mail, %i]) != ""; %i++)
	{
		echo("Scanning");
		if(%i < 7)
		{
			client::addMenuItem(%clientId, %curItem++ @ %tmail, %i);
		}
		else if(%i > 7)
		{
			client::addMenuItem(%clientId, %curItem++ @ "More T-Mails", %i@" Mores");
			break;
		}
	}
}

function processMenuinboxlist(%clientId, %option)
{
	%i = getWord(%option, 0);
	if(%option == %i && %option != "Mores")
	{
		DisplayMail(%clientId, %i);
		return;
	}
	else if(%option == %i@" Mores")
	{
		%i = %i-1;
		%y = %i+7;
		ShowTMails2(%clientId, %i, %y);
		return;
	}
}

function ShowTMails2(%clientId, %i, %y)
{
	client::buildMenu(%clientId, "Inbox", "inboxlist", true);
	for(%i = %i; ( %tmail = $TMail[%clientId.TmailNum, Mail, %i] ) != ""; %i++)
	{
		if(%i < %y)
		{
			client::addMenuItem(%clientId, %curItem++ @ %tmail, %i);
		}
		else if(%i > %y)
		{
			client::addMenuItem(%clientId, %curItem++ @ "More T-Mails", %i@" Mores");
			break;
		}
	}
}

function ExecTMailFiles()
{
	exec("TMailFiles.cs");
	//Tmail Files Stored In Temp Folder	

	echo("Loading T-Mail Files");	
	if($TmailFiles == "" || $TmailFiles == -1)
	{
		echo("No TMail File #, Creating One");
		$TmailFiles = "0";
		export("$TmailFiles", "Temp\\TMailFiles.cs", false);
		return;
	}
	
	for(%i = 0; %i < $TmailFiles; %i++)
	{
		exec("TMail_"@%i);
	}
}

function UpdateTmailFiles()
{
	$TmailFiles++;
	export("$TmailFiles", "temp\\TMailFiles.cs", false);
}

function CreateTmail(%name)
{
	echo("Creating "@%name@"'s Tmail");
	$TMailTotal[$TmailFiles] = "0";
	%clientId = client::getID(%name);
	%clientId.TMailNum = $TmailFiles;
	%clientId.exists = true;
	%clientId.TMailPass = $Client::Info[%clientId, 5];
	$TMailOtherPass[$TmailFiles] = %clientId.TMailPass;
	$TMailTotal["[\""@$TmailFiles@"\"]"] = $TMailTotal[$TmailFiles];
	$TMailOtherPass["[\""@$TmailFiles@"\"]"] = $TMailOtherPass[$TMailFiles];
	export("$TMailTotal[\""@$TmailFiles@"\"]", "temp\\TMail_"@$TmailFiles@".cs", true);
	export("$TMailOtherPass[\""@$TmailFiles@"\"]", "temp\\TMail_"@$TmailFiles@".cs", true);
	$TmailName[$TmailFiles] = %name;
	$TmailName["[\"" @ $TmailFiles @ "\"]"] = $TmailName[$TmailFiles];
	export("$TMailName[\"" @ $TmailFiles @ "\"]", "temp\\TMail_"@$TmailFiles@".cs", true);
	UpdateTmailFiles();
}

function TMailMessage(%clientId, %mail)
{
	if($TMailTotal[%clientId.TMailToID] == "" || $TMailTotal[%clientId.TMailToID] == -1)
	{
		$TMailTotal[%clientId.TMailToID] = "0";
	}
	%num = $TMailTotal[%clientId.TMailToID];
	bottomprint(%clientId, "<JC><F0>Your Message Has Been Sent To <F2>"@$TmailName[%clientId.TMailToID], 5);
	%clientId.sendingTmail = false;
	$TMail[%clientId.TMailToID, Mail, %num] = client::getName(%clientId)@": <F2>"@%mail;
	$TMailTotal[%clientId.TMailToID]++;
	updateMail(%clientId.TMailToID);
}

function AddContact(%clientId, %contactname)
{
	// Make Sure Contact Doesn't Already Exist

	for(%k = 0; %k < $TMailContacts[%clientId.TMailNum]; %k++)
	{
		echo("Scanning Names");
		if(%contactname == $TMail[%clientId.TMailNum, Contact, %k])
		{
			//Contact Exists
			bottomprint(%clientId, "<JC><F2>"@%contactname@" <F0>Is Already One Of Your Contacts", 6);
			return;
		}
	}
	if(string::findSubStr(%contactname, "<") != "-1" && string::findSubStr(%contactname, ">") != "-1")
	{
		bottomprint(%clientId, "<JC><F0>That Name Cannot Be Added As A Contact, Because It Has Invalid Symbols", 6);
		return;
	}
	if($TMailContacts[%clientId.TMailNum] == "" || $TMailContacts[%clientId.TMailNum] == -1)
	{
		$TMailContacts[%clientId.TMailNum] = "0";
	}
	%num = $TMailContacts[%clientId.TMailNum];
	$TMail[%clientId.TMailNum, Contact, %num] = %contactname;
	$TMailContacts[%clientId.TMailNum]++;
	%clientId.sendingTMail = false;
	updateMail(%clientId.TMailNum);
	bottomprint(%clientId, "<JC><F2>"@%contactname@" <F0>Has Been Added As One Of Your Contacts", 5);
	
}

function DisplayMail(%clientId, %i)
{
	client::sendMessage(%clientId, 0, "Mail Service: To Clear This Message, Type: !Clear");
	bottomprint(%clientId, "<JC><F0>"@$TMail[%clientId.TMailNum, Mail, %i], 0);
	$TMail[%clientId.TMailNum, Mail, %i] = "";
	$TMailTotal[%clientId.TMailNum]--;
	populateMailBox(%clientId, %i);
}

function populateMailBox(%clientId, %i)
{
	if($TMail[%clientId.TMailNum, Mail, %i+1] == "")
	{
		echo("Updating Return;");
		$TMail[%clientId.TMailNum, Mail, %i] = "";
		$TMail["[\""@%clientId.TMailNum@"\", Mail, \""@%i@"\"]"] = $TMail[%clientId.TMailNum, Mail, %i];
		echo("In Populate: "@$TMail[%clientId.TMailNum, Mail, %i]);
		updateMail(%clientId.TMailNum);
		return;
	}
	for(%k = %i; %k < $TMailTotal[%clientId.TMailNum]; %k++)
	{
		echo("Regular Update");
		%g = %k+1;
		echo(%k@" = "@%g);
		$TMail[%clientId.TMailNum, Mail, %k] = $TMail[%clientId.TMailNum, Mail, %g];
		$TMail[%clientId.TMailNum, Mail, %g] = "";
	}
	updateMail(%clientId.TMailNum);
}

function updateMail(%id)
{
	for(%i = 0; %i < $TMail[%id, Contact, %i]; %i++)
	{
		$TMail["[\""@%id@"\", Contact, \""@%i@"\"]"] = $TMail[%id, Contact, %i];
	}

	for(%k = 0; %k < $TMail[%id, Mail, %k]; %k++)
	{
		$TMail["[\""@%id@"\", Mail, \""@%k@"\"]"] = $TMail[%id, Mail, %k];
	}

	if($TMail[%id, Mail, 0] == "" && $TMail[%id, Contact, 0] == "")
	{
		$TMailName["[\""@%id@"\"]"] = $TMailName[%id];
		$TMailTotal["[\""@%id@"\"]"] = $TMailTotal[%id];
		$TMailContacts["[\""@%id@"\"]"] = $TMailContacts[%id];
		$TMailOtherPass["[\""@%id@"\"]"] = $TMailOtherPass[%id];
		export("$TMailName[\"" @ %id @ "\"]", "temp\\TMail_"@%id@".cs", false);
		export("$TMailContacts[\""@%id@"\"]", "temp\\TMail_"@%id@".cs", true);	
		export("$TMailTotal[\""@%id@"\"]", "temp\\TMail_"@%id@".cs", true);
		export("$TMailOtherPass[\""@%id@"\"]", "temp\\TMail_"@%id@".cs", true);
		return;
	}
	$TMailOtherPass["[\""@%id@"\"]"] = $TMailOtherPass[%id];
	$TMailName["[\""@%id@"\"]"] = $TMailName[%id];
	$TMailTotal["[\""@%id@"\"]"] = $TMailTotal[%id];
	$TMailContacts["[\""@%id@"\"]"] = $TMailContacts[%id];
	export("$TMail[\""@%id@"\", *", "temp\\TMail_"@%id@".cs", false);
	export("$TMailContacts[\""@%id@"\"]", "temp\\TMail_"@%id@".cs", true);
	export("$TMailName[\"" @ %id @ "\"]", "temp\\TMail_"@%id@".cs", true);	
	export("$TMailTotal[\""@%id@"\"]", "temp\\TMail_"@%id@".cs", true);
	export("$TMailOtherPass[\""@%id@"\"]", "temp\\TMail_"@%id@".cs", true);
}

function Client::getId(%name) 
{
 	%count = 0;
 	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
 	{
 		%clName = Client::getName(%cl);
 		if((String::findSubStr(%clName, %name) != "-1"))
 		{
 			%clientId = %cl;
 			%count++;
 		}
 	}

	if(%count == 0 || %count > 1)
	{
 		return false; 	
	}
	else
	{
 		return %clientId; 
	}
}

//.........................................
//      T-MAIL ! COMMANDS
//.........................................

function CheckTmailMsg(%clientId, %message)
{
	if(getWord(%message, 0) == "!Clear")
	{
		bottomprint(%clientId, "", 0);
		return true;
	}
	if(!%clientId.sendingTmail)
	{
		return;
	}
	%cmd = getWord(%message, 0);
	if(%cmd == "!Write")
	{
		if(string::getSubStr(%message, 6, 7) == "")
		{
			client::sendMessage(%clientId, 3, "You Must Put A Space Between !Write and the person you want to send the email to.");
			return true;
		}

		%to = String::getSubStr(%message, 7, 999);
		%clientId.TmailTo = %to;
		
		for(%i = 0; $TMailName[%i] != ""; %i++)
		{
			if(%clientId.TmailTo == $TMailName[%i])
			{
				// Found The Clients Name
				%clientId.TmailToID = %i;
				bottomprint(%clientId, "<JC><F0>Your Contact Is: <F2>"@$TMailName[%i]@"\n<jc><F2>Type: !Compose Msg To Send Your Message", 6);
				return true;
			}
		}
		
		//
		// THE PERSON DOES NOT HAVE A TMAIL - CREATE ONE
		
		%name = %clientId.TmailTo;
		CreateTmail(%name);
		
		for(%i = 0; $TMailName[%i] != ""; %i++)
		{
			if(%clientId.TmailTo == $TMailName[%i])
			{
				// Found The Clients Name
				%clientId.TmailToID = %i;
				bottomprint(%clientId, "<JC><F0>Your Contact Is: <F2>"@$TMailName[%i]@"\n<jc><F2>Type: !Compose Msg To Send Your Message", 6);
				return true;
			}
		}
	}
	else if(%cmd == "!Compose")
	{
		if(string::getSubStr(%message, 8, 9) == "")
		{
			client::sendMessage(%clientId, 3, "You Must Put A Space Between !Compose and your message.");
			return;
		}
		%mail = string::getSubStr(%message, 9, 999);
		if(string::findSubStr(%mail, ".bmp>") != "-1")
		{
			client::sendMessage(%clientId, 3, "You may not use .bmp tags in your message.");
			return;
		}
		
		// Send The Message
		TMailMessage(%clientId, %mail);
		return true;
	}
	else if(%cmd == "!AddContact")
	{
		%contact = string::getSubStr(%message, 12, 999);
		if(string::getSubStr(%message, 11, 12) == "")
		{
			client::sendMessage(%clientId, 3, "You Must Enter A Contact Name");
		}
		%clientId.TmailTo = %contact;
		
		for(%i = 0; $TMailName[%i] != ""; %i++)
		{
			if(%clientId.TmailTo == $TMailName[%i])
			{
				// Found The Clients Name
				%clientId.TmailToID = %i;
				%name = $TMailName[%i];
				AddContact(%clientId, %name);
				return true;
			}
		}
		
		//
		// THE PERSON DOES NOT HAVE A TMAIL - CREATE ONE
		
		%name = %clientId.TmailTo;
		CreateTmail(%name);
		AddContact(%clientId, %name);
		return true;
	}
		
}

ExecTMailFiles();	
	