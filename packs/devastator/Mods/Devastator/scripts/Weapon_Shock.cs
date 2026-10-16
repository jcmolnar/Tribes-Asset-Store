//----------------------------------------------

LaserData Laser1
{
   laserBitmapName   = "laserpulse.bmp";
   hitname           = "laserhit.dts";
   damageConversion  = 0.0;
   baseDamageType    = $ShockDamageType;
   beamTime          = 2.0;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = true;
   hitSoundId        = SoundELF;
};

//--------------------------------------
RocketData BlasRocket
{
   bulletShapeName  = "breath.dts";
   explosionTag     = MortarExp;
   collisionRadius  = 0.0;
   mass             = 9.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $ShockDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 125.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   totalTime        = 7.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                
   trailString = "shotgunex.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ShieldRocket
{
   bulletShapeName  = "breath.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 9.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $ShockDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 125.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   totalTime        = 7.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                
   trailString = "shield.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//----------------------------------------------------------------------------

ItemImageData ShockImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; 
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 1.2;
	minEnergy = 3.0;
	maxEnergy = 5.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };	

	sfxFire     = SoundThrowItem;
	sfxActivate = SoundJetHeavy;
	sfxSpinUp = SoundSpinUpDisc;
	sfxReady    = SoundLaserIdle;
};

ItemData Shock
{
	description = "Shockwave Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "backpack";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ShockImage;
	price = 175;
	showWeaponBar = true;
   	validateShape = true;
};

function ShockImage::onFire(%player, %slot)
{
	%oldenergy = Gamebase::getEnergy(%player);
	%oldenergy -= 30;
	Gamebase::setEnergy(%player, %oldenergy);
	Weapon::onFire(%player,Laser1);
	Weapon::onFire(%player,BlasRocket);
	Weapon::onFire(%player,ShieldRocket);
}

//--------------------------------------------------------
	$InvList[Shock] = 1;
	$RemoteInvList[Shock] = 1;

	$ItemMax[larmor, Shock] = 0;
	$ItemMax[marmor, Shock] = 0;
	$ItemMax[harmor, Shock] = 0;
	$ItemMax[qarmor, Shock] = 0;
	$ItemMax[tarmor, Shock] = 0;
	$ItemMax[sarmor, Shock] = 0;
	$ItemMax[srarmor, Shock] = 1;
	$ItemMax[parmor, Shock] = 0;
	$ItemMax[lfemale, Shock] = 0;
	$ItemMax[mfemale, Shock] = 0;
	$ItemMax[qfemale, Shock] = 0;
	$ItemMax[sfemale, Shock] = 0;
	$ItemMax[srfemale, Shock] = 1;
	$ItemMax[pfemale, Shock] = 0;
