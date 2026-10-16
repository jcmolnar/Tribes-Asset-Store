//Destruction Rifle
$InvList[SniperRifle] = 1;
$RemoteInvList[SniperRifle] = 1;
$VehicleInvList[SniperRifle] = 1;
$VehicleInvList[SniperAmmo] = 1;
$AutoUse[SniperRifle] = False;
$WeaponAmmo[SniperRifle] = SniperAmmo;
$SellAmmo[SniperAmmo] = 15;
$InvList[SniperAmmo] = 1;
$RemoteInvList[SniperAmmo] = 1;

addWeapon(SniperRifle);
addAmmo(SniperRifle, SniperAmmo, 4);

RocketData c10canister
{
  bulletShapeName = "tracer.dts";
  explosionTag = mortarExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 0;
  explosionRadius = 4.0;
  damageValue = 6.5;
  damageType = $SniperDamageType;
  kickBackStrength = 200.0;
  muzzleVelocity = 2000.0;
  terminalVelocity = 2000.0;
  acceleration = 5.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 1.0;
};

ItemData SniperAmmo 
{
  description = "Destruction Bullets";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 100;
};

ItemImageData SniperRifleImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  mountRotation = 
  {
   0, -2.0, 0 }
  ;


  weaponType = 0;
  ammoType = SniperAmmo;
  projectileType = c10canister;
  accuFire = true;
  reloadTime = 0.5;
  fireTime = 7.5;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = 
  {
    1.0, 0, 0 }
  ;
  sfxReload = SoundMortarReload;
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
  description = "Destruction Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = SniperRifleImage;
  price = 1200;
  showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Destruction Rifle: <f2>Fires hightly explosive bullets that can destroy any Gundams in one shot.");
}

function SniperRifle::onDrop(%player,%this)
{
  deleteObject(%this);
}