// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemData PlasmaAmmo
{
description = "Plasma Bolt";
heading = "xAmmunition";
className = "Ammo";
shapeFile = "plasammo";
shadowDetailMask = 4;
price = 2;
};

ItemImageData PlasmaGunImage
{
shapeFile = "plasma";
mountPoint = 0;

weaponType = 0; // Single Shot
//ammoType = PlasmaAmmo;
projectileType = PlasmaBolt;
accuFire = true;
reloadTime = 0.1;
fireTime = 0.5;

lightType = 3;  // Weapon Fire
lightRadius = 3;
lightTime = 1;
lightColor = { 1, 1, 0.2 };

sfxFire = SoundFirePlasma;
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
description = "Plasma Gun";
className = "Weapon";
shapeFile = "plasma";
hudIcon = "plasma";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = PlasmaGunImage;
price = 175;
showWeaponBar = true;
validateShape = true;
};

AddToRP(PlasmaGun);
AddWeapon(PlasmaGun);
