exec("comchat.cs");


$SensorNetworkEnabled = true;

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
$DefaultTeamEnergy = -1;

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------

// $DefaultTeamEnergy
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
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 1;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 99999999;

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 70000;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 1;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 15;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 92500; 
$RemoteInvEnergy = 90000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = 0;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 0;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 50000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 2;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 20;	  //Define Min Length from another turret
$TurretBoxMinWidth =  20;	  //Define Min Width from another turret
$TurretBoxMinHeight = 15;    //Define Min Height from another turret

$MaxNumAntiMatterTurretsInBox = 1;     //Number of remote turrets allowed in the area
$AntiMatterTurretBoxMaxLength = 75;    //Define Max Length of the area
$AntiMatterTurretBoxMaxWidth =  75;    //Define Max Width of the area
$AntiMatterTurretBoxMaxHeight = 10;    //Define Max Height of the area

$AntiMatterTurretBoxMinLength = 40;	  //Define Min Length from another turret
$AntiMatterTurretBoxMinWidth =  40;	  //Define Min Width from another turret
$AntiMatterTurretBoxMinHeight = 10;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType		 = 1 << 26;	
$MoveableObjectType	 = 1 << 22;
$VehicleObjectType	 = 1 << 29;  
$StaticObjectType	 = 1 << 23;	   
$ItemObjectType		 = 1 << 21;	  

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
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %4 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %4 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 lead dispenser.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of pellet-sized holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";

$deathMsg[$BBDamageType, 0]      = "%1 puts a tiny hole in %2 with %3 trusty BB-Gun.";
$deathMsg[$BBDamageType, 1]      = "%1 puts out %2's eye with a shiny BB.";
$deathMsg[$BBDamageType, 2]      = "%1 gives %2 a nice shiny BB-Sized welt.";
$deathMsg[$BBDamageType, 3]      = "%1 was shooting for birds with his BB gun, but hit %2 instead.";

$deathMsg[$EnergyDamageType, 0]      = "%2 was seen by a mean motion turret.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 became commotose thanks to %1's concussion grenade.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a concussion grenade.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's concussion grenade made %2 bleed from the ears.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's concussion grenade.";
$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's shrapnel.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a shrapnel overdose.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 was mutilated by %1's shrapnel.";
$deathMsg[$LaserDamageType, 0]       = "%1 hits %2 with a cowardly ray.";
$deathMsg[$LaserDamageType, 1]       = "%2 sees the light - %1's cowardly red light.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's coward laser.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's cowardly crosshairs for too long.";
$deathMsg[$LavaDamageType, 0]       = "%1 hits %2 with a wad of molten rock.";
$deathMsg[$LavaDamageType, 1]       = "%2 screams in pain from %1's molten glory.";
$deathMsg[$LavaDamageType, 2]       = "%2 becomes a victim of %1's lavaball.";
$deathMsg[$LavaDamageType, 3]       = "%2 played with %1's ball of lava.";
$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's 9 volt battery.";
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
$deathMsg[$MissileDamageType, 0]	 = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]	 = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	 = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]	 = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 shows %2 why mining is a way of life.";
$deathMsg[$MineDamageType, 1]	       = "%2 steps on %1's mine.";
$deathMsg[$MineDamageType, 2]	       = "%1 tells %2, 'What's yours is mined.'";
$deathMsg[$MineDamageType, 3]	       = "%2 found %1's little present.";
$deathMsg[$FighterGunDamageType, 0]	       = "%2 is shredded by %1.";
$deathMsg[$FighterGunDamageType, 1]	       = "%2 gets a taste of %1's piercing personality.";
$deathMsg[$FighterGunDamageType, 2]	       = "%1 mows %2 down like a weed.";
$deathMsg[$FighterGunDamageType, 3]	       = "%2 couldn't run from %1's rain of fire.";
$deathMsg[$KamikazeDamageType, 0]	="%2's machinegun exploded.";
$deathMsg[$KamikazeDamageType, 1]	="%2's heavy machinegun went kablooey.";
$deathMsg[$KamikazeDamageType, 2]	="%2 was chopped up by exploding machinegun fragments.";
$deathMsg[$KamikazeDamageType, 3]	="%2's M2 ammo box exploded.";
$deathMsg[$ElectricDamageType, 0]    = "%2 meets the chair.";
$deathMsg[$ElectricDamageType, 1]    = "%2's death is reVOLTing.";
$deathMsg[$ElectricDamageType, 2]    = "%2 catches up with current affairs.";
$deathMsg[$ElectricDamageType, 3]    = "%2 finds the joy-buzzer from Hell.";
$deathMsg[$RocketDamageType, 0]	     = "%2 sucks down a rocket from %1.";
$deathMsg[$RocketDamageType, 1]	     = "%2 gets trashed by %1's rocket.";
$deathMsg[$RocketDamageType, 2]	     = "%1 shows %2 why fireworks are dangerous.";
$deathMsg[$RocketDamageType, 3]	     = "%2 feels the sting of %1's rocket.";
$deathMsg[$SniperDamageType, 0]	    = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1]	    = "%1 fells %2 with a sniper shot.";
$deathMsg[$SniperDamageType, 2]	    = "%1 snipes a hole through %2.";
$deathMsg[$SniperDamageType, 3]	    = "%1 punctures %2 with a sniper round.";
$deathMsg[$EMPDamageType, 0] = "%1 turns 2%'s brain into jello."; 
$deathMsg[$EMPDamageType, 1] = "%2 is frazzled to death by %1.";
$deathMsg[$EMPDamageType, 2] = "%2 is short-circuited by %1.";
$deathMsg[$EMPDamageType, 3] = "%2 buys it from %1's EMP blast."; 
$deathMsg[$PlasmaCannonDamageType, 0]	="''MOOO!'' says %2 to %1 after getting prodded.";
$deathMsg[$PlasmaCannonDamageType, 1]	="%2 became beef steak after meeting %1's cattle prod.";
$deathMsg[$PlasmaCannonDamageType, 2]	="%2 was milked by %1's cattle prod.";
$deathMsg[$PlasmaCannonDamageType, 3]	="%1 shoves a hot fire poker up %2's ass.";
$deathMsg[$FlameDamageType, 0]       = "%1 says to %2, 'Only I can prevent forest fires.'";
$deathMsg[$FlameDamageType, 1]       = "'Got a light?' says %2. 'Sure!' says %1.";
$deathMsg[$FlameDamageType, 2]       = "%2 dies of %1's second-hand smoke.";
$deathMsg[$FlameDamageType, 3]       = "%1 says to %2, 'You look like a flamer!'";
$deathMsg[$AntiMatterDamageType, 0]	="%2 thought anti-matter was good for you.";
$deathMsg[$AntiMatterDamageType, 1]	="%2 is obliterated by the small blue orb.";
$deathMsg[$AntiMatterDamageType, 2]	="%2 gets a taste of anti-matter.";
$deathMsg[$AntiMatterDamageType, 3]	="The anti-matter chars %2's butt.";
$deathMsg[$PoisonDamageType, 0]       = "%2 died of radiation poisoning.";
$deathMsg[$PoisonDamageType, 1]       = "%2 went hairless then died of cancer.";
$deathMsg[$PoisonDamageType, 2]       = "%2 dies from a potent x-ray.";
$deathMsg[$PoisonDamageType, 3]       = "%2 looked into the sun and died of radiation.";
$deathMsg[$ObeliskDamageType, 0]       = "The Obelisk hits %2 with a high-watt laser pointer.";
$deathMsg[$ObeliskDamageType, 1]       = "%2 sees the light - the Obelisk's red light.";
$deathMsg[$ObeliskDamageType, 2]       = "%2 gets zapped by the big stick.";
$deathMsg[$ObeliskDamageType, 3]       = "%2 heard the buzzing too late.";
$deathMsg[$SatchelDamageType, 0]       = "%1 got %2 real good that time.";
$deathMsg[$SatchelDamageType, 1]       = "%2 featured in %1's photo from Hell.";
$deathMsg[$SatchelDamageType, 2]       = "%1 tells %2, 'Gotcha!'";
$deathMsg[$SatchelDamageType, 3]       = "%2 found %1's little package.";
$deathMsg[$MinerDamageType, 0]	       = "That mine had %2's name on it.";
$deathMsg[$MinerDamageType, 1]	       = "%2 discovers the dangers of minefields.";
$deathMsg[$MinerDamageType, 2]	       = "'What do the little triangles do?' asks %2.";
$deathMsg[$MinerDamageType, 3]	       = "%2 stepped in the wrong place.";
$deathMsg[$BombDamageType, 0]      = "%1 bombs the snot out of %2.";
$deathMsg[$BombDamageType, 1]      = "%2 didn't get to the shelter in time.";
$deathMsg[$BombDamageType, 2]      = "%2 now sits in the bottom of a very deep crater.";
$deathMsg[$BombDamageType, 3]      = "'Bombs away!' yells %1 to %2.";
$deathMsg[$AdminKillDamageType, 0]      = "%1 got revenge on %2.";
$deathMsg[$AdminKillDamageType, 1]      = "%2 ticked %1 off too many times.";
$deathMsg[$AdminKillDamageType, 2]      = "%1 nuked %2.";
$deathMsg[$AdminKillDamageType, 3]      = "%2 gets a lesson about anti-social behavior from %1.";
$deathMsg[$DroneDamageType, 0]      = "%2 takes a drone up the keister.";
$deathMsg[$DroneDamageType, 1]      = "%2 didn't duck the Guided Bomb.";
$deathMsg[$DroneDamageType, 2]      = "%2 was wiped out by a flying turret.";
$deathMsg[$DroneDamageType, 3]      = "%2 was nailed from afar.";
$deathMsg[$SurpriseDamageType, 0]       = "'WTF?!' says %2.";
$deathMsg[$SurpriseDamageType, 1]       = "%2 is very confused by what just happened.";
$deathMsg[$SurpriseDamageType, 2]       = "%2 got a taste of %1's explosive modelling clay.";
$deathMsg[$SurpriseDamageType, 3]       = "%2 was vaporized by explosive play dough.";

$deathMsg[$BulletDmgType1, 0]      = "%1 piereces %2's head with %3 M4.";
$deathMsg[$BulletDmgType1, 1]      = "%1 piereces %2's spleen with %3 M4.";
$deathMsg[$BulletDmgType1, 2]      = "%1 piereces %2's lung with %3 M4.";
$deathMsg[$BulletDmgType1, 3]      = "%1 piereces %2's groin with %3 M4.";

$deathMsg[$BulletDmgType2, 0]      = "%2 got in the way of %1's Desert Eagle.";
$deathMsg[$BulletDmgType2, 1]      = "%1 punches a large hole through %2 with %3 Desert Eagle.";
$deathMsg[$BulletDmgType2, 2]      = "%1 gets a lucky shot on %2 with %3 Desert Eagle.";
$deathMsg[$BulletDmgType2, 3]      = "%1 puts down %2 with %3 50 Caliber Eagle.";

$deathMsg[$BulletDmgType3, 0]      = "%1 sprays %2 with %3 minigun.";
$deathMsg[$BulletDmgType3, 1]      = "%1 turns %2 into swiss cheese with %3 minigun.";
$deathMsg[$BulletDmgType3, 2]      = "%1 laced %2 with more minugun lead than %2 could handle.";
$deathMsg[$BulletDmgType3, 3]      = "%1 pinned %2 to the wall with %3 minigun.";

$deathMsg[$BulletDmgType4, 0]      = "%1 puts out %2's eye with %3 HK G36.";
$deathMsg[$BulletDmgType4, 1]      = "%1 iced %2 with %3 G36.";
$deathMsg[$BulletDmgType4, 2]      = "%1 played target practice with %2's lungs with %3 G36.";
$deathMsg[$BulletDmgType4, 3]      = "%1 mowed down %2 with %3 G36.";

$deathMsg[$BulletDmgType5, 0]      = "%1 punched a football sized hole through %2 with a sniper round.";
$deathMsg[$BulletDmgType5, 1]      = "%1 turns %2 inside-out with %3 armor piercing barett round.";
$deathMsg[$BulletDmgType5, 2]      = "%2 fell over dead before realizing %1 punched a hole through %4 chest.";
$deathMsg[$BulletDmgType5, 3]      = "%1 puts a bullet clean through %2 with a Barett sniper round.";

$deathMsg[$BulletDmgType6, 0]      = "%1 peppers %2 with %3 shotgun.";
$deathMsg[$BulletDmgType6, 1]      = "PULL! says %1, thinking %2 was a clay pigeon.";
$deathMsg[$BulletDmgType6, 2]      = "%1 turns %2 into a bloody mess with %3 shotgun.";
$deathMsg[$BulletDmgType6, 3]      = "%1 was shooting for birds with %3 shotgun, but %2 got in the way.";

$deathMsg[$BulletDmgType7, 0]      = "%1 punches a couple of baseball sized holes in %2 with %3 M60.";
$deathMsg[$BulletDmgType7, 1]      = "%1 knocked %2 down with an M60 round.";
$deathMsg[$BulletDmgType7, 2]      = "%1 blows %2 away with an M60 round.";
$deathMsg[$BulletDmgType7, 3]      = "%1 shows %2 %4 place with an M60 round.";

$deathMsg[$BulletDmgType8, 0]      = "%1 spams %2 with %3 MP5.";
$deathMsg[$BulletDmgType8, 1]      = "%1 bombards %2 with a barrage of MP5 bullets.";
$deathMsg[$BulletDmgType8, 2]      = "%1 showed %2 that you really can cause damage with an MP5.";
$deathMsg[$BulletDmgType8, 3]      = "%1 punctures %2's kidney with a few dozen MP5 rounds.";

$deathMsg[$BulletDmgType9, 0]      = "%2 gets cut in half by %1's claymore.";
$deathMsg[$BulletDmgType9, 1]      = "%2 can't find %4 legs thanks to %1's claymore.";
$deathMsg[$BulletDmgType9, 2]      = "%2 made a mess on the carpet after meeting %1's claymore.";
$deathMsg[$BulletDmgType9, 3]      = "%2 found %1's claymore and decided to play with it.";

$deathMsg[$StrikeDmgType, 0]      = "%2 got caught looking at the pretty planes.";
$deathMsg[$StrikeDmgType, 1]      = "%2 didn't hear the air raid siren.";
$deathMsg[$StrikeDmgType, 2]      = "%2 says 'Those planes are the bomb!'";
$deathMsg[$StrikeDmgType, 3]      = "%2 is in the bottom of a very large crater.";





// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]	 = "%1 falls over dead.";
$deathMsg[-2,1]	 = "%1 keels over.";
$deathMsg[-2,2]	 = "%1 finds %2 way to the afterlife.";
$deathMsg[-2,3]	 = "%1 shook hands with death.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = PlasmaGun;
$spawnBuyList[2] = RepairKit;
$spawnBuyList[3] = RepairPack;
$spawnBuyList[4] = TargetingLaser;
$spawnBuyList[5] = ChainGun;
$spawnBuyList[6] = DiscLauncher;
$spawnBuyList[7] = RepairGrenade;
$spawnBuyList[8] = "AntipersonelMine";
$spawnBuyList[9] = "";



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
   // can't switch to command mode while a server menu is up or under the effect of the Chameleon Device
   if((!%clientId.guiLock) && (%clientId.traitor != 1))
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
	$GrenadeIsSmoking = 0; // Fix a bug where grenades wont smoke if playing single player
	$matchStarted = true;
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");
	Game::resetScores();	

	if($Server::Truce)
	{
		if(!$Server::InitialTruce)
			$Server::InitialTruce = 3;
		if($Server::InitialTruce > 10)
			$Server::InitialTruce = 10;
	}

	exec("ai");

	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
    	}

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
		{
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
			Combat::WarnTruce(%cl);
		}
		Game::refreshClientScore(%cl);
		$PlayerItemCount[%cl @ DecoyPack] = 0;
		
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
		Combat::WarnTruce(%clientId);
		
		
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

		$TeleSpot[Client::getTeam(%clientId)] = %spawnPos;

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
			%armor = "larmor";
		else
			%armor = "lfemale";

		%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
		echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);

		%clientId.killspree = 0;

	//Check for spawn protection

	%clientId.Stilldead = 0;
	%clientId.idletime = 0;

	if ($rb::spawnprotection >= 1)
	{
	$spawnprotect[%clientId] = true;
	schedule("$spawnprotect[" @ %clientId @ "] = false;",$rb::spawnprotection);
	Player::FlashGordon(%ClientId);
	}

		if(%pl != -1)
		{
			GameBase::setTeam(%pl, Client::getTeam(%clientId));
			Client::setOwnedObject(%clientId, %pl);
			Game::playerSpawned(%pl, %clientId, %armor, %respawn);

			if(%clientId.badaim == 1)
				schedule("player::checkLOS(" @ %pl @ ", " @ %clientId @ ");", 0.5);


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
    	else
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
		return false;
    	}
}

//Function to check if we can shoot stuff by moving over it - Used for ELF gun & ELF Turrets
function player::checkLOS(%this, %clientId)
{

	if(%clientId.badaim == 1 || !Player::isDead(%this))
	schedule("player::checkLOS(" @ %this @ ", " @ %clientId @ ");", 0.2);

	if (GameBase::getLOSInfo(%this,800)) 
	{
	%obj = getObjectType($los::object);
	%angle = GameBase::getLOSInfo(%this,10);
	%rot = Vector::getRotation($los::normal); 
	}

	if(%obj == "Player" || %obj == "Turret")
	{
			Player::trigger(%this,4,true);    
			Player::trigger(%this,4,false);   
			Player::trigger(%this,$weaponslot,true);    
			Player::trigger(%this,$weaponslot,false);   
			Player::trigger(%clientId,4,true);    
			Player::trigger(%clientId,4,false);   
			Player::trigger(%clientId,$weaponslot,true);    
			Player::trigger(%clientId,$weaponslot,false);   
	// client::sendmessage(%clientId, 1, "object: " @ %obj @ " rot = " @ %rot);
	}		
	// client::sendmessage(%clientId, 0, "object: " @ %obj @ " rot = " @ %rot);

}





//function to flash a player when they're invincible

function Player::FlashGordon(%clientId)
{

%rnd = floor(getRandom() * 5);
if (%rnd == 0)
	client::setskin(%clientId, blue);
if (%rnd == 1)
	client::setskin(%clientId, purple);
if (%rnd == 2)
	client::setskin(%clientId, green);
if (%rnd == 3)
	client::setskin(%clientId, orange);
if (%rnd == 4)
	client::setskin(%clientId, base);
if (%rnd == 5)
	client::setskin(%clientId, blue);

 if ($spawnprotect[%clientId] == true)
	schedule("Player::FlashGordon(" @ %clientId @ ");",0.1);
 else
        Client::setSkin(%clientId, $Client::info[%clientId, 0]);

// Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);

}






function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	if(%clientId.custom)
	{
		echo ("Setting user skin for player " @ %clientId @ ": " @ $Client::info[%clientId, 0]);
    	        Client::setSkin(%clientId, $Client::info[%clientId, 0]);
    	}

	%clientId.spawn= 1;
	%max = getNumItems();
	for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
	{
		buyItem(%clientId,%item);	
		if(%item.className == Weapon || %item.className == PriWeapon) 
			%clientId.spawnWeapon = %item;
	}

	%clientId.spawn= "";
	if(%clientId.spawn != 1)
	{
		Player::useItem(%clientId,%clientId.spawnWeapon);	
		// %clientId.spawnWeapon="Blaster";
   		Player::setItemCount(%clientId,$ArmorName[%armor],1);
   		Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
   		Player::setItemCount(%clientId,SPAS,1);
   		Player::setItemCount(%clientId,RepairKit,1);
   		Player::setItemCount(%clientId,EagleAmmo,50);
   		Player::setItemCount(%clientId,SPASAmmo,20);
		Player::useItem(%clientId,Blaster);

			// %item = newObject("","Item","OriginalGrenade",1,false);
			// schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
			// addToSet("MissionCleanup", %item);
			// GameBase::setPosition(%item,GameBase::getPosition(%clientId));
		 
	}

// -----------------EXPERIMENTAL SPAWN STATION CODE!!!  -- I failed at this, so Im gonna just do spawn favorites

		// SpawnResupply(%clientId);

favoriteSpawnList(%clientId); //what a pain in my ass to get this to work...


	%clientId.spawn = 1;
	%max = getNumItems();

	for(%i = 0; (%item = $spawnBuyList[%i, %clientId]) != ""; %i++)
	{
		buyItem(%clientId,%item);
		if(%item.className == Weapon || %item.className == PriWeapon) 
			%clientId.spawnWeapon = %item;
		if ($Debug) echo ("Buying = " @ %item);
	}
	for (%i = 0; %i < 6; %i++)
	{
		buyItem(%clientId,"Beacon");
		buyItem(%clientId,"Grenade");
		buyItem(%clientId,"MineAmmo");
	}

	%clientId.spawn = "";

	if(%clientId.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);
		%armor = Player::getArmor(%clientId);
		%clientId.spawnWeapon="";
	}

      	// return true;







// ---------------==End of uberexperimental spawn station code.....


	%clientId.passenger = 0;
	%clientId.traitor = 0;
	%clientId.pacified = 0;
	%clientId.scrambled = 0;
	$pacified[%clientId] = 0;
	$scrambled[%clientId] = 0;
	$shieldTime[%clientId] = 0;
	$empTime[%clientId] = 0;
	$poisonTime[%clientId] = 0;
	$scrambleTime[%clientId] = 0;

	%clientId.invulnerable = 0;
	schedule(%clientId@".invulnerable = 0;",1);
} 

// Borrowed from shifter since my spawn with station code failed kinda miserably

function favoriteSpawnList(%clientId) //borrowed from shifter and modified to fit my mod
{
	%Client = %ClientId;
		
	if (%clientId.favsettings)
	{

			%error = 0;
			%max = getNumItems();
			
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%item = getItemData(%i);
				%count = Player::getItemCount(%clientId,%item);
				
				if(%count)
				{
					
					if(%item.className != Armor)
					teamEnergyBuySell(Client::getOwnedObject(%clientId),(%item.price * %count));
					Player::setItemCount(%clientId, %item, 0);  
				}
			}
			
			if ($debug) echo ("Buying New");

			for (%i = 0; %i <= 19; %i++)
			{
				if(%clientId.fav[%i] != "")
				{
					%item = getItemData(%clientId.fav[%i]);
					
					// Player::setItemCount(%clientId,$ArmorName[%armor],1);
					

					// make sure we still buy ammo for this item. *****************
					%player = Client::getOwnedObject(%clientId);
					%armor = Player::getArmor(%clientId);
					// Player::setItemCount(%clientId,%item,$itemmax[%armor, %item]);
					

										//     ****************
					if (%i == 0)
					{
						$fa_armor = %item.description;
					}
					$spawnBuyList[%i, %clientId] = %item;
				}
		  	}
		
	}
}



//  End of borrowed code





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
		schedule("bottomprint(" @ %clientId @ ", $JoinMessage, 30);", 1);
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
		if((%clientId.justConnected))
		{
			centerprint(%clientId, $Server::JoinMOTD, 5);
			schedule("centerprint(" @ %clientId @ ", $JoinMessage, 30);", 2);
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

	schedule("centerprint(" @ %playerId @ ", $JoinMessage, 30);", 5);


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
	if(%client == "") 
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
		{
			%cl.scoreKills = 0;
			%cl.scoreheadshots = 0;
			%cl.scoremusketkills = 0;
			%cl.scoreDeaths = 0;
			%cl.turretsDeployed = 0;
			%cl.ratio = 0;
			%cl.score = 0;
			%cl.spawndelay = 0;
			%cl.buddy = 0;
		}
	}
	else
	{
			%client.turretsDeployed = 0;
			%client.scoreheadshots = 0;
			%client.scoremusketkills = 0;
		%client.scoreKills = 0;
		%client.scoreDeaths = 0;
		%client.ratio = 0;
		%client.score = 0;
		%client.spawndelay = 0;
		%client.buddy = 0;
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
	%playerId.turretsdeployed = 0;
	%playerId.ismuted = 0;
	%playerId.scoreheadshots = 0;
	%playerId.scoremusketkills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.teamkills = 0;
	%playerId.disablehelp = 0;
	%playerId.spawndelay = 0;
	%playerId.justConnected = true;
	$PlayerItemCount[%playerId @ DecoyPack] = 0;
	$menuMode[%playerId] = "None";
	Game::refreshClientScore(%playerId);
	// schedule("centerprint(" @ %playerId @ ", $JoinMessage, 30);", 3);
}

function Game::assignClientTeam(%playerId)
{
	schedule("centerprint(" @ %playerId @ ", $JoinMessage, 30);", 5);
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

function Client::onKilled(%playerId, %killerId, %damageType)
{
	echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);

	
 	if(%killerId != %playerId && Client::getName(%killerId) != "") //make sure you dont get points for suiciding it -- Deadtaco
	{
	%killerId.score += $ScorePoints[%damageType];
	%killerId.killspree++;

	//Add some killing spree bonuses to make you look cool :)

	   if (%damagetype != $minedamagetype && %damagetype != $bulletdmgtype11)
	   {
		if (%killerId.killspree == 5)
		{
		messageAll(1, Client::getName(%killerId) @ " is on a killing spree! ~wenergypackon.wav");
		messageAll(1, Client::getName(%killerId) @ " is on a killing spree! ~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wplasma2.wav");
		}
		if (%killerId.killspree == 10)
		{
		messageAll(1, Client::getName(%killerId) @ " is unstoppable!");
		messageAll(1, Client::getName(%killerId) @ " is unstoppable!");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wplasma2.wav");
		}

		if (%killerId.killspree == 15)
		{
		messageAll(1, Client::getName(%killerId) @ " IS A GOD!");
		messageAll(1, Client::getName(%killerId) @ " IS A GOD!");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wplasma2.wav");
		}	

		if (%killerId.killspree == 20)
		{
		messageAll(1, Client::getName(%killerId) @ " obviously plays too much tribes.");
		messageAll(1, Client::getName(%killerId) @ " obviously plays too much tribes.");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wenergypackon.wav");
		messageAll(1, "~wplasma2.wav");
		}
  	    }

		// Let's end someone's killing spree!
		if (%playerId.killspree >=5)
		{
		messageAll(1, Client::getName(%killerId) @ " ended " @ Client::getName(%playerId) @ "'s killing spree. ~wc_buysell.wav");
		messageAll(1, "~wfloat_target.wav");

		%killerId.score += 10 + %playerId.killspree;
		schedule("bottomprint(" @ %killerId @ ", \"<jc><f2>You gain a bonus for ending someone's killing spree.\", 3);", 1.5);
		%playerId.killspree = 0;
		}

		bottomprint(%killerId, "<jc><f2>Kill Worth " @ $ScorePoints[%damageType] @ " points.  You now have " @ %killerId.score @ " points. \n\n\n\n", 3);
		Game::refreshClientScore(%killerId);
		echo("GAME: score " @ %killerId @ " is at " @ %KillerId.scoreKills);
	}
	else
	{
	bottomprint(%killerId, "<jc><f2>You lost 5 points for self-inflicted stupidity. \n\n\n\n", 3);
	%killerId.score += -4;
	}

 	if(%killerId == %playerId && %killerId.killspree >= 5) //make sure you dont get points for suiciding it -- Deadtaco
	{
	messageAll(1, Client::getName(%killerId) @ " ended his own killing spree ~wc_buysell.wav");
	}

	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Female"))
	{
		%playerGender = "her";
	}
	else
	{
		%playerGender = "his";
	}
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);

	if(!%killerId || Client::getName(%killerId) == "")
	{
		%knowncause = 0;
		%killerName = 0;
		%killerGender = 0;
		if (%damageType == $LandingDamageType || %damageType == $EnergyDamageType || %damageType == $CrushDamageType || %damageType == $DebrisDamageType || %damageType == $MissileDamageType || %damageType == $AntiMatterDamageType || %damageType == $KamikazeDamageType || %damageType == $DroneDamageType)
			%knowncause =1;
		else if (%damageType == $LaserDamageType)
		{
			%damageType = $ObeliskDamageType;
			%knowncause =1;
		}
		else if (%damageType == $ElectricityDamageType)
		{
			%damageType = $ElectricDamageType;
			%knowncause =1;
		}
		else if (%damageType == $MineDamageType)
		{
			%damageType = $MinerDamageType;
			%knowncause =1;
		}
		else if (%damageType == $SatchelDamageType)
		{
			%damageType = $SurpriseDamageType;
			%knowncause =1;
		}
		else if (%damageType == $BBDamageType || %damageType == $BulletDamageType || %damageType == $PlasmaDamageType || %damageType == $ExplosionDamageType || %damageType == $ShrapnelDamageType || %damageType == $MortarDamageType || %damageType == $BlasterDamageType || %damageType == $RocketDamageType || %damageType == $PlasmaCannonDamageType || %damageType == $BulletDmgType1 || %damageType == $BulletDmgType2 || %damageType == $BulletDmgType3 || %damageType == $BulletDmgType4 || %damageType == $BulletDmgType5 || %damageType == $BulletDmgType6 || %damageType == $BulletDmgType7 || %damageType == $BulletDmgType8 || %damageType == $BulletDmgType9)
		{
			%killername = "Someone";
			%killerGender = "his";
			%knowncause =1;
		}
		else if (%damageType == 25)
		{
			%damageType = 26;
			%knowncause = 1;
		}
		if (!%knowncause)
			messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], %killerName, %victimName, %killerGender, %playerGender);
			messageAll(0, %obitMsg, $DeathMessageMask);
		}
		%playerId.scoreDeaths++;

		if($Server::TourneyMode)
		{
			%playerId.spawndelay++;
			if (%playerId.spawndelay > ($Server::respawnTime))
				%playerId.spawndelay = ($Server::respawnTime);
		}
		Game::refreshClientScore(%playerId);
	}
	else if(%killerId == %playerId)
	{
		if(%damageType == $LandingDamageType)
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], 0, %victimName, 0, %playerGender);
			messageAll(0, %obitMsg, $DeathMessageMask);
		}
		else
		{
			%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
			messageAll(0, %oopsMsg, $DeathMessageMask);
		}
		%playerId.scoreDeaths++;
		%playerId.score--;
		if($Server::TourneyMode)
		{
			%playerId.spawndelay++;
			if (%playerId.spawndelay > ($Server::respawnTime))
				%playerId.spawndelay = ($Server::respawnTime);
		}
		Game::refreshClientScore(%playerId);
	}
	else
	{
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
			%killerGender = "his";
		else
			%killerGender = "her";
		if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)) && %damageType != $AdminKillDamageType)
		{
			if(%damageType != $MineDamageType) 
				messageAll(0, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName, "."), $DeathMessageMask);
			else 
				messageAll(0, strcat(Client::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName,", with a mine."), $DeathMessageMask);
			if ($WasOnlyBot[%playerId] == 1)
			{
				messageAll(0, "Don't worry. It was only a Bot.", $DeathMessageMask);
			   	$WasOnlyBot[%playerId] = 0;
			}
			else
			{
			messageAll(0, strcat(Client::getName(%killerId), " loses points for team-killing a fellow player!"), $DeathMessageMask);
			%killerId.score -= $ScorePoints[%damageType];
			%killerId.score -= $ScorePoints[%damageType];
			%killerId.score -= $ScorePoints[%damageType];
			Game::refreshClientScore(%killerId);
			echo("GAME: score " @ %killerId @ " is at " @ %KillerId.scoreKills);



				Game::refreshClientScore(%killerId);
				%killerId.teamkills++;
				bottomprint(%killerId, "<jc><f2>YOU TEAM KILLED!  You lose " @ ($ScorePoints[%damageType] * 2) @ " points.  You now have " @ %killerId.score @ " points. \n\n\n", 5);

				if (%killerId.teamkills == 3)
					messageAll(0, strcat(Client::getName(%killerId), " has team-killed twice and can now be killed from the <TAB> menu."), $DeathMessageMask);
				else if (%killerId.teamkills == 5)
					messageAll(0, strcat(Client::getName(%killerId), " has team-killed five times and can now be kicked from the <TAB> menu."), $DeathMessageMask);
				else if (%killerId.teamkills >= 6)
					messageAll(0, strcat(Client::getName(%killerId), " has team-killed more than three times and can now be banned from the <TAB> menu."), $DeathMessageMask);
			}
		}
		else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
			messageAll(0, %obitMsg, $DeathMessageMask);
			if (%damageType != $AdminKillDamageType)
			{
				%killerId.scoreKills++;
				%playerId.scoreDeaths++;  // test play mode
				%killerId.score++;
				if($Server::TourneyMode)
				{
					%playerId.spawndelay++;
					if (%playerId.spawndelay > ($Server::respawnTime))
						%playerId.spawndelay = ($Server::respawnTime);
				}
				Game::refreshClientScore(%killerId);
				Game::refreshClientScore(%playerId);
			}
		}
	}
	if(%damageType > 13)
		echo("ADMINMSG: **** Death from " @ $DamageDescription[%damageType]);
   	$WasOnlyBot[%playerId] = 0;
	%playerId.killspree = 0;
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

function Player::leaveMissionArea(%player)
{
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have left the battle area.");
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
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
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

function Combat::WarnTruce(%client)
{
	if($Combat::AlreadyWarned[%client])
	{
		$Combat::AlreadyWarned[%client] = false;
		return;
	}
	else
		$Combat::AlreadyWarned[%client] = true;

	if(($Game::missionType == "CTF" || $Game::missionType == "CTFb") && $Server::InitialTruce > 0 && $Server::Truce)
	{
		echo("Initial Truce Time = " @ $Server::InitialTruce);
		echo("Mission Start Time = " @ $missionStartTime);
		echo("Current Time = " @ getSimTime());

		%time = $Server::InitialTruce - floor((getSimTime() - $missionStartTime)/ 60) + 1;
		%time = 0;
		if(%time > 0)
		{
			Client::sendMessage(%client,0,"A truce has been declared for "@ %time @" minute(s).");
			Client::sendMessage(%client,0,"You may NOT touch the enemy mainframe during a truce!~wLeftMissionArea.wav");
		}
	}
}

