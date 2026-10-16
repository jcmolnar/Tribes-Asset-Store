
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Breaker (Breaker)
//  By Psycho Dragons
//
//  Psycho Dragons version by King Shit and Neo, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[Breaker] = 1;
$RemoteInvList[Breaker] = 1;
$AutoUse[Breaker] = True;
$Use[Breaker] = True;
$WeaponAmmo[Breaker] = "";

addWeapon(Breaker);

GrenadeData BreakerShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag = RocketExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 1.0;
  damageType = $ElectricityDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 375;
  totalTime = 30.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "fusionBolt.dts";
};

ItemImageData BreakerImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = BreakerAmmo;
  projectileType = BreakerShell;
  accuFire = false;
  reloadTime = 0.5;
  fireTime = 0.3;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData Breaker 
{
  description = "Fusion Disrupter";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = BreakerImage;
  price = 575;
  showWeaponBar = true;
};

function Breaker::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Fusion Disrupter");
}
