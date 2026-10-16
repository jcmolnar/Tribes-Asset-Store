$InvList[BlasterAmmo] = 1;
$RemoteInvList[BlasterAmmo] = 1;

addAmmo(Blaster, BlasterAmmo, 2);

ItemData BlasterAmmo
{
	description = "Subvert";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[iRelo];
	shadowDetailMask = 4;
	price = 0;
};
