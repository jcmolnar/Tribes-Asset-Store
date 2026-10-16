$InvList[TankRPGLauncher]=1;
$MobileInvList[TankRPGLauncher]=1;
$RemoteInvList[TankRPGLauncher]=1;

$InvList[TankRPGAmmo]=1;
$MobileInvList[TankRPGAmmo]=1;
$RemoteInvList[TankRPGAmmo]=1;

$AutoUse[TankRPGLauncher] = True;
$WeaponAmmo[TankRPGLauncher] = TankRPGAmmo;
$AmmoPackMax[TankRPGAmmo] = 300; 
$AmmoPackItems[15] = TankRPGAmmo; 
$SellAmmo[TankRPGAmmo] = 150; 

addweapon(TankRPGLauncher);
addAmmo(TankRPGLauncher, TankRPGAmmo, 5);

$TankRPGSlotA=4;
$TankRPGSlotB=7;
$TankRPGSlotC=6; 

ItemData TankRPGAmmo 
{	description = "RPGs"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = $InvHead[ihAmm]; 
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData TankRPGLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.25 }; 
	mountRotation = { 0, 1.50, 0 }; 
	weaponType = 0; 
	reloadTime = 0.05; 
	fireTime = 0.05;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = TankRPGAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData TankRPGLauncher 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "chain"; 
	heading = $InvHead[ihWea]; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncherImage; 
	price = 550; 
	showWeaponBar = true; 
};

ItemImageData TankRPGLauncher2Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0}; 
	weaponType = 0; 
	reloadTime = 0.07;
	fireTime = 0.07;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher2 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData TankRPGLauncher3Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.09;
	fireTime = 0.09;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher3 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData TankRPGLauncher4Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0}; 
	weaponType = 0; 
	reloadTime = 0.08; 
	fireTime = 0.08;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher4 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

// --------------------------------- Firing Function --------------------------

function TankRPGLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,TankRPGammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("RPG",%trans,%player,%vel,%player); 
	if(!$FiringTankRPGLauncher[%client]) 
		CheckTankRPGLauncher(%client, %player); 
}

function TankRPGLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TankRPGLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function TankRPGLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,TankRPGLauncher2,$TankRPGSlotA); 
	Player::mountItem(%player,TankRPGLauncher3,$TankRPGSlotB); 
	Player::mountItem(%player,TankRPGLauncher4,$TankRPGSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Tank RPG: <f2>Fires four highly explosive missiles to pummel your target.");
}

function TankRPGLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TankRPGSlotA);
	Player::unmountItem(%player,$TankRPGSlotB);	 
	Player::unmountItem(%player,$TankRPGSlotC);
}

function CheckTankRPGLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankRPGLauncher")) 
	{	Player::trigger(%player,$TankRPGSlotA,true);
		Player::trigger(%player,$TankRPGSlotB,true);
		Player::trigger(%player,$TankRPGSlotC,true); 
		schedule("CheckTankRPGLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringTankRPGLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$TankRPGSlotA,false); 
		Player::trigger(%player,$TankRPGSlotB,false); 
		Player::trigger(%player,$TankRPGSlotC,false); 
		$FiringTankRPGLauncher[%client] = false; 
	} 
}
