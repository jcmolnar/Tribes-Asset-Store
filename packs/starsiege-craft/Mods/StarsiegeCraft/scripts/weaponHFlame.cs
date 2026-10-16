//Heavy Flame Thrower, Terran, M
$InvList[HFlame] = 1;
$InvList[HFlameAmmo] = 1;
$RemoteInvList[HFlame] = 1;
$RemoteInvList[HFlameAmmo] = 1;
$VehicleInvList[HFlame] = 1;
$VehicleInvList[HFlameAmmo] = 1;
$AutoUse[HFlame] = True;
$SellAmmo[HFlameAmmo] = 50;
$WeaponAmmo[HFlame] = HFlameAmmo;

addWeapon(HFlame);
addAmmo(HFlame, HFlameAmmo, 50);

GrenadeData HFlamegren
{
  bulletShapeName = "PlasmaBolt.dts";
  explosionTag = PlasmaExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.18;
  damageType = $FlamerDamageType;
  explosionRadius = 13;
  kickBackStrength = 2;
  maxLevelFlightDist = 120;
  totalTime = 5.0;
  liveTime = 0.001;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "plasmaex.dts";
  smokeDist = 15.0;
};

ItemData HFlameAmmo 
{
  description = "Heavy Flame Cartridges";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 10;
};

ItemImageData HFlameImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = HFlameAmmo;
  projectileType = HFlameGren;
  accuFire = false;
  reloadTime = 0.1;
  fireTime = 0.2;
  lightType = 3;
  lightRadius = 4;
  lightTime = 1;
  lightColor = { 1, 0, 0 };
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData HFlame 
{
  description = "Heavy Flame Thrower";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = HFLameImage;
  price = 325;
  showWeaponBar = true;
};

function HFlame::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Heavy Flame Thrower: <f2>A nuclear fusion furnace drives this new, more powerful flamer.");
}
