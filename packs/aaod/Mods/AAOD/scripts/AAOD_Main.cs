$ver="1.6Ex";
//----------------------------------------------------------------------------
$ItemFavoritesKey = "AAOD"; 
//----------------------------------------------------------------------------

exec(AAOD_Armor);	
	
//---------------------------
//***** New Damage Types ****
//---------------------------
$SniperXDamageType		= 14;
$FlameDamageType		= 15;
$BusterDamageType		= 16;
$BeaconDamageType		= 17;
$ReaperDamageType		= 18;
$DesignatorDamageType	= 19;
$StasisDamageType		= 20;
$StingerDamageType		= 21;
$GrogDamageType			= 22;
$SamDamageType			= 23;
$InfernoDamageType		= 24;
$VelcroDamageType		= 25;
$MortDamageType			= 26;
$ArtyDamageType			= 27;
$AADamageType			= 28;
$AmbushAPDamageType		= 29;
$AmbushAADamageType		= 30;

$PTurretDamageType		= 31;	
$RTurretDamageType		= 32;
$ITurretDamageType		= 33;
$ETurretDamageType		= 34;
$DTurretDamageType		= 35;


$DamageScale[larmor,$SniperXDamageType]		= 0.65;
$DamageScale[larmor,$FlameDamageType]		= 1.15;
$DamageScale[larmor,$BusterDamageType]		= 0.15;
$DamageScale[larmor,$BeaconDamageType]		= 0.20;
$DamageScale[larmor,$ReaperDamageType]		= 1.0;
$DamageScale[larmor,$DesignatorDamageType]	= 1.0;
$DamageScale[larmor,$StasisDamageType]		= 1.0;
$DamageScale[larmor,$GrogDamageType]		= 1.2;
$DamageScale[larmor,$SamDamageType]			= 1.0;
$DamageScale[larmor,$InfernoDamageType]		= 1.5;
$DamageScale[larmor,$VelcroDamageType]		= 1.0;
$DamageScale[larmor,$MortDamageType]		= 1.2;
$DamageScale[larmor,$ArtyDamageType]		= 1.4;
$DamageScale[larmor,$AADamageType]			= 1.15;
$DamageScale[larmor, $PTurretDamageType] = 1.3;
$DamageScale[larmor, $RTurretDamageType] = 1.3;
$DamageScale[larmor, $ITurretDamageType] = 1.3;
$DamageScale[larmor, $ETurretDamageType] = 1.3;
$DamageScale[larmor, $DTurretDamageType] = 1.3;


$DamageScale[lfemale,$ReaperDamageType]		= 1.0;
$DamageScale[lfemale,$SniperXDamageType]	= 0.65;
$DamageScale[lfemale,$FlameDamageType]		= 1.15;
$DamageScale[lfemale,$BusterDamageType]		= 0.15;
$DamageScale[lfemale,$BeaconDamageType]		= 0.20;
$DamageScale[lfemale,$DesignatorDamageType]	= 1.0;
$DamageScale[lfemale,$StasisDamageType]		= 1.0;
$DamageScale[lfemale,$GrogDamageType]		= 1.2;
$DamageScale[lfemale,$SamDamageType]		= 1.0;
$DamageScale[lfemale,$InfernoDamageType]	= 1.5;
$DamageScale[lfemale,$VelcroDamageType]		= 1.0;
$DamageScale[lfemale,$MortDamageType]		= 1.2;
$DamageScale[lfemale,$ArtyDamageType]		= 1.4;
$DamageScale[lfemale,$AADamageType]			= 1.15;
$DamageScale[lfemale, $PTurretDamageType] = 1.3;
$DamageScale[lfemale, $RTurretDamageType] = 1.3;
$DamageScale[lfemale, $ITurretDamageType] = 1.3;
$DamageScale[lfemale, $ETurretDamageType] = 1.3;
$DamageScale[lfemale, $DTurretDamageType] = 1.3;



$DamageScale[marmor,$ReaperDamageType]		= 1.20;
$DamageScale[marmor,$SniperXDamageType]		= 0.65;
$DamageScale[marmor,$FlameDamageType]		= 1.15;
$DamageScale[marmor,$BusterDamageType]		= 0.25;
$DamageScale[marmor,$BeaconDamageType]		= 0.20;
$DamageScale[marmor,$DesignatorDamageType]	= 1.0;
$DamageScale[marmor,$StasisDamageType]		= 1.0;
$DamageScale[marmor,$GrogDamageType]		= 1.0;
$DamageScale[marmor,$SamDamageType]			= 1.0;
$DamageScale[marmor,$InfernoDamageType]		= 1.0;
$DamageScale[marmor,$VelcroDamageType]		= 0.65;
$DamageScale[marmor,$MortDamageType]		= 1.0;
$DamageScale[marmor,$ArtyDamageType]		= 1.15;
$DamageScale[marmor,$AADamageType]			= 1.0;
$DamageScale[marmor, $PTurretDamageType] = 1.0;
$DamageScale[marmor, $RTurretDamageType] = 1.0;
$DamageScale[marmor, $ITurretDamageType] = 1.0;
$DamageScale[marmor, $ETurretDamageType] = 1.0;
$DamageScale[marmor, $DTurretDamageType] = 1.0;


$DamageScale[mfemale,$ReaperDamageType]		= 1.20;
$DamageScale[mfemale,$SniperXDamageType]	= 0.65;
$DamageScale[mfemale,$FlameDamageType]		= 0.95;
$DamageScale[mfemale,$BusterDamageType]		= 0.25;
$DamageScale[mfemale,$BeaconDamageType]		= 0.20;
$DamageScale[mfemale,$DesignatorDamageType]	= 1.0;
$DamageScale[mfemale,$StasisDamageType]		= 1.0;
$DamageScale[mfemale,$GrogDamageType]		= 1.0;
$DamageScale[mfemale,$SamDamageType]		= 1.0;
$DamageScale[mfemale,$InfernoDamageType]	= 1.0;
$DamageScale[mfemale,$VelcroDamageType]		= 0.65;
$DamageScale[mfemale,$MortDamageType]		= 1.0;
$DamageScale[mfemale,$ArtyDamageType]		= 1.15;
$DamageScale[mfemale,$AADamageType]			= 1.0;
$DamageScale[mfemale,$PTurretDamageType] = 1.0;
$DamageScale[mfemale,$RTurretDamageType] = 1.0;
$DamageScale[mfemale,$ITurretDamageType] = 1.0;
$DamageScale[mfemale,$ETurretDamageType] = 1.0;
$DamageScale[mfemale,$DTurretDamageType] = 1.0;

$DamageScale[harmor,$ReaperDamageType]		= 0.85;
$DamageScale[harmor,$SniperXDamageType]		= 1.65;
$DamageScale[harmor,$FlameDamageType]		= 1.00;
$DamageScale[harmor,$BusterDamageType]		= 0.45;
$DamageScale[harmor,$BeaconDamageType]		= 0.20;
$DamageScale[harmor,$DesignatorDamageType]	= 1.0;
$DamageScale[harmor,$StasisDamageType]		= 1.0;
$DamageScale[harmor,$GrogDamageType]		= 0.65;
$DamageScale[harmor,$SamDamageType]			= 0.5;
$DamageScale[harmor,$InfernoDamageType]		= 1.0;
$DamageScale[harmor,$VelcroDamageType]		= 0.40;
$DamageScale[harmor,$MortDamageType]		= 0.7;
$DamageScale[harmor,$ArtyDamageType]		= 0.8;
$DamageScale[harmor,$AADamageType]			= 0.6;
$DamageScale[harmor,$PTurretDamageType]	= 0.7;
$DamageScale[harmor,$RTurretDamageType]	= 0.7;
$DamageScale[harmor,$ITurretDamageType]	= 0.7;
$DamageScale[harmor,$ETurretDamageType]	= 0.7;
$DamageScale[harmor,$DTurretDamageType]	= 0.7;

$DamageScale[larmor,$AmbushAPDamageType]		= 1.0;
$DamageScale[marmor,$AmbushAPDamageType]		= 1.0;
$DamageScale[lfemale,$AmbushAPDamageType]		= 1.0;
$DamageScale[mfemale,$AmbushAPDamageType]		= 1.0;
$DamageScale[harmor,$AmbushAPDamageType]		= 1.0;

$DamageScale[larmor,$AmbushAADamageType]		= 1.0;
$DamageScale[marmor,$AmbushAADamageType]		= 1.0;
$DamageScale[lfemale,$AmbushAADamageType]		= 1.0;
$DamageScale[mfemale,$AmbushAADamageType]		= 1.0;
$DamageScale[harmor,$AmbushAADamageType]		= 1.0;

$DamageScale[larmor,$StingerDamageType]		= 1.0;
$DamageScale[marmor,$StingerDamageType]		= 1.0;
$DamageScale[lfemale,$StingerDamageType]	= 1.0;
$DamageScale[mfemale,$StingerDamageType]	= 1.0;
$DamageScale[harmor,$StingerDamageType]		= 0.6;

$deathMsg[$ReaperDamageType, 0] = "%2 is Swiss Cheese after %1's Reaper mows him down!."; 
$deathMsg[$ReaperDamageType, 1] = "%1 Ventellates %2's armor/body and everything else ."; 
$deathMsg[$ReaperDamageType, 2] = "%2 becomes a victim of %1's REAPER.";
$deathMsg[$ReaperDamageType, 3] = "%2 become a multiple gunshot wound victim of %1.";

$deathMsg[$SniperXDamageType, 0] = "%2 is Clueless after %1's SniperX Shot."; 
$deathMsg[$SniperXDamageType, 1] = "%1 punches a hole through %2's with his HP SniperX Round."; 
$deathMsg[$SniperXDamageType, 2] = "%2 Has been pushed off this Mortal realm by %1's SniperX.";
$deathMsg[$SniperXDamageType, 3] = "%2 REALLY never Saw it coming from %1.'s SniperX";

$deathMsg[$BeaconDamageType, 0] = "%2 must have been clueless to be hit by %1's Beacon Shot."; 
$deathMsg[$BeaconDamageType, 1] = "%1 Obliterates %2's with his Beacon."; 
$deathMsg[$BeaconDamageType, 2] = "%2 becomes a victim of %1's Beacon.";
$deathMsg[$BeaconDamageType, 3] = "%1's Beacon Shot makes a greasy spot where %2 was napping";

$deathMsg[$FlameDamageType, 0] = "%2 is Crispy %1's Inferno Blast."; 
$deathMsg[$FlameDamageType, 1] = "%1 Roasts %2's with his Inferno Mine."; 
$deathMsg[$FlameDamageType, 2] = "%2 becomes a victim of %1's Inferno Mine.";
$deathMsg[$FlameDamageType, 3] = "%2 Should Stay out of the Kitchen - Let alone %1's Oven";

$deathMsg[$BusterDamageType, 0] = "%2 must have been clueless to be hit by %1's Bunker Buster Shot."; 
$deathMsg[$BusterDamageType, 1] = "%1 Obliterates %2's with his Bunker Buster."; 
$deathMsg[$BusterDamageType, 2] = "%2 becomes a victim of %1's Bunker Buster.";
$deathMsg[$BusterDamageType, 3] = "%1's Buster Shot makes a greasy spot where %2 was napping";

$deathMsg[$StasisDamageType, 0] = "%2 is Motionless after %1's Stasis Shot."; 
$deathMsg[$StasisDamageType, 1] = "%1 punches a hole through %2's reality."; 
$deathMsg[$StasisDamageType, 2] = "%2 becomes a victim of %1's Alternate Dimension.";
$deathMsg[$StasisDamageType, 3] = "%2 Became Stuck in Time...";

$deathMsg[$GrogDamageType, 0] = "%1's Chaingun TURRET chews %2 to peices."; 
$deathMsg[$GrogDamageType, 1] = "%2 is Air Conditioned by %1's Chaingun TURRET."; 
$deathMsg[$GrogDamageType, 2] = "%2 has been perforated by a Chaingun TURRET deployed by %1.";
$deathMsg[$GrogDamageType, 3] = "%2 meets a Hail of Lead from %1's Chaingun TURRET.";

$deathMsg[$SamDamageType, 0] = "%2 is shot down by %1's SAM TURRET."; 
$deathMsg[$SamDamageType, 1] = "%1's SAM TURRET punches %2 right out of the Sky."; 
$deathMsg[$SamDamageType, 2] = "%2 becomes a Guided Missile Statistic of %1's SAM TURRET.";
$deathMsg[$SamDamageType, 3] = "%2 should've looked before leaping into the sights of %1's SAM Turret.";

$deathMsg[$InfernoDamageType, 0] = "%2 is Crispy fried by %1's Inferno Blast."; 
$deathMsg[$InfernoDamageType, 1] = "The %1 Team Roasts %2's with thier Inferno Mine."; 
$deathMsg[$InfernoDamageType, 2] = "%2 becomes a victim of %1's Inferno Mine.";
$deathMsg[$InfernoDamageType, 3] = "%2 Should Stay out of the Kitchen - Let alone the %1 Oven";

$deathMsg[$VelcroDamageType, 0] = "%2 gets a real CHARGE out of one of the %1 VELCRO TURRETS."; 
$deathMsg[$VelcroDamageType, 1] = "The %1 team Shocks %2's sensibilities with thier VELCRO TURRET."; 
$deathMsg[$VelcroDamageType, 2] = "%2 becomes another victim of the %1 VELCRO TURRET.";
$deathMsg[$VelcroDamageType, 3] = "%2 should look a little harder for the %1 VELCRO TURRET!";

$deathMsg[$MortDamageType, 0] = "%2 is Riddled with %1 MORT TURRET Barrage."; 
$deathMsg[$MortDamageType, 1] = "The %1 MORT TURRET Mows %2 down with unparalelled efficiency!"; 
$deathMsg[$MortDamageType, 2] = "%2 becomes a ventillated shadow of his former self. Aided by %1's MORT TURRET.";
$deathMsg[$MortDamageType, 3] = "%2 has become a chalk outline thanks to the %1 MORT TURRET!";

$deathMsg[$ArtyDamageType, 0] = "%2 is wiped off the face of the earth by %1's Artillery Shot."; 
$deathMsg[$ArtyDamageType, 1] = "%1 Rocks %2's world with a well Placed Artillery Shot."; 
$deathMsg[$ArtyDamageType, 2] = "%2 becomes OUTGOING after %1's INCOMING Artilley shell.";
$deathMsg[$ArtyDamageType, 3] = "%2 becomes one with the crater of %1's Artillery Shot";

$deathMsg[$AADamageType, 0] = "%2 is Red rain after a %1's ANTI AIR Blast."; 
$deathMsg[$AADamageType, 1] = "%1's ANTI AIR Battery Greets %2 with an explosive hug."; 
$deathMsg[$AADamageType, 2] = "%2 becomes one with a universe of expanding Gases after %1's AA Turret Barrage.";
$deathMsg[$AADamageType, 3] = "%2 Should learn not to fly around enemy %1's ANTI AIR emplacments!";

$deathMsg[$AmbushAPDamageType, 0] = "%2 is caught by surprise by a %1's AMBUSHER Turret."; 
$deathMsg[$AmbushAPDamageType, 1] = "%1's AMBUSHER TURRET Greets %2 with an unexpected barrage."; 
$deathMsg[$AmbushAPDamageType, 2] = "%2 is shocked to discover the wereabouts of %1's AMBUSHER Turret";
$deathMsg[$AmbushAPDamageType, 3] = "%2 Should learn to look a little more carefully for %1's AMBUSHER Turrets";

$deathMsg[$AmbushAAPDamageType, 0] = "%2 is caught unawares by an %1 AMBUSHER Missile."; 
$deathMsg[$AmbushAADamageType, 1] = "One of the %1 AMBUSHER TURRETs Greets %2 with an unexpected salvo of heat seekers!"; 
$deathMsg[$AmbushAADamageType, 2] = "%2 is shocked to discover the wereabouts of on of the %1 AMBUSHER ANTI AIR Turrets";
$deathMsg[$AmbushAADamageType, 3] = "%2 Should look before trying to leap near AMBUSHER ANTI AIR Turrets belonging to %1";

$deathMsg[$StingerDamageType, 0] = "%2 is shot down by %1's Missile."; 
$deathMsg[$StingerDamageType, 1] = "%1's Guided Missile knocks %2 right out of the Sky."; 
$deathMsg[$StingerDamageType, 2] = "%2 takes the heat from %1's Heat Seeking Missile.";
$deathMsg[$StingerDamageType, 3] = "%2 experinces DEATH by %1's Lethal Missile injection.";

$deathMsg[$PTurretDamageType, 0] = "%2 is electrified by one of the %1 PLASMA Turrets FUSION Bolt."; 
$deathMsg[$PTurretDamageType, 1] = "A %1 PLASMA Turret melts %2 right out of %4 boots."; 
$deathMsg[$PTurretDamageType, 2] = "%2 takes the heat from %1's PLASMA Turret.";
$deathMsg[$PTurretDamageType, 3] = "%2 experinces DEATH by electrocution Courtesy of the %1 PLASMA Turret.";

$deathMsg[$RTurretDamageType, 0] = "%2 is eliminated by the %1 Rocket Turret."; 
$deathMsg[$RTurretDamageType, 1] = "The %1 Rocket Turret shoots %2 down."; 
$deathMsg[$RTurretDamageType, 2] = "%2 crashes and burns thanks to the %1 ROCKET Turret.";
$deathMsg[$RTurretDamageType, 3] = "The %1 Rocket Turret Clears the Sky of %2 with ROCKET Love!";

$deathMsg[$ITurretDamageType, 0] = "%2 is electrified by %1's Indoor Turrets FUSION Bolts."; 
$deathMsg[$ITurretDamageType, 1] = "%1's Indoor Turret melts %2 right out of %4 boots."; 
$deathMsg[$ITurretDamageType, 2] = "%2 should note that charging %1's indoor turrets is NOT good for the health.";
$deathMsg[$ITurretDamageType, 3] = "%2 experiences Heart Failure Courtesy of %1's Indoor Turret.";

$deathMsg[$ETurretDamageType, 0] = "%2 is lit up by %1's ELF Turret."; 
$deathMsg[$ETurretDamageType, 1] = "%1's ELF turret shocks %2 right out of %4 shorts."; 
$deathMsg[$ETurretDamageType, 2] = "%2 gets short circuited by %1's ELF Turret.";
$deathMsg[$ETurretDamageType, 3] = "%2 experinces DEATH by electrocution Courtesy of %1's ELF Turret.";

$deathMsg[$DTurretDamageType, 0] = "%2 is electrified by %1's Deployable Turrets cutsie little FUSION Bolts."; 
$deathMsg[$DTurretDamageType, 1] = "%1's Indoor Turret blows %2 right out of %4 boots."; 
$deathMsg[$DTurretDamageType, 2] = "%2 should note that %1's deployable turrets are quite accurate.";
$deathMsg[$DTurretDamageType, 3] = "%2 experiences incandescance from %1's deployable Turret.";

$DamageScale[Scout,$ReaperDamageType]		= 1.0;
$DamageScale[Scout,$SniperXDamageType]		= 1.0;
$DamageScale[Scout,$FlameDamageType]		= 1.0;
$DamageScale[Scout,$BusterDamageType]		= 1.0;
$DamageScale[Scout,$BeaconDamageType]		= 1.0;
$DamageScale[Scout,$DesignatorDamageType]	= 1.0;
$DamageScale[Scout,$StasisDamageType]		= 1.0;
$DamageScale[Scout,$GrogDamageType]			= 1.0;
$DamageScale[Scout,$SamDamageType]			= 1.2;
$DamageScale[Scout,$InfernoDamageType]		= 1.0;
$DamageScale[Scout,$VelcroDamageType]		= 1.0;
$DamageScale[Scout,$MortDamageType]			= 1.0;
$DamageScale[Scout,$ArtyDamageType]			= 1.0;
$DamageScale[Scout,$AADamageType]			= 1.3;
$DamageScale[Scout,$PTurretDamageType]		= 1;
$DamageScale[Scout,$RTurretDamageType]		= 1;
$DamageScale[Scout,$ITurretDamageType]		= 1;
$DamageScale[Scout,$ETurretDamageType]		= 1;
$DamageScale[Scout,$DTurretDamageType]		= 1;

$DamageScale[LAPC,$ReaperDamageType]		= 1.0;
$DamageScale[LAPC,$SniperXDamageType]		= 1.2;
$DamageScale[LAPC,$FlameDamageType]			= 1.0;
$DamageScale[LAPC,$BusterDamageType]		= 1.2;
$DamageScale[LAPC,$BeaconDamageType]		= 1.0;
$DamageScale[LAPC,$DesignatorDamageType]	= 1.0;
$DamageScale[LAPC,$StasisDamageType]		= 1.0;
$DamageScale[LAPC,$GrogDamageType]			= 1.0;
$DamageScale[LAPC,$SamDamageType]			= 1.2;
$DamageScale[LAPC,$InfernoDamageType]		= 1.0;
$DamageScale[LAPC,$VelcroDamageType]		= 1.0;
$DamageScale[LAPC,$MortDamageType]			= 1.0;
$DamageScale[LAPC,$ArtyDamageType]			= 1.0;
$DamageScale[LAPC,$AADamageType]			= 1.3;
$DamageScale[LAPC,$PTurretDamageType]		= 1;
$DamageScale[LAPC,$RTurretDamageType]		= 1;
$DamageScale[LAPC,$ITurretDamageType]		= 1;
$DamageScale[LAPC,$ETurretDamageType]		= 1;
$DamageScale[LAPC,$DTurretDamageType]		= 1;



$DamageScale[HAPC,$ReaperDamageType]		= 1.0;
$DamageScale[HAPC,$SniperXDamageType]		= 1.5;
$DamageScale[HAPC,$FlameDamageType]			= 1.0;
$DamageScale[HAPC,$BusterDamageType]		= 1.5;
$DamageScale[HAPC,$BeaconDamageType]		= 1.0;
$DamageScale[HAPC,$DesignatorDamageType]	= 1.0;
$DamageScale[HAPC,$StasisDamageType]		= 1.0;
$DamageScale[HAPC,$GrogDamageType]			= 1.0;
$DamageScale[HAPC,$SamDamageType]			= 1.2;
$DamageScale[HAPC,$InfernoDamageType]		= 1.0;
$DamageScale[HAPC,$VelcroDamageType]		= 1.0;
$DamageScale[HAPC,$MortDamageType]			= 1.0;
$DamageScale[HAPC,$ArtyDamageType]			= 1.0;
$DamageScale[HAPC,$AADamageType]			= 1.3;
$DamageScale[HAPC,$PTurretDamageType]		= 1;
$DamageScale[HAPC,$RTurretDamageType]		= 1;
$DamageScale[HAPC,$ITurretDamageType]		= 1;
$DamageScale[HAPC,$ETurretDamageType]		= 1;
$DamageScale[HAPC,$DTurretDamageType]		= 1;

$DamageScale[HoverBike, $ImpactDamageType] 		= 1.0;	
$DamageScale[HoverBike, $BulletDamageType] 		= 1.0;	
$DamageScale[HoverBike, $PlasmaDamageType] 		= 1.0;	
$DamageScale[HoverBike, $EnergyDamageType] 		= 1.0;	
$DamageScale[HoverBike, $ExplosionDamageType] 	= 1.15;	
$DamageScale[HoverBike, $ShrapnelDamageType]	= 1.14;	
$DamageScale[HoverBike, $DebrisDamageType] 		= 1.13;	
$DamageScale[HoverBike, $MissileDamageType]		= 1.25;	
$DamageScale[HoverBike, $LaserDamageType] 		= 0.65;	
$DamageScale[HoverBike, $MortarDamageType] 		= 1.25;	
$DamageScale[HoverBike, $BlasterDamageType]		= 1.0;	
$DamageScale[HoverBike, $ElectricityDamageType]	= 1.8;
$DamageScale[HoverBike, $MineDamageType] 		= 1.25;
// End of Base Damage Types
$DamageScale[HoverBike,$ReaperDamageType]		= 1.0;
$DamageScale[HoverBike,$SniperXDamageType]		= 1.5;
$DamageScale[HoverBike,$FlameDamageType]		= 1.0;
$DamageScale[HoverBike,$BusterDamageType]		= 1.5;
$DamageScale[HoverBike,$BeaconDamageType]		= 1.0;
$DamageScale[HoverBike,$DesignatorDamageType]	= 1.0;
$DamageScale[HoverBike,$StasisDamageType]		= 1.0;
$DamageScale[HoverBike,$GrogDamageType]			= 1.0;
$DamageScale[HoverBike,$SamDamageType]			= 1.2;
$DamageScale[HoverBike,$InfernoDamageType]		= 1.0;
$DamageScale[HoverBike,$VelcroDamageType]		= 1.0;
$DamageScale[HoverBike,$MortDamageType]			= 1.0;
$DamageScale[HoverBike,$ArtyDamageType]			= 1.0;
$DamageScale[HoverBike,$AADamageType]			= 1.3;
$DamageScale[HoverBike,$PTurretDamageType]		= 1;
$DamageScale[HoverBike,$RTurretDamageType]		= 1;
$DamageScale[HoverBike,$ITurretDamageType]		= 1;
$DamageScale[HoverBike,$ETurretDamageType]		= 1;
$DamageScale[HoverBike,$DTurretDamageType]		= 1;



$DamageScale[AAPC, $ImpactDamageType] 			= 0.75;	
$DamageScale[AAPC, $BulletDamageType] 			= 0.75;	
$DamageScale[AAPC, $PlasmaDamageType] 			= 0.75;	
$DamageScale[AAPC, $EnergyDamageType] 			= 1.0;	
$DamageScale[AAPC, $ExplosionDamageType] 		= 1.0;	
$DamageScale[AAPC, $ShrapnelDamageType]			= 1.0;	
$DamageScale[AAPC, $DebrisDamageType] 			= 1.0;	
$DamageScale[AAPC, $MissileDamageType]			= 1.5;	
$DamageScale[AAPC, $LaserDamageType] 			= 0.65;	
$DamageScale[AAPC, $MortarDamageType] 			= 1.5;	
$DamageScale[AAPC, $BlasterDamageType]			= 1.0;	
$DamageScale[AAPC, $ElectricityDamageType]		= 1.8;
$DamageScale[AAPC, $MineDamageType] 			= 1.0;
// End of Base Damage Types
$DamageScale[AAPC,$ReaperDamageType]			= 1.0;
$DamageScale[AAPC,$SniperXDamageType]			= 1.5;
$DamageScale[AAPC,$FlameDamageType]				= 1.0;
$DamageScale[AAPC,$BusterDamageType]			= 1.5;
$DamageScale[AAPC,$BeaconDamageType]			= 1.0;
$DamageScale[AAPC,$DesignatorDamageType]		= 1.0;
$DamageScale[AAPC,$StasisDamageType]			= 1.0;
$DamageScale[AAPC,$GrogDamageType]				= 1.0;
$DamageScale[AAPC,$SamDamageType]				= 1.2;
$DamageScale[AAPC,$InfernoDamageType]			= 1.0;
$DamageScale[AAPC,$VelcroDamageType]			= 1.0;
$DamageScale[AAPC,$MortDamageType]				= 1.0;
$DamageScale[AAPC,$ArtyDamageType]				= 1.0;
$DamageScale[AAPC,$AADamageType]				= 1.3;
$DamageScale[AAPC,$PTurretDamageType]			= 1;
$DamageScale[AAPC,$RTurretDamageType]			= 1;
$DamageScale[AAPC,$ITurretDamageType]			= 1;
$DamageScale[AAPC,$ETurretDamageType]			= 1;
$DamageScale[AAPC,$DTurretDamageType]			= 1;

//**************************************************
//				New AMMO Pack Items
//**************************************************
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = SniperXAmmo;
$AmmoPackItems[9] = BusterAmmo;
$AmmoPackItems[10] = MissileAmmo; 	
$AmmoPackItems[11] = BeaconAmmo; 	
$AmmoPackItems[12] = ReaperAmmo; 	
$AmmoPackItems[13] = StasisAmmo;

$AmmoPackMax[BusterAmmo]	= 6;
$AmmoPackMax[MissileAmmo]	= 10;
$AmmoPackMax[BeaconAmmo]	= 10;
$AmmoPackMax[ReaperAmmo]	= 200;
$AmmoPackMax[StasisAmmo]	= 10;

//	NumAPItems - Update as Required by Number of Ammo Pack Items

$NumAPItems = 14;	

//*************************************************
//			End of AMMO Pack New Items
//*************************************************

//	Mod Global variables Groups Sets Etc..
//-----------------------------------------
$ClassAGen[0]	= "";
$ClassAGen[1]	= "";

$ClassBGen[0]	= "";
$ClassBGen[1]	= "";

$GenSet[0]		= "";
$GenSet[1]		= "";

$Alarm[0]		= false;
$Alarm[1]		= false;

//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

function SendLockWarning(%targetId,%type)
{	// if($trace) echo( $ver@"|SendLockWarning to ",$User[%targetId]);
	if(%targetId)
	{	if(%type==0)
			Client::sendMessage(%targetId,0,"** MISSILE LOCK WARNING!!! **~waccess_denied.wav");
		else if(%type==1)
			Client::sendMessage(%targetId,0,"** IMAGE MISSILE LOCK WARNING!!! **~waccess_denied.wav");
		else if(%type==2)
			Client::sendMessage(%targetId,0,"** SENSOR MISSILE LOCK WARNING!!! **~waccess_denied.wav");
		
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
	}
}


function Sin(%theta)
{ return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));}
 
function Cos(%theta) 
{ return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));}

// Thanks to Insomniax!!!
function NewVector(%vec, %scalar)
{	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}


function GiveKickback(%player, %strength, %lift)
{	if($traceAll) echo( $ver@"|GiveKickback to Player ",%player);
	if((!%lift) && (%lift != 0)) %lift = 0;
	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (Sin(%rad));
	%y = Cos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force=NewVector(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%force = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}



function remoteUseItem(%client,%type)
{	%client.throwStrength = 1;
	%item = getItemData(%type);
	if (%item == Backpack) 
	{	%item = Player::getMountedItem(%client,$BackpackSlot);
		if(%item == "-1") CheckItemPickup(%client);
	}
	else 
	{	if (%item == Weapon) %item = Player::getMountedItem(%client,$WeaponSlot);
	}
	
	Player::useItem(%client,%item);
}

function resetArmor(%client,%armor)
{	%player=Client::getOwnedObject(%client);
	%client.inStasis--;
	if(%client.inStasis<=0)
	{	Player::setArmor(%client,%armor);
		%client.inStasis=0;
		%rate=$Recharge[%client.talent[$Rch]];
		%player=Client::getOwnedObject(%client);
		GameBase::setRechargeRate(%player,%rate);
	}
	else if(%client.inStasis >= 3)
	{	schedule("resetArmor("@%client@","@%armor@");",1,%player);
	}
	else
		schedule("resetArmor("@%client@","@%armor@");",2,%player);
}

// ***************************
// ** End Special Functions **
// ***************************



// ---------------------------------------------------------------
// Modified Base scripts for Inventory Stations etc.
// -----------------------------
function Station::itemsToResupply(%player)
{	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,AODSniperX,SniperXAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,AODBBuster,BusterAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,AODStinger,MissileAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,AODBeaconGun,BeaconAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,AODReaper,ReaperAmmo,25);
	%cnt = %cnt + AmmoStation::resupply(%player,AODStasisGun,StasisAmmo,2);
	return %cnt;
}

function AmmoPack::onDrop(%player, %item)
{	// if($trace) echo( $ver@"|AmoPack On drop");
	if($matchStarted) 
	{	%item = Item::onDrop(%player,%item);
		%barmor=GetBaseArmor(%player);
		for(%i = 0; %i < $NumAPItems ; %i = %i +1) 
		{	%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[%barmor, %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) 
			{	%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) 
			{	%item.BulletAmmo = %numPack;}
			else if(%i == 1) 
			{	%item.PlasmaAmmo = %numPack;}
			else if(%i == 2) 
			{	item.DiscAmmo = %numPack;}
			else if(%i == 3) 
			{	%item.GrenadeAmmo = %numPack;}
			else if(%i == 4) 
			{  	%item.Grenade = %numPack;}
			else if(%i == 5) 
			{    	%item.MortarAmmo = %numPack;}
			else if(%I==6)
			{     	%item.MineAmmo = %numPack;}
			else if(%i == 7) 
			{     	%item.Beacon = %numPack;}
			else if(%i == 8) 
			{     	%item.SniperXAmmo = %numPack;}
			else if(%i == 9) 
			{     	%item.BusterAmmo = %numPack;}
			else if(%i == 10) 
			{     	%item.MissileAmmo = %numPack;}
			else if(%i == 11) 
			{     	%item.BeaconAmmo = %numPack;}
			else if(%i == 12) 
			{     	%item.ReaperAmmo = %numPack;}
			else if(%i == 13) 
			{     	%item.StasisAmmo = %numPack;}
					
		}
	}
}

function checkPacksAmmo(%player, %item)
{	// if($trace) echo( $ver@"|checkPacksAmmo for Player ",%player,", ",%item);
	for(%i = 0; %i < $NumAPItems ; %i++) 
	{
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0)
		{	%numAdd = %item.BulletAmmo;}
		else if(%i == 1)
		{	%numAdd = %item.PlasmaAmmo;}
		else if(%i == 2)
		{	%numAdd = %item.DiscAmmo;}
		else if(%i == 3)
		{	%numAdd = %item.GrenadeAmmo;}
		else if(%i == 4)
		{	%numAdd = %item.Grenade;}
		else if(%i == 5)
		{	%numAdd = %item.MortarAmmo;}
		else if(%I==6)
		{	%numAdd = %item.MineAmmo;}
		else if(%i == 7)
		{	%numAdd = %item.Beacon;}
		else if(%i == 8)
		{	%numAdd = %item.SniperXAmmo;}
		else if(%i == 9)
		{	%numAdd = %item.BusterAmmo;}
		else if(%i == 10)
		{	%numAdd = %item.MissileAmmo;}
		else if(%i == 11)
		{	%numAdd = %item.BeaconAmmo;}
		else if(%i == 12)
		{	%numAdd = %item.ReaperAmmo;}
		else if(%i == 13)
		{	%numAdd = %item.StasisAmmo;}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $NumApItems ; %i++)
	{	%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) 
		{
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}


function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{	if (Player::isExposed(%this)) 
	{	%damagedClient = Player::getClient(%this);
		%shooterClient = %object;
		%SObject=Client::getOwnedObject(%object);

		%barmor = GetBaseArmor(%damagedClient);
		Player::applyImpulse(%this,%mom);

		if ($traceDam) echo($ver,"|Client ",%damagedClient," damaged by ",%object," Type= ",%type, " Damage= ",%value);
		
		if((getSimTime()-%this.DamageStamp)>$ExpValidTime)		// If Player has not been damaged in over the predetermined # of seconds then reset the Exp Award Slots
		{	if($trace) Echo($User[%damagedclient]@" Has not been damaged in "@$ExpValidTime@" Resetting Assists");
			%damagedClient.LastDamBy[2]=false;
			%damagedClient.LastDamBy[1]=false;
		}
		
		if (%shooterClient.talent[$Acc])
		{	%mod=$Accuracy[ShooterClient.talent[$Acc]];
			if(%mod==0)	%mod=1;
			%value *= %mod;
			if($tracedam) echo($ver,"|Shooter has Accuracy (Damage =",%value,") Acc = ",$Accuracy[%i]);
		}
		
		if (%damagedClient.talent[$Dur])
		{	%mod=$Durability[damagedClient.talent[$Dur]];
			if(%mod==0) %mod=1;
			%value *= %mod;
			if($tracedam) echo($ver,"|Player has Durability (Damage =",%value,") Dur = ",$Durability[%i]," Dur Level = ",%i);
		}
		
		// Check to See if Player is riding a KODIAK Assault Vehicle
		// If Player is Mounted in an AAPC Assault Craft (Craft Shields Passengers)
		if(%damagedClient.inAAPC)	
		{	if($tracedam) echo("Player is Mounted in an AAPC & is Shielded");
			%aapc=%damagedClient.inAAPC;
			%energy = GameBase::getEnergy(%aapc);
			%strength = %aapc.shieldStrength;
			if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
				%strength *= 0.75;
			%absorb = %energy * %strength;
			if (%value < %absorb) 
			{	GameBase::setEnergy(%aapc,%energy - ((%value / %strength)*%friendFire));
				%thisPos = getBoxCenter(%aapc);
				%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
				GameBase::activateShield(%aapc,%vec,%offsetZ);
				%value = 0;
				return;
			}
			else 
			{	GameBase::setEnergy(%aapc,0);
				%value = %value - %absorb;
			}
		}

		if (%type==$DesignatorDamageType)
		{	DesignateTarget (%this,%value,%object);
			return;
		}
		else if(%type==$MortarDamageType) 
		{	CounterBatteryCheck(%object);
		}
		else if (%type==$StasisDamageType)
		{	if($tracedam) echo( $ver@"|$Stasis Shocked [",%damagedClient,"]");
			if(%damagedclient.inStasis>0)
			{	%damagedclient.inStasis++;
				%loss = GameBase::getEnergy(%this)*$StasisEnergyDrain;
				GameBase::setEnergy(%this,(%energy-%loss));
			}
			else
			{	%armor=Player::getArmor(%damagedClient);
				%narmor=%barmor@S;
				Player::setArmor(%damagedclient,%narmor);
				schedule("resetArmor("@%damagedclient@","@%armor@");",5,%damagedclient);
				%damagedClient.inStasis=1;
				%loss = GameBase::getEnergy(%this)*$StasisEnergyDrain;
				GameBase::setEnergy(%this,(%energy-%loss));
				%player=Client::getOwnedObject(%client);
				GameBase::setRechargeRate(%player,0);
			}
		}
		else if(%type==$SniperXDamageType)
		{	if($tracedam) echo( $ver@"|Sniper X Damage Type");
			%arm=String::getSubStr(%barmor, 0, 1);
			if (%a=="l")
				%strength=150;
			else if (%arm == "m")
				%strength=300;
			else if (%arm=="h")
				%strength=650;
			%rot = GameBase::getRotation(%ShooterClient);
			%rad = getWord(%rot, 2);
			%x = (-1) * (Sin(%rad));
			%y = Cos(%rad);
			%z= getword(%vec,2);
			%dir = %x @ " " @ %y @ " 0";
			%force=NewVector(%dir,%strength);
			%x = getWord(%force, 0);
			%y = getWord(%force, 1);
			%dir = %x @ " " @ %y @ " " @ %z;
			Player::applyImpulse(%damagedClient,%force);
		}

		// If this is a team game & there was an attacker & Its not the same as the Player & they are not on the same Team Then Attacker gets an EXP Slot
		if(%sObject && %Object!=0)
		{	if($TeamPlay && !Player::isDead(%this))
			{	if((Client::getTeam(%damagedClient) != Client::getTeam(%object)) && (getObjectType(%SObject)=="Player"))
				{	if(%object != %damagedClient.LastDamBy[1])
					{	%damagedClient.LastDamBy[2]=%damagedClient.LastDamBy[1];
						%damagedClient.LastDamBy[1]=%object;
					}
				}
			}
			else
				%damagedClient.LastDamBy[1]=%shooterClient;
		}
				
		
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) 
		{	if (%shooterClient != -1)
			{	%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) 
				{		if(%type != $MineDamageType) 
						{	Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
							Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
						}
						else
						{	Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
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

		if (!Player::isDead(%this))
		{	%arm=String::getSubStr(%barmor, 0, 1);
			//----- More damage applyed to head shots -----
			if(%vertPos == "head" && (%type == $LaserDamageType || %type == $SniperXDamageType)  )
			{	if(%arm == "h")
				{	if(%quadrant == "middle_back" || %quadrant == "middle_front" || quadrant == "middle_middle")
					{	%value += (%value);}
				}
				else
				{	%value += (%value);}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) 
			{	%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) 
				{	GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else 
				{	GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}

			if (%value) 
			{	%value = $DamageScale[%barmor, %type] * %value * %friendFire;
				%dlevel = GameBase::getDamageLevel(%this) + %value;
				%spillOver = %dlevel - %barmor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) 
				{	if(%damagedClient.lastDamage < getSimTime()) 
					{	%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
					%this.DamageStamp = getSimTime();		// Sets when the Player was last Damaged		
					if (%damagedclient.talent[$Rgn]>0)
						if (%damagedclient.isRegenerating==false)
							startRegen(%damagedClient);
				}
				else 
				{	if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType || %type== $ArtilleryDamageType ||%type== $InfernoDamageType||%type== $RTurretDamageType)) 
					{	Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                		Player::blowUp(%this);
					}
					else
					{	if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) 
						{	if(%quadrant == "front_left" || %quadrant == "front_right")
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") 
						{	if(%quadrant == "front_left" ||	%quadrant == "front_right"	)
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") 
						{	if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") 
						{	if(%quadrant == "front_left" ||	%quadrant == "back_left") 
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






//--------------------------------------------
//********** AAOD HELP ROUTINES **************
//--------------------------------------------
function HelpTitle(%msg)
{	%Hdr="<jl><f1>\n\n\n";
	return(%Hdr@%msg);
}

function AddHelpLine(%msgtxt,%msg)
{	return(%msgtxt@"\n"@%msg);
}


function AAODHELP(%client,%item)
{	schedule(%item@"::help("@%client@");",0);
}

//--------------------------------------------
//******** END AAOD HELP ROUTINES ************
//--------------------------------------------

//********************** AAOD Admin Functions ***************************
//                      Functions Pulled from 
//	   						 ADMIN.CS & Modified
//***********************************************************************

function Game::menuRequest(%clientId)
{	// if($trace) echo( $ver@"|Game::MenuRequest (client) (",%clientId,")");
	%curItem = 0;
	Client::buildMenu(%clientId, "Options", "options", true);
	if(!$matchStarted || !$Server::TourneyMode)
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	if(%clientId.Help)
		Client::addMenuItem(%clientId, %curItem++ @ "Turn AAOD Help OFF", "AAODHOFF");
	else 
		Client::addMenuItem(%clientId, %curItem++ @ "Turn AAOD Help ON", "AAODHON");
	if(GetPts(%clientId)>0)
		Client::addMenuItem(%clientId, %curItem++ @ "Select Special Skill", "getskill");
	if(!%clientId.selClient)
		Client::addMenuItem(%clientId, %curItem++ @ "Show Current Experience", "ShowExpLvl");
	if(!%clientId.selClient)
		Client::addMenuItem(%clientId, %curItem++ @ "Change Skin Options", "ChangeSkins");
	
	if(%clientId.selClient)
	{	%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		if($curVoteTopic == "" && !%clientId.isAdmin)
		{	// Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
		}
		if(%clientId.isSuperAdmin)
		{	Client::addMenuItem(%clientId, %curItem++ @ "Special Abilities Menu","ExpMenu "@ %sel);
		}
		if(%clientId.isAdmin)
		{	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			if(%clientId.isSuperAdmin)
			{	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			}
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		}
		if(%clientId.muted[%sel])
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
		if(%clientId.observerMode == "observerOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
	}
	if($curVoteTopic != "" && %clientId.vote == "")
	{	Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}
	else if($curVoteTopic == "" && !%clientId.isAdmin)
	{	Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
               
		if($Server::TourneyMode)
		{	Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
			if(!$CountdownStarted && !$matchStarted)
	            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
		}
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

		#if($Server::CampaignMode)	// AAOD
		#{	Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
		#	if(!$CountdownStarted && !$matchStarted)
	    #        Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
		#}
		#else
		#	Client::addMenuItem(%clientId, %curItem++ @ "Vote for AAOD Campaign mode", "vccampaign");
	}
	else if(%clientId.isAdmin)
	{	Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

		if($Server::TourneyMode)
		{	Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
			if(!$CountdownStarted && !$matchStarted)
	            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
		}
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");

		Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
		
		#if($Server::CampaignMode)
		#{	Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
		#	if(!$CountdownStarted && !$matchStarted)
		#		Client::addMenuItem(%clientId, %curItem++ @ "Start the Campaign!", "smatch");
		#}
		#else
		#	Client::addMenuItem(%clientId, %curItem++ @ "Begin AAOD Campaign","ccampaign");
		

	}
}

//------------------------
//	Purchase Routines
//------------------------

function BuyItem(%client,%item)
{	if($traceAll) echo( $ver@"|Buy Item  (client,Item)",%client,", ",%item);
	%BoughtItem=PurchaseItem(%client,%item);
	if(%BoughtItem)	
	{	if(%client.help==true)
		{	%typ=String::getSubStr(%item, 0, 3);
			if(%typ=="AOD")	AAODHelp(%client,%item);
		}
	}
	return (%BoughtItem);
}
	
function PurchaseItem(%client,%item)
{	if($traceAll) echo( $ver@"|Purchase Item  (client,Item)",%client,", ",%item);
	%player = Client::getOwnedObject(%client);
	%armor = GetBaseArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.classname == Armor || %item.classname == Vehicle || $TestCheats)) 
	{	if (%item.classname == Armor) 
		{	// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	
			{	teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) 
				{	teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					%buyarmor = CheckArmor(%client,%buyarmor);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,GetBaseArmor(%client));
					armorChange(%client);
					Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				Player::setItemCount(%client, %item, 1);  
					CheckStealth(%client);
					%pack=Player::getMountedItem(%client,$BackpackSlot);
					if (%pack == ammopack || %pack == AODCombo3Pack) 
						fillAmmoPack(%client);	
					return 0;
				}
				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}

		else if (%item.classname == Backpack) 
		{	if($TeamItemMax[%item] != "") 
			{	if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 		return 0;
			}
			if (%item == AODSuperRPack || %item == AODCombo1Pack|| %item == AODCombo2Pack|| %item == AODCombo3Pack || %item == AODCombo4Pack)
			{	%flag = Player::getMountedItem(%client,$FlagSlot);
				if(%flag=="flag")
				{	Client::sendMessage(%client, 0, "You cannot buy a "@%item.Description@" with a Flag ON!!~wAAODSFX14.wav");
					return 0;
				}
			}
	
			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) 
			{	if(%pack == ammopack || %pack == AODCombo3Pack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack  || AODCombo3Pack|| AODCombo4Pack) 
				{	if(%item!=EnergyPack && %item!=AODCombo3Pack)
					{	if(Player::getItemCount(%client,"LaserRifle") > 0) 
						{	Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
							remoteSellItem(%client,22);						
						}
					}
				}	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) 
			{	teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);				
				if(%item == ammopack || %item == AODCombo3Pack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1) 
			{	teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);				
				if(%pack == ammopack || %pack == AODCombo3Pack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.classname == Weapon) 
		{	if(checkResources(%player,%item,1)) 
			{	if(%item == LaserRifle && (Player::getItemCount(%client,"EnergyPack")==0 && Player::getItemCount(%client,"AODCombo3Pack")== 0&& Player::getItemCount(%client,"AODCombo4Pack")== 0)) 
				{	buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "") 
				{	%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) 
					{	teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.classname == Vehicle) 
		{	if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) 
			{	%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) 
				{	teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
		else 
		{	if($TeamItemMax[%item] != "") 
			{	if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 		return 0;
			}
		    %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			if(%delta || $testCheats) 
			{	teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
		
 	}
	return 0;
}
//------------------------
//	End Purchase Routines
//------------------------

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{	
	if(%this.destroyed) return;	//	Shape Has Already Been Destroyed....

	if($traceDam) echo($ver,"|StaticShape ",%this," damaged by ",%object," Type= ",%type, " Damage= ",%value);
	%team=GameBase::getTeam(%this);
	if (%object.talent[$Acc])
	{	%mod=$Accuracy[%object.talent[$Acc]];
		if(%mod==0) %mod=1;
		%value*=%mod;
		if($tracedam) echo( $ver@"|Shooter ",%object," has Accuracy! New Damage is:",%value);
	}
	
	if($Alarm[%team])
	{	if (!%this.Alarm)	// If this Object has Not Triggered an Alarm already
		{	SoundAlarm(%this,%object,%team);}
	}
	
	if(%type==$MortarDamageType)
	{	CounterBatteryCheck(%object);
	}
	else if (%type==$DesignatorDamageType)
	{	DesignateTarget(%this,%value,%object);
		return;
	}
	else if (%type==$StasisDamageType)
	{	if($tracedam) echo( $ver@"|STASIS DAMAGE TO: ",%this);
		%loss=GameBase::getEnergy(%this)*$StasisEnergyDrain;
		%energy-=%loss;
		GameBase::setEnergy(%this,%energy);
		%this.mass=50;
	}
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	
	// Does a Node Exist on this Object ??
	if (%this.shieldNode)
	{	%node=%this.shieldNode;					// Apply Damage to Node Shield first
		%energy = GameBase::getEnergy(%node);
		%strength = %node.shieldStrength;
		%NodeDamageLevel = GameBase::getDamageLevel(%node);
		if($traceDam) echo( $ver@"|Shield Node :",%node," Node Energy:",%energy," Node Shield Strength:",%strength,"");
		if (%type == $ShrapnelDamageType)
			%strength *= 0.5;
		else
			if (%type == $MortarDamageType)
				%strength *= 0.25;
			else
				if (%type == $BlasterDamageType)
					%strength *= 2.0;
		%absorb = %energy * %strength;
		GameBase::setEnergy(%node,%energy - (%value / %strength));
		%centerPos = getBoxCenter(%this);
		%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
		%centerPosX = getWord(%centerPos,0);
		%centerPosY = getWord(%centerPos,1);
		%centerPosZ = getWord(%centerPos,2);
		%pointX = getWord(%pos,0);
		%pointY = getWord(%pos,1);
		%pointZ = getWord(%pos,2);
		%newVecX = %centerPosX - %pointX;
		%newVecY = %centerPosY - %pointY;
		%newVecZ = %centerPosZ - %pointZ;
		%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
		%zOffset = 0;
		if(GameBase::getDataName(%this) == PulseSensor)
			%zOffset = (%pointZ-%centerPosZ) * 0.5;
		GameBase::activateShield(%this,%sphereVec,%zOffset);
		if (%value > %absorb)
		{	// if($trace) echo( $ver@"|Shield Node unable to Deflect All damage!!!"); 
			GameBase::setEnergy(%node,0);
			NewStaticShapeDamage (%node,%object,%NodeDamagelevel,%value-%absorb);
			// if($trace) echo( $ver@"|Shield Node Damage Level is :",%NodeDamageLevel," Damage appllied ",%value-%absorb);
		}
		return;	
	}

	%name=GameBase::GetDataName(%this);
	if (%this.shieldStrength) 
	{	//if this is a shield Node Then it has no shield
		if(%name=="RemoteShieldNode")
		{	if($traceAll) echo( $ver@"|Shield Node under attack");
			NewStaticShapeDamage (%this,%object,%damagelevel,%value);	
		}
		else
		{	%energy = GameBase::getEnergy(%this);
			%strength = %this.shieldStrength;
			if (%type == $ShrapnelDamageType)
				%strength *= 0.5;
			else
				if (%type == $MortarDamageType)
					%strength *= 0.25;
				else
					if (%type == $BlasterDamageType)
						%strength *= 2.0;
			%absorb = %energy * %strength;
			if (%value < %absorb) 
			{	//if($trace) echo( $ver@"|the shields wil absorb all damage");
				GameBase::setEnergy(%this,%energy - (%value / %strength));
				%centerPos = getBoxCenter(%this);
				%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
				%centerPosX = getWord(%centerPos,0);
				%centerPosY = getWord(%centerPos,1);
				%centerPosZ = getWord(%centerPos,2);
	
				%pointX = getWord(%pos,0);
				%pointY = getWord(%pos,1);
				%pointZ = getWord(%pos,2);
	
				%newVecX = %centerPosX - %pointX;
				%newVecY = %centerPosY - %pointY;
				%newVecZ = %centerPosZ - %pointZ;
				%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
				%zOffset = 0;
				if(GameBase::getDataName(%this) == PulseSensor)
					%zOffset = (%pointZ-%centerPosZ) * 0.5;
				GameBase::activateShield(%this,%sphereVec,%zOffset);
			}
			else 
			{	GameBase::setEnergy(%this,0);
				NewStaticShapeDamage (%this,%object,%damagelevel,%value-%absorb);
				//if($trace) echo( $ver@"|the shields wil absorb some Damage - Damage =",%value-%absorb);
			}
		}
	}
	else
		NewStaticShapeDamage (%this,%object,%damagelevel,%value);
		
}

function NewStaticShapeDamage(%this,%object,%damageLevel,%value)
{	%dValue = %damageLevel + %value;
	%name = GameBase::getDataName(%this);
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
	{	%ExpMod1=$ExpKill[%name.classname];
		if(%ExpMod<=0) %ExpMod=1;
		%ExpPts= %ExpMod*%value*2;
		%Pts=ExpCalc("",GameBase::GetTeam(%object),%ExpPts);
		if($traceExp) echo("Player ",$User[%object]," Loses ",%Pts," of EXP for Damaging Own Equipment");
		ExpSub(%object,%Pts);
		if($Teststuff==false)
		{	if(%name.classname == Generator || %name.classname == Station) 
			{ 	%TDS = $Server::TeamDamageScale;
				%dValue = %damageLevel + %value * %TDS;
				%disable = GameBase::getDisabledDamage(%this);
				if(!$Server::TourneyMode && %dValue > %disable - 0.05) 
				{	if(%damageLevel > %disable - 0.05)
						return;
					else
					%dValue = %disable - 0.05;
				}
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);
}
//******************************************
//		AAOD VEHICLE BLOCK
//******************************************

//******************************************
//		Hover Bike
//******************************************

$DataBlockName[AODVehicle1]		= HoverBike;
$VehicleToItem[HoverBike]		= AODVehicle1;
$VehicleInvList[AODVehicle1]	= 1;
$TeamItemMax[AODVehicle1]		= 2;

BulletData HoverBikeBullet
{	bulletShapeName = "Bullet.DTS";
	explosionTag = bulletExp0;
	expRandCycle	= 3;
	mass = 1.75;
	bulletHoleIndex = 0;
	ExplosionRadius = 3;
	damageClass = 0;
	damageValue = 0.10;
	damageType = $BulletDamageType;
	aimDeflection = 0.006;
	muzzleVelocity = 550.0;
	totalTime = 0.30;
	inheritedVelocityScale = 0.75;
	isVisible = False;
	tracerPercentage = 0.5;
	tracerLength = 10;
	detachFromShooter = false;
	rotationPeriod = 0;
	lightRange = 0.0;
	lightColor = {1.0, 0.25,0.25};
};

FlierData HoverBike 
{	explosionId = flashExpsmall;
	debrisId = flashDebrissmall;
	classname = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 1.0;
	drag = 0.1;
	density = 1.0;
	maxBank = 2.5;
	maxPitch = 2.0;
	maxSpeed = 65;
	minSpeed = -15;
	maxSideSpeed = 10;

	lift = 2.0;
	maxAlt = 1;
	maxVertical = 0.001;
	maxDamage = 0.55;
	
	damageLevel = {1.0, 1.0};
	maxEnergy = 80;
	accel = 1.5;
	groundDamageScale = 0.5;
	projectileType = HoverBikeBullet;
	reloadDelay = 0.02;
	repairRate = 0;
	fireSound = SoundFireHoverBike;
	damageSound = SoundFlierCrash;
	ramDamage = 0.65;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = true;
	driverPose = 22;
	description = "HoverBike";
};


ItemData AODVehicle1 
{	description = "HoverBike";
	classname = "Vehicle";
	heading = "aVehicle";
	price = 2500;
};

function AODVehicle1::Help(%client)
{	%msg=HelpTitle("HoverBike: Light armored scout vehicle");
	%msg=AddHelpLine(%msg,"Fast, extremely manueverable has 2 onboard chainguns");
	%msg=AddHelpLine(%msg,"makes an excelent strafing vehicle if there is no Air defense");
	%msg=AddHelpLine(%msg,"Its light armour makes it vulnerable to any sort of air cover.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}


// *******************************************
//		Assault APC
//********************************************

$DataBlockName[AODVehicle2] = AAPC;
$VehicleToItem[AAPC] = AODVehicle2;
$VehicleInvList[AODVehicle2] = 1;
$TeamItemMax[AODVehicle2] = 1;

BulletData AAPCMarker
{	bulletShapeName		= "Plasmatrail.DTS";
	explosionTag		= plasmaExp;
	mass				= 1.75;
	ExplosionRadius		= 3;
	damageClass			= 1;
	ExplosionRadius		= 3;
	damageValue			= 0.05;
	damageType			= $DesignatorDamageType;
	accufire			= true;
	muzzleVelocity		= 250.0;
	totalTime			= 2.00;
	inheritedVelocityScale = 0.75;
	isVisible			= true;
	detachFromShooter	= false;
	lightRange			= 3.0;
	lightColor			= {1.0, 0.25,0.25};
	
};

FlierData AAPC
{	explosionId			= flashExpLarge;
	debrisId			= flashDebrisLarge;
	classname			= "Vehicle";
	shapeFile			= "hover_apc";
	shieldShapeName		= "shield_large";
	mass				= 20.0;
	drag				= 1.5;
	density				= 1.2;
	maxBank				= 0.25;
	maxPitch			= 0.175;
	maxSpeed			= 20;								   
	minSpeed			= -20;
	lift				= 0.35;
	maxAlt				= 15;
	maxVertical			= 5;
	maxDamage			= 4.0;
	damageLevel			= {1.0, 1.0};
	maxEnergy			= 100;
	accel				= 0.25;
	groundDamageScale	= 0.050;
	repairRate			= 0.002;
	ramDamage			= 2;
	ramDamageType		= -1;
	mapFilter			= 2;
	mapIcon				= "M_vehicle";
	projectile			= unknown;
	fireSound			= SoundFireFlierRocket;
	reloadDelay			= 3.0;
	damageSound			= SoundTankCrash;
	visibleToSensor		= true;
	shadowDetailMask	= 2;
	mountSound			= SoundFlyerMount;
	dismountSound		= SoundFlyerDismount;
	idleSound			= SoundFlyerIdle;
	moveSound			= SoundFlyerActive;
	visibleDriver		= true;
	driverPose			= 23;
	description			= "Kodiak AAPC";
};

ItemData AODVehicle2 
{	description			= "Assault APC";
	classname			= "Vehicle";
	heading				= "aVehicle";
	price				= 7500;
};


function AODVehicle2::Help(%client)
{	%msg=HelpTitle("Kodiak Assault APC: Heavy Armoured Attack Vehicle");
	%msg=AddHelpLine(%msg,"Features: - Shields Passengers from attack");
	%msg=AddHelpLine(%msg,"- ReSupplys and repairs passengers (as long as it has energy)");
	%msg=AddHelpLine(%msg,"- Can not be 'stolen' by other team..");
	%msg=AddHelpLine(%msg,"- Takes a hell of a pounding.. with 4 heavies in it this sucker");
	%msg=AddHelpLine(%msg,"will reduce a base to rubble!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

//***********************************************************
//		Global Vehicle Functions
//***********************************************************

function Vehicle::onDelete(%this)
{	// if($traceveh) echo("Vehicle on DELETE ",%this);
}
function Vehicle::onAdd(%this)
{	// if($traceveh) echo("Vehicle on ADD ",%this);
	%this.isMarked=false;
 	if(GameBase::getDataName(%this) == Scout) 
	{	GameBase::setMapName (%this, "Scout");
		%this.shieldStrength = 0.0;
		GameBase::setRechargeRate (%this, 8);
	}
	else if(GameBase::getDataName(%this) == LAPC)
	{	GameBase::setMapName (%this, "LPC");
		%this.shieldStrength = 0.001;
		GameBase::setRechargeRate (%this, 8);
	}
	else if(GameBase::getDataName(%this) == HAPC) 
	{	GameBase::setMapName (%this, "HPC");
		%this.shieldStrength = 0.002;
		GameBase::setRechargeRate (%this, 8);
	}
	else if(GameBase::getDataName(%this) == HoverBike) 
	{	GameBase::setMapName (%this, "HoverBike");
		%this.shieldStrength = 0.0;
		GameBase::setRechargeRate (%this, 5);
	}
	else if(GameBase::getDataName(%this) == AAPC) 
	{	GameBase::setMapName (%this, "AAPC");
		%this.shieldStrength = 0.008;
		GameBase::setRechargeRate (%this, 12);
	}
}


function AAPC::onFire(%this,%slot)
{	return;
	// This Function is Disabled until it can be perfected
	if (%this.islaunching)
		return;
	%this.islaunching=true;
	if($traceveh) echo( $ver@"|AAPC::On Fire (%this,%slot) (",%this,", ",%slot,")");
	%tpos=GameBase::getposition(%this);
	%target = AquireTarget(%this,3,%tpos); 	// AAPC Scan for Target
	if($trace) echo("target is ",%target);
	if(%target)
	{	// AAPC Target Aquired....
		// FIRE Energy Bolt
		if($trace) echo("Firing Energy Bolt");
		%trans2 = GameBase::getTransform(%this); 
		%trans1 = "0 0 0 0 1.5 -1";
		%trans=%trans1@" "@%trans2;
        %vel = Item::getVelocity(%this); 
		Projectile::spawnProjectile("BlasterBolt",%trans,%this,%vel);
	}
	else
	{	%pos = GameBase::getPosition(%this); 
		%rot	= Gamebase::getRotation(%this);
		%trans1 = "0 0 0 0 1.5 -1";
		%trans=%trans1@" "@%rot@" "@%pos;
        %vel = Item::getVelocity(%this); 
		Projectile::spawnProjectile("BlasterBolt",%trans,%this,%vel);
	}
	schedule("resetAAPCfire("@%this@");",1,%this);
}

function resetAAPCfire(%this)
{
	%this.islaunching="";
}

function Vehicle::onCollision (%this, %object)
{	// if($traceveh) echo( $ver@"|Vehicle::On collision (%this,%object) (",%this,", ",%object,")");
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
	{	if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") 
		{	if( Player::isAiControlled(%object) ) return;
			%armor = Player::getArmor(%object);
			%arm=String::getSubStr(%armor, 0, 1);
			%client = Player::getClient(%object);
			%vehicle=GameBase::getDataName(%this);
			if ((%arm == "l") && Vehicle::canMount (%this, %object)) 
			{	
				if(%vehicle==AAPC)	// Vehicle is an AAOD Assault Vehicle
				{	%teamv=%this.purchaseTeam;
					%teamp=Client::getTeam(%client);
					// if($trace) echo(" Mounting AAPC belonging to Team ",%teamv," Player is ",%teamp);
					
					if (%client.talent[$Stealth]!=2) // Infiltrators Can Mount Enemy AAPC
					{	if(%teamp != %teamv)
						{	// AAPC is of the other Team..... Activate Shields....Apply Kickback
							Eject(%this,%object);
							return;
						}
					}
				}

				%weapon = Player::getMountedItem(%object,$WeaponSlot);
				if(%weapon != -1)
				{	%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				
				Player::setMountObject(%object, %this, 1);
				Client::setControlObject(%client, %this);
				CheckStealth(%client);
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				if(GameBase::getDataName(%this) == SLAPC) 
				{	%rate = Player::getSensorSupression(%object) + $StealthLevel;
					Player::setSensorSupression(%object,%rate);
				}
				%object.driver= 1;
				%object.vehicle = %this;
				%this.clLastMount = %client;
				%team=Client::getTeam(%client);
				if(GameBase::getDataName(%this) == AAPC) 
				{//	if($traceVeh) echo( $ver@"| Vehicle is an AAPC Add player to Set of Passengers",%team);
					if($AAPCSet[%team])
					{	// if($traceVeh) echo( $ver@"| Passenger ",%client," Added to Passemger List for Team ",%team);
						addToSet($AAPCSet[%team],%client);
						%client.inAAPC=%this;
						startAAPCresupply(%this);
					}
				}
			}
			else if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != HoverBike)) 
			{	if(%vehicle==AAPC)	// Vehicle is an AAOD Assault Vehicle
				{	%teamv=%this.purchaseTeam;
					%teamp=Client::getTeam(%client);
					// if($trace) echo(" Mounting AAPC belonging to Team ",%teamv," Player is ",%teamp);
					if(%teamp != %teamv)
					{	if (%client.talent[$Stealth]!=2) // Infiltrators Can Mount Enemy AAPC
						{	// AAPC is of the other Team..... Activate Shields....Apply Kickback
								Eject(%this,%object);
								return;
						}

					}
					
					// if($traceVeh) echo( $ver@"| Vehicle is an AAPC Add player to Set of Passengers",%teamp);
					if($AAPCSet[%teamp])
					{	// if($traceVeh) echo( $ver@"| Passenger ",%client," Added to Passemger List for Team ",%teamp);
						addToSet($AAPCSet[%teamp],%object);
						%client.inAAPC=%this;
						startAAPCresupply(%this);
					}
					
					
					
				}
				%mountSlot= Vehicle::findEmptySeat(%this,%client);
				if(%mountSlot) 
				{	%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
					//
					CheckStealth(%client);
					// 
				}
			}
			else if (GameBase::getControlClient(%this) == -1) 
			{	Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");}
		}
	}
}

function Eject(%this,%object)
{	GiveKickBack(%object, 500, 1);
	%name=Object::GetName(%this);
	Client::sendMessage(Player::getClient(%object),0,%name@" is useable only by the same Team!!!.~wError_Message.wav");
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
} 


function Vehicle::dismount(%this,%mom)
{//	if($traceveh) echo( $ver@"|Vehicle dismount  (Vehicle =",%this,")");
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {		%vehicle=GameBase::getDataName(%this);
	  		%client=Player::GetClient(%cl);	  
			// dismount the player
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) 
			{
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 	Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") 
				{	Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      			}
				%pl.driver = "";
				%pl.vehicle = "";
				%cl.inAAPC="";
				CheckStealth(%cl);
				
				if(%vehicle==AAPC)	// Vehicle is an AAOD Assault Vehicle
				{	%team=Client::getTeam(%client);
				//	if($traceVeh) echo(" DIS-Mounting AAPC belonging to Team ",%team," Player is ",%client);
					if($AAPCSet[%team])
					{	// if($traceVeh) echo( $ver@"| Passenger ",%cl," Added to Passemger List for Team ",%team);
						removefromSet($NodeSet[%team],%client);
					}
					%client.inAAPC="";
				}
				
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
	}
}


function Vehicle::passengerJump(%this,%passenger,%mom)
{	// if($traceveh) echo( $ver@"|Vehicle Passenger Jump (%this,%passenger) (",%this,", ",%passenger,")");
	%armor = Player::getArmor(%passenger);
	%arm=String::getSubStr(%armor, 0, 1);
	if(%arm == "l") 
	{
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%arm == "m") 
	{
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%arm == "h") 
	{
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%vehicle=GameBase::getDataName(%this);
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
		%passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
		%client.inAAPC="";
		CheckStealth(%client);
		if(%vehicle==AAPC)	// Vehicle is an AAOD Assault Vehicle
		{	%team=Client::getTeam(%client);
			if($traceVeh) echo(" DIS-Mounting AAPC belonging to Team ",%team," Player is ",%client);
			if($AAPCSet[%team])
			{	if($traceVeh) echo( $ver@"| Passenger ",%cl," Added to Passemger List for Team ",%team);
				removefromSet($NodeSet[%team],%client);
			}
			%client.inAAPC="";
		}
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function CheckAAPCResupply(%this)
{	%team=GameBase::getTeam(%this);
	%num=Group::objectCount($AAPCSet[%team]);
	if($traceveh) echo( $ver@"|AAPC Resupply (this) (",%this,") for Team ",%team," Number of Passengers =",%num);
	if (%num>0)
	{	for(%i=0;%i<%num;%i++)
		{	%client=Group::GetObject($AAPCSet[%team],%i);
			if($traceveh) echo( $ver@"|Resupplying Passenger : Client is:",%client);
			if(%client)
				AAPCRessuply(%this,%client);
		}
		schedule("CheckAAPCResupply("@%this@","@%client@");",5,%client);
	}
	else
	{
		%this.issupplying="";
		if($traceveh) echo( $ver@"|Stopping Re-supply Loop : Client is:",%client);
	}
}

function startAAPCresupply(%this)
{	if($traceveh) echo("Starting AAPC Resupply Loop");
	if (%this.issupplying)
		return;
	else
	{	%this.issupplying=true;
		CheckAAPCResupply(%this);
	}
}
function AAPCRessuply(%this,%client)
{	if($traceveh) echo(" AAPC Resupplying Player ",%player);
	%player = Client::getOwnedObject(%client);
	%energy=GameBase::getEnergy(%this);
	if (%client.inAAPC)
	{	if (%energy>5)
		{	%energy-=1;
			GameBase::setEnergy(%this,%energy);
			if (%player != -1)
			{	%cnt = Station::itemsToResupply(%player);
				if (%cnt != 0) 
				{	updateBuyingList(%client);}
			}
	
		}
		else
			Client::sendMessage(%client,0,"AAPC Energy Reserves Low - unable to resupply");
	}
}
//***************************************
//		END AAOD VEHICLE BLOCK
//***************************************

function TeamKillerCheck(%player)
{	if($trace) echo($Ver," Team Killer Check for player",%player);
	%name=Client::getName(%player);
	if(%player.teamkills>=$TeamKillMax)
	{	// Player is a Team Killer Kick the rotten bugger
		CenterPrint(%player,"<jc>Team Killers will not be tolerated on this server!!!\nYou are being AUTO Kicked for Team Killing!!",5);
		Client::sendMessage(%player,0,"~wAAODSFX61.wav");
		MessageAllExcept(%player, 0, %name@ " has been AUTO Kicked for Team Killing!~wAAODSFX62.wav");
		%player.tkick++;
		if(%player.tkick>=$TKRetries) %player.banned=true;
		AAOD_leaveGame(%player);
		schedule("Net::Kick ("@%player@");",4);
	}
	else	// Issue Warning
	{
		CenterPrint(%player,"<jc>Team Killers will not be tolerated on this server!!!\nIf you continue to Team Kill you will be Kicked!!",5);
		Client::sendMessage(%player,0,"~wAAODSFX14.wav");
	}

	if(%player.tkObjects>=$TKillObjMax)
	{	// Player is a Team Killer Kick the rotten bugger
		CenterPrint(%player,"<jc>Team Killers will not be tolerated on this server!!!\nYou are being AUTO Kicked for Team Killing!!",5);
		Client::sendMessage(%player,0,"~wAAODSFX62.wav");
		MessageAllExcept(%player, 0, %name@ " has been AUTO Kicked for Team Killing!~wAAODSFX62.wav");
		%player.tkick++;
		if(%player.tkick>=$TKRetries) %player.banned=true;
		AAOD_leaveGame(%player);
		schedule("Net::Kick ("@%player@");",4);
	}
	else	// Issue Warning
	{
		CenterPrint(%player,"<jc>Team Killers will not be tolerated on this server!!!\nIf you continue to Team Kill you will be Kicked!!",5);
		Client::sendMessage(%player,0,"~wAAODSFX14.wav");
	}
}

function TeamMessage(%team,%msg,%loc,%snd)
{	if(%loc==0)
	{	%msg=%msg@"~w"@%snd@".wav";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
				Client::sendMessage(%cl, $MsgTypeChat, %msg);
	}
	else if (%loc==1)	// TOP
	{	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{	if(gameBase::GetTeam(%cl)==%Team)
			{	topprint(%cl, %msg,5);
				if(%snd!="")
				{	%snd="~w"@%snd@".wav";
					Client::sendMessage(%cl, $MsgTypeChat, %snd);
				}
			}
		}
	}
	else if (%loc==2)	// Center
	{	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{	if(gameBase::GetTeam(%cl)==%Team)
			{	centerprint(%cl, %msg,5);
				if(%snd!="")
				{	%snd="~w"@%snd@".wav";
					Client::sendMessage(%cl, $MsgTypeChat, %snd);
				}
			}
		}
	}
	else if (%loc==3)	// Bottom
	{	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{	if(gameBase::GetTeam(%cl)==%Team)
			{	bottomprint(%cl, %msg,5);
				if(%snd!="")
				{	%snd="~w"@%snd@".wav";
					Client::sendMessage(%cl, $MsgTypeChat, %snd);
				}
			}
		}
	}
}

function DesignateTarget(%this,%dur,%that)
{	// Designator should deal only with Objects & Not clients
	if(%this.isMarked)
		return;
	if(%that==false)
	{	%team2=GameBase::getTeam(%this);
		%team1=GetEnemyTeam(%team2);
	}
	else
	{	%team1=GameBase::getTeam(%that);
		%team2=GameBase::getTeam(%this);
	}

	%pos=GameBase::GetPosition(%this);
	
	if (%team1==-1)	 %team1=GetEnemyTeam(%team2);

	%type=getObjectType(%this);
	%targetClient = Player::getClient(%this);

	if($trace) echo("Designating ",%this," as a ",%type," target for ",%Dur," seconds.");

	if (%type == "Player")				// If This is a player
	{	%mark = newObject("","Item",UnBeacon,1,true);
		if($traceObj) Echo($Ver,"|Created New Object :",%mark," | Un Beacon");
		addToSet("MissionCleanup", %mark);
		GameBase::setTeam(%mark,%team1);
		GameBase::setPosition(%mark,%pos);
		%res1=GameBase::setIsTarget(%mark,true);
		schedule("Tracer("@%this@","@%mark@");",0.35,%mark);
		schedule("UnDesignate("@%this@","@%mark@");",%dur);	
		%this.isMarked=true;
		if($trace) echo( $ver@"|Results of Designator: Target=",%res1);
	}
	else if(%type == "flier")
	{	GameBase::setTeam(%this,%team1);
		GameBase::setIsTarget(%this,true);
		%this.isMarked=true;
		schedule("UnDesignateVehicle("@%this@","@%team2@");",%dur);
	}
	else
	{	%pos=GameBase::GetPosition(%this);
		%mark = newObject("Un-beacon","Item",UnBeacon,1,false);
		if($traceObj) Echo($Ver,"|Created New Object :",%mark," | UnBeacon");
		addToSet("MissionCleanup", %mark);
		GameBase::setTeam(%mark,%team1);
		GameBase::setPosition(%mark,%pos);
		%result=GameBase::setIsTarget(%mark,true);
		if($trace) echo( $ver@"|resut of beacon=",%result);
		schedule("UnDesignate("@%this@","@%mark@");",%dur);	
		%this.isMarked=true;
	}
}

function UnDesignate(%this,%mark)
{	deleteObject(%mark);
	%this.isMarked=false;
}

function UnDesignateVehicle(%this,%team)
{	if($traceveh) echo( $ver@"|UnDesignate Vehicle");
	GameBase::setIsTarget(%this,false);
	GameBase::setTeam(%this,%team);
	%this.isMarked=false;
}

function Tracer(%this,%mark)
{	%pos=GameBase::GetPosition(%this);
	GameBase::setPosition(%mark,%pos);
	if(%this.isMarked)
		schedule("Tracer("@%this@","@%mark@");",0.5,%mark);
}
function AAOD_unused_abs(%num)	// PORT: was Abs -- an engine command in 1.50 (same result)
{	if(%num<0) %num*=-1;
	return(%num);
}



exec(AAOD_Items);
//exec(AAOD_Vehicles);
exec(AAOD_Admin);
exec(AAOD_Deployables);
exec(AAOD_Exp);
exec(AAOD_Users);
