//----Armordata.cs stuff
$ItemMax[larmor, PaintBallGun] = 1;
$ItemMax[lfemale, PaintBallGun] = 1;
$ItemMax[marmor, PaintBallGun] = 0;
$ItemMax[mfemale, PaintBallGun] = 0;
$ItemMax[harmor, PaintBallGun] = 0;
//---Ammo
$ItemMax[larmor, PaintBallGunAmmo] = 200;
$ItemMax[lfemale, PaintBallGunAmmo] = 200;
$ItemMax[marmor, PaintBallGunAmmo] = 0;
$ItemMax[mfemale, PaintBallGunAmmo] = 0;
$ItemMax[harmor, PaintBallGunAmmo] = 0;
//-----Baseprojdata.cs
BulletData TinyPaintBall
{
   bulletShapeName    = "chainspk.dts";
   explosionTag       = paintballExp;

   damageClass        = 0;
   damageValue        = 0;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 66.66;
   totalTime          = 2.5;
   liveTime           = 2.5;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};

$InvList[PaintBallGun]=1;
$RemoteInvList[PaintBallGun]=1;

$InvList[PaintBallGunAmmo]=1;
$RemoteInvList[PaintBallGunAmmo]=1;

$AutoUse[PaintBallGun] = false;
$WeaponAmmo[PaintBallGun] = PaintBallGunAmmo;
$AmmoPackMax[PaintBallGunAmmo] = 300; 
$AmmoPackItems[15] = PaintBallGunAmmo;     
$SellAmmo[PaintBallGunAmmo] = 50; 


$PaintBallGunSlotA=4;
$PaintBallGunSlotB=7;

ItemData PaintBallGunAmmo 
{
	description = "Paintball Pods"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = xAmmunition; 
	shadowDetailMask = 4; 
	price = 30; 
}; 

ItemImageData PaintBallGunImage 
{
	shapeFile = "energygun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 3.14159, 0 }; 
	weaponType = 0; 
	reloadTime = 0.0434; 
	fireTime = 0.0434;
	ammoType = PaintBallGunAmmo;
	projectileType = TinyPaintBall;  
	accuFire = true; 
	sfxFire = SoundMortarReload; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReady = SoundMortarIdle;
}; 

ItemData PaintBallGun
{
	description = "Angel LCD Paintball Gun"; 
	className = "Weapon"; 
	shapeFile = "plasma"; 
	hudIcon = "ammopack"; 
	heading = zSpecial; 
	shadowDetailMask = 4; 
	imageType = PaintBallGunImage; 
	price = 360; 
	showWeaponBar = true; 
};

ItemImageData PaintBallGun2Image 
{
	ammoType = PaintBallGunAmmo; 
	projectileType = TinyPaintBall; 
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 0.0434;
                fireTime = 0.0434;
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData PaintBallGun2 
{
	description = "PaintBallGun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	shadowDetailMask = 4; 
	imageType = PaintBallGun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

function PaintBallGunImage::onFire(%player, %slot) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,PaintBallGunammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("TinyPaintBall",%trans,%player,%vel,%player);
		
}

function PaintBallGun::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, PaintBallGun2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function PaintBallGun::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,PaintBallGun2,$PaintBallGunSlotA); 
	%clientId = Player::getclient(%player);
		bottomprint(%clientId, "<jc><f2>S<f1>p<f3>l<f2>a<f3>t<f2>: Color the other team up in paint with this fast firing <f1>w<f2>h<f3>o<f1>r<f2>e <f1>....Specs By <f2>+<f1>]<f3>-<f1>[<f2>+<f1>S<f2>p<f3>]<f1>[<f2>k<f3>e ");
}

function PaintBallGun::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$PaintBallGunSlotA);
}
