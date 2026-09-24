//----------------------------------------------------------------------------
// Herc Havoc -- HERC systems tick. (File name kept from Mech Mayhem so every
// MechHeat::isMech / MechHeat::baseChassis caller keeps working.)
//
// NO HEAT, NO SHUTDOWN. Energy is the reactor: each chassis carries its
// default reactor's battery as maxEnergy and recharges at the reactor's
// output per second (GameBase::setRechargeRate in grantLoadout). Weapons draw
// their Starsiege charge per shot; an empty reactor simply stops you firing.
//
// Per tick, for every live HERC:
//   * conscription init for BotBrain bots (they bypass Game::playerSpawned)
//   * shield regeneration at the default shield generator's rate
//   * Quicksilver nano armour self-repair on the bosses (Starsiege regen_rate)
//
// The tick is kicked from Game::startMatch (MechGame.cs) -- NEVER from boot
// scope: ConsoleScheduler is recreated at mission load and boot-scope
// schedules are silently dropped.
//----------------------------------------------------------------------------

$MM::HeatTickSecs = 0.4;

function MechHeat::isMech(%data)
{
   // all HERC datablocks start "Herc"
   return String::getSubStr(%data, 0, 4) == "Herc";
}

// strip a trailing Crip (or legacy Down) to get the base chassis name
function MechHeat::baseChassis(%data)
{
   %n = String::len(%data);
   if (String::getSubStr(%data, %n - 4, 4) == "Down")
      return String::getSubStr(%data, 0, %n - 4);
   // damaged-drive speed tiers (hh_gen SPEED_TIERS), all 4-character suffixes
   %suf = String::getSubStr(%data, %n - 4, 4);
   if (%suf == "Crip" || %suf == "Spd8" || %suf == "Spd4")
      return String::getSubStr(%data, 0, %n - 4);
   return %data;
}

function MechHeat::visit(%obj)
{
   %data = GameBase::getDataName(%obj);
   if (!MechHeat::isMech(%data))
      return;
   if (Player::isDead(%obj))
      return;
   %base = MechHeat::baseChassis(%data);

   // BOT CONSCRIPTION INIT: BotBrain spawns its bots directly (AI_spawnBot),
   // bypassing Game::playerSpawned -- a roster bot arrives here with no
   // shields, no reactor rate and no mounted rack. Idempotent via mmInit.
   if (%obj.mmInit != 1) {
      %obj.mmInit = 1;
      MechShield::init(%obj, %base);
      MechMayhem::grantLoadout(%obj, %obj, %base);
      echo("[HERC] conscript init: " @ %obj @ " (" @ %base @ ")");
   }

   MechShield::regen(%obj, $MM::HeatTickSecs);
   HHComp::tick(%obj, $MM::HeatTickSecs, %base);   // special components
   HHVoice::watch(%obj, %base);                    // cockpit voice call-outs

   // Quicksilver nano armour (bosses): slow hull self-repair
   if ($HH::Armor[%base] == "X" && HHParts::damaged(%obj))
      HHParts::repair(%obj, $HH::QuicksilverRegen * $MM::HeatTickSecs);

   // Starsiege lock-on: missiles only fire (chain) and guide once the eye has held
   // one target for their Lock_time -- tell the pilot the moment it completes
   %cl = Player::getClient(%obj);
   if (%cl > 0) {
      %lk = Player::getChainLock(%obj);
      %lt = getWord(%lk, 0);
      %lp = getWord(%lk, 1);
      if (%lt == -1)
         %obj.hhLockSaid = "";
      else if (%lp >= 1 && %obj.hhLockSaid != %lt) {
         %obj.hhLockSaid = %lt;
         Client::sendMessage(%cl, 1, "TARGET LOCKED");
      }
      // cockpit reticle (sscockpit remoteHHLock): on change, and as a keepalive
      if (MechEject::isHumanClient(%cl) &&
          (%lp != %obj.hhLockSent || getSimTime() - %obj.hhLockSentAt > 1.2)) {
         %obj.hhLockSent = %lp;
         %obj.hhLockSentAt = getSimTime();
         remoteEval(%cl, "HHLock", %lp);
      }
   }
}

function MechHeat::tick()
{
   Group::iterateRecursive(MissionCleanup, "MechHeat::visit");
   schedule("MechHeat::tick();", $MM::HeatTickSecs);
}

echo("[HERC] systems tick loaded (no heat, no shutdown).");
