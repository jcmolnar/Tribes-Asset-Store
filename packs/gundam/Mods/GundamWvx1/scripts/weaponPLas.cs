//energy scythe, colony rebels, L
$InvList[PLasGun] = 1;
$RemoteInvList[PLasGun] = 1;
$AutoUse[PLasGun] = False;
$WeaponAmmo[PLasGun] = "";
$VehicleInvList[PLasGun] = 1;

addWeapon(PLasGun);

RocketData PSlaser
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = TurretExp;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  baseDamageType = $DeathDamageType;
  damageClass = 0;
  damageValue = 1.5;
  explosionRadius = 5.0;
  mass = 0.5;
  collisionRadius = 0.0;
  acceleration = 9.0;
  totalTime = 0.3;
  liveTime = 0.3;
  isVisible = true;
};

ItemImageData PLasGunImage
{
mountRotation = 
{
 -0.4, -2.0, 0 }
;
  shapeFile = "grenadeL";
  mountPoint = 0;
  weaponType = 0;
  minEnergy = 0.1;
  maxEnergy = 1.0;
  projectileType = PSlaser;
  accuFire = true;
  reloadTime = 0.02;
  fireTime = 0.03;
//  lightType = 3;
//  lightRadius = 6;
//  lightTime = 2;
//  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundJetLight;
//  sfxReload = SoundDryFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData PLasGun 
{
  description = "Laser Scythe";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "blaster";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = PLasGunImage;
  price = 250;
  showWeaponBar = true;
};

function PLasGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Energy Scythe: <f2>A powerfull melee weapon.");
}