// Comchat Functions. These are made by |*|w00|*|Grey. Thanks to ideas from [GL]VRWarper
// [GL]JadaCyrus and ThE eViL iDiOt.

function bottagban(%name, %clientId)
{	
	CheckTagBanBot(%name, %clientId);
	if(!$tagbanned)
	{
		TagBan(%name);
		messageall(1,$adminbotname@": The Tag ->> "@%name@" <<- Is now in my Database for Banning. ~wmine_act.wav");
	}
}
function botnameban(%name, %clientId)
{	
	CheckNameBanBot(%name, %clientId);
	if(!$namebanned)
	{
		NameBan(%name);
		messageall(1,$adminbotname@": The Name ->> "@%name@" <<- Is now in my Database for Banning. ~wmine_act.wav");
	}
}

function TagBan(%name)
{
	for(%i=0;$TagBAN2[%i] != "";%i++)
	{
	}
	$TagBAN2[%i] = %name;
	SaveTagBanList();
}
function NameBan(%name)
{
	for(%i=0;$NameBAN2[%i] != "";%i++)
	{
	}
	$NameBAN2[%i] = %name;
	SaveNameBanList();
}

function SaveTagBanList()
{
      export("$TagBAN2*", "config\\TagBanList.cs", true);
	echo("TagBan List Saved");
}
function SaveNameBanList()
{
      export("$NameBAN2*", "config\\NameBanList.cs", true);
	echo("NameBan List Saved");
}

function CheckItem(%item)
{
	$ItemExist = false;
	for(%i=0; $Gimme[%i] != ""; %i++)
	{
		if((String::findSubStr($Gimme[%i], %item) != "-1"))
		{
			%item = $Gimme[%i];
			$ItemExist = true;
			echo(""@%item@"");
		}
		
	}
	return(%item);
}

function CheckTagBanBot(%name, %clientId)
{
	$tagbanned = false;
	%ip = Client::getTransportAddress(%clientId);
	%check = %name;
	echo($adminbotname @": Checking TagBAN for Comchat purposes. Checking for "@%check);
	for(%i=0; %i < 30 ;%i++)
	{
		if((String::findSubStr($TagBAN[%i], %name) != "-1") || (String::findSubStr($TagBAN2[%i], %name) != "-1"))
		{
			echo($adminbotname @": -->>WARNING<<-- TAGBAN : " @ $TagBAN[%i]);
			if(%count = "")
				%count = 1;
			else
				%count = %count + 1;
			$tagbanned = true;
			if(%count = "1")
			{
				client::Sendmessage(%clientId,1,$adminbotname@": This Tag is already banned. It cannot be banned again. ~waccess_denied.wav");
			}

		}
	
	}
		
}
function CheckNameBanBot(%name, %clientId)
{
	$namebanned = false;
	%ip = Client::getTransportAddress(%clientId);
	%check = %name;
	echo($adminbotname @": Checking NameBAN for Comchat purposes. Checking for "@%check);
	for(%i=0; %i <30 ;%i++)
	{
		if((String::findSubStr($NameBAN[%i], %name) != "-1") || (String::findSubStr($NameBAN[%i], %name) != "-1"))
		{
			echo($adminbotname @": -->>WARNING<<-- NAMEBAN : " @ $NameBAN[%i]);
			client::Sendmessage(%clientId,1,$adminbotname@": This Name is already banned. It cannot be banned again. ~waccess_denied.wav");
			$namebanned = true;
			
		}
	
	}
		
}

function botban(%goodname,%clientId, %client)
{	
	%ip = Client::getTransportAddress(%client);
	%admin = Client::getName(%clientId);
	%client.adminban = true;
	client::sendmessage(%client,1,$adminbotname @": You are banned by order of a Super-Admin with my authorisation");
	client::sendmessage(%clientId,1,$adminbotname @": Authorisation approved... banning -> "@%goodname@" <- ~wmine_act.wav");
	echo($adminbotname @": -->>WARNING<<-- ComChatBan : " @ %goodname@ " banned by "@%admin);
	BanList::add(%ip);
	SHBanName(%goodname);
	SHBan(%ip);
	HaVoCKick(%client);
	
}

function aquirebotban(%name, %clientId)
{
	echo("Ban Called from GreyBOT functions");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%name2 = Client::getName(%cl);
		if((String::findSubStr(%name2, %name) != "-1") && !%cl.isSuperAdmin)
		{
			   echo("Searching for players to ban");
			   %client = Player::getClient(%cl);
			   %goodname = Client::getName(%cl);

			          if(%count == "")
			          {
			          	    %count = 1;
			          }
			          else
			          {
               	                 %count = %count + 1; 
			          }

			   echo("Number Found = "@%count@" Name is: "@%goodname);
            } 
          	
      } 
	if(%count == "1")
	{
		botban(%goodname, %clientId, %client);
	}
	else
	{
		client::sendmessage(%clientId,1,$adminbotname@": There is more than one person connected with that as part of their name. Please Narrow Search.");
	}

   
}

function botkick(%clientId, %name)
{
	%admin = Client::getName(%clientId);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%name2 = Client::getName(%cl);
		if((String::findSubStr(%name2, %name) != "-1") && !%cl.isSuperAdmin)
		{
			%client = Player::getClient(%cl);
			client::sendmessage(%client,1,$adminbotname @": You are kicked by order of a Super-Admin with my authorisation");
			client::sendmessage(%clientId,1,$adminbotname @": Authorised... kicking -> "@%name2@" <- ~wmine_act.wav");
			echo($adminbotname @": -->>WARNING<<-- ComChatKick : " @ %name2@ " kicked by "@%admin);
			HaVoCKick(%client);
		}
		

   	}

}
function impersonate(%clientId, %name, %message)
{
	%admin = Client::getName(%clientId);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%name2 = Client::getName(%cl);
		if((String::findSubStr(%name2, %name) != "-1") && !%cl.isSuperAdmin)
		{
			messageall(2, %name2@": "@%message);
		}
		else if((String::findSubStr(%name2, %name) != "-1") && %cl.isSuperAdmin)
		{
			messageall(2, %admin@": I just tried to Impersonate "@%name2@". I tried to make him say, ' "@%message@" '. I know realise the error of my ways and I would like to Apologise.");
		}

   	}

}

function private(%clientId, %name, %message)
{
	%admin = Client::getName(%clientId);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%name2 = Client::getName(%cl);
		if((String::findSubStr(%name2, %name) != "-1"))
		{
			%client = Player::getClient(%cl);
			%goodname = Client::getName(%cl);

			if(%count == "")
			{
				%count = 1;
		      }
			else
			{
               	      %count = %count + 1; 
			}

			
		}
		
   	}
      if(%count == "1")
	{
		privatemessage(%clientId, %goodname, %message, %client);
	}
	else if(%count > "1")
	{
		client::sendmessage(%clientId,1,$adminbotname@": There is more than one person connected with that as part of their name. Please Narrow Search.~waccess_denied.wav");
	}
	else
	{
		client::sendmessage(%clientId,1,$adminbotname@": You have selected either no name... or an unsuitable name.~waccess_denied.wav");
	}	
		
}
function privatemessage(%clientId,%goodname,%message,%client)
{
	%admin = Client::getName(%clientId);
	client::sendmessage(%client,3, "["@%admin@": PRIVATE] "@%message@"~wmine_act.wav");
	client::sendmessage(%clientId,3, "[Private - "@%goodname@"] "@%message@"~wmine_act.wav");
}

exec("givemefuncs.cs");
