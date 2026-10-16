$InvList[Heavensfury] = 1;
$MobileInvList[Heavensfury] = 1;
$RemoteInvList[Heavensfury] = 1;

$AutoUse[Heavensfury] = true;
$WeaponAmmo[Heavensfury] = "";

addWeapon(Heavensfury);

ItemImageData HeavensfuryImage 
{
	shapeFile = "discb";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.14;
	fireTime = 0.14;
	minEnergy = 6;
	maxEnergy = 15;
	projectileType = EnergyRiftSpin;
	accuFire = false;
	sfxFire = SoundPickUpWeapon;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Heavensfury 
{
	heading = $InvHead[ihWea];
	description = "Energy Rift";
	className = "Weapon";
	shapeFile = "shield";
	hudIcon = "weapon";
	shadowDetailMask = 4;
	imageType = HeavensfuryImage;
	price = 325;
	showWeaponBar = true;
};

function Heavensfury::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Energy Rift: <f2>creates a standstill portal to a magical land of death for any foolish enough to walk into it.");
}