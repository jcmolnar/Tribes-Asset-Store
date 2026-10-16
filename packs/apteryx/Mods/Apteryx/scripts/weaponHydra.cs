$InvList[TBlastCannon] = 1;
$MobileInvList[TBlastCannon] = 1;
$RemoteInvList[TBlastCannon] = 1;

$InvList[TBlastCannonAmmo] = 1;
$MobileInvList[TBlastCannonAmmo] = 1;
$RemoteInvList[TBlastCannonAmmo] = 1;

$AutoUse[TBlastCannon]	= false;
$WeaponAmmo[TBlastCannon] = TBlastCannonAmmo;
$SellAmmo[TBlastCannonAmmo] = 15;

AddWeapon(TBlastCannon);
AddAmmo(TBlastCannon, TBlastCannonAmmo,15);

ItemData TBlastCannonAmmo
{
	description = "Hydra Ammo";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData TBlastCannonImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 1.65;
	spinDownTime = 2.0;
	fireTime = 0.08;
	ammoType = TBlastCannonAmmo;
	projectileType = HydraBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 0.3, 0.3 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData TBlastCannon  
{
	
	description = "Hydra Machine Gun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "weapon";
  	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TBlastCannonImage; 
	price = 340;
	showWeaponBar = true;
};

function TBlastCannon::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Hydra Machine Gun: <f2>slow spin up time along with high ammo consumption, ammo cost, and ammo shortage plague this otherwise easy and powerful weapon.");
}