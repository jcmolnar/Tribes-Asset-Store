function remoteCF(%client)
{
	%player = Client::getOwnedObject(%client);
	GameBase::getLOSInfo(%player,300);
	%flag = newObject("Flag","Item","Flag",1,false,false,false);
	addToSet("MissionCleanup", %flag);
	GameBase::setTeam(%flag, 3);
	GameBase::setPosition(%flag,$los::position);


	%flag2 = newObject("Flag","Item","Flag",1,false,false,false);
	addToSet("MissionCleanup", %flag2);
	GameBase::setTeam(%flag2, gamebase::getteam(%client));
	GameBase::setPosition(%flag2,gamebase::getPosition(%client));

	%flag2.opposite = %flag;
	%flag.opposite = %flag2;
}

function Flag::setWaypoint(%client, %flag)
{
   if(!%client.autoWaypoint)
      return;
   %flagTeam = GameBase::getTeam(%flag);
   %team = Client::getTeam(%client);

	%pos = (%flag.opposite).originalPosition;
	%posX = getWord(%pos,0);
	%posY = getWord(%pos,1);
	issueCommand(%client, %client, 0,"Take the " @ getTeamName(%flagTeam) @ " flag to our flag.~wcapobj", %posX, %posY);

}
function Flag::onAdd(%this)
{
	%this.scoreValue = "1";
	schedule("Flag::Setposition("@%this@");", 0.2);
	%this.atHome = "true";
	%this.pickupSequence = "0";
	%this.carrier = "-1";
	%this.holdingTeam = "-1";
	%this.enemyCaps = "0";


	%this.destroyable = "True";
	%this.deleteOnDestroy = "False";
	%this.rotates = "False";
	%this.collideable = "False";

	%this.count = "1";
}

function Flag::Setposition(%this)
{
	//both("setting home... "@%this);
	%this.originalPosition = gamebase::getposition(%this);
}
function remoteThrow(%cl,%w)
{
	%pl = Client::getOwnedObject(%cl);
	GameBase::throw(%w, %pl, 10, false);
	item::setvelocity(%w,"0 0 100");
}
function Flag::onDrop(%player, %type)
{
	if(%player.isDuck)
		return;

   %playerTeam = GameBase::getTeam(%player);
   %flag = %player.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   %playerClient = Player::getClient(%player);
   %dropClientName = Client::getName(%playerClient);

   if(%flagTeam == -1)
   {
      MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped " @ %flag.objectiveName @ "!");
      Client::sendMessage(%playerClient, 1, "You dropped "  @ %flag.objectiveName @ "!");
   }
   else
   {
      MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
      Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
      TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
   }
   //both("throw...");
   GameBase::throw(%flag, %player, 10, false);
   Item::hide(%flag, false);
   Player::setItemCount(%player, "Flag", 0);
   %flag.carrier = -1;
   %player.carryFlag = "";
   Flag::clearWaypoint(%playerClient, false);

   schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
   //ObjectiveMission::ObjectiveChanged(%flag);
}

function Flag::onCollision(%this, %object)
{

   if(getObjectType(%object) != "Player")
      return;

   if(%this.carrier != -1)
      return;// both("Flag collision: spurious...");// spurious collision

   if(Player::isAIControlled(%object))
   	return;

   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);

   %flagTeam = GameBase::getTeam(%this);
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);

    //both("Flag collision: Start: ", %object@" "@%touchClientName);


   if(%flagTeam == %playerTeam)
   {
	   //both("Flag collision: same team");
      // player is touching his own flag...
      if(!%this.atHome)
      {
		  //both("Flag collision: Return... it's not home");
         // the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
         Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
         %this.atHome = true;
         MessageAllExcept(%playerClient, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         teamMessages(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
         %this.pickupSequence++;
         ObjectiveMission::ObjectiveChanged(%this);
      }
      else
      {
         // it's at home - see if we have an enemy flag!
         if(%object.carryFlag != "")
         {
            // can't cap the neutral flags, duh
           	%enemyTeam = GameBase::getTeam(%object.carryFlag);
			   if(%enemyTeam != -1)
            {
               MessageAllExcept(%playerClient, 0, %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
               Client::sendMessage(%playerClient, 0, "You captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
               TeamMessages(1, %playerTeam, "Your team captured the flag.", %enemyTeam, "Your team's flag was captured.");

               %flag = %object.carryFlag;
               %flag.atHome = true;
               %flag.carrier = -1;
               %flag.caps[%playerTeam]++;
               %flag.enemyCaps++;


               Item::hide(%flag, false);
               $flagAtHome[1] = true;
               GameBase::setPosition(%flag, %flag.originalPosition);
               Item::setVelocity(%flag, "0 0 0");

               //%flag.trainingObjectiveComplete = true;
               //ObjectiveMission::ObjectiveChanged(%flag);

               Player::setItemCount(%object, Flag, 0);
               %object.carryFlag = "";
               Flag::clearWaypoint(%playerClient, true);

               $teamScore[%playerTeam] += %flag.scoreValue;
               //ObjectiveMission::checkScoreLimit();

               //flag carrier gets 5 points for caputure
               %playerClient.score += 5;
               Game::refreshClientScore(%playerClient);
               messageAll(0, Client::getName(%playerClient) @ " receives 5 point capture bonus.");
            }
         }
      }
   }
   else
   {
      // it's an enemy's flag! woohoo!
      if(%object.carryFlag == "")
      {
			if(%object.outArea == "") {
				// don't pick up our flags
        		if(%this.holdingTeam == %playerTeam)
        		   return;

        		Player::setItemCount(%object, Flag, 1);
        		Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
        		Item::hide(%this, true);
        		$flagAtHome[1] = false;
        		%this.atHome = false;
        		%this.carrier = %object;
        		%this.pickupSequence++;
        		%object.carryFlag = %this;
	 			Flag::setWaypoint(%playerClient, %this);
	 			if(%this.fadeOut) {
					GameBase::startFadeIn(%this);
	 				%this.fadeOut= "";
				}

        		if((%this.lastTeam == "" || %this.lastTeam != %playerTeam) && %flagTeam == -1) {
			 		%this.currentFlagStand="";
			 		%this.changeTeamCount++;
					%this.lastTeam = %playerTeam;
     		      %this.timerOn = 1;
     		      if($flagToStandTime >= 30) {
	     		      %timeToStand = $flagToStandTime - 30;
						%timeLeft = 30;
	     		      if($flagToStandTime > 30)
	     		      	Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
					}
					else {
						if($flagToStandTime >= 10)
							%remain = $flagToStandTime % 10;
						else
							%remain = $flagToStandTime % 5;

						if(%remain > 0 && %remain != $flagToStandTime) {
							%timeToStand = %remain;
							%timeLeft = $flagToStandTime - %remain;
		     		      Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
						}
						else {
							%timeToStand = 0;
							%timeLeft = $flagToStandTime;
						}
					}

     		      schedule("Flag::checkFlagsTime(" @ %this @"," @ %timeLeft @ "," @ %this.changeTeamCount @ ");",%timeToStand);
				}

        		if(%flagTeam != -1)
        		{
	     		   MessageAllExcept(%playerClient, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   Client::sendMessage(%playerClient, 0, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   TeamMessages(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");
        		}
        		else
        		{
        		   %hteam = %this.holdingTeam;
	     		   if(%hteam != -1)
        		   {
        		      $teamScore[%hteam] -= %this.scoreValue;
        		      $deltaTeamScore[%hteam] -= %this.deltaTeamScore;

	     		      MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
        		      Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
        		      TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", %hteam, "Your team lost " @ %this.objectiveName @ ".", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.");
        		      %this.holdingTeam = -1;
        		      %this.holder.flag = "";
        		   }
        		   else
        		   {
	     		      MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ ".~wflag1.wav");
        		      Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ ".~wflag1.wav");
        		      TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ ".");
        		   }
        		}
        		%this.trainingObjectiveComplete = true;
        		ObjectiveMission::ObjectiveChanged(%this);
			}
			else
  		      Client::sendMessage(%playerClient, 1, "Flag not in mission area.");
		}
   }
}