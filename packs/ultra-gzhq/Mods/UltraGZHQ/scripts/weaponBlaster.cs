$InvList[Blaster] = 1;
$MobileInvList[Blaster] = 1;
$RemoteInvList[Blaster] = 1;

$AutoUse[Blaster] = False;
$WeaponAmmo[Blaster] = "";

addWeapon(Blaster);

ItemImageData BlasterImage 
{
   shapeFile  = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.05;
	minEnergy = 1;
	maxEnergy = 0.1;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = energyExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster 
{
	description = "Blaster";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 100;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Blaster: <f2>Mounted");
}

