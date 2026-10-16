//Swift Killer
$InvList[WaveGun] = 1;
$RemoteInvList[WaveGun] = 1;
$VehicleInvList[Wavegun] = 1;
$AutoUse[WaveGun] = False;
$WeaponAmmo[WaveGun] = "";

addWeapon(WaveGun);

BulletData FusionCutBolt
{
  bulletShapeName = "discb.dts";
  explosionTag = bulletexp0;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.17;
  damageType = $BulletDamageType;
  muzzleVelocity = 200.0;
  totalTime = 50.0;
  liveTime = 50.0;
  lightRange = 3.0;
  lightColor = { 1.0, 1, 0 };
  inheritedVelocityScale = 1.0;
  soundId = SoundJetHeavy;
  isVisible = false;
  trailType = 1;
  trailWidth = 0.5;
  trailLength = 20.0;
};

ItemImageData WaveGunImage 
{
  shapeFile = "chaingun";
  mountPoint = 0;
  mountRotation = 
  {
   0, 3.0, 0 }
  ;

  
  weaponType = 0;
  minEnergy = 2;
  maxEnergy = 5;
  projectileType = FusionCutBolt;
  accuFire = false;
  reloadtime = 0.01;
  fireTime = 0.1;
  sfxFire = SoundPlasmaTurretFire;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
  sfxActivate = SoundPickUpWeapon;
};

ItemData WaveGun 
{
  description = "Swift Killer";
  className = "Weapon";
  shapeFile = "chaingun";
  hudIcon = "disk";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = WaveGunImage;
  price = 725;
  showWeaponBar = true;
};

function WaveGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Swift Killer: <f2>This weapon fires almost invisible energy bullets.");
}