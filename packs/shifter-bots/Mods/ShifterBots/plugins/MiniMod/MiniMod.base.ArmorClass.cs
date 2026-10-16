// This is a MiniMod Plugin.
// These are the classes for the stock Tribes Armors and Vehicles.
// Here you'll find that Both ItemClassing and DamageClassing may
// be refferenced by any ItemClass.cs and DamageClass.cs file(s).

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

// Classes 60-79 are slated for Vehicle DamageFactors (ONLY used when setting damage types)
// class 60 = Scout Vehicle
// class 61 = LAPC  Vehicle
// class 62 = HAPC  Vehicle
// class 63 = Cloaked Scouts
// class 64 = Cloaked LAPCs
// class 65 = Cloaked HAPCs

// Classes 80-99 are slated for Armor DamageFactors (ONLY used when setting damage types)
// class 80 = Light  Armor  DamageScale
// class 81 = Medium Armor  DamageScale
// class 82 = Heavy  Armor  DamageScale

// If you need to use any new class(es), E-Mail me and I'll add it to the list. :)
// My E-Mail addy is: Dewy@planetstarsiege.com
// It's no big deal just holler if your gonna an unknown class so I can make it known.
// Thanks. :)

// Now lets put em' to use. :)

// Light Armor

$ArmorClass = 0;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 0;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 0;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 0;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 0;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 2;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 2;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 3;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 3;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 3;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 3;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 3;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 4;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 4;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 4;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 4;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 4;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 5;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 5;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 5;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 6;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 7;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 7;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 7;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 8;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 9;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 9;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 9;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 9;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 9;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 10;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 10;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 10;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 11;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 12;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 14;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 14;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 14;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 15;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 15;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 15;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 15;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 15;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 16;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 16;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 16;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 17;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 17;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 17;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 18;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 18;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 18;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 18;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 18;
$Armor = harmor;
MiniMod::Include::Class();

$ArmorClass = 21;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 21;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 24;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 24;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 27;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 27;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 29;
$Armor = harmor;
MiniMod::Include::Class();

// The following classes are for setting the $DamageScale variable Vehicles ONLY.

$ArmorClass = 60;
$Armor = Scout; // The Vehicle NOT the "Scout Armor" :P
MiniMod::Include::Class();

$ArmorClass = 61;
$Armor = LAPC;
MiniMod::Include::Class();

$ArmorClass = 62;
$Armor = HAPC;
MiniMod::Include::Class();

// The following classes are for setting the $DamageScale variable Armors ONLY.

$ArmorClass = 80;
$Armor = larmor;
MiniMod::Include::Class();

$ArmorClass = 80;
$Armor = lfemale;
MiniMod::Include::Class();

$ArmorClass = 81;
$Armor = marmor;
MiniMod::Include::Class();

$ArmorClass = 81;
$Armor = mfemale;
MiniMod::Include::Class();

$ArmorClass = 82;
$Armor = harmor;
MiniMod::Include::Class();

// Setting Damage Scales

$DamageClass = 80;
$WeaponDamageType = $LandingDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $ImpactDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $CrushDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $BulletDamageType;
$value = 1.2;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $PlasmaDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $EnergyDamageType;
$value = 1.3;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $ExplosionDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $MissileDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $DebrisDamageType;
$value = 1.2;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $ShrapnelDamageType;
$value = 1.2;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $LaserDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $MortarDamageType;
$value = 1.3;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $BlasterDamageType;
$value = 1.3;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $ElectricityDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 80;
$WeaponDamageType = $MineDamageType;
$value = 1.2;
MiniMod::Build::Damage::Classes();



