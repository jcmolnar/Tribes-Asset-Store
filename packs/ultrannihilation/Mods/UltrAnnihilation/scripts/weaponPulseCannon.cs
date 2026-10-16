$InvList[PulseCannon] = 1;
$MobileInvList[PulseCannon] = 1;
$RemoteInvList[PulseCannon] = 1;

$WeaponAmmo[PulseCannon] = "";
$AutoUse[PulseCannon] = True;

addweapon(PulseCannon);

ItemData Battery
{	description = "500 Volt Battery";
	heading = $InvHead[ihAmm];
	className = "Ammo";
	shapeFile = "ammo2";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PulseCannonImage
{	shapeFile = "plasma";
	mountPoint = 0;
	minEnergy = 5;
	maxEnergy = 8;
	weaponType = 0; // Single Shot
	//ammoType = Battery;
	projectileType = PulseBolt;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirebLASTER;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PulseCannon
{	description = "Pulse Cannon";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "blaster";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PulseCannonImage;
	price = 600;
	showWeaponBar = true;
};

function PulseCannon::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Pulse Cannon: <f2>Fires Ion Bolts similar to the Ion Turrets.");
}