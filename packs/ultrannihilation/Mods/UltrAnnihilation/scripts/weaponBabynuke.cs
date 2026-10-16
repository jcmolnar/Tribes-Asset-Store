$InvList[BabyNukeMortar] = 1;
$MobileInvList[BabyNukeMortar] = 1;
$RemoteInvList[BabyNukeMortar] = 1;

$InvList[BabyNukeAmmo] = 1;
$MobileInvList[BabyNukeAmmo] = 1;
$RemoteInvList[BabyNukeAmmo] = 1;

$AutoUse[BabyNukeMortar]= True;
$WeaponAmmo[BabyNukeMortar] = BabyNukeAmmo;
$SellAmmo[BabyNukeAmmo] = 25;

addWeapon(BabyNukeMortar);
addAmmo(BabyNukeMortar, BabyNukeAmmo, 1);

ItemData BabyNukeAmmo 
{	description = "Nuclear Device";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData BabyNukeImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = BabyNukeBomb;
	accuFire = true;
	ammoType = BabyNukeAmmo;
	reloadTime = 0.55;
	fireTime = 0.55;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData BabyNukeMortar
{	description = "Baby Nuke Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BabyNukeImage;
	price = 1500;
	showWeaponBar = true;
};

function BabyNukeMortar::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Baby Nuke Mortar: <f2>Throw this lil baby and watch them run for the hills.");
}