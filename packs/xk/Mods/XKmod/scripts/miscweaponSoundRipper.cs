$InvList[SoundRipper] = 1;
$InvList[SoundAmmo] = 1;
$RemoteInvList[SoundRipper] = 1;
$RemoteInvList[SoundAmmo] = 1;
$AutoUse[SoundRipper] = True;
$SellAmmo[SoundAmmo] = 2;
$WeaponAmmo[SoundRipper] = SoundAmmo;

addWeapon(SoundRipper);
addAmmo(SoundRipper, SoundAmmo, 5);

RocketData BouncerMissile2 
{
  bulletShapeName = "mortar.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.0;
  damageType = $EnergyDamageType;
  explosionRadius = 30.5;
  kickBackStrength = 850.0;
  muzzleVelocity = 85.0;
  terminalVelocity = 2000.0;
  acceleration = 300.0;
  totalTime = 8.5;
  liveTime = 18.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "shotgunex.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
};

ItemData SoundAmmo
{
  description = "Sound Ripper Ammo";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData SoundRipperImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = SoundAmmo;
  projectileType = BouncerMissile2;
  accuFire = true;
  reloadTime = 1.5;
  fireTime = 0;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundFireWind1;
  sfxActivate = SoundPickUpWeapon;
};

ItemData SoundRipper
{
  description = "Sound Ripper";
  className = "Tool";
  shapeFile = "paintgun";
  hudIcon = "blaster";
  heading = "bMisc. Weapons";
  shadowDetailMask = 4;
  imageType = SoundRipperImage;
  price = 475;
  showWeaponBar = true;
};

function SoundRipper::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Sound Ripper");
}