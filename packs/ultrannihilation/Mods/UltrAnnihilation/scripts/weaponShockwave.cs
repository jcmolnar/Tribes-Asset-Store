$InvList[ShockwaveGun] = 1;
$MobileInvList[ShockwaveGun] = 1;
$RemoteInvList[ShockwaveGun] = 1;

$AutoUse[ShockwaveGun] = True;
$WeaponAmmo[ShockwaveGun] = "";

addWeapon(ShockwaveGun);

ItemImageData ShockwaveGunImage 
{	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 10;
	maxEnergy = 15;
	projectileType = Shock;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ShockwaveGun 
{	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ShockwaveGunImage;
	price = 250;
	showWeaponBar = true;
};

function ShockwaveGun::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Shockwave Cannon: <f2>Sends a sonic boom!.");
}
