function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
	if($Apocalypse::SlugFest)
		return;
	%cnt = %cnt + AmmoStation::resupply(%player,"",MineAmmo,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	for(%i = 0; %i < $NWeapons; %i++) {
	       if($WeaponAmmo[$Weap[%i]] != "" && $Weap[%i] != ShockGun && Player::getItemCount(%player,$Weap[%i]) > 0)
		       %cnt = %cnt + AmmoStation::resupply(%player,$Weap[%i],$WeaponAmmo[$Weap[%i]],$SellAmmo[$WeaponAmmo[$Weap[%i]]]);
	}
	return %cnt;
}
