$InvList[AnniChain]=0;
$MobileInvList[AnniChain]=0;
$RemoteInvList[AnniChain]=0;

$SellAmmo[AnniChainAmmo] = 50;
$InvList[AnniChainAmmo]=0;
$MobileInvList[AnniChainAmmo]=0;
$RemoteInvList[AnniChainAmmo]=0;

$AutoUse[AnniChain] = false;
$WeaponAmmo[AnniChain] = AnniChainAmmo;
$AmmoPackMax[AnniChainAmmo] = 250; 
$AmmoPackItems[15] = AnniChainAmmo;     
$SellAmmo[AnniChainAmmo] = 150; 

addweapon(AnniChain);
addAmmo(AnniChain, AnniChainAmmo, 5);

$AnniChainSlotA=4;
$AnniChainSlotB=7;

ItemData AnniChainAmmo 
{
	description = "Annihilator Shells"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 300; 
}; 

ItemImageData AnniChainImage 
{
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.05; 
	fireTime = 0.05;
	minEnergy = 10;	
	maxEnergy = 10;
	ammoType = AnniChainAmmo;
	projectileType = ACShell;  
	accuFire = true; 
	sfxFire = SoundFireChaingun; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData AnniChain
{
	description = "Annihilation ChainGun"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	hudIcon = "ammopack"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = AnniChainImage; 
	price = 3000; 
	showWeaponBar = true; 
};

ItemImageData AnniChain2Image 
{
	ammoType = AnniChainAmmo; 
	projectileType = ACShell; 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.15 }; 
	mountRotation = { 0, -1.57, 0}; 
	weaponType = 0; 
	reloadTime = 0.05;
                fireTime = 0.05;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData AnniChain2 
{
	description = "AnniChain"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = AnniChain2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function AnniChainImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,AnniChainammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("ACShell",%trans,%player,%vel,%player);
		
}

function AnniChain::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, AnniChain2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function AnniChain::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,AnniChain2,$AnniChainSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>____.........:::::::<[Insufficiant Data]>::::::::.........____");
}

function AnniChain::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$AnniChainSlotA);
}