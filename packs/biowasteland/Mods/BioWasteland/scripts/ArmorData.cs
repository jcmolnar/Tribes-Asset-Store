

function BuildItemList()
{
	$armorId[0] = "aarmor";		//-- Stealth
	$armorId[1] = "afemale";
	$armorId[2] = "barmor";		//-- Goliath
	$armorId[3] = "bfemale";
	$armorId[4] = "stimarmor";	//-- Stim-Scout
	$armorId[5] = "stimfemale";
	$armorId[6] = "rarmor";		//== Runner
	$armorId[7] = "earmor";		//-- Engineer
	$armorId[8] = "efemale";
	$armorId[9] = "harmor";		//-- Dreadnaught
	$armorId[10] = "jarmor";	//-- Juggernaught
	$armorId[11] = "larmor";	//-- Assassin
	$armorId[12] = "lfemale";
	$armorId[13] = "marmor";	//-- Patriot
	$armorId[14] = "mfemale";
	$armorId[15] = "tarmor";	//-- Titan
	$armorId[16] = "sarmor";	//-- Scout
	$armorId[17] = "sfemale";
	$armorId[18] = "spyarmor";	//-- Spy
	$armorId[19] = "spyfemale";

	%max = getNumItems();
	
	for (%i = 0; %i < %max; %i++)
	{
		%itemname = getItemData(%i);
		for (%k=0; $armorId[%k] != ""; %k++)
		{
			%armor = $armorId[%k];
			$ItemMax[%armor, %itemname] = 0;
		}
		
		$ItemMax[%armor, "flag"] = 1;
	}

	$MaxWeapons[aarmor] = 4;
	$MaxWeapons[afemale] = 4;
	$MaxWeapons[barmor] = 4;
	$MaxWeapons[bfemale] = 4;
	$MaxWeapons[earmor] = 4;
	$MaxWeapons[efemale] = 4;
	$MaxWeapons[harmor] = 4;
	$MaxWeapons[jarmor] = 3;
	$MaxWeapons[larmor] = 3;
	$MaxWeapons[lfemale] = 3;
	$MaxWeapons[marmor] = 5;
	$MaxWeapons[mfemale] = 5;
	$MaxWeapons[sarmor] = 2;
	$MaxWeapons[sfemale] = 2;
	$MaxWeapons[spyarmor] = 3;
	$MaxWeapons[spyfemale] = 3;
	$MaxWeapons[stimarmor] = 2;
	$MaxWeapons[stimfemale] = 2;
	$MaxWeapons[rarmor] = 1;
	$MaxWeapons[tarmor] = 10;

//================== Stealth
$ItemMax[aarmor, Chaingun] = 1; $ItemMax[afemale, Chaingun] = 1;
$ItemMax[aarmor, ArbitorBeaconPack] = 1; $ItemMax[afemale, EMPBeaconPack] = 1;
$ItemMax[aarmor, InveiglerPack] = 1; $ItemMax[afemale, InveiglerPack] = 1;
$ItemMax[aarmor, EnergyRifle] = 1; $ItemMax[afemale, EnergyRifle] = 1;
$ItemMax[aarmor, WarpPack] = 1; $ItemMax[afemale, WarpPack] = 1;
$ItemMax[aarmor, EMPBeaconPack] = 1; $ItemMax[afemale, ShieldBeaconPack] = 1;
$ItemMax[aarmor, ShieldBeaconPack] = 1; $ItemMax[afemale, AmmoPack] = 1;
$ItemMax[aarmor, AmmoPack] = 1; $ItemMax[afemale, ArbitorBeaconPack] = 1;
$ItemMax[aarmor, BalloonPack] = 1; $ItemMax[afemale, BalloonPack] = 1;
$ItemMax[aarmor, Beacon] = 5; $ItemMax[afemale, Beacon] = 5;
$ItemMax[aarmor, BulletAmmo] = 150; $ItemMax[afemale, BulletAmmo] = 150;
$ItemMax[aarmor, Mortar] = 1; $ItemMax[afemale, Mortar] = 1;
$ItemMax[aarmor, MortarAmmo] = 7; $ItemMax[afemale, MortarAmmo] = 7;
$ItemMax[aarmor, Silencer] = 1; $ItemMax[afemale, Silencer] = 1;
$ItemMax[aarmor, SilencerAmmo] = 150; $ItemMax[afemale, SilencerAmmo] = 150;
$ItemMax[aarmor, TeleportPack] = 1; $ItemMax[afemale, TeleportPack] = 1;
$ItemMax[aarmor, TrapPack6] = 1; $ItemMax[afemale, TrapPack6] = 1;
$ItemMax[aarmor, CloakingDevice] = 1; $ItemMax[afemale, CloakingDevice] = 1;
$ItemMax[aarmor, ConCun] = 1; $ItemMax[afemale, ConCun] = 1;
$ItemMax[aarmor, DeployableAmmoPack] = 1; $ItemMax[afemale, DeployableAmmoPack] = 1;
$ItemMax[aarmor, DeployableElf] = 1; $ItemMax[afemale, DeployableElf] = 1;
$ItemMax[aarmor, DeployableInvPack] = 1; $ItemMax[afemale, DeployableInvPack] = 1;
$ItemMax[aarmor, EnergyPack] = 1; $ItemMax[afemale, EnergyPack] = 1;
$ItemMax[aarmor, ForceFieldPack] = 1; $ItemMax[afemale, ForceFieldPack] = 1;
$ItemMax[aarmor, GravGun] = 1; $ItemMax[afemale, GravGun] = 1;
$ItemMax[aarmor, Grenade] = 5; $ItemMax[afemale, Grenade] = 5;
$ItemMax[aarmor, HoloPack] = 1; $ItemMax[afemale, HoloPack] = 1;
$ItemMax[aarmor, HyperB] = 1; $ItemMax[afemale, HyperB] = 1;
$ItemMax[aarmor, LargeForceFieldPack] = 1; $ItemMax[afemale, LargeForceFieldPack] = 1;
$ItemMax[aarmor, LightningPack] = 1; $ItemMax[afemale, LightningPack] = 1;
$ItemMax[aarmor, MineAmmo] = 3; $ItemMax[afemale, MineAmmo] = 3;
$ItemMax[aarmor, MotionSensorPack] = 1; $ItemMax[afemale, MotionSensorPack] = 1;
$ItemMax[aarmor, Volter] = 1; $ItemMax[afemale, Volter] = 1;
$ItemMax[aarmor, PulseSensorPack] = 1; $ItemMax[afemale, PulseSensorPack] = 1;
$ItemMax[aarmor, LeechPack] = 1; $ItemMax[afemale, LeechPack] = 1;
$ItemMax[aarmor, RepairKit] = 1; $ItemMax[afemale, RepairKit] = 1;
$ItemMax[aarmor, RepairPack] = 1; $ItemMax[afemale, RepairPack] = 1;
$ItemMax[aarmor, ShieldPack] = 1; $ItemMax[afemale, ShieldPack] = 1;
$ItemMax[aarmor, StealthShieldPack] = 1; $ItemMax[afemale, StealthShieldPack] = 1;
$ItemMax[aarmor, TargetingLaser] = 1; $ItemMax[afemale, TargetingLaser] = 1;
$ItemMax[aarmor, TurretPack] = 1; $ItemMax[afemale, TurretPack] = 1;
$ItemMax[aarmor, MiniPlasmaCannon] = 1; $ItemMax[afemale, MiniPlasmaCannon] = 1;
//=================== Goliath
$ItemMax[barmor, TrapPack4] = 1; $ItemMax[bfemale, TrapPack4] = 1;
$ItemMax[barmor, AirAmmoPad] = 1; $ItemMax[bfemale, AirAmmoPad] = 1;
$ItemMax[barmor, AmmoPack] = 1; $ItemMax[bfemale, AmmoPack] = 1;
$ItemMax[barmor, BalloonPack] = 1; $ItemMax[bfemale, BalloonPack] = 1;
$ItemMax[barmor, Beacon] = 3; $ItemMax[bfemale, Beacon] = 3;
$ItemMax[barmor, DeployableAmmoPack] = 1; $ItemMax[bfemale, DeployableAmmoPack] = 1;
$ItemMax[barmor, DeployableElf] = 1; $ItemMax[bfemale, DeployableElf] = 1;
$ItemMax[barmor, DeployableInvPack] = 1; $ItemMax[bfemale, DeployableInvPack] = 1;
$ItemMax[barmor, DiscAmmo] = 20; $ItemMax[bfemale, DiscAmmo] = 20;
$ItemMax[barmor, Disclauncher] = 1; $ItemMax[bfemale, Disclauncher] = 1;
$ItemMax[barmor, EnergyPack] = 1; $ItemMax[bfemale, EnergyPack] = 1;
$ItemMax[barmor, Flamer] = 1; $ItemMax[bfemale, Flamer] = 1;
$ItemMax[barmor, ForceFieldPack] = 1; $ItemMax[bfemale, ForceFieldPack] = 1;
$ItemMax[barmor, Grenade] = 6; $ItemMax[bfemale, Grenade] = 6;
$ItemMax[barmor, GrenadeAmmo] = 20; $ItemMax[bfemale, GrenadeAmmo] = 20;
$ItemMax[barmor, GrenadeLauncher] = 1; $ItemMax[bfemale, GrenadeLauncher] = 1;
$ItemMax[barmor, HoloPack] = 1; $ItemMax[bfemale, HoloPack] = 1;
$ItemMax[barmor, JawPack] = 1; $ItemMax[bfemale, JawPack] = 1;
$ItemMax[barmor, MineAmmo] = 6; $ItemMax[bfemale, MineAmmo] = 6;
$ItemMax[barmor, Mortar] = 1; $ItemMax[bfemale, Mortar] = 1;
$ItemMax[barmor, MortarAmmo] = 5; $ItemMax[bfemale, MortarAmmo] = 5;
$ItemMax[barmor, MotionSensorPack] = 1; $ItemMax[bfemale, MotionSensorPack] = 1;
$ItemMax[barmor, PlasmaAmmo] = 40; $ItemMax[bfemale, PlasmaAmmo] = 40;
$ItemMax[barmor, PlasmaGun] = 1; $ItemMax[bfemale, PlasmaGun] = 1;
$ItemMax[barmor, PulseSensorPack] = 1; $ItemMax[bfemale, PulseSensorPack] = 1;
$ItemMax[barmor, RepairKit] = 1; $ItemMax[bfemale, RepairKit] = 1;
$ItemMax[barmor, RepairPack] = 1; $ItemMax[bfemale, RepairPack] = 1;
$ItemMax[barmor, RocketAmmo] = 12; $ItemMax[bfemale, RocketAmmo] = 12;
$ItemMax[barmor, RocketLauncher] = 1; $ItemMax[bfemale, RocketLauncher] = 1;
$ItemMax[barmor, RocketPack] = 1; $ItemMax[bfemale, RocketPack] = 1;
$ItemMax[barmor, SensorJammerPack] = 1; $ItemMax[bfemale, SensorJammerPack] = 1;
$ItemMax[barmor, ShieldPack] = 1; $ItemMax[bfemale, ShieldPack] = 1;
$ItemMax[barmor, StealthShieldPack] = 1; $ItemMax[bfemale, StealthShieldPack] = 1;
$ItemMax[barmor, FgcPack] = 1; $ItemMax[bfemale, FgcPack] = 1;
$ItemMax[barmor, TargetingLaser] = 1; $ItemMax[bfemale, TargetingLaser] = 1;
$ItemMax[barmor, MiniPlasmaCannon] = 1; $ItemMax[bfemale, MiniPlasmaCannon] = 1;
//===================== Dreadnaught
$ItemMax[harmor, AirAmmoPad] = 1;
$ItemMax[harmor, AmmoPack] = 1;
$ItemMax[harmor, AutoRocketAmmo] = 20;
$ItemMax[harmor, BalloonPack] = 1;
$ItemMax[harmor, Beacon] = 3;
$ItemMax[harmor, Blaster] = 1;
$ItemMax[harmor, BulletAmmo] = 200;
$ItemMax[harmor, ConCun] = 1;
$ItemMax[harmor, DeployableAmmoPack] = 1;
$ItemMax[harmor, DeployableComPack] = 1;
$ItemMax[harmor, DeployableInvPack] = 1;
$ItemMax[harmor, DiscAmmo] = 30;
$ItemMax[harmor, Disclauncher] = 1;
$ItemMax[harmor, EnergyPack] = 1;
$ItemMax[harmor, Equalizer] = 1;
$ItemMax[harmor, FgcPack] = 1;
$ItemMax[harmor, ForceFieldPack] = 1;
$ItemMax[harmor, Grenade] = 3;
$ItemMax[harmor, GrenadeAmmo] = 15;
$ItemMax[harmor, GrenadeLauncher] = 1;
$ItemMax[harmor, HolePack] = 1;
$ItemMax[harmor, HoloPack] = 1;
$ItemMax[harmor, Mfgl] = 1;
$ItemMax[harmor, MfglAmmo] = 1;
$ItemMax[harmor, MineAmmo] = 5;
$ItemMax[harmor, Mortar] = 1;
$ItemMax[harmor, MortarAmmo] = 10;
$ItemMax[harmor, MotionSensorPack] = 1;
$ItemMax[harmor, PlasmaAmmo] = 50;
$ItemMax[harmor, PlasmaGun] = 1;
$ItemMax[harmor, PlasmaTurretPack] = 1;
$ItemMax[harmor, PulseSensorPack] = 1;
$ItemMax[harmor, RepairKit] = 1;
$ItemMax[harmor, RepairPack] = 1;
$ItemMax[harmor, RocketAmmo] = 15;
$ItemMax[harmor, RocketLauncher] = 1;
$ItemMax[harmor, ShieldPack] = 1;
$ItemMax[harmor, StealthShieldPack] = 1;
$ItemMax[harmor, TargetingLaser] = 1;
$ItemMax[harmor, TurretPack] = 1;
$ItemMax[harmor, Vulcan] = 1;
$ItemMax[harmor, BarragePack] = 1;
$ItemMax[harmor, ShockFloorPack] = 1;
$ItemMax[harmor, MiniPlasmaCannon] = 1;
//====================================================== Engineer
$ItemMax[earmor, AntennaPack] = 1; $ItemMax[efemale, AntennaPack] = 1;
$ItemMax[earmor, BasePack] = 1; $ItemMax[efemale, BasePack] = 1;
$ItemMax[earmor, MalicePack] = 1; $ItemMax[efemale, MalicePack] = 1;
$ItemMax[earmor, Sentry] = 1; $ItemMax[efemale, Sentry] = 1;
$ItemMax[earmor, ElectricWeb] = 1; $ItemMax[efemale, ElectricWeb] = 1;
$ItemMax[earmor, ElectricFloor] = 1; $ItemMax[efemale, ElectricFloor] = 1;
$ItemMax[earmor, Elevator] = 1; $ItemMax[efemale, Elevator] = 1;
$ItemMax[earmor, EmergencyInvPack] = 1; $ItemMax[efemale, EmergencyInvPack] = 1;
$ItemMax[earmor, GunTuretPack] = 1; $ItemMax[efemale, GunTurtPack] = 1;
$ItemMax[earmor, JawPack] = 1; $ItemMax[efemale, JawPack] = 1;
$ItemMax[earmor, ArbitorBeaconPack] = 1; $ItemMax[efemale, ArbitorBeaconPack] = 1;
$ItemMax[earmor, EMPBeaconPack] = 1; $ItemMax[efemale, EMPBeaconPack] = 1;
$ItemMax[earmor, PowerGeneratorPack] = 1; $ItemMax[efemale, PowerGeneratorPack] = 1;
$ItemMax[earmor, ShieldBeaconPack] = 1; $ItemMax[efemale, ShieldBeaconPack] = 1;
$ItemMax[earmor, AccelPPack] = 1; $ItemMax[efemale, AccelPPack] = 1;
$ItemMax[earmor, AirAmmoPad] = 1; $ItemMax[efemale, AirAmmoPad] = 1;
$ItemMax[earmor, AirBase] = 1; $ItemMax[efemale, AirBase] = 1;
$ItemMax[earmor, AmmoPack] = 1; $ItemMax[efemale, AmmoPack] = 1;
$ItemMax[earmor, AutoRocketAmmo] = 10; $ItemMax[efemale, AutoRocketAmmo] = 10;
$ItemMax[earmor, BalloonPack] = 1; $ItemMax[efemale, BalloonPack] = 1;
$ItemMax[earmor, Beacon] = 3; $ItemMax[efemale, Beacon]= 3;
$ItemMax[earmor, Blaster] = 1; $ItemMax[efemale, Blaster] = 1;
$ItemMax[earmor, BlastDoorPack] = 1; $ItemMax[efemale, BlastDoorPack] = 1;
$ItemMax[earmor, BlastFloorPack] = 1; $ItemMax[efemale, BlastFloorPack] = 1;
$ItemMax[earmor, BlastWallPack] = 1; $ItemMax[efemale, BlastWallPack] = 1;
$ItemMax[earmor, BulletAmmo] = 200; $ItemMax[efemale, BulletAmmo] = 200;
$ItemMax[earmor, DeployableAmmoPack] = 1; $ItemMax[efemale, DeployableAmmoPack] = 1;
$ItemMax[earmor, DeployableComPack] = 1; $ItemMax[efemale, DeployableComPack] = 1;
$ItemMax[earmor, DeployableElf] = 1; $ItemMax[efemale, DeployableElf] = 1;
$ItemMax[earmor, DeployableInvPack] = 1; $ItemMax[efemale, DeployableInvPack] = 1;
$ItemMax[earmor, DeployableSensorJammerPack] = 1; $ItemMax[efemale, DeployableSensorJammerPack] = 1;
$ItemMax[earmor, DiscAmmo] = 15; $ItemMax[efemale, DiscAmmo] = 15;
$ItemMax[earmor, Disclauncher] = 1; $ItemMax[efemale, Disclauncher] = 1;
$ItemMax[earmor, disit] = 1; $ItemMax[efemale, disit]=1;
$ItemMax[earmor, BunkerPack] = 1; $ItemMax[efemale, BunkerPack] = 1;
$ItemMax[earmor, EnergyPack] = 1; $ItemMax[efemale, EnergyPack] = 1;
$ItemMax[earmor, Equalizer] = 1; $ItemMax[efemale, Equalizer] = 1;
$ItemMax[earmor, Fixit] = 1; $ItemMax[efemale, Fixit]=1;
$ItemMax[earmor, ForceFieldPack] = 1; $ItemMax[efemale, ForceFieldPack] = 1;
$ItemMax[earmor, ShockFloorPack] = 1; $ItemMax[efemale, ShockFloorPack] = 1;
$ItemMax[earmor, GravGun] = 1; $ItemMax[efemale, GravGun] = 1;
$ItemMax[earmor, Grenade] = 4; $ItemMax[efemale, Grenade] = 4;
$ItemMax[earmor, GrenadeAmmo] = 10; $ItemMax[efemale, GrenadeAmmo] = 10;
$ItemMax[earmor, GrenadeLauncher] = 1; $ItemMax[efemale, GrenadeLauncher] = 1;
$ItemMax[earmor, Hackit] = 1; $ItemMax[efemale, Hackit]= 1;
$ItemMax[earmor, HoloPack] = 1; $ItemMax[efemale, HoloPack] = 1;
$ItemMax[earmor, Laptop] = 1; $ItemMax[efemale, Laptop]= 1;
$ItemMax[earmor, LargeForceFieldPack] = 1; $ItemMax[efemale, LargeForceFieldPack] = 1;
$ItemMax[earmor, LargeShockForceFieldPack] = 1; $ItemMax[efemale, LargeShockForceFieldPack] = 1;
$ItemMax[earmor, LaserPack] = 1; $ItemMax[efemale, LaserPack] = 1;
$ItemMax[earmor, LaunchPack] = 1; $ItemMax[efemale, LaunchPack] = 1;
$ItemMax[earmor, LockOutPack] = 1; $ItemMax[efemale, LockOutPack]= 1;
$ItemMax[earmor, MineAmmo] = 3; $ItemMax[efemale, MineAmmo] = 3;
$ItemMax[earmor, MotionSensorPack] = 1; $ItemMax[efemale, MotionSensorPack] = 1;
$ItemMax[earmor, PlantPack] = 1; $ItemMax[efemale, PlantPack] = 1;
$ItemMax[earmor, PlasmaAmmo] = 30; $ItemMax[efemale, PlasmaAmmo] = 30;
$ItemMax[earmor, PlasmaGun] = 1; $ItemMax[efemale, PlasmaGun] = 1;
$ItemMax[earmor, PlasmaTurretPack] = 1; $ItemMax[efemale, PlasmaTurretPack] = 1;
$ItemMax[earmor, PulseSensorPack] = 1; $ItemMax[efemale, PulseSensorPack] = 1;
$ItemMax[earmor, prismPack] = 1; $ItemMax[efemale, prismPack] = 1;
$ItemMax[earmor, RifleAmmo] = 10; $ItemMax[efemale, RifleAmmo] = 10;
$ItemMax[earmor, Railgun] = 1; $ItemMax[efemale, Railgun] = 1;
$ItemMax[earmor, ReconPack] = 1; $ItemMax[efemale, ReconPack]= 1;
$ItemMax[earmor, RepairKit] = 1; $ItemMax[efemale, RepairKit] = 1;
$ItemMax[earmor, RepairGun] = 1; $ItemMax[efemale, RepairGun] = 1;
$ItemMax[earmor, RepairPack] = 1; $ItemMax[efemale, RepairPack] = 1;
$ItemMax[earmor, RocketAmmo] = 5; $ItemMax[efemale, RocketAmmo] = 5;
$ItemMax[earmor, RocketLauncher] = 1; $ItemMax[efemale, RocketLauncher] = 1;
$ItemMax[earmor, RocketPack] = 1; $ItemMax[efemale, RocketPack] = 1;
$ItemMax[earmor, SeedPack] = 1; $ItemMax[efemale, SeedPack] = 1;
$ItemMax[earmor, SensorJammerPack] = 1; $ItemMax[efemale, SensorJammerPack] = 1;
$ItemMax[earmor, ShieldPack] = 1; $ItemMax[efemale, ShieldPack] = 1;
$ItemMax[earmor, ShockPack] = 1; $ItemMax[efemale, ShockPack] = 1;
$ItemMax[earmor, SkyEyePack] = 1; $ItemMax[efemale, SkyEyePack] = 1;
$ItemMax[earmor, SmartPack] = 1; $ItemMax[efemale, SmartPack] = 1;
$ItemMax[earmor, SprayCan] = 1; $ItemMax[efemale, SprayCan] = 1;
$ItemMax[earmor, PaintAmmo] = 20; $ItemMax[efemale, PaintAmmo] = 20;
$ItemMax[earmor, StealthShieldPack] = 1; $ItemMax[efemale, StealthShieldPack] = 1;
$ItemMax[earmor, SwitchPack] = 1; $ItemMax[efemale, SwitchPack] = 1;
$ItemMax[earmor, TargetingLaser] = 1; $ItemMax[efemale, TargetingLaser] = 1;
$ItemMax[earmor, TargetPack] = 1; $ItemMax[efemale, TargetPack] = 1;
$ItemMax[earmor, TeleportPack] = 1; $ItemMax[efemale, TeleportPack] = 1;
$ItemMax[earmor, TreePack] = 1; $ItemMax[efemale, TreePack] = 1;
$ItemMax[earmor, TurretPack] = 1; $ItemMax[efemale, TurretPack] = 1;
$ItemMax[earmor, EngineerTurretPack] = 1; $ItemMax[efemale, EngineerTurretPack] = 1;
$ItemMax[earmor, BarragePack] = 1; $ItemMax[efemale, BarragePack] = 1;
$ItemMax[earmor, JammerBeaconPack] = 1; $ItemMax[efemale, JammerBeaconPack] = 1;
$ItemMax[earmor, ZepplinPack] = 1; $ItemMax[efemale, ZepplinPack] = 1;
//Additions
$ItemMax[earmor, RailTurretPack] = 1; $ItemMax[efemale, RailTurretPack] = 1;
$ItemMax[earmor, FlameTurretPack] = 1; $ItemMax[efemale, FlameTurretPack] = 1;
$ItemMax[earmor, JailPack] = 1; $ItemMax[efemale, JailPack] = 1;
$ItemMax[earmor, JailCapPack] = 1; $ItemMax[efemale, JailCapPack] = 1;
$ItemMax[earmor, JailGun] = 1; $ItemMax[efemale, JailGun] = 1;
$ItemMax[earmor, ChaingunTurretPack] = 1; $ItemMax[efemale, ChaingunTurretPack] = 1;
$ItemMax[earmor, VulcanTurretPack] = 1; $ItemMax[efemale, VulcanTurretPack] = 1;
$ItemMax[earmor, ConPack] = 1; $ItemMax[efemale, ConPack] = 1;
$ItemMax[earmor, FlakPack] = 1; $ItemMax[efemale, FlakPack] = 1;
$ItemMax[earmor, AGravPack] = 1; $ItemMax[efemale, AGravPack] = 1;
$ItemMax[earmor, HGravTurretPack] = 1; $ItemMax[efemale, HGravTurretPack] = 1;
$ItemMax[earmor, Vulcan] = 1; $ItemMax[efemale, Vulcan] = 1;
//End Additions

//====================================================== Juggernaught
$ItemMax[jarmor, BalloonPack] = 1;
$ItemMax[jarmor, Beacon] = 5;
$ItemMax[jarmor, Grenade] = 1;
$ItemMax[jarmor, LasCannon] = 1;
$ItemMax[jarmor, MineAmmo] = 1;
$ItemMax[jarmor, Mortar] = 1;
$ItemMax[jarmor, MortarAmmo] = 25;
$ItemMax[jarmor, RepairKit] = 1;
$ItemMax[jarmor, RocketAmmo] = 25;
$ItemMax[jarmor, RocketLauncher] = 1;
$ItemMax[jarmor, PlasmaCannon] = 1;
$ItemMax[jarmor, TargetingLaser] = 1;
$ItemMax[jarmor, Hammer1Pack] = 1;
$ItemMax[jarmor, Hammer2Pack] = 1;
$ItemMax[jarmor, MiniPlasmaCannon] = 1;
//====================================================== Assassin
$ItemMax[larmor, ElectricWeb] = 1; $ItemMax[lfemale, ElectricWeb] = 1;
$ItemMax[larmor, ElectricFloor] = 1; $ItemMax[lfemale, ElectricFloor] = 1;
$ItemMax[larmor, ArbitorBeaconPack] = 1; $ItemMax[lfemale, ArbitorBeaconPack] = 1;
$ItemMax[larmor, AmmoPack] = 1; $ItemMax[lfemale, AmmoPack] = 1;
$ItemMax[larmor, BalloonPack] = 1; $ItemMax[lfemale, BalloonPack] = 1;
$ItemMax[larmor, Beacon] = 5; $ItemMax[lfemale, Beacon] = 5;
$ItemMax[larmor, Blaster] = 1; $ItemMax[lfemale, Blaster] = 1;
$ItemMax[larmor, BoomAmmo] = 10; $ItemMax[lfemale, BoomAmmo] = 10;
$ItemMax[larmor, BoomStick] = 1; $ItemMax[lfemale, BoomStick] = 1;
$ItemMax[larmor, BulletAmmo] = 75; $ItemMax[lfemale, BulletAmmo] = 75;
$ItemMax[larmor, CameraPack] = 1; $ItemMax[lfemale, CameraPack] = 1;
$ItemMax[larmor, Chaingun] = 1; $ItemMax[lfemale, Chaingun] = 1;
$ItemMax[larmor, DiscAmmo] = 15; $ItemMax[lfemale, DiscAmmo] = 15;
$ItemMax[larmor, Disclauncher] = 1; $ItemMax[lfemale, Disclauncher] = 1;
$ItemMax[larmor, EnergyPack] = 1; $ItemMax[lfemale, EnergyPack] = 1;
$ItemMax[larmor, ForceFieldPack] = 1; $ItemMax[lfemale, ForceFieldPack] = 1;
$ItemMax[larmor, Grenade] = 3; $ItemMax[lfemale, Grenade] = 3;
$ItemMax[larmor, GrenadeAmmo] = 10; $ItemMax[lfemale, GrenadeAmmo] = 10;
$ItemMax[larmor, GrenadeLauncher] = 1; $ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[larmor, HoloPack] = 1; $ItemMax[lfemale, HoloPack] = 1;
$ItemMax[larmor, LaserPack] = 1; $ItemMax[lfemale, LaserPack] = 1;
$ItemMax[larmor, LaserRifle] = 1; $ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[larmor, MineAmmo] = 3; $ItemMax[lfemale, MineAmmo] = 3;
$ItemMax[larmor, MotionSensorPack] = 1; $ItemMax[lfemale, MotionSensorPack] = 1;
$ItemMax[larmor, PlasmaAmmo] = 30; $ItemMax[lfemale, PlasmaAmmo] = 30;
$ItemMax[larmor, PlasmaGun] = 1; $ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[larmor, PulseSensorPack] = 1; $ItemMax[lfemale, PulseSensorPack] = 1;
$ItemMax[larmor, RepairKit] = 1; $ItemMax[lfemale, RepairKit] = 1;
$ItemMax[larmor, RepairPack] = 1; $ItemMax[lfemale, RepairPack] = 1;
$ItemMax[larmor, SensorJammerPack] = 1; $ItemMax[lfemale, SensorJammerPack] = 1;
$ItemMax[larmor, ShieldPack] = 1; $ItemMax[lfemale, ShieldPack] = 1;
$ItemMax[larmor, SMML] = 1; $ItemMax[lfemale, SMML] = 1;
$ItemMax[larmor, StrikePack] = 1; $ItemMax[lfemale, StrikePack] = 1;
$ItemMax[larmor, RifleAmmo] = 25; $ItemMax[lfemale, RifleAmmo] = 25;
$ItemMax[larmor, SniperRifle2] = 1; $ItemMax[lfemale, SniperRifle2] = 1;
$ItemMax[larmor, StealthShieldPack] = 1; $ItemMax[lfemale, StealthShieldPack] = 1;
$ItemMax[larmor, TargetingLaser] = 1; $ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[larmor, TranqGun] = 1; $ItemMax[lfemale, TranqGun] = 1;
$ItemMax[larmor, TrapPack3] = 1; $ItemMax[lfemale, TrapPack3] = 1;
$ItemMax[larmor, TreePack] = 1; $ItemMax[lfemale, TreePack] = 1;

$ItemMax[larmor, HellFireModule] = 1; $ItemMax[lfemale, HellFireModule] = 1;
$ItemMax[larmor, DetPackModule] = 1; $ItemMax[lfemale, DetPackModule] = 1;
$ItemMax[larmor, RamModule] = 1; $ItemMax[lfemale, RamModule] = 1;
$ItemMax[larmor, WraithModule] = 1; $ItemMax[lfemale, WraithModule] = 1;
 
//====================================================== Patriot
$ItemMax[marmor, BattlePack] = 1; $ItemMax[mfemale, BattlePack] = 1;
$ItemMax[marmor, HolePack] = 1; $ItemMax[mfemale, HolePack] = 1;
$ItemMax[marmor, AmmoPack] = 1; $ItemMax[mfemale, AmmoPack] = 1;
$ItemMax[marmor, BalloonPack] = 1; $ItemMax[mfemale, BalloonPack] = 1;
$ItemMax[marmor, Beacon] = 3; $ItemMax[mfemale, Beacon] = 3;
$ItemMax[marmor, Blaster] = 1; $ItemMax[mfemale, Blaster] = 1;
$ItemMax[marmor, BoomAmmo] = 15; $ItemMax[mfemale, BoomAmmo] = 15;
$ItemMax[marmor, BoomStick] = 1; $ItemMax[mfemale, BoomStick] = 1;
$ItemMax[marmor, BulletAmmo] = 300; $ItemMax[mfemale, BulletAmmo] = 300;
$ItemMax[marmor, DeployableAmmoPack] = 1; $ItemMax[mfemale, DeployableAmmoPack] = 1;
$ItemMax[marmor, DeployableInvPack] = 1; $ItemMax[mfemale, DeployableInvPack] = 1;
$ItemMax[marmor, DeployableSensorJammerPack] = 1; $ItemMax[mfemale, DeployableSensorJammerPack] = 1;
$ItemMax[marmor, DiscAmmo] = 20; $ItemMax[mfemale, DiscAmmo] = 20;
$ItemMax[marmor, Disclauncher] = 1; $ItemMax[mfemale, Disclauncher] = 1;
$ItemMax[marmor, EnergyPack] = 1; $ItemMax[mfemale, EnergyPack] = 1;
$ItemMax[marmor, Equalizer] = 1; $ItemMax[mfemale, Equalizer] = 1;
$ItemMax[marmor, ForceFieldPack] = 1; $ItemMax[mfemale, ForceFieldPack] = 1;
$ItemMax[marmor, Grenade] = 6; $ItemMax[mfemale, Grenade] = 6;
$ItemMax[marmor, GrenadeAmmo] = 10; $ItemMax[mfemale, GrenadeAmmo] = 10;
$ItemMax[marmor, GrenadeLauncher] = 1; $ItemMax[mfemale, GrenadeLauncher] = 1;
$ItemMax[marmor, HoloPack] = 1; $ItemMax[mfemale, HoloPack] = 1;
$ItemMax[marmor, HyperB] = 1; $ItemMax[mfemale, HyperB] = 1;
$ItemMax[marmor, JawPack] = 1; $ItemMax[mfemale, JawPack] = 1;
$ItemMax[marmor, MagBridgePack] = 1; $ItemMax[mfemale, MagBridgePack] = 1;
$ItemMax[marmor, MineAmmo] = 3; $ItemMax[mfemale, MineAmmo] = 3;
$ItemMax[marmor, MotionSensorPack] = 1; $ItemMax[mfemale, MotionSensorPack] = 1;
$ItemMax[marmor, PlasmaAmmo] = 40; $ItemMax[mfemale, PlasmaAmmo] = 40;
$ItemMax[marmor, PlasmaGun] = 1; $ItemMax[mfemale, PlasmaGun] = 1;
$ItemMax[marmor, PulseSensorPack] = 1; $ItemMax[mfemale, PulseSensorPack] = 1;
$ItemMax[marmor, RepairKit] = 1; $ItemMax[mfemale, RepairKit] = 1;
$ItemMax[marmor, RepairPack] = 1; $ItemMax[mfemale, RepairPack] = 1;
$ItemMax[marmor, RocketAmmo] = 5; $ItemMax[mfemale, RocketAmmo] = 5;
$ItemMax[marmor, RocketLauncher] = 1; $ItemMax[mfemale, RocketLauncher] = 1;
$ItemMax[marmor, SensorJammerPack] = 1; $ItemMax[mfemale, SensorJammerPack] = 1;
$ItemMax[marmor, ShieldPack] = 1; $ItemMax[mfemale, ShieldPack] = 1;
$ItemMax[marmor, StealthShieldPack] = 1; $ItemMax[mfemale, StealthShieldPack] = 1;
$ItemMax[marmor, TargetingLaser] = 1; $ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[marmor, TrapPack2] = 1; $ItemMax[mfemale, TrapPack2] = 1;
$ItemMax[marmor, TurretPack] = 1; $ItemMax[mfemale, TurretPack] = 1;
$ItemMax[marmor, Vulcan] = 1; $ItemMax[mfemale, Vulcan] = 1;
$ItemMax[marmor, Silencer] = 1; $ItemMax[mfemale, Silencer] = 1;
$ItemMax[marmor, SilencerAmmo] = 125; $ItemMax[mfemale, SilencerAmmo] = 125;
$ItemMax[marmor, BarragePack] = 1; $ItemMax[mfemale, BarragePack] = 1;
$ItemMax[marmor, Booster1Pack] = 1; $ItemMax[mfemale, Booster1Pack] = 1;
$ItemMax[marmor, Booster2Pack] = 1; $ItemMax[mfemale, Booster2Pack] = 1;
$ItemMax[marmor, MiniPlasmaCannon] = 1; $ItemMax[mfemale, MiniPlasmaCannon] = 1;
//====================================================== Scout
$ItemMax[sarmor, SpawnPack] = 1; $ItemMax[sfemale, SpawnPack] = 1;
$ItemMax[sarmor, ChaingunTurretPack] = 1; $ItemMax[sfemale, ChaingunTurretPack] = 1;
$ItemMax[sarmor, AmmoPack] = 1; $ItemMax[sfemale, AmmoPack] = 1;
$ItemMax[sarmor, BalloonPack] = 1; $ItemMax[sfemale, BalloonPack] = 1;
$ItemMax[sarmor, Beacon] = 3; $ItemMax[sfemale, Beacon] = 3;
$ItemMax[sarmor, Blaster] = 1; $ItemMax[sfemale, Blaster] = 1;
$ItemMax[sarmor, BoomAmmo] = 10; $ItemMax[sfemale, BoomAmmo] = 10;
$ItemMax[sarmor, BoomStick] = 1; $ItemMax[sfemale, BoomStick] = 1;
$ItemMax[sarmor, BulletAmmo] = 50; $ItemMax[sfemale, BulletAmmo] = 50;
$ItemMax[sarmor, Chaingun] = 1; $ItemMax[sfemale, Chaingun] = 1;
$ItemMax[sarmor, DiscAmmo] = 15; $ItemMax[sfemale, DiscAmmo] = 15;
$ItemMax[sarmor, Disclauncher] = 1; $ItemMax[sfemale, Disclauncher] = 1;
$ItemMax[sarmor, EnergyPack] = 1; $ItemMax[sfemale, EnergyPack] = 1;
$ItemMax[sarmor, Flamer] = 1; $ItemMax[sfemale, Flamer] = 1;
$ItemMax[sarmor, FlightPack] = 1; $ItemMax[sfemale, FlightPack] = 1;
$ItemMax[sarmor, ForceFieldPack] = 1; $ItemMax[sfemale, ForceFieldPack] = 1;
$ItemMax[sarmor, Grenade] = 5; $ItemMax[sfemale, Grenade] = 5;
$ItemMax[sarmor, GrenadeAmmo] = 10; $ItemMax[sfemale, GrenadeAmmo] = 10;
$ItemMax[sarmor, GrenadeLauncher] = 1; $ItemMax[sfemale, GrenadeLauncher] = 1;
$ItemMax[sarmor, HoloPack] = 1; $ItemMax[sfemale, HoloPack] = 1;
$ItemMax[sarmor, HyperB] = 1; $ItemMax[sfemale, HyperB] = 1;
$ItemMax[sarmor, Laptop] = 1; $ItemMax[sfemale, Laptop] = 1;
$ItemMax[sarmor, ReconPack] = 1; $ItemMax[sfemale, ReconPack]= 1;
$ItemMax[sarmor, LaserRifle] = 1; $ItemMax[sfemale, LaserRifle] = 1;
$ItemMax[sarmor, MechPack] = 1; $ItemMax[sfemale, MechPack] = 1;
$ItemMax[sarmor, MineAmmo] = 3; $ItemMax[sfemale, MineAmmo] = 3;
$ItemMax[sarmor, MotionSensorPack] = 1; $ItemMax[sfemale, MotionSensorPack] = 1;
$ItemMax[sarmor, PlasmaAmmo] = 30; $ItemMax[sfemale, PlasmaAmmo] = 30;
$ItemMax[sarmor, PlasmaGun] = 1; $ItemMax[sfemale, PlasmaGun] = 1;
$ItemMax[sarmor, PulseSensorPack] = 1; $ItemMax[sfemale, PulseSensorPack] = 1;
$ItemMax[sarmor, RepairKit] = 1; $ItemMax[sfemale, RepairKit] = 1;
$ItemMax[sarmor, RepairPack] = 1; $ItemMax[sfemale, RepairPack] = 1;
$ItemMax[sarmor, SensorJammerPack] = 1; $ItemMax[sfemale, SensorJammerPack] = 1;
$ItemMax[sarmor, ShieldPack] = 1; $ItemMax[sfemale, ShieldPack] = 1;
$ItemMax[sarmor, SmartPack] = 1; $ItemMax[sfemale, SmartPack] = 1;
$ItemMax[sarmor, SortieGun] = 1; $ItemMax[sfemale, SortieGun] = 1;
$ItemMax[sarmor, StealthShieldPack] = 1; $ItemMax[sfemale, StealthShieldPack] = 1;
$ItemMax[sarmor, TargetingLaser] = 1; $ItemMax[sfemale, TargetingLaser] = 1;
$ItemMax[sarmor, TrapPack1] = 1; $ItemMax[sfemale, TrapPack1] = 1;

$ItemMax[sarmor, HellFireModule] = 1; $ItemMax[sfemale, HellFireModule] = 1;
$ItemMax[sarmor, DetPackModule] = 1; $ItemMax[sfemale, DetPackModule] = 1;
$ItemMax[sarmor, RamModule] = 1; $ItemMax[sfemale, RamModule] = 1;
$ItemMax[sarmor, WraithModule] = 1; $ItemMax[sfemale, WraithModule] = 1;
//====================================================== Stim Scout
$ItemMax[stimarmor, AmmoPack] = 1; $ItemMax[stimfemale, AmmoPack] = 1;
$ItemMax[stimarmor, Beacon] = 3; $ItemMax[stimfemale, Beacon] = 3;
$ItemMax[stimarmor, Blaster] = 1; $ItemMax[stimfemale, Blaster] = 1;
$ItemMax[stimarmor, BoomAmmo] = 10; $ItemMax[stimfemale, BoomAmmo] = 10;
$ItemMax[stimarmor, BoomStick] = 1; $ItemMax[stimfemale, BoomStick] = 1;
$ItemMax[stimarmor, BulletAmmo] = 50; $ItemMax[stimfemale, BulletAmmo] = 50;
$ItemMax[stimarmor, Chaingun] = 1; $ItemMax[stimfemale, Chaingun] = 1;
$ItemMax[stimarmor, DiscAmmo] = 15; $ItemMax[stimfemale, DiscAmmo] = 15;
$ItemMax[stimarmor, Disclauncher] = 1; $ItemMax[stimfemale, Disclauncher] = 1;
$ItemMax[stimarmor, EnergyPack] = 1; $ItemMax[stimfemale, EnergyPack] = 1;
$ItemMax[stimarmor, Flamer] = 1; $ItemMax[stimfemale, Flamer] = 1;
$ItemMax[stimarmor, FlightPack] = 1; $ItemMax[stimfemale, FlightPack] = 1;
$ItemMax[stimarmor, ForceFieldPack] = 1; $ItemMax[stimfemale, ForceFieldPack] = 1;
$ItemMax[stimarmor, Grenade] = 5; $ItemMax[stimfemale, Grenade] = 5;
$ItemMax[stimarmor, GrenadeAmmo] = 10; $ItemMax[stimfemale, GrenadeAmmo] = 10;
$ItemMax[stimarmor, GrenadeLauncher] = 1; $ItemMax[stimfemale, GrenadeLauncher] = 1;
$ItemMax[stimarmor, HoloPack] = 1; $ItemMax[stimfemale, HoloPack] = 1;
$ItemMax[stimarmor, HyperB] = 1; $ItemMax[stimfemale, HyperB] = 1;
$ItemMax[stimarmor, Laptop] = 1; $ItemMax[stimfemale, Laptop] = 1;
$ItemMax[stimarmor, LaserRifle] = 1; $ItemMax[stimfemale, LaserRifle] = 1;
$ItemMax[stimarmor, MechPack] = 1; $ItemMax[stimfemale, MechPack] = 1;
$ItemMax[stimarmor, MineAmmo] = 3; $ItemMax[stimfemale, MineAmmo] = 3;
$ItemMax[stimarmor, MotionSensorPack] = 1; $ItemMax[stimfemale, MotionSensorPack] = 1;
$ItemMax[stimarmor, PlasmaAmmo] = 40; $ItemMax[stimfemale, PlasmaAmmo] = 40;
$ItemMax[stimarmor, PlasmaGun] = 1; $ItemMax[stimfemale, PlasmaGun] = 1;
$ItemMax[stimarmor, PulseSensorPack] = 1; $ItemMax[stimfemale, PulseSensorPack] = 1;
$ItemMax[stimarmor, RepairKit] = 1; $ItemMax[stimfemale, RepairKit] = 1;
$ItemMax[stimarmor, RepairPack] = 1; $ItemMax[stimfemale, RepairPack] = 1;
$ItemMax[stimarmor, SensorJammerPack] = 1; $ItemMax[stimfemale, SensorJammerPack] = 1;
$ItemMax[stimarmor, ShieldPack] = 1; $ItemMax[stimfemale, ShieldPack] = 1;
$ItemMax[stimarmor, SortieGun] = 1; $ItemMax[stimfemale, SortieGun] = 1;
$ItemMax[stimarmor, StealthShieldPack] = 1; $ItemMax[stimfemale, StealthShieldPack] = 1;
$ItemMax[stimarmor, TargetingLaser] = 1; $ItemMax[stimfemale, TargetingLaser] = 1;
//====================================================== Spy
$ItemMax[spyarmor, TrapPack1] = 1; $ItemMax[spyfemale, TrapPack1] = 1;
$ItemMax[spyarmor, TrapPack2] = 1; $ItemMax[spyfemale, TrapPack2] = 1;
$ItemMax[spyarmor, TrapPack3] = 1; $ItemMax[spyfemale, TrapPack3] = 1;
$ItemMax[spyarmor, TrapPack4] = 1; $ItemMax[spyfemale, TrapPack4] = 1;
$ItemMax[spyarmor, TrapPack5] = 1; $ItemMax[spyfemale, TrapPack5] = 1;
$ItemMax[spyarmor, TrapPack6] = 1; $ItemMax[spyfemale, TrapPack6] = 1;
$ItemMax[spyarmor, AmmoPack] = 1; $ItemMax[spyfemale, AmmoPack] = 1;
$ItemMax[spyarmor, BalloonPack] = 1; $ItemMax[spyfemale, BalloonPack] = 1;
$ItemMax[spyarmor, Beacon] = 3; $ItemMax[spyfemale, Beacon] = 3;
$ItemMax[spyarmor, Blaster] = 1; $ItemMax[spyfemale, Blaster] = 1;
$ItemMax[spyarmor, BoomAmmo] = 10; $ItemMax[spyfemale, BoomAmmo] = 10;
$ItemMax[spyarmor, BoomStick] = 1; $ItemMax[spyfemale, BoomStick] = 1;
$ItemMax[spyarmor, BulletAmmo] = 75; $ItemMax[spyfemale, BulletAmmo] = 75;
$ItemMax[spyarmor, Chaingun] = 1; $ItemMax[spyfemale, Chaingun] = 1;
$ItemMax[spyarmor, CloakingDevice] = 1; $ItemMax[spyfemale, CloakingDevice] = 1;
$ItemMax[spyarmor, DeployableSensorJammerPack] = 1; $ItemMax[spyfemale, DeployableSensorJammerPack] = 1;
$ItemMax[spyarmor, DiscAmmo] = 15; $ItemMax[spyfemale, DiscAmmo] = 15;
$ItemMax[spyarmor, Disclauncher] = 1; $ItemMax[spyfemale, Disclauncher] = 1;
$ItemMax[spyarmor, EnergyPack] = 1; $ItemMax[spyfemale, EnergyPack] = 1;
$ItemMax[spyarmor, Equalizer] = 1; $ItemMax[spyfemale, Equalizer] = 1;
$ItemMax[spyarmor, FlameTurretPack] = 1; $ItemMax[spyfemale, FlameTurretPack] = 1;
$ItemMax[spyarmor, FlightPack] = 1; $ItemMax[spyfemale, FlightPack] = 1;
$ItemMax[spyarmor, ForceFieldPack] = 1; $ItemMax[spyfemale, ForceFieldPack] = 1;
$ItemMax[spyarmor, Grenade] = 3; $ItemMax[spyfemale, Grenade] = 3;
$ItemMax[spyarmor, GrenadeAmmo] = 10; $ItemMax[spyfemale, GrenadeAmmo] = 10;
$ItemMax[spyarmor, GrenadeLauncher] = 1; $ItemMax[spyfemale, GrenadeLauncher] = 1;
$ItemMax[spyarmor, HoloPack] = 1; $ItemMax[spyfemale, HoloPack] = 1;
$ItemMax[spyarmor, Laptop] = 1; $ItemMax[spyfemale, Laptop] = 1;
$ItemMax[spyarmor, LaserPack] = 1; $ItemMax[spyfemale, LaserPack] = 1;
$ItemMax[spyarmor, LaserRifle] = 1; $ItemMax[spyfemale, LaserRifle] = 1;
$ItemMax[spyarmor, MineAmmo] = 3; $ItemMax[spyfemale, MineAmmo] = 3;
$ItemMax[spyarmor, MotionSensorPack] = 1; $ItemMax[spyfemale, MotionSensorPack] = 1;
$ItemMax[spyarmor, PlasmaAmmo] = 30; $ItemMax[spyfemale, PlasmaAmmo] = 30;
$ItemMax[spyarmor, PlasmaGun] = 1; $ItemMax[spyfemale, PlasmaGun] = 1;
$ItemMax[spyarmor, PulseSensorPack] = 1; $ItemMax[spyfemale, PulseSensorPack] = 1;
$ItemMax[spyarmor, RepairKit] = 1; $ItemMax[spyfemale, RepairKit] = 1;
$ItemMax[spyarmor, RepairPack] = 1; $ItemMax[spyfemale, RepairPack] = 1;
$ItemMax[spyarmor, SensorJammerPack] = 1; $ItemMax[spyfemale, SensorJammerPack] = 1;
$ItemMax[spyarmor, ShieldPack] = 1; $ItemMax[spyfemale, ShieldPack] = 1;
$ItemMax[spyarmor, StealthShieldPack] = 1; $ItemMax[spyfemale, StealthShieldPack] = 1;
$ItemMax[spyarmor, TargetingLaser] = 1; $ItemMax[spyfemale, TargetingLaser] = 1;
$ItemMax[spyarmor, RifleAmmo] = 20; $ItemMax[spyfemale, RifleAmmo] = 20;
$ItemMax[spyarmor, TranqGun] = 1; $ItemMax[spyfemale, TranqGun] = 1;
$ItemMax[spyarmor, HellFireModule] = 1; $ItemMax[spyfemale, HellFireModule] = 1;
$ItemMax[spyarmor, DetPackModule] = 1; $ItemMax[spyfemale, DetPackModule] = 1;
$ItemMax[spyarmor, RamModule] = 1; $ItemMax[spyfemale, RamModule] = 1;
$ItemMax[spyarmor, WraithModule] = 1; $ItemMax[spyfemale, WraithModule] = 1;
$ItemMax[spyarmor, JailGun] = 1; $ItemMax[spyfemale, JailGun] = 1;
//================  Runner Armor
$ItemMax[rarmor,	BalloonPack] = 1;
$ItemMax[rarmor,	Beacon] = 10;
$ItemMax[rarmor,	Grenade] = 10;
$ItemMax[rarmor,	Fists] = 1;
$ItemMax[rarmor,	MineAmmo] = 10;
$ItemMax[rarmor,	RepairKit] = 10;
$ItemMax[rarmor,	Sabotage] = 1;
$ItemMax[rarmor,	HellFireModule] = 1;
$ItemMax[rarmor,	DetPackModule] = 1;
$ItemMax[rarmor,	RamModule] = 1;
$ItemMax[rarmor,	WraithModule] = 1;
$ItemMax[rarmor,	MechPack] = 1;
$ItemMax[rarmor,	TargetingLaser] = 1;
$ItemMax[rarmor,	JailGun] = 1;
$ItemMax[rarmor,	GravGun] = 1;
$ItemMax[rarmor,	TrapPack5] = 1;
//===================== Titan
$ItemMax[tarmor, AmmoPack] = 1;
$ItemMax[tarmor, AutoRocketAmmo] = 20;
$ItemMax[tarmor, BalloonPack] = 1;
$ItemMax[tarmor, Beacon] = 3;
$ItemMax[tarmor, Blaster] = 1;
$ItemMax[tarmor, BoomAmmo] = 10;
$ItemMax[tarmor, BoomStick] = 1;
$ItemMax[tarmor, BulletAmmo] = 200;
$ItemMax[tarmor, Chaingun] = 1;
$ItemMax[tarmor, ConCun] = 1;
$ItemMax[tarmor, DiscAmmo] = 30;
$ItemMax[tarmor, Disclauncher] = 1;
$ItemMax[tarmor, EnergyPack] = 1;
$ItemMax[tarmor, EnergyRifle] = 1;
$ItemMax[tarmor, Equalizer] = 1;
$ItemMax[tarmor, FgcPack] = 1;
$ItemMax[tarmor, Fists] = 1;
$ItemMax[tarmor, Flamer] = 1;
$ItemMax[tarmor, Grenade] = 3;
$ItemMax[tarmor, GrenadeAmmo] = 15;
$ItemMax[tarmor, GrenadeLauncher] = 1;
$ItemMax[tarmor, HyperB] = 1;
$ItemMax[tarmor, LaserRifle] = 1;
$ItemMax[tarmor, Mfgl] = 1;
$ItemMax[tarmor, MfglAmmo] = 1;
$ItemMax[tarmor, MineAmmo] = 5;
$ItemMax[tarmor, MiniPlasmaCannon] = 1;
$ItemMax[tarmor, Mortar] = 1;
$ItemMax[tarmor, MortarAmmo] = 10;
$ItemMax[tarmor, PlasmaAmmo] = 50;
$ItemMax[tarmor, PlasmaGun] = 1;
$ItemMax[tarmor, RailGun] = 15;
$ItemMax[tarmor, RifleAmmo] = 10;
$ItemMax[tarmor, RocketAmmo] = 15;
$ItemMax[tarmor, RocketLauncher] = 1;
$ItemMax[tarmor, ShieldPack] = 1;
$ItemMax[tarmor, Silencer] = 1;
$ItemMax[tarmor, SilencerAmmo] = 20;
$ItemMax[tarmor, SMML] = 1;
$ItemMax[tarmor, SniperRifle2] = 1;
$ItemMax[tarmor, StealthShieldPack] = 1;
$ItemMax[tarmor, TargetingLaser] = 1;
$ItemMax[tarmor, TranqGun] = 1;
$ItemMax[tarmor, Volter] = 1;
$ItemMax[tarmor, Vulcan] = 1;
$ItemMax[tarmor, MiniPlasmaCannon] = 1;
}

function InitArmorMax()
{	
	for (%j=1;$armorId[%j] != "" ; %j++)
	{
		%armor = $armorId[%j];
		
		for (%i=0; !getWord($ItemBlock,%i); %i++)
		{
			%item = getWord($ItemBlock,%i);
			%ammount = getWord($armorList[%j],%i);			
			$ItemMax[%armor,%item] = %ammount;		
		}
		if ($debug) echo ("*** Initializing Armor Data " @ %armor @ "***");
	}
}


function Armordatalist(%armorId)
{
	for (%j=1;$armorId[%j] != "" ; %j++)
	{
		%armor = $armorId[%j];
		for (%i=0; !getWord($ItemBlock,%i); %i++)
		{
			for (%k=0; getItemData(%k) != ""; %k++)
			{
				if (getItemData(%k) == getWord($ItemBlock,%i))
				{
					%armorlist = (%armorlist @ " " @ $ItemMax[%armor, getItemData(%k)]);
				}
			}
		}
		%armorlist = "";
	}
}

//InitArmorMax();

//------------------------------------------------------------------
// Armour Data Fields
//------------------------------------------------------------------

DamageSkinData armorDamageSkins
{
   bmpName[0] = "dskin1_armor";
   bmpName[1] = "dskin2_armor";
   bmpName[2] = "dskin3_armor";
   bmpName[3] = "dskin4_armor";
   bmpName[4] = "dskin5_armor";
   bmpName[5] = "dskin6_armor";
   bmpName[6] = "dskin7_armor";
   bmpName[7] = "dskin8_armor";
   bmpName[8] = "dskin9_armor";
   bmpName[9] = "dskin10_armor";
};

//------------------------------------------------------------------
// Heavy Armor data: Juggernaught.
//------------------------------------------------------------------

PlayerData jarmor
{
	className = "Armor";
	shapeFile = "harmor";
	flameShapeName = "hflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.4;
	maxJetForwardVelocity = 7;
	minJetEnergy = 1;
	jetForce = 390;
	jetEnergyDrain = 1.5;

	maxDamage = 2.0;

	maxForwardSpeed = 4.8;
	maxBackwardSpeed = 4.6;
	maxSideSpeed = 4.0;

	groundForce = 35 * 22.0;
	groundTraction = 4.5;

	mass = 22.0;
	maxEnergy = 150;
	
	drag = 3.0;
	density = 2.5;
	canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};


//==============================================
// Assassin Armour
//==============================================

PlayerData larmor
{
	className = "Armor";
	shapeFile = "larmor"; //larmor
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	
	validateShape = true;

	visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 22;
	minJetEnergy = 1;
	jetForce = 238;
	jetEnergyDrain = 0.8;

	maxDamage = 0.66;
	maxForwardSpeed = 11;
	maxBackwardSpeed = 10;
	maxSideSpeed = 10;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium Armor data: Patriot
//------------------------------------------------------------------

PlayerData marmor
{
   className = "Armor";
   shapeFile = "marmor"; //marmor
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	validateShape = true;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 325;
   jetEnergyDrain = 1.0;

	maxDamage = 1.3;
   maxForwardSpeed = 9.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	
	maxEnergy = 90;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
   animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Light female data:  *Assassin
//------------------------------------------------------------------

PlayerData lfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	validateShape = true;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium female data: Patriot
//------------------------------------------------------------------

PlayerData mfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 325;
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.2;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 90;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// light armor data: Scout
//------------------------------------------------------------------


PlayerData sarmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.9;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 245;
   jetEnergyDrain = 0.8;

	maxDamage = 0.80;
   maxForwardSpeed = 12;
   maxBackwardSpeed = 12;
   maxSideSpeed = 12;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 95;
   jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


//------------------------------------------------------------------
// Light female data: Stim Female
//------------------------------------------------------------------

PlayerData stimfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 1.2;
   maxJetForwardVelocity = 35;
   minJetEnergy = 1;
   jetForce = 375;
   jetEnergyDrain = 0.8;

   maxDamage = 0.75;
   maxForwardSpeed = 18;
   maxBackwardSpeed = 18;
   maxSideSpeed = 18;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 110;
   drag = 0.7;
   density = 2.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 155;
   jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// light armor data: Stim Male	
//------------------------------------------------------------------


PlayerData stimarmor
{
	className = "Armor";
	shapeFile = "larmor"; //larmor
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 1.3;
	maxJetForwardVelocity = 26;
	minJetEnergy = 1;
	jetForce = 350;
	jetEnergyDrain = 0.8;

	maxDamage = 0.80;
	maxForwardSpeed = 18;
	maxBackwardSpeed = 18;
	maxSideSpeed = 18;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 120;
	drag = 0.8;
	density = 2.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 145;
	jumpSurfaceMinDot = 0.2;

	// animation data:
	// animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
	// movement animations:
	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };

	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

	// death animations:
	animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

	// signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


	// celebration animations:
	animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	// taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	// poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };

	jetSound = SoundJetLight;
	rFootSounds = 
	{
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSnow,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft
	}; 
	lFootSounds =
	{
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSnow,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft
	};

	footPrints = { 0, 1 };

	boxWidth = 0.5;
	boxDepth = 0.5;
	boxNormalHeight = 2.2;
	boxCrouchHeight = 1.8;

	boxNormalHeadPercentage  = 0.83;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage  = 0.6666;
	boxCrouchTorsoPercentage = 0.3333;

	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium Armor data: Goliath
//------------------------------------------------------------------

PlayerData barmor
{
	className = "Armor";
	shapeFile = "marmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	canCrouch = false;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.9;
	maxJetForwardVelocity = 18;
	minJetEnergy = 1;
	jetForce = 320;
	jetEnergyDrain = 1.0;

	maxDamage = 1.0;
	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 7.0;
	maxSideSpeed = 7.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;

	maxEnergy = 100;
	drag = 0.9;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 110;
	jumpSurfaceMinDot = 0.2;

	// animation data:
	// animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

	// movement animations:
	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };

	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

	// death animations:
	animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

	// signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	// celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	// taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	// poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };

	jetSound = SoundJetLight;

	rFootSounds = 
	{
	SoundMFootRSoft,
	SoundMFootRHard,
	SoundMFootRSoft,
	SoundMFootRHard,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRHard,
	SoundMFootRSnow,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft
	}; 
	lFootSounds =
	{
	SoundMFootLSoft,
	SoundMFootLHard,
	SoundMFootLSoft,
	SoundMFootLHard,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLHard,
	SoundMFootLSnow,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft
	};

	footPrints = { 2, 3 };

	boxWidth = 0.7;
	boxDepth = 0.7;
	boxNormalHeight = 2.4;

	boxNormalHeadPercentage  = 0.83;
	boxNormalTorsoPercentage = 0.49;

	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Heavy Armor data: Dreadnaught
//------------------------------------------------------------------

PlayerData harmor
{
	className = "Armor";
	shapeFile = "harmor";
	flameShapeName = "hflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	validateShape = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 12;
	minJetEnergy = 1;
	jetForce = 385;
	jetEnergyDrain = 1.1;

	maxDamage = 1.70;

	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 6.0;
	maxSideSpeed = 6.0;

	groundForce = 35 * 19.0;
	groundTraction = 50;
	mass = 19.0;

	maxEnergy = 140;
	drag = 0.9;
	density = 2.5;
	canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

	jumpImpulse = 150;
	jumpSurfaceMinDot = 0.2;

	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };

	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

	// death animations:
	animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

	// signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	// celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	// taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	// poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };

	jetSound = SoundJetHeavy;

	rFootSounds = 
	{
	SoundHFootRSoft,
	SoundHFootRHard,
	SoundHFootRSoft,
	SoundHFootRHard,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRHard,
	SoundHFootRSnow,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft
	}; 
	lFootSounds =
	{
	SoundHFootLSoft,
	SoundHFootLHard,
	SoundHFootLSoft,
	SoundHFootLHard,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLHard,
	SoundHFootLSnow,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft
	};

	footPrints = { 4, 5 };

	boxWidth = 0.8;
	boxDepth = 0.8;
	boxNormalHeight = 2.6;

	boxNormalHeadPercentage  = 0.70;
	boxNormalTorsoPercentage = 0.45;

	boxHeadLeftPercentage  = 0.48;
	boxHeadRightPercentage = 0.70;
	boxHeadBackPercentage  = 0.48;
	boxHeadFrontPercentage = 0.60;
};

//------------------------------------------------------------------
// Light female data: Scout
//------------------------------------------------------------------

PlayerData sfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 1.0;
   maxJetForwardVelocity = 25;
   minJetEnergy = 1;
   jetForce = 245;
   jetEnergyDrain = 0.8;

	maxDamage = 0.75;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 13;
   maxSideSpeed = 13;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 95;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium female data: Goliath
//------------------------------------------------------------------

PlayerData bfemale
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 19;
	minJetEnergy = 1;
	jetForce = 320;
	jetEnergyDrain = 1.0;

	canCrouch = false;
	maxDamage = 1.0;
	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 7.0;
	maxSideSpeed = 7.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;

	maxEnergy = 100;
	mass = 13.0;
	drag = 0.9;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 110;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// light armor data: Spy
//------------------------------------------------------------------


PlayerData spyarmor
{
   className = "Armor";
   shapeFile = "larmor"; //larmor
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 270;
   jetEnergyDrain = 0.8;

	maxDamage = 0.76;
   maxForwardSpeed = 12;
   maxBackwardSpeed = 11;
   maxSideSpeed = 11;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 80;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------------------
// Light female data:  Spy
//------------------------------------------------------------------

PlayerData spyfemale
{
	className = "Armor";
	shapeFile = "lfemale";
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";

	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 22;
	minJetEnergy = 1;
	jetForce = 260;
	jetEnergyDrain = 0.8;

	maxDamage = 0.76;
	maxForwardSpeed = 12;
	maxBackwardSpeed = 11;
	maxSideSpeed = 11;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 80;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------------------
// Medium Armor data: engineer
//------------------------------------------------------------------

PlayerData earmor
{
	className = "Armor";
	shapeFile = "marmor"; //marmor
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	canCrouch = false;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 1.0;

	maxDamage = 1.0;
	maxForwardSpeed = 9.0;
	maxBackwardSpeed = 7.5;
	maxSideSpeed = 7.5;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;


	maxEnergy = 110;
	drag = 1.0;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 110;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------------------
// Medium female data: Engineer
//------------------------------------------------------------------

PlayerData efemale
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 1.0;

	canCrouch = false;
	maxDamage = 1.0;
	maxForwardSpeed = 9.0;
	maxBackwardSpeed = 8.5;
	maxSideSpeed = 8.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;

	maxEnergy = 110;
	mass = 13.0;
	drag = 1.0;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium Armor data: Stealth
//------------------------------------------------------------------

PlayerData aarmor
{
   className = "Armor";
   shapeFile = "marmor"; //marmor
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 1.0;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 325;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.4;
	
	
	maxEnergy = 140;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------------------
// Medium female data: Stealth
//------------------------------------------------------------------

PlayerData afemale
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 1.2;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 0.9;

	canCrouch = false;
	maxDamage = 0.9;
	maxForwardSpeed = 11.0;
	maxBackwardSpeed = 10.0;
	maxSideSpeed = 9.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.5;

	maxEnergy = 140;
	mass = 13.0;
	drag = 1.0;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
//============== Runner Armor	
//------------------------------------------------------------------

PlayerData rarmor
{
	className = "Armor";
	shapeFile = "lfemale";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 1.3;
	maxJetForwardVelocity = 26;
	minJetEnergy = 1;
	jetForce = 350;
	jetEnergyDrain = 0.8;

	maxDamage = 0.80;
	maxForwardSpeed = 18;
	maxBackwardSpeed = 18;
	maxSideSpeed = 18;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 120;
	drag = 0.8;
	density = 2.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 75;
	jumpSurfaceMinDot = 0.2;

	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };

	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

	// death animations:
	animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

	// signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


	// celebration animations:
	animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	// taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	// poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };

	jetSound = SoundJetLight;
	rFootSounds = 
	{
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSnow,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft
	}; 
	lFootSounds =
	{
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSnow,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft
	};

	footPrints = { 0, 1 };

	boxWidth = 0.5;
	boxDepth = 0.5;
	boxNormalHeight = 2.2;
	boxCrouchHeight = 1.8;

	boxNormalHeadPercentage  = 0.83;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage  = 0.6666;
	boxCrouchTorsoPercentage = 0.3333;

	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};


//------------------------------------------------------------------
// Heavy Armor data: Titan.
//------------------------------------------------------------------

PlayerData tarmor
{
	className = "Armor";
	shapeFile = "harmor";
	flameShapeName = "hflame";
	shieldShapeName = "plasmaex";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.4;
	maxJetForwardVelocity = 7;
	minJetEnergy = 1;
	jetForce = 390;
	jetEnergyDrain = 1.5;

	maxDamage = 20.0;

	maxForwardSpeed = 4.8;
	maxBackwardSpeed = 4.6;
	maxSideSpeed = 4.0;

	groundForce = 35 * 22.0;
	groundTraction = 4.5;

	mass = 22.0;
	maxEnergy = 150;
	
	drag = 3.0;
	density = 2.5;
	canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundFlierCrash, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundFlierCrash, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard,
     SoundHFootRHard
  }; 
   lFootSounds =
   {
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard,
      SoundHFootLHard
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};
