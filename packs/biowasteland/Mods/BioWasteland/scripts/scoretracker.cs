function ScoreTracker(%clientId)
{
	%addr = Client::getTransportAddress(%clientId);

	if ($Wasteland::ScoreTracker)
	{
		echo ("Checking For Crappy Score");

		if (!$Wasteland::CheckScores || $Wasteland::CheckScores == "" || $Wasteland::CheckScores == "0")
		{
			$Wasteland::CheckScores = 30;
		}

		if (%clientId.score < $Wasteland::WarnScoreFinal)
		{
			%name = Client::getName(%clientId);
			if ($Server::Admin["noban", %name] && %clientId.noban)
			{
				echo ("ADMINMSG **** " @ %name @ " has crappy Score but is NoBan");
				return;
			}
			else if (%clientId.noban)
			{
				echo ("ADMINMSG **** " @ %name @ " has crappy Score but is NoBan");
				return;
			}

			MessageAll(1, Client::getName(%clientId) @ " got Kicked For Having A Crappy Score...");
			bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0> got Kicked For Having A Crappy Score...<f1>", 10);
			echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " got Kicked For Having A Crappy Score...");
			KickPlayer(%clientId, "You were kicked for having a crappy score. Score = " @ %clientId.score );
		}
		else if (%clientId.score < $Wasteland::WarnScore3)
		{
			bottomprint(%clientId, "<jc><f2>You will be kicked if your score falls to low. This is your *LAST* warning.<f0>", 10);
			//echo("ADMINMSG: **** Wasteland Is Checking For Poopy Player");
		}
		else if (%clientId.score < $Wasteland::WarnScore2)
		{
			bottomprint(%clientId, "<jc><f2>LEVEL TWO WARNING - You will be kicked if your score falls to low.<f0>", 10);
			//echo("ADMINMSG: **** Wasteland Is Checking For Poopy Player");
		}
		else if (%clientId.score < $Wasteland::WarnScore1)
		{
			bottomprint(%clientId, "<jc><f2>LEVEL ONE WARNING - You will be kicked if your score falls to low.<f0>", 10);
			//echo("ADMINMSG: **** Wasteland Is Checking For Poopy Player");
		}
	}
}