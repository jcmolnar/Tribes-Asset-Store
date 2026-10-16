//--------------------------------------

$AutoUse[PL] = True;
$SellAmmo[PLAmmo] = 5;
$AmmoPackMax[PLAmmo] = 30;
$AmmoPackItems[1] = PLAmmo;
$WeaponAmmo[PL] = PLAmmo;
//--------------------------------------

$InvList[PL] = 1;
$InvList[PLAmmo] = 1;
$RemoteInvList[PL] = 1;
$RemoteInvList[PLAmmo] = 1;

//--------------------------------------

LaserData PLaser
{
   laserBitmapName   = "repairadd.bmp";
   hitname           = "shockwave_large.dts";
   damageConversion  = 100;
   baseDamageType    = $LaserDamageType;
   beamTime          = 10.0;
   lightRange        = 10.0;
   lightColor        = { 1.0, 0, 0 };
   detachFromShooter = true;
   hitSoundId        = explosion4;
};

RocketData Plasma
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = PLexp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 5.0;
	damageType = $PlasLaserDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 0;
	muzzleVelocity = 500.0;
	terminalVelocity = 500.0;
	acceleration = 250.0;
	totalTime = 1.0;
	liveTime = 1.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0, 0 };
	inheritedVelocityScale = 0;
	soundId = SoundJetHeavy;
  	trailType   = 2;                // smoke trail
   	trailString = "fusionex.dts";
   	smokeDist   = 5.0;
};

RocketData Plasma2
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = PLexp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 2.0;
	damageType = $PlasLaserDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 0;
	muzzleVelocity = 500.0;
	terminalVelocity = 500.0;
	acceleration = 250.0;
	totalTime = 0.2;
	liveTime = 0.2;
	lightRange = 5.0;
	lightColor = { 1.0, 0, 0 };
	inheritedVelocityScale = 0;
	soundId = SoundJetHeavy;
  	trailType   = 2;                // smoke trail
   	trailString = "paint.dts";
   	smokeDist   = 5.0;
};

RocketData Plasma3
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = PLexp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 2.0;
	damageType = $PlasLaserDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 0;
	muzzleVelocity = 500.0;
	terminalVelocity = 500.0;
	acceleration = 250.0;
	totalTime = 0.3;
	liveTime = 0.3;
	lightRange = 5.0;
	lightColor = { 1.0, 0, 0 };
	inheritedVelocityScale = 0;
	soundId = SoundJetHeavy;
  	trailType   = 2;                // smoke trail
   	trailString = "shotgunex.dts";
   	smokeDist   = 6.0;
};

RocketData Plasma4
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = PLexp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 2.0;
	damageType = $PlasLaserDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 0;
	muzzleVelocity = 500.0;
	terminalVelocity = 500.0;
	acceleration = 250.0;
	totalTime = 0.4;
	liveTime = 0.4;
	lightRange = 5.0;
	lightColor = { 1.0, 0, 0 };
	inheritedVelocityScale = 0;
	soundId = SoundJetHeavy;
  	trailType   = 2;                // smoke trail
   	trailString = "tumult_small.dts";
   	smokeDist   = 7.0;
};

RocketData Plasma5
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = PLexp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 2;
	damageType = $PlasLaserDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 0;
	muzzleVelocity = 500.0;
	terminalVelocity = 500.0;
	acceleration = 250.0;
	totalTime = 0.6;
	liveTime = 0.6;
	lightRange = 5.0;
	lightColor = { 1.0, 0, 0 };
	inheritedVelocityScale = 0;
	soundId = SoundJetHeavy;
  	trailType   = 2;                // smoke trail
   	trailString = "shield_large.dts";
   	smokeDist   = 5.0;
};


//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, PL] = 0;
$ItemMax[lfemale, PL] = 0;
$ItemMax[marmor, PL] = 0;
$ItemMax[mfemale, PL] = 0;
$ItemMax[harmor, PL] = 1;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, PLAmmo] = 0;
$ItemMax[lfemale, PLAmmo] = 0;
$ItemMax[marmor, PLAmmo] = 0;
$ItemMax[mfemale, PLAmmo] = 0;
$ItemMax[harmor, PLAmmo] = 25;

//+++++++++++++++++++++++++++++++++++++++



ItemData PLAmmo 
{
	description = "Firey Beams";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 200;
};

ItemImageData PLImage 
{
	shapeFile = "mortargun";
        mountPoint = 0;
        mountRotation = { 0, -1.570795, 0 };
	weaponType = 0;
	ammoType = PLAmmo;
	accuFire = true;
	reloadTime = 0.05;
	minEnergy = 50;
	maxEnergy = 50;
	fireTime = 4.0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0, 1.0, 0 };
	sfxFire = SoundPlasmaTurretOff;
	sfxActivate = SoundTurretDeploy;
};

ItemData PL
{
	description = "P.L.C.";
	className = "Weapon";
	shapeFile = "Mortar";
	hudIcon = "blaster";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = PLImage;
   validateShape = false;
   validateMaterials = false;
	price = 5750;
	showWeaponBar = true;
};

function PL::onMount(%player,%item)
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	%clientId = Player::getclient(%player);
	bottomprint(%clientid, "<jc><f2>P.L.C.: <f1>X<f3>t<f2>R<f3>e<f2>A<f3>m<f2>L<f3>y<f2> unstable laser beam that explodes into flames");
}

function PLImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	Player::decItemCount(%player,$WeaponAmmo[PL],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("Plaser",%trans,%player,%vel);
	Projectile::spawnProjectile("Plasma",%trans,%player,%vel);
	Projectile::spawnProjectile("Plasma2",%trans,%player,%vel);
	Projectile::spawnProjectile("Plasma3",%trans,%player,%vel);
	Projectile::spawnProjectile("Plasma4",%trans,%player,%vel);
	Projectile::spawnProjectile("Plasma5",%trans,%player,%vel);
}
//--------------------------------------
