$InvList[FireMortar] = 1;
$RemoteInvList[FireMortar] = 1;
$AutoUse[FireMortar] = True;
$WeaponAmmo[FireMortar] = "";

addWeapon(FireMortar);

GrenadeData FMShell
{
  bulletShapeName = "Grenade.dts";
  explosionTag = plasmaExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.1;
  mass = 3.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.8;
  damageType = $PlasmaDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 200.0;
  maxLevelFlightDist = 375;
  totalTime = 15.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "plasmatrail.dts";
};

ItemImageData FireMortarImage
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  projectileType = FMShell;
  accufire = false;
  minEnergy = 10;
  maxEnergy = 50;
  reloadTime = 0.8;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundJetpackOn;
};

ItemData FireMortar
{
  description = "Fire Mortar";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "plasma";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = FireMortarImage;
  price = 600;
  showWeaponBar = true;
};

function FireMortar::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Fire Mortar");
}
