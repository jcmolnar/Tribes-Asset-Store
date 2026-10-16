//warp blades

$InvList[ShurCannon] = 1;
$RemoteInvList[ShurCannon] = 1;
$VehicleInvList[ShurCannon] = 1;
$AutoUse[ShurCannon] = True;

addWeapon(ShurCannon);

BulletData HShuriken
{
  bulletShapeName = "plasmawall.dts";
  explosionTag = bulletexp2;
  collisionRadius = 0.0;
  mass = 2.0;
  aimDeflection = 0.007;
  damageClass = 0;
  damageValue = 0.7;
  baseDamageType = $ReaperDamageType;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  acceleration = 1.0;
  totalTime = 0.2;
  liveTime = 0.2;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 1.0;
  isVisible = true;
};

ItemImageData ShurCannonImage 
{
  shapeFile = "shieldpack";
  mountPoint = 0;
  weaponType = 0;
  minEnergy = 0;
  maxEnergy = 1;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 0.5;
  fireTime = 1.0;
  spinUpTime = 0.35;
  sfxFire = energyExplosion;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
};

ItemData ShurCannon 
{
  description = "Warp Blades";
  className = "Weapon";
  shapeFile = "shieldpack";
  hudIcon = "disk";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = ShurCannonImage;
  price = 400;
  showWeaponBar = true;
};

function ShurCannonImage::onFire(%player, %slot) 
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
  Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
  Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
}

function ShurCannon::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Warp Blades: <f2>an invention of the dark templar of Shakuras, this weapon disrupts the space-time continuum of whatever it strikes");
   GameBase::setRechargeRate(%player,-12);
  GameBase::startFadeout(%player);
  Client::sendMessage(Player::getClient(%player),0,"Warp Blades Cloaking On");
  %rate = Player::getSensorSupression(%player) + 5;
  Player::setSensorSupression(%player,%rate);
  %player.guiLock = true;
  %c = Player::getClient(%player);
  %c.guiLock = true;
  %clientId.ghostDoneFlag = true;
  startGhosting(%cl);
}

function ShurCannon::onUnMount(%player,%item) 
{
  %client = Player::getClient(%player);
  GameBase::startFadein(%player);
   GameBase::setRechargeRate(%player,8);
  Client::sendMessage(Player::getClient(%player),0,"Warp Blades Cloaking Off");
  %rate = Player::getSensorSupression(%player) - 5;
  Player::setSensorSupression(%player,%rate);
  %player.guiLock = true;
  %c = Player::getClient(%player);
  %c.guiLock = true;
  %clientId.ghostDoneFlag = true;
  startGhosting(%cl);
}
