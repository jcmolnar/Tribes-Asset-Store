//Mod by BuLeTz/Sahb. Not to be modded without my permission. Contact me at BuLeTz@hotmail.com to be granted permission.
//--------------------------------------

$SellAmmo[BulletAmmo] = 5;
$AmmoPackMax[BulletAmmo] = 170;
$AmmoPackItems[2] = BulletAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;

//--------------------------------------

$InvList[Chaingun] = 1;
$InvList[BulletAmmo] = 1;
$RemoteInvList[Chaingun] = 1;
$RemoteInvList[BulletAmmo] = 1;

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 625.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;

soundId = SoundWindGust;

};

BulletData SMGMuzzleFlare
{
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = SmokayExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.00;
   muzzleVelocity     = 2.0;
   totalTime          = 0.035;
   isVisible          = true;

};

ItemData BulletAmmo 
{
	description = "SMG Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 75;
};

ItemImageData ChaingunImage 
{
	shapeFile = "shotgun";//B
	mountPoint = 0;//U
	mountOffset = { -0.07, -0.2, 0 };//L
      mountRotation = { 0,1.57, 0 };//E
	weaponType = 0;//T	
//	projectileType = Chaingunbullet;//Z
	accuFire = true;
	ammoType = BulletAmmo;
	reloadTime = 0;
	fireTime = 0.1;	
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
   	lightColor = { 0.4, 0.4, 1.0 };
	sfxFire = SMGFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Chaingun 
{
	description = "SMG";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "mortar";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 375;
	showWeaponBar = true;
};

ItemImageData Chaingun2Image 
{
	shapeFile = "plasma";
	mountPoint = 0;
	mountOffset = { -0.07, -0.2, -0.08 };
      mountRotation = { 0,-0, 0 };
	weaponType = 0;
	accuFire = true;
};

ItemData Chaingun2
{
	description = "SMG";
	shapeFile = "plasma";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = Chaingun2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function Chaingun::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,Chaingun2,4);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>SMG: <f2>Standard Sub-Machinegun.");
}

function Chaingun::onUnmount(%player,%item)
{
	Player::unmountItem(%player,4);
}

function ChaingunImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	Player::decItemCount(%player,$WeaponAmmo[Chaingun],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
}

//--------------------------------------