$AiNames0 = 0;
$AiNames1 = 0;
$AiNames2 = 0;
$AiNames3 = 0;
$AiNames4 = 0;

function AddAiName(%team, %name)
{
$AiName[%team, $AiNames[%team]] = %name;
$AiNames[%team]++;
}


AddAIName(1, "Christopher Betschart");
AddAIName(1, "Michael Bartelt");
AddAIName(1, "Steffen Rühl");
AddAIName(1, "Michael Brünig");
AddAIName(1, "Julius Haimüller");
AddAIName(1, "Georg Monschau");
AddAIName(1, "Gerhard Dohmen");
AddAIName(1, "Alexander Grabinger");
AddAIName(1, "Hans Baumann");
AddAIName(1, "Bernhard Niemann");
AddAIName(1, "Thomas Pechstein");
AddAIName(1, "Richard Kruspe");
AddAIName(1, "Till Lindermann");
AddAIName(1, "Bill Kraulitz");
addAIname(1, "Tom Kraulitz");
AddAIName(1, "Christopher Schneider");
AddAIName(1, "Olmert Altermann");
AddAIName(1, "Frank Werner");
AddAIName(1, "Paul Mertens");
AddAIName(1, "Paul Landers");
AddAIName(1, "Oliver Riedel");
AddAIName(1, "Christian Roberts");
AddAIName(1, "Andreas Schulz");
AddAIName(1, "Robert Kaiser");
AddAIName(1, "Rolf Böckler");
AddAIName(1, "Peter Hufschmidt");
AddAIName(1, "Helmut Klein");
AddAIName(1, "Wilhelm Bäcker");
AddAIName(1, "Reinhard Gruber");
AddAIName(1, "Udo Rabe");
AddAIName(1, "Markus Schmidtke");
AddAIName(1, "Johannes Schmidt");
AddAIName(1, "Walter Brand");
AddAIName(1, "Joachim Müller");
AddAIName(1, "Adrian Uhlmann");
AddAIName(1, "Achim Neumann");
AddAIName(1, "Clemens Mayer");
AddAIName(1, "Rüdiger Berens");
AddAIName(1, "Marcel Pelzer");
AddAIName(1, "Stephan Schwertner");
AddAIName(1, "Bastian Balter");
AddAIName(1, "Daniel Breuer");
AddAIName(1, "Detlef Dahmen");
AddAIName(1, "Dominik Krämer");
addAIName(1, "Adolf Eichmann");
addAIname(1, "Albert Gurmann");
addAiName(1, "Bruno Feldmann");
addAiName(1, "Richard Balter");
addAiName(1, "Robert Müller");
addAiName(1, "Frank Lechmidt");
addAiName(1, "Eberhard Ahnert");
addAiName(1, "Feliy Lindmayr");
addAiName(1, "Gehard Langendorf");
addAiName(1, "Levin Oelker");
addAiName(1, "Gottlieb Brettschneider");




$AIkilled = 0;
$MatchStartTime = getSimTime();
$TrainMissionComplete = false;
 
//----------------------------------
//Training::setupAI()
//----------------------------------   
function WWII::setupGermanAI(%bool)
{
messageall(0, "--Loading AI...");
  
   $numGuards = %itemCount; 
%itemcount = group::objectcount("Missiongroup\\AI");
   
      if(%bool == "") for(%guard = 1; %guard <= %itemCount; %guard++)
      {
        schedule("spawnguard(" @ %guard @ ",\"MissionGroup\\\\AI\");", %guard*0.1);
 	}
	else for(%guard = 1; $markerlist["guard" @ %guard] != ""; %guard++)
      {
       if(%guard > 37) return;
	 schedule("spawnguard(" @ %guard @ ",\"MissionGroup\\\\AI\"," @ %bool @ ");", %guard*0.1);
 	}
	
}


function spawnguard(%guard, %group,%c)
{

%AIname = "guard" @ %guard;
        %name = $AiName[1, %guard-1]; 
	$aiPathNum[%guard] = %AIname;
        if(%c == "") createAI(%AIname, "MissionGroup\\AI\\guard" @ %guard, soldier, %name, %c);
	else createAI(%AIname, "guard" @ %guard, soldier, %name, %c);
	
	 %aiId = AI::getId( %AIname );
	
         Client::setinitialTeam(%aiId, 1);
	GameBase::setTeam(%aiId, 1);
         AI::setVar( %AIname,  iq,  80 );
         AI::setVar( %AIname,  attackMode, -1);
   	ai::setvar(%ainame, spotdist, 200);
      %obj = ai::getobject(%ainame);
	
	%germanclasslist = "scout assault assault2 antitank medic engineer";
	%randomclass = randomitems(%germanclasslist, 6);
	AI::SetAutomaticTargets(%ainame);
	%obj.spawnclass = %randomclass;
	%obj.playerid = client::getownedobject(%aiId);
     	%weapon = $Weapon[%randomclass, German];
	 AI::callWithId(%AIname, Player::setItemCount, %weapon, 1);
      AI::callWithId(%AIname, Player::setitemcount, $Clip[%weapon], 25);
      AI::callWithId(%AIname, Player::mountitem, %weapon, $weaponslot);
	AI::SetVar( %aiName, triggerPct, 0.7 );
}

