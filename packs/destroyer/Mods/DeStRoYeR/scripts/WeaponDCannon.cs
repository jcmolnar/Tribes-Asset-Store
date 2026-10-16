//--------------------------------------

$AutoUse[DCannon] = True;
$WeaponAmmo[DCannon] = "";

//--------------------------------------

$InvList[DCannon] = 1;
$RemoteInvList[DCannon] = 1;

//--------------------------------------

ItemImageData DCannonImage
{
	shapeFile = "rocket";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//projectileType = DCannonShell;
	accuFire = True;
	reloadTime = 0.5;
	fireTime = 1.5;
	minEnergy = 80;
	maxEnergy = 80;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DCannon
{
	description = "Death Cannon";
	className = "Weapon";
	shapeFile = "Force";
	hudIcon = "mortar";
   heading = "dPowers";
	shadowDetailMask = 4;
	imageType = DCannonImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function DCannonImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(Player::getItemCount(%client,PowerEnhPack) > 0)
			Projectile::spawnProjectile("SDCannonShell",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("DCannonShell",%trans,%player,%vel);
}
function DCannon::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Death Cannon: <f2>Send a Psycic Missile at your foe.");
}

