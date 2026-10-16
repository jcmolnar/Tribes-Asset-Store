//Naga Blaster, Xel Naga
$InvList[NagaLauncher] = 1;
$RemoteInvList[NagaLauncher] = 1;
$VehicleInvList[NagaLauncher] = 1;
$AutoUse[NagaLauncher] = False;
$WeaponAmmo[NagaLauncher] = "";

addWeapon(NagaLauncher);

GrenadeData NagaShell
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = LargeShockwave;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 2;
  damageType = $DeathDamageType;
  explosionRadius = 22;
  kickBackStrength = 150.0;
  maxLevelFlightDist = 150;
  totalTime = 20.0;
  liveTime = 0.2;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "plasmawall.dts";
  smokeDist = 1.0;
};

ItemImageData NagaImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
        mountRotation = 
        {
        0.0, -1.57, 0.0 }//{+up -down, rolling, +left -right}
        ;
  accuFire = true;
  reloadTime = 2.0;
  fireTime = 2.0;
  minEnergy = 0;
  maxEnergy = 20;
  weaponType = 0;
  projectileType = "Undefined";
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFlierCrash;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDiscReload;
  sfxReady = SoundMortarIdle;
};

ItemData NagaLauncher 
{
  description = "Naga Blazer";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "mortar";
  heading = $InvHead[ihXnt];
  shadowDetailMask = 4;
  imageType = NagaImage;
  price = 500;
  showWeaponBar = true;
};

function NagaLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Naga Blazer: <f2>This weapon takes some of the Xel Naga's own life force and concentrates it into highly reactive core explosive matter.");
}

function NagaImage::onFire(%player,%item) 
{
  %dd = GameBase::getDamageLevel(%player);
  if (%dd <0.16)
    {
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

          Projectile::spawnProjectile("NagaShell",%trans,%player,%vel);

  %lev = GameBase::getDamageLevel(%player);
    GameBase::setDamageLevel(%player,%lev+0.09);
    }
   else Client::sendMessage(Player::getClient(%player),1, "Not enough Xel Naga life force to fire a Blazer.");
}
