// ----------------------------------------------------------------------------
// Misc Functions
// -KingTomato
// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
// This is a simple counter to deturming basically if a user is using a
// rapid fire script, or shooting by hand. Off my tests, the avg person can
// shoot (by hand) at a rate no lower than 0.1 according tro getSimTime().
// This means a user shooting a 0.06 or anything lower than 0.1 can be assumed
// to be using a script.

function checkFireTime(%player)
{
	%client	= Player::getClient(%player);

	if (%client.waitTime[Fire] != "")
		return;

	if (%client.lastTime[Fire] == "")
		%client.lastTime[Fire] = getSimTime();
	else
	{
		%time = getSimTime() - %client.lastFire;

		if (%time >= 0.1)
			%verdict = "Not using script";
		else if (%time >= 0.08)
			%verdict = "Probable Script User";
		else
			%verdict = "Using rapid fire script";

		%dec = String::findSubStr(%time, ".");
		%time = String::getSubStr(%time, 0, %dec + 3);

		for (%obsCl = Client::getFirst(); %obsCl != -1; %obsCl = Client::getNext(%obsCl))
			if (%obsCl.obsFiring == %client)
				bottomPrint(%obsCl, "<jc><f0>" @ Client::getName(%client) @ "'s shoot delay was <f1>" @ %time @ "s\n"
					@ "<f0>Outcome: <f1>" @ %verdict, 5);

		%client.lastTime[Fire] = "";
		%client.waitTime[Fire] = true;
		schedule(%client @ ".waitTime[Fire] = \"\";", 5);
	}
}