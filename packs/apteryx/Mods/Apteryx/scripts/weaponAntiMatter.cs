$InvList[Mortar] = 1;
$MobileInvList[Mortar] = 1;
$RemoteInvList[Mortar] = 1;

$InvList[MortarAmmo] = 1;
$MobileInvList[MortarAmmo] = 1;
$RemoteInvList[MortarAmmo] = 1;

$AutoUse[Mortar] = false;
$SellAmmo[MortarAmmo] = 5;
$WeaponAmmo[Mortar] = Mortar;

addWeapon(Mortar);
addAmmo(Mortar, MortarAmmo, 2);

ItemData MortarAmmo 
{
	description = "Antimatter Container";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData MortarImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = AntiMatterShell;
	accuFire = false;
	reloadTime = 0.6;
	fireTime = 1.3;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar 
{
	description = "Anti-Matter Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 500;
	showWeaponBar = true;
};

function Mortar::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Anti-Matter Launcher: <f2>rough equivalent to mortar. Fires a canister that contains some anti-matter.");
}