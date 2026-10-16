$InvList[TargetingLaser] = 1;
$MobileInvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;

$AutoUse[TargetingLaser] = False;

// Targeting Laser is not in the cycle chain, so
// it's not added, but it could be if you want.
// addWeapon(TargetingLaser);

ItemImageData TargetingLaserImage 
{	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser 
{	description = "Targeting Laser";
	className = "Tool";
	shapeFile = "paintgun";
	hudIcon = "targetlaser";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TargetingLaserImage;
	price = 50;
	showWeaponBar = false;
};
