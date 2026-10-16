// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
shapeFile = "sniper";
mountPoint = 0;

weaponType = 0; // Single Shot
projectileType = SniperLaser;
accuFire = true;
reloadTime = 0.1;
fireTime = 0.5;
minEnergy = 10;
maxEnergy = 60;

lightType = 3;  // Weapon Fire
lightRadius = 2;
lightTime = 1;
lightColor = { 1, 0, 0 };

sfxFire = SoundFireLaser;
sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
description = "Laser Rifle";
className = "Weapon";
shapeFile = "sniper";
hudIcon = "sniper";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = LaserRifleImage;
price = 200;
showWeaponBar = true;
validateShape = true;
validateMaterials = true;
};

function LaserRifle::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
Weapon::onUse(%player,%item);
else
Client::sendMessage(Player::getClient(%player),0,
"Must have an Energy Pack to use Laser Rifle.");
}

AddToRP(LaserRifle);
AddWeapon(LaserRifle);
