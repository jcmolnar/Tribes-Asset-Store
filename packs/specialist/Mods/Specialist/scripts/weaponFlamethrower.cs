$InvList[Flamethrower] = 1;
$RemoteInvList[Flamethrower] = 1;
$AutoUse[Flamethrower] = True;

$WeaponAmmo[Flamethrower] = FlamethrowerAmmo;
$SellAmmo[FlamethrowerAmmo] = 15;
$InvList[FlamethrowerAmmo] = 1;
$RemoteInvList[FlamethrowerAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, Flamethrower] = 0;
$ItemMax[reconfemalearmor, Flamethrower] = 0;
$ItemMax[espionagearmor, Flamethrower] = 0;
$ItemMax[espionagefemalearmor, Flamethrower] = 0;
$ItemMax[engineerarmor, Flamethrower] = 1;
$ItemMax[engineerfemalearmor, Flamethrower] = 1;
$ItemMax[infantryarmor, Flamethrower] = 1;
$ItemMax[infantryfemalearmor, Flamethrower] = 1;
$ItemMax[falloutarmor, Flamethrower] = 0;
$ItemMax[falloutfemalearmor, Flamethrower] = 0;
$ItemMax[demolitionsarmor, Flamethrower] = 0;
$ItemMax[assaultarmor, Flamethrower] = 1;
$ItemMax[artilleryarmor, Flamethrower] = 0;
$ItemMax[commanderarmor, Flamethrower] = 1;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, FlamethrowerAmmo] = 0;
$ItemMax[reconfemalearmor, FlamethrowerAmmo] = 0;
$ItemMax[espionagearmor, FlamethrowerAmmo] = 0;
$ItemMax[espionagefemalearmor, FlamethrowerAmmo] = 0;
$ItemMax[engineerarmor, FlamethrowerAmmo] = 50;
$ItemMax[engineerfemalearmor, FlamethrowerAmmo] = 50;
$ItemMax[infantryarmor, FlamethrowerAmmo] = 60;
$ItemMax[infantryfemalearmor, FlamethrowerAmmo] = 60;
$ItemMax[falloutarmor, FlamethrowerAmmo] = 0;
$ItemMax[falloutfemalearmor, FlamethrowerAmmo] = 0;
$ItemMax[demolitionsarmor, FlamethrowerAmmo] = 0;
$ItemMax[assaultarmor, FlamethrowerAmmo] = 100;
$ItemMax[artilleryarmor, FlamethrowerAmmo] = 0;
$ItemMax[commanderarmor, FlamethrowerAmmo] = 100;


BulletData Flame
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = flameExp;
	damageClass = 1;
	damageValue = 0.11;
	damageType = $FireDamageType;
	explosionRadius = 4.0;
	aimDeflection = 0.02;
	muzzleVelocity = 20.0;
	totalTime = 0.75;
	liveTime = 0.75;
	lightRange = 3.0;
	lightColor = { 0, 0, 0.9 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	soundId = SoundFlame;
};

ItemData FlamethrowerAmmo
{
	description = "Flamethrower Fuel";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData FlamethrowerImage 
{
	mountOffset = { 0, 0.2, 0 };
	mountRotation = { 0, 3.14, 0 };

	shapeFile = "repairGun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0.1;
	spinUpTime = 0.1;
	spinDownTime = 0.5;
	fireTime = 0.1;
	ammoType = FlamethrowerAmmo;
	projectileType = Flame;
	accuFire = true;
	lightType = 3;
	lightRadius = 15;
	lightTime = 4;
	lightColor = { 0, 0, 0.9 };
	sfxFire = SoundFlame;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Flamethrower
{
	heading = "bWeapons";
	description = "Flamethrower";
	className = "Weapon";
	shapeFile = "repairGun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = FlamethrowerImage;
	price = 385;
	showWeaponBar = true;
};

function Flamethrower::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "Fires a stream of flame which often ignites other materials.");
	}
}
