//--------------------------------------

$AutoUse[Laser] = True;
$WeaponAmmo[Laser] = "";

//--------------------------------------

$InvList[Laser] = 1;
$RemoteInvList[Laser] = 1;

//--------------------------------------

ItemImageData LaserImage
{
	shapeFile = "Breath";
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

ItemData Laser
{
	description = "Laser";
	className = "Weapon";
	shapeFile = "Force";
	hudIcon = "sniper";
   heading = "dPowers";
	shadowDetailMask = 4;
	imageType = LaserImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

//--------------------------------------
function Laser::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Laser: <f2>Slice your enemy in half.");
}
