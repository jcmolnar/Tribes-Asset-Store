




//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------


$ArmorType[Male, DuelerArmor] = duelarmor;
$ArmorType[Female, DuelerArmor] = duelfemale;
$ArmorName[duelarmor] = DuelerArmor;
$ArmorName[duelfemale] = DuelerArmor;
ItemData DuelerArmor
{
   heading = "aArmor";
	description = "Duel Armor";
showInventory = false;
	className = "Armor";
	price = 250;
};


//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[



$ArmorType[Male, ScoutArmor] = sarmor;
$ArmorType[Female, ScoutArmor] = sfemale;
$ArmorName[sarmor] = ScoutArmor;
$ArmorName[sfemale] = ScoutArmor;
ItemData ScoutArmor
{
   heading = "aArmor";
	description = "Scout Armor";
	className = "Armor";
	price = 175;
};


$ArmorType[Male, SpyArmor] = sparmor;
$ArmorType[Female, SpyArmor] = spfemale;
$ArmorName[sparmor] = SpyArmor;
$ArmorName[spfemale] = SpyArmor;
ItemData SpyArmor
{
   heading = "aArmor";
	description = "Spy Armor";
	className = "Armor";
	price = 175;
};


$ArmorType[Male, SniperArmor] = sniparmor;
$ArmorType[Female, SniperArmor] = snipfemale;
$ArmorName[sniparmor] = SniperArmor;
$ArmorName[snipfemale] = SniperArmor;
ItemData SniperArmor
{
   heading = "aArmor";
	description = "Sniper Armor";
	className = "Armor";
	price = 175;
};

$ArmorType[Male, MercenaryArmor] = mercarmor;
$ArmorType[Female, MercenaryArmor] = mercfemale;
$ArmorName[mercarmor] = MercenaryArmor;
$ArmorName[mercfemale] = MercenaryArmor;
ItemData MercenaryArmor
{
   heading = "aArmor";
	description = "Mercenary Armor";
	className = "Armor";
	price = 250;
};

$ArmorType[Male, EngineerArmor] = engarmor;
$ArmorType[Female, EngineerArmor] = engfemale;
$ArmorName[engarmor] = EngineerArmor;
$ArmorName[engfemale] = EngineerArmor;
ItemData EngineerArmor
{
   heading = "aArmor";
	description = "Engineer Armor";
	className = "Armor";
	price = 250;
};

$ArmorType[Male, FlagMoverArmor] = flagarmor;
$ArmorType[Female, FlagMoverArmor] = flagfemale;
$ArmorName[flagarmor] = FlagMoverArmor;
$ArmorName[flagfemale] = FlagMoverArmor;
ItemData FlagMoverArmor
{
   heading = "aArmor";
	description = "Flag Mover Armor";
	className = "Armor";
	price = 250;
};

$ArmorType[Male, BursterArmor] = barmor;
$ArmorType[Female, BursterArmor] = bfemale;
$ArmorName[barmor] = BursterArmor;
$ArmorName[bfemale] = BursterArmor;
ItemData BursterArmor
{
   heading = "aArmor";
	description = "Burster Armor";
	className = "Armor";
	price = 250;
};

$ArmorType[Male, DragArmor] = darmor;
$ArmorType[Female, DragArmor] = darmor; 
$ArmorName[darmor] = DragArmor; 
ItemData DragArmor 
{ 
heading = "aArmor"; 
description = "Cyborg"; 
className = "Armor"; 
price = 400; 
}; 








if ($BaseArmors)
{

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;



ItemData LightArmor
{
   heading = "aArmor";
	description = "Light Armor";
	className = "Armor";
	price = 175;
};

ItemData MediumArmor
{
   heading = "aArmor";
	description = "Medium Armor";
	className = "Armor";
	price = 250;
};

ItemData HeavyArmor
{
   heading = "aArmor";
	description = "Heavy Armor";
	className = "Armor";
	price = 400;
};


}







//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
};

ItemData WraithVehicle
{
	description = "Wraith";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
};
ItemData JetVehicle
{
	description = "Jet";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
};

ItemData LAPCVehicle
{
	description = "LAPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "HAPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
};
