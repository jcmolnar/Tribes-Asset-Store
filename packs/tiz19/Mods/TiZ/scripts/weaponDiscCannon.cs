
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  DISC CANNON
//  By Timer[TiZ]
//
//  Alliance version by Mjolnir, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[DiscCannon] = 1;
$InvList[DiskAmmo] = 1;
$RemoteInvList[DiscCannon] = 1;
$RemoteInvList[DiskAmmo] = 1;
$SellAmmo[DiskAmmo] = 1;
$WeaponAmmo[DiscCannon] = DiskAmmo;

addWeapon(DiscCannon);
addAmmo(DiscCannon, DiskAmmo, 1);

RocketData DiskShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.5;
  damageClass = 1;
  damageValue = 10.5;
  damageType = $ShurikenDamageType;
  explosionRadius = 300;
  kickBackStrength = 1500.0;
  muzzleVelocity = 285.0;
  terminalVelocity = 285.0;
  acceleration = 75.0;
  totalTime = 2.5;
  liveTime = 2.5;
  lightRange = 7.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 1.0;
  trailType = 1;
  trailLength = 15;
  trailWidth = 0.3;
  soundId = SoundDiscSpin;
};

ItemData DiskAmmo 
{
  description = "Doom Shell";
  className = "Ammo";
  shapeFile = "mortarammo";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 2000;
};

ItemImageData DiscCannonImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 3;
  ammoType = DiskAmmo;
  projectileType = DiskShell;
  accuFire = false;
  reloadTime = 8;
  fireTime = 0;
  spinUpTime = 0;
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
};

ItemData DiscCannon 
{
  description = "Doom Cannon";
  className = "Weapon";
  shapeFile = "disc";
  hudIcon = "disc";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = DiscCannonImage;
  price = 5000;
  showWeaponBar = true;
};

function DiscCannon::OnMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Doom Cannon: The most dangerous weapon known in existance, the doom cannon has the ability to destroy all armor types in single hits.");
}