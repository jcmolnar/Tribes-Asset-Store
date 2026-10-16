exec("comchat.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//PORT-OFF: $modList = "+Hybrid+ ‡2K4‡";  $modList is the search path input on 1.50 (guide 6.6)
$MODinfo = "<f3>-= <F1>+Hybrid+ ‡2K4‡ <f3>=-\n-= <f1>Modification By: <f2>+]-[+Armageddon+ <f3>=-\n-=<f2>Running <f1>Xcalibur<f2> Admin System<F3>=-\n-= <f1>© <F3>+]<F2>Hybrid Development Team<F3>[+ <F1>© 1998-2004 <f3>=-\n-= <f1>Mod News At: <f2>www.TeamHybrid.Org <f3>=-";

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
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
//         $secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

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
$ItemRespawnTime = 3;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 50000;
$RemoteInvEnergy = 40000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that
//                                  energy level is low when it reaches x amount
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;            //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 6;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 25;    //Define Max Length of the area
$TurretBoxMaxWidth =  25;    //Define Max Width of the area
$TurretBoxMaxHeight = 15;    //Define Max Height of the area

$TurretBoxMinLength = 6;     //Define Min Length from another turret
$TurretBoxMinWidth =  6;     //Define Min Width from another turret
$TurretBoxMinHeight = 6;     //Define Min Height from another turret

//---------------------------------------------------------------------------------
//        Object Types
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType                    = 1 << 26;
$MoveableObjectType            = 1 << 22;
$VehicleObjectType                  = 1 << 29;
$StaticObjectType                         = 1 << 23;
$ItemObjectType                         = 1 << 21;

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
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
$deathMsg[$BlazterDamageType, 0]     = "%2 gets a blaZt out of %1.";
$deathMsg[$BlazterDamageType, 1]     = "%2 succumbs to %1's rain of blaZter fire.";
$deathMsg[$BlazterDamageType, 2]     = "%1's puny blaZter shows %2 a new world of pain.";
$deathMsg[$BlazterDamageType, 3]     = "%2 meets %1's blaZter head on.";

$deathMsg[$ShrapnelDamageType, 0]     = "%2 gets a face full of flak from %1.";
$deathMsg[$ShrapnelDamageType, 1]     = "%1 ripped %2 apart with flak.";
$deathMsg[$ShrapnelDamageType, 2]     = "%1's Claymore devoured %2.";
$deathMsg[$ShrapnelDamageType, 3]     = "%2 met %1's flak up close and personal.";

$deathMsg[$RipperBulletDamageType, 0]      = "%1 ventilates %2 with %3 Ripper Chaingun.";
$deathMsg[$RipperBulletDamageType, 1]      = "%1 gives %2 an overdose of Ripper lead.";
$deathMsg[$RipperBulletDamageType, 2]      = "%1 Rips %2 limb from limb with %3 Ripper Chaingun.";
$deathMsg[$RipperBulletDamageType, 3]      = "%1 Rips down %2.";

$deathMsg[$PlasmaCannonDamageType, 0]      = "%2 feels the white glow of %1's plasma.";
$deathMsg[$PlasmaCannonDamageType, 1]      = "%1 gives %2 a plasma enima.";
$deathMsg[$PlasmaCannonDamageType, 2]      = "%1 asks %2 'Hot Enough For Ya?'";
$deathMsg[$PlasmaCannonDamageType, 3]      = "%1 punishes %2 with a Plasma Cannon blast.";

$deathMsg[$LandingDamageType, 0]     = "%2's Feet now set right under %4 chin.";
$deathMsg[$LandingDamageType, 1]     = "%2 Died by hitting the ground, Please laugh at %4 stupid noobie ass.";
$deathMsg[$LandingDamageType, 2]     = "%2 Eats a big slice of earth.";
$deathMsg[$LandingDamageType, 3]     = "%2 fall down go SPLAT TaT TaT TaT.";

$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";

$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";

$deathMsg[$StormHammerDamageType, 0]   = "%2 ended up on the bussiness end of %1's Dual StormHammer.";
$deathMsg[$StormHammerDamageType, 1]   = "%1 blows the shit out of %2 with %3 Dual StormHammer.";
$deathMsg[$StormHammerDamageType, 2]   = "%1's Dual StormHammer caught %2 off guard.";
$deathMsg[$StormHammerDamageType, 3]   = "%2 falls victim to %1's Dual Stormhammer.";

$deathMsg[$BioShrapnelDamageType, 0]    = "%1 Give %2 the Black Death.";
$deathMsg[$BioShrapnelDamageType, 1]    = "%2 gets a taste of %1's toxic waste.";
$deathMsg[$BioShrapnelDamageType, 2]    = "%1 gives %2 a fatal virus.";
$deathMsg[$BioShrapnelDamageType, 3]    = "%2 never saw the green glow coming from %1's Bio Grenade.";

$deathMsg[$LazerexDamageType, 0]       = "%1 adds %2 to %3 list of Laser victims.";
$deathMsg[$LazerexDamageType, 1]       = "%1 fells %2 with a Laser shot.";
$deathMsg[$LazerexDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LazerexDamageType, 3]       = "%2 stayed in %1's Laser crosshair for too long.";

$deathMsg[$SplitMortarDamageType, 0]      = "%1's Split Mortars pound %2 into oblivion.";
$deathMsg[$SplitMortarDamageType, 1]      = "%2 didn't see thoes 3 Split Mortar from %1.";
$deathMsg[$SplitMortarDamageType, 2]      = "%1 inflicts multiple Split Mortar wounds on %2.";
$deathMsg[$SplitMortarDamageType, 3]      = "%1's Mortars takes out %2.";

$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's Electron Flux Cannon.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt with %3 Electron Flux Cannon.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1's Electron Flux Cannon.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems Via Electron Flux Cannon.";

$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";

$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";

$deathMsg[$MissileDamageType, 0]	    = "%2 Takes %1's WarHead up his faggity ass.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down by %1's Rocket.";
$deathMsg[$MissileDamageType, 2]	    = "%2 gets real friendly with %1's rocket.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from %1's warhead.";

$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";

$deathMsg[$FusionDamageType, 0] = "%1 mows down %2 with his Fusion Cannon.";
$deathMsg[$FusionDamageType, 1] = "%2 gets a blast of fusion from %1.";
$deathMsg[$FusionDamageType, 2] = "%1 sends a ball of fusion in %2's direction.";
$deathMsg[$FusionDamageType, 3] = "%2 sees a blinding flash from %1's Fusion Cannon.";

$deathMsg[$TimeBombDamageType, 0] = "%1 blows %2 away with a Time Bomb.";
$deathMsg[$TimeBombDamageType, 1] = "%2 finds out why %1's TimeBomb is so lethal.";
$deathMsg[$TimeBombDamageType, 2] = "%1 gives %2 a Sparkly TimeBomb to hold..";
$deathMsg[$TimeBombDamageType, 3] = "%2 gets vaporized by %1's TimeBomb.";

$deathMsg[$FuzionDamageType, 0] = "%1 blasts %2 with his Fusion Blast.";
$deathMsg[$FuzionDamageType, 1] = "%2 is killed by %1's Fusion Blast.";
$deathMsg[$FuzionDamageType, 2] = "%1 uses his Fusion Blast on %2.";
$deathMsg[$FuzionDamageType, 3] = "%2 is mown down by Fusion bolts from %1.";

$deathMsg[$HavocDamageType, 0] = "%1 snipes %2 with %3 HaVoC Rifle.";
$deathMsg[$HavocDamageType, 1] = "%1 puts a bullet in %2's head with %3 HaVoC rifle.";
$deathMsg[$HavocDamageType, 2] = "%2 gets sniped by %1's mad sniper skills.";
$deathMsg[$HavocDamageType, 3] = "%2 got a HaVoC bullet in %4 head from %1.";

$deathMsg[$ShardDamageType, 0] = "%1 Guns down %2 with %3 Shard Gun.";
$deathMsg[$ShardDamageType, 1] = "%2 gets filled with bullets from %1's Shard Gun.";
$deathMsg[$ShardDamageType, 2] = "%1 empties a box of ammo into %2 with %3 Shard Gun.";
$deathMsg[$ShardDamageType, 3] = "%2 looks down the barrels of %1's Shard Gun.";

$deathMsg[$GlockDamageType, 0] = "%1 puts a High Cal. Bullet in %2's face with %3 Glock-9.";
$deathMsg[$GlockDamageType, 1] = "%1 kills %2 with his High Cal. Shot from a Glock-9.";
$deathMsg[$GlockDamageType, 2] = "%2 gets killed by %1's Glock-9 Pistal.";
$deathMsg[$GlockDamageType, 3] = "%2 gets blown away by %1's Glock-9.";

$deathMsg[$EWebDamageType, 0] = "%2 Got sucked dry by an Electric Web.";
$deathMsg[$EWebDamageType, 1] = "%2 Got sucked dry by an Electric Web.";
$deathMsg[$EWebDamageType, 2] = "%2 Got sucked dry by an Electric Web.";
$deathMsg[$EWebDamageType, 3] = "%2 Got sucked dry by an Electric Web.";

$deathMsg[$ARPGDamageType, 0] = "%2 gets in the way of %1's ARPG.";
$deathMsg[$ARPGDamageType, 1] = "%1 mows down %2 with his ARPG.";
$deathMsg[$ARPGDamageType, 2] = "%1 rips through %2's armor with his ARPG.";
$deathMsg[$ARPGDamageType, 3] = "%2 didn't quite dodge %1's ARPG Fire.";

$deathMsg[$StealthDamageType, 0] = "%1 vaporizes %2 with %3 Semi-Automatic Stealth.";
$deathMsg[$StealthDamageType, 1] = "%2's face got in the way of %1's Semi-Automatic Stealth.";
$deathMsg[$StealthDamageType, 2] = "%2 got %4 right eye shot by %1's Semi-Automatic Stealth.";
$deathMsg[$StealthDamageType, 3] = "%1 mows down %2 with his Semi-Automatic Stealth.";

$deathMsg[$MultiDamageType, 0] = "%1 melts %2's face off with %3 Multi Cannon Blast.";
$deathMsg[$MultiDamageType, 1] = "%1 mows down %2 with his Multi Cannon.";
$deathMsg[$MultiDamageType, 2] = "%2 gets hit in the ear with %1's Multi Cannon.";
$deathMsg[$MultiDamageType, 3] = "%2 gets in the way of %1's charged Multi Cannon.";

$deathMsg[$WTShotgunDamageType, 0] = "%1 mows down %2 with %3 WT.";
$deathMsg[$WTShotgunDamageType, 1] = "%2 gets shot in the stomach from %1's WT.";
$deathMsg[$WTShotgunDamageType, 2] = "%1 pumps ammo into %2 with %3 WT.";
$deathMsg[$WTShotgunDamageType, 3] = "%1 fills %2 with holes with %3 WT.";

$deathMsg[$AnarchyCannonDamageType, 0] = "%2 is shot down with an Anarchy shell from %1.";
$deathMsg[$AnarchyCannonDamageType, 1] = "%1's Anarchy shell finds %2's face.";
$deathMsg[$AnarchyCannonDamageType, 2] = "%1 mows down %2 with %3 Anarchy Cannon.";
$deathMsg[$AnarchyCannonDamageType, 3] = "%1 hits %2 with %3 Anarchy Cannon.";

$deathMsg[$PlasGatDamageType, 0] = "%1 mows down %2 with %3 Plasma Gat Fire.";
$deathMsg[$PlasGatDamageType, 1] = "%2 is fried to a crisp by %1's Plasma Gat.";
$deathMsg[$PlasGatDamageType, 2] = "%1 melts %2 with %3 Plasma Gat.";
$deathMsg[$PlasGatDamageType, 3] = "%1 kills %2 SyKo style with %3 Plasma Gat.";

$deathMsg[$ParticalShotgunDamageType, 0] = "%1 shoots %2 in the face with %3 Partical Shotgun.";
$deathMsg[$ParticalShotgunDamageType, 1] = "%1 mows down %2 with %3 Partical Shotgun.";
$deathMsg[$ParticalShotgunDamageType, 2] = "%2 gets shot in the right eye by %1's Partical Shotgun.";
$deathMsg[$ParticalShotgunDamageType, 3] = "%2 gets Fucked by %1's Partical Shotgun.";

$deathMsg[$HellStormDamageType, 0] = "%1 shoots down %2 with %3 Hell Storm.";
$deathMsg[$HellStormDamageType, 1] = "%1 mows down %2 with %3 Hell Storm.";
$deathMsg[$HellStormDamageType, 2] = "%2 gets shot in the left eye by %1's Hell Storm.";
$deathMsg[$HellStormDamageType, 3] = "%2 gets massacred by %1's Hell Storm.";

$deathMsg[$EMPDamageType, 0] = "%1 turns %2's brain into jello.";
$deathMsg[$EMPDamageType, 1] = "%2 was frazzled to death by %1."; 
$deathMsg[$EMPDamageType, 2] = "%2 was short circuited by %1."; 
$deathMsg[$EMPDamageType, 3] = "%2 was killed by %1's EMP blast.";

$deathMsg[$AtomicDamageType, 0] = "%1 demolishes %2 with %3 Atomic Bomb.";
$deathMsg[$AtomicDamageType, 1] = "%1 hands %2 a ticking Atomic Bomb.";
$deathMsg[$AtomicDamageType, 2] = "%2 gets his ass worked by an Atomic Bomb from %1.";
$deathMsg[$AtomicDamageType, 3] = "%2 walks into %1's Atomic Bomb Blast Zone."; 

$deathMsg[$RadiationDamageType, 0] = "%1 makes %2 glow from %3 Radiation Laser.";
$deathMsg[$RadiationDamageType, 1] = "%1 made %2 into a pile of vile goo.";
$deathMsg[$RadiationDamageType, 2] = "%2 can now glow in the dark thanks to %1's shot of Radiation.";
$deathMsg[$RadiationDamageType, 3] = "%2 will never need another night light thanks to %1's Radiation Laser.";

$deathMsg[$DiscoDamageType, 0] = "%1 showed %2 how to do the death boogie.";
$deathMsg[$DiscoDamageType, 1] = "%1 made %2 do the Dico Shuffle straight to the ground.";
$deathMsg[$DiscoDamageType, 2] = "%2 thought %1 wanted to dance not fight.";
$deathMsg[$DiscoDamageType, 3] = "%2 is dead just like disco thanks to %1's Dico Laser"; 

$deathMsg[$LazerGatDamageType, 0] = "%1 sliced %2 in half with %3 Lazer Gat.";
$deathMsg[$LazerGatDamageType, 1] = "%1 made %2 into mince meat with %3 Lazer Gat.";
$deathMsg[$LazerGatDamageType, 2] = "%2 should have ran at the first glimps of %1 Lazer Gat.";
$deathMsg[$LazerGatDamageType, 3] = "%2 got the shit cut out of %4 Via %1's Lazer Gat";

$deathMsg[$GrazerDamageType, 0] = "%1 exterminated %2 with %3 Grazer Cannon.";
$deathMsg[$GrazerDamageType, 1] = "%1 dropped %2 like a sack of shit thanks to the Grazer cannon.";
$deathMsg[$GrazerDamageType, 2] = "%2 stood 3.5 seconds too still and %1 nailed him with a Grazer Beam.";
$deathMsg[$GrazerDamageType, 3] = "%2 recived a Grazer Beam right between the eye from %1."; 

$deathMsg[$HybridLaserDamageType, 0] = "%1 with %3 Hybrid Laser showed %2 that heavies can snipe.";
$deathMsg[$HybridLaserDamageType, 1] = "%1 burned a hole in %2's forehead with %3 Hybrid Laser.";
$deathMsg[$HybridLaserDamageType, 2] = "%2 felt a burning sensation in his chest (It ain't Heart Burn Pal It's A Hybrid Laser!).";
$deathMsg[$HybridLaserDamageType, 3] = "%2 got picked outta the sky with %1's Hybrid Laser."; 

$deathMsg[$QuakeDamageType, 0] = "%1 blasted %2 with a Quake Blaster.";
$deathMsg[$QuakeDamageType, 1] = "%1 made %2 fly like a bird with one shot of %3 Quake blaster.";
$deathMsg[$QuakeDamageType, 2] = "%2 felt the ground shake and his ass break after %1 hit %4 with a Quake Shot.";
$deathMsg[$QuakeDamageType, 3] = "%2 hit the ground with too much force thanks to %1's Quake Shot."; 

$deathMsg[$SXHDamageType, 0] = "%1 made a few new holes in %2 with %3 SXH-5000.";
$deathMsg[$SXHDamageType, 1] = "%1 and a Semi-Automatic SXH-5000 made %2 into a target dummy.";
$deathMsg[$SXHDamageType, 2] = "%2 should have ran after seeing the glow of %1's SXH-5000 laser sight.";
$deathMsg[$SXHDamageType, 3] = "%2 got mowed down from a hail of %1's SXH-5000 bullets.";

$deathMsg[$HybridRailDamageType, 0] = "%1's Hybrid Rail nailed %2 to the wall.";
$deathMsg[$HybridRailDamageType, 1] = "%1's combination of bullet and energy made %2's death an easy one.";
$deathMsg[$HybridRailDamageType, 2] = "%2 felt %1's Hybrid Rail pass through %4.";
$deathMsg[$HybridRailDamageType, 3] = "%2 thought %4 got hit with a mortar, but it was only %1's Hybrid Rail.";

$deathMsg[$MiniGunDamageType, 0] = "%1's MiniGun made %2 look like a pair of %3 old holy underware.";
$deathMsg[$MiniGunDamageType, 1] = "%1 and his faythfull MiniGun tore %2 to shit and back.";
$deathMsg[$MiniGunDamageType, 2] = "%2 became Holy thanks to %1's MiniGun.";
$deathMsg[$MiniGunDamageType, 3] = "%2's armor looks like fish net stockings due to %1's MiniGun Assault.";

$deathMsg[$DFMIYADamageType, 0] = "%1's D.F.M.I.Y.A demolishes %2.";
$deathMsg[$DFMIYADamageType, 1] = "%1 sent a swarm of D.F.M.I.Y.A. Missiles into %2's asshole.";
$deathMsg[$DFMIYADamageType, 2] = "%2 finally knows what D.F.M.I.Y.A stands for.";
$deathMsg[$DFMIYADamageType, 3] = "%2's body was ripped to pieces then blown-up by %1's D.F.M.I.Y.A.";

$deathMsg[$DestroyerDamageType, 0] = "%1's Destroyer ChainGun Destroyed %2.";
$deathMsg[$DestroyerDamageType, 1] = "%1 had his finger white knuckle tight on %3 Destroyer Chaingun until %2's lifeless body hit the ground.";
$deathMsg[$DestroyerDamageType, 2] = "%2 got destroyed by %1's Destroyer ChainGun.";
$deathMsg[$DestroyerDamageType, 3] = "%2's head was cut off by %1's Destroyer ChainGun.";

$deathMsg[$HybridChainDamageType, 0] = "%1 unloaded all %3 Hybrid Chaingun Ammo into %2.";
$deathMsg[$HybridChainDamageType, 1] = "%1's Hybrid Chaingun made %2 into Swiss Cheese.";
$deathMsg[$HybridChainDamageType, 2] = "%2 could not out run %1's Hybrid Chaingun Quad Fire.";
$deathMsg[$HybridChainDamageType, 3] = "%2 was beaten to a pulp by %1's Hybrid Chaingun.";

$deathMsg[$PlasmaBlasterDamageType, 0] = "%1 unleased a storm of Plasma Blaster Bolts upon %2's ass.";
$deathMsg[$PlasmaBlasterDamageType, 1] = "%1 made %2 into a Smores.";
$deathMsg[$PlasmaBlasterDamageType, 2] = "%2 was unaware that %1 had %3 Plasma Blaster up %4 ass.";
$deathMsg[$PlasmaBlasterDamageType, 3] = "%2 was given a white hot plasma probe by %1.";

$deathMsg[$BlazeDamageType, 0] = "%1 says to %2 ''Come on baby light my fire''.";
$deathMsg[$BlazeDamageType, 1] = "%1 made %2 into a pile of ash";
$deathMsg[$BlazeDamageType, 2] = "%2 was set a Blaze by %1.";
$deathMsg[$BlazeDamageType, 3] = "%2 smelled something burning, it was %3.";

$deathMsg[$MeltLaserDamageType, 0] = "%1 tells %2 ''You should try moving''.";
$deathMsg[$MeltLaserDamageType, 1] = "%1 made %2 burn to %3 death.";
$deathMsg[$MeltLaserDamageType, 2] = "%2 was picked from the sky by %1's Melt Laser.";
$deathMsg[$MeltLaserDamageType, 3] = "%2 felt a burning sensation in %3 chest, it was %1's Melt Beam.";

$deathMsg[$NapalmLDamageType, 0] = "%1 made %2 feel the burn, from his Napalm that is.";
$deathMsg[$NapalmLDamageType, 1] = "%1 gave %2 a buncha Napalm.";
$deathMsg[$NapalmLDamageType, 2] = "%2 knows that Napalm Death is not only a band but %3 fate aswell.";
$deathMsg[$NapalmLDamageType, 3] = "%2 got covered in gooey Napalm by %1.";

$deathMsg[$NapalmRDamageType, 0] = "%1 blew the shit out of %2 with a Napalm Rocket.";
$deathMsg[$NapalmRDamageType, 1] = "%1 stopped %2 dead in %3 track with a Naplam Rocket.";
$deathMsg[$NapalmRDamageType, 2] = "%2 was blown to bits and burn to ash by %1's Napalm Rocket.";
$deathMsg[$NapalmRDamageType, 3] = "%2 got covered in gooey Napalm by %1.";

$deathMsg[$MagmaDamageType, 0] = "%1's Magma Cannon made %2 into a human fire ball.";
$deathMsg[$MagmaDamageType, 1] = "%1 gave %2 a warm cup of Magma before bed (Death Bed).";
$deathMsg[$MagmaDamageType, 2] = "%2 could not escape the range of %1's Magma Cannon.";
$deathMsg[$MagmaDamageType, 3] = "%2 got covered in gooey Magma by %1.";

$deathMsg[$NitroDamageType, 0] = "%1's Nitro Grenader made short work of %2.";
$deathMsg[$NitroDamageType, 1] = "%1 Nitrosized %2.";
$deathMsg[$NitroDamageType, 2] = "%2 could not dodge all of %1's Nitro Naddes.";
$deathMsg[$NitroDamageType, 3] = "%2 was blown into oblivion by %1.";

$deathMsg[$FireMDamageType, 0] = "%1's Fire Mortar incinerated %2.";
$deathMsg[$FireMDamageType, 1] = "%1 made %2 feel a Heat Wave.";
$deathMsg[$FireMDamageType, 2] = "%2 caught %1's Fire Mortar right in the chest.";
$deathMsg[$FireMDamageType, 3] = "%2 is now ash thanks to %1's Fire Mortar.";

$deathMsg[$ContactMDamageType, 0] = "%1's Contact mortar nailed %2.";
$deathMsg[$ContactMDamageType, 1] = "%1 lobbed a Contact Shell at %2, your reading this so you know the outcome.";
$deathMsg[$ContactMDamageType, 2] = "%2 caught %1's Contact Mortar.";
$deathMsg[$ContactMDamageType, 3] = "%2 is no longer with us due to an unfortunate mishapp with %1's Contact Mortar.";

$deathMsg[$RaidDamageType, 0] = "%1 released a net of AirRaid Shells upon %2.";
$deathMsg[$RaidDamageType, 1] = "%1's AirRaid made %2 wish for a single mortar wound.";
$deathMsg[$RaidDamageType, 2] = "%2 was caught in an AirRaid Called by %1.";
$deathMsg[$RaidDamageType, 3] = "%2 could not bob and weave through %1's AirRaid.";

$deathMsg[$ClashDamageType, 0] = "%1 busted %2 up with a Clash Missile.";
$deathMsg[$ClashDamageType, 1] = "%1's Clash Missile sent %2 to the grave.";
$deathMsg[$ClashDamageType, 2] = "%2 got fucked by %1's Clash Missile.";
$deathMsg[$ClashDamageType, 3] = "%2 took a Clash Missile in the keyster.";

$deathMsg[$HybridMortarDamageType, 0] = "%1 fucked %2 up with a Hybrid Mortar.";
$deathMsg[$HybridMortarDamageType, 1] = "%1's Hybrid Mortar showed %2 the correct way to serve an ass beating.";
$deathMsg[$HybridMortarDamageType, 2] = "%2 got pulverized by %1's Hybrid Mortar.";
$deathMsg[$HybridMortarDamageType, 3] = "%2 ate %1's Hybrid Mortar.";

$deathMsg[$HybridCannonDamageType, 0] = "%1 asked %2 to hold %3 payload.";
$deathMsg[$HybridCannonDamageType, 1] = "%1 blasted %2 with Hybrid Cannon Flak.";
$deathMsg[$HybridCannonDamageType, 2] = "%2 could not escape the wide spread mayhem of %1's Hybrid Cannon.";
$deathMsg[$HybridCannonDamageType, 3] = "%2 says: Hey %1 can ya hit me again and this time put some STANK on it!.";

$deathMsg[$HybridMissileDamageType, 0] = "%1 knocked %2 around with %3 Hybrid dual Rockets.";
$deathMsg[$HybridMissileDamageType, 1] = "%1 busted %2 up with %3 Hybrid Rockets.";
$deathMsg[$HybridMissileDamageType, 2] = "%2 wasn't fast enough to out run both Hybrid Rockets.";
$deathMsg[$HybridMissileDamageType, 3] = "%2 felt the pain that %1 delivered from %3 Hybrid Rockets.";

$deathMsg[$HybridRPGDamageType, 0] = "%1 asked %2 if it felt as bad as it looked when  thoes 4 RPGs hit.";
$deathMsg[$HybridRPGDamageType, 1] = "%1 annihilated %2 with 4 Hybrid RPGs.";
$deathMsg[$HybridRPGDamageType, 2] = "%2 caught all 4 Hybrid RPGs delivered by %1.";
$deathMsg[$HybridRPGDamageType, 3] = "%2 couldn't belive the power in %1's Hybrid RPGs.";

$deathMsg[$SalvoDamageType, 0] = "%1 asked %2 to hold %3 payload.";
$deathMsg[$SalvoDamageType, 1] = "%1 clobbered %2.";
$deathMsg[$SalvoDamageType, 2] = "%2 caught all 3 Salvo Rockets.";
$deathMsg[$SalvoDamageType, 3] = "%2 felt the burn of incindiary warheads.";

$deathMsg[$ETTRDamageType, 0] = "%1 turns %2's brain into jello.";
$deathMsg[$ETTRDamageType, 1] = "%2 was frazzled to death by %1."; 
$deathMsg[$ETTRDamageType, 2] = "%2 was short circuited by %1."; 
$deathMsg[$ETTRDamageType, 3] = "%2 was killed by %1's ETTR blast.";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]			  = "%1 shoots %2 Fucking junk off.";
$deathMsg[-2,1]			  = "%1 gets Knocked the fuck out like a chump.";
$deathMsg[-2,2]			  = "%1 fall down go....uuummmm Splat TaT TaT TaT.";
$deathMsg[-2,3]                   = "%1 gets a face full of the ol fucked pie.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Plasmagun;
$spawnBuyList[4] = GrenadeLauncher;
$spawnBuyList[5] = Mortar;
$spawnBuyList[6] = DiscLauncher;
$spawnBuyList[7] = LaserRifle;
$spawnBuyList[8] = Charger;
$spawnBuyList[9] = ClashRocket;
$spawnBuyList[10] = RepairKit;
$spawnBuyList[11] = EnergyPack;
$spawnBuyList[12] = Beacon;
$spawnBuyList[13] = MineAmmo;
$spawnBuyList[14] = Grenade;


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
	
	%Arm = (%time % 220);
		if (%Arm > 55 && %Arm <65) {
		messageAll(1, "+Hybrid+ ‡2K4‡ By: +]-[DT+");		
		}
		if (%Arm > 15 && %Arm <25) {
		messageAll(1, "www.TeamHybrid.Org For More Info.");
		}

	//echo("check: time= "@%time@", Arm= "@%Arm);
	

   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);

	
}

function Game::notifyMatchStart(%time)
{
   messageAll(3, "+Destruction In " @ %time @ " Seconds+~wLeftMissionArea.wav");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   exec(GenoServ);
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(1, "+The Battle Rages On+~wmine_act.wav");
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
   if(!$ghosting)
      return false;
Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	%clientId.tied = false;
	Client::clearItemShopping(%clientId);
	if(%clientId.penis)
	{	
		%rnd = floor(getRandom() * 30);	
		%random = (%rnd + 10);
		schedule("penis(" @ %clientId @ ");", %random);
	}
echo(%clientId);


   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);

	if(%spawnMarker) {   
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

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "larmor";
	   else
	      %armor = "lfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: "@Client::getName(%clientId)@" cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);

//----------------=Anti-SpawnKill

$Server::respawnInvulnerableTime = 10;
	   if(%respawn)$Server::respawnInvulnerableTime = 5;
         if($Server::respawnInvulnerableTime)
         {
		GameBase::startFadeout(%pl); 
            %damage = %armor.maxDamage - 0.001;
            GameBase::setEnergy(%pl, 0);
            GameBase::setDamageLevel(%pl, %damage);
            GameBase::setAutoRepairRate(%pl, %damage / $Server::respawnInvulnerableTime);
            %pl.invulnerable = true;
            for(%i=0; %i < 6.28; %i += 1.256) {
			%trans = Vector::add(getBoxCenter(%pl), Vector::getFromRot("0 0 " @ %i, 1.3, 1.2));
			Projectile::spawnProjectile("Invul", "0 0 1 0 0 0 0 0 1 " @ %trans, %pl, "0 0 -1.5");
		}
            schedule("incInvulnerable(" @ %pl @ ", 0);", 0, %pl);
		      %weapon = Player::getMountedItem(%pl,$WeaponSlot);
		      if(%weapon != -1) {
			      %pl.lastWeapon = %weapon;
			      Player::unMountItem(%pl,$WeaponSlot);
		      }
         }
// ================================================
	   if(!%respawn)
   {
      // initial drop

      bottomprint(%clientId, "<jc>Welcome to <f2>+Hybrid+ ‡2K4‡<f3> By <f2>+]-[DT+ (Hybrid Development Team) \nE-mail: ArmageddonHatesU@Aol.Com\nWebSite: www.TeamHybrid.Org\n<f0>Mission: <f1>" @ $missionName @ " <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.",15);

   }

      	      
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry, not enough respawn markers in map. Try again in a sec.");
      return false;
	}
}
//== another new function

function incInvulnerable(%player, %time)
{
   if(%time > $Server::respawnInvulnerableTime)
   {
      %player.invulnerable = "";
      GameBase::setAutoRepairRate(%player, 0);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	   if(%player.lastWeapon != "" && %weapon == -1) {
		   Player::useItem(%player,%player.lastWeapon);
		   %player.lastWeapon = "";
	    }
	GameBase::startFadein(%player); 
   }
   else
   { 
      schedule("incInvulnerable(" @ %player @ ", "@ %time + 0.5 @ ");", 0.5, %player);
   }
}




function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	%clientId.spawn= 1;
	%max = getNumItems();
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon="";
	}
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

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

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
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";
   }
   else 
   {
      Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
//=============================================================================================
  

//=============================================================================================
         centerprint(%clientId, "<jc><f3>Welcome <f2>" @ Client::getName(%clientId) @ "<f3> This Is The Long Awaited Update To +Hybrid+ Version 2K3... Prepare Yourself.", 0);
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
         Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
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
   $menuMode[%playerId] = "None";
   //=================================
   %playerId.scoreTKs = 0;
   //=================================
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

function Client::onKilled(%playerId, %killerId, %damageType)
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
      messageAll(1, strcat(%victimName, " was killed by a turret."), $DeathMessageMask);
      %playerId.scoreDeaths++;
//-------------------------------------------------------------
      Game::refreshClientScore(%playerId);
//-------------------------------------------------------------


//===============================================================================================
      bottomprint(%playerId, "<f3><jc>Stats: <f2>" @ %victimName @ " <f3>Kills: <f2>" @ %playerId.scoreKills @ " <f3>Deaths: <f2>" @ %playerId.scoreDeaths @ " <f3>TK's: <f2>" @ %playerId.scoreTKs @ " <f3>Score: <f2>" @ %playerId.score @ "  ", 5);
//===============================================================================================
	
  }
   else if(%killerId == %playerId)
   {
      %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(1, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%playerId);

       $PlayerScore = %playerId.score;
   	if(%playerId.score == "-10" && $CodeRed::LowScore == "On")
   	{
   	   	bottomprint(%playerId, "<jc> <f2>Low Score Warning - You have allowed your score to fall too low and you will be escorted out of the server.", 5);
   	   	schedule("KickDaJackal(" @ %playerId @ ");", 1, %playerId);
	}
	else if(%playerId.score == "-9" && $CodeRed::LowScore == "On")
	{
   	   	bottomprint(%playerId, "<jc><f2>Low Score Warning - If your score drops any lower, you will be booted.", 5);
	}
	else if(%playerId.score == "-1" && $CodeRed::LowScore == "On")
	{
   	   	bottomprint(%playerId, "<jc><f2>Low Score Warning - If you score continues to fall actions will be taken against you.", 5);
	}

	else
	{
//===============================================================================================

         	   	bottomprint(%killerId, "<f3><jc>Stats: <f2>" @ %victimName @ " <f3>Kills: <f2>" @ %KillerId.scoreKills @ " <f3>Deaths: <f2>" @ %killerId.scoreDeaths @ " <f3>TK's: <f2>" @ %killerId.scoreTKs @ " <f3>Score: <f2>" @ %killerId.score @ "  ", 5);


//===============================================================================================
	}
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
		if(%damageType != $MineDamageType) 
	    	messageAll(3, strcat(Client::getName(%killerId), 
   	        " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		else 
	         messageAll(3, strcat(Client::getName(%killerId), 
   	     	" killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
		 %playerId.scoreDeaths++; // did say killer Id but killer didnt die so that was gay ;-)
       %killerId.score--;
//=======================
       %killerId.scoreTKs++;
//=======================
       Game::refreshClientScore(%killerId);
//----------------------------------------------------------
       bottomprint(%killerId, "<f3><jc>Stats: <f2>" @ Client::getName(%killerId) @ " <f3>Kills: <f2>" @ %KillerId.scoreKills @ " <f3>Deaths: <f2>" @ %killerId.scoreDeaths @ " <f3>TK's: <f2>" @ %killerId.scoreTKs @ " <f3>Score: <f2>" @ %killerId.score @ "  ", 5);
//----------------------------------------------------------

//===============================================================================================
      	if(%killerId.scoreTKs == "1" && $CodeRed::AntiTK == "On")
      	{
         	   	bottomprint(%killerId, "<jc><f2>Team Kill Warning - if you continue to tk you will be booted.", 5);
      	}
      	else if(%killerId.scoreTKs == "3" && $CodeRed::AntiTK == "On")
      	{
         	   	bottomprint(%killerId, "<jc> <f2>Team Kill Warning - this is your last tk warning.", 5);
      	}
      	else if(%killerId.scoreTKs == "4" && $CodeRed::AntiTK == "On")
      	{
         	   	bottomprint(%killerId, "<jc> <f2>Team Kill Warning - you have Tk'ed over the limit and will now be escorted out of the server.", 5);
      		schedule("KickDaJackal(" @ %killerId @ ");", 1, %killerId);
      	}
      	else
      	{
         	   	bottomprint(%killerId, "<f3><jc>Stats: <f2>" @ %victimName @ " <f3>Kills: <f2>" @ %playerId.scoreKills @ " <f3>Deaths: <f2>" @ %playerId.scoreDeaths @ " <f3>TK's: <f2>" @ %playerId.scoreTKs @ " <f3>Score: <f2>" @ %playerId.score @ "  ", 5);
      	}  
//===============================================================================================
       Game::refreshClientScore(%playerId);
//===============================================================================================
      //bottomprint(%playerId, "<f3><jc> Stats: <f2>" @ %victimName @ " <f3>Kills: <f2>" @ %playerId.scoreKills @ " <f3>Deaths: <f2>" @ %playerId.scoreDeaths @ " <f3>TK's: <f2>" @ %playerId.scoreTKs @ " <f3>Score: <f2>" @ %playerId.score @ "  ", 5);
//===============================================================================================
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
         %killerId.score++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);

//===============================================================================================
      bottomprint(%playerId, "<f3><jc> +]Stats[+: <f2>" @ %victimName @ " <f3>+]Kills[+: <f2>" @ %playerId.scoreKills @ " <f3>+]Deaths[+: <f2>" @ %playerId.scoreDeaths @ " <f3>+]TK's[+: <f2>" @ %playerId.scoreTKs @ " <f3>+]Score[+: <f2>" @ %playerId.score @ "  ", 5);
//===============================================================================================
      }
   }
   Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
   // do nothing
}

function Client::leaveGame(%clientId)
{
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   %ip = Client::getTransportAddress(%clientId);
   %player = String::getSubStr(%ip, 3, 2);
   //exec(Player @ %player);
   //PORT-OFF: $PlayerName = $PCFG::Name;
   //PORT-OFF: export("PlayerName", "config\\Player" @ %player @ ".cs", False);
   //PORT-OFF: $PlayerName = "";
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   // do nothing
}

function Player::enterMissionArea(%player)
{
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have Re-entered the mission area, Good now stay here.");
}

function Player::leaveMissionArea(%player)
{
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have left the mission area, Prepare to die!!!.");
	%player.outArea=1;
	alertPlayer(%player, 3);
}

//checking for timeout of dieSeqCount
function Player::checkLMATimeout(%player, %seqCount)
{
   echo("checking player timeout " @ %player @ " " @ %seqCount);
   if(%player.dieSeqCount == %seqCount)
      remoteKill(Player::getClient(%player));
}

//called if player leaves mission area
function Player::enterMissionArea(%player)
{
   %player.outArea="";
   %player.dieSeqCount = 0;
   %player.timeLeft = %player.timeLeft - (getSimTime() - %player.leaveTime);
}
  
function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count > 1)
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%clientId);
		else 
	   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}

function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1) {
		if(!Player::isDead(%player)) {
		  	Player::setDamageFlash(%client,0.1);
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.5);
	   	schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
		}
		else { 
			playNextAnim(%client);	
			Client::onKilled(%client, %client);
		}
	}
}




function GameBase::getHeatFactor(%this)
{
   return 0.0;
}
