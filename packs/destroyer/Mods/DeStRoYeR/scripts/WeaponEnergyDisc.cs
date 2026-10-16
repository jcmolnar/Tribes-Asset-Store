//--------------------------------------

$AutoUse[EnergyDisc] = True;
$WeaponAmmo[EnergyDisc] = "";

//--------------------------------------

$InvList[EnergyDisc] = 1;
$RemoteInvList[EnergyDisc] = 1;

//--------------------------------------

ItemImageData EnergyDiscImage
{
	shapeFile = "discb";
	mountPoint = 0;

	weaponType = 0;
	//projectileType = Disc;
	accuFire = true;
	reloadTime = 0.3;
	fireTime = 0.5;
	minEnergy = 0;
	maxEnergy = 0;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EnergyDisc
{
	description = "Energy Disc";
	className = "Weapon";
	shapeFile = "force";
	hudIcon = "disk";
   heading = "dPowers";
	shadowDetailMask = 4;
	imageType = EnergyDiscImage;
	price = 150;
	showWeaponBar = true;
};

//--------------------------------------
function EnergyDiscImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(Player::getItemCount(%client,PowerEnhPack) > 0)
			Projectile::spawnProjectile("SDisc",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("Disc",%trans,%player,%vel);
}
function EnergyDisc::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Energy Disc: <f2>A Psycic Disc Launcher.");
}