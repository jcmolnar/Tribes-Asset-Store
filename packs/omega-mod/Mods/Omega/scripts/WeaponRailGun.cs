$InvList[RG]=1;
$RemoteInvList[RG]=1;

$InvList[RGAmmo]=1;
$RemoteInvList[RGAmmo]=1;

$AutoUse[RG] = false;
$WeaponAmmo[RG] = RGAmmo;
$AmmoPackMax[RGAmmo] = 40; 
$AmmoPackItems[15] = RGAmmo; 
$SellAmmo[RGAmmo] = 150; 

$RGSlotA=4;
$RGSlotB=7;

ItemData RGAmmo 
{
	description = "70mm Magneto Rails"; 
	className = "Ammo"; 
	shapeFile = "discammo"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 30; 
}; 

ItemImageData RGImage 
{
	shapeFile = "plasma"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 3.14159, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = RGAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData RG 
{
	description = "70mm Rail Cannon"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "sniper"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = RGImage; 
	price = 550; 
	showWeaponBar = true; 
};

ItemImageData RG2Image 
{
	ammoType = RGAmmo; 
	projectileType = RailgunBolt; 
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData RG2 
{
	description = "RG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = RG2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function RGImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,RGammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("RailgunBolt",%trans,%player,%vel,%player); 
	if(!$FiringRG[%client]) 
		CheckRG(%client, %player); 
}

function RG::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, RG2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function RG::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,RG2,$RGSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>Rail Gun: <f2>Fires 2 magnetic rails at the speed of sound.");
}

function RG::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$RGSlotA);
}

function CheckRG(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "RG")) 
	{	Player::trigger(%player,$RGSlotA,true);
		schedule("CheckRG(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringRG[%client] = true; 
	}
	else 
	{	Player::trigger(%player,$RGSlotA,false); 
		$FiringRG[%client] = false; 
	}
}
