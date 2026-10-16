// Paintball v.Tactical port helper (Modern Tribes 1.50). Not part of the 2004 release.
// Loaded from comchat.cs, in front of XFuncs.cs.
//
// Tab-menu codes arrive from the client, so a code the menu did not list can still be sent.
// processMenuOptions (admin.cs) ran these root-menu codes with no test of its own; this applies
// the condition Game::menuRequest uses when it lists them.
function PBTPort::optAllowed(%clientId, %opt)
{
   if(%opt == "admenu" || %opt == "fteamchange" || %opt == "genset" || %opt == "cmission"
      || %opt == "etd" || %opt == "dtd" || %opt == "cffa" || %opt == "ctourney" || %opt == "smatch")
   {
      if(%clientId.isAdmin)
         return true;
      return false;
   }
   if(%opt == "Paintball")
   {
      if(%clientId.isSuperAdmin)
         return true;
      return false;
   }
   if(%opt == "ClanChat" || %opt == "!ClanChat")
   {
      if(%clientId.isGrey)
         return true;
      return false;
   }
   if(%opt == "vkick")
   {
      if($XCalibur::KickVote && !%clientId.isAdmin && $curVoteTopic == "")
         return true;
      return false;
   }
   if(%opt == "vcmission")
   {
      if($XCalibur::ChangeMissionVote)
         return true;
      return false;
   }
   if(%opt == "vetd" || %opt == "vdtd")
   {
      if($XCalibur::TeamDamageSwitch)
         return true;
      return false;
   }
   return true;
}
