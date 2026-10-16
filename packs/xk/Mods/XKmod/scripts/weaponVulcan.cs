$AutoUse[Vulcan] = True;
$SellAmmo[VulcanAmmo] = 100;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$InvList[Vulcan] = 1;
$InvList[VulcanAmmo] = 1;
$RemoteInvList[Vulcan] = 1;
$RemoteInvList[VulcanAmmo] = 1;

addWeapon(Vulcan);
addAmmo(Vulcan, VulcanAmmo, 50);

BulletData VulcanBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.03;
  damageType = $BulletDamageType;
  aimDeflection = 0.010;
  muzzleVelocity = 900.0;
  totalTime = 1;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 2.0;
  tracerLength = 60;
};

ItemData VulcanAmmo 
{
  description = "Machine Gun Bullet";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 1;
};

ItemImageData VulcanImage 
{
  shapeFile = "grenadeL";
  mountPoint = 0;
  weaponType = 1;
  reloadTime = 0.1;
  spinUpTime = 1.5;
  spinDownTime = 3;
  fireTime = 0.05;
  ammoType = VulcanAmmo;
  projectileType = VulcanBullet;
  accuFire = true;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1 };  
  sfxFire = SoundFireChaingun;
  sfxActivate = SoundWeapon5;
  sfxSpinUp = SoundSpinUp;
  sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan 
{
  description = "Machine Gun";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "chain";
  heading = "cWeapons";
  shadowDetailMask = 4;
  imageType = VulcanImage;
  price = 125;
  showWeaponBar = true;
};

function Vulcan::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Machine Gun");
}
