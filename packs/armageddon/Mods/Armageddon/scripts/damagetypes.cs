//PORT-OFF: $ModList = "-=Armageddon=-";

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
$RepairDamageType      = 31;
$DisarmDamageType          = 40;  
$six66                 = -3;

//==============================================================================================
// Death Messages - INH*DynaBlade (Majestic 12)
// Maximum allowed messages: 8
// if there is a 9 or ++ then it will not print the selected weapon
// you can have up to 64 suicide messages; but you will strip your ability to print kill
// messages if you exceed 6 (8 in some cases)
//==============================================================================================

$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";

$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$ImpactDamageType, 2] 	= "%1 shows %2 his new ride";
$deathMsg[$ImpactDamageType, 3] 	= "%1 shoves %2 into his jet thrust.";

$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 turns %2 into swiss cheese.";
$deathMsg[$BulletDamageType, 3]      = "%2 felt like being Holy.";

$deathMsg[$EnergyDamageType, 0]      = "%2 loses a game of chicken with a turret.";
$deathMsg[$EnergyDamageType, 1]      = "%2 wonders 'hey, what's this thing do?'";
$deathMsg[$EnergyDamageType, 2]      = "%2 managed to find the enemy turrets.";
$deathMsg[$EnergyDamageType, 3]      = "%2 figures out what all those pretty lights are.";

$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a plasma transfusion.";
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
$deathMsg[$LaserDamageType, 1]       = "%2 thought %4 was the one. Turns out %4 couldnt stop %1's laser.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]       = "%2 has a hole fried through %4 head by %1's laser.";
$deathMsg[$LaserDamageType, 4]       = "%1 Lightly Amplified %2's Stimulated Emission of Radiation.";
$deathMsg[$LaserDamageType, 5]       = "%2 go BOOM BOOM!";


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

$deathMsg[$DisarmDamageType, 0]	 = "%2 didn't stay away from the moving parts.";
$deathMsg[$DisarmDamageType, 1]	 = "%2 gets caught in the machinery.";
$deathMsg[$DisarmDamageType, 2]	 = "%2 didn't stay away from the moving parts.";
$deathMsg[$DisarmDamageType, 3]	 = "%2 got a great deal for pizza.";

$deathMsg[$DebrisDamageType, 0]	 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]	 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]	 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]	 = "%2 got too close to the exploding stuff.";

$deathMsg[$MissileDamageType, 0]	 = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1] 	 = "%2 gets buttraped by a warhead.";
$deathMsg[$MissileDamageType, 2]  	 = "%2 played dodgeball with a rocket...And lost.";
$deathMsg[$MissileDamageType, 3] 	 = "%2 rides the rocket.";
$deathMsg[$MissileDamageType, 4]	 = "%2 gets ripped apart.";
$deathMsg[$MissileDamageType, 5]	 = "%2 gets torn into pieces.";
$deathMsg[$MissileDamageType, 6]	 = "%2 gets spread out across the map.";
$deathMsg[$MissileDamageType, 7]	 = "%2 came apart at the seams.";
$deathMsg[$MissileDamageType, 8] 	 = "%2 decided to be the first man to Mars.";


$deathMsg[$MineDamageType, 0]	       = "%2 stepped on a toe-popper.";
$deathMsg[$MineDamageType, 1] 	 = "%1 gives %2 a piece of %3 mine.";
$deathMsg[$MineDamageType, 2] 	 = "%1 reminds %2 that a mine is a terrible thing to waste.";
$deathMsg[$MineDamageType, 3] 	 = "%2 is blown to bits by %1's mine.";

$deathMsg[$SniperDamageType, 0]	 = "%2 never saw it coming from %1.";
$deathMsg[$SniperDamageType, 1]      = "%1 tells %2 you zigged when you should have zagged.";
$deathMsg[$SniperDamageType, 2] 	 = "%1 gave %2 a shot right between the eyes.";
$deathMsg[$SniperDamageType, 3]	 = "%1 takes a pot shot at %2.";
$deathMsg[$SniperDamageType, 4]	 = "%1 uses %2 for a spot of sniper training.";


$deathMsg[$PBWDamageType, 0]	       = "%1 punched a hole through %2.";
$deathMsg[$PBWDamageType, 1]	       = "%2 gets a taste of %1's PBW.";
$deathMsg[$PBWDamageType, 2]	       = "%1 gives %2 a fatal PBW concussion.";
$deathMsg[$PBWDamageType, 3]	       = "%2 never saw it coming from %1.";

$deathMsg[$ShotgunDamageType, 0]	 = "%1's Ion Cannon electricutes %2's vital systems.";
$deathMsg[$ShotgunDamageType, 1]	 = "%1 gives %2 a lesson in ionic chemistry.";
$deathMsg[$ShotgunDamageType, 2] 	 = "%2 caught a chest full of %1's atom stripper."; 
$deathMsg[$ShotgunDamageType, 3] 	 = "%2 lets freedom ring with a ion blast from %1."; 

$deathMsg[$MassDamageType, 0]        = "%2 took in an excessive amount of explosion";
$deathMsg[$MassDamageType, 1]        = "%2 is blown to pieces by %1's Mass Driver";
$deathMsg[$MassDamageType, 2]        = "%1 gives %2 a Mass Driver blast";
$deathMsg[$MassDamageType, 3]        = "%1 blows %2's head clean off woth a Mass Driver blast!";

$deathMsg[$GaussDamageType, 0]       = "%1 chunks apart %2 with %3 Gauss Cannon.";
$deathMsg[$GaussDamageType, 1]       = "%1 pillages %2 with %3 Gauss.";
$deathMsg[$GaussDamageType, 2]       = "%1 blows %2 to smithereens.";
$deathMsg[$GaussDamageType, 3]       = "%1 turns %2 into swiss cheese.";

$deathMsg[$MethaneDamageType, 0]	 = "%1 gives %2 a lethal injection.";
$deathMsg[$MethaneDamageType, 1]     = "%2 dies with green flesh open.";
$deathMsg[$MethaneDamageType, 2] 	 = "%2 gets a lethal injection from %1.";
$deathMsg[$MethaneDamageType, 3] 	 = "%2 falls victim to the deadly ebola virus.";

$deathMsg[$MBDamageType, 0]      	 = "%2 thought %4 was God. That was before %1's mitzi blast hit %4.";
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

$deathMsg[$SniperXDamageType, 0] 	 = "%2 is clueless after %1's HP Sniper shot."; 
$deathMsg[$SniperXDamageType, 1] 	 = "%1 punches a hole through %2's with his HP Sniper Round."; 
$deathMsg[$SniperXDamageType, 2] 	 = "%2 has been pushed off this mortal realm by %1's HP Sniper.";
$deathMsg[$SniperXDamageType, 3] 	 = "%2 REALLY never saw it coming from %1.'s HP Sniper";

$deathMsg[$PulseDamageType, 0]	 = "%1's Annihilator Mitzi Blast vaporizes %2.";
$deathMsg[$PulseDamageType, 1]	 = "%2 has been reduced to his componet atoms by %1's Annihilator.";
$deathMsg[$PulseDamageType, 2]	 = "%1 used the Force on %2.";
$deathMsg[$PulseDamageType, 3]	 = "%1 sends %2 clear through the next dimension.";

$deathMsg[$TractorDamageType, 0] = "%2 gets ripped apart.";
$deathMsg[$TractorDamageType, 1] = "%2 gets torn into pieces.";
$deathMsg[$TractorDamageType, 2] = "%2 gets pulled apart.";
$deathMsg[$TractorDamageType, 3] = "%2 came apart at the seams.";

$deathMsg[-2,0]                                          = "%1 wanted to make sure %2 gun was loaded.";
$deathMsg[-2,1]                                          = "%1 was last heard yelling 'No Surrender!'"; 
$deathMsg[-2,2]                                          = "%1 shows off %2 mad dying skills.";
$deathMsg[-2,3]                                          = "%1 says: The Borg assimilated me & all I got was this stupid T-Shirt!";

$deathMsg[-3,0]                                          = "%1 wanted to make sure %2 gun was loaded.";
$deathMsg[-3,1]                                          = "%1 was last heard yelling''death before dishonor!'"; 
$deathMsg[-3,2]                                          = "%1 shows off %2 mad dying skills.";
$deathMsg[-3,3]                                          = "%1 says: The Borg assimilated me & all I got was this stupid T-Shirt!";

$numDeathMsgs = 4;

//#############################################################################################

//=========Damage defs here

$DamageScale[larmor, $RepairDamageType] = -1.0;
$DamageScale[marmor, $RepairDamageType] = -1.5;
$DamageScale[harmor, $RepairDamageType] = -1.9;
$DamageScale[lfemale, $RepairDamageType] = -1.0;
$DamageScale[mfemale, $RepairDamageType] = -1.5;
$DamageScale[BlastechM, $RepairDamageType] = -1.0;
$DamageScale[MagIonM, $RepairDamageTypee] = -1.5;
$DamageScale[MECH, $RepairDamageType] = -1.9;
$DamageScale[BlastechF, $RepairDamageType] = -1.0;
$DamageScale[MagIonF, $RepairDamageType] = -1.5;

$DamageScale[Scout, $RepairDamageType] = -1.0;
$DamageScale[EscapePod, $RepairDamageType] = -1.0;
$DamageScale[PyroXL, $RepairDamageTypee] = -1.0;
$DamageScale[LAPC, $RepairDamageType] = -1.0;
$DamageScale[HAPC, $RepairDamageType] = -1.0;
$DamageScale[ScouterMissile, $RepairDamageType] = -1.0;
$DamageScale[EOMissile, $RepairDamageType] = -1.0;
$DamageScale[SurveyDrone, $RepairDamageType] = -1.0;
$DamageScale[ProbeDroid, $RepairDamageType] = -1.0;
$DamageScale[Interceptor, $RepairDamageType] = -1.0;
$DamageScale[HoverTank, $RepairDamageType] = -1.0;
$DamageScale[Explorer,$RepairDamageType] = -1.0;
$DamageScale[Avenger, $RepairDamageType] = -1.0;
$DamageScale[StarFighter,$RepairDamageType] = -1.0;
$DamageScale[Icarus, $RepairDamageType] = -1.0;
$DamageScale[Skyranger, $RepairDamageType] = -1.0;
$DamageScale[StarHammer, $RepairDamageType] = -1.0;
$DamageScale[SkyCutter, $RepairDamageType] = -1.0;
$DamageScale[Arwing, $RepairDamageType] = -1.0;

$DamageScale[larmor, $PulseDamageType] = 1.0;
$DamageScale[marmor, $PulseDamageType] = 1.0;
$DamageScale[harmor, $PulseDamageType] = 1.0;
$DamageScale[lfemale, $PulseDamageType] = 1.0;
$DamageScale[mfemale, $PulseDamageType] = 1.0;
$DamageScale[BlastechM, $PulseDamageType] = 1.0;
$DamageScale[MagIonM, $PulseDamageType] = 1.0;
$DamageScale[MECH, $PulseDamageType] = 1.0;
$DamageScale[BlastechF, $PulseDamageType] = 1.0;
$DamageScale[MagIonF, $PulseDamageType] = 1.0;

$DamageScale[Scout, $PulseDamageType] = 1.0;
$DamageScale[EscapePod, $PulseDamageType] = 1.0;
$DamageScale[PyroXL, $PulseDamageType] = 1.0;
$DamageScale[LAPC, $PulseDamageType] = 1.0;
$DamageScale[HAPC, $PulseDamageType] = 1.0;
$DamageScale[ScouterMissile, $PulseDamageType] = 1.0;
$DamageScale[EOMissile, $PulseDamageType] = 1.0;
$DamageScale[SurveyDrone, $PulseDamageType] = 1.0;
$DamageScale[ProbeDroid, $PulseDamageType] = 1.0;
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

$DamageScale[larmor, $SniperXDamageType] = 0.1;
$DamageScale[marmor, $SniperXDamageType] = 0.25;
$DamageScale[harmor, $SniperXDamageType] = 1.0;
$DamageScale[lfemale, $SniperXDamageType] = 0.1;
$DamageScale[mfemale, $SniperXDamageType] = 0.25;
$DamageScale[BlastechM, $SniperXDamageType] = -0.1;
$DamageScale[MagIonM, $SniperXDamageType] = 0.25;
$DamageScale[MECH, $SniperXDamageType] = 0.5;
$DamageScale[BlastechF, $SniperXDamageType] = -0.1;
$DamageScale[MagIonF, $SniperXDamageType] = 0.25;

$DamageScale[Scout, $SniperXDamageType] = 0.2;
$DamageScale[EscapePod, $SniperXDamageType] = -1;
$DamageScale[PyroXL, $SniperXDamageType] = 0.5;
$DamageScale[LAPC, $SniperXDamageType] = 1;
$DamageScale[HAPC, $SniperXDamageType] = 2;
$DamageScale[ScouterMissile, $SniperXDamageType] = 0.1;
$DamageScale[EOMissile, $SniperXDamageType] = 0.1;
$DamageScale[SurveyDrone, $SniperXDamageType] = 0.1;
$DamageScale[ProbeDroid, $SniperXDamageType] = 0.1;
$DamageScale[Interceptor, $SniperXDamageType] = 2.0;
$DamageScale[HoverTank, $SniperXDamageType] = 1.57;
$DamageScale[Explorer, $SniperXDamageType] = 0.1;
$DamageScale[Avenger, $SniperXDamageType] = 0.1;
$DamageScale[StarFighter, $SniperXDamageType] = 0.1;
$DamageScale[Icarus, $SniperXDamageType] = 0.1;
$DamageScale[Skyranger, $SniperXDamageType] = 0.1;
$DamageScale[StarHammer, $SniperXDamageType] = 0.1;
$DamageScale[SkyCutter, $SniperXDamageType] = 0.1;
$DamageScale[Arwing, $SniperXDamageType] = 0.1;

$DamageScale[larmor, $FlierBombDamageType] = 1.0;
$DamageScale[marmor, $FlierBombDamageType] = 1.0;
$DamageScale[harmor, $FlierBombDamageType] = 1.0;
$DamageScale[lfemale, $FlierBombDamageType] = 1.0;
$DamageScale[mfemale, $FlierBombDamageType] = 1.0;
$DamageScale[BlastechM, $FlierBombDamageType] = -0.3;
$DamageScale[MagIonM, $FlierBombDamageType] = 1;
$DamageScale[MECH, $FlierBombDamageType] = 0.95;
$DamageScale[BlastechF, $FlierBombDamageType] = -0.3;
$DamageScale[MagIonF, $FlierBombDamageType] = 1;

$DamageScale[Scout, $FlierBombDamageType] = 1.0;
$DamageScale[EscapePod, $FlierBombDamageType] = 1.0;
$DamageScale[PyroXL, $FlierBombDamageType] = 1.0;
$DamageScale[LAPC, $FlierBombDamageType] = 1.0;
$DamageScale[HAPC, $FlierBombDamageType] = 1.0;
$DamageScale[ScouterMissile, $FlierBombDamageType] = 1.0;
$DamageScale[EOMissile, $FlierBombDamageType] = 1.0;
$DamageScale[SurveyDrone, $FlierBombDamageType] = 1.0;
$DamageScale[ProbeDroid, $FlierBombDamageType] = 1.0;
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
$DamageScale[BlastechM, $FlameDamageType] = 1.0;
$DamageScale[MagIonM, $FlameDamageType] = 1.0;
$DamageScale[MECH, $FlameDamageType] = 1.0;
$DamageScale[BlastechF, $FlameDamageType] = 1.0;
$DamageScale[MagIonF, $FlameDamageType] = 1.0;

$DamageScale[Scout, $FlameDamageType] = 1.0;
$DamageScale[EscapePod, $FlameDamageType] = 1.0;
$DamageScale[PyroXL, $FlameDamageType] = 1.0;
$DamageScale[LAPC, $FlameDamageType] = 1.0;
$DamageScale[HAPC, $FlameDamageType] = 1.0;
$DamageScale[ScouterMissile, $FlameDamageType] = 1.0;
$DamageScale[EOMissile, $FlameDamageType] = 1.0;
$DamageScale[SurveyDrone, $FlameDamageType] = 1.0;
$DamageScale[ProbeDroid, $FlameDamageType] = 1.0;
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
$DamageScale[BlastechM, $FusionDamageType] = 1;
$DamageScale[MagIonM, $FusionDamageType] = -0.1;
$DamageScale[MECH, $FusionDamageType] = 1;
$DamageScale[BlastechF, $FusionDamageType] = 1;
$DamageScale[MagIonF, $FusionDamageType] = -0.1;

$DamageScale[Scout, $FusionDamageType] = 1.0;
$DamageScale[EscapePod, $FusionDamageType] = 1.0;
$DamageScale[PyroXL, $FusionDamageType] = 1.0;
$DamageScale[LAPC, $FusionDamageType] = 1.0;
$DamageScale[HAPC, $FusionDamageType] = 1.0;
$DamageScale[ScouterMissile, $FusionDamageType] = 1.0;
$DamageScale[EOMissile, $FusionDamageType] = 1.0;
$DamageScale[SurveyDrone, $FusionDamageType] = 1.0;
$DamageScale[ProbeDroid, $FusionDamageType] = 1.0;
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
$DamageScale[BlastechM, $MBHeatDamageType] = 1;
$DamageScale[MagIonM, $MBHeatDamageType] = 1;
$DamageScale[MECH, $MBHeatDamageType] = 0.5;
$DamageScale[BlastechF, $MBHeatDamageType] = 1;
$DamageScale[MagIonF, $MBHeatDamageType] = 1;

$DamageScale[Scout, $MBHeatDamageType] = 1.0;
$DamageScale[EscapePod, $MBHeatDamageType] = 1.0;
$DamageScale[PyroXL, $MBHeatDamageType] = 1.0;
$DamageScale[LAPC, $MBHeatDamageType] = 1.0;
$DamageScale[HAPC, $MBHeatDamageType] = 1.0;
$DamageScale[ScouterMissile, $MBHeatDamageType] = 1.0;
$DamageScale[EOMissile, $MBHeatDamageType] = 1.0;
$DamageScale[SurveyDrone, $MBHeatDamageType] = 1.0;
$DamageScale[ProbeDroid, $MBHeatDamageType] = 1.0;
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
$DamageScale[BlastechM, $MBDamageType] = 1;
$DamageScale[MagIonM, $MBDamageType] = 1;
$DamageScale[MECH, $MBDamageType] = 1;
$DamageScale[BlastechF, $MBDamageType] = 1;
$DamageScale[MagIonF, $MBDamageType] = 1;

$DamageScale[Scout, $MBDamageType] = 1.0;
$DamageScale[EscapePod, $MBDamageType] = 1.0;
$DamageScale[PyroXL, $MBDamageType] = 1.0;
$DamageScale[LAPC, $MBDamageType] = 1.0;
$DamageScale[HAPC, $MBDamageType] = 1.0;
$DamageScale[ScouterMissile, $MBDamageType] = 1.0;
$DamageScale[EOMissile, $MBDamageType] = 1.0;
$DamageScale[SurveyDrone, $MBDamageType] = 1.0;
$DamageScale[ProbeDroid, $MBDamageType] = 1.0;
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
$DamageScale[BlastechM, $VertigoDamageType] = 1.0;
$DamageScale[BlastechF, $VertigoDamageType] = 1.0;
$DamageScale[MagIonM, $VertigoDamageType] = 1.0;
$DamageScale[MagIonF, $VertigoDamageType] = 1.0;
$DamageScale[MECH, $VertigoDamageType] = 1.0;

$DamageScale[Scout, $VertigoDamageType] = 1.0;
$DamageScale[EscapePod, $VertigoDamageType] = 1.0;
$DamageScale[PyroXL, $VertigoDamageType] = 1.0;
$DamageScale[LAPC, $VertigoDamageType] = 1.0;
$DamageScale[HAPC, $VertigoDamageType] = 1.0;
$DamageScale[ScouterMissile, $VertigoDamageType] = 1.0;
$DamageScale[EOMissile, $VertigoDamageType] = 1.0;
$DamageScale[SurveyDrone, $VertigoDamageType] = 1.0;
$DamageScale[ProbeDroid, $VertigoDamageType] = 1.0;
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
$DamageScale[BlastechM, $VulcanDamageType] = 1.0;
$DamageScale[BlastechF, $VulcanDamageType] = 1.0;
$DamageScale[MagIonM, $VulcanDamageType] = 1.0;
$DamageScale[MagIonF, $VulcanDamageType] = 1.0;
$DamageScale[MECH, $VulcanDamageType] = 1.0;

$DamageScale[Scout, $VulcanDamageType] = 1.0;
$DamageScale[EscapePod, $VulcanDamageType] = 1.0;
$DamageScale[PyroXL, $VulcanDamageType] = 1.0;
$DamageScale[LAPC, $VulcanDamageType] = 1.0;
$DamageScale[HAPC, $VulcanDamageType] = 1.0;
$DamageScale[ScouterMissile, $VulcanDamageType] = 1.0;
$DamageScale[EOMissile, $VulcanDamageType] = 1.0;
$DamageScale[SurveyDrone, $VulcanDamageType] = 1.0;
$DamageScale[ProbeDroid, $VulcanDamageType] = 1.0;
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
$DamageScale[BlastechM, $GaussDamageType] = -0.05;
$DamageScale[MagIonM, $GaussDamageType] = 1;
$DamageScale[MECH, $GaussDamageType] = 1;
$DamageScale[BlastechF, $GaussDamageType] = -0.05;
$DamageScale[MagIonF, $GaussDamageType] = 1;

$DamageScale[Scout, $GaussDamageType] = 1.0;
$DamageScale[EscapePod, $GaussDamageType] = 1.0;
$DamageScale[PyroXL, $GaussDamageType] = 1.0;
$DamageScale[LAPC, $GaussDamageType] = 1.0;
$DamageScale[HAPC, $GaussDamageType] = 1.0;
$DamageScale[ScouterMissile, $GaussDamageType] = 1.0;
$DamageScale[EOMissile, $GaussDamageType] = 1.0;
$DamageScale[SurveyDrone, $GaussDamageType] = 1.0;
$DamageScale[ProbeDroid, $GaussDamageType] = 1.0;
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

$DamageScale[larmor, $MassDamageType] = 1.0;
$DamageScale[marmor, $MassDamageType] = 1.0;
$DamageScale[harmor, $MassDamageType] = 1.0;
$DamageScale[lfemale, $MassDamageType] = 1.0;
$DamageScale[mfemale, $MassDamageType] = 1.0;
$DamageScale[BlastechM, $MassDamageType] = -0.1;
$DamageScale[MagIonM, $MassDamageType] = 1;
$DamageScale[MECH, $MassDamageType] = 1;
$DamageScale[BlastechF, $MassDamageType] = -0.1;
$DamageScale[MagIonF, $MassDamageType] = 1;
$DamageScale[Scout, $MassDamageType] = 1.0;
$DamageScale[EscapePod, $MassDamageType] = 1.0;
$DamageScale[PyroXL, $MassDamageType] = 1.0;

$DamageScale[LAPC, $MassDamageType] = 1.0;
$DamageScale[HAPC, $MassDamageType] = 1.0;
$DamageScale[ScouterMissile, $MassDamageType] = 1.0;
$DamageScale[EOMissile, $MassDamageType] = 1.0;
$DamageScale[SurveyDrone, $MassDamageType] = 1.0;
$DamageScale[ProbeDroid, $MassDamageType] = 1.0;
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
$DamageScale[BlastechM, $SniperDamageType] = 1;
$DamageScale[MagIonM, $SniperDamageType] = 1;
$DamageScale[MECH, $SniperDamageType] = 1;
$DamageScale[BlastechF, $SniperDamageType] = 1;
$DamageScale[MagIonF, $SniperDamageType] = 1;

$DamageScale[Scout, $SniperDamageType] = 1.0;
$DamageScale[EscapePod, $SniperDamageType] = 1.0;
$DamageScale[PyroXL, $SniperDamageType] = 1.0;
$DamageScale[LAPC, $SniperDamageType] = 1.0;
$DamageScale[HAPC, $SniperDamageType] = 1.0;
$DamageScale[ScouterMissile, $SniperDamageType] = 1.0;
$DamageScale[EOMissile, $SniperDamageType] = 1.0;
$DamageScale[SurveyDrone, $SniperDamageType] = 1.0;
$DamageScale[ProbeDroid, $SniperDamageType] = 1.0;
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
$DamageScale[BlastechM, $ShotgunDamageType] = 1;
$DamageScale[MagIonM, $ShotgunDamageType] = 1;
$DamageScale[MECH, $ShotgunDamageType] = 1;
$DamageScale[BlastechF, $ShotgunDamageType] = 1;
$DamageScale[MagIonF, $ShotgunDamageType] = 1;

$DamageScale[Scout, $ShotgunDamageType] = 1.0;
$DamageScale[EscapePod, $ShotgunDamageType] = 1.0;
$DamageScale[PyroXL, $ShotgunDamageType] = 1.0;
$DamageScale[LAPC, $ShotgunDamageType] = 1.0;
$DamageScale[HAPC, $ShotgunDamageType] = 1.0;
$DamageScale[ScouterMissile, $ShotgunDamageType] = 1.0;
$DamageScale[EOMissile, $ShotgunDamageType] = 1.0;
$DamageScale[SurveyDrone, $ShotgunDamageType] = 1.0;
$DamageScale[ProbeDroid, $ShotgunDamageType] = 1.0;
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
$DamageScale[BlastechM, $MethaneDamageType] = 1;
$DamageScale[MagIonM, $MethaneDamageType] = 1;
$DamageScale[MECH, $MethaneDamageType] = 1;
$DamageScale[BlastechF, $MethaneDamageType] = 1;
$DamageScale[MagIonF, $MethaneDamageType] = 1;

$DamageScale[larmor, $EMPFieldDamageType] = 1.0;
$DamageScale[marmor, $EMPFieldDamageType] = 1.0;
$DamageScale[harmor, $EMPFieldDamageType] = 1.0;
$DamageScale[lfemale, $EMPFieldDamageType] = 1.0;
$DamageScale[mfemale, $EMPFieldDamageType] = 1.0;
$DamageScale[BlastechM, $EMPFieldDamageType] = 1;
$DamageScale[MagIonM, $EMPFieldDamageType] = 1;
$DamageScale[MECH, $EMPFieldDamageType] = 1;
$DamageScale[BlastechF, $EMPFieldDamageType] = 1;
$DamageScale[MagIonF, $EMPFieldDamageType] = 1;

$DamageScale[larmor, $PBWDamageType] = 1.0;
$DamageScale[marmor, $PBWDamageType] = 1.0;
$DamageScale[harmor, $PBWDamageType] = 1.0;
$DamageScale[lfemale, $PBWDamageType] = 1.0;
$DamageScale[mfemale, $PBWDamageType] = 1.0;
$DamageScale[BlastechM, $PBWDamageType] = 1;
$DamageScale[MagIonM, $PBWDamageType] = 1;
$DamageScale[MECH, $PBWDamageType] = 1;
$DamageScale[BlastechF, $PBWDamageType] = 1;
$DamageScale[MagIonF, $PBWDamageType] = 1;

$DamageScale[Scout, $PBWDamageType] = 1.0;
$DamageScale[EscapePod, $PBWDamageType] = 1.0;
$DamageScale[PyroXL, $PBWDamageType] = 1.0;
$DamageScale[LAPC, $PBWDamageType] = 1.0;
$DamageScale[HAPC, $PBWDamageType] = 1.0;
$DamageScale[ScouterMissile, $PBWDamageType] = 1.0;
$DamageScale[EOMissile, $PBWDamageType] = 1.0;
$DamageScale[SurveyDrone, $PBWDamageType] = 1.0;
$DamageScale[ProbeDroid, $PBWDamageType] = 1.0;
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
$DamageScale[BlastechM, $NullDamageType] = 0.0;
$DamageScale[BlastechF, $NullDamageType] = 0.0;
$DamageScale[MagIonM, $NullDamageType] = 0.0;
$DamageScale[MagIonF, $NullDamageType] = 0.0;
$DamageScale[MECH, $NullDamageType] = 0.0;

$DamageScale[Scout, $NullDamageType] = -0.8;
$DamageScale[EscapePod, $NullDamageType] = -0.8;
$DamageScale[PyroXL, $NullDamageType] = -0.8;
$DamageScale[LAPC, $NullDamageType] = -0.8;
$DamageScale[HAPC, $NullDamageType] = -0.8;
$DamageScale[ScouterMissile, $NullDamageType] = -0.8;
$DamageScale[EOMissile, $NullDamageType] = -0.8;
$DamageScale[SurveyDrone, $NullDamageType] = -0.8;
$DamageScale[ProbeDroid, $NullDamageType] = -0.8;
$DamageScale[Interceptor, $NullDamageType] = -0.8;
$DamageScale[HoverTank, $NullDamageType] = -0.8;
$DamageScale[Explorer, $NullDamageType] = -0.8;
$DamageScale[Avenger, $NullDamageType] = -0.8;
$DamageScale[StarFighter, $NullDamageType] = -0.80;
$DamageScale[Icarus, $NullDamageType] = -0.8;
$DamageScale[Skyranger, $NullDamageType] = -0.8;
$DamageScale[StarHammer, $NullDamageType] = -0.8;
$DamageScale[SkyCutter, $NullDamageType] = -0.8;
$DamageScale[Arwing, $NullDamageType] = -0.8;

$DamageScale[larmor, $six66] = 1.0;
$DamageScale[marmor, $six66] = 1.0;
$DamageScale[harmor, $six66] = 1.0;
$DamageScale[lfemale, $six66] = 1.0;
$DamageScale[mfemale, $six66] = 1.0;
$DamageScale[BlastechM, $six66] = 1.0;
$DamageScale[BlastechF, $six66] = 1.0;
$DamageScale[MagIonM, $six66] = 1.0;
$DamageScale[MagIonF, $six66] = 1.0;
$DamageScale[MECH, $six66] = 1.0;

$DamageScale[Scout, $six66] = 1.0;
$DamageScale[EscapePod, $six66] = 1.0;
$DamageScale[PyroXL, $six66] = 1.0;
$DamageScale[LAPC, $six66] = 1.0;
$DamageScale[HAPC, $six66] = 1.0;
$DamageScale[ScouterMissile, $six66] = 1.0;
$DamageScale[EOMissile, $six66] = 1.0;
$DamageScale[SurveyDrone, $six66] = 1.0;
$DamageScale[ProbeDroid, $six66] = 1.0;
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

$DamageScale[larmor, $DisarmDamageType] = 1.0;
$DamageScale[marmor, $DisarmDamageType] = 1.0;
$DamageScale[harmor, $DisarmDamageType] = 1.0;
$DamageScale[lfemale, $DisarmDamageType] = 1.0;
$DamageScale[mfemale, $DisarmDamageType] = 1.0;
$DamageScale[BlastechM, $DisarmDamageType] = 1.0;
$DamageScale[BlastechF, $DisarmDamageType] = 1.0;
$DamageScale[MagIonM, $DisarmDamageType] = 1.0;
$DamageScale[MagIonF, $DisarmDamageType] = 1.0;
$DamageScale[MECH, $DisarmDamageType] = 1.0;

$DamageScale[Scout, $DisarmDamageType] = 1.0;
$DamageScale[EscapePod, $DisarmDamageType] = 1.0;
$DamageScale[PyroXL, $DisarmDamageType] = 1.0;
$DamageScale[LAPC, $DisarmDamageType] = 1.0;
$DamageScale[HAPC, $DisarmDamageType] = 1.0;
$DamageScale[ScouterMissile, $DisarmDamageType] = 1.0;
$DamageScale[EOMissile, $DisarmDamageType] = 1.0;
$DamageScale[SurveyDrone, $DisarmDamageType] = 1.0;
$DamageScale[ProbeDroid, $DisarmDamageType] = 1.0;
$DamageScale[Interceptor, $DisarmDamageType] = 1.0;
$DamageScale[HoverTank, $DisarmDamageType] = 1.0;
$DamageScale[Explorer, $DisarmDamageType] = 1.0;
$DamageScale[Avenger, $DisarmDamageType] = 1.0;
$DamageScale[StarFighter, $DisarmDamageType] = 1.0;
$DamageScale[Icarus, $DisarmDamageType] = 1.0;
$DamageScale[Skyranger, $DisarmDamageType] = 1.0;
$DamageScale[StarHammer, $DisarmDamageType] = 1.0;
$DamageScale[SkyCutter, $DisarmDamageType] = 1.0;
$DamageScale[Arwing, $DisarmDamageType] = 1.0;


$DamageScale[larmor, $TractorDamageType] = 1.0;
$DamageScale[marmor, $TractorDamageType] = 1.0;
$DamageScale[harmor, $TractorDamageType] = 1.0;
$DamageScale[lfemale, $TractorDamageType] = 1.0;
$DamageScale[mfemale, $TractorDamageType] = 1.0;
$DamageScale[BlastechM, $TractorDamageType] = 1.0;
$DamageScale[BlastechF, $TractorDamageType] = 1.0;
$DamageScale[MagIonM, $TractorDamageType] = 1.0;
$DamageScale[MagIonF, $TractorDamageType] = 1.0;
$DamageScale[MECH, $TractorDamageType] = 1.0;
