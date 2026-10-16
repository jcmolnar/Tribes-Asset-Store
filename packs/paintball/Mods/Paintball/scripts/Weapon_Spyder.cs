
//Spyder Paintball
//--------------------------------------
BulletData SpyderBUlletAuto
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

BulletData SpyderBUllet3Shot
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

BulletData SpyderBUllet6Shot
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

BulletData SpyderBUlletSemi
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
BulletData SpyderBUlletAutoM
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

BulletData SpyderBUllet3ShotM
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

BulletData SpyderBUllet6ShotM
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

BulletData SpyderBUlletSemiM
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

ItemImageData S1Image
{
	shapeFile = "GrenadeL";
	mountPoint = 0; 
	mountOffset = { 0, 0.25, 0.10 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData S1
{
	description = "S1";
	className = "Weapon";
	shapeFile = "GrenadeL";
	shadowDetailMask = 4;
	imageType = S1Image;
	showWeaponBar = false;
};

ItemImageData S2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.10, 0.30 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData S2
{
	description = "S2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = S2Image;
	showWeaponBar = false;
};

ItemImageData S3Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData S3
{
	description = "S3";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = S3Image;
	showWeaponBar = false;
};

ItemImageData S4Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.20, -0.10 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData S4
{
	description = "S4";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = S4Image;
	showWeaponBar = false;
};

ItemData SpyderAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData SpyderImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = SpyderAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.199;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[Spyder] = 4;
$LCDName[Spyder,1] = "Full-Auto";
$LCDName[Spyder,2] = "3Shot-Burst";
$LCDName[Spyder,3] = "6Shot-Burst";
$LCDName[Spyder,4] = "Semi-Auto";
$LCDName[Spyder,5] = "Safety";

ItemData Spyder
{
	description = "Spyder E-99";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SpyderImage;
	price = 160;
	showWeaponBar = true;
};
function SpyderImage::onFire(%player,%slot) 
{
	checkFireTime(%player);

	if (%player.waitFire)
		return;

	%ammo = Player::getItemCount(%player,$WeaponAmmo[Spyder]);
	if(%ammo)
	{
		%client	= Player::getClient(%player);
		%trans	= GameBase::getMuzzleTransform(%client);
		%vel	= Item::getVelocity(%player);
		%mode	= %client.LCDMode[Spyder];
		%manip	= "";

		if (%client.manipAim)
			%manip = "M";

		// Full-Auto
		if ((%mode == 1) || (%mode == ""))
		{
			Projectile::spawnProjectile("SpyderBulletAuto" @ %manip, %trans, %player, %vel);
			GameBase::playSound(%player, SoundFirePlasma, 0);
		 	Player::decItemCount(%player, SpyderAmmo);
		}

		// 3-Shot or 6-Shot
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
	                        schedule("Projectile::spawnProjectile(SpyderBullet"@%shots@"Shot"@%manip@", GameBase::getMuzzleTransform("@%player@"), "@%player@", Item::getVelocity("@%player@"));",%a * 0.1);
		 		schedule("GameBase::playSound("@%player@", SoundFirePlasma, 0);",%a * 0.1);
		 		schedule("Player::decItemCount("@%player@", SpyderAmmo);", %a * 0.1);
			}
			schedule(%player @ ".waitFire = \"\";", %a * 0.1);
			Player::trigger(%player,$WeaponSlot,false);
		}

		// Semi-Auto
		else if (%mode == 4)
		{
			Projectile::spawnProjectile("SpyderBulletSemi" @ %manip, %trans, %player, %vel);
			GameBase::playSound(%player, SoundFirePlasma, 0);
		 	Player::decItemCount(%player, SpyderAmmo);
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

function Spyder::onMount(%player,%item)
{
	Player::mountItem(%player, S1, 4);
	Player::mountItem(%player, S2, 5);
	Player::mountItem(%player, S3, 6);
	Player::mountItem(%player, S4, 7);
}

function Spyder::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, Spyder] = 1;
$ItemMax[larmor, SpyderAmmo] = $PB::AmmoMax;
$ItemMax[lfemale, Spyder] = 1;
$ItemMax[lfemale, SpyderAmmo] = $PB::AmmoMax;
$InvList[Spyder] = 1;
$InvList[SpyderAmmo] = 0;
$InvList[Spyder] = 1;