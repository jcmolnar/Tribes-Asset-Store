//IS NOW STARFLARE - Crow!

$InvList[AngelFire] = 1;
$MobileInvList[AngelFire] = 1;
$RemoteInvList[AngelFire] = 1;

$AutoUse[AngelFire] = False;
$WeaponAmmo[AngelFire] = "";  //it is safe to have no ammo because you DIE when you use this

addWeapon(AngelFire);

ItemImageData AngelFireImage 
{
	shapeFile = "liqcyl";
	mountPoint = 0;
	mountOffset = { -1.0, -0.28, 0.45 };
	mountRotation = { 0, 1.5, 0 };
	weaponType = 0;
	reloadTime = 30.0;
	fireTime = 0.2;
	minEnergy = 5;
	maxEnergy = 25;
//	projectileType = StarFlareDetonate;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = debrisLargeExplosion;
	sfxReload = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AngelFire 
{
	description = "Star Flare";
	className = "Weapon";
	shapeFile = "liqcyl";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = AngelFireImage;
	price = 275;
	showWeaponBar = true;
};

function AngelFire::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Star Flare: <f2>Self destruct module.  Go out with a bang.");
}

function angelfireimage::onfire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%client = player::getclient(%player);
	%name = client::getname(%client);
	messageall(0, ""@%name@" goes out with a bang.");
	gamebase::setdamagelevel(%player, 5);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("StarFlareDetonate",%trans,%player,%vel);
	%client.score = %client.score - 1;
}