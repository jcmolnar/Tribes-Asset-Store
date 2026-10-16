$InvList[BigFlameStrike] = 1;
$MobileInvList[BigFlameStrike] = 1;
$RemoteInvList[BigFlameStrike] = 1;

$AutoUse[BigFlameStrike] = True;
$WeaponAmmo[BigFlameStrike] = "";

addWeapon(BigFlameStrike);

ItemImageData BigFlameStrikeImage
{
	shapeFile = "plasmabolt";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	//projectileType = PlasIC;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.55;
	minEnergy = 50;
	maxEnergy = 60;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = bigExplosion2;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BigFlameStrike
{
	description = "Spell: Big Flame Strike";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "plasmabolt";
	heading = $InvHead[ihSpl];
	shadowDetailMask = 4;
	imageType = BigFlameStrikeImage;
	price = 1000;
	showWeaponBar = true;
};

function BigFlameStrike::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	Bottomprint(%client, "Big Flame Strike: <f2>Sends a crawling doom to incinerate your target.");
}

function BigFlameStrikeImage::onFire(%player, %slot) 
{	
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	if (floor(getRandom() * 30) == 31)
	{
		%client = Player::getClient(%player);
		Bottomprint(%client, "WARNING: FLAME STRIKE OUT OF CONTROL- CLEAR THE EXPLOSION AREA");
		Projectile::spawnProjectile("BigFlameStrikeBig",%trans,%player,%vel);
	}
	else
	{
		Projectile::spawnProjectile("FlameStrikeBig",%trans,%player,%vel);
	}
	return;
}
