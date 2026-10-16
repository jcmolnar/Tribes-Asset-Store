$InvList[IX2002] = 1;			//1
$MobileInvList[IX2002] = 1;		//1
$RemoteInvList[IX2002] = 1;		//1

$InvList[IX2002Ammo] = 1;
$MobileInvList[IX2002Ammo] = 1;
$RemoteInvList[IX2002Ammo] = 1;

$AutoUse[IX2002] = false;
$WeaponAmmo[IX2002] = IX2002Ammo;
$SellAmmo[IX2002Ammo] = 100;

addWeapon(IX2002);
addAmmo(IX2002, IX2002Ammo, 50);

ItemData IX2002Ammo 
{
	description = "IX2002 Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData IX2002Image
{
	shapeFile = "sniper";//disc paintgun
	mountPoint = 0;
	//mountOffset = {-0.1,0.1,-0.1};//{0.065, 0.1, -0.1}
	//mountRotation = {0, -1.57, 0}; //-1.57



	weaponType = 0; // 0 singleshot,3 disk, 1 spinning,2 sustained
	ammoType = IX2002Ammo;
	projectileType = IX2002Bullet;
	accuFire = true;
	reloadTime = 0.01;
	fireTime = 0;
	//spinUpTime = 0;

	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundDiscReload;
	//sfxReady = SoundMortarTurretTurn;
};

ItemData IX2002 
{
	heading = $InvHead[ihWea];
	description = "IX-2002";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
	shadowDetailMask = 4;
	imageType = IX2002Image;
	price = 500;
	showWeaponBar = true;
};

function IX2002::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>IX-2002: <f2>Mounted");
}
