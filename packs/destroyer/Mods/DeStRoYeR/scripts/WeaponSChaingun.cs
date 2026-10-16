//--------------------------------------

$AutoUse[SChaingun] = True;
$WeaponAmmo[SChaingun] = "";

//--------------------------------------

$InvList[SChaingun] = 0;
$RemoteInvList[SChaingun] = 0;

$ItemMax[narmor, SChaingun] = 0;
$ItemMax[aarmor, SChaingun] = 0;
$ItemMax[darmor, SChaingun] = 0;
$ItemMax[nfemale, SChaingun] = 0;
$ItemMax[afemale, SChaingun] = 0;
$ItemMax[warmor, SChaingun] = 0;
$ItemMax[barmor, SChaingun] = 0;
$ItemMax[sarmor, SChaingun] = 0;
$ItemMax[avarmor, SChaingun] = 0;
$ItemMax[wfemale, SChaingun] = 0;
$ItemMax[bfemale, SChaingun] = 0;

$DamageScale[narmor, $SBulletDamageType] = 1.5;
$DamageScale[aarmor, $SBulletDamageType] = 1.5;
$DamageScale[darmor, $SBulletDamageType] = 1.5;
$DamageScale[warmor, $SBulletDamageType] = 1.5;
$DamageScale[barmor, $SBulletDamageType] = 1.5;
$DamageScale[sarmor, $SBulletDamageType] = 0.0;
$DamageScale[avarmor, $SBulletDamageType] = 1.5;
$DamageScale[nfemale, $SBulletDamageType] = 1.5;
$DamageScale[afemale, $SBulletDamageType] = 1.5;
$DamageScale[wfemale, $SBulletDamageType] = 1.5;
$DamageScale[bfemale, $SBulletDamageType] = 1.5;
$DamageScale[Fighter, $SBulletDamageType] = 1.5;
$DamageScale[Interceptor, $SBulletDamageType] = 1.5;
$DamageScale[Scout, $SBulletDamageType] = 1.5;
$DamageScale[LAPC, $SBulletDamageType] = 1.5;
$DamageScale[HAPC, $SBulletDamageType] = 1.5;
//--------------------------------------

BulletData SChainBullet
{
   bulletShapeName    = "Tracer.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass 	      = 0.05;
   bulletHoleIndex    = 0;

   damageClass	      = 0;	 // 0 impact, 1, radius
   damageValue	      = 0.1;
   damageType	      = $SBulletDamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 450.0;
   totalTime	      = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible	      = false;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------

ItemImageData SChaingunImage
{
	shapeFile = "Chaingun";
	mountPoint = 0;
	mountRotation = { 0,3.14, 0 };

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.2;
	spinDownTime = 1;
	fireTime = 0;

	//projectileType = SChainBullet;
	minEnergy = 0;
	maxEnergy = 0;
	accuFire = True;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireSChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData SChaingun
{
	description = "Super Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = SChaingunImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function SChaingun::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Super Chaingun: <f2>Similar But stronger than your ordanary chaingun.");
}
function SChaingunImage::onFire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("SChainBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("SChainBullet",%trans,%player,%vel);
}