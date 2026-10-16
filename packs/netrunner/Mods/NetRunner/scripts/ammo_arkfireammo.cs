$InvList[ArkfireAmmo] = 1;
$RemoteInvList[ArkfireAmmo] = 1;

addAmmo(Arkfire, ArkfireAmmo, 5);
addAmmo(Arkfire2, ArkfireAmmo, 5);

ItemData ArkfireAmmo
{
	description = "Arkfire";
	className = "Ammo";
	heading = $InvHead[iRelo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
};
