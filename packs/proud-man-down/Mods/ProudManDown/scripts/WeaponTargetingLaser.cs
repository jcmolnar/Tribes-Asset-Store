//--------------------------------------

$AutoUse[TargetingLaser] = False;

//--------------------------------------

$InvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;

//--------------------------------------

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

//--------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "mortar";//!B
	mountPoint = 0;//!U

	weaponType = 2; // Sustained//!L
	projectileType = targetLaser;//!E
	accuFire = true;//!T
	minEnergy = 0;//!Z
	maxEnergy = 0.5;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0, 0, 0 };

	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Binoculars";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

ItemImageData TargetingLaser2Image 
{
	shapeFile = "mortar";
	mountPoint = 0;
	mountOffset = { -0.160, 0, 0.138 };
	weaponType = 2;
	accuFire = true;
};

ItemData TargetingLaser2
{
	description = "Binoculars";
	shapeFile = "plasma";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TargetingLaser2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function TargetingLaser::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,TargetingLaser2,4);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "Binoculars.");
}

function TargetingLaser::onUnmount(%player,%item)
{
	Player::unmountItem(%player,4);
}

//--------------------------------------