//Laser Scythe
$InvList[Disclauncher] = 1;
$RemoteInvList[DiscLauncher] = 1;
$VehicleInvList[DiscLauncher] = 1;
$WeaponAmmo[DiscLauncher] = "";

addWeapon(DiscLauncher);
//addAmmo(DiscLauncher, DiscAmmo, 2);

BulletData DiscShell
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = bulletexp2;
  collisionRadius = 0.0;
  mass = 2.0;
  aimDeflection = 0.007;
  damageClass = 0;
  damageValue = 1.5;
  baseDamageType = $ReaperDamageType;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  acceleration = 5.0;
  totalTime = 0.2;
  liveTime = 0.2;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 1.0;
  isVisible = true;
};

//ItemData DiscAmmo 
//{
//  description = "Shuriken";
//  className = "Ammo";
//  shapeFile = "discammo";
//  heading = $InvHead[ihAmm];
//  shadowDetailMask = 4;
//  price = 2;
//};
//
ItemImageData DiscLauncherImage 
{
  shapeFile = "grenadeL";
  mountPoint = 0;
  mountRotation = 
  {
   -0.4, -2.0, 0 }
  ;
  weaponType = 0;
  minEnergy = 1.0;
  maxEnergy = 1.0;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 0.5;
  fireTime = 1.0;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher 
{
  description = "Laser Scythe";
  className = "Weapon";
  shapeFile = "GrenadeL";
  hudIcon = "disk";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = DiscLauncherImage;
  price = 150;
  showWeaponBar = true;
};

function DiscLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Laser Scythe: <f2>an effective melee weapon to rip into your enemies.");
}

function DiscLauncherImage::onFire(%player, %slot) 
//{
 //%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Zap]);
	 //if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 //Player::decItemCount(%player,$WeaponAmmo[Zap],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("DiscShell",%trans,%player,%vel);
                        Projectile::spawnProjectile("DiscShell",%trans,%player,%vel);	
	}
	//else
		//Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

//}
