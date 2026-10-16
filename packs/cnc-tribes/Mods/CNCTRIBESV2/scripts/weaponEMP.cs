//Bazooka
$InvList[EMP] = 1;
$InvList[EMPAmmo] = 1;
$RemoteInvList[EMP] = 1;
$RemoteInvList[EMPAmmo] = 1;
$VehicleInvList[EMP] = 1;
$VehicleInvList[EMPAmmo] = 1;
$AutoUse[EMP] = False;
$SellAmmo[EMPAmmo] = 5;
$WeaponAmmo[EMP] = EMPAmmo;

addWeapon(EMP);
addAmmo(EMP, EMPAmmo, 2);

RocketData phaserokkit
{
  bulletShapeName = "rocket2.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  explosionRadius = 10;
  damageValue = 6.45;
  damageType = $DeathDamageType;
  kickBackStrength = 50.0;
  muzzleVelocity = 55.0;
  terminalVelocity = 90.0;
  acceleration = 1.9;
  totalTime = 9.0;
  liveTime = 10.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 1.0;
  trailType = 2;
  trailString = "smoke.dts";
  smokeDist = 0.5;
};


ItemData EMPAmmo
{
	description = "Unguided Rockets";
	className = "Ammo";
	shapeFile = "rocket2";
   heading = $InvHead[ihDSe];
	shadowDetailMask = 4;
	price = 8;
};

ItemImageData EMPImage
{
	shapeFile = "bazooka";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = EMPAmmo;
	projectileType = phaserokkit;
	accuFire = false;
	reloadTime = 3.6;
	fireTime = 3.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData EMP
{
	description = "Bazooka";
	className = "Weapon";
	shapeFile = "bazooka";
	hudIcon = "energygun";
   heading = $InvHead[ihScv];
	shadowDetailMask = 4;
	imageType = EMPImage;
	price = 450;
	showWeaponBar = true;
};

function EMP::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Bazzoka: <f2>Fires VERY powerful rockets that can take out turrets in very few shots.");
}


