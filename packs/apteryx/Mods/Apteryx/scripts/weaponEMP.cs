//IS NOW EMP - Crow!

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
	minEnergy = 25;
	maxEnergy = 25;
	projectileType = EMP;
	accuFire = true;
	fireTime = 1.25;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ShockwaveGun 
{
	description = "EMP cannon";
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
		Bottomprint(%clientId, "<jc>EMP cannon: <f2>Robs its victims of their energy, more useful against heavies.");
}
