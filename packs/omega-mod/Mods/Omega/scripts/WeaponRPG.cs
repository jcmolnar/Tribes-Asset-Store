//----Armordata.cs Stuff
$ItemMax[larmor, RPG] = 0;
$ItemMax[lfemale, RPG] = 0;
$ItemMax[marmor, RPG] = 1;
$ItemMax[mfemale, RPG] = 1;
$ItemMax[harmor, RPG] = 0;
//---Ammo
$ItemMax[larmor, RPGAmmo] = 0;
$ItemMax[lfemale, RPGAmmo] = 0;
$ItemMax[marmor, RPGAmmo] = 50;
$ItemMax[mfemale, RPGAmmo] = 50;
$ItemMax[harmor, RPGAmmo] = 0;
//----BaseProjData.cs
//----
GrenadeData RPGShell
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = RPGExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 6000;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};
//-----Things that make it Work

$InvList[RPG]=1;
$RemoteInvList[RPG]=1;

$InvList[RPGAmmo]=1;
$RemoteInvList[RPGAmmo]=1;

$AutoUse[RPG] = false;
$WeaponAmmo[RPG] = RPGAmmo;
$AmmoPackMax[RPGAmmo] = 40; 
$AmmoPackItems[15] = RPGAmmo; 
$SellAmmo[RPGAmmo] = 150;

$RPGSlotA=4;
$RPGSlotB=7;

ItemData RPGAmmo 
{
	description = "RPG Shells"; 
	className = "Ammo"; 
	shapeFile = "mortar"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 300; 
}; 

ItemImageData RPGImage 
{
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	mountOffset = { -0.2, 0, 0 }; 
	mountRotation = { 0, 1.57075, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 1.0;
	ammoType = RPGAmmo; 
	accuFire = true; 
	sfxFire = SoundFireGrenade; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData RPG 
{
	description = "RPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "ammopack"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = RPGImage; 
	price = 550; 
	showWeaponBar = true; 
};

ItemImageData RPG2Image 
{
	ammoType = RPGAmmo; 
	projectileType = RPGShell; 
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, -1.57075, 0}; 
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.6;
	accuFire = true; 
	sfxFire = SoundMOrtarTurretFire; 
};

ItemData RPG2 
{
	description = "RPG"; 
	className = "Weapon"; 
	shapeFile = "mortaRGun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = RPG2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function RPGImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,RPGammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("RPGShell",%trans,%player,%vel,%player); 
	if(!$FiringRPG[%client]) 
		CheckRPG(%client, %player); 
}

function RPG::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, RPG2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function RPG::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,RPG2,$RPGSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>RPG: Fires a rocket propelled grenade. This shell looses its volocity after a short while");
}

function RPG::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$RPGSlotA);
}

function CheckRPG(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "RPG")) 
	{	Player::trigger(%player,$RPGSlotA,true);
		schedule("CheckRPG(" @ %client @ "," @ %player @ ");",1.0); 
		$FiringRPG[%client] = true; 
	}
	else 
	{	Player::trigger(%player,$RPGSlotA,false); 
		$FiringRPG[%client] = false; 
	}
}
