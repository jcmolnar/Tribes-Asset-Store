$InvList[PhaseDisrupter] = 1;
$MobileInvList[PhaseDisrupter] = 1;
$RemoteInvList[PhaseDisrupter] = 1;

$InvList[PhaseDisrupterAmmo] = 1;
$MobileInvList[PhaseDisrupterAmmo] = 1;
$RemoteInvList[PhaseDisrupterAmmo] = 1;

$AutoUse[PhaseDisrupter] = False;
$SellAmmo[PhaseDisrupterAmmo] = 2;
$WeaponAmmo[PhaseDisrupter] = PhaseDisrupterAmmo;

addWeapon(PhaseDisrupter);
addAmmo(PhaseDisrupter, PhaseDisrupterAmmo, 2);

ItemData PhaseDisrupterAmmo
{	description = "Disrupter Ammo";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 200;
};

ItemImageData PhaseDisrupterImage
{	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = PhaseDisrupterAmmo;
	projectileType = PhaseDisrupterBolt;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundJetLight;
	sfxReady = SoundJammerOn;
};

ItemData PhaseDisrupter
{	description = "Phase Disrupter";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "ammopack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PhaseDisrupterImage;
	price = 1000;
	showWeaponBar = true;
};

function PhaseDisrupter::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Phase Disrupter: <f2>This weapons disrupts the time-space continuum to send all in its path to oblivion.");
}
