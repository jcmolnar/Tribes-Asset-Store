exec("comchat.cs");
$ModVersion = "v2.2";
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

// TALON RULES NOTE - This following variable sets if TK handling is to be used. 0 = no, 1 = yes.
// It's so cool I don't know why you'd turn it off though.
$THTKHandling = 1;

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
$WaitThrowTime = 1;

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
$RemoteAmmoEnergy = 9000; 
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
// TELEPORTER PACK : -=Talon Hawk=-
//---------------------------------------------------------------------------------
$TeleBoxMinLength = 60;	  //Define Min Length from another Teleporter
$TeleBoxMinWidth =  60;	  //Define Min Width from another Teleporter
$TeleBoxMinHeight = 60;	   //Define Min Height from another Teleporter

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	 = 1 << 29;  
$StaticObjectType			 = 1 << 23;	   
$ItemObjectType			 = 1 << 21;	  

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
$deathMsg[$LandingDamageType, 0]      = "%1 falls to %2 death.";
$deathMsg[$LandingDamageType, 1]      = "%1 forgot to tie %2 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%1 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%1 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";
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
$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0]     = "%2 has %4 flesh burned off by %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of plasma fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1 burns up %2 with a Plasma Pistol.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's Plasma Pistol.";
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
// My death messages: -=TalonHawk=-
$deathMsg[$APShellDamageType, 0]	= "%1 nailed %2 down with %3 Assault Rifle.";
$deathMsg[$APShellDamageType, 1]	= "%2 gets filled full of explosive shells by %1.";
$deathMsg[$APShellDamageType, 2]	= "%1 took out %2 with %3 AR-900.";
$deathMsg[$APShellDamageType, 3]	= "%2 gets blown to hell by %1.";
$deathMsg[$SniperDamageType, 0]	= "%1 brings %2 down with %3 SR-100.";
$deathMsg[$SniperDamageType, 1]	= "%1 punches a nice little hole in %2's armor.";
$deathMsg[$SniperDamageType, 2]	= "%2 becomes a victim of %1's SR-100.";
$deathMsg[$SniperDamageType, 3]	= "%2 stayed in %1's SR-100 scope to long.";
$deathMsg[$NukeDamageType, 0]		= "%1 vaporizes %2 with a nuke.";
$deathMsg[$NukeDamageType, 1]		= "%1 shows %2 what fission power is good for.";
$deathMsg[$NukeDamageType, 2]		= "%2 is disintegrated by %1's nuke.";
$deathMsg[$NukeDamageType, 3]		= "%1 blew %2 into oblivion.";
$deathMsg[$PMissileDamageType, 0]	= "%2 takes a missile up the keister from %1.";
$deathMsg[$PMissileDamageType, 1]	= "%2 gets shot down by %1.";
$deathMsg[$PMissileDamageType, 2]	= "%2 gets real friendly with a rocket from %1.";
$deathMsg[$PMissileDamageType, 3]	= "%2 feels the burn from a warhead from %1.";
$deathMsg[$IonDamageType, 0]		= "%1 desintigrates %2 with an energy burst.";
$deathMsg[$IonDamageType, 1]		= "%2 gets vaporized by %1.";
$deathMsg[$IonDamageType, 2]		= "%2 is vaporized by a stream of energy from %1.";
$deathMsg[$IonDamageType, 3]		= "%2 feels the pain of %1's energy needles.";
$deathMsg[$PassiveDamageType, 0]	= "%1 was such a weakling they died from something that doesnt hurt!";
$deathMsg[$PassiveDamageType, 1]	= "%1 was such a weakling they died from something that doesnt hurt!";
$deathMsg[$PassiveDamageType, 2]	= "%1 was such a weakling they died from something that doesnt hurt!";
$deathMsg[$PassiveDamageType, 3]	= "%1 was such a weakling they died from something that doesnt hurt!";
$deathMsg[$EMPDamageType, 0]		= "%1 was such a weakling they died from something that doesnt hurt!";
$deathMsg[$EMPDamageType, 1]		= "%1 was such a weakling they died from something that doesnt hurt!";
$deathMsg[$EMPDamageType, 2]		= "%1 was such a weakling they died from something that doesnt hurt!";
$deathMsg[$EMPDamageType, 3]		= "%1 was such a weakling they died from something that doesnt hurt!";
$deathMsg[$FireDamageType, 0]		= "%1 barbecues %2.";
$deathMsg[$FireDamageType, 1]		= "%2 gets turned into a human torch by %1.";
$deathMsg[$FireDamageType, 2]		= "%1 heats things up for %2.";
$deathMsg[$FireDamageType, 3]		= "%2 gets burned up by %1";
$deathMsg[$SmiteDamageType, 0]	= "%1 dissaproved of %2 behavior.";
$deathMsg[$SmiteDamageType, 1]	= "%2 met %1's wrath.";
$deathMsg[$SmiteDamageType, 2]	= "%1 says, 'May this be a lesson to %2.'";
$deathMsg[$SmiteDamageType, 3]	= "%1 says, '2, I just don't like you.'";
$deathMsg[$ChemDamageType, 0]      = "%2 hacks up %4 lungs courtesy of %1.";
$deathMsg[$ChemDamageType, 1]      = "%1 gets sinister on %2.";
$deathMsg[$ChemDamageType, 2]      = "%1 tells %2, 'You should've gone to the doctor earlier'.";
$deathMsg[$ChemDamageType, 3]      = "%1 gasses %2.";
$deathMsg[$ReasonDamageType, 0]	= "%1 shows %2 %3 Reason.";
$deathMsg[$ReasonDamageType, 1]	= "%2 shoulda listened to %1's Reason.";
$deathMsg[$ReasonDamageType, 2]	= "%1 shreds %2 up with tiny darts.";
$deathMsg[$ReasonDamageType, 3]	= "%2 is ripped up by %1's supersonic darts.";
$deathMsg[$EnGunDamageType, 0]	 = "%1 fries %2 with an energy burst.";
$deathMsg[$EnGunDamageType, 1]	 = "%2 should be more respectful of Energons like %1.";
$deathMsg[$EnGunDamageType, 2]	 = "%1 shows %2 why they should fear Energons.";
$deathMsg[$EnGunDamageType, 3]	 = "%2 feels the pain of %1's energy needles.";
$deathMsg[$KamikazeDamageType, 0]      = "%2 'Dies for %4 country'.";
$deathMsg[$KamikazeDamageType, 1]      = "%2 does it for a better future.";
$deathMsg[$KamikazeDamageType, 2]      = "%2 gives %4 life for the betterment of others.";
$deathMsg[$KamikazeDamageType, 3]      = "%2 undertakes the ultimate sacrifice.";
$deathMsg[$KamKillDamageType, 0]      = "%2 is engulfed in %1's fireball.";
$deathMsg[$KamKillDamageType, 1]      = "%2 didn't get to the bomb shelter in time.";
$deathMsg[$KamKillDamageType, 2]      = "%2 didn't hear %4 teammate scream 'INCOMING!'.";
$deathMsg[$KamKillDamageType, 3]      = "%1 brings down %2 along with %3self.";
$deathMsg[$ShotgunDamageType, 0]      = "%2 shoulda stayed away from %1.";
$deathMsg[$ShotgunDamageType, 1]      = "%2 got a taste of %1's boomstick.";
$deathMsg[$ShotgunDamageType, 2]      = "%1 blows %2 away with a wave of energy.";
$deathMsg[$ShotgunDamageType, 3]      = "%2 gets a helluva blast from %1.";
$deathMsg[$PoisonDamageType, 0]      = "%2 hacks up %4 lungs courtesy of %1.";
$deathMsg[$PoisonDamageType, 1]      = "%1 exterminates %2.";
$deathMsg[$PoisonDamageType, 2]      = "%1 tells %2, 'You shoulda gone to the doctor earlier!'.";
$deathMsg[$PoisonDamageType, 3]      = "%1 gasses %2.";
$deathMsg[$ExhaustDamageType, 0]      = "%2 breathed in someone's flaming exhaust.";
$deathMsg[$ExhaustDamageType, 1]      = "%2 got a whif of pure flame.";
$deathMsg[$ExhaustDamageType, 2]      = "%2 got caught up in someone's O.I.P. backwash.";
$deathMsg[$ExhaustDamageType, 3]      = "%2 didn't notice the big cannon on that guy's back.";
$deathMsg[$BoreDamageType, 0]   = "%1 stuck something very bad into %2's head.";
$deathMsg[$BoreDamageType, 1]   = "%2 got %4 brain electrocuted by %1's cerebral bore.";
$deathMsg[$BoreDamageType, 2]   = "%2's brain is fried by %1.";
$deathMsg[$BoreDamageType, 3]   = "%2 gets %4 head blown off by %1.";
$deathMsg[$BoreDmgDamageType, 0]   = "%1 stuck something very bad into %2's head.";
$deathMsg[$BoreDmgDamageType, 1]   = "%2 got %4 brain electrocuted by %1's cerebral bore.";
$deathMsg[$BoreDmgDamageType, 2]   = "%2's brain is fried by %1.";
$deathMsg[$BoreDmgDamageType, 3]   = "%2 gets %4 head blown off by %1.";
$deathMsg[$PheonixDamageType, 0]      = "%2 got burned by %1's firebird.";
$deathMsg[$PheonixDamageType, 1]      = "%1 lit %2 up in flames with %3 Pheonix.";
$deathMsg[$PheonixDamageType, 2]      = "%1 showed %2 one of the many wonders of science.";
$deathMsg[$PheonixDamageType, 3]      = "%1 blew the crap out of %2 with %3 Pheonix.";
$deathMsg[$GuassDamageType, 0]	= "%1 shows %2 what a very fast moving object can do to %4 body.";
$deathMsg[$GuassDamageType, 1]	= "%1 makes a nice round hole right through %2.";
$deathMsg[$GaussDamageType, 2]	= "%2 didnt even see %1's dart.";
$deathMsg[$GaussDamageType, 3]	= "%1 takes %2 down with a Guass Rifle.";

$deathMsg[$GargoyleDamageType, 0]	= "%1 gunned down %2 down with %3 Gargoyle.";
$deathMsg[$GargoyleDamageType, 1]	= "%2 gets strafed down by %1's dinky little plane.";
$deathMsg[$GargoyleDamageType, 2]	= "%2 didn't run for cover when %4 saw %1's little flying thing.";
$deathMsg[$GargoyleDamageType, 3]	= "%2 gets zapped by %1's Gargoyle.";

$deathMsg[$TurPlasmaDamageType, 0]		= "%2 gets mowed down by %1's Plasma Turret fire.";
$deathMsg[$TurPlasmaDamageType, 1]	= "%2 is chewed to pieces by %1's Plasma Turret.";
$deathMsg[$TurPlasmaDamageType, 2]	= "%2 walks into a stream of %1's Plasma Turret fire.";
$deathMsg[$TurPlasmaDamageType, 3]	= "%2 ends up on the wrong side of %1's big bad Plasma Turret.";
$deathMsg[$TurELFDamageType, 0]	= "%2 gets zapped by %1's ELF Turret fire.";
$deathMsg[$TurELFDamageType, 1]	= "%2 gets a jolt from %1's ELF Turret.";
$deathMsg[$TurELFDamageType, 2]	= "%1 short-circuits %2 with %3 ELF Turret.";
$deathMsg[$TurELFDamageType, 3]	= "%2 ends up on the wrong side of %1's little ELF Turret.";
$deathMsg[$TurMissileDamageType, 0]	= "%2 gets blown away by %1's Rocket Turret fire.";
$deathMsg[$TurMissileDamageType, 1]	= "%2 is chewed to pieces by %1's Rocket Turret.";
$deathMsg[$TurMissileDamageType, 2]	= "%2 walks into a stream of %1's Rocket Turret fire.";
$deathMsg[$TurMissileDamageType, 3]	= "%2 ends up on the wrong side of %1's big bad Rocket Turret.";
$deathMsg[$TurChainDamageType, 0]	= "%2 is gunned down by %1's Chaingun Turret.";
$deathMsg[$TurChainDamageType, 1]	= "%2 is chewed up by %1's Chain Turret.";
$deathMsg[$TurChainDamageType, 2]	= "%2 walks into a stream of hot lead from %1's Chaingun Turret.";
$deathMsg[$TurChainDamageType, 3]	= "%2 unluckily ended up on the recieving end of %1's mean Chain Turret.";
$deathMsg[$TurLaserDamageType, 0]	= "%2 is gunned down by %1's Aerial Laser.";
$deathMsg[$TurLaserDamageType, 1]	= "%2 couldn't find %1's floating laser turret.";
$deathMsg[$TurLaserDamageType, 2]	= "%2 gets sniped by %1's Aerial Laser Turret.";
$deathMsg[$TurLaserDamageType, 3]	= "%2 needs to look out for %1's floating laser turret some more.";
$deathMsg[$HangingDamageType, 0]	= "%2 gets mowed down by %1's Hanging Turret.";
$deathMsg[$HangingDamageType, 1]	= "%2 couldn't find %1's Hanging Turret in time.";
$deathMsg[$HangingDamageType, 2]	= "%2 walks into a stream of %1's Hanging Turret fire.";
$deathMsg[$HangingDamageType, 3]	= "%2 gets ambushed by %1's Hanging Turret.";
$deathMsg[$StingerDamageType, 0]	= "%2 gets stung by %1's Stinger Battery.";
$deathMsg[$StingerDamageType, 1]	= "%2 takes a big mean missile up %4 kiester from %1's Stinger Turret.";
$deathMsg[$StingerDamageType, 2]	= "%2 is blown up by %1's Stinger Turret.";
$deathMsg[$StingerDamageType, 3]	= "%2 gets dangerously close to %1's Stinger Missile.";
$deathMsg[$RPGTurretDamageType, 0]	= "%2 gets blasted by %1's RPG Turret.";
$deathMsg[$RPGTurretDamageType, 1]	= "%2 takes a big mean missile up %3 kiester from %1's RPG Siege Turret.";
$deathMsg[$RPGTurretDamageType, 2]	= "%2 is blown up by %1's RPG Turret.";
$deathMsg[$RPGTurretDamageType, 3]	= "%2 gets dangerously close to %1's RPG.";
$deathMsg[$FusionDamageType, 0]	= "%2 gets blown away by %1's explosing fusion reactor.";
$deathMsg[$FusionDamageType, 1]	= "%1 takes %2 down with %3self.";
$deathMsg[$FusionDamageType, 2]	= "%2 atomizes from %1's reactor detonation.";
$deathMsg[$FusionDamageType, 3]	= "%2 is vaporized by %1's cold fusion reactor.";

// Headshot kills - use normal msg vars
$HeadShot[$SniperDamageType, 0]	= "%1 pops %2 right smack in the head.";
$HeadShot[$SniperDamageType, 1]	= "%1 finishes %2 with a headshot.";
$HeadShot[$SniperDamageType, 2]	= "%2 tried to catch %1's bullet with his teeth.";
$HeadShot[$SniperDamageType, 3]	= "%1 takes %2 down with a shot to the head.";
$HeadShot[$LaserDamageType, 0]	= "%1 cores out a burning hole in %2's head.";
$HeadShot[$LaserDamageType, 1]	= "%1 tried to fix %2's eye using laser surgery - but with the wrong laser.";
$HeadShot[$LaserDamageType, 2]	= "%1 cooks %2's noggin.";
$HeadShot[$LaserDamageType, 3]	= "%1 melts %2's brain with a searing red beam.";
$HeadShot[$GaussDamageType, 0]	= "%1 places a supersonic object in %2's face.";
$HeadShot[$GaussDamageType, 1]	= "%1 cuts a clean hole straight through %2's brain.";
$HeadShot[$GaussDamageType, 2]	= "%2 didn't even feel the pain of %1's bullet going through %4 head.";
$HeadShot[$GaussDamageType, 3]	= "%2 catches %1's rail dart with his head.";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 does us all a big favor and kills %2self.";
$deathMsg[-2,1]						 = "%1 takes %2 own worthless life.";
$deathMsg[-2,2]						 = "%1 kills %2 own REALLY dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what food they serve in heaven.";

//   %1 = player name,  %2 = turret type
// You died from a turret messages.
$TurretDeathMsg[0]	= "%1 dies of turret trauma.";
$TurretDeathMsg[1]	= "%1 is chewed to pieces by a %2.";
$TurretDeathMsg[2]	= "%1 walks into a stream of %2 fire.";
$TurretDeathMsg[3]	= "%1 ends up on the wrong side of a %2.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------
// All buy presets
$allSpawnBuyList[0] = Grenade;
$allSpawnBuyList[1] = MineAmmo;
$allSpawnBuyList[2] = RepairKit;
$allSpawnBuyList[3] = Beacon;
$allSpawnBuyList[4] = TargetingLaser;

// Scout buy presets
$spawnBuyList[1,0] = ScoutArmor;
$spawnBuyList[1,1] = Blaster;
$spawnBuyList[1,2] = LaserRifle;

// Assassin buy presets
$spawnBuyList[2,0] = LightArmor;
$spawnBuyList[2,1] = PlasmaGun;
$spawnBuyList[2,2] = DiscLauncher;
$spawnBuyList[2,3] = SR100;
$spawnBuyList[2,4] = AmmoPack;

// Fighter buy presets
$spawnBuyList[3,0] = FighterArmor;
$spawnBuyList[3,1] = Blaster;
$spawnBuyList[3,2] = Chaingun;
$spawnBuyList[3,3] = GrenadeLauncher;
$spawnBuyList[3,4] = DiscLauncher;
$spawnBuyList[3,5] = EnergyPack;

// Engineer buy presets
$spawnBuyList[4,0] = MediumArmor;
$spawnBuyList[4,1] = BlastRifle;
$spawnBuyList[4,2] = SupportMortar;
$spawnBuyList[4,3] = AR900;
$spawnBuyList[4,4] = HealRifle;

// Destroyer buy presets
$spawnBuyList[5,0] = HeavyArmor;
$spawnBuyList[5,1] = Mortar;
$spawnBuyList[5,2] = RPG;
$spawnBuyList[5,3] = AR900;
$spawnBuyList[5,4] = Reason;
$spawnBuyList[5,5] = SupportMortar;
$spawnBuyList[5,6] = BlastRifle;
$spawnBuyList[5,7] = AmmoPack;

// Energon buy presets
$spawnBuyList[6,0] = TrooperArmor;
$spawnBuyList[6,1] = BlastRifle;
$spawnBuyList[6,2] = AR900;
$spawnBuyList[6,3] = Swarmer;
$spawnBuyList[6,4] = GasMortar;
$spawnBuyList[6,5] = Flamer;
$spawnBuyList[6,6] = RPG;
$spawnBuyList[6,7] = EnGun;
$spawnBuyList[5,8] = AmmoPack;

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

echo("TALON:RUNNING GAME PLAYER SPAWN");
function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
		bottomprint(%clientId, "<jc><f2>-- T A L O N   R U L E S   M O D --\n - VERSION " @ $ModVersion @ " -\n - Get it at www.talonhawk.com!! -\n Written by <f3>-=Talon Hawk=-\n\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);  
   }
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
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
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
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

echo("TALON:RUNNING GAME PLAYER SPAWNED");
// spawn item handling here
function Game::playerSpawned(%pl, %clientId, %armor)
{
	%armor = $ArmorMode[%clientId];
	if($ArmorMode[%clientId] > 6 || $ArmorMode[%clientId] < 1)
	{
		%armor = 3;
		$ArmorSpec[%clientId] = "Health";
		$SpecPending[%clientId] = "Health";
	}

	if(%clientId.PSkin == True)
	{
		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	}		  			  
	%clientId.spawn= 1;
	%max = getNumItems();
	for(%i = 0; (%item = $allSpawnBuyList[%i]) != ""; %i++)
	{
		buyItem(%clientId,%item);
	}
	for(%i = 0; (%item = $spawnBuyList[%armor,%i]) != ""; %i++)
	{
		buyItem(%clientId,%item);
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}

	echo("CURRENT SPEC IS:"@ $ArmorSpec[%clientId]@" SPEC PENDING IS:"@$SpecPending[%clientId]@".");
	if($SpecPending[%clientId] == Construction)
			Player::setItemCount(%pl,"ConstrBuff",1);
	if(%armor == 4)
	{
		if($SpecPending[%clientId] == Construction)
			buyItem(%clientId,Nanopack);
		else
			buyItem(%clientId,RepairPack);
	}
	if($SpecPending[%clientId] == Health)
	{
			echo("TALON:GIVING A PLAYER ARMOR BUFF");
			Player::setItemCount(%pl,"ArmorBuff",1);
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);	
		%clientId.spawnWeapon="";
	}

	for(%i = 0; %i < $ItemMax[Player::getArmor(%pl), Grenade]; %i++)
	{
		buyItem(%clientId,"BasicGrenadeIcon");
	}
	for(%i = 0; %i < $ItemMax[Player::getArmor(%pl), Beacon]; %i++)
	{
		buyItem(%clientId,"HeavyBeaconIcon");
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
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";
   }
   else 
   {
	if(%clientId.PSkin == True)
		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	else
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
         centerprint(%clientId, $Server::JoinMOTD, 0);
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
	if($ServerCheats)
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

echo("All safe up to onKilled");
function Client::onKilled(%playerId, %killerId, %damageType)
{
	echo("GAME: " @ %killerId @ " killed " @ %playerId @ " with " @ %damageType);

	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);

	if(!String::ICompare(Client::getGender(%playerId), "Male"))
	{
		%playerGender = "his";
		%otherGender = "He";
	}
	else
	{
		%playerGender = "her";
		%otherGender = "She";
	}

	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);
	if(%damageType == $ExhaustDamageType)
	{
		%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		return;
	}
	if(!%killerId)
	{
		%name = "none";
		if(%damageType == $TurPlasmaDamageType)
			%name = "Plasma Turret";
		else if(%damageType == $TurELFDamageType)
			%name = "ELF Turret";
		else if(%damageType == $FlakkerDamageType)
			%name = "Flakker Turret";
		else if(%damageType == $TurMissileDamageType)
			%name = "Rocket Turret";
		else if(%damageType == $TurLaserDamageType || %damageType == $LaserDamageType)
			%name = "Laser Turret";
		else if(%damageType == $EnergyDamageType)
			%name = "Indoor Turret";
		else if(%damageType == $HangingDamageType)
			%name = "Hanging Turret";
		else if(%damageType == $TurChainDamageType)
			%name = "Chaingun Turret";
		else if(%damageType == $StingerDamageType)
			%name = "Stinger Turret";
		else if(%damageType == $RPGTurretDamageType)
			%name = "RPG Turret";
		else if(%damageType == $MineDamageType)
			%name = "Mini-Mine";
		if (%name == "none")
			messageAll(0, strcat(%victimName, " was killed by an AI player."), $DeathMessageMask);
		if (%name == "Mini-Mine")
			messageAll(0, strcat(%victimName, " stepped on an unmarked mine."), $DeathMessageMask);
		else if(%damageType != $ExhaustDamageType && %name != "none")
		{
			%oopsMsg = sprintf($TurretDeathMsg[%ridx], %victimName, %name);
			messageAll(0, %oopsMsg, $DeathMessageMask);
		}
		%playerId.scoreDeaths++;
		%playerId.score--;
	}
	else if(%killerId == %playerId && %damageType != $LandingDamageType)
	{
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.score--;
		Game::refreshClientScore(%playerId);
	}
	else if(%damageType == $LandingDamageType)
	{
		%oopsMsg = sprintf($deathMsg[$LandingDamageType, %ridx], %victimName, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
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
		if(!%killerId.TKs)
			%pasttks = "no";
		else
			%pasttks = %killerId.TKs;
		if(%damageType != $MineDamageType) 
			messageAll(1, strcat(Client::getName(%killerId)," mows down ", %killerGender, " teammate, ", %victimName ,". ",%otherGender," has TK'ed ", %pasttks ," other times."), $DeathMessageMask);
		else
			messageAll(1, strcat(Client::getName(%killerId)," killed ", %killerGender, " teammate, ", %victimName ," with a mine. ",%otherGender," has TK'ed ", %pasttks ," other times."), $DeathMessageMask);
		if($THTKHandling == 1 && %damageType != $SmiteDamageType)
		{
			// Calculations for general "evilness" factor. Repeat TK's and multiple team TK's in a limited time contribute to this factor.
			if(%killerId.THlastTK = %victimName)
				%killerId.evilness++;
			else if(%killerId.THTKs > 2)
				%killerId.evilness++;
			// Now to the messages. Just a warning at level 2 "evilness"
			if(%killerId.evilness == 2)
				Client::sendMessage(%killerID,1,"Work on your aim man! Keep TKing and feel the consequences.");
			// Past level 2 you get into the punishment
			if(%killerId.evilness > 2 && %killerId.evilness < 8)
			{
				Client::sendMessage(%killerID,1,"Just for killing "@ %victimName @", I think I might have to punish you.");
				schedule("THFirstStageTK("@ %killerId @");",3); // PORT: the victim's NAME was spliced in here (the function never reads it)
			}
			// After 7 goto the final stage, where it's 50/50 to either get banned or killed
			if(%killerId.evilness > 7)
			{
				Client::sendMessage(%killerID,1,"You are angering me, "@ Client::getName(%killerId) @".");
				schedule("THSecondStageTK("@ %killerId @");",5); // PORT: as above
			}
			// Set general TK variables & count down the most recent TK in 60 secs.
			%killerId.THlastTK = %victimName;
			%killerId.THTKs++;
			echo(%killerId @".EVILNESS = "@ %killerID.evilness);
			schedule(%killerId.THTKs @" = ("@ %killerId.THTKs @" - 1);",60);

		}
		%killerId.scoreDeaths++;
		%killerId.TKs++;
		%killerId.score--;
		Game::refreshClientScore(%killerId);
	}
	else
	{
		if(%playerId.HeadShot == True)
		{
			%obitMsg = sprintf($HeadShot[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
//			messageAll(0, "ASD");
			messageAll(0, %obitMsg, $DeathMessageMask);
			%playerId.HeadShot = false;
		}
		else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
			echo(%damageType @" "@ %ridx @" "@ %obitmsg);
//			messageAll(0, "DSA");
			messageAll(0, %obitMsg, $DeathMessageMask);
		}
		%killerId.scoreKills++;
		%playerId.scoreDeaths ++;
		if(%damagetype != $NukeDamageType && %damagetype != $GargoyleDamageType && %damagetype != $FusionDamageType)
		{
			%killerId.score ++;
			%playerId.score --;
		}
		Game::refreshClientScore(%killerId);
		Game::refreshClientScore(%playerId);
      }
   }
   Game::clientKilled(%playerId, %killerId);
}

echo("onKilled is fine");

function Game::clientKilled(%playerId, %killerId)
{
   // do nothing
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

function PM(%client,%string)
{
	Client::sendMessage(%client,%string);
}

function THFirstStageTK(%killerId,%victimName)
{
	%ridx = floor(getRandom() * (5 - 0.01));
	if(%ridx == 0)
	{
		Client::sendMessage(%killerID,1,"I think I'm going to lower your score by 10 points just for that...");
		MessageAll(1, "The God-King -=Talon Hawk=- decided to be mean and lower "@ Client::getName(%killerId) @"'s score by 10 points.");
		%killerId.score = (%killerId.score - 10);
		Game::refreshClientScore(%killerId);
	}
	else if(%ridx == 1)
	{
		Client::sendMessage(%killerID,1,"I think I'm going to lower your score by 5 points...");
		MessageAll(1, "The God-King -=Talon Hawk=- decided to lower "@ Client::getName(%killerId) @"'s score by 5 points.");			
		%killerId.score = (%killerId.score - 5);
		Game::refreshClientScore(%killerId);
	}
	else if(%ridx == 2)
	{
		Client::sendMessage(%killerID,1,"Hmmm... Just for being mean I think I'll be evil and take away ALL of your energy untill you die!");
		%killerPlayer = Client::getOwnedObject(%killerID);
		GameBase::setEnergy(%killerPlayer,0);
		GameBase::setRechargeRate(%killerPlayer,0);
	}
	else if(%ridx == 3)
	{
		Client::sendMessage(%killerID,1,"Alright, I can't come up with something creative so I'll just kill you.");
		MessageAllExcept(%killerId,1, "Lord -=Talon Hawk=- decided that "@ Client::getName(%killerId) @" didn't deserve to live.");			
		remoteKill(%killerId);
	}
	else if(%ridx == 4)
	{
		Client::sendMessage(%killerID,1,"Alright, I can't come up with something creative so I'll just kill you.");
		MessageAll(1, "Lord -=Talon Hawk=- decided that "@ Client::getName(%killerId) @" didn't deserve to live.");			
		remoteKill(%killerId);
	}
	else if(%ridx == 5)
		Client::sendMessage(%killerID,1,"You know what, you lucky bastard, I'm gonna let you go free.");
}

function THSecondStageTK(%killerId,%victimName)
{
	%ridx = floor(getRandom() * (2 - 0.01));
	if(%ridx == 0)
	{
		Client::sendMessage(%killerID,1,"Since you're such an ass, I dont think you realy need to be on this server anymore. Bye bye.");
		MessageAll(1, "The Lord of Everything, -=Talon Hawk=-, has decided to boot "@ Client::getName(%killerId) @" off the server for 1 hour.");
	      %ip = Client::getTransportAddress(%killerId);
      	BanList::add(%ip, 3600);
         	Net::kick(%killerId, "You were banned from this server for TK'ing. You have been given 1 hour to reconsider your ways. If you come back after the hour and continue to TK, you will go through the same process as you just did.");
	}
	if(%ridx == 1)
	{
		Client::sendMessage(%killerID,1,"Alright, this is enough. Stop TK'ing or be banned. I'm going to kill you now.");
		MessageAll(1, "Lord -=Talon Hawk=- decided that "@ Client::getName(%killerId) @" didn't deserve to live.");
		remoteKill(%killerId);
	}
}

