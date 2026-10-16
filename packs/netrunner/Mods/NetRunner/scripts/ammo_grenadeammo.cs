$InvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

addAmmo(LGrenadeLauncher, GrenadeAmmo, 10);
addAmmo(GrenadeLauncher, GrenadeAmmo, 10);
addAmmo(HGrenadeLauncher, GrenadeAmmo, 10);

ItemData GrenadeAmmo
{
	description = "Confuse";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = $InvHead[iRelo];
	shadowDetailMask = 4;
	price = 0;
};
