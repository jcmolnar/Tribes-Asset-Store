//---------------------------------|
// Author: Whoever Made VX5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//---------------------------------|
//
// * Just like the energy weapons i have grouped togeather into one file
// these weapons are grouped because they require no special functions 
// and take up very little space.
//
//
ItemData BulletAmmo {
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};
ItemImageData ChaingunImage {
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; 
	reloadTime = 0;
	fireTime = 0.02;
	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = true;
	sfxFire = debrissmallexplosion;
	sfxActivate = SoundPickUpWeapon;
};
ItemData Chaingun {
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "sniper";
    validateShape = false;
	hudIcon = "sniper";
    heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};
function Chaingun::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }
//===========================================================================================

ItemData LiLPOOmkiAmmo {
	description = "Bullet mki";
	className   = "Ammo";
	shapeFile   = "ammo1";
    heading     = "xAmmunition";
	shadowDetailMask = 4;
	price       = 0;
};

ItemImageData LiLPOOmkiImage {
	shapeFile  = "sniper";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0;
	fireTime   = 0.011;
	ammoType   = LiLPOOmkiAmmo;
	projectileType = LiLPOOmkiBullet;
	accuFire       = true;
	sfxFire        = SoundDryFire;
	sfxActivate    = SoundPickUpWeapon;
};

ItemData LiLPOOmki {
	description = "LiL POO mki";
	className   = "Weapon";
	shapeFile   = "sniper";
    validateShape = false;
	hudIcon       = "sniper";
    heading       = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType        = LiLPOOmkiImage;
	price            = 125;
	showWeaponBar    = true;
};
function LiLPOOmki::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }
//===========================================================================================


ItemData LiLPOOmkiiAmmo
{
	description = "Bullet mkii";
	className   = "Ammo";
	shapeFile   = "ammo1";
    heading     = "xAmmunition";
	shadowDetailMask = 4;
	price            = 25;
};
ItemImageData LiLPOOmkiiImage
{
	shapeFile  = "sniper";
	mountPoint = 0;
	weaponType = 0; 
	reloadTime = 0;
	fireTime   = 0.02;
	ammoType   = LiLPOOmkiiAmmo;
	projectileType = LiLPOOmkiiBullet;
	accuFire       = true;
	sfxFire        = SoundMayhemAssaultRifle;
	sfxActivate    = SoundPickUpWeapon;
};
ItemData LiLPOOmkii
{
	description = "LiL POO mkii";
	className   = "Weapon";
	shapeFile   = "sniper";
	hudIcon     = "sniper";
    heading     = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType        = LiLPOOmkiiImage;
	price            = 125;
	showWeaponBar    = true;
};
function LiLPOOmkii::onUse(%player,%item)
{ Weapon::onUse(%player, %item); }
//===========================================================================================

ItemData PlasmaAmmo {
	description = "Plasma Bolt";
    heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};
ItemImageData PlasmaGunImage {
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0; 
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.03;
	fireTime = 0.03;
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};
ItemData PlasmaGun {
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
    heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
    validateShape = false;
};
function PlasmaGun::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }
//===========================================================================================

ItemData GrenadeAmmo {
	description = "Grenade Ammo";
	className   = "Ammo";
	shapeFile   = "grenammo";
    heading     = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage {
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType   = GrenadeAmmo;
	projectileType = GrenadeShell;
	accuFire       = false;
	reloadTime     = 0.05;
	fireTime       = 0.05;
	sfxFire        = SoundFireGrenade;
	sfxActivate    = SoundPickUpWeapon;
	sfxReload      = SoundDryFire;
};

ItemData GrenadeLauncher {
	description = "Grenade Launcher";
	className   = "Weapon";
	shapeFile   = "grenadeL";
	hudIcon     = "grenade";
    heading     = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
    validateShape = false;
};

function GrenadeLauncher::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }
//===========================================================================================

ItemData LiLFFBAmmo { 
	description = "LiLFFB Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "grenammo";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData LiLFFBImage { 
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = LiLFFBAmmo;
	projectileType = LiLFFBShell;
	accuFire = false;
	reloadTime = 1;
	fireTime = 0;
	sfxFire = SoundMortarTurretFire;
	sfxActivate = SoundChainTurretOn;
	sfxReady = SoundGeneratorPower;
};
ItemData LiLFFB
{ 
	description = "LiLForce Field Buster";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = LiLFFBImage;
	price = 100;
	showWeaponBar = true;
};
function LiLFFB::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }