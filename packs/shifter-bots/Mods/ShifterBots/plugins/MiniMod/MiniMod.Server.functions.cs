// This is a MiniMod Plugin.
// This is a "functions" patch for upgrading Tribes to MiniMod v.07 compliance.

function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2);

// MiniMod's support for ammo based weapons. Starting here.

MiniMod::Load("plugins\\*.resupply.cs");

// Ending here.

	return %cnt;
}

