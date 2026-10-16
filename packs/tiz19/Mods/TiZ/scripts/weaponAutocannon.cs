
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Auto Cannon
//
//  
//    
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[AutoCannon] = 1;
$RemoteInvList[AutoCannon] = 1;
$AutoUse[AutoCannon] = true;
$WeaponAmmo[AutoCannon] = AutocannonBulletAmmo;
$SellAmmo[AutocannonBulletAmmo] = 20;
$InvList[AutocannonBulletAmmo] = 1;
$RemoteInvList[AutocannonBulletAmmo] = 1;

addWeapon(Autocannon);
addAmmo(Autocannon,AutocannonAmmo,50);

BulletData AutocannonBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.07;
  damageType = $BulletDamageType;
  aimDeflection = 0.001;
  muzzleVelocity = 600.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
};

ItemData AutocannonBulletAmmo 
{
  description = "Autocannon Shells";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 7;
};

ItemImageData AutoCannonImage 
{
  shapeFile = "chaingun";
  mountPoint = 0;
  weaponType = 1;
  reloadTime = 0;
  spinUpTime = 0.3;
  spinDownTime = 1;
  fireTime = 0.05;
  ammoType = AutocannonBulletAmmo;
  projectileType = AutocannonBullet;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = {0.6, 1, 1};
  sfxFire = SoundFireChaingun;
  sfxActivate = SoundPickUpWeapon;
  sfxSpinUp = SoundSpinUp;
  sfxSpinDown = SoundSpinDown;
};

ItemData Autocannon 
{
  description = "AutoCannon";
  className = "Weapon";
  shapeFile = "chaingun";
  hudIcon = "chain";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = AutocannonImage;
  price = 75;
  showWeaponBar = true;
};

function Autocannon::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Autocannon: Designed for the lighter, weaker armors, the Autocannon dishes out bullets at an alarming rate.");
}

