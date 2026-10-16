
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Plasma Gun (PlasmaGun)
//  By Dynamix
//
//  Alliance version by Mjolnir, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[PlasmaGun] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaAmmo] = 1;
$AutoUse[PlasmaGun] = False;
$SellAmmo[PlasmaAmmo] = 5;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

addWeapon(PlasmaGun);
addAmmo(PlasmaGun, PlasmaAmmo, 5);

BulletData PlasmaBolt 
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.35;
  damageType = $FlamerDamageType;
  explosionRadius = 4.0;
  muzzleVelocity = 55.0;
  totalTime = 3.0;
  liveTime = 2.0;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
};

ItemData PlasmaAmmo
{
  description = "Plasma Bolt";
  heading = $InvHead[ihAmm];
  className = "Ammo";
  shapeFile = "plasammo";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData PlasmaGunImage
{
  shapeFile = "plasma";
  mountPoint = 0;
  weaponType = 0;
  ammoType = PlasmaAmmo;
  projectileType = PlasmaBolt;
  accuFire = true;
  reloadTime = 0.1;
  fireTime = 0.5;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 1, 1, 0.2 };
  sfxFire = SoundFirePlasma;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
  description = "Plasma Gun";
  className = "Weapon";
  shapeFile = "plasma";
  hudIcon = "plasma";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = PlasmaGunImage;
  price = 175;
  showWeaponBar = true;
};

function PlasmaGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Plasma Gun: Firing charged energy, on impact its shots burn at extremly high temperatures.");
}

