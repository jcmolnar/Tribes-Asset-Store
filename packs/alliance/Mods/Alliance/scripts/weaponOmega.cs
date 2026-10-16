
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Omega Cannon (Omega)
//  By Renegades
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[Omega] = 1;
$RemoteInvList[Omega] = 1;
$AutoUse[Omega] = True;
$WeaponAmmo[Omega] = "";

addWeapon(Omega);

BulletData OmegaBolt 
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = energyExp;
  damageClass = 0;
  damageValue = 0.05;
  damageType = $ElectricityDamageType;
  aimDeflection = 0.015;
  muzzleVelocity = 100.0;
  totalTime = 0.3;
  liveTime = 0.3;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};

ItemImageData OmegaImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.01;
  fireTime = 0.01;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = OmegaBolt;
  accuFire = false;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Omega 
{
  heading = $InvHead[ihWea];
  description = "Omega Cannon";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = OmegaImage;
  price = 385;
  showWeaponBar = true;
};

function Omega::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Omega Cannon.  Sprays energy particles at target.");
}

