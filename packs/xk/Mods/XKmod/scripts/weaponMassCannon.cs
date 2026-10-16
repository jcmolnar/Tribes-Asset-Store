$InvList[MassCannon] = 1;
$RemoteInvList[MassCannon] = 1;
$AutoUse[MassCannon] = True;
$WeaponAmmo[MassCannon] = MassCAmmo;
$SellAmmo[MassCAmmo] = 15;
$InvList[MassCAmmo] = 1;
$RemoteInvList[MassCAmmo] = 1;

addWeapon(MassCannon);
addAmmo(MassCannon, MassCAmmo, 2);

RocketData MassShell
{
  bulletShapeName = "mortar.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 1;
  damageValue = 0.8;
  damageType = $ExplosionDamageType;
  explosionRadius = 8.5;
  kickBackStrength = 600.0;
  muzzleVelocity = 120.0;
  terminalVelocity = 2000.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 11.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  trailType = 1;
  trailLength = 1000.0;
  trailWidth = 0.8;
  inheritedVelocityScale = 0.0;
};

ItemData MassCAmmo 
{
  description = "Flak Shell";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData MassCannonImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = MassCAmmo;
  projectileType = MassShell;
  accuFire = true;
  reloadTime = 1.5;
  fireTime = 0;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundMortarIdle;
};

ItemData MassCannon
{
  description = "Flak Cannon";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = MassCannonImage;
  price = 1500;
  showWeaponBar = true;
};

function MassCannon::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Flak Cannon");
}

