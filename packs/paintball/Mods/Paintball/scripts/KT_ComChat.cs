// ------------------------------------------------------------------------------------------------
// On Text Events
// By KingTomato
// --
// If you are farmiliar with the presto pack events, you will love this >:D
// ------------------------------------------------------------------------------------------------

$OnText::Events		= 0;
$OnText::StopSpam	= True;
$OnText::Debug		= $PB::ExtDebug; // Debugging mode

$MsgType::System	= 0;
$MsgType::Game		= 1;
$MsgType::Chat		= 2;
$MsgType::TeamChat	= 3;
$MsgType::Command	= 4;

// Added
$MsgType::ObsEvesdrop	= 3;
$MsgType::ObsTeamChat	= 3;

// ------------------------------------------------------------------------------------------------
// Add Event
//
// Called to attach an event to a client message in the server.  Here we make it easy to add new
// commands (atleast I think so).  The basic layout is this:
//
//	1. Attach a command
//	2. The functions in the list are called one by one in the order they were added. Each
//	   function called is passed three parameters.  There parameters are as follows:
//		%client	- ID Of the client whome sent message
//		%msg	- The message that was sent
//		%team	- return 0 if it was a global message, and 1 if it was a team message
//	3. In the block of code you have assigned to the function, should you have the function
//	   return the value "true", the onClientMessage function will halt processing, and will
//	   not send a message to all the clients in the server.  Say if you added a command like
//	   .bp <text>  Yo could have it bottomPrintAll(<text>, 5); then return true; This would
//	   show the bottom printed text, then not display the command that was typed to trigger
//	   it.
//	4. The default command(s) are called that are normally found in the remoteSay function
//	   such as the spam filter, and global/team chat messages.
// ------------------------------------------------------------------------------------------------
function OnText::Attach(%function) {
	%event = $OnText::Events;

	$OnText::List[%event]	= %function;
	$OnText::Events++;

	if ($OnText::Debug)
		echo("Event Attached: " @ %function);
}

// ------------------------------------------------------------------------------------------------
// Execute Functions
// ------------------------------------------------------------------------------------------------
function OnText::Execute(%client, %msg, %team) {

	for (%function = 0; %function < $OnText::Events; %function++)
	{
		%funcName = $OnText::List[%function];

		if ($OnText::Debug)
			echo("Executing " @ %funcName);

		$OnText::Return[%function] = eval(%funcName @ "(%client,%msg,%team);");

		if (($OnText::Return[%function] != true) && ($OnText::Return[%function] != false)) {
			if ($OnText::Return[%function] != "") {
				%msg = $OnText::Return[%function];
				$OnText::Return[%function] = false;
			}
			else
				$OnText::Return[%function] = false;
		}

		if ($OnText::Debug) {
			echo("Message: " @ %msg);
			echo("Return: " @ $OnText::Return[%function]);
		}
	}

	if (!OnText::isReturned(True))
		return %msg;
	else
		return "";

}

// ------------------------------------------------------------------------------------------------
// Event Return
// ------------------------------------------------------------------------------------------------
function OnText::isReturned(%val)
{
	for (%event = 0; %event < $Ontext::Events; %event++)
	{
		if ($OnText::Return[%event] == %val)
			return true;
	}

	return false;
}

// ------------------------------------------------------------------------------------------------
// Default Function
// ------------------------------------------------------------------------------------------------
function onText_Default(%client, %msg, %team) {
	// Execute the Event Call
	%return = OnText::Execute(%client, %msg, %team);
	if (%return != "")
		%msg = %return;
	else
		return;

	// Edit message for echoing
	%message = %client @ " \"" @ escapeString(%msg) @ "\"";

	// Client Messages
	if (%team) {

		if ($dedicated)
			echo("SAYTEAM: " @ %message);

		%team = Client::getTeam(%client);

		for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if (%cl.Muted[%client])
				return;

			if (Client::getTeam(%cl) == %team) {
				if (%team == -1)
					Client::sendMessage(%cl, $MsgType::ObsTeamChat, %msg, %client);
				else
					Client::sendMessage(%cl, $MsgType::TeamChat, %msg, %client);
			}

			else if ((%cl.isSuperAdmin) && (Client::getTeam(%cl) == -1)) {
				Client::sendMessage(%cl, $MsgType::ObsEvesdrop, "(Team Chat): " @ %msg, %client);
			}
		}
	}
	else {
		if ($dedicated)
			echo("SAY: " @ %message);

		for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(!%cl.muted[%client])
				Client::sendMessage(%cl, $MsgType::Chat, %msg, %client);
	}
}

// ------------------------------------------------------------------------------------------------
// Say Event
// ------------------------------------------------------------------------------------------------
function remoteSay(%client, %team, %msg) {
	%msg = String::getSubStr(%msg, 0, 240); // PORT: cap chat length (as in the HaVoC port)
	onText_Default(%client, %msg, %team);
}