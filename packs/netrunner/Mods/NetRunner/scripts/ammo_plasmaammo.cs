$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

addAmmo(PlasmaGun, PlasmaAmmo, 30);

ItemData PlasmaAmmo
{
	description = "Decrypt";
	heading = $InvHead[iRelo];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 0;
};
