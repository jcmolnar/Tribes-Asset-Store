$InvList[ShockwaveGun] = 1;
$MobileInvList[ShockwaveGun] = 1;
$RemoteInvList[ShockwaveGun] = 1;

$AutoUse[ShockwaveGun] = false;
$WeaponAmmo[ShockwaveGun] = "";

addWeapon(ShockwaveGun);

ItemImageData ShockwaveGunImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 40;
	maxEnergy = 25;		//45 thanks perrinoia!
	projectileType = Shock;
	accuFire = true;
	fireTime = 0.5;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ShockwaveGun 
{
	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "clock";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ShockwaveGunImage;
	price = 250;
	showWeaponBar = true;
};

function ShockwaveGun::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Shockwave Cannon: <f2>Mounted");
}
