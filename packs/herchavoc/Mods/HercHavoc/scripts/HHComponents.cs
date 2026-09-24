//----------------------------------------------------------------------------
// Herc Havoc -- Starsiege special components ("packs") and mines.
//
// A Starsiege HERC's special mount points take one internal component each
// (datIntMounts.cs). Every HERC here starts with the specials in its own
// Starsiege default configuration ($HH::DefComp, generated); the TAB menu's
// "Special components" page swaps any slot for another component. Choices
// apply on the NEXT spawn. Raw Starsiege parameters are generated into
// $HH::CompP0..3[id]; hit points / damage in them are /100 like everything else.
//
// Always-on (applied at spawn / on the systems tick):
//   ECM, Thermal Diffuser  sensor suppression (you vanish from enemy radar)
//   Shield Amplifier       shield strength x multiplier (1.25)
//   Shield Capacitor       +capacity/100 shield, +chargeRate/100 regen
//   Shield Modulator       front hits absorbed better, rear worse (FocusBoost)
//   Extra Battery          a reservoir (capacity) topped up from spare reactor
//                          output, feeding the main battery when it runs low
//   Reactor Capacitor      a reservoir that charges on its own (chargeRate/s)
//   NanoRepair             repairs the hull (rate/100 per s) for energy/s
//   Angel Life Support     the pilot ejects on the killing blow (any HERC)
//   Universal Ammo Pack    +50% mines
// Pack key (toggle):
//   Chameleon / Cuttlefish Cloak   fade out + radar silence, drains energy
//   Rocket Booster / Turbine Boost burst to boostRatio x top speed on fuel
// Carried but inert in Tribes (no equivalent system): Laser Targeting, Field
// Stabilizer, Agrav Generator.
//
// Exec'd from MechGame.cs. Ticked from MechHeat::visit.
//----------------------------------------------------------------------------

$HH::CloakDrain = 25;        // energy/s while cloaked (Starsiege table carries none usable)
$HH::BoostTick = 0.1;

//--- pack key (HHSystems datablocks live in HHSystemsData.cs, pre-preload) ----
function HHSystemsImage::onActivate(%player, %slot)
{
   HHComp::toggle(%player, 1);
}

function HHSystemsImage::onDeactivate(%player, %slot)
{
   HHComp::toggle(%player, 0);
   Player::trigger(%player, $BackpackSlot, false);
}

//--- which components this pilot carries --------------------------------------
// %cl.hhComp[i] = chosen id, "" = the chassis default for slot i.
function HHComp::resolve(%cl, %chassis, %i)
{
   %id = "";
   if (%cl > 0)
      %id = %cl.hhComp[%i];
   if (%id == "")
      %id = $HH::DefComp[%chassis, %i];
   return %id;
}

function HHComp::apply(%pl, %cl, %chassis)
{
   %pl.hhShieldMul = 1;
   %pl.hhShieldAdd = 0;
   %pl.hhShieldRateAdd = 0;
   %pl.hhFocus = 0;
   %pl.hhSupp = 0;
   %pl.hhNano = 0;          %pl.hhNanoDrain = 0;
   %pl.hhBattCap = 0;       %pl.hhBatt = 0;
   %pl.hhCapCap = 0;        %pl.hhCap = 0;        %pl.hhCapRate = 0;
   %pl.hhCloakId = "";      %pl.hhCloaked = 0;
   %pl.hhBoostId = "";      %pl.hhBoosting = 0;
   %pl.hhFuel = 0;          %pl.hhFuelCap = 0;
   %pl.hhLifeSupport = 0;
   %pl.hhAmmoPack = 0;
   %pl.hhEcm = "";          %pl.hhTherm = "";     %pl.hhJamT = 0;
   %names = "";
   %n = $HH::CompSlots[%chassis];
   if (%n == "") %n = 0;
   for (%i = 0; %i < %n; %i++) {
      %id = HHComp::resolve(%cl, %chassis, %i);
      if (%id == "")
         continue;
      %k = $HH::CompKind[%id];
      if (%names != "") %names = %names @ ", ";
      %names = %names @ $HH::CompName[%id];
      if (%k == "ecm")        { %pl.hhSupp = %pl.hhSupp + 20;  %pl.hhEcm = %id; }
      else if (%k == "thermal")  { %pl.hhSupp = %pl.hhSupp + 10;  %pl.hhTherm = %id; }
      else if (%k == "amplifier") %pl.hhShieldMul = %pl.hhShieldMul * $HH::CompP0[%id];
      else if (%k == "shieldcap") {
         %pl.hhShieldAdd = %pl.hhShieldAdd + $HH::CompP0[%id] / 100;
         %pl.hhShieldRateAdd = %pl.hhShieldRateAdd + $HH::CompP1[%id] / 100;
      }
      else if (%k == "modulator") %pl.hhFocus = $HH::CompP0[%id];
      else if (%k == "battery")   %pl.hhBattCap = %pl.hhBattCap + $HH::CompP0[%id];
      else if (%k == "capacitor") {
         %pl.hhCapCap = %pl.hhCapCap + $HH::CompP0[%id];
         %pl.hhCapRate = %pl.hhCapRate + $HH::CompP1[%id];
      }
      else if (%k == "nano") {
         %pl.hhNano = %pl.hhNano + $HH::CompP0[%id] / 100;
         %pl.hhNanoDrain = %pl.hhNanoDrain + $HH::CompP1[%id];
      }
      else if (%k == "lifesupport") %pl.hhLifeSupport = 1;
      else if (%k == "ammopack")    %pl.hhAmmoPack = 1;
      else if (%k == "cloak")       %pl.hhCloakId = %id;
      else if (%k == "booster") {
         %pl.hhBoostId = %id;
         %pl.hhFuelCap = $HH::CompP1[%id];
         %pl.hhFuel = %pl.hhFuelCap;
      }
   }
   // shields: class strength, then the components
   %pl.mmShieldMax = %pl.mmShieldMax * %pl.hhShieldMul + %pl.hhShieldAdd;
   %pl.mmShield = %pl.mmShieldMax;
   %pl.mmShieldRate = %pl.mmShieldRate + %pl.hhShieldRateAdd;
   %pl.hhBatt = %pl.hhBattCap;
   %pl.hhCap = %pl.hhCapCap;
   if (%pl.hhSupp > 0)
      Player::setSensorSupression(%pl, Player::getSensorSupression(%pl) + %pl.hhSupp);
   // the pack key needs a mounted pack only when something toggles
   if (%pl.hhCloakId != "" || %pl.hhBoostId != "") {
      Player::setItemCount(%pl, HHSystems, 1);
      Player::mountItem(%pl, HHSystems, $BackpackSlot);
   }
   %pl.hhCompNames = %names;
   if (%cl > 0 && %names != "")
      Client::sendMessage(%cl, 0, "SPECIAL COMPONENTS: " @ %names);
   // cockpit voice: power-up, then the jammer call-out if one is fitted
   HHVoice::say(%pl, "powerup");
   if (%pl.hhSupp >= 20)
      schedule("HHVoice::say(" @ %pl @ ", \"jam_engaged\");", 2.0, %pl);
   else if (%pl.hhSupp > 0)
      schedule("HHVoice::say(" @ %pl @ ", \"therm_dif_on\");", 2.0, %pl);
}

//--- systems tick (from MechHeat::visit) --------------------------------------
function HHComp::tick(%pl, %dt, %chassis)
{
   %e = GameBase::getEnergy(%pl);
   %max = %chassis.maxEnergy;
   // NanoRepair: hull repair paid for in energy
   if (%pl.hhNano > 0) {
      if (HHParts::damaged(%pl) && %e > %pl.hhNanoDrain * %dt) {
         HHParts::repair(%pl, %pl.hhNano * %dt);   // armour shares, then structure
         %e = %e - %pl.hhNanoDrain * %dt;
      }
   }
   // ECM / Thermal Diffuser (FOLLOWUP-RE 3): while on they draw ChargeRate energy
   // per second, and once a second every radar (ECM) / heat (diffuser) missile
   // aimed at this HERC within JammingDistance may lose its lock:
   // r1*r2 < JammingChance*(1 - d^2/R^2). Params: P1 rate, P2 distance, P3 chance.
   if (%pl.hhEcm != "" || %pl.hhTherm != "") {
      %pl.hhJamT = %pl.hhJamT + %dt;
      if (%pl.hhEcm != "")   %e = %e - $HH::CompP1[%pl.hhEcm] * %dt;
      if (%pl.hhTherm != "") %e = %e - $HH::CompP1[%pl.hhTherm] * %dt;
      if (%pl.hhJamT >= 1) {
         %pl.hhJamT = %pl.hhJamT - 1;
         if (%e > 0) {
            %jb = 0;
            if (%pl.hhEcm != "")
               %jb = %jb + Player::jamMissiles(%pl, 1, $HH::CompP2[%pl.hhEcm], $HH::CompP3[%pl.hhEcm]);
            if (%pl.hhTherm != "")
               %jb = %jb + Player::jamMissiles(%pl, 2, $HH::CompP2[%pl.hhTherm], $HH::CompP3[%pl.hhTherm]);
            if (%jb > 0 && $pref::starsiegeDiag)
               echo("[SSJAM] " @ %pl @ " broke " @ %jb @ " missile lock(s)");
         }
      }
   }
   // Reactor Capacitor charges itself; Extra Battery charges from spare output
   if (%pl.hhCapCap > 0) {
      %pl.hhCap = %pl.hhCap + %pl.hhCapRate * %dt;
      if (%pl.hhCap > %pl.hhCapCap) %pl.hhCap = %pl.hhCapCap;
   }
   if (%pl.hhBattCap > 0 && %e >= %max) {
      %pl.hhBatt = %pl.hhBatt + $HH::Reactor[%chassis] * %dt;
      if (%pl.hhBatt > %pl.hhBattCap) %pl.hhBatt = %pl.hhBattCap;
   }
   // reservoirs feed the main battery when it drops below half
   if (%e < %max * 0.5) {
      %want = %max * 0.5 - %e;
      if (%pl.hhCap > 0) {
         %t = %want;
         if (%t > %pl.hhCap) %t = %pl.hhCap;
         %pl.hhCap = %pl.hhCap - %t;  %e = %e + %t;  %want = %want - %t;
      }
      if (%want > 0 && %pl.hhBatt > 0) {
         %t = %want;
         if (%t > %pl.hhBatt) %t = %pl.hhBatt;
         %pl.hhBatt = %pl.hhBatt - %t;  %e = %e + %t;
      }
   }
   // cloak drain; drops when the reactor cannot pay
   if (%pl.hhCloaked == 1) {
      %e = %e - $HH::CloakDrain * %dt;
      if (%e <= 0) {
         %e = 0;
         HHComp::toggle(%pl, 0);
      }
   }
   // booster fuel recharges while idle
   if (%pl.hhBoostId != "" && %pl.hhBoosting != 1 && %pl.hhFuel < %pl.hhFuelCap) {
      %pl.hhFuel = %pl.hhFuel + $HH::CompP3[%pl.hhBoostId] * %dt;
      if (%pl.hhFuel > %pl.hhFuelCap) %pl.hhFuel = %pl.hhFuelCap;
   }
   if (%e > %max) %e = %max;
   if (%e < 0) %e = 0;
   GameBase::setEnergy(%pl, %e);
   HHComp::pads(%pl, %dt, %chassis);
}

//--- repair / ammo pads (Starsiege base pads) -----------------------------------
// Mission tails list them: $HH::Pad[i] = "heal|ammo x y z radius". Starsiege made
// you shut your reactor down on a pad; here a HERC standing (nearly) still on one
// is serviced: heal = hull + shields, ammo = mines + reactor battery.
$HH::PadHealRate = 0.03;     // fraction of hull per second
$HH::PadStillSpeed = 2.0;    // m/s

function HHComp::pads(%pl, %dt, %chassis)
{
   if ($HH::PadCount == "" || $HH::PadCount <= 0)
      return;
   %pos = GameBase::getPosition(%pl);
   %vel = Item::getVelocity(%pl);
   %spd = Vector::getDistance(%vel, "0 0 0");
   if (%spd > $HH::PadStillSpeed)
      return;
   for (%i = 0; %i < $HH::PadCount; %i++) {
      %p = $HH::Pad[%i];
      %c = getWord(%p, 1) @ " " @ getWord(%p, 2) @ " " @ getWord(%p, 3);
      if (Vector::getDistance(%pos, %c) > getWord(%p, 4) + 5)
         continue;
      %cl = Player::getClient(%pl);
      if (getWord(%p, 0) == "heal") {
         if (HHParts::damaged(%pl) || %pl.mmShield < %pl.mmShieldMax) {
            // live parts only: a destroyed part stays destroyed
            HHParts::repair(%pl, %pl.hhMaxTot * $HH::PadHealRate * %dt);
            %pl.mmShield = %pl.mmShieldMax * %pl.hhShdFrac;
            if (%pl.hhPadMsg != %i && %cl > 0)
               Client::sendMessage(%cl, 0, "Repair pad: repairing hull.~wrepair_ent.wav");
            %pl.hhPadMsg = %i;
         }
      }
      else {
         GameBase::setEnergy(%pl, %chassis.maxEnergy);
         if (%pl.hhMine != "") {
            HHComp::grantMines(%pl, %cl, %chassis);
            %pl.hhBatt = %pl.hhBattCap;
            %pl.hhCap = %pl.hhCapCap;
         }
         if (%pl.hhPadMsg != %i && %cl > 0)
            Client::sendMessage(%cl, 0, "Ammo pad: reactor and mines replenished.~wreload_complete.wav");
         %pl.hhPadMsg = %i;
      }
      return;
   }
   %pl.hhPadMsg = "";
}

//--- pack key -----------------------------------------------------------------
function HHComp::toggle(%pl, %on)
{
   %cl = Player::getClient(%pl);
   if (%pl.hhCloakId != "") {
      if (%on == 1 && %pl.hhCloaked != 1) {
         %pl.hhCloaked = 1;
         GameBase::startFadeOut(%pl);
         Player::setSensorSupression(%pl, Player::getSensorSupression(%pl) + 40);
         if (%cl > 0) Client::sendMessage(%cl, 0, $HH::CompName[%pl.hhCloakId] @ " engaged");
      }
      else if (%on == 0 && %pl.hhCloaked == 1) {
         %pl.hhCloaked = 0;
         GameBase::startFadeIn(%pl);
         Player::setSensorSupression(%pl, Player::getSensorSupression(%pl) - 40);
         if (%cl > 0) Client::sendMessage(%cl, 0, $HH::CompName[%pl.hhCloakId] @ " off");
      }
   }
   if (%pl.hhBoostId != "") {
      if (%on == 1 && %pl.hhBoosting != 1 && %pl.hhFuel > 0) {
         %pl.hhBoosting = 1;
         if (%cl > 0) Client::sendMessage(%cl, 0, $HH::CompName[%pl.hhBoostId] @ " firing");
         HHComp::boost(%pl);
      }
      else if (%on == 0)
         %pl.hhBoosting = 0;
   }
}

// Starsiege booster: boostRatio x top speed while fuel lasts (burnRate/s)
function HHComp::boost(%pl)
{
   if (%pl == "" || %pl <= 0 || Player::isDead(%pl) || %pl.hhBoosting != 1)
      return;
   if (%pl.hhFuel <= 0) {
      %pl.hhBoosting = 0;
      Player::trigger(%pl, $BackpackSlot, false);
      return;
   }
   %id = %pl.hhBoostId;
   %chassis = MechHeat::baseChassis(GameBase::getDataName(%pl));
   %pl.hhFuel = %pl.hhFuel - $HH::CompP2[%id] * $HH::BoostTick;
   %fwd = Vector::getFromRot(GameBase::getRotation(%pl), 1);
   %vel = Item::getVelocity(%pl);
   %along = getWord(%vel, 0) * getWord(%fwd, 0) + getWord(%vel, 1) * getWord(%fwd, 1);
   %target = %chassis.maxForwardSpeed * $HH::CompP0[%id];
   if (%along < %target) {
      %dv = %target - %along;
      %step = %chassis.maxForwardSpeed * 0.25;     // reach boost speed in ~0.4 s
      if (%dv > %step) %dv = %step;
      %k = %dv * $HH::Tons[%chassis];
      Player::applyImpulse(%pl, getWord(%fwd, 0) * %k @ " " @ getWord(%fwd, 1) * %k @ " 0");
   }
   schedule("HHComp::boost(" @ %pl @ ");", $HH::BoostTick, %pl);
}

//--- Shield Modulator: front/back focus --------------------------------------
// FocusBoost f: front hits cost the shield 1/(1+f), rear hits (1+f).
function HHComp::focus(%pl, %quadrant)
{
   if (%pl.hhFocus == "" || %pl.hhFocus <= 0)
      return 1;
   if (%quadrant == "front_left" || %quadrant == "front_right" || %quadrant == "middle_front")
      return 1 / (1 + %pl.hhFocus);
   if (%quadrant == "back_left" || %quadrant == "back_right" || %quadrant == "middle_back")
      return 1 + %pl.hhFocus;
   return 1;
}

//--- mines --------------------------------------------------------------------
// %cl.hhMineKind: "" (none, the default), "prox" or "arach". Opt-in: a pack takes
// a hardpoint, so the pilot gives up a gun for it (MechMayhem::grantLoadout drops
// it and records its size in %pl.hhMineSize, which sizes the pack).

// Rack index the mine pack replaces, or -1 for no mines: the rack's last gun
// (every rack gun fires in the chain, twins included -- MechGame.cs HHRack).
// A one-gun rack keeps its gun.
function HHComp::mineDrop(%cl, %chassis, %n)
{
   if (%cl <= 0 || %n < 2)
      return -1;
   if (%cl.hhMineKind != "prox" && %cl.hhMineKind != "arach")
      return -1;
   return %n - 1;
}

function HHComp::grantMines(%pl, %cl, %chassis)
{
   %size = %pl.hhMineSize;
   %pl.hhMine = "";
   %n = 0;
   if (%size != "") {
      if (%cl > 0 && %cl.hhMineKind == "arach") {
         %pl.hhMine = $HH::MineArach[%size];
         %n = $HH::MineArachCount[%size];
      }
      else {
         %pl.hhMine = $HH::MineProx[%size];
         %n = $HH::MineProxCount[%size];
      }
   }
   if (%pl.hhAmmoPack == 1)
      %n = floor(%n * 1.5);
   if (%pl.hhMine != "" && %n > 0)
      Player::setItemCount(%pl, MineAmmo, %n);
   else
      Player::setItemCount(%pl, MineAmmo, 0);
}

//--- TAB menu pages -----------------------------------------------------------
function HHComp::menu(%clientId)
{
   %chassis = %clientId.mmChassis;
   if (%chassis == "") {
      %pl = Client::getOwnedObject(%clientId);
      if (%pl != -1)
         %chassis = MechHeat::baseChassis(GameBase::getDataName(%pl));
   }
   if (%chassis == "" || $HH::CompSlots[%chassis] == "") {
      Client::sendMessage(%clientId, 1, "Pick a HERC in the garage first.");
      return;
   }
   %clientId.hhMenuChassis = %chassis;
   Client::buildMenu(%clientId, "Special components -- " @ %chassis @ " (next spawn)", "HHSys", true);
   %n = $HH::CompSlots[%chassis];
   for (%i = 0; %i < %n; %i++) {
      %id = HHComp::resolve(%clientId, %chassis, %i);
      %nm = "(empty)";
      if (%id != "") %nm = $HH::CompName[%id];
      %k = %i + 1;
      Client::addMenuItem(%clientId, %k @ "Slot " @ %k @ ": " @ %nm, "slot " @ %i);
   }
   Client::addMenuItem(%clientId, "0Restore Starsiege defaults", "reset");
   Client::addMenuItem(%clientId, "9Back", "back");
}

// One page of the component list for the slot being edited: rows 1-7 from list
// index %start, 8 = the next page (only when one exists), 9 = back to the slots.
function HHComp::slotPage(%clientId, %start)
{
   %k = %clientId.hhMenuSlot + 1;
   Client::buildMenu(%clientId, "Slot " @ %k @ " -- choose a component", "HHSys", true);
   %item = 0;
   %next = -1;
   for (%j = %start; %j < $HH::CompListCount; %j++) {
      %id = $HH::CompList[%j];
      if ($HH::CompKind[%id] == "none")
         continue;          // no Tribes equivalent -- not offered
      if (%item >= 7) {
         %next = %j;
         break;
      }
      Client::addMenuItem(%clientId, %item++ @ $HH::CompName[%id] @ "  (CV " @ $HH::CompCV[%id] @ ")", "set " @ %id);
   }
   if (%next != -1)
      Client::addMenuItem(%clientId, "8More...", "more " @ %next);
   Client::addMenuItem(%clientId, "9Back", "slots");
}

function processMenuHHSys(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %arg = getWord(%option, 1);
   %chassis = %clientId.hhMenuChassis;
   if (%opt == "reset") {
      for (%i = 0; %i < 8; %i++)
         %clientId.hhComp[%i] = "";
      Client::sendMessage(%clientId, 1, "Special components reset to the Starsiege defaults (next spawn).");
      return;
   }
   if (%opt == "back") {
      Game::menuRequest(%clientId);
      return;
   }
   if (%opt == "slots") {
      HHComp::menu(%clientId);
      return;
   }
   if (%opt == "slot") {
      %clientId.hhMenuSlot = %arg;
      HHComp::slotPage(%clientId, 0);
      return;
   }
   if (%opt == "more") {
      HHComp::slotPage(%clientId, %arg);
      return;
   }
   if (%opt == "set") {
      %clientId.hhComp[%clientId.hhMenuSlot] = %arg;
      %k = %clientId.hhMenuSlot + 1;
      Client::sendMessage(%clientId, 1, "Slot " @ %k @ ": " @ $HH::CompName[%arg] @ " (next spawn).");
      HHComp::menu(%clientId);   // back to the slot list, showing the new pick
      return;
   }
}

function HHComp::mineMenu(%clientId)
{
   Client::buildMenu(%clientId, "Mine pack (takes a gun's hardpoint)", "HHMines", true);
   Client::addMenuItem(%clientId, "1No mines (keep every gun)", "none");
   Client::addMenuItem(%clientId, "2Proximity mines (bigger blast)", "prox");
   Client::addMenuItem(%clientId, "3Arachnitron mines (more of them)", "arach");
   Client::addMenuItem(%clientId, "9Back", "back");
}

function processMenuHHMines(%clientId, %option)
{
   if (getWord(%option, 0) == "back") {
      Game::menuRequest(%clientId);
      return;
   }
   %kind = getWord(%option, 0);
   if (%kind == "none") {
      %clientId.hhMineKind = "";
      Client::sendMessage(%clientId, 1, "Mine pack: none, full weapon rack (next spawn).");
      return;
   }
   %clientId.hhMineKind = %kind;
   Client::sendMessage(%clientId, 1, "Mine pack: " @ %kind @ ", replaces your last gun (next spawn).");
}

echo("[HERC] HHComponents loaded (special components + mines).");
