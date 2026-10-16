//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Assault Cannon
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$AutoUse[Autogun] = False;
$SellAmmo[AutoAmmo] = 100;
$WeaponAmmo[Autogun] = AutoAmmo;
$InvList[Autogun] = 1;
$InvList[AutoAmmo] = 1;
$RemoteInvList[Autogun] = 1;
$RemoteInvList[AutoAmmo] = 1;

addWeapon(Autogun);
addAmmo(Autogun, AutoAmmo, 50);

BulletData AutogunBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.2;
  damageType = $BulletDamageType;
  aimDeflection = 0.002;
  muzzleVelocity = 425.0;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
  totalTime = 4.5;
  liveTime = 4.5;
};

ItemData AutoAmmo 
{
  description = "Bullet";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData AutogunImage 
{
  shapeFile = "TrinAssaultCannon";
  mountPoint = 0;
  weaponType = 1;
  reloadTime = 0;
  spinUpTime = 2.0;
  spinDownTime = 3;
  fireTime = 0.2;
  ammoType = AutoAmmo;
  projectileType = AutogunBullet;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1 };  
  sfxFire = SoundFireChaingun;
  sfxActivate = SoundPickUpWeapon;
  sfxSpinUp = SoundSpinUp;
  sfxSpinDown = SoundSpinDown;
};

ItemData Autogun 
{
  description = "Assault Cannon";
  className = "Weapon";
  shapeFile = "TrinAssaultCannon";
  hudIcon = "chain";
  heading = $InvHead[ihWma];
  shadowDetailMask = 4;
  imageType = AutogunImage;
  price = 525;
  showWeaponBar = true;
};

function Autogun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Assault Cannon: Rapid fire with hard-tipped shells, this is a superior version to it's lighter counterpart.");
}


