
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Reaper Cannon
//  by <[DC]>Paladin :modded from Mass Driver(al_renegades)
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[MassDriver] = 1;
$RemoteInvList[MassDriver] = 1;
$AutoUse[MassDriver] = False;
$WeaponAmmo[MassDriver] = MassAmmo;
$SellAmmo[MassAmmo] = 15;
$InvList[MassAmmo] = 1;
$RemoteInvList[MassAmmo] = 1;

addWeapon(MassDriver);
addAmmo(MassDriver, MassAmmo, 2);

RocketData Mass
{
  bulletShapeName = "rocket.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.35;
  damageType = $ReaperDamageType;
  explosionRadius = 20.5;
  kickBackStrength = 150.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 130.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 10.0;
  lightRange = 2.0;
  lightColor = { 1.20, 1.7, 1.5 };
  inheritedVelocityScale = 0.0;
  trailType = 2;
  trailString = "dustplume.dts";
  smokeDist = 1.0;
  soundId = SoundJetHeavy;
};

ItemData MassAmmo 
{
  description = "Reaper Shell";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData MassDriverImage 
{
  shapeFile = "GrenadeL";
  mountPoint = 0;
  weaponType = 0;
  ammoType = MassAmmo;
  projectileType = Mass;
  accuFire = false;
  reloadTime = 1.0;
  fireTime = 0.5;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 0, 0, 3.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundMortarIdle;
};

ItemData MassDriver
{
  description = "Reaper Launcher";
  className = "Weapon";
  shapeFile = "GrenadeL";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWel];
  shadowDetailMask = 4;
  imageType = MassDriverImage;
  price = 375;
  showWeaponBar = true;
};

function MassDriver::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Reaper Launcher: A Dark Reaper's weapon, it fires deadly searing rounds that melt and maim targets in an explosive haze.");
}
