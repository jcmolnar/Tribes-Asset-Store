//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[TargetingLaser] = 1;

$AutoUse[TargetingLaser] = false;
$WeaponAmmo[TargetingLaser] = "";

$ItemMax[larmor, TargetingLaser] = 1;	//Seraph
$ItemMax[lfemale, TargetingLaser] = 1;	//Seraph
$ItemMax[earmor, TargetingLaser] = 1;	//Slave
$ItemMax[efemale, TargetingLaser] = 1;	//Slave
$ItemMax[marmor, TargetingLaser] = 1;	//Pawn
$ItemMax[aarmor, TargetingLaser] = 1;	//Navigator
$ItemMax[darmor, TargetingLaser] = 1;	//Atomizer
$ItemMax[barmor, TargetingLaser] = 1;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

TargetLaserData targetLaser 
{
	laserBitmapName = "paintPulse.bmp";
	damageConversion = 0.0;
	baseDamageType = 0;
	lightRange = 10.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
}; 


ItemImageData TargetingLaserImage 
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	reloadTime = 0.0;
	lightType = 3;
	lightRadius = 10;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData TargetingLaser 
{
	description = "Targeting Laser";
	className = "Tool";
	shapeFile = "paintgun";
	hudIcon = "targetlaser";
	heading = "fTools";
	shadowDetailMask = 4;
	imageType = TargetingLaserImage;
	price = 77;
	showWeaponBar = false;
}; 

function TargetingLaser::onUse(%player,%item)
{
Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Targeting Laser", 2); }
