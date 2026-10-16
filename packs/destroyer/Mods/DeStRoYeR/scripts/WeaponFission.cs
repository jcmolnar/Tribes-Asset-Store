$AutoUse[FissionL] = True;
$WeaponAmmo[FissionL] = NukeAmmo;
$InvList[FissionL] = 1;
$RemoteInvList[FissionL] = 1;

$ItemMax[narmor, FissionL] = 0;
$ItemMax[aarmor, FissionL] = 0;
$ItemMax[darmor, FissionL] = 1;
$ItemMax[nfemale, FissionL] = 0;
$ItemMax[afemale, FissionL] = 0;
$ItemMax[warmor, FissionL] = 1;
$ItemMax[barmor, FissionL] = 1;
$ItemMax[sarmor, FissionL] = 1;
$ItemMax[avarmor, FissionL] = 1;
$ItemMax[wfemale, FissionL] = 1;
$ItemMax[bfemale, FissionL] = 1;

$DamageScale[narmor, $fissionDamageType] = 1.0;
$DamageScale[aarmor, $fissionDamageType] = 1.6;
$DamageScale[darmor, $fissionDamageType] = 0.5;
$DamageScale[warmor, $fissionDamageType] = 1.0;
$DamageScale[barmor, $fissionDamageType] = 0.8;
$DamageScale[sarmor, $fissionDamageType] = 0.25;
$DamageScale[avarmor, $fissionDamageType] = 0.6;
$DamageScale[nfemale, $fissionDamageType] = 0.8;
$DamageScale[afemale, $fissionDamageType] = 1.6;
$DamageScale[wfemale, $fissionDamageType] = 1.0;
$DamageScale[bfemale, $fissionDamageType] = 0.8;
$DamageScale[Fighter, $fissionDamageType] = 1.0;
$DamageScale[Interceptor, $fissionDamageType] = 1.0;
$DamageScale[Scout, $fissionDamageType] = 1.0;
$DamageScale[LAPC, $fissionDamageType] = 1.0;
$DamageScale[HAPC, $fissionDamageType] = 1.0;

$FissionLSlotA=4;
$FissionLSlotB=7;

ItemImageData FissionLImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, -0.1 };

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.7;

	ammoType = NukeAmmo;
	//projectileType = FissionShot;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FissionL
{
	description = "Fission Launcher";
	className = "Weapon";
	shapeFile = "sniper";
	validateShape = False;
	hudIcon = "Blaster";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = FissionLImage;
	price = 2500;
	showWeaponBar = true;
};
ItemImageData FissionL2Image
{
	shapeFile = "Shotgun";
	mountPoint = 0;
	mountRotation = { 0, 1.57, 0 };
	mountOffset = { 0.1, 0, 0 };

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.7;

	ammoType = NukeAmmo;
	//projectileType = FissionShot;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FissionL2
{
	description = "Fission Launcher";
	className = "Weapon";
	shapeFile = "shotgun";
	validateShape = False;
	hudIcon = "Blaster";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = FissionL2Image;
	price = 2500;
	showWeaponBar = true;
};
ItemImageData FissionL3Image
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	mountOffset = { -0.1, 0, 0 };

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.7;

	ammoType = NukeAmmo;
	//projectileType = FissionShot;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FissionL3
{
	description = "Fission Launcher";
	className = "Weapon";
	shapeFile = "shotgun";
	validateShape = False;
	hudIcon = "Blaster";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = FissionL3Image;
	price = 2500;
	showWeaponBar = true;
};
function FissionLImage::onFire(%player, %slot)
{
	Player::decItemCount(%player,NukeAmmo,1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("FissionShot",%trans,%player,%vel);
}
function FissionL::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Fission launcher: <f2>Mixing nuclear reactants, this weapon fires a Fission Bolt");
	Player::mountItem(%player,FissionL2,$FissionLSlotA);
	Player::mountItem(%player,FissionL3,$FissionLSlotB);
}
function FissionL::onDrop(%player,%item)
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
	{	Player::setItemCount(%player, FissionL2, 0);
		Player::setItemCount(%player, FissionL3, 0);
		Item::onDrop(%player,%item);
	}
}
function FissionL::onUnmount(%player,%imageSlot)
{	Player::unmountItem(%player,$FissionLSlotA);
	Player::unmountItem(%player,$FissionLSlotB);
}
