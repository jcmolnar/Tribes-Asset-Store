
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  DiskHammer (DiskHammer)
//  By Forsaken Knights
//
//  Forsaken Knights version by King Shit & Neo, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[DiskHammer] = 1;
$RemoteInvList[DiskHammer] = 1;
$AutoUse[DiskHammer] = True;
$Use[DiskHammer] = True;
$WeaponAmmo[DiskHammer] = "";

addWeapon(DiskHammer);

RocketData CycloneBolt 
{
  bulletShapeName = "discb.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.1;
  damageType = $ExplosionDamageType;
  explosionRadius = 6.5;
  kickBackStrength = 50.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 8.0;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 15;
  trailWidth = 0.3;
  soundId = SoundDiscSpin;
};

ItemImageData DiskHammerImage 
{
  shapeFile = "GrenadeL";
 mountRotation = { 0, 160.0, 0 };
  mountPoint = 0;
  weaponType = 3;
  ammoType = energy;
  projectileType = CycloneBolt;
  accuFire = true;
  reloadTime = 0.0;
  fireTime = 0.1;
  spinUpTime = 0.1;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData DiskHammer
{
  description = "Cyclone Disc";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "disk";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = DiskHammerImage;
  price = 200;
  showWeaponBar = true;
};

function DiskHammer::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) == HammerPack) 
    Weapon::onUse(%player,%item);
  else 
    Client::sendMessage(Player::getClient(%player),0, "You have to have the Cyclone Pack to use the Cyclone Disc..");
}

function DiskHammer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Cyclone Disc");
}
