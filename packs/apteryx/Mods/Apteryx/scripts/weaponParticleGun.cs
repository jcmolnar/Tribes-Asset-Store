//IS NOW PARTICLE GUN  --Crow!

$InvList[RocketLauncher] = 1;
$MobileInvList[RocketLauncher] = 1;
$RemoteInvList[RocketLauncher] = 1;

$InvList[RocketAmmo] = 1;
$MobileInvList[RocketAmmo] = 1;
$RemoteInvList[RocketAmmo] = 1;

$AutoUse[RocketLauncher] = false;
$SellAmmo[RocketAmmo] = 3;
$WeaponAmmo[RocketLauncher] = "";

addWeapon(RocketLauncher);
addAmmo(RocketLauncher, RocketAmmo, 1);

ItemData RocketAmmo 
{
	description = "Dust Mites";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData RocketImage 
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.7;
	fireTime = 0.85;
	lightType = 3;
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 0.0, 1.0, 1.0 };
	sfxActivate = SoundPickUpWeapon;
};

ItemData RocketLauncher 
{
	description = "Particle Gun";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "blaster";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 450;
	showWeaponBar = true;
};

function RocketLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Particle Gun: <f2>Fires a clump of particles at high speed that cause a tiny nuclear explosion on impact.");
}

function RocketImage::onFire(%player, %slot)
{
	%energy = gamebase::getenergy(%player);
	if(%energy > 17.5)
	{
		gamebase::setenergy(%player, %energy - 22.5);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ParticleShot",%trans,%player,%vel);
		gamebase::playsound(%player, SoundFireLaser, 0.5);
	}
}