

$InvList[GrenadeLauncher] = 1;
$MobileInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeLauncher] = 1;

$InvList[GrenadeAmmo] = 1;
$MobileInvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

$AutoUse[GrenadeLauncher] = false;
$SellAmmo[GrenadeAmmo] = 5;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

addWeapon(GrenadeLauncher);
addAmmo(GrenadeLauncher, GrenadeAmmo, 2);

ItemData GrenadeAmmo 
{	
	description = "Grenade ammo"; 
	className = "Ammo"; 
	shapeFile = "grenammo"; 
	heading = $InvHead[ihAmm]; 
	shadowDetailMask = 4; 
	price = 2;
}; 

ItemImageData GrenadeLauncherImage 
{	
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = GrenadeAmmo;
	//projectileType = BomberWarhead;
	accuFire = false;
	reloadTime = 0.4;
	fireTime = 0.4;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPickUpWeapon;	//SoundTurretDeploy;	//SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher 
{	
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function GrenadeLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
	{
	if(%clientId.MiniMode == 0)
		bottomprint(%clientId, "<jc>Grenade Launcher: <f2>SINGLE <f1>Grenade Projectile", 2);
	else if(%clientId.MiniMode == 1)
		bottomprint(%clientId, "<jc>Grenade Launcher: <f2>TRIPLE <f1>Grenade Projectiles", 2);
	else if(%clientId.MiniMode == 2)
		bottomprint(%clientId, "<jc>Grenade Launcher: <f2>FFB <f1>Projectile", 2);
	}	
}

function GrenadelauncherImage::onFire(%player, %slot)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[GrenadeLauncher]);
	
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	if(%clientId.MiniMode == 0)
	{
		if(%AmmoCount > 0)
		{
			Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
			playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Grenade Launcher out of ammo.");
			return false;
		}
	}
	else if(%clientId.MiniMode == 1)
	{
		if(%AmmoCount > 3)
		{
			Projectile::spawnProjectile("GrenadeShell2",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("GrenadeShell3",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("GrenadeShell4",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],2);
			playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Not enough ammo to fire Triple Projectiles.");//~wdryfire1.wav");
			return false;
		}
	}
	else if(%clientId.MiniMode == 2)
	{
		if(%AmmoCount > 0)
		{
		Projectile::spawnProjectile("FFBShell",%trans,%player,%vel,%player);
		Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],2);
		playSound(SoundMortarTurretFire, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Not enough ammo to fire FFB Projectile.");//~wdryfire1.wav");
			return false;
		}
	}	
}

