//FeedBack Thingy
$InvList[FBGun] = 1;
$RemoteInvList[FBGun] = 1;
$VehicleInvList[FBGun] = 1;
$VehicleInvList[FBGunAmmo] = 1;
$AutoUse[FBGun] = False;
$WeaponAmmo[FBGun] = FBGunAmmo;
$SellAmmo[FBGunAmmo] = 15;
$InvList[FBGunAmmo] = 1;
$RemoteInvList[FBGunAmmo] = 1;

addWeapon(FBGun);
addAmmo(FBGun, FBGunAmmo, 4);

RocketData FBGunBolt
{
  bulletShapeName = "tracer.dts";
  explosionTag = FeedBackExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 0;
  damageValue = 0.0;
  damageType = $FeedBackDamageType;
  kickBackStrength = 200.0;
  muzzleVelocity = 2000.0;
  terminalVelocity = 2000.0;
  acceleration = 5.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 0.0;
  isVisible = true;
};

ItemData FBGunAmmo 
{
  description = "FeedBack Bolts";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 50;
};

ItemImageData FBGunImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
        mountRotation = 
        {
        0.0, 3.14, 0.0 }//{+up -down, rolling, +left -right}
        ;
  ammoType = FBGunAmmo;
  projectileType = FBGunBolt;
  accuFire = true;
  reloadTime = 0.5;
  fireTime = 5.5;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = 
  {
    1.0, 0, 0 }
  ;
  sfxReload = SoundMortarReload;
  sfxFire = SoundBeaconUse;
  sfxActivate = SoundPickUpWeapon;
};

ItemData FBGun 
{
  description = "FeedBack Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = FBGunImage;
  price = 800;
  showWeaponBar = true;
};

function FBGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Feedback Rifle: <f2>Gets into a target's power supply and uses their energy to cause harm.");
}
