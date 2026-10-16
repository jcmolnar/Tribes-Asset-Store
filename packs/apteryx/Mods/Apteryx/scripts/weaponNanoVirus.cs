$InvList[ShockingGrasp] = 1;
$MobileInvList[ShockingGrasp] = 1;
$RemoteInvList[ShockingGrasp] = 1;

$AutoUse[ShockingGrasp] = False;
$WeaponAmmo[ShockingGrasp] = "";

addWeapon(ShockingGrasp);

ItemImageData ShockingGraspImage 
{
	shapeFile = "smoke";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.5;
	lightType = 3; // Weapon Fire
	lightRadius = 3;
	lightTime = 0.75;
	lightColor = { -0.5, -0.5, -0.5 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFirePlasma;
};

ItemData ShockingGrasp
{
	className = "Weapon";
	description = "Nano Virus";
	shapeFile = "smoke";
	shadowDetailMask = 4;
	heading = $InvHead[ihWea];
	hudIcon = "fear";
	imageType = ShockingGraspImage;
	showWeaponBar = true;
	price = 300;
};

function ShockingGrasp::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>Nano Virus: <f2>Vitims have their health torn away by tiny nanites for a while.");
}

function ShockingGraspImage::onFire(%player, %slot)
{
	gamebase::setenergy(%player, gamebase::getenergy(%player) - 20);
	%trans = gamebase::getmuzzletransform(%player);
	%vel = item::getvelocity(%player);
	projectile::spawnProjectile("NanoInfection", %trans, %player, %vel);
	projectile::spawnProjectile("NanoDamage", %trans, %player, %vel);
}