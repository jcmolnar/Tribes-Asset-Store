//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Shock Bolt
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[DCannon] = 1;
$RemoteInvList[DCannon] = 1;
$AutoUse[DCannon] = True;
$WeaponAmmo[DCannon] = "";

addWeapon(DCannon);

RocketData DCannonShell
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $PsiDamageType;

   explosionRadius  = 80.5;
   kickBackStrength = 300.0;
   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;
   totalTime        = 20.0;
   liveTime         = 20.0;
   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 5.0 };
   inheritedVelocityScale = 0.5;
   soundId = MineExplosion;
};

ItemImageData DCannonImage
{
	shapeFile = "sensor_small";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = DCannonShell;
	accuFire = true;
	reloadTime = 6.0;
	fireTime = 1.0;
        damageClass = 1;
        damageValue = 0.3;
	minEnergy = 90;
	maxEnergy = 100;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DCannon
{
	description = "Erupt";
	className = "Weapon";
	shapeFile = "sensor_small";
	hudIcon = "energyRifle";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = DCannonImage;
	price = 2650;
	showWeaponBar = true;
};

function DCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "This psionic power takes a lot of psy to use, though it will definitely leave a lasting impression on your enemies.");
}

function DCannon::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == MindPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must concentrate to use Erupt."); }
