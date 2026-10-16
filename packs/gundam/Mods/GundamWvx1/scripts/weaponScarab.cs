//Death Bringer, Colony Rebels, H
$InvList[Warp] = 1;
$InvList[WarpAmmo] = 1;
$RemoteInvList[Warp] = 1;
$RemoteInvList[WarpAmmo] = 1;
$VehicleInvList[Warp] = 1;
$VehicleInvList[WarpAmmo] = 1;
$AutoUse[Warp] = False;
$SellAmmo[WarpAmmo] = 2;
$WeaponAmmo[Warp] = WarpAmmo;

addWeapon(Warp);
addAmmo(Warp, WarpAmmo, 2);

//=====================================================================//=== Tactical Nuke Shell

RocketData ScarabH
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = DCannonBoom;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 1.6;
  baseDamageType = $MortarDamageType;
  explosionRadius = 25.0;
  kickBackStrength = 450.0;
  muzzleVelocity = 80.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 15.0;
  liveTime = 15.0;
  lightRange = 10.0;
  lightColor = { 1.0, 6.7, 9.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "HFlame.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
};

//=====================================================================//=== Warp Launcher

ItemData WarpAmmo
{
	description = "Death Fusion Bolts";
	className = "Ammo";
   heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 200;
};

ItemImageData WarpImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = WarpAmmo;
	projectileType = ScarabH;
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 4.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundJetLight;
	sfxReady = SoundJammerOn;
};

ItemData Warp
{
	description = "Death Bringer";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "ammopack";
    heading = $InvHead[ihWet];
	shadowDetailMask = 4;
	imageType = WarpImage;
	price = 1000;
	showWeaponBar = true;
};


function Warp::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Death Bringer: <f2>A powerfull weapon for the Colony Rebels. It has a big shockwave explosion.");
}
