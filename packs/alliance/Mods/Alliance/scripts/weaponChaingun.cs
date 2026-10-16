
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Chaingun (Chaingun)
//  By Dynamix
//  xxxx.xx.xx : Mjolnir : Alliance port
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[Chaingun] = 1;
$RemoteInvList[Chaingun] = 1;
$AutoUse[Chaingun] = True;
$WeaponAmmo[Chaingun] = BulletAmmo;
$SellAmmo[BulletAmmo] = 25;
$InvList[BulletAmmo] = 1;
$RemoteInvList[BulletAmmo] = 1;

addWeapon(Chaingun);
addAmmo(ChainGun,BulletAmmo,20);

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
  aimDeflection = 0.003;
  muzzleVelocity = 425.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
};

ItemData BulletAmmo 
{
  description = "Bullet";
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
  reloadTime = 0;
  spinUpTime = 0.5;
  spinDownTime = 3;
  fireTime = 0.2;
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
  description = "Chaingun";
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
  Bottomprint(%client, "Chain Gun.  Shoots a medium speed stream of bullets.");
}

