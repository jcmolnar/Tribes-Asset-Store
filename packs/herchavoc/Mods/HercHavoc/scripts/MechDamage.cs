//----------------------------------------------------------------------------
// Herc Havoc -- Starsiege shields + armour, component damage, death spectacle.
//
// Overrides Player::onDamage wholesale (no super in TribesScript): the stock
// player.cs:88 body is replicated VERBATIM for non-mech armors; Herc armors
// divert into the HERC pipeline.
//
// THE STARSIEGE DAMAGE MODEL, as Starsiege.exe does it (Starsiege RE\
// combat-re-2026-09-22\COMBAT-RE.md sections 13, A-D, F -- proven from the
// decompile). Every Herc Havoc weapon has its OWN damage type ($HH::TypeBase +
// Starsiege weapon id), so this script applies that projectile's real columns.
// Everything is in Starsiege units / 100.
//
//   BODY PARTS  a hit lands on the part whose collision box holds it (the
//               struck shape node in Starsiege); a destroyed part forwards to
//               its parent. Tables: $HHP::* in HHChassis.cs (tools/hh_gen.py).
//   SHIELD      Passthru Shield skips it; the rest x Effect v. Shield; overflow
//               / effect passes through. Regen DRAWS reactor energy (the
//               generator's chargeRate per second); capacity follows the
//               shield generator's health.
//   ARMOUR      per part: the Armor component's share there. Passthru Armor
//               skips it; the rest x Effect v. Armor, minus ONE type-weighted
//               shrug (scaled 50-100% by the share left), DIVIDED by the
//               type-weighted effectiveness. What the armour stops is gone;
//               structure takes passthrough + overflow only. A bare part takes
//               the whole hit, no shrug.
//   STRUCTURE   round-robin between the part itself and the internals inside it
//               (servo shares, engine/reactor/shield/sensors... at full HP in
//               their mount's damage parent). A part at <= 1 raw HP is
//               destroyed: its internals and child parts go with it, its guns
//               leave the rack, the excess hits the parent.
//   DEATH       3 s after the ENGINE or the REACTOR is destroyed. Reactor
//               output and engine speed fall to half at 0 HP; the leg servos'
//               health scales the throttle.
//   SPLASH      a weapon with Blast > 0 does no direct hit: every part takes
//               base x (1 - (d - 1) / R)^2 at its own distance (1 m full core).
//   BEAMS       Var% is a distance lerp, +Var at point blank to -Var at range.
//   armour type every HERC = Quad-Bonded Metaplas; bosses = Quicksilver nano
//               armour ($HH::Armor[chassis] Q / X), which slowly regrows.
//   death       staged reactor detonation, wreck persists $MM::WreckSecs.
//----------------------------------------------------------------------------

$MM::DetonateDamage = 5.0;      // fallback only: $HH::Meltdown[chassis] is the rule
if ($HH::MaxFlash == "") $HH::MaxFlash = 0.2;   // red hit-flash ceiling (was 0.75)
$MM::WreckSecs = 60;

function MechDamage::isMech(%armor)
{
   return String::getSubStr(%armor, 0, 4) == "Herc";
}

//--- shields ----------------------------------------------------------------

function MechShield::init(%pl, %chassis)
{
   %pl.mmShieldMax = $HH::ShieldMax[%chassis];
   if (%pl.mmShieldMax == "")
      %pl.mmShieldMax = 26;
   %pl.mmShieldRate = $HH::ShieldRate[%chassis];
   if (%pl.mmShieldRate == "")
      %pl.mmShieldRate = 0.3;
   // the generator's reactor draw (energy/s); regen per energy unit is
   // mmShieldRate / mmShieldDraw, so a Shield Capacitor's extra rate still counts
   %pl.mmShieldDraw = $HH::ShieldDraw[%chassis];
   if (%pl.mmShieldDraw == "" || %pl.mmShieldDraw <= 0)
      %pl.mmShieldDraw = 25;
   %pl.mmShield = %pl.mmShieldMax;
   %pl.mmLastHit = -100;
   %pl.mmCrippled = 0;
   HHParts::init(%pl, %chassis);
}

// called from MechHeat::tick for every live HERC; %dt = seconds since last.
// Starsiege: the generator is a reactor consumer -- it charges only as fast as
// the reactor can pay, up to its capacity x generator health.
function MechShield::regen(%obj, %dt)
{
   if (%obj.mmShieldMax == "")
      return;
   %f = %obj.hhShdFrac;
   if (%f == "")
      %f = 1;
   %cap = %obj.mmShieldMax * %f;
   if (%obj.mmShield > %cap)
      %obj.mmShield = %cap;
   if (%obj.mmShield >= %cap) {
      if (%cap > 0 && %obj.mmShield >= %obj.mmShieldMax * 0.5)
         %obj.mmShieldDownSaid = 0;
      return;
   }
   %per = %obj.mmShieldRate / %obj.mmShieldDraw;
   %draw = %obj.mmShieldDraw * %dt;
   %e = GameBase::getEnergy(%obj);
   if (%draw > %e)
      %draw = %e;
   %gain = %draw * %per;
   if (%gain > %cap - %obj.mmShield) {
      %gain = %cap - %obj.mmShield;
      %draw = %gain / %per;
   }
   GameBase::setEnergy(%obj, %e - %draw);
   %obj.mmShield = %obj.mmShield + %gain;
   if (%obj.mmShield >= %obj.mmShieldMax * 0.5)
      %obj.mmShieldDownSaid = 0;
}

// The Starsiege shield step for one hit of HH weapon %type (FUN_00467184).
// Returns what passes through, in raw/100 -- the body-part step takes it.
function MechShield::absorbHit(%this, %type, %value, %quadrant)
{
   %pass = $HH::Pass[%type];
   // Shield Modulator (special component) focuses the shield forward
   %eff = $HH::EffSh[%type] * HHComp::focus(%this, %quadrant);
   if (%eff <= 0) %eff = 1;
   %toArmor = %value * %pass;
   %shieldPart = %value - %toArmor;
   if (%this.mmShield > 0) {
      %sh = %shieldPart * %eff;
      if (%sh <= %this.mmShield)
         %this.mmShield = %this.mmShield - %sh;
      else {
         // overflow re-enters raw units before it reaches the armour
         %toArmor = %toArmor + (%sh - %this.mmShield) / %eff;
         %this.mmShield = 0;
         // once per collapse: regen puts a sliver back every tick, and each
         // following hit broke it again -- one message per hit. Re-armed in
         // MechShield::regen once the shield is back above half.
         if (%this.mmShieldDownSaid != 1) {
            %this.mmShieldDownSaid = 1;
            %cl = Player::getClient(%this);
            if (%cl > 0)
               Client::sendMessage(%cl, 1, "SHIELDS DOWN");
         }
      }
   }
   else
      %toArmor = %toArmor + %shieldPart;
   return %toArmor;
}

// non-projectile damage (falls, collisions, stock weapons): no projectile
// columns. Starsiege lets 75% of impact damage straight through and the shield
// soaks the rest up to its charge; anything else is fully absorbable.
function MechShield::absorb(%this, %type, %value)
{
   %pass = 0;
   if (%type == $ImpactDamageType) {
      %pass = %value * 0.75;
      %value = %value - %pass;
   }
   if (%this.mmShield <= 0)
      return %value + %pass;
   if (%value <= %this.mmShield) {
      %this.mmShield = %this.mmShield - %value;
      return %pass;
   }
   %through = %value - %this.mmShield;
   %this.mmShield = 0;
   return %through + %pass;
}

//--- body parts (Starsiege component model, COMBAT-RE C) ---------------------
// Per-pilot state on the player object: hhPHp[i] part structure, hhPArm[i] its
// armour share, hhPDead[i], hhPCtr[i] structure-hit counter, hhIHp[i, k] the
// internal shares inside part i. Tables $HHP::* are per chassis (HHChassis.cs).

function HHParts::init(%pl, %db)
{
   %pl.hhDb = %db;
   %pl.hhPN = 0;
   %n = $HHP::N[%db];
   if (%n == "" || %n <= 0)
      return;
   %pl.hhPN = %n;
   %pl.hhArmNow = 0;
   %pl.hhMaxTot = 0;
   for (%i = 0; %i < %n; %i++) {
      %pl.hhPHp[%i] = $HHP::Hp[%db, %i];
      %pl.hhPArm[%i] = $HHP::Arm[%db, %i];
      %pl.hhPDead[%i] = 0;
      %pl.hhPCtr[%i] = 0;
      %pl.hhArmNow = %pl.hhArmNow + %pl.hhPArm[%i];
      %pl.hhMaxTot = %pl.hhMaxTot + $HHP::Hp[%db, %i] + $HHP::Arm[%db, %i];
      for (%k = 0; %k < $HHP::NIn[%db, %i]; %k++)
         %pl.hhIHp[%i, %k] = $HHP::InHp[%db, %i, %k];
   }
   %pl.hhDying = 0;
   %pl.hhGunsLost = 0;
   %pl.hhShdFrac = 1;
   %pl.hhSpeedFrac = 1;
   %pl.hhThrottle = 1;
   %pl.hhPilot = $HHP::PilotHp[%db];
   if (%pl.hhPilot == "")
      %pl.hhPilot = 3;
}

// Starsiege's hard-coded projectile specials (FUN_00472de8, COMBAT-RE G8), after
// the normal hit. %p = what passed the shield (raw/100), %value = the full hit.
//   rad  Radiation Gun: extra PILOT damage, (0.05-0.1) x the hit (the other term
//        in the exe scales pilot damage taken through the structure, which this
//        port's part model never routes to the pilot); a dead pilot loses the
//        HERC 2.5 s later (event 8)
//   dis  Disruptor: a passthrough over 25 raw permanently multiplies the drive's
//        throttle by a random 0.2-0.5
function HHParts::special(%pl, %type, %value, %p)
{
   %sp = $HH::Special[%type];
   if (%sp == "rad") {
      %pl.hhPilot = %pl.hhPilot - %value * (0.05 + getRandom() * 0.05);
      if (%pl.hhPilot <= 0 && %pl.hhDying != 1) {
         %pl.hhDying = 1;
         %cl = Player::getClient(%pl);
         if (%cl > 0)
            Client::sendMessage(%cl, 1, "PILOT CRITICAL -- RADIATION");
         echo("[HHPART] " @ %pl @ " pilot killed by radiation");
         schedule("HHParts::die(" @ %pl @ ");", 2.5, %pl);
      }
   }
   else if (%sp == "dis" && %p > 0.25) {
      %pl.hhThrottle = %pl.hhThrottle * (0.2 + getRandom() * 0.3);
      %cl = Player::getClient(%pl);
      if (%cl > 0)
         Client::sendMessage(%cl, 1, "DRIVE DISRUPTED");
   }
}

// health 0..1 of one internal kind (Engine Reactor Shield Sensors Computer
// ServoL ServoR); a kind the chassis does not carry reads 1
function HHParts::kind(%pl, %kind)
{
   %db = %pl.hhDb;
   %cur = 0;
   %max = 0;
   for (%i = 0; %i < %pl.hhPN; %i++) {
      for (%k = 0; %k < $HHP::NIn[%db, %i]; %k++) {
         if ($HHP::InKind[%db, %i, %k] == %kind) {
            %cur = %cur + %pl.hhIHp[%i, %k];
            %max = %max + $HHP::InHp[%db, %i, %k];
         }
      }
   }
   if (%max <= 0)
      return 1;
   return %cur / %max;
}

// world point -> the HERC's own frame (x right, y forward, z up; yaw only)
function HHParts::local(%pl, %pos)
{
   %o = GameBase::getPosition(%pl);
   %rx = getWord(%pos, 0) - getWord(%o, 0);
   %ry = getWord(%pos, 1) - getWord(%o, 1);
   %rz = getWord(%pos, 2) - getWord(%o, 2);
   %f = Vector::getFromRot(GameBase::getRotation(%pl), 1);
   %fx = getWord(%f, 0);
   %fy = getWord(%f, 1);
   // right = forward turned -90 deg about z = (fy, -fx)
   return (%rx * %fy - %ry * %fx) @ " " @ (%rx * %fx + %ry * %fy) @ " " @ %rz;
}

// "dx dy dz" from world point %pos to part %i's collision box, in the pose the
// HERC is in NOW: the point goes into the part's node frame (engine
// Player::worldToNode, animated) and is tested against the node-local mesh box.
// Falls back to the rest-pose box in the HERC frame if the engine cannot say.
function HHParts::partVec(%pl, %i, %pos)
{
   %db = %pl.hhDb;
   %n = Player::worldToNode(%pl, $HHP::Node[%db, %i], %pos);
   if (%n != "")
      return HHParts::vecTo($HHP::LMin[%db, %i], $HHP::LMax[%db, %i], %n);
   return HHParts::vecTo($HHP::Min[%db, %i], $HHP::Max[%db, %i], HHParts::local(%pl, %pos));
}

// box centre of part %i, in the frame partVec measured in
function HHParts::partCentreDist(%pl, %i, %pos)
{
   %db = %pl.hhDb;
   %n = Player::worldToNode(%pl, $HHP::Node[%db, %i], %pos);
   if (%n != "") {
      %mn = $HHP::LMin[%db, %i];
      %mx = $HHP::LMax[%db, %i];
   }
   else {
      %n = HHParts::local(%pl, %pos);
      %mn = $HHP::Min[%db, %i];
      %mx = $HHP::Max[%db, %i];
   }
   %c = ((getWord(%mn, 0) + getWord(%mx, 0)) / 2) @ " " @ ((getWord(%mn, 1) + getWord(%mx, 1)) / 2)
        @ " " @ ((getWord(%mn, 2) + getWord(%mx, 2)) / 2);
   return Vector::getDistance(%n, %c);
}

// "dx dy dz" from point %l to the box %mn..%mx (0 0 0 inside)
function HHParts::vecTo(%mn, %mx, %l)
{
   %v = "";
   for (%a = 0; %a < 3; %a++) {
      %p = getWord(%l, %a);
      %d = 0;
      if (%p < getWord(%mn, %a))
         %d = getWord(%mn, %a) - %p;
      else if (%p > getWord(%mx, %a))
         %d = %p - getWord(%mx, %a);
      if (%a == 0) %v = %d;
      else %v = %v @ " " @ %d;
   }
   return %v;
}

// the struck part: the box holding the hit (nearest box centre among
// overlapping ones), else the nearest box; a destroyed part forwards to its
// parent (FUN_00464128); -1 when the whole chain is gone
function HHParts::locate(%pl, %pos)
{
   %db = %pl.hhDb;
   %best = -1;
   %bs = 1000000;
   for (%i = 0; %i < %pl.hhPN; %i++) {
      %d = Vector::getDistance(HHParts::partVec(%pl, %i, %pos), "0 0 0");
      if (%d <= 0.001)
         %s = HHParts::partCentreDist(%pl, %i, %pos);
      else
         %s = 1000 + %d;
      if (%s < %bs) {
         %bs = %s;
         %best = %i;
      }
   }
   while (%best >= 0 && %pl.hhPDead[%best] == 1)
      %best = $HHP::Par[%db, %best];
   return %best;
}

// one hit's post-shield damage %D on part %i (FUN_00463b7c + FUN_0040eb18)
function HHParts::hit(%pl, %i, %type, %D)
{
   if (%i < 0 || %D <= 0 || %pl.hhPDead[%i] == 1)
      return;
   %db = %pl.hhDb;
   %pass = %D * $HH::PassAr[%type];
   %effAr = $HH::EffAr[%type];
   if (%effAr == "")
      %effAr = 1;
   %arm = %pl.hhPArm[%i];
   if (%arm > 0) {
      if ($HH::Armor[%db] == "X") {
         %sc = $HH::ShrugXConc;  %se = $HH::ShrugXElec;  %st = $HH::ShrugXTherm;
         %ec = $HH::EffXConc;    %ee = $HH::EffXElec;    %et = $HH::EffXTherm;
      }
      else {
         %sc = $HH::ShrugQConc;  %se = $HH::ShrugQElec;  %st = $HH::ShrugQTherm;
         %ec = $HH::EffQConc;    %ee = $HH::EffQElec;    %et = $HH::EffQTherm;
      }
      %fc = $HH::FracConc[%type];
      %fe = $HH::FracElec[%type];
      %ft = $HH::FracTherm[%type];
      %fs = $HH::FracSpec[%type];
      // effectiveness DIVIDES; special damage has no armorInfospecial entry on
      // QBM/Quicksilver, so it takes eff 1 and no shrug (default unresolved in RE)
      %effSum = %fc * %ec + %fe * %ee + %ft * %et + %fs;
      if (%effSum < 0.1)
         %effSum = 0.1;
      %shrug = %fc * %sc + %fe * %se + %ft * %st;
      %rest = (%D - %pass) * %effAr;
      %x = %rest - %shrug * 0.5 * (1 + %arm / $HHP::Arm[%db, %i]);
      if (%x < 0)
         %x = 0;
      %x = %x / %effSum;
      %over = 0;
      if (%x > %arm) {
         %over = (%x - %arm) * %effSum;
         %x = %arm;
      }
      %pl.hhPArm[%i] = %arm - %x;
      %pl.hhArmNow = %pl.hhArmNow - %x;
      if (%effAr > 0.01)
         %over = %over / %effAr;
      %struct = %pass + %over;
   }
   else
      %struct = %D;          // bare part: the whole hit, no shrug
   HHParts::structure(%pl, %i, %type, %struct);
}

// structure damage, round-robin between the part and its internal shares
function HHParts::structure(%pl, %i, %type, %amt)
{
   %db = %pl.hhDb;
   %guard = 0;
   while (%amt > 0.0001 && %pl.hhPDead[%i] != 1 && %guard < 32) {
      %guard++;
      %n = $HHP::NIn[%db, %i];
      %idx = 0;
      if (%pl.hhPCtr[%i] > 0 && %n > 0) {
         %v = %pl.hhPCtr[%i] + floor(getRandom() * (%n + 1));
         %idx = %v - floor(%v / (%n + 1)) * (%n + 1);
      }
      %pl.hhPCtr[%i] = %pl.hhPCtr[%i] + 1;
      if (%idx > 0 && %pl.hhIHp[%i, %idx - 1] > 0) {
         %k = %idx - 1;
         %s = %pl.hhIHp[%i, %k];
         if (%amt < %s) {
            %pl.hhIHp[%i, %k] = %s - %amt;
            %amt = 0;
         }
         else {
            %pl.hhIHp[%i, %k] = 0;
            %amt = %amt - %s;
         }
      }
      else {
         %hp = %pl.hhPHp[%i];
         if (%hp - %amt <= 0.01) {
            %par = $HHP::Par[%db, %i];
            HHParts::destroy(%pl, %i);
            // the excess hits the parent through ITS armour (apply(parent, rest))
            if (%par >= 0)
               HHParts::hit(%pl, %par, %type, %amt - %hp);
            return;
         }
         %pl.hhPHp[%i] = %hp - %amt;
         %amt = 0;
      }
   }
}

// FUN_00463a74: structure 0, remaining armour and every contained internal
// share dealt in full, guns on it lost, child parts destroyed with it
function HHParts::destroy(%pl, %i)
{
   %db = %pl.hhDb;
   if (%pl.hhPDead[%i] == 1)
      return;
   %pl.hhPDead[%i] = 1;
   %pl.hhPHp[%i] = 0;
   %pl.hhArmNow = %pl.hhArmNow - %pl.hhPArm[%i];
   %pl.hhPArm[%i] = 0;
   for (%k = 0; %k < $HHP::NIn[%db, %i]; %k++)
      %pl.hhIHp[%i, %k] = 0;
   echo("[HHPART] " @ %pl @ " " @ %db @ " " @ $HHP::Name[%db, %i] @ " destroyed");
   %cl = Player::getClient(%pl);
   if (%cl > 0)
      Client::sendMessage(%cl, 1, $HHP::Name[%db, %i] @ " destroyed");
   for (%g = 0; %g < $HHP::NGun[%db]; %g++)
      if ($HHP::GunPart[%db, %g] == %i)
         HHRack::loseHp(%pl, %g);
   for (%j = 0; %j < %pl.hhPN; %j++)
      if ($HHP::Par[%db, %j] == %i)
         HHParts::destroy(%pl, %j);
}

// Starsiege splash (FUN_0044d254): every live part takes its own event,
// base x (1 - (d - 1) / R)^2 at its own distance, full damage inside 1 m
function HHParts::splash(%pl, %center, %R, %base, %type)
{
   if (%R <= 0 || %base <= 0)
      return;
   %db = %pl.hhDb;
   for (%i = 0; %i < %pl.hhPN; %i++) {
      if (%pl.hhPDead[%i] == 1)
         continue;
      %d = Vector::getDistance(HHParts::partVec(%pl, %i, %center), "0 0 0");
      if (%d < 1)
         %d = 1;
      if (%d - 1 >= %R)
         continue;
      %f = 1 - (%d - 1) / %R;
      %p = MechShield::absorbHit(%pl, %type, %base * %f * %f, "");
      HHParts::hit(%pl, %i, %type, %p);
   }
}

function HHParts::lamp(%f)
{
   if (%f >= 0.67) return 0;
   if (%f > 0.33) return 1;
   return 2;
}

// after any damage or repair: functional effects, HUD, death
function HHParts::update(%pl)
{
   if (%pl.hhPN == "" || %pl.hhPN <= 0)
      return;
   %db = %pl.hhDb;
   %eng = HHParts::kind(%pl, "Engine");
   %rea = HHParts::kind(%pl, "Reactor");
   %pl.hhShdFrac = HHParts::kind(%pl, "Shield");
   %sen = HHParts::kind(%pl, "Sensors");
   %sv = (HHParts::kind(%pl, "ServoL") + HHParts::kind(%pl, "ServoR")) / 2;
   // reactor output halves at 0 HP (FUN_0054f42c)
   %out = $HH::Reactor[%db];
   if (%out == "")
      %out = 60;
   GameBase::setRechargeRate(%pl, %out * 0.5 * (1 + %rea));
   // engine top speed x0.5(1 + HP%), leg servos scale the throttle by their
   // average (a Disruptor hit multiplies in hhThrottle). Tribes keeps speed on
   // the datablock, so the HERC steps to the nearest speed-tier twin.
   %thr = %pl.hhThrottle;
   if (%thr == "")
      %thr = 1;
   %pl.hhSpeedFrac = 0.5 * (1 + %eng) * %sv * %thr;
   HHParts::speedTier(%pl);
   // cockpit lamps: 0 ok, 1 damaged, 2 critical
   %pl.hhLampLegs = HHParts::lamp(%sv);
   %pl.hhLampSens = HHParts::lamp(%sen);
   %pl.hhLampRctr = HHParts::lamp(%rea);
   %pl.hhLampGuns = 0;
   if (%pl.hhGunsLost > 0) {
      %pl.hhLampGuns = 1;
      if (%pl.hhRackN == "" || %pl.hhRackN <= 0 || %pl.hhGunsLost >= %pl.hhRackN)
         %pl.hhLampGuns = 2;
   }
   // the Tribes damage level (HUD bar, bots, voice call-outs) mirrors what is
   // left of structure + armour; it only reaches max at death
   %left = 0;
   for (%i = 0; %i < %pl.hhPN; %i++)
      %left = %left + %pl.hhPHp[%i] + %pl.hhPArm[%i];
   %frac = 1 - %left / %pl.hhMaxTot;
   if (%frac > 0.97)
      %frac = 0.97;
   if (%frac < 0)
      %frac = 0;
   if (!Player::isDead(%pl)) {
      %armor = Player::getArmor(%pl);
      GameBase::setDamageLevel(%pl, %armor.maxDamage * %frac);
   }
   // Starsiege: destroyed ENGINE or REACTOR -> the HERC dies 3 s later
   if ((%eng <= 0 || %rea <= 0) && %pl.hhDying != 1) {
      %pl.hhDying = 1;
      %cl = Player::getClient(%pl);
      if (%cl > 0) {
         if (%rea <= 0)
            Client::sendMessage(%cl, 1, "REACTOR DESTROYED -- CRITICAL");
         else
            Client::sendMessage(%cl, 1, "ENGINE DESTROYED -- CRITICAL");
      }
      echo("[HHPART] " @ %pl @ " " @ %db @ " dying: engine " @ %eng @ " reactor " @ %rea);
      schedule("HHParts::die(" @ %pl @ ");", 3.0, %pl);
   }
}

// nearest speed tier for hhSpeedFrac: 1 / 0.8 (Spd8) / 0.6 (Crip) / 0.4 (Spd4)
function HHParts::speedTier(%pl)
{
   if (Player::isDead(%pl))
      return;
   %f = %pl.hhSpeedFrac;
   %suf = "";
   if (%f < 0.9) %suf = "Spd8";
   if (%f < 0.7) %suf = "Crip";
   if (%f < 0.5) %suf = "Spd4";
   %armor = Player::getArmor(%pl);
   %base = MechHeat::baseChassis(%armor);
   if (%armor == %base @ %suf)
      return;
   %dmg = GameBase::getDamageLevel(%pl);
   Player::setArmor(%pl, %base @ %suf);
   GameBase::setDamageLevel(%pl, %dmg);
   %pl.mmCrippled = 0;
   if (%suf != "")
      %pl.mmCrippled = 1;
   %cl = Player::getClient(%pl);
   if (%cl > 0 && %suf != "")
      Client::sendMessage(%cl, 1, "DRIVE DAMAGED -- " @ floor(%f * 100 + 0.5) @ "% speed");
   echo("[HHPART] " @ %pl @ " speed tier " @ %base @ %suf @ " (" @ %f @ ")");
}

function HHParts::die(%pl)
{
   if (%pl == "" || !isObject(%pl) || Player::isDead(%pl))
      return;
   MechDamage::kill(%pl, %pl.hhLastShooter, %pl.hhLastType);
}

// repair (nano repair, repair pads, Quicksilver regrowth): armour shares on
// live parts first, then their structure. Destroyed parts stay destroyed.
function HHParts::repair(%pl, %amt)
{
   %db = %pl.hhDb;
   for (%i = 0; %i < %pl.hhPN && %amt > 0; %i++) {
      if (%pl.hhPDead[%i] == 1)
         continue;
      %need = $HHP::Arm[%db, %i] - %pl.hhPArm[%i];
      if (%need > %amt) %need = %amt;
      if (%need > 0) {
         %pl.hhPArm[%i] = %pl.hhPArm[%i] + %need;
         %pl.hhArmNow = %pl.hhArmNow + %need;
         %amt = %amt - %need;
      }
   }
   for (%i = 0; %i < %pl.hhPN && %amt > 0; %i++) {
      if (%pl.hhPDead[%i] == 1)
         continue;
      %need = $HHP::Hp[%db, %i] - %pl.hhPHp[%i];
      if (%need > %amt) %need = %amt;
      if (%need > 0) {
         %pl.hhPHp[%i] = %pl.hhPHp[%i] + %need;
         %amt = %amt - %need;
      }
   }
   HHParts::update(%pl);
}

function HHParts::damaged(%pl)
{
   %left = 0;
   for (%i = 0; %i < %pl.hhPN; %i++)
      %left = %left + %pl.hhPHp[%i] + %pl.hhPArm[%i];
   return %left < %pl.hhMaxTot - 0.001;
}

//--- death spectacle --------------------------------------------------------

// staged chain: two escalating internal pops, then the reactor blast. Nearby
// pilots get camera shake at each stage (Player::camShake native hook).
function MechDeath::spectacle(%this)
{
   %pos = GameBase::getPosition(%this);
   playSound(SoundFireMortar, %pos);
   schedule("MechDeath::pop(" @ %this @ ", 1);", 0.4, %this);
   schedule("MechDeath::pop(" @ %this @ ", 2);", 0.8, %this);
   schedule("MechDeath::detonate(" @ %this @ ");", 1.2, %this);
}

function MechDeath::pop(%this, %stage)
{
   if (%this == "" || %this <= 0)
      return;
   %pos = GameBase::getPosition(%this);
   playSound(SoundFireGrenade, %pos);
   MechDeath::shakeNear(%pos, 0.15 * %stage, 30);
}

// camera shake for every human piloting a mech within range, linear falloff
function MechDeath::shakeNear(%pos, %amp, %radius)
{
   $MMShake::pos = %pos;
   $MMShake::amp = %amp;
   $MMShake::radius = %radius;
   Group::iterateRecursive(MissionCleanup, "MechDeath::shakeVisit");
}

function MechDeath::shakeVisit(%obj)
{
   %data = GameBase::getDataName(%obj);
   if (String::getSubStr(%data, 0, 4) != "Herc")
      return;
   %cl = Player::getClient(%obj);
   if (%cl <= 0)
      return;
   %d = Vector::getDistance(GameBase::getPosition(%obj), $MMShake::pos);
   if (%d > $MMShake::radius)
      return;
   remoteEval(%cl, "MMShake", $MMShake::amp * (1 - (%d / $MMShake::radius)));
}

function MechDeath::detonate(%this)
{
   if (%this == "" || %this <= 0)
      return;
   %pos = GameBase::getPosition(%this);
   %base = MechHeat::baseChassis(Player::getArmor(%this));
   // Starsiege meltdown (FUN_00475134): the default reactor's Meltdown as THERMAL
   // damage, radius 2 x the shape's radius, the same quadratic per-part falloff
   $MMDet::pos = %pos;
   $MMDet::src = %this;
   $MMDet::dmg = $HH::Meltdown[%base];
   if ($MMDet::dmg == "")
      $MMDet::dmg = $MM::DetonateDamage;
   $MMDet::R = 2 * $HHP::Radius[%base];
   if ($MMDet::R == "" || $MMDet::R <= 0)
      $MMDet::R = 20;
   Player::blowUp(%this);
   playSound(bigExplosion1, %pos);
   Group::iterateRecursive(MissionCleanup, "MechDeath::damageNear");
   MechDeath::shakeNear(%pos, 0.5, 60);
   echo("[MECHDEATH] detonation at " @ %pos @ " meltdown " @ $MMDet::dmg @ " R " @ $MMDet::R);
}

function MechDeath::damageNear(%obj)
{
   if (%obj == $MMDet::src)
      return;
   %data = GameBase::getDataName(%obj);
   if (String::getSubStr(%data, 0, 4) != "Herc")
      return;
   if (Player::isDead(%obj))
      return;
   // cheap reject before the per-part pass (a HERC is at most ~10 m across)
   if (Vector::getDistance(GameBase::getPosition(%obj), $MMDet::pos) > $MMDet::R + 12)
      return;
   if (%obj.hhPN == "" || %obj.hhPN <= 0)
      HHParts::init(%obj, MechHeat::baseChassis(%data));
   %obj.hhLastShooter = Player::getClient($MMDet::src);
   %obj.hhLastType = $HH::MeltType;
   HHParts::splash(%obj, $MMDet::pos, $MMDet::R, $MMDet::dmg, $HH::MeltType);
   HHParts::update(%obj);
   echo("[MECHDEATH] meltdown splash on " @ %obj);
}

//--- the override -----------------------------------------------------------

function MechDamage::apply(%this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object)
{
   %damagedClient = Player::getClient(%this);
   %shooterClient = %object;

   Player::applyImpulse(%this, %mom);

   // friendly fire (stock rule, without the chat spam for bots)
   %friendFire = 1.0;
   if ($teamplay && %damagedClient != %shooterClient
       && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient))
      %friendFire = $Server::TeamDamageScale;

   if (Player::isDead(%this))
      return;

   %armor = Player::getArmor(%this);
   %this.mmLastHit = getSimTime();
   if (%this.hhPN == "" || %this.hhPN <= 0)
      HHParts::init(%this, MechHeat::baseChassis(%armor));
   %this.hhLastShooter = %shooterClient;
   %this.hhLastType = %type;
   %before = GameBase::getDamageLevel(%this);

   if ($HH::Raw[%type] != "") {
      if ($HH::Blast[%type] > 0) {
         // Starsiege: a blast weapon does NO direct hit -- the detonation point
         // (%pos) splashes every part at its own distance, from the full damage
         HHParts::splash(%this, %pos, $HH::Blast[%type], $HH::Raw[%type] * %friendFire, %type);
      }
      else {
         %value = %value * %friendFire;
         if (%value <= 0)
            return;
         // beam Var%: +Var at point blank, -Var at max range (FUN_0048b6fc)
         %var = $HH::Var[%type];
         if (%var > 0 && $HH::Range[%type] > 0) {
            %src = Client::getOwnedObject(%shooterClient);
            if (%src != -1) {
               %dist = Vector::getDistance(GameBase::getPosition(%src), %pos);
               %f = ($HH::Range[%type] - %dist) / $HH::Range[%type];
               if (%f < 0) %f = -%f;
               if (%f > 1) %f = 1;
               %value = %value * ((1 - %var) + 2 * %var * %f);
            }
         }
         // Direct hits arrive with zero momentum (projectile.cpp:425 passes
         // 0,0,0; only splash kicks), so apply Starsiege's pseudo-mass knockback
         // here along the shot, scaled by how much of a full hit landed.
         if (%mom == "0 0 0" && $HH::Kick[%type] > 0 && %vec != "0 0 0") {
            %k = $HH::Kick[%type] * (%value / $HH::Raw[%type]);
            %n = Vector::normalize(%vec);
            Player::applyImpulse(%this, getWord(%n, 0) * %k @ " " @ getWord(%n, 1) * %k
                                        @ " " @ getWord(%n, 2) * %k);
         }
         %part = HHParts::locate(%this, %pos);
         // $pref::hhPartDiag 1: which part a hit chose, beside Tribes' own verdict
         if ($pref::hhPartDiag)
            echo("[HHHIT] " @ %this @ " " @ $HHP::Name[%this.hhDb, %part] @ " vert=" @ %vertPos
                 @ " quad=" @ %quadrant @ " local=" @ HHParts::local(%this, %pos) @ " dmg=" @ %value);
         %p = MechShield::absorbHit(%this, %type, %value, %quadrant);
         HHParts::hit(%this, %part, %type, %p);
         if ($HH::Special[%type] != "")
            HHParts::special(%this, %type, %value, %p);
      }
   }
   else {
      %value = %value * %friendFire;
      if (%value <= 0)
         return;
      %part = HHParts::locate(%this, %pos);
      HHParts::hit(%this, %part, $HH::GenericType, MechShield::absorb(%this, %type, %value));
   }
   HHParts::update(%this);

   // Red hit flash, kept faint (guide: rapid-fire weapons used to blind the
   // pilot). Scaled by the share of the hull this hit took, capped low.
   %took = GameBase::getDamageLevel(%this) - %before;
   if (%took > 0) {
      %flash = Player::getDamageFlash(%this) + (%took / %armor.maxDamage) * 1.5;
      if (%flash > $HH::MaxFlash)
         %flash = $HH::MaxFlash;
      Player::setDamageFlash(%this, %flash);
   }
}

// the HERC is lost (engine or reactor destroyed, 3 s on -- HHParts::die)
function MechDamage::kill(%this, %shooterClient, %type)
{
   %damagedClient = Player::getClient(%this);
   %armor = Player::getArmor(%this);
   // LAST STAND: a perk chassis ejects its pilot instead (MechEject.cs). fire()
   // handles ALL of the death's bookkeeping; on spawn failure it returns 0 and
   // the normal death below proceeds untouched.
   if (MechEject::canEject(%this)) {
      if (MechEject::fire(%this, %damagedClient, %shooterClient, %type))
         return;
   }
   GameBase::setDamageLevel(%this, %armor.maxDamage);
   if (Player::isDead(%this)) {
      MechDeath::spectacle(%this);
      if (%type == $ImpactDamageType && %shooterClient.clLastMount != "")
         %shooterClient = %shooterClient.clLastMount;
      Client::onKilled(%damagedClient, %shooterClient, %type);
   }
}

function Player::onDamage(%this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object)
{
   %mmArmor = Player::getArmor(%this);
   if (MechDamage::isMech(%mmArmor)) {
      if (%object != "" && %object != -1)
         %this.mmLastAttacker = %object;   // salvage credit at charge() time
      MechDamage::apply(%this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object);
      return;
   }

   // ------- stock player.cs:88 body, verbatim, for everything else -------
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					if(%type != $MineDamageType) {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
					}
					else {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient))
			%friendFire = $Server::TeamDamageScale;
		else
			%friendFire = 1.0;

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType) {
				if(%armor == "harmor") {
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) {
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else {
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
  			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75)
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) {
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
               if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right")
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) )
							%curDie = $PlayerAnim::Crouching;
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	)
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") {
							if(%quadrant == "front_left" )
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right")
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" )
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right")
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left")
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right")
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
	}
}

echo("[MECH] MechDamage loaded (shields + crits + death spectacle).");
