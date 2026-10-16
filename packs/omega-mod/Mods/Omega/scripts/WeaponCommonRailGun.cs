$ItemMax[larmor, CommonRailGun] = 1;
$ItemMax[lfemale, CommonRailGun] = 1;
$ItemMax[marmor, CommonRailGun] = 1;
$ItemMax[mfemale, CommonRailGun] = 1;
$ItemMax[harmor, CommonRailGun] = 1;

$ItemMax[larmor, CommonRailGunAmmo] = 25;
$ItemMax[lfemale, CommonRailGunAmmo] = 25;
$ItemMax[marmor, CommonRailGunAmmo] = 30;
$ItemMax[mfemale, CommonRailGunAmmo] = 30;
$ItemMax[harmor, CommonRailGunAmmo] = 40;


$InvList[CommonRailGun]=1;
$RemoteInvList[CommonRailGun]=1;

$InvList[CommonRailGunAmmo]=1;
$RemoteInvList[CommonRailGunAmmo]=1;

$AutoUse[CommonRailGun] = false;
$WeaponAmmo[CommonRailGun] = CommonRailGunAmmo;
$AmmoPackMax[CommonRailGunAmmo] = 25; 
$AmmoPackItems[15] = CommonRailGunAmmo;     
$SellAmmo[CommonRailGunAmmo] = 150; 


$CommonRailGunSlotA=4;
$CommonRailGunSlotB=7;

ItemData CommonRailGunAmmo 
{
	description = "22mm Rail Slides"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 300; 
}; 

ItemImageData CommonRailGunImage 
{
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.7; 
	fireTime = 0.7;
	minEnergy = 10;	
	maxEnergy = 10;
	ammoType = CommonRailGunAmmo;
	projectileType = CommonRail;  
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData CommonRailGun
{
	description = "22mm Rail Gun"; 
	className = "Weapon"; 
	shapeFile = "plasma"; 
	hudIcon = "plasma"; 
	heading = bWeapons; 
	shadowDetailMask = 4; 
	imageType = CommonRailGunImage; 
	price = 1800; 
	showWeaponBar = true; 
};

ItemImageData CommonRailGun2Image 
{
	ammoType = CommonRailGunAmmo; 
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountOffset = { 0, 0.2, 0.15 }; 
	mountRotation = { 0, 3.14159, 3.14159 }; 
	weaponType = 0; 
	reloadTime = 0.1;
                fireTime = 0.1;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData CommonRailGun2 
{
	description = "CommonRailGun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = CommonRailGun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function CommonRailGunImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,CommonRailGunammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("CommonRail",%trans,%player,%vel,%player); 
}



function CommonRailGun::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, CommonRailGun2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CommonRailGun::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,CommonRailGun2,$CommonRailGunSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc><f2>The 22m Rail Gun fires a small round (22m) that is on fire and contains a small explosive head. Another very good sniping weapon  ");
}

function CommonRailGun::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$CommonRailGunSlotA);
}


//--------------------------------------
BulletData CommonRail
{
   bulletShapeName    = "plasmatrail.dts";
   validateShape      = true;
   explosionTag       = RailExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $RGDamageType;

   explosionRadius  = 3;
   aimDeflection      = 0;
   muzzleVelocity     = 1000;
   totalTime          = 10.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

};
