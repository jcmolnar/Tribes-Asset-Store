
//Angel Paintball
//--------------------------------------
BulletData AngelBUlletAuto
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00009;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData AngelBUllet3Shot
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

BulletData AngelBUllet6Shot
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

BulletData AngelBUlletSemi
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
//--------------------------------------

ItemImageData A1Image
{
	shapeFile = "plasma";
	mountPoint = 0; 
	mountOffset = { 0, 0.10, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData A1
{
	description = "A1";
	className = "Weapon";
	shapeFile = "plasma";
	shadowDetailMask = 4;
	imageType = A1Image;
	showWeaponBar = false;
};

ItemImageData A2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0.10, 0.10, 0.20 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0.30, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData A2
{
	description = "A2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = A2Image;
	showWeaponBar = false;
};

ItemImageData A3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.15, -0.26 }; //-  left-right, back-front, up-down
	mountRotation = { -3.05, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData A3
{
	description = "A3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = A3Image;
	showWeaponBar = false;
};

ItemData AngelAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData AngelImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = AngelAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.123;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[Angel] = 4;
$LCDName[Angel,1] = "Full-Auto";
$LCDName[Angel,2] = "3Shot-Burst";
$LCDName[Angel,3] = "6Shot-Burst";
$LCDName[Angel,4] = "Semi-Auto";
$LCDName[Angel,5] = "Safety";

ItemData Angel
{
	description = "UnhOlYAngl BuRstEr";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = AngelImage;
	price = 1300;
	showWeaponBar = true;
};
function AngelImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[Angel]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,Angel] == 1 || $LCDMode[%client,Angel] == "")
		{
			Projectile::spawnProjectile("AngelBulletAuto",%trans,%player,%vel);
			GameBase::playSound(%player,SoundFirePlasma,0);
		 	Player::decItemCount(%player,AngelAmmo);
		}
		else if($LCDMode[%client,Angel] == 2)
		{
                        Projectile::spawnProjectile("AngelBullet3Shot",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
                        schedule("Projectile::spawnProjectile(\"AngelBullet3Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.1);
                        schedule("Projectile::spawnProjectile(\"AngelBullet3Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*3);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2*2);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2*3);
			Player::trigger(%player,$WeaponSlot,false);
		}
	        else if($LCDMode[%client,Angel] == 3)
		{
                        Projectile::spawnProjectile("AngelBullet6Shot",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
                        schedule("Projectile::spawnProjectile(\"AngelBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.1);
                        schedule("Projectile::spawnProjectile(\"AngelBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.2);
                        schedule("Projectile::spawnProjectile(\"AngelBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.3);
                        schedule("Projectile::spawnProjectile(\"AngelBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.4);
                        schedule("Projectile::spawnProjectile(\"AngelBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.5);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*3);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*4);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*5);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*6);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2*2);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2*3);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2*4);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2*5);
		 	schedule("Player::decItemCount("@%player@",AngelAmmo);",0.2*6);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Angel] == 4)
		{
			Projectile::spawnProjectile("AngelBulletSemi",%trans,%player,%vel);
			GameBase::playSound(%player,SoundFirePlasma,0);
		 	Player::decItemCount(%player,AngelAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Angel] == 5)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
}

//Mounts

function Angel::onMount(%player,%item)
{
	Player::mountItem(%player, A1, 5);
	Player::mountItem(%player, A2, 6);
	Player::mountItem(%player, A3, 7);
}

function Angel::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, Angel] = 1;
$ItemMax[larmor, AngelAmmo] = 500;
$ItemMax[lfemale, Angel] = 1;
$ItemMax[lfemale, AngelAmmo] = 500;
$InvList[Angel] = 1;
$InvList[AngelAmmo] = 0;
