// ----------------------------------------------------------------------------
// Cash Handling
// --
// Inspired by K0RN
// Coded By KingTomato
// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
// Summary:
//
// On join to a server, each user is given $0.00 At that point the user must
// either login to an existing account, or create one. Should they create an
// account, they must enter a password to later login to that account.
// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
// Mode Activation
// --
// This will load or unload th emod depending on how you call it. Use true to
// load money, and false to unload it.

function Money::Activate(%enabled)
{
	$Money::Enabled = %enabled;

	// Enable money mode
	if ($Money::Enabled)
	{
		$itemPopTime = $Money::PopTime;

		Money::Init();

		// Load each user individually.
		for (%cl = Client::getFirst(); %cl != -1; %cl = Client::GetNext(%cl))
		{
			Money::LoadProfile(%cl);
			Money::GiveWeapons(%cl);
		}

		messageAll(0, "Client spending has been enabled.");
		messageAll(0, "Please type .spending for more information.");
	}
	else
	{
		$itemPopTime = $PB::itemPopTime;

		// Unload all the user profiles.
		for (%cl = Client::getFirst(); %cl != -1; %cl = Client::GetNext(%cl))
		{
			Money::UnloadProfile(%cl);
			Money::GiveWeapons(%cl);
		}

		Money::Cleanup();

		messageAll(0, "Client spending has been disabled.");
	}
}

// ----------------------------------------------------------------------------
// Initialization
// --
// This will load the main mod files

function Money::Init()
{
	// Save some memory if it isn't default to be loaded
	if (!$Money::Enabled)
		return;

	// This is what the user ID is based off of.
	$Money::Members = 0;

	if (isFile("config\\Money.cs"))
	{
		// Passwords
		exec("Money.cs");
		echo("Money files loaded.");
	}

	Money::BackupLoop();
}

// ----------------------------------------------------------------------------
// Profile handling
// --
// Loads, Unloads, creates, and delete profiles

function Money::BackupProfile(%client)
{
	if (%client.userId != -1)
	{
		%uid = %client.userId;

		export("$Money::User" @ %uid @ "_*", "temp\\Money_User" @ %uid @ ".cs");

		$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;
	}
}

function Money::CreateProfile(%client, %password)
{
	%id	= $Money::Members++;
	%ip	= String::GetSubStr(Client::getTransportAddress(%client), 3, 16);
	%colon	= String::findSubStr(%ip, ":");
	%ip	= String::getSubStr(%ip, 0, %colon);
		
	$Money::Password[%password]	= %id;
	$Money::User[%id, Name]		= Client::GetName(%client);
	$Money::User[%id, IP]		= %ip;

	$Money::User[%id, Money]	= $Money::StartAmount;

	$Money::User[%id, Backpack]	= "";
	$Money::User[%id, Tool]		= "";
	$Money::User[%id, Weapon]	= "";
	$Money::User[%id, BuyNade]	= "";

	$Money::User[%id, Kills]	= 0;
	$Money::User[%id, HeadShot]	= 0;
	$Money::User[%id, Deaths]	= 0;
	$Money::User[%id, Suicides]	= 0;
	$Money::User[%id, Captures]	= 0;
	$Money::User[%id, Returns]	= 0;

	%client.userId = %id;
	%client.userPass = %password;

	Money::BackupProfile(%client);
	export("$Money::Password*", "config\\Money.cs");
	export("$Money::Members", "config\\Money.cs", true);

	return %id;
}

function Money::LoadProfile(%client)
{
	if (%client.userId != -1)
	{
		%uid = %client.userId;

		$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;

		if (isFile("temp\\Money_User" @ %uid @ ".cs"))
		{
			if ($Money::User[%uid, Money] == "")
				exec("Money_User" @ %uid @ ".cs");

			%ip	= String::GetSubStr(Client::getTransportAddress(%client), 3, 16);
			%colon	= String::findSubStr(%ip, ":");
			%ip	= String::getSubStr(%ip, 0, %colon);

			// update name and ip
			$Money::User[%uid, Name] = Client::getName(%client);
			$Money::User[%uid, IP] = %ip;

			messageAllExcept(%client, 0, Client::getName(%client) @ " is now logged in to " @ $Money::User[%uid, Name] @ "'s account.");
			Client::sendMessage(%client, 0, "You are now logged in.");
			bottomPrint(%client, "<jc><f2>Current Balances\n"
				@ "<f1>Account funds: <f0>$" @ $Money::User[%uid, Money] @ "\n"
				@ "<f1>Kills / Deaths / Suicides: <f0>$" @ $Money::User[%uid, Kills] @ " <f1>/<f0> "
				@ $Money::User[%uid, Deaths] @ " <f1>/<f0> " @ $Money::User[%uid, Suicides], 10);
			return true;
		}
		else
		{
			deleteVariables("$Money::Password" @ %client.userPass);
			%client.userId = -1;
			%client.userPass = "";

			Client::SendMessage(%client, 0, "Sorry, but we were unable to locate your user profile. Please create a new profile.");
		}
	}
	return false;
}

function Money::UnloadProfile(%client)
{
	if (%client.userId != -1)
	{
		Money::BackupProfile(%client);
		deleteVariables("$Money::User" @ %uid @ "_*");

		%client.userId = -1;
		%client.userPass = "";		
	}
}

// ----------------------------------------------------------------------------
// Backup current accounts

function Money::Backup()
{
	if ($Money::Enabled)
	{
		for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			Money::BackupProfile(%cl);

		export("$Money::Password*", "config\\Money.cs");
		export("$Money::Members", "config\\Money.cs", true);
	}
}

function Money::BackupLoop()
{
	Money::Backup();

	if ($Money::Enabled)
		schedule("Money::BackupLoop();", $Money::BackupTime);
}

function Money::Cleanup()
{
	deleteVariables("$Money::User*");
	deleteVariables("$Money::Password*");
	deleteVariables("$Money::Members");
}

// ----------------------------------------------------------------------------
// Create user

function Money::createUser(%client, %password)
{
	if (%client.userId != -1)
	{
		Client::sendMessage(%client, 0, "You are already logged into an account.");
	}
	else if (!Money::ValidPassword(%password))
	{
		%min = getWord($Money::PassLength, 0);
		%max = getWord($Money::PassLength, 1);

		Client::SendMessage(%client, 0, "The password you have chosen is invalid. A password msut be one word, and be made up of letters and/or numbers.");
		Client::SendMessage(%client, 0, "Additionally, the password must be between " @ %min @ " and " @ %max @ " characters.");
	}
	else if ($Money::Password[%password] != "")
	{
		Client::SendMessage(%client, 0, "The password you have chosen is invalid. Please think of a new password.");
	}
	else
	{
		%id = Money::CreateProfile(%client, %password);

		bottomPrint(%client,
			"<jc><f2>Account Status\n\n<f1>You are now logged in as<f0> " @ $Money::User[%id, Name] @
			"\n<f1>You have been given a starting balance of <f0>$" @ $Money::User[%id, Money], 10);
		Client::sendMessage(%client, 0,
			"The password you have chosen is '" @ %password @ "'. " @
			"To login again later, type \".login " @ %password @ "\".");
		Money::Backup();
		return true;
	}
	return false;
}

// ----------------------------------------------------------------------------
// Logging in

function Money::Login(%client, %password)
{
	if (%client.userId != -1)
		Client::sendMessage(%client, 0, "You are already logged into an account.");
	else if (%password == "")
		Client::SendMessage(%client, 0, "Please provide a login password.");
	else if ((%userId = $Money::Password[%password]) != "")
	{
		if (Money::SamePerson(%client, %userId))
		{
			%client.userId = %userId;
			%client.userPass = %password;

			return Money::LoadProfile(%client);
		}
	}
	else
		Client::SendMessage(%client, 0, "The password you provided is incorrect.");
	return false;
}

// ----------------------------------------------------------------------------
// Change Password

function Money::ChangePassword(%client, %password)
{
	if (%client.userId != -1)
	{
		if (Money::ValidPassword(%password))
		{
			if ($Money::Password[%password] == "")
			{
				deleteVariables("$Money::Password" @ %client.userPass);
				$Money::Password[%password] = %client.userId;
				export("$Money::Password*", "config\\Money.cs");
				export("$Money::Members", "config\\Money.cs", true);

				Client::sendMessage(%client, 0, "You have successfully changed your password to '" @ %password @ "'.");
			}
			else
				Client::sendMessage(%client, 0, "The password '" @ %password @ "' is invalid. Please use another password.");
		}
		else
			Client::sendMessage(%client, 0, "Invalid password. Must contain only letters and numbers.");
	}
	else
		Client::sendMessage(%client, 0, "You must be logged in to use this command.");
}

// ----------------------------------------------------------------------------
// Validation

function Money::ValidPassword(%pass)
{
	%valid = "abcdefghijklmnopqrstuvwxyz0123456789";
	for (%a = 0; (%letter = String::getSubStr(%pass, %a, 1)) != ""; %a++)
		if (String::findSubStr(%valid, %letter) == -1)
			return false;

	%min = getWord($Money::PassLength, 0);
	%max = getWord($Money::PassLength, 1);
	for (%a = 0; String::GetSubStr(%pass, %a, 1) != ""; %a++) {}
	if ((%a < %min) || (%a > %max))
		return false;


	%invalid = "password Password pass Pass abc123 paintball Paintball pb PB";
	for (%a = 0; (%word = getWord(%invalid, %a)) != -1; %a++)
		if (%pass == %word)
			return false;

	return true;
}

function Money::SamePerson(%client, %uid)
{
	$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;

	if (!$Money::StrictLogin)
		return true;

	if (isFile("temp\\Money_User" @ %uid @ ".cs"))
	{
		exec("Money_User" @ %uid @ ".cs");

		%ip = String::GetSubStr(Client::getTransportAddress(%client), 3, 16);
		%colon = String::findSubStr(%ip, ":");
		%ip = String::getSubStr(%ip, 0, %colon);

		if (($Money::User[%uid, Name] != Client::GetName(%client)) && ($Money::User[%uid, Ip] != %ip))
		{
			Client::sendMessage(%client, 0,
				"The username and/or IP do not match that of the owner of this account.");
			deleteVariables("$Money::User" @ %uid @ "_*");
		}
		else
			return true;
	}
	else
	{
		deleteVariables("$Money::Password" @ %client.userPass);
		%client.userId = -1;
		%client.userPass = "";

		Client::SendMessage(%client, 0, "Sorry, but we were unable to locate your user profile. Please create a new profile.");
	}

	return false;

}

// ----------------------------------------------------------------------------
// Give Weapons

function Money::GiveWeapons(%client)
{
	%player = Client::getOwnedObject(%client);

	if ($PB::Debug)
		echo(sprintf("Money::GiveWeapons(%1);", %client));

	if ((%client.observerMode == "JustJoined") || (Observer::isObserver(%client)) || (Player::isDead(%player)))
		return;

	%max = getNumItems();
	for (%a = 0; %a < %max; %a++)
	{
		%item = getItemData(%a);

		if (%item.className == Armor)
			continue;

		Player::SetItemCount(%client, %item, 0);
		if ($PB::Debug)
			echo("Removing item " @ %item);
	}

	if ($Money::Enabled)
	{
		if (%client.userId != -1)
		{
			%client.spawn = 1;

			%items = "Backpack Tool Weapon";
			for (%a = 0; (%item = getWord(%items, %a)) != -1; %a++)
				if ((%buy = Money::Get(%client, %item)) != "")
					buyItem(%client, %buy);

			%client.spawn = "";
		}
	}
	else
	{
		if (%client.SpawnBuy[Pack] == "")
			processMenuSpawnArmor(%client, "Weapon");
		else
		{
			%client.spawn = 1;
			buyItem(%client, Grenade);
			buyItem(%client, %client.SpawnBuy[Weapon]);
			buyItem(%client, %client.SpawnBuy[Pack]);
			%client.spawn = "";
		}
	}

	echo("I know this does the loop through \"could not find player\"");
	echo("I'm working ona  way to stop that, but until now it will continue");
	echo("to do so. Sorry. -KT");
}

// ----------------------------------------------------------------------------
// Increase/Decrease/Set/Get count

function Money::Inc(%client, %item, %amount)
{
	if ($PB::Debug)
		echo(sprintf("Money::Inc(%1, %2, %3);", %client, %item, %amount));

	if (%amount == "")
		%amount = 1;

	if (%client.userID == -1)
		return;

	$Money::User[%client.userId, %item] += %amount;

	Client::setInventoryText(%client, "<f1><jc>Current Balance: $" @ $Money::User[%client.userId, Money]);

	return $Money::User[%client.userId, %item];
}

function Money::Dec(%client, %item, %amount)
{
	if ($PB::Debug)
		echo(sprintf("Money::Dec(%1, %2, %3);", %client, %item, %amount));

	if (%amount == "")
		%amount = 1;

	if (%client.userID == -1)
		return;

	if (($Money::User[%client.userId, %item] - %amount) < 0)
		$Money::User[%client.userId, %item] = 0;
	else
		$Money::User[%client.userId, %item] -= %amount;

	Client::setInventoryText(%client, "<f1><jc>Current Balance: $" @ $Money::User[%client.userId, Money]);

	return $Money::User[%client.userId, %item];
}

function Money::Set(%client, %item, %value)
{
	if ($PB::Debug)
		echo(sprintf("Money::Set(%1, %2, %3);", %client, %item, %value));

	if (%client.userId == -1)
		return 0;
	
	$Money::User[%client.userId, %item] = %value;

	Client::setInventoryText(%client, "<f1><jc>Current Balance: $" @ $Money::User[%client.userId, Money]);

	return $Money::User[%client.userId, %item];
}

function Money::Get(%client, %item)
{
	if ($PB::Debug)
		echo(sprintf("Money::Get(%1, %2);", %client, %item));

	if (%client.userId == -1)
		return 0;

	%value = $Money::User[%client.userId, %item];

	if ($PB::Debug)
		echo(sprintf("$Money::User[%1, %2] = %3;", %client.userId, %item, %value));
	
	return %value;
}

// ----------------------------------------------------------------------------
// Events

function Money::Event(%client, %event, %target)
{
	if (%client.userId == -1)
		return;

	if (%event == Capture)
	{
		%caps	= Money::Inc(%client, Captures);
		%team	= getTeamName(Gamebase::getTeam(%target));
		%msg	= "<jc><f2>You have captured the " @ %team @ " flag! (#" @ %caps @ ")";

		if ($Money::Price[Cap] > 0)
		{
			%bal	= Money::Inc(%client, Money, $Money::Price[Cap]);
			%msg	= %msg @ "\n\n<f1>Account Increase: <f0>$" @ $Money::Price[Cap] @ " "
				@ "<f1>Current Balance: <f0>$" @ %bal;
		}
	}
	else if (%event == Death)
	{
		%deaths	= Money::Inc(%client, Deaths);
		if (%target != -1)
			%killer	= Client::getName(%target);
		else
			%killer = "a grenade";
		%msg	= "<jc><f2>You have been killed by " @ %killer @ " (#" @ %deaths @ ")";

		if ($Money::Price[Death] > 0)
		{
			%bal	= Money::Dec(%client, Money, $Money::Price[Death]);
			%msg	= %msg @ "\n\n<f1>Account Increase: <f0>$" @ $Money::Price[Death] @ " "
				@ "<f1>Current Balance: <f0>$" @ %bal;
		}
	}
	else if (%event == HeadShot)
	{
		%heads	= Money::Inc(%client, HeadShot);
		%victim	= Client::getName(%target);
		%msg	= "<jc><f2>You shot " @ %victim @ " in the mask! (#" @ %heads @ ")";

		if ($Money::Price[HeadS] > 0)
		{
			%bal	= Money::Inc(%client, Money, $Money::Price[HeadS]);
			%msg	= %msg @ "\n\n<f1>Account Increase: <f0>$" @ $Money::Price[HeadS] @ " "
				@ "<f1>Current Balance: <f0>$" @ %bal;
		}
	}
	else if (%event == Kill)
	{
		%kills	= Money::Inc(%client, Kills);
		%victim	= Client::getName(%target);
		%msg	= "<jc><f2>You killed " @ %victim @ " (#" @ %kills @ ")";

		if ($Money::Price[Kill] > 0)
		{
			%bal	= Money::Inc(%client, Money, $Money::Price[Kill]);
			%msg	= %msg @ "\n\n<f1>Account Increase: <f0>$" @ $Money::Price[Kill] @ " "
				@ "<f1>Current Balance: <f0>$" @ %bal;
		}
	}
	else if (%event == Return)
	{
		%returns = Money::Inc(%client, Returns);
		%team = getTeamName(Gamebase::GetTeam(%target));
		%msg	= "<jc><f2>You returned the " @ %team @ " flag! (#" @ %returns @ ")";

		if ($Money::Price[Return] > 0)
		{
			%bal = Money::Inc(%client, Money, $Money::Price[Return]);
			%msg	= %msg @ "\n\n<f1>Account Increase: <f0>$" @ $Money::Price[Return] @ " "
				@ "<f1>Current Balance: <f0>$" @ %bal;
		}
	}
	else if (%event == Suicide)
	{
		%ctrlks = Money::Inc(%client, Suicides);
		%msg	= "<jc><f2>You killed yourself (#" @ %ctrlks @ ")";

		if ($Money::Price[Suicide] > 0)
		{
			%bal	= Money::Dec(%client, Money, $Money::Price[Suicide]);
			%msg	= %msg @ "\n\n<f1>Account Decrease: <f0>$" @ $Money::Price[Suicide] @ " "
				@ "<f1>Current Balance: <f0>$" @ %bal;
		}
	}
	else if (%event == TeamKill)
	{
		%kills	= Money::Inc(%client, Kills);
		%victim	= Client::getName(%target);
		%msg	= "<jc><f2>You TEAM KILLED " @ %victim @ " (#" @ %kills @ ")";

		if ($Money::Price[TeamKill] > 0)
		{
			%bal	= Money::Dec(%client, Money, $Money::Price[TeamKill]);
			%msg	= %msg @ "\n\n<f1>Account Decrease: <f0>$" @ $Money::Price[TeamKill] @ " "
				@ "<f1>Current Balance: <f0>$" @ %bal;
		}
	}
	else
		return;

	bottomPrint(%client, %msg, 10);
}

// ----------------------------------------------------------------------------

Event::Attach(Game_initialMissionDrop, Money::JoinMsg);

function Money::JoinMsg(%clientId)
{
	if ($Money::Enabled)
	{
		Client::SendMessage(%clientId, 0,
			"This server currently has client spending enabled.");

		if (%clientId.userId == -1)
		{
			Client::SendMessage(%clientId, 0,
				"If you already have an account, please login now. If you do not " @
				"have one, please take this opportunity to create one.");
			Client::SendMessage(%clientId, 0,
				"For information or assistance, type .spending");

			processMenuClientSpending(%clientId);
		}

		schedule("Money::Intro(" @ %clientId @ ");", 5);
	}
}

function Money::Intro(%client)
{
	if (%client.userId != -1)
		return;

	%title = "<jc><f2>Client Spending Help\n\n<f1>";

	%m = -1;
	%msg[%m++] = "This server is currently running with client spending <f0>enabled<f1>.";
	%msg[%m++] = "For information on what client spending is, please type <f0>.spending<f1> into global or team chat.";

	for (%a = 0; (%message = %msg[%a]) != ""; %a++)
	{
		if (%message == pause)
			continue;

		schedule("bottomPrint(" @ %client @ ", \"" @ escapestring(%title @ %message) @ "\", 10);", %a * 10, %client);
		schedule("Client::sendMessage(" @ %client @ ", 0, \"~wshell_click.wav\");", %a * 10, %client);
	}
}

function Money::HelpMessage(%client)
{
			%title = "<jc><f2>Account Options Help: ";
			%m = -1;

			%msg[%m++]	= "General Overview\n\n<f0>"
					@ "What is client spending? Thes mod was designed to enable "
					@ "players to be more responsible for their actions";
			%msg[%m++]	= "General Overview\n\n<f0>"
					@ "Each player is given an alotted amount of money which they "
					@ "may use to purchase varied items found in the inventory.";
			%msg[%m++]	= "General Overview\n\n<f0>"
					@ "To start, a player has limited options, and may only use "
					@ "the weapons that are first available.";
			%msg[%m++]	= "General Overview\n\n<f0>"
					@ "As a player's skill progresses, their account balance "
					@ "increases. Tasks such as killing, capturing the flag, and "
					@ "others all increase the user's balance.";

			%msg[%m++]	= pause;

			%msg[%m++]	= "Account Creation\n\n<f0>"
					@ "To begin, think of a password you wish to use to manage your account.";
			%msg[%m++]	= "Account Creation\n\n<f0>"
					@ "Next, create an account using that password with the <f1>.create<f0> command.";
			%msg[%m++]	= "Account Creation\n\n<f0>"
					@ "For example, if you chose the password <f1>abc123<f0>, you would "
					@ "type <f1>.create abc123<f0> into global or team chat.";
			%msg[%m++]	= "Account Creation\n\n<f0>"
					@ "After you have created your account, you may then purchase items from the "
					@ "inventory station.";

			%msg[%m++]	= pause;

			%msg[%m++]	= "Logging In\n\n<f0>"
					@ "On your next visit to the server, you may then relogin to the account you "
					@ "previously created.";
			%msg[%m++]	= "Logging In\n\n<f0>"
					@ "To login, use the <f1>.login<f0> command.";
			%msg[%m++]	= "Logging In\n\n<f0>"
					@ "If you created your account with the password <f1>abc123<f0>, you must login "
					@ "using the command <f1>.login abc123<f0>.";

			%msg[%m++]	= pause;
			%msg[%m++]	= pause;

			%msg[%m++]	= "Getting Set Up\n\n<f0>"
					@ "Now that you have an account, it's time to buy weapons.";
			%msg[%m++]	= "Getting Set Up\n\n<f0>"
					@ "To do so, simply enter an inventory station, and buy the items that are "
					@ "available to you.";
			%msg[%m++]	= "Getting Set Up\n\n<f0>"
					@ "Though there is a limited selection at first, as you progress in the game, "
					@ "more options will become available.";
			%msg[%m++]	= "Getting Set Up\n\n<f0>"
					@ "Please note that when you buy an item, it is at full cost, howver when you "
					@ "sell an item, it is at <f1>half<f0> cost.";
			%msg[%m++]	= "Getting Set Up\n\n<f0>"
					@ "This is to simulate a 'used' price on a gun.";
			%msg[%m++]	= "Getting Set Up\n\n<f0>"
					@ "If you happen to lose all your money, feel free to ask an admin for help.";

			%msg[%m++]	= pause;

			%msg[%m++]	= "Conclusion\n\n<f0>"
					@ "Just to sumarize, the main commands you will need are as follows";
			%msg[%m++]	= "Conclusion\n\n<f0>"
					@ ".create [password] <f1>- Creates an account you may use to begin playing.";
			%msg[%m++]	= "Conclusion\n\n<f0>"
					@ ".login [password] <f1>- Logs you into your previously created account.";
			%msg[%m++]	= "Conclusion\n\n<f0>"
					@ ".spending <f1>- Provides you with this help again.";

			//%msg[%m++]	= "";

			for (%a = 0; (%message = %msg[%a]) != ""; %a++)
			{
				if (%message == pause)
					continue;

				schedule("bottomPrint(" @ %client @ ", \"" @ escapestring(%title @ %message) @ "\", 10);", %a * 10, %client);
				schedule("Client::sendMessage(" @ %client @ ", 0, \"~wshell_click.wav\");", %a * 10, %client);
			}
}

// ----------------------------------------------------------------------------
// Money Menu

function processMenuClientSpending(%client, %option)
{
	%curItem = 0;
	%opt = getWord(%option, 0);
	%val = getWord(%option, 1);	

	if (%opt == -1)
	{
		Client::buildMenu(%client, "Client Spending Mode", "ClientSpending", %client.userId != -1);
		if (%client.userId == -1)
		{
			Client::addMenuItem(%client, %curItem++ @ "I have an account", "haveacct");
			Client::addMenuItem(%client, %curItem++ @ "I do not have an account", "noacct");
		}
		Client::addMenuItem(%client, %curItem++ @ "What is client spending?", "helpme");
		Client::addMenuItem(%client, %curItem++ @ "Spending Commands", "commands");
	}
	else if (%opt == "commands")
	{
		%title = "<jc><f2>Current Commands\n\n";
		%template = "<f0>%1 <f1>- %2";

		%m = -1;
		%msg[%m++] = sprintf(%template, ".create [password]", "Creates a new account with a password of [password]");
		%msg[%m++] = sprintf(%template, ".login [password]", "Logs into a preexisting account using the password [password]");
		%msg[%m++] = sprintf(%template, ".pass [password]", "Changes your account password to [password]");
		%msg[%m++] = sprintf(%template, ".spending", "View information and help on client spending mode.");

		for (%a = 0; (%message = %msg[%a]) != ""; %a++)
		{
			schedule("bottomPrint(" @ %client @ ", \"" @ escapestring(%title @ %message) @ "\", 10);", %a * 5, %client);
			schedule("Client::sendMessage(" @ %client @ ", 0, \"~wshell_click.wav\");", %a * 5, %client);
		}

		if (%client.userId == -1)
			processMenuClientSpending(%client);
	}
	else if (%opt == "haveacct")
	{
		bottomPrint(%client, "<jc><f2>Account Login\n<f1>Please login to your account by typing <f0>.login<f1> followed by your password.", 10);
		Client::sendMessage(%client, 0, "~wshell_click.wav");

		if (%client.userId == -1)
			processMenuClientSpending(%client);
	}
	else if (%opt == "helpme")
	{
		Money::HelpMessage(%client);
		if (%client.userId == -1)
			processMenuClientSpending(%client);
	}
	else if (%opt == "noacct")
	{
		bottomPrint(%client, "<jc><f2>Account Creation\n<f1>Please type <f0>.spending<f1> into global or team chat for information on creating an account.", 10);
		Client::sendMessage(%client, 0, "~wshell_click.wav");

		if (%client.userId == -1)
			processMenuClientSpending(%client);
	}
	else if ((%opt == "options") && (%client.userId != -1))
	{
		if (%val == -1)
		{
			Client::buildMenu(%client, "Spending options", "ClientSpending", true);
			Client::addMenuItem(%client, %curItem++ @ "What is client spending?", "helpme");
			Client::addMenuItem(%client, %curItem++ @ "Spending Commands", "commands");
			if (%client.userId != -1)
			{
				if (Money::Get(%client, BuyNade))
					Client::addMenuItem(%client, %curItem++ @ "Disable grenade auto-buy", "options -grenade");
				else
					Client::addMenuItem(%client, %curItem++ @ "Enable grenade auto-buy", "options grenade");
			}
			return;
		}
		else if (%val == "grenade")
		{
			Money::Set(%client, BuyNade, true);
			Client::SendMessage(%client, 0, "Grenade auto buy has been enabled.");
			Client::SendMessage(%client, 0, "Please note you need a minimum account balance of $" @ $Money::BuyNadePrice @ " for it to be effective.");
		}
		else if (%val == "-grenade")
		{
			Money::Set(%client, BuyNade, "");
			Client::SendMessage(%client, 0, "Grenade auto buy has been disabled.");
		}

		processMenuClientSpending(%client, "options");
	}
	else if (%client.userId == -1)
			processMenuClientSpending(%client);
}

// ----------------------------------------------------------------------------
// Money Functions

function Money::FileName(%name)
{
	// Here we take a name and replace all the invalid characters with ones
	// that windows allows. For the most part, e only have to get rid of
	// the characters that bother windows file names. Put each item in the
	// list, and divide them by spaces. From there, if an item from the
	// invlaid list is found, it is replaces with the item from the same
	// position in the replace list. i.e. a backslash (\) would become a
	// [b].
	%invalid = "\\ / : * ? \" < > |";
	%replace = "[b] [f] [c] [qs] [qt] [lt] [gt] [l]";

	%newName = "";
	for (%pos = 0; (%letter = String::getSubStr(%name, %pos, 1)) != ""; %pos++)
	{
		for (%rep = 0; (%bad = getWord(%invalid, %rep)) != -1; %rep++)
			if (%letter == %bad)
			{
				%letter = getWord(%replace, %rep);
				break; // save some time
			}
		%newName = %newName @ %letter;
	}

	return %newName;
}

// ----------------------------------------------------------------------------
// Load Money

if ($Money::Enabled)
	Money::init();

//	Edits were made to the following items to make this possible:
//
//	admin.cs	(function remoteSelectClient)
//	- Added current player account status to client profile page
//
//	comchat.cs	(function: onText_Money)
//	- Added command:	.create <pass>
//	- Added command:	.login <pass>
//
//	game.cs		(function remoteInventoryMode)
//	- Added updated account information line
//
//	game.cs		(function Game::playerSpawned)
//	- Modified spawn buy list to buy only items present when a
//	  player is dead.
//
//	game.cs		(function Game::onPlayerConnected)
//	- Set properties of a player on join
//
//	game.cs		(function Client::onKilled)
//	- Added money decrease on death
//
//	item.cs		(function teamEnergyBuySell)
//	- Added ability to sell in percents
//
//	item.cs		(function buyItem)
//	- Added the no-cost spawn (spawn with items at no cost)
//	- Added spawn items to list when bought
//
//	item.cs		(function remoteSellItem)
//	- Added spawn items to removed list when sold
//
//	item.cs		(function Item::onAdd)
//	- Added the deletion of an object (when dropped, etc)
//	  on immediate add to map. This prevents players from
//	  picking up packs, guns, etc and bringing them to invo
//	  to cash in.
//
//	item.cs		(function Item::onDrop)
//	- When a weapon, tool, or backpack is dropped, it is removed
//	  from the auto buy list on spawn
//
//	item.cs		(function checkPlayerCash)
//	- Modified function to account for individual spending
//
//	item.cs
//	- Kill Clip Prices
//
//	objectives.cs	(function flag::onCollision)
//	- added flag capture event catch
//	- Added protection for non-logged in users from getting flag
//
//	player.cs	(function Player::onDamage)
//	- Added event catching for kill,death,and headshot (for
//	  spending increase)
//
//	server.cs	(function Server::onClientDisconnect)
//	- Log a player out and save their account information when they exit
//
//	server.cs	(function Server::onClientConnect)
//	- Start a player off with a userId of -1, and userPass of null. This
//	  flags a user who has not been logged in yet.
//
//	...
//
//	I got tired of tracking it, but to make it easy, just look for
//	"vvv Added for money vvv". There is a comment such as this on
//	every change made for the spending enhancement.