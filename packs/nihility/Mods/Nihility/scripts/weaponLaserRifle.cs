//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(LaserRifle);
$InvList[LaserRifle] = 1;

$AutoUse[LaserRifle] = True;
$WeaponAmmo[LaserRifle] = "";

$ItemMax[larmor, LaserRifle] = 1;		//Seraph
$ItemMax[lfemale, LaserRifle] = 1;		//Seraph
$ItemMax[earmor, LaserRifle] = 0;		//Slave
$ItemMax[efemale, LaserRifle] = 0;		//Slave
$ItemMax[marmor, LaserRifle] = 0;		//Pawn
$ItemMax[aarmor, LaserRifle] = 0;		//Navigator
$ItemMax[darmor, LaserRifle] = 0;		//Atomizer
$ItemMax[barmor, LaserRifle] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


LaserData sniperLaseri 
{
	laserBitmapName = "plasmabolt.bmp";
	hitName = "plasmaex.dts";//laserhit
	damageConversion = 0.0195;
	baseDamageType = $LaserDamageType;
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
}; 




ItemImageData LaserRifleImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, -2.00, 0};
	weaponType = 0;
	projectileType = SniperLaseri;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
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
	price = 77;
	showWeaponBar = true;
}; 

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
	Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Laser Rifle", 2);
}
  