//----------------------------------
// BFG 10k by Neo, {FK} Mod
//{FK} Made from Rocket Launcher
//----------------------------------

$InvList[RocketLauncher] = 1;
$InvList[RocketAmmo] = 1;
$RemoteInvList[RocketLauncher] = 1;
$RemoteInvList[RocketAmmo] = 1;
$AutoUse[RocketLauncher] = True;
$SellAmmo[RocketAmmo] = 3;
$WeaponAmmo[RocketLauncher] = RocketAmmo;

addWeapon(RocketLauncher);
addAmmo(RocketLauncher, RocketAmmo, 1);

RocketData StingerMissile 
{
  bulletShapeName = "paint.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.5;
  damageType = $ExplosionDamageType;
  explosionRadius = 30.5;
  kickBackStrength = 850.0;
  muzzleVelocity = 405.0;
  terminalVelocity = 700.0;
  acceleration = 800.0;
  totalTime = 18.5;
  liveTime = 18.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "plasmatrail.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
};

ItemData RocketAmmo 
{
  description = "BFG Cells";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "fusionbolt";
  shadowDetailMask = 4;
  price = 50;
};

ItemImageData RocketImage 
{
  shapeFile = "mortargun";
  mountRotation = { 0, 360.0, 0 };
  mountPoint = 0;
  weaponType = 0;
  ammoType = RocketAmmo;
  projectileType = StingerMissile;
  accuFire = true;
  reloadTime = 1.9;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundCoolExplosion;
  sfxActivate = SoundRMTurret;
  sfxReload = SoundFailPack;
  sfxReady = SoundWeapon5;
};

ItemData RocketLauncher 
{
  description = "BFG 10000";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = RocketImage;
  price = 850;
  showWeaponBar = true;
};

function RocketLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>BFG 10k");
}
