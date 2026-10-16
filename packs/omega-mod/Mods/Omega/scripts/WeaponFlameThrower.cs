$InvList[FlameThrower]=1;
$MobileInvList[FlameThrower]=1;
$RemoteInvList[FlameThrower]=1;

$InvList[FlameThrowerAmmo]=1;
$MobileInvList[FlameThrowerAmmo]=1;
$RemoteInvList[FlameThrowerAmmo]=1;

$AutoUse[FlameThrower] = false;
$WeaponAmmo[FlameThrower] = FlameThrowerAmmo;
$AmmoPackMax[FlameThrowerAmmo] = 100; 
$AmmoPackItems[15] = FlameThrowerAmmo; 
$SellAmmo[FlameThrowerAmmo] = 300; 

addweapon(FlameThrower);
addAmmo(FlameThrower, FlameThrowerAmmo, 5);

$FlameThrowerSlotA=4;
$FlameThrowerSlotB=7;

ItemData FlameThrowerAmmo 
{
	description = "Methane Fuel Cells"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 90; 
}; 

ItemImageData FlameThrowerImage 
{
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 3.14159, 0 }; 
	weaponType = 0; 
	reloadTime = 0.1; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = FlameThrowerAmmo; 
	accuFire = true; 
	sfxFire = SoundButtonPDAHard; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundSensorPower;
}; 

ItemData FlameThrower
{
	description = "M.J.I.T."; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "plasma"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = FlameThrowerImage; 
	price = 600; 
	showWeaponBar = true; 
};

ItemImageData FlameThrower2Image 
{
	ammoType = FlameThrowerAmmo; 
	projectileType = MethaneBolt; 
	shapeFile = "plasma"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 0.5;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = soundPDAButtonHard; 
};

ItemData FlameThrower2 
{
	description = "FlameThrower"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = FlameThrower2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function FlameThrowerImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,FlameThrowerammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MethaneBolt",%trans,%player,%vel,%player); 
	if(!$FiringFlameThrower[%client]) 
		CheckFlameThrower(%client, %player); 
}

function FlameThrower::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, FlameThrower2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function FlameThrower::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,FlameThrower2,$FlameThrowerSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "The Methane Jet Incendary Thrower(MJIT( throws out methane streams of gas that will catch almost anything into flames");
}

function FlameThrower::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$FlameThrowerSlotA);
}

function CheckFlameThrower(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "FlameThrower")) 
	{	Player::trigger(%player,$FlameThrowerSlotA,true);
		schedule("CheckFlameThrower(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringFlameThrower[%client] = true; 
	}
	else 
	{	Player::trigger(%player,$FlameThrowerSlotA,false); 
		$FiringFlameThrower[%client] = false; 
	}
}
