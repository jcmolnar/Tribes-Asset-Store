BulletData PaintPellet1
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = RedPaintSplatExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 50.0, 0.0, 0.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

BulletData PaintPellet2
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = BluePaintSplatExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 0.0, 50.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

BulletData PaintPellet3
{
   bulletShapeName    = "paint.dts";
   explosionTag       = greenPaintSplatExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 50.0, 0.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

BulletData PaintPellet4
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = OrangePaintSplatExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 50.0, 0.0, 0.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

ItemData AWPTShotgunAmmo
{
	description = "AWPT Shotgun Shells";
   heading = $InvHead[ihPbs];
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData AWPTShotgun5Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0.6, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 1.57, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AWPTShotgun5
{
	description = "AWPTShotgun5";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = AWPTShotgun5Image;
	showWeaponBar = false;
};

ItemImageData AWPTShotgun4Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 0.20, -0.30 }; //-  left-right, back-front, up-down
	mountRotation = { -1.55, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AWPTShotgun4
{
	description = "AWPTShotgun4";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = AWPTShotgun4Image;
	showWeaponBar = false;
};

ItemImageData AWPTShotgun3Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.0, -0.03 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AWPTShotgun3
{
	description = "AWPTShotgun3";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = AWPTShotgun3Image;
	showWeaponBar = false;
};

ItemImageData AWPTShotgun2Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AWPTShotgun2 
{
	description = "AWPTShotgun2";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = AWPTShotgun2Image;
	showWeaponBar = false;
};

ItemImageData AWPTShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountOffset = { 0, 0.0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right

	weaponType = 0; // Spinning
	reloadTime = 0.8;
	fireTime = 0.5;

	ammoType = AWPTShotgunAmmo;
	//projectileType = ;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = bigExplosion4;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AWPTShotgun
{
	description = "AWPT Shotgun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "paintgun";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AWPTShotgunImage;
	price = 0;
	showWeaponBar = true;
};

function AWPTShotgun::onMount(%player,%item)
{
	Player::mountItem(%player,AWPTShotgun2,7);
	Player::mountItem(%player,AWPTShotgun3,6);
	Player::mountItem(%player,AWPTShotgun4,5);
	Player::mountItem(%player,AWPTShotgun5,4);
}

function AWPTShotgun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,4);
}

function AWPTShotgunImage::onFire(%player,%slot)
{

	for(%i = 0; %i < 3; %i++)
	{
		%client = Player::getClient(%player);
		%trans = LabRat::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("PaintPellet1",%trans,%player,%vel);
		Projectile::spawnProjectile("PaintPellet2",%trans,%player,%vel);
		Projectile::spawnProjectile("PaintPellet3",%trans,%player,%vel);
		Projectile::spawnProjectile("PaintPellet4",%trans,%player,%vel);
	}

	Player::decItemCount(%player,$WeaponAmmo[AWPTShotgun],1);
}

//Important Stuff
$ItemMax[larmor, AWPTShotgun] = 1;
$ItemMax[larmor, AWPTShotgunAmmo] = 24;
$ItemMax[lfemale, AWPTShotgun] = 1;
$ItemMax[lfemale, AWPTShotgunAmmo] = 24;
$InvList[AWPTShotgun] = 1;
$InvList[AWPTShotgunAmmo] = 0;	