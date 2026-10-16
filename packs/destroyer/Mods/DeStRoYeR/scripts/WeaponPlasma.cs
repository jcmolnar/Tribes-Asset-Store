//--------------------------------------

$AutoUse[Plasma] = True;
$WeaponAmmo[Plasma] = "";

//--------------------------------------

$InvList[Plasma] = 1;
$RemoteInvList[Plasma] = 1;

//--------------------------------------

ItemImageData PlasmaImage
{
	shapeFile = "plasmabolt";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 0;
	maxEnergy = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Plasma
{
	description = "Plasma";
	className = "Weapon";
	shapeFile = "force";
	hudIcon = "plasma";
   heading = "dPowers";
	shadowDetailMask = 4;
	imageType = PlasmaImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function PlasmaImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(Player::getItemCount(%client,PowerEnhPack) > 0)
			Projectile::spawnProjectile("SPlasmaBolt",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("PlasmaBolt",%trans,%player,%vel);
}
function Plasma::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Plasma: <f2>A Psycic version of a Plasma Gun.");
}
