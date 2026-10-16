$InvList[HawkTC]=1;
$RemoteInvList[HawkTC]=1;

$InvList[HawkTCAmmo]=1;
$RemoteInvList[HawkTCAmmo]=1;

$AutoUse[HawkTC] = false;
$WeaponAmmo[HawkTC] = HawkTCAmmo;
$AmmoPackMax[HawkTCAmmo] = 18; 
$AmmoPackItems[15] = HawkTCAmmo;     
$SellAmmo[HawkTCAmmo] = 150; 

$HawkTCSlotA=4;
$HawkTCSlotB=7;

ItemData HawkTCAmmo 
{
	description = "Uranium Packets"; 
	className = "Ammo"; 
	shapeFile = "grenammo"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 2300; 
}; 

ItemImageData HawkTCImage 
{
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 1.0;
	minEnergy = 10;	
	maxEnergy = 10;
	ammoType = HawkTCAmmo; 
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundDiscSpin;
}; 

ItemData HawkTC 
{
	description = "Hawk Torpedo Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	hudIcon = "disk"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = HawkTCImage; 
	price = 1250; 
	showWeaponBar = true; 
};

ItemImageData HawkTC2Image 
{
	ammoType = HawkTCAmmo; 
	projectileType = HawkTorpedo; 
	shapeFile = "grenammo"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 0.50;
                fireTime = 0.1;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData HawkTC2 
{
	description = "HawkTC"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = HawkTC2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function HawkTCImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,HawkTCammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("HawkTorpedo",%trans,%player,%vel,%player);
	Projectile::spawnProjectile("HawkTorpedo2",%trans,%player,%vel,%player);
		
}

function HawkTC::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, HawkTC2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function HawkTC::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,HawkTC2,$HawkTCSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>Hawk Torpedo Launcher: firing a high radius, high explosive shrapnel charge to blow your foolish foe away.");
}

function HawkTC::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$HawkTCSlotA);
}