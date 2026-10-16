echo("Loading Screaming Fist Version");
function TimeLimit()
{
	if(!$Server::timeLimit)
		$Server::timeLimit = 25;
}
	
function DefensePoints()
{
	TimeLimit();
	
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	
	if(%curTimeLeft >= 2)
		schedule("DefensePoints();",1);
	else
		$teamScore[1] = "100";
}

$AttackGameType = TRUE;
TimeLimit();
