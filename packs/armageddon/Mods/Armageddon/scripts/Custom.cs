// Customisable Features :- Beacon/Mine/Grenade & Spawn Items

###############################################################
###############################################################
##  This function of the Meltdown v w00 Modification         ##
##  should only be used when and if you are confident        ##
##  with the changes involved. There is the potential        ##
##  for changes made here to in some way make your mod       ##
##  unusable and in this case I will not be held responsible ##
##  for any damage caused.                                   ##
##                                      ~|*|w00|*|GreyWolf   ##
###############################################################
###############################################################

//=================================================================
// Instructions :- For the Ammo changes make sure you only change 
//   the numbers. NOTHING else... and make sure the colon is still 
//   there when you change.
//
//  :- For the Spawn list make sure the changes you make are spelt
//      Exactly the same as in the options list I have provided. And
//     again make sure the colon is still present.
//
//      SAVE THE CHANGES AND RUN THE MOD AS NORMAL!!
//==================================================================


//Archer :- Mine/Beacon/Grenade Ammo

$ItemMax[larmor, MineAmmo] = 8;
$ItemMax[larmor, Grenade] = 8;
$ItemMax[larmor, Beacon]  = 8;
$ItemMax[larmor, Admin] = 4;

//SilverWolf (Eng.) :- Mine/Beacon/Grenade Ammo

$ItemMax[marmor, MineAmmo] = 10;
$ItemMax[marmor, Grenade] = 10;
$ItemMax[marmor, Beacon] = 10;
$ItemMax[marmor, Admin] = 4;

//Zeus :- Mine/Beacon/Grenade Ammo

$ItemMax[harmor, Grenade] = 10;
$ItemMax[harmor, Beacon] = 10;
$ItemMax[harmor, Admin] = 4;

//Archer (Female) :- Mine/Beacon/Grenade Ammo

$ItemMax[lfemale, MineAmmo] = 7;
$ItemMax[lfemale, Grenade] = 7;
$ItemMax[lfemale, Beacon] = 7;
$ItemMax[lfemale, Admin] = 4;

//SilverWolf (Eng. Female) :- Mine/Beacon/Grenade Ammo

$ItemMax[mfemale, MineAmmo] = 8;
$ItemMax[mfemale, Grenade] = 8;
$ItemMax[mfemale, Beacon] = 8;
$ItemMax[mfemale, Admin] = 4;

//Mercury :- Mine/Beacon/Grenade Ammo

$ItemMax[BlastechM, MineAmmo] = 8;
$ItemMax[BlastechM, Grenade] = 8;
$ItemMax[BlastechM, Beacon]  = 6;
$ItemMax[BlastechM, Admin] = 4;

//Paris :- Mine/Beacon/Grenade Ammo

$ItemMax[MagIonM, MineAmmo] = 8;
$ItemMax[MagIonM, Grenade] = 8;
$ItemMax[MagIonM, Beacon] = 8;
$ItemMax[MagIonM, Admin] = 4;
//Hercules:- Mine/Beacon/Grenade Ammo

$ItemMax[MECH, Grenade] = 10;
$ItemMax[MECH, Beacon] = 10;
$ItemMax[MECH, Admin] = 4;

//Mercury (Female) :- Mine/Beacon/Grenade Ammo

$ItemMax[BlastechF, MineAmmo] = 6;
$ItemMax[BlastechF, Grenade] = 6;
$ItemMax[BlastechF, Beacon]  = 6;
$ItemMax[BlastechF, Admin] = 4;

//Paris (Female) :- Mine/Beacon/Grenade Ammo

$ItemMax[MagIonF, MineAmmo] = 5;
$ItemMax[MagIonF, Grenade] = 6;
$ItemMax[MagIonF, Beacon] = 7;
$ItemMax[MagIonF, Admin] = 4;

// Spawn Customisable features :-

$spawnBuyList[0] = MagIonArmor;
$spawnBuyList[1] = DiscLauncher;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = PlasmaGun;
$spawnBuyList[4] = Reassembler;
$spawnBuyList[5] = MBCannon;
$spawnBuyList[6] = GrenadeLauncher;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Beacon;
$spawnBuyList[9] = MineAmmo;
$spawnBuyList[10] = PBW;
$spawnBuyList[11] = EnergyPack;


// Armor Options :-
//
// 1) LightArmor
// 2) BlastechArmor
// 3) MediumArmor
// 4) MagIonArmor
// 5) MECHArmor
// 6) HeavyArmor
//
// Weapon Options :-
//
// 1) MaserRifle
// 2) MBCannon
// 3) Chaingun
// 4) GatB
// 5) Gauss
// 6) Minigun
// 7) GrenadeLauncher
// 8) Mortar
// 9) StasisCannon
// 10) DiscLauncher
// 11) TwinFusor
// 12) PBW
// 13) Railgun
// 14) AAODSniperX
// 15) Reassembler
// 16) PlasmaGun
//
// Pack Options :-
//
// 1) EnergyPack
// 2) Accelerator
// 3) GravFieldPack
// 4) BugPack