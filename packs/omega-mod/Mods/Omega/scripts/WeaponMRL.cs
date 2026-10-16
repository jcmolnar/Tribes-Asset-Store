$InvList[MRL]=1;
$MobileInvList[MRL]=1;
$RemoteInvList[MRL]=1;

$InvList[MRLAmmo]=1;
$MobileInvList[MRLAmmo]=1;
$RemoteInvList[MRLAmmo]=1;

$AutoUse[MRL] = false;
$WeaponAmmo[MRL] = MRLAmmo;
$AmmoPackMax[MRLAmmo] = 40; 
$AmmoPackItems[15] = MRLAmmo; 
$SellAmmo[MRLAmmo] = 150; 

addweapon(MRL);
addAmmo(MRL, MRLAmmo, 5);

$MRLSlotA=4;
$MRLSlotB=7;

ItemData MRLAmmo 
{
	description = "Mini Rockets"; 
	className = "Ammo"; 
	shapeFile = "rocket"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 400; 
}; 

ItemImageData MRLImage 
{
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, -0.1 }; 
	mountRotation = { 0, 3.14159, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = MRLAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData MRL
{
	description = "Mini-Rocket Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "ammopack"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = MRLImage; 
	price = 600; 
	showWeaponBar = true; 
};

ItemImageData MRL2Image 
{
	ammoType = MRLAmmo; 
	projectileType = MR; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData MRL2 
{
	description = "MRL"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = MRL2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function MRLImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,MRLammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MR",%trans,%player,%vel,%player); 
	Projectile::spawnProjectile("MR2",%trans,%player,%vel,%player); 
}

function MRL::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, MRL2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function MRL::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,MRL2,$MRLSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>MRL: fires a rocket that does high damage, small radius");
}

function MRL::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$MRLSlotA);
}
