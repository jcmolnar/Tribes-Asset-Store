// Renegades Duel port helper (Modern Tribes 1.50). Not part of the 2002 release.
// Loaded once from createServer (server.cs), next to duelshapes.cs.

// Tab-menu codes arrive from the client (remoteMenuSelect -> processMenuOptions), so a code the
// menu did not list can still be sent. This applies the conditions the duel menus use when they
// list an option, plus the Renegades Classic vote settings (Renegades.cs) and its "stripped of
// voting privileges" flag, which the duel menus never looked at.
// duelmatch.cs calls hvcAdminMsg but only RenDuel.cs defines it (same text as there).
function hvcAdminMsg(%msg)
{
   echo("SERVER: " @ %msg);
   %numPlayers = getNumClients();
   for(%i = 0; %i < %numPlayers; %i++)
   {
      %pl = getClientByIndex(%i);
      if(%pl.isSuperAdmin)
         Client::sendMessage(%pl, 0, %msg);
   }
}

function RenDuelPort::isClient(%cl)
{
   if(%cl == "" || %cl == 0 || %cl == -1)
      return false;
   if(Client::getName(%cl) == "")
      return false;
   return true;
}

function RenDuelPort::optAllowed(%clientId, %opt, %cl)
{
   if(%opt == "removeadmin")
   {
      if(!%clientId.isSuperAdmin)
         return false;
      if(!RenDuelPort::isClient(%cl))
         return false;
      if(%cl == %clientId)
         return true;
      if(%cl.isSuperAdmin || %cl.isGod)
         return false;
      return true;
   }
   if(%opt == "admin" || %opt == "ban")
   {
      if(%clientId.isSuperAdmin && RenDuelPort::isClient(%cl))
         return true;
      return false;
   }
   if(%opt == "kick" || %opt == "fteamchange")
   {
      if(%clientId.isAdmin && RenDuelPort::isClient(%cl))
         return true;
      return false;
   }
   if(%opt == "ctimelimit" || %opt == "reset" || %opt == "smatch" || %opt == "etd" || %opt == "dtd" || %opt == "cffa" || %opt == "ctourney")
   {
      if(%clientId.isAdmin)
         return true;
      return false;
   }
   if(%opt == "cmission")
   {
      if(%clientId.isSuperAdmin)
         return true;
      if(%clientId.isAdmin && $Reneg::PAMission)
         return true;
      return false;
   }
   if(%opt == "forcedt")
   {
      if(%clientId.isAdmin && !$DuelStart && $matchStarted)
         return true;
      return false;
   }
   if(%opt == "changeteams")
      return false;
   if(%opt == "observe")
   {
      if(!Observer::isObserver(%clientId))
         return false;
      if(%cl == %clientId || !RenDuelPort::isClient(%cl))
         return false;
      return true;
   }
   if(%opt == "vkick" || %opt == "vadmin")
   {
      if(%clientId.isAdmin || %clientId.Nvote || $curVoteTopic != "")
         return false;
      if(!RenDuelPort::isClient(%cl))
         return false;
      if(%opt == "vkick" && $Reneg::VoteKick)
         return true;
      if(%opt == "vadmin" && $Reneg::VotePA)
         return true;
      return false;
   }
   if(%opt == "vcmission")
   {
      if(!%clientId.Nvote && $Reneg::VoteMission)
         return true;
      return false;
   }
   if(%opt == "vetd" || %opt == "vdtd")
   {
      if(!%clientId.Nvote && $Reneg::VoteTD)
         return true;
      return false;
   }
   if(%opt == "vcffa" || %opt == "vctourney")
   {
      if(!%clientId.Nvote && $Reneg::VoteTourney)
         return true;
      return false;
   }
   if(%opt == "vsmatch")
   {
      if(%clientId.Nvote)
         return false;
      return true;
   }
   return true;
}
