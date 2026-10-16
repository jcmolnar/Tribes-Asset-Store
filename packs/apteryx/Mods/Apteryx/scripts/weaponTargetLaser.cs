$InvList[TargetingLaser] = 1;
$MobileInvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;

AddItem(TargetingLaser);	// adding this way so doesnt cycle -plasmatic
$AutoUse[TargetingLaser] = False;

// Targeting Laser is not in the cycle chain, so
// it's not added, but it could be if you want.
// addWeapon(TargetingLaser);
// -Plasmatic

ItemImageData TargetingLaserImage 
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 2;	//15
	reloadTime = 1.0;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser 
{
	description = "Targeting Laser";
	className = "Tool";
	shapeFile = "paintgun";
	hudIcon = "targetlaser";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TargetingLaserImage;
	price = 50;
	showWeaponBar = false;
};

function TargetingLaser::onMount(%player,%item)
{	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Target Laser: <f2>Target your stuff.");
}

function TargetingLaser::onuse(%player)
{
	if(!$build)
		Player::mountItem(%player,TargetingLaser,0);	
	else
	{
		%clientId = Player::getclient(%player);
		Player::mountItem(%player,CuttingLaser,0);
		bottomprint(%clientId, "<jc>Cutting Laser: <f2>Watch your eyes.");
	}		
}
