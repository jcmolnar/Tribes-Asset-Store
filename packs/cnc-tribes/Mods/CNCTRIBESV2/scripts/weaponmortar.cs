//Grenade Launcher
$InvList[Mortar] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[Mortar] = 1;
$RemoteInvList[MortarAmmo] = 1;
$VehicleInvList[Mortar] = 1;
$VehicleInvList[MortarAmmo] = 1;
$AutoUse[Mortar] = False;
$SellAmmo[MortarAmmo] = 5;
$WeaponAmmo[Mortar] = Mortar;

addWeapon(Mortar);
addAmmo(Mortar, MortarAmmo, 2);

GrenadeData MortarShell 
{
  bulletShapeName = "grenade.dts";
  explosionTag = mortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.75;
  damageType = $MortarDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 253;
  totalTime = 30.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "smoke.dts";
};

ItemData MortarAmmo 
{
  description = "Grenade Packs";
  className = "Ammo";
  heading = $InvHead[ihDSe];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData MortarImage 
{
  shapeFile = "grenade2L";
  mountPoint = 0;
  weaponType = 0;
  ammoType = MortarAmmo;
  projectileType = MortarShell;
  accuFire = false;
  reloadTime = 0.6;
  fireTime = 0.6;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData Mortar 
{
  description = "Grenade Launcher";
  className = "Weapon";
  shapeFile = "grenade2L";
  hudIcon = "mortar";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = MortarImage;
  price = 155;
  showWeaponBar = true;
};

function Mortar::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Grenade Launcher: <f2>A grenadiers favorite, used for taking out bunkers of infantry.");
}
