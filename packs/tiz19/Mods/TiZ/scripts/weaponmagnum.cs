//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  E.R.F.P : modded from magnum
//
//  For installation information, see Install.txt
//  Created by Timer[tiz]
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Silencer] = 1;
$InvList[SilencerAmmo] = 1;
$RemoteInvList[Silencer] = 1;
$RemoteInvList[SilencerAmmo] = 1;
$AutoUse[Silencer] = False;
$SellAmmo[SilencerAmmo] = 25;
$WeaponAmmo[Silencer] = SilencerAmmo;

addWeapon(Silencer);
addAmmo(Silencer, SilencerAmmo, 5);

BulletData SilencerBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = rocketExp;
  expRandCycle = 3;
  mass = 0.05;
  explosionRadius = 2;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.11;
  damageType = $BulletDamageType;
  aimDeflection = 0.0009;
  muzzleVelocity = 625.0;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  tracerPercentage = 100.0;
  tracerLength = 30;
  totalTime = 1.5;
  liveTime = 1.5;
};

ItemData SilencerAmmo 
{
  description = "Pistol Clips";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData SilencerImage 
{
  shapeFile = "energygun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = SilencerAmmo;
  projectileType = SilencerBullet;
  accuFire = false;
  reloadTime = 0;
  fireTime = 0.05;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 0, 0, 0 };
  sfxFire = SoundFireBlaster;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Silencer 
{
  description = "ERFP";
  className = "Weapon";
  shapeFile = "energygun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = SilencerImage;
  price = 375;
  showWeaponBar = true;
};

function Silencer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "ERFP (Explosive Rapid Fire Pistol): The standard weapon of most marines, this weapon is worthy against any foe.");
}
