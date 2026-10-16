$InvList[BabyNukeMortar] = 1;
$MobileInvList[BabyNukeMortar] = 1;
$RemoteInvList[BabyNukeMortar] = 1;

$InvList[BabyNukeAmmo] = 1;
$MobileInvList[BabyNukeAmmo] = 1;
$RemoteInvList[BabyNukeAmmo] = 1;

$AutoUse[BabyNukeMortar]= True;
$WeaponAmmo[BabyNukeMortar] = BabyNukeAmmo;
$SellAmmo[BabyNukeAmmo] = 25;

addWeapon(BabyNukeMortar);
addAmmo(BabyNukeMortar, BabyNukeAmmo, 1);

ItemData BabyNukeAmmo 
{
	description = "Drone";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 65;
};

ItemImageData BabyNukeImage
{
	shapeFile = "sensor_small";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	accuFire = true;
	ammoType = BabyNukeAmmo;
	reloadTime = 0.25;
	fireTime = 0.25;
	sfxFire = SoundPickUpWeapon; 
	sfxActivate = SoundPickUpWeapon;
};

ItemData BabyNukeMortar
{
	description = "Drone Deployer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BabyNukeImage;
	price = 300;
	showWeaponBar = true;
};

function BabyNukeMortar::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Drone Deployer: <f2>Deploys one drone based on your current selection.  Select your drone via the selector pack. Click once to throw, click again to activate and take command of the drone.");
}

function BabyNukeImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

	%client = GameBase::getOwnerClient(%player);
	Player::trigger(%player, false);
	if(%player.QuewedDrone > 0) ThrowingDrone::Deploy(%player);
	if(!%player.QuewedDrone) DroneDeploy(%player);
}