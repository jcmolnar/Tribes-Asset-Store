//--------------------------------------

$AutoUse[FlameB] = True;
$WeaponAmmo[FlameB] = "";

//--------------------------------------

$InvList[FlameB] = 1;
$RemoteInvList[FlameB] = 1;

$ItemMax[narmor, FlameB] = 1;
$ItemMax[aarmor, FlameB] = 0;
$ItemMax[darmor, FlameB] = 0;
$ItemMax[nfemale, FlameB] = 1;
$ItemMax[afemale, FlameB] = 0;
$ItemMax[warmor, FlameB] = 0;
$ItemMax[barmor, FlameB] = 0;
$ItemMax[sarmor, FlameB] = 1;
$ItemMax[avarmor, FlameB] = 0;
$ItemMax[wfemale, FlameB] = 0;
$ItemMax[bfemale, FlameB] = 0;

//--------------------------------------

ItemImageData FlameBImage
{
	shapeFile = "mortartrail";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.5;

	//projectileType = FlameBl;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlameB
{
	description = "Flame Blast";
	className = "Weapon";
	shapeFile = "force";
   validateShape = true;
	hudIcon = "grenade";
   heading = "dPowers";
	shadowDetailMask = 4;
	imageType = FlameBImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function FlameB::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Flame Blast: <f2>A long range Flame Thrower.");
}
function FlameBImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(Player::getItemCount(%client,PowerEnhPack) > 0)
			Projectile::spawnProjectile("SFlameBl",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("FlameBl",%trans,%player,%vel);
}