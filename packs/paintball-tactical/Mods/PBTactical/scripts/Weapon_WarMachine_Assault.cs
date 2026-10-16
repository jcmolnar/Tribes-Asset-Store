
//WMAssault Paintball
//--------------------------------------
BulletData WMAssaultBUlletAuto
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = orangepaintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00299;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 0.0, 0.0, 50.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData WMAssaultBUllet3Shot
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = orangepaintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00199;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 0.0, 0.0, 50.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData WMAssaultBUllet6Shot
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = orangepaintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.002;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 0.0, 0.0, 50.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData WMAssaultBUlletSemi
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = orangepaintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.0007;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 0.0, 0.0, 50.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------
ItemImageData WM1Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0.0, -0.3, 0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.18 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData WM1
{
	description = "WM1";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = WM1Image;
	showWeaponBar = false;
};

ItemImageData WM2Image
{
	shapeFile = "grenade";
	mountPoint = 0; 
	mountOffset = { 0, -0.15, -0.26 }; //-  left-right, back-front, up-down
	mountRotation = { -3.05, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData WM2
{
	description = "WM2";
	className = "Weapon";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	imageType = WM2Image;
	showWeaponBar = false;
};


ItemData WMAssaultAmmo
{
	description = "WMAssault Paintballs";
   heading = $InvHead[ihPbs];
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData WMAssaultImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = WMAssaultAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.09;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[WMAssault] = 4;
$LCDName[WMAssault,1] = "Full-Auto";
$LCDName[WMAssault,2] = "3Shot-Burst";
$LCDName[WMAssault,3] = "6Shot-Burst";
$LCDName[WMAssault,4] = "Semi-Auto";
$LCDName[WMAssault,5] = "Safety";

ItemData WMAssault
{
	description = "WarMachine Assault 80";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = $InvHead[ihGun];
	shadowDetailMask = 4;
	imageType = WMAssaultImage;
	price = 0;
	showWeaponBar = true;
};
function WMAssaultImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[WMAssault]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = LabRat::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,WMAssault] == 1 || $LCDMode[%client,WMAssault] == "")
		{
			%proj = Projectile::spawnProjectile("WMAssaultBulletAuto",%trans,%player,%vel);
			GameBase::playSound(%player,bigExplosion4,0);
		 	Player::decItemCount(%player,WMAssaultAmmo);
		}
		else if($LCDMode[%client,WMAssault] == 2)
		{
                        %proj = Projectile::spawnProjectile("WMAssaultBullet3Shot",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
                        schedule("Projectile::spawnProjectile(\"WMAssaultBullet3Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.1);
                        schedule("Projectile::spawnProjectile(\"WMAssaultBullet3Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*3);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2*2);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2*3);
			Player::trigger(%player,$WeaponSlot,false);
		}
	        else if($LCDMode[%client,WMAssault] == 3)
		{
                        %proj = Projectile::spawnProjectile("WMAssaultBullet6Shot",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
                        schedule("Projectile::spawnProjectile(\"WMAssaultBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.1);
                        schedule("Projectile::spawnProjectile(\"WMAssaultBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.2);
                        schedule("Projectile::spawnProjectile(\"WMAssaultBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.3);
                        schedule("Projectile::spawnProjectile(\"WMAssaultBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.4);
                        schedule("Projectile::spawnProjectile(\"WMAssaultBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.5);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*3);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*4);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*5);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*6);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2*2);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2*3);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2*4);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2*5);
		 	schedule("Player::decItemCount("@%player@",WMAssaultAmmo);",0.2*6);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,WMAssault] == 4)
		{
			%proj = Projectile::spawnProjectile("WMAssaultBulletSemi",%trans,%player,%vel);
			GameBase::playSound(%player,bigExplosion4,0);
		 	Player::decItemCount(%player,WMAssaultAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,WMAssault] == 5)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
}

//Mounts

function WMAssault::onMount(%player,%item)
{
	Player::mountItem(%player, WM1, 5);
	Player::mountItem(%player, WM2, 6);
}

function WMAssault::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
}

//Important Stuff
$ItemMax[larmor, WMAssault] = 1;
$ItemMax[larmor, WMAssaultAmmo] = 250;
$ItemMax[lfemale, WMAssault] = 1;
$ItemMax[lfemale, WMAssaultAmmo] = 250;
$InvList[WMAssault] = 1;
$InvList[WMAssaultAmmo] = 0;