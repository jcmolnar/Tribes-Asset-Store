exec("comchat.cs");

$pxModName = "Phobiax TRIBES Mod";
$PhobiaxInternalVersion = "v1.09";
$pxModURL = "http://phobiax.thisplacehere.com/";

$ixModName = "Insomniax TRIBES Mod";
$InsomniaxInternalVersion = "v0.9c";
$ixModURL = "http://www.insomniax.net/mods/";

$MODInfo = "<f2>" @ $pxModName @ " " @ $PhobiaxInternalVersion @ "\n" @ $pxModURL;

$SensorNetworkEnabled = true;
$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$TeamEnergy[-1] = $DefaultTeamEnergy;
$TeamEnergy[0] = $DefaultTeamEnergy;
$TeamEnergy[1] = $DefaultTeamEnergy;
$TeamEnergy[2] = $DefaultTeamEnergy;
$TeamEnergy[3] = $DefaultTeamEnergy;
$TeamEnergy[4] = $DefaultTeamEnergy;
$TeamEnergy[5] = $DefaultTeamEnergy;
$TeamEnergy[6] = $DefaultTeamEnergy;
$TeamEnergy[7] = $DefaultTeamEnergy;
$WaitThrowTime = 2;
$TeamEnergyCheat = 0;
$MaxTeamEnergy = 700000;
$flagToStandTime = 180;
$incTeamEnergy = 700;
$secTeamEnergy = 30;
$ItemRespawnTime = 30;
$RemoteAmmoEnergy = 2500;
$RemoteInvEnergy = 3000;
$TeammateSpending = -4000;
$WarnEnergyLow = 4000;
$InitialPlayerEnergy = 5000;
$MaxNumTurretsInBox = 2;
$TurretBoxMaxLength = 50;
$TurretBoxMaxWidth = 50;
$TurretBoxMaxHeight = 25;
$TurretBoxMinLength = 10;
$TurretBoxMinWidth = 10;
$TurretBoxMinHeight = 10;
$ForceFieldBoxMinLength = 10;
$ForceFieldBoxMinWidth = 10;
$ForceFieldBoxMinHeight = 10;
$SimTerrainObjectType = 1 << 1;
$SimInteriorObjectType = 1 << 2;
$SimPlayerObjectType = 1 << 7;
$MineObjectType = 1 << 26;
$MoveableObjectType = 1 << 22;
$VehicleObjectType = 1 << 29;
$StaticObjectType = 1 << 23;
$ItemObjectType = 1 << 21;
$ServerCheats = 0;
$TestCheats = 0;
$AutoRespawn = 0;

$deathMsg[$LandingDamageType, 0] = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1] = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2] = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3] = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0] = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1] = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2] = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3] = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0] = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1] = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2] = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3] = "%1 guns down %2.";
$deathMsg[$EnergyDamageType, 0] = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1] = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2] = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3] = "%2 ends up on the wrong side of a turret.";
$deathMsg[$PlasmaDamageType, 0] = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1] = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2] = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3] = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0] = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1] = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2] = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3] = "%2 falls victim to %1's Stormhammer.";
$deathMsg[$ShrapnelDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$LaserDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1] = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2] = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$MortarDamageType, 0] = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1] = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2] = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3] = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0] = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1] = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2] = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3] = "%2 meets %1's master blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$CrushDamageType, 0] = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1] = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2] = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3] = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0] = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1] = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2] = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3] = "%2 got too close to the exploding stuff.";
$deathMsg[$MissileDamageType, 0] = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1] = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2] = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3] = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$MagneticDamageType, 0] = "%1 ripps %2 apart.";
$deathMsg[$MagneticDamageType, 1] = "%2 Felt %1's magnetic Personality.";
$deathMsg[$MagneticDamageType, 2] = "%2 was torn apart by %1's MAG Gun.";
$deathMsg[$MagneticDamageType, 3] = "%1 Zapped %2 into Oblivion.";
$deathMsg[$EMPDamageType, 0] = "%2 was Killed by %1's EMP Blast.";
$deathMsg[$EMPDamageType, 1] = "%2 was Killed by %1's EMP Blast.";
$deathMsg[$EMPDamageType, 2] = "%2 was Killed by %1's EMP Blast.";
$deathMsg[$EMPDamageType, 3] = "%2 was Killed by %1's EMP Blast.";
$deathMsg[$RocketDamageType, 0] = "%1 shoots %2 down.";
$deathMsg[$RocketDamageType, 1] = "%2 was scorched by %1's Rocket.";
$deathMsg[$RocketDamageType, 2] = "%1 shoots %2 down.";
$deathMsg[$RocketDamageType, 3] = "%2 was scorched by %1's Rocket.";
$deathMsg[$RifleDamageType, 0] = "%2 is Clueless after %1's Sniper Shot.";
$deathMsg[$RifleDamageType, 1] = "%1 punches a hole through %2's armor.";
$deathMsg[$RifleDamageType, 2] = "%2 becomes a victim of %1's IX-2000.";
$deathMsg[$RifleDamageType, 3] = "%2 REALLY never saw it coming from %1.";
$deathMsg[$BomberDamageType, 0] = "%1 rain of bombs obliterated %2.";
$deathMsg[$BomberDamageType, 1] = "%1 bombed the crap outa %2.";
$deathMsg[$BomberDamageType, 2] = "%2 couldn't escape %1's bombing run.";
$deathMsg[$BomberDamageType, 3] = "%1 over ran %2 with a string of bombs.";
$deathMsg[$FlamerDamageType, 0] = "%1 roasted %2 to a nice golden brown.";
$deathMsg[$FlamerDamageType, 1] = "%2 was left with a burning sensation after %4 encounter with %1.";
$deathMsg[$FlamerDamageType, 2] = "%1 overcooked %2.";
$deathMsg[$FlamerDamageType, 3] = "%1 incinerated %2 with %3 Pyro-Torch.";
$deathMsg[$FlamerOverHeatType, 0] = "%1 Overheated %2 with his Pyro-Torch.";
$deathMsg[$FlamerOverHeatType, 1] = "%2 should have ran from %1's hot advances.";
$deathMsg[$FlamerOverHeatType, 2] = "%2's Rocket Booster couldn't handle %1's Pyro-Torch.";
$deathMsg[$FlamerOverHeatType, 3] = "%2 Exploded from the heat of %1's Pyro-Torch.";
$deathMsg[$BoosterDamageType, 0] = "%2 was caught in %1's Backwash.";
$deathMsg[$BoosterDamageType, 1] = "%2 was caught in %1's Backwash.";
$deathMsg[$BoosterDamageType, 2] = "%2 was caught in %1's Backwash.";
$deathMsg[$BoosterDamageType, 3] = "%2 was caught in %1's Backwash.";
$deathMsg[$FlakDamageType, 0] = "%2 was downed by a Flak Cannon.";
$deathMsg[$FlakDamageType, 1] = "%2 caught a little too much Flak.";
$deathMsg[$FlakDamageType, 2] = "%2 heard someone yell PULL!";
$deathMsg[$FlakDamageType, 3] = "%2 caught a little too much Flak.";
$deathMsg[$ShotgunDamageType, 0] = "%2 caught a chest full of %1's shotgun blast.";
$deathMsg[$ShotgunDamageType, 1] = "%1 filled %2 full of shotgun pellets.";
$deathMsg[$ShotgunDamageType, 2] = "%2 went down after %1's vicious shotgun assault.";
$deathMsg[$ShotgunDamageType, 3] = "%2 lets freedom ring with a shotgun blast from %1.";
$deathMsg[$LowWarheadDamageType, 0] = "%1 reaped Vengeance upon %2";
$deathMsg[$LowWarheadDamageType, 1] = "%2 felt %1's hand of Vengeance";
$deathMsg[$LowWarheadDamageType, 2] = "%2 succumbed to %1's Vengeance";
$deathMsg[$LowWarheadDamageType, 3] = "%1's Vengeance anihiliated %2";
$deathMsg[$MedWarheadDamageType, 0] = "%1 reaped Vengeance upon %2";
$deathMsg[$MedWarheadDamageType, 1] = "%2 felt %1's hand of Vengeance";
$deathMsg[$MedWarheadDamageType, 2] = "%2 succumbed to %1's Vengeance";
$deathMsg[$MedWarheadDamageType, 3] = "%1's Vengeance anihiliated %2";
$deathMsg[$HighWarheadDamageType, 0] = "%1 reaped Vengeance upon %2";
$deathMsg[$HighWarheadDamageType, 1] = "%2 felt %1's hand of Vengeance";
$deathMsg[$HighWarheadDamageType, 2] = "%2 succumbed to %1's Vengeance";
$deathMsg[$HighWarheadDamageType, 3] = "%1's Vengeance anihiliated %2";
$deathMsg[$EMPWarheadDamageType, 0] = "%1 reaped Vengeance upon %2";
$deathMsg[$EMPWarheadDamageType, 1] = "%2 felt %1's hand of Vengeance";
$deathMsg[$EMPWarheadDamageType, 2] = "%2 succumbed to %1's Vengeance";
$deathMsg[$EMPWarheadDamageType, 3] = "%1's Vengeance anihiliated %2";
$deathMsg[$PhalanxxDamageType, 0] = "%1 unleashed %3 Phalanxx on %2.";
$deathMsg[$PhalanxxDamageType, 1] = "%2 was seriously torn up by %1's Phalanxx Cannon.";
$deathMsg[$PhalanxxDamageType, 2] = "%1 leaned into %2 with %3 Phalanxx.";
$deathMsg[$PhalanxxDamageType, 3] = "%1 force fed %2 an extra helping of lead.";
$deathMsg[$ELFTurretDamageType, 0] = "%2 gets zapped by an ELF Turret.";
$deathMsg[$ELFTurretDamageType, 1] = "%2 gets a nasty jolt.";
$deathMsg[$ELFTurretDamageType, 2] = "%2 gets a real shock out of an ELF Turret.";
$deathMsg[$ELFTurretDamageType, 3] = "An ELF Turret short-circuits %2's systems.";
$deathMsg[$DetonationDamageType, 0] = "%1 didn't recycle and it cost %2's %4 Life.";
$deathMsg[$DetonationDamageType, 1] = "%2 gets caught by %1's discarded Booster.";
$deathMsg[$DetonationDamageType, 2] = "%2 didnt want %1's old booster to go to waste.";
$deathMsg[$DetonationDamageType, 3] = "%2 is going to keep clear of %1's litter from now on.";
$deathMsg[$TurretDamageType, 0] = "%1's turret ripped up %2.";
$deathMsg[$TurretDamageType, 1] = "%2 is chewed to pieces by %1's turret.";
$deathMsg[$TurretDamageType, 2] = "%2 walked into %1's turret.";
$deathMsg[$TurretDamageType, 3] = "%2 ends up on the wrong side of %1's turret.";
$deathMsg[$SentryDamageType, 0] = "%1's Sentry ripped up %2.";
$deathMsg[$SentryDamageType, 1] = "%2 is chewed to pieces by %1's Sentry.";
$deathMsg[$SentryDamageType, 2] = "%2 walked into %1's Sentry.";
$deathMsg[$SentryDamageType, 3] = "%2 ends up on the wrong side of %1's Sentry.";
$deathMsg[$AvengerDamageType, 0] = "%1's Avenger blasted %2 out of the sky.";
$deathMsg[$AvengerDamageType, 1] = "%2 is torn up by %1's Avenger.";
$deathMsg[$AvengerDamageType, 2] = "%2 didn't spot %1's Avenger soon enough.";
$deathMsg[$AvengerDamageType, 3] = "%2 was downed by %1's Avenger.";
$deathMsg[-2,0] = "%1 ends it all.";
$deathMsg[-2,1] = "%1 takes %2 own life.";
$deathMsg[-2,2] = "%1 kills %2 own dumb self.";
$deathMsg[-2,3] = "%1 decides to see what the afterlife is like.";

$deathMsg[$FighterDamageType, 0] = "%2 was pelted full of energy by %1 from %3 fighter.";
$deathMsg[$FighterDamageType, 1] = "%1's fighter sends death from above to %2.";
$deathMsg[$FighterDamageType, 2] = "%2 was struck be lightning generated by %1";
$deathMsg[$FighterDamageType, 3] = "%2 looked up, but it wasn't a bird, it was %1 in %3 fighter.";
$deathMsg[$EnergyRepeaterDamageType, 0] = "%1 pumps %2 full of energy bolts.";
$deathMsg[$EnergyRepeaterDamageType, 1] = "%1 gives %2 an overdose of energy.";
$deathMsg[$EnergyRepeaterDamageType, 2] = "%2 was riddled with %1's energy repeater burns.";
$deathMsg[$EnergyRepeaterDamageType, 3] = "%1 guns down %2 with his energy repeater.";
$deathMsg[$TazerBeamDamageType, 0] = "%1 electrocutes %2.";
$deathMsg[$TazerBeamDamageType, 1] = "%2 got a real charge out %1's Tazer.";
$deathMsg[$TazerBeamDamageType, 2] = "%1 fries %2's ass with a Tazer.";
$deathMsg[$TazerBeamDamageType, 3] = "%1 snuck up on %2 and zapped %4 good with a Tazer.";
$deathMsg[$TazerBoltDamageType, 0] = "%1 electrocutes %2.";
$deathMsg[$TazerBoltDamageType, 1] = "%2 didn't expect that bolt from %1's Tazer.";
$deathMsg[$TazerBoltDamageType, 2] = "%2 got a real charge out %1's Tazer.";
$deathMsg[$TazerBoltDamageType, 3] = "%2 thought %1's Tazer was in the other mode...";
$deathMsg[$RetributionDamageType, 0] = "%1 got %3 own justice for %2's vicious assault.";
$deathMsg[$RetributionDamageType, 1] = "%2 just realized killing %1 was a bad idea.";
$deathMsg[$RetributionDamageType, 2] = "%1 demanded retribution from %2 and was paid in full.";
$deathMsg[$RetributionDamageType, 3] = "%1 took %3 revenge on %2 from beyond the grave.";
$deathMsg[$FlareDamageType, 0] = "%2 was killed by %1's Flare.";
$deathMsg[$FlareDamageType, 1] = "%2 was killed by %1's Flare.";
$deathMsg[$FlareDamageType, 2] = "%2 was killed by %1's Flare.";
$deathMsg[$FlareDamageType, 3] = "%2 was killed by %1's Flare.";
$deathMsg[$InjectorDamageType, 0] = "%2 had a fatal reaction to %1's Injector.";
$deathMsg[$InjectorDamageType, 1] = "%2 had a fatal reaction to %1's Injector.";
$deathMsg[$InjectorDamageType, 2] = "%2 had a fatal reaction to %1's Injector.";
$deathMsg[$InjectorDamageType, 3] = "%2 had a fatal reaction to %1's Injector.";
$deathMsg[$NaniteDamageType, 0] = "%1's Nanites ate through %2's armor.";
$deathMsg[$NaniteDamageType, 1] = "%1's Nanites found the cream filling inside %2.";
$deathMsg[$NaniteDamageType, 2] = "%2 just didn't know that %1's little Nanites were eating away at %4 bones.";
$deathMsg[$NaniteDamageType, 3] = "%1 injected Nanites into %2 and the little buggers hollowed out %4 insides.";
$deathMsg[$SentinelDamageType, 0] = "%2 stepped on %1's Sentinel, so it took %4 worthless life away.";
$deathMsg[$SentinelDamageType, 1] = "%2 didn't see %1's Sentinel hanging on the wall.";
$deathMsg[$SentinelDamageType, 2] = "%1's Sentinel obliterates %2.";
$deathMsg[$SentinelDamageType, 3] = "%1's Sentinel didn't like the look %2's face.";
$deathMsg[$DecimatorDamageType, 0] = "%2 ran toward the light, but it was the wrong kind of light.";
$deathMsg[$DecimatorDamageType, 1] = "%2 was Decimated!";
$deathMsg[$DecimatorDamageType, 2] = "%2 was blown away by the power of a Decimator.";
$deathMsg[$DecimatorDamageType, 3] = "%2 was Decimated!";
$deathMsg[$DoomsdayDamageType, 0] = "%1 doomed %2 to oblivion";
$deathMsg[$DoomsdayDamageType, 1] = "%1 blew %2 the hell up!!";
$deathMsg[$DoomsdayDamageType, 2] = "%1 prophesied %2's Doomsday";
$deathMsg[$DoomsdayDamageType, 3] = "%1's very slow Doomsday Missile caught up with %2";
$deathMsg[$ConcussionMineDamageType, 0] = "%1's Concussion Mine shoved %2 a bit too hard.";
$deathMsg[$ConcussionMineDamageType, 1] = "%1's Concussion Mine shoved %2 a bit too hard.";
$deathMsg[$ConcussionMineDamageType, 2] = "%1's Concussion Mine shoved %2 a bit too hard.";
$deathMsg[$ConcussionMineDamageType, 3] = "%1's Concussion Mine shoved %2 a bit too hard.";
$deathMsg[$EMPMineDamageType, 0] = "%2 was killed by %1's EMP Mine, everyone point and laugh!";
$deathMsg[$EMPMineDamageType, 1] = "%2 was killed by %1's EMP Mine, everyone point and laugh!";
$deathMsg[$EMPMineDamageType, 2] = "%2 was killed by %1's EMP Mine, everyone point and laugh!";
$deathMsg[$EMPMineDamageType, 3] = "%2 was killed by %1's EMP Mine, everyone point and laugh!";
$deathMsg[$CloakedMineDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$CloakedMineDamageType, 1] = "%2 just didn't hear that ping from %1's Cloaked Mine.";
$deathMsg[$CloakedMineDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$CloakedMineDamageType, 3] = "%2 never saw it coming from %1, because it was invisible.";
$deathMsg[$BoomBoxFizzleDamageType, 0] = "%2 died because of %1's Disarmed Boom Box.";
$deathMsg[$BoomBoxFizzleDamageType, 1] = "%2 died because of %1's Disarmed Boom Box.";
$deathMsg[$BoomBoxFizzleDamageType, 2] = "%2 died because of %1's Disarmed Boom Box.";
$deathMsg[$BoomBoxFizzleDamageType, 3] = "%2 died because of %1's Disarmed Boom Box.";
$deathMsg[$BoomBoxNukeDamageType, 0] = "%1 surpised %2 with a very large Boom in a very little Box.";
$deathMsg[$BoomBoxNukeDamageType, 1] = "%2 didn't know there was a bomb in that crate %1 left behind.";
$deathMsg[$BoomBoxNukeDamageType, 2] = "It wasn't %4's birthday, but %2 got a nasty present from %1 anyway.";
$deathMsg[$BoomBoxNukeDamageType, 3] = "%2 must've been too close when %1 detonated %3 Boom Box.";
$numDeathMsgs = 4;

$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = MagGun;
$spawnBuyList[2] = PlasmaGun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = "";


function remotePlayMode(%clientId)
{
  if(!%clientId.guiLock)
  {
    remoteSCOM(%clientId, -1);
    Client::setGuiMode(%clientId, $GuiModePlay);
  }
}


function remoteCommandMode(%clientId)
{
  if(!%clientId.guiLock)
  {
    remoteSCOM(%clientId, -1);
    if(%clientId.observerMode != "pregame") checkControlUnmount(%clientId);
    Client::setGuiMode(%clientId, $GuiModeCommand);
  }
}


function remoteInventoryMode(%clientId)
{
  if(!%clientId.guiLock && !Observer::isObserver(%clientId))
  {
    remoteSCOM(%clientId, -1);
    Client::setGuiMode(%clientId, $GuiModeInventory);
  }
}


function remoteObjectivesMode(%clientId)
{
  if(!%clientId.guiLock)
  {
    remoteSCOM(%clientId, -1);
    Client::setGuiMode(%clientId, $GuiModeObjectives);
  }
}


function remoteScoresOn(%clientId)
{
  if(!%clientId.menuMode) Game::menuRequest(%clientId);
}


function remoteScoresOff(%clientId)
{
  Client::cancelMenu(%clientId);
}


function remoteToggleCommandMode(%clientId)
{
  if (Client::getGuiMode(%clientId) != $GuiModeCommand) remoteCommandMode(%clientId);
  else remotePlayMode(%clientId);
}


function remoteToggleInventoryMode(%clientId)
{
  if (Client::getGuiMode(%clientId) != $GuiModeInventory) remoteInventoryMode(%clientId);
  else remotePlayMode(%clientId);
}


function remoteToggleObjectivesMode(%clientId)
{
  if (Client::getGuiMode(%clientId) != $GuiModeObjectives) remoteObjectivesMode(%clientId);
  else remotePlayMode(%clientId);
}


function Time::getMinutes(%simTime)
{
  return floor(%simTime / 60);
}


function Time::getSeconds(%simTime)
{
  return %simTime % 60;
}


function Game::pickRandomSpawn(%team)
{
  %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
  %count = Group::objectCount(%group);
  if(!%count) return -1;
  %spawnIdx = floor(getRandom() * (%count - 0.1));
  %value = %count;
  for(%i = %spawnIdx; %i < %value; %i++)
  {
    %set = newObject("set",SimSet);
    %obj = Group::getObject(%group, %i);
    if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
    {
      deleteObject(%set);
      return %obj;
    }
    if(%i == %count - 1)
    {
      %i = -1;
      %value = %spawnIdx;
    }
    deleteObject(%set);
  }
  return false;
}


function Game::pickStartSpawn(%team)
{
  %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
  %count = Group::objectCount(%group);
  if(!%count) return -1;
  %spawnIdx = $lastTeamSpawn[%team] + 1;
  if(%spawnIdx >= %count) %spawnIdx = 0;
  $lastTeamSpawn[%team] = %spawnIdx;
  return Group::getObject(%group, %spawnIdx);
}


function Game::pickTeamSpawn(%team, %respawn)
{
  if(%respawn) return Game::pickRandomSpawn(%team);
  else
  {
    %spawn = Game::pickStartSpawn(%team);
    if(%spawn == -1) return Game::pickRandomSpawn(%team);
    return %spawn;
  }
}


function Game::pickObserverSpawn(%client)
{
  %group = nameToID("MissionGroup\\ObserverDropPoints");
  %count = Group::objectCount(%group);
  if(%group == -1 || !%count) %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
  %count = Group::objectCount(%group);
  if(%group == -1 || !%count) %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
  %count = Group::objectCount(%group);
  if(%group == -1 || !%count) return -1;
  %spawnIdx = %client.lastObserverSpawn + 1;
  if(%spawnIdx >= %count) %spawnIdx = 0;
  %client.lastObserverSpawn = %spawnIdx;
  return Group::getObject(%group, %spawnIdx);
}


function UpdateClientTimes(%time)
{
  for(%cl = Client::getFirst();
  %cl != -1;
  %cl = Client::getNext(%cl)) remoteEval(%cl, "setTime", -%time);
}


function Game::notifyMatchStart(%time)
{
  messageAll(0, "Match starts in " @ %time @ " seconds.");
  UpdateClientTimes(%time);
}


function Game::startMatch()
{
  $TeamsRandomized = "";
  $matchStarted = true;
  $missionStartTime = getSimTime();
  messageAll(0, "Match started.");
  Game::resetScores();
  %numTeams = getNumTeams();
  for(%i = 0; %i < %numTeams; %i = %i + 1)
  {
    if($TeamEnergy[%i] != "Infinite") schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
  }
  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
  {
    if(%cl.observerMode == "pregame")
    {
      %cl.observerMode = "";
      Client::setControlObject(%cl, Client::getOwnedObject(%cl));
    }
    Game::refreshClientScore(%cl);
  }
  Game::checkTimeLimit();
}


function Game::pickPlayerSpawn(%clientId, %respawn)
{
  return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}


function Game::playerSpawn(%clientId, %respawn)
{
  if(!$ghosting) return false;
  Client::clearItemShopping(%clientId);
  %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
  if(!%respawn)
  {
    bottomprint(%clientId, "<jc>" @ $MODInfo @ "\n\n<f0>Mission: <f1>" @ $missionName @ " <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.\n\n<f2>SERVER: " @ Insomniax_ServerLvlTxt() @ "\nCLIENT: " @ Insomniax_ClientLvlTxt(), 5);
  }
  if(%spawnMarker)
  {
    %clientId.guiLock = "";
    %clientId.dead = "";
    if(%spawnMarker == -1)
    {
      %spawnPos = "0 0 300";
      %spawnRot = "0 0 0";
    }
    else
    {
      %spawnPos = GameBase::getPosition(%spawnMarker);
      %spawnRot = GameBase::getRotation(%spawnMarker);
    }
    if(!String::ICompare(Client::getGender(%clientId), "Male")) %armor = "larmor";
    else %armor = "lfemale";
    %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
    echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
    if(%pl != -1)
    {
      GameBase::setTeam(%pl, Client::getTeam(%clientId));
      Client::setOwnedObject(%clientId, %pl);
      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
      if($matchStarted) Client::setControlObject(%clientId, %pl);
      else
      {
        %clientId.observerMode = "pregame";
        Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
        Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
      }
    }
    return true;
  }
  else
  {
    Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later");
    return false;
  }
}


function Game::playerSpawned(%pl, %clientId, %armor)
{
  if(%clientId.custom) Client::setSkin(%clientId, $Client::info[%clientId, 0]);
  else Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
  Insomniax_onRespawn(%clientId,%pl);
  %clientId.spawn = 1;
  %max = getNumItems();
  for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
  {
    buyItem(%clientId,%item);
    if(%item.className == Weapon) %clientId.spawnWeapon = %item;
  }
  %clientId.spawn = "";
  if(%clientId.spawnWeapon != "")
  {
    Player::useItem(%pl,%clientId.spawnWeapon);
    %clientId.spawnWeapon = "";
  }
}


function Game::autoRespawn(%client)
{
  if(%client.dead == 1) Game::playerSpawn(%client, "true");
}


function onServerGhostAlwaysDone()
{
}


function Game::initialMissionDrop(%clientId)
{
  Client::setGuiMode(%clientId, $GuiModePlay);
  if($Server::TourneyMode)
  {
    if($TeamsRandomized)
    {
      %teamName = getTeamName(Client::getTeam(%clientId));
      bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\n<f0>You were randomly assigned to the " @ %teamName @ "<f1>\nTeam damage is " @ isEnabled($Server::TeamDamageScale) @ "\n\nPress FIRE when ready.", 0);
      %clientId.notready = true;
      %clientId.notreadyCount = "";
    }
    else GameBase::setTeam(%clientId, -1);
  }
  else
  {
    if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
    {
      %clientId.observerMode = "observerOrbit";
      %clientId.guiLock = "";
      Observer::jump(%clientId);
      return;
    }
    %numTeams = getNumTeams();
    %curTeam = Client::getTeam(%clientId);
    if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) ) Game::assignClientTeam(%clientId);
  }
  Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
  %camSpawn = Game::pickObserverSpawn(%clientId);
  Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), GameBase::getRotation(%camSpawn), true, true);
  if(Client::getTeam(%clientId) == -1)
  {
    %clientId.observerMode = "pickingTeam";
    if($Server::TourneyMode && ($matchStarted || $matchStarting))
    {
      %clientId.observerMode = "observerFly";
      return;
    }
    else if($Server::TourneyMode)
    {
      if($Server::TeamDamageScale) %td = "ENABLED";
      else %td = "DISABLED";
      bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
    }
    Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
    Client::addMenuItem(%clientId, "0Observe", -2);
    Client::addMenuItem(%clientId, "1Automatic", -1);
    for(%i = 0; %i < getNumTeams(); %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
    %clientId.justConnected = "";
  }
  else
  {
    Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
    if(%clientId.justConnected)
    {
      centerprint(%clientId, "<jc>" @ $ModInfo @ "\n\n<f1>" @ $Server::JoinMOTD, 0);
      %clientId.observerMode = "justJoined";
      %clientId.justConnected = "";
    }
    else if(%clientId.observerMode == "justJoined")
    {
      centerprint(%clientId, "");
      %clientId.observerMode = "";
      Game::playerSpawn(%clientId, false);
    }
    else
    {
      if($TeamsRandomized) Game::playerSpawn(%clientId, true);
      else Game::playerSpawn(%clientId, false);
    }
  }
  if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite") $TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
  %clientId.teamEnergy = 0;
}


function processMenuInitialPickTeam(%clientId, %team)
{
  if($Server::TourneyMode && $matchStarted) %team = -2;
  if(%team == -2)
  {
    Observer::enterObserverMode(%clientId);
  }
  if(%team == -1)
  {
    Game::assignClientTeam(%clientId);
    %team = Client::getTeam(%clientId);
  }
  if(%team != -2)
  {
    GameBase::setTeam(%clientId, %team);
    if($TeamEnergy[%team] != "Infinite") $TeamEnergy[%team] += $InitialPlayerEnergy;
    %clientId.teamEnergy = 0;
    Client::setControlObject(%clientId, -1);
    Game::playerSpawn(%clientId, false);
  }
  if($Server::TourneyMode && !$CountdownStarted)
  {
    if(%team != -2)
    {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
      %clientId.notreadyCount = "";
    }
    else
    {
      bottomprint(%clientId, "", 0);
      %clientId.notready = "";
      %clientId.notreadyCount = "";
    }
  }
}


function Game::ForceTourneyMatchStart()
{
  %playerCount = 0;
  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
  {
    if(%cl.observerMode == "pregame") %playerCount++;
  }
  if(%playerCount == 0) return;
  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
  {
    if(%cl.observerMode == "pickingTeam") processMenuInitialPickTeam(%cl, -2);
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    {
      %cl.notready = "";
      %cl.notreadyCount = "";
      bottomprint(%cl, "", 0);
    }
  }
  Server::Countdown(30);
}


function Game::CheckTourneyMatchStart()
{
  if($CountdownStarted || $matchStarted) return;
  %playerCount = 0;
  %notReadyCount = 0;
  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
  {
    if(%cl.observerMode == "pickingTeam")
    {
      %notReady[%notReadyCount] = %cl;
      %notReadyCount++;
    }
    else if(%cl.observerMode == "pregame")
    {
      if(%cl.notready)
      {
        %notReady[%notReadyCount] = %cl;
        %notReadyCount++;
      }
      else %playerCount++;
    }
  }
  if(%notReadyCount)
  {
    if(%notReadyCount == 1) MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
    else if(%notReadyCount < 4)
    {
      for(%i = 0; %i < %notReadyCount - 2; %i++) %str = Client::getName(%notReady[%i]) @ ", " @ %str;
      %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";
      MessageAll(0, %str);
    }
    return;
  }
  if(%playerCount != 0)
  {
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    {
      %cl.notready = "";
      %cl.notreadyCount = "";
      bottomprint(%cl, "", 0);
    }
    Server::Countdown(30);
  }
}


function Game::checkTimeLimit()
{
  $timeLimitReached = false;
  if(!$Server::timeLimit)
  {
    schedule("Game::checkTimeLimit();", 60);
    return;
  }
  %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
  if(%curTimeLeft <= 0 && $matchStarted)
  {
    echo("GAME: Timelimit reached.");
    $timeLimitReached = true;
    Server::nextMission();
  }
  else
  {
    schedule("Game::checkTimeLimit();", 20);
    UpdateClientTimes(%curTimeLeft);
  }
}


function Game::resetScores(%client)
{
  if(%client == "")
  {
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    {
      %cl.scoreKills = 0;
      %cl.scoreDeaths = 0;
      %cl.ratio = 0;
      %cl.score = 0;
    }
  }
  else
  {
    %client.scoreKills = 0;
    %client.scoreDeaths = 0;
    %client.ratio = 0;
    %client.score = 0;
  }
}


function remoteSetArmor(%player, %armorType)
{
  if ($ServerCheats)
  {
    checkMax(Player::getClient(%player),%armorType);
    Player::setArmor(%player, %armorType);
  }
  else if($TestCheats)
  {
    Player::setArmor(%player, %armorType);
  }
}


function Game::onPlayerConnected(%playerId)
{
  %playerId.scoreKills = 0;
  %playerId.scoreDeaths = 0;
  %playerId.score = 0;
  %playerId.justConnected = true;
  $menuMode[%playerId] = "None";
  Game::refreshClientScore(%playerId);
}


function Game::assignClientTeam(%playerId)
{
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
    for(%i = 0; %i < %numTeams; %i = %i + 1) %numTeamPlayers[%i] = 0;
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
      if( (%numTeamPlayers[%i] < %leastPlayers) || ( (%numTeamPlayers[%i] == %leastPlayers) && ($teamScore[%i] < $teamScore[%leastTeam] ) ))
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


function Client::onKilled(%playerId, %killerId, %damageType, %overheat)
{
  echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
  %playerId.guiLock = true;
  Client::setGuiMode(%playerId, $GuiModePlay);
  if(!String::ICompare(Client::getGender(%playerId), "Male"))
  {
    %playerGender = "his";
  }
  else
  {
    %playerGender = "her";
  }
  %ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
  %victimName = Client::getName(%playerId);
  if(!%killerId)
  {
    if(%damageType == $MineDamageType || %damageType == $CloakedMineDamageType || %damageType == $ConcussionMineDamageType || %damageType == $EMPMineDamageType)
    {
      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      %playerId.scoreDeaths++;
    }
  }
  if(%killerId == %playerId)
  {
    if(%damageType == $BoosterDamageType) messageAll(0, %victimName @ " Overheated " @ %playerGender @ " Rocket Booster.", $DeathMessageMask);
    else if (%damageType == $FlamerOverHeatType) messageAll(0, %victimName @ " was playing with fire and Overheated " @ %playerGender @ " Rocket Booster.", $DeathMessageMask);
    else if (%damageType == $ImpactDeathType) messageAll(0, %victimName @ "'s Rocket Booster exploded on Impact.", $DeathMessageMask);
    else if (%damageType == $DetonationDamageType) messageAll(0, %victimName @ " discarded " @ %playerGender @ " Rocket Booster only to be killed by it anyway.", $DeathMessageMask);
    else if (%damageType == $BoomBoxNukeDamageType) messageAll(0, %victimName @ " was standing way too close to " @ %playerGender @ " own Boom Box when it detonated.", $DeathMessageMask);
    else if (%damageType == $NaniteDamageType)
    {
      if(%playerGender == "his") %playerGender = "him";
      messageAll(0, %victimName @ " infected " @ %playerGender @ "self with Nanites and they finally devoured " @ %playerGender @ " whole.", $DeathMessageMask);
      if(%playerGender == "him") %playerGender = "his";
    }
    else
    {
      %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
    }
    %playerId.scoreDeaths++;
    %playerId.score--;
    Game::refreshClientScore(%playerId);
  }
  else
  {
    if(!String::ICompare(Client::getGender(%killerId), "Male"))
    {
      %killerGender = "his";
    }
    else
    {
      %killerGender = "her";
    }
    if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
    {
      if(%damageType == $BoosterDamageType) messageAll(0,strcat(Client::getName(%killerId),"'s Backwash Overheated ",%victimName,"'s Rocket Booster."), $DeathMessageMask);
      else if(%overheat) messageAll(0,strcat(Client::getName(%killerId)," Overheated ",%victimName,"'s Rocket Booster."), $DeathMessageMask);
      else if(%damageType != $MineDamageType) messageAll(0, strcat(Client::getName(%killerId)," mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
      else messageAll(0, strcat(Client::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
      bottomprint(%playerId, "<jc><f1>You have just been\n<f2>TEAM KILLED <f1>by<f2> " @ Client::getName(%killerId), 10);
      bottomprint(%killerId, "<jc><f2>YOU<f1> have just <f2>TEAM KILLED\n " @ Client::getName(%playerId), 10);
      Insomniax_setTeamKill(%playerId, %killerId);
      %killerId.scoreDeaths++;
      %killerId.score--;
      Game::refreshClientScore(%killerId);
    }
    else
    {
      if(!%killerid)
      {
        if((%damageType == $MineDamageType) || (%damageType == $CloakMineDamageType) || (%damageType == $ConcussionMineDamageType) || (%damageType == $EMPMineDamageType)) %damageType = $DebrisDamageType;
        if((%damageType == $TurretDamageType) || (%damageType == $SentryDamageType) || (%damageType == $SentinelDamageType)) %damageType = $EnergyDamageType;
        if(%damageType == $AvengerDamageType) %damageType = $MissileDamageType;
      }
      if(%overheat)
      {
        if((!%killerId) || (%killerId > 6000))
        {
          if(%damageType == $DebrisDamageType) messageAll(0,strcat("A nearby explosion overheated ",%victimName,"'s Rocket Booster."), $DeathMessageMask);
          else messageAll(0,strcat("A turret overheated ",%victimName,"'s Rocket Booster."), $DeathMessageMask);
          %playerId.scoreDeaths++;
        }
        else messageAll(0,strcat(Client::getName(%killerId)," Overheated ",%victimName,"'s Rocket Booster."), $DeathMessageMask);
      }
      else
      {
        %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
        messageAll(0, %obitMsg, $DeathMessageMask);
      }
      %killerId.scoreKills++;
      %playerId.scoreDeaths++;
      %killerId.score++;
      Game::refreshClientScore(%killerId);
      Game::refreshClientScore(%playerId);
    }
  }
  Game::clientKilled(%playerId, %killerId);
}


function Game::clientKilled(%playerId, %killerId)
{
}


function Client::leaveGame(%clientId)
{
}


function Player::enterMissionArea(%player)
{
  echo("Player " @ %player @ " entered the mission area.");
}


function Player::leaveMissionArea(%player)
{
  echo("Player " @ %player @ " left the mission area.");
}


function GameBase::getHeatFactor(%this)
{
  return 0.0;
}
