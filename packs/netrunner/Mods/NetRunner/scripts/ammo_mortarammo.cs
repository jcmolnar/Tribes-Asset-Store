$InvList[MortarAmmo] = 1;
$RemoteInvList[MortarAmmo] = 1;

addAmmo(Mortar, MortarAmmo, 5);

ItemData MortarAmmo
{
	description = "Expel";
	className = "Ammo";
	heading = $InvHead[iRelo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
};
