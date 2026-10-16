//--------------------------------------

$AutoUse[EnBlast] = True;
$WeaponAmmo[GrenadeLauncher] = "";

//--------------------------------------

$InvList[EnBlast] = 1;
$RemoteInvList[EnBlast] = 1;

//--------------------------------------

ItemImageData EnBlastImage
{
	shapeFile = "enex";
	mountPoint = 0;

	weaponType = 0;
	//projectileType = BlastShell;
	accuFire = True;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 0;
	maxEnergy = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData EnBlast
{
	description = "Blast Cannon";
	className = "Weapon";
	shapeFile = "Force";
	hudIcon = "blaster";
   heading = "dPowers";
	shadowDetailMask = 4;
	imageType = EnBlastImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function EnBlastImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(Player::getItemCount(%client,PowerEnhPack) > 0)
			Projectile::spawnProjectile("SBlastShell",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("BlastShell",%trans,%player,%vel);
}
function EnBlast::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Blast Cannon: <f2>Send a Explosive Ball-O-Death at your enemy.");
}
