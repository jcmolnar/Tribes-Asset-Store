//--------------------------------------

$AutoUse[Mortar] = True;
$SellAmmo[MortarAmmo] = 1;
$AmmoPackMax[MortarAmmo] = 1;
$AmmoPackItems[1] = MortarAmmo;
$WeaponAmmo[Mortar] = Mortar;

//--------------------------------------

$InvList[Mortar] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[Mortar] = 1;
$RemoteInvList[MortarAmmo] = 1;

//--------------------------------------
GrenadeData RPGShell
{
   bulletShapeName    = "chainspk.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 999.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 4000;
   totalTime          = 10.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";
	smokeDist = 999.0;
   
soundId = SoundJetHeavy;

};

//--------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = RPGShell;
	accuFire = false;
	reloadTime = 5.15;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0, 0 };

	sfxFire = bigExplosion3;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundPickUpWeapon;
	sfxReady = SoundDryFire;
};

ItemData Mortar
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

ItemImageData Mortar2Image 
{
	shapeFile = "grenadeL";
	mountPoint = 0;
      mountRotation = { 0, 0,-3.14 };
	mountOffset = { 0, -0.7, 0 };
	weaponType = 0;
	accuFire = true;
};

ItemData Mortar2
{
	description = "Rocket Launcher";
	shapeFile = "grenadeL";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = Mortar2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

ItemImageData MortarShieldImage 
{
	shapeFile = "discammo";
	mountPoint = 0;
      mountRotation = { -1.57, 0, 0 };
	mountOffset = { 0, 0.7, 0 };
	weaponType = 0;
	accuFire = true;
};

ItemData MortarShield
{
	description = "RocketGrenade";
	shapeFile = "discammo";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = Mortar2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};


function Mortar::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,Mortar2,4);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Rocket");
}

function Mortar::onUnmount(%player,%item)
{
	Player::unmountItem(%player,4);
}
//--------------------------------------