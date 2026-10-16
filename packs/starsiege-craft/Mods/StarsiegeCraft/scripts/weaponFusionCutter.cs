//fusion cutter, terran, H
$InvList[WaveGun] = 1;
$RemoteInvList[WaveGun] = 1;
$VehicleInvList[Wavegun] = 1;
$AutoUse[WaveGun] = False;
$WeaponAmmo[WaveGun] = "";

addWeapon(WaveGun);

BulletData FusionCutBolt
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = TurretExp;
  damageClass = 1;
  explosionRadius = 15.0;
  damageValue = 0.8;
  damageType = $DeathDamageType;
  muzzleVelocity = 150.0;
  terminalVelocity = 150.0;
  totalTime = 3.0;
  liveTime = 2.0;
  lightRange = 3.0;
  lightColor = { 0.0, 5, 0 };
  inheritedVelocityScale = 1.0;
  soundId = SoundJetHeavy;
  isVisible = true;
//  trailType = 1;
//  trailWidth = 0.5;
//  trailLength = 50.0;
};

ItemImageData WaveGunImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  minEnergy = 10;
  maxEnergy = 11;
        mountRotation = 
        {
        0, 1.5, 0.0 }
        ;
  projectileType = FusionCutBolt;
  accuFire = true;
  reloadtime = 0.5;
  fireTime = 0.5;
  sfxFire = SoundPlasmaTurretFire;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
  sfxActivate = SoundPickUpWeapon;
};

ItemData WaveGun 
{
  description = "Fusion Cutter";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "disk";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = WaveGunImage;
  price = 700;
  showWeaponBar = true;
};

function WaveGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Fusion Cutter: <f2>The mother of all fusion weapons, only the goliath has the mass to carry this bad boy.");
}
