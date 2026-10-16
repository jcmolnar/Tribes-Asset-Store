$InvList[TankShredder]=1;
$MobileInvList[TankShredder]=1;
$RemoteInvList[TankShredder]=1;

$InvList[TankShredderAmmo]=1;
$MobileInvList[TankShredderAmmo]=1;
$RemoteInvList[TankShredderAmmo]=1;

$AutoUse[TankShredder] = True;
$WeaponAmmo[TankShredder] = TankShredderAmmo;
$SellAmmo[TankShredderAmmo] = 500;

addweapon(TankShredder);
addAmmo(TankShredder, TankShredderAmmo, 15);

$TankShredderSlotA=4;
$TankShredderSlotB=7;
$TankShredderSlotC=6;


ItemData TankShredderAmmo 
{	description = "Tank Shredder Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData TankShredderImage 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, -0.351, 0 };
	mountRotation = { 0, -1.01, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickupWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData TankShredder 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TankShredderImage;
	price = 7500;
	showWeaponBar = true;
};


ItemImageData TankShredder2Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.21, -0.351, 0 };
	mountRotation = { 0, 1.01, 0};
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder2 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData TankShredder3Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.3051, -0.201, 0.251 };
	mountRotation = { 0, 1.501, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder3 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder3Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};
ItemImageData TankShredder4Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 };
	mountRotation = { 0, -1.501, 0}; 
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder4 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder4Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

// --------------------------------------- Firing Functions --------------------------------------

function MDCheckTankShredder(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankShredder")) 
	{	Player::trigger(%player,$TankShredderSlot,true);
		schedule("MDCheckTankShredder(" @ %client @ "," @ %player @ ");",0.05);
		$MDFiringTankShredder[%client] = true;
	}
	else
	{	Player::trigger(%player,$TankShredderSlot,false);
		$MDFiringTankShredder[%client] = false;
	}
}

function TankShredderImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,$WeaponAmmo[TankShredder],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ShredderBullet",%trans,%player,%vel,%player);
	if(!$MDFiringTankShredder[%client]) 
		MDCheckTankShredder(%client, %player);
}

function TankShredder::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TankShredder2, 0);
		Item::onDrop(%player,%item);
	}
}

function TankShredder::onMount(%player,%imageSlot, %item, $WeaponSlot) 
{	Player::mountItem(%player,TankShredder2,$TankShredderSlotA);
	Player::mountItem(%player,TankShredder3,$TankShredderSlotB);
	Player::mountItem(%player,TankShredder4,$TankShredderSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Tank Shredder: <f2>You don't want to get in the way of this quad chaingun!");
}

function TankShredder::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TankShredderSlotA);
	Player::unmountItem(%player,$TankShredderSlotB);	 
	Player::unmountItem(%player,$TankShredderSlotC);
}

function MDCheckTankShredder(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankShredder")) 
	{	Player::trigger(%player,$TankShredderSlotA,true);
		Player::trigger(%player,$TankShredderSlotB,true);
		Player::trigger(%player,$TankShredderSlotC,true);
		schedule("MDCheckTankShredder(" @ %client @ "," @ %player @ ");",0.1);
		$MDFiringTankShredder[%client] = true;
	}
	else 
	{	Player::trigger(%player,$TankShredderSlotA,false);
		Player::trigger(%player,$TankShredderSlotB,false);
		Player::trigger(%player,$TankShredderSlotC,false);
		$MDFiringTankShredder[%client] = false;
	}
}
