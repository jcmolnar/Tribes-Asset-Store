
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Plasma Gun (PlasmaGun)
//  By Dynamix
//
//  Alliance version by Mjolnir, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[Plas] = 1;
$InvList[PlasAmmo] = 1;
$RemoteInvList[Plas] = 1;
$RemoteInvList[PlasAmmo] = 1;
$AutoUse[Plas] = True;
$SellAmmo[PlasAmmo] = 5;
$WeaponAmmo[Plas] = PlasAmmo;

addWeapon(Plas);
addAmmo(Plas, PlasAmmo, 5);

RocketData PlasBolt 
{
  bulletShapeName = "plasmaex.dts";
  explosionTag = Flare2Exp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.5;
  damageType = $PlasmaDamageType;
  explosionRadius = 15.5;
  kickBackStrength = 0.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 50.0;
  acceleration = 200.0;
  totalTime = 8.5;
  liveTime = 18.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "tumult_small.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
};

ItemData PlasAmmo
{
  description = "Plas Shell";
  heading = $InvHead[ihAmm];
  className = "Ammo";
  shapeFile = "plasammo";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData PlasImage
{
  shapeFile = "plasma";
  mountRotation = { 0.0, 140.0, 0.0 };
  mountPoint = 0;
  weaponType = 0;
  ammoType = PlasAmmo;
  projectileType = PlasBolt;
  accuFire = true;
  reloadTime = 0.3;
  fireTime = 0.5;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 1, 1, 0.2 };
  sfxFire = SoundFirePlasma;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData Plas
{
  description = "Plas Cannon";
  className = "Weapon";
  shapeFile = "plasma";
  hudIcon = "plasma";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = PlasImage;
  price = 175;
  showWeaponBar = true;
};
function Plas::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Plas Cannon");
}
