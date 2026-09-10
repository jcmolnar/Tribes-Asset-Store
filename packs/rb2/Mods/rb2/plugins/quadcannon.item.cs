// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 
 
addPluginWeapon(LaserRifle, QuadCannon); 
$AutoUse[QuadCannon] = true; 
$WeaponAmmo[QuadCannon] = ""; 
 
$ItemMax[hlarmor, QuadCannon] = 0; 
$ItemMax[hlfemale, QuadCannon] = 0; 
$ItemMax[larmor, QuadCannon] = 0; 
$ItemMax[lfemale, QuadCannon] = 0; 
$ItemMax[earmor, QuadCannon] = 0; 
$ItemMax[efemale, QuadCannon] = 0; 
$ItemMax[marmor, QuadCannon] = 0; 
$ItemMax[mfemale, QuadCannon] = 0; 
$ItemMax[harmor, QuadCannon] = 0; 
$ItemMax[uharmor, QuadCannon] = 0; 
 
$InvList[QuadCannon] = 0; 
$RemoteInvList[QuadCannon] = 0; 
 
$HelpMessage[QuadCannon] = "Not available from any inventory stations"; 
  

BulletData QuadCannonBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = BigBulletExp;
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 1.00; 
	damageType = $BulletDmgType32; 
	aimDeflection = 0.001; 
	muzzleVelocity = 1500; 
	totaltime = 2.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.0; 
	isVisible = false; 
     	soundId = SoundJetHeavy;
	tracerPercentage = 0.2; 
	tracerLength = 100; 
}; 
 
ItemImageData QuadCannonImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	// projectileType = QuadCannonBullet; 
	spinUpTime = 0.0;
	spinDownTime = 0.2;
        minEnergy = 1;
        maxEnergy = 1;
 
	aimDeflection = 0.001; 
	accuFire = True; 
	reloadTime = 0; 
	fireTime = 0.4; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = turretexplosion; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData QuadCannon 
{ 
	description = "QuadCannon"; 
	className = weapon; 
	shapefile = "sniper"; 
	hudIcon = "sniper"; 
	heading = "bPrimary Weapons"; 
	shadowDetailMask = 4; 
	imageType = QuadCannonImage; 
	price = 200; 
	showWeaponBar = true; 
}; 
 
function QuadCannon::onUse(%player, %item) 
{ 
	%clientId = Player::getClient(%player); 
	if (%clientId.pacified == 1) 
		Client::sendMessage(%clientId,0,"Can't arm weapons when affected by tear gas!"); 
	else 
	{ 
		weapon::onUse(%player, %item); 
		%player.shotcycle = 5;
		bottomprint(Player::getClient(%player), "<jc><f2>Using 60mm heavy cannon - Watch the bodies fly!", 2); 
	} 
} 
// Created by the Reality Bites Weapon Creation Utility by Deadtaco 
// Version 0.5 alpha - Incomplete version 
// Please visit www.cfareno.com/reality for more information 


function QuadCannonImage::onFire(%player, %slot) 
{
			
			schedule("ixApplyKickback(" @ %player @ ", 900, 370);", 0.1);
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
			schedule("SecondShotQuad(" @ %player @ ", 7);", 0.1);
			schedule("SecondShotQuad(" @ %player @ ", 5);", 0.2);
			schedule("SecondShotQuad(" @ %player @ ", 6);", 0.3);
	

}
 
function SecondshotQuad(%player, %cycle)
{
			Player::trigger(%player,%cycle,true);    
			Player::trigger(%player,%cycle,false);   
			%client = GameBase::getOwnerClient(%player);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			%fired = (Projectile::spawnProjectile("QuadCannonBullet",%trans,%player,%vel));
}


// --------------------------------------extended model info--------------------------------------









ItemImageData QUADScopeImage
{
	shapeFile  = "sniper";
	mountPoint = 0;
	// mountRotation = { 0, 0, 3.14 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.0, 0.6 };
        minEnergy = 1;
        maxEnergy = 1;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = QuadCannonBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};


ItemData QUADScope
{
	heading = "cSecondary Weapons";
	description = "";
	className = "Weapon";
	shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = QUADScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData QUADClipImage
{
	shapeFile  = "Sniper";
	mountPoint = 0;
	// mountRotation = {0, 3.14, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.8, -0.0, 0.0 };

        minEnergy = 1;
        maxEnergy = 1;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = QuadCannonBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData QUADClip
{
	heading = "cSecondary Weapons";
	description = "";
	className = "Weapon";
	shapeFile  = "Sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = QUADClipImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData QUADMountImage
{
	shapeFile  = "Sniper";
	mountPoint = 0;
	// mountRotation = {0, 0, 3.14 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.8, 0.0, 0.6 };

        minEnergy = 1;
        maxEnergy = 1;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = QuadCannonBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData QUADMount
{
	heading = "cSecondary Weapons";
	description = "QUADClip";
	className = "Weapon";
	shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = QUADMountImage;
	price = 50;
	showWeaponBar = true;
};

function QUADCannon::onMount(%player,%item)
{
	Player::MountItem(%player,QUADMount,5);
	Player::MountItem(%player,QUADScope,7);
	Player::MountItem(%player,QUADClip,6);
}
function QUADCannon::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
	Player::UnMountItem(%player,5);
}


$InvList[QUADMount] = 0; 
$RemoteInvList[QUADMount] = 0; 
$InvList[QUADScope] = 0; 
$RemoteInvList[QUADScope] = 0;
$InvList[QUADClip] = 0; 
$RemoteInvList[QUADClip] = 0; 
