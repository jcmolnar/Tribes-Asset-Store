$InvList[TBlastCannon] = 1;
$MobileInvList[TBlastCannon] = 1;
$RemoteInvList[TBlastCannon] = 1;

$InvList[TBlastCannonAmmo] = 1;
$MobileInvList[TBlastCannonAmmo] = 1;
$RemoteInvList[TBlastCannonAmmo] = 1;

$AutoUse[TBlastCannon]	= True;
$WeaponAmmo[TBlastCannon] = TBlastCannonAmmo;
$SellAmmo[TBlastCannonAmmo] = 5;

AddWeapon(TBlastCannon);
AddAmmo(TBlastCannon, TBlastCannonAmmo, 3);

ItemData TBlastCannonAmmo
{	description = "Blast Cannon Shots";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mrtwig";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData TBlastCannonImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = TBlastCannonAmmo;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireFlierRocket; //SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundEnergyTurretTurn;
	sfxReady = SoundBeaconActive;
};

function TBlastCannonImage::onFire(%player,%slot) 
{	
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[TBlastCannon]);
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	if(%Ammo > 0)
	{	//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));
		Player::decItemCount(%player,$WeaponAmmo[TBlastCannon],1);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
	}
	else
	{	Client::sendMessage(Player::getClient(%player), 0,"You have no ammo for the Tank BlastCannon Cannon");
	}
}

ItemData TBlastCannon  
{	description = "Tank Blast Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
  	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TBlastCannonImage; 
	price = 2000;
	showWeaponBar = true;
};

function TBlastCannon::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Tank Blast Cannon: <f2>Only the Tank could wield this massive weapon.  It's a shotgun on crack!");
}
