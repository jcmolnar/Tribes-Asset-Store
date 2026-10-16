
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Mass Driver (MassDriver)
//  By Alazane
//  xxxx.xx.xx : Mjolnir : Tweeked
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[MassDriver] = 1;
$RemoteInvList[MassDriver] = 1;
$AutoUse[MassDriver] = True;
$WeaponAmmo[MassDriver] = MassAmmo;
$SellAmmo[MassAmmo] = 15;
$InvList[MassAmmo] = 1;
$RemoteInvList[MassAmmo] = 1;

addWeapon(MassDriver);
addAmmo(MassDriver, MassAmmo, 2);

RocketData Mass
{
  bulletShapeName = "mortar.dts";
  explosionTag = energyExp;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 0;
  damageValue = 0.5;
  damageType = $SniperDamageType;
  explosionRadius = 0.1;
  kickBackStrength = 600.0;
  muzzleVelocity = 120.0;
  terminalVelocity = 2000.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 11.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  trailType = 1;
  trailLength = 10;
  trailWidth = 0.4;
  inheritedVelocityScale = 0.0;
};

ItemData MassAmmo 
{
  description = "Mass Shell";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData MassDriverImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = MassAmmo;
  projectileType = Mass;
  accuFire = true;
  reloadTime = 0.5;
  fireTime = 0;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundMortarIdle;
};

ItemData MassDriver
{
  description = "Mass Driver";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = MassDriverImage;
  price = 375;
  showWeaponBar = true;
};

function MassDriver::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Mass Driver.  Lauches massive bolts precisely at target.");
}

