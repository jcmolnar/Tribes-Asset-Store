//RPG, vulture, M
$InvList[RocketLauncher] = 1;
$InvList[RocketAmmo] = 1;
$RemoteInvList[RocketLauncher] = 1;
$RemoteInvList[RocketAmmo] = 1;
$VehicleInvList[RocketLauncher] = 1;
$VehicleInvList[RocketAmmo] = 1;
$AutoUse[RocketLauncher] = False;
$SellAmmo[RocketAmmo] = 3;
$WeaponAmmo[RocketLauncher] = RocketAmmo;

addWeapon(RocketLauncher);
addAmmo(RocketLauncher, RocketAmmo, 1);

RocketData HandHeldRPG
{
  bulletShapeName = "mortar.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 1.25;
  damageType = $MissileDamageType;
  explosionRadius = 17.5;
  kickBackStrength = 300.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 2000.0;
  acceleration = 200.0;
  totalTime = 6.5;
  liveTime = 10.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "chainspk.dts";
  smokeDist = 1.0;
};

ItemData RocketAmmo 
{
  description = "RPGs";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "rocket";
  shadowDetailMask = 4;
  price = 25;
};

ItemImageData RocketImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = RocketAmmo;
  projectileType = HandHeldRPG;
        mountRotation = 
        {
        0, -1.57, 0 }
        ;
  accuFire = true;
  reloadTime = 1.0;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundMissileTurretFire;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData RocketLauncher 
{
  description = "RPG Launcher";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = RocketImage;
  price = 650;
  showWeaponBar = true;
};

function RocketLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "RPG Launcher: <f2>'Rocket Propelled Grenade Launcher', this is the frag grens, with a twist.");
}
