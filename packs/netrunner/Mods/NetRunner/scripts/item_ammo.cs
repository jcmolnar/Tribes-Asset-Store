$PickupSound[Ammo] = "SoundPickupAmmo";

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player, %item)
{
	if($matchStarted)
	{
		%count = Player::getItemCount(%player, %item);
		%delta = $SellAmmo[%item];
		if((Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType == %item) return;
		if(%count < %delta) %delta = %count;
		if(%delta > 0)
		{
			%obj = newObject("", "Item", %item, %delta, false);
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj, %player, 20, false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player, %item, %delta);
		}
	}
}

$AmmoCount = 0;

function addAmmo(%weapon, %ammo, %count)
{
	$Ammo_Weapon[$AmmoCount] = %weapon;
	$Ammo_Ammo[$AmmoCount] = %ammo;
	$Ammo_Count[$AmmoCount] = %count;  
	$AmmoCount++;
	$SellAmmo[%ammo] = %count;
}

echo('>> Loading Ammo');
exec(ammo_blasterammo);
exec(ammo_laserammo);
exec(ammo_bulletammo);
exec(ammo_discammo);
exec(ammo_grenadeammo);
exec(ammo_mortarammo);
exec(ammo_plasmaammo);
exec(ammo_arkfireammo);
echo('>> Finished Loading Ammo');
