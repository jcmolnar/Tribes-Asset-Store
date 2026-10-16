//phase cannon, toss, M
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
  bulletShapeName = "mortar.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  explosionRadius = 15;
  damageValue = 1.0;
  damageType = $DeathDamageType;
  kickBackStrength = 200.0;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  acceleration = 5.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 1.0;
  trailType = 2;
  trailString = "paint.dts";
  smokeDist = 0.5;
};


ItemData EMPAmmo
{
	description = "Phase charges";
	className = "Ammo";
	shapeFile = "Ammo2";
   heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 8;
};

ItemImageData EMPImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = EMPAmmo;
	projectileType = phaserokkit;
	accuFire = false;
	reloadTime = 1.5;
	fireTime = 1.5;

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
	description = "Phase Cannon";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "plasma";
   heading = $InvHead[ihWet];
	shadowDetailMask = 4;
	imageType = EMPImage;
	price = 450;
	showWeaponBar = true;
};

function EMP::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Phase Disruptor Cannon: <f2>fires a concentrated fusion surge at enemies.");
}


