//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(GrenadeLauncher);
$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;

$SellAmmo[GrenadeAmmo] = 5;
$AutoUse[GrenadeLauncher] = True;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

$ItemMax[larmor, GrenadeLauncher] = 1;	//Seraph
$ItemMax[lfemale, GrenadeLauncher] = 1;	//Seraph
$ItemMax[earmor, GrenadeLauncher] = 1;	//Slave
$ItemMax[efemale, GrenadeLauncher] = 1;	//Slave
$ItemMax[marmor, GrenadeLauncher] = 1;	//Pawn
$ItemMax[aarmor, GrenadeLauncher] = 0;	//Navigator
$ItemMax[darmor, GrenadeLauncher] = 1;	//Atomizer
$ItemMax[barmor, GrenadeLauncher] = 0;	//Paladin

$ItemMax[larmor, GrenadeAmmo] = 15;	//Seraph
$ItemMax[lfemale, GrenadeAmmo] = 15;	//Seraph
$ItemMax[earmor, GrenadeAmmo] = 15;	//Slave
$ItemMax[efemale, GrenadeAmmo] = 15;	//Slave
$ItemMax[marmor, GrenadeAmmo] = 30;	//Pawn
$ItemMax[aarmor, GrenadeAmmo] = 0;	//Navigator
$ItemMax[darmor, GrenadeAmmo] = 15;	//Atomizer
$ItemMax[barmor, GrenadeAmmo] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemImageData GrenadeLauncherImage 
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = GrenadeAmmo;
	//projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;
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
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 77;
	showWeaponBar = true;
}; 

function GrenadeLauncherImage::onFire(%player, %slot) 
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[GrenadeLauncher]);
	%playerId = Player::getClient(%player);
	 
	 if(%Ammo || %client.fireGrenadeLauncher) 
	 {
	 	%fired.deployer = %player;
		%client = GameBase::getOwnerClient(%player);
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);

		if (!%playerId.GrenadeLauncher || %playerId.GrenadeLauncher == 0)
		{
			%fired = Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
			Player::decItemCount(%player,GrenadeAmmo);
		}
		else if (%playerId.GrenadeLauncher == 1)
		{
			%fired = Projectile::spawnProjectile("RepulseShell",%trans,%player,%vel);
			Player::decItemCount(%player,GrenadeAmmo);
		}
		else if (%playerId.GrenadeLauncher == 2)
		{
			Projectile::spawnProjectile("GrenadeLauncherGren1",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("GrenadeLauncherGren2",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("GrenadeLauncherGren3",%trans,%player,%vel,%player);

			Player::decItemCount(%player,GrenadeAmmo);
			Player::decItemCount(%player,GrenadeAmmo);
			Player::decItemCount(%player,GrenadeAmmo);
		}
		else if (%playerId.GrenadeLauncher == 3)
		{
			%fired = Projectile::spawnProjectile("MineShell",%trans,%player,%vel);
			Player::decItemCount(%player,GrenadeAmmo);
		}
		else if (%playerId.GrenadeLauncher == 4)
		{

			%fired = Projectile::spawnProjectile("PlasEnShell",%trans,%player,%vel);
			%energy = GameBase::getEnergy(%player);
			%energy -= 20;
			GameBase::setEnergy(%player,%energy);
		}

	}	
}

function GrenadeLauncher::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.GrenadeLauncher || %client.GrenadeLauncher == 0)
	{
	        bottomprint(%client, "<jc><f2>Grenade Launcher<f1> Standard Nades", 2);
	}
	if (%client.GrenadeLauncher == 1)
	{
	        bottomprint(%client, "<jc><f2>Grenade Launcher<f1> Repulsor Nades", 2);
	}
	if (%client.GrenadeLauncher == 2)
	{
	        bottomprint(%client, "<jc><f2>Grenade Launcher<f1> Napalm Nades", 2);
	}
	if (%client.GrenadeLauncher == 3)
	{
	        bottomprint(%client, "<jc><f2>Grenade Launcher<f1> Mine Nades", 2);
	}    
	if (%client.GrenadeLauncher == 4)
	{
	        bottomprint(%client, "<jc><f2>Grenade Launcher<f1> Energy Pulse Nades", 2);
	}       
}