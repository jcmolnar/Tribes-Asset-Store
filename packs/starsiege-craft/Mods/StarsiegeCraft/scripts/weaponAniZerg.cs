//Ani Zerg Launcher, all, terran
$InvList[AniZergLauncher] = 1;
$InvList[AniZergAmmo] = 1;
$RemoteInvList[AniZergLauncher] = 1;
$RemoteInvList[AniZergAmmo] = 1;
$VehicleInvList[AniZergLauncher] = 1;
$VehicleInvList[AniZergAmmo] = 1;
$AutoUse[AniZergLauncher] = False;
$SellAmmo[AniZergAmmo] = 3;
$WeaponAmmo[AniZergLauncher] = AniZergAmmo;

addWeapon(AniZergLauncher);
addAmmo(AniZergLauncher, AniZergAmmo, 1);

GrenadeData AniZergBomb
{
  bulletShapeName = "Mortar.dts";
  explosionTag = turretExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.05;
  damageClass = 1;
  damageValue = 0.25;
  damageType = $DDamageType;
  explosionRadius = 10;
  kickBackStrength = 300.0;
  maxLevelFlightDist = 150;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
};


ItemData AniZergAmmo 
{
  description = "Terran Spore Bombs";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "rocket";
  shadowDetailMask = 4;
  price = 25;
};

ItemImageData AniZergImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = AniZergAmmo;
  projectileType = AniZergBomb;
  accuFire = true;
  reloadTime = 2.0;
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

ItemData AniZergLauncher 
{
  description = "Spore Demetabolizer";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = AniZergImage;
  price = 650;
  showWeaponBar = true;
};

function AniZergLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Spore Demetabolizer: <f2>This weapon breaks the bonds of Zerg molecules, instantly ending a Zerg's life.");
}
