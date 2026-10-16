$InvList[TitanBurstPack] = 1;
$MobileInvList[TitanBurstPack] = 1;
$RemoteInvList[TitanBurstPack] = 1;
AddItem(TitanBurstPack);

//--------------------------------------
//Titan Pack Projectiles
//--------------------------------------
 BulletData TitanFlakBomb
 {
	 bulletShapeName = "shield_medium.dts";
	 explosionTag = debrisExpLarge;
	 mass = 0.05;
	 bulletHoleIndex = 0;
  collisionRadius    = 15.0;
	 damageClass = 1;
   explosionRadius    = 8;
   kickBackStrength   = 120.0;
	 damageValue = 0.3; 
	 damageType = $ShrapnelDamageType;
	 aimDeflection = 0.006;
	 muzzleVelocity = 150.0;
	 totalTime = 4.5; 
	 liveTime = 4.45;
	 inheritedVelocityScale = 1.0;
	 isVisible = True;
 };



//----------------------------------------------------------------------------
ItemImageData TitanBurstPackImage
{
	shapeFile = "logo";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   	minEnergy = -1;
	maxEnergy = -5;   // Energy used/sec for sustained weapons
	mountOffset = { 0, 0, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData TitanBurstPack
{
	description = "Sonic Burst Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = TitanBurstPackImage;
	price = 1750;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TitanBurstPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == TitanCannon) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function TitanBurstPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
	if(!%player.invulnerable)
		Player::mountItem(%player,TitanCannon,$WeaponSlot);
	bottomprint(Player::getClient(%player), "<jc>Sonic Burst:<f2>Gathers Ionic energy into a reactor then releases it at your target, Heed the over heating warnings or feel a shock!", 2);
	}
}

function TitanBurstPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == TitanCannon) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the TitanCannon
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}

//----------------------------------------------------------------------------
//Titan Pack Weapon
//----------------------------------------------------------------------------
ItemImageData TitanCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, 3.14, 0 };
	mountOffset = { 0, 0.1, 0 };
	weaponType = 0;
      minEnergy = 0.06;
	maxEnergy = 0.06;
	accuFire = true;
	reloadTime = 0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.5, 0.25, 1.0 };	

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundTeleportPower; 
};

ItemData TitanCannon
{
	description = "Titan Cannon";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = TitanCannonImage;
	showInventory = false;
	price = 125;
   validateShape = true;
};

function TitanCannon::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,TitanCannonT,6); 
	Player::setItemCount(%player, "TitanCannonTAmmo", 3);
	Player::trigger(%player,$BackpackSlot,true);
   %player.TitanShort = 0;
}

function TitanCannon::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,6); 
	Player::trigger(%player,$BackpackSlot,false);
}

function TitanCannonImage::onFire(%player, %slot) 
{ 
   %enVal  = 0.06;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   %player.TitanShort++;
   TitanCircuit(%player);

	%rand = floor(getRandom() * 15);
	%chance = %rand + %player.TitanShort;
	if(%chance > 15) 
	{
	Player::unmountItem(%damagedClient,3);
	Player::mountItem(%player,ShortPack,3);
	schedule("Player::unmountItem(" @ %player @ "," @ 3 @ ");",6);
	}

   if (%energy >= 30.0)
	{
   		 GameBase::setEnergy(%player,%energy);
				Player::setItemCount(%player, "TitanCannonTAmmo", 3);
			Player::trigger(%player,6,true);
	}
	else
   if (%energy >= 0.0)
	{
   		 GameBase::setEnergy(%player,%energy);
				Player::setItemCount(%player, "TitanCannonTAmmo", 2);
			Player::trigger(%player,6,true);
	}
	else
   if (%energy < 0.0)
	{
   		 GameBase::setEnergy(%player,0);
				Player::setItemCount(%player, "TitanCannonTAmmo", 1);
			Player::trigger(%player,6,true);
	}
}

function TitanCircuit(%client)
{
if (%client.TitanShort> 0)
	{
	%weaponmode = Player::getItemState(%client,$WeaponSlot);
	if (%weaponmode != "Fire" && %weaponmode != "Reload")
		{
		%client.TitanShort--;
		schedule("TitanCircuit(" @ %client @ ");",2,%client);
		}
	else
	schedule("TitanCircuit(" @ %client @ ");",2,%client);
	}
}

ItemData TitanCannonTAmmo
{
	description = "Titan Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
showInventory = false; }; 

ItemImageData TitanCannonTImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };
        weaponType = 1;
	ammoType = TitanCannonTAmmo;
	projectileType = TitanFlakBomb;
	accuFire = false;
	reloadTime = 0;
	fireTime = 0.05;
	spinUpTime = 0;
	spinDownTime = 0;
	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundPickUpWeapon;
};

ItemData TitanCannonT
{
	description = "Titan Cannon Top";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = true;
	hudIcon = "chain";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = TitanCannonTImage;
	price = 125;
	showWeaponBar = false;
	showInventory = false;
};