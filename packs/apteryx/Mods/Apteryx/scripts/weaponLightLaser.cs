$InvList[DeathRay] = 1;
$MobileInvList[DeathRay] = 1;
$RemoteInvList[DeathRay] = 1;

$AutoUse[DeathRay] = True;
$WeaponAmmo[DeathRay] = "";

addWeapon(DeathRay);

ItemImageData DeathRayImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.20;
	fireTime = 0.20;
	minEnergy = 6;
	maxEnergy = 8;
	projectileType = LightLaser;
	accuFire = true;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DeathRay 
{
	heading = $InvHead[ihWea];
	description = "Light Laser";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	shadowDetailMask = 4;
	imageType = DeathRayImage;
	price = 150;
	showWeaponBar = true;
};

function DeathRay::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Light Laser: <f2>Fires a small, pulse laser.");
}