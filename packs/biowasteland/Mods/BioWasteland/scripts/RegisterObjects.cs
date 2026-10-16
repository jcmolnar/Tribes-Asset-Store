function MissionRegDis( %MenuGroup, %ItemName )
{
	%DisName = strcat( %ItemName, ".dis" );
	MissionRegObject( %MenuGroup, %ItemName, MissionCreateObject, %ItemName, InteriorShape, %DisName );
}

function MissionRegItem( %MenuGroup, %Desc, %ItemName, %count )
{
	MissionRegObject( %MenuGroup, %Desc, MissionCreateObject, %ItemName, Item, %ItemName, %count, false, true);
}	
//-------------------------------- Mission
MissionRegObject( Mission, Group, MissionCreateObject, "Group", SimGroup );
MissionRegObject( Mission, Set, MissionCreateObject, "Set", SimSet );
MissionRegObject( Mission, Path, MissionCreateObject, "Path", SimPath );
MissionRegObject( Mission, Marker, MissionCreateObject, "Marker", Marker, PathMarker );
MissionRegObject( Mission, "Map Marker", MissionCreateObject, "Map Marker", Marker, MapMarker );
MissionRegObject( Mission, "Drop Point", MissionCreateObject, "Drop Point", Marker, DropPointMarker );
MissionRegObject( Mission, Trigger, MissionCreateObject,GroupTrigger, Trigger, GroupTrigger );
MissionRegObject( Mission, Volume, ME::onCreateVolume);
MissionRegObject( Mission, "Point Light", MissionCreateObject, PointLight, SimLight, Point, 10, 1, 1, 1, 0, 0, 0);

//-------------------------------- Sky
MissionRegObject( Sky, Sky, MissionCreateObject, sky, Sky, ".5", ".5", ".5" );
MissionRegObject( Sky, Planet, MissionCreateObject, planet, Planet );
MissionRegObject( Sky, Starfield, MissionCreateObject, stars, StarField );
MissionRegObject( Sky, Snow, MissionCreateObject, snow, Snowfall, 1, 0, 0, 0 );
MissionRegObject( Sky, Rain, MissionCreateObject, rain, Snowfall, 1, 0, 0, 1 );
MissionRegObject( Sky, Rain2, MissionCreateObject, rain, Snowfall, 1, 1, 1, 1 );
//-------------------------------- Objectives
MissionRegObject( Objectives, "Ancestor", MissionCreateObject, Ancestor, StaticShape, Ancestor );
MissionRegObject( Objectives, "EnergySteal", MissionCreateObject,EnergyTrigger, Trigger, EnergyTrigger );
MissionRegObject( Objectives, "Flag", ME::AddFlag);
MissionRegObject( Objectives, "Flag Stand", MissionCreateObject, Stand, StaticShape, FlagStand );
MissionRegObject( Objectives, "Race Chkpnt", MissionCreateObject,RaceTrigger, Trigger, RaceTrigger );
MissionRegObject( Objectives, "Switch: Help", MissionCreateObject, MapInstructions, StaticShape, HelpSwitch );
MissionRegObject( Objectives, "Switch: Ornamental", MissionCreateObject, Switch, StaticShape, JailSwitchOpen );
MissionRegObject( Objectives, "Switch: Tower", ME::AddTowerSwitch);
//-------------------------------- Stations
MissionRegObject( Stations, "Ammo", 		MissionCreateObject, AmmoStation, StaticShape, AmmoStation );
MissionRegObject( Stations, "Ammo: deployed", 	MissionCreateObject, DeployableAmmoStation, StaticShape, DeployableAmmoStation );
MissionRegObject( Stations, "Command", 		MissionCreateObject, CommandStation, StaticShape, CommandStation );
MissionRegObject( Stations, "Inventory", 	MissionCreateObject, InventoryStation, StaticShape, InventoryStation );
MissionRegObject( Stations, "Inventory: deployed", MissionCreateObject, DeployableInvStation, StaticShape, DeployableInvStation );
MissionRegObject( Stations, "EmergencyInv", 	MissionCreateObject, EmergencyInv, StaticShape, EmergencyInv );
MissionRegObject( Base, "EmergencyPad", 	MissionCreateObject, MainPad, StaticShape, MainPad);
MissionRegObject( Stations, "Vehicle", 		MissionCreateObject, VehicleStation, StaticShape, VehicleStation );
MissionRegObject( Stations, "Vehicle Pad", 	MissionCreateObject, VehiclePad, StaticShape, VehiclePad);
MissionRegObject( Stations, "Zepplin Pad", 		MissionCreateObject, ZepplinPad, StaticShape, ZepplinPad );
MissionRegItem( Stations, "DeployableAmmoPack", DeployableAmmoPack, 1);
MissionRegItem( Stations, "DeployableComPack", DeployableComPack, 1);
MissionRegItem( Stations, "DeployableInvPack", DeployableInvPack, 1);
//-------------------------------- Gens
MissionRegObject( Generators, "Generator", 		MissionCreateObject, Generator, StaticShape, Generator );
MissionRegObject( Generators, "Big Solar", 		MissionCreateObject, SolarBig, StaticShape, SolarBig );
MissionRegObject( Generators, "Portable Generator", 	MissionCreateObject, PortGen, StaticShape, PortGenerator );
MissionRegObject( Generators, "Solar Panel", 		MissionCreateObject, Solar, StaticShape, SolarPanel );
//-------------------------------- Turrets
MissionRegObject( Turrets, "Alien",     	MissionCreateObject, GunTuret, StaticShape, GunTuret );
MissionRegObject( Turrets, "Indoor Turret",  		MissionCreateObject, indoorTurret, Turret, indoorTurret );
MissionRegObject( Turrets, "Mortar Turret",  		MissionCreateObject, mortarTurret, Turret, mortarTurret );
MissionRegObject( Turrets, "Plasma Turret",  		MissionCreateObject, plasmaTurret, Turret, plasmaTurret );
MissionRegObject( Turrets, "Vulcan(ELF) Turret",  		MissionCreateObject, ELFTurret, Turret, ELFTurret );
MissionRegObject( Turrets, "Rocket Turret",  		MissionCreateObject, rocketTurret, Turret, rocketTurret );
MissionRegObject( TurretsDep, "AATurret", MissionCreateObject, BarragePack, Turret, BarrageTurret );
MissionRegObject( TurretsDep, "Concussion", MissionCreateObject, ConPack, Turret, DeployableConTurret );
MissionRegObject( TurretsDep, "Dart", MissionCreateObject, CameraPack, Turret, CameraTurret );
MissionRegObject( TurretsDep, "Elf", MissionCreateObject, DeployableElf, Turret, DeployableElfTurret );
MissionRegObject( TurretsDep, "EMP", MissionCreateObject, ShockPack, Turret, DeployableShock );
MissionRegObject( TurretsDep, "Flak", MissionCreateObject, FlakPack, Turret, DeployableFlak );
MissionRegObject( TurretsDep, "Flame", MissionCreateObject, FlameTurretPack, Turret, FlameTurret );
MissionRegObject( TurretsDep, "Guided Missile: Launcher", MissionCreateObject, CoolLauncher, Turret, DeployableCoolMortar );
MissionRegObject( TurretsDep, "Guided Missile: Stn", MissionCreateObject, comunit_remote, StaticShape, DeployableCoolStation );
MissionRegObject( TurretsDep, "Ion", MissionCreateObject, TurretPack, Turret, DeployableTurret);
MissionRegObject( TurretsDep, "Grav: Anti", MissionCreateObject, AGravPack, Turret, DeployableSnare);
MissionRegObject( TurretsDep, "Grav: Hyper", MissionCreateObject, HGravPack, Turret, DeployableHGravTurret);
MissionRegObject( TurretsDep, "Laser", MissionCreateObject, LaserPack, Turret, DeployableLaser );
MissionRegObject( TurretsDep, "Hellacious", MissionCreateObject, MalicePack, Turret, MaliceTurret );
MissionRegObject( TurretsDep, "Mortar", MissionCreateObject, TargetPack, Turret, DeployableMortar );
MissionRegObject( TurretsDep, "Plasma", MissionCreateObject, PlasmaTurretPack, TurretDep, DeployablePlasma );
MissionRegObject( TurretsDep, "Rail", MissionCreateObject, RailTurretPack, Turret, RailTurret );
MissionRegObject( TurretsDep, "Rocket", MissionCreateObject, RocketPack, Turret, DeployableRocket );
MissionRegObject( TurretsDep, "Target", MissionCreateObject, ChaingunTurretPack, Turret, DeployableChaingun );
MissionRegObject( TurretsDep, "Vulcan", MissionCreateObject, VulcanTurretPack, Turret, VulcanTurret );

//-------------------------------- Panels
MissionRegObject( Panels, "Chat Encryptor", 	MissionCreateObject, "DisplayH2", StaticShape, HTwoPanel );
MissionRegObject( Panels, "Switch Lock", 	MissionCreateObject, BluePanel, StaticShape, BluePanel );
MissionRegObject( Panels, "Vigil", 	MissionCreateObject, "DisplayS1", StaticShape, SOnePanel );
MissionRegObject( Panels, "TribesLogo", MissionCreateObject, TribesLogo, StaticShape, TribesLogo );
MissionRegObject( Panels, "Square", 	MissionCreateObject, SquarePanel, StaticShape, SquarePanel );
MissionRegObject( Panels, "Vertical", 	MissionCreateObject, VerticalPanel, StaticShape, VerticalPanel );
MissionRegObject( Panels, "Yellow", 	MissionCreateObject, YellowPanel, StaticShape, YellowPanel );
MissionRegObject( Panels, "Set", 	MissionCreateObject, SetPanel, StaticShape, SetPanel );
MissionRegObject( Panels, "Vertical2", 	MissionCreateObject, "VertPanel2", StaticShape, VerticalPanelB );
MissionRegObject( Panels, "Display1", 	MissionCreateObject, "Display1", StaticShape, DisplayPanelOne );
MissionRegObject( Panels, "Display2", 	MissionCreateObject, "Display2", StaticShape, DisplayPanelTwo );
MissionRegObject( Panels, "Display3", 	MissionCreateObject, "Display3", StaticShape, DisplayPanelThree );
MissionRegObject( Panels, "DisplayH1", 	MissionCreateObject, "DisplayH1", StaticShape, HOnePanel );
MissionRegObject( Panels, "DisplayS2", 	MissionCreateObject, "DisplayS2", StaticShape, STwoPanel );
MissionRegObject( Panels, "DisplayV1", 	MissionCreateObject, "DisplayV1", StaticShape, VOnePanel );
MissionRegObject( Panels, "DisplayV2", 	MissionCreateObject, "DisplayV2", StaticShape, VTwoPanel );
//-------------------------------- Fountains
MissionRegObject( Fountains, "FireBolt", MissionCreateObject, "FireBolt", StaticShape, FireBolt);
MissionRegObject( Fountains, "Elecbolt", MissionCreateObject, "elecbolt", StaticShape, elecbolt);
MissionRegObject( Fountains, "VoltBolt", MissionCreateObject, "VoltBolt", StaticShape, VoltBolt);
MissionRegObject( Fountains, "Torch", MissionCreateObject, "Torch", StaticShape, Torch);

//-------------------------------- Weapons
MissionRegItem( Weapons, "4-in-1 Gun", Hackit, 1);
MissionRegItem( Weapons, "Auto Rocket Pack",SMRPack , 1);
MissionRegItem( Weapons, "Blaster", Blaster, 1);
MissionRegItem( Weapons, "BoomStick", BoomStick, 1);
MissionRegItem( Weapons, "Chaingun", Chaingun, 1);
MissionRegItem( Weapons, "Twin Fuser", DiscLauncher, 1);
MissionRegItem( Weapons, "ELF Gun", EnergyRifle , 1);
MissionRegItem( Weapons, "Flame Thrower", Flamer, 1);
MissionRegItem( Weapons, "Grav Gun", GravGun , 1);
MissionRegItem( Weapons, "Grenade Launcher", GrenadeLauncher, 1);
MissionRegItem( Weapons, "Hyper Blaster", HyperB, 1);
MissionRegItem( Weapons, "SMML", SMML, 1);
MissionRegItem( Weapons, "Laser Rifle", LaserRifle, 1);
MissionRegItem( Weapons, "Magnum", Silencer, 1);
MissionRegItem( Weapons, "Mortar",Mortar , 1);
MissionRegItem( Weapons, "Plasma Gun", PlasmaGun, 1);
MissionRegItem( Weapons, "Railgun", Railgun, 1);
MissionRegItem( Weapons, "RocketLauncher", RocketLauncher , 1);
MissionRegItem( Weapons, "ShockWave Cannon",ConCun , 1);
MissionRegItem( Weapons, "Sniper Rifle", SniperRifle2, 1);
MissionRegItem( Weapons, "Tactical Nuke Launcher", Mfgl, 1);
MissionRegItem( Weapons, "Tranq Gun", TranqGun, 1);
MissionRegItem( Weapons, "Volter", Volter, 1);
MissionRegItem( Weapons, "Vulcan", Vulcan, 1);

//-------------------------------- Ammo
MissionRegItem( Ammo, "Auto Launcher Rockets",AutoRocketAmmo, 5);
MissionRegItem( Ammo, "Bullets", BulletAmmo, 30);
MissionRegItem( Ammo, "Discs", DiscAmmo, 5);
MissionRegItem( Ammo, "Hand Grenades", Grenade, 15);
MissionRegItem( Ammo, "Grenades", GrenadeAmmo, 5);
MissionRegItem( Ammo, "Magnum Ammo",SilencerAmmo, 10);
MissionRegItem( Ammo, "Mines", MineAmmo, 5);
MissionRegItem( Ammo, "Mortar Shells",MortarAmmo, 10);
MissionRegItem( Ammo, "Plasma Bolts", PlasmaAmmo, 10);
MissionRegItem( Ammo, "Rifle Ammo",RifleAmmo, 10);
MissionRegItem( Ammo, "Rocket Ammo",RocketAmmo, 10);
MissionRegItem( Ammo, "Shot Gun Shells",BoomAmmo, 5);
MissionRegItem( Ammo, "Tactical Nuke",MfglAmmo, 1);

//-------------------------------- Packs
MissionRegItem( Packs, "Ammo Pack", AmmoPack, 1);
MissionRegItem( Packs, "CloakingDevice", CloakingDevice, 1);
MissionRegItem( Packs, "Energy Pack", EnergyPack, 1);
MissionRegItem( Packs, "FlightPack", FlightPack, 1);
MissionRegItem( Packs, "Laptop", Laptop, 1);
MissionRegItem( Packs, "LeechPack", LeechPack, 1);
MissionRegItem( Packs, "MotionSensorPack", MotionSensorPack, 1);
MissionRegItem( Packs, "PulseSensorPack", PulseSensorPack, 1);
MissionRegItem( Packs, "Repair Kit", RepairKit, 1);
MissionRegItem( Packs, "Repair Pack", RepairPack, 1);
MissionRegItem( Packs, "Repair Patch", RepairPatch, 1);
MissionRegItem( Packs, "Sensor Jammer Pack", SensorJammerPack, 1);
MissionRegItem( Packs, "Shield Pack", ShieldPack, 1);
MissionRegItem( Packs, "SMRPack", SMRPack, 1);
MissionRegItem( Packs, "StealthShieldPack", StealthShieldPack, 1);
MissionRegItem( Packs, "Nuclear Pack", FgcPack, 1);
MissionRegItem( Packs, "TeleportPack", LightningPack, 1);
MissionRegItem( Packs, "Zepplin", BalloonPack, 1);
//-------------------------------- Comms
MissionRegObject( Comms, "Small Antenna", 	MissionCreateObject, AntennaSmall, StaticShape, SmallAntenna );
MissionRegObject( Comms, "Medium Antenna", 	MissionCreateObject, AntennaMed, StaticShape, MediumAntenna );
MissionRegObject( Comms, "Large Antenna", 	MissionCreateObject, AntennaLarge, StaticShape, LargeAntenna );
MissionRegObject( Comms, "Antenna Array", 	MissionCreateObject, AntennaArray, StaticShape, ArrayAntenna );
MissionRegObject( Comms, "Antenna Rod", 	MissionCreateObject, AntennaRod, StaticShape, RodAntenna );
MissionRegObject( Comms, "Force Beacon", 	MissionCreateObject, Beacon, StaticShape, ForceBeacon );
//-------------------------------- Sensors
MissionRegObject( Sensors, "Remote Pulse Sensor", 		MissionCreateObject, RmtPulse, Sensor, DeployablePulseSensor );
MissionRegObject( Sensors, "Pulse Sensor", 			MissionCreateObject, Sensor, Sensor, PulseSensor );
MissionRegObject( Sensors, "Medium Pulse Sensor", 		MissionCreateObject, MedPulse, Sensor, MediumPulseSensor );
MissionRegObject( Sensors, "Portable Motion Sensor", 		MissionCreateObject, MotionSens, Sensor, DeployableMotionSensor );
MissionRegObject( Sensors, "Satalite Dish (not working)", 	MissionCreateObject, SatBig, StaticShape, SatBig );
MissionRegItem( Sensors, "DeployableSensorJammerPack", DeployableSensorJammerPack, 1);
//-------------------------------- Base
MissionRegObject( Base, "Blast Floor", MissionCreateObject, BlastFloor, StaticShape, BlastFloor);
MissionRegObject( Base, "Blast Wall", MissionCreateObject, BlastWall, StaticShape, BlastWall);
MissionRegObject( Base, "Bridge", MissionCreateObject, Bridge, StaticShape, Bridge);
MissionRegObject( Base, "Cargo Crate", MissionCreateObject, MagCargo, StaticShape, CargoCrate );
MissionRegObject( Base, "EnerPad", 	MissionCreateObject, EnerPad, StaticShape, EnerPad);
MissionRegObject( Base, "Hologram:L", 	MissionCreateObject, Hologram3, StaticShape, Hologram3);
MissionRegObject( Base, "Hologram:M", 	MissionCreateObject, Hologram2, StaticShape, Hologram2);
MissionRegObject( Base, "Hologram:S", 	MissionCreateObject, Hologram1, StaticShape, Hologram1);
MissionRegObject( Base, "Liquid Cylinder", MissionCreateObject, LiquidCyl, StaticShape, CargoBarrel );
MissionRegObject( Base, "PlasmaWall", MissionCreateObject, plasmawall, StaticShape, PlasmaWall );
//-------------------------------- Door Objects
MissionRegObject( Doors, "AngleCut-T",  	MissionCreateObject, DoorOneTop,  Moveable,  DoorOneTop );
MissionRegObject( Doors, "AngleCut-B", 		MissionCreateObject, DoorOneBottom, Moveable,  DoorOneBottom );
MissionRegObject( Doors, "RedSpider-L",  	MissionCreateObject, DoorOneLeft,  Moveable,  DoorOneLeft );
MissionRegObject( Doors, "RedSpider-R", 	MissionCreateObject, DoorOneRight, Moveable,  DoorOneRight );
MissionRegObject( Doors, "GreyStaff-L",  	MissionCreateObject, DoorTwoLeft,  Moveable,  DoorTwoLeft );
MissionRegObject( Doors, "GreyStaff-R", 	MissionCreateObject, DoorTwoRight, Moveable,  DoorTwoRight );
MissionRegObject( Doors, "GoldLogo-L", 		MissionCreateObject, DoorThreeLeft,  Moveable,  DoorThreeLeft );
MissionRegObject( Doors, "GoldLogo-R", 		MissionCreateObject, DoorThreeRight, Moveable,  DoorThreeRight );
MissionRegObject( Doors, "GoldMartini-L",   	MissionCreateObject, DoorFourLeft,Moveable,  DoorFourLeft );
MissionRegObject( Doors, "GoldMartini-R",	MissionCreateObject, DoorFourRight,  Moveable,  DoorFourRight );
MissionRegObject( Doors, "Red&Blue-L", 		MissionCreateObject, DoorSixLeft, Moveable,  DoorSixLeft );
MissionRegObject( Doors, "Red&Blue-R", 		MissionCreateObject, DoorSixRight, Moveable,  DoorSixRight );
MissionRegObject( Doors, "Single", 		MissionCreateObject, DoorFive, Moveable,  DoorFive );
MissionRegObject( Doors, "ForceField", 		MissionCreateObject, DoorForceField, Moveable,  DoorForceField );
MissionRegObject( Doors, "ForceField3x4", 	MissionCreateObject, DoorForceField, Moveable,  DoorForceField3x4 );
MissionRegObject( Doors, "ForceField4x17", 	MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x17 );
MissionRegObject( Doors, "ForceField4x14", 	MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x14 );
MissionRegObject( Doors, "ForceField4x8", 	MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x8 );
MissionRegObject( Doors, "ForceField5x5", 	MissionCreateObject, DoorForceField, Moveable,  DoorForceField5x5 );
MissionRegObject( Doors, "Diagonal", 		MissionCreateObject, DoorDiagonal, Moveable,  DoorDiagonal );
//-------------------------------- Enviro
MissionRegObject( Environment, "Cactus: Drops", 		MissionCreateObject, Cactus1, StaticShape, Cactus1 );
MissionRegObject( Environment, "Cactus: EMP", 		MissionCreateObject, Cactus2, StaticShape, Cactus2 );
MissionRegObject( Environment, "Cactus: Big Hurt", 		MissionCreateObject, Cactus3, StaticShape, Cactus3 );
MissionRegObject( Environment, "Cactus: Deadly", 		MissionCreateObject, Cactus, StaticShape, Cactus );
MissionRegObject( Environment, "Healing Plant", 		MissionCreateObject, PlantTwo, StaticShape, PlantTwo );
MissionRegObject( Environment, "Tree", 		MissionCreateObject, TreeOne, StaticShape, TreeShape );
MissionRegObject( Environment, "Tree: Carniverous", 		MissionCreateObject, TreeTwo, StaticShape, TreeShapeTwo );
MissionRegObject( Environment, "Twig", 		MissionCreateObject, PlantOne, StaticShape, PlantOne );
MissionRegObject( Environment, "*MUD - Grass Vent", 	MissionCreateObject, GrassVent, StaticShape, SteamOnGrass );
MissionRegObject( Environment, "*MUD - Mud Vent", 	MissionCreateObject, MudVent, StaticShape, SteamOnMud );
MissionRegObject( Environment, "*MUD - Grass Vent2", 	MissionCreateObject, GrassVent, StaticShape, SteamOnGrass2 );
MissionRegObject( Environment, "*MUD - Mud Vent2", 	MissionCreateObject, MudVent, StaticShape, SteamOnMud2 );
//-------------------------------- ForceFields
MissionRegObject( ForceFields, "Electric Beam", 	MissionCreateObject, ElectrBeam, StaticShape, ElectricalBeam );
MissionRegObject( ForceFields, "Elec. Beam: Big", 	MissionCreateObject, BigElectroBeam, StaticShape, ElectricalBeamBig );
MissionRegObject( ForceFields, "Elec. Beam: Powered", 	MissionCreateObject, PoweredElectricalBeam, StaticShape, PoweredElectricalBeam );
MissionRegObject( ForceFields, "Forcefield", 		MissionCreateObject, Forcefield, StaticShape, ForceField );
MissionRegObject( ForceFields, "Forcefield 1", 		MissionCreateObject, Forcefield1, StaticShape, ForceField1 );
MissionRegObject( ForceFields, "Forcefield 2", 		MissionCreateObject, Forcefield2, StaticShape, ForceField2 );
MissionRegObject( ForceFields, "Forcefield 3", 		MissionCreateObject, Forcefield3, StaticShape, ForceField3 );
MissionRegObject( ForceFields, "Forcefield 4", 		MissionCreateObject, Forcefield4, StaticShape, ForceField4 );
MissionRegObject( ForceFields, "Forcefield 5", 		MissionCreateObject, Forcefield5, StaticShape, ForceField5 );
MissionRegObject( ForceFields, "Electric Web",  		MissionCreateObject, PlasmaDoorTurr, Turret, PlasmaDoorTurr );
MissionRegObject( ForceFields, "Plasma Wall", 		MissionCreateObject, PlasmaWall, StaticShape, PlasmaWall );
MissionRegObject( ForceFields, "Portable Hole", 		MissionCreateObject, Portal, StaticShape, Portal );
//-------------------------------- Platforms
MissionRegObject( Platforms, "Elev:4x4", 	MissionCreateObject, elevator_4x4,  Moveable, elevator4x4 );
MissionRegObject( Platforms, "Elev:4x5", 	MissionCreateObject, elevator_4x5,  Moveable, elevator4x5 );
MissionRegObject( Platforms, "Elev:5x5", 	MissionCreateObject, elevator_5x5,  Moveable, elevator5x5 );
MissionRegObject( Platforms, "Elev:6x4", 	MissionCreateObject, elevator_6x4, Moveable, elevator6x4 );
MissionRegObject( Platforms, "Elev:6x4_thin", 	MissionCreateObject, elevator_6x4thin, Moveable, elevator6x4thin );
MissionRegObject( Platforms, "Elev:6x5", 	MissionCreateObject, elevator_6x5, Moveable, elevator6x5 );
MissionRegObject( Platforms, "Elev:6x6_thin", 	MissionCreateObject, elevator_6x6thin, Moveable, elevator6x6thin );
MissionRegObject( Platforms, "Elev:6x6", 	MissionCreateObject, elevator_6x6,  Moveable, elevator6x6 );
MissionRegObject( Platforms, "Elev:6x6_Octa", 	MissionCreateObject, elevator_6x6_octagon,  Moveable, elevator6x6Octa );
MissionRegObject( Platforms, "Elev:8x4", 	MissionCreateObject, elevator_8x4,Moveable, elevator8x4 );
MissionRegObject( Platforms, "Elev:8x6", 	MissionCreateObject, elevator_8x6, Moveable, elevator8x6 );
MissionRegObject( Platforms, "Elev:8x8", 	MissionCreateObject, elevator_8x8, Moveable, elevator8x8 );
MissionRegObject( Platforms, "Elev:9x9", 	MissionCreateObject, elevator_9x9, Moveable, elevator9x9 );
MissionRegObject( Platforms, "Elev:16x16_Octa", MissionCreateObject, elevator16x16_octo, Moveable, elevator16x16Octa);

//-------------------------------- DoorMacros
MissionRegObject(DoorMacros, DoubleDoor1, ME::PasteFile, "doubledoor1.cs");
MissionRegObject(DoorMacros, DoubleDoor2, ME::PasteFile, "doubledoor2.cs");
MissionRegObject(DoorMacros, DoubleDoor3, ME::PasteFile, "doubledoor3.cs");
MissionRegObject(DoorMacros, DoubleDoor4, ME::PasteFile, "doubledoor4.cs");
MissionRegObject(DoorMacros, DoubleDoor5, ME::PasteFile, "doubledoor5.cs");
MissionRegObject(DoorMacros, DoubleDoor6, ME::PasteFile, "doubledoor6.cs");
MissionRegObject(DoorMacros, ForceField, ME::PasteFile, "forcefield.cs");
MissionRegObject(DoorMacros, ForceField3x4, ME::PasteFile, "forcefield3x4.cs");
MissionRegObject(DoorMacros, Forcefield4x8, ME::PasteFile, "Forcefield4x8.cs");
MissionRegObject(DoorMacros, Forcefield4x14, ME::PasteFile, "Forcefield4x14.cs");
MissionRegObject(DoorMacros, Forcefield4x17, ME::PasteFile, "Forcefield4x17.cs");
MissionRegObject(DoorMacros, Forcefield5x5, ME::PasteFile, "Forcefield5x5.cs");
MissionRegObject(DoorMacros, SingleDoorRotate, ME::PasteFile, "SingleDoorRotate.cs");
MissionRegObject(DoorMacros, SingleDoorSlide, ME::PasteFile, "SingleDoorSlide.cs");
MissionRegObject(DoorMacros, SingleDoorUp, ME::PasteFile, "SingleDoorUp.cs");
//-------------------------------- Elevators
MissionRegObject(ElevatorMacros, Elevator4x4, ME::PasteFile, "Elevator4x4.cs");
MissionRegObject(ElevatorMacros, Elevator4x5, ME::PasteFile, "Elevator4x5.cs");
MissionRegObject(ElevatorMacros, Elevator5x5, ME::PasteFile, "Elevator5x5.cs");
MissionRegObject(ElevatorMacros, Elevator6x4, ME::PasteFile, "Elevator6x4.cs");
MissionRegObject(ElevatorMacros, Elevator6x4t, ME::PasteFile, "Elevator6x4t.cs");
MissionRegObject(ElevatorMacros, Elevator6x5, ME::PasteFile, "Elevator6x5.cs");
MissionRegObject(ElevatorMacros, Elevator6x6, ME::PasteFile, "Elevator6x6.cs");
MissionRegObject(ElevatorMacros, Elevator6x6octa, ME::PasteFile, "Elevator6x6octa.cs");
MissionRegObject(ElevatorMacros, Elevator6x6t, ME::PasteFile, "Elevator6x6t.cs");
MissionRegObject(ElevatorMacros, Elevator8x4, ME::PasteFile, "Elevator8x4.cs");
MissionRegObject(ElevatorMacros, Elevator8x6, ME::PasteFile, "Elevator8x6.cs");
MissionRegObject(ElevatorMacros, Elevator8x8, ME::PasteFile, "Elevator8x8.cs");
MissionRegObject(ElevatorMacros, Elevator9x9, ME::PasteFile, "Elevator9x9.cs");
MissionRegObject(ElevatorMacros, Elevator16x16, ME::PasteFile, "Elevator16x16.cs");

//==============Custom Volume
MissionRegDis(custom, floatpad);
MissionRegDis(custom, flytower);
MissionRegDis(custom, kiel);
MissionRegDis(custom, sbunker);
MissionRegDis(custom, siam);
MissionRegDis(custom, tblock);
MissionRegDis(custom, watchtower);

exec("registerworld.cs");
exec("registerUserObjects.cs");
