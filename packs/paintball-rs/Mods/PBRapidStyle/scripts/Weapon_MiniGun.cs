
//MiniGun Paintball
//--------------------------------------
BulletData MiniGunBUllet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
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

ItemData MiniGunAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MiniGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down
        mountRotation = { 0, 3.15, 0 };//-  //- X= up-down , Y= roll-left-right , Z= left-right

	weaponType = 0; // Single Shot
	ammoType = MiniGunAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0009;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[MiniGun] = 4;
$LCDName[MiniGun,1] = "Full-Auto";
$LCDName[MiniGun,2] = "3Shot-Burst";
$LCDName[MiniGun,3] = "6Shot-Burst";
$LCDName[MiniGun,4] = "Semi-Auto";
$LCDName[MiniGun,5] = "Safety";

ItemData MiniGun
{
	description = "MiNi RaPtoR 30-6";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = MiniGunImage;
	price = 175;
	showWeaponBar = true;
};
function MiniGunImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[MiniGun]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,MiniGun] == 1 || $LCDMode[%client,MiniGun] == "")
		{
			Projectile::spawnProjectile("MiniGunBullet",%trans,%player,%vel);
			GameBase::playSound(%player,SoundFirePlasma,0);
		 	Player::decItemCount(%player,MiniGunAmmo);
		}
		else if($LCDMode[%client,MiniGun] == 2)
		{
                        Projectile::spawnProjectile("MiniGunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
                        schedule("Projectile::spawnProjectile(\"MiniGunBullet\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.1);
                        schedule("Projectile::spawnProjectile(\"MiniGunBullet\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*3);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2*2);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2*3);
			Player::trigger(%player,$WeaponSlot,false);
		}
	        else if($LCDMode[%client,MiniGun] == 3)
		{
                        Projectile::spawnProjectile("AngelBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
                        schedule("Projectile::spawnProjectile(\"MiniGunBullet\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.1);
                        schedule("Projectile::spawnProjectile(\"MiniGunBullet\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.2);
                        schedule("Projectile::spawnProjectile(\"MiniGunBullet\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.3);
                        schedule("Projectile::spawnProjectile(\"MiniGunBullet\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.4);
                        schedule("Projectile::spawnProjectile(\"MiniGunBullet\",GameBase::getMuzzleTransform("@%player@"),"@%player@",Item::getVelocity("@%player@"));",0.5);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*2);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*3);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*4);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*5);
		 	schedule("GameBase::playSound("@%player@",SoundFirePlasma,"@0@");",0.2*6);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2*2);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2*3);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2*4);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2*5);
		 	schedule("Player::decItemCount("@%player@",MiniGunAmmo);",0.2*6);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,MiniGun] == 4)
		{
			Projectile::spawnProjectile("MiniGunBullet",%trans,%player,%vel);
			GameBase::playSound(%player,SoundFirePlasma,0);
		 	Player::decItemCount(%player,MiniGunAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,MiniGun] == 5)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
}

//Important Stuff
$ItemMax[larmor, MiniGun] = 0;
$ItemMax[larmor, MiniGunAmmo] = 500;
$ItemMax[lfemale, MiniGun] = 0;
$ItemMax[lfemale, MiniGunAmmo] = 500;
$InvList[MiniGun] = 0;
$InvList[MiniGunAmmo] = 0;
