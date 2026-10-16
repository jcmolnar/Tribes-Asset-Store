//1 - german, 2 - russian, 3 - british, 4 - american

function AddAiName(%team, %name)
{
$AiName[%team, $AiNames[%team]] = %name;
$AiNames[%team]++;
}


AddAIName(2, "Arkady Popov");
AddAIName(2, "Boris Borisenkov");
AddAIName(2, "Dmitry Stupnikov");
AddAIName(2, "Edik Chernobyl");
AddAIName(2, "Feoder Vasilinkov");
AddAIName(2, "Filipp Vlasov");
AddAIName(2, "Anatoly Danilko");
AddAIName(2, "Ivan Makarov");
AddAIName(2, "Kostya Kazakov");
AddAIName(2, "Leonya Kalmykov");
AddAIName(2, "Nikolai Gorkov");
AddAIName(2, "Moisei Glukhov");
AddAIName(2, "Nikita Moiseev");
AddAIName(2, "Pavel Chernenkov");
AddAIName(2, "Peoter Barbanov");
AddAIName(2, "Sergei Androsov");
AddAIName(2, "Ilya Ascarov");
AddAIName(2, "Vassily Zaitsev");
AddAIName(2, "Yasha Putin");
AddAIName(2, "Yuri Bulkin");
AddAIName(2, "Grisha Kuznetsov");
AddAIName(2, "Andrey Mihalev");
AddAIName(2, "Daniel Mironov");
AddAIName(2, "Denis Baskov");
AddAIName(2, "Jenya Smirnov");
AddAIName(2, "Kirill Vorobiov");
AddAIName(2, "Maxim Volkov");
AddAIName(2, "Ostap Zaharov");
AddAIName(2, "Roman Kudayev");
AddAIName(2, "Viktor Chorni");
AddAIName(2, "Sasha Harkov");
AddAIName(2, "Semen Rappaport");
AddAIName(2, "Yaroslav Kauchuk");
AddAIName(2, "Igor Gavnuk");
AddAIName(2, "Viktor Kozlov");



AddAIName(3, "Andrew Rice");
AddAIName(3, "Andy Bush");
AddAIName(3, "Arthur Jacobs");
AddAIName(3, "Bill Smith");
AddAIName(3, "Brian Young");
AddAIName(3, "Charles Parker");
AddAIName(3, "Charlie Hodsdon");
AddAIName(3, "Stanley Van Halen");
AddAIName(3, "Steeve Vai");
AddAIName(3, "Edward McDonald");
AddAIName(3, "Michael Amott");
AddAIName(3, "Matt Casey");
AddAIName(3, "Bob Nonamed");
AddAIName(3, "Ronald Roach");
AddAIName(3, "Arnold Rubik");
AddAIName(3, "Oscar Pozner");
AddAIName(3, "Nick Powell");
AddAIName(3, "Jack Shepport");
AddAIName(3, "Jimmy Thomson");
AddAIName(3, "Kevin Walker");
AddAIName(3, "Dexter Hemilton");
AddAIName(3, "Thomas Roger");
AddAIName(3, "Dave Mushroom");
AddAIName(3, "Will Waylon");
AddAIName(3, "Roy Martin");
AddAIName(3, "Scott Creel");
AddAIName(3, "Butch Hawk");
AddAIName(3, "John Lock");
AddAIName(3, "Ben Li");
AddAIName(3, "Frank Warner");
AddAIName(3, "Fred Bloggs");



AddAIName(4, "Larry Smith");
AddAIName(4, "Henry Johnson");
AddAIName(4, "Bill Brown");
AddAIName(4, "John Miller");
AddAIName(4, "Gerge Davis");
AddAIName(4, "Chester Willson");
AddAIName(4, "Mike Gates");
AddAIName(4, "Walter Day");
AddAIName(4, "Drake McMurphy");
AddAIName(4, "Dave Nicols");
AddAIName(4, "Josh Norris");
AddAIName(4, "Joey Bell");
AddAIName(4, "Ray Wise");
AddAIName(4, "Harry Looper");
AddAIName(4, "Max Gander");
AddAIName(4, "Curly McClure");
AddAIName(4, "Jacob Sexton");
AddAIName(4, "Matthew Leach");
AddAIName(4, "William Shakespeare");
AddAIName(4, "James Benson");
AddAIName(4, "Albert Cock");
AddAIName(4, "Robert Brewer");
AddAIName(4, "Mark Kirby");
AddAIName(4, "Carl Einstein");
AddAIName(4, "Bart Jones");
AddAIName(4, "Barney Henderson");
AddAIName(4, "Charlie Pearson");
AddAIName(4, "Roger Avila");
AddAIName(4, "Tony Hornbuckle");
AddAIName(4, "Jose Mabrey");

function spawnguardA(%guard, %group,%c)
{

%AIname = "guard" @ %guard;
        %name = $AiName[1, %guard-1]; 
	$aiPathNum[%guard] = %AIname;
        if(%c == "") createAI(%AIname, "MissionGroup\\AI\\guard" @ %guard, soldier, %name, %c);
	else createAI(%AIname, "guard" @ %guard, soldier, %name, %c);
	
	 %aiId = AI::getId( %AIname );
	
         Client::setinitialTeam(%aiId, 0);
	GameBase::setTeam(%aiId, 0);
         AI::setVar( %AIname,  iq,  80 );
         AI::setVar( %AIname,  attackMode, -1);
   	ai::setvar(%ainame, spotdist, 200);
      %aiId.spawnclass = assault;
	if($country[0] == "Russia") %alliedweaponlist = "ymosinnagant yppsh ysubmgun ygarand yDP ybazooka";
	else if($country[0] == "US") %alliedweaponlist = "ysniperrifle ythompson ym3 ybazooka ysten ycarbine";
	else if($country[0] == "British") %alliedweaponlist = "ysniperrifle ybar ylanchester ysten ybazooka ybren";
	
	%randomweapon = randomitems(%alliedweaponlist, 6);
	AI::SetAutomaticTargets(%ainame);
      AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
      AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 25);
      AI::callWithId(%AIname, Player::mountitem, %randomweapon, $weaponslot);
	AI::SetVar( %aiName, triggerPct, 0.7 );
}

function WWII::setupAlliedAI(%bool)
{
messageall(0, "--Loading AI...");
  
   $numGuards = %itemCount; 
%itemcount = group::objectcount("Missiongroup\\AI");
   
      if(%bool == "") for(%guard = 1; %guard <= %itemCount; %guard++)
      {
        schedule("spawnguarda(" @ %guard @ ",\"MissionGroup\\\\AI\");", %guard*0.1);
 	}
	else for(%guard = 1; $markerlist["guard" @ %guard] != ""; %guard++)
      {
        schedule("spawnguarda(" @ %guard @ ",\"MissionGroup\\\\AI\"," @ %bool @ ");", %guard*0.1);
 	}
	
}



