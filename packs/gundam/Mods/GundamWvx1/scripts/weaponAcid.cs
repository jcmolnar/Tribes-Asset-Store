//Energy Beam Launcher, Earth Alliance, mH
$InvList[Stream] = 1;
$RemoteInvList[Stream] = 1;
$WeaponAmmo[Stream] = "";
$AutoUse[Stream] = True;
$VehicleInvList[Stream] = 1;

addWeapon(Stream);

RocketData StreamBolt 
{
  bulletShapeName = "shield_large.dts";
  explosionTag = TurretExp;
  damageClass = 1;
  damageValue = 0.4;
  damageType = $PsiDamageType;
  explosionRadius = 12.0;
  muzzleVelocity = 35.0;
  terminalVelocity = 35.0;
  totalTime = 4.5;
  liveTime = 4.5;
  lightRange = 5.0;
  lightColor = { 2, 0, 2 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  trailtype = 2;
  trailString = "mortartrail.dts";
  smokeDist = 5.0;
//  soundId = SoundJetLight;
};
ItemImageData StreamImage 
{
  shapeFile = "grenadeL";
  mountPoint = 0;
 mountRotation = 
  {
   0, 2.0, 0 }
  ;

  weaponType = 0;
  reloadTime = 0.2;
  fireTime = 0.1;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = StreamBolt;
  accuFire = true;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};
ItemData Stream 
{
  heading = $InvHead[ihWet];
  description = "Energy Beam Launcher";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = StreamImage;
  price = 775;
  showWeaponBar = true;
};

function Stream::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Energy Beam Launcher: <f2>This weapon shoots beams of unstable energy that can perforate almost any king of steel.");
}
