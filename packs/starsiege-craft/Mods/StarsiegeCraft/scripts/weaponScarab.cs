//scarab launcher, toss, H
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
  damageValue = 2.0;
  DamageType = $MortarDamageType;
  explosionRadius = 30.0;
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
  trailString = "fusionex.dts";
  smokeDist = 4;
  soundId = SoundJetHeavy;
};

//=====================================================================//=== Warp Launcher

ItemData WarpAmmo
{
	description = "Scarabs";
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
	description = "Scarab Cannon";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "ammopack";
    heading = $InvHead[ihWet];
	shadowDetailMask = 4;
	imageType = WarpImage;
	price = 800;
	showWeaponBar = true;
};


function Warp::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Scarab Cannon: <f2>a very close attempt at a fire-and-forget weapon, this flaunts the best of Protoss' Destruction skills.");
}
