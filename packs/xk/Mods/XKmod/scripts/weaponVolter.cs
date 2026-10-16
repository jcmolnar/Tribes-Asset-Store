$InvList[Volter] = 1; //Volter: From the Shifter Mod
$RemoteInvList[Volter] = 1;
$AutoUse[Volter] = True;
$WeaponAmmo[Volter] = "";

addWeapon(Volter);

GrenadeData FlameBurst 
{
  explosionTag = plasmaExp;
  collideWithOwner = True;
  ownerGraceMS = 50;
  collisionRadius = 10.0;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.30;
  damageType = $PlasmaDamageType;
  explosionRadius = 5.0;
  kickBackStrength = 0.1;
  maxLevelFlightDist = 75;
  totalTime = 4.0;
  liveTime = 0.02;
  projSpecialTime = 0.01;
  lightRange = 10.0;
  lightColor = { 1, 1, 0 }; 
  inheritedVelocityScale = 1.5;
  smokeName = "plasmatrail.dts";
  soundId = SoundJetLight;
};
 
ItemImageData VolterImage
{
  shapeFile  = "shotgun";
  mountPoint = 0;
  weaponType = 0; // Single Shot
  reloadTime = 0.2;
  fireTime = 0;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = FlameBurst;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 1.0, 0.7, 0.5 };
  sfxFire = SoundFlyerActive;
  sfxActivate = SoundEnergyWhirl;
};

ItemData Volter
{
  heading = $InvHead[ihWea];
  description = "Volter";
  className = "Weapon";
  shapeFile  = "shotgun";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = VolterImage;
  price = 685;
  showWeaponBar = true;
};

function Volter::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Volter");
}
