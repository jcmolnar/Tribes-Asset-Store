
//Mongoose Paintball
//--------------------------------------
BulletData MongooseBUlletAuto
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00299;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData MongooseBUllet3Shot
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00199;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData MongooseBUllet6Shot
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.002;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData MongooseBUlletSemi
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.0007;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//-------------------------------------- Admin Manip
BulletData MongooseBUlletAutoM
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00299 * $PB::Menu::ManipAim;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData MongooseBUllet3ShotM
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00199 * $PB::Menu::ManipAim;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData MongooseBUllet6ShotM
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.002 * $PB::Menu::ManipAim;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData MongooseBUlletSemiM
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.0007 * $PB::Menu::ManipAim;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------

ItemImageData M1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0.05, 0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData M1
{
	description = "M1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = M1Image;
	showWeaponBar = false;
};

ItemImageData M2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.15, 0.35 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData M2
{
	description = "M2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = M2Image;
	showWeaponBar = false;
};

ItemImageData M3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.26, -0.23 }; //-  left-right, back-front, up-down
	mountRotation = { -3.05, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData M3
{
	description = "M3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = M3Image;
	showWeaponBar = false;
};

ItemImageData M4Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.10 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData M4
{
	description = "M4";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = M4Image;
	showWeaponBar = false;
};

ItemData MongooseAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData MongooseImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = MongooseAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.123;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[Mongoose] = 5;
$LCDName[Mongoose,1] = "Full-Auto";
$LCDName[Mongoose,2] = "3Shot-Burst";
$LCDName[Mongoose,3] = "6Shot-Burst";
$LCDName[Mongoose,4] = "Semi-Auto";
$LCDName[Mongoose,5] = "Safety";

ItemData Mongoose
{
	description = "Diablo Mongoose LCD";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MongooseImage;
	price = 200;
	showWeaponBar = true;
};
function MongooseImage::onFire(%player,%slot) 
{
	checkFireTime(%player);

	if (%player.waitFire)
		return;

	%ammo = Player::getItemCount(%player,$WeaponAmmo[Mongoose]);
	if(%ammo)
	{
		%client	= Player::getClient(%player);
		%trans	= GameBase::getMuzzleTransform(%client);
		%vel	= Item::getVelocity(%player);
		%mode	= %client.LCDMode[Mongoose];
		%manip	= "";

		if (%client.manipAim)
			%manip = "M";

		// Full-Auto
		if ((%mode == 1) || (%mode == ""))
		{
			Projectile::spawnProjectile("MongooseBulletAuto" @ %manip, %trans, %player, %vel);
			GameBase::playSound(%player, bigExplosion4, 0);
		 	Player::decItemCount(%player, MongooseAmmo);
		}

		// 3-Shot or 6-Shot Burst
		else if ((%mode == 2) || (%mode == 3))
		{
			%player.waitFire = true;
			%shots = 3;
			if (%mode == 3)
				%shots = 6;

			if ((%ammo - %shots) < 0)
				%shots = %ammo;

			for (%a = 0; %a < %shots; %a++)
			{
	                        schedule("Projectile::spawnProjectile(MongooseBullet"@%shots@"Shot"@%manip@", GameBase::getMuzzleTransform("@%player@"), "@%player@", Item::getVelocity("@%player@"));", %a * 0.1);
			 	schedule("GameBase::playSound("@%player@", bigExplosion4, 0);", %a * 0.1);
			 	schedule("Player::decItemCount("@%player@", MongooseAmmo);", %a * 0.1);
			}
			schedule(%player @ ".waitFire = \"\";", %a * 0.1);
			Player::trigger(%player,$WeaponSlot,false);
		}

		// Semi-Auto
		else if (%mode == 4)
		{
			Projectile::spawnProjectile("MongooseBulletSemi" @ %manip, %trans, %player, %vel);
			GameBase::playSound(%player, bigExplosion4, 0);
		 	Player::decItemCount(%player, MongooseAmmo);
			Player::trigger(%player, $WeaponSlot, false);
		}

		// Safety
		else
		{
			GameBase::playSound(%player, SoundWeaponSelect, 1);
			Player::trigger(%player, $WeaponSlot, false);
		}
	}
}

//Mounts

function Mongoose::onMount(%player,%item)
{

	Player::mountItem(%player, M1, 4);
	Player::mountItem(%player, M2, 5);
	Player::mountItem(%player, M3, 6);
	Player::mountItem(%player, M4, 7);
}

function Mongoose::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, Mongoose] = 1;
$ItemMax[larmor, MongooseAmmo] = $PB::AmmoMax;
$ItemMax[lfemale, Mongoose] = 1;
$ItemMax[lfemale, MongooseAmmo] = $PB::AmmoMax;
$InvList[Mongoose] = 1;
$InvList[MongooseAmmo] = 0;