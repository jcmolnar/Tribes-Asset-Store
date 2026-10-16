// SexNC17.cs -- Modern Tribes (1.50) entry script for "SEX mod NC17" (Sex.v.NC17, 2004-05):
// .:(A):.Armagedon's edit of Plasmatic's Sex mod 3.
//
// The 2004 archive was a flat folder of scripts (its own server.cs, admin.cs, game.cs, item.cs ...)
// plus sex.cs and adminuserlist.cs for the config folder; it was started with "-mod sex" and its
// server.cs loads the settings with exec(sex) and the user list with exec(AdminUserList).
// Here the server-side scripts are in scripts\ and the two config files sit next to this file under
// their own names, so they cannot be confused with the config\sex.cs / config\adminuserlist.cs of the
// Sex mod 3 that ships with the game:
//   SexNC17Settings.cs  = sex.cs (server.cs execs it when a server is created or reset)
//   SexNC17UserList.cs  = an EMPTY admin user list (the archive's list is not shipped)
//
// Server owners: MOTD, vote rules, team names and the mod switches are in SexNC17Settings.cs.
// The host of a listen server is admin automatically. Set your own $AdminPassword in the game's
// server settings if you want sad() logins; none is shipped.

// Kick / ban lengths in seconds. admin.cs reads these and no file of the mod ever set them
// (a kick or ban lasted 0 seconds). Values are the stock ones.
if($Havoc::KickTime == "")
   $Havoc::KickTime = 180;
if($Havoc::BanTime == "")
   $Havoc::BanTime = 1800;

echo(">> SEX mod NC17 (Sex.v.NC17, 2004-05) by .:(A):.Armagedon, on Sex mod 3 by Plasmatic");
