//----------------------------------------------------------------------------
// Herc Havoc -- game modes (forked from Mech Mayhem's MechGame.cs; function
// names kept so the shared cockpit HUD pack and BotBrain hooks still bind).
// Bound by a mission's tail:  exec(MechGame);  $Game::missionType = "MechMay";
//
// Attrition TDM with Combat-Value tickets: each team starts with a shared CV
// pool; a death subtracts the fallen HERC's FULL Starsiege Combat Value --
// chassis + every default weapon + every default internal. Pool empty -> the
// other team wins. Kills score via the normal DM plumbing too.
//
// Builds on dm.cs (which execs game.cs); overrides below win the last-wins
// exec race. Systems tick + ticket refresh are kicked from Game::startMatch
// (survives the ConsoleScheduler recreation at mission load).
//----------------------------------------------------------------------------
// Base rules: a CTF mission sets $MM::GameBase = "objectives" BEFORE exec'ing
// this file (stock flag/flag-stand/scoring machinery); everything else builds on
// dm.cs. The overrides below keep the objectives' kill/drop hooks alive.
if ($MM::GameBase == "objectives")
   exec(objectives);
else
   exec(dm);
$MM::GameBase = "";
// Mission tails set $MM::Mode AFTER exec(MechGame); clear the previous map's
// value here so an incursion/ctf mode never leaks into the next mission.
$MM::Mode = "";
// The previous match ended with MatchOver = 1 and stale pools; the objectives
// page is written from Mission::init (dm.cs -> DM::missionObjectives below),
// before Game::startMatch resets them, so clear them here too.
$MM::MatchOver = 0;
$MM::Tickets[0] = "";
$MM::Tickets[1] = "";
$HH::PadCount = 0;
exec(MechHeat);
exec(MechDamage);
exec(MechWaves);
exec(MechZones);
exec(MechProgress);
exec(MechEject);
exec(HHVoice);
exec(HHComponents);

// A death now costs the FULL default-config Combat Value (chassis + weapons +
// internals, 6-21k), not the chassis alone (1-8k) -- the pool scales with it
// to keep roughly the same number of deaths per match.
$MM::TicketPool = 180000;

//--- mines on the mine key ----------------------------------------------------
// Starsiege mine packs are not rack weapons here: the stock mine key throws
// MineAmmo, and a HERC throws its own Starsiege mine (%pl.hhMine, set by
// grantLoadout from the generated $HH::MineType table) at its Starsiege energy
// cost. Troopers (the ejected pilot) keep the stock antipersonnel mine.
function MineAmmo::onUse(%player, %item)
{
   if (%player.hhMine == "") {
      // --- stock item.cs:2395 body, verbatim ---
      if($matchStarted) {
         if(%player.throwTime < getSimTime() ) {
            Player::decItemCount(%player,%item);
            %obj = newObject("","Mine","antipersonelMine");
            addToSet("MissionCleanup", %obj);
            %client = Player::getClient(%player);
            GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
            %player.throwTime = getSimTime() + 0.5;
         }
      }
      return;
   }
   if (!$matchStarted || %player.throwTime >= getSimTime())
      return;
   %cost = $HH::MineEnergy[%player.hhMine];
   if (GameBase::getEnergy(%player) < %cost)
      return;
   GameBase::setEnergy(%player, GameBase::getEnergy(%player) - %cost);
   Player::decItemCount(%player, %item);
   %obj = newObject("", "Mine", %player.hhMine);
   addToSet("MissionCleanup", %obj);
   %client = Player::getClient(%player);
   // Starsiege launches mines at StartVel 50 m/s (newMine), not a Tribes throw
   GameBase::throw(%obj, %player, 50, false);
   %obj.hhTeam = GameBase::getTeam(%player);
   if (String::findSubStr(%player.hhMine, "Arach") != -1) {
      %obj.hhSeek = 1;          // HHMine::seek once armed
      %obj.hhLaunchAt = getSimTime();
      %obj.hhSpd = 0;
      // landing heading = the launch heading
      %f = Vector::getFromRot(GameBase::getRotation(%player), 1);
      %fl = Vector::getDistance(getWord(%f, 0) @ " " @ getWord(%f, 1) @ " 0", "0 0 0");
      %obj.hhHx = 0;
      %obj.hhHy = 1;
      if (%fl > 0.01) {
         %obj.hhHx = getWord(%f, 0) / %fl;
         %obj.hhHy = getWord(%f, 1) / %fl;
      }
      // the launcher's target, only if its lock had matured (Lock_time)
      %obj.hhTarget = -1;
      %lk = Player::getChainLock(%player);
      if (getWord(%lk, 0) != -1 && getWord(%lk, 2) >= $HH::MineLock[%player.hhMine])
         %obj.hhTarget = getWord(%lk, 0);
   }
   %player.throwTime = getSimTime() + $HH::MineReload[%player.hhMine];
   // Starsiege mine-launch sound (Arachnitron / Proximity)
   if (String::findSubStr(%player.hhMine, "Arach") != -1)
      playSound(HHSfxMineArach, GameBase::getPosition(%player));
   else
      playSound(HHSfxMineProx, GameBase::getPosition(%player));
}

function HHMine::arm(%this)
{
   if (%this == "" || %this <= 0)
      return;
   GameBase::setActive(%this, true);
   if (%this.hhSeek == 1)
      schedule("HHMine::seek(" @ %this @ ");", 0.2, %this);
}

// Arachnitron, as Starsiege.exe runs it (FOLLOWUP-RE 1):
//   target  the launcher's current target, only if its lock had matured (the
//           mine launcher's Lock_time, 3 s) -- never re-acquired; no target =
//           crawl straight along the landing heading
//   crawl   after landing: 10 m/s^2 up to TermVel 50 m/s along the ground
//   steer   the missile code, turn-limited to 2 rad/s the whole time
//   detonate  straight at the target inside the 10 m cruise envelope; Explode on
//           Miss is forced on, so it blows once the target is behind it; end of
//           its 30 s Duration (HHMine::expire). No proximity fuse (contact only).
$HH::ArachSpeed = 50;
$HH::ArachAccel = 10;
$HH::ArachTurnDeg = 114.59;     // 2 rad/s
$HH::ArachDive = 10;
$HH::ArachTick = 0.1;

function HHMine::seek(%this)
{
   if (%this == "" || !isObject(%this))
      return;
   %dt = $HH::ArachTick;
   %v = Item::getVelocity(%this);
   %vz = getWord(%v, 2);
   // it crawls only once it has landed (it flies ballistic, then sits on the ground)
   if (%this.hhLanded != 1) {
      if (%vz > -1.5 && %vz < 1.5 && getSimTime() - %this.hhLaunchAt > 0.3)
         %this.hhLanded = 1;
      else {
         schedule("HHMine::seek(" @ %this @ ");", %dt, %this);
         return;
      }
   }
   %this.hhSpd = %this.hhSpd + $HH::ArachAccel * %dt;
   if (%this.hhSpd > $HH::ArachSpeed)
      %this.hhSpd = $HH::ArachSpeed;
   %hx = %this.hhHx;
   %hy = %this.hhHy;
   %t = %this.hhTarget;
   if (%t != "" && %t != -1 && (!isObject(%t) || Player::isDead(%t)))
      %t = -1;
   if (%t != "" && %t != -1) {
      %p = GameBase::getPosition(%this);
      %tp = GameBase::getPosition(%t);
      %dx = getWord(%tp, 0) - getWord(%p, 0);
      %dy = getWord(%tp, 1) - getWord(%p, 1);
      %dz = getWord(%tp, 2) + 2 - getWord(%p, 2);
      %d3 = Vector::getDistance(%dx @ " " @ %dy @ " " @ %dz, "0 0 0");
      %h = Vector::getDistance(%dx @ " " @ %dy @ " 0", "0 0 0");
      if (%h > 0.01) {
         %ux = %dx / %h;
         %uy = %dy / %h;
         // Explode on Miss: the target is behind it
         if (%hx * %ux + %hy * %uy < 0) {
            GameBase::setDamageLevel(%this, GameBase::getDataName(%this).maxDamage);
            return;
         }
         if (%d3 <= $HH::ArachDive) {
            // inside the cruise envelope: straight at it
            %s = %this.hhSpd / %d3;
            Item::setVelocity(%this, %dx * %s @ " " @ %dy * %s @ " " @ %dz * %s);
            schedule("HHMine::seek(" @ %this @ ");", %dt, %this);
            return;
         }
         // turn toward it, at most 2 rad/s
         %maxA = $HH::ArachTurnDeg * %dt;
         %c = mCos(%maxA);
         if (%hx * %ux + %hy * %uy >= %c) {
            %hx = %ux;
            %hy = %uy;
         }
         else {
            %s = mSin(%maxA);
            if (%hx * %uy - %hy * %ux >= 0) {
               %nx = %hx * %c - %hy * %s;
               %ny = %hx * %s + %hy * %c;
            }
            else {
               %nx = %hx * %c + %hy * %s;
               %ny = %hy * %c - %hx * %s;
            }
            %hx = %nx;
            %hy = %ny;
         }
         %this.hhHx = %hx;
         %this.hhHy = %hy;
      }
   }
   Item::setVelocity(%this, %hx * %this.hhSpd @ " " @ %hy * %this.hhSpd @ " " @ %vz);
   schedule("HHMine::seek(" @ %this @ ");", %dt, %this);
}

function HHMine::touch(%this, %object)
{
   if (!GameBase::isActive(%this))
      return;
   %type = getObjectType(%object);
   if (%type == "Player" || %type == "Moveable" || GameBase::getDataName(%object) == Vehicle)
      GameBase::setDamageLevel(%this, GameBase::getDataName(%this).maxDamage);
}

function HHMine::hurt(%this, %value)
{
   %this.damage = %this.damage + %value;
   if (%this.damage >= GameBase::getDataName(%this).maxDamage)
      GameBase::setDamageLevel(%this, GameBase::getDataName(%this).maxDamage);
}

// Starsiege mines self-destruct at the end of their duration
function HHMine::expire(%this)
{
   if (%this == "" || %this <= 0)
      return;
   GameBase::setDamageLevel(%this, GameBase::getDataName(%this).maxDamage);
}

// Stage 2 roster: varied chassis, round-robin (garage picks come later).
$MechMayhem::ChassisCount = 6;
$MechMayhem::Chassis[0] = "HercKntalon";   // light
$MechMayhem::Chassis[1] = "HercCyseek";    // light
$MechMayhem::Chassis[2] = "HercKnmino";    // medium
$MechMayhem::Chassis[3] = "HercTrbasl";    // medium
$MechMayhem::Chassis[4] = "HercKnapoc";    // heavy
$MechMayhem::Chassis[5] = "HercKngorg";    // assault

// Rotation for pilots with NO garage pick: FREE-tech roster chassis only
// (tech <= $MM::FreeTech, never bosses). The old hand-typed 6-list handed
// out T5/T6 hulls the garage charges salvage for -- free rides by dying.
function MechMayhem::pickChassis()
{
   %n = $MM::RosterCount;
   if (%n == "" || %n <= 0)
      return "HercTrtalon";
   for (%t = 0; %t < %n; %t++) {
      %idx = $MechMayhem::NextChassis;
      if (%idx == "" || %idx < 0 || %idx >= %n)
         %idx = 0;
      $MechMayhem::NextChassis = %idx + 1;
      %db = $MM::Roster[%idx];
      if ($MM::Tech[%db] <= $MM::FreeTech && $MM::Class[%db] != "boss")
         return %db;
   }
   return "HercTrtalon";
}

// grant the default loadout for a chassis' hardpoint rack.
// The per-chassis tables ($MM::Loadout[chassis, i]) are GENERATED by
// tools/hh_gen.py. Herc Havoc has ONE rack per chassis: Starsiege's own defaultWeapons(...)
// (Prometheus: the guide's 2 Quantum / 2 MFAC / 2 Heavy Blast Cannon).
function MechMayhem::selectRack(%chassis)
{
   if ($MM::RackBuilt[%chassis] == 1)
      return;
   %n = $MM::LoadoutCount[%chassis];
   if (%n == "")
      %n = 0;
   for (%i = 0; %i < %n; %i++)
      $MM::Rack[%chassis, %i] = $MM::Loadout[%chassis, %i];
   $MM::RackCount[%chassis] = %n;
   $MM::RackBuilt[%chassis] = 1;
   echo("[HERC] rack: " @ %chassis @ " -> " @ %n @ " weapons");
}

//--- turn-rate cap channel ---------------------------------------------------
// maxTurnRate/maxTurnRateFast are UNPACKED datablock fields (v16 wire
// compatibility), so a client never receives them with the ghost. It predicts its
// own view, though, so it MUST clamp with the same numbers or the server's
// absolute rot.z correction fights the player's mouse every tick.
// Player::integrateMoveRotation reads $MMC::turnSlow / $MMC::turnFast on the
// client; this is what puts them there, straight off the same datablock the
// server clamps with.
//
// Pass "" as the chassis to CLEAR the cap -- an ejected pilot is on foot and must
// turn like a trooper again.
function MechMayhem::pushTurnCap(%cl, %chassis)
{
   if (%cl <= 0)
      return;
   %slow = 0;
   %fast = 0;
   if (%chassis != "") {
      %slow = %chassis.maxTurnRate;
      %fast = %chassis.maxTurnRateFast;
      if (%slow == "") %slow = 0;
      if (%fast == "") %fast = 0;
   }
   remoteEval(%cl, "MMTurn", %slow, %fast);
}

//--- the chain rack -----------------------------------------------------------
// Slot 0 holds the LEAD gun (the one next/prev selects); every other gun in the
// pilot's rack rides in slots 3..7 as its $HH::Twin item. The engine relay
// (chainNextSlot) never fires an extra slot whose item type equals slot 0's, so
// mounting the real item there silently dropped the second of a twin pair
// (a Talon fired one Compression Laser) -- the twin item is the same image under
// another type. Each gun sits on its own hardpoint slot (2 + rack index); the
// lead's hardpoint slot takes hardpoint 0's gun, since slot 0 is hardpoint 0.
// Re-run on every lead change, so cycling keeps the whole rack firing.
function HHRack::mountExtras(%pl, %lead)
{
   if (%pl.hhRackN == "" || %pl.hhRackN <= 0)
      return;
   %leadHp = -1;
   for (%k = 0; %k < %pl.hhRackN; %k++)
      if (%leadHp == -1 && %pl.hhRack[%k] == %lead)
         %leadHp = %pl.hhRackHp[%k];
   for (%s = 3; %s <= 7; %s++)
      %want[%s] = "";
   %skipped = 0;
   for (%k = 0; %k < %pl.hhRackN; %k++) {
      %w = %pl.hhRack[%k];
      %hp = %pl.hhRackHp[%k];
      if (!%skipped && %hp == %leadHp) {
         %skipped = 1;           // this gun IS the lead in slot 0
         continue;
      }
      %s = 2 + %hp;
      if (%hp == 0)
         %s = 2 + %leadHp;       // hardpoint 0's gun moves to the lead's hardpoint
      if (%s >= 3 && %s <= 7) {
         %t = $HH::Twin[%w];
         if (%t == "")
            %t = %w;
         %want[%s] = %t;
      }
   }
   // which hardpoint each chain slot now holds (weapon groups key on hardpoints)
   %pl.hhSlotHp[0] = %leadHp;
   for (%s = 3; %s <= 7; %s++)
      %pl.hhSlotHp[%s] = -1;
   for (%k = 0; %k < %pl.hhRackN; %k++) {
      %hp = %pl.hhRackHp[%k];
      if (%hp == %leadHp)
         continue;
      if (%hp == 0) %pl.hhSlotHp[2 + %leadHp] = 0;
      else %pl.hhSlotHp[2 + %hp] = %hp;
   }
   // touch only slots that change: a remount restarts that gun's cadence
   // (getMountedItem returns the item NAME, or -1 for an empty slot)
   for (%s = 3; %s <= 7; %s++) {
      %cur = Player::getMountedItem(%pl, %s);
      if (%want[%s] == "") {
         if (%cur != -1)
            Player::unmountItem(%pl, %s);
      }
      else if (%cur != %want[%s])
         Player::mountItem(%pl, %want[%s], %s);
   }
   HHRack::groupSync(%pl);
}

//--- weapon groups (Starsiege groups 1-3, FUN_00496c00 / FUN_00471518) --------
// Per pilot, per HARDPOINT: %cl.hhGrpOut[g, hp] = 1 takes that gun out of group g
// (default: every gun in every group, as Starsiege without prefs); %cl.hhGrpMode[g]
// 0 chain / 1 linked; %cl.hhGrpSel the group the trigger fires (0-2).
function HHRack::inGroup(%cl, %g, %hp)
{
   if (%cl <= 0)
      return 1;
   return %cl.hhGrpOut[%g, %hp] != 1;
}

// push the selected group to the engine: member slots + chain/linked
function HHRack::groupSync(%pl)
{
   %cl = Player::getClient(%pl);
   %g = 0;
   if (%cl > 0 && %cl.hhGrpSel != "")
      %g = %cl.hhGrpSel;
   %mask = 0;
   %bit = 1;
   for (%s = 0; %s <= 7; %s++) {
      if (%s == 0 || %s >= 3) {
         %hp = %pl.hhSlotHp[%s];
         if (%hp != "" && %hp >= 0 && HHRack::inGroup(%cl, %g, %hp))
            %mask = %mask + %bit;
      }
      %bit = %bit * 2;
   }
   Player::setChainGroup(%pl, %mask);
   %mode = 0;
   if (%cl > 0 && %cl.hhGrpMode[%g] == 1)
      %mode = 1;
   Player::setChainLinked(%pl, %mode);
   // the cockpit weapons panel (sscockpit remoteHHGroups): per rack row, the
   // groups that gun is in (bit0 = group 1). Human pilots only.
   if (%cl > 0 && MechEject::isHumanClient(%cl)) {
      for (%k = 0; %k < 6; %k++) {
         %gm[%k] = "";
         if (%k < %pl.hhRackN) {
            %hp = %pl.hhRackHp[%k];
            %gm[%k] = HHRack::inGroup(%cl, 0, %hp) + 2 * HHRack::inGroup(%cl, 1, %hp)
                      + 4 * HHRack::inGroup(%cl, 2, %hp);
         }
      }
      remoteEval(%cl, "HHGroups", %g, %mode, %gm[0], %gm[1], %gm[2], %gm[3], %gm[4], %gm[5]);
   }
}

function HHRack::groupMenu(%cl)
{
   %g = %cl.hhGrpSel;
   if (%g == "") %g = 0;
   %pl = Client::getOwnedObject(%cl);
   Client::buildMenu(%cl, "Weapon group " @ (%g + 1) @ " (trigger fires it)", "HHGroups", true);
   %key = 0;
   Client::addMenuItem(%cl, MechMayhem::menuKey(%key++) @ "Fire group: " @ (%g + 1) @ "  (next)", "sel");
   if (%cl.hhGrpMode[%g] == 1)
      Client::addMenuItem(%cl, MechMayhem::menuKey(%key++) @ "Mode: LINKED (all at once)", "mode");
   else
      Client::addMenuItem(%cl, MechMayhem::menuKey(%key++) @ "Mode: chain (one after another)", "mode");
   if (%pl != -1 && %pl.hhRackN > 0) {
      for (%k = 0; %k < %pl.hhRackN && %k < 6; %k++) {
         %hp = %pl.hhRackHp[%k];
         %mark = "[ ] ";
         if (HHRack::inGroup(%cl, %g, %hp)) %mark = "[x] ";
         Client::addMenuItem(%cl, MechMayhem::menuKey(%key++) @ %mark @ $MM::WeapName[%pl.hhRack[%k]]
                             @ " (hardpoint " @ (%hp + 1) @ ")", "gun " @ %hp);
      }
   }
   Client::addMenuItem(%cl, "9Back", "back");
}

function processMenuHHGroups(%cl, %option)
{
   %opt = getWord(%option, 0);
   if (%opt == "back") {
      Game::menuRequest(%cl);
      return;
   }
   %g = %cl.hhGrpSel;
   if (%g == "") %g = 0;
   if (%opt == "sel") {
      %g = %g + 1;
      if (%g > 2) %g = 0;
      %cl.hhGrpSel = %g;
   }
   else if (%opt == "mode") {
      if (%cl.hhGrpMode[%g] == 1) %cl.hhGrpMode[%g] = 0;
      else %cl.hhGrpMode[%g] = 1;
   }
   else if (%opt == "gun") {
      %hp = getWord(%option, 1);
      if (%cl.hhGrpOut[%g, %hp] == 1) %cl.hhGrpOut[%g, %hp] = 0;
      else %cl.hhGrpOut[%g, %hp] = 1;
   }
   %pl = Client::getOwnedObject(%cl);
   if (%pl != -1 && %pl.hhRackN > 0)
      HHRack::groupSync(%pl);
   HHRack::groupMenu(%cl);
}

// a rack gun became the lead (spawn, next/prev, a bot's weapon pick)
function Weapon::onMount(%player, %item)
{
   if ($HH::Twin[%item] != "" && %player.hhRackN > 0)
      HHRack::mountExtras(%player, %item);
}

// the gun on hardpoint %hp is gone -- its body part was destroyed (Starsiege:
// hardpoint weapons are children of their Dmg Prnt part, MechDamage.cs
// HHParts::destroy). The item leaves the inventory only when no copy is left;
// losing the lead hands the lead to the next gun.
function HHRack::loseHp(%pl, %hp)
{
   if (%pl.hhRackN == "" || %pl.hhRackN <= 0)
      return false;
   %lead = Player::getMountedItem(%pl, $WeaponSlot);
   %gone = "";
   %n = 0;
   for (%k = 0; %k < %pl.hhRackN; %k++) {
      if (%gone == "" && %pl.hhRackHp[%k] == %hp) {
         %gone = %pl.hhRack[%k];
         continue;
      }
      %pl.hhRack[%n] = %pl.hhRack[%k];
      %pl.hhRackHp[%n] = %pl.hhRackHp[%k];
      %n++;
   }
   if (%gone == "")
      return false;             // a mine pack already took this hardpoint
   %pl.hhRackN = %n;
   %pl.hhGunsLost++;
   %left = 0;
   for (%k = 0; %k < %n; %k++)
      if (%pl.hhRack[%k] == %gone)
         %left++;
   %cl = Player::getClient(%pl);
   if (%cl > 0)
      Client::sendMessage(%cl, 1, "WEAPON DESTROYED -- " @ $MM::WeapName[%gone]);
   HHVoice::say(%pl, "weap_dest");
   echo("[HHPART] " @ %pl @ " lost " @ %gone @ " (hardpoint " @ %hp @ ")");
   if (%left == 0) {
      if (%gone == %lead)
         Player::trigger(%pl, $WeaponSlot, false);
      Player::setItemCount(%pl, %gone, 0);
   }
   if (%n == 0) {
      for (%s = 3; %s <= 7; %s++)
         if (Player::getMountedItem(%pl, %s) != -1)
            Player::unmountItem(%pl, %s);
      return true;
   }
   if (%left == 0 && %gone == %lead) {
      %lead = %pl.hhRack[0];
      Player::useItem(%pl, %lead);
   }
   HHRack::mountExtras(%pl, %lead);
   return true;
}

function MechMayhem::grantLoadout(%pl, %clientId, %chassis)
{
   MechMayhem::selectRack(%chassis);
   %n = $MM::RackCount[%chassis];
   if (%n == "")
      %n = 0;
   // MINES cost a gun (Starsiege mines sat on a hardpoint): a pilot who picked a
   // mine pack loses the rack's last gun that is not a twin of the lead. That
   // gun's hardpoint size sizes the pack.
   %drop = HHComp::mineDrop(Player::getClient(%pl), %chassis, %n);
   %pl.hhMineSize = "";
   if (%drop >= 0)
      %pl.hhMineSize = $HH::WeapSize[$MM::Rack[%chassis, %drop]];

   // this pilot's rack: gun + the hardpoint it sits on (rack index = Starsiege
   // hardpoint = image slot 2 + index, slot 0 for hardpoint 0). A mine pack's gun
   // or a crit-destroyed gun leaves it. HHRack::mountExtras reads it.
   %pl.hhRackN = 0;
   %first = "";
   for (%i = 0; %i < %n; %i++) {
      %w = $MM::Rack[%chassis, %i];
      if (%w != "" && %i != %drop) {
         %pl.hhRack[%pl.hhRackN] = %w;
         %pl.hhRackHp[%pl.hhRackN] = %i;
         %pl.hhRackN++;
         Player::setItemCount(%clientId, %w, 1);
         if (%first == "") %first = %w;
      }
   }
   if (%first == "") {
      Player::setItemCount(%clientId, MechLaser, 1);
      %first = MechLaser;
      %pl.hhRack[0] = MechLaser;
      %pl.hhRackHp[0] = 0;
      %pl.hhRackN = 1;
   }
   Player::setItemCount(%clientId, RepairKit, 1);
   Player::useItem(%pl, %first);

   // REACTOR: the default reactor's output per second refills the battery
   // (maxEnergy). setRechargeRate is per-object and packed, so it is set here
   // at spawn rather than on the datablock. Start full.
   %rate = $HH::Reactor[%chassis];
   if (%rate == "")
      %rate = 60;
   GameBase::setRechargeRate(%pl, %rate);
   GameBase::setEnergy(%pl, %chassis.maxEnergy);

   // SPECIAL COMPONENTS (Starsiege default specials, or the pilot's picks) and
   // MINES (mine key; MineAmmo::onUse throws %pl.hhMine). HHComponents.cs.
   %realCl0 = Player::getClient(%pl);
   HHComp::apply(%pl, %realCl0, %chassis);
   HHComp::grantMines(%pl, %realCl0, %chassis);

   // CHAINED FIRE: the rest of the rack goes into image slots 3..7 (1 = backpack,
   // 2 = flag stay stock) -- Weapon::onMount already did it when useItem mounted
   // the lead; repeat in case the lead was already mounted (no callback then).
   HHRack::mountExtras(%pl, %first);    // also pushes the pilot's weapon group

   // cockpit rack panel: push pretty names once per grant (real clients only --
   // the conscription sweep passes the player OBJECT for bots)
   %realCl = Player::getClient(%pl);
   if (%realCl > 0) {
      MechMayhem::pushTurnCap(%realCl, %chassis);
      // the panel lists the guns actually carried (a mine pack's gun is gone)
      %k = 0;
      for (%i = 0; %i < 6; %i++)
         %nm[%i] = "";
      for (%i = 0; %i < %n && %k < 6; %i++) {
         if (%i != %drop) {
            %nm[%k] = $MM::WeapName[$MM::Rack[%chassis, %i]];
            %k++;
         }
      }
      remoteEval(%realCl, "MMRack", %k, %nm[0], %nm[1], %nm[2], %nm[3], %nm[4], %nm[5]);
   }
}

function Game::playerSpawned(%pl, %clientId, %armor)
{
   Client::setSkin(%clientId, $Client::info[%clientId, 0]);
   %clientId.mmOnFoot = "";   // a fresh mech ends any Last Stand on-foot life

   // a pilot's MMPick beats the round-robin; validity re-checked each spawn
   %chassis = %clientId.mmChassis;
   if (%chassis == "" || !MechProgress::canUse(%clientId, %chassis))
      %chassis = MechMayhem::pickChassis();
   Player::setArmor(%pl, %chassis);
   echo("[MECH] spawn: client " @ %clientId @ " -> " @ %chassis);

   %pl.mmInit = 1;   // MechHeat's conscription sweep must not double-init us
   MechShield::init(%pl, %chassis);
   MechMayhem::grantLoadout(%pl, %clientId, %chassis);

   // NOT DMTEAM::checkMissionObjectives(): the stock DM-team writer scribbles
   // "Kill all players / Team Scores" over lines 2-8 of OUR objectives page on
   // every spawn (Joe's screenshot). Refresh the mech page instead.
   MechMayhem::objectives(0, "");
}

//--- CV tickets --------------------------------------------------------------
// Player::onKilled fires for EVERY player death, humans and AI alike (the
// stock body handles %cl == -1). Chain: run the stock corpse logic first via
// a saved copy? No super in TribesScript -- so we re-implement the ticket
// accounting HERE and leave Player::onKilled itself alone; the hook below is
// GameBase-level: MechTickets::onDeath is called from MechHeat's tick when it
// sees a dead mech it hasn't accounted. Deaths are counted exactly once via
// the mmCounted flag on the corpse object.

function MechTickets::charge(%obj)
{
   if (%obj.mmCounted == 1)
      return;
   %obj.mmCounted = 1;
   %data = GameBase::getDataName(%obj);
   %base = MechHeat::baseChassis(%data);
   %cv = $MM::CV[%base];
   if (%cv == "")
      %cv = 1000;
   %team = GameBase::getTeam(%obj);
   if (%team < 0 || %team == "")
      return;
   // salvage: pay the last attacker (recorded per hit in MechDamage::apply).
   // Victim humanity = does a real client own the corpse (bots resolve <= 0).
   %mmk = %obj.mmLastAttacker;
   %vh = 0;
   if (Player::getClient(%obj) > 0)
      %vh = 1;
   if (%mmk != "" && %mmk > 0 && %mmk != Player::getClient(%obj))
      MechProgress::creditKill(%mmk, %base, %vh);
   if ($MM::Mode == "incursion") {
      // no ticket pools in PvE: Cybrid kills bank salvage (progression,
      // Stage 6); the wave director owns win/loss
      if (%team == 1) {
         $MMW::salvage = $MMW::salvage + %cv;
         echo("[MECHWAVE] salvage +" @ %cv @ " -> " @ $MMW::salvage);
      }
      return;
   }
   if ($MM::Mode == "ctf")
      return;      // flags keep score; salvage was credited above
   if ($MM::Mode == "dm") {
      MechDM::score(%obj, %base, %mmk);
      return;
   }
   // the match is decided: deaths in the 12 s before the next map (or after, on a
   // host that does not cycle) no longer drain -- the pool ran to -28629 on 09-22
   if ($MM::MatchOver == 1)
      return;
   $MM::Tickets[%team] = $MM::Tickets[%team] - %cv;
   $teamScore[%team] = $MM::Tickets[%team];
   // a corpse has already lost its owner client, so the pilot's name is the one
   // MechTickets::visit recorded while the mech was alive
   %who = %obj.mmPilot;
   if (%who == "")
      %who = Client::getName(Player::getClient(%obj));
   if (%who == "")
      %who = "A";
   else
      %who = %who @ "'s";
   messageAll(0, %who @ " " @ %base
              @ " destroyed: team " @ getTeamName(%team) @ " loses " @ %cv
              @ " CV (" @ $MM::Tickets[%team] @ " left)");
   echo("[MECHCV] team " @ %team @ " -" @ %cv @ " -> " @ $MM::Tickets[%team]);
   if ($MM::Tickets[%team] <= 0)
      MechTickets::endMatch(%team);
}

// DEATHMATCH scoring: the kill goes to the last attacker (bots included -- their
// reps carry a client id and a name). A suicide or an unowned death scores nothing.
// The tally lives in $HHDM::Kills[pilot name] so bots, which never pass through
// Game::onPlayerConnected, score the same way humans do.
function MechDM::score(%obj, %base, %killer)
{
   if ($MM::MatchOver == 1)
      return;
   %victim = %obj.mmPilot;
   if (%victim == "")
      %victim = "a pilot";
   if (%killer == "" || %killer <= 0 || Client::getName(%killer) == %obj.mmPilot) {
      messageAll(0, %victim @ "'s " @ %base @ " destroyed.");
      return;
   }
   // keyed by NAME: a bot gets a new client id every respawn, and an id-keyed
   // tally restarted from 1 each life
   %name = Client::getName(%killer);
   %k = $HHDM::Kills[%name] + 1;
   $HHDM::Kills[%name] = %k;
   if (%k > $HHDM::lead) {
      $HHDM::lead = %k;
      $HHDM::leadName = %name;
      $teamScore[0] = %k;
   }
   messageAll(0, %name @ " destroyed " @ %victim @ "'s " @ %base
              @ " (" @ %k @ " of " @ $MM::DMKillLimit @ ")");
   echo("[HERCDM] " @ %name @ " " @ %k);
   if (%k >= $MM::DMKillLimit)
      MechDM::endMatch(%killer);
}

function MechDM::endMatch(%winner)
{
   if ($MM::MatchOver == 1)
      return;
   $MM::MatchOver = 1;
   %name = Client::getName(%winner);
   messageAll(0, %name @ " WINS THE DEATHMATCH.");
   $timeLimitReached = true;
   $timeReached = 1;
   schedule("Server::nextMission();", 12);   // before the cosmetics, as endMatch below
   for (%vc = Client::getFirst(); %vc != -1; %vc = Client::getNext(%vc)) {
      %vcy = HHVoice::isCybrid(MechHeat::baseChassis(GameBase::getDataName(Client::getOwnedObject(%vc))));
      if (%vc == %winner)
         HHVoice::sayClient(%vc, "mission_comp", %vcy);
      else
         HHVoice::sayClient(%vc, "mission_fail", %vcy);
   }
   MechMayhem::objectives(1, %name @ " wins with " @ $HHDM::Kills[%name] @ " kills.");
}

// cockpit state channel: once a second per HUMAN-piloted mech, feed the
// mechcockpit ModernHUD pack (remoteMMState in its hud.cs). Bots skip it.
function MechHUD::push(%obj, %data)
{
   %cl = Player::getClient(%obj);
   if (%cl <= 0)
      return;
   %base = MechHeat::baseChassis(%data);
   %max = %base.maxEnergy;
   %heat = 0;
   if (%max > 0)
      %heat = 1 - (GameBase::getEnergy(%obj) / %max);
   // lamps from the Starsiege part model (MechDamage.cs HHParts::update):
   // leg servos, lost guns, sensors, reactor -- 0 ok, 1 damaged, 2 critical
   %legs = %obj.hhLampLegs + 0;
   %guns = %obj.hhLampGuns + 0;
   %sens = %obj.hhLampSens + 0;
   %rctr = %obj.hhLampRctr + 0;
   %wave = "";
   %salv = "";
   if ($MM::Mode == "incursion") {
      %wave = $MMW::wave;
      %salv = $MMW::salvage;
   }
   remoteEval(%cl, "MMState", %heat, %obj.mmShield, %obj.mmShieldMax,
              %legs, %guns, %sens, %rctr, %base, $MM::CV[%base],
              $MM::Tickets[0], $MM::Tickets[1], %obj.mmShutdown,
              %cl.scoreKills, %cl.scoreDeaths, %wave, %salv);
   HHHUD::push(%obj, %cl, %base);
}

// Herc Havoc cockpit channel (mechcockpit pack, remoteHHState). Its presence is
// what switches the pack into Herc Havoc mode: REACTOR instead of HEAT, the
// special components, mines and the pack key, CTF flag score. Mech Mayhem never
// sends it, so that mod's cockpit is unchanged.
//   energy     battery fraction 0..1 (the reactor, not heat)
//   rsv        reservoir fraction 0..1 (Extra Battery + Reactor Capacitor), "" = none
//   c0..c3     component lines, e.g. "Chameleon Cloak  ON"
//   pack       what the pack key does ("" = nothing fitted to toggle)
//   mine       mine name, mines left
//   mode       $MM::Mode ("ctf" -> flag score instead of CV pools)
//   f0 f1      CTF captures per team
function HHHUD::push(%obj, %cl, %base)
{
   %max = %base.maxEnergy;
   %en = 0;
   if (%max > 0)
      %en = GameBase::getEnergy(%obj) / %max;
   %rsv = "";
   %rcap = %obj.hhBattCap + %obj.hhCapCap;
   if (%rcap > 0)
      %rsv = (%obj.hhBatt + %obj.hhCap) / %rcap;
   // component lines (4 max; a HERC has at most 2 special mounts today).
   // Plain %c0..%c3 -- local arrays are unreliable in this dialect.
   %c0 = ""; %c1 = ""; %c2 = ""; %c3 = "";
   %n = $HH::CompSlots[%base];
   if (%n == "") %n = 0;
   %k = 0;
   %cl0 = Player::getClient(%obj);
   for (%i = 0; %i < %n && %k < 4; %i++) {
      %id = HHComp::resolve(%cl0, %base, %i);
      if (%id == "")
         continue;
      %line = $HH::CompName[%id];
      %kind = $HH::CompKind[%id];
      if (%kind == "cloak") {
         if (%obj.hhCloaked == 1) %line = %line @ "  ON";
         else %line = %line @ "  off";
      }
      else if (%kind == "booster") {
         %f = 0;
         if (%obj.hhFuelCap > 0) %f = floor(100 * %obj.hhFuel / %obj.hhFuelCap);
         %line = %line @ "  " @ %f @ "%";
         if (%obj.hhBoosting == 1) %line = %line @ " BURN";
      }
      else if (%kind == "none")
         %line = %line @ "  (inert)";
      if (%k == 0) %c0 = %line;
      else if (%k == 1) %c1 = %line;
      else if (%k == 2) %c2 = %line;
      else %c3 = %line;
      %k++;
   }
   %pack = "";
   if (%obj.hhCloakId != "")
      %pack = "cloak";
   else if (%obj.hhBoostId != "")
      %pack = "boost";
   %mine = "";
   %mdb = %obj.hhMine;
   if (%mdb != "")
      %mine = %mdb.description;
   %mines = Player::getItemCount(%cl, MineAmmo);   // client id: inventory queries on the object lie
   // deathmatch: the two score slots carry the leader's kills and this pilot's own
   %s0 = $teamScore[0];
   %s1 = $teamScore[1];
   if ($MM::Mode == "dm") {
      %s0 = $HHDM::lead;
      %s1 = $HHDM::Kills[Client::getName(%cl)];
   }
   remoteEval(%cl, "HHState", %en, %rsv, %c0, %c1, %c2, %c3, %pack,
              %mine, %mines, $MM::Mode, %s0, %s1);
}

function MechTickets::visit(%obj)
{
   %data = GameBase::getDataName(%obj);
   if (String::getSubStr(%data, 0, 4) != "Herc")
      return;
   if (Player::isDead(%obj))
      MechTickets::charge(%obj);
   else {
      MechHUD::push(%obj, %data);
      // shield broadcast pairs: "<clientId> <frac>" per LIVING mech, bots
      // included (Player::getClient is getOwnerClient, and bot reps have one).
      // Consumed by remoteMMShields in the mechcockpit pack, which feeds the
      // engine nameplate shield bars and the ShieldFx bubbles.
      %scl = Player::getClient(%obj);
      if (%scl > 0)
         %obj.mmPilot = Client::getName(%scl);
      if (%scl > 0 && %obj.mmShieldMax > 0) {
         %sfrac = %obj.mmShield / %obj.mmShieldMax;
         if (%sfrac < 0)
            %sfrac = 0;
         $MMS::pairs = $MMS::pairs @ " " @ %scl @ " " @ %sfrac;
      }
   }
}

function MechTickets::tick()
{
   $MMS::pairs = "";
   Group::iterateRecursive(MissionCleanup, "MechTickets::visit");
   for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "MMShields", $MMS::pairs);
   schedule("MechTickets::tick();", 1);
}

function MechTickets::endMatch(%loser)
{
   if ($MM::MatchOver == 1)
      return;
   $MM::MatchOver = 1;
   messageAll(0, "TEAM " @ getTeamName(%loser) @ " HAS BEEN ANNIHILATED.");
   $timeLimitReached = true;
   $timeReached = 1;
   // ★schedule the cycle BEFORE the cosmetics★ -- a runtime abort in the
   // summary writer must never strand the mission (measured: pools ran to
   // -5080 with no cycle when the summary call preceded the schedule)
   schedule("Server::nextMission();", 12);
   %winner = 1 - %loser;
   // Starsiege mission call-out, in each pilot's own faction voice
   for (%vc = Client::getFirst(); %vc != -1; %vc = Client::getNext(%vc)) {
      %vcy = HHVoice::isCybrid(MechHeat::baseChassis(GameBase::getDataName(Client::getOwnedObject(%vc))));
      if (Client::getTeam(%vc) == %loser)
         HHVoice::sayClient(%vc, "mission_fail", %vcy);
      else
         HHVoice::sayClient(%vc, "mission_comp", %vcy);
   }
   MechMayhem::objectives(1, "Team " @ getTeamName(%winner)
      @ " wins -- " @ getTeamName(%loser) @ "'s Combat Value pool is exhausted.");
}

// stock game.cs:735 body + pilot record load
function Game::onPlayerConnected(%playerId)
{
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
   %playerId.score = 0;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
   MechProgress::load(%playerId);
}

// stock is an empty stub; save the pilot on the way out
function Client::leaveGame(%clientId)
{
   MechProgress::save(%clientId);
   // CTF (objectives.cs): a leaving flag carrier drops the flag
   %set = nameToID("MissionCleanup/ObjectivesSet");
   if (%set != -1)
      for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
         GameBase::virtual(%obj, "clientDropped", %clientId);
}

// dm.cs's version decrements $teamScore per kill, which fights the CV ticket
// pools; ours banks salvage for the killer instead. Non-team scoring (kills/
// deaths/obits) already happened in Client::onKilled before this dispatch.
function Game::clientKilled(%playerId, %killerId)
{
   // salvage credit moved to MechTickets::charge (corpse-side): it has the
   // victim OBJECT (real chassis CV) and works when the victim is a bot --
   // Client::getOwnedObject on a bot rep resolves nothing, which is why every
   // kill used to pay the flat 500 fallback and bot kills mispaid.
   MechEject::bounty(%playerId, %killerId);
   if (%playerId != -1 && %playerId.mmKey != "")
      $MMP::deaths[%playerId.mmKey] = $MMP::deaths[%playerId.mmKey] + 1;
   // CTF (objectives.cs body): a killed carrier drops the flag, carrier-kill scoring
   %set = nameToID("MissionCleanup/ObjectivesSet");
   if (%set != -1)
      for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
         GameBase::virtual(%obj, "clientKilled", %playerId, %killerId);
}

// Replaces the game.cs body (no super in TribesScript) -- the stock lines
// are replicated verbatim first, then the Mech Mayhem additions.
function Game::startMatch()
{
   // --- stock game.cs:373 body ---
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
   Game::resetScores();

   %numTeams = getNumTeams();
   for (%i = 0; %i < %numTeams; %i = %i + 1) {
      if ($TeamEnergy[%i] != "Infinite")
         schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
   }

   for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if (%cl.observerMode == "pregame")
      {
         %cl.observerMode = "";
         Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      }
      Game::refreshClientScore(%cl);
   }
   Game::checkTimeLimit();

   // --- Mech Mayhem ---
   $MM::MatchOver = 0;
   schedule("MechHeat::tick();", 2);
   schedule("MechTickets::tick();", 2);
   schedule("MechMayhem::objTick();", 3);      // objectives page (O key), 30 s cadence
   schedule("MechProgress::saveAll();", $MM::AutosaveSecs);
   if ($MM::Mode == "incursion") {
      MechWaves::start();
      echo("[MECH] INCURSION started.");
   }
   else if ($MM::Mode == "ctf") {
      // flags score (objectives.cs); $teamScore stays the flag count
      echo("[HERC] CTF started: " @ %numTeams @ " teams, " @ $teamScoreLimit @ " captures to win.");
   }
   else if (%numTeams == 1 && $MM::Mode != "groundwar") {
      // DEATHMATCH: a one-team mission is every pilot for themselves. No shared
      // CV pool -- each kill scores for the pilot who made it (MechTickets::charge),
      // first to $MM::DMKillLimit wins.
      $MM::Mode = "dm";
      if ($MM::DMKillLimit == "")
         $MM::DMKillLimit = 20;
      deleteVariables("HHDM::*");
      $HHDM::lead = 0;
      $teamScore[0] = 0;
      echo("[HERC] DEATHMATCH started: first to " @ $MM::DMKillLimit @ " kills.");
   }
   else {
      for (%i = 0; %i < %numTeams; %i++) {
         $MM::Tickets[%i] = $MM::TicketPool;
         $teamScore[%i] = $MM::TicketPool;
      }
      if ($MM::Mode == "groundwar") {
         MechZones::start();
         echo("[MECH] GROUNDWAR started: " @ $MM::ZoneCount @ " zones, " @ $MM::TicketPool @ " CV each.");
      }
      else
         echo("[MECH] ESCALATION started: " @ %numTeams @ " team(s), " @ $MM::TicketPool @ " CV each.");
   }
}

// INCURSION: every human defends -- no auto-balance onto the Cybrid team.
// Non-incursion path is the stock game.cs:745 body, verbatim.
function Game::assignClientTeam(%playerId)
{
   if ($MM::Mode == "incursion") {
      GameBase::setTeam(%playerId, 0);
      echo(Client::getName(%playerId), " assigned to the defense (incursion)");
      return;
   }
   if($teamplay)
   {
      %name = Client::getName(%playerId);
      %numTeams = getNumTeams();
      if($teamPreset[%name] != "")
      {
         if($teamPreset[%name] < %numTeams)
         {
            GameBase::setTeam(%playerId, $teamPreset[%name]);
            echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
            return;
         }
      }
      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i = %i + 1)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i = %i + 1)
      {
         %pl = getClientByIndex(%i);
         if(%pl != %playerId)
         {
            %team = Client::getTeam(%pl);
            %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         }
      }
      %leastPlayers = %numTeamPlayers[0];
      %leastTeam = 0;
      for(%i = 1; %i < %numTeams; %i = %i + 1)
      {
         if( (%numTeamPlayers[%i] < %leastPlayers) ||
            ( (%numTeamPlayers[%i] == %leastPlayers) &&
            ($teamScore[%i] < $teamScore[%leastTeam] ) ))
         {
            %leastTeam = %i;
            %leastPlayers = %numTeamPlayers;
         }
      }
      GameBase::setTeam(%playerId, %leastTeam);
      echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
   }
   else
   {
      GameBase::setTeam(%playerId, 0);
   }
}


//=============================================================================
// TAB MENU (Mech Mayhem) -- Game::menuRequest is a COPY of base\scripts\
// admin.cs:473 with the two mech entries inserted; last-wins exec makes it
// live. processMenuOptions pre-dispatches mech codes then calls
// ProcessMenuOptionsStock, a verbatim copy of admin.cs:635 appended below.
// If admin.cs's menu changes, reconcile here. Mech submenus use their OWN
// menu modes (MMGarage/MMVote) so their dispatch cannot collide with stock.
//=============================================================================
// A menu row's hotkey is its FIRST CHARACTER, so "10Reset..." is key '1' again and
// the engine refuses it ("Error adding menu to CurServerMenu") -- an admin's Options
// list runs past 9 rows here. Rows go 1-9, then 0, then letters.
function MechMayhem::menuKey(%n)
{
   if(%n < 10)
      return %n;
   if(%n == 10)
      return 0;
   return String::getSubStr("abcdefghijklmnop", %n - 11, 1);
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);

   // --- Mech Mayhem entries ---
   Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "HERC Garage - pick your chassis", "mmgarage");
   Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Special components", "hhsys");
   Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Mine pack", "hhmines");
   Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Weapon groups (fire chains)", "hhgroups");
   if($curVoteTopic == "")
      Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote next battle mode", "mmvote");

   if(!$matchStarted || !$Server::TourneyMode)
      Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Change Teams/Observe", "changeteams");
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Kick " @ %name, "kick " @ %sel);
         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Ban " @ %name, "ban " @ %sel);
            Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Admin " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Observe " @ %name, "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote to enable team damage", "vetd");
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Vote to enter Tournament mode", "vctourney");
   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Change mission", "cmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Enable team damage", "etd");
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Change to FFA mode", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Start the match", "smatch");
      }
      else
         Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Change to Tournament mode", "ctourney");
      Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, MechMayhem::menuKey(%curItem++) @ "Reset Server Defaults", "reset");
   }
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   if(%opt == "mmgarage")
   {
      MechMayhem::garageMenu(%clientId);
      return;
   }
   if(%opt == "mmvote")
   {
      MechMayhem::voteMenu(%clientId);
      return;
   }
   if(%opt == "hhsys")
   {
      HHComp::menu(%clientId);
      return;
   }
   if(%opt == "hhgroups")
   {
      // Starsiege weapon groups 1-3: members per gun, chain (one after another,
      // evenly spaced) or linked (all at once; lock-on weapons fire unguided
      // until locked) per group, and which group the trigger fires.
      HHRack::groupMenu(%clientId);
      return;
   }
   if(%opt == "hhmines")
   {
      HHComp::mineMenu(%clientId);
      return;
   }
   ProcessMenuOptionsStock(%clientId, %option);
}

//--- Mech Garage -------------------------------------------------------------
// Progression-aware: T1 chassis are free ($MM::FreeTech); the rest unlock
// with salvage (2 x CV, MechProgress). The list SHOWS lock state + price and
// buys in place -- the first cut hid all of that behind a bare "not cleared"
// bounce, which read as an error (Joe, live).
function MechMayhem::garageMenu(%clientId)
{
   %cur = %clientId.mmChassis;
   if(%cur == "")
      %cur = "auto rotation";
   %salv = 0;
   if(%clientId.mmKey != "")
      %salv = $MMP::salvage[%clientId.mmKey];
   if(%salv == "") %salv = 0;
   Client::buildMenu(%clientId, "Mech Garage  --  now: " @ %cur @ "   salvage: " @ %salv, "MMGarage", true);
   Client::addMenuItem(%clientId, "0Auto (rotation each spawn)", "auto");
   Client::addMenuItem(%clientId, "1Light chassis", "class light");
   Client::addMenuItem(%clientId, "2Medium chassis", "class medium");
   Client::addMenuItem(%clientId, "3Heavy chassis", "class heavy");
   Client::addMenuItem(%clientId, "4Assault chassis", "class assault");
   Client::addMenuItem(%clientId, "9Back", "back");
}

function MechMayhem::garageLabel(%clientId, %db)
{
   %lbl = %db @ "  T" @ $MM::Tech[%db] @ "  CV " @ $MM::CV[%db] @ "  [" @ $MM::Slots[%db] @ "]";
   if ($MM::EjectChassis[%db] == 1)
      %lbl = %lbl @ "  +EJECT";
   if(MechProgress::canUse(%clientId, %db))
      return %lbl;
   return "LOCKED  " @ %lbl @ "  -- buy for " @ ($MM::CV[%db] * $MM::UnlockCostMult) @ " salvage";
}

function processMenuMMGarage(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %arg = getWord(%option, 1);

   if(%opt == "back")
   {
      Game::menuRequest(%clientId);
      return;
   }
   if(%opt == "garage")
   {
      MechMayhem::garageMenu(%clientId);
      return;
   }
   if(%opt == "auto")
   {
      %clientId.mmChassis = "";
      if (%clientId.mmKey != "")
         $MMP::lastChassis[%clientId.mmKey] = "";
      Client::sendMessage(%clientId, 1, "GARAGE: auto rotation -- your next spawn picks from the roster.");
      bottomPrint(%clientId, "<jc><f1>Garage: auto rotation on next spawn", 4);
      return;
   }
   if(%opt == "class")
   {
      Client::buildMenu(%clientId, "Garage: " @ %arg @ " chassis (pick = next spawn; LOCKED = buy)", "MMGarage", true);
      %item = 0;
      for(%i = 0; %i < $MM::RosterCount; %i++)
      {
         %db = $MM::Roster[%i];
         if($MM::Class[%db] != %arg)
            continue;
         Client::addMenuItem(%clientId, %item++ @ MechMayhem::garageLabel(%clientId, %db), "pick " @ %db);
      }
      if(%item == 0)
         Client::sendMessage(%clientId, 1, "GARAGE: no " @ %arg @ " chassis on the roster.");
      Client::addMenuItem(%clientId, "9Back", "garage");
      return;
   }
   if(%opt == "pick")
   {
      if($MM::CV[%arg] == "" || $MM::Class[%arg] == "boss")
      {
         Client::sendMessage(%clientId, 1, "GARAGE: " @ %arg @ " cannot be piloted.");
         return;
      }
      if(!MechProgress::canUse(%clientId, %arg))
      {
         // buy in place: confirm submenu with the price
         %cost = $MM::CV[%arg] * $MM::UnlockCostMult;
         %salv = 0;
         if(%clientId.mmKey != "") %salv = $MMP::salvage[%clientId.mmKey];
         if(%salv == "") %salv = 0;
         Client::buildMenu(%clientId, %arg @ " LOCKED (T" @ $MM::Tech[%arg] @ ") -- unlock for " @ %cost @ " salvage? (have " @ %salv @ ")", "MMGarage", true);
         if(%salv >= %cost)
            Client::addMenuItem(%clientId, "0YES -- unlock " @ %arg @ " now", "buy " @ %arg);
         else
            Client::addMenuItem(%clientId, "0(not enough salvage -- earn it destroying mechs)", "class " @ $MM::Class[%arg]);
         Client::addMenuItem(%clientId, "1Back", "class " @ $MM::Class[%arg]);
         return;
      }
      if (%clientId.mmAuth != 1)
      {
         Client::sendMessage(%clientId, 1, "GARAGE: your pilot record is locked. Console:  remoteEval(2048, MMPass, \"yourpassword\");");
         return;
      }
      %clientId.mmChassis = %arg;
      $MMP::lastChassis[%clientId.mmKey] = %arg;   // persists across sessions
      Client::sendMessage(%clientId, 1, "GARAGE: " @ %arg @ " locked in -- you will pilot it on your NEXT spawn.");
      bottomPrint(%clientId, "<jc><f2>" @ %arg @ " selected<f1> -- takes effect on your next spawn", 5);
      return;
   }
   if(%opt == "buy")
   {
      remoteMMBuy(%clientId, %arg);
      if(MechProgress::canUse(%clientId, %arg))
      {
         %clientId.mmChassis = %arg;
         $MMP::lastChassis[%clientId.mmKey] = %arg;
         bottomPrint(%clientId, "<jc><f2>" @ %arg @ " unlocked and selected<f1> -- next spawn", 5);
      }
      return;
   }
}

//--- battle-mode vote --------------------------------------------------------
$MMV::Window = 45;

function MechMayhem::voteMenu(%clientId)
{
   Client::buildMenu(%clientId, "Vote the next battle mode", "MMVote", true);
   Client::addMenuItem(%clientId, "0Escalation Arena (CV tickets)", "MechArena1");
   Client::addMenuItem(%clientId, "1Incursion (PvE Cybrid waves)", "MechIncursion1");
   Client::addMenuItem(%clientId, "2Groundwar (zone control)", "MechGroundwar1");
   Client::addMenuItem(%clientId, "3Monsoon Arena (storm)", "MechMonsoon1");
   Client::addMenuItem(%clientId, "9Back", "back");
}

function MechMayhem::voteOk(%mis)
{
   if(%mis == "MechArena1") return 1;
   if(%mis == "MechIncursion1") return 1;
   if(%mis == "MechGroundwar1") return 1;
   if(%mis == "MechMonsoon1") return 1;
   return 0;
}

function processMenuMMVote(%clientId, %option)
{
   %mis = getWord(%option, 0);
   if(%mis == "back")
   {
      Game::menuRequest(%clientId);
      return;
   }
   if(!MechMayhem::voteOk(%mis))
      return;
   if($MMV::active != 1)
   {
      $MMV::active = 1;
      $MMV::gen++;
      $MMV::count[MechArena1] = 0;
      $MMV::count[MechIncursion1] = 0;
      $MMV::count[MechGroundwar1] = 0;
      $MMV::count[MechMonsoon1] = 0;
      messageAll(0, "BATTLE-MODE VOTE started by " @ Client::getName(%clientId) @ " -- TAB, then Vote next battle mode. Closes in " @ $MMV::Window @ "s.");
      schedule("MechMayhem::voteTally();", $MMV::Window);
   }
   if(%clientId.mmVoteGen == $MMV::gen)
      return;
   %clientId.mmVoteGen = $MMV::gen;
   $MMV::count[%mis]++;
   messageAll(0, Client::getName(%clientId) @ " votes " @ %mis @ ".");
}

function MechMayhem::voteTally()
{
   $MMV::active = 0;
   %best = "";
   %bestN = 0;
   %mis = "MechArena1";     if($MMV::count[%mis] > %bestN) { %bestN = $MMV::count[%mis]; %best = %mis; }
   %mis = "MechIncursion1"; if($MMV::count[%mis] > %bestN) { %bestN = $MMV::count[%mis]; %best = %mis; }
   %mis = "MechGroundwar1"; if($MMV::count[%mis] > %bestN) { %bestN = $MMV::count[%mis]; %best = %mis; }
   %mis = "MechMonsoon1";   if($MMV::count[%mis] > %bestN) { %bestN = $MMV::count[%mis]; %best = %mis; }

   %humans = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      %humans++;
   %need = floor(%humans / 2) + 1;
   if(%need < 1) %need = 1;
   if(%bestN >= %need && %best != "")
   {
      messageAll(0, "VOTE PASSED: next battle is " @ %best @ " (" @ %bestN @ " of " @ %humans @ " pilots).");
      schedule("Server::loadMission(" @ %best @ ");", 3);
   }
   else
      messageAll(0, "Battle-mode vote failed (" @ %bestN @ " of " @ %humans @ ", needed " @ %need @ ").");
}

//=============================================================================
// OBJECTIVES PAGE -- the mech modes never wrote Team::setObjective lines, so
// the O page and the match-end summary were blank. Refreshed every 30 s
// (objTick, kicked from Game::startMatch), and with %final=1 + a headline at
// the win/loss paths.
//=============================================================================
function MechMayhem::objectives(%final, %headline)
{
   // CTF owns the objectives page (flag status lines, objectives.cs)
   if ($MM::Mode == "ctf")
      return;
   for(%l = -1; %l < getNumTeams(); %l++)
   {
      %n = 0;
      if(%final == 1)
      {
         Team::setObjective(%l, %n++, "<f5>MISSION SUMMARY");
         Team::setObjective(%l, %n++, "<f1>" @ %headline);
         Team::setObjective(%l, %n++, " ");
      }
      else
      {
         Team::setObjective(%l, %n++, "<f5>HERC HAVOC -- " @ $missionName);
         Team::setObjective(%l, %n++, " ");
      }
      if($MM::Mode == "incursion")
      {
         Team::setObjective(%l, %n++, "<f5>INCURSION -- survive " @ $MM::MaxWave @ " Cybrid waves");
         Team::setObjective(%l, %n++, "<f1>   - Wave: " @ $MMW::wave @ " of " @ $MM::MaxWave);
         Team::setObjective(%l, %n++, "<f1>   - Salvage banked: " @ $MMW::salvage);
         Team::setObjective(%l, %n++, "<f1>   - A full defender wipe mid-wave loses the outpost.");
      }
      else if($MM::Mode == "groundwar")
      {
         Team::setObjective(%l, %n++, "<f5>GROUNDWAR -- hold the zones");
         Team::setObjective(%l, %n++, "<f1>   - Presence in a zone captures it; defend orders rally your bots.");
      }
      else if($MM::Mode == "dm")
      {
         Team::setObjective(%l, %n++, "<f5>DEATHMATCH -- every pilot for themselves");
         Team::setObjective(%l, %n++, "<f1>   - First to " @ $MM::DMKillLimit @ " kills wins. Everyone you see is hostile.");
         if($HHDM::lead > 0)
            Team::setObjective(%l, %n++, "<f1>   - Leader: " @ $HHDM::leadName @ " with " @ $HHDM::lead);
      }
      else
      {
         Team::setObjective(%l, %n++, "<f5>ESCALATION -- Combat Value tickets");
         Team::setObjective(%l, %n++, "<f1>   - Every mech destroyed drains its authentic CV from its team's pool.");
         // pools are unset between the mission load and Game::startMatch
         %t0 = $MM::Tickets[0];
         %t1 = $MM::Tickets[1];
         if(%t0 == "") %t0 = $MM::TicketPool;
         if(%t1 == "") %t1 = $MM::TicketPool;
         Team::setObjective(%l, %n++, "<f1>   - " @ getTeamName(0) @ ": " @ %t0 @ " CV      " @ getTeamName(1) @ ": " @ %t1 @ " CV");
      }
      Team::setObjective(%l, %n++, " ");
      Team::setObjective(%l, %n++, "<f5>YOUR MECH");
      Team::setObjective(%l, %n++, "<f1>   - TAB, then Mech Garage picks your chassis (next spawn).");
      Team::setObjective(%l, %n++, "<f1>   - Weapons drain the REACTOR battery; it recharges when you hold fire. No heat, no shutdown.");
      Team::setObjective(%l, %n++, "<f1>   - TAB, then Special components swaps your HERC's specials; the pack key toggles cloak / booster.");
      Team::setObjective(%l, %n++, "<f1>   - TAB, then Weapon groups sets fire groups 1-3, each chain fire or LINKED (all at once).");
      Team::setObjective(%l, %n++, "<f1>   - Missiles need a LOCK: keep the target in your sights until the lock bar fills.");
      Team::setObjective(%l, %n++, "<f1>   - TAB, then Mine pack (optional) trades your last gun for mines; the mine key throws them.");
      Team::setObjective(%l, %n++, "<f1>   - Jump = dash on the light chassis (Talon, Seeker, Goad, Shepherd, Minotaur, Pieman, Emancipator). No HERC flies.");
      Team::setObjective(%l, %n++, "<f1>   - Tech-5+ human chassis (+EJECT in the garage) carry EJECTION SEATS: the pilot bails out and fights on foot.");
      Team::setObjective(%l, %n++, " ");
      Team::setObjective(%l, %n++, "<f5>TOP PILOTS");
      Team::setObjective(%l, %n++, "<f1>Pilot<L40>Kills<L55>Deaths");
      %shown = 0;
      $MMO::gen++;
      while(%shown < 5)
      {
         %bestCl = -1;
         %bestK = -1;
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         {
            if(%cl.mmObjGen == $MMO::gen)
               continue;
            %k = %cl.scoreKills;
            if(%k == "") %k = 0;
            if(%k > %bestK) { %bestK = %k; %bestCl = %cl; }
         }
         if(%bestCl == -1)
            break;
         %bestCl.mmObjGen = $MMO::gen;
         %d = %bestCl.scoreDeaths;
         if(%d == "") %d = 0;
         Team::setObjective(%l, %n++, "<f1>" @ Client::getName(%bestCl) @ "<L40>" @ %bestK @ "<L55>" @ %d);
         %shown++;
      }
      // blank the rest: lines persist server-side, so a shorter page (the end
      // summary) would otherwise show the previous page's tail under it
      while(%n < 32)
         Team::setObjective(%l, %n++, " ");
   }
}

// dm.cs calls this from Mission::init (mission load, BEFORE the match starts),
// from every Game::refreshClientScore, and at a time-limit/vote end. Stock it
// writes a DEATHMATCH page to teams -1 and 0 only -- line 0 banners over our
// page for them, nothing for team 1, whose O page stayed blank until the first
// objTick after startMatch. Route every call to the Herc Havoc page instead.
function DM::missionObjectives()
{
   if($MM::MatchOver != 1)
   {
      if($timeReached == 1)
         MechMayhem::objectives(1, "The match has ended.");
      else
         MechMayhem::objectives(0, "");
   }
   $timeReached = "";
   return false;
}

function MechMayhem::objTick()
{
   // the final summary stays up through the post-match window and the victory
   // screen; the next mission's startMatch kicks a fresh tick
   if($MM::MatchOver == 1)
      return;
   MechMayhem::objectives(0, "");
   schedule("MechMayhem::objTick();", 30);
}

echo("[MECH] menu + objectives loaded.");

// verbatim copy of base\scripts\admin.cs processMenuOptions (see header)
function ProcessMenuOptionsStock(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney")
      Admin::setModeTourney(%clientId);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "110 Minutes", 10);
      Client::addMenuItem(%clientId, "215 Minutes", 15);
      Client::addMenuItem(%clientId, "320 Minutes", 20);
      Client::addMenuItem(%clientId, "425 Minutes", 25);
      Client::addMenuItem(%clientId, "530 Minutes", 30);
      Client::addMenuItem(%clientId, "645 Minutes", 45);
      Client::addMenuItem(%clientId, "760 Minutes", 60);
      Client::addMenuItem(%clientId, "8No Time Limit", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   Game::menuRequest(%clientId);
}
