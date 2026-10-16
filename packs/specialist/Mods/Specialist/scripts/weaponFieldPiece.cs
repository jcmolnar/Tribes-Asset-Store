$InvList[AntiPersonnelCannon] = 1;
$RemoteInvList[AntiPersonnelCannon] = 1;
$AutoUse[AntiPersonnelCannon] = True;

$WeaponAmmo[AntiPersonnelCannon] = AntiPersonnelCannonAmmo;
$SellAmmo[AntiPersonnelCannonAmmo] = 15;
$InvList[AntiPersonnelCannonAmmo] = 1;
$RemoteInvList[AntiPersonnelCannonAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, AntiPersonnelCannon] = 0;
$ItemMax[reconfemalearmor, AntiPersonnelCannon] = 0;
$ItemMax[espionagearmor, AntiPersonnelCannon] = 0;
$ItemMax[espionagefemalearmor, AntiPersonnelCannon] = 0;
$ItemMax[engineerarmor, AntiPersonnelCannon] = 0;
$ItemMax[engineerfemalearmor, AntiPersonnelCannon] = 0;
$ItemMax[infantryarmor, AntiPersonnelCannon] = 0;
$ItemMax[infantryfemalearmor, AntiPersonnelCannon] = 0;
$ItemMax[falloutarmor, AntiPersonnelCannon] = 0;
$ItemMax[falloutfemalearmor, AntiPersonnelCannon] = 0;
$ItemMax[demolitionsarmor, AntiPersonnelCannon] = 0;
$ItemMax[assaultarmor, AntiPersonnelCannon] = 1;
$ItemMax[artilleryarmor, AntiPersonnelCannon] = 1;
$ItemMax[commanderarmor, AntiPersonnelCannon] = 1;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[reconfemalearmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[espionagearmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[espionagefemalearmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[engineerarmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[engineerfemalearmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[infantryarmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[infantryfemalearmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[falloutarmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[falloutfemalearmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[demolitionsarmor, AntiPersonnelCannonAmmo] = 0;
$ItemMax[assaultarmor, AntiPersonnelCannonAmmo] = 400;
$ItemMax[artilleryarmor, AntiPersonnelCannonAmmo] = 200;
$ItemMax[commanderarmor, AntiPersonnelCannonAmmo] = 250;

BulletData AntiPersonnelRound 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.15;
	bulletHoleIndex = 0;

  damageClass = 0; // 1 = radius
  damageValue = 0.19;
  damageType = $BulletDamageType;

  aimDeflection = 0.002;
  muzzleVelocity = 425.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;

  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 90;

};

ItemData AntiPersonnelCannonAmmo
{
	description = "High Caliber Round";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData AntiPersonnelCannonImage 
{
	mountOffset = { 0, 0.3, 0 };
	mountRotation = { 0, 3.14, 0 };

	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0.3;
	spinUpTime = 0.7;
	spinDownTime = 4;
	fireTime = 0.2;

	ammoType = AntiPersonnelCannonAmmo;
	projectileType = AntiPersonnelRound;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.2;
	lightColor = { 1.0, 1.0, 0.0 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData AntiPersonnelCannon 
{
	description = "Fieldpiece";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AntiPersonnelCannonImage;
	price = 250;
	showWeaponBar = true;
};

function AntiPersonnelCannon::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Fieldpiece is a powerful hi-caliber automatic weapon.");
	}
}
