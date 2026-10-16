$InvList[BulletAmmo] = 1;
$RemoteInvList[BulletAmmo] = 1;

addAmmo(LChaingun, BulletAmmo, 100);
addAmmo(Chaingun, BulletAmmo, 100);
addAmmo(HChaingun, BulletAmmo, 100);

ItemData BulletAmmo
{
	description = "Killer";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[iRelo];
	shadowDetailMask = 4;
	price = 0;
};
