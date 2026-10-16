$AutoUse[SoulSucker] = true;
$WeaponAmmo[SoulSucker] = "";

$InvList[SoulSucker] = 1;
$MobileInvList[SoulSucker] = 1;
$RemoteInvList[SoulSucker] = 1;

addWeapon(SoulSucker);

ItemImageData SoulSuckerImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 1;
	lightType = 5;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.2, 1.0, 0.2 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundActivateInventoryStation;
};

//There used to be soulsucker r l and b here --Crow!

ItemData SoulSucker
{
	description = "Healing Laser";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = SoulSuckerImage;
	price = 200;
	showWeaponBar = true;
};

function SoulSucker::onMount(%player, %slot) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	bottomprint(Player::getClient(%player), "<jc> Healing Laser: <f2>Snipe your allies to health!  Note - actually uses crosshairs, not the laser.",10);
}

function SoulSuckerImage::onfire(%player, %slot)
{
	GameBase::SetEnergy(%player, GameBase::GetEnergy(%player) - 20);
	%trans = gamebase::getmuzzletransform(%player);
	Projectile::spawnProjectile("HealingLaser", %trans, %player, 20);
	if(gamebase::getLOSInfo(%player, 1000))
	{
		if(gamebase::getteam(%player) == gamebase::getteam($los::object))
		{
			gamebase::setDamageLevel($los::object, gamebase::getdamagelevel($los::object) - 0.5);
		}
	}
}