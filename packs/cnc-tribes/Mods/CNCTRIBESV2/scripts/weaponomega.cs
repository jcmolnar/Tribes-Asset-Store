//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Meltagun: modded from omega cannon
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Omega] = 1;
$RemoteInvList[Omega] = 1;
$AutoUse[Omega] = False;
$WeaponAmmo[Omega] = "";

addWeapon(Omega);

RocketData OmegaBolt
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = plasmaExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.65;
  damageType = $MeltaDamageType;
  explosionRadius = 3.5;
  kickBackStrength = 0.0;
  muzzleVelocity = 85.0;
  terminalVelocity = 130.0;
  acceleration = 5.0;
  totalTime = 0.28;
  liveTime = 0.28;
  lightRange = 2.0;
  lightColor = { 1.20, 1.7, 1.5 };
  inheritedVelocityScale = 0.0;
  trailType = 2;
  trailString = "plasmabolt.dts";
  smokeDist = 1.0;
};

ItemImageData OmegaImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 1.0;
  fireTime = 0.1;
  minEnergy = 44;
  maxEnergy = 45;
  projectileType = OmegaBolt;
  accuFire = false;
  sfxFire = SoundFirePlasma;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Omega 
{
  heading = $InvHead[ihWma];
  description = "Meltagun";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = OmegaImage;
  price = 585;
  showWeaponBar = true;
};

function Omega::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Meltagun: Firing radioactive energy, this gun does what it's name implies. Causes severe discomfort.");
}
