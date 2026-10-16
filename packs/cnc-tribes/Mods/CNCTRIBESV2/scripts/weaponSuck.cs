//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Gravity Burst
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Gravi] = 1;
$RemoteInvList[Gravi] = 1;
$AutoUse[Gravi] = True;
$WeaponAmmo[Gravi] = "";

addWeapon(Gravi);

RocketData GraviShot
{
   bulletShapeName  = "plasmawall.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $PsiDamageType;

   explosionRadius  = 120.5;
   kickBackStrength = -700.0;
   muzzleVelocity   = 395.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 10.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   soundId = MineExplosion;
};

ItemImageData GraviImage
{
	shapeFile = "sensor_small";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = GraviShot;
	accuFire = true;
	reloadTime = 8.0;
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

ItemData Gravi
{
	description = "Implode";
	className = "Weapon";
	shapeFile = "sensor_small";
	hudIcon = "energyRifle";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = GraviImage;
	price = 1650;
	showWeaponBar = true;
};

function Gravi::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "This power sucks targets toward the source point of impact.");
}

function Gravi::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == MindPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must concentrate to use Implode."); }
