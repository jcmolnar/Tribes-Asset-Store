$InvList[TankShredder] = 1;
$MobileInvList[TankShredder] = 1;
$RemoteInvList[TankShredder] = 1;

$InvList[TankShredderAmmo] = 1;
$MobileInvList[TankShredderAmmo] = 1;
$RemoteInvList[TankShredderAmmo] = 1;

$AutoUse[TankShredder] = false;
$SellAmmo[TankShredderAmmo] = 2;
$WeaponAmmo[TankShredder] = "TankShredderAmmo";

addweapon(TankShredder);
addAmmo(TankShredder, TankShredderAmmo, 4);

ItemData TankShredderAmmo
{
	description = "Lasher Charges";
	heading = $InvHead[ihAmm];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;	
};

ItemImageData TankShredderImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	minEnergy = 15;
	maxEnergy = 32;
	weaponType = 0; // Single Shot
	projectileType = LasherBolt;
	ammotype = TankShredderAmmo;
	accuFire = false;
	reloadTime = 0.8;
	fireTime = 1.6;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.5, 0.5, 1};
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TankShredder
{
	description = "Lasher";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TankShredderImage;
	price = 50;
	showWeaponBar = true;
};

function TankShredder::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Lasher: <f2>Gathers energy from its ammunition and fires it as a ball of electricity.");
}