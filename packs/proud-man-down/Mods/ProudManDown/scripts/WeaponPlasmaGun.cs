//--------------------------------------

$AutoUse[PlasmaGun] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackItems[1] = PlasmaAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

//--------------------------------------

$InvList[PlasmaGun] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

//--------------------------------------

GrenadeData ForceShell
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = BulletExp3;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 8.0;
   density = 8.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 5.0;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.001;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   isVisible          = False;
   smokeName              = "rsmoke.dts";

};

BulletData MuzzleSmoke
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = SmokeyExp;
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

BulletData ARBullet
{
   bulletShapeName    = "tracer.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0035;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 9.0;
   tracerLength       = 9.0;

soundId = SoundWindGust; // This makes the bullet hiss
			 // if it passes by your head.
			 // Adds to the realism of the
			 // bullet.  --Deadtaco

};

//--------------------------------------


ItemData PlasmaAmmo
{
	description = "Machine Gun Ammo";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "shotgun";//!B
	mountPoint = 0;//!U
	mountOffset = { -0.18, -0.2, -0.1 };//!L -0.07
      mountRotation = { 0,-1.57, 0 };//!E

	weaponType = 0; //!T
	ammoType = PlasmaAmmo;//!Z
//	projectileType = ARBullet;
	maxEnergy = 50.6;
	minGunEnergy = 0.1;
	maxGunEnergy = 0.5;
	accuFire = false;
	reloadTime = 0;
	fireTime = 0.13;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
   	lightColor = { 0.4, 0.4, 1.0 };

	sfxFire = MachineGunFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PlasmaGun
{
	description = "Machine Gun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chaingun";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

ItemImageData PlasmaGun2Image 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { -0.22, -0.2, -0.18 }; //-0.11
      mountRotation = { 0,-0, 0 };
	weaponType = 0;
	projectileType = ARbullet;
	accuFire = true;
};

ItemData PlasmaGun2
{
	description = "Machine Gun";
	shapeFile = "sniper";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PlasmaGun2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function PlasmaGun::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,PlasmaGun2,4);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>SMG: <f2>Standard Automatic Rifle.");
}

function PlasmaGun::onUnmount(%player,%item)
{
	Player::unmountItem(%player,4);
}

function PlasmaGunImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ARBullet",%trans,%player,%vel);
	Player::setAnimation(%player, 15);
                GameBase::playSound(%player,debrisLargeExplosion,0);
}

//--------------------------------------