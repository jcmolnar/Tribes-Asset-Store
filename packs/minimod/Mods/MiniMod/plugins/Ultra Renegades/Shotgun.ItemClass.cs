// This is a MiniMod plugin
// This is the Shotgun From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.

$ItemClass = 4;
$Item = Shotgun;
$qty = 1;
MiniMod::Build::Classes();

$ItemClass = 4;
$Item = ShotgunShells;
$qty = 20;
MiniMod::Build::Classes();

$ItemClass = 5;
$Item = ShotgunShells;
$qty = 40;
MiniMod::Build::Classes();

$ItemClass = 6;
$Item = ShotgunShells;
$qty = 60;
MiniMod::Build::Classes();

// Now setup the Damage Classes.

$DamageClass = 0;
$WeaponDamageType = $ShotgunDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 60;
$WeaponDamageType = $ShotgunDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 61;
$WeaponDamageType = $ShotgunDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 62;
$WeaponDamageType = $ShotgunDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 63;
$WeaponDamageType = $ShotgunDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 64;
$WeaponDamageType = $ShotgunDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();

$DamageClass = 65;
$WeaponDamageType = $ShotgunDamageType;
$value = 1.0;
MiniMod::Build::Damage::Classes();



