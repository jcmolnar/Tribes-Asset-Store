//Mod by BuLeTz/Sahb. Not to be modded without my permission. Contact me at BuLeTz@hotmail.com to be granted permission.
//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;

//--------------------------------------

$InvList[Disclauncher] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[Disclauncher] = 1;
$RemoteInvList[DiscAmmo] = 1;

//--------------------------------------

BulletData RifleBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0006;
   muzzleVelocity     = 625.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 9.0;
   tracerLength       = 9.0;

soundId = SoundWindPast; // This makes the bullet hiss
			 // if it passes by your head.
			 // Adds to the realism of the
			 // bullet.  --Deadtaco

};

//--------------------------------------

ItemData DiscAmmo
{
	description = "Rifle Ammo";
	className = "Ammo";
	shapeFile = "liqcyl";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "sniper";//B
	mountPoint = 0;//U
	mountOffset = { 0, -0.4, 0.1 };//L -0.4
	mountRotation = {0, 3.1, 0 };//E	

	weaponType = 0; // Singleshot//T
	reloadTime = 0.35;//Z
	fireTime = 0.002;

	ammoType = DiscAmmo;
	
//	 projectileType = RifleBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
   	lightColor = { 0.4, 0.4, 1.0 };

	sfxFire = RifleFire;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundDryFire;
//	sfxReady = SoundPickUpWeapon;
};

ItemData DiscLauncher
{
	description = "Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chaingun";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 100;
	showWeaponBar = true;
};

ItemImageData DiscLauncher2Image 
{
	shapeFile = "energygun";
	mountPoint = 0;
	mountOffset = { 0, -0.5, 0.1 }; //-0.5
	mountRotation = {0, 3.1, 0 };	
	weaponType = 0;
	accuFire = true;
};

ItemData DiscLauncher2
{
	description = "Rifle";
	shapeFile = "sniper";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncher2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function DiscLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,DiscLauncher2,4);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>SMG: <f2>A rife for medium range shooting.");
}

function DiscLauncher::onUnmount(%player,%item)
{
	Player::unmountItem(%player,4);
}

function DiscLauncherImage::onFire(%player, %slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[DiscLauncher]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("RifleBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("SMGMuzzleFlare",%trans,%player,%vel);
                GameBase::playSound(%player,SoundDryFire,0);
		Player::decItemCount(%player,DiscAmmo);
		Player::trigger(%player,$WeaponSlot,false);
	}
}

//--------------------------------------