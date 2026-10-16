//--------------------------------------

$AutoUse[EnChaingun] = True;
$WeaponAmmo[EnChaingun] = "";

//--------------------------------------

$InvList[EnChaingun] = 1;
$RemoteInvList[EnChaingun] = 1;

//--------------------------------------

ItemImageData EnChaingunImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = EnChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EnChaingun
{
	description = "Energy Chaingun";
	className = "Weapon";
	shapeFile = "force";
   validateShape = true;
	hudIcon = "chain";
   heading = "dPowers";
	shadowDetailMask = 4;
	imageType = EnChaingunImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function EnChaingunImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(Player::getItemCount(%client,PowerEnhPack) > 0)
			Projectile::spawnProjectile("SEnChaingunBullet",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("EnChaingunBullet",%trans,%player,%vel);
}
function EnChaingun::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Energy Chaingun: <f2>A psycic chaingun!.");
}
