$InvList[TBlastCannon] = 1;
$MobileInvList[TBlastCannon] = 1;
$RemoteInvList[TBlastCannon] = 1;

$InvList[TBlastCannonAmmo] = 1;
$MobileInvList[TBlastCannonAmmo] = 1;
$RemoteInvList[TBlastCannonAmmo] = 1;

$AutoUse[TBlastCannon]	= false;
$WeaponAmmo[TBlastCannon] = TBlastCannonAmmo;
$SellAmmo[TBlastCannonAmmo] = 5;

AddWeapon(TBlastCannon);
AddAmmo(TBlastCannon, TBlastCannonAmmo, 3);

ItemData TBlastCannonAmmo
{
	description = "Blast Cannon Shots";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData TBlastCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = TBlastCannonAmmo;
	accuFire = false;
	reloadTime = 0.4;
	fireTime = 0.4;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireFlierRocket; //SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundEnergyTurretTurn;
	sfxReady = SoundBeaconActive;
};

ItemData TBlastCannon  
{
	description = "Heavy Blast Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "weapon";
  	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TBlastCannonImage; 
	price = 2000;
	showWeaponBar = true;
};

function TBlastCannonImage::onFire(%player,%slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%Ammo = Player::getItemCount(%player, $WeaponAmmo[TBlastCannon]);
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	if(%Ammo > 0)
	{
		//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));
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
	{
		Client::sendMessage(Player::getClient(%player), 0,"You have no ammo for the Heavy Blast Cannon.");
	}
}

function TBlastCannon::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Heavy Blast Cannon: <f2>Mounted");
}
