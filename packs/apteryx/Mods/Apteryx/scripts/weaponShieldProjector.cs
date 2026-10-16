$InvList[Stinger] = 1;
$MobileInvList[Stinger] = 1;
$RemoteInvList[Stinger] = 1;

$InvList[StingerAmmo] = 1;
$MobileInvList[StingerAmmo] = 1;
$RemoteInvList[StingerAmmo] = 1;

$AutoUse[Stinger] = false;
$WeaponAmmo[Stinger] = StingerAmmo;
$SellAmmo[StingerAmmo] = 5;

addweapon(Stinger);
addammo(Stinger, StingerAmmo, 2);

ItemData StingerAmmo
{
	description = "ShieldCapacitor";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 25;
};

ItemImageData StingerImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { -0.1, 0, 0 };
	mountRotation = { 0, -1.85, 0};
	weaponType = 0; 
	reloadTime = 1.5;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	ammoType = StingerAmmo;
	accuFire = true;
	sfxFire	= SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	//sfxReady = SoundMortarIdle;
};

ItemData Stinger
{
	heading = $InvHead[ihWea];
	description = "Shield Projector";
	classname = "Weapon";
	shapeFile = "paintgun";
	hudIcon	= "sensorjamerpack";
	shadowDetailMask = 4;
	imageType = StingerImage;
	price = 300;
	showWeaponBar = true;
};

function Stinger::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Shield Projector: <f2>Fires all your energy for emergencies.");
}

function StingerImage::onFire(%player,%slot)
{		
if(Player::getitemcount(%player, $WeaponAmmo[stinger]) != 0)
{
	if(gamebase::getenergy(%player) >= 20)
	{
		Client::sendMessage(Player::getClient(%player),0, "Firing all shield energy.");
		GameBase::playSound(%player, SoundFireLaser, 0);
		FireShield(%player, gamebase::getenergy(%player) / 0.85);
		gamebase::setenergy(%player, 0);
		Player::decitemcount(%player, $weaponammo[stinger]);
	}
}
}
function FireShield(%player, %energy)
{
   if(%energy > 0)
   {
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("BeaconShieldFire",%trans,%player,%vel,%player); 
	%energy = %energy - 5;
	schedule("FireShield("@%player@","@%energy@");", 0.035);
   }
}		
