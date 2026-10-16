
$InvList[TankRPGLauncher] = 1;
$MobileInvList[TankRPGLauncher] = 1;
$RemoteInvList[TankRPGLauncher] = 1;

$AutoUse[TankRPGLauncher] = False;
$WeaponAmmo[TankRPGLauncher] = "";

addWeapon(TankRPGLauncher);

ItemImageData TankRPGLauncherImage
{
	shapefile = "bullet";
	mountPoint = 0;
	weaponType = 0;
	projectileType = SilverWorm;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.15;
	minEnergy = 1;
	maxEnergy = 6;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.1, 0.7, 1.0 };
	sfxFire = SoundLaserHit;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData TankRPGLauncher
{
	description = "Quicksilver";
	className = "Weapon";
	shapeFile = "bullet";
	hudIcon = "blaster";
	heading = $InvHead[ihWea];
	shadowDetailMask = 2;
	imageType = TankRPGLauncherImage;
	price = 50;
	showWeaponBar = true;
};

function TankRPGLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Quicksilver Worm: <f2>Fires short, wormlike streams of boiling mercury.");
}