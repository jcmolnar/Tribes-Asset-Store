DamageSkinData armorDamageSkins
{
	bmpName[0] = "dskin1_armor";
	bmpName[1] = "dskin2_armor";
	bmpName[2] = "dskin3_armor";
	bmpName[3] = "dskin4_armor";
	bmpName[4] = "dskin5_armor";
	bmpName[5] = "dskin6_armor";
	bmpName[6] = "dskin7_armor";
	bmpName[7] = "dskin8_armor";
	bmpName[8] = "dskin9_armor";
	bmpName[9] = "dskin10_armor";
};

$ArmorFirst = "";
$ArmorLast = "";

$ArmorCount = 0;

function addArmor(%armor, %male, %female)
{
	if($ArmorFirst == "") $ArmorFirst = %armor;
	if($ArmorLast == "") $ArmorLast = %armor;
	$PrevArmor[%armor] = $ArmorLast;
	$NextArmor[%armor] = $ArmorFirst;
	$PrevArmor[$ArmorFirst] = %armor;
	$NextArmor[$ArmorLast] = %armor;
	$ArmorLast = %armor;
	$ArmorCount++;

	$ArmorType[Male, %armor] = %male;
	$ArmorType[Female, %armor] = %female;
	$ArmorName[%male] = %armor;
	$ArmorName[%female] = %armor;
}

echo('>> Loading Decks');
exec(armo_larmor);
exec(armo_hlarmor);
exec(armo_lmarmor);
exec(armo_marmor);
exec(armo_hmarmor);
exec(armo_lharmor);
exec(armo_harmor);
echo('>> Finished Loading Decks');