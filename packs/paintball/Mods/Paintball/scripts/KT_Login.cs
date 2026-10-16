///////////////////////////////////////////////////////////////////////////////////////////////////
// KingTomato Login Script 							   July 25, 2003 //
///////////////////////////////////////////////////////////////////////////////////////////////////

//$PB::Admin::Pass[<level>,	<pass>]		= <username>;

///////////////////////////////////////////////////////////////////////////////////////////////////
// Login											 //
///////////////////////////////////////////////////////////////////////////////////////////////////

function remoteAdminPassword(%client, %password)
{
	%clientName = Client::GetName(%client);

	// Notify Of An Attempt
	ECHO("ADMINMSG: *** " @ %clientName @ " is attempting admin login using \"" @ %password @ "\" (" @ timestamp() @ ")");

	if ((%client.isLoggedIn) && ((%client.isAdmin) || (%client.isSuperAdmin)))
	{
		Client::SendMessage(%client, 0, "You have already been logged in as an adminitrator");
		ECHO("ADMINMSG: *** " @ %clientName @ " is already logged in.");
		return;
	}

	%client.isLoggedIn = False;
	%client.passwordAttempts++;

	// Verify Password and If They Tried
	if (%client.passwordAttempts <= $PB::Admin::Attempts)
	{
		// Super Admin
		if ($PB::Admin::Pass[Super, %password] != "")
		{
			%client.isSuperAdmin = True;
			%client.isAdmin = True;
			%client.isLoggedIn = True;

			ECHO("ADMINMSG: *** " @ %clientName @ " has become a Super-Admin");
			for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl))
			{
				if (%cl == %client)
					Client::sendMessage(%cl, $PB::Admin:TextColor, "You are now logged in as Super Admin");
				else if ($PB::Admin::Announce)
					Client::sendMessage(%cl, $PB::Admin::TextColor, %clientName @ " has become Super Admin using " @ $PB::Admin::Pass[Super, %password] @ "'s password");
			}
			if ($PB::Admin::Skin)
				PB::Login::Skin(%client, 0);
				
		}

		// Public Admin
		else if ($PB::Admin::Pass[Public, %password] != "")
		{
			%client.isAdmin = True;
			%client.isLoggedIn = True;

			ECHO("ADMINMSG: *** " @ %clientName @ " has become a Public-Admin");
			for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl))
			{
				if (%cl == %client)
					Client::sendMessage(%cl, $PB::Admin:TextColor, "You are now logged in as Public Admin");
				else if ($PB::Admin::Announce)
					Client::sendMessage(%cl, $PB::Admin::TextColor, %clientName @ " has become Public Admin using " @ $PB::Admin::Pass[Admin, %password] @ "'s password");
			}
			if ($PB::Admin::Skin)
				PB::Login::Skin(%client, 0);
		}

		// Bad Password Attempt
		else
		{
			ECHO("ADMINMSG: *** " @ %clientName @ " provided an invalid login password (" @ %password @ ")");
			for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl))
			{
				if (%cl == %client)
					Client::sendMessage(%cl, $PB::Admin:TextColor, "You have entered an invalid password (Attempt " @ %client.passwordAttempts @ "/" @ $PB::Admin::Attempts @ ")");
				else if ($PB::Admin::Announce)
				{
					Client::sendMessage(%cl, $PB::Admin::TextColor, %clientName @ " has entered an invalid login password");
					if ((%cl.isSuperAdmin) && ($PB::Admin::SayPass))
						Client::sendMessage(%cl, $PB::Admin::TextColor, %clientName @ " attempted to login with the password \"" @ %password @ "\"");
				}
			}
		}
	}
	else {
		%msg = "Password attempt limit (" @ $PB::Admin::Attempts @ ") has been reached.  You may not try any more passwords until you reconnect to the server.";
		Client::SendMessage(%client, $PB::Admin:TextColor, %msg);
	}
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// Kick (Alternate)
// --
// This is just to provide the ability of scripts being able to kick a user. Say if you have a
// client side script, and you want it to kick a use for spamming, you call this function. Very
// clean, and no gui involved,

function remoteAdminKick(%admin, %client, %reason, %time)
{
	// %admin	- Guy kicking the user
	// %client	- Victim of kick
	// %reason	- Reason for kick (Shown on kick message
	// %time	- Time (in seconds) they are banned from server

	// Only a super admin ability
	if (%admin.isSuperAdmin)
	{
		if (%client == "")
			Client::SendMessage(%admin, 1, "AdminKick: Missing client id to be kicked.");
		else if (Client::GetName(%client) == "")
			Client::SendMessage(%admin, 1, "AdminKick: Invalid client id.");
		else if (%client == %admin)
			Client::SendMessage(%admin, 1, "AdminKick: You may not kick yourself.");
		else if (%client.isSuperAdmin)
			Client::SendMessage(%admin, 1, "AdminKick: You may not kick a Super Admin.");
		else
		{
			%adminName = Client::GetName(%admin);
			%clientName = Client::GetName(%client);
			%ip = Client::GetTransportAddress(%client);

			if (%reason == "")
				%reason = "You were kicked by admin " @ %adminName @ ".";
			if (%time == "")
				%time = "300";

			Banlist::Add(%ip, %time);
			Net::kick(%client, %reason); // PORT: was NetKick (no such function)

			messageAll(0, "User " @ %clientName @ " has been kicked by " @ %adminName @ ".");
			messageAll(0, "Reason: " @ %reason);
		}
	}
	else
	{
		// send a message back so maybe you can have a script get triggered to login
		// when the message appears.
		Client::SendMessage(%admin, 1, "AdminKick: You do not have admin access to this function."); // PORT: was sent to %client
	}
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// Logging

function PB::Login::Log(%client, %text)
{
	if ($PB::Admin::Logging)
	{
		%l = 0;
		$log[%l++] = "--";
		if (%client != -1)
		{
			$log[%l++] = sprintf("User: %1 (%2)", Client::GetName(%client), %client);
			$log[%l++] = sprintf("Date: %1", timestamp());
			$log[%l++] = sprintf("IP: %1", Client::getTransportAddress(%client));
		}
		$log[%l++] = %text;
		export("$log*", "config\\" @ $PB::Admin::LogFile, true);
		deleteVariables("$log*");	
	}
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// Admin Skins
// --
// Changes your skin every half second, to signify you are an admin. Unfortunatly, tribes kills
// the console scheduler on a mission change, so this only works untilt he next mission change.
// i may or may not impliment a workaround, but right now I don't care.

%s = 0;
$PB::Skin[%s++] = "base";
$PB::Skin[%s++] = "blue";
$PB::Skin[%s++] = "green";
$PB::Skin[%s++] = "orange";
$PB::Skin[%s++] = "purple";

function PB::Login::Skin(%client, %skin)
{
	if (%client.isAdmin)
	{
		%skin++;
		if ($PB::Skin[%skin] == "")
			%skin = 1;

		Client::setSkin(%client, $PB::Skin[%skin]);
		schedule("PB::Login::Skin(" @ %client @ ", " @ %skin @ ");", 0.5);
	}
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// EOF												 //
///////////////////////////////////////////////////////////////////////////////////////////////////