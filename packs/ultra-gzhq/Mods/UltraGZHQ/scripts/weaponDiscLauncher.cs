$InvList[Disclauncher] = 1;
$MobileInvList[Disclauncher] = 1;
$RemoteInvList[Disclauncher] = 1;

$InvList[DiscAmmo] = 1;
$MobileInvList[DiscAmmo] = 1;
$RemoteInvList[DiscAmmo] = 1;

$SellAmmo[DiscAmmo] = 5;
$WeaponAmmo[DiscLauncher] = DiscAmmo;

addWeapon(DiscLauncher);
addAmmo(DiscLauncher, DiscAmmo, 2);

ItemData DiscAmmo 
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage 
{
	shapeFile = "disc";
	mountPoint = 0;
	weaponType = 3;
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.05;
      fireTime = 0.05;
      spinUpTime = 0.05;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher 
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function Disclauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Disc Launcher: <f2>Mounted");
}