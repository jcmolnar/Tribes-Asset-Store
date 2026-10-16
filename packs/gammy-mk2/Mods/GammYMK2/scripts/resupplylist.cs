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
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",PlasmaAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",MortarAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",PlasmaAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",EnergyAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",DiscAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",GrenadeAmmo,3);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",FireAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",GhostAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",StrikeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"Grenade",StrikeXAmmo,20);
	return %cnt;

}