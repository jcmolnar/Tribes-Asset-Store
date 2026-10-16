$AutoUse[FusionL] = True;
$SellAmmo[NukeAmmo] = 25;
$AmmoPackMax[NukeAmmo] = 50;
$AmmoPackItems[3] = NukeAmmo;
$WeaponAmmo[FusionL] = NukeAmmo;
$InvList[FusionL] = 1;
$RemoteInvList[FusionL] = 1;

$ItemMax[narmor, FusionL] = 0;
$ItemMax[aarmor, FusionL] = 0;
$ItemMax[darmor, FusionL] = 1;
$ItemMax[nfemale, FusionL] = 0;
$ItemMax[afemale, FusionL] = 0;
$ItemMax[warmor, FusionL] = 0;
$ItemMax[barmor, FusionL] = 0;
$ItemMax[sarmor, FusionL] = 1;
$ItemMax[avarmor, FusionL] = 1;
$ItemMax[wfemale, FusionL] = 0;
$ItemMax[bfemale, FusionL] = 0;

$ItemMax[narmor, NukeAmmo] = 0;
$ItemMax[aarmor, NukeAmmo] = 0;
$ItemMax[darmor, NukeAmmo] = 30;
$ItemMax[nfemale, NukeAmmo] = 0;
$ItemMax[afemale, NukeAmmo] = 0;
$ItemMax[warmor, NukeAmmo] = 20;
$ItemMax[barmor, NukeAmmo] = 25;
$ItemMax[sarmor, NukeAmmo] = 500;
$ItemMax[avarmor, NukeAmmo] = 30;
$ItemMax[wfemale, NukeAmmo] = 20;
$ItemMax[bfemale, NukeAmmo] = 25;

$DamageScale[narmor, $fusionDamageType] = 1.0;
$DamageScale[aarmor, $fusionDamageType] = 1.8;
$DamageScale[darmor, $fusionDamageType] = 0.5;
$DamageScale[warmor, $fusionDamageType] = 1.2;
$DamageScale[barmor, $fusionDamageType] = 1.0;
$DamageScale[sarmor, $fusionDamageType] = 0.25;
$DamageScale[avarmor, $fusionDamageType] = 0.8;
$DamageScale[nfemale, $fusionDamageType] = 1.0;
$DamageScale[afemale, $fusionDamageType] = 0.8;
$DamageScale[wfemale, $fusionDamageType] = 1.2;
$DamageScale[bfemale, $fusionDamageType] = 1.0;
$DamageScale[Fighter, $fusionDamageType] = 1.0;
$DamageScale[Interceptor, $fusionDamageType] = 1.0;
$DamageScale[Scout, $fusionDamageType] = 1.0;
$DamageScale[LAPC, $fusionDamageType] = 1.0;
$DamageScale[HAPC, $fusionDamageType] = 1.0;

ItemData NukeAmmo
{
	description = "Nucelear Reactants";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

$FusionLSlotA=4;
$FusionLSlotB=7;

ItemImageData FusionLImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 3.14, 0 };
	mountOffset = { 0, 0, 0 };

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.7;

	ammoType = NukeAmmo;
	//projectileType = FusionShot;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FusionL
{
	description = "Fusion Launcher";
	className = "Weapon";
	shapeFile = "sniper";
	validateShape = False;
	hudIcon = "Blaster";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = FusionLImage;
	price = 2500;
	showWeaponBar = true;
};
ItemImageData FusionL2Image
{
	shapeFile = "Shotgun";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	mountOffset = { 0.1, 0, -0.1 };

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.7;

	ammoType = NukeAmmo;
	//projectileType = FusionShot;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FusionL2
{
	description = "Fusion Launcher";
	className = "Weapon";
	shapeFile = "shotgun";
	validateShape = False;
	hudIcon = "Blaster";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = FusionL2Image;
	price = 2500;
	showWeaponBar = true;
};
ItemImageData FusionL3Image
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 1.57, 0 };
	mountOffset = { -0.1, 0, -0.1 };

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.7;

	ammoType = NukeAmmo;
	//projectileType = FusionShot;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FusionL3
{
	description = "Fusion Launcher";
	className = "Weapon";
	shapeFile = "shotgun";
	validateShape = False;
	hudIcon = "Blaster";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = FusionL3Image;
	price = 2500;
	showWeaponBar = true;
};
function FusionLImage::onFire(%player, %slot)
{
	Player::decItemCount(%player,NukeAmmo,1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("FusionShot",%trans,%player,%vel);
}
function FusionL::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Fusion launcher: <f2>Mixing nuclear reactants, this weapon fires a Fusion Bolt");
	Player::mountItem(%player,FusionL2,$FusionLSlotA);
	Player::mountItem(%player,FusionL3,$FusionLSlotB);
	}
function FusionL::onDrop(%player,%item)
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
	{	Player::setItemCount(%player, FusionL2, 0);
		Player::setItemCount(%player, FusionL3, 0);
		Item::onDrop(%player,%item);
	}
}
function FusionL::onUnmount(%player,%imageSlot)
{	Player::unmountItem(%player,$FusionLSlotA);
	Player::unmountItem(%player,$FusionLSlotB);
}