// Chivalry v2.0 by [CLU]Robear and [CLU]Clu, the Sojourn Development Team (September 2000)
// -- Modern Tribes (1.50) entry script.
//
// Original launch line (Chivalry Admin Manual, section 1):
//    c:/Dynamix/Tribes.exe -mod Chivalry -dedicated
// with scripts.vol in Tribes\Chivalry, ChivalryPrefs.cs in Tribes\config and a blank
// ReturnPlayers.cs in Tribes\temp. Here: -mod Chivalry, scripts loose under scripts\, the
// default options in Mods\Chivalry\ChivalryPrefs.cs. Nothing has to be exec'd: scripts\server.cs
// loads the mod when a server is created.
//
// Files the mod writes while it runs (as in 2000):
//    temp\ReturnPlayers.cs      every player's name, rank, score, team kills, ADDRESS and
//                               character PASSWORD, in plain text
//    config\ChivalryPrefs.cs    the options, rewritten when a Warlord or Paladin is crowned
//                               (from then on it is read instead of the copy in the mod folder)
//
// The character password is the text of the last box of the Player Setup screen, "Other info"
// in 1998, labelled "RPG password" by the 1.50 client. The mod's own messages still say
// "Other Info".
//
// This file holds three helpers the scripts call (PORT changes, see the pack's PORT-REPORT.md).
echo(">> Chivalry v2.0 (Sojourn Development Team, 2000) -- 1.50 port entry");

// ---- which 'Chivalry Options' menu codes a client may send --------------------------------
// The menu (admin.cs, processMenuOptions "chopt") lists Ceremony mode, the crown and stats
// logging for super admins, and "Increase Time", Silence / UnSilence and "More Options" for
// admins. The handler used to act on any code from anyone.
function ChivalryPort::optAllowed(%clientId, %opt)
{
   if(%opt == "discer" || %opt == "encer" || %opt == "nostat" || %opt == "letstat")
      return %clientId.isSuperAdmin;
   if(%opt == "crown")
      return %clientId.isSuperAdmin && $Chivalry::Ceremony;
   if(%opt == "atime" || %opt == "itl" || %opt == "speak" || %opt == "shutup" || %opt == "more1")
      return %clientId.isAdmin || %clientId.isSuperAdmin;
   return true;
}

// ---- $Chivalry::SAD1 .. SAD3: automatic super admin for a player name ----------------------
// Called from CheckPassword (ServerPlayerList.cs) after the character password has matched.
// The name must have had a real password on file BEFORE this visit: not "NEW", not empty, and
// not one that was recorded a moment ago. The release gave the rank for the name alone.
// ("x" @ a) == ("x" @ b) is a plain text compare; a bare == treats numbers and true / false
// as values.
function ChivalryPort::autoAdmin(%clientId, %num)
{
   if(%clientId.chivNewPw)
      return;
   %pw = $Stats::Password[%num];
   if(("x" @ %pw) == "x" || ("x" @ %pw) == "xNEW")
      return;
   %name = Client::getName(%clientId);
   if(("x" @ %name) == "x")
      return;
   for(%i = 1; %i <= 3; %i++)
   {
      %sad = $Chivalry::SAD[%i];
      if(("x" @ %sad) != "x" && String::ICompare(%sad, "false") != 0 && ("x" @ %sad) == ("x" @ %name))
      {
         %clientId.isAdmin = true;
         %clientId.isSuperAdmin = true;
         echo("ADMIN: " @ %name @ " is on the SAD list and gave the character password");
         return;
      }
   }
}

// ---- the stats list must end in the name "false" -------------------------------------------
// Every stats loop of the mod runs until it meets that name (Admin Manual: "If this string is
// missing, the server will crash"). Called from createServer after ReturnPlayers.cs was read:
// with no file at all the list becomes the release's blank file, $Stats::Name0 = "false".
function ChivalryPort::checkStats()
{
   for(%i = 0; %i < 200000; %i++)
   {
      %n = $Stats::Name[%i];
      // a real entry always has a rank and a password (NewPlayer); nothing at all = the end
      if(("x" @ %n) == "x" && ("x" @ $Stats::Rank[%i]) == "x" && ("x" @ $Stats::Password[%i]) == "x")
      {
         $Stats::Name[%i] = "false";
         echo("Chivalry: stats list had no end marker, added at entry " @ %i);
         return;
      }
      if(String::ICompare(%n, "false") == 0)
         return;
   }
}
