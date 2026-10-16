$InvList[Sword] = 1;
$RemoteInvList[Sword] = 1;
$WeaponAmmo[Sword] = "";
$AutoUse[Sword] = True;

addWeapon(Sword);

BulletData SwordBolt 
{
  bulletShapeName = "";
  damageClass = 0;
  damageValue = 1.0;
  damageType = $ElectricityDamageType;
  muzzleVelocity = 30.0;
  totalTime = 0.2;
  liveTime = 0.2;
  lightRange = 5.0;
  lightColor = { 0, 4, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};
ItemImageData SwordImage 
{
  shapeFile = "zap";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.05;
  fireTime = 0.05;
  minEnergy = 74;
  maxEnergy = 75;
  projectileType = SwordBolt;
  accuFire = true;
  sfxFire = SoundFireBlaster;
  sfxActivate = SoundPickUpWeapon;
};
ItemData Sword 
{
  heading = $InvHead[ihWea];
  description = "Psycho Sword";
  className = "Weapon";
  shapeFile = "zap";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = SwordImage;
  price = 2500;
  showWeaponBar = true;
};

function Sword::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Psycho Sword");
}
