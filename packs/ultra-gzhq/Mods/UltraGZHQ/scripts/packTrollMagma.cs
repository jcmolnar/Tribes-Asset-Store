$InvList[TrollMagmaPack] = 1;
$MobileInvList[TrollMagmaPack] = 1;
$RemoteInvList[TrollMagmaPack] = 1;
AddItem(TrollMagmaPack);

//--------------------------------------
RocketData TrollBlast
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = plasmaExp;
   collisionRadius = 0.0;
   mass            = 0.5;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.55;
   damageType       = $PlasmaDamageType;
   explosionRadius  = 3.5;
   kickBackStrength = 20.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 75.0;
   acceleration     = 8.0;
   totalTime        = 3.75;
   liveTime         = 3.7;
   lightRange       = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1;
   soundId = SoundJetLight;
};

//--------------------------------------


ItemImageData TrollMagmaPackImage
{
	shapeFile = "plasammo";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = -1;
	maxEnergy = -3;   // Energy used/sec for sustained weapons
	firstPerson = false;
};

ItemData TrollMagmaPack
{
	description = "Magma Pack";
	shapeFile = "plasammo";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = TrollMagmaPackImage;
	price = 1850;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TrollMagmaPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == TrollCannon) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function TrollMagmaPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
	if(!%player.invulnerable)
		Player::mountItem(%player,TrollCannon,$WeaponSlot);
	bottomprint(Player::getClient(%player), "<jc>Magma Cannon: <f2>Very Heavy Plasma Cannon. Heed it's warning messages or pay the price", 7);
	}
}

function TrollMagmaPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == TrollCannon) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the TrollCannon
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}


//----------------------------------------------------------------------------
ItemImageData TrollCannonImage
{
	shapeFile  = "grenammo";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.05 };
	weaponType = 3;  
	reloadTime = 0;
	fireTime = 0.1;
	spinUpTime = 0.01;
	minEnergy = 0.06;
	maxEnergy = 0.06;
	lightType = 3;  // Weapon Fire
	lightRadius = 0.01;
	lightTime = 1;
	lightColor = { 1.5, 0.25, 1.0 };	
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundTeleportPower; 
};

ItemData TrollCannon
{
	description = "Magma Cannon";
	shapeFile = "plasammo";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = TrollCannonImage;
	showInventory = false;
	price = 0;
   validateShape = true;
};

function TrollCannon::onMount(%player,%imageSlot)
{
	Player::setItemCount(%player, "TrollCannonAAmmo", 2);
	Player::mountItem(%player,TrollCannonA,6); 
	Player::setItemCount(%player, "TrollCannonBAmmo", 2);
	Player::mountItem(%player,TrollCannonB,7); 
	Player::trigger(%player,$BackpackSlot,true);
}

function TrollCannon::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,6); 
	Player::unmountItem(%player,7); 
	Player::trigger(%player,$BackpackSlot,false);
}

function TrollCannonImage::onFire(%player, %slot) 
{ 
%enVal  = 0.06;
%energy = GameBase::getEnergy(%player);
%energy = %energy - %enVal;
%player.PlasmaTemp++;
CoolTrollPack(%player);
if (%energy > 1.0)
	{
	if (%player.PlasmaTemp > 15.0) //catch on fire and drop the pack
		{
		Client::sendMessage(Player::getClient(%player),1,"Your Plasma Pack RUPTURED!");
	Player::unmountItem(%damagedClient,3);
		Player::mountItem(%player,BurnFlame,3);
			Player::trigger(%player,$WeaponSlot,false);
			Player::trigger(%player,6,false);
			Player::trigger(%player,7,false);
			playSound(turretExplosion,GameBase::getPosition(%player));
			GameBase::applyDamage(%player,$BurnDamageType, 0.5,
			GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
		}
	else
	if (%player.PlasmaTemp > 18.0) //warn player of impending doom
		{
Client::sendMessage(Player::getClient(%player),1,"Plasma temperature reaching critical!");
	%state1 = Player::getItemState(%player,6);
	%state2 = Player::getItemState(%player,7);
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload")  			{
		%client = GameBase::getOwnerClient(%player); 
		if(%client.ac == 0) 
				{
			%client.ac = 1;
   			GameBase::setEnergy(%player,%energy);
			Player::setItemCount(%player, "TrollCannonAAmmo", 1);
			Player::trigger(%player,6,true);
				} 
		else 
				{
			%client.ac = 0;
   			GameBase::setEnergy(%player,%energy);
			Player::setItemCount(%player, "TrollCannonBAmmo", 1);
			Player::trigger(%player,7,true);
				}
			}
		}
	else //fire normally
		{
	%state1 = Player::getItemState(%player,6);
	%state2 = Player::getItemState(%player,7);
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload")  			{
		%client = GameBase::getOwnerClient(%player); 
		if(%client.ac == 0) 
				{
			%client.ac = 1;
   			GameBase::setEnergy(%player,%energy);
			Player::setItemCount(%player, "TrollCannonAAmmo", 1);
			Player::trigger(%player,6,true);
				} 
		else 
				{
			%client.ac = 0;
   			GameBase::setEnergy(%player,%energy);
			Player::setItemCount(%player, "TrollCannonBAmmo", 1);
			Player::trigger(%player,7,true);
				}
			}
		}
	}
else
	{
	 playSound(SoundPackFail,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 0,"Magma Cannon must Recharge");
	} 
}

function CoolTrollPack(%client)
{
if (%client.PlasmaTemp > 0)
	{
	%weaponmode = Player::getItemState(%client,$WeaponSlot);
	if (%weaponmode != "Fire" && %weaponmode != "Reload")
		{
		%client.PlasmaTemp--;
		schedule("CoolTrollPack(" @ %client @ ");",2,%client);
		}
	else
	schedule("CoolTrollPack(" @ %client @ ");",2,%client);
	}
}

ItemData TrollCannonAAmmo
{
	description = "TrollA Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
showInventory = false; 
}; 

ItemImageData TrollCannonAImage
{
        shapeFile  = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.02, 0, 0 };
	mountRotation = { 0, -1.57, 0 };
        weaponType = 1;
	ammoType = TrollCannonAAmmo;
	projectileType = TrollBlast;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.2;
	spinUpTime = 0;
	spinDownTime = 0;
	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundPickUpWeapon;
};

ItemData TrollCannonA
{
   heading = "cProjectile Weapons";
        description = "TrollCannon A";
	className = "Weapon";
        shapeFile  = "mortargun";
	hudIcon = "chain";
	shadowDetailMask = 4;
        imageType = TrollCannonAImage;
        price = 300;
showWeaponBar = false; 
showInventory = false;
 }; 

ItemData TrollCannonBAmmo
{
	description = "Trollb Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
showInventory = false; }; 

ItemImageData TrollCannonBImage
{
        shapeFile  = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.02, 0, 0 };
	mountRotation = { 0, 1.57, 0 };
        weaponType = 1;
	ammoType = TrollCannonBAmmo;
	projectileType = TrollBlast;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.2;
	spinUpTime = 0;
	spinDownTime = 0;
           
	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundPickUpWeapon;
};

ItemData TrollCannonB
{
   heading = "cProjectile Weapons";
        description = "TrollCannon B";
	className = "Weapon";
        shapeFile  = "mortargun";
	hudIcon = "chain";
	shadowDetailMask = 4;
        imageType = TrollCannonBImage;
        price = 300;
showWeaponBar = false; 
showInventory = false; 
}; 