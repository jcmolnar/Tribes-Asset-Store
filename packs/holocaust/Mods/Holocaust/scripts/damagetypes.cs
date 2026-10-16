//PORT-OFF: $ModList = "Holocaust v3.5";

//=============================================================================================
# Damage Types

$ImpactDamageType      = -1;
$LandingDamageType     =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
$EMPDamageType         = 14;
$SniperDamageType      = 15;
$MethaneDamageType     = 16;
$ShotgunDamageType     = 17;
$MassDamageType        = 18;
$PBWDamageType         = 19;
$GaussDamageType       = 20;
$SniperXDamageType     = 21;
$MBDamageType          = 23;
$FusionDamageType      = 24;
$FlierBombDamageType   = 26;
$PulseDamageType       = 27;
$MBHeatDamageType      = 28;
$NullDamageType        = 29;
$TractorDamageType        = 30;
$six66                 = -3;

$deathMsg[$LandingDamageType, 0]      = "%1 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%1 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%1 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%1 fall down go boom.";

$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%1 says, ''Hey %2, you scratched my paint job!''";
$deathMsg[$ImpactDamageType, 2] 	= "%1 shows %2 his new ride";
$deathMsg[$ImpactDamageType, 3] 	= "%1 shoves %2 into his jet thrust.";

$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 turns %2 into swiss cheese.";
$deathMsg[$BulletDamageType, 3]      = "%2 felt like being Holy.";

$deathMsg[$EnergyDamageType, 0]      = "%1 wonders ''hey, what's this thing do?''";
$deathMsg[$EnergyDamageType, 1]      = "%1 got hit with a blast of energy.";
$deathMsg[$EnergyDamageType, 2]      = "%1 came face to face with an energy blast, and was later found dead.";
$deathMsg[$EnergyDamageType, 3]      = "%1 figures out what that pretty light was.";

$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 asks %2, Crispy Critter Anyone?";
$deathMsg[$PlasmaDamageType, 2] 	 = "%1 asks %2, ''Need a light?''";
$deathMsg[$PlasmaDamageType, 3] 	 = "%2 saw %3 life before his eyes, or at least %1's glowing plasma.";

$deathMsg[$ExplosionDamageType, 0]   = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's Stormhammer.";

$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";

$deathMsg[$LaserDamageType, 0]       = "%2 finally realised what that red dot was.";
$deathMsg[$LaserDamageType, 1]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 2]       = "%2 has a hole fried through %4 head by %1's laser.";
$deathMsg[$LaserDamageType, 3]       = "%1 Lightly Amplified %2's Stimulated Emission of Radiation.";

$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1 blew %2 all to pieces.";

$deathMsg[$BlasterDamageType, 0]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 1]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 2]     = "%2 meets %1's master blaster.";
$deathMsg[$BlasterDamageType, 3] 	 = "%2 couldn't steer clear of %1's Blaster.";

$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, 4] = "%2 caught a few volts.";

$deathMsg[$CrushDamageType, 0]	 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]	 = "%2 gets caught in the machinery.";
$deathMsg[$CrushDamageType, 2]	 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 3]	 = "%2 got a great deal for pizza.";

$deathMsg[$DebrisDamageType, 0]	 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]	 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]	 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]	 = "%2 got too close to the exploding stuff.";

$deathMsg[$MissileDamageType, 0]	 = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1] 	 = "%2 gets buttraped by a warhead.";
$deathMsg[$MissileDamageType, 2]  	 = "%2 played dodgeball with a rocket...And lost.";
$deathMsg[$MissileDamageType, 3] 	 = "%2 rides the rocket.";

$deathMsg[$MineDamageType, 0]	       = "%2 stepped on a toe-popper.";
$deathMsg[$MineDamageType, 1] 	 = "%1 gives %2 a piece of %3 mine.";
$deathMsg[$MineDamageType, 2] 	 = "%1 reminds %2 that a mine is a terrible thing to waste.";
$deathMsg[$MineDamageType, 3] 	 = "%2 is blown to bits by %1's mine.";

$deathMsg[$SniperDamageType, 0]	 ="%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1]      ="%1 fells %2 with a sniper shot.";
$deathMsg[$SniperDamageType, 2] 	 ="%1 Tells %2 One Less Brown Stain In This World";
$deathMsg[$SniperDamageType, 3]	 ="%2 stayed in %1's crosshairs for too long.";

$deathMsg[$PBWDamageType, 0]	       = "%1 punched a hole through %2 with %4 Proton  Beam.";
$deathMsg[$PBWDamageType, 1]	       = "%2 understands why electricity ane other particles hurt when %1 shot %3.";
$deathMsg[$PBWDamageType, 2]	       = "%1's big blue nasty decimates %2.";
$deathMsg[$PBWDamageType, 3]	       = "%2 is blown to bits by %1's Particle Beam.";

$deathMsg[$ShotgunDamageType, 0]	 = "%1's Ion Cannon electricutes %2's vital systems.";
$deathMsg[$ShotgunDamageType, 1]	 = "%1 gives %2 a lesson in ionic chemistry.";
$deathMsg[$ShotgunDamageType, 2] 	 = "%2 caught a chest full of %1's atom stripper."; 
$deathMsg[$ShotgunDamageType, 3] 	 = "%2 lets freedom ring with a ion blast from %1."; 

$deathMsg[$MassDamageType, 0]        = "%2 Says: The mass went up my ass!";
$deathMsg[$MassDamageType, 1]        = "%2 says: Feels Good, May I have another?";
$deathMsg[$MassDamageType, 2]        = "%1 gives %2 a Mass Driver Blast";
$deathMsg[$MassDamageType, 3]        = "%1 blows %2's head clean off with a Mass Driver blast!";

$deathMsg[$GaussDamageType, 0]       = "%1 chunks apart %2 with %3 Gauss Cannon.";
$deathMsg[$GaussDamageType, 1]       = "%1 pillages %2 with %3 Gauss.";
$deathMsg[$GaussDamageType, 2]       = "%1 blows %2 to smithereens.";
$deathMsg[$GaussDamageType, 3]       = "%1 turns %2 into pieces swiss cheese.";

$deathMsg[$MethaneDamageType, 0]	 = "%1 gives %2 a lethal injection.";
$deathMsg[$MethaneDamageType, 1]    	 = "%2 dies with green flesh open.";
$deathMsg[$MethaneDamageType, 2]         = "%1 shoots %2 with %4 Poison dart and %2 sings: ''Killing me softly with %3 dart....''";
$deathMsg[$MethaneDamageType, 3] 	 = "%2 falls victim to a deadly virus.";

$deathMsg[$MBDamageType, 0]      	 = "%2 is blown away.";
$deathMsg[$MBDamageType, 1]      	 = "%1 gives %2 an overload of shear energy.";
$deathMsg[$MBDamageType, 2]      	 = "%1 fills %2 with a hyperactive blast.";
$deathMsg[$MBDamageType, 3]      	 = "%1 lets %4 Mitzi Blast eat %2 alive.";

$deathMsg[$FusionDamageType, 0]	 = "%1 electrified %2 with %3 Fusion Cannon.";
$deathMsg[$FusionDamageType, 1]	 = "%2 fused instead of fizzed.";
$deathMsg[$FusionDamageType, 2]	 = "%2 gets a fusion reactor overload.";
$deathMsg[$FusionDamageType, 3]	 = "%2 took in too much energy.";

$deathMsg[$FlierBombDamageType, 0]	 = "%2 got killed by a bomb.";
$deathMsg[$FlierBombDamageType, 1]	 = "%2 got bombed by %1.";
$deathMsg[$FlierBombDamageType, 2]	 = "%1 let his bombs loose on %2.";
$deathMsg[$FlierBombDamageType, 3] 	 = "%1 bombed the crap outa %2."; 

$deathMsg[$SniperXDamageType, 0]	 ="%1 adds %2 to %3list of sniper victims.";
$deathMsg[$SniperXDamageType, 1]      ="%1 fells %2 with a sniper shot.";
$deathMsg[$SniperXDamageType, 2] 	 ="%1 Tells %2 One Less Brown Stain In This World";
$deathMsg[$SniperXDamageType, 3]	 ="%2 stayed in %1's crosshairs for too long.";

$deathMsg[$PulseDamageType, 0]	 = "%1's Annihilator Blast vaporizes %2.";
$deathMsg[$PulseDamageType, 1]	 = "%2 has been reduced to his componet atoms by %1's Annihilator blast.";
$deathMsg[$PulseDamageType, 2]	 = "%1 used the Force on %2.";
$deathMsg[$PulseDamageType, 3]	 = "%1 sends %2 clear through the next dimension.";

$deathMsg[$TractorDamageType, 0] = "%2 gets ripped apart.";
$deathMsg[$TractorDamageType, 1] = "%2 gets torn into pieces.";
$deathMsg[$TractorDamageType, 2] = "%2 gets pulled apart.";
$deathMsg[$TractorDamageType, 3] = "%2 came apart at the seams.";

$deathMsg[$ProtronDamageType, 0] = "%1 riddles %2 with %4 Protron.";
$deathMsg[$ProtronDamageType, 1] = "%2 gets capped by %1's Protron.";
$deathMsg[$ProtronDamageType, 2] = "%1's Protron genetically rearranges %2 into a mutating radiated hump.";
$deathMsg[$ProtronDamageType, 3] = "%2 came apart at the seams with outgoing Protrons from %1.";

$deathMsg[$ShotgunDamageType, 0] = "%1's Compressed Zica Blast phases %2 out of existance.";
$deathMsg[$ShotgunDamageType, 1] = "%2 gets capped by %1's Zica Cannon.";
$deathMsg[$ShotgunDamageType, 2] = "%1 punches a gaping hole in %2 with a Zica Blast.";
$deathMsg[$ShotgunDamageType, 3] = "%2 became quantized by %1's Zica Blast.";


$deathMsg[-2,0]                                          = "%1 wanted to make sure %2 gun was loaded.";
$deathMsg[-2,1]                                          = "%1 was last heard yelling 'Hail To The King baby!''"; 
$deathMsg[-2,2]                                          = "%1 shows off %2 mad dying skills.";
$deathMsg[-2,3]                                          = "%1 says: No Fun Looking out my Ass!";

$deathMsg[-3,0]                                          = "%2 wanted to make sure %2 gun was loaded.";
$deathMsg[-3,1]                                          = "%2 was last heard yelling 'Hail To The King baby!''"; 
$deathMsg[-3,2]                                          = "%2 shows off %2 mad dying skills.";
$deathMsg[-3,3]                                          = "%2 says: No Fun Looking out my Ass!";

$numDeathMsgs = 4;

//#############################################################################################

//=========Damage defs here

$DamageScale[larmor, $PulseDamageType] = 1.0;
$DamageScale[marmor, $PulseDamageType] = 1.0;
$DamageScale[harmor, $PulseDamageType] = 1.0;
$DamageScale[lfemale, $PulseDamageType] = 1.0;
$DamageScale[mfemale, $PulseDamageType] = 1.0;
$DamageScale[MagIonM, $PulseDamageType] = 1.0;
$DamageScale[MECH, $PulseDamageType] = 1.0;
$DamageScale[MagIonF, $PulseDamageType] = 1.0;
$DamageScale[sarmor, $PulseDamageType] = 1.0;
$DamageScale[sfemale, $PulseDamageType] = 1.0;
$DamageScale[mearmor, $PulseDamageType] = 1.0;
$DamageScale[ebarmor, $PulseDamageType] = 1.0;
$DamageScale[ebfemale, $PulseDamageType] = 1.0;

$DamageScale[Scout, $PulseDamageType] = 1.0;
$DamageScale[EscapePod, $PulseDamageType] = 1.0;
$DamageScale[Jetfire, $PulseDamageType] = 1.0;
$DamageScale[LAPC, $PulseDamageType] = 1.0;
$DamageScale[HAPC, $PulseDamageType] = 1.0;
$DamageScale[ScouterMissile, $PulseDamageType] = 1.0;
$DamageScale[EOMissile, $PulseDamageType] = 1.0;
$DamageScale[SurveyDrone, $PulseDamageType] = 1.0;
$DamageScale[Retaliator, $PulseDamageType] = 1.0;
$DamageScale[Interceptor, $PulseDamageType] = 1.0;
$DamageScale[HoverTank, $PulseDamageType] = 1.0;
$DamageScale[Explorer, $PulseDamageType] = 1.0;
$DamageScale[Avenger, $PulseDamageType] = 1.0;
$DamageScale[StarFighter, $PulseDamageType] = 1.0;
$DamageScale[Icarus, $PulseDamageType] = 1.0;
$DamageScale[Skyranger, $PulseDamageType] = 1.0;
$DamageScale[StarHammer, $PulseDamageType] = 1.0;
$DamageScale[SkyCutter, $PulseDamageType] = 1.0;
$DamageScale[Arwing, $PulseDamageType] = 1.0;

$DamageScale[larmor, $SniperXDamageType] = 0.8;
$DamageScale[marmor, $SniperXDamageType] = 0.8;
$DamageScale[harmor, $SniperXDamageType] = 0.8;
$DamageScale[lfemale, $SniperXDamageType] = 0.8;
$DamageScale[mfemale, $SniperXDamageType] = 0.8;
$DamageScale[MagIonM, $SniperXDamageType] = 0.80;
$DamageScale[MECH, $SniperXDamageType] = 0.8;
$DamageScale[MagIonF, $SniperXDamageType] = 0.80;
$DamageScale[sarmor, $SniperXDamageType] = 0.8;
$DamageScale[sfemale, $SniperXDamageType] = 0.8;
$DamageScale[mearmor, $SniperXDamageType] = 0.8;
$DamageScale[ebarmor, $SniperXDamageType] = 0.80;
$DamageScale[ebfemale, $SniperXDamageType] = 0.80;

$DamageScale[Scout, $SniperXDamageType] = 1.0;
$DamageScale[EscapePod, $SniperXDamageType] = 1.0;
$DamageScale[Jetfire, $SniperXDamageType] = 1.0;
$DamageScale[LAPC, $SniperXDamageType] = 1;
$DamageScale[HAPC, $SniperXDamageType] = 2;
$DamageScale[ScouterMissile, $SniperXDamageType] = 1.0;
$DamageScale[EOMissile, $SniperXDamageType] = 1.0;
$DamageScale[SurveyDrone, $SniperXDamageType] = 1.0;
$DamageScale[Retaliator, $SniperXDamageType] = 1.0;
$DamageScale[Interceptor, $SniperXDamageType] = 2.0;
$DamageScale[HoverTank, $SniperXDamageType] = 1.57;
$DamageScale[Explorer, $SniperXDamageType] = 1.0;
$DamageScale[Avenger, $SniperXDamageType] = 1.0;
$DamageScale[StarFighter, $SniperXDamageType] = 1.0;
$DamageScale[Icarus, $SniperXDamageType] = 1.0;
$DamageScale[Skyranger, $SniperXDamageType] = 1.0;
$DamageScale[StarHammer, $SniperXDamageType] = 1.0;
$DamageScale[SkyCutter, $SniperXDamageType] = 1.0;
$DamageScale[Arwing, $SniperXDamageType] = 1.0;

$DamageScale[larmor, $FlierBombDamageType] = 1.0;
$DamageScale[marmor, $FlierBombDamageType] = 1.0;
$DamageScale[harmor, $FlierBombDamageType] = 1.0;
$DamageScale[lfemale, $FlierBombDamageType] = 1.0;
$DamageScale[mfemale, $FlierBombDamageType] = 1.0;
$DamageScale[MagIonM, $FlierBombDamageType] = 1;
$DamageScale[MECH, $FlierBombDamageType] = 0.95;
$DamageScale[MagIonF, $FlierBombDamageType] = 1;
$DamageScale[sarmor, $FlierBombDamageType] = 1.0;
$DamageScale[sfemale, $FlierBombDamageType] = 1.0;
$DamageScale[mearmor, $FlierBombDamageType] = 1.0;
$DamageScale[ebarmor, $FlierBombDamageType] = 1.0;
$DamageScale[ebfemale, $FlierBombDamageType] = 1.0;

$DamageScale[Scout, $FlierBombDamageType] = 1.0;
$DamageScale[EscapePod, $FlierBombDamageType] = 1.0;
$DamageScale[Jetfire, $FlierBombDamageType] = 1.0;
$DamageScale[LAPC, $FlierBombDamageType] = 1.0;
$DamageScale[HAPC, $FlierBombDamageType] = 1.0;
$DamageScale[ScouterMissile, $FlierBombDamageType] = 1.0;
$DamageScale[EOMissile, $FlierBombDamageType] = 1.0;
$DamageScale[SurveyDrone, $FlierBombDamageType] = 1.0;
$DamageScale[Retaliator, $FlierBombDamageType] = 1.0;
$DamageScale[Interceptor, $FlierBombDamageType] = 1.0;
$DamageScale[HoverTank, $FlierBombDamageType] = 1.0;
$DamageScale[Explorer, $FlierBombDamageType] = 1.0;
$DamageScale[Avenger, $FlierBombDamageType] = 1.0;
$DamageScale[StarFighter, $FlierBombDamageType] = 1.0;
$DamageScale[Icarus, $FlierBombDamageType] = 1.0;
$DamageScale[Skyranger, $FlierBombDamageType] = 1.0;
$DamageScale[StarHammer, $FlierBombDamageType] = 1.0;
$DamageScale[SkyCutter, $FlierBombDamageType] = 1.0;
$DamageScale[Arwing, $FlierBombDamageType] = 1.0;

$DamageScale[larmor, $FlameDamageType] = 1.0;
$DamageScale[marmor, $FlameDamageType] = 1.0;
$DamageScale[harmor, $FlameDamageType] = 1.0;
$DamageScale[lfemale, $FlameDamageType] = 1.0;
$DamageScale[mfemale, $FlameDamageType] = 1.0;
$DamageScale[MagIonM, $FlameDamageType] = 1.0;
$DamageScale[MECH, $FlameDamageType] = 1.0;
$DamageScale[MagIonF, $FlameDamageType] = 1.0;
$DamageScale[sarmor, $FlameDamageType] = 1.0;
$DamageScale[sfemale, $FlameDamageType] = 1.0;
$DamageScale[mearmor, $FlameDamageType] = 1.0;
$DamageScale[ebarmor, $FlameDamageType] = 1.0;
$DamageScale[ebfemale, $FlameDamageType] = 1.0;

$DamageScale[Scout, $FlameDamageType] = 1.0;
$DamageScale[EscapePod, $FlameDamageType] = 1.0;
$DamageScale[Jetfire, $FlameDamageType] = 1.0;
$DamageScale[LAPC, $FlameDamageType] = 1.0;
$DamageScale[HAPC, $FlameDamageType] = 1.0;
$DamageScale[ScouterMissile, $FlameDamageType] = 1.0;
$DamageScale[EOMissile, $FlameDamageType] = 1.0;
$DamageScale[SurveyDrone, $FlameDamageType] = 1.0;
$DamageScale[Retaliator, $FlameDamageType] = 1.0;
$DamageScale[Interceptor, $FlameDamageType] = 1.0;
$DamageScale[HoverTank, $FlameDamageType] = 1.0;
$DamageScale[Explorer, $FlameDamageType] = 1.0;
$DamageScale[Avenger, $FlameDamageType] = 1.0;
$DamageScale[StarFighter, $FlameDamageType] = 1.0;
$DamageScale[Icarus, $FlameDamageType] = 1.0;
$DamageScale[Skyranger, $FlameDamageType] = 1.0;
$DamageScale[StarHammer, $FlameDamageType] = 1.0;
$DamageScale[SkyCutter, $FlameDamageType] = 1.0;
$DamageScale[Arwing, $FlameDamageType] = 1.0;

$DamageScale[larmor, $FusionDamageType] = 1.0;
$DamageScale[marmor, $FusionDamageType] = 1.0;
$DamageScale[harmor, $FusionDamageType] = 1.0;
$DamageScale[lfemale, $FusionDamageType] = 1.0;
$DamageScale[mfemale, $FusionDamageType] = 1.0;
$DamageScale[MagIonM, $FusionDamageType] = 1;
$DamageScale[MECH, $FusionDamageType] = 1;
$DamageScale[MagIonF, $FusionDamageType] = 1.0;
$DamageScale[sarmor, $FusionDamageType] = 1.0;
$DamageScale[sfemale, $FusionDamageType] = 1.0;
$DamageScale[mearmor, $FusionDamageType] = 1.0;
$DamageScale[ebarmor, $FusionDamageType] = -0.1;
$DamageScale[ebfemale, $FusionDamageType] = -0.1;

$DamageScale[Scout, $FusionDamageType] = 1.0;
$DamageScale[EscapePod, $FusionDamageType] = 1.0;
$DamageScale[Jetfire, $FusionDamageType] = 1.0;
$DamageScale[LAPC, $FusionDamageType] = 1.0;
$DamageScale[HAPC, $FusionDamageType] = 1.0;
$DamageScale[ScouterMissile, $FusionDamageType] = 1.0;
$DamageScale[EOMissile, $FusionDamageType] = 1.0;
$DamageScale[SurveyDrone, $FusionDamageType] = 1.0;
$DamageScale[Retaliator, $FusionDamageType] = 1.0;
$DamageScale[Interceptor, $FusionDamageType] = 1.0;
$DamageScale[HoverTank, $FusionDamageType] = 1.0;
$DamageScale[Explorer, $FusionDamageType] = 1.0;
$DamageScale[Avenger, $FusionDamageType] = 1.0;
$DamageScale[StarFighter, $FusionDamageType] = 1.0;
$DamageScale[Icarus, $FusionDamageType] = 1.0;
$DamageScale[Skyranger, $FusionDamageType] = 1.0;
$DamageScale[StarHammer, $FusionDamageType] = 1.0;
$DamageScale[SkyCutter, $FusionDamageType] = 1.0;
$DamageScale[Arwing, $FusionDamageType] = 1.0;

$DamageScale[larmor, $MBHeatDamageType] = 1.0;
$DamageScale[marmor, $MBHeatDamageType] = 1.0;
$DamageScale[harmor, $MBHeatDamageType] = 1.0;
$DamageScale[lfemale, $MBHeatDamageType] = 1.0;
$DamageScale[mfemale, $MBHeatDamageType] = 1.0;
$DamageScale[MagIonM, $MBHeatDamageType] = 1;
$DamageScale[MECH, $MBHeatDamageType] = -0.1;
$DamageScale[MagIonF, $MBHeatDamageType] = 1;
$DamageScale[sarmor, $MBHeatDamageType] = 1.0;
$DamageScale[sfemale, $MBHeatDamageType] = 1.0;
$DamageScale[mearmor, $MBHeatDamageType] = 1.0;
$DamageScale[ebarmor, $MBHeatDamageType] = 1.0;
$DamageScale[ebfemale, $MBHeatDamageType] = 1.0;

$DamageScale[Scout, $MBHeatDamageType] = 1.0;
$DamageScale[EscapePod, $MBHeatDamageType] = 1.0;
$DamageScale[Jetfire, $MBHeatDamageType] = 1.0;
$DamageScale[LAPC, $MBHeatDamageType] = 1.0;
$DamageScale[HAPC, $MBHeatDamageType] = 1.0;
$DamageScale[ScouterMissile, $MBHeatDamageType] = 1.0;
$DamageScale[EOMissile, $MBHeatDamageType] = 1.0;
$DamageScale[SurveyDrone, $MBHeatDamageType] = 1.0;
$DamageScale[Retaliator, $MBHeatDamageType] = 1.0;
$DamageScale[Interceptor, $MBHeatDamageType] = 1.0;
$DamageScale[HoverTank, $MBHeatDamageType] = 1.0;
$DamageScale[Explorer, $MBHeatDamageType] = 1.0;
$DamageScale[Avenger, $MBHeatDamageType] = 1.0;
$DamageScale[StarFighter, $MBHeatDamageType] = 1.0;
$DamageScale[Icarus, $MBHeatDamageType] = 1.0;
$DamageScale[Skyranger, $MBHeatDamageType] = 1.0;
$DamageScale[StarHammer, $MBHeatDamageType] = 1.0;
$DamageScale[SkyCutter, $MBHeatDamageType] = 1.0;
$DamageScale[Arwing, $MBHeatDamageType] = 1.0;

$DamageScale[larmor, $MBDamageType] = 1.0;
$DamageScale[marmor, $MBDamageType] = 1.0;
$DamageScale[harmor, $MBDamageType] = 1.0;
$DamageScale[lfemale, $MBDamageType] = 1.0;
$DamageScale[mfemale, $MBDamageType] = 1.0;
$DamageScale[MagIonM, $MBDamageType] = 1;
$DamageScale[MECH, $MBDamageType] = 1;
$DamageScale[MagIonF, $MBDamageType] = 1;
$DamageScale[sarmor, $MBDamageType] = 1.0;
$DamageScale[sfemale, $MBDamageType] = 1.0;
$DamageScale[mearmor, $MBDamageType] = 1.0;
$DamageScale[ebarmor, $MBDamageType] = 1.0;
$DamageScale[ebfemale, $MBDamageType] = 1.0;

$DamageScale[Scout, $MBDamageType] = 1.0;
$DamageScale[EscapePod, $MBDamageType] = 1.0;
$DamageScale[Jetfire, $MBDamageType] = 1.0;
$DamageScale[LAPC, $MBDamageType] = 1.0;
$DamageScale[HAPC, $MBDamageType] = 1.0;
$DamageScale[ScouterMissile, $MBDamageType] = 1.0;
$DamageScale[EOMissile, $MBDamageType] = 1.0;
$DamageScale[SurveyDrone, $MBDamageType] = 1.0;
$DamageScale[Retaliator, $MBDamageType] = 1.0;
$DamageScale[Interceptor, $MBDamageType] = 1.0;
$DamageScale[HoverTank, $MBDamageType] = 1.0;
$DamageScale[Explorer, $MBDamageType] = 1.0;
$DamageScale[Avenger, $MBDamageType] = 1.0;
$DamageScale[StarFighter, $MBDamageType] = 1.0;
$DamageScale[Icarus, $MBDamageType] = 1.0;
$DamageScale[Skyranger, $MBDamageType] = 1.0;
$DamageScale[StarHammer, $MBDamageType] = 1.0;
$DamageScale[SkyCutter, $MBDamageType] = 1.0;
$DamageScale[Arwing, $MBDamageType] = 1.0;

$DamageScale[larmor, $VertigoDamageType] = 1.0;
$DamageScale[marmor, $VertigoDamageType] = 1.0;
$DamageScale[harmor, $VertigoDamageType] = 1.0;
$DamageScale[lfemale, $VertigoDamageType] = 1.0;
$DamageScale[mfemale, $VertigoDamageType] = 1.0;
$DamageScale[MagIonM, $VertigoDamageType] = 1.0;
$DamageScale[MagIonF, $VertigoDamageType] = 1.0;
$DamageScale[MECH, $VertigoDamageType] = 1.0;
$DamageScale[sarmor, $VertigoDamageType] = 1.0;
$DamageScale[sfemale, $VertigoDamageType] = 1.0;
$DamageScale[mearmor, $VertigoDamageType] = 1.0;
$DamageScale[ebarmor, $VertigoDamageType] = 1.0;
$DamageScale[ebfemale, $VertigoDamageType] = 1.0;

$DamageScale[Scout, $VertigoDamageType] = 1.0;
$DamageScale[EscapePod, $VertigoDamageType] = 1.0;
$DamageScale[Jetfire, $VertigoDamageType] = 1.0;
$DamageScale[LAPC, $VertigoDamageType] = 1.0;
$DamageScale[HAPC, $VertigoDamageType] = 1.0;
$DamageScale[ScouterMissile, $VertigoDamageType] = 1.0;
$DamageScale[EOMissile, $VertigoDamageType] = 1.0;
$DamageScale[SurveyDrone, $VertigoDamageType] = 1.0;
$DamageScale[Retaliator, $VertigoDamageType] = 1.0;
$DamageScale[Interceptor, $VertigoDamageType] = 1.0;
$DamageScale[HoverTank, $VertigoDamageType] = 1.0;
$DamageScale[Explorer, $VertigoDamageType] = 1.0;
$DamageScale[Avenger, $VertigoDamageType] = 1.0;
$DamageScale[StarFighter, $VertigoDamageType] = 1.0;
$DamageScale[Icarus, $VertigoDamageType] = 1.0;
$DamageScale[Skyranger, $VertigoDamageType] = 1.0;
$DamageScale[StarHammer, $VertigoDamageType] = 1.0;
$DamageScale[SkyCutter, $VertigoDamageType] = 1.0;
$DamageScale[Arwing, $VertigoDamageType] = 1.0;

$DamageScale[larmor, $VulcanDamageType] = 1.0;
$DamageScale[marmor, $VulcanDamageType] = 1.0;
$DamageScale[harmor, $VulcanDamageType] = 1.0;
$DamageScale[lfemale, $VulcanDamageType] = 1.0;
$DamageScale[mfemale, $VulcanDamageType] = 1.0;
$DamageScale[MagIonM, $VulcanDamageType] = 1.0;
$DamageScale[MagIonF, $VulcanDamageType] = 1.0;
$DamageScale[MECH, $VulcanDamageType] = 1.0;
$DamageScale[sarmor, $VulcanDamageType] = 1.0;
$DamageScale[sfemale, $VulcanDamageType] = 1.0;
$DamageScale[mearmor, $VulcanDamageType] = 1.0;
$DamageScale[ebarmor, $VulcanDamageType] = 1.0;
$DamageScale[ebfemale, $VulcanDamageType] = 1.0;

$DamageScale[Scout, $VulcanDamageType] = 1.0;
$DamageScale[EscapePod, $VulcanDamageType] = 1.0;
$DamageScale[Jetfire, $VulcanDamageType] = 1.0;
$DamageScale[LAPC, $VulcanDamageType] = 1.0;
$DamageScale[HAPC, $VulcanDamageType] = 1.0;
$DamageScale[ScouterMissile, $VulcanDamageType] = 1.0;
$DamageScale[EOMissile, $VulcanDamageType] = 1.0;
$DamageScale[SurveyDrone, $VulcanDamageType] = 1.0;
$DamageScale[Retaliator, $VulcanDamageType] = 1.0;
$DamageScale[Interceptor, $VulcanDamageType] = 1.0;
$DamageScale[HoverTank, $VulcanDamageType] = 1.0;
$DamageScale[Explorer, $VulcanDamageType] = 1.0;
$DamageScale[Avenger, $VulcanDamageType] = 1.0;
$DamageScale[StarFighter, $VulcanDamageType] = 1.0;
$DamageScale[Icarus, $VulcanDamageType] = 1.0;
$DamageScale[Skyranger, $VulcanDamageType] = 1.0;
$DamageScale[StarHammer, $VulcanDamageType] = 1.0;
$DamageScale[SkyCutter, $VulcanDamageType] = 1.0;
$DamageScale[Arwing, $VulcanDamageType] = 1.0;

$DamageScale[larmor, $GaussDamageType] = 1.0;
$DamageScale[marmor, $GaussDamageType] = 1.0;
$DamageScale[harmor, $GaussDamageType] = 1.0;
$DamageScale[lfemale, $GaussDamageType] = 1.0;
$DamageScale[mfemale, $GaussDamageType] = 1.0;
$DamageScale[MagIonM, $GaussDamageType] = 1;
$DamageScale[MECH, $GaussDamageType] = 1;
$DamageScale[MagIonF, $GaussDamageType] = 1;
$DamageScale[sarmor, $GaussDamageType] = 1.0;
$DamageScale[sfemale, $GaussDamageType] = 1.0;
$DamageScale[mearmor, $GaussDamageType] = 1.0;
$DamageScale[ebarmor, $GaussDamageType] = 1.0;
$DamageScale[ebfemale, $GaussDamageType] = 1.0;

$DamageScale[Scout, $GaussDamageType] = 1.0;
$DamageScale[EscapePod, $GaussDamageType] = 1.0;
$DamageScale[Jetfire, $GaussDamageType] = 1.0;
$DamageScale[LAPC, $GaussDamageType] = 1.0;
$DamageScale[HAPC, $GaussDamageType] = 1.0;
$DamageScale[ScouterMissile, $GaussDamageType] = 1.0;
$DamageScale[EOMissile, $GaussDamageType] = 1.0;
$DamageScale[SurveyDrone, $GaussDamageType] = 1.0;
$DamageScale[Retaliator, $GaussDamageType] = 1.0;
$DamageScale[Interceptor, $GaussDamageType] = 1.0;
$DamageScale[HoverTank, $GaussDamageType] = 1.0;
$DamageScale[Explorer, $GaussDamageType] = 1.0;
$DamageScale[Avenger, $GaussDamageType] = 1.0;
$DamageScale[StarFighter, $GaussDamageType] = 1.0;
$DamageScale[Icarus, $GaussDamageType] = 1.0;
$DamageScale[Skyranger, $GaussDamageType] = 1.0;
$DamageScale[StarHammer, $GaussDamageType] = 1.0;
$DamageScale[SkyCutter, $GaussDamageType] = 1.0;
$DamageScale[Arwing, $GaussDamageType] = 1.0;

$DamageScale[larmor, $MassDamageType] = 0.4;
$DamageScale[marmor, $MassDamageType] = 0.4;
$DamageScale[harmor, $MassDamageType] = 0.6;
$DamageScale[lfemale, $MassDamageType] = 0.4;
$DamageScale[mfemale, $MassDamageType] = 0.4;
$DamageScale[MagIonM, $MassDamageType] = 0.6;
$DamageScale[MECH, $MassDamageType] = 0.6;
$DamageScale[MagIonF, $MassDamageType] = 0.6;
$DamageScale[sarmor, $MassDamageType] = 0.4;
$DamageScale[sfemale, $MassDamageType] = 0.4;
$DamageScale[mearmor, $MassDamageType] = 0.4;
$DamageScale[ebarmor, $MassDamageType] = 0.4;
$DamageScale[ebfemale, $MassDamageType] = 0.4;

$DamageScale[Scout, $MassDamageType] = 1.0;
$DamageScale[EscapePod, $MassDamageType] = 1.0;
$DamageScale[Jetfire, $MassDamageType] = 1.0;
$DamageScale[LAPC, $MassDamageType] = 1.0;
$DamageScale[HAPC, $MassDamageType] = 1.0;
$DamageScale[ScouterMissile, $MassDamageType] = 1.0;
$DamageScale[EOMissile, $MassDamageType] = 1.0;
$DamageScale[SurveyDrone, $MassDamageType] = 1.0;
$DamageScale[Retaliator, $MassDamageType] = 1.0;
$DamageScale[Interceptor, $MassDamageType] = 1.0;
$DamageScale[HoverTank, $MassDamageType] = 1.0;
$DamageScale[Explorer, $MassDamageType] = 1.0;
$DamageScale[Avenger, $MassDamageType] = 1.0;
$DamageScale[StarFighter, $MassDamageType] = 1.0;
$DamageScale[Icarus, $MassDamageType] = 1.0;
$DamageScale[Skyranger, $MassDamageType] = 1.0;
$DamageScale[StarHammer, $MassDamageType] = 1.0;
$DamageScale[SkyCutter, $MassDamageType] = 1.0;
$DamageScale[Arwing, $MassDamageType] = 1.0;

$DamageScale[larmor, $SniperDamageType] = 1.0;
$DamageScale[marmor, $SniperDamageType] = 1.0;
$DamageScale[harmor, $SniperDamageType] = 1.0;
$DamageScale[lfemale, $SniperDamageType] = 1.0;
$DamageScale[mfemale, $SniperDamageType] = 1.0;
$DamageScale[MagIonM, $SniperDamageType] = 1.0;
$DamageScale[MECH, $SniperDamageType] = 1.0;
$DamageScale[MagIonF, $SniperDamageType] = 1;
$DamageScale[sarmor, $SniperDamageType] = 1.0;
$DamageScale[sfemale, $SniperDamageType] = 1.0;
$DamageScale[mearmor, $SniperDamageType] = 1.0;
$DamageScale[ebarmor, $SniperDamageType] = 1.0;
$DamageScale[ebfemale, $SniperDamageType] = 1.0;

$DamageScale[Scout, $SniperDamageType] = 1.0;
$DamageScale[EscapePod, $SniperDamageType] = 1.0;
$DamageScale[Jetfire, $SniperDamageType] = 1.0;
$DamageScale[LAPC, $SniperDamageType] = 1.0;
$DamageScale[HAPC, $SniperDamageType] = 1.0;
$DamageScale[ScouterMissile, $SniperDamageType] = 1.0;
$DamageScale[EOMissile, $SniperDamageType] = 1.0;
$DamageScale[SurveyDrone, $SniperDamageType] = 1.0;
$DamageScale[Retaliator, $SniperDamageType] = 1.0;
$DamageScale[Interceptor, $SniperDamageType] = 1.0;
$DamageScale[HoverTank, $SniperDamageType] = 1.0;
$DamageScale[Explorer, $SniperDamageType] = 1.0;
$DamageScale[Avenger, $SniperDamageType] = 1.0;
$DamageScale[StarFighter, $SniperDamageType] = 1.0;
$DamageScale[Icarus, $SniperDamageType] = 1.0;
$DamageScale[Skyranger, $SniperDamageType] = 1.0;
$DamageScale[StarHammer, $SniperDamageType] = 1.0;
$DamageScale[SkyCutter, $SniperDamageType] = 1.0;
$DamageScale[Arwing, $SniperDamageType] = 1.0;

$DamageScale[larmor, $ShotgunDamageType] = 1.0;
$DamageScale[marmor, $ShotgunDamageType] = 1.0;
$DamageScale[harmor, $ShotgunDamageType] = 1.0;
$DamageScale[lfemale, $ShotgunDamageType] = 1.0;
$DamageScale[mfemale, $ShotgunDamageType] = 1.0;
$DamageScale[MagIonM, $ShotgunDamageType] = 1;
$DamageScale[MECH, $ShotgunDamageType] = 1;
$DamageScale[MagIonF, $ShotgunDamageType] = 1;
$DamageScale[sarmor, $ShotgunDamageType] = 1.0;
$DamageScale[sfemale, $ShotgunDamageType] = 1.0;
$DamageScale[mearmor, $ShotgunDamageType] = 1.0;
$DamageScale[ebarmor, $ShotgunDamageType] = 1.0;
$DamageScale[ebfemale, $ShotgunDamageType] = 1.0;

$DamageScale[Scout, $ShotgunDamageType] = 1.0;
$DamageScale[EscapePod, $ShotgunDamageType] = 1.0;
$DamageScale[Jetfire, $ShotgunDamageType] = 1.0;
$DamageScale[LAPC, $ShotgunDamageType] = 1.0;
$DamageScale[HAPC, $ShotgunDamageType] = 1.0;
$DamageScale[ScouterMissile, $ShotgunDamageType] = 1.0;
$DamageScale[EOMissile, $ShotgunDamageType] = 1.0;
$DamageScale[SurveyDrone, $ShotgunDamageType] = 1.0;
$DamageScale[Retaliator, $ShotgunDamageType] = 1.0;
$DamageScale[Interceptor, $ShotgunDamageType] = 1.0;
$DamageScale[HoverTank, $ShotgunDamageType] = 1.0;
$DamageScale[Explorer, $ShotgunDamageType] = 1.0;
$DamageScale[Avenger, $ShotgunDamageType] = 1.0;
$DamageScale[StarFighter, $ShotgunDamageType] = 1.0;
$DamageScale[Icarus, $ShotgunDamageType] = 1.0;
$DamageScale[Skyranger, $ShotgunDamageType] = 1.0;
$DamageScale[StarHammer, $ShotgunDamageType] = 1.0;
$DamageScale[SkyCutter, $ShotgunDamageType] = 1.0;
$DamageScale[Arwing, $ShotgunDamageType] = 1.0;

$DamageScale[larmor, $MethaneDamageType] = 1.0;
$DamageScale[marmor, $MethaneDamageType] = 1.0;
$DamageScale[harmor, $MethaneDamageType] = 1.0;
$DamageScale[lfemale, $MethaneDamageType] = 1.0;
$DamageScale[mfemale, $MethaneDamageType] = 1.0;
$DamageScale[MagIonM, $MethaneDamageType] = 1;
$DamageScale[MECH, $MethaneDamageType] = 1;
$DamageScale[MagIonF, $MethaneDamageType] = 1;
$DamageScale[sarmor, $MethaneDamageType] = 1.0;
$DamageScale[sfemale, $MethaneDamageType] = 1.0;
$DamageScale[mearmor, $MethaneDamageType] = 1.0;
$DamageScale[ebarmor, $MethaneDamageType] = 1.0;
$DamageScale[ebfemale, $MethaneDamageType] = 1.0;

$DamageScale[larmor, $PBWDamageType] = 1.0;
$DamageScale[marmor, $PBWDamageType] = 1.0;
$DamageScale[harmor, $PBWDamageType] = 1.0;
$DamageScale[lfemale, $PBWDamageType] = 1.0;
$DamageScale[mfemale, $PBWDamageType] = 1.0;
$DamageScale[MagIonM, $PBWDamageType] = 1;
$DamageScale[MECH, $PBWDamageType] = 1;
$DamageScale[MagIonF, $PBWDamageType] = 1;
$DamageScale[sarmor, $PBWDamageType] = 1.0;
$DamageScale[sfemale, $PBWDamageType] = 1.0;
$DamageScale[mearmor, $PBWDamageType] = 1.0;
$DamageScale[ebarmor, $PBWDamageType] = 1.0;
$DamageScale[ebfemale, $PBWDamageType] = 1.0;

$DamageScale[Scout, $PBWDamageType] = 1.0;
$DamageScale[EscapePod, $PBWDamageType] = 1.0;
$DamageScale[Jetfire, $PBWDamageType] = 1.0;
$DamageScale[LAPC, $PBWDamageType] = 1.0;
$DamageScale[HAPC, $PBWDamageType] = 1.0;
$DamageScale[ScouterMissile, $PBWDamageType] = 1.0;
$DamageScale[EOMissile, $PBWDamageType] = 1.0;
$DamageScale[SurveyDrone, $PBWDamageType] = 1.0;
$DamageScale[Retaliator, $PBWDamageType] = 1.0;
$DamageScale[Interceptor, $PBWDamageType] = 1.0;
$DamageScale[HoverTank, $PBWDamageType] = 1.0;
$DamageScale[Explorer, $PBWDamageType] = 1.0;
$DamageScale[Avenger, $PBWDamageType] = 1.0;
$DamageScale[StarFighter, $PBWDamageType] = 1.0;
$DamageScale[Icarus, $PBWDamageType] = 1.0;
$DamageScale[Skyranger, $PBWDamageType] = 1.0;
$DamageScale[StarHammer, $PBWDamageType] = 1.0;
$DamageScale[SkyCutter, $PBWDamageType] = 1.0;
$DamageScale[Arwing, $PBWDamageType] = 1.0;

$DamageScale[larmor, $NullDamageType] = 0.0;
$DamageScale[marmor, $NullDamageType] = 0.0;
$DamageScale[harmor, $NullDamageType] = 0.0;
$DamageScale[lfemale, $NullDamageType] = 0.0;
$DamageScale[mfemale, $NullDamageType] = 0.0;
$DamageScale[MagIonM, $NullDamageType] = 0.0;
$DamageScale[MagIonF, $NullDamageType] = 0.0;
$DamageScale[MECH, $NullDamageType] = 0.0;
$DamageScale[sarmor, $PBWDamageType] = 1.0;
$DamageScale[sfemale, $PBWDamageType] = 1.0;
$DamageScale[mearmor, $PBWDamageType] = 1.0;
$DamageScale[ebarmor, $PBWDamageType] = 1.0;
$DamageScale[ebfemale, $PBWDamageType] = 1.0;

$DamageScale[Scout, $NullDamageType] = 0.0;
$DamageScale[EscapePod, $NullDamageType] = 0.0;
$DamageScale[Jetfire, $NullDamageType] = 0.0;
$DamageScale[LAPC, $NullDamageType] = 0.0;
$DamageScale[HAPC, $NullDamageType] = 0.0;
$DamageScale[ScouterMissile, $NullDamageType] = 0.0;
$DamageScale[EOMissile, $NullDamageType] = 0.0;
$DamageScale[SurveyDrone, $NullDamageType] = 0.0;
$DamageScale[Retaliator, $NullDamageType] = 0.0;
$DamageScale[Interceptor, $NullDamageType] = 0.0;
$DamageScale[HoverTank, $NullDamageType] = 0.0;
$DamageScale[Explorer, $NullDamageType] = 0.0;
$DamageScale[Avenger, $NullDamageType] = 0.0;
$DamageScale[StarFighter, $NullDamageType] = 0.0;
$DamageScale[Icarus, $NullDamageType] = 0.0;
$DamageScale[Skyranger, $NullDamageType] = 0.0;
$DamageScale[StarHammer, $NullDamageType] = 0.0;
$DamageScale[SkyCutter, $NullDamageType] = 0.0;
$DamageScale[Arwing, $NullDamageType] = 0.0;

$DamageScale[larmor, $six66] = 1.0;
$DamageScale[marmor, $six66] = 1.0;
$DamageScale[harmor, $six66] = 1.0;
$DamageScale[lfemale, $six66] = 1.0;
$DamageScale[mfemale, $six66] = 1.0;
$DamageScale[MagIonM, $six66] = 1.0;
$DamageScale[MagIonF, $six66] = 1.0;
$DamageScale[MECH, $six66] = 1.0;
$DamageScale[sarmor, $six66] = 1.0;
$DamageScale[sfemale, $six66] = 1.0;
$DamageScale[mearmor, $six66] = 1.0;
$DamageScale[ebarmor, $six66] = 1.0;
$DamageScale[ebfemale, $six66] = 1.0;

$DamageScale[Scout, $six66] = 1.0;
$DamageScale[EscapePod, $six66] = 1.0;
$DamageScale[Jetfire, $six66] = 1.0;
$DamageScale[LAPC, $six66] = 1.0;
$DamageScale[HAPC, $six66] = 1.0;
$DamageScale[ScouterMissile, $six66] = 1.0;
$DamageScale[EOMissile, $six66] = 1.0;
$DamageScale[SurveyDrone, $six66] = 1.0;
$DamageScale[Retaliator, $six66] = 1.0;
$DamageScale[Interceptor, $six66] = 1.0;
$DamageScale[HoverTank, $six66] = 1.0;
$DamageScale[Explorer, $six66] = 1.0;
$DamageScale[Avenger, $six66] = 1.0;
$DamageScale[StarFighter, $six66] = 1.0;
$DamageScale[Icarus, $six66] = 1.0;
$DamageScale[Skyranger, $six66] = 1.0;
$DamageScale[StarHammer, $six66] = 1.0;
$DamageScale[SkyCutter, $six66] = 1.0;
$DamageScale[Arwing, $six66] = 1.0;

$DamageScale[larmor, $TractorDamageType] = 1.0;
$DamageScale[marmor, $TractorDamageType] = 1.0;
$DamageScale[harmor, $TractorDamageType] = 1.0;
$DamageScale[lfemale, $TractorDamageType] = 1.0;
$DamageScale[mfemale, $TractorDamageType] = 1.0;
$DamageScale[MagIonM, $TractorDamageType] = 1;
$DamageScale[MECH, $TractorDamageType] = 1;
$DamageScale[MagIonF, $TractorDamageType] = 1;
$DamageScale[sarmor, $TractorDamageType] = 1.0;
$DamageScale[sfemale, $TractorDamageType] = 1.0;
$DamageScale[mearmor, $TractorDamageType] = 1.0;
$DamageScale[ebarmor, $TractorDamageType] = 1.0;
$DamageScale[ebfemale, $TractorDamageType] = 1.0;

//=================================== Clustered String defs -- dmg defs 31++

#================================================================#
$ProtronDamageType = 31;

$deathMsg[$ProtronDamageType, 0] = "%1 riddles %2 with %4 Protron.";
$deathMsg[$ProtronDamageType, 1] = "%2 gets capped by %1's Protron.";
$deathMsg[$ProtronDamageType, 2] = "%1's Protron genetically rearranges %2 into a mutating radiated hump.";
$deathMsg[$ProtronDamageType, 3] = "%2 came apart at the seams with outgoing Protrons from %1.";

$DamageScale[larmor, $ProtronDamageType] = 1.0;
$DamageScale[marmor, $ProtronDamageType] = 1.0;
$DamageScale[harmor, $ProtronDamageType] = 1.0;
$DamageScale[lfemale, $ProtronDamageType] = 1.0;
$DamageScale[mfemale, $ProtronDamageType] = 1.0;
$DamageScale[MagIonM, $ProtronDamageType] = 1.0;
$DamageScale[MECH, $ProtronDamageType] = 1.0;
$DamageScale[MagIonF, $ProtronDamageType] = 1.0;
$DamageScale[sarmor, $ProtronDamageType] = 1.0;
$DamageScale[sfemale, $ProtronDamageType] = 1.0;
$DamageScale[mearmor, $ProtronDamageType] = 1.0;
$DamageScale[ebarmor, $ProtronDamageType] = -0.1;
$DamageScale[ebfemale, $ProtronDamageType] = -0.1;

$DamageScale[Scout, $ProtronDamageType] = 1.0;
$DamageScale[EscapePod, $ProtronDamageType] = 1.0;
$DamageScale[Jetfire, $ProtronDamageType] = 1.0;
$DamageScale[LAPC, $ProtronDamageType] = 1.0;
$DamageScale[HAPC, $ProtronDamageType] = 1.0;
$DamageScale[ScouterMissile, $ProtronDamageType] = 1.0;
$DamageScale[EOMissile, $ProtronDamageType] = 1.0;
$DamageScale[SurveyDrone, $ProtronDamageType] = 1.0;
$DamageScale[Retaliator, $ProtronDamageType] = 1.0;
$DamageScale[Interceptor, $ProtronDamageType] = 1.0;
$DamageScale[HoverTank, $ProtronDamageType] = 1.0;
$DamageScale[Explorer, $ProtronDamageType] = 1.0;
$DamageScale[Avenger, $ProtronDamageType] = 1.0;
$DamageScale[StarFighter, $ProtronDamageType] = 1.0;
$DamageScale[Icarus, $ProtronDamageType] = 1.0;
$DamageScale[Skyranger, $ProtronDamageType] = 1.0;
$DamageScale[StarHammer, $ProtronDamageType] = 1.0;
$DamageScale[SkyCutter, $ProtronDamageType] = 1.0;
$DamageScale[Arwing, $ProtronDamageType] = 1.0;

#================================================================#
$BettyDamageType = 32;

$deathMsg[$BettyDamageType , 0] = "%1's Vertigo Bomb blows %2 to dust.";
$deathMsg[$BettyDamageType , 1] = "%2 in Blastech thought %4 could take %1's Mortar. It was too late when %2 found out that it was a Vertigo Bomb.";
$deathMsg[$BettyDamageType , 2] = "%1's Vertigo Bomb dissipates as %2 is left dead on the ground.";
$deathMsg[$BettyDamageType , 3] = "%2's Blastech suit couldn't handle the overload of pure Vertigo from %1's Vertigo Bomb.";

$DamageScale[larmor, $BettyDamageType] = 1.0;
$DamageScale[marmor, $BettyDamageType] = 1.0;
$DamageScale[harmor, $BettyDamageType] = 1.0;
$DamageScale[lfemale, $BettyDamageType] = 1.0;
$DamageScale[mfemale, $BettyDamageType] = 1.0;
$DamageScale[MagIonM, $BettyDamageType] = 1.0;
$DamageScale[MECH, $BettyDamageType] = 1.0;
$DamageScale[MagIonF, $BettyDamageType] = 1.0;
$DamageScale[sarmor, $BettyDamageType] = 1.0;
$DamageScale[sfemale, $BettyDamageType] = 1.0;
$DamageScale[mearmor, $BettyDamageType] = 1.0;
$DamageScale[ebarmor, $BettyDamageType] = 1.0;
$DamageScale[ebfemale, $BettyDamageType] = 1.0;

$DamageScale[Scout, $BettyDamageType] = 1.0;
$DamageScale[EscapePod, $BettyDamageType] = 1.0;
$DamageScale[Jetfire, $BettyDamageType] = 1.0;
$DamageScale[LAPC, $BettyDamageType] = 1.0;
$DamageScale[HAPC, $BettyDamageType] = 1.0;
$DamageScale[ScouterMissile, $BettyDamageType] = 1.0;
$DamageScale[EOMissile, $BettyDamageType] = 1.0;
$DamageScale[SurveyDrone, $BettyDamageType] = 1.0;
$DamageScale[Retaliator, $BettyDamageType] = 1.0;
$DamageScale[Interceptor, $BettyDamageType] = 1.0;
$DamageScale[HoverTank, $BettyDamageType] = 1.0;
$DamageScale[Explorer, $BettyDamageType] = 1.0;
$DamageScale[Avenger, $BettyDamageType] = 1.0;
$DamageScale[StarFighter, $BettyDamageType] = 1.0;
$DamageScale[Icarus, $BettyDamageType] = 1.0;
$DamageScale[Skyranger, $BettyDamageType] = 1.0;
$DamageScale[StarHammer, $BettyDamageType] = 1.0;
$DamageScale[SkyCutter, $BettyDamageType] = 1.0;
$DamageScale[Arwing, $BettyDamageType] = 1.0;

#================================================================#
$EnergyTurretDamageType= 33;

$deathMsg[$EnergyTurretDamageType, 0]      = "%1 ends up on the wrong side of a turret.";
$deathMsg[$EnergyTurretDamageType, 1]      = "%1 loses a game of chicken with a turret.";
$deathMsg[$EnergyTurretDamageType, 2]      = "%1 managed to find the enemy turrets.";
$deathMsg[$EnergyTurretDamageType, 3]      = "%1 figures out what all those pretty lights are.";

$DamageScale[larmor, $EnergyTurretDamageType] = 1.0;
$DamageScale[marmor, $EnergyTurretDamageType] = 1.0;
$DamageScale[harmor, $EnergyTurretDamageType] = 1.0;
$DamageScale[lfemale, $EnergyTurretDamageType] = 1.0;
$DamageScale[mfemale, $EnergyTurretDamageType] = 1.0;
$DamageScale[MagIonM, $EnergyTurretDamageType] = 1.0;
$DamageScale[MECH, $EnergyTurretDamageType] = 1.0;
$DamageScale[MagIonF, $EnergyTurretDamageType] = 1.0;
$DamageScale[sarmor, $EnergyTurretDamageType] = 1.0;
$DamageScale[sfemale, $EnergyTurretDamageType] = 1.0;
$DamageScale[mearmor, $EnergyTurretDamageType] = 1.0;
$DamageScale[ebarmor, $EnergyTurretDamageType] = -0.1;
$DamageScale[ebfemale, $EnergyTurretDamageType] = -0.1;

$DamageScale[Scout, $EnergyTurretDamageType] = 1.0;
$DamageScale[EscapePod, $EnergyTurretDamageType] = 1.0;
$DamageScale[Jetfire, $EnergyTurretDamageType] = 1.0;
$DamageScale[LAPC, $EnergyTurretDamageType] = 1.0;
$DamageScale[HAPC, $EnergyTurretDamageType] = 1.0;
$DamageScale[ScouterMissile, $EnergyTurretDamageType] = 1.0;
$DamageScale[EOMissile, $EnergyTurretDamageType] = 1.0;
$DamageScale[SurveyDrone, $EnergyTurretDamageType] = 1.0;
$DamageScale[Retaliator, $EnergyTurretDamageType] = 1.0;
$DamageScale[Interceptor, $EnergyTurretDamageType] = 1.0;
$DamageScale[HoverTank, $EnergyTurretDamageType] = 1.0;
$DamageScale[Explorer, $EnergyTurretDamageType] = 1.0;
$DamageScale[Avenger, $EnergyTurretDamageType] = 1.0;
$DamageScale[StarFighter, $EnergyTurretDamageType] = 1.0;
$DamageScale[Icarus, $EnergyTurretDamageType] = 1.0;
$DamageScale[Skyranger, $EnergyTurretDamageType] = 1.0;
$DamageScale[StarHammer, $EnergyTurretDamageType] = 1.0;
$DamageScale[SkyCutter, $EnergyTurretDamageType] = 1.0;
$DamageScale[Arwing, $EnergyTurretDamageType] = 1.0;
