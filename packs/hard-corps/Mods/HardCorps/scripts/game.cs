exec("comchat.cs");

$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$HardCorps::Version = "HARD CORPS V1.5 FINAL";
$HardCorps::Information = "<f0>Press <f1>TAB<f0> - Player Options - Spawn Equipment to set up default spawn gear.";
$HardCorps::Menu = "HARD CORPS V1.5 FINAL";
$HardCorps::LoadingMessage = "<jc><f2>THIS SERVER HAS BEEN MODIFIED:\n\n<f3>Now running " @ $HardCorps::Version @ "\n<f1>http://www.planetstarsiege.com/hardcorps/";
// PORT: removed -- the author's own Super Admin entry (name, real name, e-mail, password, address mask) was planted here in list slot 0 on every server

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
$WaitThrowTime = 1.5;

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
$RemoteAmmoEnergy = 3000; 
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
$TurretBoxMaxLength = 30;    //Define Max Length of the area
$TurretBoxMaxWidth =  30;    //Define Max Width of the area
$TurretBoxMaxHeight = 10;    //Define Max Height of the area

$TurretBoxMinLength = 8;	  //Define Min Length from another turret
$TurretBoxMinWidth =  8;	  //Define Min Width from another turret
$TurretBoxMinHeight = 8;    //Define Min Height from another turret

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
$HeadFront = 0;
$HeadBack = 1;
$TorsoFront = 2;
$TorsoBack = 3;
$LegsFront = 4;
$LegsBack = 5;
$NumberOfDeathTypes = 6;
$NORM = 0;
$OWNE = 6;
$TKER = 0;
$TKIT = 0;

//LEAVING THE MISSION AREA DEATH
$deathMsg[$MissionAreaDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$MissionAreaDamageType, $HeadFront,0]	= "%2 is killed for leaving the mission area.";
$deathMsg[$MissionAreaDamageType, $HeadBack,0]	= "%2 is killed for leaving the mission area.";
$deathMsg[$MissionAreaDamageType, $TorsoFront,0]= "%2 is killed for leaving the mission area.";
$deathMsg[$MissionAreaDamageType, $TorsoBack,0]	= "%2 is killed for leaving the mission area.";
$deathMsg[$MissionAreaDamageType, $LegsFront,0]	= "%2 is killed for leaving the mission area.";
$deathMsg[$MissionAreaDamageType, $LegsBack,0]	= "%2 is killed for leaving the mission area.";


//FALLING DAMAGE
$deathMsg[$LandingDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$LandingDamageType, $HeadFront,0]     	= "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, $HeadBack,0]     		= "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, $TorsoFront,0]    	= "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, $TorsoBack,0]     	= "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, $LegsFront,0]     	= "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, $LegsBack,0] 	    	= "%2 falls to %3 death.";


//VEHICLE IMPACTS
$deathMsg[$ImpactDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$ImpactDamageType, $HeadFront,0]	     	= "%1 lands on %2's forehead.";
$deathMsg[$ImpactDamageType, $HeadBack,0]     		= "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, $TorsoFront,0]     	= "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, $TorsoBack,0]    	 	= "%1 parks his vehicle between %2's shoulders.";
$deathMsg[$ImpactDamageType, $LegsFront,0]    	 	= "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, $LegsBack,0]     		= "%1 rides right up %2's butt.";


// NAPALM LAUNCHER
$deathMsg[$NapalmLauncherDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$NapalmLauncherDamageType, $HeadFront,0]      	= "%2 feels the burn from %1's napalm.";
$deathMsg[$NapalmLauncherDamageType, $HeadBack,0]  	    	= "%2 never saw it coming from %1's napalm.";
$deathMsg[$NapalmLauncherDamageType, $TorsoFront,0]      	= "%2 feels the burn from %1's napalm.";
$deathMsg[$NapalmLauncherDamageType, $TorsoBack,0]      	= "%2 never saw it coming from %1's napalm.";
$deathMsg[$NapalmLauncherDamageType, $LegsFront,0]      	= "%2 feels the burn from %1's napalm.";
$deathMsg[$NapalmLauncherDamageType, $LegsBack,0]      	= "%2 never saw it coming from %1's napalm.";


// CLUSTER CANNON
$deathMsg[$ClusterCannonDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$ClusterCannonDamageType, $HeadFront,0]      	= "%1 makes pizza of %2's face with %3 Cluster Cannon.";
$deathMsg[$ClusterCannonDamageType, $HeadBack,0]      	= "%1 puts a few high-velocity cluster rounds into the back of %2's head.";
$deathMsg[$ClusterCannonDamageType, $TorsoFront,0]      	= "%1 air-conditions %2 with %3 Cluster Cannon.";
$deathMsg[$ClusterCannonDamageType, $TorsoBack,0]      	= "%2 never saw it coming from %1.";
$deathMsg[$ClusterCannonDamageType, $LegsFront,0]      	= "%1 fills %2's legs full of holes.";
$deathMsg[$ClusterCannonDamageType, $LegsBack,0]      	= "%1 tears %2 a few new buttholes with %3 Cluster Cannon.";


// VEHICLE BOMBS
$deathMsg[$VehicleBombDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$VehicleBombDamageType, $HeadFront,0]    		= "%1 lands a HEAP bomb on %2's head.";
$deathMsg[$VehicleBombDamageType, $HeadBack,0]    		= "%2 didn't see that last HEAP bomb from %1.";
$deathMsg[$VehicleBombDamageType, $TorsoFront,0]   		= "%1 HEAP bombs %2 into oblivion";
$deathMsg[$VehicleBombDamageType, $TorsoBack,0]    		= "%2 didn't see that last HEAP bomb from %1";
$deathMsg[$VehicleBombDamageType, $LegsFront,0]	    		= "%1's HEAP bomb takes out %2.";
$deathMsg[$VehicleBombDamageType, $LegsBack,0]	    		= "%1's HEAP bomb takes out %2.";


//BULLET WEAPONS
$deathMsg[$BulletDamageType, $NumberOfDeathTypes,0] = 3;
$deathMsg[$BulletDamageType, $HeadFront,0]      	= "%1 messes up %2's face with %3 chaingun.";
$deathMsg[$BulletDamageType, $HeadBack,0] 	     	= "%1 puts a few chaingun rounds into the back of %2's head.";
$deathMsg[$BulletDamageType, $TorsoFront,0]      	= "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, $TorsoBack,0]      	= "%1 guns %2 down from behind.";
$deathMsg[$BulletDamageType, $LegsFront,0]      	= "%1 fills %2's legs full of holes.";
$deathMsg[$BulletDamageType, $LegsBack,0]	      	= "%1 tears %2 a new butthole with %3 chaingun.";

$deathMsg[$BulletDamageType, $HeadFront,1]      	= "%1 puts a few chaingun rounds into %2's face.";
$deathMsg[$BulletDamageType, $HeadBack,1]      		= "%1 removes the back of %2's head with his chaingun.";
$deathMsg[$BulletDamageType, $TorsoFront,1]      	= "%2 is disembowelled by %1's chaingun.";
$deathMsg[$BulletDamageType, $TorsoBack,1]      	= "%1 puts a few well-placed chaingun rounds into %2's back.";
$deathMsg[$BulletDamageType, $LegsFront,1]      	= "%1 puts some lead in %2's pencil.";
$deathMsg[$BulletDamageType, $LegsBack,1]      		= "%1 amputates %2's legs with %3 chaingun.";

$deathMsg[$BulletDamageType, $HeadFront,2]      	= "%2 has a mind blowing experience with %1's chaingun.";
$deathMsg[$BulletDamageType, $HeadBack,2] 	     	= "%2 receives a few too many of %1's bullets to the back of the head.";
$deathMsg[$BulletDamageType, $TorsoFront,2]      	= "%1's chaingun gives %2 high-velocity lead poisoning.";
$deathMsg[$BulletDamageType, $TorsoBack,2]      	= "%1 asks %2, 'Did my chaingun get your kidneys?'";
$deathMsg[$BulletDamageType, $LegsFront,2]      	= "%1 kneecaps %2 with his chaingun.";
$deathMsg[$BulletDamageType, $LegsBack,2]	      	= "%2 takes %1's chaingun rounds from behind.";


//ROTARY CANNON
$deathMsg[$RotaryCannonDamageType, $NumberOfDeathTypes,0] = 3;
$deathMsg[$RotaryCannonDamageType, $HeadFront,0]      	= "%1 messes up %2's face with %3 rotary cannon.";
$deathMsg[$RotaryCannonDamageType, $HeadBack,0] 	     	= "%1 puts a few rotary cannon rounds into the back of %2's head.";
$deathMsg[$RotaryCannonDamageType, $TorsoFront,0]      	= "%1 ventilates %2 with %3 rotary cannon.";
$deathMsg[$RotaryCannonDamageType, $TorsoBack,0]      	= "%1 guns %2 down from behind.";
$deathMsg[$RotaryCannonDamageType, $LegsFront,0]      	= "%1 fills %2's legs full of holes.";
$deathMsg[$RotaryCannonDamageType, $LegsBack,0]	      	= "%1 tears %2 a new butthole with %3 rotary cannon.";

$deathMsg[$RotaryCannonDamageType, $HeadFront,1]      	= "%1 puts a few rotary cannon rounds into %2's face.";
$deathMsg[$RotaryCannonDamageType, $HeadBack,1]      		= "%1 removes the back of %2's head with his rotary cannon.";
$deathMsg[$RotaryCannonDamageType, $TorsoFront,1]      	= "%2 is disembowelled by %1's rotary cannon.";
$deathMsg[$RotaryCannonDamageType, $TorsoBack,1]      	= "%1 puts a few well-placed rotary cannon rounds into %2's back.";
$deathMsg[$RotaryCannonDamageType, $LegsFront,1]      	= "%1 puts some lead in %2's pencil.";
$deathMsg[$RotaryCannonDamageType, $LegsBack,1]      		= "%1 amputates %2's legs with %3 rotary cannon.";

$deathMsg[$RotaryCannonDamageType, $HeadFront,2]      	= "%2 has a mind blowing experience with %1's rotary cannon.";
$deathMsg[$RotaryCannonDamageType, $HeadBack,2] 	     	= "%2 receives a few too many of %1's bullets to the back of the head.";
$deathMsg[$RotaryCannonDamageType, $TorsoFront,2]      	= "%1's rotary cannon gives %2 high-velocity lead poisoning.";
$deathMsg[$RotaryCannonDamageType, $TorsoBack,2]      	= "%1 asks %2, 'Did my rotary cannon get your kidneys?'";
$deathMsg[$RotaryCannonDamageType, $LegsFront,2]      	= "%1 kneecaps %2 with his rotary cannon.";
$deathMsg[$RotaryCannonDamageType, $LegsBack,2]	      	= "%2 takes %1's rotary cannon rounds from behind.";


// PLASMA WEAPONS
$deathMsg[$PlasmaDamageType, $NumberOfDeathTypes,0] = 2;
$deathMsg[$PlasmaDamageType, $HeadFront,0]      	= "%2 takes one of %1's plasma rounds to the face.";
$deathMsg[$PlasmaDamageType, $HeadBack,0]  	    	= "%1 puts a plasma burst into the back of %2's head.";
$deathMsg[$PlasmaDamageType, $TorsoFront,0]      	= "%2 turns up the heat on %2.";
$deathMsg[$PlasmaDamageType, $TorsoBack,0]      	= "%2 takes %1's plasma round right in the back.";
$deathMsg[$PlasmaDamageType, $LegsFront,0]      	= "%1 gives %2's groin a distinct burning sensation.";
$deathMsg[$PlasmaDamageType, $LegsBack,0]	      	= "%1 lights up %2's passage.";

$deathMsg[$PlasmaDamageType, $HeadFront,0]      	= "%1 puts a twinkle in %2's eye with his plasma gun.";
$deathMsg[$PlasmaDamageType, $HeadBack,0]	      	= "%1 sears the skin off the back of %2's head.";
$deathMsg[$PlasmaDamageType, $TorsoFront,0]      	= "%2 catches one of %1's plasma rounds in the chest.";
$deathMsg[$PlasmaDamageType, $TorsoBack,0]      	= "%1 lands a ball of super-heated death on %2's back.";
$deathMsg[$PlasmaDamageType, $LegsFront,0]      	= "%1 removes %2's pubic hair with %3 plasma gun.";
$deathMsg[$PlasmaDamageType, $LegsBack,0]	      	= "%2 didn't see that last plasma from %1.";


// DISC WEAPONS
$deathMsg[$ExplosionDamageType, $NumberOfDeathTypes,0] = 3;
$deathMsg[$ExplosionDamageType, $HeadFront,0]    	= "%1 puts a disc right between %2's eyes.";
$deathMsg[$ExplosionDamageType, $HeadBack,0]    	= "%2 catches one of %1's discs in the back of the head.";
$deathMsg[$ExplosionDamageType, $TorsoFront,0]   	= "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, $TorsoBack,0]    	= "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, $LegsFront,0]    	= "%2 falls victim to %1's Stormhammer.";
$deathMsg[$ExplosionDamageType, $LegsBack,0]    	= "%2 takes %1's disc from behind.";

$deathMsg[$ExplosionDamageType, $HeadFront,1]    	= "%1 lands a disc in %2's mouth.";
$deathMsg[$ExplosionDamageType, $HeadBack,1]    	= "The back of %2's skull is removed by %1's disc.";
$deathMsg[$ExplosionDamageType, $TorsoFront,1]   	= "%1 puts a disc into %2's stomach.";
$deathMsg[$ExplosionDamageType, $TorsoBack,1]    	= "%2 catches one of %1's discs between the shoulderblades.";
$deathMsg[$ExplosionDamageType, $LegsFront,1]    	= "%1 lands a disc between %2's legs.";
$deathMsg[$ExplosionDamageType, $LegsBack,1]    	= "%1's disc gives %2 a thorough proctological examination.";

$deathMsg[$ExplosionDamageType, $HeadFront,2]    	= "%2 loses his face to %1's high-explosive disc.";
$deathMsg[$ExplosionDamageType, $HeadBack,2]    	= "%1 blasts %2 in the back of the neck.";
$deathMsg[$ExplosionDamageType, $TorsoFront,2]   	= "%2 catches a disc in the chest, courtesy of %1.";
$deathMsg[$ExplosionDamageType, $TorsoBack,2]    	= "%2 catches a disc to the spine, courtesy of %1.";
$deathMsg[$ExplosionDamageType, $LegsFront,2]    	= "%1 blasts %2's testicles through the top of his head.";
$deathMsg[$ExplosionDamageType, $LegsBack,2]    	= "%2 didn't see that last disc from %1.";


// SHRAPNEL
$deathMsg[$ShrapnelDamageType, $NumberOfDeathTypes,0] = 2;
$deathMsg[$ShrapnelDamageType, $HeadFront,0]    	= "%1 lands a grenade in %2's mouth.";
$deathMsg[$ShrapnelDamageType, $HeadBack,0]    		= "%2 catches one of %1's grenades in the back of the head.";
$deathMsg[$ShrapnelDamageType, $TorsoFront,0]   	= "%2 catches one of %1's grenades front-on.";
$deathMsg[$ShrapnelDamageType, $TorsoBack,0]    	= "%1's grenades caught %2 by surprise.";
$deathMsg[$ShrapnelDamageType, $LegsFront,0]    	= "%1 blows %2's legs out from under him.";
$deathMsg[$ShrapnelDamageType, $LegsBack,0]    		= "%1 gives %2 a shrapnel enema.";

$deathMsg[$ShrapnelDamageType, $HeadFront,0]    	= "%2 catches one of %1's grenades between the eyes.";
$deathMsg[$ShrapnelDamageType, $HeadBack,0]    		= "%2 didn't see that last grenade from %1.";
$deathMsg[$ShrapnelDamageType, $TorsoFront,0]   	= "%1 lands a grenade on %2's chest.";
$deathMsg[$ShrapnelDamageType, $TorsoBack,0]    	= "%1 lands a grenade in %2's unprotected back.";
$deathMsg[$ShrapnelDamageType, $LegsFront,0]    	= "%1's grenade removes %2's testicles.";
$deathMsg[$ShrapnelDamageType, $LegsBack,0]	    	= "%2 didn't see that last grenade from %2.";


// LASER WEAPONS
$deathMsg[$LaserDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$LaserDamageType, $HeadFront,0]       	= "%2 takes a faceful of %1's laser.";
$deathMsg[$LaserDamageType, $HeadBack,0]  	     	= "%1 puts a laser beam through the back of %2's head.";
$deathMsg[$LaserDamageType, $TorsoFront,0]       	= "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, $TorsoBack,0]       	= "%1 puts a laser beam into %2's unprotected back.";
$deathMsg[$LaserDamageType, $LegsFront,0]       	= "%2 feels the searing heat of %1's laser knee-capping.";
$deathMsg[$LaserDamageType, $LegsBack,0]	       	= "%2 is a victim to %1's laser enema.";


//MORTAR WEAPONS
$deathMsg[$MortarDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$MortarDamageType, $HeadFront,0]    		= "%1 lands a mortar on %2's head.";
$deathMsg[$MortarDamageType, $HeadBack,0]    		= "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, $TorsoFront,0]   		= "%1 mortars %2 into oblivion";
$deathMsg[$MortarDamageType, $TorsoBack,0]    		= "%2 didn't see that last mortar from %1";
$deathMsg[$MortarDamageType, $LegsFront,0]	    	= "%1's mortar takes out %2.";
$deathMsg[$MortarDamageType, $LegsBack,0]	    		= "%1's mortar takes out %2.";


//BLASTER WEAPONS
$deathMsg[$BlasterDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$BlasterDamageType, $HeadFront,0]    		= "%1's stream of blaster bolts open %2's eyes.";
$deathMsg[$BlasterDamageType, $HeadBack,0]    		= "%2 is killed by blaster bolts to the back of the head.";
$deathMsg[$BlasterDamageType, $TorsoFront,0]   		= "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, $TorsoBack,0]    		= "%2 is mowed down by %1's blaster fire.";
$deathMsg[$BlasterDamageType, $LegsFront,0]    		= "%2 is knee-capped by %1's blaster fire.";
$deathMsg[$BlasterDamageType, $LegsBack,0] 	   	= "%1 shoots out %2's legs with his trusty Blaster.";


//ELF GUNS
$deathMsg[$ElectricityDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$ElectricityDamageType, $HeadFront,0]   	= "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, $HeadBack,0]    	= "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, $TorsoFront,0]  	= "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, $TorsoBack,0]  	= "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, $LegsFront,0]	   	= "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, $LegsBack,0] 	   	= "%1 short-circuits %2's systems.";


//CRUSH DAMAGE
$deathMsg[$CrushDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$CrushDamageType, $HeadFront,0]    		= "%2 is crushed.";
$deathMsg[$CrushDamageType, $HeadBack,0]    		= "%2 is crushed.";
$deathMsg[$CrushDamageType, $TorsoFront,0]   		= "%2 is crushed.";
$deathMsg[$CrushDamageType, $TorsoBack,0]    		= "%2 is crushed.";
$deathMsg[$CrushDamageType, $LegsFront,0]    		= "%2 is crushed.";
$deathMsg[$CrushDamageType, $LegsBack,0]    		= "%2 is crushed.";


//DEBRIS DAMAGE
$deathMsg[$CrushDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$CrushDamageType, $HeadFront,0] 	 	= "%2 is killed by debris..";
$deathMsg[$CrushDamageType, $HeadBack,0]    		= "%2 is killed by debris.";
$deathMsg[$CrushDamageType, $TorsoFront,0]   		= "%2 is killed by debris.";
$deathMsg[$CrushDamageType, $TorsoBack,0]    		= "%2 is killed by debris.";
$deathMsg[$CrushDamageType, $LegsFront,0]    		= "%2 is killed by debris.";
$deathMsg[$CrushDamageType, $LegsBack,0]    		= "%2 is killed by debris.";

//MISSILE DAMAGE
$deathMsg[$MissileDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$MissileDamageType, $HeadFront,0]  		= "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, $HeadBack,0]    		= "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, $TorsoFront,0]   		= "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, $TorsoBack,0]    		= "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, $LegsFront,0]    		= "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, $LegsBack,0]    		= "%2 gets real friendly with a rocket.";


//MINE DAMAGE
$deathMsg[$MineDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$MineDamageType, $HeadFront,0]  		= "%1 blows up %2 with a mine.";
$deathMsg[$MineDamageType, $HeadBack,0]   	 	= "%1 blows up %2 with a mine.";
$deathMsg[$MineDamageType, $TorsoFront,0]   		= "%1 blows up %2 with a mine.";
$deathMsg[$MineDamageType, $TorsoBack,0]    		= "%1 blows up %2 with a mine.";
$deathMsg[$MineDamageType, $LegsFront,0]    		= "%1 blows up %2 with a mine.";
$deathMsg[$MineDamageType, $LegsBack,0]    		= "%1 blows up %2 with a mine.";


//CLUSTER GUN DAMAGE
$deathMsg[$ClusterDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$ClusterDamageType, $HeadFront,0]      	= "%1 makes pizza of %2's face with %3 Cluster Gun.";
$deathMsg[$ClusterDamageType, $HeadBack,0]      	= "%1 puts a few high-velocity cluster rounds into the back of %2's head.";
$deathMsg[$ClusterDamageType, $TorsoFront,0]      	= "%1 air-conditions %2 with %3 Cluster Gun.";
$deathMsg[$ClusterDamageType, $TorsoBack,0]      	= "%2 never saw it coming from %1.";
$deathMsg[$ClusterDamageType, $LegsFront,0]      	= "%1 fills %2's legs full of holes.";
$deathMsg[$ClusterDamageType, $LegsBack,0]      	= "%1 tears %2 a few new buttholes with %3 Cluster Gun.";

//EMP PULSE GUN DAMAGE
$deathMsg[$EMPulseDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$EMPulseDamageType, $HeadFront,0]   		= "%1 short-circuits %2's systems.";
$deathMsg[$EMPulseDamageType, $HeadBack,0]    		= "%1 short-circuits %2's systems.";
$deathMsg[$EMPulseDamageType, $TorsoFront,0]  		= "%1 short-circuits %2's systems.";
$deathMsg[$EMPulseDamageType, $TorsoBack,0]   		= "%1 short-circuits %2's systems.";
$deathMsg[$EMPulseDamageType, $LegsFront,0]   		= "%1 short-circuits %2's systems.";
$deathMsg[$EMPulseDamageType, $LegsBack,0]    		= "%1 short-circuits %2's systems.";

//UNNAMED TURRET DAMAGE
$deathMsg[$TurretDamageType, $NumberOfDeathTypes,0] = 1;
$deathMsg[$TurretDamageType, $HeadFront,0]      	= "A turret messes up %2's face real bad.";
$deathMsg[$TurretDamageType, $HeadBack,0]      		= "A turret takes off the back of %2's head";
$deathMsg[$TurretDamageType, $TorsoFront,0]      	= "%2 takes it in the chest from a turret.";
$deathMsg[$TurretDamageType, $TorsoBack,0]      	= "%2 never saw it coming from a turret.";
$deathMsg[$TurretDamageType, $LegsFront,0]      	= "%2 is knee-capped by a turret.";
$deathMsg[$TurretDamageType, $LegsBack,0]      		= "%2 never saw it coming from a turret.";

//OWNED TURRET DAMAGE
$deathMsg[$TurretDamageType, $HeadFront+$OWNE,0] 	= "%1 turret messes up %2's face real bad.";
$deathMsg[$TurretDamageType, $HeadBack+$OWNE,0]  	= "%1 turret takes off the back of %2's head";
$deathMsg[$TurretDamageType, $TorsoFront+$OWNE,0]	= "%2 takes it in the chest from %1 turret.";
$deathMsg[$TurretDamageType, $TorsoBack+$OWNE,0] 	= "%2 never saw it coming from %1 turret.";
$deathMsg[$TurretDamageType, $LegsFront+$OWNE,0] 	= "%2 is knee-capped by %1 turret.";
$deathMsg[$TurretDamageType, $LegsBack+$OWNE,0]  	= "%2 never saw it coming from %1 turret.";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = TargetingLaser;
$spawnBuyList[6] = "";

//Stairway To Heaven Buy Lists
$StairwayBuyList[0] = LightArmor;
$StairwayBuyList[1] = Blaster;
$StairwayBuyList[2] = StairwayForceFieldPack;
$StairwayBuyList[3] = TargetingLaser;
$StairwayBuyList[4] = "";

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
   messageAll(0, "Game starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Game started.");
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

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
	if ($Game::MissionType == "Stairway") centerprint(%clientId, "<jc><f0>" @ $HardCorps::Version @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>Stairway To Heaven\n\n<f0>Construct a tower of Force Fields up to the objective.\nThe first team to touch the objective wins!", 10);
	else if ($Game::MissionType == "Oversight") centerprint(%clientId, "<jc><f0>" @ $HardCorps::Version @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>Unfortunate Oversight\n\n<f0>Both teams have the others flag.  Kill the enemy flag\n carrier and touch the flags to score!",10);
	else if ($Game::MissionType == "TideOfBattle") centerprint(%clientId, "<jc><f0>" @ $HardCorps::Version @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>Tide Of Battle\n\n<f0>Kill an enemy to convert them to your team.\n The last surviving team wins the game!",10);
		else bottomprint(%clientId, "<jc><f0>" @ $HardCorps::Version @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n" @ $HardCorps::Information @ "", 5);
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

function SpawnImmunityCountdown(%clientId)
{
	if (%clientId.spawnimmunity > 0)
		{
			%clientId.spawnimmunity--;
			schedule("SpawnImmunityCountdown(" @ %clientId @ ");", 1);
		} else %clientId.jamdetect = "false";
}

function Game::playerSpawned(%pl, %clientId, %armor)
{	
	%clientId.duelist = "false";
	if(%clientId.custom && $AllowCustomSkins == "true")
		{
			Client::setSkin(%clientId, $Client::info[%clientId, 0]);
		} else Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);

	%clientId.spawnimmunity = $SpawnImmunityTime;
	HCTK::CheckForTKer(%clientId);
	schedule("SpawnImmunityCountdown(" @ %clientId @ ");", 1);
				
	  
	%clientId.spawn= 1;
	%max = getNumItems();
	if ($Game::MissionType == "Stairway")
		{
			for(%i = 0; (%item = $StairwayBuyList[%i]) != ""; %i++)
				{
					buyItem(%clientId,%item);	
					if(%item.className == Weapon) 
					%clientId.spawnWeapon = %item;
				}
		} else
		{
			for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
				{
					if (%i == 0 || %i > 3)
						{
							buyItem(%clientId,%item);	
							if(%item.className == Weapon) 
							%clientId.spawnWeapon = %item;
						} else
						{
							if (%i == 1) 
								{
									buyItem(%clientId,%clientId.slota);
									if(%clientId.slota.className == Weapon) 
									%clientId.spawnWeapon = %clientId.slota;
								}
							if (%i == 2) 
								{
									buyItem(%clientId,%clientId.slotb);
									if(%clientId.slotb.className == Weapon) 
									%clientId.spawnWeapon = %clientId.slotb;
								}
							if (%i == 3) 
								{
									buyItem(%clientId,%clientId.slotc);
									if(%clientId.slotc.className == Weapon) 
									%clientId.spawnWeapon = %clientId.slotc;
								}
						}
				}
		}
	
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") 
		{
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
         bottomprint(%clientId, "<jc><f1>Game in Competition Mode\nTeam Damage is " @ %td, 0);
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
      Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
         centerprint(%clientId, "<jc><f2>" @ $HardCorps::Version @ "\n\n" @ $Server::JoinMOTD, 0);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
      }
      else if(%clientId.observerMode == "justJoined")
      {
         bottomprint(%clientId, "");
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
		%cl.TeamKills = 0;
		%cl.totalKills = 0;
		%cl.selfKills = 0;
	      %cl.scoreDeaths = 0;
		%cl.FlagStops = 0;
		%cl.ratio = 0;
      	%cl.score = 0;
		%cl.empeffect = 0;
      	%cl.snipes = 0;
      	%cl.flagknocks = 0;
		%cl.inStation = "false";
		%cl.stationtime = 0;
		%cl.stationouttime = 0;
      	%cl.defencebonus = 0;
		%cl.offencebonus = 0;
      	%cl.FlagCaps = 0;
		%cl.TeamDamaged = 0;
		%cl.FlagGrabs = 0;
		%cl.DeathByFlag = 0;
		%cl.suddendeathactive = "false";
		%cl.suddendeathcounter = 0;
		%cl.damageteamstuff = 0;
		%cl.jamdetect = "false";
		}
	}
	else {
      	%client.scoreKills = 0;
	  	%client.scoreDeaths = 0;
		%client.ratio = 0;
	     	%client.score = 0;
		%client.inStation = "false";
		%client.TeamKills = 0;
		%client.totalKills = 0;
		%client.selfKills = 0;
      	%client.flagknocks = 0;
		%client.FlagStops = 0;
		%client.suddendeathactive = "false";
		%client.suddendeathcounter = 0;
		%client.TeamDamaged = 0;
		%client.DeathByFlag = 0;
      	%client.defencebonus = 0;
      	%client.snipes = 0;
		%client.empeffect = 0;
		%client.stationtime = 0;
		%client.stationouttime = 0;
		%client.offencebonus = 0;
      	%client.FlagCaps = 0;
		%client.FlagGrabs = 0;
		%client.jamdetect = "false";
		%client.damageteamstuff = 0;
	}
}

function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.stationtime = 0;
	%playerId.stationouttime = 0;
	%playerId.TeamKills = 0;
	%playerId.totalKills = 0;
	%playerId.selfKills = 0;
     	%playerId.flagknocks = 0;
	%playerId.DeathByFlag = 0;
	%playerId.teamkiller = "false";
	%playerId.tklog = 0;
	%playerId.showscorebonuses = $ShowScoreBonuses;
	%playerId.showdescriptions = "true";
     	%playerId.FlagCaps = 0;
	%playerId.FlagGrabs = 0;
	%playerId.FlagStops = 0;
     	%playerId.snipes = 0;
     	%playerId.defencebonus = 0;
	%playerId.inStation = "false";
	%playerId.offencebonus = 0;
	%playerId.justConnected = true;
	%playerId.weaponnames = $DefaultShowWeaponNames;
	%playerId.weaponstats = $DefaultShowWeaponStats;
	%playerId.custom = $DefaultCustomSkin;
	%playerId.suddendeathactive = "false";
	%playerId.suddendeathcounter = 0;
	%playerId.damageteamstuff = 0;
	%playerId.empeffect = 0;
     	%playerId.showdescriptions = $DefaultShowDescriptions;
	%playerId.TeamDamaged = 0;
	%playerId.slota = $DefaultEquipmentSlotA;
	%playerId.slotb = $DefaultEquipmentSlotB;
	%playerId.slotc = $DefaultEquipmentSlotC;
	%playerId.jamdetect = "false";
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

function LocationHit(%victimName,%killerName,%playerId,%killerId,%playerGender,%killerGender,%damageType,%killcontext)
{
	%ridx = floor(getRandom() * ($deathMsg[%damageType, $NumberOfDeathTypes,0] - 0.01));
	%vertPos = %playerId.damVert;
	%quadrant = %playerId.damQuad;
	
	if (%damageType == $TurretDamageType)
		{
			if (victimName == %killerName && %killcontext == $OWNE) %killerName = "" @ %killerGender @ " own"; 
				else %killerName = "" @ %killerName @ "'s";
		}
	%location = $TorsoFront;
	if (%vertPos == "head")
		{
			if (%quadrant == "back_right" || %quadrant == "back_left" || %quadrant == "middle_back") 
				{
					%location = $HeadBack; 
				} else 
				{
					%location = $HeadFront;
				}
		}
	if (%vertPos == "torso")
		{
			if (%quadrant == "back_right" || %quadrant == "back_left" || %quadrant == "middle_back")
				{
					%location = $TorsoBack;
				} else
				{
					%location = $TorsoFront;
				}
		}
	if (%vertPos == "legs")
		{
			if (%quadrant == "back_right" || %quadrant == "back_left" || %quadrant == "middle_back")
				{
					%location = $LegsBack;
				} else
				{
					%location = $LegsFront;
				}
		}

	%msg = sprintf($deathMsg[%damageType, %location + %killcontext,%ridx], %killerName, %victimName, %killerGender, %playerGender);
	%playerId.message = %msg;
}

function Client::onKilled(%playerId, %killerId, %damageType)
{
	echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male")) 
		{
			%playerGender = "his";
		} else
		{
			%playerGender = "her";
		}
	if(!String::ICompare(Client::getGender(%killerId), "Male")) 
		{
			%killerGender = "his";
		} else
		{
			%killerGender = "her";
		}

	%victimName = Client::getName(%playerId);
	%killerName = Client::getName(%killerId);

	if (!%killerId && %damageType != $TurretDamageType)
		{
			%playerId.message = "" @ %victimName @ " dies.";
			messageAll(0,"" @ %playerId.message @ "");
		} else if (%killerId == %playerId && %damageType != $TurretDamageType)
		{
			if (%damageType == $LandingDamageType || %damageType == $CrushDamageType || %damageType == $MissionAreaDamageType)
				{
					LocationHit(%victimName,%killerName,%playerId,%killerId,%playerGender,%killerGender,%damageType,$NORM);
				} else
				{
					if (%playerGender == "his") %playerId.message = "" @ %victimName @ " kills himself.";
						else %playerId.message = "" @ %victimName @ " kills herself.";
				}
			messageAll(0,"" @ %playerId.message @ "");
			if ($UseAdjustedScoring == "true")
				{
					if (%damageType != $LandingDamageType && %damageType != $CrushDamageType)
						{
							%playerId.selfKills++;
							%playerId.score -= %playerId.selfKills;
							if ($ShowScoreBonuses == "true") Client::sendMessage(%playerId, 0, "You lose " @ %playerId.selfKills @ " point(s) for killing yourself.");
						}
				} else
				{
					if (%damageType != $LandingDamageType && %damageType != $CrushDamageType)
						{
							%playerId.score--;
						}
				}
		} else if($teamplay && Client::getTeam(%killerId) == Client::getTeam(%playerId) && %damageType != $TurretDamageType)
		{
			if (%killerId != %playerId && %playerId.teamkiller == "true") 
				{
					bottomprint(%killerId, "<jc><f1>You have just killed the TEAM KILLER " @ %victimName @ ".", 1);
					LocationHit(%victimName,%killerName,%playerId,%killerId,%playerGender,%killerGender,%damageType,$TKER);
					messageAll(0,"" @ %playerId.message @ "");
					if($UseAdjustedScoring == "true")
						{
							%killerId.totalkills++;
							%killerId.score += (%playerId.TeamKills * 10);
							if ($ShowScoreBonuses == "true") Client::sendMessage(%killerId, 0, "You receive " @ (%playerId.TeamKills * 10) @ " point(s) for killing the Team Killer " @ %victimName @ ".");
						} else
						{
							%killerId.score++;
						}
					%playerId.TeamKills--;
					if (%playerId.TeamKills < 0) HCTK::TKOff(%playerId);
				} else
				{
					bottomprint(%playerId, "<jc><f1>You have just been TEAM KILLED by " @ %killerName @ ".", 1);
					if (%killerId != %playerId) bottomprint(%killerId, "<jc><f1>You have just TEAM KILLED " @ %victimName @ ".", 5);
					LocationHit(%victimName,%killerName,%playerId,%killerId,%playerGender,%killerGender,%damageType,$TKIT);
					messageAll(0,"" @ %playerId.message @ "");
					%killerId.TeamKills++;
					HCTK::CheckForTKer(%playerId);
					if ($UseAdjustedScoring == "true")
						{
							if (%playerId.carryFlag != "")
								{
									%pointval = %killerId.TeamKills + 25;
									%killerId.score -= %pointval;
									%killerId.defencebonus--;
									if (%killerId.defencebonus < 0) %killerId.defencebonus = 0;
									if ($ShowScoreBonuses == "true") Client::sendMessage(%killerId, 0, "You are penalized " @ %pointval @ " points for killing your own flag carrier.");
								} else 
								{
									%killerId.score -= %killerId.TeamKills;
									%killerId.defencebonus--;
									if (%killerId.defencebonus < 0) %killerId.defencebonus = 0;
									if ($ShowScoreBonuses == "true") Client::sendMessage(%killerId, 0, "You lose " @ %killerId.TeamKills @ " point(s) for killing your teammate.");
								}
						} else
						{
							%killerId.score--;
						}
				}
		} else
		{
			if (%damageType == $TurretDamageType && %killerId) LocationHit(%victimName,%killerName,%playerId,%killerId,%playerGender,%killerGender,%damageType,$OWNE); 
			else LocationHit(%victimName,%killerName,%playerId,%killerId,%playerGender,%killerGender,%damageType,$NORM);
			messageAll(0,"" @ %playerId.message @ "");
			if (%damageType == $TurretDamageType)
				{
					if ($UseAdjustedScoring == "true")
						{
							if (%killerId != %playerId)
								{
									%pointval = %playerId.totalkills + %playerId.defencebonus + %playerId.offencebonus + %killerId.defencebonus;
									if (%pointval <= 0) %pointval = 1;
									if (%playerId.carryFlag != "")
										{
											%killerId.FlagStops += %pointmod;
											%pointval += (%killerId.FlagStops * 5);
											if ($ShowScoreBonuses == "true") Client::sendMessage(%killerId, 0, "You receive " @ %pointval @ " point(s) for killing the enemy flag carrier.");
											%killerId.defencebonus += 2;
										} else 
										{
											if (%pointmod == 1)
												{
													if ($ShowScoreBonuses == "true") Client::sendMessage(%killerId, 0, "You receive " @ %pointval @ " point(s) for killing " @ %victimName @ ".");
													%killerId.defencebonus++;
												}
										}
									if (%pointval <= 0) %pointval = 1;
									%killerId.score += (%pointval * %pointmod);
								}
						}
				} else
				{
					%killerId.totalkills++;
					if ($UseAdjustedScoring == "true")
						{
							%pointval = %playerId.totalkills + %playerId.defencebonus + %playerId.offencebonus;
							if (%pointval <= 0) %pointval = 1;
							if (%playerId.carryFlag != "")
								{
									%killerId.FlagStops++;
									%pointval += (%killerId.FlagStops * 5);
									if ($ShowScoreBonuses == "true") Client::sendMessage(%killerId, 0, "You receive " @ %pointval @ " point(s) for killing the enemy flag carrier.");
									%killerId.offencebonus++;
									%killerId.defencebonus++;
								} else 
								{
									if ($ShowScoreBonuses == "true") Client::sendMessage(%killerId, 0, "You receive " @ %pointval @ " point(s) for killing " @ %victimName @ ".");
									%killerId.offencebonus++;
								}
							%killerId.score += %pointval;
						} else
						{
							%killerId.score++;
						}
				}
		} 

      if($Game::MissionType == "TideOfBattle") 
		{
			if (Client::getTeam(%killerId) != Client::getTeam(%playerId))
				{
			            $teamScore[Client::getTeam(%killerId)]++;
			            $teamScore[Client::getTeam(%playerId)]--;
				      GameBase::setTeam(%playerId, Client::getTeam(%killerId));
			            ObjectiveMission::checkScoreLimit();

					%allonteam = "true";
					%numPlayers = getNumClients();
					for(%i = 0; %i < %numPlayers; %i = %i + 1)
						{
							%id = getClientByIndex(%i);
							if(Client::getTeam(%id) != Client::getTeam(%killerId)) %allonteam = "false";
						}
					if(%allonteam == "true") ObjectiveMission::missionComplete();
				}
		}
	Game::refreshClientScore(%killerId);
	Game::refreshClientScore(%playerId);
	Game::clientKilled(%playerId, %killerId);
}

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


