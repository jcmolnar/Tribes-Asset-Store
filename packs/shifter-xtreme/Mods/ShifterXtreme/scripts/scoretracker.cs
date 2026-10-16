function ScoreTracker(%clientId)
{
	%addr = Client::getTransportAddress(%clientId);

	if ($Shifter::ScoreTracker)
	{
		if (!$Shifter::CheckScores || $Shifter::CheckScores == "" || $Shifter::CheckScores == "0")
		{
			$Shifter::CheckScores = 30;
		}

		if (%clientId.score < $Shifter::WarnScoreFinal)
		{
			for(%i=0; $Server::NoBan[%i] != "" || $Server::NoBanAddr[%i] != "" ;%i++)
			{
				if(($Server::NoBan[%i] == "" || $Server::NoBan[%i] == Client::getName(%clientId)) && String::findSubStr(%addr,$Server::NoBanAddr[%i]) == 0)
				{
					echo("Player Has Crappy Score But Is On NoBan List: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
					return;
				}
			}			
			MessageAll(1, Client::getName(%clientId) @ " got Kicked For Having A Crappy Score...");
			bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0> got Kicked For Having A Crappy Score...<f1>", 10);
			echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " got Kicked For Having A Crappy Score...");
			Net::kick(%clientId, "You were kicked for having a crappy score. Score = " @ %clientId.score );
		}
		else if (%clientId.score < $Shifter::WarnScore3)
		{
			bottomprint(%clientId, "<jc><f2>You will be kicked if your score falls to low. This is your *LAST* warning.<f0>", 10);
			echo("ADMINMSG: **** Shifter Is Checking For Poopy Player");
		}
		else if (%clientId.score < $Shifter::WarnScore2)
		{
			bottomprint(%clientId, "<jc><f2>LEVEL TWO WARNING - You will be kicked if your score falls to low.<f0>", 10);
			echo("ADMINMSG: **** Shifter Is Checking For Poopy Player");
		}
		else if (%clientId.score < $Shifter::WarnScore1)
		{
			bottomprint(%clientId, "<jc><f2>LEVEL ONE WARNING - You will be kicked if your score falls to low.<f0>", 10);
			echo("ADMINMSG: **** Shifter Is Checking For Poopy Player");
		}
	}
}

