$InvList[IonDisk] = 1;
$RemoteInvList[IonDisk] = 1;
$AutoUse[IonDisk] = True;
$WeaponAmmo[IonDisk] = "";

addWeapon(IonDisk);

RocketData IonEMP 
{
  bulletShapeName = "Shield.dts";
  explosionTag = TurretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.3;
  damageType = $IonDamageType;
  explosionRadius = 5.5;
  kickBackStrength = 150.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 8.0;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 1000;
  trailWidth = 1.5;
  soundId = SoundShieldOn;
};

ItemImageData IonDiskImage
{
  shapeFile = "Disc";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0;
  fireTime = 0.5;
  minEnergy = 19;
  maxEnergy = 20;
  projectileType = IonEMP;
  accuFire = True;
  sfxFire = SoundFirePlasma;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundShieldOn;
};

ItemData IonDisk 
{
  heading = $InvHead[ihWea];
  description = "Ion Disc";
  className = "Weapon";
  shapeFile = "Disc";
  hudIcon = "targetlaser";
  shadowDetailMask = 4;
  imageType = IonDiskImage;
  price = 250;
  showWeaponBar = true; 
};
     
function IonDisk::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Ion Disc");
}

