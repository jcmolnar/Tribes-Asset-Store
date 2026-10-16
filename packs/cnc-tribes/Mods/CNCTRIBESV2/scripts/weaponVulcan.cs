//Heavy Auto Cannon
$AutoUse[Vulcan] = False;
$SellAmmo[VulcanAmmo] = 100;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$InvList[Vulcan] = 1;
$InvList[VulcanAmmo] = 1;
$RemoteInvList[Vulcan] = 1;
$RemoteInvList[VulcanAmmo] = 1;
$VehicleInvList[Vulcan] = 1;
$VehicleInvList[VulcanAmmo] = 1;

addWeapon(Vulcan);
addAmmo(Vulcan, VulcanAmmo, 50);

GrenadeData VulcanGren
{
  bulletShapeName = "Paint.dts";
  explosionTag = rocketExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.45;
  damageType = $FlamerDamageType;
  explosionRadius = 15;
  kickBackStrength = 0;
  maxLevelFlightDist = 200;
  totalTime = 5.0;
  liveTime = 0.05;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "enex.dts";
  smokeDist = 1.5;
};

ItemData VulcanAmmo 
{
  description = "Heavy Autocannon Cartridges";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihDSe];
  shadowDetailMask = 4;
  price = 1;
};

ItemImageData VulcanImage 
{
  shapeFile = "bizon";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.2;
  fireTime = 0.14;
  ammoType = VulcanAmmo;
  projectileType = VulcanGren;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1 };  
  sfxFire = SoundJetHeavy;
  sfxReload = SoundDryFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Vulcan 
{
  description = "Heavy Autocannon";
  className = "Weapon";
  shapeFile = "bizon";
  hudIcon = "chain";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = VulcanImage;
  price = 475;
  showWeaponBar = true;
};

function Vulcan::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Heavy Autocannon: <f2>Fires short range 150mm shells at a high rate of fire.");
}

