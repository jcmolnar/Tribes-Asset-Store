//adrenal glands
$InvList[Sword] = 1;
$RemoteInvList[Sword] = 1;
$WeaponAmmo[Sword] = "";
$AutoUse[Sword] = True;
$VehicleInvList[Sword] = 1;

addWeapon(Sword);

BulletData SwordBolt 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletexp2;
  damageClass = 0;
  damageValue = 0.12;
  damageType = $ReaperDamageType;
  muzzleVelocity = 45.0;
  totalTime = 0.2;
  aimDeflection = 0.05;
  liveTime = 0.2;
  lightRange = 5.0;
  lightColor = { 0, 4, 0 };
  inheritedVelocityScale = 1.0;
  isVisible = false;
};
ItemImageData SwordImage 
{
  shapeFile = "enbolt";
//  mountOffset = 
//  {
//  0.0, 0.5, 0.5 }
//  ;
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.03;
  fireTime = 0.02;
  minEnergy = 0.2;
  maxEnergy = 1.0;
  projectileType = SwordBolt;
  accuFire = false;
  sfxFire = SoundJetLight;
  sfxActivate = SoundPickUpWeapon;
};
ItemData Sword 
{
  heading = $InvHead[ihPsi];
  description = "Adrenal Glands";
  className = "Weapon";
  shapeFile = "enbolt";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = SwordImage;
  price = 1000;
  showWeaponBar = true;
};

function Sword::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Adrenal Glands: <f2>These glands will greatly improve the almost useless claws that the Zerg have from birth.");
}
