//psionic assault
$InvList[Tassadar] = 1;
$RemoteInvList[Tassadar] = 1;
$WeaponAmmo[Tassadar] = "";
$AutoUse[Tassadar] = True;
$VehicleInvList[Tassadar] = 1;

addWeapon(Tassadar);

BulletData TassadarBolt 
{
  bulletShapeName = "bullet.dts";
  explosionTag = debrisExpSmall;
  damageClass = 1;
  explosionRadius = 7;
  damageValue = 0.3;
  damageType = $ReaperDamageType;
  muzzleVelocity = 300.0;
  totalTime = 0.3;
  liveTime = 0.3;
  lightRange = 5.0;
  lightColor = { 0, 4, 0 };
  inheritedVelocityScale = 0.0;
  isVisible = false;
};

ItemImageData TassadarImage 
{
  shapeFile = "force";
  mountPoint = 0;
  weaponType = 0;
        mountRotation = 
        {
        -1.5, 0, 3 }
        ;
        mountOffset = 
        {
        0, -0.4, 0 }
        ;
  reloadTime = 0.0;
  fireTime = 0.2;
  minEnergy = 0.2;
  maxEnergy = 4.0;
  projectileType = TassadarBolt;
  accuFire = true;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Tassadar 
{
  heading = $InvHead[ihWet];
  description = "Psionic Assault";
  className = "Weapon";
  shapeFile = "force";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = TassadarImage;
  price = 425;
  showWeaponBar = true;
};

function Tassadar::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Psionic Assault: <f2>Months ago Tassadar shared his gift of diverting the mind power to create an explosion with the templar of Adun.");
}
