//------------------------------------------
//
//	ITEM ASIGNMENT
//
//------------------------------------------

$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;
$Picture1Slot=6;

$ArmorType[Male, Parmor] = Pmale;
$ArmorType[Male, DMarmor] = DMmale;
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, FlightArmor] = farmor;
$ArmorType[Male, EngineerArmor] = Earmor;
$ArmorType[Female, Parmor] = Pfemale;
$ArmorType[Female, DMarmor] = DMfemale;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;
$ArmorType[Female, FlightArmor] = ffemale;
$ArmorType[Female, EngineerArmor] = Efemale;

$ArmorName[Pmale] = Parmor;
$ArmorName[DMmale] = DMarmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[farmor] = FlightArmor;
$ArmorName[Earmor] = EngineerArmor;
$ArmorName[Pfemale] = Parmor;
$ArmorName[DMfemale] = DMarmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorName[ffemale] = FlightArmor;
$ArmorName[Efemale] = EngineerArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[SniperAmmo] = 25;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[FlameAmmo] = 5;
$AmmoPackMax[TranqAmmo] = 10;
$AmmoPackMax[HCAmmo] = 5;
$AmmoPackMax[RailAmmo] = 5;
$AmmoPackMax[ShotgunAmmo] = 5;
$AmmoPackMax[SniperAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 5;
$AmmoPackMax[Beacon] = 5;

// Items in the AmmoPack
$AmmoPackItems[0] = FlameAmmo;
$AmmoPackItems[1] = TranqAmmo;
$AmmoPackItems[2] = HCAmmo;
$AmmoPackItems[3] = RailAmmo;
$AmmoPackItems[4] = ShotgunAmmo;
$AmmoPackItems[5] = SniperAmmo;
$AmmoPackItems[6] = SniperAmmo;
$AmmoPackItems[7] = Grenade;
$AmmoPackItems[8] = MineAmmo;
$AmmoPackItems[9] = Beacon;

// Max Amount of Mines the Mine Pack can carry
$MinePackMax[MineAmmo] = 15;
$MinePackItems[0] = MineAmmo;