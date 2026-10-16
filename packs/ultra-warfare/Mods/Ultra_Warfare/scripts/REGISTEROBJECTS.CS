// Register objects to be used with the mission editor in this file
// Format is:
//  MissionRegObject MenuCategory bmpIndex Description ConsoleScript
//
//  Default bitmap indecies: 
//     2  -  Base Mission bitmap
//     4  -  Folder bitmap
//     6  -  Herc bitmap
//
//
function MissionRegDis( %MenuGroup, %ItemName )
{
	%DisName = strcat( %ItemName, ".dis" );
	MissionRegObject( %MenuGroup, %ItemName, MissionCreateObject, %ItemName, InteriorShape, %DisName );
}

function MissionRegItem( %MenuGroup, %Desc, %ItemName, %count )
{
	MissionRegObject( %MenuGroup, %Desc, MissionCreateObject, %ItemName, Item, %ItemName, %count, false, true);
}	

//
// Register fear object types for the mission editor
//

MissionRegType( ItemObjectType, 31 );
MissionRegType( PlayerObjectType, 30 );
MissionRegType( TeleportObjectType, 29 );
MissionRegType( CorpseObjectType, 28 );
MissionRegType( StationsObjectType, 27 );
MissionRegType( MoveableObjectType, 25 );

// 
//
//

MissionRegObject( Mission, Group, MissionCreateObject, "Group", SimGroup );
MissionRegObject( Mission, Set, MissionCreateObject, "Set", SimSet );
MissionRegObject( Mission, Path, MissionCreateObject, "Path", SimPath );
MissionRegObject( Mission, Marker, MissionCreateObject, "Marker", Marker, PathMarker );
MissionRegObject( Mission, "Path Marker", MissionCreateObject, "Map Marker", Marker, MapMarker );
MissionRegObject( Mission, "Drop Point", MissionCreateObject, "Drop Point", Marker, DropPointMarker );
MissionRegObject( Mission, Trigger, MissionCreateObject,GroupTrigger, Trigger, GroupTrigger );

//
//
//

MissionRegObject( Sky, Sky, MissionCreateObject, sky, Sky, ".5", ".5", ".5" );
MissionRegObject( Sky, Planet, MissionCreateObject, planet, Planet );
MissionRegObject( Sky, Starfield, MissionCreateObject, stars, StarField );
MissionRegObject( Sky, Snow, MissionCreateObject, snow, Snowfall, 1, 0, 0, 0 );
MissionRegObject( Sky, Rain, MissionCreateObject, rain, Snowfall, 1, 0, 0, 1 );

//
//
//

MissionRegObject( Objectives, "Flag", MissionCreateObject, flag, Item, Flag, 1, false );
MissionRegObject( Objectives, "Flag Stand", MissionCreateObject, Stand, StaticShape, FlagStand );
MissionRegObject( Objectives, "Tower Switch", MissionCreateObject, Switch, StaticShape, TowerSwitch );

//
//
//

MissionRegObject( Stations, "Inventory", MissionCreateObject, InventoryStation, StaticShape, InventoryStation );
MissionRegObject( Stations, "Ammo", MissionCreateObject, AmmoStation, StaticShape, AmmoStation );
MissionRegObject( Stations, "Command", MissionCreateObject, CommandStation, StaticShape, CommandStation );
MissionRegObject( Stations, "Vehicle", MissionCreateObject, VehicleStation, StaticShape, VehicleStation );
MissionRegObject( Stations, "Vehicle Pad", MissionCreateObject, VehiclePad, StaticShape, VehiclePad);

//
//
//

MissionRegObject( Generators, "Generator", MissionCreateObject, Generator, StaticShape, Generator );
MissionRegObject( Generators, "Portable Generator", MissionCreateObject, PortGen, StaticShape, PortGenerator );
MissionRegObject( Generators, "Solar Panel", MissionCreateObject, Solar, StaticShape, SolarPanel );

//
//
//

MissionRegObject( Turrets, "Indoor Turret",  MissionCreateObject, indoorTurret, Turret, indoorTurret );
MissionRegObject( Turrets, "ELF Turret",  MissionCreateObject, ELFTurret, Turret, elfTurret );
MissionRegObject( Turrets, "Sonic Turret",  MissionCreateObject, SonicTurret, Turret, SonicTurret );
MissionRegObject( Turrets, "Missile Turret",  MissionCreateObject, MissileTurret, Turret, MissileTurret );
MissionRegObject( Turrets, "Plasma Turret",  MissionCreateObject, PlasmaTurret, Turret, PlasmaTurret );
MissionRegObject( Turrets, "Laser Turret",  MissionCreateObject, LaserTurret, Turret, LaserTurret );
MissionRegObject( Turrets, "Mortar Turret",  MissionCreateObject, MortarTurret, Turret, MortarTurret );
MissionRegObject( Turrets, "Rocket Turret",  MissionCreateObject, RocketTurret, Turret, RocketTurret );

//
//
//
MissionRegObject( Panels, "Square", MissionCreateObject, SquarePanel, StaticShape, SquarePanel );
MissionRegObject( Panels, "Vertical", MissionCreateObject, VerticalPanel, StaticShape, VerticalPanel );
MissionRegObject( Panels, "Blue", MissionCreateObject, BluePanel, StaticShape, BluePanel );
MissionRegObject( Panels, "Yellow", MissionCreateObject, YellowPanel, StaticShape, YellowPanel );
MissionRegObject( Panels, "Set", MissionCreateObject, SetPanel, StaticShape, SetPanel );
MissionRegObject( Panels, "Vertical2", MissionCreateObject, "VertPanel2", StaticShape, VerticalPanelB );
MissionRegObject( Panels, "Display1", MissionCreateObject, "Display1", StaticShape, DisplayPanelOne );
MissionRegObject( Panels, "Display2", MissionCreateObject, "Display2", StaticShape, DisplayPanelTwo );
MissionRegObject( Panels, "Display3", MissionCreateObject, "Display3", StaticShape, DisplayPanelThree );
MissionRegObject( Panels, "DisplayH1", MissionCreateObject, "DisplayH1", StaticShape, HOnePanel );
MissionRegObject( Panels, "DisplayH2", MissionCreateObject, "DisplayH2", StaticShape, HTwoPanel );
MissionRegObject( Panels, "DisplayS1", MissionCreateObject, "DisplayS1", StaticShape, SOnePanel );
MissionRegObject( Panels, "DisplayS2", MissionCreateObject, "DisplayS2", StaticShape, STwoPanel );
MissionRegObject( Panels, "DisplayV1", MissionCreateObject, "DisplayV1", StaticShape, VOnePanel );
MissionRegObject( Panels, "DisplayV2", MissionCreateObject, "DisplayV2", StaticShape, VTwoPanel );

//
//
//
MissionRegItem( Weapons, "Raptor Rifle", Raptor, 1);
MissionRegItem( Weapons, "IX-Assault Rifle", Assault, 1);
MissionRegItem( Weapons, "IX-Shotgun", Shotgun, 1);
MissionRegItem( Weapons, "IX-Sniper Rifle", SniperRifle, 1);
MissionRegItem( Weapons, "FEB Rifle", FEB, 1);
MissionRegItem( Weapons, "FGL", FGL, 1);
MissionRegItem( Weapons, "RailGun", RailGun, 1);
MissionRegItem( Weapons, "Minigun", Minigun, 1);
MissionRegItem( Weapons, "FarSight", FarSight, 1);
MissionRegItem( Weapons, "Laser Cannon", LaserCan, 1);
MissionRegItem( Weapons, "Trojax", Trojax, 1);
MissionRegItem( Weapons, "Fusion Rifle", Fusion, 1);
MissionRegItem( Weapons, "Plasma Cannon", Plasma, 1);
MissionRegItem( Weapons, "Shockwave Cannon", Shock, 1);
MissionRegItem( Weapons, "Flame Thrower", Flamer, 1);
MissionRegItem( Weapons, "Mine Layer", Miner, 1);
MissionRegItem( Weapons, "Slayer", FBWRocketLauncher, 1);
MissionRegItem( Weapons, "Slayer", Slayer, 1);
MissionRegItem( Weapons, "Laser Rifle", LaserRifle, 1);
MissionRegItem( Weapons, "ShockLance", SoulSucker, 1);
MissionRegItem( Weapons, "ELF Projector", ELFGun, 1);
MissionRegItem( Weapons, "Flame Thrower", Flamer, 1);
MissionRegItem( Weapons, "Missile Launcher", MissileLauncher, 1);
MissionRegItem( Weapons, "Mortar Launcher", MortarLauncher, 1);
MissionRegItem( Weapons, "Grenade Launcher", GrenadeLauncher, 1);
MissionRegItem( Weapons, "Spinfusor", Spinfusor, 1);
MissionRegItem( Weapons, "Chaingun", Chaingun, 1);
MissionRegItem( Weapons, "Blaster", Blaster, 1);
//
//
//
MissionRegItem( Ammo, "Minigun Bullets", MinigunAmmo, 250);
MissionRegItem( Ammo, "Trojax Cell", TrojaxAmmo, 25);
MissionRegItem( Ammo, "Plasma Cell", PlasmaAmmo, 25);
MissionRegItem( Ammo, "Laser Cell", LaserAmmo, 25);
MissionRegItem( Ammo, "Shockwave Cell", ShockAmmo, 5);
MissionRegItem( Ammo, "Disc Ammo", DiscAmmo, 10);
MissionRegItem( Ammo, "Anti-personnel Mines", MineAmmo, 3);
MissionRegItem( Ammo, "Missiles", MissileAmmo, 10);
MissionRegItem( Ammo, "Slayer Rounds", FBWRocketAmmo, 25);
MissionRegItem( Ammo, "Shotgun Shells", IXShotAmmo, 100);
MissionRegItem( Ammo, "Sniper Bullets", IXSniperAmmo, 100);
MissionRegItem( Ammo, "Assault Bullets", IXAssaultAmmo, 100);
MissionRegItem( Ammo, "FEB Bullets", FEBAmmo, 100);
MissionRegItem( Ammo, "Mine Rounds", MinerAmmo, 5);
MissionRegItem( Ammo, "FGL Rounds", FGLAmmo, 15);
MissionRegItem( Ammo, "Raptor Rifle Bullets", RaptorAmmo, 25);
MissionRegItem( Ammo, "Flamer Rounds", FlamerAmmo, 50);
MissionRegItem( Ammo, "Rail Rounds", RailAmmo, 10);
MissionRegItem( Ammo, "FGL Rounds", FGLAmmo, 6);
MissionRegItem( Ammo, "Slayer Rounds", FBWRocketAmmo, 10);
MissionRegItem( Ammo, "Grenade Rounds", GrenadeAmmo, 5);
//
//
//

MissionRegItem( Packs, "Energy Pack", EnergyPack, 1);
MissionRegItem( Packs, "Repair Pack", RepairPack, 1);
MissionRegItem( Packs, "Shield Pack", ShieldPack, 1);
MissionRegItem( Packs, "Stealth Shield Pack", StealthShieldPack, 1);
MissionRegItem( Packs, "Ammo Pack", AmmoPack, 1);
MissionRegItem( Packs, "Cloaking pack", CloakingDevice, 1);
//MissionRegItem( Packs, "Satchel Pack", SatchelPack, 1);
MissionRegItem( Packs, "Minigun Pack", MinigunAmmoPack, 1);
MissionRegItem( Packs, "Fuel Pack", FuelPack, 1);
MissionRegItem( Packs, "Repair Kit (inventory)", RepairKit, 1);
MissionRegItem( Packs, "Repair Patch (instant)", RepairPatch, 1);


//
//
//

MissionRegObject( Comms, "Satellite Dish", MissionCreateObject, SatDish, StaticShape, LargeSatellite );
MissionRegObject( Comms, "Small Antenna", MissionCreateObject, AntennaSmall, StaticShape, SmallAntenna );
MissionRegObject( Comms, "Medium Antenna", MissionCreateObject, AntennaMed, StaticShape, MediumAntenna );
MissionRegObject( Comms, "Large Antenna", MissionCreateObject, AntennaLarge, StaticShape, LargeAntenna );
MissionRegObject( Comms, "Antenna Array", MissionCreateObject, AntennaArray, StaticShape, ArrayAntenna );
MissionRegObject( Comms, "Antenna Rod", MissionCreateObject, AntennaRod, StaticShape, RodAntenna );
MissionRegObject( Comms, "Force Beacon", MissionCreateObject, Beacon, StaticShape, ForceBeacon );

//
//
//

MissionRegObject( Sensors, "Remote Pulse Sensor", MissionCreateObject, RmtPulse, Sensor, DeployablePulseSensor );
MissionRegObject( Sensors, "Pulse Sensor", MissionCreateObject, Sensor, Sensor, PulseSensor );
MissionRegObject( Sensors, "Medium Pulse Sensor", MissionCreateObject, MedPulse, Sensor, MediumPulseSensor );
MissionRegObject( Sensors, "Portable Motion Sensor", MissionCreateObject, MotionSens, Sensor, DeployableMotionSensor );

//
//
//

MissionRegObject( Base, "Air Filter", MissionCreateObject, filter, StaticShape, AirFilter );
MissionRegObject( Base, "Cargo Crate", MissionCreateObject, MagCargo, StaticShape, CargoCrate );
MissionRegObject( Base, "Liquid Cylinder", MissionCreateObject, LiquidCyl, StaticShape, CargoBarrel );
MissionRegObject( Base, "Air Filter", MissionCreateObject, filter, StaticShape, AirFilter );

//
//
//

MissionRegObject( Doors, "AngleCut-T",  MissionCreateObject, DoorOneTop,  Moveable,  DoorOneTop );
MissionRegObject( Doors, "AngleCut-B", MissionCreateObject, DoorOneBottom, Moveable,  DoorOneBottom );
MissionRegObject( Doors, "RedSpider-L",  MissionCreateObject, DoorOneLeft,  Moveable,  DoorOneLeft );
MissionRegObject( Doors, "RedSpider-R", MissionCreateObject, DoorOneRight, Moveable,  DoorOneRight );
MissionRegObject( Doors, "GreyStaff-L",  MissionCreateObject, DoorTwoLeft,  Moveable,  DoorTwoLeft );
MissionRegObject( Doors, "GreyStaff-R", MissionCreateObject, DoorTwoRight, Moveable,  DoorTwoRight );
MissionRegObject( Doors, "GoldLogo-L",  MissionCreateObject, DoorThreeLeft,  Moveable,  DoorThreeLeft );
MissionRegObject( Doors, "GoldLogo-R", MissionCreateObject, DoorThreeRight, Moveable,  DoorThreeRight );
MissionRegObject( Doors, "GoldMartini-L",   MissionCreateObject, DoorFourLeft,Moveable,  DoorFourLeft );
MissionRegObject( Doors, "GoldMartini-R",  MissionCreateObject, DoorFourRight,  Moveable,  DoorFourRight );
MissionRegObject( Doors, "Red&Blue-L", MissionCreateObject, DoorSixLeft, Moveable,  DoorSixLeft );
MissionRegObject( Doors, "Red&Blue-R", MissionCreateObject, DoorSixRight, Moveable,  DoorSixRight );
MissionRegObject( Doors, "Single", MissionCreateObject, DoorFive, Moveable,  DoorFive );
MissionRegObject( Doors, "ForceField", MissionCreateObject, DoorForceField, Moveable,  DoorForceField );
MissionRegObject( Doors, "ForceField3x4", MissionCreateObject, DoorForceField, Moveable,  DoorForceField3x4 );
MissionRegObject( Doors, "ForceField4x17", MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x17 );
MissionRegObject( Doors, "ForceField4x14", MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x14 );
MissionRegObject( Doors, "ForceField4x8", MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x8 );
MissionRegObject( Doors, "ForceField5x5", MissionCreateObject, DoorForceField, Moveable,  DoorForceField5x5 );
MissionRegObject( Doors, "Diagonal", MissionCreateObject, DoorDiagonal, Moveable,  DoorDiagonal );

//
//
//

MissionRegObject( Environment, "Tree 1", MissionCreateObject, TreeOne, StaticShape, TreeShape );
MissionRegObject( Environment, "Tree 2", MissionCreateObject, TreeTwo, StaticShape, TreeShapeTwo );
MissionRegObject( Environment, "Cactus1", MissionCreateObject, Cactus1, StaticShape, Cactus1 );
MissionRegObject( Environment, "Cactus2", MissionCreateObject, Cactus2, StaticShape, Cactus2 );
MissionRegObject( Environment, "Cactus3", MissionCreateObject, Cactus3, StaticShape, Cactus3 );
MissionRegObject( Environment, "Plant 1", MissionCreateObject, PlantOne, StaticShape, PlantOne );
MissionRegObject( Environment, "Plant 2", MissionCreateObject, PlantTwo, StaticShape, PlantTwo );
MissionRegObject( Environment, "Grass Vent", MissionCreateObject, GrassVent, StaticShape, SteamOnGrass );
MissionRegObject( Environment, "Mud Vent", MissionCreateObject, MudVent, StaticShape, SteamOnMud );
MissionRegObject( Environment, "Grass Vent2", MissionCreateObject, GrassVent, StaticShape, SteamOnGrass2 );
MissionRegObject( Environment, "Mud Vent2", MissionCreateObject, MudVent, StaticShape, SteamOnMud2 );

//
//
//

MissionRegObject( Test, "Forcefield", MissionCreateObject, Forcefield, StaticShape, ForceField );
MissionRegObject( Test, "Electric Beam", MissionCreateObject, ElectrBeam, StaticShape, ElectricalBeam );
MissionRegObject( Test, "Bigger Elec. Beam", MissionCreateObject, BigElectroBeam, StaticShape, ElectricalBeamBig );

//
//
//

MissionRegObject( Platforms, "Elev:4x4", MissionCreateObject, elevator_4x4,  Moveable, elevator4x4 );
MissionRegObject( Platforms, "Elev:4x5", MissionCreateObject, elevator_4x5,  Moveable, elevator4x5 );
MissionRegObject( Platforms, "Elev:5x5", MissionCreateObject, elevator_5x5,  Moveable, elevator5x5 );
MissionRegObject( Platforms, "Elev:6x4", MissionCreateObject, elevator_6x4, Moveable, elevator6x4 );
MissionRegObject( Platforms, "Elev:6x4_thin", MissionCreateObject, elevator_6x4thin, Moveable, elevator6x4thin );
MissionRegObject( Platforms, "Elev:6x5", MissionCreateObject, elevator_6x5, Moveable, elevator6x5 );
MissionRegObject( Platforms, "Elev:6x6_thin", MissionCreateObject, elevator_6x6thin, Moveable, elevator6x6thin );
MissionRegObject( Platforms, "Elev:6x6", MissionCreateObject, elevator_6x6,  Moveable, elevator6x6 );
MissionRegObject( Platforms, "Elev:6x6_Octa", MissionCreateObject, elevator_6x6_octagon,  Moveable, elevator6x6Octa );
MissionRegObject( Platforms, "Elev:8x4", MissionCreateObject, elevator_8x4,Moveable, elevator8x4 );
MissionRegObject( Platforms, "Elev:8x6", MissionCreateObject, elevator_8x6, Moveable, elevator8x6 );
MissionRegObject( Platforms, "Elev:8x8", MissionCreateObject, elevator_8x8, Moveable, elevator8x8 );
MissionRegObject( Platforms, "Elev:9x9", MissionCreateObject, elevator_9x9, Moveable, elevator9x9 );
MissionRegObject( Platforms, "Elev:16x16_Octa", MissionCreateObject, elevator16x16_octo, Moveable, elevator16x16Octa);

//
//
//

//MissionRegObject( Vehicle, "Flier", MissionCreateObject, "Flier", "Flier", flier );
//MissionRegObject( Vehicle, "APC", MissionCreateObject, "APC", "Flier", apc );
//MissionRegObject( Vehicle, "Tank", MissionCreateObject, "Tank", "Tank", tank );
//MissionRegObject( Vehicle, "Scout", MissionCreateObject, "Scout", "Tank", scout );
//MissionRegObject( Vehicle, "Car", MissionCreateObject, "AssaultCar", "Car", AssaultCar );

//
//
//

exec("registerworld.cs");
