$InvList[Flamer] = 1;
$RemoteInvList[Flamer] = 1;
$WeaponAmmo[Flamer] = "";
$AutoUse[Flamer] = True;

addWeapon(Flamer);

BulletData FlamerBolt 
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.06;
  damageType = $PlasmaDamageType;
  explosionRadius = 4.0;
  muzzleVelocity = 30.0;
  totalTime = 0.75;
  liveTime = 0.75;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};
ItemImageData FlamerImage 
{
  shapeFile = "GrenadeL";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.05;
  fireTime = 0.10;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = FlamerBolt;
  accuFire = true;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};
ItemData Flamer 
{
  heading = $InvHead[ihWea];
  description = "Flame Thrower";
  className = "Weapon";
  shapeFile = "GrenadeL";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = FlamerImage;
  price = 385;
  showWeaponBar = true;
};
