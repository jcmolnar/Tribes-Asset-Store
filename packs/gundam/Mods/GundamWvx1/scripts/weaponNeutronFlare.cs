//energy flare, Colony Rebels, M
$InvList[DeathLaser] = 1;
$RemoteInvList[DeathLaser] = 1;
$AutoUse[DeathLaser] = False;
$WeaponAmmo[DeathLaser] = "";
$VehicleInvList[DeathLaser] = 1;

AddWeapon(DeathLaser);

BulletData DeathLaserBeam
{
   bulletShapeName   = "enbolt.dts";
   explosionTag      = TurretExp;
   damageType        = 1;
   damageValue       = 0.1;
   baseDamageType    = $ShellDamageType;
   damageType        = $ShellDamageType;
   explosionRadius    = 12.0;
   aimDeflection     = 0.0004;
   liveTime          = 4.5;
   totalTime         = 4.5;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.5, 1 };
   muzzleVelocity    = 800.0;
   terminalVelocity  = 800.0;
   inheritedVelocityScale = 0.5;
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
   trailType         = 1;
   trailLength       = 300;
   trailWidth        = 0.3;
};

ItemImageData DeathLaserImage 
{
  shapeFile = "chaingun";
  mountPoint = 0;
  mountRotation = 
  {
   0, -2.0, 0 }
  ;
  weaponType = 0;
  projectileType = DeathLaserBeam;
  accuFire = false;
  minEnergy = 0.2;
  maxEnergy = 1;
  reloadTime = 0.04;
  fireTime = 0.1;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0, 3, 0 };
  //sfxSpinUp = SoundSpinUp;
  sfxFire = SoundDryFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DeathLaser
{
  description = "Energy Flare";
  className = "Weapon";
  shapeFile = "chaingun";
  hudIcon = "sniper";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = DeathLaserImage;
  price = 500;
  showWeaponBar = true;
};

function DeathLaser::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Energy Flare: <f2>The Colony Rebels's personal Machine Gun upgrade. It shoots anti mater bullets.");
}