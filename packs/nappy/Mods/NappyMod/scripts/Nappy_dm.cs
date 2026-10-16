function DM::missionObjectives()
{
	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++) 
		%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1) {
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++) {
			if((%clientList[%i]).ratio < (%clientList[%i+1]).ratio) {
				%hold = %clientList[%i];
				%clientList[%i] = %clientList[%i+1];
				%clientList[%i+1]	= %hold;
				%doIt=1;
			}
		}
	}
   if(!$Server::timeLimit)
      %str = "<f1>   - No time limit on the game.";
   else if($timeLimitReached)
      %str = "<f1>   - Time limit reached.";
   else
      %str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";
	for(%l = -1; %l < 1 ; %l++) {		
		%lineNum = 0;
		if($timeReached == "") {
	 	  	Team::setObjective(%l, %lineNum, "<jc><B0,0:deathmatch1.bmp><B0,0:deathmatch2.bmp>");
	  		Team::setObjective(%l, %lineNum++, "<f5>Mission Information:");
			Team::setObjective(%l, %lineNum++, "<f1>   - Mission Name: " @ $missionName); 
	      Team::setObjective(%l, %lineNum++, %str);
	      Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f5>Mission Objectives:");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Kill all other players!");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Stay alive!");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -To have the highest Efficiency!");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   	 -Efficiency is calculated once (Kills + Deaths) is greater than 4");
	 	  	Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>Remember to stay within the mission area, which is defined by the extents of your commander screen map."	@ 
	 	                                 " If you go outside of the mission area you will have 3 seconds to get back into the mission area, or you'll start taking damage!");
	 	  	Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, " ");
		  	Team::setObjective(%l, %lineNum++, "<f5>TOP PLAYERS ARE: " );
	 	  	Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>Player Name<L30>Kills<L50>Deaths<L70>Efficiency");
	   }
	   else {
			Team::setObjective(%l, %lineNum++, "<f5>Mission Summary:");
	 	  	Team::setObjective(%l, %lineNum++, " " );
	 	  	Team::setObjective(%l, %lineNum++, "<f1>     - The Best Player(s): " );
			%i=0;
			%TopRatio="";
			while(%i < %numClients && %clientList[%i].ratio != 0 && (%TopRatio == "" || (%TopRatio ==  (%clientList[%i+1]).ratio && %TopRatio != 0) )) {
	 	  		Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Nappy::getName(%clientList[%i]) @ "<f1> with a ratio of <f5>" @ (%clientList[%i]).ratio @ ".0%");
				%TopRatio = (%clientList[%i]).ratio;
				%i++;
			}
			if(%i == 0) {
	 	  		Team::setObjective(%l, %lineNum++, "<L14><f1>NONE with a ratio greater than 0.0%");
			}
			Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, " ");
			Team::setObjective(%l, %lineNum++, "<f5>TOP PLAYERS ARE: " );
	 	  	Team::setObjective(%l, %lineNum++, " ");
			Team::setObjective(%l, %lineNum++, "<f1>Player Name<L30>Kills<L50>Deaths<L70>Efficiency");
		}
	   //print out top 5 scores
		%index = 0;
		while(%index < %numClients && %clientList[%index].ratio != 0 && (%index < 5 || (%clientList[%index].ratio == %lastRatio && %lastRatio != 0))) {
	  		%client = getClientByIndex(%count);
	  	   Team::setObjective(%l, %lineNum++,"<Bskull_small.bmp>" @ Nappy::getName(%clientList[%index]) @ " <L31>" @ (%clientList[%index]).scoreKills @ "<L53>" @ (%clientList[%index]).scoreDeaths @ "<L72>" @ (%clientList[%index]).ratio @ ".0%");
			%lastRatio = (%clientList[%index]).ratio;
			%index++;
		}  
		for(%s = %lineNum+1; %s < 30 ;%s++)
			Team::setObjective(%l, %s, " ");
	}
	$timeReached="";
}
