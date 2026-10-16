
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Vulcan Cannon (Vulcan)
//  By Renegades
//  2000.01.08 : Alazane : Added onMount documentation
//  2000.01.09 : Alazane : Changed values to match R2K (kept old in comments)
//
//  For installation information, see Install.txt & Contrib.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

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
  damageValue = 0.08; // 0.03;
  damageType = $BulletDamageType;
  aimDeflection = 0.005; // 0.001;
  muzzleVelocity = 900.0;
  totalTime = 2; // 1;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 2.0;
  tracerLength = 60;
};

ItemData VulcanAmmo 
{
  description = "Vulcan Bullet";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 1;
};

ItemImageData VulcanImage 
{
  shapeFile = "chaingun";
  mountPoint = 0;
  weaponType = 1;
  reloadTime = 0; //0.1;
  spinUpTime = 0.75; //1.5;
  spinDownTime = 3;
  fireTime = 0.045; //0.05;
  ammoType = VulcanAmmo;
  projectileType = VulcanBullet;
  accuFire = true;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1 };  
  sfxFire = SoundFireChaingun;
  sfxActivate = SoundPickUpWeapon;
  sfxSpinUp = SoundSpinUp;
  sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan
{
  description = "Vulcan";
  className = "Weapon";
  shapeFile = "chaingun";
  hudIcon = "chain";
  heading = "bWeapons";
  shadowDetailMask = 4;
  imageType = VulcanImage;
  price = 125;
  showWeaponBar = true;
};

function Vulcan::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Vulcan.  Shoots a high speed stream of bullets.");
}

