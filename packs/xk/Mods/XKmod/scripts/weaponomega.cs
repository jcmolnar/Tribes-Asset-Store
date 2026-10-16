$InvList[Omega] = 1;
$RemoteInvList[Omega] = 1;
$AutoUse[Omega] = True;
$WeaponAmmo[Omega] = "";

addWeapon(Omega);

BulletData OmegaBolt 
{
  bulletShapeName = "mortar.dts";
  explosionTag = PaintExp;
  damageClass = 0;
  damageValue = 0.05;
  damageType = $IonDamageType;
  aimDeflection = 0.015;
  muzzleVelocity = 100.0;
  totalTime = 5.3;
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
  mountRotation = { 0, 180.0, 0 };
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.01;
  fireTime = 0.01;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = OmegaBolt;
  accuFire = false;
  sfxFire = SoundFloatTarget;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Omega 
{
  heading = $InvHead[ihWea];
  description = "Omega Death Rifle";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = OmegaImage;
  price = 485;
  showWeaponBar = true;
};

function Omega::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Omega Death Rifle");
}
