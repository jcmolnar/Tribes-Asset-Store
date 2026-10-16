$InvList[Shotgun] = 1;
$MobileInvList[Shotgun] = 1;
$RemoteInvList[Shotgun] = 1;

$AutoUse[Shotgun] = False;
$WeaponAmmo[Shotgun] = ""; //ShotgunShells;

$InvList[ShotgunShells] = 1;
$MobileInvList[ShotgunShells] = 1;
$RemoteInvList[ShotgunShells] = 1;

addWeapon(Shotgun);
//addAmmo(Shotgun, ShotgunShells, 5);

//ItemData ShotgunShells 
//{
//	description = "Terra Bolts";
//	className = "Ammo";
//	shapeFile = "ammo2";
//	heading = $InvHead[ihAmm];
//	shadowDetailMask = 4;
//	price = 1;
//};

ItemImageData ShotgunImage
{
	shapefile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	projectileType = TerraShot;
	accuFire = false;
//	ammoType = ShotgunShells;
	reloadTime = 0.3;
	fireTime = 0.3;
	minEnergy = 10;
	maxEnergy = 50;
	lightType = 3;  // Weapon Fire
	lightRadius = 6.5;
	lightTime = 2;
	lightColor = { 1.0, 0.4, 1.0 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Shotgun
{
	description = "Terra Arcus";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ShotGunImage;
	price = 75;
	showWeaponBar = true;
};

function Shotgun::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Terra Arcus: <f2>An old Earth weapon, it gathers particles from all around and hurls them forward as an unstable bolt.");
}