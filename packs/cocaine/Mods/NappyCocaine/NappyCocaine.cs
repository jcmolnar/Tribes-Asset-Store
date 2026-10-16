// Nappy Cocaine v1.3 by SSSneeky (based on Nappy V4 by NHOP; Insomniax admin scripts), 2004
// -- Modern Tribes (1.50) entry script.
//
// The release was a scripts.vol plus CocaineOptions.cs, run with -mod <folder>. Here:
// -mod NappyCocaine, scripts loose under scripts\, the options in Mods\NappyCocaine\CocaineOptions.cs.
// Nothing has to be exec'd: scripts\server.cs loads the mod when a server is created.
//
// ADMINS. The mod does not use $AdminPassword. Admin and super admin passwords are the
// $CocaineAdmin[n] lines of CocaineOptions.cs; the port ships NONE (the release shipped a
// default super admin password), so until the host adds a line only the host himself
// (a listen server's own player) is an admin.
//
// This file holds three helpers the admin menu handlers call (PORT changes, see PORT-REPORT.md).
echo(">> Nappy Cocaine v1.3 (SSSneeky, 2004) -- 1.50 port entry");

// ---- which Options-menu codes a client may send ---------------------------------------------
// Game::menuRequest (admin.cs) lists each line only for the rank, and under the Public Admin
// lockout ($Insomniax::PA...), named here; the handler used to act on any code from anyone.
function CocainePort::optAllowed(%clientId, %opt)
{
   if(%opt == "tkopt")
   {
      // the "Kick Team Killer" / "Vote to Kick" line: only against the sender's own team killer,
      // and only once that player has reached the team kill limit
      %k = Insomniax_getKiller(%clientId);
      if(%k == "" || %k == %clientId)
         return false;
      return $tkKills[%k] >= $Insomniax::tkLimit;
   }
   if(%clientId.isSuperAdmin)
      return true;
   if(%opt == "admin" || %opt == "execute")
      return false;
   if(%opt == "vadmin")
      return $Insomniax::PAVote;
   if(%opt == "vkick")
      return $Insomniax::PAKick;
   if(%opt == "vcmission")
      return $Insomniax::PAMission;
   if(%opt == "kick")
      return %clientId.isAdmin && $Insomniax::PAKick;
   if(%opt == "ban")
      return %clientId.isAdmin && $Insomniax::PABan;
   if(%opt == "fteamchange")
      return %clientId.isAdmin && $Insomniax::PATeamChange;
   if(%opt == "cmission")
      return %clientId.isAdmin && $Insomniax::PAMission;
   if(%opt == "etd" || %opt == "dtd")
      return %clientId.isAdmin && $Insomniax::PATeamDamage;
   if(%opt == "cffa" || %opt == "ctourney" || %opt == "smatch")
      return %clientId.isAdmin && $Insomniax::PATourneyMode;
   if(%opt == "ctimelimit")
      return %clientId.isAdmin && $Insomniax::PATimeLimit;
   if(%opt == "reset")
      return %clientId.isAdmin && $Insomniax::PAResetDefaults;
   if(%opt == "insomniax")
      return %clientId.isAdmin && $Insomniax::PAModOptions;
   return true;
}

// ---- the "Server Options" menu ---------------------------------------------------------------
// Super admins always; public admins only while "Server Options" is not locked out.
function CocainePort::modOptAllowed(%clientId)
{
   if(%clientId.isSuperAdmin)
      return true;
   return %clientId.isAdmin && $Insomniax::PAModOptions;
}

// Lines 1 and 2 of that menu (the two anti-TK levels) and the out-of-bounds kill time are for
// every admin who may open it; every other code is a super admin line.
function CocainePort::ixAllowed(%clientId, %opt)
{
   if(%opt == "tkserv" || %opt == "tkclient" || %opt == "areakill")
      return CocainePort::modOptAllowed(%clientId);
   return %clientId.isSuperAdmin;
}
