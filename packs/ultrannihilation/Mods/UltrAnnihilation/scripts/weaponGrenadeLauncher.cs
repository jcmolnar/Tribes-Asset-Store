$InvList[GrenadeLauncher] = 1;
$MobileInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeLauncher] = 1;

$InvList[GrenadeAmmo] = 1;
$MobileInvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

$AutoUse[GrenadeLauncher] = True;
$SellAmmo[GrenadeAmmo] = 5;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

addWeapon(GrenadeLauncher);
addAmmo(GrenadeLauncher, GrenadeAmmo, 2);

ItemData GrenadeAmmo 
{	
	description = "Grenade Ammo"; 
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
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireGrenade;
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

function GrenadeLauncher::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Grenade Launcher: <f2>Fires 3 canisters of firey Napalm, perfect way to warm up on a cold day.");
}

function GrenadelauncherImage::onFire(%player, %slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[GrenadeLauncher]);
	if(%AmmoCount > 0)
	{	%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("GrenadeLauncherGren1",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("GrenadeLauncherGren2",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("GrenadeLauncherGren3",%trans,%player,%vel,%player);
		Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
	}
	else
	{	Client::sendMessage(Player::getClient(%player),0,"Grenade Launcher out of ammo.");
	}
}
