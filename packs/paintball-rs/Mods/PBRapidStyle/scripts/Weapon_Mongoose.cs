
//Mongoose Paintball
//--------------------------------------
BulletData MongooseBUlletAuto
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00029;
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
	price = 2;
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
	description = "MoNGooSe 2350";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = MongooseImage;
	price = 180;
	showWeaponBar = true;
};
function MongooseImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[Mongoose]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,Mongoose] == 1 || $LCDMode[%client,Mongoose] == "")
		{
			Projectile::spawnProjectile("MongooseBulletAuto",%trans,%player,%vel);
			GameBase::playSound(%player,bigExplosion4,0);
		 	Player::decItemCount(%player,MongooseAmmo);
		}
		else if($LCDMode[%client,Mongoose] == 2)
		{
                        Projectile::spawnProjectile("MongooseBullet3Shot",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
                        schedule("Projectile::spawnProjectile(\"MongooseBullet3Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.1);
                        schedule("Projectile::spawnProjectile(\"MongooseBullet3Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*3);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2*2);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2*3);
			Player::trigger(%player,$WeaponSlot,false);
		}
	        else if($LCDMode[%client,Mongoose] == 3)
		{
                        Projectile::spawnProjectile("MongooseBullet6Shot",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
                        schedule("Projectile::spawnProjectile(\"MongooseBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.1);
                        schedule("Projectile::spawnProjectile(\"MongooseBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.2);
                        schedule("Projectile::spawnProjectile(\"MongooseBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.3);
                        schedule("Projectile::spawnProjectile(\"MongooseBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.4);
                        schedule("Projectile::spawnProjectile(\"MongooseBullet6Shot\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.5);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*2);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*3);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*4);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*5);
		 	schedule("GameBase::playSound("@%player@",bigExplosion4,"@0@");",0.2*6);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2*2);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2*3);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2*4);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2*5);
		 	schedule("Player::decItemCount("@%player@",MongooseAmmo);",0.2*6);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Mongoose] == 4)
		{
			Projectile::spawnProjectile("MongooseBulletSemi",%trans,%player,%vel);
			GameBase::playSound(%player,bigExplosion4,0);
		 	Player::decItemCount(%player,MongooseAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Mongoose] == 5)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
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
$ItemMax[larmor, MongooseAmmo] = 275;
$ItemMax[lfemale, Mongoose] = 1;
$ItemMax[lfemale, MongooseAmmo] = 275;
$InvList[Mongoose] = 1;
$InvList[MongooseAmmo] = 0;
