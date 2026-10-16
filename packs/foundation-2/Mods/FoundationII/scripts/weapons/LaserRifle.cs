//--------------------------------------

$AutoUse[LaserRifle] = True;
$WeaponAmmo[LaserRifle] = "";

addToInv(LaserRifle,1,1);

setArmorItemMax(LaserRifle,1,1,0);

//--------------------------------------

LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName	     = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime	     = 0.5;

   lightRange	     = 2.0;
   lightColor	     = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId	     = SoundLaserHit;
};

//--------------------------------------

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
	maxEnergy = 70;

	lightType = 3;	// Weapon Fire
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
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
   //validateMaterials = true;
};

function LaserRifle::onUse(%player,%item)
{
	%pack = Player::getMountedItem(%player,$BackpackSlot);
	if(%pack == EnergyPack || %pack == PerGenPack || %pack == UltimaPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Laser Rifle.");
}

$MountMSG[LaserRifle] = "<JC><F2>Laser Rifle <F0>- <F1>Fires a powerful laser that will cut through the target.";

AddWeapon(LaserRifle);
