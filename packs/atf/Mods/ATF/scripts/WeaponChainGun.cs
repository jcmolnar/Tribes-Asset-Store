//--------------------------------------

$AutoUse[Chaingun] = True;
$SellAmmo[BulletAmmo] = 25;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;

//--------------------------------------

$InvList[Chaingun] = 1;
$InvList[BulletAmmo] = 1;
$RemoteInvList[Chaingun] = 1;
$RemoteInvList[BulletAmmo] = 1;

//--------------------------------------

BulletData ChaingunBullet
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.53;
   damageType       = $MissileDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 90.0; //90
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.02;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Plasma.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.2;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Auto-Rocket ChainGun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "bRocket Launchers";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function Chaingun::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The Chaingun was converted into a Auto-Rocket Launcher. Both accuracy and distance are low on this gun but peeps will think twice during a flag cap if they see 20 Auto-Rockets flying at them.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

//$AutoUse[Chainguni] = True;
//$SellAmmo[BulletAmmo] = 25;
//$AmmoPackMax[BulletAmmo] = 150;
//$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[Chainguni] = "";

//--------------------------------------

//--------------------------------------

BulletData ChaingunBulleti
{
   bulletShapeName = "Endarrow.dts";
   explosionTag    = GrenadeExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.53;
   damageType       = $MissileDamageType;
   explosionRadius  = 10.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 90.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.02;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundPlayerDeath;
};

//--------------------------------------



ItemImageData ChaingunImagei
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.1;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.0;

	//ammoType = BulletAmmo;
	projectileType = ChaingunBulleti;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundFireChaingun;
	sfxSpinUp = SounddryFire;
	sfxSpinDown = SounddryFire;
};

ItemData Chainguni
{
	description = "C.U.G.O.M.S. Gun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = ChaingunImagei;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function Chainguni::onUse(%player,%item)
{
	MessageAll(0, "!!!!");Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

$AutoUse[XLChaingun] = True;
$SellAmmo[BulletAmmo] = 25;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[XLChaingun] = BulletAmmo;

//--------------------------------------

$InvList[XLChaingun] = 1;

$RemoteInvList[XLChaingun] = 1;


//--------------------------------------

BulletData ChaingunBulletbu
{
   bulletShapeName = "Chainspk.dts";
   explosionTag    = BulletExp1;
   expRandCycle       = 1;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 1;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.10;
   damageType       = $BulletDamageType;

   muzzleVelocity    = 600.0;
   terminalVelocity = 710.0;
   acceleration     = 710.0;
   aimDeflection      = 0.002;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   soundId = SoundDryFire;
};

//--------------------------------------

ItemImageData ChaingunImagebu
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.5;
	spinDownTime = 3;
	fireTime = 0;

	ammoType = BulletAmmo;
	projectileType = ChaingunBulletbu;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData XLChaingun
{
	description = "XLChaingun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "bRocket Launchers";
	shadowDetailMask = 4;
	imageType = ChaingunImagebu;
	price = 425;
	showWeaponBar = true;
};

//--------------------------------------
function XLChaingun::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "<jc>The XLChaingun, a fast shooting spray of bullets is what your enemy sees....placed in rocket launchers for implication purposes", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

