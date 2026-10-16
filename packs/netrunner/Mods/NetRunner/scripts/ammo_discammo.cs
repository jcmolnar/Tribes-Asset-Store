$InvList[DiscAmmo] = 1;
$RemoteInvList[DiscAmmo] = 1;

addAmmo(LDiscLauncher, DiscAmmo, 100);
addAmmo(DiscLauncher, DiscAmmo, 100);
addAmmo(HDiscLauncher, DiscAmmo, 100);

ItemData DiscAmmo
{
	description = "Solburn";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[iRelo];
	shadowDetailMask = 4;
	price = 0;
};
