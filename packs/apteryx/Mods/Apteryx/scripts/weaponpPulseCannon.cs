$InvList[PulseCannon] = 1;
$MobileInvList[PulseCannon] = 1;
$RemoteInvList[PulseCannon] = 1;

$WeaponAmmo[PulseCannon] = "";
$AutoUse[PulseCannon] = false;

addweapon(PulseCannon);

ItemImageData PulseCannonImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	//	minEnergy = 10;
	//	maxEnergy = 15;
	weaponType = 0; // Single Shot
	//	projectileType = PulseBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	lightType = 3;  // Weapon Fire
	lightRadius = 6.5;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	//	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PulseCannon
{
	description = "Pulse Cannon";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "blaster";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PulseCannonImage;
	price = 325;
	showWeaponBar = true;
};

function PulseCannon::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Pulse Cannon: <f2>Fires Ion Bolts similar to the Ion Turrets.");
}

function PulseCannonImage::onFire(%player, %slot)
{
	%energy = gamebase::getenergy(%player);
	if(%energy > 10)
	{
		gamebase::setenergy(%player, %energy - 15.0);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("PulseBolt",%trans,%player,%vel);
		gamebase::playsound(%player, SoundFireBlaster, 0.75);
	}
}