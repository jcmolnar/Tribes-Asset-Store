//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(TranqGun);
$InvList[TranqGun] = 1;
$InvList[TranqAmmo] = 1;

$SellAmmo[TranqAmmo] = 10;
$AutoUse[TranqGun] = True;
$WeaponAmmo[TranqGun] = TranqAmmo;

$ItemMax[larmor, TranqGun] = 1;		//Seraph
$ItemMax[lfemale, TranqGun] = 1;	//Seraph
$ItemMax[earmor, TranqGun] = 0;		//Slave
$ItemMax[efemale, TranqGun] = 0;	//Slave
$ItemMax[marmor, TranqGun] = 0;		//Pawn
$ItemMax[aarmor, TranqGun] = 0;		//Navigator
$ItemMax[darmor, TranqGun] = 0;		//Atomizer
$ItemMax[barmor, TranqGun] = 0;		//Paladin

$ItemMax[larmor, TranqAmmo] = 50;	//Seraph
$ItemMax[lfemale, TranqAmmo] = 50;	//Seraph
$ItemMax[earmor, TranqAmmo] = 0;	//Slave
$ItemMax[efemale, TranqAmmo] = 0;	//Slave
$ItemMax[marmor, TranqAmmo] = 0;	//Pawn
$ItemMax[aarmor, TranqAmmo] = 0;	//Navigator
$ItemMax[darmor, TranqAmmo] = 0;	//Atomizer
$ItemMax[barmor, TranqAmmo] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


ItemData TranqAmmo 
{
	description = "Poison Dart";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
}; 


ItemImageData TranqGunImage 
{ 
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, -10.00, 0 };
	weaponType = 0;
	ammoType = TranqAmmo;
	//projectileType = TranqDart;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireChainGun;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData TranqGun 
{
	description = "Dart Gun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TranqGunImage;
	price = 77;
	showWeaponBar = true;
}; 

function TranqGunImage::onFire(%player, %slot) 
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[TranqGun]);
	%playerId = Player::getClient(%player);
	 
	 if(%Ammo || %client.fireTranqGun) 
	 {
	 	%fired.deployer = %player;
		%client = GameBase::getOwnerClient(%player);
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);

		if (!%playerId.TranqGun || %playerId.TranqGun == 0)
		{
			%fired = Projectile::spawnProjectile("TranqDart",%trans,%player,%vel);
		}
		else if (%playerId.TranqGun == 1)
		{
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 8);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 11);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 14);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 17);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel - 8);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel - 11);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel - 14);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel - 17);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 1);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 9);
			%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 12);
			//%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 15);
			//%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel + 18);
			//%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel - 9);
			//%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel - 12);
			//%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel - 15);
			//%fired = Projectile::spawnProjectile("NematBullet",%trans,%player,%vel - 18);
		Player::decItemCount(%player,TranqAmmo);
		Player::decItemCount(%player,TranqAmmo);
		Player::decItemCount(%player,TranqAmmo);
		Player::decItemCount(%player,TranqAmmo);
		Player::decItemCount(%player,TranqAmmo);
		//Player::decItemCount(%player,TranqAmmo);
		}
		Player::decItemCount(%player,TranqAmmo);
	}	
}

function TranqGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.TranqGun || %client.TranqGun == 0)
	{
	        bottomprint(%client, "<jc><f2>Dart Gun <f1> Sniper Mode", 2);
	}
	if (%client.TranqGun == 1)
	{
	        bottomprint(%client, "<jc><f2>Dart Gun <f1> Nematocyst Mode", 2);
	}        
}