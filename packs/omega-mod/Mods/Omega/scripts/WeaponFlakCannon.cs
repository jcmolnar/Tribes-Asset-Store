$InvList[Flakcannon]=1;
$MobileInvList[Flakcannon]=1;
$RemoteInvList[Flakcannon]=1;

$InvList[FlakcannonAmmo]=1;
$MobileInvList[FlakcannonAmmo]=1;
$RemoteInvList[FlakcannonAmmo]=1;

$AutoUse[Flakcannon] = false;
$WeaponAmmo[Flakcannon] = FlakcannonAmmo;
$AmmoPackMax[FlakcannonAmmo] = 70; 
$AmmoPackItems[15] = FlakcannonAmmo;     
$SellAmmo[FlakcannonAmmo] = 150; 

addweapon(Flakcannon);
addAmmo(Flakcannon, FlakcannonAmmo, 5);

$FlakcannonSlotA=4;
$FlakcannonSlotB=7;

ItemData FlakcannonAmmo 
{
	description = "Flak Shells"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 170; 
}; 

ItemImageData FlakcannonImage 
{
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.5; 
	fireTime = 0.1;
	minEnergy = 10;	
	maxEnergy = 10;
	ammoType = FlakcannonAmmo; 
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData Flakcannon 
{
	description = "Flak Cannon"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	hudIcon = "ammopack"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = FlakcannonImage; 
	price = 1250; 
	showWeaponBar = true; 
};

ItemImageData Flakcannon2Image 
{
	ammoType = FlakcannonAmmo; 
	projectileType = FlakShell; 
	shapeFile = "jetpack"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, -1.57, 0}; 
	weaponType = 0; 
	reloadTime = 0.50;
                fireTime = 0.1;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData Flakcannon2 
{
	description = "Flakcannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = Flakcannon2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function FlakcannonImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Flakcannonammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel,%player);
	Projectile::spawnProjectile("FlakShell2",%trans,%player,%vel,%player);
		
}

function Flakcannon::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, Flakcannon2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function Flakcannon::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,Flakcannon2,$FlakcannonSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>Flak Cannon: firing shells that are filled with flammable materials and sand, killing anything in almost 3 shots.");
}

function Flakcannon::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$FlakcannonSlotA);
}