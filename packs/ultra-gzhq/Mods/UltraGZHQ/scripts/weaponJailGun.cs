$InvList[JailGun] = 1;
$MobileInvList[JailGun] = 1;
$RemoteInvList[JailGun] = 1;

$AutoUse[JailGun] = false;
$WeaponAmmo[JailGun] = "";

addWeapon(JailGun);

ItemImageData JailGunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	weaponType = 2;
	projectileType = jailbolt;
	minEnergy = 5;
	maxEnergy = 80;
	reloadTime = 2.0;
	fireTime = 1.5;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundELFIdle;
};

ItemData JailGun
{
	heading = $InvHead[ihWea];
	description = "Jailers Gun";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "energyrifle";
	hadowDetailMask = 4;
	imageType = JailGunImage;
	price = 385;
	showWeaponBar = true;
};

function Jailgun::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Jail Gun: <f2>Mounted <f1>|| <f2>Requires a Jail to be deployed");
}
