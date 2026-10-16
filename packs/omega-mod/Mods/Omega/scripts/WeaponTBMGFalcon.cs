$InvList[Falcon]=1;
$RemoteInvList[Falcon]=1;

$InvList[FalconAmmo]=1;
$RemoteInvList[FalconAmmo]=1;

$AutoUse[Falcon] = false;
$WeaponAmmo[Falcon] = FalconAmmo;
$AmmoPackMax[FalconAmmo] = 200; 
$AmmoPackItems[15] = FalconAmmo; 
$SellAmmo[FalconAmmo] = 150; 

$FalconSlotA=4;
$FalconSlotB=7;
$FalconSlotC=6; 

ItemData FalconAmmo 
{
	description = "Quad-Bullets"; 
	className = "Ammo"; 
	shapeFile = "mortarammo"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 30; 
}; 

ItemImageData FalconImage 
{
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 1.57, 0 }; 
	weaponType = 0; 
	reloadTime = 0.05; 
	fireTime = 0.05;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = FalconAmmo; 
	accuFire = true; 
	sfxFire = explosion4; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData Falcon
{
	description = "T.B.L.G. Falcon Rifle"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "chain"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = FalconImage; 
	price = 1550; 
	showWeaponBar = true; 
};

ItemImageData Falcon2Image 
{
	ammoType = FalconAmmo; 
	projectileType = FalconBullet; 
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountOffset = { 0, 0.1, 0 }; 
	mountRotation = { 0, -1.57, 0}; 
	weaponType = 0; 
	reloadTime = 0.05;
	fireTime = 0.05;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData Falcon2 
{
	description = "Falcon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = Falcon2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData Falcon3Image 
{
	ammoType = FalconAmmo; 
	projectileType = FalconBullet; 
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.05;
	fireTime = 0.05;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData Falcon3 
{
	description = "Falcon"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = Falcon3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData Falcon4Image 
{
	ammoType = FalconAmmo; 
	projectileType = FalconLaser; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, -0.1 }; 
	mountRotation = { 0, 3.14159, 0}; 
	weaponType = 0; 
	reloadTime = 10.0; 
	fireTime = 10.0;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData Falcon4 
{
	description = "DevCannon"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = Falcon4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function FalconImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Falconammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("FalconBullet",%trans,%player,%vel,%player); 
	if(!$FiringFalcon[%client]) 
		CheckFalcon(%client, %player); 
}

function Falcon::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, Falcon2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function Falcon::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,Falcon2,$FalconSlotA); 
	Player::mountItem(%player,Falcon3,$FalconSlotB); 
	Player::mountItem(%player,Falcon4,$FalconSlotC);
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>Tri-Barraled Laser Guided Falcon Rifle, guidance with a laser, along with 3 bullets @ the same time. Evil one it is ");
}

function Falcon::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$FalconSlotA);
	Player::unmountItem(%player,$FalconSlotB);	 
	Player::unmountItem(%player,$FalconSlotC);
}

function CheckFalcon(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Falcon")) 
	{	Player::trigger(%player,$FalconSlotA,true);
		Player::trigger(%player,$FalconSlotB,true);
		Player::trigger(%player,$FalconSlotC,true); 
		schedule("CheckFalcon(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringFalcon[%client] = true; 
	}
	else 
	{	Player::trigger(%player,$FalconSlotA,false); 
		Player::trigger(%player,$FalconSlotB,false); 
		Player::trigger(%player,$FalconSlotC,false); 
		$FiringFalcon[%client] = false; 
	}
}
