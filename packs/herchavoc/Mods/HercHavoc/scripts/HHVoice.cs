//----------------------------------------------------------------------------
// Herc Havoc -- Starsiege cockpit voice.
//
// Starsiege's onboard computer calls out shield, damage, power and mission
// events (datSfx IDCV_* tags). Human HERCs get the human voice, Cybrid HERCs
// (cy_* / mg_* / pl_* chassis) the Cybrid "cy_" voice. Played privately to the
// pilot as a sound-only message ("~w<file>" prints no chat line -- the same
// route the engine's own hit cue uses). WAVs ship in Mods\HercHavoc\Starsiege.
//
// Each call-out re-arms only after its condition clears (hysteresis), and never
// repeats inside $HH::VoiceGap seconds.
//----------------------------------------------------------------------------

$HH::VoiceGap = 6;

function HHVoice::isCybrid(%chassis)
{
   %p = String::getSubStr(%chassis, 4, 2);     // "Herc" + faction
   return (%p == "Cy" || %p == "Mg" || %p == "Pl");
}

// %key = the human file stem (shields_crit, internal_dam, ...)
function HHVoice::say(%pl, %key)
{
   %cl = Player::getClient(%pl);
   if (%cl <= 0 || !MechEject::isHumanClient(%cl))
      return;
   %now = getSimTime();
   if (%pl.hhVoiceAt[%key] != "" && %now - %pl.hhVoiceAt[%key] < $HH::VoiceGap)
      return;
   %pl.hhVoiceAt[%key] = %now;
   %f = %key;
   if (HHVoice::isCybrid(MechHeat::baseChassis(GameBase::getDataName(%pl))))
      %f = "cy_" @ %key;
   Client::sendMessage(%cl, 0, "~w" @ %f @ ".wav");
}

// to a client directly (end of match -- the pilot may be dead)
function HHVoice::sayClient(%cl, %key, %cybrid)
{
   if (%cl <= 0)
      return;
   %f = %key;
   if (%cybrid == 1)
      %f = "cy_" @ %key;
   Client::sendMessage(%cl, 0, "~w" @ %f @ ".wav");
}

// called from the systems tick: shield / hull / energy thresholds
function HHVoice::watch(%pl, %chassis)
{
   // shields critical below 25%, re-arms above 50%
   if (%pl.mmShieldMax > 0) {
      %f = %pl.mmShield / %pl.mmShieldMax;
      if (%f < 0.25 && %pl.hhVShield != 1) {
         %pl.hhVShield = 1;
         HHVoice::say(%pl, "shields_crit");
      }
      else if (%f > 0.5)
         %pl.hhVShield = 0;
   }
   // internal damage once the hull is half gone
   %d = GameBase::getDamageLevel(%pl) / %chassis.maxDamage;
   if (%d > 0.5 && %pl.hhVHull != 1) {
      %pl.hhVHull = 1;
      HHVoice::say(%pl, "internal_dam");
   }
   else if (%d < 0.3)
      %pl.hhVHull = 0;
   // low energy below 15%, re-arms above 40%
   %e = GameBase::getEnergy(%pl) / %chassis.maxEnergy;
   if (%e < 0.15 && %pl.hhVEnergy != 1) {
      %pl.hhVEnergy = 1;
      HHVoice::say(%pl, "low_energy");
   }
   else if (%e > 0.4)
      %pl.hhVEnergy = 0;
}

echo("[HERC] HHVoice loaded (Starsiege cockpit voice).");
