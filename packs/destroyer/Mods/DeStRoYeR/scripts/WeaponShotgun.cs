//--------------------------------------

$AutoUse[Shotgun] = True;
$SellAmmo[ShotgunShell] = 5;
$AmmoPackMax[ShotgunShell] = 15;
$AmmoPackItems[7] = ShotgunShell;
$WeaponAmmo[Shotgun] = ShotgunShell;

//--------------------------------------

$InvList[Shotgun] = 1;
$InvList[ShotgunShell] = 1;
$RemoteInvList[Shotgun] = 1;
$RemoteInvList[ShotgunShell] = 1;

$ItemMax[narmor, Shotgun] = 0;
$ItemMax[aarmor, Shotgun] = 0;
$ItemMax[darmor, Shotgun] = 1;
$ItemMax[nfemale, Shotgun] = 0;
$ItemMax[afemale, Shotgun] = 0;
$ItemMax[warmor, Shotgun] = 1;
$ItemMax[barmor, Shotgun] = 1;
$ItemMax[sarmor, Shotgun] = 1;
$ItemMax[avarmor, Shotgun] = 1;
$ItemMax[wfemale, Shotgun] = 1;
$ItemMax[bfemale, Shotgun] = 1;

$ItemMax[narmor, ShotgunShell] = 0;
$ItemMax[aarmor, ShotgunShell] = 0;
$ItemMax[darmor, ShotgunShell] = 50;
$ItemMax[nfemale, ShotgunShell] = 0;
$ItemMax[afemale, ShotgunShell] = 0;
$ItemMax[warmor, ShotgunShell] = 30;
$ItemMax[barmor, ShotgunShell] = 40;
$ItemMax[sarmor, ShotgunShell] = 500;
$ItemMax[avarmor, ShotgunShell] = 50;
$ItemMax[wfemale, ShotgunShell] = 30;
$ItemMax[bfemale, ShotgunShell] = 40;

//--------------------------------------


ItemData ShotgunShell
{
	description = "Shotgun Shells";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo2";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ShotgunImage
{	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = ShotgunShell;
	reloadTime = 0.38;
	accuFire = false;
	fireTime = 0.25;
	sfxFire = SoundFireShotgun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Shotgun
{	description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "ammopack";
	className = "Weapon";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	showWeaponBar = true;
	price = 85;
};

//--------------------------------------

function ShotgunImage::onFire(%player, %slot)
{
	Player::decItemCount(%player,ShotgunShell,1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
}
function Shotgun::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Shotgun: <f2>A normal double barreled shotgun.");
}