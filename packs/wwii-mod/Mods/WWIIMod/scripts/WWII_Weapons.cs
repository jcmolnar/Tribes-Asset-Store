$ammo[yppsh] = yppshammo;
$ammo[ysniperrifle] = ysniperammo;
$ammo[xSTG] = xSTGammo;
$ammo[xar] = xarammo;
$ammo[xPanzergun] = xpanzerammo;
$ammo[ysubmgun] = ysubmgunammo;
$ammo[xrifle] = xrifleammo;
$ammo[ybazooka] = ybazookaammo;
$ammo[ybren] = ybrenammo;
$ammo[xMP40] = xmp40ammo;
$ammo[ybar] = ybarammo;
$ammo[ythompson] = ythompsonammo;
$ammo[ycarbine] = ycarbineammo;
$ammo[ymosinnagant] = ymosinnagantammo;
$ammo[ysten] = ystenammo;
$ammo[ygarand] = ygarandammo;
$ammo[xpistol] = xpistolammo;
$ammo[ypistol] = ypistolammo;
$ammo[binoculars] = "";
$ammo[xgrifle] = nadeammo;
$ammo[yDP] = yDPammo;
$ammo[yM3] = yM3ammo;
$ammo[ylanchester] = ylanchesterammo;
$ammo[yPTRD] = yPTRDammo;
$ammo[yPIAT] = yPIATammo;
$ammo[xrifleJ] = xrifleJammo;
$ammo[xType100] = xtype100ammo;
$ammo[xtype96] = xtype96ammo;
$ammo[xrocket] = xRocketammo;
$ammo[xType97] = xType97ammo;
$ammo[xrifleJE] = xrifleJEammo;
$ammo[xnambu] = xnambuammo;
$ammo[xShotgun] = xShotgunammo;

//------------------------------------------
//-------------------PPSH41
//------------------------------------------

BulletData yppshBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.39;
   damageType         = $ppsh;

    aimDeflection      = 0.012;
   muzzleVelocity     = 600.9;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData yppshAmmo
{
	description = "PPSH41 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData yPPSHImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // 
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 0.1;
	fireTime = 0.07;

	ammoType = yppshammo;
	projectileType = yppshBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData yppsh
{
	description = "PPSH41";
	className = "Weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yppshImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData yppsh2Image 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, -1.55, 0 };
	weaponType = 0;
	mountOffset = { 0.024, 0, 0.07 };
	accuFire = true;
};

ItemData yppsh2
{
	description = "Railgun";
	shapeFile = "shotgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yppsh2Image;
	showWeaponBar = false;
	showInventory = false;
	price = 0;
};

ItemImageData yppsh3Image 
{
	shapeFile = "discammo";
	mountPoint = 0;
	mountRotation = { 1.5707, 0.15, 0 };
	weaponType = 0;
	mountOffset = { 0, 0, -0.085 };
	accuFire = true;
};

ItemData yppsh3
{
	description = "Railgun";
	shapeFile = "discammo";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yppsh3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};


function yppsh::onMount(%player,%item) 
{	
	
	Player::mountItem(%player,yppsh2,5); 
	Player::mountItem(%player,yppsh3,6); 
	
}

function yppsh::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
}

//------------------------------------------
//-------------------SpringField Sniper
//------------------------------------------




$AutoUse[ySniperrifle] = true;
$WeaponAmmo[ySniperrifle] = ysniperammo;


RocketData ySniperBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = mediumbullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.64;
	damageType = $springfield;		
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3500.0;
	terminalVelocity = 3500.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};


ItemData ysniperAmmo
{
	description = "Sniper Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ySniperrifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	ammoType = ysniperAmmo;
	projectileType = ysniperbullet;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.5;
	spinUpTime = 0.25;

	sfxFire = debrisSmallExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ysniperrifle
{
	description = "Springfield M1903";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysniperrifleImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ysniperrifle2Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.1, 0.22 };
	mountRotation = { -1.55, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ysniperrifle2
{
	description = "Railgun";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysniperrifle2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ysniperrifle3Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.1, 0.22 };
	mountRotation = { 3.1, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ysniperrifle3
{
	description = "Railgun";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysniperrifle3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ysniperrifle4Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.1, 0.22 };
	mountRotation = { 1.55, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ysniperrifle4
{
	description = "Railgun";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysniperrifle4Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};


function ysniperrifle::onMount(%player,%item) 
{	
	Player::mountItem(%player,ysniperrifle2,5); 
	Player::mountItem(%player,ysniperrifle3,6); 
	Player::mountItem(%player,ysniperrifle4,7); 
	
}



function ysniperrifle::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
}

//------------------------------------------
//-------------------STG44
//------------------------------------------


$AutoUse[xSTG] = true;
$WeaponAmmo[xSTG] = xSTGammo;


BulletData xSTGBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $STG;

   aimDeflection      = 0.00465;
   muzzleVelocity     = 625.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = false;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData xSTGAmmo
{
	description = "STG44 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xSTGImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; 
	reloadTime = 0;
	fireTime = 0.14;
	//mountOffset = { 0, -0.25, 0 };
	ammoType = xSTGAmmo;
	projectileType = xSTGBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xSTG
{
	description = "STG44 Assault Rifle";
	className = "Weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xSTGImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xSTG2Image 
{
	shapeFile = "plasma";
	mountPoint = 0;	
	mountOffset = { 0, -0.1, -0.05 };
	//mountRotation = { 0, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xSTG2
{
	description = "Railgun";
	shapeFile = "plasma";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xSTG2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xSTG3Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.58, 0.25 };
	mountRotation = { 3.1, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xSTG3
{
	description = "Railgun";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xSTG3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};




function xSTG::onMount(%player,%item) 
{	
	
	Player::mountItem(%player,xSTG2,5);
	Player::mountItem(%player,xSTG3,6); 
	
	
	
}

function xSTG::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	
}

//------------------------------------------
//-------------------Fallschirmj Ager Gewehr 42
//------------------------------------------


$AutoUse[xar] = true;
$WeaponAmmo[xar] = xarammo;


BulletData xarBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.43;
   damageType         = $Fallschirmj;

   aimDeflection      = 0.005;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData xarAmmo
{
	description = "Fallschirmj Ager Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xarImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountOffset = { -0.03, -0.12, 0.075 };
	mountRotation = { 0, 1.55, 0 };
	
	weaponType = 0; 
	reloadTime = 0;
	fireTime = 0.19;
	
	ammoType = xarAmmo;
	projectileType = xarBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundMortarTurretFire;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xar
{
	description = "Fallschirmj Ager Gewehr 42";
	className = "Weapon";
	shapeFile = "shotgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xarImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xar2Image 
{
	shapeFile = "sniper";
	mountPoint = 0;	
	weaponType = 0;
	mountOffset = { 0, -0.25, 0 };
	accuFire = true;
};

ItemData xar2
{
	description = "Railgun";
	shapeFile = "sniper";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xar2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xar3Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.5, 0.25 };
	mountRotation = { 3.1, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xar3
{
	description = "Railgun";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xar3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};



function xar::onMount(%player,%item) 
{	
	Player::mountItem(%player,xar2,5); 
	Player::mountItem(%player,xar3,6); 
	
	
}

function xar::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	
}

//------------------------------------------
//-------------------Panzershreck
//------------------------------------------

$AutoUse[xpanzergun] = true;
$WeaponAmmo[xpanzergun] = xpanzerammo;



ItemData xpanzerAmmo
{
	description = "Panzershreck Grenades";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xPanzergunImage
{
	shapeFile = "Mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = xpanzerAmmo;
	//projectileType = xpanzershell;
	accuFire = true;
	//reloadTime = 1.5;
	fireTime = 0.4;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	mountOffset = { 0, -0.3, 0.4 };
	mountRotation = { 0, 1.45, 0 };
	
	

	sfxFire = shockexplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xpanzergun
{
	description = "Panzerschreck";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xpanzergunImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xpanzer2Image 
{
	shapeFile = "mortargun";
	mountPoint = 0;	
	mountOffset = { 0, -0.85, 0.4 };
	mountRotation = { 0, 1.45, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xpanzer2
{
	description = "Railgun";
	shapeFile = "Mortargun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xpanzer2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};


function xpanzergun::onMount(%player,%item) 
{	
	
	Player::mountItem(%player,xpanzer2,5); 
	 
	
}

function xPanzergun::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);

}
function xpanzergunimage::onFire(%player)
{
player::decitemcount(%player, xpanzerammo);
%trans = gamebase::getmuzzletransform(%player);
%vel = item::getvelocity(%player);
%id = projectile::spawnprojectile("xPanzerShell", %trans, %player, %vel);
%id.player = %player;
%id.explosive = 1;
schedule("WWII::RocketSeq(" @ %id @ ", " @ %player @ ");", 0.1);

}
//------------------------------------------
//-------------------MP18
//------------------------------------------

$AutoUse[ysubmgun] = true;
$WeaponAmmo[ySubmgun] = ysubmgunammo;


BulletData ysubmgunBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $MP18;

   aimDeflection      = 0.0055;
   muzzleVelocity     = 825.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData ysubmgunAmmo
{
	description = "MP18 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ySubmgunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 0.1;
	fireTime = 0.2;

	ammoType = ysubmgunAmmo;
	projectileType = ysubmgunBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData ysubmgun
{
	description = "MP18 Sub Machine Gun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysubmgunImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ysubmgun2Image 
{
	shapeFile = "GrenadeL";
	mountPoint = 0;
	mountRotation = { 0, 1.45, 0 };
	weaponType = 0;
	mountOffset = { 0, 0, 0.035 };
	accuFire = true;
};

ItemData ysubmgun2
{
	description = "Railgun";
	shapeFile = "grenadeL";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysubmgun2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ysubmgun3Image 
{
	shapeFile = "GrenadeL";
	mountPoint = 0;
	mountRotation = { 0, -1.45, 0 };
	weaponType = 0;
	mountOffset = { 0, 0, 0.035 };
	accuFire = true;
};

ItemData ysubmgun3
{
	description = "Railgun";
	shapeFile = "grenadeL";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysubmgun3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ysubmgun4Image 
{
	shapeFile = "force";
	mountPoint = 0;
	mountRotation = { 0, -1.45, 0 };
	weaponType = 0;
	mountOffset = { -0.1, 0.12, 0.050 };
	accuFire = true;
};

ItemData ysubmgun4
{
	description = "Railgun";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysubmgun4Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};




function ysubmgun::onMount(%player,%item) 
{	
	Player::mountItem(%player,ysubmgun2,5); 
	Player::mountItem(%player,ysubmgun3,6); 
	Player::mountItem(%player,ysubmgun4,7); 
}

function ysubmgun::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
}

//------------------------------------------
//-------------------K98 rifle
//------------------------------------------

$AutoUse[xrifle] = true;
$WeaponAmmo[xrifle] = xrifleammo;


RocketData xrifleBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = heavybullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.7;
	damageType = $k98;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3500.0;
	terminalVelocity = 3500.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};


ItemData xrifleAmmo
{
	description = "Rifle Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xrifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = xrifleAmmo;
	projectileType = xriflebullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 1;
	//spinUpTime = 0.25;
	projectileType = xrifleBullet;
	sfxFire = debrislargeExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xrifle
{
	description = "Karabiner 98K Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	
	imageType = xrifleImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xrifle2Image 
{
	shapeFile = "repairgun";
	mountPoint = 0;	
	mountOffset = { 0, 0, 0.13 };
	//mountRotation = { -1.5, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xrifle2
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xrifle2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function xrifle::onMount(%player,%item) 
{	
	
	Player::mountItem(%player,xrifle2,5); 

}



function xrifle::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	
}

//------------------------------------------
//-------------------M9A1 Bazooka
//------------------------------------------

$AutoUse[yBazooka] = true;
$WeaponAmmo[yBazooka] = yBazookaammo;

seekingmissileData yBazookaShell
{
  bulletShapeName = "plasmabolt.dts";
   explosionTag    = flashExplarge;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.4;
   damageType       = $bazooka;
   explosionRadius  = 4;
   kickBackStrength = 60.0;

   muzzleVelocity    = 47.0;
   totalTime         = 3.5;
   liveTime          = 3.5;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeName = "dustplume.dts";
   smokeDist         = 1;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};
seekingmissileData xpanzerShell
{
  bulletShapeName = "plasmabolt.dts";
   explosionTag    = flashExplarge;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.4;
   damageType       = $panzershreck;
   explosionRadius  = 4;
   kickBackStrength = 60.0;

   muzzleVelocity    = 47.0;
   totalTime         = 3.5;
   liveTime          = 3.5;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeName = "dustplume.dts";
   smokeDist         = 1;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

ItemData yBazookaAmmo
{
	description = "M9A1 Grenades";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData yBazookaImage
{
	shapeFile = "GrenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = yBazookaAmmo;
	//projectileType = yBazookashell;
	accuFire = true;
	//reloadTime = 1.5;
	fireTime = 0.4;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	mountOffset = { 0, -0.3, 0.4 };
	mountRotation = { 0, -1.45, 0 };
	
	

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	
};
function ybazookaimage::onFire(%player)
{
player::decitemcount(%player, ybazookaammo);
%trans = gamebase::getmuzzletransform(%player);
%vel = item::getvelocity(%player);
%id = projectile::spawnprojectile("yBazookaShell", %trans, %player, %vel);
%id.player = %player;
%id.explosive = 1;
schedule("WWII::RocketSeq(" @ %id @ ", " @ %player @ ");", 0.1);

}
ItemData yBazooka
{
	description = "M9A1 Bazooka";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yBazookaImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData yBazooka2Image 
{
	shapeFile = "GrenadeL";
	mountPoint = 0;	
	mountOffset = { 0, -0.75, 0.4 };
	mountRotation = { 0, -1.45, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData yBazooka2
{
	description = "Railgun";
	shapeFile = "GrenadeL";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yBazooka2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};



function yBazooka::onMount(%player,%item) 
{	
	Player::mountItem(%player,yBazooka2,5); 
	
}

function yBazooka::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);

}

//------------------------------------------
//-------------------Bren LMG
//------------------------------------------

$AutoUse[ybren] = true;
$WeaponAmmo[ybren] = ybrenammo;


BulletData ybrenBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.28;
   damageType         = $bren;

   aimDeflection      = 0.0047;
   muzzleVelocity     = 725.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData ybrenAmmo
{
	description = "Bren Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ybrenImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; 
	reloadTime = 0;
	fireTime = 0.14;
	//mountOffset = { 0, -0.25, 0 };
	ammoType = ybrenAmmo;
	projectileType = ybrenBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ybren
{
	description = "Bren-Light Machine Gun";
	className = "Weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ybrenImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ybren2Image 
{
	shapeFile = "plasma";
	mountPoint = 0;	
	mountOffset = { 0, 0, 0.215 };
	mountRotation = { 0, 3.1, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ybren2
{
	description = "Railgun";
	shapeFile = "plasma";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ybren2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ybren3Image 
{
	shapeFile = "shotgun";
	mountPoint = 0;	
	mountOffset = { 0.01, 0, 0.075 };
	//mountRotation = { 0, -1.55, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ybren3
{
	description = "Railgun";
	shapeFile = "shotgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ybren3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};




function ybren::onMount(%player,%item) 
{	

	Player::mountItem(%player,ybren2,5); 
	Player::mountItem(%player,ybren3,6); 
	
}

function ybren::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	
}

//------------------------------------------
//-------------------MP40
//------------------------------------------

$AutoUse[xMP40] = true;
$WeaponAmmo[xMP40] = xMP40ammo;

BulletData xMP40Bullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.19;
   damageType         = $mp40;

   aimDeflection      = 0.0037;
   muzzleVelocity     = 825.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData xMP40Ammo
{
	description = "MP40 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xMP40Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0, 0.25, -0.05 };
	weaponType = 0; 
	reloadTime = 0.11;
	fireTime = 0.01;
	ammoType = xMP40Ammo;
	projectileType = xMP40Bullet;
	accuFire = true;
	mountOffset = { 0, 0, -0.05 };
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xMP40
{
	description = "MP40";
	className = "tool";
	shapeFile = "paintgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xMP40Image;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xMP40Image2
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.05 };
	weaponType = 0; 

	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xMP402
{
	description = "MP40";
	className = "tool";
	shapeFile = "grenadeL";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xMP40Image2;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData xMP40Image3
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0, 0.65, -0.09 };
	weaponType = 0; 
	mountRotation = { 0, 0, 0 };
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xMP403
{
	description = "MP40";
	className = "tool";
	shapeFile = "paintgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xMP40Image3;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData xMP40Image4
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0.65, 0.02 };
	weaponType = 0; 
	mountRotation = { -1.55, 0, 0 };
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xMP404
{
	description = "MP40";
	className = "tool";
	shapeFile = "force";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xMP40Image4;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData xMP40Image5
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0.65, 0.13 };
	weaponType = 0; 
	mountRotation = { 0, -3.1 ,0 };
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xMP405
{
	description = "MP40";
	className = "tool";
	shapeFile = "force";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xMP40Image5;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData xMP40Image6
{
	shapeFile = "GrenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0.3, -0.32 };
	weaponType = 0; 
	mountRotation = { -1.55, 0, 0 };
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xMP406
{
	description = "MP40";
	className = "tool";
	shapeFile = "grenadeL";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xMP40Image6;
	showInventory = false;
	showWeaponBar = false;
};


function xMP40::onMount(%player, %item)
{	
	player::mountitem(%player, xMP402, 5);
	player::mountitem(%player, xMP403, 6);
	player::mountitem(%player, xMP404, 7);
	player::mountitem(%player, xMP405, 4);
	player::mountitem(%player, xMP406, 3);

}

function xMP40::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,3);
}

//------------------------------------------
//-------------------BAR M1918
//------------------------------------------
$AutoUse[ybar] = true;
$WeaponAmmo[ybar] = ybarammo;

BulletData ybarBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.499;
   damageType         = $bar;

    aimDeflection      = 0.0061;
   muzzleVelocity     = 800.9;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData ybarAmmo
{
	description = "B.A.R bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ybarImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; 
	ammoType = ybarAmmo;
	projectileType = ybarbullet;
	accuFire = true;
	reloadTime = 0.10;
	fireTime = 0.05;
	
	sfxFire = debrislargeExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ybar
{
	description = "B.A.R M1918";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	
	imageType = ybarImage;
	
	showWeaponBar = true;
};

ItemImageData ybar2Image 
{
	shapeFile = "paintgun";
	mountPoint = 0;	
	mountOffset = { 0, -0.23, 0.06 };
	//mountRotation = { -1.5, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ybar2
{
	description = "lol";
	shapeFile = "paintgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ybar2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ybar3Image 
{
	shapeFile = "grenammo";
	mountPoint = 0;	
	mountOffset = { 0.13, -0.1, -0.06 };
	mountRotation = { 0, -1.5, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ybar3
{
	description = "lol";
	shapeFile = "grenammo";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ybar3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ybar4Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.7, 0.1 };
	mountRotation = { 0, -2.7, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ybar4
{
	description = "lol";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ybar4Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ybar5Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.7, 0.1 };
	mountRotation = { 0, 2.7, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ybar5
{
	description = "lol";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ybar5Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};


function ybar::onMount(%player,%item) 
{	
	
	Player::mountItem(%player,ybar2,5); 
	Player::mountItem(%player,ybar3,6); 
	Player::mountItem(%player,ybar4,7); 
	Player::mountItem(%player,ybar5,4); 

}

function ybar::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,4);
}


//------------------------------------------
//-------------------M1A1 Thompson
//------------------------------------------

$AutoUse[ythompson] = true;
$WeaponAmmo[ythompson] = ythompsonammo;


BulletData ythompsonBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.45;
   damageType         = $thompson;

    aimDeflection      = 0.005;
   muzzleVelocity     = 1300.9;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData ythompsonAmmo
{
	description = "Thompson Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ythompsonImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.06, 0 };
	weaponType = 0; 
	ammoType = ythompsonAmmo;
	accuFire = true;
	reloadTime = 0.08;
	fireTime = 0.05;
	projectileType = ythompsonBullet;
	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ythompson
{
	description = "M1A1 Thompson Machine Gun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	
	imageType = ythompsonImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ythompson2Image 
{
	shapeFile = "plasma";
	mountPoint = 0;	
	mountOffset = { -0.03, 0.1, -0.05 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ythompson2
{
	description = "l";
	shapeFile = "plasma";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ythompson2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ythompson3Image
{
	shapeFile = "sniper";
	mountOffset = { -0.06, 0.06, 0 }; 
	mountRotation = { 0, 0, -0 };
	mountPoint = 0;
	weaponType = 0; 
	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ythompson3
{
	description = "M1A1 Thompson Machine Gun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	
	imageType = ythompson3Image;
	
	showWeaponBar = true;
};

ItemImageData ythompson4Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { -0.05, 0.8, 0.26 };
	mountRotation = { 0, 3.1, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ythompson4
{
	description = "p";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ythompson4Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function ythompson::onMount(%player,%item) 
{	
	
	Player::mountItem(%player,ythompson2,6); 
	Player::mountItem(%player,ythompson3,7); 
	Player::mountItem(%player,ythompson4,5); 
}



function ythompson::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,5);
}


//------------------------------------------
//-------------------M1 Carbine
//------------------------------------------




$AutoUse[ycarbine] = true;
$WeaponAmmo[ycarbine] = ycarbineammo;


RocketData ycarbineBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = mediumbullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.3;
	damageType = $m1carbine;		
	explosionRadius = 0.1;
	kickBackStrength = 400.0;
	muzzleVelocity = 1500.0;
	terminalVelocity = 1500.0;
	acceleration = 200.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};


ItemData ycarbineAmmo
{
	description = "Cal. 30 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ycarbineImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; 
	ammoType = ycarbineAmmo;
	projectileType = ycarbinebullet;
	accuFire = true;
	reloadTime = 0.65;
	fireTime = 0.2;
	mountOffset = { 0, 0.4, -0.1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ycarbine
{
	description = "M1 Carbine";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ycarbineImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ycarbine2Image 
{
	shapeFile = "sniper";
	mountPoint = 0;	
	mountOffset = { 0, -0.3, 0.05 };
	mountRotation = { 0, 3.1, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ycarbine2
{
	description = "po";
	shapeFile = "sniper";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ycarbine2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ycarbine3Image 
{
	shapeFile = "repairgun";
	mountPoint = 0;	
	mountOffset = { 0, 0, 0.03 };
	
	weaponType = 0;
	
	accuFire = true;
};

ItemData ycarbine3
{
	description = "po";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ycarbine3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ycarbine4Image 
{
	shapeFile = "paintgun";
	mountPoint = 0;	
	mountOffset = { 0, 0.35, -0.04 };
	mountRotation = { 0, 0, 3.1 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ycarbine4
{
	description = "po";
	shapeFile = "paintgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ycarbine4Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function ycarbine::onMount(%player,%item) 
{	
	Player::mountItem(%player,ycarbine2,5); 
	Player::mountItem(%player,ycarbine3,6); 
	Player::mountItem(%player,ycarbine4,7); 
}



function ycarbine::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}


//------------------------------------------
//-------------------Mosin Nagant
//------------------------------------------




$AutoUse[ymosinnagant] = true;
$WeaponAmmo[ymosinnagant] = ymosinnagantammo;


RocketData ymosinnagantBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = heavybullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.66;
	damageType = $mosinnagant;		
	explosionRadius = 0.1;
	kickBackStrength = 400.0;
	muzzleVelocity = 1500.0;
	terminalVelocity = 1500.0;
	acceleration = 200.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};


ItemData ymosinnagantAmmo
{
	description = "Mosin-Nagant ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ymosinnagantImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; 
	ammoType = ymosinnagantAmmo;
	projectileType = ymosinnagantbullet;
	accuFire = true;
	reloadTime = 0.65;
	fireTime = 0.2;
	

	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ymosinnagant
{
	description = "Mosin-Nagant";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ymosinnagantImage;
	price = 200;
	showWeaponBar = true;
};


ItemImageData ymosinnagant2Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.8, 0.13 };
	mountRotation = { -1.55, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ymosinnagant2
{
	description = "po";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ymosinnagant2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ymosinnagant3Image 
{
	shapeFile = "repairgun";
	mountPoint = 0;	
	mountOffset = { 0, 0.35, 0.15 };
	mountRotation = { 0, 0, 3.1 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ymosinnagant3
{
	description = "pk";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ymosinnagant3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ymosinnagant4Image 
{
	shapeFile = "paintgun";
	mountPoint = 0;	
	mountOffset = { 0, 0.07, 0.06 };
	mountRotation = { 0.2, 0, 3.1 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ymosinnagant4
{
	description = "hk";
	shapeFile = "paintgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ymosinnagant4Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ymosinnagant5Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { -0.02, -0.02, 0.13 };
	mountRotation = { 0, 0.65, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ymosinnagant5
{
	description = "hu";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ymosinnagant5Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};



function ymosinnagant::onMount(%player,%item) 
{	
	Player::mountItem(%player,ymosinnagant2,3); 
	Player::mountItem(%player,ymosinnagant3,4); 
	Player::mountItem(%player,ymosinnagant4,5); 
	Player::mountItem(%player,ymosinnagant5,6); 
}



function ymosinnagant::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,3);
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
}


//------------------------------------------
//-------------------Sten
//------------------------------------------0

$AutoUse[ysten] = true;
$WeaponAmmo[ysten] = ystenammo;

BulletData ystenBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.4;
   damageType         = $sten;

    aimDeflection      = 0.0056;
   muzzleVelocity     = 800.9;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData ystenammo
{
	description = "Sten Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ystenImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // 
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 0.1;
	fireTime = 0.1;
	mountOffset = { 0, -0.1, 0 };
	ammoType = ystenAmmo;
	projectileType = ystenBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ysten
{
	description = "Sten";
	className = "Weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ystenImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ysten2Image 
{
	shapeFile = "sniper";
	mountPoint = 0;	
	mountOffset = { -0.03, -0.1, 0 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ysten2
{
	description = "po";
	shapeFile = "sniper";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysten2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData ysten3Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { -0.015, 0.55, 0.24 };
	mountRotation = { 0, 3.1, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ysten3
{
	description = "po";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysten3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};


ItemImageData ysten4Image 
{
	shapeFile = "plasma";
	mountPoint = 0;	
	mountOffset = { -0.15, -0.09, 0.07 };
	mountRotation = { 0, 1.55, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData ysten4
{
	description = "po";
	shapeFile = "plasma";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ysten4Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function ysten::onMount(%player,%item) 
{	
	Player::mountItem(%player,ysten2,3); 
	Player::mountItem(%player,ysten3,4); 
	Player::mountItem(%player,ysten4,5); 
	//Player::mountItem(%player,ysten5,6); 
}



function ysten::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,3);
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,5);
	//Player::unmountItem(%player,6);
}


//------------------------------------------
//-------------------M1 Garand
//------------------------------------------




$AutoUse[ygarand] = true;
$WeaponAmmo[ygarand] = ygarandammo;


RocketData ygarandBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = mediumbullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.35;
	damageType = $garand;		
	explosionRadius = 0.1;
	kickBackStrength = 100.0;
	muzzleVelocity = 2500.0;
	terminalVelocity = 2500.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};


ItemData ygarandAmmo
{
	description = "Garand Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ygarandImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.2, 0.19 };
	mountrotation = { 0, 3.1, 0 };
	weaponType = 0; 
	ammoType = ygarandAmmo;
	projectileType = ygarandbullet;
	accuFire = true;
	reloadTime = 0.45;
	fireTime = 0.1;
	

	sfxFire = debrisSmallExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ygarand
{
	description = "M1 Garand";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ygarandImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ygarand2Image 
{
	shapeFile = "sniper";
	mountPoint = 0;	
	
	
	weaponType = 0;
	
	accuFire = true;
};

ItemData ygarand2
{
	description = "po";
	shapeFile = "sniper";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ygarand2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function ygarand::onMount(%player,%item) 
{	
	Player::mountItem(%player,ygarand2,3); 
	 
}



function ygarand::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,3);
	
}

//------------------------------------------
//-------------------P38 Pistol
//------------------------------------------


BulletData xpistolBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.35;
   damageType         = $P38;

   aimDeflection      = 0.007;
   muzzleVelocity     = 420.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData xpistolAmmo
{
	description = "P38 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xpistolImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 3; 
	reloadTime = 0;
	fireTime = 0.25;
	mountOffset = { 0, 0.1, 0 };
	ammoType = xpistolAmmo;
	projectileType = xpistolBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = bigExplosion4;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xpistol
{
	description = "Walther P38 Pistol";
	className = "tool";
	shapeFile = "paintgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xpistolImage;
	price = 200;
	showWeaponBar = true;
};

//------------------------------------------
//-------------------M1911 Pistol
//------------------------------------------


BulletData ypistolBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $M1911;

   aimDeflection      = 0.009;
   muzzleVelocity     = 300.0;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData ypistolAmmo
{
	description = "M1911 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ypistolImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; 
	reloadTime = 0;
	fireTime = 0.35;
	ammoType = ypistolAmmo;
	projectileType = ypistolBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = soundfirechaingun;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ypistol
{
	description = "M1911 Pistol";
	className = "tool";
	shapeFile = "energygun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ypistolImage;
	price = 200;
	showWeaponBar = true;
};

//------------------------------------------
//-------------------K98 grenade rifle
//------------------------------------------

$AutoUse[xgrifle] = true;
$WeaponAmmo[xgrifle] = nadeammo;

ItemData xgAmmo
{
	description = "dont look";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
	showinventory=false;
	showweaponbar=false;
};

ItemImageData xgrifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; 
	reloadTime = 0.1;
	fireTime = 0.1;
	ammoType = xgAmmo;
	//projectileType = ypistolBullet;
	accuFire = true;
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xgrifle
{
	description = "Mauser K98 Grenade Rifle";
	className = "weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xgrifleImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xriflenadeImage 
{
	shapeFile = "grenade";
	mountPoint = 0;	
	weaponType = 0;
	accuFire = true;
	mountOffset = { 0,0.85,0.12 };
	mountRotation = { 1.57079, 0, 0 };
};

ItemData xriflenade
{
	description = "po";
	shapeFile = "grenade";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = xriflenadeImage;
	showWeaponBar = false;
	showInventory = false;
	price = 0;
};


function xgrifle::onMount(%player,%item) 
{		
	Player::mountItem(%player,xrifle2,5); 
	if(Player::getitemcount(%player, nadeammo)) 
		{
		Player::mountItem(%player,xriflenade,6); 
		player::setitemcount(%player, xgammo, 1);
		}
}

function xgrifle::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);	
	Player::unmountItem(%player,6);	
}

function xgrifleImage::onFire(%player)
{
if(player::getitemcount(%player, nadeammo) < 1) return;
player::decItemcount(%player, nadeammo);
player::setitemcount(%player, xgammo, 0);
Player::unmountItem(%player,6);	
%trans = Gamebase::getmuzzletransform(%player);
%aimvector = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
%muzzlepos = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);

%obj = newObject("","Mine","Grenadebomb");
addToSet("MissionCleanup", %obj);
GameBase::throw(%obj,%player,0.001 ,false);
gamebase::setposition(%obj, %muzzlepos);
Item::setvelocity(%obj, vector::add(vector::multiply(%aimvector, "50 50 50"), item::getvelocity(%player)));

if(player::getitemcount(%player, nadeammo) >= 1) 
	{
	schedule("if(player::getmounteditem(" @ %player @ ",0) == xgrifle) player::mountitem(" @ %player @ ",xriflenade,6);", 4.8);
	schedule("if(player::getmounteditem(" @ %player @ ",0) == xgrifle) gamebase::playsound(" @ %player @ ",soundpickupitem,2);", 4.8);
	schedule("player::setitemcount(" @ %player @ ",xgammo,1);", 4.8);
	}
}

//------------------------------------------
//-------------------------DP Machine Gun
//------------------------------------------
BulletData yDPBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.4;
   damageType         = $DP;

    aimDeflection      = 0.008;
   muzzleVelocity     = 850.9;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData yDPAmmo
{
	description = "DP Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData yDPImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // 
	reloadTime = 0;
	spinUpTime = 0;
	fireTime = 0.15;
	mountoffset = { 0, 0.2, 0 };
	ammoType = yDPAmmo;
	projectileType = yDPBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFlierCrash;
	sfxActivate = SoundPickUpWeapon;
};

ItemData yDP
{
	description = "DP-28";
	className = "Weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yDPImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData yDP2Image 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, -1.55, 0 };
	weaponType = 0;
	mountOffset = { 0.024, 0, 0.07 };
	accuFire = true;
};

ItemData yDP2
{
	description = "Railgun";
	shapeFile = "shotgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yDP2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};
	
ItemImageData yDP3Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.9, 0.1 };
	mountRotation = { 0, -2.7, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData yDP3
{
	description = "lol";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yDP3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData yDP4Image 
{
	shapeFile = "force";
	mountPoint = 0;	
	mountOffset = { 0, 0.9, 0.1 };
	mountRotation = { 0, 2.7, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData yDP4
{
	description = "lol";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yDP4Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};
 
ItemImageData yDP5Image 
{
	shapeFile = "discammo";
	mountPoint = 0;	
	mountOffset = { 0, 0.25, 0.09 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData yDP5
{
	description = "lol";
	shapeFile = "discammo";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yDP5Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};
	
function yDP::onMount(%player,%item) 
{	
	Player::mountItem(%player,yDP2,5); 
	Player::mountItem(%player,yDP3,6); 
	Player::mountItem(%player,yDP4,7); 
	Player::mountItem(%player,yDP5,4); 
}

function yDP::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,4);
	
}

//------------------------------------------
//-------------------M3 - Grease Gun
//------------------------------------------

BulletData yM3Bullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.35;
   damageType         = $M3;

   aimDeflection      = 0.0039;
   muzzleVelocity     = 900.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData yM3Ammo
{
	description = "M3 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData yM3Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
	
	mountOffset = { 0, 0.65, -0.09 };
	weaponType = 0; 
	reloadTime = 0.001;
	fireTime = 0.15;
	ammoType = yM3Ammo;
	projectileType = yM3Bullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = debrisSmallExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yM3
{
	description = "M3 - Grease Gun";
	className = "weapon";
	shapeFile = "paintgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yM3Image;
	price = 200;
	showWeaponBar = true;
};

ItemImageData yM3Image2
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.05 };
	weaponType = 0; 

	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yM32
{
	description = "MP40";
	className = "tool";
	shapeFile = "grenadeL";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yM3Image2;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData yM3Image3
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0, 0.25, -0.05 };
	weaponType = 0; 
	mountRotation = { 0, 0, 0 };
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yM33
{
	description = "MP40";
	className = "tool";
	shapeFile = "paintgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yM3Image3;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData yM3Image4
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0.9, 0.02 };
	weaponType = 0; 
	mountRotation = { -1.57079, 0, 0 };
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yM34
{
	description = "MP40";
	className = "tool";
	shapeFile = "force";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yM3Image4;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData yM3Image5
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0.9, 0.02 };
	weaponType = 0; 
	mountRotation = { 1.57079, 0 ,0 };
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yM35
{
	description = "MP40";
	className = "tool";
	shapeFile = "force";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yM3Image5;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData yM3Image6
{
	shapeFile = "GrenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0.3, -0.32 };
	weaponType = 0; 
	mountRotation = { -1.55, 0, 0 };
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yM36
{
	description = "MP40";
	className = "tool";
	shapeFile = "grenadeL";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yM3Image6;
	showInventory = false;
	showWeaponBar = false;
};


function yM3::onMount(%player, %item)
{	
	player::mountitem(%player, yM32, 5);
	player::mountitem(%player, yM33, 6);
	player::mountitem(%player, yM34, 7);
	player::mountitem(%player, yM35, 4);
	player::mountitem(%player, yM36, 3);

}

function ym3::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,3);
}

//------------------------------------------
//-------------------Lanchester-SMG
//------------------------------------------

BulletData ylanchesterBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.415;
   damageType         = $Lanchester;

    aimDeflection      = 0.006;
   muzzleVelocity     = 350.9;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 1;
};


ItemData ylanchesterAmmo
{
	description = "Lanchester Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ylanchesterImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // 
	reloadTime = 0;
	fireTime = 0.1;
	mountrotation = { 0, -1.57079, 0 };
	mountoffset = { 0.02, 0.15, 0.08 };
	ammoType = ylanchesterAmmo;
	projectileType = ylanchesterBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ylanchester
{
	description = "Lanchester SMG";
	className = "Weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ylanchesterImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ylanchesterImage2
{
	shapeFile = "sniper";
	mountPoint = 0;
	
	weaponType = 0; 
	
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ylanchester2
{
	description = "gsfgjk";
	className = "tool";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ylanchesterImage2;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData ylanchesterImage3
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountrotation = { 0, 1.57079, 1.57079 };
	mountoffset = { -0.23, 0.27, 0.09 }; 
	weaponType = 0; 
	
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ylanchester3
{
	description = "gsfgjk";
	className = "tool";
	shapeFile = "repairgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ylanchesterImage3;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData ylanchesterImage4
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountrotation = { 0, 1.57079, -1.57079 };
	mountoffset = { -0.2, 0.17, 0.09 }; 
	weaponType = 0; 
	
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ylanchester4
{
	description = "gsfgjk";
	className = "tool";
	shapeFile = "repairgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ylanchesterImage4;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData ylanchesterImage5
{
	shapeFile = "force";
	mountPoint = 0;
	mountrotation = { 0, 3.14159, 0 };
	mountoffset = { 0, 0.7, 0.27 }; 
	weaponType = 0; 
	
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ylanchester5
{
	description = "gsfgjk";
	className = "tool";
	shapeFile = "force";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ylanchesterImage5;
	showInventory = false;
	showWeaponBar = false;
};


function ylanchester::onMount(%player)
{
player::mountitem(%player, ylanchester2, 4);
player::mountitem(%player, ylanchester3, 5);
player::mountitem(%player, ylanchester4, 6);
player::mountitem(%player, ylanchester5, 7);
}

function ylanchester::onUnMount(%player)
{
player::unmountitem(%player, 4);
player::unmountitem(%player, 5);
player::unmountitem(%player, 6);
player::unmountitem(%player, 7);
}

//------------------------------------------
//-------------------PTRD - Russian AT Rfile
//------------------------------------------

$AutoUse[yPTRD] = true;
$WeaponAmmo[yPTRD] = yPTRDammo;


RocketData yPTRDbullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = debrisExpmedium;
	collisionRadius = 0.0;
	mass = 9.0;
	damageClass = 0;
	damageValue = 1.4;
	damageType = $PTRD;		
	explosionRadius = 2.5;
	kickBackStrength = 5.0;
	muzzleVelocity = 750.0;
	terminalVelocity = 600.0;
	acceleration = 5.0;
	totalTime = 0.6;
	liveTime = 0.6;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};


ItemData yPTRDAmmo
{
	description = "PTRD shells";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData yPTRDImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // 
	reloadTime = 0;
	fireTime = 1;
	//mountrotation = { 0, -1.57079, 0 };
	mountoffset = { 0,0,-0.1 };
	ammoType = yPTRDAmmo;
	//projectileType = yPTRDBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	//sfxFire = mineExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData yPTRD
{
	description = "PTRD";
	className = "Weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yPTRDImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData yPTRDImage2
{
	shapeFile = "grenadel";
	mountPoint = 0;
	//mountrotation = { 0, 3.14159, 0 };
	mountoffset = { 0, -0.2, 0 }; 
	weaponType = 0; 
	
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yPTRD2
{
	description = "gsfgjk";
	className = "tool";
	shapeFile = "grenadel";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yPTRDImage2;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData yPTRDImage3
{
	shapeFile = "grenadel";
	mountPoint = 0;
	//mountrotation = { 0, 3.14159, 0 };
	mountoffset = { 0, 0.4, 0 }; 
	weaponType = 0; 
	
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yPTRD3
{
	description = "gsfgjk";
	className = "tool";
	shapeFile = "grenadel";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yPTRDImage3;
	showInventory = false;
	showWeaponBar = false;
};

function yPTRDimage::onFire(%pl)
{
if(player::iscrouching(%pl) != true) { bottomprint(player::getclient(%pl), "<jc><f1>Must crouch when firing!!", 3,WEAPON); return; }
player::decitemcount(%pl, yPTRDammo);
gamebase::playsound(%pl, mineExplosion, 2);
%trans = gamebase::getmuzzletransform(%pl);
%vel = item::getvelocity(%pl);
%id = Projectile::spawnProjectile("yPTRDbullet", %trans, %pl, %Vel); 
%id.explosive = 1;
schedule("deleteobject(" @ %id @ ");", 3, %id);

}


function yPTRD::onMount(%pl)
{
player::mountitem(%pl, yPTRD2, 4);
player::mountitem(%pl, yPTRD3, 5);
}
function yPTRD::onunmount(%pl)
{
player::unmountitem(%pl, 4);
player::unmountitem(%pl, 5);
}

//------------------------------------------
//-------------------PIAT - British AT Rfile
//------------------------------------------

$AutoUse[yPIAT] = true;
$WeaponAmmo[yPIAT] = yPIATammo;


RocketData yPIATbullet
{
	bulletShapeName = "rocket.dts";
	explosionTag = debrisExplarge;
	collisionRadius = 0.0;
	mass = 9.0;
	damageClass = 1;
	damageValue = 2.4;
	damageType = $PIAT;		
	explosionRadius = 4;
	kickBackStrength = 5.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 150.0;
	acceleration = 5.0;
	totalTime = 3.8;
	liveTime = 3.8;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
	trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;
};


ItemData yPIATAmmo
{
	description = "PIAT shells";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData yPIATImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // 
	reloadTime = 0;
	fireTime = 1;
	//mountrotation = { 0, -1.57079, 0 };
	mountoffset = { 0,0,-0.1 };
	ammoType = yPIATAmmo;
	//projectileType = yPIATBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	//sfxFire = mineExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData yPIAT
{
	description = "PIAT";
	className = "Weapon";
	shapeFile = "sniper";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yPIATImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData yPIATImage2
{
	shapeFile = "paintgun";
	mountPoint = 0;
	//mountrotation = { 0, 3.14159, 0 };
	mountoffset = { 0, 0.2, 0.04 }; 
	weaponType = 0; 
	
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yPIAT2
{
	description = "gsfgjk";
	className = "tool";
	shapeFile = "paintgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yPIATImage2;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData yPIATImage3
{
	shapeFile = "grenadel";
	mountPoint = 0;
	//mountrotation = { 0, 3.14159, 0 };
	mountoffset = { 0, 0.2, 0 }; 
	weaponType = 0; 
	
	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData yPIAT3
{
	description = "gsfgjk";
	className = "tool";
	shapeFile = "grenadel";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = yPIATImage3;
	showInventory = false;
	showWeaponBar = false;
};

function yPIATimage::onFire(%pl)
{
if(player::iscrouching(%pl) != true) { bottomprint(player::getclient(%pl), "<jc><f1>Must crouch when firing!!", 3,WEAPON); return; }
player::decitemcount(%pl, yPIATammo);
gamebase::playsound(%pl, SoundFireGrenade, 2);
%trans = gamebase::getmuzzletransform(%pl);
%vel = item::getvelocity(%pl);
%aimvector = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
player::applyimpulse(%pl, vector::multiply(vector::neg(%aimvector), "40 40 80"));
%id = Projectile::spawnProjectile("yPIATbullet", %trans, %pl, %Vel); 
%id.explosive = 1;
schedule("deleteobject(" @ %id @ ");", 3.5, %id);

}


function yPIAT::onMount(%pl)
{
player::mountitem(%pl, yPIAT2, 4);
player::mountitem(%pl, yPIAT3, 5);
}
function yPIAT::onunmount(%pl)
{
player::unmountitem(%pl, 4);
player::unmountitem(%pl, 5);
}


//------------------------------------------
//-------------------Type 99 Sniper Rifle
//------------------------------------------

$AutoUse[xrifleJ] = true;
$WeaponAmmo[xrifleJ] = xrifleJammo;


RocketData xrifleJBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = heavybullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.55;
	damageType = $type99;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3500.0;
	terminalVelocity = 3500.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 1, 0.7, 0 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};


ItemData xrifleJAmmo
{
	description = "Rifle Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xrifleJImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.200985, 0 };

	weaponType = 3; // DiscLauncher
	ammoType = xrifleJAmmo;
	accuFire = true;
	reloadTime = 0;
	fireTime = 1;
	//spinUpTime = 0.25;
	projectileType = xrifleJBullet;
	sfxFire = SoundTankCrash;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xrifleJ
{
	description = "Type 99 Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	
	imageType = xrifleJImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xrifleJaImage 
{
	shapeFile = "SNIPER";
	mountPoint = 0;
	mountOffset = { 0, -0.295336, 0.0138836 };
	mountRotation = { 0.199994, 3.1402, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xrifleJa
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xrifleJaImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xrifleJbImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0, -0.06031, 0.0178325 };
	mountRotation = { 0, 0, 3.13996 };
	weaponType = 0;
	accuFire = true;
};

ItemData xrifleJb
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xrifleJbImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xrifleJcImage 
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, -0.054537, 0.1052 };
	mountRotation = { 0, 1.09998, 0 };

	weaponType = 0;
	accuFire = true;
};

ItemData xrifleJc
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xrifleJcImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};
function xrifleJ::onMount(%player,%item) 
{	
	Player::mountItem(%player,xrifleJa,5); 
	Player::mountItem(%player,xrifleJb,6); 
	Player::mountItem(%player,xrifleJc,7); 
}



function xrifleJ::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

//------------------------------------------
//-------------------Type 100 Submachine Gun
//------------------------------------------

$AutoUse[xType100] = true;
$WeaponAmmo[xType100] = xType100Ammo;


BulletData xtype100Bullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.35; //Low calibre compared to most other SMGs
   damageType         = $type100;

    aimDeflection      = 0.005;
   muzzleVelocity     = 335;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 1;
};

ItemData xType100Ammo
{
	description = "Type 100 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xType100Image
{
	shapeFile = "FORCE";
	mountPoint = 0;
	
	mountOffset = { 0, 0.211737, 0.0201543 };

	mountRotation = { 0, 0, 0 };

	weaponType = 0; // 
	reloadTime = 0;
	fireTime = 0.075;
	ammoType = xType100Ammo;
	projectileType = xType100Bullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1.0, 0.8, 0 };
	sfxFire = SoundTankCrash;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xType100
{
	description = "Type 100 Submachine Gun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	
	imageType = xType100Image;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xType100aImage 
{
	shapeFile = "ENERGYGUN";
	mountPoint = 0;
	mountOffset = { 0, 0.0, 0 };
	mountRotation = { 0, 0, 0 };

	weaponType = 0;
	
	accuFire = true;
};

ItemData xType100a
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType100aImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xType100bImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, -0.326031, 0.0261217 };
	mountRotation = { 0.139993, 3.13991, 0 };

	weaponType = 0;
	
	accuFire = true;
};

ItemData xType100b
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType100bImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xType100cImage 
{
	shapeFile = "Force";
	mountPoint = 0;
	mountOffset = { 0, 0.875022, 0.127704 };
	mountRotation = { 1.56204, 0, 0 };

	weaponType = 0;
	
	accuFire = true;
};

ItemData xType100c
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType100cImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xType100clipImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { -0.093149, 0.292737, 0.0703383 };
	mountRotation = { 0, 1.56997, -1.82998 };

	weaponType = 0;
	
	accuFire = true;
};

ItemData xType100clip
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType100clipImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function xType100::onMount(%player,%item)
{	
	Player::mountItem(%player,xType100a,5); 
	Player::mountItem(%player,xType100b,6); 
	Player::mountItem(%player,xType100c,7); 
	Player::mountItem(%player,xType100clip,3); 
}

function xType100::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,3);
}



//------------------------------------------
//-------------------Type 96 Machine Gun
//------------------------------------------

$AutoUse[xType96] = true;
$WeaponAmmo[xType96] = xType96Ammo;


BulletData xtype96Bullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;
   damageValue        = 0.41; //Longer barrel than previous.
   damageType         = $type96;

    aimDeflection      = 0.008;
   muzzleVelocity     = 735;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 1;
};

ItemData xType96Ammo
{
	description = "Type 96 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xType96Image
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.378988, 0.16583 };
	mountRotation = { 0, 3.13997, 0 };


	weaponType = 0; // 
	reloadTime = 0;
	fireTime = 0.10909;
	ammoType = xType96Ammo;
	projectileType = xType96Bullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1.0, 0.8, 0 };
	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xType96
{
	description = "Type 96 Machine Gun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	
	imageType = xType96Image;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xType96aImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, -0.199999, 0 };
	mountRotation = { 0, 0, 0 };

	weaponType = 0;
	
	accuFire = true;
};

ItemData xType96a
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType96aImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xType96bImage 
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0.598603, 0.0083092 };
	mountRotation = { 0, 2.5, 0 };

	weaponType = 0;
	
	accuFire = true;
};

ItemData xType96b
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType96bImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xType96cImage 
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0.598603, 0.0083092 };
	mountRotation = { 0, -2.5, 0 };

	weaponType = 0;
	
	accuFire = true;
};

ItemData xType96c
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType96cImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xType96clipImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { -0.0785758, 0.0703166, 0.170352 };
	mountRotation = { -1.35059, 1.55579, -1.58772 };

	weaponType = 0;
	
	accuFire = true;
};

ItemData xType96clip
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType96clipImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function xType96::onMount(%player,%item)
{	
	Player::mountItem(%player,xType96a,5); 
	Player::mountItem(%player,xType96b,6); 
	Player::mountItem(%player,xType96c,7); 
	Player::mountItem(%player,xType96clip,3); 
}

function xType96::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,3);
}



//------------------------------------------
//-------------------Type 4 Rocket
//------------------------------------------

$AutoUse[xRocket] = true;
$WeaponAmmo[xRocket] = xRocketammo;

seekingmissileData xRocketShell
{
  bulletShapeName = "mortar.dts";
   explosionTag    = debrisExpMedium;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.8;
   damageType       = $Type4;
   explosionRadius  = 5;
   kickBackStrength = 60.0;

   muzzleVelocity    = 75.0;
   totalTime         = 3.5;
   liveTime          = 3.5;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeName = "dustplume.dts";
   smokeDist         = 1;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.8, 0.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

ItemData xRocketAmmo
{
	description = "Type 4 Rocket";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xRocketImage
{
	shapeFile = "force";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = xRocketAmmo;
	//projectileType = yBazookashell;
	accuFire = true;
	//reloadTime = 1.5;
	fireTime = 0.4;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 1.0, 0.4, 0.0 };

	mountOffset = { 0, 0.466671, 0.4 };
	mountRotation = { 0, -1.57, 0 };
	
	

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	
};
function xRocketimage::onFire(%player)
{
player::decitemcount(%player, xRocketammo);
%trans = gamebase::getmuzzletransform(%player);
%vel = item::getvelocity(%player);
%id = projectile::spawnprojectile("xRocketShell", %trans, %player, %vel);
%id.player = %player;
%id.explosive = 1;
schedule("WWII::RocketSeq(" @ %id @ ", " @ %player @ ");", 0.1);

}
ItemData xRocket
{
	description = "Type 4 Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xRocketImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xRocket2Image 
{
	shapeFile = "GrenadeL";
	mountPoint = 0;	
	mountOffset = { 0, 0.296658, 0.399998 };
	mountRotation = { 0, -1.56998, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xRocket2
{
	description = "fwee";
	shapeFile = "GrenadeL";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xRocket2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};



ItemImageData xRocket3Image 
{
	shapeFile = "GrenadeL";
	mountPoint = 0;	
	mountOffset = { -0.0374993, -0.166602, 0.355498 };
	mountRotation = { 0, 0, 3.13996 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xRocket3
{
	description = "fwee";
	shapeFile = "GrenadeL";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xRocket3Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};



function xRocket::onMount(%player,%item) 
{	
	Player::mountItem(%player,xRocket2,5); 
	Player::mountItem(%player,xRocket3,6); 
	
}

function xRocket::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);

}


//------------------------------------------
//-------------------Type 97 AT Rifle
//------------------------------------------

$AutoUse[xType97] = true;
$WeaponAmmo[xType97] = xType97ammo;

RocketData xType97bullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = debrisExplarge;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 1.4;
	damageType = $Type97;		
	explosionRadius = 3;
	kickBackStrength = 25.0;
	muzzleVelocity = 470.0;
	terminalVelocity = 440.0;
	acceleration = 5.0;
	totalTime = 0.8;
	liveTime = 0.8;
	lightRange = 10.0;
	lightColor = { 1, 0.7, 0 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
	trailType   = 2;                // smoke trail
  	trailString = "rsmoke.dts";
  	smokeDist   = 1.8;
};




ItemData xType97Ammo
{
	description = "Type 97 HE round";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xType97Image
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = xType97Ammo;
	//projectileType = xType97Bullet;
	accuFire = true;
	//reloadTime = 1.5;
	fireTime = 3;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 1.0, 0.4, 0.0 };

	sfxFire = bigExplosion1;
	sfxActivate = SoundPickUpWeapon;
};

function xType97image::onFire(%pl)
{
if(player::iscrouching(%pl) != true) { bottomprint(player::getclient(%pl), "<jc><f1>Must crouch when firing!!", 3,WEAPON); return; }
player::decitemcount(%pl, xtype97ammo);
gamebase::playsound(%pl, SoundFireGrenade, 2);
%trans = gamebase::getmuzzletransform(%pl);
%vel = item::getvelocity(%pl);
%aimvector = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
player::applyimpulse(%pl, vector::multiply(vector::neg(%aimvector), "40 40 80"));
%id = Projectile::spawnProjectile("xType97Bullet", %trans, %pl, %Vel);
%id.explosive = 1;
schedule("deleteobject(" @ %id @ ");", 3.5, %id);

}

ItemData xType97
{
	description = "Type 97 AT Rifle";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType97Image;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xType972Image 
{
	shapeFile = "GrenadeL";
	mountPoint = 0;	
	mountOffset = { 0, 0.626985, 0.0543152 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xType972
{
	description = "fwee";
	shapeFile = "GrenadeL";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType972Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};



ItemImageData xType973Image 
{
	shapeFile = "GrenadeL";
	mountPoint = 0;	
	mountOffset = { 0,0.245448, 0.173879 };
	mountRotation = { 0, -3.14159, -3.14159 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xType973
{
	description = "fwee";
	shapeFile = "GrenadeL";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType973Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xType974Image 
{
	shapeFile = "Paintgun";
	mountPoint = 0;	
	mountOffset = { 0.0309579,0.318988, 0.178417 };
	mountRotation = { -1.29869, -1.08765, 2.07104 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xType974
{
	description = "fwee";
	shapeFile = "GrenadeL";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xType974Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};



function xType97::onMount(%player,%item) 
{	
	Player::mountItem(%player,xType972,5); 
	Player::mountItem(%player,xType973,6); 
	Player::mountItem(%player,xType974,7); 
	
}

function xType97::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);

}




//------------------------------------------
//-------------------Type 38 Rifle
//------------------------------------------

$AutoUse[xrifleJE] = true;
$WeaponAmmo[xrifleJE] = xrifleJEammo;


RocketData xrifleJEBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = heavybullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.3;
	damageType = $type38;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 765.0;
	terminalVelocity = 765.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 1, 0.7, 0 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};


ItemData xrifleJEAmmo
{
	description = "Rifle Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xrifleJEImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };

	weaponType = 3; // DiscLauncher
	ammoType = xrifleJEAmmo;
	accuFire = true;
	reloadTime = 0;
	fireTime = 1;
	//spinUpTime = 0.25;
	projectileType = xrifleJEBullet;
	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xrifleJE
{
	description = "Type 38 Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	
	imageType = xrifleJEImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData xrifleJEaImage 
{
	shapeFile = "SNIPER";
	mountPoint = 0;
	mountOffset = { 0, -0.505458, -0.0936799 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	
	accuFire = true;
};

ItemData xrifleJEa
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xrifleJEaImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData xrifleJEbImage
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0.100229, 0.0895813 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	accuFire = true;
};

ItemData xrifleJEb
{
	description = "Railgun";
	shapeFile = "repairgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xrifleJEbImage;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};
function xrifleJE::onMount(%player,%item) 
{
	Player::mountItem(%player,xrifleJEa,5); 
	Player::mountItem(%player,xrifleJEb,6); 
}



function xrifleJE::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
}




//------------------------------------------
//-------------------Nambu Type 14 Pistol
//------------------------------------------


BulletData xNambuBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = smallbullet;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $Nambu;

   aimDeflection      = 0.0032;
   muzzleVelocity     = 525.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData xNambuAmmo
{
	description = "Type 14 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xNambuImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; 
	reloadTime = 0;
	fireTime = 0.35;
	ammoType = xNambuAmmo;
	projectileType = xNambuBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = soundfirechaingun;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xNambu
{
	description = "Nambu Type 14 Pistol";
	className = "tool";
	shapeFile = "energygun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xNambuImage;
	price = 200;
	showWeaponBar = true;
};



//------------------------------------------
//-------------------UNNAMED SHOTGUN
//------------------------------------------


BulletData xShotgunBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.38;
   damageType         = $Shotgun;

   aimDeflection      = 0.007;
   muzzleVelocity     = 999.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};


ItemData xShotgunAmmo
{
	description = "Type 14 Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData xShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; 
	reloadTime = 0.4;
	fireTime = 0.5;
	ammoType = xShotgunAmmo;
	//projectileType = xShotgunBullet;
	accuFire = true;
	mountOffset = {0,-0.2,0};
	mountrotation = {0,-1.57079,0};
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData xShotgun
{
	description = "Undefined Shotgun Object";
	className = "Weapon";
	shapeFile = "shotgun";
   validateshape = false;
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = xShotgunImage;
	price = 200;
	showWeaponBar = true;
};


function xShotgunImage::onFire(%player)
{
%trans = gamebase::getmuzzletransform(%player);
%vel = item::getvelocity(%player);
Player::decitemcount(%player, xShotgunAmmo);
for(%i = 0; %i < 4 + getrandom()*5; %i++) Projectile::SpawnProjectile("xShotgunBullet", %trans, %player, %vel);
gamebase::playsound(%player, MineExplosion, 1);

}