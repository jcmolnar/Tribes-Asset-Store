$InvList[TRocketLauncher] = 1;
$MobileInvList[TRocketLauncher] = 1;
$RemoteInvList[TRocketLauncher] = 1;

$InvList[TRocketLauncherAmmo] = 1;
$MobileInvList[TRocketLauncherAmmo] = 1;
$RemoteInvList[TRocketLauncherAmmo] = 1;

$AutoUse[TRocketLauncher] = false;
$WeaponAmmo[TRocketLauncher] = TRocketLauncherAmmo;
$SellAmmo[TRocketLauncherAmmo] = 30;

AddWeapon(TRocketLauncher);
AddAmmo(TRocketLauncher, TRocketLauncherAmmo, 30); 

ItemData TRocketLauncherAmmo
{
	description = "Shatter Storm Ammo";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData TRocketLauncherImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 2;
	spinUpTime = 3.0;
	spinDownTime = 0.5;
	fireTime = 0.05;
	ammoType = TRocketLauncherAmmo;
	projectileType = SSBullet;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 0.1;
	lightColor = { 1.0, 0.5, 0.2 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData TRocketLauncher
{
	description = "Shatter Storm";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "weapon";
  	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TRocketLauncherImage; 
	price = 150;
	showWeaponBar = true;
};

function TRocketLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Shatter-Storm Light Machine Gun: <f2>Takes a few seconds to achive proper airflow but then lets loose a hail of small bullets that turn into shrapnel on contact.");
}