//--------------------------------------

$AutoUse[Chaingun] = True;
$SellAmmo[BulletAmmo] = 25;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;

//--------------------------------------

$InvList[Chaingun] = 1;
$InvList[BulletAmmo] = 1;
$RemoteInvList[Chaingun] = 1;
$RemoteInvList[BulletAmmo] = 1;

$ItemMax[narmor, Chaingun] = 0;
$ItemMax[aarmor, Chaingun] = 1;
$ItemMax[darmor, Chaingun] = 1;
$ItemMax[nfemale, Chaingun] = 0;
$ItemMax[afemale, Chaingun] = 1;
$ItemMax[warmor, Chaingun] = 1;
$ItemMax[barmor, Chaingun] = 1;
$ItemMax[sarmor, Chaingun] = 1;
$ItemMax[avarmor, Chaingun] = 1;
$ItemMax[wfemale, Chaingun] = 1;
$ItemMax[bfemale, Chaingun] = 1;

$ItemMax[narmor, BulletAmmo] = 0;
$ItemMax[aarmor, BulletAmmo] = 100;
$ItemMax[darmor, BulletAmmo] = 250;
$ItemMax[nfemale, BulletAmmo] = 0;
$ItemMax[afemale, BulletAmmo] = 100;
$ItemMax[warmor, BulletAmmo] = 150;
$ItemMax[barmor, BulletAmmo] = 200;
$ItemMax[sarmor, BulletAmmo] = 500;
$ItemMax[avarmor, BulletAmmo] = 250;
$ItemMax[wfemale, BulletAmmo] = 150;
$ItemMax[bfemale, BulletAmmo] = 200;

//--------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function Chaingun::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Chaingun: <f2>A standard Rapid-Fire chaingun.");
}