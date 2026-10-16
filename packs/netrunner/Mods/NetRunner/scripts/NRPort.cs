// NetRunner -- helpers added by the Modern Tribes (1.50) port. Not part of the original mod.
// Loaded by the first line of createServer (scripts\server.cs).

// server.cs picks the next map with this when $RandomMissions is set. It came from the mod's
// copy of missionlist.cs, which is otherwise the stock file and is not shipped.
function MissionList::nextRandom()
{
   %i = floor(getRandom() * $MLIST::Count);
   return $MLIST::EName[%i];
}

// The Tab menu only LISTS what a player may do; the option code itself is sent by the client.
// This is the test Game::menuRequest and the three sub-menus (Voting Items, Admin Functions,
// Super Admin Functions) apply before they list an entry.
function NRPort::optionAllowed(%clientId, %opt)
{
   if(%opt == "kill" || %opt == "ban" || %opt == "fteamchange" || %opt == "admin"
      || %opt == "deadmin" || %opt == "admute" || %opt == "deadmute" || %opt == "cffa"
      || %opt == "ctourney" || %opt == "smatch" || %opt == "reset" || %opt == "superrights")
   {
      if(%clientId.isSuperAdmin)
         return true;
      return false;
   }
   if(%opt == "kick" || %opt == "etd" || %opt == "dtd" || %opt == "ctimelimit"
      || %opt == "adminrights" || %opt == "cancelVote")
   {
      if(%clientId.isAdmin || %clientId.isSuperAdmin)
         return true;
      return false;
   }
   if(%opt == "vkick")
   {
      if($NetRunner::VoteKick)
         return true;
      return false;
   }
   if(%opt == "vadmin")
   {
      if($NetRunner::VoteAdmin)
         return true;
      return false;
   }
   if(%opt == "vetd" || %opt == "vdtd")
   {
      if($NetRunner::VoteDTD)
         return true;
      return false;
   }
   if(%opt == "vcffa" || %opt == "vctourney" || %opt == "vsmatch")
   {
      if($NetRunner::VoteFFA)
         return true;
      return false;
   }
   return true;
}

// May this player move to this team by his own menu pick? Same rule the "Pick a team" menu uses
// when it lists the teams ($NetRunner::KeepBalanced: only the smallest team, or any team for a
// player who has none while the teams are level).
function NRPort::teamAllowed(%clientId, %team)
{
   if(%team >= getNumTeams())
      return false;
   if(!$NetRunner::KeepBalanced)
      return true;
   %low = checkTeams();
   if(%low == -1)
   {
      if(Client::getTeam(%clientId) == -1)
         return true;
      return false;
   }
   if(%team == %low)
      return true;
   return false;
}

// The super admin menu lists "DeAdmin <player>" and opens a confirm menu called "daffirm", but
// admin.cs has no handler for it, so picking "DeAdmin" did nothing. This is the handler, written
// after processMenuAAffirm; a super admin's own flag is left alone.
function processMenuDAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         if(!%cl.isSuperAdmin)
         {
            %cl.isAdmin = false;
            messageAll(0, Client::getName(%clientId) @ " removed " @ Client::getName(%cl) @ "'s admin status.");
         }
      }
   }
   Game::menuRequest(%clientId);
}
