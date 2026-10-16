function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"AGG",MortarAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"ARL",MortarAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"LF2",PlasmaAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"RocketLauncher3",EnergyAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"ChaingunB",BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,"Chaingun",BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,"Mortar",MortarAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"Nuke",MortarAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"Swa",PlasmaAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",SmokeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"Chaingun2",BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,"SD",BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",PlasmaAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",MortarAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",PlasmaAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",EnergyAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",DiscAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",GrenadeAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",FireAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",GhostAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",StrikeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"RepairKit",StrikeXAmmo,20);
	return %cnt;

}