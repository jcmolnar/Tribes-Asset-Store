//--------------------------------------

$AutoUse[NitroB] = True;
$WeaponAmmo[NitroB] = "";

//--------------------------------------

$InvList[NitroB] = 1;
$RemoteInvList[NitroB] = 1;

$ItemMax[narmor, NitroB] = 1;
$ItemMax[aarmor, NitroB] = 0;
$ItemMax[darmor, NitroB] = 0;
$ItemMax[nfemale, NitroB] = 1;
$ItemMax[afemale, NitroB] = 0;
$ItemMax[warmor, NitroB] = 0;
$ItemMax[barmor, NitroB] = 0;
$ItemMax[sarmor, NitroB] = 1;
$ItemMax[avarmor, NitroB] = 0;
$ItemMax[wfemale, NitroB] = 0;
$ItemMax[bfemale, NitroB] = 0;

//--------------------------------------

ItemImageData NitroBImage
{
	shapeFile = "mortartrail";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.5;

	//projectileType = LiquidNB;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData NitroB
{
	description = "Liquid Nitrogen Blast";
	className = "Weapon";
	shapeFile = "force";
   validateShape = true;
	hudIcon = "grenade";
   heading = "dPowers";
	shadowDetailMask = 4;
	imageType = NitroBImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function NitroB::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Liquid Nitrogen Blast: <f2>A long range Chemical Sprayer.");
}
function NitroBImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(Player::getItemCount(%client,PowerEnhPack) > 0)
			Projectile::spawnProjectile("SLiquidNB",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("LiquidNB",%trans,%player,%vel);
}