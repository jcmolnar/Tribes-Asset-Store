$InvList[GammaChain]=1;
$RemoteInvList[GammaChain]=1;

$InvList[GammaChainAmmo]=1;
$RemoteInvList[GammaChainAmmo]=1;

$AutoUse[GammaChain] = false;
$WeaponAmmo[GammaChain] = GammaChainAmmo;
$AmmoPackMax[GammaChainAmmo] = 250; 
$AmmoPackItems[15] = GammaChainAmmo;     
$SellAmmo[GammaChainAmmo] = 150; 


$GammaChainSlotA=4;
$GammaChainSlotB=7;

ItemData GammaChainAmmo 
{
	description = "Gamma Ray Packets"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 300; 
}; 

ItemImageData GammaChainImage 
{
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 1.570795, 0 }; 
	weaponType = 0; 
	reloadTime = 0.1; 
	fireTime = 0.1;
	minEnergy = 10;	
	maxEnergy = 10;
	ammoType = GammaChainAmmo ;
	projectileType = GammaPacket;  
	accuFire = true; 
	sfxFire = SoundFireGammaChain; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData GammaChain
{
	description = "G.R.P. Cannon"; 
	className = "Weapon"; 
	shapeFile = "plasma"; 
	hudIcon = "energyRifle"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = GammaChainImage; 
	price = 3600; 
	showWeaponBar = true; 
};

ItemImageData GammaChain2Image 
{
	ammoType = GammaChainAmmo; 
	projectileType = GammaPacket; 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.2 }; 
	mountRotation = { 0, -1.57, 0}; 
	weaponType = 0; 
	reloadTime = 0.1;
                fireTime = 0.1;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData GammaChain2 
{
	description = "GammaChain"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = GammaChain2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function GammaChainImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[GammaChain],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,2000)) //rocket locking range 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("GammaPacketRocketSubmission",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("GammaPacketRocketalt",%trans,%player,%vel);
	} else 
                        Projectile::spawnProjectile("GammaPacketRocketalt",%trans,%player,%vel);  
} 



function GammaChain::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, GammaChain2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function GammaChain::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,GammaChain2,$GammaChainSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc><f2>The Gamma Ray Packet Cannon:<f1> Fires a packet of gamma rays to explode upon your enemy, will burn the enemy as well, And can acquire a guided lock. This gun is god for indoors and medium range combat");
}

function GammaChain::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$GammaChainSlotA);
}

//---the xtra shot data for the Gamma Rocket!

//--------------------------------------
SeekingMissileData GammaPacketRocketSubmission
{ 
   bulletShapeName = "shield.dts";
   explosionTag = GammaExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.3;
   damageType = $GammaDamageType;
   explosionRadius = 7.0;
   kickBackStrength = 0.0;
   
   muzzleVelocity = 40.0;
   
   terminalVelocity = 60.0;
   acceleration = 3;
   
   totalTime = 30.0;
   liveTime = 31.0;
   seekingTurningRadius = 0.1;
   nonSeekingTurningRadius = 0.1; 
   proximityDist = 0;
 
   
   inheritedVelocityScale = 0.76;
   
};

//--------------------------------------
RocketData GammaPacketRocketalt
{
   bulletShapeName  = "shield.dts";
   explosionTag     = GammaExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $GammaDamageType;

   explosionRadius  = 7.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 50.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   inheritedVelocityScale = 0.5;


};

//++++++++++++++++++++++++++++++++++++++

//--------------------------------------
RocketData GammaPacket
{
   bulletShapeName  = "shield.dts";
   explosionTag     = GammaExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $GammaDamageType;

   explosionRadius  = 7.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 50.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   inheritedVelocityScale = 0.5;


};

