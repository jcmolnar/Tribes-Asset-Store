$InvList[IX2000] = 1;			//1
$MobileInvList[IX2000] = 1;		//1
$RemoteInvList[IX2000] = 1;		//1

$InvList[IX2000Ammo] = 1;
$MobileInvList[IX2000Ammo] = 1;
$RemoteInvList[IX2000Ammo] = 1;

$AutoUse[IX2000] = false;
$WeaponAmmo[IX2000] = IX2000Ammo;
$SellAmmo[IX2000Ammo] = 100;

addWeapon(IX2000);
addAmmo(IX2000, IX2000Ammo, 50);

ItemData IX2000Ammo 
{
	description = "IX2000 Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData IX2000Image
{
	shapeFile = "sniper";//disc paintgun
	mountPoint = 0;
	mountOffset = {0,0,0};
	mountRotation = {0, 7, 0}; 



	weaponType = 0; // 0 singleshot,3 disk, 1 spinning,2 sustained
	ammoType = IX2000Ammo;
	projectileType = IX2000Bullet;
	accuFire = true;
	reloadTime = 0.01;
	fireTime = 0;
	//spinUpTime = 0;

	sfxFire = ricochet2;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundDiscReload;
	//sfxReady = SoundMortarTurretTurn;
};

ItemData IX2000 
{
	heading = $InvHead[ihWea];
	description = "IX-2000";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
	shadowDetailMask = 4;
	imageType = IX2000Image;
	price = 500;
	showWeaponBar = true;
};

function IX2000::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>IX-2000: <f2>Mounted");
}
