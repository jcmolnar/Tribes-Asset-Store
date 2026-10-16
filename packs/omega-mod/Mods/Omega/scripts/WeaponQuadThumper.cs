//----Armordata.cs----///
$ItemMax[larmor, QThumper] = 1;
$ItemMax[lfemale, QThumper] = 1;
$ItemMax[marmor, QThumper] = 1;
$ItemMax[mfemale, QThumper] = 1;
$ItemMax[harmor, QThumper] = 0;
$ItemMax[larmor, QThumperAmmo] = 30;
$ItemMax[lfemale, QThumperAmmo] = 30;
$ItemMax[marmor, QThumperAmmo] = 60;
$ItemMax[mfemale, QThumperAmmo] = 60;
$ItemMax[harmor, QThumperAmmo] = 0;
//----BaseProjData.cs
//--------------------------------------
GrenadeData ThumperShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = ThumperExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $MortarDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 600;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "chainspk.dts";
};

//--------------------------------------

$InvList[QThumper]=1;
$RemoteInvList[QThumper]=1;

$InvList[QThumperAmmo]=1;
$RemoteInvList[QThumperAmmo]=1;

$AutoUse[QThumper] = false;
$WeaponAmmo[QThumper] = QThumperAmmo;
$AmmoPackMax[QThumperAmmo] = 70; 
$AmmoPackItems[15] = QThumperAmmo; 
$SellAmmo[QThumperAmmo] = 150; 

$QThumperSlotA=4;
$QThumperSlotB=7;
$QThumperSlotC=6; 

ItemData QThumperAmmo 
{
	description = "Thumper Shells"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 30; 
}; 

ItemImageData QThumperImage 
{
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 1.5775, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = QThumperAmmo; 
	accuFire = true; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData QThumper 
{
	description = "Quad Thumper Cannon"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "ammopack"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = QThumperImage; 
	price = 890; 
	showWeaponBar = true; 
};

ItemImageData QThumper2Image 
{
	ammoType = QThumperAmmo; 
	projectileType = ThumperShell; 
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, -1.5775, 0}; 
	weaponType = 0; 
	reloadTime = 1.5;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = shockExplosion; 
};

ItemData QThumper2 
{
	description = "QThumper"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = QThumper2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData QThumper3Image 
{
	ammoType = QThumperAmmo; 
	projectileType = ThumperShell; 
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.15};
	mountRotation = { 0, 3.14159, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData QThumper3 
{
	description = "QThumper"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = QThumper3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData QThumper4Image 
{
	ammoType = QThumperAmmo; 
	projectileType = ThumperShell; 
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, -0.15};
	mountRotation = { 0, -3.14159, 0}; 
	weaponType = 0; 
	reloadTime = 0.5; 
	fireTime = 0.1;
	accuFire = true; 
	sfxFire = 0; 
};

ItemData QThumper4 
{
	description = "QThumper"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = QThumper4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function QThumperImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,QThumperAmmo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("ThumperShell",%trans,%player,%vel,%player); 
	if(!$FiringQThumper[%client]) 
		CheckQThumper(%client, %player); 
}

function QThumper::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, QThumper2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function QThumper::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,QThumper2,$QThumperSlotA); 
	Player::mountItem(%player,QThumper3,$QThumperSlotB); 
	Player::mountItem(%player,QThumper4,$QThumperSlotC);
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc><f2>Quad Thumper Cannon: <f3>Designed for lights and mediums, this gun fires a shell that will do medium damage and has a medium radius. Fires a 3 bomb cluster on the first shot, hold fire button down and will fire continuosly at a 1 shell pace");
}

function QThumper::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$QThumperSlotA);
	Player::unmountItem(%player,$QThumperSlotB);	 
	Player::unmountItem(%player,$QThumperSlotC);
}

function CheckQThumper(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "QThumper")) 
	{	Player::trigger(%player,$QThumperSlotA,true);
		Player::trigger(%player,$QThumperSlotB,true);
		Player::trigger(%player,$QThumperSlotC,true); 
		schedule("CheckQThumper(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringQThumper[%client] = true; 
	}
	else 
	{	Player::trigger(%player,$QThumperSlotA,false); 
		Player::trigger(%player,$QThumperSlotB,false); 
		Player::trigger(%player,$QThumperSlotC,false); 
		$FiringQThumper[%client] = false; 
	}
}
