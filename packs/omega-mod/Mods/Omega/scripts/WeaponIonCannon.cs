$InvList[Icannon]=1;
$MobileInvList[Icannon]=1;
$RemoteInvList[Icannon]=1;

$InvList[IcannonAmmo]=1;
$MobileInvList[IcannonAmmo]=1;
$RemoteInvList[IcannonAmmo]=1;

$AutoUse[Icannon] = false;
$WeaponAmmo[Icannon] = IcannonAmmo;
$AmmoPackMax[IcannonAmmo] = 70; 
$AmmoPackItems[15] = IcannonAmmo; 
$SellAmmo[IcannonAmmo] = 150; 

addweapon(Icannon);
addAmmo(Icannon, IcannonAmmo, 5);

$IcannonSlotA=4;
$IcannonSlotB=7;

ItemData IcannonAmmo 
{
	description = "Ion Pax"; 
	className = "Ammo"; 
	shapeFile = "discammo"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 150; 
}; 

ItemImageData IcannonImage 
{
	shapeFile = "plasma"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.5; 
	fireTime = 0.1;
	minEnergy = 10;	
	maxEnergy = 10;
	ammoType = IcannonAmmo; 
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundEnergyPackOn;
}; 

ItemData Icannon 
{
	description = "Ion Cannon"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	hudIcon = "blaster"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = IcannonImage; 
	price = 600; 
	showWeaponBar = true; 
};

ItemImageData Icannon2Image 
{
	ammoType = IcannonAmmo; 
	projectileType = IonBlast; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 3.14159, 0}; 
	weaponType = 0; 
	reloadTime = 0.25;
	fireTime = 0.25;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData Icannon2 
{
	description = "Icannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = Icannon2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function IcannonImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Icannonammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("IonBlast",%trans,%player,%vel,%player); 
	if(!$FiringIcannon[%client]) 
		CheckIcannon(%client, %player); 
}

function Icannon::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, Icannon2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function Icannon::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,Icannon2,$IcannonSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>Ion Cannon: <f2>Launchers a projectile at high speed charged with ions..");
}

function Icannon::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$IcannonSlotA);
}
