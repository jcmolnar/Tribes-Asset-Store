
$BulletDmgType10 = 45; //Shotgun slug
$BulletDmgType11 = 46; //Turret bullet
$BulletDmgType12 = 47; //sequential bullet damage types
$BulletDmgType13 = 48; //sequential bullet damage types
$BulletDmgType14 = 49; //sequential bullet damage types
$BulletDmgType15 = 50; //sequential bullet damage types
$BulletDmgType16 = 51; //sequential bullet damage types
$BulletDmgType17 = 52; //sequential bullet damage types
$BulletDmgType18 = 53; //sequential bullet damage types
$BulletDmgType19 = 54; //sequential bullet damage types
$BulletDmgType20 = 55; //sequential bullet damage types

// Shotgun slug

$DamageScale[hlarmor, $BulletDmgType10] = 1.0;
$DamageScale[hlfemale, $BulletDmgType10] = 1.0;
$DamageScale[larmor, $BulletDmgType10] = 1.0;
$DamageScale[lfemale, $BulletDmgType10] = 1.0;
$DamageScale[earmor, $BulletDmgType10] = 1.0;
$DamageScale[efemale, $BulletDmgType10] = 1.0;
$DamageScale[marmor, $BulletDmgType10] = 1.0;
$DamageScale[mfemale, $BulletDmgType10] = 1.0;
$DamageScale[harmor, $BulletDmgType10] = 1.0;
$DamageScale[uharmor, $BulletDmgType10] = 1.0;
$DamageScale[Scout, $BulletDmgType10] = 2.0;
$DamageScale[LAPC, $BulletDmgType10] = 2.0;
$DamageScale[HAPC, $BulletDmgType10] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType10] = 2.0;
$DoorScale[$BulletDmgType10] = 3; //damage done to a door

$DamageDescription[$BulletDmgType10] = "Shotgun Slug";

$deathMsg[$BulletDmgType10, 0]      = "%1 replaces %2's brain with a lead slug.";
$deathMsg[$BulletDmgType10, 1]      = "%1 splatters %2 with a lead slug.";
$deathMsg[$BulletDmgType10, 2]      = "%1 knocks %2 back with a shotgun slug.";
$deathMsg[$BulletDmgType10, 3]      = "%1 pounded %2 with a heavy slug.";

// Turret round

$DamageScale[hlarmor, $BulletDmgType11] = 1.0;
$DamageScale[hlfemale, $BulletDmgType11] = 1.0;
$DamageScale[larmor, $BulletDmgType11] = 1.0;
$DamageScale[lfemale, $BulletDmgType11] = 1.0;
$DamageScale[earmor, $BulletDmgType11] = 1.0;
$DamageScale[efemale, $BulletDmgType11] = 1.0;
$DamageScale[marmor, $BulletDmgType11] = 1.0;
$DamageScale[mfemale, $BulletDmgType11] = 1.0;
$DamageScale[harmor, $BulletDmgType11] = 1.0;
$DamageScale[uharmor, $BulletDmgType11] = 1.0;
$DamageScale[Scout, $BulletDmgType11] = 1.0;
$DamageScale[LAPC, $BulletDmgType11] = 1.0;
$DamageScale[HAPC, $BulletDmgType11] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType11] = 2.0;
$DoorScale[$BulletDmgType11] = 2.0; //damage done to a door

$DamageDescription[$BulletDmgType11] = "Turret bullet";

$deathMsg[$BulletDmgType11, 0]      = "%2 found %1's turret.";
$deathMsg[$BulletDmgType11, 1]      = "%2 lost to a duel with %1's turret.";
$deathMsg[$BulletDmgType11, 2]      = "%2 had a bad experience with %1's turret.";
$deathMsg[$BulletDmgType11, 3]      = "%2 thought %1's turret was inanimate.";

// OICW round

$DamageScale[hlarmor, $BulletDmgType12] = 1.0;
$DamageScale[hlfemale, $BulletDmgType12] = 1.0;
$DamageScale[larmor, $BulletDmgType12] = 1.0;
$DamageScale[lfemale, $BulletDmgType12] = 1.0;
$DamageScale[earmor, $BulletDmgType12] = 1.0;
$DamageScale[efemale, $BulletDmgType12] = 1.0;
$DamageScale[marmor, $BulletDmgType12] = 1.0;
$DamageScale[mfemale, $BulletDmgType12] = 1.0;
$DamageScale[harmor, $BulletDmgType12] = 1.0;
$DamageScale[uharmor, $BulletDmgType12] = 1.0;
$DamageScale[Scout, $BulletDmgType12] = 1.0;
$DamageScale[LAPC, $BulletDmgType12] = 1.0;
$DamageScale[HAPC, $BulletDmgType12] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType12] = 2.0;
$DoorScale[$BulletDmgType12] = 0.25; //damage done to a door

$DamageDescription[$BulletDmgType12] = "OICW bullet";

$deathMsg[$BulletDmgType12, 0]      = "%2 got caught by %1's OICW spray.";
$deathMsg[$BulletDmgType12, 1]      = "%1 chopped %2 into bite size chunks with his OICW.";
$deathMsg[$BulletDmgType12, 2]      = "%2 was pureed by %1's OICW.";
$deathMsg[$BulletDmgType12, 3]      = "%2 was belittled by %1's OICW.";

// OICW Grenade

$DamageScale[hlarmor, $BulletDmgType13] = 0.35;
$DamageScale[hlfemale, $BulletDmgType13] = 0.35;
$DamageScale[larmor, $BulletDmgType13] = 0.35;
$DamageScale[lfemale, $BulletDmgType13] = 0.35;
$DamageScale[earmor, $BulletDmgType13] = 0.38;
$DamageScale[efemale, $BulletDmgType13] = 0.38;
$DamageScale[marmor, $BulletDmgType13] = 0.38;
$DamageScale[mfemale, $BulletDmgType13] = 0.38;
$DamageScale[harmor, $BulletDmgType13] = 0.35;
$DamageScale[uharmor, $BulletDmgType13] = 0.35;
$DamageScale[Scout, $BulletDmgType13] = 50.0;
$DamageScale[LAPC, $BulletDmgType13] = 50.0;
$DamageScale[HAPC, $BulletDmgType13] = 50.0;
$DamageScale[AttackDrone, $BulletDmgType13] = 2.0;
$DoorScale[$BulletDmgType13] = 10; //damage done to a door

$DamageDescription[$BulletDmgType13] = "OICW Grenade";

$deathMsg[$BulletDmgType13, 0]      = "%2 was disintegrated by %1's OICW Grenade.";
$deathMsg[$BulletDmgType13, 1]      = "%1 shoved an OICW grenade into %2's pants.";
$deathMsg[$BulletDmgType13, 2]      = "%2 was tagged by %1's OICW grenade.";
$deathMsg[$BulletDmgType13, 3]      = "%2 was turned to kibble by %1's OICW grenade.";

// Remington round

$DamageScale[hlarmor, $BulletDmgType14] = 1.0;
$DamageScale[hlfemale, $BulletDmgType14] = 1.0;
$DamageScale[larmor, $BulletDmgType14] = 1.0;
$DamageScale[lfemale, $BulletDmgType14] = 1.0;
$DamageScale[earmor, $BulletDmgType14] = 1.0;
$DamageScale[efemale, $BulletDmgType14] = 1.0;
$DamageScale[marmor, $BulletDmgType14] = 1.0;
$DamageScale[mfemale, $BulletDmgType14] = 1.0;
$DamageScale[harmor, $BulletDmgType14] = 1.0;
$DamageScale[uharmor, $BulletDmgType14] = 1.0;
$DamageScale[Scout, $BulletDmgType14] = 1.0;
$DamageScale[LAPC, $BulletDmgType14] = 1.0;
$DamageScale[HAPC, $BulletDmgType14] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType14] = 2.0;
$DoorScale[$BulletDmgType14] = 0.5; //damage done to a door

$DamageDescription[$BulletDmgType12] = "Remington bullet";

$deathMsg[$BulletDmgType14, 0]      = "%2 is leaking from %1's Remington hole.";
$deathMsg[$BulletDmgType14, 1]      = "%1 gave %2 a free Remington nipple piercing.";
$deathMsg[$BulletDmgType14, 2]      = "%2 thinks %1's Remington bullet tastes funny.";
$deathMsg[$BulletDmgType14, 3]      = "%2 coughed up %1's Remington round.";

// Glock round

$DamageScale[hlarmor, $BulletDmgType15] = 1.0;
$DamageScale[hlfemale, $BulletDmgType15] = 1.0;
$DamageScale[larmor, $BulletDmgType15] = 1.0;
$DamageScale[lfemale, $BulletDmgType15] = 1.0;
$DamageScale[earmor, $BulletDmgType15] = 1.0;
$DamageScale[efemale, $BulletDmgType15] = 1.0;
$DamageScale[marmor, $BulletDmgType15] = 1.0;
$DamageScale[mfemale, $BulletDmgType15] = 1.0;
$DamageScale[harmor, $BulletDmgType15] = 1.0;
$DamageScale[uharmor, $BulletDmgType15] = 1.0;
$DamageScale[Scout, $BulletDmgType15] = 1.0;
$DamageScale[LAPC, $BulletDmgType15] = 1.0;
$DamageScale[HAPC, $BulletDmgType15] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType14] = 2.0;
$DoorScale[$BulletDmgType14] = 0.25; //damage done to a door

$DamageDescription[$BulletDmgType12] = "Glock bullet";

$deathMsg[$BulletDmgType15, 0]      = "%2 got clocked by %1's Glock.";
$deathMsg[$BulletDmgType15, 1]      = "%1 gave %2 a tingly sensation with %3 glock.";
$deathMsg[$BulletDmgType15, 2]      = "%2 was bled out by %1's glock.";
$deathMsg[$BulletDmgType15, 3]      = "%2 has a nice 9mm hole from %1.";

// Ruger round

$DamageScale[hlarmor, $BulletDmgType16] = 1.0;
$DamageScale[hlfemale, $BulletDmgType16] = 1.0;
$DamageScale[larmor, $BulletDmgType16] = 1.0;
$DamageScale[lfemale, $BulletDmgType16] = 1.0;
$DamageScale[earmor, $BulletDmgType16] = 1.0;
$DamageScale[efemale, $BulletDmgType16] = 1.0;
$DamageScale[marmor, $BulletDmgType16] = 1.0;
$DamageScale[mfemale, $BulletDmgType16] = 1.0;
$DamageScale[harmor, $BulletDmgType16] = 1.0;
$DamageScale[uharmor, $BulletDmgType16] = 1.0;
$DamageScale[Scout, $BulletDmgType16] = 1.0;
$DamageScale[LAPC, $BulletDmgType16] = 1.0;
$DamageScale[HAPC, $BulletDmgType16] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType16] = 2.0;
$DoorScale[$BulletDmgType16] = 0.25; //damage done to a door

$DamageDescription[$BulletDmgType16] = "Ruger bullet";

$deathMsg[$BulletDmgType16, 0]      = "%2 was brained by %1's Ruger.";
$deathMsg[$BulletDmgType16, 1]      = "%1 gave %2 a new Ruger .22 shaped nostril.";
$deathMsg[$BulletDmgType16, 2]      = "%2 was popped by %1's Ruger.";
$deathMsg[$BulletDmgType16, 3]      = "%2 found %1's ruger to be weak but deadly.";

// Tommy Gun round

$DamageScale[hlarmor, $BulletDmgType17] = 1.0;
$DamageScale[hlfemale, $BulletDmgType17] = 1.0;
$DamageScale[larmor, $BulletDmgType17] = 1.0;
$DamageScale[lfemale, $BulletDmgType17] = 1.0;
$DamageScale[earmor, $BulletDmgType17] = 1.0;
$DamageScale[efemale, $BulletDmgType17] = 1.0;
$DamageScale[marmor, $BulletDmgType17] = 1.0;
$DamageScale[mfemale, $BulletDmgType17] = 1.0;
$DamageScale[harmor, $BulletDmgType17] = 1.0;
$DamageScale[uharmor, $BulletDmgType17] = 1.0;
$DamageScale[Scout, $BulletDmgType17] = 1.0;
$DamageScale[LAPC, $BulletDmgType17] = 1.0;
$DamageScale[HAPC, $BulletDmgType17] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType17] = 2.0;
$DoorScale[$BulletDmgType17] = 0.25; //damage done to a door

$DamageDescription[$BulletDmgType17] = "Tommy Gun";

$deathMsg[$BulletDmgType17, 0]      = "%2 disrespected %1's Tommy gun.";
$deathMsg[$BulletDmgType17, 1]      = "%1 whacked %2 with his Tommy gun";
$deathMsg[$BulletDmgType17, 2]      = "%2 disrespected %1's family and was whacked.";
$deathMsg[$BulletDmgType17, 3]      = "%1 played a game of Al Capone with %2.";

// Flash Grenade

$DamageScale[hlarmor, $BulletDmgType18] = 1.0;
$DamageScale[hlfemale, $BulletDmgType18] = 1.0;
$DamageScale[larmor, $BulletDmgType18] = 1.0;
$DamageScale[lfemale, $BulletDmgType18] = 1.0;
$DamageScale[earmor, $BulletDmgType18] = 1.0;
$DamageScale[efemale, $BulletDmgType18] = 1.0;
$DamageScale[marmor, $BulletDmgType18] = 1.0;
$DamageScale[mfemale, $BulletDmgType18] = 1.0;
$DamageScale[harmor, $BulletDmgType18] = 1.0;
$DamageScale[uharmor, $BulletDmgType18] = 1.0;
$DamageScale[Scout, $BulletDmgType18] = 1.0;
$DamageScale[LAPC, $BulletDmgType18] = 1.0;
$DamageScale[HAPC, $BulletDmgType18] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType18] = 2.0;
$DoorScale[$BulletDmgType18] = 200.0; //damage done to a door

$DamageDescription[$BulletDmgType18] = "Flash Grenade";

$deathMsg[$BulletDmgType18, 0]      = "%2 was flashed by %1 and died of a heart attack.";
$deathMsg[$BulletDmgType18, 1]      = "%2 was blinded by %1's light";
$deathMsg[$BulletDmgType18, 2]      = "%2 walked towards %1's light.";
$deathMsg[$BulletDmgType18, 3]      = "%2 can see no evil thanks to %1.";

// Sticky Bomb

$DamageScale[hlarmor, $BulletDmgType19] = 1.0;
$DamageScale[hlfemale, $BulletDmgType19] = 1.0;
$DamageScale[larmor, $BulletDmgType19] = 1.0;
$DamageScale[lfemale, $BulletDmgType19] = 1.0;
$DamageScale[earmor, $BulletDmgType19] = 1.0;
$DamageScale[efemale, $BulletDmgType19] = 1.0;
$DamageScale[marmor, $BulletDmgType19] = 1.0;
$DamageScale[mfemale, $BulletDmgType19] = 1.0;
$DamageScale[harmor, $BulletDmgType19] = 1.0;
$DamageScale[uharmor, $BulletDmgType19] = 1.0;
$DamageScale[Scout, $BulletDmgType19] = 10.0;
$DamageScale[LAPC, $BulletDmgType19] = 10.0;
$DamageScale[HAPC, $BulletDmgType19] = 10.0;
$DamageScale[AttackDrone, $BulletDmgType19] = 2.0;
$DoorScale[$BulletDmgType19] = 50.0; //damage done to a door

$DamageDescription[$BulletDmgType19] = "Sticky Bomb";

$deathMsg[$BulletDmgType19, 0]      = "'I am rubber, you are glue.' says %1 to %2.";
$deathMsg[$BulletDmgType19, 1]      = "%1 put %2 in a sticky situation.";
$deathMsg[$BulletDmgType19, 2]      = "%2 tasted %1's sticky monkey.";
$deathMsg[$BulletDmgType19, 3]      = "'Say hello to my little friend!' says %1 to %2.";

// Rock

$DamageScale[hlarmor, $BulletDmgType20] = 1.0;
$DamageScale[hlfemale, $BulletDmgType20] = 1.0;
$DamageScale[larmor, $BulletDmgType20] = 1.0;
$DamageScale[lfemale, $BulletDmgType20] = 1.0;
$DamageScale[earmor, $BulletDmgType20] = 1.0;
$DamageScale[efemale, $BulletDmgType20] = 1.0;
$DamageScale[marmor, $BulletDmgType20] = 1.0;
$DamageScale[mfemale, $BulletDmgType20] = 1.0;
$DamageScale[harmor, $BulletDmgType20] = 1.0;
$DamageScale[uharmor, $BulletDmgType20] = 1.0;
$DamageScale[Scout, $BulletDmgType20] = 10.0;
$DamageScale[LAPC, $BulletDmgType20] = 10.0;
$DamageScale[HAPC, $BulletDmgType20] = 10.0;
$DamageScale[AttackDrone, $BulletDmgType20] = 2.0;
$DoorScale[$BulletDmgType20] = 50.0; //damage done to a door

$DamageDescription[$BulletDmgType20] = "Rock";

$deathMsg[$BulletDmgType20, 0]      = "'%1 got %2 stoned.";
$deathMsg[$BulletDmgType20, 1]      = "%2 was stoned by %1.";
$deathMsg[$BulletDmgType20, 2]      = "%2 was rocked by %1.";
$deathMsg[$BulletDmgType20, 3]      = "%1 rocked %2's world.";

// Belly Gun

$DamageScale[hlarmor, $BulletDmgType21] = 1.0;
$DamageScale[hlfemale, $BulletDmgType21] = 1.0;
$DamageScale[larmor, $BulletDmgType21] = 1.0;
$DamageScale[lfemale, $BulletDmgType21] = 1.0;
$DamageScale[earmor, $BulletDmgType21] = 1.0;
$DamageScale[efemale, $BulletDmgType21] = 1.0;
$DamageScale[marmor, $BulletDmgType21] = 1.0;
$DamageScale[mfemale, $BulletDmgType21] = 1.0;
$DamageScale[harmor, $BulletDmgType21] = 1.0;
$DamageScale[uharmor, $BulletDmgType21] = 1.0;
$DamageScale[Scout, $BulletDmgType21] = 5.0;
$DamageScale[LAPC, $BulletDmgType21] = 5.0;
$DamageScale[HAPC, $BulletDmgType21] = 5.0;
$DamageScale[AttackDrone, $BulletDmgType21] = 2.0;
$DoorScale[$BulletDmgType21] = 50.0; //damage done to a door

$DamageDescription[$BulletDmgType21] = "Belly Gun";

$deathMsg[$BulletDmgType21, 0]      = "%2 rubbed %1's belly gun.";
$deathMsg[$BulletDmgType21, 1]      = "%2 couldn't run from %1's belly gun.";
$deathMsg[$BulletDmgType21, 2]      = "%2 was a victim of %1's belly gun.";
$deathMsg[$BulletDmgType21, 3]      = "%2 met %1's air superiority.";

// AK74

$DamageScale[hlarmor, $BulletDmgType22] = 1.0;
$DamageScale[hlfemale, $BulletDmgType22] = 1.0;
$DamageScale[larmor, $BulletDmgType22] = 1.0;
$DamageScale[lfemale, $BulletDmgType22] = 1.0;
$DamageScale[earmor, $BulletDmgType22] = 1.0;
$DamageScale[efemale, $BulletDmgType22] = 1.0;
$DamageScale[marmor, $BulletDmgType22] = 1.0;
$DamageScale[mfemale, $BulletDmgType22] = 1.0;
$DamageScale[harmor, $BulletDmgType22] = 1.0;
$DamageScale[uharmor, $BulletDmgType22] = 1.0;
$DamageScale[Scout, $BulletDmgType22] = 1.0;
$DamageScale[LAPC, $BulletDmgType22] = 1.0;
$DamageScale[HAPC, $BulletDmgType22] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType22] = 2.0;
$DoorScale[$BulletDmgType22] = 2.0; //damage done to a door

$DamageDescription[$BulletDmgType22] = "Klashnikov";

$deathMsg[$BulletDmgType22, 0]      = "%2 clashed with %1's klashnikov.";
$deathMsg[$BulletDmgType22, 1]      = "%1's fed %2 some AK74 goodness.";
$deathMsg[$BulletDmgType22, 2]      = "%2 was at the wrong end of %1's AK74.";
$deathMsg[$BulletDmgType22, 3]      = "%1 threw some AK lead at %2.";

// Taurus 44 magnum

$DamageScale[hlarmor, $BulletDmgType23] = 1.0;
$DamageScale[hlfemale, $BulletDmgType23] = 1.0;
$DamageScale[larmor, $BulletDmgType23] = 1.0;
$DamageScale[lfemale, $BulletDmgType23] = 1.0;
$DamageScale[earmor, $BulletDmgType23] = 1.0;
$DamageScale[efemale, $BulletDmgType23] = 1.0;
$DamageScale[marmor, $BulletDmgType23] = 1.0;
$DamageScale[mfemale, $BulletDmgType23] = 1.0;
$DamageScale[harmor, $BulletDmgType23] = 1.0;
$DamageScale[uharmor, $BulletDmgType23] = 1.0;
$DamageScale[Scout, $BulletDmgType23] = 1.0;
$DamageScale[LAPC, $BulletDmgType23] = 1.0;
$DamageScale[HAPC, $BulletDmgType23] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType23] = 2.0;
$DoorScale[$BulletDmgType22] = 3.0; //damage done to a door

$DamageDescription[$BulletDmgType23] = "Taurus";

$deathMsg[$BulletDmgType23, 0]      = "%1 found the quickest way to %2's heart with a Taurus.";
$deathMsg[$BulletDmgType23, 1]      = "%2 lost a game of Russian roulette with %1's Taurus.";
$deathMsg[$BulletDmgType23, 2]      = "%2 was snubbed by %1's Taurus.";
$deathMsg[$BulletDmgType23, 3]      = "%1 blasted a big hole in %2 with a Taurus round.";

// M177 Anti-tank machinegun

$DamageScale[hlarmor, $BulletDmgType24] = 0.35;
$DamageScale[hlfemale, $BulletDmgType24] = 0.35;
$DamageScale[larmor, $BulletDmgType24] = 0.35;
$DamageScale[lfemale, $BulletDmgType24] = 0.35;
$DamageScale[earmor, $BulletDmgType24] = 0.35;
$DamageScale[efemale, $BulletDmgType24] = 0.35;
$DamageScale[marmor, $BulletDmgType24] = 0.35;
$DamageScale[mfemale, $BulletDmgType24] = 0.35;
$DamageScale[harmor, $BulletDmgType24] = 0.5;
$DamageScale[uharmor, $BulletDmgType24] = 0.5;
$DamageScale[Scout, $BulletDmgType24] = 5.5;
$DamageScale[LAPC, $BulletDmgType24] = 5.5;
$DamageScale[HAPC, $BulletDmgType24] = 5.5;
$DamageScale[AttackDrone, $BulletDmgType24] = 2.0;
$DoorScale[$BulletDmgType24] = 12.0; //damage done to a door

$DamageDescription[$BulletDmgType24] = "M177 HMG";

$deathMsg[$BulletDmgType24, 0]      = "%2 was cut to pieces by %1's M177.";
$deathMsg[$BulletDmgType24, 1]      = "%1 gave %2 some M177 poisoning.";
$deathMsg[$BulletDmgType24, 2]      = "%2 had no chance to escape %1's M177.";
$deathMsg[$BulletDmgType24, 3]      = "%1 used his M177 as a cookie cutter on %2.";

// Ingram MAC10

$DamageScale[hlarmor, $BulletDmgType25] = 1.0;
$DamageScale[hlfemale, $BulletDmgType25] = 1.0;
$DamageScale[larmor, $BulletDmgType25] = 1.0;
$DamageScale[lfemale, $BulletDmgType25] = 1.0;
$DamageScale[earmor, $BulletDmgType25] = 1.0;
$DamageScale[efemale, $BulletDmgType25] = 1.0;
$DamageScale[marmor, $BulletDmgType25] = 1.0;
$DamageScale[mfemale, $BulletDmgType25] = 1.0;
$DamageScale[harmor, $BulletDmgType25] = 1.0;
$DamageScale[uharmor, $BulletDmgType25] = 1.0;
$DamageScale[Scout, $BulletDmgType25] = 1.0;
$DamageScale[LAPC, $BulletDmgType25] = 1.0;
$DamageScale[HAPC, $BulletDmgType25] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType25] = 2.0;
$DoorScale[$BulletDmgType25] = 0.5; //damage done to a door

$DamageDescription[$BulletDmgType25] = "Ingram";

$deathMsg[$BulletDmgType25, 0]      = "%2 was sprayed by %1's MAC10.";
$deathMsg[$BulletDmgType25, 1]      = "%1 punched a few dozen holes in %2 with a MAC10.";
$deathMsg[$BulletDmgType25, 2]      = "%2 was turned to goo by %1's MAC10.";
$deathMsg[$BulletDmgType25, 3]      = "%1 gave %2 a big MAC.";

// Beretta M12 SMG

$DamageScale[hlarmor, $BulletDmgType26] = 1.0;
$DamageScale[hlfemale, $BulletDmgType26] = 1.0;
$DamageScale[larmor, $BulletDmgType26] = 1.0;
$DamageScale[lfemale, $BulletDmgType26] = 1.0;
$DamageScale[earmor, $BulletDmgType26] = 1.0;
$DamageScale[efemale, $BulletDmgType26] = 1.0;
$DamageScale[marmor, $BulletDmgType26] = 1.0;
$DamageScale[mfemale, $BulletDmgType26] = 1.0;
$DamageScale[harmor, $BulletDmgType26] = 1.0;
$DamageScale[uharmor, $BulletDmgType26] = 1.0;
$DamageScale[Scout, $BulletDmgType26] = 1.0;
$DamageScale[LAPC, $BulletDmgType26] = 1.0;
$DamageScale[HAPC, $BulletDmgType26] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType26] = 2.0;
$DoorScale[$BulletDmgType26] = 0.5; //damage done to a door

$DamageDescription[$BulletDmgType24] = "Beretta SMG";

$deathMsg[$BulletDmgType26, 0]      = "%2 was erased by %1's M12.";
$deathMsg[$BulletDmgType26, 1]      = "%1 let %2 have a close look at his M12.";
$deathMsg[$BulletDmgType26, 2]      = "%2 was spewed on by %1's M12.";
$deathMsg[$BulletDmgType26, 3]      = "%1 added a notch to his M12 thanks to %2.";

// Mini Uzi

$DamageScale[hlarmor, $BulletDmgType27] = 1.0;
$DamageScale[hlfemale, $BulletDmgType27] = 1.0;
$DamageScale[larmor, $BulletDmgType27] = 1.0;
$DamageScale[lfemale, $BulletDmgType27] = 1.0;
$DamageScale[earmor, $BulletDmgType27] = 1.0;
$DamageScale[efemale, $BulletDmgType27] = 1.0;
$DamageScale[marmor, $BulletDmgType27] = 1.0;
$DamageScale[mfemale, $BulletDmgType27] = 1.0;
$DamageScale[harmor, $BulletDmgType27] = 1.0;
$DamageScale[uharmor, $BulletDmgType27] = 1.0;
$DamageScale[Scout, $BulletDmgType27] = 1.0;
$DamageScale[LAPC, $BulletDmgType27] = 1.0;
$DamageScale[HAPC, $BulletDmgType27] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType27] = 2.0;
$DoorScale[$BulletDmgType27] = 0.5; //damage done to a door

$DamageDescription[$BulletDmgType27] = "Mini Uzi";

$deathMsg[$BulletDmgType27, 0]      = "%1 showed %2 his mighty mini.";
$deathMsg[$BulletDmgType27, 1]      = "%1 actually got a kill on %2 with a Mini Uzi.";
$deathMsg[$BulletDmgType27, 2]      = "%2 was plastered by %1's mini uzi.";
$deathMsg[$BulletDmgType27, 3]      = "%2 was a victim of %1's 20 bullets .";

// Famas

$DamageScale[hlarmor, $BulletDmgType28] = 1.0;
$DamageScale[hlfemale, $BulletDmgType28] = 1.0;
$DamageScale[larmor, $BulletDmgType28] = 1.0;
$DamageScale[lfemale, $BulletDmgType28] = 1.0;
$DamageScale[earmor, $BulletDmgType28] = 1.0;
$DamageScale[efemale, $BulletDmgType28] = 1.0;
$DamageScale[marmor, $BulletDmgType28] = 1.0;
$DamageScale[mfemale, $BulletDmgType28] = 1.0;
$DamageScale[harmor, $BulletDmgType28] = 1.0;
$DamageScale[uharmor, $BulletDmgType28] = 1.0;
$DamageScale[Scout, $BulletDmgType28] = 1.0;
$DamageScale[LAPC, $BulletDmgType28] = 1.0;
$DamageScale[HAPC, $BulletDmgType28] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType28] = 2.0;
$DoorScale[$BulletDmgType28] = 0.5; //damage done to a door

$DamageDescription[$BulletDmgType28] = "FAMAS";

$deathMsg[$BulletDmgType28, 0]      = "%1 Frenched %2 with his FA-MAS.";
$deathMsg[$BulletDmgType28, 1]      = "%1 gave %2 a large order of French Fries, FA-MAS style.";
$deathMsg[$BulletDmgType28, 2]      = "%1 made %2 surrender to his FA-MAS.";
$deathMsg[$BulletDmgType28, 3]      = "%1 gave %2 a French style whoopin'.";

// Musket

$DamageScale[hlarmor, $BulletDmgType29] = 1.0;
$DamageScale[hlfemale, $BulletDmgType29] = 1.0;
$DamageScale[larmor, $BulletDmgType29] = 1.0;
$DamageScale[lfemale, $BulletDmgType29] = 1.0;
$DamageScale[earmor, $BulletDmgType29] = 1.0;
$DamageScale[efemale, $BulletDmgType29] = 1.0;
$DamageScale[marmor, $BulletDmgType29] = 1.0;
$DamageScale[mfemale, $BulletDmgType29] = 1.0;
$DamageScale[harmor, $BulletDmgType29] = 1.0;
$DamageScale[uharmor, $BulletDmgType29] = 1.0;
$DamageScale[Scout, $BulletDmgType29] = 1.0;
$DamageScale[LAPC, $BulletDmgType29] = 1.0;
$DamageScale[HAPC, $BulletDmgType29] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType29] = 5.0;
$DoorScale[$BulletDmgType29] = 0.5; //damage done to a door

$DamageDescription[$BulletDmgType29] = "Musket";

$deathMsg[$BulletDmgType29, 0]      = "%1 involved %2 in a civil war.";
$deathMsg[$BulletDmgType29, 1]      = "%1 played George Washington with %2.";
$deathMsg[$BulletDmgType29, 2]      = "%1 insulted %2 with an obsolete musket.";
$deathMsg[$BulletDmgType29, 3]      = "%1 put a large lead ball through %2.";

// M249 SAW

$DamageScale[hlarmor, $BulletDmgType30] = 1.0;
$DamageScale[hlfemale, $BulletDmgType30] = 1.0;
$DamageScale[larmor, $BulletDmgType30] = 1.0;
$DamageScale[lfemale, $BulletDmgType30] = 1.0;
$DamageScale[earmor, $BulletDmgType30] = 1.0;
$DamageScale[efemale, $BulletDmgType30] = 1.0;
$DamageScale[marmor, $BulletDmgType30] = 1.0;
$DamageScale[mfemale, $BulletDmgType30] = 1.0;
$DamageScale[harmor, $BulletDmgType30] = 1.0;
$DamageScale[uharmor, $BulletDmgType30] = 1.0;
$DamageScale[Scout, $BulletDmgType30] = 1.0;
$DamageScale[LAPC, $BulletDmgType30] = 1.0;
$DamageScale[HAPC, $BulletDmgType30] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType30] = 5.0;
$DoorScale[$BulletDmgType30] = 0.5; //damage done to a door

$DamageDescription[$BulletDmgType30] = "M249 SAW";

$deathMsg[$BulletDmgType30, 0]      = "%2 was sawed in half by %1's M249.";
$deathMsg[$BulletDmgType30, 1]      = "%1 cut down %2 with his SAW.";
$deathMsg[$BulletDmgType30, 2]      = "%1 pummelled %2 with a bunch of M249 bullets.";
$deathMsg[$BulletDmgType30, 3]      = "%1 saw %2 get SAWed by %1's SAW.";

// M2 Heavy Machinegun

$DamageScale[hlarmor, $BulletDmgType31] = 1.0;
$DamageScale[hlfemale, $BulletDmgType31] = 1.0;
$DamageScale[larmor, $BulletDmgType31] = 1.0;
$DamageScale[lfemale, $BulletDmgType31] = 1.0;
$DamageScale[earmor, $BulletDmgType31] = 1.0;
$DamageScale[efemale, $BulletDmgType31] = 1.0;
$DamageScale[marmor, $BulletDmgType31] = 1.0;
$DamageScale[mfemale, $BulletDmgType31] = 1.0;
$DamageScale[harmor, $BulletDmgType31] = 1.0;
$DamageScale[uharmor, $BulletDmgType31] = 1.0;
$DamageScale[Scout, $BulletDmgType31] = 1.0;
$DamageScale[LAPC, $BulletDmgType31] = 0.1;
$DamageScale[HAPC, $BulletDmgType31] = 0.1;
$DamageScale[AttackDrone, $BulletDmgType31] = 1.0;
$DoorScale[$BulletDmgType31] = 4.5; //damage done to a door

$DamageDescription[$BulletDmgType31] = "Mounted MG";

$deathMsg[$BulletDmgType31, 0]      = "%2 was turned to goo from %1's mounted machinegun.";
$deathMsg[$BulletDmgType31, 1]      = "%1 is raising hell on %2 with his M2.";
$deathMsg[$BulletDmgType31, 2]      = "%1 is going Rambo on %2 with his M2.";
$deathMsg[$BulletDmgType31, 3]      = "%1 blew both of %2's legs off with his M2.";

// Helicopter MG

$DamageScale[hlarmor, $BulletDmgType32] = 1.0;
$DamageScale[hlfemale, $BulletDmgType32] = 1.0;
$DamageScale[larmor, $BulletDmgType32] = 1.0;
$DamageScale[lfemale, $BulletDmgType32] = 1.0;
$DamageScale[earmor, $BulletDmgType32] = 1.0;
$DamageScale[efemale, $BulletDmgType32] = 1.0;
$DamageScale[marmor, $BulletDmgType32] = 1.0;
$DamageScale[mfemale, $BulletDmgType32] = 1.0;
$DamageScale[harmor, $BulletDmgType32] = 1.0;
$DamageScale[uharmor, $BulletDmgType32] = 1.0;
$DamageScale[Scout, $BulletDmgType32] = 5.0;
$DamageScale[LAPC, $BulletDmgType32] = 0.1;
$DamageScale[HAPC, $BulletDmgType32] = 0.1;
$DamageScale[AttackDrone, $BulletDmgType32] = 5.0;
$DoorScale[$BulletDmgType32] = 10.0; //damage done to a door

$DamageDescription[$BulletDmgType32] = "Huey MG";

$deathMsg[$BulletDmgType32, 0]      = "%1 is raining down hell upon %2.";
$deathMsg[$BulletDmgType32, 1]      = "%2 meets the wrath of the %1's air force.";
$deathMsg[$BulletDmgType32, 2]      = "%1 cut through %2 with a chopper's 60 mm.";
$deathMsg[$BulletDmgType32, 3]      = "%2 exploded from %1's 60 mm. machinegun.";

// Flak Cannon Flak

$DamageScale[hlarmor, $BulletDmgType33] = 0.5;
$DamageScale[hlfemale, $BulletDmgType33] = 0.5;
$DamageScale[larmor, $BulletDmgType33] = 0.5;
$DamageScale[lfemale, $BulletDmgType33] = 0.5;
$DamageScale[earmor, $BulletDmgType33] = 0.5;
$DamageScale[efemale, $BulletDmgType33] = 0.5;
$DamageScale[marmor, $BulletDmgType33] = 0.5;
$DamageScale[mfemale, $BulletDmgType33] = 0.5;
$DamageScale[harmor, $BulletDmgType33] = 0.5;
$DamageScale[uharmor, $BulletDmgType33] = 0.5;
$DamageScale[Scout, $BulletDmgType33] = 50.0;
$DamageScale[LAPC, $BulletDmgType33] = 40.0;
$DamageScale[HAPC, $BulletDmgType33] = 40.0;
$DamageScale[AttackDrone, $BulletDmgType33] = 5.0;
$DoorScale[$BulletDmgType33] = 50.0; //damage done to a door

$DamageDescription[$BulletDmgType33] = "Flak Burst";

$deathMsg[$BulletDmgType33, 0]      = "%2 was flakked to death.";
$deathMsg[$BulletDmgType33, 1]      = "%2 was cut to ribbons by flak.";
$deathMsg[$BulletDmgType33, 2]      = "%2 shouldn't have taken flight around all that flak.";
$deathMsg[$BulletDmgType33, 3]      = "%2 is missing a few arms and legs from flak.";

// Metal fragment from grenades and claymores

$DamageScale[hlarmor, $BulletDmgType34] = 1.0;
$DamageScale[hlfemale, $BulletDmgType34] = 1.0;
$DamageScale[larmor, $BulletDmgType34] = 1.0;
$DamageScale[lfemale, $BulletDmgType34] = 1.0;
$DamageScale[earmor, $BulletDmgType34] = 1.0;
$DamageScale[efemale, $BulletDmgType34] = 1.0;
$DamageScale[marmor, $BulletDmgType34] = 1.0;
$DamageScale[mfemale, $BulletDmgType34] = 1.0;
$DamageScale[harmor, $BulletDmgType34] = 1.0;
$DamageScale[uharmor, $BulletDmgType34] = 1.0;
$DamageScale[Scout, $BulletDmgType34] = 20.0;
$DamageScale[LAPC, $BulletDmgType34] = 20.0;
$DamageScale[HAPC, $BulletDmgType34] = 20.0;
$DamageScale[AttackDrone, $BulletDmgType34] = 15.0;
$DoorScale[$BulletDmgType34] = 1.0; //damage done to a door

$DamageDescription[$BulletDmgType34] = "Metal fragment";

$deathMsg[$BulletDmgType34, 0]      = "%2 got a metal fragment stuck between his eyes.";
$deathMsg[$BulletDmgType34, 1]      = "%2 lost a limb to metal fragments.";
$deathMsg[$BulletDmgType34, 2]      = "%2 has shrapnel lodged in his brain.";
$deathMsg[$BulletDmgType34, 3]      = "%2 had an unlucky encounter with metal fragments.";

// Lance

$DamageScale[hlarmor, $BulletDmgType35] = 1.0;
$DamageScale[hlfemale, $BulletDmgType35] = 1.0;
$DamageScale[larmor, $BulletDmgType35] = 1.0;
$DamageScale[lfemale, $BulletDmgType35] = 1.0;
$DamageScale[earmor, $BulletDmgType35] = 1.0;
$DamageScale[efemale, $BulletDmgType35] = 1.0;
$DamageScale[marmor, $BulletDmgType35] = 1.0;
$DamageScale[mfemale, $BulletDmgType35] = 1.0;
$DamageScale[harmor, $BulletDmgType35] = 1.0;
$DamageScale[uharmor, $BulletDmgType35] = 1.0;
$DamageScale[Scout, $BulletDmgType35] = 20.0;
$DamageScale[LAPC, $BulletDmgType35] = 20.0;
$DamageScale[HAPC, $BulletDmgType35] = 20.0;
$DamageScale[AttackDrone, $BulletDmgType35] = 15.0;
$DoorScale[$BulletDmgType35] = 5.0; //damage done to a door

$DamageDescription[$BulletDmgType35] = "Lance";

$deathMsg[$BulletDmgType35, 0]      = "%2 was skewered by %1's lance.";
$deathMsg[$BulletDmgType35, 1]      = "%2 was cut up by %1.";
$deathMsg[$BulletDmgType35, 2]      = "%2 is %1's shishkabob.";
$deathMsg[$BulletDmgType35, 3]      = "%2 was run through by %1.";


// POINTS TO BE SCORED FOR EACH KILL


// You must have a score for every damage type or scores wont work
// So lets start with a score of 0 for all items for now -- Deadtaco

$ScorePoints[-1] = 10;
$ScorePoints[0] = -1;
$ScorePoints[1] = 10;
$ScorePoints[2] = 0;
$ScorePoints[3] = 0;
$ScorePoints[4] = 0;
$ScorePoints[5] = 0;
$ScorePoints[6] = 0;
$ScorePoints[7] = 0;
$ScorePoints[8] = 0;
$ScorePoints[9] = 0;
$ScorePoints[10] = 0;
$ScorePoints[11] = 0;
$ScorePoints[12] = 0;
$ScorePoints[13] = 0;
$ScorePoints[14] = 0;
$ScorePoints[15] = 0;
$ScorePoints[16] = 0;
$ScorePoints[17] = 0;
$ScorePoints[18] = 0;
$ScorePoints[19] = 0;
$ScorePoints[20] = 0;
$ScorePoints[21] = 0;
$ScorePoints[22] = 0;
$ScorePoints[23] = 0;
$ScorePoints[24] = 0;
$ScorePoints[25] = 0;
$ScorePoints[26] = 0;
$ScorePoints[27] = 0;
$ScorePoints[28] = 0;
$ScorePoints[29] = 0;
$ScorePoints[30] = 0;
$ScorePoints[31] = 0;
$ScorePoints[32] = 0;
$ScorePoints[33] = 0;
$ScorePoints[34] = 0;
$ScorePoints[35] = 0;
$ScorePoints[36] = 0;
$ScorePoints[37] = 0;
$ScorePoints[38] = 0;
$ScorePoints[39] = 0;
$ScorePoints[40] = 0;
$ScorePoints[41] = 0;
$ScorePoints[42] = 0;
$ScorePoints[43] = 0;
$ScorePoints[44] = 0;
$ScorePoints[45] = 0;
$ScorePoints[46] = 0;
$ScorePoints[47] = 0;
$ScorePoints[48] = 0;
$ScorePoints[49] = 0;
$ScorePoints[50] = 0;

// Now lets give a good score number to each existing damage type

$ScorePoints[$ImpactDamageType] = 10;
$ScorePoints[$LandingDamageType] = -1;
$ScorePoints[$BulletDamageType] = 10;
$ScorePoints[$EnergyDamageType] = 10;
$ScorePoints[$PlasmaDamageType] = 10;
$ScorePoints[$ExplosionDamageType] = 10;
$ScorePoints[$ShrapnelDamageType] = 10;
$ScorePoints[$LaserDamageType] = 10;
$ScorePoints[$MortarDamageType] = 15;
$ScorePoints[$BlasterDamageType] = 10;
$ScorePoints[$ElectricityDamageType] = 10;
$ScorePoints[$CrushDamageType] = 10;
$ScorePoints[$DebrisDamageType] = 10;
$ScorePoints[$MissileDamageType] = 5;
$ScorePoints[$MineDamageType] = 3;
$ScorePoints[$FighterGunDamageType] = 5;
$ScorePoints[$KamikaziDamageType] = 10;
$ScorePoints[$ElectricDamageType] = 10;
$ScorePoints[$RocketDamageType] = 5;
$ScorePoints[$PlasmaCannonDamageType] = 20;
$ScorePoints[$FlameDamageType] = 5;
$ScorePoints[$SatchelDamageType] = 15;
$ScorePoints[$BombDamageType] = 10;
$ScorePoints[$AdminKillDamageType] = 0;
$ScorePoints[$SurpriseDamageType] = 15;
$ScorePoints[$BulletDmgType1] = 10;
$ScorePoints[$BulletDmgType2] = 15;
$ScorePoints[$BulletDmgType3] = 10;
$ScorePoints[$BulletDmgType4] = 10;
$ScorePoints[$BulletDmgType5] = 5;
$ScorePoints[$BulletDmgType6] = 10;
$ScorePoints[$BulletDmgType7] = 10;
$ScorePoints[$BulletDmgType8] = 10;
$ScorePoints[$BulletDmgType9] = 3;
$ScorePoints[$BulletDmgType10] = 10;
$ScorePoints[$BulletDmgType11] = 2;
$ScorePoints[$BulletDmgType12] = 10;
$ScorePoints[$BulletDmgType13] = 5;
$ScorePoints[$BulletDmgType14] = 8;
$ScorePoints[$BulletDmgType15] = 15;
$ScorePoints[$BulletDmgType16] = 20;
$ScorePoints[$BulletDmgType17] = 10;
$ScorePoints[$BulletDmgType18] = 20;
$ScorePoints[$BulletDmgType19] = 10;
$ScorePoints[$BulletDmgType20] = 10;
$ScorePoints[$BulletDmgType21] = 2;
$ScorePoints[$BulletDmgType22] = 10;
$ScorePoints[$BulletDmgType23] = 10;
$ScorePoints[$BulletDmgType24] = 10;
$ScorePoints[$BulletDmgType25] = 10;
$ScorePoints[$BulletDmgType26] = 10;
$ScorePoints[$BulletDmgType27] = 10;
$ScorePoints[$BulletDmgType28] = 10;
$ScorePoints[$BulletDmgType29] = 20;
$ScorePoints[$BulletDmgType30] = 10;
$ScorePoints[$BulletDmgType31] = 10;
$ScorePoints[$BulletDmgType32] = 5;
$ScorePoints[$BulletDmgType33] = 2;
$ScorePoints[$BulletDmgType34] = 10;
$ScorePoints[$BulletDmgType35] = 20;
$ScorePoints[$BulletDmgType36] = 10;

$ScorePoints[$StrikeDmgType] = 10;
