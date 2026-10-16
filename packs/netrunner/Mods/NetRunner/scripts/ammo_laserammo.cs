$InvList[LaserAmmo] = 1;
$RemoteInvList[LaserAmmo] = 1;

addAmmo(LaserRifle, LaserAmmo, 10);
addAmmo(HLaserRifle, LaserAmmo, 10);

ItemData LaserAmmo
{
	description = "Vampire";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[iRelo];
	shadowDetailMask = 4;
	price = 0;
};
