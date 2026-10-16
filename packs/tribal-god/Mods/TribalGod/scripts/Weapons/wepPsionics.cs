//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|


ItemData FireballAbilityAmmo
{
	description = "Fire Implants";
	className   = "Ammo";
	shapeFile   = "grenammo";
	heading     = "xAmmunition";
	shadowDetailMask = 4;
	price            = 5;
};
ItemImageData FireballAbilityImage
{
	shapeFile  = "plasmatrail";
	mountPoint = 0;
	weaponType = 0; 
	ammoType   = FireballAbilityAmmo;
	projectileType = Fireball;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};
ItemData FireballAbility
{
	description = "Fireball Ability";
	className   = "Weapon";
	shapeFile   = "plasmatrail";
	hudIcon     = "deployable";
	heading     = $InvHeading[PsionicsWeapons];
	shadowDetailMask = 4;
	imageType        = FireballAbilityImage;
	price            = 420;
	showWeaponBar    = true;
};
function FireballAbility::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }
//===========================================================================================


ItemData SmScreenAbilityAmmo
{
	description = "Smoke Implants";
	className   = "Ammo";
	shapeFile   = "grenammo";
	heading     = "xAmmunition";
	shadowDetailMask = 4;
	price            = 5;
};
ItemImageData SmScreenAbilityImage
{
	shapeFile  = "breath";
	mountPoint = 0;
    weaponType = 0;
    ammoType   = SmScreenAbilityAmmo;
    projectileType = SmScreen;
    accuFire       = true;
    reloadTime     = 0.1;
    fireTime       = 0;
    sfxFire        = SoundJetHeavy;
    sfxActivate    = SoundPickUpWeapon;
};

ItemData SmScreenAbility
{
	description = "SmokeScreen Ability";
	className   = "Weapon";
    shapeFile   = "breath";
    hudIcon     = "deployable";
    heading     = $InvHeading[PsionicsWeapons];
    shadowDetailMask = 4;
    imageType        = SmScreenAbilityImage;
    price            = 23;
    showWeaponBar    = true;
};
function SmScreenAbility::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }
//===========================================================================================


ItemData ExSmScreenAbilityAmmo
{
	description = "Lair Implants";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ExSmScreenAbilityImage
{
	shapeFile = "enbolt";
    mountPoint = 0;
    weaponType = 0;
    ammoType = ExSmScreenAbilityAmmo;
    projectileType = ExSmScreen;
    accuFire = true;
    reloadTime = 0.5;
    fireTime = 0;
    sfxFire = SoundJetHeavy;
    sfxActivate = SoundPickUpWeapon;
};

ItemData ExSmScreenAbility
{
    description = "LairWaster";
    className = "Weapon";
    shapeFile = "enbolt";
    hudIcon = "deployable";
    heading = $InvHeading[PsionicsWeapons];
    shadowDetailMask = 4;
    imageType = ExSmScreenAbilityImage;
    price = 23;
    showWeaponBar = true;
};
function ExSmScreenAbility::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }
//===========================================================================================


ItemData FireScreenAbilityAmmo
{
	description = "FireWall Bombs";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FireScreenAbilityImage
{
	shapeFile = "plasmabolt";
    mountPoint = 0;
    weaponType = 0; 
    ammoType = FireScreenAbilityAmmo;
    projectileType = FireScreen;
    accuFire = true;
    reloadTime = 0.05;
    fireTime = 0;
    sfxFire = SoundJetHeavy;
    sfxActivate = SoundPickUpWeapon;
};

ItemData FireScreenAbility
{
    description = "FireWall";
    className = "Weapon";
    shapeFile = "plasmabolt";
    hudIcon = "deployable";
    heading = $InvHeading[PsionicsWeapons];
    shadowDetailMask = 4;
    imageType = FireScreenAbilityImage;
    price = 23;
    showWeaponBar = true;
};
function FireScreenAbility::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }
//===========================================================================================


ItemData SpellAbilityAmmo
{
	description = "SpellHeart";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SpellAbilityImage
{
	shapeFile = "breath";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.1;
	ammoType = SpellAbilityAmmo;
	projectileType = SpellAbilityproj;
	accuFire = true;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SpellAbility
{
	description = "Spell";
	className = "Weapon";
	shapeFile = "breath";
    validateShape = false;
	hudIcon = "sniper";
    heading = $InvHeading[PsionicsWeapons];
	shadowDetailMask = 4;
	imageType = SpellAbilityImage;
	price = 125;
	showWeaponBar = true;
};
function SpellAbility::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }