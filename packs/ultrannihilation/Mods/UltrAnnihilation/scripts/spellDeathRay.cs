$InvList[DeathRay] = 1;
$MobileInvList[DeathRay] = 1;
$RemoteInvList[DeathRay] = 1;

$AutoUse[DeathRay] = True;
$WeaponAmmo[DeathRay] = "";

addWeapon(DeathRay);

ItemImageData DeathRayImage
{	shapeFile = "fusionbolt";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.30;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 20;
	projectileType = DeathRayLaser;
	accuFire = true;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DeathRay 
{	heading = $InvHead[ihSpl];
	description = "Spell: Death Ray";
	className = "Weapon";
	shapeFile = "fusionbolt";
	hudIcon = "fusionbolt";
	shadowDetailMask = 4;
	imageType = DeathRayImage;
	price = 250;
	showWeaponBar = true;
};

function DeathRay::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Death Ray: <f2>This spell fires a bolt of negative energy towards your target.");
}