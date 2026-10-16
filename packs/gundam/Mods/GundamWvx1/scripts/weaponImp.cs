//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Web Gun
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Grav] = 1;
$RemoteInvList[Grav] = 1;
$AutoUse[Grav] = False;
$WeaponAmmo[Grav] = "";

addWeapon(Grav);

RocketData GravShot
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $MissileDamageType;

   explosionRadius  = 80.5;
   kickBackStrength = -300.0;
   muzzleVelocity   = 395.0;
   terminalVelocity = 80.0;
   acceleration     = 9.0;
   totalTime        = 10.0;
   liveTime         = 4.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 0.8;

   soundId = MineExplosion;
};

ItemImageData GravImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = GravShot;
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 0.2;
        damageClass = 1;
        damageValue = 0.05;
	minEnergy = 49;
	maxEnergy = 50;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Grav
{
	description = "Web Gun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "energyRifle";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GravImage;
	price = 650;
	showWeaponBar = true;
};

function Grav::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "This weapon is very useful if employed correctly. It pulls its targets toward its explosion, using gravity to their disadvantage.");
}

