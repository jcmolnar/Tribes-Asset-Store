$DamageScale[larmor, $FissionDamageType] = 10;
$DamageScale[lfemale, $FissionDamageType] = 10;
$DamageScale[marmor, $FissionDamageType] = 10;
$DamageScale[mfemale, $FissionDamageType] = 10;
$DamageScale[harmor, $FissionDamageType] = 100;
$DamageScale[indalacioarmor, $FissionDamageType] = 1;

$InvList[FissionSniper]=1;
$RemoteInvList[FissionSniper]=1;

$InvList[FissionSniperAmmo]=1;
$RemoteInvList[FissionSniperAmmo]=1;

$AutoUse[FissionSniper] = false;
$WeaponAmmo[FissionSniper] = FissionSniperAmmo;
$AmmoPackMax[FissionSniperAmmo] = 250; 
$AmmoPackItems[15] = FissionSniperAmmo;     
$SellAmmo[FissionSniperAmmo] = 150; 

$ItemMax[larmor, FissionSniper] = 1;
$ItemMax[lfemale, FissionSniper] = 1;
$ItemMax[marmor, FissionSniper] = 0;
$ItemMax[mfemale, FissionSniper] = 0;
$ItemMax[harmor, FissionSniper] = 0;
$ItemMax[indalacioarmor, FissionSniper] = 0;

$ItemMax[larmor, FissionSniperAmmo] = 100;
$ItemMax[lfemale, FissionSniperAmmo] = 100;
$ItemMax[marmor, FissionSniperAmmo] = 0;
$ItemMax[mfemale, FissionSniperAmmo] = 0;
$ItemMax[harmor, FissionSniperAmmo] = 0;
$ItemMax[indalacioarmor, FissionSniperAmmo] = 0;




$FissionSniperSlotA=4;
$FissionSniperSlotB=7;

ItemData FissionSniperAmmo 
{
	description = "Fission Batterys"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 300; 
}; 

ItemImageData FissionSniperImage 
{
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, -1.570795, 0 }; 
	weaponType = 0; 
	reloadTime = 0.5; 
	fireTime = 0.5;
	minEnergy = 10;	
	maxEnergy = 10;
	ammoType = FissionSniperAmmo;
	accuFire = true; 
	sfxFire = SoundFireGammaChain; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundEnergyPackOn;
}; 

ItemData FissionSniper
{
	description = "E.F.G.S.R."; 
	className = "Weapon"; 
	shapeFile = "plasma"; 
	hudIcon = "ammopack"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = FissionSniperImage; 
	price = 9200; 
	showWeaponBar = true; 
};

ItemImageData FissionSniper2Image 
{
	ammoType = FissionSniperAmmo; 
	projectileType = GammaPacket; 
	shapeFile = "plasma"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 0.1;
                fireTime = 0.1;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData FissionSniper2 
{
	description = "FissionSniper"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = FissionSniper2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function FissionSniperImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[FissionSniper],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,2000)) //rocket locking range 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("FissionBolt",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("FissionBoltSubmission",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("FissionBoltalt",%trans,%player,%vel);
	} else 
                        Projectile::spawnProjectile("FissionBoltalt",%trans,%player,%vel);  
} 



function FissionSniper::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, FissionSniper2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function FissionSniper::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,FissionSniper2,$FissionSniperSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc><f2>Electro Fission Guided Sniper Rifle: Fireing a high speed bolt that can lock on at enemies");
}

function FissionSniper::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$FissionSniperSlotA);
}

//---the xtra shot data for the Fission Bolt

//--------------------------------------
SeekingMissileData FissionBoltSubmission
{ 
   bulletShapeName = "enbolt.dts";
   explosionTag = EnergyExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 30.0;
   damageType = $FissionDamageType;
   explosionRadius = 5;
   kickBackStrength = 0.0;
   
   muzzleVelocity = 250.0;
   
   terminalVelocity = 60.0;
   acceleration = 3;
   
   totalTime = 30.0;
   liveTime = 31.0;
   seekingTurningRadius = 0.1;
   nonSeekingTurningRadius = 0.1; 
   proximityDist = 1.5;
 
   
   inheritedVelocityScale = 0.76;
   
};

//--------------------------------------
RocketData FissionBoltalt
{
   bulletShapeName  = "enbolt.dts";
   explosionTag     = EnergyExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $FissionDamageType;

   explosionRadius  = 0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 500.0;
   terminalVelocity = 500.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   inheritedVelocityScale = 0.5;


};

//++++++++++++++++++++++++++++++++++++++

//--------------------------------------
RocketData FissionBolt
{
   bulletShapeName  = "enbolt.dts";
   explosionTag     = EnergyExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 2.8;
   damageType       = $FissionDamageType;

   explosionRadius  = 0.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 500.0;
   terminalVelocity = 500.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   inheritedVelocityScale = 0.5;


};

