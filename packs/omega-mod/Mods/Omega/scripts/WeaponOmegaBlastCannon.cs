//-----Armordata.cs Stuff
$ItemMax[larmor, OBCannon] = 0;
$ItemMax[lfemale, OBCannon] = 0;
$ItemMax[marmor, OBCannon] = 1;
$ItemMax[mfemale, OBCannon] = 1;
$ItemMax[harmor, OBCannon] = 1;

$ItemMax[larmor, OBCannonAmmo] = 0;
$ItemMax[lfemale, OBCannonAmmo] = 0;
$ItemMax[marmor, OBCannonAmmo] = 7;
$ItemMax[mfemale, OBCannonAmmo] = 7;
$ItemMax[harmor, OBCannonAmmo] = 14;

$DamageScale[larmor, $OhmDamageType] = 1;
$DamageScale[lfemale, $OhmDamageType] = 1;
$DamageScale[marmor, $OhmDamageType] = 1;
$DamageScale[mfemale, $OhmDamageType] = 1;
$DamageScale[harmor, $OhmDamageType] = 1;
$DamageScale[indalacioarmor, $OhmDamageType] = 100;


$InvList[OBCannon]=1;
$RemoteInvList[OBCannon]=1;

$InvList[OBCannonAmmo]=1;
$RemoteInvList[OBCannonAmmo]=1;

$AutoUse[OBCannon] = false;
$WeaponAmmo[OBCannon] = OBCannonAmmo;
$AmmoPackMax[OBCannonAmmo] = 70; 
$AmmoPackItems[15] = OBCannonAmmo; 
$SellAmmo[OBCannonAmmo] = 150; 


$OBCannonSlotA=4;
$OBCannonSlotB=7;
$OBCannonSlotC=6; 

ItemData OBCannonAmmo 
{
	description = "Ohm Shells"; 
	className = "Ammo"; 
	shapeFile = "discb"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 30; 
}; 

ItemImageData OBCannonImage 
{
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = OBCannonAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData OBCannon 
{
	description = "Omega Blast Cannon"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "energyRifle"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = OBCannonImage; 
	price = 550; 
	showWeaponBar = true; 
};

ItemImageData OBCannon2Image 
{
	ammoType = OBCannonAmmo; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, -1.7557, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = shockExplosion; 
};

ItemData OBCannon2 
{
	description = "OBCannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = OBCannon2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData OBCannon3Image 
{
	ammoType = OBCannonAmmo; 
	shapeFile = "MortarGun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 3.14159, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData OBCannon3 
{
	description = "OBCannon"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = OBCannon3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData OBCannon4Image 
{
	ammoType = OBCannonAmmo; 
	shapeFile = "mortarGun"; 
	mountPoint = 0; 
	mountOffset = {0, 0, 0.25 }; 
	mountRotation = { 0, -3.14159, 0}; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData OBCannon4 
{
	description = "OBCannon"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = OBCannon4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function OBCannonImage::onFire(%player,%slot)
{
	for(%i = 0; %i < 20; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("OhmBlast",%trans,%player,%vel);
	}
	Player::decItemCount(%player,$WeaponAmmo[OBCannon],1);
}

function OBCannon::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, OBCannon2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function OBCannon::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,OBCannon2,$OBCannonSlotA); 
	Player::mountItem(%player,OBCannon3,$OBCannonSlotB); 
	Player::mountItem(%player,OBCannon4,$OBCannonSlotC);
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc>Omega Blast Cannon: Rip them bitches a new asshole");
}

function OBCannon::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$OBCannonSlotA);
	Player::unmountItem(%player,$OBCannonSlotB);	 
	Player::unmountItem(%player,$OBCannonSlotC);
}

function CheckOBCannon(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "OBCannon")) 
	{	Player::trigger(%player,$OBCannonSlotA,true);
		Player::trigger(%player,$OBCannonSlotB,true);
		Player::trigger(%player,$OBCannonSlotC,true); 
		schedule("CheckOBCannon(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringOBCannon[%client] = true; 
	}
	else 
	{	Player::trigger(%player,$OBCannonSlotA,false); 
		Player::trigger(%player,$OBCannonSlotB,false); 
		Player::trigger(%player,$OBCannonSlotC,false); 
		$FiringOBCannon[%client] = false; 
	}
}


//-----Base Proj Data.cs 

BulletData OhmBlast
{
   bulletShapeName    = "paint.dts";
   validateShape      = false;
   explosionTag       = OhmExp;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $OhmDamageType;

   explosionRadius  = 5;
   aimDeflection      = 0.009;
   muzzleVelocity     = 800.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

   rotationPeriod = 0.1;
};
