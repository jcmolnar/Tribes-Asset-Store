

//---------------------------------------------------------------------------------
// Eradication Global Variables
//---------------------------------------------------------------------------------

$EradicationVersion = "1.4";
$Eradication::minSize = 1;
$Eradication::hazeFactor = 0.1;

if ($Eradication::leaveMissionAreaResult == "")
	$Eradication::leaveMissionAreaResult = "Catapult";
if ($Eradication::leaveMissionAreaTime == "")
	$Eradication::leaveMissionAreaTime = 3;

if($Eradication::SpawnWith[0] != "") {
	%i=0;
	while($Eradication::SpawnWith[%i] != "") {
		$spawnBuyList[%i] = $Eradication::SpawnWith[%i];
		%i++;
	}
	$spawnBuyList[%i] = "";
}	
else {
	$spawnBuyList[0] = MediumArmor;
	$spawnBuyList[1] = DiscLauncher;
	$spawnBuyList[2] = AutoBlaster;
	$spawnBuyList[3] = Shotgun;
	$spawnBuyList[4] = RepairKit;
	$spawnBuyList[5] = Grenade;
	$spawnBuyList[6] = "";
}

if($Eradication::repairGunAutoRemount == "")
	$Eradication::repairGunAutoRemount = false;

if($Eradication::noAmmoNextWeapon == "")
	$Eradication::noAmmoNextWeapon = false;

if($Eradication::showDeathMessages == "")
	$Eradication::showDeathMessages = true;

if($Eradication::showBroadcastScore == "")
	$Eradication::showBroadcastScore = true;

if($Eradication::showDestructionMessages == "")
	$Eradication::showDestructionMessages = true;

if($Eradication::stationKick == "")
	$Eradication::stationKick = true;

if($Eradication::stationKickTime == "")
	$Eradication::stationKickTime = 10;

if($Eradication::tkBan == "")
	$Eradication::tkBan = true;

if($Eradication::tkWarningLimit == "")
	$Eradication::tkWarningLimit = 2;

if($Eradication::tkBanLimit == "")
	$Eradication::tkBanLimit = 3;

if($Eradication::deflagDisarm == "")
	$Eradication::deflagDisarm = true;

if($Eradication::eradicationTurrets == "")
	$Eradication::eradicationTurrets = true;

$LoserListCount = 0;
for(%i=0; %i < 2000; %i++)
	$LoserList[%i] = "";

//---------------------------------------------------------------------------------
// Damage Type Global Variables
//---------------------------------------------------------------------------------

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;
$SensorSlot=4;
$MineSlot=5;
$RepairKitSlot=6;
$MarkerSlot=7;


//---------------------------------------------------------------------------------
// Damage Type Global Variables
//---------------------------------------------------------------------------------

# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
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

//---------------------------------------------------------------------------------
// Message Type Global Variables
//---------------------------------------------------------------------------------

$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

//---------------------------------------------------------------------------------
// Voting Global Variables
//---------------------------------------------------------------------------------

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

//---------------------------------------------------------------------------------
// Game.cs
//---------------------------------------------------------------------------------

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

$SensorNetworkEnabled = true;
$WaitThrowTime = 2;

if($Eradication::flagToStandTime != "")
	$flagToStandTime = $Eradication::flagToStandTime;	  
else	  
	$flagToStandTime = 180;	  
if($Eradication::ItemRespawnTime != "")
	$ItemRespawnTime = $Eradication::ItemRespawnTime;	  
else	  
	$ItemRespawnTime = 30;
if($Eradication::RemoteAmmoEnergy != "")
	$RemoteAmmoEnergy = $Eradication::RemoteAmmoEnergy;	  
else	  
	$RemoteAmmoEnergy = 2500; 
if($Eradication::RemoteInvEnergy != "")
	$RemoteInvEnergy = $Eradication::RemoteInvEnergy;	  
else	  
	$RemoteInvEnergy = 3000;
if($Eradication::AutoRespawn != "")
	$AutoRespawn = $Eradication::AutoRespawn;	  
else	  
	$AutoRespawn = 0;	  
if($Eradication::DefaultTeamEnergy != "")
	$DefaultTeamEnergy = $Eradication::DefaultTeamEnergy;	  
else	  
	$DefaultTeamEnergy = "Infinite";

$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

if($Eradication::MaxTeamEnergy != "")
	$MaxTeamEnergy = $Eradication::MaxTeamEnergy;	  
else	  
	$MaxTeamEnergy = 700000;

$incTeamEnergy = 700;
$secTeamEnergy = 30;
$TeammateSpending = -4000; 
$WarnEnergyLow = 4000;
$InitialPlayerEnergy = 5000;

$MaxNumTurretsInBox = 2;
$TurretBoxMaxLength = 40;
$TurretBoxMaxWidth =  40;
$TurretBoxMaxHeight = 20;
$TurretBoxMinLength = 10;
$TurretBoxMinWidth =  10;
$TurretBoxMinHeight = 10;

$CorpseTimeoutValue = 22;
$flagReturnTime = 45;
$ItemPopTime = 30;

$ItemFavoritesKey = "";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.


$SimTerrainObjectType = 1 << 1;
$SimInteriorObjectType = 1 << 2;
$SimPlayerObjectType = 1 << 7;
$MineObjectType = 1 << 26;	
$MoveableObjectType = 1 << 22;
$VehicleObjectType = 1 << 29;  
$StaticObjectType	= 1 << 23;	   
$ItemObjectType = 1 << 21;	  

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------

$numDeathMsgs = 4;

$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0]      = "%2 gets new air-conditioning installed.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";
$deathMsg[$EnergyDamageType, 0]      = "%2 gets cooked in %4 armor.";
$deathMsg[$EnergyDamageType, 1]      = "%2 meets Betty Crocker.";
$deathMsg[$EnergyDamageType, 2]      = "%2 is now a puddle on the battlefield.";
$deathMsg[$EnergyDamageType, 3]      = "%2 winds up a pile of smoking remains.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 gets %4 sphincter stretched.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 gives %2 a well-placed blast.";
$deathMsg[$ExplosionDamageType, 2]   = "%1 gives it to %2 in an uncomfortable place.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 gets %4 armor ventilated for free.";
$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";
$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]       = "%1 uses %2 for target practice.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$MortarDamageType, 0]      = "%1 blows %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 flies into many pieces.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts big pain on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1 blows %2 into many pieces.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's blaster bolt shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 learns to fear %1's mighty blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped by %1.";
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
$deathMsg[$MissileDamageType, 0]	    = "%2 takes it in the keister.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	    = "%2 takes it in midair.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";
$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

//---------------------------------------------------------------------------------
// death animations
//---------------------------------------------------------------------------------

$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//---------------------------------------------------------------------------------
// Team Item Max Variables
//---------------------------------------------------------------------------------

if($Eradication::TeamItemMax[DeployableInvPack] != "")
	$TeamItemMax[DeployableInvPack] = $Eradication::TeamItemMax[DeployableInvPack];	  
else	  
	$TeamItemMax[DeployableInvPack] = 5;
if($Eradication::TeamItemMax[DeployableAmmoPack] != "")
	$TeamItemMax[DeployableAmmoPack] = $Eradication::TeamItemMax[DeployableAmmoPack];	  
else	  
	$TeamItemMax[DeployableAmmoPack] = 7;
if($Eradication::TeamItemMax[BarrierPack] != "")
	$TeamItemMax[BarrierPack] = $Eradication::TeamItemMax[BarrierPack];	  
else	  
	$TeamItemMax[BarrierPack] = 10;
if($Eradication::TeamItemMax[StackableCratePack] != "")
	$TeamItemMax[StackableCratePack] = $Eradication::TeamItemMax[StackableCratePack];	  
else	  
	$TeamItemMax[StackableCratePack] = 25;
if($Eradication::TeamItemMax[SuspendedPlatformPack] != "")
	$TeamItemMax[SuspendedPlatformPack] = $Eradication::TeamItemMax[SuspendedPlatformPack];	  
else	  
	$TeamItemMax[SuspendedPlatformPack] = 5;
if($Eradication::TeamItemMax[LargeDecoyTurretPack] != "")
	$TeamItemMax[LargeDecoyTurretPack] = $Eradication::TeamItemMax[LargeDecoyTurretPack];	  
else	  
	$TeamItemMax[LargeDecoyTurretPack] = 2;
if($Eradication::TeamItemMax[MediumDecoyTurretPack] != "")
	$TeamItemMax[MediumDecoyTurretPack] = $Eradication::TeamItemMax[MediumDecoyTurretPack];	  
else	  
	$TeamItemMax[MediumDecoyTurretPack] = 3;
if($Eradication::TeamItemMax[SmallDecoyTurretPack] != "")
	$TeamItemMax[SmallDecoyTurretPack] = $Eradication::TeamItemMax[SmallDecoyTurretPack];	  
else	  
	$TeamItemMax[SmallDecoyTurretPack] = 4;
if($Eradication::TeamItemMax[AutoPlasmaTurretPack] != "")
	$TeamItemMax[AutoPlasmaTurretPack] = $Eradication::TeamItemMax[AutoPlasmaTurretPack];	  
else	  
	$TeamItemMax[AutoPlasmaTurretPack] = 2;
if($Eradication::TeamItemMax[BlasterTurretPack] != "")
	$TeamItemMax[BlasterTurretPack] = $Eradication::TeamItemMax[BlasterTurretPack];	  
else	  
	$TeamItemMax[BlasterTurretPack] = 3;
if($Eradication::TeamItemMax[ChaingunTurretPack] != "")
	$TeamItemMax[ChaingunTurretPack] = $Eradication::TeamItemMax[ChaingunTurretPack];	  
else	  
	$TeamItemMax[ChaingunTurretPack] = 2;
if($Eradication::TeamItemMax[DiscTurretPack] != "")
	$TeamItemMax[DiscTurretPack] = $Eradication::TeamItemMax[DiscTurretPack];	  
else	  
	$TeamItemMax[DiscTurretPack] = 1;
if($Eradication::TeamItemMax[FusionTurretPack] != "")
	$TeamItemMax[FusionTurretPack] = $Eradication::TeamItemMax[FusionTurretPack];	  
else	  
	$TeamItemMax[FusionTurretPack] = 1;
if($Eradication::TeamItemMax[GrenadeTurretPack] != "")
	$TeamItemMax[GrenadeTurretPack] = $Eradication::TeamItemMax[GrenadeTurretPack];	  
else	  
	$TeamItemMax[GrenadeTurretPack] = 1;
if($Eradication::TeamItemMax[LaserTurretPack] != "")
	$TeamItemMax[LaserTurretPack] = $Eradication::TeamItemMax[LaserTurretPack];	  
else	  
	$TeamItemMax[LaserTurretPack] = 2;
if($Eradication::TeamItemMax[EnergyVortexPack] != "")
	$TeamItemMax[EnergyVortexPack] = $Eradication::TeamItemMax[EnergyVortexPack];	  
else	  
	$TeamItemMax[EnergyVortexPack] = 1;
if($Eradication::TeamItemMax[EnergyFieldGeneratorPack] != "")
	$TeamItemMax[EnergyFieldGeneratorPack] = $Eradication::TeamItemMax[EnergyFieldGeneratorPack];	  
else	  
	$TeamItemMax[EnergyFieldGeneratorPack] = 1;
if($Eradication::TeamItemMax[CameraPack] != "")
	$TeamItemMax[CameraPack] = $Eradication::TeamItemMax[CameraPack];	  
else	  
	$TeamItemMax[CameraPack] = 15;
if($Eradication::TeamItemMax[DeployableSensorJammerPack] != "")
	$TeamItemMax[DeployableSensorJammerPack] = $Eradication::TeamItemMax[DeployableSensorJammerPack];	  
else	  
	$TeamItemMax[DeployableSensorJammerPack] = 8;
if($Eradication::TeamItemMax[MotionSensorPack] != "")
	$TeamItemMax[MotionSensorPack] = $Eradication::TeamItemMax[MotionSensorPack];	  
else	  
	$TeamItemMax[MotionSensorPack] = 15;
if($Eradication::TeamItemMax[PulseSensorPack] != "")
	$TeamItemMax[PulseSensorPack] = $Eradication::TeamItemMax[PulseSensorPack];	  
else	  
	$TeamItemMax[PulseSensorPack] = 15;
if($Eradication::TeamItemMax[Beacon] != "")
	$TeamItemMax[Beacon] = $Eradication::TeamItemMax[Beacon];	  
else	  
	$TeamItemMax[Beacon] = 40;
if($Eradication::TeamItemMax[MineAmmo] != "")
	$TeamItemMax[MineAmmo] = $Eradication::TeamItemMax[MineAmmo];	  
else	  
	$TeamItemMax[MineAmmo] = 50;
if($Eradication::TeamItemMax[LightArmor] != "")
	$TeamItemMax[LightArmor] = $Eradication::TeamItemMax[LightArmor];	  
else	  
	$TeamItemMax[LightArmor] = 50;
if($Eradication::TeamItemMax[MediumArmor] != "")
	$TeamItemMax[MediumArmor] = $Eradication::TeamItemMax[MediumArmor];	  
else	  
	$TeamItemMax[MediumArmor] = 50;
if($Eradication::TeamItemMax[HeavyArmor] != "")
	$TeamItemMax[HeavyArmor] = $Eradication::TeamItemMax[HeavyArmor];	  
else	  
	$TeamItemMax[HeavyArmor] = 50;
if($Eradication::TeamItemMax[CommandArmor] != "")
	$TeamItemMax[CommandArmor] = $Eradication::TeamItemMax[CommandArmor];	  
else	  
	$TeamItemMax[CommandArmor] = 2;
if($Eradication::TeamItemMax[SupportArmor] != "")
	$TeamItemMax[SupportArmor] = $Eradication::TeamItemMax[SupportArmor];	  
else	  
	$TeamItemMax[SupportArmor] = 50;
if($Eradication::TeamItemMax[ScoutVehicle] != "")
	$TeamItemMax[ScoutVehicle] = $Eradication::TeamItemMax[ScoutVehicle];	  
else	  
$TeamItemMax[ScoutVehicle] = 3;
if($Eradication::TeamItemMax[HAPCVehicle] != "")
	$TeamItemMax[HAPCVehicle] = $Eradication::TeamItemMax[HAPCVehicle];	  
else	  
	$TeamItemMax[HAPCVehicle] = 1;
if($Eradication::TeamItemMax[LAPCVehicle] != "")
	$TeamItemMax[LAPCVehicle] = $Eradication::TeamItemMax[LAPCVehicle];	  
else	  
	$TeamItemMax[LAPCVehicle] = 2;

//---------------------------------------------------------------------------------
// Inventory Global Variables
//---------------------------------------------------------------------------------

if($Eradication::ItemEnabled[Blaster] == false) {
	$InvList[Blaster] = 0;
	$RemoteInvList[Blaster] = 0;
}
else {
	$InvList[Blaster] = 1;
	$RemoteInvList[Blaster] = 1;
}
if($Eradication::ItemEnabled[SniperRifle] == false) {
	$InvList[SniperRifle] = 0;
	$RemoteInvList[SniperRifle] = 0;
	$InvList[SniperAmmo] = 0;
	$RemoteInvList[SniperAmmo] = 0;
}
else {
	$InvList[SniperRifle] = 1;
	$RemoteInvList[SniperRifle] = 1;
	$InvList[SniperAmmo] = 1;
	$RemoteInvList[SniperAmmo] = 1;
}
if($Eradication::ItemEnabled[LaserRifle] == false) {
	$InvList[LaserRifle] = 0;
	$RemoteInvList[LaserRifle] = 0;
}
else {
	$InvList[LaserRifle] = 1;
	$RemoteInvList[LaserRifle] = 1;
}
if($Eradication::ItemEnabled[PlasmaGun] == false) {
	$InvList[PlasmaGun] = 0;
	$RemoteInvList[PlasmaGun] = 0;
	$InvList[PlasmaAmmo] = 0;
	$RemoteInvList[PlasmaAmmo] = 0;
}
else {
	$InvList[PlasmaGun] = 1;
	$RemoteInvList[PlasmaGun] = 1;
	$InvList[PlasmaAmmo] = 1;
	$RemoteInvList[PlasmaAmmo] = 1;
}
if($Eradication::ItemEnabled[PlasmaShotgun] == false) {
	$InvList[PlasmaShotgun] = 0;
	$RemoteInvList[PlasmaShotgun] = 0;
}
else {
	$InvList[PlasmaShotgun] = 1;
	$RemoteInvList[PlasmaShotgun] = 1;
}
if($Eradication::ItemEnabled[Lamprey] == false) {
	$InvList[Lamprey] = 0;
	$RemoteInvList[Lamprey] = 0;
}
else {
	$InvList[Lamprey] = 1;
	$RemoteInvList[Lamprey] = 1;
}
if($Eradication::ItemEnabled[AutoBlaster] == false) {
	$InvList[AutoBlaster] = 0;
	$RemoteInvList[AutoBlaster] = 0;
}
else {
	$InvList[AutoBlaster] = 1;
	$RemoteInvList[AutoBlaster] = 1;
}
if($Eradication::ItemEnabled[EnergyRifle] == false) {
	$InvList[EnergyRifle] = 0;
	$RemoteInvList[EnergyRifle] = 0;
}
else {
	$InvList[EnergyRifle] = 1;
	$RemoteInvList[EnergyRifle] = 1;
}
if($Eradication::ItemEnabled[Shotgun] == false) {
	$InvList[Shotgun] = 0;
	$RemoteInvList[Shotgun] = 0;
	$InvList[ShotgunAmmo] = 0;
	$RemoteInvList[ShotgunAmmo] = 0;
}
else {
	$InvList[Shotgun] = 1;
	$RemoteInvList[Shotgun] = 1;
	$InvList[ShotgunAmmo] = 1;
	$RemoteInvList[ShotgunAmmo] = 1;
}
if($Eradication::ItemEnabled[DiscLauncher] == false) {
	$InvList[DiscLauncher] = 0;
	$RemoteInvList[DiscLauncher] = 0;
	$InvList[DiscAmmo] = 0;
	$RemoteInvList[DiscAmmo] = 0;
}
else {
	$InvList[DiscLauncher] = 1;
	$RemoteInvList[DiscLauncher] = 1;
	$InvList[DiscAmmo] = 1;
	$RemoteInvList[DiscAmmo] = 1;
}
if($Eradication::ItemEnabled[SballLauncher] == false) {
	$InvList[SballLauncher] = 0;
	$RemoteInvList[SballLauncher] = 0;
	$InvList[SuperballAmmo] = 0;
	$RemoteInvList[SuperballAmmo] = 0;
}
else {
	$InvList[SballLauncher] = 1;
	$RemoteInvList[SballLauncher] = 1;
	$InvList[SuperballAmmo] = 1;
	$RemoteInvList[SuperballAmmo] = 1;
}
if($Eradication::ItemEnabled[GrenadeLauncher] == false) {
	$InvList[GrenadeLauncher] = 0;
	$RemoteInvList[GrenadeLauncher] = 0;
	$InvList[GrenadeAmmo] = 0;
	$RemoteInvList[GrenadeAmmo] = 0;
}
else {
	$InvList[GrenadeLauncher] = 1;
	$RemoteInvList[GrenadeLauncher] = 1;
	$InvList[GrenadeAmmo] = 1;
	$RemoteInvList[GrenadeAmmo] = 1;
}
if($Eradication::ItemEnabled[Chaingun] == false) {
	$InvList[Chaingun] = 0;
	$RemoteInvList[Chaingun] = 0;
	$InvList[BulletAmmo] = 0;
	$RemoteInvList[BulletAmmo] = 0;
}
else {
	$InvList[Chaingun] = 1;
	$RemoteInvList[Chaingun] = 1;
	$InvList[BulletAmmo] = 1;
	$RemoteInvList[BulletAmmo] = 1;
}
if($Eradication::ItemEnabled[Mortar] == false) {
	$InvList[Mortar] = 0;
	$RemoteInvList[Mortar] = 0;
	$InvList[MortarAmmo] = 0;
	$RemoteInvList[MortarAmmo] = 0;
}
else {
	$InvList[Mortar] = 1;
	$RemoteInvList[Mortar] = 1;
	$InvList[MortarAmmo] = 1;
	$RemoteInvList[MortarAmmo] = 1;
}
if($Eradication::ItemEnabled[MultiGrenadeLauncher] == false) {
	$InvList[MultiGrenadeLauncher] = 0;
	$RemoteInvList[MultiGrenadeLauncher] = 0;
	$InvList[GrenadeAmmo] = 0;
	$RemoteInvList[GrenadeAmmo] = 0;
}
else {
	$InvList[MultiGrenadeLauncher] = 1;
	$RemoteInvList[MultiGrenadeLauncher] = 1;
	$InvList[GrenadeAmmo] = 1;
	$RemoteInvList[GrenadeAmmo] = 1;
}
if($Eradication::ItemEnabled[Howitzer] == false) {
	$InvList[Howitzer] = 0;
	$RemoteInvList[Howitzer] = 0;
	$InvList[HowitzerAmmo] = 0;
	$RemoteInvList[HowitzerAmmo] = 0;
}
else {
	$InvList[Howitzer] = 1;
	$RemoteInvList[Howitzer] = 1;
	$InvList[HowitzerAmmo] = 1;
	$RemoteInvList[HowitzerAmmo] = 1;
}
if($Eradication::ItemEnabled[RepulsorGun] == false) {
	$InvList[RepulsorGun] = 0;
	$RemoteInvList[RepulsorGun] = 0;
}
else {
	$InvList[RepulsorGun] = 1;
	$RemoteInvList[RepulsorGun] = 1;
}
if($Eradication::ItemEnabled[TargetingLaser] == false) {
	$InvList[TargetingLaser] = 0;
	$RemoteInvList[TargetingLaser] = 0;
}
else {
	$InvList[TargetingLaser] = 1;
	$RemoteInvList[TargetingLaser] = 1;
}
if($Eradication::ItemEnabled[RepairPack] == false) {
	$InvList[RepairPack] = 0;
	$RemoteInvList[RepairPack] = 0;
}
else {
	$InvList[RepairPack] = 1;
	$RemoteInvList[RepairPack] = 1;
}
if($Eradication::ItemEnabled[AssaultPack] == false) {
	$InvList[AssaultPack] = 0;
	$RemoteInvList[AssaultPack] = 0;
}
else {
	$InvList[AssaultPack] = 1;
	$RemoteInvList[AssaultPack] = 1;
}
if($Eradication::ItemEnabled[DefenderPack] == false) {
	$InvList[DefenderPack] = 0;
	$RemoteInvList[DefenderPack] = 0;
}
else {
	$InvList[DefenderPack] = 1;
	$RemoteInvList[DefenderPack] = 1;
}
if($Eradication::ItemEnabled[ScoutPack] == false) {
	$InvList[ScoutPack] = 0;
	$RemoteInvList[ScoutPack] = 0;
}
else {
	$InvList[ScoutPack] = 1;
	$RemoteInvList[ScoutPack] = 1;
}
if($Eradication::ItemEnabled[SniperPack] == false) {
	$InvList[SniperPack] = 0;
	$RemoteInvList[SniperPack] = 0;
}
else {
	$InvList[SniperPack] = 1;
	$RemoteInvList[SniperPack] = 1;
}
if($Eradication::ItemEnabled[StealthPack] == false) {
	$InvList[StealthPack] = 0;
	$RemoteInvList[StealthPack] = 0;
}
else {
	$InvList[StealthPack] = 1;
	$RemoteInvList[StealthPack] = 1;
}
if($Eradication::ItemEnabled[MinelayerPack] == false) {
	$InvList[MinelayerPack] = 0;
	$RemoteInvList[MinelayerPack] = 0;
}
else {
	$InvList[MinelayerPack] = 1;
	$RemoteInvList[MinelayerPack] = 1;
}
if($Eradication::ItemEnabled[RepulsorPack] == false) {
	$InvList[RepulsorPack] = 0;
	$RemoteInvList[RepulsorPack] = 0;
}
else {
	$InvList[RepulsorPack] = 1;
	$RemoteInvList[RepulsorPack] = 1;
}
if($Eradication::ItemEnabled[CommanderPack] == false) {
	$InvList[CommanderPack] = 0;
	$RemoteInvList[CommanderPack] = 0;
}
else {
	$InvList[CommanderPack] = 1;
	$RemoteInvList[CommanderPack] = 1;
}
if($Eradication::ItemEnabled[RepairKit] == false) {
	$InvList[RepairKit] = 0;
	$RemoteInvList[RepairKit] = 0;
}
else {
	$InvList[RepairKit] = 1;
	$RemoteInvList[RepairKit] = 1;
}
if($Eradication::ItemEnabled[CameraPack] == false) {
	$InvList[CameraPack] = 0;
	$RemoteInvList[CameraPack] = 0;
}
else {
	$InvList[CameraPack] = 1;
	$RemoteInvList[CameraPack] = 1;
}
if($Eradication::ItemEnabled[DeployableSensorJammerPack] == false) {
	$InvList[DeployableSensorJammerPack] = 0;
	$RemoteInvList[DeployableSensorJammerPack] = 0;
}
else {
	$InvList[DeployableSensorJammerPack] = 1;
	$RemoteInvList[DeployableSensorJammerPack] = 1;
}
if($Eradication::ItemEnabled[MotionSensorPack] == false) {
	$InvList[MotionSensorPack] = 0;
	$RemoteInvList[MotionSensorPack] = 0;
}
else {
	$InvList[MotionSensorPack] = 1;
	$RemoteInvList[MotionSensorPack] = 1;
}
if($Eradication::ItemEnabled[PulseSensorPack] == false) {
	$InvList[PulseSensorPack] = 0;
	$RemoteInvList[PulseSensorPack] = 0;
}
else {
	$InvList[PulseSensorPack] = 1;
	$RemoteInvList[PulseSensorPack] = 1;
}
if($Eradication::ItemEnabled[Beacon] == false) {
	$InvList[Beacon] = 0;
	$RemoteInvList[Beacon] = 0;
}
else {
	$InvList[Beacon] = 1;
	$RemoteInvList[Beacon] = 1;
}
if($Eradication::ItemEnabled[MineAmmo] == false) {
	$InvList[MineAmmo] = 0;
	$RemoteInvList[MineAmmo] = 0;
}
else {
	$InvList[MineAmmo] = 1;
	$RemoteInvList[MineAmmo] = 1;
}
if($Eradication::ItemEnabled[Grenade] == false) {
	$InvList[Grenade] = 0;
	$RemoteInvList[Grenade] = 0;
}
else {
	$InvList[Grenade] = 1;
	$RemoteInvList[Grenade] = 1;
}
if($Eradication::ItemEnabled[FlashGrenade] == false) {
	$InvList[FlashGrenade] = 0;
	$RemoteInvList[FlashGrenade] = 0;
}
else {
	$InvList[FlashGrenade] = 1;
	$RemoteInvList[FlashGrenade] = 1;
}
if($Eradication::ItemEnabled[VortexGrenade] == false) {
	$InvList[VortexGrenade] = 0;
	$RemoteInvList[VortexGrenade] = 0;
}
else {
	$InvList[VortexGrenade] = 1;
	$RemoteInvList[VortexGrenade] = 1;
}
if($Eradication::ItemEnabled[StickyBomb] == false) {
	$InvList[StickyBomb] = 0;
	$RemoteInvList[StickyBomb] = 0;
}
else {
	$InvList[StickyBomb] = 1;
	$RemoteInvList[StickyBomb] = 1;
}
if($Eradication::ItemEnabled[DeployableInvPack] == false) {
	$InvList[DeployableInvPack] = 0;
	$RemoteInvList[DeployableInvPack] = 0;
}
else {
	$InvList[DeployableInvPack] = 1;
	$RemoteInvList[DeployableInvPack] = 0;
}
if($Eradication::ItemEnabled[DeployableAmmoPack] == false) {
	$InvList[DeployableAmmoPack] = 0;
	$RemoteInvList[DeployableAmmoPack] = 0;
}
else {
	$InvList[DeployableAmmoPack] = 1;
	$RemoteInvList[DeployableAmmoPack] = 0;
}
if($Eradication::ItemEnabled[BarrierPack] == false) {
	$InvList[BarrierPack] = 0;
	$RemoteInvList[BarrierPack] = 0;
}
else {
	$InvList[BarrierPack] = 1;
	$RemoteInvList[BarrierPack] = 1;
}
if($Eradication::ItemEnabled[StackableCratePack] == false) {
	$InvList[StackableCratePack] = 0;
	$RemoteInvList[StackableCratePack] = 0;
}
else {
	$InvList[StackableCratePack] = 1;
	$RemoteInvList[StackableCratePack] = 1;
}
if($Eradication::ItemEnabled[SuspendedPlatformPack] == false) {
	$InvList[SuspendedPlatformPack] = 0;
	$RemoteInvList[SuspendedPlatformPack] = 0;
}
else {
	$InvList[SuspendedPlatformPack] = 1;
	$RemoteInvList[SuspendedPlatformPack] = 1;
}
if($Eradication::ItemEnabled[LargeDecoyTurretPack] == false) {
	$InvList[LargeDecoyTurretPack] = 0;
	$RemoteInvList[LargeDecoyTurretPack] = 0;
}
else {
	$InvList[LargeDecoyTurretPack] = 1;
	$RemoteInvList[LargeDecoyTurretPack] = 1;
}
if($Eradication::ItemEnabled[MediumDecoyTurretPack] == false) {
	$InvList[MediumDecoyTurretPack] = 0;
	$RemoteInvList[MediumDecoyTurretPack] = 0;
}
else {
	$InvList[MediumDecoyTurretPack] = 1;
	$RemoteInvList[MediumDecoyTurretPack] = 1;
}
if($Eradication::ItemEnabled[SmallDecoyTurretPack] == false) {
	$InvList[SmallDecoyTurretPack] = 0;
	$RemoteInvList[SmallDecoyTurretPack] = 0;
}
else {
	$InvList[SmallDecoyTurretPack] = 1;
	$RemoteInvList[SmallDecoyTurretPack] = 1;
}
if($Eradication::ItemEnabled[AutoPlasmaTurretPack] == false) {
	$InvList[AutoPlasmaTurretPack] = 0;
	$RemoteInvList[AutoPlasmaTurretPack] = 0;
}
else {
	$InvList[AutoPlasmaTurretPack] = 1;
	$RemoteInvList[AutoPlasmaTurretPack] = 1;
}
if($Eradication::ItemEnabled[BlasterTurretPack] == false) {
	$InvList[BlasterTurretPack] = 0;
	$RemoteInvList[BlasterTurretPack] = 0;
}
else {
	$InvList[BlasterTurretPack] = 1;
	$RemoteInvList[BlasterTurretPack] = 1;
}
if($Eradication::ItemEnabled[ChaingunTurretPack] == false) {
	$InvList[ChaingunTurretPack] = 0;
	$RemoteInvList[ChaingunTurretPack] = 0;
}
else {
	$InvList[ChaingunTurretPack] = 1;
	$RemoteInvList[ChaingunTurretPack] = 1;
}
if($Eradication::ItemEnabled[DiscTurretPack] == false) {
	$InvList[DiscTurretPack] = 0;
	$RemoteInvList[DiscTurretPack] = 0;
}
else {
	$InvList[DiscTurretPack] = 1;
	$RemoteInvList[DiscTurretPack] = 1;
}
if($Eradication::ItemEnabled[FusionTurretPack] == false) {
	$InvList[FusionTurretPack] = 0;
	$RemoteInvList[FusionTurretPack] = 0;
}
else {
	$InvList[FusionTurretPack] = 1;
	$RemoteInvList[FusionTurretPack] = 1;
}
if($Eradication::ItemEnabled[GrenadeTurretPack] == false) {
	$InvList[GrenadeTurretPack] = 0;
	$RemoteInvList[GrenadeTurretPack] = 0;
}
else {
	$InvList[GrenadeTurretPack] = 1;
	$RemoteInvList[GrenadeTurretPack] = 1;
}
if($Eradication::ItemEnabled[LaserTurretPack] == false) {
	$InvList[LaserTurretPack] = 0;
	$RemoteInvList[LaserTurretPack] = 0;
}
else {
	$InvList[LaserTurretPack] = 1;
	$RemoteInvList[LaserTurretPack] = 1;
}
if($Eradication::ItemEnabled[EnergyVortexPack] == false) {
	$InvList[EnergyVortexPack] = 0;
	$RemoteInvList[EnergyVortexPack] = 0;
}
else {
	$InvList[EnergyVortexPack] = 1;
	$RemoteInvList[EnergyVortexPack] = 0;
}
if($Eradication::ItemEnabled[EnergyFieldGeneratorPack] == false) {
	$InvList[EnergyFieldGeneratorPack] = 0;
	$RemoteInvList[EnergyFieldGeneratorPack] = 0;
}
else {
	$InvList[EnergyFieldGeneratorPack] = 1;
	$RemoteInvList[EnergyFieldGeneratorPack] = 0;
}

$AutoUse[Blaster] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[PlasmaShotgun] = True;
$AutoUse[Lamprey] = True;
$AutoUse[AutoBlaster] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[Shotgun] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[SballLauncher] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[Chaingun] = True;
$AutoUse[Mortar] = True;
$AutoUse[MultiGrenadeLauncher] = True;
$AutoUse[Howitzer] = True;
$AutoUse[RepulsorGun] = True;
$AutoUse[TargetingLaser] = False;

$WeaponAmmo[Blaster] = "";
$WeaponAmmo[SniperRifle] = SniperAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[PlasmaShotgun] = "";
$WeaponAmmo[Lamprey] = "";
$WeaponAmmo[AutoBlaster] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[Shotgun] = ShotgunAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[SballLauncher] = SuperballAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[Mortar] = MortarAmmo;
$WeaponAmmo[MultiGrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Howitzer] = HowitzerAmmo;
$WeaponAmmo[RepulsorGun] = "";
$WeaponAmmo[TargetingLaser]="";

$SellAmmo[SniperAmmo] = 10;
$SellAmmo[PlasmaAmmo] = 10;
$SellAmmo[ShotgunAmmo] = 10;
$SellAmmo[DiscAmmo] = 10;
$SellAmmo[SuperballAmmo] = 10;
$SellAmmo[GrenadeAmmo] = 10;
$SellAmmo[BulletAmmo] = 50;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[HowitzerAmmo] = 10;
$SellAmmo[Beacon] = 1;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[FlashGrenade] = 5;
$SellAmmo[VortexGrenade] = 1;
$SellAmmo[StickyBomb] = 1;

//---------------------------------------------------------------------------------
// Armor Global Variables
//---------------------------------------------------------------------------------


if($Eradication::MaxWeapons[larmor] != "") 
	$MaxWeapons[larmor] = $Eradication::MaxWeapons[larmor];
else
	$MaxWeapons[larmor] = 2;
$ArmorType[Male, LightArmor] = larmor;
$ArmorName[larmor] = LightArmor;

$DamageScale[larmor, $LandingDamageType] = 0.8;
$DamageScale[larmor, $ImpactDamageType] = 0.8;
$DamageScale[larmor, $CrushDamageType] = 1.0;
$DamageScale[larmor, $BulletDamageType] = 1.2;
$DamageScale[larmor, $PlasmaDamageType] = 1.0;
$DamageScale[larmor, $EnergyDamageType] = 1.3;
$DamageScale[larmor, $ExplosionDamageType] = 1.0;
$DamageScale[larmor, $MissileDamageType] = 1.0;
$DamageScale[larmor, $DebrisDamageType] = 1.2;
$DamageScale[larmor, $ShrapnelDamageType] = 1.2;
$DamageScale[larmor, $LaserDamageType] = 1.0;
$DamageScale[larmor, $MortarDamageType] = 1.3;
$DamageScale[larmor, $BlasterDamageType] = 1.3;
$DamageScale[larmor, $ElectricityDamageType] = 1.0;
$DamageScale[larmor, $MineDamageType] = 1.2;

$ItemMax[larmor, Blaster] = 1;
$ItemMax[larmor, SniperRifle] = 1;
$ItemMax[larmor, SniperAmmo] = 8;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, PlasmaAmmo] = 15;
$ItemMax[larmor, PlasmaShotgun] = 0;
$ItemMax[larmor, Lamprey] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, AutoBlaster] = 0;
$ItemMax[larmor, Shotgun] = 0;
$ItemMax[larmor, ShotgunAmmo] = 10;
$ItemMax[larmor, DiscLauncher] = 1;
$ItemMax[larmor, DiscAmmo] = 10;
$ItemMax[larmor, SballLauncher] = 1;
$ItemMax[larmor, SuperballAmmo] = 10;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, GrenadeAmmo] = 6;
$ItemMax[larmor, Chaingun] = 0;
$ItemMax[larmor, BulletAmmo] = 50;
$ItemMax[larmor, Mortar] = 0;
$ItemMax[larmor, MortarAmmo] = 1;
$ItemMax[larmor, MultiGrenadeLauncher] = 0;
$ItemMax[larmor, Howitzer] = 0;
$ItemMax[larmor, HowitzerAmmo] = 1;
$ItemMax[larmor, RepulsorGun] = 1;
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[larmor, RepairPack] = 1;
$ItemMax[larmor, AssaultPack] = 0;
$ItemMax[larmor, DefenderPack] = 1;
$ItemMax[larmor, ScoutPack] = 1;
$ItemMax[larmor, SniperPack] = 1;
$ItemMax[larmor, StealthPack] = 1;
$ItemMax[larmor, MinelayerPack] = 1;
$ItemMax[larmor, RepulsorPack] = 1;
$ItemMax[larmor, CommanderPack] = 0;
$ItemMax[larmor, DeployableInvPack] = 0;
$ItemMax[larmor, DeployableAmmoPack] = 0;
$ItemMax[larmor, BarrierPack] = 0;
$ItemMax[larmor, StackableCratePack] = 0;
$ItemMax[larmor, SuspendedPlatformPack] = 0;
$ItemMax[larmor, LargeDecoyTurretPack] = 0;
$ItemMax[larmor, MediumDecoyTurretPack] = 0;
$ItemMax[larmor, SmallDecoyTurretPack] = 0;
$ItemMax[larmor, AutoPlasmaTurretPack] = 0;
$ItemMax[larmor, BlasterTurretPack] = 0;
$ItemMax[larmor, ChaingunTurretPack] = 0;
$ItemMax[larmor, DiscTurretPack] = 0;
$ItemMax[larmor, FusionTurretPack] = 0;
$ItemMax[larmor, GrenadeTurretPack] = 0;
$ItemMax[larmor, LaserTurretPack] = 0;
$ItemMax[larmor, EnergyVortexPack] = 0;
$ItemMax[larmor, EnergyFieldGeneratorPack] = 0;
$ItemMax[larmor, RepairKit] = 1;
$ItemMax[larmor, CameraPack] = 1;
$ItemMax[larmor, DeployableSensorJammerPack] = 1;
$ItemMax[larmor, MotionSensorPack] = 1;
$ItemMax[larmor, PulseSensorPack] = 1;
$ItemMax[larmor, Beacon] = 2;
$ItemMax[larmor, MineAmmo] = 1;
$ItemMax[larmor, Grenade] = 2;
$ItemMax[larmor, FlashGrenade] = 2;
$ItemMax[larmor, VortexGrenade] = 1;
$ItemMax[larmor, StickyBomb] = 1;

if($Eradication::MaxWeapons[lfemale] != "") 
	$MaxWeapons[lfemale] = $Eradication::MaxWeapons[lfemale];
else
	$MaxWeapons[lfemale] = 2;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorName[lfemale] = LightArmor;

$DamageScale[lfemale, $LandingDamageType] = 0.8;
$DamageScale[lfemale, $ImpactDamageType] = 0.8;	
$DamageScale[lfemale, $CrushDamageType] = 1.0;	
$DamageScale[lfemale, $BulletDamageType] = 1.2;
$DamageScale[lfemale, $PlasmaDamageType] = 1.0;
$DamageScale[lfemale, $EnergyDamageType] = 1.3;
$DamageScale[lfemale, $ExplosionDamageType] = 1.0;
$DamageScale[lfemale, $MissileDamageType] = 1.0;
$DamageScale[lfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[lfemale, $DebrisDamageType] = 1.2;
$DamageScale[lfemale, $LaserDamageType] = 1.0;
$DamageScale[lfemale, $MortarDamageType] = 1.3;
$DamageScale[lfemale, $BlasterDamageType] = 1.3;
$DamageScale[lfemale, $ElectricityDamageType] = 1.0;
$DamageScale[lfemale, $MineDamageType] = 1.2;

$ItemMax[lfemale, Blaster] = 1;
$ItemMax[lfemale, SniperRifle] = 1;
$ItemMax[lfemale, SniperAmmo] = 8;
$ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[lfemale, PlasmaAmmo] = 15;
$ItemMax[lfemale, PlasmaShotgun] = 0;
$ItemMax[lfemale, Lamprey] = 1;
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[lfemale, AutoBlaster] = 0;
$ItemMax[lfemale, Shotgun] = 0;
$ItemMax[lfemale, ShotgunAmmo] = 10;
$ItemMax[lfemale, DiscLauncher] = 1;
$ItemMax[lfemale, DiscAmmo] = 10;
$ItemMax[lfemale, SballLauncher] = 1;
$ItemMax[lfemale, SuperballAmmo] = 10;
$ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[lfemale, GrenadeAmmo] = 6;
$ItemMax[lfemale, Chaingun] = 0;
$ItemMax[lfemale, BulletAmmo] = 50;
$ItemMax[lfemale, Mortar] = 0;
$ItemMax[lfemale, MortarAmmo] = 1;
$ItemMax[lfemale, MultiGrenadeLauncher] = 0;
$ItemMax[lfemale, Howitzer] = 0;
$ItemMax[lfemale, HowitzerAmmo] = 1;
$ItemMax[lfemale, RepulsorGun] = 1;
$ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[lfemale, RepairPack] = 1;
$ItemMax[lfemale, AssaultPack] = 0;
$ItemMax[lfemale, DefenderPack] = 1;
$ItemMax[lfemale, ScoutPack] = 1;
$ItemMax[lfemale, SniperPack] = 1;
$ItemMax[lfemale, StealthPack] = 1;
$ItemMax[lfemale, MinelayerPack] = 1;
$ItemMax[lfemale, RepulsorPack] = 1;
$ItemMax[lfemale, CommanderPack] = 0;
$ItemMax[lfemale, DeployableInvPack] = 0;
$ItemMax[lfemale, DeployableAmmoPack] = 0;
$ItemMax[lfemale, BarrierPack] = 0;
$ItemMax[lfemale, StackableCratePack] = 0;
$ItemMax[lfemale, SuspendedPlatformPack] = 0;
$ItemMax[lfemale, LargeDecoyTurretPack] = 0;
$ItemMax[lfemale, MediumDecoyTurretPack] = 0;
$ItemMax[lfemale, SmallDecoyTurretPack] = 0;
$ItemMax[lfemale, AutoPlasmaTurretPack] = 0;
$ItemMax[lfemale, BlasterTurretPack] = 0;
$ItemMax[lfemale, ChaingunTurretPack] = 0;
$ItemMax[lfemale, DiscTurretPack] = 0;
$ItemMax[lfemale, FusionTurretPack] = 0;
$ItemMax[lfemale, GrenadeTurretPack] = 0;
$ItemMax[lfemale, LaserTurretPack] = 0;
$ItemMax[lfemale, EnergyVortexPack] = 0;
$ItemMax[lfemale, EnergyFieldGeneratorPack] = 0;
$ItemMax[lfemale, RepairKit] = 1;
$ItemMax[lfemale, CameraPack] = 1;
$ItemMax[lfemale, DeployableSensorJammerPack] = 1;
$ItemMax[lfemale, MotionSensorPack] = 1;
$ItemMax[lfemale, PulseSensorPack] = 1;
$ItemMax[lfemale, Beacon] = 2;
$ItemMax[lfemale, MineAmmo] = 1;
$ItemMax[lfemale, Grenade] = 2;
$ItemMax[lfemale, FlashGrenade] = 2;
$ItemMax[lfemale, VortexGrenade] = 1;
$ItemMax[lfemale, StickyBomb] = 1;

if($Eradication::MaxWeapons[marmor] != "") 
	$MaxWeapons[marmor] = $Eradication::MaxWeapons[marmor];
else
	$MaxWeapons[marmor] = 3;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorName[marmor] = MediumArmor;

$DamageScale[marmor, $LandingDamageType] = 1.0;
$DamageScale[marmor, $ImpactDamageType] = 1.0;
$DamageScale[marmor, $CrushDamageType] = 1.0;
$DamageScale[marmor, $BulletDamageType] = 1.0;
$DamageScale[marmor, $PlasmaDamageType] = 1.0;
$DamageScale[marmor, $EnergyDamageType] = 1.0;
$DamageScale[marmor, $ExplosionDamageType] = 1.0;
$DamageScale[marmor, $MissileDamageType] = 1.0;
$DamageScale[marmor, $ShrapnelDamageType] = 1.0;
$DamageScale[marmor, $DebrisDamageType] = 1.0;
$DamageScale[marmor, $LaserDamageType] = 1.0;
$DamageScale[marmor, $MortarDamageType] = 1.0;
$DamageScale[marmor, $BlasterDamageType] = 1.0;
$DamageScale[marmor, $ElectricityDamageType] = 1.0;
$DamageScale[marmor, $MineDamageType] = 1.0;

$ItemMax[marmor, Blaster] = 1;
$ItemMax[marmor, SniperRifle] = 1;
$ItemMax[marmor, SniperAmmo] = 15;
$ItemMax[marmor, LaserRifle] = 1;
$ItemMax[marmor, PlasmaGun] = 1;
$ItemMax[marmor, PlasmaAmmo] = 20;
$ItemMax[marmor, PlasmaShotgun] = 1;
$ItemMax[marmor, Lamprey] = 1;
$ItemMax[marmor, EnergyRifle] = 1;
$ItemMax[marmor, AutoBlaster] = 1;
$ItemMax[marmor, Shotgun] = 1;
$ItemMax[marmor, ShotgunAmmo] = 15;
$ItemMax[marmor, DiscLauncher] = 1;
$ItemMax[marmor, DiscAmmo] = 15;
$ItemMax[marmor, SballLauncher] = 1;
$ItemMax[marmor, SuperballAmmo] = 15;
$ItemMax[marmor, GrenadeLauncher] = 1;
$ItemMax[marmor, GrenadeAmmo] = 9;
$ItemMax[marmor, Chaingun] = 1;
$ItemMax[marmor, BulletAmmo] = 100;
$ItemMax[marmor, Mortar] = 1;
$ItemMax[marmor, MortarAmmo] = 2;
$ItemMax[marmor, MultiGrenadeLauncher] = 1;
$ItemMax[marmor, Howitzer] = 1;
$ItemMax[marmor, HowitzerAmmo] = 2;
$ItemMax[marmor, RepulsorGun] = 1;
$ItemMax[marmor, TargetingLaser] = 1;
$ItemMax[marmor, RepairPack] = 1;
$ItemMax[marmor, AssaultPack] = 1;
$ItemMax[marmor, DefenderPack] = 1;
$ItemMax[marmor, ScoutPack] = 1;
$ItemMax[marmor, SniperPack] = 1;
$ItemMax[marmor, StealthPack] = 1;
$ItemMax[marmor, MinelayerPack] = 1;
$ItemMax[marmor, RepulsorPack] = 1;
$ItemMax[marmor, CommanderPack] = 0;
$ItemMax[marmor, DeployableInvPack] = 1;
$ItemMax[marmor, DeployableAmmoPack] = 1;
$ItemMax[marmor, BarrierPack] = 1;
$ItemMax[marmor, StackableCratePack] = 1;
$ItemMax[marmor, SuspendedPlatformPack] = 1;
$ItemMax[marmor, LargeDecoyTurretPack] = 1;
$ItemMax[marmor, MediumDecoyTurretPack] = 1;
$ItemMax[marmor, SmallDecoyTurretPack] = 1;
$ItemMax[marmor, AutoPlasmaTurretPack] = 1;
$ItemMax[marmor, BlasterTurretPack] = 1;
$ItemMax[marmor, ChaingunTurretPack] = 1;
$ItemMax[marmor, DiscTurretPack] = 1;
$ItemMax[marmor, FusionTurretPack] = 1;
$ItemMax[marmor, GrenadeTurretPack] = 1;
$ItemMax[marmor, LaserTurretPack] = 1;
$ItemMax[marmor, EnergyVortexPack] = 0;
$ItemMax[marmor, EnergyFieldGeneratorPack] = 0;
$ItemMax[marmor, RepairKit] = 1;
$ItemMax[marmor, CameraPack] = 1;
$ItemMax[marmor, DeployableSensorJammerPack] = 1;
$ItemMax[marmor, MotionSensorPack] = 1;
$ItemMax[marmor, PulseSensorPack] = 1;
$ItemMax[marmor, Beacon] = 1;
$ItemMax[marmor, MineAmmo] = 1;
$ItemMax[marmor, Grenade] = 3;
$ItemMax[marmor, FlashGrenade] = 3;
$ItemMax[marmor, VortexGrenade] = 1;
$ItemMax[marmor, StickyBomb] = 2;

if($Eradication::MaxWeapons[mfemale] != "") 
	$MaxWeapons[mfemale] = $Eradication::MaxWeapons[mfemale];
else
	$MaxWeapons[mfemale] = 3;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorName[mfemale] = MediumArmor;

$DamageScale[mfemale, $LandingDamageType] = 1.0;
$DamageScale[mfemale, $ImpactDamageType] = 1.0;
$DamageScale[mfemale, $CrushDamageType] = 1.0;
$DamageScale[mfemale, $BulletDamageType] = 1.0;
$DamageScale[mfemale, $EnergyDamageType] = 1.0;
$DamageScale[mfemale, $PlasmaDamageType] = 0.6;
$DamageScale[mfemale, $ExplosionDamageType] = 1.0;
$DamageScale[mfemale, $MissileDamageType] = 1.0;
$DamageScale[mfemale, $ShrapnelDamageType] = 1.0;
$DamageScale[mfemale, $DebrisDamageType] = 1.0;
$DamageScale[mfemale, $LaserDamageType] = 1.0;
$DamageScale[mfemale, $MortarDamageType] = 1.0;
$DamageScale[mfemale, $BlasterDamageType] = 1.0;
$DamageScale[mfemale, $ElectricityDamageType] = 1.0;
$DamageScale[mfemale, $MineDamageType] = 1.0;

$ItemMax[mfemale, Blaster] = 1;
$ItemMax[mfemale, SniperRifle] = 1;
$ItemMax[mfemale, SniperAmmo] = 15;
$ItemMax[mfemale, LaserRifle] = 1;
$ItemMax[mfemale, PlasmaGun] = 1;
$ItemMax[mfemale, PlasmaAmmo] = 20;
$ItemMax[mfemale, PlasmaShotgun] = 1;
$ItemMax[mfemale, Lamprey] = 1;
$ItemMax[mfemale, EnergyRifle] = 1;
$ItemMax[mfemale, AutoBlaster] = 1;
$ItemMax[mfemale, Shotgun] = 1;
$ItemMax[mfemale, ShotgunAmmo] = 15;
$ItemMax[mfemale, DiscLauncher] = 1;
$ItemMax[mfemale, DiscAmmo] = 15;
$ItemMax[mfemale, SballLauncher] = 1;
$ItemMax[mfemale, SuperballAmmo] = 15;
$ItemMax[mfemale, GrenadeLauncher] = 1;
$ItemMax[mfemale, GrenadeAmmo] = 9;
$ItemMax[mfemale, Chaingun] = 1;
$ItemMax[mfemale, BulletAmmo] = 100;
$ItemMax[mfemale, Mortar] = 1;
$ItemMax[mfemale, MortarAmmo] = 2;
$ItemMax[mfemale, MultiGrenadeLauncher] = 1;
$ItemMax[mfemale, Howitzer] = 1;
$ItemMax[mfemale, HowitzerAmmo] = 2;
$ItemMax[mfemale, RepulsorGun] = 1;
$ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[mfemale, RepairPack] = 1;
$ItemMax[mfemale, AssaultPack] = 1;
$ItemMax[mfemale, DefenderPack] = 1;
$ItemMax[mfemale, ScoutPack] = 1;
$ItemMax[mfemale, SniperPack] = 1;
$ItemMax[mfemale, StealthPack] = 1;
$ItemMax[mfemale, MinelayerPack] = 1;
$ItemMax[mfemale, RepulsorPack] = 1;
$ItemMax[mfemale, CommanderPack] = 0;
$ItemMax[mfemale, DeployableInvPack] = 1;
$ItemMax[mfemale, DeployableAmmoPack] = 1;
$ItemMax[mfemale, BarrierPack] = 1;
$ItemMax[mfemale, StackableCratePack] = 1;
$ItemMax[mfemale, SuspendedPlatformPack] = 1;
$ItemMax[mfemale, LargeDecoyTurretPack] = 1;
$ItemMax[mfemale, MediumDecoyTurretPack] = 1;
$ItemMax[mfemale, SmallDecoyTurretPack] = 1;
$ItemMax[mfemale, AutoPlasmaTurretPack] = 1;
$ItemMax[mfemale, BlasterTurretPack] = 1;
$ItemMax[mfemale, ChaingunTurretPack] = 1;
$ItemMax[mfemale, DiscTurretPack] = 1;
$ItemMax[mfemale, FusionTurretPack] = 1;
$ItemMax[mfemale, GrenadeTurretPack] = 1;
$ItemMax[mfemale, LaserTurretPack] = 1;
$ItemMax[mfemale, EnergyVortexPack] = 0;
$ItemMax[mfemale, EnergyFieldGeneratorPack] = 0;
$ItemMax[mfemale, RepairKit] = 1;
$ItemMax[mfemale, CameraPack] = 1;
$ItemMax[mfemale, DeployableSensorJammerPack] = 1;
$ItemMax[mfemale, MotionSensorPack] = 1;
$ItemMax[mfemale, PulseSensorPack] = 1;
$ItemMax[mfemale, Beacon] = 1;
$ItemMax[mfemale, MineAmmo] = 1;
$ItemMax[mfemale, Grenade] = 3;
$ItemMax[mfemale, FlashGrenade] = 3;
$ItemMax[mfemale, VortexGrenade] = 1;
$ItemMax[mfemale, StickyBomb] = 2;

if($Eradication::MaxWeapons[harmor] != "") 
	$MaxWeapons[harmor] = $Eradication::MaxWeapons[harmor];
else
	$MaxWeapons[harmor] = 5;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, HeavyArmor] = harmor;	   
$ArmorName[harmor] = HeavyArmor;

$DamageScale[harmor, $LandingDamageType] = 1.0;
$DamageScale[harmor, $ImpactDamageType] = 1.0;
$DamageScale[harmor, $CrushDamageType] = 1.0;
$DamageScale[harmor, $BulletDamageType] = 0.6;
$DamageScale[harmor, $PlasmaDamageType] = 0.4;
$DamageScale[harmor, $EnergyDamageType] = 0.7;
$DamageScale[harmor, $ExplosionDamageType] = 0.6;
$DamageScale[harmor, $MissileDamageType] = 0.6;
$DamageScale[harmor, $DebrisDamageType] = 0.8;
$DamageScale[harmor, $ShrapnelDamageType] = 0.8;
$DamageScale[harmor, $LaserDamageType] = 0.6;
$DamageScale[harmor, $MortarDamageType] = 0.7;
$DamageScale[harmor, $BlasterDamageType] = 0.7;
$DamageScale[harmor, $ElectricityDamageType] = 1.0;
$DamageScale[harmor, $MineDamageType] = 0.8;

$ItemMax[harmor, Blaster] = 1;
$ItemMax[harmor, SniperRifle] = 0;
$ItemMax[harmor, SniperAmmo] = 15;
$ItemMax[harmor, LaserRifle] = 0;
$ItemMax[harmor, PlasmaGun] = 1;
$ItemMax[harmor, PlasmaAmmo] = 40;
$ItemMax[harmor, PlasmaShotgun] = 1;
$ItemMax[harmor, Lamprey] = 1;
$ItemMax[harmor, EnergyRifle] = 1;
$ItemMax[harmor, AutoBlaster] = 1;
$ItemMax[harmor, Shotgun] = 1;
$ItemMax[harmor, ShotgunAmmo] = 25;
$ItemMax[harmor, DiscLauncher] = 1;
$ItemMax[harmor, DiscAmmo] = 25;
$ItemMax[harmor, SballLauncher] = 1;
$ItemMax[harmor, SuperballAmmo] = 20;
$ItemMax[harmor, GrenadeLauncher] = 1;
$ItemMax[harmor, GrenadeAmmo] = 18;
$ItemMax[harmor, Chaingun] = 1;
$ItemMax[harmor, BulletAmmo] = 175;
$ItemMax[harmor, Mortar] = 1;
$ItemMax[harmor, MortarAmmo] = 5;
$ItemMax[harmor, MultiGrenadeLauncher] = 1;
$ItemMax[harmor, Howitzer] = 1;
$ItemMax[harmor, HowitzerAmmo] = 5;
$ItemMax[harmor, RepulsorGun] = 1;
$ItemMax[harmor, TargetingLaser] = 1;
$ItemMax[harmor, RepairPack] = 1;
$ItemMax[harmor, AssaultPack] = 1;
$ItemMax[harmor, DefenderPack] = 1;
$ItemMax[harmor, ScoutPack] = 0;
$ItemMax[harmor, SniperPack] = 0;
$ItemMax[harmor, StealthPack] = 1;
$ItemMax[harmor, MinelayerPack] = 1;
$ItemMax[harmor, RepulsorPack] = 0;
$ItemMax[harmor, CommanderPack] = 0;
$ItemMax[harmor, DeployableInvPack] = 0;
$ItemMax[harmor, DeployableAmmoPack] = 1;
$ItemMax[harmor, BarrierPack] = 1;
$ItemMax[harmor, StackableCratePack] = 0;
$ItemMax[harmor, SuspendedPlatformPack] = 0;
$ItemMax[harmor, LargeDecoyTurretPack] = 0;
$ItemMax[harmor, MediumDecoyTurretPack] = 0;
$ItemMax[harmor, SmallDecoyTurretPack] = 0;
$ItemMax[harmor, AutoPlasmaTurretPack] = 0;
$ItemMax[harmor, BlasterTurretPack] = 0;
$ItemMax[harmor, ChaingunTurretPack] = 0;
$ItemMax[harmor, DiscTurretPack] = 0;
$ItemMax[harmor, FusionTurretPack] = 0;
$ItemMax[harmor, GrenadeTurretPack] = 0;
$ItemMax[harmor, LaserTurretPack] = 0;
$ItemMax[harmor, EnergyVortexPack] = 0;
$ItemMax[harmor, EnergyFieldGeneratorPack] = 0;
$ItemMax[harmor, CameraPack] = 0;
$ItemMax[harmor, RepairKit] = 2;
$ItemMax[harmor, DeployableSensorJammerPack] = 0;
$ItemMax[harmor, MotionSensorPack] = 0;
$ItemMax[harmor, PulseSensorPack] = 0;
$ItemMax[harmor, Beacon] = 1;
$ItemMax[harmor, MineAmmo] = 2;
$ItemMax[harmor, Grenade] = 5;
$ItemMax[harmor, FlashGrenade] = 4;
$ItemMax[harmor, VortexGrenade] = 2;
$ItemMax[harmor, StickyBomb] = 3;

if($Eradication::MaxWeapons[carmor] != "") 
	$MaxWeapons[carmor] = $Eradication::MaxWeapons[carmor];
else
	$MaxWeapons[carmor] = 2;

$ArmorType[Female, CommandArmor] = carmor;
$ArmorType[Male, CommandArmor] = carmor;
$ArmorName[carmor] = CommandArmor;

$DamageScale[carmor, $LandingDamageType] = 1.0;
$DamageScale[carmor, $ImpactDamageType] = 1.0;
$DamageScale[carmor, $CrushDamageType] = 1.0;
$DamageScale[carmor, $BulletDamageType] = 1.0;
$DamageScale[carmor, $PlasmaDamageType] = 0.6;
$DamageScale[carmor, $EnergyDamageType] = 1.0;
$DamageScale[carmor, $ExplosionDamageType] = 1.0;
$DamageScale[carmor, $MissileDamageType] = 1.0;
$DamageScale[carmor, $ShrapnelDamageType] = 1.0;
$DamageScale[carmor, $DebrisDamageType] = 1.0;
$DamageScale[carmor, $LaserDamageType] = 1.0;
$DamageScale[carmor, $MortarDamageType] = 1.0;
$DamageScale[carmor, $BlasterDamageType] = 1.0;
$DamageScale[carmor, $ElectricityDamageType] = 1.0;
$DamageScale[carmor, $MineDamageType] = 1.0;

$ItemMax[carmor, Blaster] = 1;
$ItemMax[carmor, SniperRifle] = 1;
$ItemMax[carmor, SniperAmmo] = 10;
$ItemMax[carmor, LaserRifle] = 1;
$ItemMax[carmor, PlasmaGun] = 1;
$ItemMax[carmor, PlasmaAmmo] = 15;
$ItemMax[carmor, PlasmaShotgun] = 0;
$ItemMax[carmor, Lamprey] = 1;
$ItemMax[carmor, EnergyRifle] = 1;
$ItemMax[carmor, AutoBlaster] = 1;
$ItemMax[carmor, Shotgun] = 1;
$ItemMax[carmor, ShotgunAmmo] = 10;
$ItemMax[carmor, DiscLauncher] = 1;
$ItemMax[carmor, DiscAmmo] = 10;
$ItemMax[carmor, SballLauncher] = 1;
$ItemMax[carmor, SuperballAmmo] = 10;
$ItemMax[carmor, GrenadeLauncher] = 1;
$ItemMax[carmor, GrenadeAmmo] = 6;
$ItemMax[carmor, Chaingun] = 0;
$ItemMax[carmor, BulletAmmo] = 50;
$ItemMax[carmor, Mortar] = 0;
$ItemMax[carmor, MortarAmmo] = 1;
$ItemMax[carmor, MultiGrenadeLauncher] = 0;
$ItemMax[carmor, Howitzer] = 0;
$ItemMax[carmor, HowitzerAmmo] = 1;
$ItemMax[carmor, RepulsorGun] = 1;
$ItemMax[carmor, TargetingLaser] = 1;
$ItemMax[carmor, RepairPack] = 1;
$ItemMax[carmor, AssaultPack] = 0;
$ItemMax[carmor, DefenderPack] = 1;
$ItemMax[carmor, ScoutPack] = 1;
$ItemMax[carmor, SniperPack] = 0;
$ItemMax[carmor, StealthPack] = 1;
$ItemMax[carmor, MinelayerPack] = 1;
$ItemMax[carmor, RepulsorPack] = 1;
$ItemMax[carmor, CommanderPack] = 1;
$ItemMax[carmor, DeployableInvPack] = 1;
$ItemMax[carmor, DeployableAmmoPack] = 1;
$ItemMax[carmor, BarrierPack] = 1;
$ItemMax[carmor, StackableCratePack] = 1;
$ItemMax[carmor, SuspendedPlatformPack] = 1;
$ItemMax[carmor, LargeDecoyTurretPack] = 1;
$ItemMax[carmor, MediumDecoyTurretPack] = 1;
$ItemMax[carmor, SmallDecoyTurretPack] = 1;
$ItemMax[carmor, AutoPlasmaTurretPack] = 1;
$ItemMax[carmor, BlasterTurretPack] = 1;
$ItemMax[carmor, ChaingunTurretPack] = 1;
$ItemMax[carmor, DiscTurretPack] = 1;
$ItemMax[carmor, FusionTurretPack] = 1;
$ItemMax[carmor, GrenadeTurretPack] = 1;
$ItemMax[carmor, LaserTurretPack] = 1;
$ItemMax[carmor, EnergyVortexPack] = 0;
$ItemMax[carmor, EnergyFieldGeneratorPack] = 0;
$ItemMax[carmor, RepairKit] = 2;
$ItemMax[carmor, CameraPack] = 1;
$ItemMax[carmor, DeployableSensorJammerPack] = 1;
$ItemMax[carmor, MotionSensorPack] = 1;
$ItemMax[carmor, PulseSensorPack] = 1;
$ItemMax[carmor, Beacon] = 2;
$ItemMax[carmor, MineAmmo] = 1;
$ItemMax[carmor, Grenade] = 2;
$ItemMax[carmor, FlashGrenade] = 2;
$ItemMax[carmor, VortexGrenade] = 1;
$ItemMax[carmor, StickyBomb] = 1;

if($Eradication::MaxWeapons[sarmor] != "") 
	$MaxWeapons[sarmor] = $Eradication::MaxWeapons[sarmor];
else
	$MaxWeapons[sarmor] = 3;

$ArmorType[Male, SupportArmor] = sarmor;
$ArmorType[Female, SupportArmor] = sarmor;	   
$ArmorName[sarmor] = SupportArmor;

$DamageScale[sarmor, $LandingDamageType] = 0.9;
$DamageScale[sarmor, $ImpactDamageType] = 0.9;
$DamageScale[sarmor, $CrushDamageType] = 0.9;
$DamageScale[sarmor, $BulletDamageType] = 0.5;
$DamageScale[sarmor, $PlasmaDamageType] = 0.4;
$DamageScale[sarmor, $EnergyDamageType] = 0.7;
$DamageScale[sarmor, $ExplosionDamageType] = 0.5;
$DamageScale[sarmor, $MissileDamageType] = 0.6;
$DamageScale[sarmor, $DebrisDamageType] = 0.8;
$DamageScale[sarmor, $ShrapnelDamageType] = 0.8;
$DamageScale[sarmor, $LaserDamageType] = 0.5;
$DamageScale[sarmor, $MortarDamageType] = 0.6;
$DamageScale[sarmor, $BlasterDamageType] = 0.7;
$DamageScale[sarmor, $ElectricityDamageType] = 0.9;
$DamageScale[sarmor, $MineDamageType] = 0.8;

$ItemMax[sarmor, Blaster] = 1;
$ItemMax[sarmor, SniperRifle] = 1;
$ItemMax[sarmor, SniperAmmo] = 15;
$ItemMax[sarmor, LaserRifle] = 0;
$ItemMax[sarmor, PlasmaGun] = 1;
$ItemMax[sarmor, PlasmaAmmo] = 20;
$ItemMax[sarmor, PlasmaShotgun] = 1;
$ItemMax[sarmor, Lamprey] = 1;
$ItemMax[sarmor, EnergyRifle] = 1;
$ItemMax[sarmor, AutoBlaster] = 1;
$ItemMax[sarmor, Shotgun] = 1;
$ItemMax[sarmor, ShotgunAmmo] = 15;
$ItemMax[sarmor, DiscLauncher] = 1;
$ItemMax[sarmor, DiscAmmo] = 20;
$ItemMax[sarmor, SballLauncher] = 1;
$ItemMax[sarmor, SuperballAmmo] = 15;
$ItemMax[sarmor, GrenadeLauncher] = 1;
$ItemMax[sarmor, GrenadeAmmo] = 9;
$ItemMax[sarmor, Chaingun] = 0;
$ItemMax[sarmor, BulletAmmo] = 100;
$ItemMax[sarmor, Mortar] = 0;
$ItemMax[sarmor, MortarAmmo] = 2;
$ItemMax[sarmor, MultiGrenadeLauncher] = 0;
$ItemMax[sarmor, Howitzer] = 0;
$ItemMax[sarmor, HowitzerAmmo] = 2;
$ItemMax[sarmor, RepulsorGun] = 1;
$ItemMax[sarmor, TargetingLaser] = 1;
$ItemMax[sarmor, RepairPack] = 1;
$ItemMax[sarmor, AssaultPack] = 0;
$ItemMax[sarmor, DefenderPack] = 1;
$ItemMax[sarmor, ScoutPack] = 0;
$ItemMax[sarmor, SniperPack] = 0;
$ItemMax[sarmor, StealthPack] = 1;
$ItemMax[sarmor, MinelayerPack] = 1;
$ItemMax[sarmor, RepulsorPack] = 1;
$ItemMax[sarmor, CommanderPack] = 0;
$ItemMax[sarmor, DeployableInvPack] = 1;
$ItemMax[sarmor, DeployableAmmoPack] = 1;
$ItemMax[sarmor, BarrierPack] = 1;
$ItemMax[sarmor, StackableCratePack] = 1;
$ItemMax[sarmor, SuspendedPlatformPack] = 1;
$ItemMax[sarmor, LargeDecoyTurretPack] = 1;
$ItemMax[sarmor, MediumDecoyTurretPack] = 1;
$ItemMax[sarmor, SmallDecoyTurretPack] = 1;
$ItemMax[sarmor, AutoPlasmaTurretPack] = 1;
$ItemMax[sarmor, BlasterTurretPack] = 1;
$ItemMax[sarmor, ChaingunTurretPack] = 1;
$ItemMax[sarmor, DiscTurretPack] = 1;
$ItemMax[sarmor, FusionTurretPack] = 1;
$ItemMax[sarmor, GrenadeTurretPack] = 1;
$ItemMax[sarmor, LaserTurretPack] = 1;
$ItemMax[sarmor, EnergyVortexPack] = 1;
$ItemMax[sarmor, EnergyFieldGeneratorPack] = 1;
$ItemMax[sarmor, RepairKit] = 2;
$ItemMax[sarmor, CameraPack] = 1;
$ItemMax[sarmor, DeployableSensorJammerPack] = 1;
$ItemMax[sarmor, MotionSensorPack] = 1;
$ItemMax[sarmor, PulseSensorPack] = 1;
$ItemMax[sarmor, Beacon] = 2;
$ItemMax[sarmor, MineAmmo] = 3;
$ItemMax[sarmor, Grenade] = 2;
$ItemMax[sarmor, FlashGrenade] = 2;
$ItemMax[sarmor, VortexGrenade] = 1;
$ItemMax[sarmor, StickyBomb] = 1;

$ItemMax[larmor, KillerMarker] = 1;
$ItemMax[lfemale, KillerMarker] = 1;
$ItemMax[marmor, KillerMarker] = 1;
$ItemMax[mfemale, KillerMarker] = 1;
$ItemMax[harmor, KillerMarker] = 1;
$ItemMax[carmor, KillerMarker] = 1;
$ItemMax[sarmor, KillerMarker] = 1;
$ItemMax[larmor, NewbieMarker] = 1;
$ItemMax[lfemale, NewbieMarker] = 1;
$ItemMax[marmor, NewbieMarker] = 1;
$ItemMax[mfemale, NewbieMarker] = 1;
$ItemMax[harmor, NewbieMarker] = 1;
$ItemMax[carmor, NewbieMarker] = 1;
$ItemMax[sarmor, NewbieMarker] = 1;

//---------------------------------------------------------------------------------
// Vehicle Global Variables
//---------------------------------------------------------------------------------

// List of all items available to buy from Vehicle station

if($Eradication::ItemEnabled[ScoutVehicle] != "")
	$VehicleInvList[ScoutVehicle] = $Eradication::ItemEnabled[ScoutVehicle];
else
	$VehicleInvList[ScoutVehicle] = 1;
if($Eradication::ItemEnabled[LAPCVehicle] != "")
	$VehicleInvList[LAPCVehicle] = $Eradication::ItemEnabled[LAPCVehicle];
else
	$VehicleInvList[LAPCVehicle] = 1;
if($Eradication::ItemEnabled[HAPCVehicle] != "")
	$VehicleInvList[HAPCVehicle] = $Eradication::ItemEnabled[HAPCVehicle];
else
	$VehicleInvList[HAPCVehicle] = 1;

$DataBlockName[ScoutVehicle] = Scout;
$DataBlockName[LAPCVehicle] = LAPC;
$DataBlockName[HAPCVehicle] = HAPC;

$VehicleToItem[Scout] = ScoutVehicle;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleToItem[HAPC] = HAPCVehicle;

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;


//---------------------------------------------------------------------------------
// remoteNextWeapon() and remotePrevWeapon() globals
//---------------------------------------------------------------------------------

$NextWeapon[EnergyRifle] = Shotgun;
$NextWeapon[Shotgun] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = Howitzer;
$NextWeapon[Howitzer] = LaserRifle;
$NextWeapon[LaserRifle] = AutoBlaster;
$NextWeapon[AutoBlaster] = Lamprey;
$NextWeapon[Lamprey] = MultiGrenadeLauncher;
$NextWeapon[MultiGrenadeLauncher] = SballLauncher;
$NextWeapon[SballLauncher] = SniperRifle;
$NextWeapon[SniperRifle] = PlasmaShotgun;
$NextWeapon[PlasmaShotgun] =  RepulsorGun;
$NextWeapon[RepulsorGun] = TargetingLaser;
$NextWeapon[TargetingLaser] = EnergyRifle;

$PrevWeapon[Shotgun] = EnergyRifle;
$PrevWeapon[Blaster] = Shotgun;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[Howitzer] = Mortar;
$PrevWeapon[LaserRifle] = Howitzer;
$PrevWeapon[AutoBlaster] = EnergyRifle;
$PrevWeapon[Lamprey] = AutoBlaster;
$PrevWeapon[MultiGrenadeLauncher] = Lamprey;
$PrevWeapon[SballLauncher] = MultiGrenadeLauncher;
$PrevWeapon[SniperRifle] = SballLauncher;
$PrevWeapon[PlasmaShotgun] = SniperRifle;
$PrevWeapon[RepulsorGun] = PlasmaShotgun;
$PrevWeapon[TargetingLaser] = RepulsorGun;
$PrevWeapon[EnergyRifle] = TargetingLaser;


// -------------------------------------------------
// Mission types global variables
// -------------------------------------------------

$missionTypes[0, type]        = "CandH";
$missionTypes[0, description] = "Capture and Hold";
$missionTypes[0, minTeams]    = 2;
$missionTypes[0, maxTeams]    = 8;
$missionTypes[0, varName, 0]  = numObjectives;
$missionTypes[0, varDesc, 0]  = "Number of objectives";
$missionTypes[0, varVal, 0]   = 1;
$missionTypes[0, varName, 1]  = scoreLimit;
$missionTypes[0, varDesc, 1]  = "Score limit";
$missionTypes[0, varVal, 1]   = 100;
$missionTypes[0, varName, 2]  = cdTrack;
$missionTypes[0, varDesc, 2]  = "CD Track";
$missionTypes[0, varVal, 2]   = 2;
$missionTypes[0, varName, 3]  = cdMode;
$missionTypes[0, varDesc, 3]  = "CD Play Mode";
$missionTypes[0, varVal, 3]   = 1;
 
$missionTypes[1, type]        = "CTF";
$missionTypes[1, description] = "Capture the Flag";
$missionTypes[1, minTeams]    = 2;
$missionTypes[1, maxTeams]    = 8;
$missionTypes[1, varName, 0]  = winCaps;
$missionTypes[1, varDesc, 0]  = "Flag caps to win";
$missionTypes[1, varVal, 0]   = 5;
$missionTypes[1, varName, 1]  = cdTrack;
$missionTypes[1, varDesc, 1]  = "CD Track";
$missionTypes[1, varVal, 1]   = 2;
$missionTypes[1, varName, 2]  = cdMode;
$missionTypes[1, varDesc, 2]  = "CD Play Mode";
$missionTypes[1, varVal, 2]   = 1;

$missionTypes[2, type]        = "DM";
$missionTypes[2, description] = "Death match";
$missionTypes[2, minTeams]    = 1;
$missionTypes[2, maxTeams]    = 1;
$missionTypes[2, varName, 0]  = fragLimit;
$missionTypes[2, varDesc, 0]  = "Frag limit";
$missionTypes[2, varVal, 0]   = 40;
$missionTypes[2, varName, 1]  = cdTrack;
$missionTypes[2, varDesc, 1]  = "CD Track";
$missionTypes[2, varVal, 1]   = 2;
$missionTypes[2, varName, 2]  = cdMode;
$missionTypes[2, varDesc, 2]  = "CD Play Mode";
$missionTypes[2, varVal, 2]   = 1;

$missionTypes[3, type]        = "DandD";
$missionTypes[3, description] = "Defend and Destroy";
$missionTypes[3, minTeams]    = 2;
$missionTypes[3, maxTeams]    = 8;
$missionTypes[3, varName, 0]  = scoreLimit;
$missionTypes[3, varDesc, 0]  = "Score limit";
$missionTypes[3, varVal, 0]   = 20;
$missionTypes[3, varName, 1]  = cdTrack;
$missionTypes[3, varDesc, 1]  = "CD Track";
$missionTypes[3, varVal, 1]   = 2;
$missionTypes[3, varName, 2]  = cdMode;
$missionTypes[3, varDesc, 2]  = "CD Play Mode";
$missionTypes[3, varVal, 2]   = 1;

$missionTypes[4, type]        = "FandR";
$missionTypes[4, description] = "Find and Retrieve";
$missionTypes[4, minTeams]    = 2;
$missionTypes[4, maxTeams]    = 8;
$missionTypes[4, varName, 0]  = numFlags;
$missionTypes[4, varDesc, 0]  = "Number of flags";
$missionTypes[4, varVal, 0]   = 1;
$missionTypes[4, varName, 1]  = cdTrack;
$missionTypes[4, varDesc, 1]  = "CD Track";
$missionTypes[4, varVal, 1]   = 2;
$missionTypes[4, varName, 2]  = cdMode;
$missionTypes[4, varDesc, 2]  = "CD Play Mode";
$missionTypes[4, varVal, 2]   = 1;

$missionTypes[4, type]        = "TeamDM";
$missionTypes[4, description] = "Team DeathMatch";
$missionTypes[4, minTeams]    = 2;
$missionTypes[4, maxTeams]    = 8;
$missionTypes[4, varName, 0]  = scoreLimit;
$missionTypes[4, varDesc, 0]  = "Score Limit";
$missionTypes[4, varVal, 0]   = 100;
$missionTypes[4, varName, 1]  = cdTrack;
$missionTypes[4, varDesc, 1]  = "CD Track";
$missionTypes[4, varVal, 1]   = 2;
$missionTypes[4, varName, 2]  = cdMode;
$missionTypes[4, varDesc, 2]  = "CD Play Mode";
$missionTypes[4, varVal, 2]   = 1;
