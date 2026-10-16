// This is a MiniMod Plugin.
// These are the classes for the stock Tribes items.

// Classes are as Follows...

// class 0  = general stuff (ie. repair kits, flares, anything that most armors should carry.)
// class 1  = recon stuff
// class 2  = sniper stuff (weapons and ammo)
// class 3  = protective stuff (ie. shields, etc.)
// class 4  = light weapons
// class 5  = medium weapons
// class 6  = heavy weapons
// class 7  = assault weapons
// class 8  = defence weapons
// class 9  = light deployables
// class 10 = medium deployables
// class 11 = heavy deployables (ie. big sensors)
// class 12 = heavy defence deployabes (ie. big turrets)
// class 13 = special deployables (ie. air bases, etc.)[Engineer stuff]
// class 14 = support stuff (ie. Inv. Stat's, Ammo Stat's, bulk ammo, etc.)
// class 15 = repair stuff (ie. repair packs, etc.)
// class 16 = sensor stuff
// class 17 = heavy-duty sensor stuff
// class 18 = general packs
// class 19 = special packs (you may wish to manually set these, instead)
// class 20 = command packs (ie. command PDA)
// class 21 = vehicle packs
// class 22 = sniper   armor specific
// class 23 = flight   armor specific
// class 24 = light    armor specific
// class 24 = engineer armor specific
// class 25 = burster  armor specific
// class 26 = arbitor  armor specific
// class 27 = medium   armor specific
// class 28 = dragoon  armor specific
// class 29 = heavy    armor specific

// Classes 60-79 are slated for Vehicle DamageFactors
// class 60 = Scout Vehicle   (ONLY used when setting damage types)
// class 61 = LAPC  Vehicle   (ONLY used when setting damage types)
// class 62 = HAPC  Vehicle   (ONLY used when setting damage types)
// class 63 = Cloaked Scouts  (ONLY used when setting damage types)
// class 64 = Cloaked LAPCs   (ONLY used when setting damage types)
// class 65 = Cloaked HAPCs   (ONLY used when setting damage types)

// Classes 80-99 are slated for Armor DamageFactors
// class 80 = Light  Armor  DamageScale
// class 81 = Medium Armor  DamageScale
// class 82 = Heavy  Armor  DamageScale

// If you need to use a new class, E-Mail me and I'll add it to the list.
// My E-Mail addy is: Dewy@planetstarsiege.com
// It's no big deal just holler if your gonna an unknown class so I can make it known.

// Now lets put em' to use. :)

$ItemClass = 0;
$Item = TargetingLaser;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 2;
$Item = LaserRifle;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 4;
$Item = Blaster;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 4;
$Item = PlasmaGun;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 4;
$Item = Chaingun;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 4;
$Item = Disclauncher;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 4;
$Item = EnergyRifle;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 4;
$Item = GrenadeLauncher;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 9;
$Item = MineAmmo;
$qty = 3;
MiniMod::Build::Classes();

$ItemClass = 24;
$Item = Grenade;
$qty = 5;
MiniMod::Build::Classes();

$ItemClass = 27;
$Item = Grenade;
$qty = 10;
MiniMod::Build::Classes();

$ItemClass = 29;
$Item = Grenade;
$qty = 5;
MiniMod::Build::Classes();

$ItemClass = 9;
$Item = Beacon;
$qty = 3;
MiniMod::Build::Classes();

$ItemClass = 24;
$Item = BulletAmmo;
$qty = 100;
MiniMod::Build::Classes();

$ItemClass = 27;
$Item = BulletAmmo;
$qty = 150;
MiniMod::Build::Classes();

$ItemClass = 29;
$Item = BulletAmmo;
$qty = 200;
MiniMod::Build::Classes();

$ItemClass = 24;
$Item = PlasmaAmmo;
$qty = 30;
MiniMod::Build::Classes();

$ItemClass = 27;
$Item = PlasmaAmmo;
$qty = 40;
MiniMod::Build::Classes();

$ItemClass = 29;
$Item = PlasmaAmmo;
$qty = 50;
MiniMod::Build::Classes();

$ItemClass = 24;
$Item = DiscAmmo;
$qty = 15;
MiniMod::Build::Classes();

$ItemClass = 27;
$Item = DiscAmmo;
$qty = 20;
MiniMod::Build::Classes();

$ItemClass = 29;
$Item = DiscAmmo;
$qty = 25;
MiniMod::Build::Classes();

$ItemClass = 24;
$Item = GrenadeAmmo;
$qty = 10;
MiniMod::Build::Classes();

$ItemClass = 27;
$Item = GrenadeAmmo;
$qty = 15;
MiniMod::Build::Classes();

$ItemClass = 29;
$Item = GrenadeAmmo;
$qty = 20;
MiniMod::Build::Classes();

$ItemClass = 24;
$Item = MortarAmmo;
$qty = 10;
MiniMod::Build::Classes();

$ItemClass = 27;
$Item = MortarAmmo;
$qty = 15;
MiniMod::Build::Classes();

$ItemClass = 29;
$Item = MortarAmmo;
$qty = 20;
MiniMod::Build::Classes();

$ItemClass = 18;
$Item = EnergyPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 15;
$Item = RepairPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 3;
$Item = ShieldPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 18;
$Item = SensorJammerPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 9;
$Item = MotionSensorPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 9;
$Item = PulseSensorPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 9;
$Item = DeployableSensorJammerPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 9;
$Item = CameraPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 10;
$Item = TurretPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 18;
$Item = AmmoPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 0;
$Item = RepairKit;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 6;
$Item = Mortar;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 10;
$Item = DeployableInvPack;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 10;
$Item = DeployableAmmoPack;
$qty = 1;
MiniMod::Build::Classes();

