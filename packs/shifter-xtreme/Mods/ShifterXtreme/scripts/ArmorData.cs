

function BuildItemList()
{
	$armorId[0] = "aarmor";		// -- Arbitor
	$armorId[1] = "afemale";
	$armorId[2] = "barmor";		// -- Goliath
	$armorId[3] = "bfemale"; 
	$armorId[4] = "darmor";		// -- Dreadnaught
	$armorId[5] = "dmarmor";	// -- Death Match Male 
	$armorId[6] = "dmfemale";	// -- Death Match Female 
	$armorId[7] = "earmor";		// -- Engineer
	$armorId[8] = "efemale";
	$armorId[9] = "harmor";		// -- Heavy
	$armorId[10] = "jarmor";	// -- Juggernaught
	$armorId[11] = "larmor";	// -- Assassin
	$armorId[12] = "lfemale";
	$armorId[13] = "marmor";	// -- Merc.
	$armorId[14] = "mfemale";
	$armorId[15] = "parmor";	// -- PArmor
	$armorId[16] = "sarmor";	// -- Scout
	$armorId[17] = "sfemale";
	$armorId[18] = "spyarmor";	// -- Chemeleon
	$armorId[19] = "spyfemale";
	$armorId[20] = "stimarmor";	// -- Stim-Scout
	$armorId[21] = "stimfemale";
	$armorId[22] = "";

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
	$MaxWeapons[barmor] = 5;
	$MaxWeapons[bfemale] = 5;
	$MaxWeapons[darmor] = 7;  //was 4
	$MaxWeapons[dmarmor] = 4; 
	$MaxWeapons[dmfemale] = 4;  
	$MaxWeapons[earmor] = 4;
	$MaxWeapons[efemale] = 4;
	$MaxWeapons[harmor] = 4;  //was 5
	$MaxWeapons[jarmor] = 3;
	$MaxWeapons[larmor] = 3;
	$MaxWeapons[lfemale] = 3;
	$MaxWeapons[marmor] = 5;
	$MaxWeapons[mfemale] = 5;
	$MaxWeapons[parmor] = 1;
	$MaxWeapons[sarmor] = 2;
	$MaxWeapons[sfemale] = 2;
	$MaxWeapons[spyarmor] = 3;
	$MaxWeapons[spyfemale] = 3;
	$MaxWeapons[stimarmor] = 2;
	$MaxWeapons[stimfemale] = 2;

	//====================================================== Arbitor
	$ItemMax[aarmor, 	ArbitorBeaconPack] = 1;			$ItemMax[afemale,	EMPBeaconPack] = 1;
	$ItemMax[aarmor, 	EMPBeaconPack] = 1;			$ItemMax[afemale,	ShieldBeaconPack] = 1;
	$ItemMax[aarmor, 	ShieldBeaconPack] = 1;			$ItemMax[afemale,	AmmoPack] = 1;
	$ItemMax[aarmor,	AmmoPack] = 1;				$ItemMax[afemale,	ArbitorBeaconPack] = 1;
	$ItemMax[aarmor,	Beacon] = 3;				$ItemMax[afemale,	Beacon] = 3;
	$ItemMax[aarmor,	Blaster] = 1;				$ItemMax[afemale,	Blaster] = 1;
	$ItemMax[aarmor,	Boomer] = 1;				$ItemMax[afemale,	Boomer] = 1;  //added
	$ItemMax[aarmor,	BulletAmmo] = 450;			$ItemMax[afemale,	BulletAmmo] = 450;
	$ItemMax[aarmor,	CameraPack] = 1;			$ItemMax[afemale,	CameraPack] = 1;
	$ItemMax[aarmor,	CloakingDevice] = 1;			$ItemMax[afemale,	CloakingDevice] = 1;
	$ItemMax[aarmor,	ConCun] = 1;				$ItemMax[afemale,	ConCun] = 1;
	$ItemMax[aarmor,	DeployableAmmoPack] = 1;		$ItemMax[afemale,	DeployableAmmoPack] = 1;
	$ItemMax[aarmor,	DeployableElf] = 1;			$ItemMax[afemale,	DeployableElf] = 1;
	$ItemMax[aarmor,	DeployableGrav] = 1;			$ItemMax[afemale,	DeployableGrav] = 1;  //added
	$ItemMax[aarmor,	DeployableInvPack] = 1;			$ItemMax[afemale,	DeployableInvPack] = 1;
	$ItemMax[aarmor,	DeployableSensorJammerPack] = 1;	$ItemMax[afemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[aarmor,	DiscAmmo] = 15;				$ItemMax[afemale,	DiscAmmo] = 15;
	$ItemMax[aarmor,	EnergyPack] = 1;			$ItemMax[afemale,	EnergyPack] = 1;
	$ItemMax[aarmor,	EnergyRifle] = 1;		     $ItemMax[afemale,	EnergyRifle] = 1;  //added
	$ItemMax[aarmor,	Flamer] = 1;			 	$ItemMax[afemale,	Flamer] = 1;  //added
	$ItemMax[aarmor,	ForceFieldPack] = 1;			$ItemMax[afemale,	ForceFieldPack] = 1;
	$ItemMax[aarmor,	FusionBlaster] = 1;			$ItemMax[afemale,	FusionBlaster] = 1;
	$ItemMax[aarmor,	FusionTurretPack] = 1;			$ItemMax[afemale,	FusionTurretPack] = 1;
	$ItemMax[aarmor,	GravGun] = 1;				$ItemMax[afemale,	GravGun] = 1;
	$ItemMax[aarmor,	Grenade] = 5;				$ItemMax[afemale,	Grenade] = 5;
	$ItemMax[aarmor,	GrenadeAmmo] = 10;			$ItemMax[afemale,	GrenadeAmmo] = 10;
	$ItemMax[aarmor,	HoloPack] = 1;				$ItemMax[afemale,	HoloPack] = 1;
	$ItemMax[aarmor,	HyperB] = 1;				$ItemMax[afemale,	HyperB] = 1;
	$ItemMax[aarmor,	IonGun] = 1;				$ItemMax[afemale,	IonGun] = 1;
	$ItemMax[aarmor,	LargeForceFieldPack] = 1;		$ItemMax[afemale,	LargeForceFieldPack] = 1;
	$ItemMax[aarmor,	LaserRifle] = 1;			$ItemMax[afemale,	LaserRifle] = 1;  //added
	$ItemMax[aarmor,	LightningPack] = 1;			$ItemMax[afemale,	LightningPack] = 1;
	$ItemMax[aarmor,	MineAmmo] = 3;				$ItemMax[afemale,	MineAmmo] = 3;
	$ItemMax[aarmor,	MotionSensorPack] = 1;			$ItemMax[afemale,	MotionSensorPack] = 1;
	$ItemMax[aarmor,	Volter] = 1;				$ItemMax[afemale,	Volter] = 1;
	$ItemMax[aarmor,	PlasmaAmmo] = 40;			$ItemMax[afemale,	PlasmaAmmo] = 40;
	$ItemMax[aarmor,	PulseSensorPack] = 1;			$ItemMax[afemale,	PulseSensorPack] = 1;
	$ItemMax[aarmor,	RailAmmo] = 10;				$ItemMax[afemale,	RailAmmo] = 10;
	$ItemMax[aarmor,	RegenerationPack] = 1;			$ItemMax[afemale,	RegenerationPack] = 1;
	$ItemMax[aarmor,	RepairKit] = 1;				$ItemMax[afemale,	RepairKit] = 1;
	$ItemMax[aarmor,	RepairPack] = 1;			$ItemMax[afemale,	RepairPack] = 1;
	$ItemMax[aarmor,	ShieldPack] = 1;			$ItemMax[afemale,	ShieldPack] = 1;
	$ItemMax[aarmor,	ShockForceFieldPack] = 1;	$ItemMax[afemale,	ShockForceFieldPack] = 1;
	$ItemMax[aarmor,	StealthShieldPack] = 1;			$ItemMax[afemale,	StealthShieldPack] = 1;
	$ItemMax[aarmor,	TargetingLaser] = 1;			$ItemMax[afemale,	TargetingLaser] = 1;
	$ItemMax[aarmor,	TranqAmmo] = 20;			$ItemMax[afemale,	TranqAmmo] = 20;
	$ItemMax[aarmor,	TurretPack] = 1;			$ItemMax[afemale,	TurretPack] = 1;
	$ItemMax[aarmor,	RegPack] = 1;			$ItemMax[afemale,	RegPack] = 1;
	//====================================================== Goliath
	$ItemMax[barmor,	AirAmmoPad] = 1;			$ItemMax[bfemale,	AirAmmoPad] = 1;
	$ItemMax[barmor,	AmmoPack] = 1;				$ItemMax[bfemale,	AmmoPack] = 1;
	$ItemMax[barmor,	AutoRocketAmmo] = 25;		$ItemMax[bfemale,	AutoRocketAmmo] = 25;
	$ItemMax[barmor,	Beacon] = 9;				$ItemMax[bfemale,	Beacon] = 9;
	$ItemMax[barmor,	CameraPack] = 1;		 	$ItemMax[bfemale,	CameraPack] = 1;
	$ItemMax[barmor,	DeployableAmmoPack] = 1;	 	$ItemMax[bfemale,	DeployableAmmoPack] = 1;
	$ItemMax[barmor,	DeployableElf] = 1;		 	$ItemMax[bfemale,	DeployableElf] = 1;
	$ItemMax[barmor,	DeployableInvPack] = 1;		 	$ItemMax[bfemale,	DeployableInvPack] = 1;
	$ItemMax[barmor,	DeployableSensorJammerPack] = 1; 	$ItemMax[bfemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[barmor,	DiscAmmo] = 45;			 	$ItemMax[bfemale,	DiscAmmo] = 45;
	$ItemMax[barmor,	Disclauncher] = 1;		 	$ItemMax[bfemale,	Disclauncher] = 1;
	$ItemMax[barmor,	EnergyPack] = 1;		 	$ItemMax[bfemale,	EnergyPack] = 1;
	$ItemMax[barmor,	Flamer] = 1;			 	$ItemMax[bfemale,	Flamer] = 1;
	$ItemMax[barmor,	FlamerPack] = 1;			 	$ItemMax[bfemale,	FlamerPack] = 1;
	$ItemMax[barmor,	ForceFieldPack] = 1;		 	$ItemMax[bfemale,	ForceFieldPack] = 1;
	$ItemMax[barmor,	Grenade] = 8;			 	$ItemMax[bfemale,	Grenade] = 8;
	$ItemMax[barmor,	GrenadeAmmo] = 40;		 	$ItemMax[bfemale,	GrenadeAmmo] = 40;
	$ItemMax[barmor,	GrenadeLauncher] = 1;		 	$ItemMax[bfemale,	GrenadeLauncher] = 1;
	$ItemMax[barmor,	HoloPack] = 1;			 	$ItemMax[bfemale,	HoloPack] = 1;
	$ItemMax[barmor,	MfglAmmo] = 0;			 	$ItemMax[bfemale,	MfglAmmo] = 0;
	$ItemMax[barmor,	MineAmmo] = 6;			 	$ItemMax[bfemale,	MineAmmo] = 6;
	$ItemMax[barmor,	Mortar] = 1;			 	$ItemMax[bfemale,	Mortar] = 1;
	$ItemMax[barmor,	MortarAmmo] = 20;		 	$ItemMax[bfemale,	MortarAmmo] = 20;
	$ItemMax[barmor,	MotionSensorPack] = 1;		 	$ItemMax[bfemale,	MotionSensorPack] = 1;
	$ItemMax[barmor,	PlasmaAmmo] = 90;		 	$ItemMax[bfemale,	PlasmaAmmo] = 90;
	$ItemMax[barmor,	PlasmaGun] = 1;			 	$ItemMax[bfemale,	PlasmaGun] = 1;
	$ItemMax[barmor,	PlasmaTurretPack] = 1;			 	$ItemMax[bfemale,	PlasmaTurretPack] = 1;
	$ItemMax[barmor,	PulseSensorPack] = 1;		 	$ItemMax[bfemale,	PulseSensorPack] = 1;
	$ItemMax[barmor,	RailAmmo] = 10;			 	$ItemMax[bfemale,	RailAmmo] = 10;
	$ItemMax[barmor,	RepairKit] = 1;			 	$ItemMax[bfemale,	RepairKit] = 1;
	$ItemMax[barmor,	RepairPack] = 1;		 	$ItemMax[bfemale,	RepairPack] = 1;
	$ItemMax[barmor,	RocketAmmo] = 25;		 	$ItemMax[bfemale,	RocketAmmo] = 25;
	$ItemMax[barmor,	RocketLauncher] = 1;		 	$ItemMax[bfemale,	RocketLauncher] = 1;
	$ItemMax[barmor,	RocketPack] = 1;		 	$ItemMax[bfemale,	RocketPack] = 1;
	$ItemMax[barmor,	SensorJammerPack] = 1;		 	$ItemMax[bfemale,	SensorJammerPack] = 1;
	$ItemMax[barmor,	ShieldPack] = 1;		 	$ItemMax[bfemale,	ShieldPack] = 1;
	$ItemMax[barmor,	StealthShieldPack] = 1;		 	$ItemMax[bfemale,	StealthShieldPack] = 1;
	$ItemMax[barmor,	SMRPack] = 1;			$ItemMax[bfemale,	SMRPack] = 1;  //added
	$ItemMax[barmor,	SuicidePack] = 1;		 	$ItemMax[bfemale,	SuicidePack] = 1;
	$ItemMax[barmor,	TargetingLaser] = 1;		 	$ItemMax[bfemale,	TargetingLaser] = 1;
	$ItemMax[barmor,	TranqAmmo] = 20; 			$ItemMax[bfemale,	TranqAmmo] = 20;

	//====================================================== Dreadnaught
	$ItemMax[darmor,	AirAmmoPad] = 1;
	$ItemMax[darmor,	AmmoPack] = 1;
	$ItemMax[darmor,	AutoRocketAmmo] = 35;  //was 15
	$ItemMax[darmor,	AutoRocketAmmo] = 35;  //was 20
	$ItemMax[darmor,	Beacon] = 3;
	$ItemMax[darmor,	Blaster] = 1;
	$ItemMax[darmor,	BulletAmmo] = 750;  //was 450
	$ItemMax[darmor,	CameraPack] = 1;
	$ItemMax[darmor,	Chaingun] = 1;
	$ItemMax[darmor,	ConCun] = 1;
	$ItemMax[darmor,	DeployableAmmoPack] = 1;
	$ItemMax[darmor,	DeployableComPack] = 1;
	$ItemMax[darmor,	DeployableInvPack] = 1;
	$ItemMax[darmor,	DeployableSensorJammerPack] = 1;
	$ItemMax[darmor,	DiscAmmo] = 45;  //was 15
	$ItemMax[darmor,	Disclauncher] = 1;
	$ItemMax[darmor,	EnergyPack] = 1;
	$ItemMax[darmor,	EnergyRifle] = 1;
	$ItemMax[darmor,	Equalizer] = 1;
	$ItemMax[darmor,	FgcPack] = 1;
	$ItemMax[darmor,	ForceFieldPack] = 1;
	$ItemMax[darmor,	Grenade] = 5;  //was 3
	$ItemMax[darmor,	GrenadeAmmo] = 60;  //was 15
	$ItemMax[darmor,	GrenadeLauncher] = 1;
	$ItemMax[darmor,	HoloPack] = 1;
	$ItemMax[darmor,	Mfgl] = 1;
	$ItemMax[darmor,	MfglAmmo] = 4;  //was 1
	$ItemMax[darmor,	MineAmmo] = 8;  //was 5
	$ItemMax[darmor,	Mortar] = 1;
	$ItemMax[darmor,	MortarAmmo] = 25;  //was 10
	$ItemMax[darmor,	MotionSensorPack] = 1;
	$ItemMax[darmor,	PlasmaAmmo] = 80;  //was 50
	$ItemMax[darmor,	PlasmaGun] = 1;
	$ItemMax[darmor,	PlasmaTurretPack] = 1;
	$ItemMax[darmor,	PulseSensorPack] = 1;
	$ItemMax[darmor,	RailAmmo] = 10;
	$ItemMax[darmor,	RepairKit] = 1;
	$ItemMax[darmor,	RepairPack] = 1;
	$ItemMax[darmor,	RocketAmmo] = 35;  //was 15
	$ItemMax[darmor,	RocketLauncher] = 1;
	$ItemMax[darmor,	ShieldPack] = 1;
	$ItemMax[darmor,	SMRPack] = 1;
	$ItemMax[darmor,	StealthShieldPack] = 1;
	$ItemMax[darmor,	TargetingLaser] = 1;
	$ItemMax[darmor,	TranqAmmo] = 20;
	$ItemMax[darmor,	TurretPack] = 1;
	$ItemMax[darmor,	Vulcan] = 1;
	$ItemMax[darmor,	VulcanAmmo] = 1000;  //was 400
	$ItemMax[darmor, 	BarragePack] = 1;

	//====================================================== Death Match
	$ItemMax[dmarmor,	Equalizer] = 1;		$ItemMax[dmfemale,	Equalizer] = 1;
$ItemMax[dmarmor,	AmmoPack] = 1;			     $ItemMax[dmfemale,	AmmoPack] = 1;
	$ItemMax[dmarmor,	Beacon] = 4;			     $ItemMax[dmfemale,	Beacon] = 4;
	$ItemMax[dmarmor,	Blaster] = 1;			     $ItemMax[dmfemale,	Blaster] = 1;
	$ItemMax[dmarmor,	BoomAmmo] = 20;			     $ItemMax[dmfemale,	BoomAmmo] = 25;
	$ItemMax[dmarmor,	BoomStick] = 1;			     $ItemMax[dmfemale,	BoomStick] = 1;
	$ItemMax[dmarmor,	BulletAmmo] = 475;		     $ItemMax[dmfemale,	BulletAmmo] = 475;
	$ItemMax[dmarmor,	Chaingun] = 1;			     $ItemMax[dmfemale,	Chaingun] = 1;
	$ItemMax[dmarmor,	ConCun] = 1;				$ItemMax[dmfemale,	ConCun] = 1;  
	$ItemMax[dmarmor,	DiscAmmo] = 55;			     $ItemMax[dmfemale,	DiscAmmo] = 55;
	$ItemMax[dmarmor,	Disclauncher] = 1;		     $ItemMax[dmfemale,	Disclauncher] = 1;
	$ItemMax[dmarmor,	DeployableInv2Pack] = 1;		$ItemMax[dmfemale,	DeployableInv2Pack] = 1;	
	$ItemMax[dmarmor,	EnergyPack] = 1;		     $ItemMax[dmfemale,	EnergyPack] = 1;
	$ItemMax[dmarmor,	EnergyRifle] = 1;		     $ItemMax[dmfemale,	EnergyRifle] = 1;
	$ItemMax[dmarmor,	Flamer] = 1;			$ItemMax[dmfemale,	Flamer] = 1;
	$ItemMax[dmarmor,	FusionBlaster] = 1;		$ItemMax[dmfemale,	FusionBlaster] = 1;
//	$ItemMax[dmarmor,	HammerGun2] = 1;			$ItemMax[dmfemale,	HammerGun2] = 1;
//	$ItemMax[dmarmor,	HammerAmmo] = 155;		$ItemMax[dmfemale,	HammerAmmo] = 155;  
	$ItemMax[dmarmor,	GravGun] = 1;			$ItemMax[dmfemale,	GravGun] = 1;
	$ItemMax[dmarmor,	Grenade] = 5;			     $ItemMax[dmfemale,	Grenade] = 5;
	$ItemMax[dmarmor,	GrenadeAmmo] = 35;		     $ItemMax[dmfemale,	GrenadeAmmo] = 35;
	$ItemMax[dmarmor,	GrenadeLauncher] = 1;		     $ItemMax[dmfemale,	GrenadeLauncher] = 1;
	$ItemMax[dmarmor,	HyperB] = 1;			     $ItemMax[dmfemale,	HyperB] = 1;
	$ItemMax[dmarmor,	IonGun] = 1;				$ItemMax[dmfemale,	IonGun] = 1;
	$ItemMax[dmarmor,	LaserRifle] = 1;		     $ItemMax[dmfemale,	LaserRifle] = 1;
	$ItemMax[dmarmor,	Mfgl] = 1;				$ItemMax[dmfemale,	Mfgl] = 1;  
	$ItemMax[dmarmor,	MfglAmmo] = 6;			$ItemMax[dmfemale,	MfglAmmo] = 6; 
	$ItemMax[dmarmor,	MineAmmo] = 3;			     $ItemMax[dmfemale,	MineAmmo] = 3;
	$ItemMax[dmarmor,	Mortar] = 1;			 	$ItemMax[dmfemale,	Mortar] = 1;  //added
	$ItemMax[dmarmor,	MortarAmmo] = 12;		 	$ItemMax[dmfemale,	MortarAmmo] = 12;  //added
	$ItemMax[dmarmor,	PlasmaAmmo] = 60;		     $ItemMax[dmfemale,	PlasmaAmmo] = 60;
	$ItemMax[dmarmor,	PlasmaGun] = 1;			     $ItemMax[dmfemale,	PlasmaGun] = 1;
	$ItemMax[dmarmor,	RailAmmo] = 20;			     $ItemMax[dmfemale,	RailAmmo] = 20;
	$ItemMax[dmarmor,	Railgun] = 1;			$ItemMax[dmfemale,	Railgun] = 1;  
	$ItemMax[dmarmor,	RepairKit] = 1;			     $ItemMax[dmfemale,	RepairKit] = 1;
	$ItemMax[dmarmor,	RepairPack] = 1;		     $ItemMax[dmfemale,	RepairPack] = 1;	$ItemMax[dmarmor,	RocketAmmo] = 20;			$ItemMax[dmfemale,	RocketAmmo] = 20;  //added
	$ItemMax[dmarmor,	RocketLauncher] = 1;			$ItemMax[dmfemale,	RocketLauncher] = 1;  //added
	$ItemMax[dmarmor,	Silencer] = 1;			     	$ItemMax[dmfemale,	Silencer] = 1;  //added
	$ItemMax[dmarmor,	SilencerAmmo] = 200;		     	$ItemMax[dmfemale,	SilencerAmmo] = 200;  //added
	$ItemMax[dmarmor,	ShieldPack] = 1;		     $ItemMax[dmfemale,	ShieldPack] = 1;
	$ItemMax[dmarmor,	SniperAmmo] = 5;			$ItemMax[dmfemale,	SniperAmmo] = 5;  //added
	$ItemMax[dmarmor,	SniperRifle] = 1;			$ItemMax[dmfemale,	SniperRifle] = 1;  //added
	$ItemMax[dmarmor,	TargetingLaser] = 1;		     $ItemMax[dmfemale,	TargetingLaser] = 1;
	$ItemMax[dmarmor,	TranqAmmo] = 25;		     $ItemMax[dmfemale,	TranqAmmo] = 25;
	$ItemMax[dmarmor,	TranqGun] = 1;			     $ItemMax[dmfemale,	TranqGun] = 1;  //added
	$ItemMax[dmarmor,	Volter] = 1;				$ItemMax[dmfemale,	Volter] = 1;  //added
	$ItemMax[dmarmor,	Vulcan] = 1;				$ItemMax[dmfemale,	Vulcan] = 1;  //added
	$ItemMax[dmarmor,	VulcanAmmo] = 600;			$ItemMax[dmfemale,	VulcanAmmo] = 600;  //added

	//====================================================== Engineer
	$ItemMax[earmor, 	ArbitorBeaconPack] = 1;		$ItemMax[efemale,	ArbitorBeaconPack] = 1;
	$ItemMax[earmor, 	EMPBeaconPack] = 1;		$ItemMax[efemale,	EMPBeaconPack] = 1;
	$ItemMax[earmor, 	PowerGeneratorPack] = 1;	$ItemMax[efemale,	PowerGeneratorPack] = 1;
	$ItemMax[earmor, 	ShieldBeaconPack] = 1;		$ItemMax[efemale,	ShieldBeaconPack] = 1;
	$ItemMax[earmor,	AccelPPack] = 1;		$ItemMax[efemale,	AccelPPack] = 1;
	$ItemMax[earmor,	AirAmmoPad] = 1;		$ItemMax[efemale,	AirAmmoPad] = 1;
	$ItemMax[earmor,	AirBase] = 1;			$ItemMax[efemale,	AirBase] = 1;
	$ItemMax[earmor,	AmmoPack] = 1;			$ItemMax[efemale,	AmmoPack] = 1;
	$ItemMax[earmor,	AutoRocketAmmo] = 10;		$ItemMax[efemale,	AutoRocketAmmo] = 10;
	$ItemMax[earmor,	Beacon] = 3;			$ItemMax[efemale,	Beacon]= 3;
	$ItemMax[earmor,	Blaster] = 1;			$ItemMax[efemale,	Blaster] = 1;
	$ItemMax[earmor,	BlastFloorPack] = 1;		$ItemMax[efemale,	BlastFloorPack] = 1;
	$ItemMax[earmor,	BlastWallPack] = 1;		$ItemMax[efemale,	BlastWallPack] = 1;
	$ItemMax[earmor,	BoomPack] = 1;		$ItemMax[efemale,	BoomPack] = 1;
	$ItemMax[earmor,	BulletAmmo] = 450;		$ItemMax[efemale,	BulletAmmo] = 450;
	$ItemMax[earmor,	CameraPack] = 1;		$ItemMax[efemale,	CameraPack] = 1;
	$ItemMax[earmor,	Chaingun] = 1;			$ItemMax[efemale,	Chaingun] = 1;
	$ItemMax[earmor,	DeployableAmmoPack] = 1;	$ItemMax[efemale,	DeployableAmmoPack] = 1;
	$ItemMax[earmor,	DeployableComPack] = 1;		$ItemMax[efemale,	DeployableComPack] = 1;
	$ItemMax[earmor,	DeployableElf] = 1;		$ItemMax[efemale,	DeployableElf] = 1;
	$ItemMax[earmor,	DeployableInvPack] = 1;		$ItemMax[efemale,	DeployableInvPack] = 1;
	$ItemMax[earmor,	DeployableSensorJammerPack] = 1;	$ItemMax[efemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[earmor,	DiscAmmo] = 30;			$ItemMax[efemale,	DiscAmmo] = 15;
	$ItemMax[earmor,	Disclauncher] = 1;		$ItemMax[efemale,	Disclauncher] = 1;
	$ItemMax[earmor,	disit] = 1;			$ItemMax[efemale,	disit]=1;
	$ItemMax[earmor,	EmplacementPack] = 1;		$ItemMax[efemale,	EmplacementPack] = 1;
	$ItemMax[earmor,	EnergyPack] = 1;		$ItemMax[efemale,	EnergyPack] = 1;
	$ItemMax[earmor,	EnergyRifle] = 1;		$ItemMax[efemale,	EnergyRifle] = 1;
	$ItemMax[earmor,	Equalizer] = 1;			$ItemMax[efemale,	Equalizer] = 1;
	$ItemMax[earmor,	Fixit] = 1;			$ItemMax[efemale,	Fixit]=1;
	$ItemMax[earmor,	ForceFieldPack] = 1;		$ItemMax[efemale,	ForceFieldPack] = 1;
	$ItemMax[earmor,	FragPack] = 1;		$ItemMax[efemale,	FragPack] = 1;
	$ItemMax[earmor,	FusionTurretPack] = 1;		$ItemMax[efemale,	FusionTurretPack] = 1;
	$ItemMax[earmor,	ShockFloorPack] = 1;		$ItemMax[efemale,	ShockFloorPack] = 1;
	$ItemMax[earmor,	GravGun] = 1;			$ItemMax[efemale,	GravGun] = 1;
	$ItemMax[earmor,	Grenade] = 11;			$ItemMax[efemale,	Grenade] = 11;
	$ItemMax[earmor,	GrenadeAmmo] = 20;		$ItemMax[efemale,	GrenadeAmmo] = 20;
	$ItemMax[earmor,	GrenadeLauncher] = 1;		$ItemMax[efemale,	GrenadeLauncher] = 1;
	$ItemMax[earmor,	Hackit] = 1;			$ItemMax[efemale,	Hackit]= 1;
	$ItemMax[earmor,	HoloPack] = 1;			$ItemMax[efemale,	HoloPack] = 1;
//	$ItemMax[earmor,	HyperBPack] = 1;		//	$ItemMax[efemale,	HyperBPack] = 1;
	$ItemMax[earmor,	Laptop] = 1;			$ItemMax[efemale,	Laptop]= 1;
	$ItemMax[earmor,	LargeForceFieldPack] = 1;	$ItemMax[efemale,	LargeForceFieldPack] = 1;
	$ItemMax[earmor,	LargeShockForceFieldPack] = 1;	$ItemMax[efemale,	LargeShockForceFieldPack] = 1;
	$ItemMax[earmor,	LaserPack] = 1;			$ItemMax[efemale,	LaserPack] = 1;
	$ItemMax[earmor,	LaunchPack] = 1;		$ItemMax[efemale,	LaunchPack] = 1;
	$ItemMax[earmor,	MfglAmmo] = 1;		$ItemMax[efemale,	MfglAmmo] = 1;
	$ItemMax[earmor,	MineAmmo] = 8;			$ItemMax[efemale,	MineAmmo] = 8;
	$ItemMax[earmor,	MotionSensorPack] = 1;		$ItemMax[efemale,	MotionSensorPack] = 1;
	$ItemMax[earmor,	PlantPack] = 1;			$ItemMax[efemale,	PlantPack] = 1;
	$ItemMax[earmor,	PlasmaAmmo] = 70;		$ItemMax[efemale,	PlasmaAmmo] = 70;
	$ItemMax[earmor,	PlasmaGun] = 1;			$ItemMax[efemale,	PlasmaGun] = 1;
	$ItemMax[earmor,	PlasmaTurretPack] = 1;		$ItemMax[efemale,	PlasmaTurretPack] = 1;
	$ItemMax[earmor,	PlatformPack] = 1;		$ItemMax[efemale,	PlatformPack] = 1;
	$ItemMax[earmor,	PulseSensorPack] = 1;		$ItemMax[efemale,	PulseSensorPack] = 1;
	$ItemMax[earmor,	RailAmmo] = 20;			$ItemMax[efemale,	RailAmmo] = 20;
	$ItemMax[earmor,	Railgun] = 1;			$ItemMax[efemale,	Railgun] = 1;
	$ItemMax[earmor,	RepairKit] = 1;			$ItemMax[efemale,	RepairKit] = 1;
	$ItemMax[earmor,	RepairPack] = 1;		$ItemMax[efemale,	RepairPack] = 1;
	$ItemMax[earmor,	RocketAmmo] = 10;		$ItemMax[efemale,	RocketAmmo] = 10;
	$ItemMax[earmor,	RocketLauncher] = 1;		$ItemMax[efemale,	RocketLauncher] = 1;
	$ItemMax[earmor,	RocketPack] = 1;		$ItemMax[efemale,	RocketPack] = 1;
	$ItemMax[earmor,	SensorJammerPack] = 1;		$ItemMax[efemale,	SensorJammerPack] = 1;
	$ItemMax[earmor,	ShieldPack] = 1;		$ItemMax[efemale,	ShieldPack] = 1;
	$ItemMax[earmor,	ShockPack] = 1;			$ItemMax[efemale,	ShockPack] = 1;
	$ItemMax[earmor,	ShockForceFieldPack] = 1;	$ItemMax[efemale,	ShockForceFieldPack] = 1;
	$ItemMax[earmor,	StealthShieldPack] = 1;		$ItemMax[efemale,	StealthShieldPack] = 1;
	$ItemMax[earmor,	TargetingLaser] = 1;		$ItemMax[efemale,	TargetingLaser] = 1;
	$ItemMax[earmor,	TargetPack] = 1;		$ItemMax[efemale,	TargetPack] = 1;
	$ItemMax[earmor,	ShockFloorPack] = 1;		$ItemMax[efemale,	ShockFloorPack] = 1;
	$ItemMax[earmor,	TeleportPack] = 1;		$ItemMax[efemale,	TeleportPack] = 1;
	$ItemMax[earmor,	TranqAmmo] = 20;		$ItemMax[efemale,	TranqAmmo] = 20;
	$ItemMax[earmor,	TreePack] = 1;			$ItemMax[efemale,	TreePack] = 1;
	$ItemMax[earmor,	TurretPack] = 1;		$ItemMax[efemale,	TurretPack] = 1;
	$ItemMax[earmor,	VulcanAmmo] = 200;		$ItemMax[efemale,	VulcanAmmo] = 200;
	$ItemMax[earmor,	EngineerTurretPack] = 1;	$ItemMax[efemale,	EngineerTurretPack] = 1;
	$ItemMax[earmor, 	BarragePack] = 1;		$ItemMax[efemale, 	BarragePack] = 1;

	$ItemMax[earmor,	NapalmModule] = 1;		     $ItemMax[efemale,	NapalmModule] = 1;
	$ItemMax[earmor,	HellFireModule] = 1;		     $ItemMax[efemale,	HellFireModule] = 1;
	$ItemMax[earmor,	DetPackModule] = 1;		     $ItemMax[efemale,	DetPackModule] = 1;
	$ItemMax[earmor,	BomberModule] = 1;		     $ItemMax[efemale,	BomberModule] = 1;
	$ItemMax[earmor,	PickUpModule] = 1;		     $ItemMax[efemale,	PickUpModule] = 1;
	$ItemMax[earmor,	MineNetModule] = 1;		     $ItemMax[efemale,	MineNetModule] = 1;
	$ItemMax[earmor,	WraithModule] = 1;		     $ItemMax[efemale,	WraithModule] = 1;
	$ItemMax[earmor,	StealthModule] = 1;		     $ItemMax[efemale,	StealthModule] = 1;
	$ItemMax[earmor,	InterceptorModule] = 1;		     $ItemMax[efemale,	InterceptorModule] = 1;
	$ItemMax[earmor,	GodHammerModule] = 1;		     $ItemMax[efemale,	GodHammerModule] = 1;
	$ItemMax[earmor,	DeployableGrav] = 1;		$ItemMax[efemale,	DeployableGrav] = 1;
	$ItemMax[earmor,	NukePack] = 1;		$ItemMax[efemale,	NukePack] = 1;
	$ItemMax[earmor,	GHPack] = 1;		$ItemMax[efemale,	GHPack] = 1;

	//====================================================== Standard Heavy
	$ItemMax[harmor,	AmmoPack] = 1;
	$ItemMax[harmor,	AutoRocketAmmo] = 45;  //added
	$ItemMax[harmor,	SMRPack2] = 1;  //added
	$ItemMax[harmor,	Beacon] = 0;  //was 5
	$ItemMax[harmor,	BulletAmmo] = 700;  //was 450
	$ItemMax[harmor,	FgcPack] = 1;  //added
//	$ItemMax[harmor,	DeployableAmmoPack] = 1;
//	$ItemMax[harmor,	DeployableComPack] = 1;
//	$ItemMax[harmor,	DeployableInvPack] = 1;
//	$ItemMax[harmor,	DiscAmmo] = 75;  //was 15
//	$ItemMax[harmor,	Disclauncher] = 1;
//	$ItemMax[harmor,	EnergyPack] = 1;
//	$ItemMax[harmor,	Grenade] = 7;  //was 1
//	$ItemMax[harmor,	GrenadeAmmo] = 60; //was 15
//	$ItemMax[harmor,	GrenadeLauncher] = 1;
	$ItemMax[harmor,	Hammer1Pack] = 1;  //added
	$ItemMax[harmor,	Hammer2Pack] = 1;  //added
	$ItemMax[harmor,	HammerAmmo] = 400;  //added
//	$ItemMax[harmor,	HoloPack] = 1;
	$ItemMax[harmor,	Mfgl] = 1;
	$ItemMax[harmor,	MfglAmmo] = 6;  //was 4
//	$ItemMax[harmor,	MineAmmo] = 3;
	$ItemMax[harmor,	Mortar] = 1;
	$ItemMax[harmor,	MortarAmmo] = 45;  //was 10
//	$ItemMax[harmor,	MotionSensorPack] = 1;
	$ItemMax[harmor,	NukePack] = 1;  //added
//	$ItemMax[harmor,	PlasmaAmmo] = 100;  //was 50
//	$ItemMax[harmor,	PlasmaGun] = 1;
//	$ItemMax[harmor,	PulseSensorPack] = 1;
	$ItemMax[harmor,	RailAmmo] = 10;
	$ItemMax[harmor,	RepairKit] = 3;  //was 1
	$ItemMax[harmor,	RepairPack] = 1;
	$ItemMax[harmor,	RocketAmmo] = 45;  //was 15
	$ItemMax[harmor,	RocketLauncher] = 1;  //added
//	$ItemMax[harmor,	ShieldPack] = 1;
	$ItemMax[harmor,	SuicidePack] = 1; //added
	$ItemMax[harmor,	TargetingLaser] = 1;
//	$ItemMax[harmor,	TranqAmmo] = 20;
	$ItemMax[harmor,	GHPack] = 1;  //added
	$ItemMax[harmor,	Vulcan] = 1;
	$ItemMax[harmor,	VulcanAmmo] = 900;  //was 400

	//====================================================== Juggernaught
	$ItemMax[jarmor,	AutoRocketAmmo] = 35;  //was 20
	$ItemMax[jarmor,	Beacon] = 5;
	$ItemMax[jarmor,	LasCannon] = 1;
	$ItemMax[jarmor,	Mfgl] = 1;
	$ItemMax[jarmor,	MfglAmmo] = 8;  //was 4
	$ItemMax[jarmor,	Mortar] = 1;
	$ItemMax[jarmor,	MortarAmmo] = 35;  //was 25
	$ItemMax[jarmor,	RepairKit] = 3;  //was 1
	$ItemMax[jarmor,	RocketAmmo] = 35;  //was 25
	$ItemMax[jarmor,	RocketLauncher] = 1;
	$ItemMax[jarmor,	SMRPack2] = 1;
	$ItemMax[jarmor, 	PlasmaCannon] = 1;
	$ItemMax[jarmor,	TargetingLaser] = 1;
	$ItemMax[jarmor,	Hammer1Pack] = 1;
	$ItemMax[jarmor,	Hammer2Pack] = 1;
	$ItemMax[jarmor,	HammerAmmo] = 500;
	
	//====================================================== Assassin
	$ItemMax[larmor, 	ArbitorBeaconPack] = 1;			$ItemMax[lfemale,	ArbitorBeaconPack] = 1;
	$ItemMax[larmor,	AmmoPack] = 1;				$ItemMax[lfemale,	AmmoPack] = 1;
	$ItemMax[larmor,	Beacon] = 5;				$ItemMax[lfemale,	Beacon] = 5;
	$ItemMax[larmor,	Blaster] = 1;				$ItemMax[lfemale,	Blaster] = 1;
	$ItemMax[larmor,	BoomAmmo] = 10;				$ItemMax[lfemale,	BoomAmmo] = 10;
//	$ItemMax[larmor,	BoomStick] = 1;				$ItemMax[lfemale,	BoomStick] = 1;
	$ItemMax[larmor,	BulletAmmo] = 225;			$ItemMax[lfemale,	BulletAmmo] = 225;
	$ItemMax[larmor,	CameraPack] = 1;			$ItemMax[lfemale,	CameraPack] = 1;
//	$ItemMax[larmor,	Chaingun] = 1;				$ItemMax[lfemale,	Chaingun] = 1;
	$ItemMax[larmor,	TranqPack] = 1;				$ItemMax[lfemale, TranqPack] = 1;
	$ItemMax[larmor,	DeployableSensorJammerPack] = 1;	$ItemMax[lfemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[larmor,	DiscAmmo] = 15;				$ItemMax[lfemale,	DiscAmmo] = 15;
//	$ItemMax[larmor,	Disclauncher] = 1;			$ItemMax[lfemale,	Disclauncher] = 1;
	$ItemMax[larmor,	EnergyPack] = 1;			$ItemMax[lfemale,	EnergyPack] = 1;
//	$ItemMax[larmor,	EnergyRifle] = 1;			$ItemMax[lfemale,	EnergyRifle] = 1;
	$ItemMax[larmor,	ForceFieldPack] = 1;			$ItemMax[lfemale,	ForceFieldPack] = 1;
	$ItemMax[larmor,	Grenade] = 3;				$ItemMax[lfemale,	Grenade] = 3;
	$ItemMax[larmor,	GrenadeAmmo] = 10;			$ItemMax[lfemale,	GrenadeAmmo] = 10;
//	$ItemMax[larmor,	GrenadeLauncher] = 1;			$ItemMax[lfemale,	GrenadeLauncher] = 1;
	$ItemMax[larmor,	HoloPack] = 1;				$ItemMax[lfemale,	HoloPack] = 1;
	$ItemMax[larmor,	LaserRifle] = 1;			$ItemMax[lfemale,	LaserRifle] = 1;
	$ItemMax[larmor,	MineAmmo] = 3;				$ItemMax[lfemale,	MineAmmo] = 3;
	$ItemMax[larmor,	MotionSensorPack] = 1;			$ItemMax[lfemale,	MotionSensorPack] = 1;
	$ItemMax[larmor,	OpticPack] = 1;				$ItemMax[lfemale,	OpticPack] = 1;
	$ItemMax[larmor,	PlasmaAmmo] = 30;			$ItemMax[lfemale,	PlasmaAmmo] = 30;
//	$ItemMax[larmor,	PlasmaGun] = 1;				$ItemMax[lfemale,	PlasmaGun] = 1;
	$ItemMax[larmor,	PulseSensorPack] = 1;			$ItemMax[lfemale,	PulseSensorPack] = 1;
	$ItemMax[larmor,	RailAmmo] = 10;				$ItemMax[lfemale,	RailAmmo] = 10;
	$ItemMax[larmor,	Railgun] = 1;				$ItemMax[lfemale,	Railgun] = 1;
	$ItemMax[larmor,	RepairKit] = 1;				$ItemMax[lfemale,	RepairKit] = 1;
	$ItemMax[larmor,	RepairPack] = 1;			$ItemMax[lfemale,	RepairPack] = 1;
	$ItemMax[larmor,	SensorJammerPack] = 1;			$ItemMax[lfemale,	SensorJammerPack] = 1;
	$ItemMax[larmor,	ShieldPack] = 1;			$ItemMax[lfemale,	ShieldPack] = 1;
	$ItemMax[larmor,	SniperAmmo] = 25;			$ItemMax[lfemale,	SniperAmmo] = 25;
	$ItemMax[larmor,	SniperRifle] = 1;			$ItemMax[lfemale,	SniperRifle] = 1;
	$ItemMax[larmor,	StealthShieldPack] = 1;			$ItemMax[lfemale,	StealthShieldPack] = 1;
	$ItemMax[larmor,	TargetingLaser] = 1;			$ItemMax[lfemale,	TargetingLaser] = 1;
	$ItemMax[larmor,	TranqAmmo] = 40;			$ItemMax[lfemale,	TranqAmmo] = 40;  //was 20
	$ItemMax[larmor,	TranqGun] = 1;				$ItemMax[lfemale,	TranqGun] = 1;
	$ItemMax[larmor,	TreePack] = 1;				$ItemMax[lfemale,	TreePack] = 1;
	$ItemMax[larmor,	Silencer] = 1;			     $ItemMax[lfemale,	Silencer] = 1;  //added
	$ItemMax[larmor,	SilencerAmmo] = 100;		     	$ItemMax[lfemale,	SilencerAmmo] = 100;  //added
	

	$ItemMax[larmor,	NapalmModule] = 1;		     $ItemMax[lfemale,	NapalmModule] = 1;
	$ItemMax[larmor,	HellFireModule] = 1;		     $ItemMax[lfemale,	HellFireModule] = 1;
	$ItemMax[larmor,	DetPackModule] = 1;		     $ItemMax[lfemale,	DetPackModule] = 1;
	$ItemMax[larmor,	BomberModule] = 1;		     $ItemMax[lfemale,	BomberModule] = 1;
	$ItemMax[larmor,	PickUpModule] = 1;		     $ItemMax[lfemale,	PickUpModule] = 1;
	$ItemMax[larmor,	MineNetModule] = 1;		     $ItemMax[lfemale,	MineNetModule] = 1;
	$ItemMax[larmor,	WraithModule] = 1;		     $ItemMax[lfemale,	WraithModule] = 1;
	$ItemMax[larmor,	StealthModule] = 1;		     $ItemMax[lfemale,	StealthModule] = 1;
	$ItemMax[larmor,	InterceptorModule] = 1;		     $ItemMax[lfemale,	InterceptorModule] = 1;
	$ItemMax[larmor,	GodHammerModule] = 1;		     $ItemMax[lfemale,	GodHammerModule] = 1;
	
	//====================================================== Mercinary
	$ItemMax[marmor,	AmmoPack] = 1;				$ItemMax[mfemale,	AmmoPack] = 1;
	$ItemMax[marmor,	Beacon] = 3;				$ItemMax[mfemale,	Beacon] = 3;
	$ItemMax[marmor,	Blaster] = 1;				$ItemMax[mfemale,	Blaster] = 1;
	$ItemMax[marmor,	BoomAmmo] = 30;				$ItemMax[mfemale,	BoomAmmo] = 30;
	$ItemMax[marmor,	BoomStick] = 1;				$ItemMax[mfemale,	BoomStick] = 1;
	$ItemMax[marmor,	BulletAmmo] = 900;			$ItemMax[mfemale,	BulletAmmo] = 900;
	$ItemMax[marmor,	Chaingun] = 1;				$ItemMax[mfemale,	Chaingun] = 1;
	$ItemMax[marmor,	DeployableAmmoPack] = 1;		$ItemMax[mfemale,	DeployableAmmoPack] = 1;
	$ItemMax[marmor,	DeployableInvPack] = 1;			$ItemMax[mfemale,	DeployableInvPack] = 1;
	$ItemMax[marmor,	DeployableSensorJammerPack] = 1;	$ItemMax[mfemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[marmor,	DiscAmmo] = 25;				$ItemMax[mfemale,	DiscAmmo] = 25;
	$ItemMax[marmor,	Disclauncher] = 1;			$ItemMax[mfemale,	Disclauncher] = 1;
	$ItemMax[marmor,	EnergyPack] = 1;			$ItemMax[mfemale,	EnergyPack] = 1;
	$ItemMax[marmor,	EnergyRifle] = 1;			$ItemMax[mfemale,	EnergyRifle] = 1;
	$ItemMax[marmor,	Equalizer] = 1;				$ItemMax[mfemale,	Equalizer] = 1;
	$ItemMax[marmor,	ForceFieldPack] = 1;			$ItemMax[mfemale,	ForceFieldPack] = 1;
	$ItemMax[marmor,	Grenade] = 6;				$ItemMax[mfemale,	Grenade] = 6;
	$ItemMax[marmor,	GrenadeAmmo] = 30;			$ItemMax[mfemale,	GrenadeAmmo] = 30;
	$ItemMax[marmor,	GrenadeLauncher] = 1;			$ItemMax[mfemale,	GrenadeLauncher] = 1;
	$ItemMax[marmor,	HoloPack] = 1;				$ItemMax[mfemale,	HoloPack] = 1;
	$ItemMax[marmor,	HyperB] = 1;				$ItemMax[mfemale,	HyperB] = 1;
	$ItemMax[marmor,	MineAmmo] = 3;				$ItemMax[mfemale,	IonGun] = 1;
	$ItemMax[marmor,	MortarAmmo] = 10;			$ItemMax[mfemale,	MineAmmo] = 3;
	$ItemMax[marmor,	MotionSensorPack] = 1;			$ItemMax[mfemale,	MotionSensorPack] = 1;
	$ItemMax[marmor,	PlasmaAmmo] = 50;			$ItemMax[mfemale,	PlasmaAmmo] = 50;
	$ItemMax[marmor,	PlasmaGun] = 1;				$ItemMax[mfemale,	PlasmaGun] = 1;
	$ItemMax[marmor,	PulseSensorPack] = 1;			$ItemMax[mfemale,	PulseSensorPack] = 1;
	$ItemMax[marmor,	RailAmmo] = 10;				$ItemMax[mfemale,	RailAmmo] = 10;
	$ItemMax[marmor,	RepairKit] = 1;				$ItemMax[mfemale,	RepairKit] = 1;
	$ItemMax[marmor,	RepairPack] = 1;			$ItemMax[mfemale,	RepairPack] = 1;
	$ItemMax[marmor,	RocketAmmo] = 15;			$ItemMax[mfemale,	RocketAmmo] = 15;
	$ItemMax[marmor,	RocketLauncher] = 1;			$ItemMax[mfemale,	RocketLauncher] = 1;
	$ItemMax[marmor,	SensorJammerPack] = 1;			$ItemMax[mfemale,	SensorJammerPack] = 1;
	$ItemMax[marmor,	ShieldPack] = 1;			$ItemMax[mfemale,	ShieldPack] = 1;
	$ItemMax[marmor,	StealthShieldPack] = 1;			$ItemMax[mfemale,	StealthShieldPack] = 1;
	$ItemMax[marmor,	TargetingLaser] = 1;			$ItemMax[mfemale,	TargetingLaser] = 1;
	$ItemMax[marmor,	TranqAmmo] = 20;			$ItemMax[mfemale,	TranqAmmo] = 20;
	$ItemMax[marmor,	TurretPack] = 1;			$ItemMax[mfemale,	TurretPack] = 1;
	$ItemMax[marmor,	Vulcan] = 1;				$ItemMax[mfemale,	Vulcan] = 1;
	$ItemMax[marmor,	VulcanAmmo] = 800;			$ItemMax[mfemale,	VulcanAmmo] = 800;  //was 500
	$ItemMax[marmor,	Silencer] = 1;			     	$ItemMax[mfemale,	Silencer] = 1;
	$ItemMax[marmor,	SilencerAmmo] = 200;		     	$ItemMax[mfemale,	SilencerAmmo] = 200;
	$ItemMax[marmor, 	BarragePack] = 1;			$ItemMax[mfemale, 	BarragePack] = 1;
	
	$ItemMax[marmor,	NapalmModule] = 1;		     	$ItemMax[mfemale,	NapalmModule] = 1;
	$ItemMax[marmor,	HellFireModule] = 1;		     	$ItemMax[mfemale,	HellFireModule] = 1;
	$ItemMax[marmor,	DetPackModule] = 1;		     	$ItemMax[mfemale,	DetPackModule] = 1;
	$ItemMax[marmor,	BomberModule] = 1;		     	$ItemMax[mfemale,	BomberModule] = 1;
	$ItemMax[marmor,	PickUpModule] = 1;		     	$ItemMax[mfemale,	PickUpModule] = 1;
	$ItemMax[marmor,	MineNetModule] = 1;		     	$ItemMax[mfemale,	MineNetModule] = 1;
	$ItemMax[marmor,	WraithModule] = 1;		     	$ItemMax[mfemale,	WraithModule] = 1;
	$ItemMax[marmor,	StealthModule] = 1;		     	$ItemMax[mfemale,	StealthModule] = 1;
	$ItemMax[marmor,	InterceptorModule] = 1;		     	$ItemMax[mfemale,	InterceptorModule] = 1;
	$ItemMax[marmor,	GodHammerModule] = 1;		     	$ItemMax[mfemale,	GodHammerModule] = 1;
	//====================================================== Cursed
	$ItemMax[parmor,	Penis] = 1;
	$ItemMax[parmor,	Penisd] = 1;

	//====================================================== Scout
	$ItemMax[sarmor,	AmmoPack] = 1;			     $ItemMax[sfemale,	AmmoPack] = 1;
	$ItemMax[sarmor,	Beacon] = 3;			     $ItemMax[sfemale,	Beacon] = 3;
	$ItemMax[sarmor,	Blaster] = 1;			     $ItemMax[sfemale,	Blaster] = 1;
	$ItemMax[sarmor,	BoomAmmo] = 10;			     $ItemMax[sfemale,	BoomAmmo] = 10;
	$ItemMax[sarmor,	BoomStick] = 1;			     $ItemMax[sfemale,	BoomStick] = 1;
	$ItemMax[sarmor,	BulletAmmo] = 200;		     $ItemMax[sfemale,	BulletAmmo] = 200;
	$ItemMax[sarmor,	CameraPack] = 1;		     $ItemMax[sfemale,	CameraPack] = 1;
	$ItemMax[sarmor,	Chaingun] = 1;			     $ItemMax[sfemale,	Chaingun] = 1;
	$ItemMax[sarmor,	ConCun] = 1;				$ItemMax[sfemale,	ConCun] = 1;  //added
	$ItemMax[sarmor,	DeployableSensorJammerPack] = 1;     $ItemMax[sfemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[sarmor,	DiscAmmo] = 15;			     $ItemMax[sfemale,	DiscAmmo] = 15;
	$ItemMax[sarmor,	Disclauncher] = 1;		     $ItemMax[sfemale,	Disclauncher] = 1;
	$ItemMax[sarmor,	EnergyPack] = 1;		     $ItemMax[sfemale,	EnergyPack] = 1;
	$ItemMax[sarmor,	EnergyRifle] = 1;		     $ItemMax[sfemale,	EnergyRifle] = 1;
	$ItemMax[sarmor,	FgcPack] = 1;			$ItemMax[sfemale, FgcPack] = 1;  //added
	$ItemMax[sarmor,	Flamer] = 1;			     $ItemMax[sfemale,	Flamer] = 1;
	$ItemMax[sarmor,	FlightPack] = 1;		     $ItemMax[sfemale,	FlightPack] = 1;
	$ItemMax[sarmor,	ForceFieldPack] = 1;		     $ItemMax[sfemale,	ForceFieldPack] = 1;
	$ItemMax[sarmor,	FusionBlaster] = 1;		$ItemMax[sfemale, FusionBlaster] = 1;
	$ItemMax[sarmor,	HammerGun] = 1;			$ItemMax[sfemale,	HammerGun] = 1;  //added
	$ItemMax[sarmor,	HammerGun2] = 1;			$ItemMax[sfemale,	HammerGun2] = 1;  //added
	$ItemMax[sarmor,	HammerAmmo] = 100;		$ItemMax[sfemale,	HammerAmmo] = 100;  //added
	$ItemMax[sarmor,	GravGun] = 1;			$ItemMax[sfemale,	GravGun] = 1;
	$ItemMax[sarmor,	Grenade] = 5;			     $ItemMax[sfemale,	Grenade] = 5;
	$ItemMax[sarmor,	GrenadeAmmo] = 20;		     $ItemMax[sfemale,	GrenadeAmmo] = 20;
	$ItemMax[sarmor,	GrenadeLauncher] = 1;		     $ItemMax[sfemale,	GrenadeLauncher] = 1;
	$ItemMax[sarmor,	HoloPack] = 1;			     $ItemMax[sfemale,	HoloPack] = 1;
	$ItemMax[sarmor,	HyperB] = 1;			     $ItemMax[sfemale,	HyperB] = 1;
	$ItemMax[sarmor,	IonGun] = 1;				$ItemMax[sfemale,	IonGun] = 1;  //added
	$ItemMax[sarmor,	Laptop] = 1;			     $ItemMax[sfemale,	Laptop] = 1;
	$ItemMax[sarmor,	LaserRifle] = 1;		     $ItemMax[sfemale,	LaserRifle] = 1;
	$ItemMax[sarmor,	MechPack] = 1;			     $ItemMax[sfemale,	MechPack] = 1;
	$ItemMax[sarmor,	Mfgl] = 1;				$ItemMax[sfemale,	Mfgl] = 1;  //added
	$ItemMax[sarmor,	MfglAmmo] = 1;			$ItemMax[sfemale,	MfglAmmo] = 1;  //added
	$ItemMax[sarmor,	MineAmmo] = 3;			     $ItemMax[sfemale,	MineAmmo] = 3;
	$ItemMax[sarmor,	Mortar] = 1;			 	$ItemMax[sfemale,	Mortar] = 1;  //added
	$ItemMax[sarmor,	MortarAmmo] = 8;		 	$ItemMax[sfemale,	MortarAmmo] = 8;  //added
	$ItemMax[sarmor,	MotionSensorPack] = 1;		     $ItemMax[sfemale,	MotionSensorPack] = 1;
	$ItemMax[sarmor,	PlasmaAmmo] = 30;		     $ItemMax[sfemale,	PlasmaAmmo] = 30;
	$ItemMax[sarmor,	PlasmaGun] = 1;			     $ItemMax[sfemale,	PlasmaGun] = 1;
	$ItemMax[sarmor,	PulseSensorPack] = 1;		     $ItemMax[sfemale,	PulseSensorPack] = 1;
	$ItemMax[sarmor,	RailAmmo] = 10;			     $ItemMax[sfemale,	RailAmmo] = 10;
	$ItemMax[sarmor,	Railgun] = 1;			$ItemMax[sfemale,	Railgun] = 1;  
	$ItemMax[sarmor,	RepairKit] = 1;			     $ItemMax[sfemale,	RepairKit] = 1;
	$ItemMax[sarmor,	RepairPack] = 1;		     $ItemMax[sfemale,	RepairPack] = 1;	$ItemMax[sarmor,	RocketAmmo] = 10;			$ItemMax[sfemale,	RocketAmmo] = 10;  //added
	$ItemMax[sarmor,	RocketLauncher] = 1;			$ItemMax[sfemale,	RocketLauncher] = 1;  //added
	$ItemMax[sarmor,	SensorJammerPack] = 1;		     $ItemMax[sfemale,	SensorJammerPack] = 1;
	$ItemMax[sarmor,	Silencer] = 1;			     	$ItemMax[sfemale,	Silencer] = 1;  //added
	$ItemMax[sarmor,	SilencerAmmo] = 100;		     	$ItemMax[sfemale,	SilencerAmmo] = 100;  //added
	$ItemMax[sarmor,	ShieldPack] = 1;		     $ItemMax[sfemale,	ShieldPack] = 1;
	$ItemMax[sarmor,	SniperAmmo] = 5;			$ItemMax[sfemale,	SniperAmmo] = 5;  //added
	$ItemMax[sarmor,	SniperRifle] = 1;			$ItemMax[sfemale,	SniperRifle] = 1;  //added
	$ItemMax[sarmor,	StealthShieldPack] = 1;		     $ItemMax[sfemale,	StealthShieldPack] = 1;
	$ItemMax[sarmor,	TargetingLaser] = 1;		     $ItemMax[sfemale,	TargetingLaser] = 1;
	$ItemMax[sarmor,	TranqAmmo] = 20;		     $ItemMax[sfemale,	TranqAmmo] = 20;
	$ItemMax[sarmor,	TranqGun] = 1;			     $ItemMax[sfemale,	TranqGun] = 1;  //added
	$ItemMax[sarmor,	Volter] = 1;				$ItemMax[sfemale,	Volter] = 1;  //added
	$ItemMax[sarmor,	Vulcan] = 1;				$ItemMax[sfemale,	Vulcan] = 1;  //added
	$ItemMax[sarmor,	VulcanAmmo] = 300;			$ItemMax[sfemale,	VulcanAmmo] = 300;  //added
	
	$ItemMax[sarmor,	NapalmModule] = 1;		     $ItemMax[sfemale,	NapalmModule] = 1;
	$ItemMax[sarmor,	HellFireModule] = 1;		     $ItemMax[sfemale,	HellFireModule] = 1;
	$ItemMax[sarmor,	DetPackModule] = 1;		     $ItemMax[sfemale,	DetPackModule] = 1;
	$ItemMax[sarmor,	BomberModule] = 1;		     $ItemMax[sfemale,	BomberModule] = 1;
	$ItemMax[sarmor,	PickUpModule] = 1;		     $ItemMax[sfemale,	PickUpModule] = 1;
	$ItemMax[sarmor,	MineNetModule] = 1;		     $ItemMax[sfemale,	MineNetModule] = 1;
	$ItemMax[sarmor,	WraithModule] = 1;		     $ItemMax[sfemale,	WraithModule] = 1;
	$ItemMax[sarmor,	StealthModule] = 1;		     $ItemMax[sfemale,	StealthModule] = 1;
	$ItemMax[sarmor,	InterceptorModule] = 1;		     $ItemMax[sfemale,	InterceptorModule] = 1;
	$ItemMax[sarmor,	GodHammerModule] = 1;		     $ItemMax[sfemale,	GodHammerModule] = 1;

	//====================================================== Stim Scout
	$ItemMax[stimarmor,	AmmoPack] = 1;			      $ItemMax[stimfemale,	AmmoPack] = 1;
	$ItemMax[stimarmor,	Beacon] = 3;			      $ItemMax[stimfemale,	Beacon] = 3;
	$ItemMax[stimarmor,	Blaster] = 1;			      $ItemMax[stimfemale,	Blaster] = 1;
	$ItemMax[stimarmor,	BoomAmmo] = 10;			      $ItemMax[stimfemale,	BoomAmmo] = 10;
	$ItemMax[stimarmor,	BoomStick] = 1;			      $ItemMax[stimfemale,	BoomStick] = 1;
	$ItemMax[stimarmor,	BulletAmmo] = 200;		      $ItemMax[stimfemale,	BulletAmmo] = 200;
	$ItemMax[stimarmor,	CameraPack] = 1;		      $ItemMax[stimfemale,	CameraPack] = 1;
	$ItemMax[stimarmor,	Chaingun] = 1;			      $ItemMax[stimfemale,	Chaingun] = 1;
	$ItemMax[stimarmor,	ConCun] = 1;				$ItemMax[stimfemale,	ConCun] = 1;  //added
	$ItemMax[stimarmor,	DeployableSensorJammerPack] = 1;      $ItemMax[stimfemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[stimarmor,	DiscAmmo] = 15;			      $ItemMax[stimfemale,	DiscAmmo] = 15;
	$ItemMax[stimarmor,	Disclauncher] = 1;		      $ItemMax[stimfemale,	Disclauncher] = 1;
	$ItemMax[stimarmor,	EnergyPack] = 1;		      $ItemMax[stimfemale,	EnergyPack] = 1;
	$ItemMax[stimarmor,	EnergyRifle] = 1;		      $ItemMax[stimfemale,	EnergyRifle] = 1;
	$ItemMax[stimarmor,	FgcPack] = 1;			$ItemMax[stimfemale, FgcPack] = 1;  //added
	$ItemMax[stimarmor,	Mfgl] = 1;				$ItemMax[stimfemale,	Mfgl] = 1;  //added
	$ItemMax[stimarmor,	MfglAmmo] = 1;			$ItemMax[stimfemale,	MfglAmmo] = 1;  //added
	$ItemMax[stimarmor,	Flamer] = 1;			      $ItemMax[stimfemale,	Flamer] = 1;
	$ItemMax[stimarmor,	FlightPack] = 1;		      $ItemMax[stimfemale,	FlightPack] = 1;
	$ItemMax[stimarmor,	ForceFieldPack] = 1;		      $ItemMax[stimfemale,	ForceFieldPack] = 1;
	$ItemMax[stimarmor,	FusionBlaster] = 1;		$ItemMax[stimfemale,	FusionBlaster] = 1;
	$ItemMax[stimarmor,	GravGun] = 1;			$ItemMax[stimfemale,	GravGun] = 1;
	$ItemMax[stimarmor,	Grenade] = 5;			      $ItemMax[stimfemale,	Grenade] = 5;
	$ItemMax[stimarmor,	GrenadeAmmo] = 20;		      $ItemMax[stimfemale,	GrenadeAmmo] = 20;
	$ItemMax[stimarmor,	GrenadeLauncher] = 1;		      $ItemMax[stimfemale,	GrenadeLauncher] = 1;
	$ItemMax[stimarmor,	HoloPack] = 1;			      $ItemMax[stimfemale,	HoloPack] = 1;
	$ItemMax[stimarmor,	HyperB] = 1;			      $ItemMax[stimfemale,	HyperB] = 1;
	$ItemMax[stimarmor,	HammerGun] = 1;			$ItemMax[stimfemale,	HammerGun] = 1;  //added
	$ItemMax[stimarmor,	HammerAmmo] = 100;		$ItemMax[stimfemale,	HammerAmmo] = 100;  //added
	$ItemMax[stimarmor,	IonGun] = 1;				$ItemMax[stimfemale,	IonGun] = 1;  //added
	$ItemMax[stimarmor,	Laptop] = 1;			      $ItemMax[stimfemale,	Laptop] = 1;
	$ItemMax[stimarmor,	LaserRifle] = 1;		      $ItemMax[stimfemale,	LaserRifle] = 1;
	$ItemMax[stimarmor,	MechPack] = 1;			      $ItemMax[stimfemale,	MechPack] = 1;
	$ItemMax[stimarmor,	MineAmmo] = 3;			      $ItemMax[stimfemale,	MineAmmo] = 3;
	$ItemMax[stimarmor,	Mortar] = 1;			 	$ItemMax[stimfemale,	Mortar] = 1;  //added
	$ItemMax[stimarmor,	MortarAmmo] = 8;		 	$ItemMax[stimfemale,	MortarAmmo] = 8;  //added
	$ItemMax[stimarmor,	MotionSensorPack] = 1;		      $ItemMax[stimfemale,	MotionSensorPack] = 1;
	$ItemMax[stimarmor,	PlasmaAmmo] = 30;		      $ItemMax[stimfemale,	PlasmaAmmo] = 30;
	$ItemMax[stimarmor,	PlasmaGun] = 1;			      $ItemMax[stimfemale,	PlasmaGun] = 1;
	$ItemMax[stimarmor,	PulseSensorPack] = 1;		      $ItemMax[stimfemale,	PulseSensorPack] = 1;
	$ItemMax[stimarmor,	RailAmmo] = 10;			      $ItemMax[stimfemale,	RailAmmo] = 10;
	$ItemMax[stimarmor,	Railgun] = 1;			$ItemMax[stimfemale,	Railgun] = 1;
	$ItemMax[stimarmor,	RepairKit] = 1;			      $ItemMax[stimfemale,	RepairKit] = 1;
	$ItemMax[stimarmor,	RepairPack] = 1;		      $ItemMax[stimfemale,	RepairPack] = 1;	
	$ItemMax[stimarmor,	RocketAmmo] = 10;			$ItemMax[stimfemale,	RocketAmmo] = 10;  //added
	$ItemMax[stimarmor,	RocketLauncher] = 1;			$ItemMax[stimfemale,	RocketLauncher] = 1;  //added
	$ItemMax[stimarmor,	SensorJammerPack] = 1;		      $ItemMax[stimfemale,	SensorJammerPack] = 1;
	$ItemMax[stimarmor,	Silencer] = 1;			     	$ItemMax[stimfemale,	Silencer] = 1;  //added
	$ItemMax[stimarmor,	SilencerAmmo] = 50;		     	$ItemMax[stimfemale,	SilencerAmmo] = 50;  //added
	$ItemMax[stimarmor,	ShieldPack] = 1;		      $ItemMax[stimfemale,	ShieldPack] = 1;
	$ItemMax[sarmor,	SniperAmmo] = 5;			$ItemMax[sfemale,	SniperAmmo] = 5;  //added
	$ItemMax[sarmor,	SniperRifle] = 1;			$ItemMax[sfemale,	SniperRifle] = 1;  //added
	$ItemMax[stimarmor,	StealthShieldPack] = 1;		      $ItemMax[stimfemale,	StealthShieldPack] = 1;
	$ItemMax[stimarmor,	TargetingLaser] = 1;		      $ItemMax[stimfemale,	TargetingLaser] = 1;
	$ItemMax[stimarmor,	TranqAmmo] = 20;		      $ItemMax[stimfemale,	TranqAmmo] = 20;
	$ItemMax[stimarmor,	TranqGun] = 1;			     $ItemMax[stimfemale,	TranqGun] = 1;  //added
	$ItemMax[stimarmor,	Volter] = 1;				$ItemMax[stimfemale,	Volter] = 1;  //added
	$ItemMax[stimarmor,	Vulcan] = 1;				$ItemMax[stimfemale,	Vulcan] = 1;
	$ItemMax[stimarmor,	VulcanAmmo] = 300;			$ItemMax[stimfemale,	VulcanAmmo] = 300;  //added  

	//====================================================== Chemeleon
	$ItemMax[spyarmor,	AmmoPack] = 1;			     $ItemMax[spyfemale,	AmmoPack] = 1;
	$ItemMax[spyarmor,	Beacon] = 3;			     $ItemMax[spyfemale,	Beacon] = 3;
	$ItemMax[spyarmor,	Blaster] = 1;			     $ItemMax[spyfemale,	Blaster] = 1;
	$ItemMax[spyarmor,	BoomAmmo] = 15;			     $ItemMax[spyfemale,	BoomAmmo] = 15;
	$ItemMax[spyarmor,	BoomStick] = 1;			     $ItemMax[spyfemale,	BoomStick] = 1;
	$ItemMax[spyarmor,	BulletAmmo] = 225;		     $ItemMax[spyfemale,	BulletAmmo] = 225;
	$ItemMax[spyarmor,	CameraPack] = 1;		     $ItemMax[spyfemale,	CameraPack] = 1;
	$ItemMax[spyarmor,	Chaingun] = 1;			     $ItemMax[spyfemale,	Chaingun] = 1;
	$ItemMax[spyarmor,	CloakingDevice] = 1;		     $ItemMax[spyfemale,	CloakingDevice] = 1;
	$ItemMax[spyarmor,	DeployableSensorJammerPack] = 1;     $ItemMax[spyfemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[spyarmor,	DetPack] = 1;     $ItemMax[spyfemale,	DetPack] = 1;
	$ItemMax[spyarmor,	DiscAmmo] = 15;			     $ItemMax[spyfemale,	DiscAmmo] = 15;
	$ItemMax[spyarmor,	Disclauncher] = 1;		     $ItemMax[spyfemale,	Disclauncher] = 1;
	$ItemMax[spyarmor,	EnergyPack] = 1;		     $ItemMax[spyfemale,	EnergyPack] = 1;
	$ItemMax[spyarmor,	EnergyRifle] = 1;		     $ItemMax[spyfemale,	EnergyRifle] = 1;
	$ItemMax[spyarmor,	Equalizer] = 1;			     $ItemMax[spyfemale,	Equalizer] = 1;
	$ItemMax[spyarmor,	FlightPack] = 1;		     $ItemMax[spyfemale,	FlightPack] = 1;
	$ItemMax[spyarmor,	ForceFieldPack] = 1;		     $ItemMax[spyfemale,	ForceFieldPack] = 1;
	$ItemMax[spyarmor,	Grenade] = 3;			     $ItemMax[spyfemale,	Grenade] = 3;
	$ItemMax[spyarmor,	GrenadeAmmo] = 10;		     $ItemMax[spyfemale,	GrenadeAmmo] = 10;
	$ItemMax[spyarmor,	GrenadeLauncher] = 1;		     $ItemMax[spyfemale,	GrenadeLauncher] = 1;
	$ItemMax[spyarmor,	HoloPack] = 1;			     $ItemMax[spyfemale,	HoloPack] = 1;
	$ItemMax[spyarmor,	Laptop] = 1;			     $ItemMax[spyfemale,	Laptop] = 1;
	$ItemMax[spyarmor,	LaserPack] = 1;			     $ItemMax[spyfemale,	LaserPack] = 1;
	$ItemMax[spyarmor,	LaserRifle] = 1;		     $ItemMax[spyfemale,	LaserRifle] = 1;
	$ItemMax[spyarmor,	MineAmmo] = 3;			     $ItemMax[spyfemale,	MineAmmo] = 3;
	$ItemMax[spyarmor,	MotionSensorPack] = 1;		     $ItemMax[spyfemale,	MotionSensorPack] = 1;
	$ItemMax[spyarmor,	PlasmaAmmo] = 30;		     $ItemMax[spyfemale,	PlasmaAmmo] = 30;
	$ItemMax[spyarmor,	PlasmaGun] = 1;			     $ItemMax[spyfemale,	PlasmaGun] = 1;
	$ItemMax[spyarmor,	PulseSensorPack] = 1;		     $ItemMax[spyfemale,	PulseSensorPack] = 1;
	$ItemMax[spyarmor,	RailAmmo] = 10;			     $ItemMax[spyfemale,	RailAmmo] = 10;
	$ItemMax[spyarmor,	RepairKit] = 1;			     $ItemMax[spyfemale,	RepairKit] = 1;
	$ItemMax[spyarmor,	RepairPack] = 1;		     $ItemMax[spyfemale,	RepairPack] = 1;
	$ItemMax[spyarmor,	SensorJammerPack] = 1;		     $ItemMax[spyfemale,	SensorJammerPack] = 1;
	$ItemMax[spyarmor,	ShieldPack] = 1;		     $ItemMax[spyfemale,	ShieldPack] = 1;
	$ItemMax[spyarmor,	Silencer] = 1;			     $ItemMax[spyfemale,	Silencer] = 1;
	$ItemMax[spyarmor,	SilencerAmmo] = 100;		     $ItemMax[spyfemale,	SilencerAmmo] = 100;
	$ItemMax[spyarmor,	StealthShieldPack] = 1;		     $ItemMax[spyfemale,	StealthShieldPack] = 1;
	$ItemMax[spyarmor,	TargetingLaser] = 1;		     $ItemMax[spyfemale,	TargetingLaser] = 1;
	$ItemMax[spyarmor,	TranqAmmo] = 35;		     $ItemMax[spyfemale,	TranqAmmo] = 35;
	$ItemMax[spyarmor,	TranqGun] = 1;			     $ItemMax[spyfemale,	TranqGun] = 1;
	
	$ItemMax[spyarmor,	NapalmModule] = 1;		     $ItemMax[spyfemale,	NapalmModule] = 1;
	$ItemMax[spyarmor,	HellFireModule] = 1;		     $ItemMax[spyfemale,	HellFireModule] = 1;
	$ItemMax[spyarmor,	DetPackModule] = 1;		     $ItemMax[spyfemale,	DetPackModule] = 1;
	$ItemMax[spyarmor,	BomberModule] = 1;		     $ItemMax[spyfemale,	BomberModule] = 1;
	$ItemMax[spyarmor,	PickUpModule] = 1;		     $ItemMax[spyfemale,	PickUpModule] = 1;
	$ItemMax[spyarmor,	MineNetModule] = 1;		     $ItemMax[spyfemale,	MineNetModule] = 1;
	$ItemMax[spyarmor,	WraithModule] = 1;		     $ItemMax[spyfemale,	WraithModule] = 1;
	$ItemMax[spyarmor,	StealthModule] = 1;		     $ItemMax[spyfemale,	StealthModule] = 1;
	$ItemMax[spyarmor,	InterceptorModule] = 1;		     $ItemMax[spyfemale,	InterceptorModule] = 1;
	$ItemMax[spyarmor,	GodHammerModule] = 1;		     $ItemMax[spyfemale,	GodHammerModule] = 1;
//=============================== Mine Launcher
//$ItemMax[larmor, MineLauncher] = 0;
//$ItemMax[lfemale, MineLauncher] = 0;
//$ItemMax[marmor, MineLauncher] = 1;
//$ItemMax[mfemale, MineLauncher] = 1;
//$ItemMax[harmor, MineLauncher] = 1;

//$ItemMax[sarmor, MineLauncher] = 1;
//$ItemMax[sfemale, MineLauncher] = 1;
//$ItemMax[spyarmor, MineLauncher] = 0;
//$ItemMax[spyfemale, MineLauncher] = 0;
//$ItemMax[barmor, MineLauncher] = 1;
//$ItemMax[bfemale, MineLauncher] = 1;
//$ItemMax[earmor, MineLauncher] = 1;
//$ItemMax[efemale, MineLauncher] = 1;
//$ItemMax[aarmor, MineLauncher] = 0;
//$ItemMax[afemale, MineLauncher] = 0;
//$ItemMax[darmor, MineLauncher] = 0;

//$ItemMax[larmor, MinelAmmo] = 0;
//$ItemMax[lfemale, MinelAmmo] = 0;
//$ItemMax[marmor, MinelAmmo] = 6;
//$ItemMax[mfemale, MinelAmmo] = 6;
//$ItemMax[harmor, MinelAmmo] = 10;

//$ItemMax[sarmor, MinelAmmo] = 8;
//$ItemMax[sfemale, MinelAmmo] = 8;
//$ItemMax[spyarmor, MinelAmmo] = 0;
//$ItemMax[spyfemale, MinelAmmo] = 0;
//$ItemMax[barmor, MinelAmmo] = 8;
//$ItemMax[bfemale, MinelAmmo] = 8;
//$ItemMax[earmor, MinelAmmo] = 12;
//$ItemMax[efemale, MinelAmmo] = 12;
//$ItemMax[aarmor, MinelAmmo] = 0;
//$ItemMax[afemale, MinelAmmo] = 0;
//$ItemMax[darmor, MinelAmmo] = 0;

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

$DamageScale[aarmor,	$AntimatterDamageType] 	= 0.01;  //added
$DamageScale[aarmor,	$BlasterDamageType] 	= 0.5;
$DamageScale[aarmor,	$BulletDamageType] 	= 1.0;
$DamageScale[aarmor,	$CloakDamageType] 	= 0.0;
$DamageScale[aarmor,	$CrushDamageType] 	= 1.0;
$DamageScale[aarmor,	$DebrisDamageType] 	= 1.2;
$DamageScale[aarmor,	$ElectricityDamageType] = 0.2;
$DamageScale[aarmor,	$ELFDamageType] = 0.2;
$DamageScale[aarmor,	$EnergyDamageType] 	= 0.3;
$DamageScale[aarmor,	$EqualizerDamageType] 	= 1.2;
$DamageScale[aarmor,	$ExplosionDamageType] 	= 1.1;
$DamageScale[aarmor,	$FlashDamageType] 	= 0.5;
$DamageScale[aarmor,	$GravDamageType]	= 0.0;  //was 1.7
$DamageScale[aarmor,	$GayDamageType] 	 	= 1.0;  //added
$DamageScale[aarmor,	$IDamageType] 	 	= 0.7;
$DamageScale[aarmor,	$ImpactDamageType] 	= 1.0;
$DamageScale[aarmor,	$LandingDamageType] 	= 0.3;
$DamageScale[aarmor,	$LaserDamageType] 	= 0.5;
$DamageScale[aarmor,	$MagDamageType] 	= 1.0;  //added
$DamageScale[aarmor,	$MineDamageType] 	= 1.0;
$DamageScale[aarmor,	$MissileDamageType] 	= 1.2;
$DamageScale[aarmor,	$MortarDamageType] 	= 1.5;
$DamageScale[aarmor,	$NukeDamageType] 	= 1.3;
$DamageScale[aarmor,	$PlasmaDamageType] 	= 1.5;
$DamageScale[aarmor,	$ShellDamageType] 	= 1.2;
$DamageScale[aarmor,	$ShrapnelDamageType] 	= 1.2;
$DamageScale[aarmor,	$SniperDamageType] 	= 1.2;
$DamageScale[afemale,	$AntimatterDamageType] 	= 0.01;  //added
$DamageScale[afemale,	$BlasterDamageType] 	= 0.5;
$DamageScale[afemale,	$BulletDamageType] 	= 1.0;
$DamageScale[afemale,	$CloakDamageType]	= 0.0;
$DamageScale[afemale,	$CrushDamageType] 	= 1.0;
$DamageScale[afemale,	$DebrisDamageType] 	= 1.2;
$DamageScale[afemale,	$ElectricityDamageType] = 0.2;
$DamageScale[afemale,	$ELFDamageType] = 0.2;
$DamageScale[afemale,	$EnergyDamageType] 	= 0.3;
$DamageScale[afemale,	$EqualizerDamageType] 	= 1.2;
$DamageScale[afemale,	$ExplosionDamageType] 	= 1.0;
$DamageScale[afemale,	$FlashDamageType] 	= 0.5;
$DamageScale[afemale,	$GravDamageType]	= 0.0;  //was 1.7
$DamageScale[afemale,	$GayDamageType] 	 	= 1.0;  //added
$DamageScale[afemale,	$IDamageType] 	 	= 0.7;
$DamageScale[afemale,	$ImpactDamageType] 	= 1.0;
$DamageScale[afemale,	$LandingDamageType] 	= 0.3;
$DamageScale[afemale,	$LaserDamageType] 	= 0.5;
$DamageScale[afemale,	$MagDamageType] 	= 1.0;  //added
$DamageScale[afemale,	$MineDamageType] 	= 1.0;
$DamageScale[afemale,	$MissileDamageType] 	= 1.2;
$DamageScale[afemale,	$MortarDamageType] 	= 1.5;
$DamageScale[afemale,	$NukeDamageType] 	= 1.3;
$DamageScale[afemale,	$PlasmaDamageType] 	= 1.5;
$DamageScale[afemale,	$ShellDamageType] 	= 1.2;
$DamageScale[afemale,	$ShrapnelDamageType] 	= 1.2;
$DamageScale[afemale,	$SniperDamageType] 	= 1.2;
$DamageScale[barmor,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[barmor,	$BlasterDamageType] = 1.2;
$DamageScale[barmor,	$BulletDamageType] = 1.3;
$DamageScale[barmor,	$CloakDamageType] 	 = 0.0;
$DamageScale[barmor,	$CrushDamageType] = 1.0;
$DamageScale[barmor,	$DebrisDamageType] = 1.0;
$DamageScale[barmor,	$ElectricityDamageType] = 1.0;
$DamageScale[barmor,	$ELFDamageType] = 1.0;
$DamageScale[barmor,	$EnergyDamageType] = 1.1;
$DamageScale[barmor,	$EqualizerDamageType] 	 = 1.1;
$DamageScale[barmor,	$ExplosionDamageType] = 0.5;
$DamageScale[barmor,	$FlashDamageType] = 1.0;
$DamageScale[barmor,	$GravDamageType] 	 = 0.0;  //was 0.1
$DamageScale[barmor,	$GayDamageType] 	 = 1.0;  //added
$DamageScale[barmor,	$IDamageType] 	 = 0.7;
$DamageScale[barmor,	$ImpactDamageType] = 1.0;
$DamageScale[barmor,	$LandingDamageType] = 1.0;
$DamageScale[barmor,	$LaserDamageType] = 1.2;
$DamageScale[barmor,	$MagDamageType] = 1.3;  //added
$DamageScale[barmor,	$MineDamageType] = 0.5;
$DamageScale[barmor,	$MissileDamageType] = 0.5;
$DamageScale[barmor,	$MortarDamageType] = 0.5;
$DamageScale[barmor,	$NukeDamageType] = 1.0;
$DamageScale[barmor,	$PlasmaDamageType] = 0.5;
$DamageScale[barmor,	$ShellDamageType] = 1.0;
$DamageScale[barmor,	$ShrapnelDamageType] = 0.5;
$DamageScale[barmor,	$SniperDamageType] = 1.0;
$DamageScale[bfemale,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[bfemale,	$BlasterDamageType] = 1.2;
$DamageScale[bfemale,	$BulletDamageType] = 1.3;
$DamageScale[bfemale,	$CloakDamageType]	 = 0.0;
$DamageScale[bfemale,	$CrushDamageType] = 1.0;
$DamageScale[bfemale,	$DebrisDamageType] = 1.0;
$DamageScale[bfemale,	$ElectricityDamageType] = 1.0;
$DamageScale[bfemale,	$ELFDamageType] = 1.0;
$DamageScale[bfemale,	$EnergyDamageType] = 1.1;
$DamageScale[bfemale,	$EqualizerDamageType]	 = 1.1;
$DamageScale[bfemale,	$ExplosionDamageType] = 0.5;
$DamageScale[bfemale,	$FlashDamageType] = 1.0;
$DamageScale[bfemale,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[bfemale,	$GayDamageType]	 = 1.0;  //added
$DamageScale[bfemale,	$IDamageType]	 = 0.7;
$DamageScale[bfemale,	$ImpactDamageType] = 1.0;
$DamageScale[bfemale,	$LandingDamageType] = 1.0;
$DamageScale[bfemale,	$LaserDamageType] = 1.2;
$DamageScale[bfemale,	$MagDamageType] = 1.3;  //added
$DamageScale[bfemale,	$MineDamageType] = 0.5;
$DamageScale[bfemale,	$MissileDamageType] = 0.5;
$DamageScale[bfemale,	$MortarDamageType] = 0.5;
$DamageScale[bfemale,	$NukeDamageType] = 1.0;
$DamageScale[bfemale,	$PlasmaDamageType] = 0.5;
$DamageScale[bfemale,	$ShellDamageType] = 1.0;
$DamageScale[bfemale,	$ShrapnelDamageType] = 0.5;
$DamageScale[bfemale,	$SniperDamageType] = 1.0;
$DamageScale[darmor,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[darmor,	$BlasterDamageType] = 0.7;
$DamageScale[darmor,	$BulletDamageType] = 0.5;
$DamageScale[darmor,	$CloakDamageType] 	 = 0.0;
$DamageScale[darmor,	$CrushDamageType] = 0.8;
$DamageScale[darmor,	$DebrisDamageType] = 0.8;
$DamageScale[darmor,	$ElectricityDamageType] = 0.8;
$DamageScale[darmor,	$ELFDamageType] = 0.8;
$DamageScale[darmor,	$EnergyDamageType] = 0.7;
$DamageScale[darmor,	$EqualizerDamageType] 	 = 0.8;
$DamageScale[darmor,	$ExplosionDamageType] = 0.6;
$DamageScale[darmor,	$FlashDamageType] = 1.0;
$DamageScale[darmor,	$GravDamageType] 	 = 0.0;  //was 0.1
$DamageScale[darmor,	$GayDamageType] 	 = 1.0;
$DamageScale[darmor,	$IDamageType] 	 = 0.7;
$DamageScale[darmor,	$ImpactDamageType] = 0.8;
$DamageScale[darmor,	$LandingDamageType] = 0.8;
$DamageScale[darmor,	$LaserDamageType] = 0.6;
$DamageScale[darmor,	$MagDamageType] = 0.5;  //added
$DamageScale[darmor,	$MineDamageType] = 0.8;
$DamageScale[darmor,	$MissileDamageType] = 0.6;
$DamageScale[darmor,	$MortarDamageType] = 0.7;
$DamageScale[darmor,	$NukeDamageType] = 1.0;
$DamageScale[darmor,	$PlasmaDamageType] = 0.7;
$DamageScale[darmor,	$ShellDamageType] = 1.0;
$DamageScale[darmor,	$ShrapnelDamageType] = 0.8;
$DamageScale[darmor,	$SniperDamageType] = 0.6;
$DamageScale[dmarmor,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[dmarmor,	$BlasterDamageType] = 1.0;
$DamageScale[dmarmor,	$BulletDamageType] = 1.0;
$DamageScale[dmarmor,	$CloakDamageType] 	 = 0.0;
$DamageScale[dmarmor,	$CrushDamageType] = 1.0;
$DamageScale[dmarmor,	$DebrisDamageType] = 1.0;
$DamageScale[dmarmor,	$ElectricityDamageType] = 1.0;
$DamageScale[dmarmor,	$ELFDamageType] = 1.0;
$DamageScale[dmarmor,	$EnergyDamageType] = 1.0;
$DamageScale[dmarmor,	$EqualizerDamageType] 	 = 1.0;
$DamageScale[dmarmor,	$ExplosionDamageType] = 1.0;
$DamageScale[dmarmor,	$FlashDamageType] = 1.0;
$DamageScale[dmarmor,	$GravDamageType] 	 = 0.0;  //was 0.1
$DamageScale[dmarmor,	$GayDamageType] 	 = 1.0;
$DamageScale[dmarmor,	$IDamageType] 	 = 1.0;
$DamageScale[dmarmor,	$ImpactDamageType] = 1.0;
$DamageScale[dmarmor,	$LandingDamageType] = 0.4;
$DamageScale[dmarmor,	$LaserDamageType] = 1.0;
$DamageScale[dmarmor,	$MagDamageType] = 1.0;
$DamageScale[dmarmor,	$MineDamageType] = 1.0;
$DamageScale[dmarmor,	$MissileDamageType] = 1.0;
$DamageScale[dmarmor,	$MortarDamageType] = 1.0;
$DamageScale[dmarmor,	$NukeDamageType] = 1.0;
$DamageScale[dmarmor,	$PlasmaDamageType] = 1.0;
$DamageScale[dmarmor,	$ShellDamageType] = 1.0;
$DamageScale[dmarmor,	$ShrapnelDamageType] = 1.0;
$DamageScale[dmarmor,	$SniperDamageType] = 1.0;
$DamageScale[dmfemale,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[dmfemale,	$BlasterDamageType] = 1.0;
$DamageScale[dmfemale,	$BulletDamageType] = 1.0;
$DamageScale[dmfemale,	$CloakDamageType] 	 = 0.0;
$DamageScale[dmfemale,	$CrushDamageType] = 1.0;
$DamageScale[dmfemale,	$DebrisDamageType] = 1.0;
$DamageScale[dmfemale,	$ElectricityDamageType] = 1.0;
$DamageScale[dmfemale,	$ELFDamageType] = 1.0;
$DamageScale[dmfemale,	$EnergyDamageType] = 1.0;
$DamageScale[dmfemale,	$EqualizerDamageType] 	 = 1.0;
$DamageScale[dmfemale,	$ExplosionDamageType] = 1.0;
$DamageScale[dmfemale,	$FlashDamageType] = 1.0;
$DamageScale[dmfemale,	$GravDamageType] 	 = 0.0;  //was 0.1
$DamageScale[dmfemale,	$GayDamageType] 	 = 1.0;
$DamageScale[dmfemale,	$IDamageType] 	 = 1.0;
$DamageScale[dmfemale,	$ImpactDamageType] = 1.0;
$DamageScale[dmfemale,	$LandingDamageType] = 0.4;
$DamageScale[dmfemale,	$LaserDamageType] = 1.0;
$DamageScale[dmfemale,	$MagDamageType] = 1.0;
$DamageScale[dmfemale,	$MineDamageType] = 1.0;
$DamageScale[dmfemale,	$MissileDamageType] = 1.0;
$DamageScale[dmfemale,	$MortarDamageType] = 1.0;
$DamageScale[dmfemale,	$NukeDamageType] = 1.0;
$DamageScale[dmfemale,	$PlasmaDamageType] = 1.0;
$DamageScale[dmfemale,	$ShellDamageType] = 1.0;
$DamageScale[dmfemale,	$ShrapnelDamageType] = 1.0;
$DamageScale[dmfemale,	$SniperDamageType] = 1.0;
$DamageScale[earmor,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[earmor,	$BlasterDamageType] = 1.0;
$DamageScale[earmor,	$BulletDamageType] = 1.0;
$DamageScale[earmor,	$CloakDamageType] 	 = 0.0;
$DamageScale[earmor,	$CrushDamageType] = 1.0;
$DamageScale[earmor,	$DebrisDamageType] = 1.0;
$DamageScale[earmor,	$ElectricityDamageType] = 1.0;
$DamageScale[earmor,	$ELFDamageType] = 1.0;
$DamageScale[earmor,	$EnergyDamageType] = 1.0;
$DamageScale[earmor,	$EqualizerDamageType] 	 = 0.7;
$DamageScale[earmor,	$ExplosionDamageType] = 1.0;
$DamageScale[earmor,	$FlashDamageType] = 0.7;
$DamageScale[earmor,	$GravDamageType] 	 = 0.0;  //was 0.1
$DamageScale[earmor,	$GayDamageType] 	 = 1.0;  //added
$DamageScale[earmor,	$IDamageType] 	 = 0.7;
$DamageScale[earmor,	$ImpactDamageType] = 1.0;
$DamageScale[earmor,	$LandingDamageType] = 1.0;
$DamageScale[earmor,	$LaserDamageType] = 1.0;
$DamageScale[earmor,	$MagDamageType] = 1.0;  //added
$DamageScale[earmor,	$MineDamageType] = 1.0;
$DamageScale[earmor,	$MissileDamageType] = 1.0;
$DamageScale[earmor,	$MortarDamageType] = 1.0;
$DamageScale[earmor,	$NukeDamageType] = 1.0;
$DamageScale[earmor,	$PlasmaDamageType] = 1.0;
$DamageScale[earmor,	$ShellDamageType] = 1.0;
$DamageScale[earmor,	$ShrapnelDamageType] = 1.0;
$DamageScale[earmor,	$SniperDamageType] = 1.0;
$DamageScale[efemale,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[efemale,	$BlasterDamageType] = 1.0;
$DamageScale[efemale,	$BulletDamageType] = 1.0;
$DamageScale[efemale,	$CloakDamageType]	 = 0.0;
$DamageScale[efemale,	$CrushDamageType] = 1.0;
$DamageScale[efemale,	$DebrisDamageType] = 1.0;
$DamageScale[efemale,	$ElectricityDamageType] = 1.0;
$DamageScale[efemale,	$ELFDamageType] = 1.0;
$DamageScale[efemale,	$EnergyDamageType] = 1.0;
$DamageScale[efemale,	$EqualizerDamageType]	 = 0.7;
$DamageScale[efemale,	$ExplosionDamageType] = 1.0;
$DamageScale[efemale,	$FlashDamageType] = 0.7;
$DamageScale[efemale,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[efemale,	$GayDamageType]	 = 1.0;
$DamageScale[efemale,	$IDamageType]	 = 0.7;
$DamageScale[efemale,	$ImpactDamageType] = 1.0;
$DamageScale[efemale,	$LandingDamageType] = 1.0;
$DamageScale[efemale,	$LaserDamageType] = 1.0;
$DamageScale[efemale,	$MagDamageType] = 1.0;  //added
$DamageScale[efemale,	$MineDamageType] = 1.0;
$DamageScale[efemale,	$MissileDamageType] = 1.0;
$DamageScale[efemale,	$MortarDamageType] = 1.0;
$DamageScale[efemale,	$NukeDamageType] = 1.0;
$DamageScale[efemale,	$PlasmaDamageType] = 1.0;
$DamageScale[efemale,	$ShellDamageType] = 1.0;
$DamageScale[efemale,	$ShrapnelDamageType] = 1.0;
$DamageScale[efemale,	$SniperDamageType] = 1.0;
$DamageScale[harmor,	$AntimatterDamageType] = 0.1;  //added
$DamageScale[harmor,	$BlasterDamageType] = 0.7;
$DamageScale[harmor,	$BulletDamageType] = 0.3;
$DamageScale[harmor,	$CloakDamageType]	 = 0.0;
$DamageScale[harmor,	$CrushDamageType] = 1.0;
$DamageScale[harmor,	$DebrisDamageType] = 0.5;
$DamageScale[harmor,	$ElectricityDamageType] = 1.5;  //was 1.5  
$DamageScale[harmor,	$ELFDamageType] = 1.5;  
$DamageScale[harmor,	$EnergyDamageType] = 1.3;  //was .7
$DamageScale[harmor,	$EqualizerDamageType]	 = 1.3;
$DamageScale[harmor,	$ExplosionDamageType] = 0.6;
$DamageScale[harmor,	$FlashDamageType] = 1.5;  //was 1.0
$DamageScale[harmor,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[harmor,	$GayDamageType]	 = 1.0;
$DamageScale[harmor,	$IDamageType]	 = 0.7;  //was .7
$DamageScale[harmor,	$ImpactDamageType] = 1.0;  //was .5
$DamageScale[harmor,	$LandingDamageType] = 0.5;  //was .7
$DamageScale[harmor,	$LaserDamageType] = 0.7;  //was .6
$DamageScale[harmor,	$MagDamageType] = 0.3;  //added
$DamageScale[harmor,	$MineDamageType] = 0.8;
$DamageScale[harmor,	$MissileDamageType] = 0.7;  //was 1.0
$DamageScale[harmor,	$MortarDamageType] = 0.7;
$DamageScale[harmor,	$NukeDamageType] = 1.3;
$DamageScale[harmor,	$PlasmaDamageType] = 1.3;  //was .8
$DamageScale[harmor,	$ShellDamageType] = 1.3;
$DamageScale[harmor,	$ShrapnelDamageType] = 0.5;
$DamageScale[harmor,	$SniperDamageType] = 0.6;
$DamageScale[jarmor,	$AntimatterDamageType] = 0.1;  //added
$DamageScale[jarmor,	$BlasterDamageType] = 1.5;
$DamageScale[jarmor,	$BulletDamageType] = 1.0;
$DamageScale[jarmor,	$CloakDamageType] 	 = 0.0;
$DamageScale[jarmor,	$CrushDamageType] = 0.6;
$DamageScale[jarmor,	$DebrisDamageType] = 1.0;
$DamageScale[jarmor,	$ElectricityDamageType] = 1.2;
$DamageScale[jarmor,	$ELFDamageType] = 1.2;
$DamageScale[jarmor,	$EnergyDamageType] = 1.3;
$DamageScale[jarmor,	$EqualizerDamageType] 	 = 1.0;
$DamageScale[jarmor,	$ExplosionDamageType] = 1.0;
$DamageScale[jarmor,	$FlashDamageType] = 1.5;
$DamageScale[jarmor,	$GravDamageType] 	 = 0.0;  //was 0.1
$DamageScale[jarmor,	$GayDamageType] 	 = 1.0;
$DamageScale[jarmor,	$IDamageType] 	 = 0.7;
$DamageScale[jarmor,	$ImpactDamageType] = 0.5;
$DamageScale[jarmor,	$LandingDamageType] = 0.2;
$DamageScale[jarmor,	$LaserDamageType] = 0.5;
$DamageScale[jarmor,	$MagDamageType] = 1.0;  //added
$DamageScale[jarmor,	$MineDamageType] = 1.0;
$DamageScale[jarmor,	$MissileDamageType] = 1.0;
$DamageScale[jarmor,	$MortarDamageType] = 1.2;
$DamageScale[jarmor,	$NukeDamageType] = 1.0;
$DamageScale[jarmor,	$PlasmaDamageType] = 2.0;
$DamageScale[jarmor,	$ShellDamageType] = 1.0;
$DamageScale[jarmor,	$ShrapnelDamageType] = 1.0;
$DamageScale[jarmor,	$SniperDamageType] = 1.0;
$DamageScale[larmor,	$AntimatterDamageType] = 0.07;  //added
$DamageScale[larmor,	$BlasterDamageType] = 1.3;
$DamageScale[larmor,	$BulletDamageType] = 1.2;
$DamageScale[larmor,	$CloakDamageType]	 = 0.0;
$DamageScale[larmor,	$CrushDamageType] = 1.0;
$DamageScale[larmor,	$DebrisDamageType] = 1.2;
$DamageScale[larmor,	$ElectricityDamageType] = 1.0;
$DamageScale[larmor,	$ELFDamageType] = 1.0;
$DamageScale[larmor,	$EnergyDamageType] = 1.3;
$DamageScale[larmor,	$EqualizerDamageType]	 = 1.0;
$DamageScale[larmor,	$ExplosionDamageType] = 1.0;
$DamageScale[larmor,	$FlashDamageType] = 1.0;
$DamageScale[larmor,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[larmor,	$GayDamageType]	 = 1.0;  //added
$DamageScale[larmor,	$IDamageType]	 = 0.7;
$DamageScale[larmor,	$ImpactDamageType] = 1.0;
$DamageScale[larmor,	$LandingDamageType] = 1.0;
$DamageScale[larmor,	$LaserDamageType] = 1.0;
$DamageScale[larmor,	$MagDamageType] = 1.2;  //added
$DamageScale[larmor,	$MineDamageType] = 1.2;
$DamageScale[larmor,	$MissileDamageType] = 1.0;
$DamageScale[larmor,	$MortarDamageType] = 1.3;
$DamageScale[larmor,	$NukeDamageType] = 1.0;
$DamageScale[larmor,	$PlasmaDamageType] = 1.0;
$DamageScale[larmor,	$ShellDamageType] = 1.0;
$DamageScale[larmor,	$ShrapnelDamageType] = 1.2;
$DamageScale[larmor,	$SniperDamageType] = 1.0;
$DamageScale[lfemale,	$AntimatterDamageType] = 0.08;  //added
$DamageScale[lfemale,	$BlasterDamageType] = 1.3;
$DamageScale[lfemale,	$BulletDamageType] = 1.2;
$DamageScale[lfemale,	$CloakDamageType]	 = 0.0;
$DamageScale[lfemale,	$CrushDamageType] = 1.0;	
$DamageScale[lfemale,	$DebrisDamageType] = 1.2;
$DamageScale[lfemale,	$ElectricityDamageType] = 1.0;
$DamageScale[lfemale,	$ELFDamageType] = 1.0;
$DamageScale[lfemale,	$EnergyDamageType] = 1.3;
$DamageScale[lfemale,	$EqualizerDamageType]	 = 1.0;
$DamageScale[lfemale,	$ExplosionDamageType] = 1.0;
$DamageScale[lfemale,	$FlashDamageType] = 1.0;
$DamageScale[lfemale,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[lfemale,	$GayDamageType]	 = 1.0;
$DamageScale[lfemale,	$IDamageType]	 = 0.7;
$DamageScale[lfemale,	$ImpactDamageType] = 1.0;	
$DamageScale[lfemale,	$LandingDamageType] = 1.0;
$DamageScale[lfemale,	$LaserDamageType] = 1.0;
$DamageScale[lfemale,	$MagDamageType] = 1.2;  //added
$DamageScale[lfemale,	$MineDamageType] = 1.2;
$DamageScale[lfemale,	$MissileDamageType] = 1.0;
$DamageScale[lfemale,	$MortarDamageType] = 1.3;
$DamageScale[lfemale,	$NukeDamageType] = 1.0;
$DamageScale[lfemale,	$PlasmaDamageType] = 1.0;
$DamageScale[lfemale,	$ShellDamageType] = 1.0;
$DamageScale[lfemale,	$ShrapnelDamageType] = 1.2;
$DamageScale[lfemale,	$SniperDamageType] = 1.0;
$DamageScale[marmor,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[marmor,	$BlasterDamageType] = 1.0;
$DamageScale[marmor,	$BulletDamageType] = 1.0;
$DamageScale[marmor,	$CloakDamageType]	 = 0.0;
$DamageScale[marmor,	$CrushDamageType] = 1.0;
$DamageScale[marmor,	$DebrisDamageType] = 1.0;
$DamageScale[marmor,	$ElectricityDamageType] = 0.2;
$DamageScale[marmor,	$ELFDamageType] = 0.2;
$DamageScale[marmor,	$EnergyDamageType] = 1.0;
$DamageScale[marmor,	$EqualizerDamageType]	 = 1.0;
$DamageScale[marmor,	$ExplosionDamageType] = 1.0;
$DamageScale[marmor,	$FlashDamageType] = 1.0;
$DamageScale[marmor,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[marmor,	$GayDamageType]	 = 1.0;  //added
$DamageScale[marmor,	$IDamageType]	 = 0.7;
$DamageScale[marmor,	$ImpactDamageType] = 1.0;
$DamageScale[marmor,	$LandingDamageType] = 1.0;
$DamageScale[marmor,	$LaserDamageType] = 1.0;
$DamageScale[marmor,	$MagDamageType] = 1.0;  //added
$DamageScale[marmor,	$MineDamageType] = 1.0;
$DamageScale[marmor,	$MissileDamageType] = 1.0;
$DamageScale[marmor,	$MortarDamageType] = 1.0;
$DamageScale[marmor,	$NukeDamageType] = 1.0;
$DamageScale[marmor,	$PlasmaDamageType] = 1.0;
$DamageScale[marmor,	$ShellDamageType] = 1.0;
$DamageScale[marmor,	$ShrapnelDamageType] = 1.0;
$DamageScale[marmor,	$SniperDamageType] = 1.0;
$DamageScale[mfemale,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[mfemale,	$BlasterDamageType] = 1.0;
$DamageScale[mfemale,	$BulletDamageType] = 1.0;
$DamageScale[mfemale,	$CloakDamageType]	 = 0.0;
$DamageScale[mfemale,	$CrushDamageType] = 1.0;
$DamageScale[mfemale,	$DebrisDamageType] = 1.0;
$DamageScale[mfemale,	$ElectricityDamageType] = 0.2;
$DamageScale[mfemale,	$ELFDamageType] = 0.2;
$DamageScale[mfemale,	$EnergyDamageType] = 1.0;
$DamageScale[mfemale,	$EqualizerDamageType]	 = 1.0;
$DamageScale[mfemale,	$ExplosionDamageType] = 1.0;
$DamageScale[mfemale,	$FlashDamageType] = 1.0;
$DamageScale[mfemale,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[mfemale,	$GayDamageType]	 = 1.0;  //added
$DamageScale[mfemale,	$IDamageType]	 = 0.7;
$DamageScale[mfemale,	$ImpactDamageType] = 1.0;
$DamageScale[mfemale,	$LandingDamageType] = 1.0;
$DamageScale[mfemale,	$LaserDamageType] = 1.0;
$DamageScale[mfemale,	$MagDamageType] = 1.0;  //added
$DamageScale[mfemale,	$MineDamageType] = 1.0;
$DamageScale[mfemale,	$MissileDamageType] = 1.0;
$DamageScale[mfemale,	$MortarDamageType] = 1.0;
$DamageScale[mfemale,	$NukeDamageType] = 1.0;
$DamageScale[mfemale,	$PlasmaDamageType] = 1.0;
$DamageScale[mfemale,	$ShellDamageType] = 1.0;
$DamageScale[mfemale,	$ShrapnelDamageType] = 1.0;
$DamageScale[mfemale,	$SniperDamageType] = 1.0;
$DamageScale[parmor,	$AntimatterDamageType] = 0.02;  //added
$DamageScale[parmor,	$BlasterDamageType] = 0.0;
$DamageScale[parmor,	$BulletDamageType] = 0.0;
$DamageScale[parmor,	$CloakDamageType]  	 = 0.0;
$DamageScale[parmor,	$CrushDamageType] = 0.0;
$DamageScale[parmor,	$DebrisDamageType] = 0.0;
$DamageScale[parmor,	$ElectricityDamageType] = 0.0;
$DamageScale[parmor,	$EnergyDamageType] = 0.0;
$DamageScale[parmor,	$EqualizerDamageType]  	 = 0.0;
$DamageScale[parmor,	$ExplosionDamageType] = 0.0;
$DamageScale[parmor,	$FlashDamageType] = 0.0;
$DamageScale[parmor,	$GravDamageType] = 10.0;  //added
$DamageScale[parmor,	$IDamageType]  	 = 0.0;
$DamageScale[parmor,	$ImpactDamageType] = 0.0;
$DamageScale[parmor,	$LandingDamageType] = 0.0;
$DamageScale[parmor,	$LaserDamageType] = 0.0;
$DamageScale[parmor,	$MineDamageType] = 0.0;
$DamageScale[parmor,	$MissileDamageType] = 0.0;
$DamageScale[parmor,	$MortarDamageType] = 0.0;
$DamageScale[parmor,	$NukeDamageType] = 0.0;
$DamageScale[parmor,	$PlasmaDamageType] = 0.0;
$DamageScale[parmor,	$ShellDamageType] = 0.0;
$DamageScale[parmor,	$ShrapnelDamageType] = 0.0;
$DamageScale[parmor,	$SniperDamageType] = 0.0;
$DamageScale[sarmor,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[sarmor,	$BlasterDamageType] = 1.3;
$DamageScale[sarmor,	$BulletDamageType] = 1.2;
$DamageScale[sarmor,	$CloakDamageType]	 = 0.0;
$DamageScale[sarmor,	$CrushDamageType] = 0.5;
$DamageScale[sarmor,	$DebrisDamageType] = 1.2;
$DamageScale[sarmor,	$ElectricityDamageType] = 1.0;
$DamageScale[sarmor,	$ELFDamageType] = 1.0;
$DamageScale[sarmor,	$EnergyDamageType] = 1.3;
$DamageScale[sarmor,	$EqualizerDamageType]	 = 1.1;
$DamageScale[sarmor,	$ExplosionDamageType] = 1.0;
$DamageScale[sarmor,	$FlashDamageType] = 1.0;
$DamageScale[sarmor,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[sarmor,	$GayDamageType]	 = 1.0;
$DamageScale[sarmor,	$IDamageType]	 = 0.7;
$DamageScale[sarmor,	$ImpactDamageType] = 0.5;
$DamageScale[sarmor,	$LandingDamageType] = 0.5;
$DamageScale[sarmor,	$LaserDamageType] = 1.2;
$DamageScale[sarmor,	$MagDamageType] = 1.2;  //added
$DamageScale[sarmor,	$MineDamageType] = 1.2;
$DamageScale[sarmor,	$MissileDamageType] = 1.0;
$DamageScale[sarmor,	$MortarDamageType] = 1.3;
$DamageScale[sarmor,	$NukeDamageType] = 1.0;
$DamageScale[sarmor,	$PlasmaDamageType] = 1.0;
$DamageScale[sarmor,	$ShellDamageType] = 1.0;
$DamageScale[sarmor,	$ShrapnelDamageType] = 1.2;
$DamageScale[sarmor,	$SniperDamageType] = 1.0;
$DamageScale[sfemale,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[sfemale,	$BlasterDamageType] = 1.3;
$DamageScale[sfemale,	$BulletDamageType] = 1.2;
$DamageScale[sfemale,	$CloakDamageType]	 = 0.0;
$DamageScale[sfemale,	$CrushDamageType] = 0.5;	
$DamageScale[sfemale,	$DebrisDamageType] = 1.2;
$DamageScale[sfemale,	$ElectricityDamageType] = 1.0;
$DamageScale[sfemale,	$ELFDamageType] = 1.0;
$DamageScale[sfemale,	$EnergyDamageType] = 1.3;
$DamageScale[sfemale,	$EqualizerDamageType]	 = 1.1;
$DamageScale[sfemale,	$ExplosionDamageType] = 1.0;
$DamageScale[sfemale,	$FlashDamageType] = 1.0;
$DamageScale[sfemale,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[sfemale,	$GayDamageType]	 = 1.0;  //added
$DamageScale[sfemale,	$IDamageType]	 = 0.7;
$DamageScale[sfemale,	$ImpactDamageType] = 0.5;	
$DamageScale[sfemale,	$LandingDamageType] = 0.5;
$DamageScale[sfemale,	$LaserDamageType] = 1.0;
$DamageScale[sfemale,	$MagDamageType] = 1.2;  //added
$DamageScale[sfemale,	$MineDamageType] = 1.2;
$DamageScale[sfemale,	$MissileDamageType] = 1.0;
$DamageScale[sfemale,	$MortarDamageType] = 1.3;
$DamageScale[sfemale,	$NukeDamageType] = 1.0;
$DamageScale[sfemale,	$PlasmaDamageType] = 1.0;
$DamageScale[sfemale,	$ShellDamageType] = 1.0;
$DamageScale[sfemale,	$ShrapnelDamageType] = 1.2;
$DamageScale[sfemale,	$SniperDamageType] = 1.0;
$DamageScale[spyarmor,	$AntimatterDamageType] = 0.01; //added
$DamageScale[spyarmor,	$BlasterDamageType] = 1.3;
$DamageScale[spyarmor,	$BulletDamageType] = 0.5;
$DamageScale[spyarmor,	$CloakDamageType]	 = 0.0;
$DamageScale[spyarmor,	$CrushDamageType] = 1.0;
$DamageScale[spyarmor,	$DebrisDamageType] = 1.3;
$DamageScale[spyarmor,	$ElectricityDamageType] = 1.0;
$DamageScale[spyarmor,	$ELFDamageType] = 1.0;
$DamageScale[spyarmor,	$EnergyDamageType] = 1.3;
$DamageScale[spyarmor,	$EqualizerDamageType]	 = 0.9;
$DamageScale[spyarmor,	$ExplosionDamageType] = 1.2;
$DamageScale[spyarmor,	$FlashDamageType] = 1.0;
$DamageScale[spyarmor,	$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[spyarmor,	$GayDamageType]	 = 1.0;  //added
$DamageScale[spyarmor,	$IDamageType]	 = 0.7;
$DamageScale[spyarmor,	$ImpactDamageType] = 1.0;
$DamageScale[spyarmor,	$LandingDamageType] = 1.0;
$DamageScale[spyarmor,	$LaserDamageType] = 1.0;
$DamageScale[spyarmor,	$MagDamageType] = 0.5;  //added
$DamageScale[spyarmor,	$MineDamageType] = 1.2;
$DamageScale[spyarmor,	$MissileDamageType] = 1.3;
$DamageScale[spyarmor,	$MortarDamageType] = 1.3;
$DamageScale[spyarmor,	$NukeDamageType] = 0.9;
$DamageScale[spyarmor,	$PlasmaDamageType] = 1.2;
$DamageScale[spyarmor,	$ShellDamageType] = 0.9;
$DamageScale[spyarmor,	$ShrapnelDamageType] = 1.3;
$DamageScale[spyarmor,	$SniperDamageType] = 1.0;
$DamageScale[spyfemale,	$AntimatterDamageType] = 0.01;  //added
$DamageScale[spyfemale, $CloakDamageType]	 = 0.0;
$DamageScale[spyfemale, $GravDamageType]	 = 0.1;
$DamageScale[spyfemale, $NukeDamageType] = 0.9;
$DamageScale[spyfemale,	$BlasterDamageType] = 1.3;
$DamageScale[spyfemale,	$BulletDamageType] = 0.5;
$DamageScale[spyfemale,	$CrushDamageType] = 1.0;
$DamageScale[spyfemale,	$DebrisDamageType] = 1.3;
$DamageScale[spyfemale,	$ElectricityDamageType] = 1.0;
$DamageScale[spyfemale,	$ELFDamageType] = 1.0;
$DamageScale[spyfemale,	$EnergyDamageType] = 1.3;
$DamageScale[spyfemale,	$EqualizerDamageType]	 = 0.9;
$DamageScale[spyfemale,	$ExplosionDamageType] = 1.2;
$DamageScale[spyfemale,	$FlashDamageType] = 1.0;
$DamageScale[spyfemale,	$GayDamageType]	 = 1.0;  //added
$DamageScale[spyfemale,	$IDamageType]	 = 0.7;
$DamageScale[spyfemale,	$ImpactDamageType] = 1.0;
$DamageScale[spyfemale,	$LandingDamageType] = 1.0;
$DamageScale[spyfemale,	$LaserDamageType] = 1.0;
$DamageScale[spyfemale,	$MagDamageType] = 0.5;  //added
$DamageScale[spyfemale,	$MineDamageType] = 1.2;
$DamageScale[spyfemale,	$MissileDamageType] = 1.3;
$DamageScale[spyfemale,	$MortarDamageType] = 1.3;
$DamageScale[spyfemale,	$PlasmaDamageType] = 1.2;
$DamageScale[spyfemale,	$ShellDamageType] = 0.9;
$DamageScale[spyfemale,	$ShrapnelDamageType] = 1.3;
$DamageScale[spyfemale,	$SniperDamageType] = 1.0;
$DamageScale[stimarmor, $AntimatterDamageType]	= 0.01;  //added
$DamageScale[stimarmor, $CloakDamageType]	 = 0.0;
$DamageScale[stimarmor, $GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[stimarmor, $NukeDamageType] = 1.0;
$DamageScale[stimarmor,	$BlasterDamageType] = 1.3;
$DamageScale[stimarmor,	$BulletDamageType] = 1.2;
$DamageScale[stimarmor,	$CrushDamageType] = 0.5;
$DamageScale[stimarmor,	$DebrisDamageType] = 1.2;
$DamageScale[stimarmor,	$ElectricityDamageType] = 1.0;
$DamageScale[stimarmor,	$ELFDamageType] = 1.0;
$DamageScale[stimarmor,	$EnergyDamageType] = 1.3;
$DamageScale[stimarmor,	$EqualizerDamageType]	 = 1.1;
$DamageScale[stimarmor,	$ExplosionDamageType] = 1.0;
$DamageScale[stimarmor,	$FlashDamageType] = 1.0;
$DamageScale[stimarmor,	$GayDamageType]	 = 1.0;  //added
$DamageScale[stimarmor,	$IDamageType]	 = 0.7;
$DamageScale[stimarmor,	$ImpactDamageType] = 0.5;
$DamageScale[stimarmor,	$LandingDamageType] = 0.5;
$DamageScale[stimarmor,	$LaserDamageType] = 1.2;
$DamageScale[stimarmor,	$MagDamageType] = 1.2;  //added
$DamageScale[stimarmor,	$MineDamageType] = 1.2;
$DamageScale[stimarmor,	$MissileDamageType] = 1.0;
$DamageScale[stimarmor,	$MortarDamageType] = 1.3;
$DamageScale[stimarmor,	$PlasmaDamageType] = 1.0;
$DamageScale[stimarmor,	$ShellDamageType] = 1.0;
$DamageScale[stimarmor,	$ShrapnelDamageType] = 1.2;
$DamageScale[stimarmor,	$SniperDamageType] = 1.0;
$DamageScale[stimfemale,$AntimatterDamageType] = 0.01;  //added
$DamageScale[stimfemale,$BlasterDamageType] = 1.3;
$DamageScale[stimfemale,$BulletDamageType] = 1.2;
$DamageScale[stimfemale,$CloakDamageType]	 = 0.0;
$DamageScale[stimfemale,$CrushDamageType] = 0.5;
$DamageScale[stimfemale,$DebrisDamageType] = 1.2;
$DamageScale[stimfemale,$ElectricityDamageType] = 1.0;
$DamageScale[stimfemale,$ELFDamageType] = 1.0;
$DamageScale[stimfemale,$EnergyDamageType] = 1.3;
$DamageScale[stimfemale,$EqualizerDamageType]	 = 1.1;
$DamageScale[stimfemale,$ExplosionDamageType] = 1.0;
$DamageScale[stimfemale,$FlashDamageType] = 1.0;
$DamageScale[stimfemale,$GravDamageType]	 = 0.0;  //was 0.1
$DamageScale[stimfemale,$GayDamageType]	 = 1.0;  //added
$DamageScale[stimfemale,$IDamageType]	 = 0.7;
$DamageScale[stimfemale,$ImpactDamageType] = 0.5;
$DamageScale[stimfemale,$LandingDamageType] = 0.5;
$DamageScale[stimfemale,$LaserDamageType] = 1.2;
$DamageScale[stimfemale,$MagDamageType] = 1.2;  //added
$DamageScale[stimfemale,$MineDamageType] = 1.2;
$DamageScale[stimfemale,$MissileDamageType] = 1.0;
$DamageScale[stimfemale,$MortarDamageType] = 1.3;
$DamageScale[stimfemale,$NukeDamageType] = 1.0;
$DamageScale[stimfemale,$PlasmaDamageType] = 1.0;
$DamageScale[stimfemale,$ShellDamageType] = 1.0;
$DamageScale[stimfemale,$ShrapnelDamageType] = 1.2;
$DamageScale[stimfemale,$SniperDamageType] = 1.0;

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


//----------------------------------------------------------------------------
// Light Armor *Penis Cursed Armor
//----------------------------------------------------------------------------
PlayerData parmor {
 
className = "Armor";
shapeFile = "larmor";
damageSkinData = "armorDamageskins";
debrisId = playerDebris;
flameShapeName = "lflame";
shieldShapeName = "shield";
shadowDetailMask = 1;
visibleToSensor = True;
mapFilter = 1;
mapIcon = "M_player";
canCrouch = true;
maxJetSideForceFactor = 1;
maxJetForwardVelocity = 1;
minJetEnergy = 1;
jetForce = 1;
jetEnergyDrain = 3.8;
maxDamage = 0.11;
maxForwardSpeed = 2;
maxBackwardSpeed = 2;
maxSideSpeed = 2;
groundForce = 40 * 9.0;
mass = 20.0;
groundTraction = 3.0;
maxEnergy = 160;
drag = 1.0;
density = 1.2;
minDamageSpeed = 25;
damageScale = 0.005;
jumpImpulse = 75;
jumpSurfaceMinDot = 0.2;

animData[0] = { "root", none, 1, true, true, true, false, 0 };
animData[1] = { "run", none, 1, true, false, true, false, 3 };
animData[2] = { "runback", none, 1, true, false, true, false, 3 };
animData[3] = { "side left", none, 1, true, false, true, false, 3 };
animData[4] = { "side left", none, -1, true, false, true, false, 3 };
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
animData[14] = { "fall", none, 1, true, true, true, false, 3 };
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
animData[19] = { "jet", none, 1, true, true, true, false, 3 };
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
animData[21] = { "throw", none, 1, true, false, false, false, 3 };
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
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
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
animData[50] = { "wave", none, 1, true, false, false, true, 1 };
 
 jetSound = SoundJetLight;
 rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
 lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
 footPrints = { 0, 1 };
 boxWidth = 0.5;
 boxDepth = 0.5;
 boxNormalHeight = 2.3;
 boxCrouchHeight = 1.8;
 boxNormalHeadPercentage = 0.83;
 boxNormalTorsoPercentage = 0.53;
 boxCrouchHeadPercentage = 0.6666;
 boxCrouchTorsoPercentage = 0.3333;
 boxHeadRightPercentage = 1;
 boxHeadFrontPercentage = 1;
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
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.8;  //was .4
	maxJetForwardVelocity = 7;  //was 7
	minJetEnergy = 1;
	jetForce = 390;
	jetEnergyDrain = 1.2;  //was 1.5

	maxDamage = 2.0;

	maxForwardSpeed = 5.4;  //was 4.8
	maxBackwardSpeed = 5.0;  //was 4.6
	maxSideSpeed = 4.0;

	groundForce = 35 * 22.0;
	groundTraction = 4.5;

	mass = 18.2;  //was 20.0
	maxEnergy = 140;  //was 150
	
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
	shapeFile = "larmor";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 22;  //was 22
	minJetEnergy = 1;
	jetForce = 306;  //was 236
	jetEnergyDrain = 0.62;  //was 0.8

	maxDamage = 0.59;  //was 0.66
	maxForwardSpeed = 11;
	maxBackwardSpeed = 10;
	maxSideSpeed = 10;
	groundForce = 40 * 9.0;
	mass = 9.0;  //was 9
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
// Medium Armor data: Mercenary
//------------------------------------------------------------------

PlayerData marmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 395;  //was 325
   jetEnergyDrain = 0.55;  //was 1.0

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
// Medium Armor data: Death Match Male
//------------------------------------------------------------------

PlayerData dmarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 400;  //was 325
   jetEnergyDrain = 0.5;  //was 1.0

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
// Heavy Armor data: Neo-Juggernaught
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
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;  //was .8
   maxJetForwardVelocity = 10;  //was 12
   minJetEnergy = 1;
   jetForce = 390;  //was 390
   jetEnergyDrain = 0.75;  //was 1.1

	maxDamage = 1.32;
	
   maxForwardSpeed = 6.0;
   maxBackwardSpeed = 5.0;
	
   maxSideSpeed = 4.0;
   groundForce = 35 * 18.0;
   groundTraction = 4.5;
   mass = 18.0;  //was 18.0
	
	maxEnergy = 140;
   drag = 1.2;  //was 1.0
   density = 2.5;
   canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 150;
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
	
	//validateShape = true;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 23;  //was 22
   minJetEnergy = 1;
   jetForce = 316;  //was 236
   jetEnergyDrain = 0.6;  //was .8

	maxDamage = 0.56;  //was 0.66
   maxForwardSpeed = 11.5;  //was 11
   maxBackwardSpeed = 10.2;  //was 10
   maxSideSpeed = 10.2;  //was 1
   groundForce = 40 * 9.0;
   mass = 8.7;  //was 10
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
// Medium female data: Mercenary
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
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 400;  //was 325
   jetEnergyDrain = 0.5;  //was 1.0

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
// Medium female data: Death Match Female
//------------------------------------------------------------------

PlayerData dmfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 405;  //was 325
   jetEnergyDrain = 0.45;  //was 1.0

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
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.9;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 275;  //was 245
   jetEnergyDrain = 0.5;  //was 0.8

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
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 1.1;
   maxJetForwardVelocity = 35;
   minJetEnergy = 1;
   jetForce = 400;  //was 375
   jetEnergyDrain = 0.55;  //was 0.8

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
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 1.1;
	maxJetForwardVelocity = 26;
	minJetEnergy = 1;
	jetForce = 380;  //was 350
	jetEnergyDrain = 0.6;  //was 0.8

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
	flameShapeName = "plasmatrail";  //mflame
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	canCrouch = false;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.9;
	maxJetForwardVelocity = 18;
	minJetEnergy = 1;
	jetForce = 360;  //was 320
	jetEnergyDrain = 0.6;  //was 1.0

	maxDamage = 1.0;
	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 7.0;
	maxSideSpeed = 7.0;
	groundForce = 35 * 13.0;
	mass = 12.0;  //was 13
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

PlayerData darmor
{
	className = "Armor";
	shapeFile = "harmor";
	flameShapeName = "hflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 12;
	minJetEnergy = 1;
	jetForce = 410;  //was 385
	jetEnergyDrain = 0.65;  //was 1.1

	maxDamage = 1.70;

	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 6.0;
	maxSideSpeed = 6.0;

	groundForce = 35 * 19.0;
	groundTraction = 50;
	mass = 17.0;  //was 19

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
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 1.0;
   maxJetForwardVelocity = 25;
   minJetEnergy = 1;
   jetForce = 275;  //was 245
   jetEnergyDrain = 0.45;  //was 0.8

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
	flameShapeName = "plasmatrail";  //mflame
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 19;
	minJetEnergy = 1;
	jetForce = 380;  //was 320
	jetEnergyDrain = 0.55;  //was 1.0

	canCrouch = false;
	maxDamage = 1.0;
	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 7.0;
	maxSideSpeed = 7.0;
	groundForce = 35 * 13.0;
	mass = 10.8;  //was 13
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
// light armor data: *Chemeleon
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
	
	//validateShape = true;

   visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 310;  //was 270
   jetEnergyDrain = 0.4;  //was 0.8

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
// Light female data:  *Chemeleon
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
	
	//validateShape = true;

	visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";

	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 22;
	minJetEnergy = 1;
	jetForce = 320;  //was 260
	jetEnergyDrain = 0.38;  //was 0.8

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
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 375;  //was 325
   jetEnergyDrain = 0.45;  //was 1

	maxDamage = 1.0;
   maxForwardSpeed = 9.0;
   maxBackwardSpeed = 7.5;
   maxSideSpeed = 7.5;
   groundForce = 35 * 13.0;
   mass = 10.0;  //was 13
   groundTraction = 3.0;
	
	
	maxEnergy = 100;  //was 90
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
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 380;  //was 325
   jetEnergyDrain = 0.43;  //was 1.0

   canCrouch = false;
	maxDamage = 0.95;  //was 1.0
   maxForwardSpeed = 9.5;  //was 9.0
   maxBackwardSpeed = 9.0;  //was 8.5
   maxSideSpeed = 8.5;  //was 8.0
   groundForce = 35 * 13.0;
   mass = 9.8;  //was 13
   groundTraction = 3.0;
	
	maxEnergy = 105;  //was 90
   mass = 9.8;  //was 13
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
// Medium Armor data: Arbitor
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
	
	//validateShape = true;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 1.0;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 415;  //was 325
   jetEnergyDrain = 0.1;  //was 1.0

	maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 8.0;
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
// Medium female data: Arbitor
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
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 1.2;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 418;  //was 325
	jetEnergyDrain = 0.09;  //was 1.0

	canCrouch = false;
	maxDamage = 0.9;
	maxForwardSpeed = 9.0;
	maxBackwardSpeed = 9.0;
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

