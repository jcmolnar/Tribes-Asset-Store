//C-10 Canister Rifle used by ghosts
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
  explosionTag = debrisExpSmall;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 0;
  explosionRadius = 4.0;
  damageValue = 2.5;
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
  description = "C-10 Canister";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 10;
};

ItemImageData SniperRifleImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = SniperAmmo;
  projectileType = c10canister;
  accuFire = true;
  reloadTime = 1;
  fireTime = 6.5;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = 
  {
    1.0, 0, 0 }
  ;
  sfxReload = SoundMortarReload;
  sfxFire = debrisSmallExplosion;
  sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
  description = "C-10 Canister Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = SniperRifleImage;
  price = 600;
  showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "C-10 Canister Rifle: <f2>Fires a small canister filled with explosive shrapnel at extremely high speeds, excellent sniper weapon.");
}

function SniperRifle::onDrop(%player,%this)
{
// don't let player drop it, this can create a rapid firing C-10 exploit
}