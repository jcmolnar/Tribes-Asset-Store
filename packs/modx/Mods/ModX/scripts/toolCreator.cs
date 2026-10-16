// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
$AutoUse[Creator] = False;

$ItemMax[larmor, Creator] = 1;
$ItemMax[lfemale, Creator] = 1;

AddToInv(Creator);
AddWeapon(Creator);

//----------------------------------------------------------------------------

LaserData creatorCharge
{
   laserBitmapName   = "repairAdd.bmp";
   //hitName           = "laserhit.dts";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor = { 0.85, 0.25, 0.25 };

   detachFromShooter = false;
   //hitSoundId        = SoundLaserHit;
};

ItemImageData CreatorImage
{
    shapeFile = "repairgun";
    mountPoint = 0;
    mountRotation = { 0, 3.14, 0 };
    mountOffset = { 0, 0, 0 };

    weaponType = 0; // Sustained
    //projectileType = creatorCharge;
    accuFire = true;
    minEnergy = 0;
    maxEnergy = 0;
    reloadTime = 0.4;

    lightType   = 3;  // Weapon Fire
    lightRadius = 1;
    lightTime   = 1;
    lightColor = { 0.85, 0.25, 0.25 };

    sfxFire     = SoundFireTargetingLaser;
    sfxActivate = SoundPickUpWeapon;
};

ItemData Creator
{
    description   = "Object Creator";
    className     = "Tool";
    shapeFile     = "repairgun";
    //hudIcon       = "targetlaser";
    heading = "bTools";
    shadowDetailMask = 4;
    imageType     = CreatorImage;
    price         = 50;
    showWeaponBar = false;
};

$AmtOfDep = 0;

// Categorys -- Current Max of 8 categorys

$Category[0] = "Floors, Doors, and Barriers";
$Category[1] = "Stations, Etc.";
$Category[2] = "Generators";
$Category[3] = "Comms, Sensors, and Etc." ;
$Category[4] = "Turrets";
$Category[5] = "Misc Objects";
$Category[6] = "Interior Objects";
$Category[7] = "Panels";
$Category[8] = "Lights";
$Category[9] = "Lazer-Tag Items";
$Category[10] = "Bots";

for(%i = 0; $Category[%i] != ""; %i++)
    $CategoryTotal[%i] = 0;
%i = 0;

$DeployableTotal = 0;
function AddDepToList(%category, %initName, %Shape, %desc, %DOD, %power, %spec, %offset, %offset2, %angletype)
{
    %num = $AmtOfDep;
    $Deployable[%num] = %initName;
    $DeployableShape[%num] = %Shape;
    $DeployableDesc[%num] = %desc;
    $DeployableDOD[%num] = %DOD;
    $DeployablePower[%num] = %power;
    $DeployableSpecial[%num] = %spec;
    $DeployableAngleType[%num] = %angletype;
    $DeployableOffset[%num] = %offset;
    $DeployableOffset2[%num] = %offset2;
    $DeployableTotal++;
    $AmtOfDep++;

    %catNum = $Category[%category].Total;
    $CategoryIndexes[%category] = $CategoryIndexes[%category] @ " " @  %num;
    $CategoryTotal[%category]++;
}

//
// AddDepToList(CATEGORY, INITNAME, SHAPENAME, MAPNAME, DOD, POWERREQ, TYPE, POSOFFSET, ROTOFFSET, ANGLETYPE)
//
// CATEGORY: Arrays declared above
// INITNAME: Can be whatever, usually just put the name of the SHAPENAME (String)
// SHAPENAME: The name of the ShapeData block (ShapeData)
// MAPNAME: Name shown to players of the object (String)
// DOD: Is the object Destroyed On Disabled (Boolean)
// POWERREQ: How the object uses the power grid (0-2)
//  0 : Ignore \ No Power Required
//  1 : Uses Power
//  2 : Generates Power
// TYPE: What kind of object is this (-2 to 3)
//  -2: Bot
//  -1: Auto-Align Floor
//  0 : StaticShape
//  1 : InteriorShape
//  2 : Sensor
//  3 : Turret
// POSOFFSET: This offset is added to the position of the deploy area, in meters (String, "X Y Z")
// ROTOFFSET: Offset added to the rotation of the deploy area, in radians (String, "X Y Z")
// ANGLETYPE: Type of angle this object uses (RAD/DEG)
//  RAD : Uses Radians
//  DEG : Uses Degrees
//
// The function uses arrays and is a FIFO Buffer. This means that it is in order as
// seen on the list. So all items are added in a linear fashion.
// Consequently, if you change the indexes in the middle you'll mess up alotta people's saves
// so add any items you want in the bottom, but remeber some servers might not have that object
// so the person's save might turn up 'CORRUPT' if they go on a different server.

// Floors, Barriers, Etc.
AddDepToList(0, "Floor4x4Shape", Floor4x4Shape, "4x4 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor4x5Shape", Floor4x5Shape, "4x5 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor5x5Shape", Floor5x5Shape, "5x5 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor6x4Shape", Floor6x4Shape, "6x4 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor6x4ThinShape", Floor6x4ThinShape, "6x4 Floor Thin", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor6x5Shape", Floor6x5Shape, "6x5 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor6x6Shape", Floor6x6Shape, "6x6 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor6x6ThinShape", Floor6x6ThinShape, "6x6 Floor Thin", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor6x6OctoShape", Floor6x6OctoShape, "6x6 Floor Octagon", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor8x4Shape", Floor8x4Shape, "8x4 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor8x6Shape", Floor8x6Shape, "8x6 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor8x8Shape", Floor8x8Shape, "8x8 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor9x9Shape", Floor9x9Shape, "9x9 Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor16x16OctoShape", Floor16x16OctoShape, "16x16 Floor Octagon", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "MetalShield", MetalShield, "Blast Wall", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Forcefield1", ForceField1, "3x4 Forcefield Wall", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Forcefield2", ForceField2, "4x17 Forcefield Wall", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Forcefield3", ForceField3, "4x8 Forcefield Wall", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Forcefield4", ForceField4, "5x5 Forcefield Wall", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Forcefield5", ForceField5, "4x14 Forcefield Wall", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ForceFieldDoor1", ForceFieldDoor1, "3x4 Forcefield Door", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ForceFieldDoor2", ForceFieldDoor2, "4x17 Forcefield Door", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ForceFieldDoor3", ForceFieldDoor3, "4x8 Forcefield Door", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ForceFieldDoor4", ForceFieldDoor4, "5x5 Forcefield Door", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ForceFieldDoor5", ForceFieldDoor5, "4x14 Forcefield Door", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "PlasmaWall", PlasmaWall, "Plasma Floor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXDoor", ModXDoor, "ModX Door", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "RotModXDoor", RotModXDoor, "Rotating ModX Door", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "SlideModXDoor", SlideModXDoor, "Sliding ModX Door", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "Floor6x6ThinShape", Floor6x6ThinShape, "Auto-Align Floor", true, 0, -1, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor4x4", ModXElevatorFloor4x4, "4x4 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor4x5", ModXElevatorFloor4x5, "4x5 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor5x5", ModXElevatorFloor5x5, "5x5 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor6x4", ModXElevatorFloor6x4, "6x4 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor6x4Thin", ModXElevatorFloor6x4Thin, "6x4 Elevator Thin", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor6x5", ModXElevatorFloor6x5, "6x5 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor6x6", ModXElevatorFloor6x6, "6x6 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor6x6Thin", ModXElevatorFloor6x6Thin, "6x6 Elevator Thin", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor6x6Octo", ModXElevatorFloor6x6Octo, "6x6 Elevator Octagon", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor8x4", ModXElevatorFloor8x4, "8x4 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor8x6", ModXElevatorFloor8x6, "8x6 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor8x8", ModXElevatorFloor8x8, "8x8 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor9x9", ModXElevatorFloor9x9, "9x9 Elevator", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "ModXElevatorFloor16x16Octo", ModXElevatorFloor16x16Octo, "16x16 Elevator Octagon", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(0, "WaterWall", WaterWall, "Water", true, 0, -1, "0 0 0", "3.14 0 0", Rad);

// Stations, Etc.
AddDepToList(1, "MobileInvent", MobileInvent, "Inventory Station", true, 1, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(1, "PortaA", PortaA, "Ammo Station", true, 1, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(1, "PortaC", PortaC, "Command Station", true, 1, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(1, "RPStation", RPStation, "Role-Playing Station", true, 1, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(1, "VehicleStation", VehicleStation, "Vehicle Station", true, 1, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(1, "VehiclePad", VehiclePad, "Vehicle Pad", true, 1, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(1, "telePadSml", telePadSml, "Teleport Pad", true, 1, 0, "0 0 -0.05", "0 0 0", Rad);
AddDepToList(1, "telePad", telePad, "Teleport Pad Mk.II", true, 1, 0, "0 0 -0.2", "0 0 -1.57", Rad);
AddDepToList(1, "boostPad", boostPad, "Boost Pad", true, 0, 0, "0 0 -0.05", "0 0 0", Rad);
AddDepToList(1, "uberBoostPad", uberBoostPad, "Uber-Boost Pad", true, 0, 0, "0 0 -0.05", "0 0 0", Rad);
AddDepToList(1, "blowPad", blowPad, "Blow Pad", true, 0, 0, "0 0 -0.05", "0 0 0", Rad);
AddDepToList(1, "uberBlowPad", uberBlowPad, "Uber Blow Pad", true, 0, 0, "0 0 -0.05", "0 0 0", Rad);
AddDepToList(1, "advPad", advPad, "Advanced Pad", true, 0, 0, "0 0 0", "0 0 0", Rad);

// Generators
AddDepToList(2, "MobileGen", MobileGen, "Portable Generator", true, 2, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(2, "BigMobileGen", BigMobileGen, "Generator", true, 2, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(2, "PortaSolar", PortaSolar, "Solar Panel", true, 2, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(2, "PortaSolarBig", PortaSolarBig, "Big Solar Panel", true, 2, 0, "0 0 0", "0 0 0", Rad);

// Antennas, Sensors, Etc.
AddDepToList(3, "SmlAnt", SmallAntenna, "Small Antenna", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "MedAnt", LargeAntenna, "Medium Antenna", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "LgrAnt", MediumAntenna, "Large Antenna", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "ArrayAntenna", ArrayAntenna, "Array Antenna", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "RodAntenna", RodAntenna, "Rod Antenna", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "SatBig", SatBig, "SatBig", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "PulseSensor", PulseSensor, "Pulse Sensor", true, 1, 2, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "MediumPulseSensor", MediumPulseSensor, "Medium Pulse Sensor", true, 1, 2, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "smallSensorRed", smallSensorRed, "Small Red Sensor", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(3, "smallSensorYellow", smallSensorYellow, "Small Yellow Sensor", true, 0, 0, "0 0 0", "0 0 0", Rad);

// Turrets
AddDepToList(4, "CameraTurret", CameraTurret, "Camera", true, 0, 3, "0 0 0", "0 0 0", Rad);
AddDepToList(4, "PlasmaTurret", PlasmaTurret, "Plasma Turret", true, 1, 3, "0 0 0", "0 0 0", Rad);
AddDepToList(4, "ELFTurret", ELFTurret, "ELF Turret", true, 1, 3, "0 0 0", "0 0 0", Rad);
AddDepToList(4, "RocketTurret", RocketTurret, "Rocket Turret", true, 1, 3, "0 0 0", "0 0 0", Rad);
AddDepToList(4, "MortarTurret", MortarTurret, "Mortar Turret", true, 1, 3, "0 0 0", "0 0 0", Rad);
AddDepToList(4, "IndoorTurret", IndoorTurret, "Indoor Turret", true, 1, 3, "0 0 0", "0 0 0", Rad);
AddDepToList(4, "DeployableTurret", DeployableTurret, "Turret", true, 1, 3, "0 0 0", "0 0 0", Rad);
AddDepToList(4, "DeployableLaserCannon", DeployableLaserCannon, "Laser Turret", true, 1, 3, "0 0 0", "0 0 0", Rad);

//Misc
AddDepToList(5, "ElectricalBeam", ElectricalBeam, "Electrical Beam", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "ElectricalBeamBig", ElectricalBeamBig, "Electrical Beam Big", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "CargoCrate", CargoCrate, "Cargo Crate", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "dummyl", dummyl, "Light Dummy", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "dummym", dummym, "Medium Dummy", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "dummyh", dummyh, "Heavy Dummy", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "dummylf", dummylf, "Light Female Dummy", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "dummymf", dummymf, "Medium Female Dummy", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Cube1", Cube1, "Cube One", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Cube2", Cube2, "Cube Two", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Cube3", Cube3, "Cube Three", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Pyrm1", Pyrm1, "Pyramid One", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Pyrm2", Pyrm2, "Pyramid Two", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Pyrm3", Pyrm3, "Pyramid Three", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "TreeShape", TreeShape, "Tree One", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "TreeShape", TreeShape, "Tree Two", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Cactus1", Cactus1, "Cactus One", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Cactus2", Cactus2, "Cactus Two", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "Cactus3", Cactus3, "Cactus Three", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "PlantTwo", PlantTwo, "Plant", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "mrtwig", mrtwig, "Twiggy", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "arrow5_r", arrow5_r, "Red Arrow", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "endarrow", endarrow, "Red Arrow 2", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "arrow5_g", arrow5_g, "Green Arrow", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "arrow5_b", arrow5_b, "Blue Arrow", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "arrow5_y", arrow5_y, "Yellow Arrow", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "ammo1", ammo1, "Large Ammo Box", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "ammo2", ammo2, "Small Ammo Box", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "ammopack_dep", ammopack_dep, "Ammo Pack", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "ammounit_remote", ammounit_remote, "Remote Ammo Unit", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "bridge_dep", bridge_dep, "Large Beacon", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "bullet", bullet, "Bullet", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "chaingun_dep", chaingun_dep, "Chaingun", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "dirarrows", dirarrows, "Path Marker", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "disc", disc, "Disc Launcher", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "discammo_dep", discammo_dep, "Disc Ammo", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "discb", discb, "Disc", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "energygun", energygun, "Blaster", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "flag", flag, "Flag", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "flagstand_dep", flagstand_dep, "Flag Stand", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "grenade_dep", grenade_dep, "Grenade", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "grenadel", grenadel, "Grenade Launcher", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "grenammo", grenammo, "Grenade Ammo", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "invent_remote", invent_remote, "Remote Inventory", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "jetpack", jetpack, "Energy Pack", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "liqcyl", liqcyl, "Gas Tank", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "logo", logo, "Tribes Logo", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "mine", mine, "Mine", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "mineammo_dep", mineammo_dep, "Mine Ammo", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "mortargun", mortargun, "Mortar Gun", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "mortar_dep", mortar_dep, "Mortar Projectile", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "mortarammo_dep", mortarammo_dep, "Mortar Ammo", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "mortarpack", mortarpack, "Mortar Pack", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "paint", paint, "Targeting Laser Projectile", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "paintgun", paintgun, "Targeting Laser", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "plasammo", plasammo, "Plasma Ammo", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "plasma", plasma, "Plasma Gun", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "plasmabolt_dep", plasmabolt_dep, "Plasma Gun Projectile", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "remoteturret", remoteturret, "Remote Turret", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "repairgun_dep", repairgun_dep, "Repair Gun", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "rocket", rocket, "Rocket Projectile", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "sensorjampack", sensorjampack, "Sensor Jammer Pack", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "shotgun", shotgun, "ELF Gun", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "shotgunbolt", shotgunbolt, "ELF Gun Projectile", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "sniper", sniper, "Lazer Rifle", true, 0, 0, "0 0 0", "0 0 0", Rad);
AddDepToList(5, "tracer", tracer, "Tracer Projectile", true, 0, 0, "0 0 0", "0 0 0", Rad);

exec("InteriorObjs.cs");
for(%h = 0; (%name = $InteriorDeployList[%h]) != ""; %h++)
{
    if(%name != "--")
        //AddDepToList(6, %name @ ".dis", %name @ ".dis", $InteriorDeployNamesList[%h], false, 0, 1, "0 0 0", "0 0 0", Rad);
        AddDepToList(6, %name @ ".dis", %name @ ".dis", %name, false, 0, 1, "0 0 0", "0 0 0", Rad);
}

//Panels
AddDepToList(7, "SquarePanel", SquarePanel, "Square Panel", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "SOnePanel", SOnePanel, "Square Panel 2", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "STwoPanel", STwoPanel, "Square Panel 3", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "VerticalPanel", VerticalPanel, "Vertical Panel", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "VerticalPanelB", VerticalPanelB, "Vertical Panel 2", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "VOnePanel", VOnePanel, "Vertical Panel 3", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "HOnePanel", HOnePanel, "Horizontal Panel", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "HTwoPanel", HTwoPanel, "Horizontal Panel 2", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "BluePanel", BluePanel, "Blue Panel", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "YellowPanel", YellowPanel, "Yellow Panel", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "SetPanel", SetPanel, "Set Panel", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "DisplayPanelTwo", DisplayPanelTwo, "Display Panel", true, 0, 0, "0 0 0", "1.57 0 3.14", Rad);
AddDepToList(7, "DisplayPanelThree", DisplayPanelThree, "Display Panel Two", true, 0, 0, "0 0 0", "1.57 0 0", Rad);

//Lights
AddDepToList(8, "FloodLight", FloodLight, "Flood Light White", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Red", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Green", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Blue", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Purple", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Orange", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Yellow", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light White AutoRot", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Red AutoRot", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Green AutoRot", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Blue AutoRot", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Purple AutoRot", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Orange AutoRot", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);
AddDepToList(8, "FloodLight", FloodLight, "Flood Light Yellow AutoRot", true, 1, 0, "0 0 0.05", "-1.57 0 0", Rad);

//LT-Items
AddDepToList(9, "LTSafeBeacon", LTSafeBeacon, "Lazer-Tag Safe Beacon", true, 1, 0, "0 0 0", "0 0 0", Rad);

//Bots
AddDepToList(10, "VageBot", larmor, "Vage Bot -- Light", true, 0, -2, "0 0 0", "0 0 0", Rad);
AddDepToList(10, "VageBot", marmor, "Vage Bot -- Medium", true, 0, -2, "0 0 0", "0 0 0", Rad);
AddDepToList(10, "VageBot", harmor, "Vage Bot -- Heavy", true, 0, -2, "0 0 0", "0 0 0", Rad);

function AddPosDeployOffset(%pos1, %clientId, %objrot)
{
    %extraXPos = %clientId.XPosOffset;
    %extraYPos = %clientId.YPosOffset;
    %extraZPos = %clientId.ZPosOffset;

    %plrot = GameBase::getRotation(Client::getOwnedObject(%clientId));

    %oldpos = %pos1;
    %oldrot = %objrot;
    %newpos = rotatevector("0 "@%extraXPos@" 0",vector::add(%plrot,"0 0 0"));
    %newposOne = %newpos;
    
    %oldpos = %pos1;
    %oldrot = %objrot;
    %newpos = rotatevector(%extraYPos@" 0 0",vector::add(%plrot,"0 0 0"));
    %newposTwo = %newpos;
    
    %newpos = Vector::add(Vector::add(%newposOne, %newposTwo), "0 0 " @ %extraZPos);

    %posfinal = Vector::add(%newpos, %pos1);
    return %posfinal;
}

function AddDeployOffset(%rot1, %clientId)
{
    %extraXRot = Math::deg2rad(%clientId.XRotOffset);
    %extraYRot = Math::deg2rad(%clientId.YRotOffset);
    %extraZRot = Math::deg2rad(%clientId.ZRotOffset);

    %rot1X = getWord(%rot1, 0);
    %rot1Y = getWord(%rot1, 1);
    %rot1Z = getWord(%rot1, 2);

    %rot1XFinal = %extraXRot + %rot1X;
    %rot1YFinal = %extraYRot + %rot1Y;
    %rot1ZFinal = %extraZRot + %rot1Z;

    %rotfinal = %rot1XFinal @ " " @ %rot1YFinal @ " " @ %rot1ZFinal;

    return %rotfinal;
}

function AddDeployOffsetDeg(%rot1, %clientId)
{
    %extraXRot = %clientId.XRotOffset;
    %extraYRot = %clientId.YRotOffset;
    %extraZRot = %clientId.ZRotOffset;

    %rot1X = getWord(%rot1, 0);
    %rot1Y = getWord(%rot1, 1);
    %rot1Z = getWord(%rot1, 2);

    %rot1XFinal = %extraXRot + %rot1X;
    %rot1YFinal = %extraYRot + %rot1Y;
    %rot1ZFinal = %extraZRot + %rot1Z;

    %rotfinal = %rot1XFinal @ " " @ %rot1YFinal @ " " @ %rot1ZFinal;

    return %rotfinal;
}

function CreatorImage::onFire(%player)
{
    %clientId = Player::getClient(%player);

   if($DeployFloodProtect && %clientId.isSuperAdmin != true)
   {
      %time = getIntegerTime(true) >> 5;
      if(%clientId.floodDeployStop)
      {
         %delta = %clientId.depFloodDoneTime - %time;
         if(%delta > 0)
         {
            Client::sendMessage(%clientId, $MSGTypeGame, "DEPLOY FLOOD! You cannot deploy for " @ %delta @ " seconds.");
            return;
         }
         %clientId.floodDeployStop = "";
         %clientId.depFloodDoneTime = "";
      }
      %clientId.depFloodMessageCount++;

      schedule(%clientId @ ".depFloodMessageCount--;", 5, %clientId);
      if(%clientId.depFloodMessageCount > $DeployFloodProtectFrequency)
      {
         %clientId.floodDeployStop = true;
         %clientId.depFloodDoneTime = %time + $DeployFloodProtectTime;
         Client::sendMessage(%clientId, $MSGTypeGame, "DEPLOY FLOOD! You cannot deploy for " @ $DeployFloodProtectTime @ " seconds.");
         return;
      }
   }

    if(%clientId.CannotDeploy == true)
    {
        Client::sendMessage(%clientId,1,"Your tool-usage priviliges have been disabled.~waccess_denied.wav");
        return;
    }
    
    %set = newObject("set",SimSet);
    %radius = 15;
    %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, GameBase::getPosition(%this), %radius, %radius, %radius, 0);
    for(%i = %numItems - 1 ; %i>=0; %i--)
    {
        %obj = Group::getObject(%set, %i);
        if(%obj.DontBuildAroundMe == true)
            return;
    }
    
    %trans = GameBase::getMuzzleTransform(%player);
    %vel = Item::getVelocity(%player);
    Projectile::spawnProjectile("creatorCharge",%trans,%player,%vel);

    %item = $Deployable[%clientId.CurDeploy];
    %itemShape = $DeployableShape[%clientId.CurDeploy];
    %itemDesc = $DeployableDesc[%clientId.CurDeploy];
    %itemDOD = $DeployableDOD[%clientId.CurDeploy];
    %itemSpec = $DeployableSpecial[%clientId.CurDeploy];
    %itemOffset = $DeployableOffset[%clientId.CurDeploy];
    %itemOffset2 = $DeployableOffset2[%clientId.CurDeploy];
    %itemAngleType = $DeployableAngleType[%clientId.CurDeploy];

    if(!GameBase::getLOSInfo(%player,$DeployGunRange))
	{
		Client::sendMessage(%clientId,0,"Deploy position out of range");
		return false;
    }
	%rot = GameBase::getRotation(%player); //floor

    if (%clientId.moldsurface == true)
    {
        %prot = GameBase::getRotation(%player);
        %zRot = getWord(%prot,2);

        if (Vector::dot($los::normal,"0 0 1") > 0.6)
        {
    		%rot = "0 0 " @ %zRot;
        }
        else
        {
    		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
            {
    		   %rot = $Math::PI @ " 0 " @ %zRot;
    		}
    		else
            {
               %rot = Vector::getRotation($los::normal);
            }
        }
    }

    %rot = AddDeployOffset(%rot, %clientId);
    if (%itemAngleType == "Deg")
        %rot = AddDeployOffsetDeg(%rot, %clientId);

    %rot = vector::add(%rot, %itemOffset2);

    Client::sendMessage(%clientId,0,"Deployed " @ %itemDesc);

    if (%itemSpec == 3)
    {
        %obj = newObject(%item,"Turret",%itemShape,%itemDOD);
        addToSet("MissionCleanup",%obj);
        GameBase::startFadeIn(%obj);
        %team = GameBase::getTeam(%player);
    	GameBase::setTeam(%obj,%team);
        %postodeployin = vector::add(AddPosDeployOffset($los::position, %clientId, %rot), %itemOffset);
    	GameBase::setPosition(%obj,%postodeployin);
        playSound(SoundCreateItem,%postodeployin);
    	GameBase::setRotation(%obj,%rot);
    	Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        %power = $DeployablePower[%clientId.CurDeploy];
        %pRange = $DeployablePowerRange;
        AddClObj(%obj, %clientId, %itemDesc);

        GameBase::setRechargeRate (%obj, 10);

        if(%power==1)	// Item Requires Power
    	{
            Client::sendMessage(%clientId,1,"Attempting Power Grid Connection");
            %obj.ispowerReq = true;
            schedule("PowerItem("@%obj@","@%pRange@","@%clientId@");",2,%obj);
        }
    	else
        {
        	GameBase::SetActive(%obj,true);
            %obj.ispowerReq = false;
        }
    }

    if (%itemSpec == 2)
    {
        %obj = newObject(%item,"Sensor",%itemShape,%itemDOD);
        addToSet("MissionCleanup",%obj);
        GameBase::startFadeIn(%obj);
        %team = GameBase::getTeam(%player);
    	GameBase::setTeam(%obj,%team);
        %postodeployin = vector::add(AddPosDeployOffset($los::position, %clientId, %rot), %itemOffset);
    	GameBase::setPosition(%obj,%postodeployin);
        playSound(SoundCreateItem,%postodeployin);
    	GameBase::setRotation(%obj,%rot);
    	Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        %power = $DeployablePower[%clientId.CurDeploy];
        %pRange = $DeployablePowerRange;
        AddClObj(%obj, %clientId, %itemDesc);

        if(%power==1)	// Item Requires Power
    	{
            Client::sendMessage(%clientId,1,"Attempting Power Grid Connection");
            %obj.ispowerReq = true;
    		schedule("PowerItem("@%obj@","@%pRange@","@%clientId@");",2,%obj);
        }
    	else
        {
        	GameBase::SetActive(%obj,true);
            %obj.ispowerReq = false;
        }
    }

    if (%itemSpec == 1)
    {
        %postodeployin = vector::add(AddPosDeployOffset($los::position, %clientId, %rot), %itemOffset);

        %obj = newObject(%item,InteriorShape,%itemShape,%itemDOD);
        %team = GameBase::getTeam(%player);
        addToSet("MissionCleanup", %obj);
        GameBase::setTeam(%obj,%team);
        GameBase::setRotation(%obj,%rot);
    	GameBase::setPosition(%obj,%postodeployin);
        Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        playSound(SoundCreateItem,%postodeployin);
        AddClObj(%obj, %clientId, %itemDesc);
        %obj.ispowerReq = false;
    }

    if (%itemSpec == 0)
    {
        %obj = newObject(%item,"StaticShape",%itemShape,%itemDOD);
        addToSet("MissionCleanup",%obj);
        GameBase::startFadeIn(%obj);
        %team = GameBase::getTeam(%player);
    	GameBase::setTeam(%obj,%team);
        %postodeployin = vector::add(AddPosDeployOffset($los::position, %clientId, %rot), %itemOffset);

        GameBase::setPosition(%obj,%postodeployin);
        playSound(SoundCreateItem,%postodeployin);
        GameBase::setRotation(%obj,%rot);

    	Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        %power = $DeployablePower[%clientId.CurDeploy];
        %pRange = $DeployablePowerRange;
        AddClObj(%obj, %clientId, %itemDesc);

        if(%power==1)	// Item Requires Power
        {
            Client::sendMessage(%clientId,1,"Attempting Power Grid Connection");
    		schedule("PowerItem("@%obj@","@%pRange@","@%clientId@");",2,%obj);
            %obj.ispowerReq = true;
        }
    	else if(%power==2)	// Item generates Power
    	{
    		GameBase::SetActive(%obj,true);
    		Client::sendMessage(%clientId,1,"Attempting Power Grid Connection");
    		schedule("ConnectGenerator("@%obj@","@%clientId@");",2,%obj);
            %obj.ispowerReq = false;
    	}
    	else
        {
            %obj.ispowerReq = false;
        }
    }
    
    if (%itemSpec == -1)
    {
        %obj = newObject(%item,"StaticShape",%itemShape,%itemDOD);
        addToSet("MissionCleanup",%obj);
        GameBase::startFadeIn(%obj);
        %team = GameBase::getTeam(%player);
    	GameBase::setTeam(%obj,%team);
        %postodeployin = vector::add(AddPosDeployOffset($los::position, %clientId, %rot), %itemOffset);

        if(GameBase::getLOSInfo(%player, 50))
        {
           %foundobj = $los::object;

           %deployPos = $los::position;
           %DeployRot = %rot;

           %radius = GameBase::getRadius(%obj) + (GameBase::getRadius(%obj) / 2.72);

           if(GameBase::getDataName(%foundobj) == %itemShape)
           {
              %PlatPos = GameBase::getPosition(%foundobj);
              %PlatRot = GameBase::getRotation(%foundobj);

              for(%f = 0; %f < 6; %f += 1.575) //(1.575 * 4) > 6   ... You know ...
              {
                 %markerpos = vector::add(%PlatPos,rotatevector(%radius / 2.72 @ " 0 0.5",vector::add(%PlatRot,"0 0 "@%f )));

                 if(Vector::getdistance(%markerpos,%deployPos) < 0.5)
                 {
                    %postodeployin = vector::add(rotatevector(%radius @ " 0 0",vector::add(%PlatRot,"0 0 "@%f )),%PlatPos);
                    %rot = %PlatRot;
                 }

              }
           }
        }
        GameBase::setPosition(%obj,%postodeployin);
        GameBase::setRotation(%obj,%rot);
        playSound(SoundCreateItem,%postodeployin);
    	Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        AddClObj(%obj, %clientId, %itemDesc);
    }
    
    if(%itemSpec == -2)
    {
        //if($DummyNumber[%clientId] == "")
        //    $DummyNumber[%clientId] = 0;
        //$DummyNumber[%clientId] = (Math::randomInt(Math::randomInt(Math::randomInt(Math::randomInt(2097120) * 2) * 10)) - Math::randomInt(1048560)); //EXTREME Randomness! ;)
        $DummyNumber[%clientId] = 0;
        //if(%clientId.isSuperAdmin == true)
        //    $DummyNumber[%clientId] = (Math::randomInt(Math::randomInt(Math::randomInt(Math::randomInt(2097120) * 2) * 10)) - Math::randomInt(1048560)); //EXTREME Randomness! ;)
        %spawnPos = %postodeployin = vector::add(AddPosDeployOffset($los::position, %clientId, %rot), %itemOffset);
        %spawnRot = "0 0 " @ getWord(%rot, 2);

        %aiName = %item @ %clientId @ $DummyNumber[%clientId];
        %name = %itemDesc;// @ " #" @ $DummyNumber[%clientId];
        %armorType = %itemShape;
        //createAI( %aiName, %markerGroup, %armorType, %name );
        %bool = AI::spawn( %aiName, %armorType, %spawnPos, %spawnRot, %name, "male2" );

        if(%bool == false)
            return;

        %DummyID = Client::getOwnedObject(AI::getID(%aiName));
        AddClObj(%DummyID, %clientId, %name);
        AI::setWeapons(%aiName);
        %DummyID.isBot = true;
        //GameBase::setTeam(%DummyID, GameBase::getTeam(%player));
        //Gamebase::setMapName(%DummyID, Client::getName(%clientId) @ "'s " @ %itemDesc);
        //AI::moveTo(%aiName, "0 0 0");
        //Item::setVelocity($DummyID, "-60 0 65");
        //%Dlevel = GameBase::getDamageLevel($dummyID);
    }
    
    %obj.DepIndex = %clientId.CurDeploy;
    %dataName = GameBase::getDataName(%obj);
    if(Account::IsAutoWeld(%clientId) == true)
        %obj.weld = true;
    else
        %obj.weld = false;

    if(GameBase::getDataName(%obj).className == "Light")
    {
        Light::Activate(%obj, $LightObjectColor[$DeployableDesc[%obj.depIndex]]);
        %obj.LightZROT = $LightObjectZROT[$DeployableDesc[%obj.depIndex]];
    }
                
    Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
    CheckDeployLimit();
}

function DeployClObj(%clientId, %depIndex, %pos, %rot, %weld)
{
    %player = Client::getOwnedObject(%clientId);

    %item = $Deployable[%depIndex];
    %itemShape = $DeployableShape[%depIndex];
    %itemDesc = $DeployableDesc[%depIndex];
    %itemDOD = $DeployableDOD[%depIndex];
    %itemSpec = $DeployableSpecial[%depIndex];

    if(%itemShape == "")
        return;
    if(%itemDOD == "")
        %itemDOD = true;
    if(%itemSpec == "")
        return;
    %postodeployin = %pos;

    if (%itemSpec == 3)
    {
        %obj = newObject(%item,"Turret",%itemShape,%itemDOD);
        if(%obj == 0)
            return;
        addToSet("MissionCleanup",%obj);
        GameBase::startFadeIn(%obj);
        %team = GameBase::getTeam(%player);
    	GameBase::setTeam(%obj,%team);
    	GameBase::setPosition(%obj,%postodeployin);
        playSound(SoundCreateItem,%postodeployin);
    	GameBase::setRotation(%obj,%rot);
    	Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        %power = $DeployablePower[%depIndex];
        %pRange = $DeployablePowerRange;
        AddClObj(%obj, %clientId, %itemDesc);

        GameBase::setRechargeRate(%obj, 10);

        if(%power==1)	// Item Requires Power
    	{
            %obj.ispowerReq = true;
            schedule("PowerItemSilent("@%obj@","@%pRange@","@%clientId@");",2,%obj);
        }
    	else
        {
        	GameBase::SetActive(%obj,true);
            %obj.ispowerReq = false;
        }
    }

    if (%itemSpec == 2)
    {
        %obj = newObject(%item,"Sensor",%itemShape,%itemDOD);
        if(%obj == 0)
            return;
        addToSet("MissionCleanup",%obj);
        GameBase::startFadeIn(%obj);
        %team = GameBase::getTeam(%player);
    	GameBase::setTeam(%obj,%team);
        GameBase::setPosition(%obj,%postodeployin);
        playSound(SoundCreateItem,%postodeployin);
    	GameBase::setRotation(%obj,%rot);
    	Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        %power = $DeployablePower[%depIndex];
        %pRange = $DeployablePowerRange;
        AddClObj(%obj, %clientId, %itemDesc);

        if(%power==1)	// Item Requires Power
    	{
            %obj.ispowerReq = true;
    		schedule("PowerItemSilent("@%obj@","@%pRange@","@%clientId@");",2,%obj);
        }
    	else
        {
        	GameBase::SetActive(%obj,true);
            %obj.ispowerReq = false;
        }
    }

    if (%itemSpec == 1)
    {
        %obj = newObject(%item,InteriorShape,%itemShape,%itemDOD);
        if(%obj == 0)
            return;
        %team = GameBase::getTeam(%player);
        addToSet("MissionCleanup", %obj);
        GameBase::setTeam(%obj,%team);
        GameBase::setRotation(%obj,%rot);
    	GameBase::setPosition(%obj,%postodeployin);
        Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        playSound(SoundCreateItem,%postodeployin);
        AddClObj(%obj, %clientId, %itemDesc);
        %obj.ispowerReq = false;
    }

    if (%itemSpec == 0 || %itemSpec == -1)
    {
        %obj = newObject(%item,"StaticShape",%itemShape,%itemDOD);
        if(%obj == 0)
            return;
        addToSet("MissionCleanup",%obj);
        GameBase::startFadeIn(%obj);
        %team = GameBase::getTeam(%player);
    	GameBase::setTeam(%obj,%team);
        GameBase::setPosition(%obj,%postodeployin);
        playSound(SoundCreateItem,%postodeployin);
    	GameBase::setRotation(%obj,%rot);
    	Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
        %power = $DeployablePower[%depIndex];
        %pRange = $DeployablePowerRange;
        AddClObj(%obj, %clientId, %itemDesc);

        if(%power==1)	// Item Requires Power
        {
    		schedule("PowerItemSilent("@%obj@","@%pRange@","@%clientId@");",2,%obj);
            %obj.ispowerReq = true;
        }
    	else if(%power==2)	// Item generates Power
    	{
    		GameBase::SetActive(%obj,true);
    		schedule("ConnectGeneratorSilent("@%obj@","@%clientId@");",2,%obj);
            %obj.ispowerReq = false;
    	}
    	else
        {
            %obj.ispowerReq = false;
        }
    }
    
    if(%itemSpec == -2)
    {
        //if($DummyNumber[%clientId] == "")
        //    $DummyNumber[%clientId] = 0;
        //$DummyNumber[%clientId] = (Math::randomInt(Math::randomInt(Math::randomInt(Math::randomInt(2097120) * 2) * 10)) - Math::randomInt(1048560)); //EXTREME Randomness! ;)
        $DummyNumber[%clientId] = 0;
        %spawnPos = %postodeployin = vector::add(AddPosDeployOffset($los::position, %clientId, %rot), %itemOffset);
        %spawnRot = "0 0 " @ getWord(%rot, 2);

        %aiName = %item @ %clientId @ $DummyNumber[%clientId];
        %name = %itemDesc;
        %armorType = %itemShape;
        //createAI( %aiName, %markerGroup, %armorType, %name );
        %bool = AI::spawn( %aiName, %armorType, %spawnPos, %spawnRot, %name, "male2" );

        if(%bool == false)
            return;

        %DummyID = Client::getOwnedObject(AI::getID(%aiName));
        AddClObj(%DummyID, %clientId, %name);
        AI::setWeapons(%aiName);
        %DummyID.isBot = true;
        %DummyID.AIname = %aiName;
        //GameBase::setTeam(%DummyID, GameBase::getTeam(%player));
        //Gamebase::setMapName(%DummyID, Client::getName(%clientId) @ "'s " @ %itemDesc);
        //AI::moveTo(%aiName, "0 0 0");
        //Item::setVelocity($DummyID, "-60 0 65");
        //%Dlevel = GameBase::getDamageLevel($dummyID);
    }
    
    %obj.DepIndex = %depIndex;

    if(%weld == true)
        %obj.weld = true;
    else
        %obj.weld = false;
    
    if(GameBase::getDataName(%obj).className == "Light")
    {
        Light::Activate(%obj, $LightObjectColor[$DeployableDesc[%obj.depIndex]]);
        %obj.LightZROT = $LightObjectZROT[$DeployableDesc[%obj.depIndex]];
    }
    
    Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
    CheckDeployLimit();
    return %obj;
}

function CheckDeployLimit()
{
      if ($TotalDeploys > $MaximumDeployCap - 100)
      {
          BottomPrintAll("<jc><f0><->\n<F2>Warning: <F0>Server Approaching Maximum Object Capacity! Total: "@ $TotalDeploys @" \n<->");
      }
      if ($TotalDeploys >= $MaximumDeployCap)
      {
          DeleteAllObjects();
      }
}

function AddClObj(%obj, %clientId, %desc)
{
          %num = 0;
          for(%i = 0; (%objIndex = %clientId.ClObj[%i]) != ""; %i++)
          {
                %num++;
    	  }
          %obj.Owner = %clientId;
          %obj.PositionalCoord = GameBase::getPosition(%obj);
          %obj.RotationalCoord = GameBase::getRotation(%obj);
          %obj.ClIndex = %num;
          %clientId.ClObj[%num] = %obj;
          %clientId.ClObj[%num].isInside = false;
          %clientId.ClObj[%num].Desc = %desc;
          %clientId.TotalDeploys++;
          $TotalDeploys++;
          schedule("GameBase::SetActive("@%obj@",true);", 2.4, %obj);
          %clientId.score = %clientId.TotalDeploys;
          Game::refreshClientScore(%clientId);
          UpdateClTeam(%clientId, 1);
          
          WorkingLayer::addToCurrentLayer(%clientId, %obj);
          
          Redo::Rem(%clientId);
}

function Redo::Add(%clientId, %depIndex, %pos, %rot, %weld)
{
    $Redo[%clientId] = %depIndex @ "~" @ %pos @ "~" @ %rot @ "~" @ %weld;
}

function Redo::Rem(%clientId)
{
    $Redo[%clientId] = "";
}

function RedoLast(%clientId)
{
    if($Redo[%clientId] == "")
        return;
        
    %str = String::Replace($Redo[%clientId], " ", "=");
    %str = String::Replace(%str, "~", " ");
    
    %depIndex = String::Replace(getWord(%str, 0), "=", " ");
    %pos = String::Replace(getWord(%str, 1), "=", " ");
    %rot = String::Replace(getWord(%str, 2), "=", " ");
    %weld = String::Replace(getWord(%str, 3), "=", " ");
    
    DeployClObj(%clientId, %depIndex, %pos, %rot, %weld);
    schedule("Client::sendMessage(" @ %clientId @ ",3, \"Last Undo Redone\" );", 0.1);
    Redo::Rem(%clientId);
}

function UndoLast(%clientId)
{
    %obj = %clientId.ClObj[%clientId.TotalDeploys - 1];
    if(%obj == "")
        return;
        
    if(%obj.Owner != %clientId)
    {
        RemoveFromObjIndex(%TgtClientId, %obj);
        if(%obj.Owner == "")
            AddClObj(%obj.Owner, %obj);
    }
    %target = %obj;

    Redo::Add(%clientId, %target.DepIndex, GameBase::getPosition(%target), GameBase::getRotation(%target), %target.weld);

    %targetMapName = GameBase::getMapName(%target);
    if (%targetMapName == "")
       %targetMapName = %target.Desc;
    if (%targetMapName == "")
       %targetMapName = "Object ID " @ %target;
    %succmsg = "\"Last Deploy Deleted: " @ escapeString(%targetMapName) @ "\""; // PORT: the map name holds the owner's player name

    %TgtClientId = %target.Owner;
    
    //if(Player::isAiControlled(%target))
    //    $DummyNumber[%clientId]--;

    RemoveFromObjIndex(%TgtClientId, %target);

    GameBase::setTeam(%target, -1);
    %target.Del = true;
    GameBase::setActive(%target, false);
    GameBase::generatePower(%target, false);
    schedule("Client::sendMessage(" @ %clientId @ ",3," @ %succmsg @ ");", 0.1, %target);
    schedule("deleteObject(" @ %target @ ");", 0.1, %target);

    if(%clientId.SelectedElev == %target)
        %clientId.SelectedElev = "";

    if(%target.DontDel == true)
        return;
        
    if(%target.weld)
        %target.weld = false;

    if(GameBase::getDataName(%obj).className != "ModXElevator")
    {
        if(isObject(%target.Child))
        {
            $TotalDeploys--;
            deleteObject(%target.Child);
            %target.Child = "";
        }
        if(isObject(%target.Mother))
        {
            $TotalDeploys--;
            deleteObject(%target.Mother);
            %target.Mother = "";
        }
    }
    else
    {
        for(%i = 0; isObject(%target.Child[%i]) != false; %i++)
        {
            $TotalDeploys--;
            deleteObject(%target.Child[%i]);
            %target.Child[%i] = "";
        }
    }
    return;
}

function UpdateClTeam(%clientId, %num)
{
    %team = Client::getTeam(%clientId);
    UpdateTeamScore(%team, %num);
}

function UpdateTeamScore(%team, %num)
{
    $teamScore[%team] = $teamScore[%team] + %num;
    ObjectiveMission::refreshTeamScores();
}

function DestroyAllClObj(%TgtclientId, %clientId)
{
      for(%a = 0; (%target = %TgtclientId.ClObj[%a]) != ""; %a++)
            DeleteClObj(%TgtclientId, %target); //%TargetIndex[%a] == %target;

      ClearObjIndex(%TgtClientId);
      
      if (%clientId != -1)
      {
          %clName = Client::getName(%clientId);
          Client::sendMessage(%TgtclientId, 1, "All your deployed object have been deleted by " @ %clName);
          Echo("MODX: All of " @ %TgtclientId @ "'s Deployed Objects Deleted by " @ %clientId);
          return;
      }
}

function ClearObjIndex(%TgtClientId)
{
      if(%TgtClientId == false || %TgtClientId == -1 || %TgtClientId == "")
            return;

      %boolFound = false;
      for(%j = 0; (%objIndex = %TgtclientId.ClObj[%j]) != ""; %j++)
      {
                %TgtclientId.ClObj[%j].isInside = false;
                %TgtclientId.ClObj[%j].Desc = "";
                %TgtclientId.ClObj[%j].Teleporter = false;
                %TgtclientId.ClObj[%j].PositionalCoord = "";
                %TgtclientId.ClObj[%j].RotationalCoord = "";
                %objIndex.move = false;

                UpdateClTeam(%TgtclientId, -1);
                $TotalDeploys--;
                %TgtclientId.TotalDeploys--;
                %TgtclientId.score = %TgtclientId.TotalDeploys;

                %TgtclientId.ClObj[%j] = "";
      }
      Game::refreshClientScore(%TgtclientId);
}

function RemoveFromObjIndex(%TgtClientId, %obj)
{
      if(%TgtClientId == false || %TgtClientId == -1 || %TgtClientId == "")
            return;
            
      %boolFound = false;
      for(%j = %obj.ClIndex; (%objIndex = %TgtclientId.ClObj[%j]) != ""; %j++)
      {
            if(%objIndex == %obj && GameBase::getDataName(%target) != "Player")
            {
                %TgtclientId.TotalDeploys--;
                %TgtclientId.score = %TgtclientId.TotalDeploys;
                Game::refreshClientScore(%TgtclientId);

                %boolFound = true;
                %TgtclientId.ClObj[%j].isInside = false;
                %TgtclientId.ClObj[%j].Desc = "";
                %TgtclientId.ClObj[%j].Teleporter = false;
                %TgtclientId.ClObj[%j].PositionalCoord = "";
                %TgtclientId.ClObj[%j].RotationalCoord = "";
                UpdateClTeam(%TgtclientId, -1);
                $TotalDeploys--;
                %objIndex.move = false;
                GameBase::setActive(%objIndex, false);
                
                %obj = -1; //Put some Bullshit value here...
            }
            if(%boolFound == true)
            {
                %TgtclientId.ClObj[%j] = %TgtclientId.ClObj[%j + 1];
            }
      }
}

function DeleteClObj(%clientId, %target)
{
    %TgtClientId = %target.Owner;

    if(%TgtClientId != %clientId)
        return;

    if(%TgtClientId == false || %TgtClientId == -1 || %TgtClientId == "")
        return;

    GameBase::setTeam(%target, -1);
    %target.Del = true;
    GameBase::setActive(%target, false);
    GameBase::generatePower(%target, false);
    schedule("deleteObject(" @ %target @ ");", 0.1, %target);

    WorkingLayer::removeFromLayer(%TgtClientId, %target);

    if(Player::isAiControlled(%target))
        $DummyNumber[%tgtClientId]--;

    if(GameBase::getDataName(%target).className != "ModXElevator")
    {
        if(isObject(%target.Child))
        {
            $TotalDeploys--;
            deleteObject(%target.Child);
            %target.Child = "";
        }
        if(isObject(%target.Mother))
        {
            $TotalDeploys--;
            deleteObject(%target.Mother);
            %target.Mother = "";
        }
    }
    else
    {
        for(%i = 0; isObject(%target.Child[%i]) != false; %i++)
        {
            $TotalDeploys--;
            deleteObject(%target.Child[%i]);
            %target.Child[%i] = "";
        }
    }
    return;
}

function ChangeClObjTeam(%TgtClientId, %team, %oldteam)
{
      if(%TgtClientId == false || %TgtClientId == -1 || %TgtClientId == "")
            return;

      for(%i = 0; (%objIndex = %TgtclientId.ClObj[%i]) != ""; %i++)
      {

            GameBase::setTeam(%objIndex, %team);
            UpdateTeamScore(%oldteam, -1);       // Make sure that team's deploys
            UpdateTeamScore(%team, 1);           // stay in order...
            PowerItemSilent(%objIndex,$DeployablePowerRange,%TgtclientId); // Try to look for another generator in range
            
      }
}

function ToggleDepPriv(%clientId)
{
    %newState = true;
    if(%clientId.CannotDeploy == true)
       %newState = false;
    %clientId.CannotDeploy = %newState;
}

function AbandonAllClObj(%TgtclientId)
{
    DestroyAllClObj(%TgtclientId, -1);
}

function DeleteAllObjects()
{
    if ($TotalDeploys != 0)
    {
        %firstCl = Client::getFirst();
        schedule("DestroyAllClObj("@%firstCl@", -1);", 0.1);
        %nextCl = %firstCl;
        for(%j = 0; (%nextCl = Client::getNext(%nextCl)) != -1; %j++)
        {
            schedule("DestroyAllClObj("@%nextCl@", -1);", 0.1);
        }
        Teleport::ResetAll();
        BottomPrintAll("<jc><f1>-\nAll Deployed Objects Deleted\n-");
        Echo("MODX: All Deployed Objects Deleted");
    }
}

function Admin::isMovingAllObject(%clientId)
{
    %bool = false;
    if(%clientId.isAdmin == true)
    {
        if(%clientId.isMovingAll == true)
            %bool = true;
    }
    return %bool;
}

//10-17-04 -- Vage
//Layering System:

$LayerType[-1] = "All"; //Not A Real Layer...
$LayerType[0]  = "Layer One";
$LayerType[1]  = "Layer Two";
$LayerType[2]  = "Layer Three";
$LayerType[3]  = "Layer Four";
$LayerType[4]  = "Layer Five";
$LayerType[5]  = "Layer Six";
$LayerType[6]  = "Layer Seven";

function WorkingLayer::getDesc(%layer)
{
    return $LayerType[%layer];
}

function WorkingLayer::isValidLayer(%layer)
{
    if($LayerType[%layer] != "" && $LayerType[%layer] != -1)
        return true;
    return false;
}

function WorkingLayer::isInLayerScope(%clientId, %obj)
{
    if(%obj.InLayer == %clientId.currLayer || %clientId.currLayer == -1 || Admin::isMovingAllObject(%clientId) == true)
        return true;
    return false;
}

function WorkingLayer::addToCurrentLayer(%clientId, %obj)
{
    %currLayer = %clientId.currLayer;
    WorkingLayer::addToLayer(%clientId, %obj, %currLayer);
}

function WorkingLayer::changeActiveLayer(%clientId, %newLayer)
{
    %oldLayer = %clientId.currLayer;
    %clientId.currLayer = %newLayer;
    WorkingLayer::putInBack(%clientId, %oldLayer);
    WorkingLayer::putInFore(%clientId, %newLayer);
    if(%newLayer == -1)
    {
        %clientId.RefreshAllLayers = true;
        for(%layer = 0; WorkingLayer::isValidLayer(%layer) == true; %layer++)
            WorkingLayer::putInFore(%clientId, %layer);
    }
    if(%clientId.RefreshAllLayers == true && %newLayer != -1)
    {
        %clientId.RefreshAllLayers = "";
        for(%layer = 0; WorkingLayer::isValidLayer(%layer) == true; %layer++)
        {
            if(%clientId.currLayer == %layer)
                WorkingLayer::putInFore(%clientId, %layer);
            else
                WorkingLayer::putInBack(%clientId, %layer);
        }
    }
}

function WorkingLayer::refreshCurrentLayer(%clientId)
{
    WorkingLayer::changeActiveLayer(%clientId, %clientId.currLayer);
}

function WorkingLayer::putInBack(%clientId, %layer)
{
    for(%i = 0; (%obj = $LayerList[%clientId, %layer, %i]) != ""; %i++)
    {
        GameBase::setPosition(%obj, Vector::add(%obj.PositionalCoord, "-20000 -20000 -20000")); //Move outta the way...
    }
}

function WorkingLayer::echoLayer(%clientId, %layer)
{
    for(%i = 0; (%obj = $LayerList[%clientId, %layer, %i]) != ""; %i++)
    {
        echo(%i @ "/" @ %layer @ ": " @ %obj);
    }
}

function WorkingLayer::putInFore(%clientId, %layer)
{
    for(%i = 0; (%obj = $LayerList[%clientId, %layer, %i]) != ""; %i++)
    {
        GameBase::setPosition(%obj, %obj.PositionalCoord);
    }
}

function WorkingLayer::addToLayer(%clientId, %obj, %layer)
{
    if(WorkingLayer::isValidLayer(%obj.InLayer) == true)
        return;
    %num = 0;
    if(WorkingLayer::isValidLayer(%layer) == false)
        %layer = 0;
    for(%i = 0; $LayerList[%clientId, %layer, %i] != ""; %i++)
        %num++;
    $LayerList[%clientId, %layer, %num] = %obj;
    
    %obj.LayerListNum = %num;
    %obj.InLayer = %layer;
    //echo("$LayerList["@%clientId@", "@%layer@", "@%num@"] = " @ %obj);
}

function WorkingLayer::removeFromLayer(%clientId, %obj)
{
    if(WorkingLayer::isValidLayer(%obj.InLayer) == false)
        return;
        
    %layer = %obj.InLayer;
    %oln = %obj.LayerListNum; //Object List Num

    %boolFound = false;

      for(%j = %oln; (%objIndex = $LayerList[%clientId, %layer, %j]) != ""; %j++)
      {
            if(%objIndex == %obj)
            {
                $LayerList[%clientId, %layer, %objIndex.LayerListNum] = "";
                %obj.LayerListNum = "";
                %obj.InLayer = "";
                
                %boolFound = true;
                %obj = -1;
            }
            if(%boolFound == true)
            {
                $LayerList[%clientId, %layer, %j] = $LayerList[%clientId, %layer, %j + 1];
            }
      }
    
    //echo("$LayerList["@%clientId@", "@%layer@", "@%oln@"] = " @ $LayerList[%clientId, %layer, %oln]);
}

function WorkingLayer::mergeLayer(%clientId, %mergeLayer, %destLayer)
{
    if(%mergeLayer == %destLayer)
        return;

    %mergeTotal = 0;

    WorkingLayer::echoLayer(%clientId, %mergeLayer);
    WorkingLayer::echoLayer(%clientId, %destLayer);

    for(%i = 0; (%obj = $LayerList[%clientId, %mergeLayer, %i]) != ""; %i++)
        WorkingLayer::moveToLayer(%clientId, %obj, %newLayer);
    
    WorkingLayer::refreshCurrentLayer(%clientId);
    
    WorkingLayer::echoLayer(%clientId, %mergeLayer);
    WorkingLayer::echoLayer(%clientId, %destLayer);
}

function WorkingLayer::mergeAllLayers(%clientId, %destLayer)
{
    for(%mergeLayer = 0; WorkingLayer::isValidLayer(%mergeLayer) == true; %mergeLayer++)
        WorkingLayer::mergeLayer(%clientId, %mergeLayer, %destLayer);
        
    WorkingLayer::refreshCurrentLayer(%clientId);
}

function WorkingLayer::moveToLayer(%clientId, %obj, %newLayer)
{
    if(%newLayer == %obj.InLayer)
        return;
        
    WorkingLayer::removeFromLayer(%clientId, %obj);
    WorkingLayer::addToLayer(%clientId, %obj, %newLayer);
    
    WorkingLayer::refreshCurrentLayer(%clientId);
}

StaticShapeData Floor4x4Shape
{
        className = "Floor4x4";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_4x4";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor4x5Shape
{
        className = "Floor4x5";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_4x5";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor5x5Shape
{
        className = "Floor5x5";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_5x5";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor6x4Shape
{
        className = "Floor6x4";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator6x4";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor6x4ThinShape
{
        className = "Floor6x4Thin";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator6X4thin";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};


StaticShapeData Floor6x5Shape
{
        className = "Floor6x5";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_6x5";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor6x6Shape
{
        className = "Floor6x6";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_6x6";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor6x6ThinShape
{
        className = "Floor6x6Thin";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator6X6thin";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor6x6OctoShape
{
        className = "Floor6x6Octo";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_6x6_octagon";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor8x4Shape
{
        className = "Floor8x4";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_8x4";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor8x6Shape
{
        className = "Floor8x6";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_8x6";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor8x8Shape
{
        className = "Floor8x8";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_8x8";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor9x9Shape
{
        className = "Floor9x9";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_9x9";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

StaticShapeData Floor16x16OctoShape
{
        className = "Floor16x16Octo";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator16x16_octo";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

//function LgrBlastFloorShape::Destruct(%this)
//{
//        LgrBlastFloorShape::doDamage(%this);
//}
//
//function LgrBlastFloorShape::doDamage(%this)
//{
//        calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
//}

//function LgrBlastFloorShape::onDestroyed(%this)
//{
//        LgrBlastDoorShape::doDamage(%this);
//        $TeamItemCount[GameBase::getTeam(%this) @ "LgrBlastFloor"]--;
//}

StaticShapeData boostPad
{
   description = "Boost Pad";
	shapeFile = "flagstand";
	visibleToSensor = true;
};

$boostPowerL = 250;
$boostPowerH = 0.1;

function boostPad::onCollision(%this,%obj)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;
    
    %thisPos = GameBase::getPosition(%this);
    
    GameBase::setPosition(%obj, %thisPos);
    
    %rot = GameBase::getRotation(%obj);
    
    %boostVec = Vector::getFromRot(%rot, $boostPowerL, $boostPowerH);

    Player::applyImpulse(%obj,%boostVec);
    return;
}

StaticShapeData uberBoostPad
{
   description = "Uber-Boost Pad";
	shapeFile = "flagstand";
	visibleToSensor = true;
};

function uberBoostPad::onCollision(%this,%obj)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;

    %thisPos = GameBase::getPosition(%this);

    GameBase::setPosition(%obj, %thisPos);

    %rot = GameBase::getRotation(%obj);

    %boostVec = Vector::getFromRot(%rot, $boostPowerL * 4, $boostPowerH);

    Player::applyImpulse(%obj,%boostVec);
    return;
}

StaticShapeData blowPad
{
   description = "Blow Pad";
	shapeFile = "flagstand";
	visibleToSensor = true;
};

$blowPowerL = 0;
$blowPowerH = 250;

function blowPad::onCollision(%this,%obj)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;

    %thisPos = GameBase::getPosition(%this);

    GameBase::setPosition(%obj, %thisPos);

    %rot = GameBase::getRotation(%obj);

    %boostVec = Vector::getFromRot(%rot, $blowPowerL, $blowPowerH);

    Player::applyImpulse(%obj,%boostVec);
    return;
}

StaticShapeData uberBlowPad
{
   description = "Uber Blow Pad";
	shapeFile = "flagstand";
	visibleToSensor = true;
};

function uberBlowPad::onCollision(%this,%obj)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;

    %thisPos = GameBase::getPosition(%this);

    GameBase::setPosition(%obj, %thisPos);

    %rot = GameBase::getRotation(%obj);

    %boostVec = Vector::getFromRot(%rot, $blowPowerL, $blowPowerH * 4);

    Player::applyImpulse(%obj,%boostVec);
    return;
}

StaticShapeData advPad
{
    description = "Advanced Pad";
	shapeFile = "flagstand";
	visibleToSensor = true;
};

function advPad::onCollision(%this,%obj)
{
    %tPos = GameBase::getPosition(%this); //This depends upon if the box center is different from the real pos.
    %tPosII = getBoxCenter(%this);

    %vec = Vector::Normalize(Vector::Sub(%tPosII, %tPos));
    %vec = (getWord(%vec, 0) * $boostPowerL * 2) @ " " @ (getWord(%vec, 1) * $boostPowerL * 2) @ " " @ (getWord(%vec, 2) * $boostPowerL * 2);
    Player::applyImpulse(%obj, %vec);
}


StaticShapeData smallSensorRed
{
        className = "Small Red Sensor";
        damageSkinData = "objectDamageSkins";
        shapeFile =  "sensor_small";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        side = "single";
        isTranslucent = false;
        description = "Small Red Sensor";
	    shieldShapeName = "shield";
};

StaticShapeData smallSensorYellow
{
        className = "Small Yellow Sensor";
        damageSkinData = "objectDamageSkins";
        shapeFile =  "sensor_jammer";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        side = "single";
        isTranslucent = false;
        description = "Small Yellow Sensor";
	    shieldShapeName = "shield";
};

//function BlastFloorShape::Destruct(%this)
//{
//        BlastFloorShape::doDamage(%this);
//}

//function BlastFloorShape::doDamage(%this)
//{
//        calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
//}

//function BlastFloorShape::onDestroyed(%this)
//{
//        BlastDoorShape::doDamage(%this);
//        $TeamItemCount[GameBase::getTeam(%this) @ "BlastFloor"]--;
//}

//Generator//
StaticShapeData BigMobileGen
{	description		= "Large Portable Generator";
	shapeFile		= "generator";
	classname		= "Gen";
	debrisId		= flashDebrisSmall;
	sfxAmbient		= SoundGeneratorPower;
	maxDamage		= 1.8;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	shieldShapeName = "shield";
};

function BigMobileGen::onDestroyed(%this)
{	//if($trace) echo($ver,"| MobileGen::onDestroyed");
	MobileGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
}

function BigMobileGen::onEnabled(%this)
{	//if($trace) echo($ver,"| MobileGen::onEnabled ",%this);
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
    //RecheckGrid(%this);
}

function BigMobileGen::onDisabled(%this)
{	//if($trace) echo($ver,"| MobileGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

//PortaGen//
StaticShapeData MobileGen
{	description		= "Portable Generator";
	shapeFile		= "generator_p";
	classname		= "pGen";
	debrisId		= flashDebrisSmall;
	sfxAmbient		= SoundGeneratorPower;
	maxDamage		= 1.8;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	shieldShapeName = "shield";
};

function MobileGen::onDestroyed(%this)
{	//if($trace) echo($ver,"| MobileGen::onDestroyed");
	MobileGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
}

function MobileGen::onEnabled(%this)
{	//if($trace) echo($ver,"| MobileGen::onEnabled ",%this);
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
    //RecheckGrid(%this);
	GameBase::isPowerGenerator(%this);
}

function MobileGen::onDisabled(%this)
{	//if($trace) echo($ver,"| MobileGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
    DisconnectGenerator(%this);
}
//PortaSolar//
StaticShapeData PortaSolar
{	description		= "Solar Panel";
	shapeFile		= "solar_med";
	classname		= "pSol";
	debrisId		= flashDebrisSmall;
	//sfxAmbient		= SoundGeneratorPower;
	maxDamage		= 1.8;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	shieldShapeName = "shield";
};

function PortaSolar::onDestroyed(%this)
{	//if($trace) echo($ver,"| MobileGen::onDestroyed");
	PortaSolar::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
}

function PortaSolar::onEnabled(%this)
{	//if($trace) echo($ver,"| MobileGen::onEnabled ",%this);
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
    //RecheckGrid(%this);
	GameBase::isPowerGenerator(%this);
}

function PortaSolar::onDisabled(%this)
{	//if($trace) echo($ver,"| MobileGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
    DisconnectGenerator(%this);
}

//PortaSolarBig//
StaticShapeData PortaSolarBig
{	description		= "Solar Panel";
	shapeFile		= "solar";
	classname		= "pSol";
	debrisId		= flashDebrisSmall;
	//sfxAmbient		= SoundGeneratorPower;
	maxDamage		= 1.8;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	shieldShapeName = "shield";
};

function PortaSolarBig::onDestroyed(%this)
{	//if($trace) echo($ver,"| MobileGen::onDestroyed");
	PortaSolar::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
}

function PortaSolarBig::onEnabled(%this)
{	//if($trace) echo($ver,"| MobileGen::onEnabled ",%this);
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
    //RecheckGrid(%this);
	GameBase::isPowerGenerator(%this);
}

function PortaSolarBig::onDisabled(%this)
{	//if($trace) echo($ver,"| MobileGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
    DisconnectGenerator(%this);
}

//PortaAmmo//

StaticShapeData PortaA
{  description                = "Mobile Ammo Unit";
        shapeFile                = "Ammounit";
        classname                = "station";
        visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateAmmoStation };
	sequenceSound[1] = { "power", SoundAmmoStationPower };
	sequenceSound[2] = { "use", SoundUseAmmoStation };
        maxDamage                = 1.5;
        debrisId                = flashDebrisLarge;

       mapFilter                = 4;
        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        triggerRadius        = 1.5;
        explosionId                = flashExpLarge;
        shieldShapeName = "shield";

};

function PortaA::onEndSequence(%this,%thread)
{
        if (Station::onEndSequence(%this,%thread))
                AmmoStation::onResupply(%this);
}

function PortaA::onPower(%this, %newState, %generator)
{
         if (%newState == false)
         {
                NoPower(%this);
         }
}

StaticShapeData PortaC
{  description                = "Command Station";
        shapeFile                = "cmdpnl";
        classname                = "station";
        visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateCommandStation };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundUseCommandStation };
        maxDamage                = 1.5;
        debrisId                = flashDebrisLarge;
        mapFilter                = 4;

        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        triggerRadius        = 1.5;
        explosionId                = flashExpLarge;
        shieldShapeName = "shield";

};

function PortaC::onEndSequence(%this,%thread)
{
        if (Station::onEndSequence(%this,%thread))
                CommandStation::onResupply(%this);
}

function PortaC::onPower(%this, %newState, %generator)
{
         if (%newState == false)
         {
                NoPower(%this);
         }
}

//RemoteInv//
StaticShapeData MobileInvent
{
        description                = "Inventory Station";
        shapeFile                = "inventory_sta";
        classname                = "station";
        visibleToSensor = true;
        sequenceSound[0] = { "activate", SoundActivateInventoryStation };
        sequenceSound[1] = { "power", SoundInventoryStationPower };
        sequenceSound[2] = { "use", SoundUseInventoryStation };
        maxDamage                = 1.5;
        debrisId                = flashDebrisLarge;
        mapFilter                = 4;
        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        triggerRadius        = 1.5;
        explosionId                = flashExpLarge;
        shieldShapeName = "shield";

};

function MobileInvent::onEndSequence(%this,%thread)
{
        if (Station::onEndSequence(%this,%thread))
                InventoryStation::onResupply(%this,"InvList");
}

function MobileInvent::onPower(%this, %newState, %generator)
{
         if (%newState == false)
         {
                 NoPower(%this);
         }
}

// Doors

StaticShapeData ForceFieldDoor1
{
	shapeFile = "ForceField_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 36.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceFieldDoor2
{
	shapeFile = "ForceField_4x17";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceFieldDoor3
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 36.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceFieldDoor4
{
	shapeFile = "ForceField_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceFieldDoor5
{
	shapeFile = "ForceField_4x14";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};

function ForceFieldDoor1::onCollision(%this,%obj)
{
    Door::doCollision(%this,%obj);
}

function ForceFieldDoor2::onCollision(%this,%obj)
{
    Door::doCollision(%this,%obj);
}

function ForceFieldDoor3::onCollision(%this,%obj)
{
    Door::doCollision(%this,%obj);
}

function ForceFieldDoor4::onCollision(%this,%obj)
{
    Door::doCollision(%this,%obj);
}

function ForceFieldDoor5::onCollision(%this,%obj)
{
    Door::doCollision(%this,%obj);
}

function Door::doCollision(%this,%obj)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;

    %c = Player::getClient(%obj);
    //%playerTeam = GameBase::getTeam(%obj);
    //%fieldTeam = GameBase::getTeam(%this);      //Commented Out, enable if you want TeamBased opening
    //if(%fieldTeam != %playerTeam)
    //    return;
    Door::openDoor(%this);
    return;
}

function Door::openDoor(%this)
{
    GameBase::startfadeout(%this);
    %pos=GameBase::getPosition(%this);
    %pos=Vector::add(%pos,"0 0 1024");
    GameBase::setPosition(%this,%pos);
    schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
    schedule("Door::closeDoor("@%this@");",4);
}

function Door::closeDoor(%this)
{
    %pos=GameBase::getPosition(%this);
    %pos=Vector::add(%pos,"0 0 -1024");
    GameBase::setPosition(%this,%pos);
    GameBase::startfadein(%this);
    schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

StaticShapeData telePad
{
    description = "Teleporter";
    sfxAmbient = SoundBeaconActive;
	shapeFile =  "enerpad"; //"flagstand";
	visibleToSensor = true;
    lightType = 2;   // Pulsing
	lightRadius = 3;
	lightTime = 0.1;
	lightColor = { 0.85, 0.85, 0.85 };
};

StaticShapeData teleBeam
{
	shapeFile = "zap";
	maxDamage = 10000.0;
	isTranslucent = true;
    description = "Teleporter Beam";
    disableCollision = true;
};

function telePad::onActivate(%this)
{
    if (%this.Move != true)
       Teleport::Init(%this);

    %clientId = %this.Owner;
    $TotalDeploys++;
    //ElecBeam
    %item = "teleBeam";
    %itemShape = teleBeam;
    %itemDesc = "Teleporter Beam";
    %itemDOD = false;

    %rot = GameBase::getRotation(%this);
    %obj = newObject(%item,"StaticShape",%itemShape,%itemDOD);
    addToSet("MissionCleanup",%obj);
    GameBase::startFadeIn(%obj);
    %team = GameBase::getTeam(%this);
    GameBase::setTeam(%obj,%team);
    %postodeployin = vector::add(GameBase::getPosition(%this), "0 0 0.05");
    GameBase::setPosition(%obj,%postodeployin);
    GameBase::setRotation(%obj,vector::add(%rot, "0 -0.35 0"));
    Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
    %obj.PositionalCoord = GameBase::getPosition(%obj);
    WorkingLayer::addToCurrentLayer(%clientId, %obj);
    %this.Child = %obj;
    %obj.Mother = %this;
}

function telePad::onDeactivate(%this)
{
    $TotalDeploys--;
    deleteObject(%this.Child);
    %this.Child = "";
    %obj.PositionalCoord = GameBase::getPosition(%obj);
    WorkingLayer::removeFromLayer(%obj);
    %obj.PositionalCoord = "";
    
    if (%this.Move != true)
        Teleport::Rem(%this);
}

function telePad::onPower(%this, %newState, %generator)
{
         if (%newState == false)
         {
                 NoPower(%this);
         }
}

function telePad::onCollision(%this,%obj)
{
    Teleport::doCollision(%this,%obj, 0.9);
}

StaticShapeData telePadSml
{
   description = "Teleporter";
	shapeFile = "flagstand";
	visibleToSensor = true;
    lightType = 2;   // Pulsing
	lightRadius = 3;
	lightTime = 0.1;
	lightColor = { 0.85, 0.85, 0.85 };
};

function telePadSml::onActivate(%this)
{
    if (%this.Move != true)
       Teleport::Init(%this);

    %clientId = %this.Owner;
    $TotalDeploys++;
    //ElecBeam
    %item = "teleBeam";
    %itemShape = teleBeam;
    %itemDesc = "Teleporter Beam";
    %itemDOD = false;

    %rot = GameBase::getRotation(%this);
    %obj = newObject(%item,"StaticShape",%itemShape,%itemDOD);
    addToSet("MissionCleanup",%obj);
    GameBase::startFadeIn(%obj);
    %team = GameBase::getTeam(%this);
    GameBase::setTeam(%obj,%team);
    %postodeployin = vector::add(GameBase::getPosition(%this), "0 0 0.05");
    GameBase::setPosition(%obj,%postodeployin);
    GameBase::setRotation(%obj,%rot);
    Gamebase::setMapName(%obj, Client::getName(%clientId) @ "'s " @ %itemDesc);
    %obj.PositionalCoord = GameBase::getPosition(%obj);
    WorkingLayer::addToCurrentLayer(%clientId, %obj);
    %this.Child = %obj;
    %obj.Mother = %this;
}

function telePadSml::onDeactivate(%this)
{
    $TotalDeploys--;
    deleteObject(%this.Child);
    %this.Child = "";
    WorkingLayer::removeFromLayer(%obj);
    %obj.PositionalCoord = "";

    if (%this.Move != true)
        Teleport::Rem(%this);
}

function telePadSml::onPower(%this, %newState, %generator)
{
         if (%newState == false)
         {
                 NoPower(%this);
         }
}

function telePadSml::onCollision(%this,%obj)
{
    Teleport::doCollision(%this,%obj, 1.45);
}

function Teleport::doCollision(%this,%obj, %rng)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;

    if(checkRange(%this, %obj, %rng) == false)
        return;

    Teleport::goToNext(%this, %obj);
    return;
}

function checkRange(%this, %that, %Rng)
{
    %sPos = getBoxCenter(%this);
    %ePos = getBoxCenter(%that);

    %Dist = vector::getdistance(%sPos, %ePos);

    if(%Dist <= %Rng)
        return true; // Is In Range

    return false; // Or Not...
}

function Teleport::goToNext(%this, %player)
{
    %clientId = Player::getClient(%player);
    if(%this.TeleState == false)
    {
       Client::sendMessage(%clientId, 1, "Teleporter is recharging");
       return; //The Teleporter Has been used
    }
    %next = -1;
    for(%i = 0; (%objIndex = $TeleList[%i, $TeleOwner[%this]]) != ""; %i++)
    {
        if(%objIndex == %this)
        {
           %next = $TeleList[%i + 1, $TeleOwner[%this]]; //Get the next obj in the index
        }
    }
    
    if(%next == -1 || %next == "")
       %next = $TeleList[0, $TeleOwner[%this]]; //We've gone over the index, reset it
       
    if(%next == %this || %next == "")
    {
       Client::sendMessage(%clientId, 1, "No other teleporters");
       return; //This is the only teleporter!

    }
    
    if(%next.Teleporter != true)
    {
       Teleport::Rem(%next);
       return;
       //Teleport::goToNext(%this, %player);
    }
    
    %pos = GameBase::getPosition(%next);
    %pos = Vector::add(%pos,"0 0 0.4"); //Don't appear inside the teleporter
    Teleport::Deplete(%next); //The next teleport has been used
    %rot = vector::add(GameBase::getRotation(%next), "0 0 1.57");
    %rot = "0 0 " @ getWord(%rot, 2);
    GameBase::setPosition(%player, %pos); //getBoxCenter(%next)); //Teleport the player
    GameBase::setRotation(%player,%rot);
    //schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
    Teleport::Deplete(%this); //This teleport has been used
    playSound(SoundBeaconUse, GameBase::getPosition(%this));
    playSound(SoundBeaconUse, GameBase::getPosition(%next));
}

function Teleport::Deplete(%this)
{
    %this.TeleState = false;
    %this.Move = true;
    GameBase::setActive(%this, false);
    schedule("Teleport::Recharge("@%this@");",2);
}

function Teleport::Recharge(%this)
{
    GameBase::setActive(%this, true);
    %this.Move = false;
    %this.TeleState = true;
}

function Teleport::Init(%this)
{
    $TeleOwner[%this] = %this.Owner;
    %num = 0;
    for(%i = 0; (%objIndex = $TeleList[%i, $TeleOwner[%this]]) != ""; %i++)
    {
        %num++;
    }

    //%num = $TotalTeles[$TeleOwner[%this]];
    $TeleList[%num, $TeleOwner[%this]] = %this;
    %this.TeleState = true;
    %this.Teleporter = true;
    $TotalTeles[$TeleOwner[%this]]++;

    //schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

function Teleport::Rem(%this)
{
    %found = false;

    for(%i = 0; $TeleList[%i, $TeleOwner[%this]] != ""; %i++)
    {
        %TargetList[%i] = $TeleList[%i, $TeleOwner[%this]];
        %num++;
    }
    
    for(%a = 0; (%obj = %TargetList[%a]) != ""; %a++)
    {
        if(%this == %obj)
        {
            %found = true;
            %this.TeleState = false;
            %this.Teleporter = false;
            $TotalTeles[$TeleOwner[%this]]--;
        }
        if(%found == true)
        {
            %TargetList[%a] = %TargetList[%a + 1];
        }
    }
    
    for(%b = 0; %b < %num; %b++)
    {
        $TeleList[%b, $TeleOwner[%this]] = %TargetList[%b];
    }
}

function Teleport::ResetAll()
{
    %num = 0;
    for(%owner = Client::getFirst(); %owner != -1; %owner = Client::getNext(%owner))
    {
        for(%i = 0; (%objIndex = $TeleList[%i, %owner]) != ""; %i++)
        {
            %TargetList[%i] = %objIndex;
            %num++;
        }
        for(%j = 0; %j <= %num; %j++)
        {
            Teleport::Rem(%TargetList[%j]);
        }
    }
}

StaticShapeData Cube1
{
   description = "Cube";
	shapeFile = "cube2";
	visibleToSensor = true;
};
StaticShapeData Cube2
{
   description = "Cube";
	shapeFile = "cube4";
	visibleToSensor = true;
};
StaticShapeData Cube3
{
   description = "Cube";
	shapeFile = "cube8";
	visibleToSensor = true;
};
StaticShapeData Pyrm1
{
   description = "Pyrm";
	shapeFile = "Pyrm2";
	visibleToSensor = true;
};
StaticShapeData Pyrm2
{
   description = "Pyrm";
	shapeFile = "Pyrm4";
	visibleToSensor = true;
};
StaticShapeData Pyrm3
{
   description = "Pyrm";
	shapeFile = "Pyrm8";
	visibleToSensor = true;
};

   // Copy-Cat Anim Indexes
   $animIndex[0] = "root";
   $animIndex[1] = "run";
   $animIndex[2] = "runback";
   $animIndex[3] = "side left";
   $animIndex[4] = "side left";
   $animIndex[5] = "jump stand";
   $animIndex[6] = "jump run";
   $animIndex[7] = "crouch root";
   $animIndex[8] = "crouch root";
   $animIndex[9] = "crouch root";
   $animIndex[10] = "crouch forward";
   $animIndex[11] = "crouch forward";
   $animIndex[12] = "crouch side left";
   $animIndex[13] = "crouch side left";
   $animIndex[14] = "fall";
   $animIndex[15] = "landing";
   $animIndex[16] = "landing";
   $animIndex[17] = "tumble loop";
   $animIndex[18] = "tumble end";
   $animIndex[19] = "jet";

   // misc. animations:
   $animIndex[20] = "PDA access";
   $animIndex[21] = "throw";
   $animIndex[22] = "flyer root";
   $animIndex[23] = "apc root";
   $animIndex[24] = "apc pilot";

   // death animations:
   $animIndex[25] = "crouch die";
   $animIndex[26] = "die chest";
   $animIndex[27] = "die head";
   $animIndex[28] = "die grab back";
   $animIndex[29] = "die right side";
   $animIndex[30] = "die left side";
   $animIndex[31] = "die leg left";
   $animIndex[32] = "die leg right";
   $animIndex[33] = "die blown back";
   $animIndex[34] = "die spin";
   $animIndex[35] = "die forward";
   $animIndex[36] = "die forward kneel";
   $animIndex[37] = "die back";

   // signal moves:
   $animIndex[38] = "sign over here";
   $animIndex[39] = "sign point";
   $animIndex[40] = "sign retreat";
   $animIndex[41] = "sign stop";
   $animIndex[42] = "sign salut";

    // celebration animations:
   $animIndex[43] = "celebration 1";
   $animIndex[44] = "celebration 2";
   $animIndex[45] = "celebration 3";

   // taunt animations:
   $animIndex[46] = "taunt 1";
   $animIndex[47] = "taunt 2";

   // poses:
   $animIndex[48] = "pose kneel";
   $animIndex[49] = "pose stand";

   // Bonus wave
   $animIndex[50] = "wave";
   
//----------------------------------------------------------------------------

StaticShapeData ModXDoor
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "ModX Door";
};

function ModXDoor::onCollision(%this,%obj)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;
        
    ModXDoor::doCollision(%this,%obj);
}

function ModXDoor::doCollision(%this,%obj)
{
    if(%this.weld)
        return;

    if(%this.opening)
        return;

    ModXDoor::openDoor(%this);
}

function ModXDoor::openDoor(%this)
{
    for(%i = 0.01; %i < 0.3; %i = %i + 0.01)
        schedule("ModXDoor::move("@%this@","@%i@");",%i, %this);
    schedule("ModXDoor::closeDoor("@%this@");",4.5);
    playSound(SoundDoorOpen, GameBase::getPosition(%this));
    %this.opening = true;
    %this.OrigPos = GameBase::getPosition(%this);
}

function ModXDoor::closeDoor(%this)
{
    for(%i = 0.01; %i < 0.3; %i = %i + 0.01)
        schedule("ModXDoor::move("@%this@",-"@%i@");",%i, %this);
    schedule("ModXDoor::Final("@%this@");",%i, %this);
    schedule(%this@".opening = false;",%i, %this);
    playSound(SoundDoorClose, GameBase::getPosition(%this));
}

function ModXDoor::move(%this, %htoadd)
{
    %postoadd = "0 0 " @ %htoadd;
    %pos = GameBase::getPosition(%this);
    %pos = Vector::add(%pos,%postoadd);
    GameBase::setPosition(%this, %pos);
}

function ModXDoor::Final(%this)
{
    GameBase::setPosition(%this, %this.OrigPos);
    %this.OrigPos = "";
    %this.opening = false;
}

//----------------------------------------------------------------------------

StaticShapeData RotModXDoor
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Rotating ModX Door";
};

function RotModXDoor::onCollision(%this,%obj)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;
        
    RotModXDoor::doCollision(%this,%obj);
}

function RotModXDoor::doCollision(%this,%obj)
{
    if(%this.weld)
        return;

    if(%this.opening)
        return;

    RotModXDoor::openDoor(%this);
}

function RotModXDoor::openDoor(%this)
{
    for(%i = 0.1; %i < 0.55; %i = %i + 0.1)
        schedule("RotModXDoor::move("@%this@","@%i@");",%i, %this);
    schedule("RotModXDoor::closeDoor("@%this@");",4.5);
    playSound(SoundDoorOpen, GameBase::getPosition(%this));
    %this.opening = true;
    %this.OrigRot = GameBase::getRotation(%this);
    %this.OrigPos = GameBase::getPosition(%this);
}

function RotModXDoor::closeDoor(%this)
{
    %this.closing = true;
    for(%i = 0.1; %i < 0.55; %i = %i + 0.1)
        schedule("RotModXDoor::move("@%this@","@%i@");",%i, %this);
    schedule("RotModXDoor::Final("@%this@");",%i, %this);
    playSound(SoundDoorClose, GameBase::getPosition(%this));
}

function RotModXDoor::move(%this, %toadd)
{
    %oldpos = Gamebase::getPosition(%this);
    %oldrot = Gamebase::getRotation(%this);
    if(!%this.closing)
    {
        %newrot = vector::add(%oldrot, "0 0 " @ %toadd);
        %newpos = vector::add(%oldpos,rotatevector("-1.2 0 0",vector::multiply(vector::add(%oldrot,"0 0 "@%toadd ), "0 0 -1")));
        //GameBase::setPosition(newObject("Marker", "StaticShape", smallSensorRed), %newpos);
        $RotDoorTotal[%this]++;
        $RotDoorPos[%this, $RotDoorTotal[%this]] = %newpos;
        $RotDoorRot[%this, $RotDoorTotal[%this]] = %newrot;
    }
    else
    {
        %newrot = $RotDoorRot[%this, $RotDoorTotal[%this]];
        %newpos = $RotDoorPos[%this, $RotDoorTotal[%this]];
        if($RotDoorTotal[%this] == 1)
        {
            %newrot = %this.OrigRot;
            %newpos = %this.OrigPos;
        }
        $RotDoorTotal[%this]--;
    }
    GameBase::setRotation(%this, %newrot);
    GameBase::setPosition(%this, %newpos);
}

function RotModXDoor::Final(%this)
{
    GameBase::setRotation(%this, %this.OrigRot);
    GameBase::setPosition(%this, %this.OrigPos);
    %this.OrigRot = "";
    %this.OrigPos = "";
    %this.opening = false;
    %this.closing = "";
    $RotDoorTotal[%this] = "";
}

//----------------------------------------------------------------------------

StaticShapeData SlideModXDoor
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Sliding ModX Door";
};

function SlideModXDoor::onCollision(%this,%obj)
{
    if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        return;

    SlideModXDoor::doCollision(%this,%obj);
}

function SlideModXDoor::doCollision(%this,%obj)
{
    if(%this.weld)
        return;

    if(%this.opening)
        return;

    SlideModXDoor::openDoor(%this);
}

function SlideModXDoor::openDoor(%this)
{
    for(%i = 0.1; %i < 0.55; %i = %i + 0.1)
        schedule("SlideModXDoor::move("@%this@","@%i@");",%i, %this);
    schedule("SlideModXDoor::closeDoor("@%this@");",4.5);
    playSound(SoundDoorOpen, GameBase::getPosition(%this));
    %this.opening = true;
    %this.OrigRot = GameBase::getRotation(%this);
    %this.OrigPos = GameBase::getPosition(%this);
}

function SlideModXDoor::closeDoor(%this)
{
    %this.closing = true;
    for(%i = 0.1; %i < 0.55; %i = %i + 0.1)
        schedule("SlideModXDoor::move("@%this@","@%i@");",%i, %this);
    schedule("SlideModXDoor::Final("@%this@");",%i, %this);
    playSound(SoundDoorClose, GameBase::getPosition(%this));
}

function SlideModXDoor::move(%this, %toadd)
{
    %oldpos = Gamebase::getPosition(%this);
    %oldrot = Gamebase::getRotation(%this);
    if(!%this.closing)
    {
        //%newrot = vector::add(%oldrot, "0 0 " @ %toadd);
        %newpos = vector::add(rotatevector("2 0 0",vector::add(%oldrot,"0 0 0")),%oldpos);
        //GameBase::setPosition(newObject("Marker", "StaticShape", smallSensorRed), %newpos);
        $DoorTotal[%this]++;
        $DoorPos[%this, $DoorTotal[%this]] = %newpos;
        //$DoorRot[%this, $DoorTotal[%this]] = %newrot;
    }
    else
    {
        //%newrot = $DoorRot[%this, $DoorTotal[%this]];
        %newpos = $DoorPos[%this, $DoorTotal[%this]];
        if($DoorTotal[%this] == 1)
        {
            %newrot = %this.OrigRot;
            %newpos = %this.OrigPos;
        }
        $DoorTotal[%this]--;
    }
    GameBase::setPosition(%this, %newpos);
}

function SlideModXDoor::Final(%this)
{
    GameBase::setRotation(%this, %this.OrigRot);
    GameBase::setPosition(%this, %this.OrigPos);
    %this.OrigRot = "";
    %this.OrigPos = "";
    %this.opening = false;
    %this.closing = "";
    $DoorTotal[%this] = "";
}

StaticShapeData RPStation
{
   description = "Station Supply Unit";
	shapeFile = "mainpad";
	className = "RoleplayingStation";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   explosionId = flashExpLarge;
};

//----------------------------------------------------------------------------

function RPStation::onActivate(%this)
{
		GameBase::playSequence(%this,1,"use");
		//echo("Activate " @ %this);
 		RPStation::onResupply(%this,"RPList");
		%this.lastPlayer = Station::getTarget(%this);
}

function RPStation::onResupply(%this,%InvShopList)
{
    dbecho(3, "STATION::Resupply");
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player) {
			%client = Player::getClient(%player);
			if (%this.target != %client) {
				%player.Station = %this;
				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
            if(!%client.noEnterInventory)
                Client::setInventoryText(%this.target, "<f1><jc>Roleplaying Station");
   				Client::setGuiMode(%client,$GuiModeInventory);
				Client::sendMessage(%client,0,"Station Access On");
                %player.ResupplyFlag = 1;
				%weapon = Player::getMountedItem(%player,$WeaponSlot);
				if(%weapon != -1) {
					%player.lastWeapon = %weapon;
					Player::unMountItem(%player,$WeaponSlot);
				}
			}
			%player.waitThrowTime = getSimTime();
			schedule("RPStation::onResupply(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target != "") {
		%player = Client::getOwnedObject(%this.target);
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);
		Client::setInventoryText(%this.target, "<f1><jc>ModX");
		if(Client::getGuiMode(%this.target) != 1)
			Client::setGuiMode(%this.target,1);
		%player.Station = "";
		%this.target = "";
		if(Player::getMountedItem(%player,$WeaponSlot) == -1){
			if(%player.lastWeapon != "") {
				Player::useItem(%player,%player.lastWeapon);
				%player.lastWeapon = "";
	  		}
		}
	}
	%this.enterTime="";
}
//----------------------------------------------------------------------------
StaticShapeData ModXElevatorFloor4x4
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_4x4";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor4x4::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor4x4::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor4x4::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor4x4::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor4x4::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor4x5
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_4x5";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor4x5::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor4x5::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor4x5::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor4x5::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor4x5::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor5x5
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_5x5";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor5x5::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor5x5::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor5x5::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor5x5::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor5x5::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor6x4
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator6x4";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor6x4::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor6x4::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor6x4::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor6x4::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor6x4::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor6x4Thin
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator6X4thin";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor6x4Thin::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor6x4Thin::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor6x4Thin::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor6x4Thin::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor6x4Thin::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor6x5
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_6x5";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor6x5::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor6x5::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor6x5::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor6x5::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor6x5::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor6x6
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_6x6";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor6x6::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor6x6::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor6x6::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor6x6::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor6x6::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor6x6Thin
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator6X6thin";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor6x6Thin::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor6x6Thin::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor6x6Thin::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor6x6Thin::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor6x6Thin::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor6x6Octo
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_6x6_octagon";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor6x6Octo::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor6x6Octo::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor6x6Octo::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor6x6Octo::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor6x6Octo::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor8x4
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_8x4";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor8x4::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor8x4::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor8x4::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor8x4::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor8x4::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor8x6
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_8x6";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor8x6::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor8x6::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor8x6::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor8x6::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor8x6::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor8x8
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_8x8";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor8x8::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor8x8::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor8x8::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor8x8::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor8x8::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor9x9
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator_9x9";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor9x9::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor9x9::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor9x9::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor9x9::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor9x9::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ModXElevatorFloor16x16Octo
{
        className = "ModXElevator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator16x16_octo";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "--";
	shieldShapeName = "shield";
};

function ModXElevatorFloor16x16Octo::onCollision(%this,%obj)
{
    if(getObjectType(%obj)=="Player" || getObjectType(%obj)=="Flyer" || !Player::isDead(%obj))
        Elevator::doCollision(%this,%obj);
    else
        return;
}

function ModXElevatorFloor16x16Octo::onActivate(%this)
{
    Elevator::Init(%this);
}

function ModXElevatorFloor16x16Octo::onDeactivate(%this)
{
    Elevator::Uninit(%this);
}

function ModXElevatorFloor16x16Octo::onWeld(%this, %weld)
{
    Elevator::onWeld(%this, %weld);
}

function ModXElevatorFloor16x16Octo::onDelete(%this)
{
    Elevator::onDelete(%this);
}

StaticShapeData ElevatorMarker0
{
        className = "ElevMarker";
        shapeFile =  "arrow5_r";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "-Marker-";
};

StaticShapeData ElevatorMarker1
{
        className = "ElevMarker";
        shapeFile =  "arrow5_g";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "-Marker-";
};

StaticShapeData ElevatorMarker2
{
        className = "ElevMarker";
        shapeFile =  "arrow5_b";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "-Marker-";
};

StaticShapeData ElevatorMarker3
{
        className = "ElevMarker";
        shapeFile =  "arrow5_y";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "-Marker-";
};

function ElevatorMarker0::onActivate(%this)
{
    %this.Mother.EndPos[%this.MarkerNo] = GameBase::getPosition(%this);
    %this.DontWeld = true;
    %this.DontRot = true;
    %this.DontDel = true;
    %this.PositionalCoord = GameBase::getPosition(%this);
}

function ElevatorMarker1::onActivate(%this)
{
    %this.Mother.EndPos[%this.MarkerNo] = GameBase::getPosition(%this);
    %this.DontWeld = true;
    %this.DontRot = true;
    %this.DontDel = true;
    %this.PositionalCoord = GameBase::getPosition(%this);
}

function ElevatorMarker2::onActivate(%this)
{
    %this.Mother.EndPos[%this.MarkerNo] = GameBase::getPosition(%this);
    %this.DontWeld = true;
    %this.DontRot = true;
    %this.DontDel = true;
    %this.PositionalCoord = GameBase::getPosition(%this);
}

function ElevatorMarker3::onActivate(%this)
{
    %this.Mother.EndPos[%this.MarkerNo] = GameBase::getPosition(%this);
    %this.DontWeld = true;
    %this.DontRot = true;
    %this.DontDel = true;
    %this.PositionalCoord = GameBase::getPosition(%this);
}

function Elevator::doCollision(%this,%obj)
{
    if(!%this.weld)
        return;

    if(%this.ElevStatus != "ENDED")
        return;

    if(GameBase::isActive(%this) != true)
        return;

    %cl = Player::getClient(%obj);

    if(%cl.elevdelay == 3)
    {
        Elevator::MakeMovementPath(%this);
        Elevator::Forward(%this);
        %cl.elevdelay = 0;
    }
    else
        %cl.elevdelay++;
}

function Elevator::MakeMovementPath(%this)
{
    Elevator::moveCalc(%this, %this.StartPos, %this.EndPos[0]);
    for(%i = 1; %i < $ElevTotalMoves[%this]; %i++)
    {
        %MovementPathTemp[%num] = $ElevPosArray[%this, %i];
        %num++;
    }
    
    for(%i = 1; %this.EndPos[%i] != ""; %i++)
    {
        Elevator::moveCalc(%this, %this.EndPos[%i - 1], %this.EndPos[%i]);
        for(%j = 1; %j < $ElevTotalMoves[%this]; %j++)
        {
            %MovementPathTemp[%num] = $ElevPosArray[%this, %j];
            %num++;
        }
    }
    if(%this.ElevLoop == true)
    {
        Elevator::moveCalc(%this, %this.EndPos[%i - 1], %this.StartPos);
        for(%j = 1; %j < $ElevTotalMoves[%this]; %j++)
        {
            %MovementPathTemp[%num] = $ElevPosArray[%this, %j];
            %num++;
        }
    }
    $ElevTotalMoves[%this] = %num;
    for(%i = %num; %i != 0; %i--)
    {
        $ElevPosArray[%this, %i] = %MovementPathTemp[%i];
    }
}

function Elevator::Init(%this)
{
    %thisPos = GameBase::getPosition(%this);
    %this.StartPos = %thisPos;

    if(%this.EndPos[0] == "")
        %this.EndPos[0] = Vector::add(%thisPos, "0 0 5");
    if(%this.MarkerCreated == "")
        %this.MarkerCreated = false;

    if(%this.ElevDelay == "")
        %this.ElevDelay = 3;
    if(%this.ElevSpeed == "")
        %this.ElevSpeed = 0.1;

    Elevator::onWeld(%this, %this.weld);
    $ElevCurrent[%this] = 0;

    %this.MovedDownOne = false;
    %this.ElevStatus = "ENDED";
}

function Elevator::onWeld(%this, %weld)
{
    if(!%weld)
    {
        Elevator::createMarker(%this);
    }
    else if(%weld)
    {
        Elevator::cleanupMarker(%this);
    }
}

function Elevator::onDelete(%this)
{
    Elevator::cleanupMarker(%this);
}

function Elevator::AddMarker(%this, %num)
{
    %thisPos = GameBase::getPosition(%this);
    %this.EndPos[%num] = Vector::add(%thisPos, "0 0 "@(%num+5));
    //Must Unweld here...
    %this.weld = false;
    //Cleanup then Create!
    Elevator::cleanupMarker(%this);
    Elevator::createMarker(%this);
}

function Elevator::DelMarker(%this, %num)
{
    %this.EndPos[%num] = "";
    %this.weld = false;
    Elevator::cleanupMarker(%this);
    Elevator::createMarker(%this);
}

function Elevator::createMarker(%this)
{
    if(%this.MarkerCreated == true)
        return;

    %this.MarkerCreated = true;
    %thisPos = GameBase::getPosition(%this);

    for(%i = 0; %this.EndPos[%i] != ""; %i++)
    {
        $TotalDeploys++;
        %marker = newObject("Marker #" @ %i + 1, "StaticShape", ElevatorMarker@%i);
        GameBase::setPosition(%marker, %this.EndPos[%i]);
        %marker.Mother = %this;
        %marker.Owner = %this.Owner;
        %marker.MarkerNo = %i;
        GameBase::setActive(%marker, true);
        %this.Child[%i] = %marker;
        %this.EndPos[%i] = GameBase::getPosition(%marker);
        GameBase::setMapName(%marker, "Movement Path Marker");
        WorkingLayer::addToCurrentLayer(%this.Owner, %marker);
    }
    %this.ElevStatus = "MARKING";
    //echo(%this.ElevStatus);
}

function Elevator::cleanupMarker(%this)
{
    if(%this.MarkerCreated == false)
        return;

    %this.MarkerCreated = false;
    for(%i = 0; (%marker = %this.Child[%i]) != ""; %i++)
    {
        if(isObject(%marker) == true)
        {
            %this.EndPos[%marker.MarkerNo] = GameBase::getPosition(%marker);
            deleteObject(%marker);
            WorkingLayer::removeFromLayer(%this.Owner, %marker);
            $TotalDeploys--;
        }
    }
    %this.ElevStatus = "ENDED";
    //echo(%this.ElevStatus);
}

function Elevator::Uninit(%this)
{
    %this.StartPos = GameBase::getPosition(%this);
    %this.ElevStatus = "MOVING";
}

function Elevator::Forward(%this)
{
    %this.DontMove = true;
    %this.DontWeld = true;
    %this.ElevStatus = "FORWARD";
    for(%i = 1; %i != $ElevTotalMoves[%this]; %i++)
    {
        %j = %j + %this.ElevSpeed;
        schedule("Elevator::move("@%this@");", %j, %this);
    }
    if(%this.ElevLoop != true)
    {
        schedule("Elevator::Backward("@%this@");", %j + %this.ElevDelay, %this);
    }
    else
    {
        schedule("Elevator::Final("@%this@");", %j + (%this.ElevSpeed * 2), %this);
    }
}

function Elevator::Backward(%this)
{
    %this.ElevStatus = "BACKWARD";
    for(%i = 1; %i != $ElevTotalMoves[%this]; %i++)
    {
        %j = %j + %this.ElevSpeed;
        schedule("Elevator::move("@%this@");", %j, %this);
    }
    schedule("Elevator::Final("@%this@");", %j + (%this.ElevSpeed * 2), %this);
}

SoundData SoundElevatorRunNoLoop
{
   wavFileName = "generator.wav";
   profile = Profile3dNear;
};

function Elevator::moveCalc(%this, %thisPos, %toPos)
{
    //%thisPos = %this.StartPos;
    %posA = getWord(%thisPos, 0);
    %posB = getWord(%thisPos, 1);
    %posC = getWord(%thisPos, 2);
    //echo("THISPOS: " @ %thisPos);
    //%toPos = %this.EndPos;
    %pos1 = getWord(%toPos, 0);
    %pos2 = getWord(%toPos, 1);
    %pos3 = getWord(%toPos, 2);
    //echo("TOPOS:   " @ %toPos);

    %posDiffI = (%pos1 - %posA);
    %posDiffII = (%pos2 - %posB);
    %posDiffIII = (%pos3 - %posC);

    //echo("POSDIFFII: "@%posDiffI);
    //echo("POSDIFFIII: "@%posDiffII);
    //echo("POSDIFFIIII: "@%posDiffIII);

    %delta = sqrt(pow(%posDiffI, 2)+pow(%posDiffII, 2)+pow(%posDiffIII, 2));
    //echo("DELTA: " @ %delta);
    
    %increX = (%posDiffI / %delta);
    %increY = (%posDiffII / %delta);
    %increZ = (%posDiffIII / %delta);
    
    %increPos = %increX @ " " @ %increY @ " " @ %increZ;
    
    //echo("X INC: "@%increX);
    //echo("Y INC: "@%increY);
    //echo("Z INC: "@%increZ);

    //echo(" ");
    
    %finalX = %posA+(%increX*%delta);
    %finalY = %posB+(%increY*%delta);
    %finalZ = %posC+(%increZ*%delta);
    %finalPos = %finalX @ " " @ %finalY @ " " @ %finalZ;
    
    //echo("FINALX: "@%finalX);
    //echo("FINALY: "@%finalY);
    //echo("FINALZ: "@%finalZ);
    
    %newA = %posA;
    %newB = %posB;
    %newC = %posC;
    
    for(%i = 0; %i != %delta; %i)
    {
          %num++;
          if(%i>%delta)
              %i = %delta;
          else
              %i++;

          %newA = %posA + (%increX * %i);
          %newB = %posB + (%increY * %i);
          %newC = %posC + (%increZ * %i);

          $ElevPosArray[%this, %num] = %newA @ " " @ %newB @ " " @ %newC;

          //$ElevClPosArray[%this, %num] = %increPos;
          //$ElevClPosArray0[%this, %num] = (%increX * %i);
          //$ElevClPosArray1[%this, %num] = (%increY * %i);
          //$ElevClPosArray2[%this, %num] = (%increZ * %i);

          $ElevTotalMoves[%this] = %num;

          //echo("ARRAY: "@$ElevPosArray[%this, %num]);
    }

    //echo("TOTALMOVES: " @ $ElevTotalMoves[%this]);
    //echo(" ");
    //echo(%newA);
    //echo(%newB);
    //echo(%newC);
}

function Elevator::Final(%this)
{
    %this.MovedDownOne = false;
    %this.DontMove = false;
    %this.DontWeld = false;
    %oldpos = GameBase::getPosition(%this);
    %radius = GameBase::getRadius(%this) + (GameBase::getRadius(%this) / 2.75);
    %set = newObject("set",SimSet);
	%mask = $VehicleObjectType | $SimPlayerObjectType;
	%objsInWay = containerBoxFillSet(%set,%mask,%oldpos,%radius,%radius,%radius,%radius/2);

    %pos1o = getWord(%oldpos, 0);
    %pos2o = getWord(%oldpos, 1);
    %pos3o = getWord(%oldpos, 2);

	if(%objsInWay > 0)
    {
        for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
        {
            %pos = Gamebase::getPosition(%obj);
            %pos1cl = getWord(%pos, 0);
            %pos2cl = getWord(%pos, 1);
            %pos3cl = getWord(%pos, 2);

            %pos = Vector::Add(%this.StartPos, (%pos1cl - %pos1o) @ " " @ (%pos2cl - %pos2o) @ " " @ (%pos3cl - %pos3o));
            GameBase::setPosition(%obj, %pos);
        }
    }
    
    $ElevCurrent[%this] = 0;
    %this.ElevStatus = "ENDED";
    GameBase::setPosition(%this, %this.StartPos);
}

function Elevator::move(%this)
{
    %oldpos = GameBase::getPosition(%this);
    %pos1o = getWord(%oldpos, 0);
    %pos2o = getWord(%oldpos, 1);
    %pos3o = getWord(%oldpos, 2);
    //echo("MOVE#: "@$ElevCurrent[%this]);
    if(%this.ElevStatus == "FORWARD")
    {
        $ElevCurrent[%this]++;
        %newpos = $ElevPosArray[%this, $ElevCurrent[%this]];
        //%clpos = $ElevClPosArray[%this, $ElevCurrent[%this]];
    }

    if(%this.ElevStatus == "BACKWARD")
    {
        %newpos = $ElevPosArray[%this, $ElevCurrent[%this]];
        $ElevPosArray[%this, $ElevCurrent[%this]] = "";
        //%clpos = $ElevClPosArray[%this, $ElevCurrent[%this]];
        $ElevCurrent[%this]--;
    }
    playSound(SoundElevatorRunNoLoop, %newpos);
    GameBase::setPosition(%this, %newpos);

    if(%this.ElevStatus == "FORWARD" || %this.ElevStatus == "BACKWARD")
    {
        //echo("Moving Objs");
        %radius = GameBase::getRadius(%this) + (GameBase::getRadius(%this) / 2.75);
        %set = newObject("set",SimSet);
		%mask = $VehicleObjectType | $SimPlayerObjectType;
		%objsInWay = containerBoxFillSet(%set,%mask,%oldpos,%radius,%radius,%radius,%radius/2);

		if(%objsInWay > 0)
        {
            for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
            {
                %pos = Gamebase::getPosition(%obj);
                //%moveClPos = %clpos;

                %pos1cl = getWord(%pos, 0);
                %pos2cl = getWord(%pos, 1);
                %pos3cl = getWord(%pos, 2);

                if(%this.ElevStatus == "FORWARD")
                {
                    //%movePos = Vector::Add(%moveClPos, %pos);
                    //%pos = %movePos;
                    %pos = Vector::Add(%newpos, (%pos1cl - %pos1o) @ " " @ (%pos2cl - %pos2o) @ " " @ (%pos3cl - %pos3o));
                }
                else if(%this.ElevStatus == "BACKWARD")
                {
                    //%movePos = Vector::Add(Vector::Multiply(%moveClPos, "-1 -1 -1"), %pos);
                    if(%this.MovedDownOne)
                    {
                        //%pos = %movePos;
                        %pos = Vector::Add(%newpos, (%pos1cl - %pos1o) @ " " @ (%pos2cl - %pos2o) @ " " @ (%pos3cl - %pos3o));
                    }
                    else
                        %this.MovedDownOne = true;
                }
                
                GameBase::setPosition(%obj, %pos);
            }
		}
    }
}

StaticShapeData arrow5_r
{
        className = "MiscObject";
        shapeFile =  "arrow5_r";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData arrow5_g
{
        className = "MiscObject";
        shapeFile =  "arrow5_g";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData arrow5_b
{
        className = "MiscObject";
        shapeFile =  "arrow5_b";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData arrow5_y
{
        className = "MiscObject";
        shapeFile =  "arrow5_y";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData ammo1
{
        className = "MiscObject";
        shapeFile =  "ammo1";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData ammo2
{
        className = "MiscObject";
        shapeFile =  "ammo2";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData ammopack_dep
{
        className = "MiscObject";
        shapeFile =  "ammopack";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData ammounit_remote
{
        className = "MiscObject";
        shapeFile =  "ammounit_remote";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData bridge_dep
{
        className = "MiscObject";
        shapeFile =  "bridge";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData bullet
{
        className = "MiscObject";
        shapeFile =  "bullet";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData chaingun_dep
{
        className = "MiscObject";
        shapeFile =  "chaingun";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData dirarrows
{
        className = "MiscObject";
        shapeFile =  "dirarrows";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData disc
{
        className = "MiscObject";
        shapeFile =  "disc";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData discammo_dep
{
        className = "MiscObject";
        shapeFile =  "discammo";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData discb
{
        className = "MiscObject";
        shapeFile =  "discb";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData endarrow
{
        className = "MiscObject";
        shapeFile =  "endarrow";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData energygun
{
        className = "MiscObject";
        shapeFile =  "energygun";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData flag
{
        className = "MiscObject";
        shapeFile =  "flag";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData flagstand_dep
{
        className = "MiscObject";
        shapeFile =  "flagstand";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData grenade_dep
{
        className = "MiscObject";
        shapeFile =  "grenade";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData grenadel
{
        className = "MiscObject";
        shapeFile =  "grenadel";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData grenammo
{
        className = "MiscObject";
        shapeFile =  "grenammo";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData invent_remote
{
        className = "MiscObject";
        shapeFile =  "invent_remote";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData jetpack
{
        className = "MiscObject";
        shapeFile =  "jetpack";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData liqcyl
{
        className = "MiscObject";
        shapeFile =  "liqcyl";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData logo
{
        className = "MiscObject";
        shapeFile =  "logo";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData mine
{
        className = "MiscObject";
        shapeFile =  "mine";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData mineammo_dep
{
        className = "MiscObject";
        shapeFile =  "mineammo";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData mortar_dep
{
        className = "MiscObject";
        shapeFile =  "mortar";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData mortarammo_dep
{
        className = "MiscObject";
        shapeFile =  "mortarammo";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData mortargun
{
        className = "MiscObject";
        shapeFile =  "mortargun";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData mortarpack
{
        className = "MiscObject";
        shapeFile =  "mortarpack";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData paint
{
        className = "MiscObject";
        shapeFile =  "paint";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData paintgun
{
        className = "MiscObject";
        shapeFile =  "paintgun";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData plasammo
{
        className = "MiscObject";
        shapeFile =  "plasammo";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData plasma
{
        className = "MiscObject";
        shapeFile =  "plasma";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData plasmabolt_dep
{
        className = "MiscObject";
        shapeFile =  "plasmabolt";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData remoteturret
{
        className = "MiscObject";
        shapeFile =  "remoteturret";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData repairgun_dep
{
        className = "MiscObject";
        shapeFile =  "repairgun";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData rocket
{
        className = "MiscObject";
        shapeFile =  "rocket";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData sensorjampack
{
        className = "MiscObject";
        shapeFile =  "sensorjampack";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData shotgun
{
        className = "MiscObject";
        shapeFile =  "shotgun";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData shotgunbolt
{
        className = "MiscObject";
        shapeFile =  "shotgunbolt";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData sniper
{
        className = "MiscObject";
        shapeFile =  "sniper";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

StaticShapeData tracer
{
        className = "MiscObject";
        shapeFile =  "tracer";
        maxDamage = 10000;
        visibleToSensor = true;
        isTranslucent = false;
        description = "--";
};

$color["White"] = "white";
$color["Blue"] = "blue";
$color["Green"] = "green";
$color["Orange"] = "orange";
$color["Purple"] = "purple";
$color["Red"] = "red";
$color["Yellow"] = "yellow";

$LightObjectColor["Flood Light White"] = "white";
$LightObjectColor["Flood Light Blue"] = "blue";
$LightObjectColor["Flood Light Green"] = "green";
$LightObjectColor["Flood Light Orange"] = "orange";
$LightObjectColor["Flood Light Purple"] = "purple";
$LightObjectColor["Flood Light Red"] = "red";
$LightObjectColor["Flood Light Yellow"] = "yellow";
$LightObjectColor["Flood Light White AutoRotate"] = "white";
$LightObjectColor["Flood Light Blue AutoRotate"] = "blue";
$LightObjectColor["Flood Light Green AutoRotate"] = "green";
$LightObjectColor["Flood Light Orange AutoRotate"] = "orange";
$LightObjectColor["Flood Light Purple AutoRotate"] = "purple";
$LightObjectColor["Flood Light Red AutoRotate"] = "red";
$LightObjectColor["Flood Light Yellow AutoRotate"] = "yellow";

$LightObjectZROT["Flood Light White"] = false;
$LightObjectZROT["Flood Light Blue"] = false;
$LightObjectZROT["Flood Light Green"] = false;
$LightObjectZROT["Flood Light Orange"] = false;
$LightObjectZROT["Flood Light Purple"] = false;
$LightObjectZROT["Flood Light Red"] = false;
$LightObjectZROT["Flood Light Yellow"] = false;
$LightObjectZROT["Flood Light White AutoRotate"] = true;
$LightObjectZROT["Flood Light Blue AutoRotate"] = true;
$LightObjectZROT["Flood Light Green AutoRotate"] = true;
$LightObjectZROT["Flood Light Orange AutoRotate"] = true;
$LightObjectZROT["Flood Light Purple AutoRotate"] = true;
$LightObjectZROT["Flood Light Red AutoRotate"] = true;
$LightObjectZROT["Flood Light Yellow AutoRotate"] = true;

$colorLaser["white"] = "whiteLaserCharge";
$colorLaser["blue"] = "blueLaserCharge";
$colorLaser["green"] = "greenLaserCharge";
$colorLaser["orange"] = "orangeLaserCharge";
$colorLaser["purple"] = "purpleLaserCharge";
$colorLaser["red"] = "redLaserCharge";
$colorLaser["yellow"] = "yellowLaserCharge";

LaserData whiteLaserCharge
{
   laserBitmapName   = "grn_blink0.bmp";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 2;

   lightRange        = 5.0;
   lightColor  = { 1, 1, 1 };

   detachFromShooter = true;
};

LaserData blueLaserCharge
{
   laserBitmapName   = "grn_blink0.bmp";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 2;

   lightRange        = 5.0;
   lightColor  = { 0, 0, 1 };

   detachFromShooter = true;
};
LaserData greenLaserCharge
{
   laserBitmapName   = "grn_blink0.bmp";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 2;

   lightRange        = 5.0;
   lightColor  = { 0, 1, 0 };

   detachFromShooter = true;
};

LaserData orangeLaserCharge
{
   laserBitmapName   = "grn_blink0.bmp";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 2;

   lightRange        = 5.0;
   lightColor  = { 0.87, 0.54, 0.3 };

   detachFromShooter = true;
};

LaserData purpleLaserCharge
{
   laserBitmapName   = "grn_blink0.bmp";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 2;

   lightRange        = 5.0;
   lightColor  = { 1, 0.2, 0.9 };

   detachFromShooter = true;
};

LaserData redLaserCharge
{
   laserBitmapName   = "grn_blink0.bmp";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 2;

   lightRange        = 5.0;
   lightColor  = { 1, 0, 0 };

   detachFromShooter = true;
};

LaserData yellowLaserCharge
{
   laserBitmapName   = "grn_blink0.bmp";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 2;

   lightRange        = 5.0;
   lightColor  = { 1, 1, 0 };

   detachFromShooter = true;
};

StaticShapeData FloodLight
{
        className = "Light";
        damageSkinData = "objectDamageSkins";
        shapeFile =  "bullet";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        side = "single";
        isTranslucent = false;
        description = "Flood Light";
	    shieldShapeName = "shield";
};

function Light::sendLaserLight(%light, %color)
{
        %clientId = %light.Owner;
        %player = Client::getOwnedObject(%clientId);
        
        %trans = GameBase::getMuzzleTransform(%light);
        %vel = Item::getVelocity(%light);

        %pos = GameBase::getPosition(%light);
        %rot = GameBase::getRotation(%light);
        
        %trans = GameBase::ReplacePosInTrans(%trans, %pos);
        %trans = GameBase::ReplaceRotInTrans(%trans, %rot);
        Projectile::spawnProjectile($colorLaser[%color],%trans,%light,%vel);
}

function Light::goThroughLoop(%light, %color)
{
    if(GameBase::isActive(%light))
        Light::sendLaserLight(%light, %color);
    schedule("Light::goThroughLoop("@%light@", "@%color@");", $colorLaser[%color].beamTime / 1.5, %light);
    if(%light.LightZROT == true)
    {
        GameBase::setRotation(%light, Vector::add(GameBase::getRotation(%light), "0 0 0.130834"));
    }
}

function Light::Activate(%light, %color)
{
    Light::goThroughLoop(%light, %color);
}

$LaserTagNoDmgBeaconRange = 30; // Meters

StaticShapeData LTSafeBeacon
{
        className = "LT_Item";
        damageSkinData = "objectDamageSkins";
        shapeFile =  "bridge";
        maxDamage = 19;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        side = "single";
        isTranslucent = false;
        description = "--";
	    shieldShapeName = "shield";
};

function LTSafeBeacon::onActivate(%this)
{
    %this.IsLTSafeBeacon = true;
}

function LTSafeBeacon::onDeactivate(%this)
{
    %this.IsLTSafeBeacon = false;
}

StaticShapeData WaterWall
{
	shapeFile = "plasmawall";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "WaterWall";
};

function WaterWall::onCollision(%this, %obj)
{
    %oPos = getBoxCenter(%obj);
    %tPos = getBoxCenter(%this);
    
    if(getWord(%oPos, 2) > getWord(%tPos, 2))
        GameBase::setPosition(%obj, Vector::add(GameBase::getPosition(%obj), "0 0 -3"));
    else
        GameBase::setPosition(%obj, Vector::add(GameBase::getPosition(%obj), "0 0 3"));
}
