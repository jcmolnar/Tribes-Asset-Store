//-----------------------------------
//Pistol- By Neo -PD Mod
//-----------------------------------
$InvList[Pistol] = 1;
$InvList[PistolAmmo] = 1;
$RemoteInvList[Pistol] = 1;
$RemoteInvList[PistolAmmo] = 1;
$AutoUse[Pistol] = True;
$SellAmmo[PistolAmmo] = 50;
$WeaponAmmo[Pistol] = PistolAmmo;

addWeapon(Pistol);
addAmmo(Pistol, PistolAmmo, 10);

BulletData PistolBullet
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.03;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.100;
  damageType = $LaserDamageType;
  aimDeflection = 0.0013;
  muzzleVelocity = 450.0;
  totalTime = 2.6;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  tracerPercentage = 100.0;
  tracerLength = 25;
};

ItemData PistolAmmo
{
  description = "Clip";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo2";
  shadowDetailMask = 4;
  price = 50;
};

ItemImageData PistolImage
{
  shapeFile = "paintgun";  
  mountRotation = { 0, -360.0, 0 };
  mountPoint = 0;
  weaponType = 0;
  ammoType = PistolAmmo;
  projectileType = PistolBullet;
  accuFire = True;
  reloadTime = 0.2;
  fireTime = 0.2;
  lightType = 3;
  lightRadius = 5;
  lightTime = 3;
  lightColor = { 0, 0, 0 };
  sfxFire = SoundMagnumFire;
  sfxActivate = SoundWeapon5;
};
  
ItemData Pistol
{
  description = "9MM Pistol";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = PistolImage;
  price = 650;
  showWeaponBar = true;
};

function Pistol::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>9MM Pistol");
}


  
  