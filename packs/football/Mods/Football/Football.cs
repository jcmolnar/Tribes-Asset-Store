// Football.cs -- entry script for the Tribes Football mod (Football_Tasermod v5.7.5) on the 1.50 client.
// console.cs runs this once at boot (ExecModScripts), after base client.cs / server.cs / game.cs and
// BEFORE base serverDefaults.cs and serverPrefs.cs.  The mod's own server.cs (scripts\server.cs) has
// already replaced createServer by then; it loads the rest of the mod when a server is created.

// Helper pack the mod's server.cs / admin.cs / comchat.cs call into (kick, ban, Admin::Exploit,
// String::containsCrash, Client::trimIP ...).  The original install exec'd it from the host's autoexec.cs.
exec("CrashProtectionPack.cs");

// Football rule settings ($VoteAdminAllowed, $halftimeDelay, $gunFumbleChance, $ConnectsPerIP ...).
// Host identity, passwords, telnet and the hand-built mission rotation in it are commented out
// (//PORT-OFF:) -- set those in your own serverPrefs.cs / autoexec.cs.
exec("FootballserverConfig.cs");

// The mod's "Silence" admin option was enforced for voice-menu sounds inside the mod's copy of client.cs.
// That 1.0-era file is not shipped (base client.cs is used), so the one server-side check it carried is
// restored here.  The length guard is the one base client.cs has.
function remoteLMSG(%cl, %wav)
{
   if(String::getSubStr(%wav, 0, 50) != %wav)
      return false;
   if(!$GlobalMute[%cl])
      playVoice(%cl, %wav);
}
