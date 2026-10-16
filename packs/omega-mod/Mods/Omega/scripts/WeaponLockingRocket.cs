
$InvList[QRLC]=1;
$RemoteInvList[QRLC]=1;

$InvList[QRLCAmmo]=1;
$RemoteInvList[QRLCAmmo]=1;

$AutoUse[QRLC] = false;
$WeaponAmmo[QRLC] = QRLCAmmo;
$AmmoPackMax[QRLCAmmo] = 250; 
$AmmoPackItems[15] = QRLCAmmo;     
$SellAmmo[QRLCAmmo] = 150; 

$ItemMax[larmor, QRLC] = 1;
$ItemMax[lfemale, QRLC] = 1;
$ItemMax[marmor, QRLC] = 1;
$ItemMax[mfemale, QRLC] = 1;
$ItemMax[harmor, QRLC] = 0;
$ItemMax[indalacioarmor, QRLC] = 0;

$ItemMax[larmor, QRLCAmmo] = 10;
$ItemMax[lfemale, QRLCAmmo] = 10;
$ItemMax[marmor, QRLCAmmo] = 20;
$ItemMax[mfemale, QRLCAmmo] = 20;
$ItemMax[harmor, QRLCAmmo] = 0;
$ItemMax[indalacioarmor, QRLCAmmo] = 0;




$QRLCSlotA=4;
$QRLCSlotB=7;

ItemData QRLCAmmo 
{
	description = "120mm Rockets"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 300; 
}; 

ItemImageData QRLCImage 
{
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, -1.570795, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 1.0;
	minEnergy = 10;	
	maxEnergy = 10;
	ammoType = QRLCAmmo;
	accuFire = true; 
	sfxFire = SoundFlyerDismount; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData QRLC
{
	description = "Guided Rocket Launcher"; 
	className = "Weapon"; 
	shapeFile = "plasma"; 
	hudIcon = "ammopack"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = QRLCImage; 
	price = 9200; 
	showWeaponBar = true; 
};

ItemImageData QRLC2Image 
{
	ammoType = QRLCAmmo; 
	projectileType = GammaPacket; 
	shapeFile = "mortar"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.2 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 0.1;
                fireTime = 0.1;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData QRLC2 
{
	description = "QRLC"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = QRLC2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function QRLCImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[QRLC],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,2000)) //rocket locking range 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
			Projectile::spawnProjectile("LockedRocketSubmission",%trans,%player,%vel,$los::object);
Client::sendMessage(%client,1,"-_-_---_+[120mm Rocket Lock]+_-_--_--_ ~wWeapon5.wav");
				Client::sendMessage(%targeted,1,"<+><+><+>[120mm Rocket Lock Detected]<+><+><+>~wWeapon5.wav");
		} else 
		        Projectile::spawnProjectile("NLockedRocketAlt",%trans,%player,%vel);
	} else 
                        Projectile::spawnProjectile("NlockedRocket",%trans,%player,%vel);  
} 



function QRLC::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, QRLC2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function QRLC::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,QRLC2,$QRLCSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc><f2>Rocket Launcher: Fires a high damag shell that travels at slow speeds and can lock onto enemies. Specialty for medium and light armors only. ");
}

function QRLC::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$QRLCSlotA);
}

//------------------------------------
SeekingMissileData LockedRocketSubmission
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 5.0;
   damageType = $MissileDamageType;
   explosionRadius = 10;
   kickBackStrength = 0.0;
   
   muzzleVelocity = 40.0;
   
   terminalVelocity = 60.0;
   acceleration = 3;
   
   totalTime = 300.0;
   liveTime = 310.0;
   seekingTurningRadius = 0.0000000000000000000000001;
   nonSeekingTurningRadius = 0.000000000000000000000000001; 
   proximityDist = 0;
 
   
   inheritedVelocityScale = 0.76;
   
};

//--------------------------------------
RocketData NLockedRocketalt
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 40.0;
   terminalVelocity = 40.0;
   acceleration     = 5.0;
   totalTime        = 100.0;
   liveTime         = 110.0;
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "dustplume.dts";
   smokeDist   = 10.0;



};

//++++++++++++++++++++++++++++++++++++++

//--------------------------------------
RocketData NlockedRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.8;
   damageType       = $MissileDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 40.0;
   terminalVelocity = 40.0;
   acceleration     = 5.0;
   totalTime        = 100.0;
   liveTime         = 110.0;
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "dustplume.dts";
   smokeDist   = 10.0;


};

