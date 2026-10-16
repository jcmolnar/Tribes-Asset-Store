// IS NOW PLASMA CANNON --Crow!

$InvList[FlameThrower] = 1;
$MobileInvList[FlameThrower] = 1;
$RemoteInvList[FlameThrower] = 1;

$InvList[FlameThrowerAmmo] = 0;
$MobileInvList[FlameThrowerAmmo] = 0;
$RemoteInvList[FlameThrowerAmmo] = 0;

$AutoUse[FlameThrower] = True;
$SellAmmo[FlameThrowerAmmo] = 25;	
$WeaponAmmo[FlameThrower] = "";

addWeapon(FlameThrower);
addAmmo(FlameThrower, FlameThrowerAmmo, 10);

ItemData FlameThrowerAmmo 
{
	description = "Flame Cartridges";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData FlameThrowerImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	accuFire = true;
	reloadTime = 1.55;
	fireTime = 1.0;
	maxEnergy = 35;
	minEnergy = 25;
	lightType = 3;
	lightRadius = 7.5;
	lightTime = 0.6;
	lightColor = { 1.0, 0.0, 0.0 };
};

ItemData FlameThrower 
{
	description = "Plasma Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FlameThrowerImage;
	price = 475;
	showWeaponBar = true;
};

function FlameThrower::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Plasma Canon: <f2>Fires a powerful but slow projectile.");
}

function FlameThrowerImage::onFire(%player, %slot)
{
	%energy = gamebase::getenergy(%player);
	if(%energy > 26.5)
	{
		gamebase::setenergy(%player, %energy - 35.0);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("PlasmaBlast",%trans,%player,%vel);
		gamebase::playsound(%player, SoundFireMortar, 0.75);
	}
}