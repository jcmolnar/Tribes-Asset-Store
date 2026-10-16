//neutron flare, toss, M
$InvList[DeathLaser] = 1;
$RemoteInvList[DeathLaser] = 1;
$AutoUse[DeathLaser] = False;
$WeaponAmmo[DeathLaser] = "";
$VehicleInvList[DeathLaser] = 1;

AddWeapon(DeathLaser);

BulletData DeathLaserBeam
{
   bulletShapeName   = "enbolt.dts";
   explosionTag      = energyexp;
   damageType        = 0;
   damageValue       = 0.1;
   baseDamageType    = $ShellDamageType;
   damageType        = $ShellDamageType;
   aimDeflection     = 0.0008;
   liveTime          = 2.0;
   totalTime         = 2.0;
   muzzleVelocity    = 800.0;
   terminalVelocity  = 800.0;
   inheritedVelocityScale = 0.5;
   detachFromShooter = false;
   trailType         = 1;
   trailLength       = 300;
   trailWidth        = 0.3;
};
// mount offset  +right -left, +forward -backward, +up -down
ItemImageData DeathLaserImage 
{
  shapeFile = "plasma";
  mountPoint = 0;
  weaponType = 1;
  projectileType = DeathLaserBeam;
  accuFire = false;
  minEnergy = 0.2;
  maxEnergy = 1;
  reloadTime = 0.01;
  fireTime = 0.1;
  spinupTime = 0.0;
  spinDownTime = 0.5;
        mountRotation = 
        {
        0.0, -1.5, 0.0 }//{+up -down, rolling, +left -right}
        ;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0, 3, 0 };
  //sfxSpinUp = SoundSpinUp;
  //sfxFire = SoundDryFire;
  sfxFire = SoundElfFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DeathLaser
{
  description = "Neutron Flare";
  className = "Weapon";
  shapeFile = "plasma";
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
  Bottomprint(%client, "Neutron Flare: <f2>A hand-held rapid-fire modification of the Corsair's Neutron Flare.");
}