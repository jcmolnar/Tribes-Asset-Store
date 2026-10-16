// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

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

//ammoType = BulletAmmo;
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
heading = "bWeapons";
shadowDetailMask = 4;
imageType = ChaingunImage;
price = 125;
showWeaponBar = true;
};

AddToRP(Chaingun);
AddWeapon(Chaingun);
