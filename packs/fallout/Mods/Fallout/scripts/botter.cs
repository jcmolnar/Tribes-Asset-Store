//%%%%%%%%%%%%%%% start helper function call -Floater
function AI::bhelper(%aiName, %armorType, %player, %client, %team, %role)
{
    //%%%%% get player position, add a few decimal spaces, and spawn -Floater
    %spawnMarker = GameBase::getPosition(%player);
    %xPos = getWord(%spawnMarker, 0) + floor(getRandom());
	%yPos = getword(%spawnMarker, 1) + floor(getRandom());
	%zPos = getWord(%spawnMarker, 2);
    %zGroupPos = %zPos + 300;
	%rPos = GameBase::getRotation(%player);

	%aiSpawnPos = %xPos @ " " @ %yPos @ " " @ %zPos;
    %aiGroupSpawnPos = %xpos @ " " @ %yPos @ " " @ %zGroupPos;

	%newName = %aiName @ $numAI;
	$numAI++;

    if(%role != 12)
    Ai::spawn(%newName, %armorType, %aiSpawnPos, %rPos);
    else if(%role == 12)
    Ai::spawn(%newName, %armorType, %aiGroupSpawnPos, %rPos);

    //%%%%% Set some basic variables. Makes sure a client was provided.
    //%%%%% -------------------------------------
    //%%%%% if(!%client)
    //%%%%% %client = Player::getClient(%player);
    //%%%%% -------------------------------------
    //%%%%% ^ This is
    //%%%%% a fix for a bug that comes and goes, that messes up the whole bot
    //%%%%% system if it isn't corrected. For some reason, it only happens with
    //%%%%% some bots, not all don't uncomment the lines above, it will screw
    //%%%%% things up. it's called below. it's freaking WEIRD! -Floater

    %ai = AI::getId(%newName);
    if(!%client)
    %client = Player::getClient(%player);
    %barmor = Player::getArmor(%ai);
//	%slave = Player::getClient(%ai);
    %botterIQ = floor(getRandom() * 125) + 25;

    //%%%%% Also pivotal. Basically, anything in this part or above in this
    //%%%%% function can't be screwed with, unless you want to completely redo
    //%%%%% EVERYTHING! So, don't mess with it unless you have to.
	GameBase::setTeam(%ai, %team);
    Client::setOwnedObject(%player,%ai);

    //%%%%% Some of these variables are now used. There are extras, just in case -Floater
	$AiOwnerById[%ai] = %client;
    $AiTeam[%ai] = %team;
	$AiOwnerByName[%newName] = %client;
	$Ainame[%ai] = %newName;
	$BotCount[%client]++;
	$PlayerAi[%client,%newName] = %ai;
    $PlayerIsAi[%ai] = "True";

    $AttackerCommand[%client] = 0;

	//%%%%% Now comes weapon usage upon spawn, and behavior calls. -Floater
    if(%barmor == "larmor") {
         if(%role == -1) {
              Player::setItemCount(%ai,SuperBlaster,1);
  			  Player::setItemCount(%ai,PowerCell,10000000);
              Player::mountItem(%ai,SuperBlaster,0);
              AI::attacker(%client, %newName);
         }
	     else {
              Player::setItemCount(%ai,BotBlaster,1);
			  Player::mountItem(%ai,blaster,0);
    	      AI::attacker(%client, %newName);
		 }
	}
	else if(%barmor == "marmor") {
			Player::setItemCount(%ai,PlasmaGun,1);
			Player::setItemCount(%ai,PlasmaAmmo,10000);
			Player::mountItem(%ai,PlasmaGun,0);
	            	AI::attacker(%client, %newName);
	}
		else if(%barmor == "harmor")
			{
//---------------
		            if(%role == 11)
		                 {
		                    Player::setItemCount(%ai,Mortar,1);
		        			Player::setItemCount(%ai,MortarAmmo,10000);
		                    Player::mountItem(%ai,Mortar,0);
		
		                    $ArtilleryCommand[%client] = 0;
		
		                    AI::artillery(%client, %newName);
		
		                 }
		            else
		                 {
		                    Player::setItemCount(%ai,PlasmaGun,1);
		                    Player::setItemCount(%ai,PlasmaAmmo,10000);
                            Player::setItemCount(%ai,SuperBlaster,1);
                            Player::setItemCount(%ai,PowerCell,10000000);
		                    Player::setItemCount(%ai,Blaster,1);
		                    Player::mountItem(%ai,SuperBlaster,0);
                            //%%%%% Uncomment this next line for mortar bots. They have
                            //%%%%% a tendency to kill their teammates, and shoot poorly
                            //%%%%% on their own, so i gave em a SuperBlaster -Floater
                            //Player::mountItem(%ai,Mortar,0);//%slave,Mortar,0);
		                    AI::attacker(%client, %newName);
            		     }
//---------------
			}
		else
			{
			Player::setItemCount(%ai,BotBlaster,1);
			Player::mountItem(%ai,Blaster,0);
            AI::attacker(%client, %newName);
			}
 	return ( %newName );
 }
//%%%%%%%%%%%%%%% end helper function -Floater

//%%%%% Fallout function for dead AI cleanup. Necessary to make sure nobody's got too many bots, among other things.
function AI::Cleanup(%playerId, %killerId, %damageType)//%%%%% This is called in Client onKilled
{

    %playerAiControl = $PlayerIsAi[%playerId];//Player::isAiControlled(%playerId);
    %killerAiControl = $PlayerIsAi[%killerId];

    echo(%playerId);
    echo("Ai Cleanup called. Player isAiControlled: " @ %aiControl);
    echo("Killer ID: " @ %killerId);
    
    %client = Player::getClient(%player);

//    %playerTeam = GameBase::getTeam(%playerId);
//    %killerTeam = GameBase::getTeam(%killerId);

	if(%playerAiControl == "True") {
         %playerTeam = $AiTeam[%playerId];
         %killerTeam = $AiTeam[%killerId];
         %client = $AiOwnerById[%playerId];
	     %ai = %playerId;

         $BotCount[%client]--;

         Ai::Delete(%ai);

         echo("Killer team: " @ %killerTeam @ " Victim team: " @ %playerTeam);

         if(%playerTeam != %killerTeam) {
              echo("Player inc score supposed to happen. Client ID: " @ %client);
              %client.score++;
              Game::refreshClientScore(%client);
         }
         else if(%playerTeam == %killerTeam) {
              echo("Player dec score supposed to happen. Client ID: " @ %client);
              %client.score--;
              Game::refreshClientScore(%client);
         }

         if($debug == "True") {
              echo($BotCount[%client]);
              Player::incItemCount(%client,BotAmmo,1);
              echo("Game::clientKilled(" @ %playerId @ "," @ %killerId @ "); succeeded.");
         }
	}
//    else if(%aiControl != "True") //%%%%% needs to be added.
}
