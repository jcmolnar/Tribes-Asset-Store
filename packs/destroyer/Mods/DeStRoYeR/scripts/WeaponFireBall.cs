//--------------------------------------

$AutoUse[FireBall] = True;
$Use[FireBall] = True;
$WeaponAmmo[FireBall] = "";

//--------------------------------------

$InvList[FireBall] = 1;
$RemoteInvList[FireBall] = 1;

//--------------------------------------

ItemImageData FireBallImage
{
   shapeFile  = "plasmatrail";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.4;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = FireBallShell;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FireBall
{
   heading = "dPowers";
	description = "Fire Ball";
	className = "Weapon";
   shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FireBallImage;
	price = 85;
	showWeaponBar = true;
};

//--------------------------------------
function FireBallImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(Player::getItemCount(%client,PowerEnhPack) > 0)
			Projectile::spawnProjectile("SFireBallShell",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("FireBallShell",%trans,%player,%vel);
}
function FireBall::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Fire Ball: <f2>Warm up your enemy with a ball of fire.");
}
