//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Plasma cannon: modded from Shockwave
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[WaveGun] = 1;
$RemoteInvList[WaveGun] = 1;
$InvList[WaveGunAmmo] = 1;
$RemoteInvList[WaveGunAmmo] = 1;
$AutoUse[WaveGun] = False;
$WeaponAmmo[WaveGun] = WaveGunAmmo;

addWeapon(WaveGun);
addAmmo(WaveGun, WaveGunAmmo, 25);


RocketData Shock 
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = PlasCanExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.75;
  damageType = $FlamerDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 150.0;
  muzzleVelocity = 50.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 5.0;
  liveTime = 5.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "plasmatrail.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
};

ItemData WaveGunAmmo 
{
  description = "Plasma Cannon Charges";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "plasammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData WaveGunImage 
{
  shapeFile = "mortargun";
  mountPoint = 2;
  mountOffset = { -0.5, 0.0, 0.3 };
  mountRotation = { 0.2, 0, 0 };
  weaponType = 0;
  ammoType = WaveGunAmmo;
  projectileType = Shock;
  accuFire = true;
  reloadTime = 2.0;
  fireTime = 0.5;
  sfxFire = SoundPlasmaTurretFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData WaveGun 
{
  description = "Plasma Cannon";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "disk";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = WaveGunImage;
  price = 250;
  showWeaponBar = true;
};

function WaveGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Plasma Cannon: Nicely bakes targets in long-ranged glory.");
}