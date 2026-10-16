//corr. acid, zurg, mH
$InvList[Stream] = 1;
$RemoteInvList[Stream] = 1;
$WeaponAmmo[Stream] = "";
$AutoUse[Stream] = True;
$VehicleInvList[Stream] = 1;

addWeapon(Stream);

RocketData StreamBolt
{
  bulletShapeName = "bullet.dts";
  explosionTag = TurretExp;
  damageClass = 1;
  damageValue = 0.32;
  damageType = $PsiDamageType;
  explosionRadius = 8.0;
  muzzleVelocity = 45.0;
  terminalVelocity = 45.0;
  totalTime = 4.0;
  liveTime = 4.0;
  lightRange = 5.0;
  lightColor = { 0, 2, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  trailtype = 2;
  trailString = "mortartrail.dts";
  smokeDist = 5.0;
//  soundId = SoundJetLight;
};

ItemImageData StreamImage 
{
  shapeFile = "paint";
  mountPoint = 0;
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
  heading = $InvHead[ihPsi];
  description = "Corrosive Acid";
  className = "Weapon";
  shapeFile = "paint";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = StreamImage;
  price = 700;
  showWeaponBar = true;
};

function Stream::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Corrosive Acid: <f2>Acid that seeps into armor in order to cause harm to the person inside.");
}
