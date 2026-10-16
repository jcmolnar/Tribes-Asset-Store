
function onPlayerKilled(%killerId, %playerId, %msgTag)
{
   if(!%killerId)
   {
      messageAll(0, strcat(getPlayerName(%playerId), " died."));
   }
   else if(%playerId == %killerId)
   {
      %message1 = strcat(getPlayerName(%playerId), " killed himself.");
      %message2 = "You killed yourself.";
      if(%playerId == $ITplayer)
      {
         %message1 = strcat(%message1, "  IT is up for grabs!");
         %message2 = strcat(%message2, "  You are no longer it.");
      }   
      messageAllExcept(%playerId, 0, %message1);
      messageToPlayer(%playerId, 0, %message2);
      $ITplayer = 0;
   }
   else
   {
      %message1 = strcat(getPlayerName(%killerId), " killed player ",
          getPlayerName(%playerId), ".");
      %message2 = strcat("You killed ", getPlayerName(%playerId), ".");

      if(!$ITplayer)
      {
         %message1 = strcat(%message1, "  ", getPlayerName(%killerId), " is now IT!");
         %message2 = strcat(%message2, "  You are now IT!");
         $ITplayer = %killerId;
      }
      else if($ITplayer == %killerId)
      {
         %message1 = strcat(%message1, "  ", getPlayerName(%killerId), " scores a point because he is IT!");
         %message2 = strcat(%message2, "  You score!");
         playerScored(%killerId, 1);
      }
      else if($ITplayer == %playerId)
      {
         %message1 = strcat(%message1, "  ", getPlayerName(%killerId), " is now IT!");
         %message2 = strcat(%message2, "  You are now IT!");
         $ITplayer = %killerId;
      }
      messageAllExcept(%killerId, 0, %message1);
      messageToPlayer(%killerId, 0, %message2);
   }
}

function onPlayerDisconnect(%playerId)
{
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
   GameBase::throw(%flag, %player, 10, false);
   Item::hide(%flag, false);
   Player::setItemCount(%player, "Flag", 0);
   %flag.carrier = -1;
   %player.carryFlag = "";
   Flag::clearWaypoint(%playerClient, false);

   schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
   ObjectiveMission::ObjectiveChanged(%flag);   
}