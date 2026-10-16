//--------------------------------|
// Author: Whoever Made VX5
// Modified By: [TG]-X-Ecutioner
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//--------------------------------|
//
// * These are the itemdata blocks for various energy weapons. The reason 
// these weapons are all in one file is that these weapons don't require 
// special functions such as onFire or onMount.
//===========================================================================================


ItemImageData LaserRifleImage {
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	projectileType = sniperLaser;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 0.5;
	reloadTime = 0.03;
	fireTime = 0.03;
	sfxFire     = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle {
	description   = "Laser Rifle 6.7";
	className     = "Weapon";
	shapeFile     = "sniper";
	hudIcon       = "sniper";
	heading       = $InvHeading[EnergyWeapons];
	shadowDetailMask = 4;
	imageType     = LaserRifleImage;
	price         = 100;
	showWeaponBar = true;
};

function LaserRifle::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }
//===========================================================================================


ItemImageData TaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	projectileType = TaserRfLaser;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 0.5;
	reloadTime = 0.08;
	sfxFire     = SoundTaserFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundEnergyPackOn;
};
ItemData TaserRifle
{
	description   = "Taser Rifle";
	className     = "Weapon";
	shapeFile     = "sniper";
	hudIcon       = "sniper";
	heading       = $InvHeading[EnergyWeapons];
	shadowDetailMask = 4;
	imageType     = TaserRifleImage;
	price         = 100;
	showWeaponBar = true;
};
function TaserRifle::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }
//===========================================================================================


ItemImageData EnergyRifleImage
{
	shapeFile   = "shotgun";
	mountPoint  = 0;
	weaponType  = 2;
	projectileType = lightningCharge;
	minEnergy   = 3;
	maxEnergy   = 11;
	reloadTime  = 0.08;
	lightType   = 3;
	lightRadius = 2;
	lightTime   = 1;
	lightColor  = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
   shapeFile = "shotgun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = $InvHeading[EnergyWeapons];
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
   showWeaponBar = true;
   price = 125;
   validateShape = false;
};
function EnergyRifle::onUse(%player, %item)
{ Weapon::onUse(%player,%item); }
//===========================================================================================


ItemImageData BeamOfPainImage {
	shapeFile   = "shotgun";
	mountPoint  = 0;
	mountoffset = { 0, 0, -0.2 };
	mountrotation = { 0, 3, 0 };
	weaponType  = 2;
	projectileType = BeamOfPainProj;
	minEnergy = 3;
	maxEnergy = 11;
	reloadTime = 0.03;
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundELFFire;
};

ItemData BeamOfPain {
	description = "Beam Of Pain";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = $InvHeading[EnergyWeapons];
	shadowDetailMask = 4;
	imageType = BeamOfPainImage;
	showWeaponBar = true;
	price = 125;
	validateShape = false;
};

function BeamOfPain::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }
//===========================================================================================


ItemImageData TargetingLaserImage {
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};
ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
    heading = $InvHeading[EnergyWeapons];
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};
function TargetingLaser::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }