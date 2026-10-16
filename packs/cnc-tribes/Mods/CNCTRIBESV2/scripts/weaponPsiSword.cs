//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Psionic Blade
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Sword] = 1;
$RemoteInvList[Sword] = 1;
$WeaponAmmo[Sword] = "";
$AutoUse[Sword] = True;

addWeapon(Sword);

BulletData SwordBolt 
{
  bulletShapeName = "bullet.dts";
  explosionTag = SwordHit;
  damageClass = 0;
  damageValue = 0.2;
  damageType = $ExplosionDamageType;
  muzzleVelocity = 25.125;
  totalTime = 0.08;
  liveTime = 0.08;
  lightRange = 3;
  lightColor = { 0, 0, 1 };
  inheritedVelocityScale = 0.0;
  isVisible = false;
  soundId = undefined;
};
ItemImageData SwordImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.2;
  fireTime = 0.28;
  minEnergy = 1;
  maxEnergy = 2;
  projectileType = SwordBolt;
  accuFire = true;
  sfxFire = ForceFieldClose;
  sfxActivate = ForceFieldOpen;
  sfxReady = SoundLaserIdle;
  lightType = 2;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0, 0, 1 };

};
ItemData Sword 
{
  heading = $InvHead[ihWma];
  description = "Power Sword";
  className = "Tool";
  shapeFile = "sniper";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = SwordImage;
  price = 185;
  showWeaponBar = true;
};

function Sword::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Power Sword: This energy charged blade can cut through almost any material with relative ease.");
}
