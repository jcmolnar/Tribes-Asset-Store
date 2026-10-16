
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Shockwave Cannon (WaveGun)
//  By Renegades
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[WaveGun] = 1;
$RemoteInvList[WaveGun] = 1;
$AutoUse[WaveGun] = True;
$WeaponAmmo[WaveGun] = "";

addWeapon(WaveGun);

RocketData Shock 
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.15;
  damageType = $MissileDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 350.0;
  muzzleVelocity = 50.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 6.0;
  liveTime = 4.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
};

ItemImageData WaveGunImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 0;
  minEnergy = 40;
  maxEnergy = 45;
  projectileType = Shock;
  accuFire = true;
  fireTime = 0.9;
  sfxFire = SoundPlasmaTurretFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData WaveGun 
{
  description = "Shockwave Cannon";
  className = "Weapon";
  shapeFile = "shotgun";
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
  Bottomprint(%client, "Shockwave Cannon.  Throws target away from blast.");
}

