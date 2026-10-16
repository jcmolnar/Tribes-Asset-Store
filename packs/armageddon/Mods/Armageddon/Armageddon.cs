// Armageddon ("Meltdown v w00", 2002) by |*|w00|*|GreyWolf with [GL]VRWarper -- Modern Tribes
// (1.50) port, entry script.
//
// The release was a bare script folder that ran as  Tribes.exe -mod Meltdown : the stock loader
// then executed Meltdown\Meltdown.cs (the mod's settings file) because it carried the folder name.
// The port's folder is Armageddon, so this file does that exec.

// The mod's own settings: vote switches, team-kill limits, ban lists, admin passwords, auto-admins.
// It ships with the author's own server entries switched off (lines marked //PORT-OFF:). A host
// fills in his own. Notes for a host:
//   * admin is NOT $AdminPassword in this mod: it is $Meltdown::PAPassword[n] (public admin),
//     $Meltdown::SadPassword[n] (super admin) and $Meltdown::GAPassword[n] (master admin).
//   * an auto-admin needs BOTH $Server::AutoAdmin[n] (name) and $Server::AutoAdminAddr[n] (start of
//     the address, "IP:a.b.c"). A name with a blank address no longer matches anybody.
//   * $TagADMIN[n] makes EVERY player whose name contains that tag an admin. Leave it blank unless
//     you understand that anyone can type a tag.
exec("Meltdown.cs");

// A kick bans for $Meltdown::BanTime seconds, and this build never sets it. Stock Tribes uses 180.
if($Meltdown::BanTime == "")
   $Meltdown::BanTime = 180;

// Functions the mod calls but does not define (see the file for each one).
exec("Armageddon_compat.cs");

echo("Armageddon (Meltdown v w00, 1.50 port) loaded.");
