//--------------------------------------

$AutoUse[GrenadeLauncher] = True;
$SellAmmo[GrenadeAmmo] = 50;
$AmmoPackMax[GrenadeAmmo] = 300;
$AmmoPackItems[3] = GrenadeAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

//--------------------------------------

$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

//--------------------------------------
RocketData Flame
{
   bulletShapeName = "tumult_small.dts"; //tumult_large.dts
   explosionTag    = PlasmaExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 0;

   muzzleVelocity   = 38.0;
   terminalVelocity = 38.0;
   acceleration     = 0.1;
   aimDeflection      = 0.004;

   totalTime        = 1.0;
   liveTime         = 0.1;

   lightRange       = 5.0;
	lightColor = { 1.0, 0, 0 };


   inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "tumult_small.dts";
	smokeDist = 84.9;
	soundId = SoundJetLight;


};

//--------------------------------------

ItemData GrenadeAmmo
{
	description = "Flame Thrower Pack";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
//	projectileType = Flame;
	accuFire = false;
	reloadTime = 0;
	fireTime = 0.20;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = FlameThrowerFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData GrenadeLauncher
{
	description = "FlameThrower";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

ItemImageData GrenadeLauncher2Image 
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	accuFire = true;
};

ItemData GrenadeLauncher2
{
	description = "FlameThrower";
	shapeFile = "grenadeL";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncher2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};


function GrenadeLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,GrenadeLauncher2,4);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>FlameThrower");
}

function GrenadeLauncher::onUnmount(%player,%item)
{
	Player::unmountItem(%player,4);
}

function GrenadeLauncherImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("Flame",%trans,%player,%vel);
}