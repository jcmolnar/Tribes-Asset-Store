//Flamer Gun
$InvList[Silencer] = 1;
$InvList[SilencerAmmo] = 1;
$RemoteInvList[Silencer] = 1;
$RemoteInvList[SilencerAmmo] = 1;
$VehicleInvList[Silencer] = 1;
$VehicleInvList[SilencerAmmo] = 1;
$AutoUse[Silencer] = False;
$SellAmmo[SilencerAmmo] = 50;
$WeaponAmmo[Silencer] = SilencerAmmo;

addWeapon(Silencer);
addAmmo(Silencer, SilencerAmmo, 50);

GrenadeData Silencergren
{
  bulletShapeName = "PlasmaBolt.dts";
  explosionTag = plasmaExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.1;
  damageType = $PlasmaDamageType;
  explosionRadius = 8;
  kickBackStrength = 0;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 0.001;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "Plasmatrail.dts";
  smokeDist = 1.5;
};

ItemData SilencerAmmo 
{
  description = "Flamer Cartridges";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData SilencerImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  mountRotation = 
  {
   0, -2.0, 0 }
  ;


  weaponType = 0;
  ammoType = SilencerAmmo;
  projectileType = SilencerGren;
  accuFire = false;
  reloadTime = 0.01;
  fireTime = 0.01;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData Silencer 
{
  description = "Flamer Gun";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = SilencerImage;
  price = 175;
  showWeaponBar = true;
};

function Silencer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Flamer Gun: <f2>Hurls flames rapiditly to burn the enemies that get too close.");
}
