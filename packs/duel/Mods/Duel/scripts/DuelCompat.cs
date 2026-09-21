//-----------------------------------------------------------------------------
// DuelCompat.cs -- names the Duel mod calls but never shipped a definition for.
//
// duelmod.cs execs this early (right after serverConfig.cs), before AdminRemotes
// and the TD chain, because several of them are called from those files.
//
// EVERY name in here was ALREADY undefined on the live =Argh!= server this build
// came from -- these are not port regressions. A call to an unknown console name
// in Tribes fails SILENTLY: it returns empty, execution continues, and the
// symptom shows up somewhere else entirely. That is why they are all given a
// definition here rather than left to rot.
//
// Three groups:
//   1. REPAIRED  -- the definition existed in a file this port drops, and the
//                   feature is otherwise fully wired, so it is restored here.
//   2. IMPLEMENTED -- the name was never defined anywhere, but the call sites
//                   need a real answer, so one is written.
//   3. STUBBED   -- the name was never defined anywhere and the state it would
//                   operate on is not maintained by anything that ships. A quiet
//                   no-op is the faithful behaviour; restoring a guess would be
//                   worse than the silence the original had.
//-----------------------------------------------------------------------------


// ========================= 0. PERMISSION HELPER =============================

//-----------------------------------------------------------------------------
// Duel::requireAdmin(%clientId) -- true if the caller may run an admin/build tool,
// otherwise tells them no and returns false.
//
// Every console function whose name starts with "remote" is reachable straight off
// the wire: a client sends remoteEval and simBase.cpp dispatches "remote<Name>".
// This mod has 133 of them and most were written with no permission check at all,
// which was fine on one private server and is not fine in a pack anyone can install.
// Used by the handful that delete other people's work or write files.
//-----------------------------------------------------------------------------
function Duel::requireAdmin(%clientId)
{
   if(%clientId.isAdmin || %clientId.isSuperAdmin || %clientId.AboveAdmin)
      return true;
   client::sendmessage(%clientId, 1, "That command is for admins.");
   return false;
}


// ============================= 2. IMPLEMENTED ===============================

//-----------------------------------------------------------------------------
// Vector::Rotate(%vec, %rot) -- rotate %vec ("x y z") by the euler %rot ("x y z").
//
// item.cs calls this 8 times to place a built object relative to the player's
// facing (nudge forward / back / left / right). No such command exists: the
// engine registers Vector::add, sub, neg, dot, normalize, getDistance,
// getRotation and getFromRot -- but not rotate. So every one of those calls
// returned "" and the object was placed at Vector::add("", %oldpos), i.e. junk.
//
// Built from the one rotation primitive the engine DOES expose. getFromRot(rot,y,z)
// runs (0,y,z) through the rotation matrix M, so:
//      F = M*(0,1,0)   getFromRot(%rot, 1)
//      U = M*(0,0,1)   getFromRot(%rot, 0, 1)
// and because M is a rotation (det +1), M*(1,0,0) = M*(e2 x e3) = F x U. That
// gives the full basis without any trig, exactly, for any rotation -- not just
// the yaw-only case the call sites happen to use.
//-----------------------------------------------------------------------------
function Vector::Rotate(%vec, %rot)
{
   %F = Vector::getFromRot(%rot, 1);
   %U = Vector::getFromRot(%rot, 0, 1);

   %fx = getWord(%F, 0);  %fy = getWord(%F, 1);  %fz = getWord(%F, 2);
   %ux = getWord(%U, 0);  %uy = getWord(%U, 1);  %uz = getWord(%U, 2);

   // R = F x U
   %rx = (%fy * %uz) - (%fz * %uy);
   %ry = (%fz * %ux) - (%fx * %uz);
   %rz = (%fx * %uy) - (%fy * %ux);

   %a = getWord(%vec, 0);  %b = getWord(%vec, 1);  %c = getWord(%vec, 2);

   %ox = (%a * %rx) + (%b * %fx) + (%c * %ux);
   %oy = (%a * %ry) + (%b * %fy) + (%c * %uy);
   %oz = (%a * %rz) + (%b * %fz) + (%c * %uz);

   return %ox @ " " @ %oy @ " " @ %oz;
}

//-----------------------------------------------------------------------------
// remoteAN -- short alias for remotePlayAnim, used by the mod's client scripts.
// Lived in the mod's own copy of client.cs, which this port drops (its only other
// delta was whitespace, and base's 1.40 client.cs carries ~150 lines of fixes
// worth keeping).
//-----------------------------------------------------------------------------
function remoteAN(%cl, %anim)
{
   remotePlayAnim(%cl, %anim);
}


// ============================== 1. REPAIRED =================================

//-----------------------------------------------------------------------------
// Pack selection. duelmod.cs defines $DuelPack[1..4] and $DuelPackMax, TDMenu
// offers the "Pack:" row, and DMMain.cs reads $DuelPackSetup[%client] when it
// kits a player out -- but the three functions in the middle were left behind in
// duelmatch.cs (an older, separate 1v1 duel mod that this build superseded and
// no longer loads). Restored verbatim so the feature works end to end.
//-----------------------------------------------------------------------------
function PackSetup(%clientId)
{
   Client::buildMenu(%clientId, "Select your pack:", "choosepack", true);
   for(%i = 1; %i <= $DuelPackMax; %i++)
      Client::addMenuItem(%clientId, %i @ $DuelPack[%i], %i);
}

function processMenuchoosepack(%cl, %option)
{
   $DuelPackSetup[%cl] = %option;

   if(!$DuelWeaponSetup[%cl, 0])  $DuelWeaponSetup[%cl, 0] = 3;
   if(!$DuelWeaponSetup[%cl, 1])  $DuelWeaponSetup[%cl, 1] = 2;
   if(!$DuelWeaponSetup[%cl, 2])  $DuelWeaponSetup[%cl, 2] = 4;

   bottomprint(%cl, "<jc><f1>Your weapon setup is <f2>" @
      $DuelWeapon[$DuelWeaponSetup[%cl, 0]] @ "<f1>, <f2>" @
      $DuelWeapon[$DuelWeaponSetup[%cl, 1]] @ "<f1>, and <f2>" @
      $DuelWeapon[$DuelWeaponSetup[%cl, 2]] @ "<f1>.\nYour pack setup is a <f2>" @
      $DuelPack[$DuelPackSetup[%cl]] @ "<f1>.", 10);
   schedule("CPmsg(" @ %cl @ ");", 10);
   return;
}

function CPmsg(%cl)
{
   if(!$DuelStart)
   {
      if(%cl.notready)
         centerprint(%cl, "<jc><f0>Welcome to Duel Tournament\n<f2>by [HvC]NaTeDoGG\n\n<f1>Press 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0);
      else
         bottomprint(%cl, "<f1><jc>Waiting for the tournament to start.", 0);
   }
}

//-----------------------------------------------------------------------------
// DeathMatch::ClearObjects -- DMMain.cs calls it when a deathmatch arena is torn
// down. The definition was in DMMain2.cs (the superseded DMMain), where every
// branch of it is an EMPTY body -- it was already a no-op upstream. Kept as one,
// explicitly, so the call resolves.
//-----------------------------------------------------------------------------
function DeathMatch::ClearObjects()
{
}


// =============================== 3. STUBBED =================================
//
// Nothing below was defined anywhere in the upstream package. Each call site
// therefore already did nothing on the live server. They are stubbed rather than
// removed so that (a) the call resolves instead of silently evaluating to "",
// and (b) the list of what this mod is missing stays visible in one place.
//
// Set $Duel::WarnMissing = true to have each one announce itself in the console
// the first time it is hit -- useful if you are trying to recover the originals.

function Duel::missing(%what)
{
   if($Duel::WarnMissing && !$Duel::Warned[%what])
   {
      $Duel::Warned[%what] = true;
      echo("[Duel] missing upstream function called: " @ %what @ " (stubbed in DuelCompat.cs)");
   }
}

// Called from admin.cs after a super-admin login and from duelmod.cs when a
// client is cleaned up. Almost certainly cleared a client's admin/duel flags.
function ClearMe(%client)
{
   Duel::missing("ClearMe");
}

// AdminRemotes.cs -- part of the arena "project" builder's bounds check.
function CheckCorner(%axis, %distance)
{
   Duel::missing("CheckCorner");
}

// AdminRemotes.cs / DMMain2.cs -- spawned one arena prop. The shipped arena
// loader (TDArena.cs + the zz<Arena>.cs tables) does its own spawning, so this
// path is dead in the configuration that ships.
function ArenaSpawnObj(%name, %type, %pos, %rot, %scale)
{
   Duel::missing("ArenaSpawnObj");
   return -1;
}

// AdminRemotes.cs -- pushed a formatted stat line somewhere (an external stats
// daemon over telnet, by the look of the call site). No listener ships here.
function UpdateClientStats(%string)
{
   Duel::missing("UpdateClientStats");
}

// comchat.cs -- the "Set SAD Password" chat flow in TDMenu arms %clientId.SetSAD
// and the next chat line lands here. Never implemented upstream, so the menu
// entry has always been inert. Admin passwords are set in serverConfig.cs.
function SetSAD(%clientId, %message)
{
   Duel::missing("SetSAD");
   client::sendmessage(%clientId, 1, "Admin passwords are set in Mods\\Duel\\serverConfig.cs, not in chat.");
   %clientId.SetSAD = "";
}

// item.cs -- a building-ownership test from a group/clan system this mod does not
// ship. The call site is `if (%TempObj.Owner != "" || GroupSystem::IsInGroup(...))`,
// so returning false leaves the plain owner check in charge, which is the
// behaviour the server actually had.
function GroupSystem::IsInGroup(%clientId, %group)
{
   Duel::missing("GroupSystem::IsInGroup");
   return false;
}

// TDMenu.cs -- belonged to duelmatch.cs's 1v1 auto-pairing system ($DuelPartner /
// $DuelAlive / AssignPartner), which this build replaced with TeamDuel and does
// not load. NOT restored: it would rewrite pairing state that nothing maintains.
function CheckPartners()
{
   Duel::missing("CheckPartners");
}

// TDObjectives.cs -- per-client timing cleanup.
function CleanupTimes(%cl)
{
   Duel::missing("CleanupTimes");
}

// TDOverWriting.cs -- death logging hook.
function LogDeath(%damageType)
{
   Duel::missing("LogDeath");
}

// TDScores.cs -- a terrain-deformation gimmick ("asunder") that was never written.
function Terrain::Asunder(%player)
{
   Duel::missing("Terrain::Asunder");
}

// TDSupport.cs -- Plug:: is the naming convention of the 1.x binary plugin API
// (Attachment.dll and friends). No plugin shipped this, and the Modern Client
// does not load 1.x plugins at all.
function Plug::CloneBlock(%obj, %shape)
{
   Duel::missing("Plug::CloneBlock");
   return -1;
}

// TDStatDetection.cs -- fallback armour damage handler for the "duck" gimmick.
// Player::onDamage is the real one and is what the non-duck path uses.
function BCPlayer::onDamage(%this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object)
{
   Duel::missing("BCPlayer::onDamage");
   return Player::onDamage(%this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object);
}

// duelmod.cs -- the LastHope 1.30 server binary's keepalive. That exe is not this
// engine; the call site upstream was already commented out of createServer.
function LastHope::PeriodicCheck()
{
   Duel::missing("LastHope::PeriodicCheck");
}

// AdminRemotes.cs / TDMenu.cs -- the arena map-ripper: dumped every object's
// position to config\zx<mission>.cs so an arena could be re-authored. It lived in
// TDTesting.cs, which duelmod.cs has commented out of its own boot chain
// (`//exec(tdtesting);`), so it was already undefined on the live server.
function addtodb(%obj)
{
   Duel::missing("addtodb");
}

echo("[Duel] DuelCompat.cs loaded");
