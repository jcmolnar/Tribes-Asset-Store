//%%%%%%%%%%%%AI behavior functions! very sexy! -Floater


//%%%%% this is called whenever someone says something
//%%%%% it then checks who the command issuer was, then
//%%%%% issues different commands and sens the instructions to
//%%%%% the apropriate AI. it is called in comchat.cs. -Floater

function AI::delegateCommands(%clientId, %team, %message)
{


    %AttackerCommand = $AttackerCommand[%client];
    %client = %clientId;
    %team = GameBase::getTeam(%client);
    %name = Client::getName(%client);
    
    %machina = %client @ "_" @ %team @ "machina*";
    %artillery = %client @ "_" @ %team @ "!Artillery!*";
    
    %callA = "Fire on my target~wfiretgt";
    %callB = "Move out.~wmoveout";
    %callC = "Cover me!~wcoverme";
    %callD = "Attack!~wattack";

    %clientObject = Client::getOwnedObject(%client);
    %losInfo = GameBase::getLosInfo(%clientObject,500);
    %losPosition = $los::position;

    //%%%%% Artillery commands -Floater
	if(%message	== %callB) {
             AI::DirectiveRemove(%artillery,1);
             AI::DirectiveFollow(%artillery,%client,8,1);
             $ArtilleryCommand[%client] = 1;
    }

    else if(%message == %callA) {
             AI::DirectiveRemove(%artillery,1);
             AI::directiveTargetLaser(%artillery,%client,1,350);
             $ArtilleryCommand[%client] = 0;
    }

    //%%%%% Attacker commands -Floater
    else if(%message == %callD) {
              AI::DirectiveRemove(%machina,1);
              AI::DirectiveWayPoint(%machina,%losPosition,1);
              $AttackerCommand[%client] = 1;

    }
    else if(%message == %callC) {
              AI::DirectiveRemove(%machina,1);
              AI::DirectiveFollow(%machina,%client,8,1);
              $AttackerCommand[%client] = 0;
              echo("%command = " @ %command);
    }
    //%%%%% There may also be DEFENDER commands later. These guys will stay at
    //%%%%% your base, maybe repairing broken stuff, setting up turrets
    //%%%%% and when someone says "Incoming enemies!" they will pull out
    //%%%%% guns and shoot at 'em. they will only be deployable near invos.
    //%%%%% This hasn't been decided. it just depends how much time i want
    //%%%%% to spend on makin the dudes.
}

//%%%%% These were supposed to be the original behavior functions. Instead, I
//%%%%% shmushed 'em all into AI::delegateCommands for efficiency, at the cost
//%%%%% of nice, neat code. All "commands" are issued via that ^ function, now -Floater
function AI::attacker(%client, %newName, %command)
{
     %command = $AttackerCommand[%player];
     %clientObject = Client::getOwnedObject(%client);
     %losInfo = GameBase::getLosInfo(%clientObject,500);
     %losPosition = $los::position;

     AI::setVar(%newName, iq, 250);
     AI::SetAutomaticTargets(%newName);

     if(%command == 0)
     {
     AI::DirectiveRemove(%newName,1);
     AI::DirectiveFollow(%newName, %client,15,1);
     }

     else if(%command == 1)
     {
     if(%losInfo)
     AI::DirectiveRemove(%newName,1);
     AI::directiveWaypoint(%newName,%losPosition,1);
     }
}

function AI::artillery(%client, %newName)// %ai, %newName)
{
     AI::setVar(%newName,iq,225);
     
     %command = $ArtilleryCommand[%client];

     if(%command == 0)
     {
     AI::DirectiveRemove(%newName,1);
     AI::directiveTargetLaser(%newName,%client,1,350);
     }
     
     else if(%command == 1)
     {
     AI::DirectiveRemove(%newName,1);
     AI::DirectiveFollow(%newName,%client,8,1);
     //AI::SetAutomaticTargets(%newName);
     }
}

function AI::defender(%client, %ai, %newName)
{
	AI::setVar(%newName,iq,300);
	%clientPos = GameBase::getPosition(%client);
	%clientRot = GameBase::getRotation(%client);
	echo(%clientPos);
	echo(%clientRot);
    //%%%%% Probably will never use this function. -Floater
}

function Player::getOwnedAi(%player)
{
    %count = $numAI;
    %aiNumber = 2050;
    echo(%count);
    for(%i= 0; %i <= %count; %i++)
    {
         echo("yo!");

//         if($AiOwnerById[%aiNumber] == %player)
//         {
//              echo("DING! " @ %i);
//         }
         
         %aiNumber++;
         
    }
}
