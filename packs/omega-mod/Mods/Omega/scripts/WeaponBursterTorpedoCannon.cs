//--------------------------------------

$AutoUse[BurTC] = True;
$SellAmmo[BurTCAmmo] = 5;
$AmmoPackMax[BurTCAmmo] = 30;
$AmmoPackItems[1] = BurTCAmmo;
$WeaponAmmo[BurTC] = BurTCAmmo;
//--------------------------------------

$InvList[BurTC] = 1;
$InvList[BurTCAmmo] = 1;
$RemoteInvList[BurTC] = 1;
$RemoteInvList[BurTCAmmo] = 1;

//--------------------------------------

RocketData Burster
{
   bulletShapeName  = "shockwave_large.dts";
   explosionTag     = BursterExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.8; //KABOOM
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 30;
   kickBackStrength = 200.5;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   rotationPeriod = 0.1;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 3.9;

   soundId = SoundJetHeavy;
};

RocketData Burster2
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0; //looks
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 0;
   kickBackStrength = 0.5;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   rotationPeriod = 0.1;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "MORTARTRAIL.dts";
   smokeDist   = 3.9;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, BurTC] = 0;
$ItemMax[lfemale, BurTC] = 0;
$ItemMax[marmor, BurTC] = 0;
$ItemMax[mfemale, BurTC] = 0;
$ItemMax[harmor, BurTC] = 1;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, BurTCAmmo] = 0;
$ItemMax[lfemale, BurTCAmmo] = 0;
$ItemMax[marmor, BurTCAmmo] = 0;
$ItemMax[mfemale, BurTCAmmo] = 0;
$ItemMax[harmor, BurTCAmmo] = 25;

//+++++++++++++++++++++++++++++++++++++++



ItemData BurTCAmmo 
{
	description = "Neptunium Cases";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 6000;
};

ItemImageData BurTCImage 
{
	shapeFile = "ammo2";
	mountPoint = 0;
	mountOffset = { 0, -0.25, 0.4};
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	ammoType = BurTCAmmo;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = ForceFieldOpen;
	sfxActivate = SoundEnergyTurretOn;
};

ItemData BurTC
{
	description = "Burster Torpedo Cannon";
	className = "Weapon";
	shapeFile = "ammo2";
	hudIcon = "sniper";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = BurTCImage;
   	validateShape = false;
   	validateMaterials = false;
	price = 2500;
	showWeaponBar = true;
};

function BurTC::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "This cannon launches a torpedo containing neptunium, because of that...use at a very safe distance. Its the very big brother of the Hawk Torpedo Cannon.");
}

function BurTCImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,BurTCammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("Burster",%trans,%player,%vel,%player);
	Projectile::spawnProjectile("Burster2",%trans,%player,%vel,%player);
		
}
		
//--------------------------------------