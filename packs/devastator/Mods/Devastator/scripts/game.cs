exec("comchat.cs");
$SensorNetworkEnabled = true;

$Console::LogMode = 2;

//$Server::FileURL = "<jc>\n<f2>www.PlanetTribes.com/OldSchool/Devastator.zip\n <f0>Go get it!";
$Server::FileURL = "<jc>\n<f2>www.GeoCities.com/Ice29407/Devastator.zip\n <f0>Go get it!";
$DModVersion = "BETA v0.99 - Serverside";
$Mod::Current = "Devastator";

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//  Global Variables

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
//---------------------------------------------------------------------------------
$flagToStandTime = 180;	  

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 3000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 2;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$ItemObjectType		 = 1 << 21;
$MoveableObjectType	 = 1 << 22;
$StaticObjectType	 = 1 << 23;
$MineObjectType		 = 1 << 26;
$VehicleObjectType	 = 1 << 29;

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
//- NEW DEATH MSG VARIABLES BY ICE (Now you can be specific in your death messages)
//---------------------------------------------------------------------------------
// %1 = killer's name                   %2 = victim's name,     
// %3 = killer's Pronoun    (his/her)   %4 = victim's Pronoun    (his/her)
// %5 = killer's ProperNoun (he /she)   %6 = victim's ProperNoun (he/she)
// %7 = killer's Noun       (him/her)   %8 = victim's Noun       (him/her)
//---------------------------------------------------------------------------------
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";
$deathMsg[$SBulletDamageType, 0]      = "%1 sticks a shotgun up %2's ass and pulls the trigger.";
$deathMsg[$SBulletDamageType, 1]      = "%1 taught %2 that you should never trust a man with a shotgun.";
$deathMsg[$SBulletDamageType, 2]      = "%2's head is ripped off by %1's shotgun.";
$deathMsg[$SBulletDamageType, 3]      = "%1's buckshot taught %2 about spread fire.";
$deathMsg[$PBulletDamageType, 0]      = "%2 didn't hear the shot coming from %1.";
$deathMsg[$PBulletDamageType, 1]      = "%2's death was as silent as %1's footsteps.";
$deathMsg[$PBulletDamageType, 2]      = "%2 is shot by %1's silenced pistol.";
$deathMsg[$PBulletDamageType, 3]      = "%1 puts one between %2's eyes with %3 silenced pistol.";
$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's Stormhammer.";
$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";
$deathMsg[$FragDamageType, 0]        = "%1 poriferated %2 with %3 Frag Grenade.";
$deathMsg[$FragDamageType, 1]        = "%2 walked into %1's Frag Grenade.";
$deathMsg[$FragDamageType, 2]        = "%1 tossed %2 a Frag Grenade.";
$deathMsg[$FragDamageType, 3]	     = "%2 forgot to toss %1's Frag Grenade back.";
$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";
$deathMsg[$MissileDamageType, 0]	    = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	    = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";
$deathMsg[$AAMineDamageType, 0]	       = "%1 's AA Mine caught up to %2.";
$deathMsg[$AAMineDamageType, 1]	       = "%2 was shot down by %1's AA Mine.";
$deathMsg[$AAMineDamageType, 2]	       = "%1 blasted %2 out of the air with %3 AA Mine.";
$deathMsg[$AAMineDamageType, 3]	       = "%2 should have watched out for %1's AA Mine.";
$deathMsg[$MiniDamageType, 0]      = "%2 is ripped up by %1's minigun.";
$deathMsg[$MiniDamageType, 1]      = "%1's minigun shredded %2.";
$deathMsg[$MiniDamageType, 2]      = "%1's Minigun showed %2 how to dance.";
$deathMsg[$MiniDamageType, 3]      = "%1's Minigun puts a lot of holes in %2.";
$deathMsg[$SniperDamageType, HS]     = "%1 pulls off a headshot on %2 with %3 sniper rifle.";
$deathMsg[$SniperDamageType, 0]      = "%2 gets a 3rd eye thanks to %1's sniper rifle.";
$deathMsg[$SniperDamageType, 1]      = "%1 tries to get %2's attention with %3 sniper rifle.";
$deathMsg[$SniperDamageType, 2]      = "%2 is tagged by %1's sniper rifle.";
$deathMsg[$SniperDamageType, 3]      = "%2 gets knocked down by %1's sniper rifle.";
$deathMsg[$LaserDamageType, 0]        = "%1 adds %2 to %3 list of Long-Range Laser victims.";
$deathMsg[$LaserDamageType, 1]        = "%1 fells %2 with a Long-Range Laser blast.";
$deathMsg[$LaserDamageType, 2]        = "%2 becomes a victim of %1's Long-Range Laser.";
$deathMsg[$LaserDamageType, 3]        = "%2 took to many hits from %1's Long-Range Laser.";
$deathMsg[$LaserCutDamageType, 0]     = "%1 sliced through %2's armor with %3 Cutting Laser.";
$deathMsg[$LaserCutDamageType, 1]     = "%1 burned holes in %2 with %3 Cutting Laser.";
$deathMsg[$LaserCutDamageType, 2]     = "%2 melted at the work of %1's Cutting Laser.";
$deathMsg[$LaserCutDamageType, 3]     = "%2 was singed by %1's Cutting Laser.";
$deathMsg[$MesonDamageType, 0]      = "%2 is taught a lesson about energy shotguns by %1.";
$deathMsg[$MesonDamageType, 1]      = "%1 gives %2 an energy overdose with %3 Meson Shotgun.";
$deathMsg[$MesonDamageType, 2]      = "%2 is vaporized by %1's Meson Shotgun.";
$deathMsg[$MesonDamageType, 3]      = "%1 fed %2 a handful of Meson shot with %3 barrel.";
$deathMsg[$PsychoDamageType, 0]      = "%2 tried to get TOO close to the ¡Psycho!, %1.";
$deathMsg[$PsychoDamageType, 1]      = "%2 didn't realize %1 was a ¡Psycho!";
$deathMsg[$PsychoDamageType, 2]      = "%2 feels the 'burn' after getting too close to %1.";
$deathMsg[$PsychoDamageType, 3]      = "%1 went ¡Psycho! on %2!";
$deathMsg[$ViralDamageType, 0]      = "%1 gave %2 a little bug.";
$deathMsg[$ViralDamageType, 1]      = "%1 uploaded a virus on %2.";
$deathMsg[$ViralDamageType, 2]      = "%2 caught a bit of a bug from %1.";
$deathMsg[$ViralDamageType, 3]      = "%2 was 'REPAIRED' by %1.";
$deathMsg[$BeamDamageType, 0]      = "%1 showed %2 the REAL light with %3 Beam Cannon.";
$deathMsg[$BeamDamageType, 1]      = "%1 evaporated %2 with %3 Beam Cannon.";
$deathMsg[$BeamDamageType, 2]      = "%2 melted at %1's Beam Cannon laser.";
$deathMsg[$BeamDamageType, 3]      = "%2 wasn't quite quick enough to avoid %1's Beam Cannon.";
$deathMsg[$FlameDamageType, 0]      = "%2 got a little TOO warmed up with %1.";
$deathMsg[$FlameDamageType, 1]      = "%1 caught %2 on fire.";
$deathMsg[$FlameDamageType, 2]      = "%1 turned %2 into a smoldering pile of ash.";
$deathMsg[$FlameDamageType, 3]      = "%2 burned to the ground as %1 laughed.";
$deathMsg[$AssaultDamageType, 0]      = "%1 loaded %2 with Assault rifle rounds.";
$deathMsg[$AssaultDamageType, 1]      = "%2 was at the wrong end of %1's Assault Rifle.";
$deathMsg[$AssaultDamageType, 2]      = "%1 taught %2 the advantage of having an Assault Rifle.";
$deathMsg[$AssaultDamageType, 3]      = "%2 got a 'blast' out of %1's Assault Rifle.";
$deathMsg[$NukeDamageType, 0]      = "%2 shouldn't have walked into %1's Nuclear Blast.";
$deathMsg[$NukeDamageType, 1]      = "%1 launched a Nuclear Blast at %2.";
$deathMsg[$NukeDamageType, 2]      = "%2 should have noticed the slow moving Nuclear Blast from %1.";
$deathMsg[$NukeDamageType, 3]      = "%2 was obliterated by %1's Nuclear Fission Emitter.";
$deathMsg[$ShockDamageType, 0]      = "%2 was knocked down by %1's ShockWave Rifle.";
$deathMsg[$ShockDamageType, 1]      = "%1 nailed %2 with %3 ShockWave Rifle.";
$deathMsg[$ShockDamageType, 2]      = "%2 should have have avoided %1's ShockWave Blast.";
$deathMsg[$ShockDamageType, 3]      = "%2 was blown apart by %1's ShockWave Rifle.";
$deathMsg[$MultiDamageType, 0]      = "%2 caught one of %1's Multi-Rockets.";
$deathMsg[$MultiDamageType, 1]      = "%1 plastered %2 to the ground with %3 Multi-Rockets.";
$deathMsg[$MultiDamageType, 2]      = "%2 should have have been more careful around %1's Multi-Rockets.";
$deathMsg[$MultiDamageType, 3]      = "%2 was shredded by %1's Multi-Rockets.";
$deathMsg[$SwordDamageType, 0]      = "%2 gets diced up by %1's Flame Sword.";
$deathMsg[$SwordDamageType, 1]      = "%1 cut %2 in half with %3 Flaming Blade.";
$deathMsg[$SwordDamageType, 2]      = "%1 singed through %2's armor with %3 Flame Sword.";
$deathMsg[$SwordDamageType, 3]      = "%2 was sliced and diced by %1's Flame Sword.";
$deathMsg[$LPDamageType, 0]      = "%1 showed %2 what %3 little Laser Pistol can really do.";
$deathMsg[$LPDamageType, 1]      = "%1 surprised %2 with %3 Laser Pistol.";
$deathMsg[$LPDamageType, 2]      = "%1 burned holes in %2 with %3 Laser Pistol.";
$deathMsg[$LPDamageType, 3]      = "%2 was singed by %1's Laser Pistol.";
$deathMsg[$RicochetDamageType, 0]      = "%2 was shredded by %3 own bullets.";
$deathMsg[$RicochetDamageType, 1]      = "%2 didn't know that bullets ricochet off of GODs.";
$deathMsg[$RicochetDamageType, 2]      = "%1 laughed to %3self as %2 wasted %4self with %4 own bullets!";
$deathMsg[$RicochetDamageType, 3]      = "%2 caught a ricocheting bullet off of %1.";
$deathMsg[$GuardDamageType, 0]      = "%1 'knocked the breath out of %2' permanantly with %3 Raptor.";
$deathMsg[$GuardDamageType, 1]      = "%2 was floored by %1's Raptor.";
$deathMsg[$GuardDamageType, 2]      = "%1's Raptor smashed %2!";
$deathMsg[$GuardDamageType, 3]      = "%2 got one too many high impact shells from %1's Raptor.";
$deathMsg[$SynDamageType, 0]      = "%1 'ate' %2 alive with %3 Syndicate.";
$deathMsg[$SynDamageType, 1]      = "%2 was eaten alive by %1's Syndicate.";
$deathMsg[$SynDamageType, 2]      = "%1's Syndicate satisfied It's appetite on %2!";
$deathMsg[$SynDamageType, 3]      = "%2 found %1's Syndicate to have horrible table mannors.";
$deathMsg[$HGDamageType, 0]      = "%1 and %3 Hostage Gun were just too quick for %2.";
$deathMsg[$HGDamageType, 1]      = "%2 was caught surprised by %1's Hostage Gun.";
$deathMsg[$HGDamageType, 2]      = "%1 sneaked up on %2 with %3 Hostage Gun.";
$deathMsg[$HGDamageType, 3]      = "%2 shouldn't have resisted being taken Hostage by %1";
$deathMsg[$KamiKazeKDamageType, 0]      = "%1 showed %2 how desperate %5 was with %3 Suicide Pack.";
$deathMsg[$KamiKazeKDamageType, 1]      = "%2 noticed %1's Suicide Pack seconds too late.";
$deathMsg[$KamiKazeKDamageType, 2]      = "%1 blowed %2 and %7self up good.";
$deathMsg[$KamiKazeKDamageType, 3]      = "%1 clicked a little button and blew %2 and %7self to bits.";
$deathMsg[$BoomDamageType, 0]      = "%1 showed %3 rage to %2.";
$deathMsg[$BoomDamageType, 1]      = "%2 pissed %1 off for the last time.";
$deathMsg[$BoomDamageType, 2]      = "%1 blasted %2 with %3 rage."; //-%2 - his? %3 = he?
$deathMsg[$BoomDamageType, 3]      = "%1 asks %2, 'What do you mean Anger Management!?'";
$deathMsg[$PCDamageType, 0]      = "%1 fused %2 to the ground with %3 Hellfire Cannon.";
$deathMsg[$PCDamageType, 1]      = "%2 was victim to a Hellfire blasting from %1.";
$deathMsg[$PCDamageType, 2]      = "%1 gave %2 a little too much Hellfire blasts for one day.";
$deathMsg[$PCDamageType, 3]      = "%2 wouldn't be dead if only %4 had avoided %1's Hellfire Cannon";
$deathMsg[$RocketDamageType, 0]	    = "%1 shoves a missile up %2's keister.";
$deathMsg[$RocketDamageType, 1]	    = "%2 gets shot down by %1.";
$deathMsg[$RocketDamageType, 2]	    = "%2 gets real friendly with %1's rocket.";
$deathMsg[$RocketDamageType, 3]	    = "%2 feels the burn from %1's warhead.";
$deathMsg[$AcidDamageType, 0]	   = "%1 gave %2 an acid complex.";
$deathMsg[$AcidDamageType, 1]	   = "%2 was dissolved by %1's Acid-Gun.";
$deathMsg[$AcidDamageType, 2]	   = "%1 melted %2 with %3 Acid-Gun.";
$deathMsg[$AcidDamageType, 3]      = "%2 was plastered to the floor by %1's Acid-Gun.";
$deathMsg[$Plasma2DamageType, 0]     = "%1 nailed %2 too many times with %3 Plasma Pistol.";
$deathMsg[$Plasma2DamageType, 1]     = "%2 was knocked down by %1's Plasma Pistol.";
$deathMsg[$Plasma2DamageType, 2]     = "%1 burned %2 with %3 Plasma Pistol.";
$deathMsg[$Plasma2DamageType, 3]     = "%2 was singed by %1's Plasma Pistol.";

//-Vehicle Smack Messages
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$KamikazeDamageType, 0]    = "%1 rode %3 Kamikaze into %2.";
$deathMsg[$KamikazeDamageType, 1]    = "%1's Kamikaze crashed %2's party.";
$deathMsg[$KamikazeDamageType, 2]    = "%2 was smeared and blown up by %1's Kamikaze.";
$deathMsg[$KamikazeDamageType, 3]    = "%2 got smacked like a bug by %1's Kamikaze.";
$deathMsg[$KamiDiveDamageType, 0]    = "%1 sent %3 Kamikaze diving into %2.";
$deathMsg[$KamiDiveDamageType, 1]    = "%1's Kamikaze took a dive into %2.";
$deathMsg[$KamiDiveDamageType, 2]    = "%2 got in the way of %1's Kamikaze dive.";
$deathMsg[$KamiDiveDamageType, 3]    = "%1 dove %3 Kamikaze into %2.";

//-Vehicle Weapon Messages
$deathMsg[$KamiRocketDamageType, 0]    = "%1 used %3 only Kamikaze blast on %2.";
$deathMsg[$KamiRocketDamageType, 1]    = "%1 took out %2 with %3 Kamikaze blast.";
$deathMsg[$KamiRocketDamageType, 2]    = "%2 got in the way of %1's Kamikaze blast.";
$deathMsg[$KamiRocketDamageType, 3]    = "%2 was nailed by %1's Kamikaze blast.";
$deathMsg[$KamiDetDamageType, 0]       = "%1 blew %3 Kamikaze sky high next to %2.";
$deathMsg[$KamiDetDamageType, 1]       = "%1's Kamikaze detonated too close to %2.";
$deathMsg[$KamiDetDamageType, 2]       = "%1 parked and detonated %3 Kamikaze right next to %2.";
$deathMsg[$KamiDetDamageType, 3]       = "%2 couldn't get away from %1's Kamikaze before %5 could detonate it.";
$deathMsg[$RemoteDetDamageType, 0]     = "%1 blew %2 to chunks with %3 Remote Detonation.";
$deathMsg[$RemoteDetDamageType, 1]     = "%1's Remote detonated right on %2.";
$deathMsg[$RemoteDetDamageType, 2]     = "%1 chased %2 with %3 Remote and then Detonated it.";
$deathMsg[$RemoteDetDamageType, 3]     = "%2 didn't realize %1's Remote was close enough to Detonate .";
$deathMsg[$ParaBombDamageType, 0]      = "%1 dropped a ParaBomb on %2.";
$deathMsg[$ParaBombDamageType, 1]      = "%1's ParaBomb found its way onto %2's path.";
$deathMsg[$ParaBombDamageType, 2]      = "%2 was blown to fragments by %1's ParaBomb.";
$deathMsg[$ParaBombDamageType, 3]      = "%2 shouldn't have stayed to read the label on %1's ParaBomb.";
$deathMsg[$StingerADamageType, 0]      = "%1's Stinger sent %2 home in a jar.";
$deathMsg[$StingerADamageType, 1]      = "%1's Stinger took out %2.";
$deathMsg[$StingerADamageType, 2]      = "%2 couldn't shake %1's Stinger.";
$deathMsg[$StingerADamageType, 3]      = "%2 didn't realize %1's Stinger had a lock on %8.";
$deathMsg[$StingerBDamageType, 0]      = "%1's EMP rocket fried %2.";
$deathMsg[$StingerBDamageType, 1]      = "%1 used %3 EMP rocket on %2.";
$deathMsg[$StingerBDamageType, 2]      = "%2 was shutdown by %1's EMP rocket.";
$deathMsg[$StingerBDamageType, 3]      = "%2 didn't see %1's EMP rocket coming.";
$deathMsg[$FlareDamageType, 0]         = "%1 burned %2 to a crisp with %3 Heat Flare.";
$deathMsg[$FlareDamageType, 1]         = "%1's Heat Flare sizzled out on %2.";
$deathMsg[$FlareDamageType, 2]         = "%2 though %3 supposed to catch %1's Heat Flare.";
$deathMsg[$FlareDamageType, 3]         = "%2 found %1's Heat Flare and got too close.";
$deathMsg[$MinePodDamageType, 0]       = "%1's Mine Pod scattered %2 to bits.";
$deathMsg[$MinePodDamageType, 1]       = "%1 dropped a Mine Pod right where %2 was walking.";
$deathMsg[$MinePodDamageType, 2]       = "%2 tripped on %1's Mine Pod.";
$deathMsg[$MinePodDamageType, 3]       = "%2 couldn't get away from %1's Mine Pos.";
$deathMsg[$FalconMissileDamageType, 0] = "%1's Missile showed %2 the advantage of being an Ace.";
$deathMsg[$FalconMissileDamageType, 1] = "%1 shot a Missile in %2's way.";
$deathMsg[$FalconMissileDamageType, 2] = "%2 was turned into goo by %1's Missile.";
$deathMsg[$FalconMissileDamageType, 3] = "%2 didn't see %1's Missile in time.";
$deathMsg[$FalconRocketDamageType, 0]  = "%1 shot %2 down with %3 Falcon rockets.";
$deathMsg[$FalconRocketDamageType, 1]  = "%1's Falcon's rockets nailed %2.";
$deathMsg[$FalconRocketDamageType, 2]  = "%2 bit %1's Falcon rocket.";
$deathMsg[$FalconRocketDamageType, 3]  = "%2 thought %1's Falcon was out of rockets.";
$deathMsg[$FalconShockDamageType, 0]   = "%1 used %3 only Kamikaze blast on %2.";
$deathMsg[$FalconShockDamageType, 1]   = "%1 took out %2 with %3 Kamikaze blast.";
$deathMsg[$FalconShockDamageType, 2]   = "%2 was \"Shocked\" when %4 saw %1's Shock Missile heading for %8.";
$deathMsg[$FalconShockDamageType, 3]   = "%2 was blasted by %1's Shock Missiles.";
$deathMsg[$FalconGrenadeDamageType, 0] = "%1's Falcon's Grenade Launcher was too much for %2.";
$deathMsg[$FalconGrenadeDamageType, 1] = "%1 used %3 Falcon's Grenade Launcher on %2.";
$deathMsg[$FalconGrenadeDamageType, 2] = "%1 lobbed a few Falcon Grenades in %2's way.";
$deathMsg[$FalconGrenadeDamageType, 3] = "%2 caught %1's Falcon's Grenade.";
$deathMsg[$BulletVDamageType, 0]       = "%1's Eagle Fighter technique was too much for %2.";
$deathMsg[$BulletVDamageType, 1]       = "%2 was rivetted into the earth by %1's Eagle Fighter.";
$deathMsg[$BulletVDamageType, 2]       = "%1 won the Dog-Fight against %2 in %3 Eagle Fighter.";
$deathMsg[$BulletVDamageType, 3]       = "%1 strafed %2 with his Eagle Fighter.";
$deathMsg[$CrazySpikeDamageType, 0]    = "%1's Remote layed %2 waste.";
$deathMsg[$CrazySpikeDamageType, 1]    = "%2 was confused %1's Remote's Porchupine Guns.";
$deathMsg[$CrazySpikeDamageType, 2]    = "%1 got lucky and pegged %2 with %3 Porchupine Guns.";
$deathMsg[$CrazySpikeDamageType, 3]    = "%2 didn't think that %1's Remote could hit %4 with the Porchupine Guns.";
$deathMsg[$BomberDamageType, 0]	       = "%1's Night Hawk bombing run was too much for %2.";
$deathMsg[$BomberDamageType, 1]	       = "%2 was blasted to bits by %1's Night Hawk bombing run.";
$deathMsg[$BomberDamageType, 2]	       = "%1 dropped the hammer on %2 with %3 Night Hawk.";
$deathMsg[$BomberDamageType, 3]	       = "%2 shouldn't have been under %1's Night Hawk bomber.";
$deathMsg[$BigBomberDamageType, 0]     = "%1 devastated %2 and %4 surroundings with %3 B-52 bombing run.";
$deathMsg[$BigBomberDamageType, 1]     = "%2 was thundered into the ground by %1's B-52 bomber.";
$deathMsg[$BigBomberDamageType, 2]     = "%1 hammered the earth in around %2 with %3 B-52 bomber.";
$deathMsg[$BigBomberDamageType, 3]     = "%2 was in the way of %1's B-52 bombing run.";
$deathMsg[$B52GunnerDamageType, 0]     = "%1 nailed %2 with %3 B-52 gun.";
$deathMsg[$B52GunnerDamageType, 1]     = "%2 was torn apart by %1's B-52 gun.";
$deathMsg[$B52GunnerDamageType, 2]     = "%1 strafed %2 from %3 B-52.";
$deathMsg[$B52GunnerDamageType, 3]     = "%2 was chewed up by %1's B-52 gun.";

//-OK, I'll admit, the following are just a little bit on the weird and unusual side
$deathMsg[$FlagDamageType, 0]      = "%2 was pummeled by %4 own flag carried by %1!";
$deathMsg[$FlagDamageType, 1]      = "%1 beat %2 senseless with %4 own flag!";
$deathMsg[$FlagDamageType, 2]      = "%1 smeared %2 on %3 own flag!";
$deathMsg[$FlagDamageType, 3]      = "%2 was victim to %1's vicious Flag beating!";
$deathMsg[$ConfettiDamageType, 0]      = "%2 got a little TOO festive with %1's confetti.";
$deathMsg[$ConfettiDamageType, 1]      = "%1 choked %2 with confetti!";
$deathMsg[$ConfettiDamageType, 2]      = "%1 turned %2 into a large glittering corpse.";
$deathMsg[$ConfettiDamageType, 3]      = "%2 inhaled too much of %1's confetti.";
$deathMsg[$SmokeDamageType, 0]      = "%1's smoke launcher left %2 more than temporarily blinded.";
$deathMsg[$SmokeDamageType, 1]      = "%2 figured out that %4 COULDN'T breath in %1's smoke.";
$deathMsg[$SmokeDamageType, 2]      = "%1 test %3 smoke launcher on %2's face.";
$deathMsg[$SmokeDamageType, 3]      = "%2 couldn't find %4 way out of %1's smoke in time.";
$deathMsg[$ProtonDamageType, 0]      = "%2 found %1 to be explosively shocking.";
$deathMsg[$ProtonDamageType, 1]      = "%2 got TOO close to %1's Proton Grenade Launcher.";
$deathMsg[$ProtonDamageType, 2]      = "%1 gave %2 quite a shock with %2 Proton Grenade Launcher.";
$deathMsg[$ProtonDamageType, 3]      = "%2 got fried by %1's Proton Grenade Launcher.";
$deathMsg[$TazerDamageType, 0]      = "%2 found %1 to be quite shocking.";
$deathMsg[$TazerDamageType, 1]      = "%2 got TOO close to %1's bug-zapper.";
$deathMsg[$TazerDamageType, 2]      = "%1 gave %2 a little energy overload with %3 Tazer.";
$deathMsg[$TazerDamageType, 3]      = "%2 was shocked to no end by %1's Tazer.";
$deathMsg[$EvilPongDamageType, 0]      = "%2 was sliced and diced by %1's evil GOD PONG.";
$deathMsg[$EvilPongDamageType, 1]      = "%2 caught %1's GOD PONG the wrong way.";
$deathMsg[$EvilPongDamageType, 2]      = "%1 gave %2 a hard time with %3 GOD PONG skills.";
$deathMsg[$EvilPongDamageType, 3]      = "%2 got GOD PONG'ed to death by %1.";
$deathMsg[$GodBootDamageType, 0]      = "%1 went for a field goal on %2's ass.";
$deathMsg[$GodBootDamageType, 1]      = "%2 had shoe-laces coming out of %4 mouth thanks to %1.";
$deathMsg[$GodBootDamageType, 2]      = "%1 shoved %3 boot up %2's ass.";
$deathMsg[$GodBootDamageType, 3]      = "%2 got the royal boot in the ass by %1.";
$deathMsg[$GODDamageType, 0]      = "%1 sent %2 to %4 grave with %3 GODly power.";
$deathMsg[$GODDamageType, 1]      = "%2 was deleted by %1's GODly power.";
$deathMsg[$GODDamageType, 2]      = "%1 used %3 GODly power to destroy %2.";
$deathMsg[$GODDamageType, 3]      = "%2 was evaporated by %1's GODly power.";

//-MY GOOD BUDDY THE SERVER OF FATE
$deathMsg[$ServerDamageType, 0]			= "%2 pushed %1 too far.";
$deathMsg[$ServerDamageType, 1]			= "%2 got %1 a little too edgy.";
$deathMsg[$ServerDamageType, 2]			= "%2 shouldn't have pissed off %1.";
$deathMsg[$ServerDamageType, 3]			= "%2 thought that %1 was only kidding.";
$deathMsg[$ServerDamageType, Choice0]		= "%2 asked %1 for %4 own death.";
$deathMsg[$ServerDamageType, Choice1]		= "%2 desired to die.";
$deathMsg[$ServerDamageType, Choice2]		= "%2 asked for %4 own death.";
$deathMsg[$ServerDamageType, Choice3]		= "%2 wanted %1 to kill %8.";
$deathMsg[$ServerDamageType, Hired0]		= "%2 was destroyed by %1 on command.";
$deathMsg[$ServerDamageType, Hired1]		= "%1 murdered %2 on command.";
$deathMsg[$ServerDamageType, Hired2]		= "%1 killed %2 as %5 was told.";
$deathMsg[$ServerDamageType, Hired3]		= "%2 shouldn't have pissed off %1's friend.";

//-LET THE BEER GUZZLIN' CHAOS AND INSANITY BEGIN!
$deathMsg[$BeerDamageType, 0]        = "%2 drown in %4 own vomit with some help from %1.";
$deathMsg[$BeerDamageType, 1]        = "%1 gave %2 a little too much to drink.";
$deathMsg[$BeerDamageType, 2]        = "%2 drank from %1's Keg for the last time.";
$deathMsg[$BeerDamageType, 3]        = "%2 was literally 'wasted' by %1's Keg.";
$deathMsg[$CarWreck,          Drunk] = "%2 learned that you shouldn't drink and drive the hard way.";
$deathMsg[$HGDamageType,      Drunk] = "%2's drunk ass shouldn't have refused being taken Hostage by %1.";
$deathMsg[$LandingDamageType, Drunk] = "%2's drunken self missed that last step.";
$deathMsg[$ImpactDamageType,  Drunk] = "%2's drunk carcass staggered into %1's flight-path.";

//------------------------------------------------------------------------------------
//- NEW VEHICLE DEATH MSG VARIABLES BY ICE (Now your vehicles can have death messages)
//------------------------------------------------------------------------------------
// %1 = killer's name                   %2 = victim's name,			%3 = vehicle's name,
// %4 = killer's Pronoun    (his/her)   %5 = victim's Pronoun    (his/her)
// %6 = killer's ProperNoun (he /she)   %7 = victim's ProperNoun (he/she)
// %8 = killer's Noun       (him/her)   %9 = victim's Noun       (him/her)
//------------------------------------------------------------------------------------
$VehDeathMsg[$Default,0] = "%2's %3 was shot down by %1.";
$VehDeathMsg[$Default,1] = "%1 brought %2's %3 down from the sky.";
$VehDeathMsg[$Default,2] = "%1 caught 2's %3 before it could get away.";
$VehDeathMsg[$Default,3] = "%2's %3 wasn't fast enough to avoid %1.";
$VehDeathMsg[$ImpactDamageType,0] = "%2's %3 was scared of heights.";
$VehDeathMsg[$ImpactDamageType,1] = "%2's %3 took a nose dive.";
$VehDeathMsg[$ImpactDamageType,2] = "%2's %3 wasn't high enough.";
$VehDeathMsg[$ImpactDamageType,3] = "%2's %3 played chicken with the ground.";
$VehDeathMsg[$GuardDamageType,0] = "%2's %3 took %1's Raptor Shell too hard.";
$VehDeathMsg[$GuardDamageType,1] = "%1 gave %2's %3 an unscheduled stop with %4 Raptor.";
$VehDeathMsg[$GuardDamageType,2] = "%1 found %2 and %5 %3 to be going a tad slow for %4 Raptor.";
$VehDeathMsg[$GuardDamageType,3] = "%2's %3 couldn't out maneuver %1's Raptor Shell in time.";
$VehDeathMsg[$TeamVehicleDamage,0] = "%2's %3 was destroyed by %5 teammate, %1.";
$VehDeathMsg[$TeamVehicleDamage,1] = "%1 TK'ed %2's %3.";
$VehDeathMsg[$TeamVehicleDamage,2] = "%2's %3 was TK'ed by %1.";
$VehDeathMsg[$TeamVehicleDamage,3] = "%2 found %1, %5 teammate, to have something against %5 %3.";

//------------------------------------------------------------------------------------
// %1 = player's name                   %2 = player's vehicle
// %3 = player's Pronoun    (his/her)   %4 = player's ProperNoun (he /she)
// %5 = player's Noun       (him/her)
//------------------------------------------------------------------------------------
$VehDeathMsg[$Unknown]		= "%1's %2 crashed.";
$VehDeathMsg[$Nuclear]		= "%1's %2 was obliterated by nuclear radiation.";

//------------------------------------------------------------------------------------ 
//- NEW SUICIDE MSG VARIABLES BY ICE (Now you can be specific in your suicide messages)
//------------------------------------------------------------------------------------
//%1 = player name                  %2 = player Pronoun (his/her)
//%3 = player ProperNoun (he /she)  %4 = player Noun (him/her)

//-Ctrl-K, ect., standard...
$SuicideMsg[-2,0]				= "%1 Played Russian Roulette with a fully loaded gun.";
$SuicideMsg[-2,1]				= "%1 Held the gun the wrong way.";
$SuicideMsg[-2,2]				= "%1 forgot the safety.";
$SuicideMsg[-2,3]				= "%1 couldn't take losing anymore.";

//-Try to hammer down on a MiniGun...
$SuicideMsg[$MGBurnDamageType, 0]		= "%1 shouldn't have held onto that Minigun for so long.";
$SuicideMsg[$MGBurnDamageType, 1]		= "%1 won a stupidity contest by holding a burning Minigun the longest.";
$SuicideMsg[$MGBurnDamageType, 2]		= "%1 melted along with %2 Minigun.";
$SuicideMsg[$MGBurnDamageType, 3]		= "%1 burned %4self too much with %2 Minigun.";

//-Oh, thats what the flare warning meant...
$SuicideMsg[$FlareOopsDamageType, 0]	= "%1 launched too many flares.";
$SuicideMsg[$FlareOopsDamageType, 1]	= "%1's efforts with %2 Flare went unnoticed.";
$SuicideMsg[$FlareOopsDamageType, 2]	= "%1's teammates never found %4.";
$SuicideMsg[$FlareOopsDamageType, 3]	= "%1 thought that %3 should launch as many flares as possible.";

//-Oops, my suicide pack didn't kill anyone but me
$SuicideMsg[$KamiKazeSDamageType, 0]	= "%1 bought the wrong pack.";
$SuicideMsg[$KamiKazeSDamageType, 1]	= "%1 pressed the wrong button.";
$SuicideMsg[$KamiKazeSDamageType, 2]	= "%1 got a bit trigger happy.";
$SuicideMsg[$KamiKazeSDamageType, 3]	= "%1 gave %2 Suicide Pack a test run too early.";

//-Oops, Frag Nades aren't edible - bullets not the actual boom
$SuicideMsg[$FragOopsDamageType, 0]	= "%1 tried juggling %2 Frag grenades.";
$SuicideMsg[$FragOopsDamageType, 1]	= "%1 didn't throw %2 Frag grenade far enough.";
$SuicideMsg[$FragOopsDamageType, 2]       = "%1 forgot to duck and cover after lobbing a Frag grenade.";
$SuicideMsg[$FragOopsDamageType, 3]       = "%1 decided to dive on %2 own Frag grenade.";

//-No clue why or who killed ya
$deathMsg[$Unknown]		= "%1 dies.";

//-Nuclear Mine caught ya
$deathMsg[$NukeRad]		= "%1 was obliterated by nuclear radiation.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = PantherArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = LP;
$spawnBuyList[3] = Grenade;
$spawnBuyList[4] = RepairPack;
$spawnBuyList[5] = RepairKit;
$spawnBuyList[6] = MineAmmo;

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
   // can't switch to command mode while a server menu is up
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
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
   if(!%clientId.menuMode)
      Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
   Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
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
   if(!%count)
      return -1;
  	%spawnIdx = floor(getRandom() * (%count - 0.1));
  	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
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
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = %client.lastObserverSpawn + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   messageAll(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	

   %numTeams = getNumTeams();
   for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
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
	echo(%respawn);
	if(!$ghosting)
		return false;
	Client::clearItemShopping(%clientId);
	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
	if(!%respawn)
		bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
	if(%spawnMarker) {   
		%clientId.guiLock = "";
		%clientId.dead = "";
		if(%spawnMarker == -1) {
			%spawnPos = "0 0 300";
			%spawnRot = "0 0 0";
		}
		else {
			%spawnPos = GameBase::getPosition(%spawnMarker);
			%spawnRot = GameBase::getRotation(%spawnMarker);
		}
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
			%armor = "qarmor";
		else
			%armor = "qfemale";
//		if(IsIce(%clientId))
//			%armor = "icemor";
		%pl = spawnPlayer(%armor,%spawnPos,%spawnRot);
		echo("SPAWN: cl: " @ %clientId @ " pl: " @ %pl @ " marker: " @ %spawnMarker @ " armor: " @ %armor);
		if(%pl != -1) {
			GameBase::setTeam(%pl, Client::getTeam(%clientId));
			Client::setOwnedObject(%clientId, %pl);
			Game::playerSpawned(%pl, %clientId, %armor, %respawn);
			if($matchStarted)
				Client::setControlObject(%clientId, %pl);
			else {
				%clientId.observerMode = "pregame";
				Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
				Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
			}
		}
		return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
		return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	if(%clientId.GODpref && !IsIce(%clientId))
		echo(%clientId@"'s GOD preference is: "@%clientId.GODpref);
	Client::setSkin(%clientId,$Client::info[%clientId,0]);
	%clientId.spawn= 1;
	%max = getNumItems();
	for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++) {
		buyItem(%clientId,%item);
		if(%item.className == Weapon)
			%clientId.spawnWeapon = %item;
	}
	
	%clientId.spawn = "";
	$Reloading[%clientId] = "";
	%clientId.tempRageCount = "";
	if(IsIce(%clientId))
		GiveIceList(%clientId);
	else
		MakeGod(%clientId,%clientId.GODpref);
//	if(%clientId.isSuperAdmin)
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);
   		%clientId.spawnWeapon="";
	}
	Reset::InventoryOnBuyList(%clientId);
	$CurWeap[%clientId] = 3;
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);
	if($Server::TourneyMode)
		GameBase::setTeam(%clientId, -1);
	else {
		if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit") {
			%clientId.observerMode = "observerOrbit";
			%clientId.guiLock = "";
			Observer::jump(%clientId);
			return;
		}
		%numTeams = getNumTeams();
		%curTeam = Client::getTeam(%clientId);
		if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)))
		Game::assignClientTeam(%clientId);
	}    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%camSpawn = Game::pickObserverSpawn(%clientId);
	Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	GameBase::getRotation(%camSpawn), true, true);
	if(Client::getTeam(%clientId) == -1) {
		%clientId.observerMode = "pickingTeam";
		if($Server::TourneyMode && ($matchStarted || $matchStarting)) {
			%clientId.observerMode = "observerFly";
			return;
		}
		else if($Server::TourneyMode) {
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
		}
		Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
		Client::addMenuItem(%clientId, "0Observe", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		%clientId.justConnected = "";
	}
	else {
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
		if(%clientId.justConnected) {
			centerprint(%clientId, $Server::JoinMOTD, 0);
			%clientId.observerMode = "justJoined";
			%clientId.justConnected = "";
		}
		else if(%clientId.observerMode == "justJoined") {
			centerprint(%clientId, "");
			%clientId.observerMode = "";
			Game::playerSpawn(%clientId, false);
		}
		else
			Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
	$ClientName[%clientId] = Client::getName(%clientId);
}

function processMenuInitialPickTeam(%clientId, %team)
{
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

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
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
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
      if(%cl.observerMode == "pregame")
         %playerCount++;
   }
   if(%playerCount == 0)
      return;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")   
         processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
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
   if($CountdownStarted || $matchStarted)
      return;
   
   // loop through all the clients and see if any are still notready
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
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
                     @ " are holding things up!";
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
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
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
	if(%client == "") {
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	      %cl.scoreKills = 0;
   	   %cl.scoreDeaths = 0;
			%cl.ratio = 0;
      	%cl.score = 0;
		}
	}
	else {
      %client.scoreKills = 0;
  	   %client.scoreDeaths = 0;
		%client.ratio = 0;
     	%client.score = 0;
	}
}

function remoteSetArmor(%player, %armorType)
{
	if ($ServerCheats) {
		checkMax(Player::getClient(%player),%armorType);
	   Player::setArmor(%player, %armorType);
	}
	else if($TestCheats) {
	   Player::setArmor(%player, %armorType);
	}
}

function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.justConnected = true;
	$ClientName[%playerId] = Client::getName(%playerId);
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

function CheckScoreRecord(%client)
{
	%Kills = %client.scoreKills;
	%Death = %client.scoreDeaths;
	%ratio = (%Kills / %Death)*10;
	%avg = (%client.KDratio+%ratio)/2;
	%client.KDavg = %avg;
	%client.KDratio = %ratio;
	return %client.KDratio;
}

function Client::onKilled(%playerId, %killerId, %damageType, %special)
{
	%playerVictim = Client::getOwnedObject(%playerId);
	%playerKiller = Client::getOwnedObject(%killerId);
	%objType = getObjectType(%killedId);
	%VctType = getObjectType(%playerId);
	$Reloading[%playerId] = 0;
	if($ClientName[%killerId])
		%killerName = $ClientName[%killerId];
	else
		%killerName = Client::getName(%killerId);
	if($ClientName[%playerId])
		%victimName = $ClientName[%playerId];
	else
		%victimName = Client::getName(%playerId);		
	if(%objType == "Flier")
		%killerId = %killerId.clLastMount;
	//----------------- Ace Mode Vehiclular Kills Tracking -----------------//
	if(%playerKiller.pilot == 1) {
		%vehicle = %playerKiller.vehicle;
		%multiplier = 1;
		if(Player::isJetting(%playerVictim)) {
			%vehicle.airKills++;
			%multiplier++;
		}
		if(%playerVictim.pilot) {
			%vehicle.pilotKills++;
			%multiplier++;
			if(GameBase::getDamageLevel(%playerVictim.vehicle) < 0.5)
				%multiplier++;
		}
		else if(AreSniper(%playerVictim)) {
			%vehicle.snipeKills++;
			%multiplier++;
		}
		else if(GameBase::isAtRest(%playerVictim)) {
			%vehicle.cheapKills++;
			%multiplier--;
		}
		%vehicle.score += %multiplier;
		%vehicle.kills++;
		Vehicle::CheckAceMode(%vehicle);
	}
	echo("GAME: "@%killerName@": "@%killerId@ " killed "@%victimName@": "@%playerId@", "@%damageType@"; Special: "@%special);
	%playerId.guiLock = true;
	if(%playerId.Owner != "" && %playerId.Owner != 0) {
		Client::sendMessage(%playerId.Owner,0,"Gun-Buddy destroyed by "@%killerName@"!");
		Client::sendMessage(%killerId,0,%victimName@" was a fake!");
		GameBase::startFadeIn(%playerId.Owner);
		return;
	}
	if(%killerId.Owner != "" && %killerId.Owner != 0) {
		Client::sendMessage(%killerId.Owner,0,"Your Gun-Buddy destroyed "@%playerName@"!");
		Client::sendMessage(%playerId,0,%killerName@"was a fake! Geez, you really suck");
	}
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male")) {
		%playerGender  = "his";
		%playerGender2 = "he";
		%playerGender3 = "him";
	}
	else {
		%playerGender  = "her";
		%playerGender2 = "she";
		%playerGender3 = "her";
	}
	if((AreGod(%killerId) == ultra || AreGod(%killerId) == true || AreGod(%killerId) == perfect) && %damageType == $ViralDamageType && %playerId.switcherooed == 1) {
		Client::sendMessage(%playerId,0,"You can't give a virus to a GOD like "@%killerName@"!");
		Client::sendMessage(%killerId,0,%victimName@" found out that a GOD can't get viruses the hard way!");
	}
	%ridx = %special;
	if(%special == "")
		%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	if(%killerId == "Server") {	
		%obitMsg = sprintf($deathMsg[$ServerDamageType,%ridx],$Server::SIName,%victimName,"it's", %playerGender,"it", %playerGender2,"it", %playerGender3);
		messageAll(0, %obitMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.score--;
		Game::refreshClientScore(%playerId);
	}
	else if(%killerId == %playerId) {
		%oopsMsg = sprintf($SuicideMsg[-2,%ridx], %victimName, %playerGender, %playerGender2, %playerGender3);
		if(%damageType == $MGBurnDamageType)
			%oopsMsg = sprintf($SuicideMsg[$MGBurnDamageType,%ridx], %victimName, %playerGender, %playerGender2, %playerGender3);
		else if(%damageType == $KamiKazeKDamageType) {
			if(%playerId.SuicideVictims == 0)
				%oopsMsg = sprintf($SuicideMsg[$KamiKazeSDamageType,%ridx], %victimName, %playerGender, %playerGender2, %playerGender3);
			if(%playerId.SuicideVictims > 0) {
				if(%playerId.SuicideVictims != 1)
					%s = "s";
				%oopsMsg = %victimName@" Detonated "@%playerGender@" Suicide Pack on "@%playerId.SuicideVictims@" victim"@%s@".";
			}
			%playerId.SuicideVictims = "";
		}
		messageAll(0, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.score--;
		Game::refreshClientScore(%playerId);
	}
	else if(!%killerId) {
		%unknownMsg = sprintf($deathMsg[$Unknown],%victimName);
		if(%damageType == $NukeDamageType)
			%unknownMsg = sprintf($deathMsg[$NukeRad],%victimName);
		messageAll(0,%unknownMsg,$DeathMessageMask);
		%playerId.scoreDeaths++;
	}
	else {
		if(!String::ICompare(Client::getGender(%killerId), "Male")) {
			%killerGender  = "his";
			%killerGender2 = "he";
			%killerGender3 = "him";
		}
		else {
			%killerGender  = "her";
			%killerGender2 = "she";
			%killerGender3 = "her";
		}
		if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId))) {
			if(%damageType != $MineDamageType) 
				messageAll(0, strcat(%killerName," mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else 
				messageAll(0, strcat(%killerName," killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
			%killerId.scoreDeaths++;
			%killerId.score--;
			Game::refreshClientScore(%killerId);
		}
		else {
			//----------------- Kill Msg -----------------//
			%obitMsg = sprintf($deathMsg[%damageType, %ridx],%killerName, %victimName, %killerGender, %playerGender, %killerGender2, %playerGender2, %killerGender3, %playerGender3);
			messageAll(0, %obitMsg, $DeathMessageMask);
			if(%killerId.Owner != "" && %killerId.Owner != 0) {
				%killerId.Owner.scoreKills++;
				%killerId.Owner.score++;
				Game::refreshClientScore(%killerId.Owner);
			} else {
				%killerId.scoreKills++;
				//%killerId.killed.%playerId++;
				%killerId.score++;
				Game::refreshClientScore(%killerId);
			}
			%playerId.scoreDeaths++;  // test play mode
			Game::refreshClientScore(%playerId);
		}
	}
	Game::clientKilled(%playerId, %killerId);
	CheckScoreRecord(%killerId);
}

function Game::clientKilled(%playerId,%killerId)
{
	//
}

function Client::leaveGame(%clientId)
{
   // do nothing
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

