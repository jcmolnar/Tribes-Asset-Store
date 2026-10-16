//--------------------------------------

$AutoUse[Knife] = True;
$Use[Knife] = True;
$WeaponAmmo[Knife] = "";

//--------------------------------------

$InvList[Knife] = 1;
$RemoteInvList[Knife] = 1;

//--------------------------------------
BulletData Cutstab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = knifeExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.5;
   damageType         = $PlasmaDamageType;

   aimDeflection      = 0.00;
   muzzleVelocity     = 5.0;
   totalTime          = 0.035;
   isVisible          = False;
};

//--------------------------------------

ItemImageData KnifeImage
{
   shapeFile  = "bullet";//B
	mountPoint = 0;//U
	mountOffset = { 0, 0, 0 };//L
	mountRotation = { 0, 0, 0 };//E

	weaponType = 0; // Single Shot//T
	reloadTime = 0;//Z
	fireTime = 0.30;
	minEnergy = 0;
	maxEnergy = 0;

	projectileType = Cutstab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickupWeapon;
};

ItemData Knife
{
   heading = "cSecondary Weapons";
	description = "Knife";
	className = "Tool";
   shapeFile  = "bullet";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = KnifeImage;
	price = 85;
	showWeaponBar = true;
};