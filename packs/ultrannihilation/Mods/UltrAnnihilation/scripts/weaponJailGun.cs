$InvList[JailGun] = 1;
$MobileInvList[JailGun] = 1;
$RemoteInvList[JailGun] = 1;

$AutoUse[JailGun] = True;
$WeaponAmmo[JailGun] = "";

addWeapon(JailGun);

ItemImageData JailGunImage
{	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	weaponType = 2;
	projectileType = jailbolt;
	minEnergy = 5;
	maxEnergy = 80;
	reloadTime = 4.0;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundELFIdle;
};

ItemData JailGun
{	heading = $InvHead[ihWea];
        description = "Jailers Gun";
        className = "Weapon";
        shapeFile  = "repairgun";
        hadowDetailMask = 4;
        imageType = JailGunImage;
        price = 385;
        showWeaponBar = true;
};

function Jailgun::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Jail Gun: <f2>You are the judge and jury with this little device.  Requires the Jail to be deployed.");
}
