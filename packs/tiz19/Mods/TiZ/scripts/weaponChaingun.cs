
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Auto Cannon
//  By <[DC]>Paladin
//
//  
//    
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[Chaingun] = 1;
$RemoteInvList[Chaingun] = 1;
$AutoUse[Chaingun] = False;
$WeaponAmmo[Chaingun] = BulletAmmo;
$SellAmmo[BulletAmmo] = 25;
$InvList[BulletAmmo] = 1;
$RemoteInvList[BulletAmmo] = 1;

addWeapon(Chaingun);
addAmmo(ChainGun,BulletAmmo,60);

BulletData ChaingunBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.11;
  damageType = $BulletDamageType;
  aimDeflection = 0.0007;
  muzzleVelocity = 300.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
};

ItemData BulletAmmo 
{
  description = "M-2 Bullets";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 1;
};

ItemImageData ChaingunImage 
{
  shapeFile = "chaingun";
  mountPoint = 0;
  weaponType = 1;
  reloadTime = 0.08;
  spinUpTime = 0.5;
  spinDownTime = 3;
  fireTime = 0.05;
  ammoType = BulletAmmo;
  projectileType = ChaingunBullet;
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

ItemData Chaingun 
{
  description = "Nailgun";
  className = "Weapon";
  shapeFile = "chaingun";
  hudIcon = "chain";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = ChaingunImage;
  price = 125;
  showWeaponBar = true;
};

function Chaingun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Nailgun: Ideal for close combat, the 'Nailer' is meant for base infiltration, and is extremely deadly.");
}
