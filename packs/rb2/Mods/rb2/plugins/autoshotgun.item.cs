addPluginWeapon(LaserRifle, AutoShotgun);
 $AutoUse[AutoShotgun] = True;

 $SellAmmo[AutoShotgunAmmo] = 5;
 $AmmoPackMax[AutoShotgunAmmo] = 0;
 $WeaponAmmo[AutoShotgun] = AutoShotgunAmmo;

$InvList[AutoShotgun] = 1;
$RemoteInvList[AutoShotgun] = 1;
$InvList[AutoShotgunAmmo] = 1;
$RemoteInvList[AutoShotgunAmmo] = 1;
$HelpMessage[AutoShotgun] = "A fully automatic shotgun with a 12 round magazine.";

$ItemMax[hlarmor, AutoShotgun] = 0;
$ItemMax[hlfemale, AutoShotgun] = 0;
$ItemMax[marmor, AutoShotgun] = 0;
$ItemMax[mfemale, AutoShotgun] = 0;
$ItemMax[larmor, AutoShotgun] = 0;
$ItemMax[lfemale, AutoShotgun] = 0;
$ItemMax[earmor, AutoShotgun] = 0;
$ItemMax[efemale, AutoShotgun] = 0;
$ItemMax[harmor, AutoShotgun] = 1;
$ItemMax[uharmor, AutoShotgun] = 1;

$ItemMax[hlarmor, AutoShotgunAmmo] = 12;
$ItemMax[hlfemale, AutoShotgunAmmo] = 12;
$ItemMax[marmor, AutoShotgunAmmo] = 12;
$ItemMax[mfemale, AutoShotgunAmmo] = 12;
$ItemMax[larmor, AutoShotgunAmmo] = 12;
$ItemMax[lfemale, AutoShotgunAmmo] = 12;
$ItemMax[earmor, AutoShotgunAmmo] = 12;
$ItemMax[efemale, AutoShotgunAmmo] = 12;
$ItemMax[harmor, AutoShotgunAmmo] = 12;
$ItemMax[uharmor, AutoShotgunAmmo] = 12;






ItemData AutoShotgunAmmo
{
	description = "AutoShotgun Shells";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData AutoShotgunImage
{
	shapeFile = "bullet";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	// projectileType = ShotgunPellet;
	ammoType = AutoShotgunAmmo;
	accuFire = True;
	reloadTime = 0.0;
	fireTime = 0.2;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData AutoShotgun
{
	description = "H&K AutoShotgun";
	className = "PriWeapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = AutoShotgunImage;
	price = 250;
	showWeaponBar = true;
};

function AutoShotgun::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"You are as drunk as a skunk.  Stay off the molotovs!");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by a stun grenade.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>H&K CAW Autoshotgun - Spray the skies with a shower of lead.", 2);
	}
}


function AutoShotgunImage::onFire(%player, %slot)
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AutoShotgun]);
	
	if (%AmmoCount)
	 {
   		 playSound(turretExplosion,GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("GunFlame",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[AutoShotgun],1);
	 }
	 else
	 {
	 	playSound(SoundPackFail,GameBase::getPosition(%player));
	 	Player::trigger(%player,$WeaponSlot,false);
	 	Client::sendMessage(Player::getClient(%player), 0,"Shotgun is outta ammo!");
	 } 
}


//----------------------------extended model information------------------------------------

ItemImageData AutoShotgunScopeImage
{
	shapeFile  = "discammo";
	mountPoint = 0;
	mountRotation = { 1.1, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.1, -0.1 };

	ammoType = DummyAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};


ItemData AutoShotgunScope
{
	heading = "cSecondary Weapons";
	description = "AutoShotgunScope";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = AutoShotgunScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData AutoShotgunClipImage
{
	shapeFile  = "breath";
	mountPoint = 0;
	mountRotation = {0, 3.14, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.0, -0.1 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AutoShotgunClip
{
	heading = "cSecondary Weapons";
	description = "AutoShotgunClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = AutoShotgunClipImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData AutoShotgunMountImage
{
	shapeFile  = "plasma";
	mountPoint = 0;
	mountRotation = {0, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { 0, 0.0, 0.0 };

	ammoType = EagleAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AutoShotgunMount
{
	heading = "cSecondary Weapons";
	description = "AutoShotgunClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = AutoShotgunMountImage;
	price = 50;
	showWeaponBar = true;
};

function AutoShotgun::onMount(%player,%item)
{
	Player::MountItem(%player,AutoShotgunMount,5);
	Player::MountItem(%player,AutoShotgunScope,7);
	Player::MountItem(%player,AutoShotgunClip,6);
}
function AutoShotgun::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
	Player::UnMountItem(%player,5);
}

$InvList[AutoShotgunMount] = 0;
$RemoteInvList[AutoShotgunMount] = 0;
$InvList[AutoShotgunScope] = 0;
$RemoteInvList[AutoShotgunScope] = 0;
$InvList[AutoShotgunClip] = 0;
$RemoteInvList[AutoShotgunClip] = 0;

