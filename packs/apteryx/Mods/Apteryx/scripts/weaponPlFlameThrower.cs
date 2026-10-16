$InvList[FlameStrike] = 1;
$MobileInvList[FlameStrike] = 1;
$RemoteInvList[FlameStrike] = 1;

$AutoUse[FlameStrike] = True;
$WeaponAmmo[FlameStrike] = "";

addWeapon(FlameStrike);

ItemImageData FlameStrikeImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = PlasmaPlume;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.15;
	minEnergy = 5;
	maxEnergy = 10;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = explosion4;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlameStrike
{
	description = "Plasma Flame Thrower";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "shotgun";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FlameStrikeImage;
	price = 325;
	showWeaponBar = true;
};

function FlameStrike::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Plasma Pulse Flame Thrower: <f2> easiest melee weapon to hit your target with, but causes the least damage total.");
}