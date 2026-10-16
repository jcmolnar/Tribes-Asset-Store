$InvList[DevCannon]=1;
$MobileInvList[DevCannon]=1;
$RemoteInvList[DevCannon]=1;

$InvList[DevCannonAmmo]=1;
$MobileInvList[DevCannonAmmo]=1;
$RemoteInvList[DevCannonAmmo]=1;

$AutoUse[DevCannon] = false;
$WeaponAmmo[DevCannon] = DevCannonAmmo;
$AmmoPackMax[DevCannonAmmo] = 70; 
$AmmoPackItems[15] = DevCannonAmmo; 
$SellAmmo[DevCannonAmmo] = 150; 

addweapon(DevCannon);
addAmmo(DevCannon, DevCannonAmmo, 5);

$DevCannonSlotA=4;
$DevCannonSlotB=7;
$DevCannonSlotC=6; 

ItemData DevCannonAmmo 
{
	description = "Devastator Blasts"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 30; 
}; 

ItemImageData DevCannonImage 
{
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.5 }; 
	mountRotation = { 0, 1.50, 0 }; 
	weaponType = 0; 
	reloadTime = 0.2; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = DevCannonAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData DevCannon 
{
	description = "Devastator Cannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "amun01"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = DevCannonImage; 
	price = 550; 
	showWeaponBar = true; 
};

ItemImageData DevCannon2Image 
{
	ammoType = DevCannonAmmo; 
	projectileType = DevBlast; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0}; 
	weaponType = 0; 
	reloadTime = 0.3;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = shockExplosion; 
};

ItemData DevCannon2 
{
	description = "DevCannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = DevCannon2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData DevCannon3Image 
{
	ammoType = DevCannonAmmo; 
	projectileType = DevBlast; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.4;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData DevCannon3 
{
	description = "DevCannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = DevCannon3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData DevCannon4Image 
{
	ammoType = DevCannonAmmo; 
	projectileType = DevBlast; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.5 }; 
	mountRotation = { 0, -1.50, 0}; 
	weaponType = 0; 
	reloadTime = 0.5; 
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData DevCannon4 
{
	description = "DevCannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = DevCannon4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function DevCannonImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,DevCannonAmmo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("DevBlast",%trans,%player,%vel,%player); 
	if(!$FiringDevCannon[%client]) 
		CheckDevCannon(%client, %player); 
}

function DevCannon::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, DevCannon2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function DevCannon::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,DevCannon2,$DevCannonSlotA); 
	Player::mountItem(%player,DevCannon3,$DevCannonSlotB); 
	Player::mountItem(%player,DevCannon4,$DevCannonSlotC);
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>Devastator Cannon: <f2>Billows out 4 deadly charges of explosives. Plummels the target in seconds.");
}

function DevCannon::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$DevCannonSlotA);
	Player::unmountItem(%player,$DevCannonSlotB);	 
	Player::unmountItem(%player,$DevCannonSlotC);
}

function CheckDevCannon(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "DevCannon")) 
	{	Player::trigger(%player,$DevCannonSlotA,true);
		Player::trigger(%player,$DevCannonSlotB,true);
		Player::trigger(%player,$DevCannonSlotC,true); 
		schedule("CheckDevCannon(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringDevCannon[%client] = true; 
	}
	else 
	{	Player::trigger(%player,$DevCannonSlotA,false); 
		Player::trigger(%player,$DevCannonSlotB,false); 
		Player::trigger(%player,$DevCannonSlotC,false); 
		$FiringDevCannon[%client] = false; 
	}
}
