$InvList[Disclauncher] = 1;
$MobileInvList[Disclauncher] = 1;
$RemoteInvList[Disclauncher] = 1;

$InvList[DiscAmmo] = 1;
$MobileInvList[DiscAmmo] = 1;
$RemoteInvList[DiscAmmo] = 1;

$SellAmmo[DiscAmmo] = 2;
$WeaponAmmo[DiscLauncher] = DiscAmmo;

addWeapon(DiscLauncher);
addAmmo(DiscLauncher, DiscAmmo, 1);

ItemData DiscAmmo 
{
	description = "Batteries";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData DiscLauncherImage 
{
	shapeFile = "disc";
	mountPoint = 0;
	weaponType = 3;
	ammoType = DiscAmmo;
	accuFire = true;
	reloadTime = 0.30;
	fireTime = 0.60;
	spinUpTime = 0.50;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
	mountOffset = { -0.5, -0.25, -0.1 };
	mountRotation = { 0, 0, 0.1 };
};

ItemData DiscLauncher 
{
	description = "Reactor Capacitor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 350;
	showWeaponBar = true;
};

function Disclauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Reactor Capacitor: <f2>NOT A WEAPON.  Recharges your energy for a bit.");
}

function DisclauncherImage::onFire(%player, %slot)
{
   if(Player::getitemcount(%player,$weaponammo[disclauncher]) > 0)
   {
	player::decitemcount(%player, $weaponammo[disclauncher]);
	%clientId = Player::getclient(%player);
	Client::sendMessage(%client,0,"Recharging energy");
	gamebase::setenergy(%player, gamebase::getenergy(%player) + 50);

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ArtilleryEffect",%trans,%player,%vel);
   }
}