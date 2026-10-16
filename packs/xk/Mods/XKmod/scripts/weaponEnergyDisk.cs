$InvList[EnergyDisk] = 1;
$InvList[DiskBolt] = 1;
$RemoteInvList[EnergyDisk] = 1;
$RemoteInvList[DiskBolt] = 1;
$AutoUse[EnergyDisk] = True;
$SellAmmo[DiskBolt] = 5;
$WeaponAmmo[EnergyDisk] = DiskBolt;

addWeapon(EnergyDisk);
addAmmo(EnergyDisk, DiskBolt, 2);

ItemData DiskBolt
{
  description = "Energy Disk Bolts";
  className = "Ammo";
  shapeFile = "mortarammo";
  heading = $InvHead[ihAmm];
  shadowDeatilMask = 4;
  price = 30;
};

ItemImageData EnergyDiskImage
{
  shapeFile = "grenadeL";
  mountPoint = 0;
  weaponType = 0;
  ammoType = DiskBolt;
  reloadTime = 1.5;
  fireTime = 0.01;
  projectileType = EDiskBolt;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0};
  sfxFire = SoundFireDisc;
  sfxActivate = SoundWeapon5;
};

ItemData EnergyDisk
{
  heading = $InvHead[ihWea];
  description = "Energy Disc";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = EnergyDiskImage;
  price = 535;
  showWeaponBar = true;
};

function EnergyDiskImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[EnergyDisk]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[EnergyDisk],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
			Projectile::spawnProjectile("EDiskBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("EDiskBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("EDiskBolt",%trans,%player,%vel);			
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Ammo");

}

BulletData EDiskBolt
{
  bulletShapeName = "discb.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.3;
  damageType = $FlashDamageType;
  aimDeflection = 0.004;
  explosionRadius = 4.5;
  muzzleVelocity = 300.0;
  terminalVelocity = 400.0;
  totalTime = 50.5;
  liveTime = 0.3;
  seekingTurningRadius = 6;
  nonSeekingTurningRadius = 65.0;
  proximityDist = 1.5;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 3000;
  trailWidth = 0.3;
  isVisible = True;
  soundId = SoundDiscSpin;
  rotationPeriod = 1;
};

BulletData EDiskBolt2
{
  bulletShapeName = "discb.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.2;
  damageType = $FlashDamageType;
  aimDeflection = 0.002;
  explosionRadius = 4.5;
  muzzleVelocity = 300.0;
  terminalVelocity = 400.0;
  totalTime = 50.5;
  liveTime = 0.3;
  seekingTurningRadius = 6;
  nonSeekingTurningRadius = 65.0;
  proximityDist = 1.5;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 3000;
  trailWidth = 0.3;
  isVisible = True;
  soundId = SoundDiscSpin;
  rotationPeriod = 1;
};

BulletData EDiskBolt3
{
   bulletShapeName = "discb.dts";
   explosionTag = turretExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 0.3;
   damageType = $FlashDamageType;
   aimDeflection = 0.003;
   explosionRadius = 4.5;
   muzzleVelocity = 300.0;
   terminalVelocity = 400.0;
   totalTime = 50.5;
   liveTime = 0.3;
   seekingTurningRadius = 6;
   nonSeekingTurningRadius = 65.0;
   proximityDist = 1.5;
   lightRange = 3.0;
   lightColor = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;
   trailType = 1;
   trailLength = 3000;
   trailWidth = 0.3;
   isVisible = True;
   soundId = SoundDiscSpin;
   rotationPeriod = 1;
};

BulletData EDiskBoltE
{
   bulletShapeName = "discb.dts";
   explosionTag = turretExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 0.9;
   damageType = $FlashDamageType;
   aimDeflection = 0.0;
   explosionRadius = 9.5;
   muzzleVelocity = 300.0;
   terminalVelocity = 400.0;
   totalTime = 50.5;
   liveTime = 0.3;
   seekingTurningRadius = 6;
   nonSeekingTurningRadius = 65.0;
   proximityDist = 1.5;
   lightRange = 3.0;
   lightColor = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;
   trailType = 1;
   trailLength = 3000;
   trailWidth = 0.3;
   isVisible = True;
   soundId = SoundDiscSpin;
   rotationPeriod = 1;
};

function EnergyDisk::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Energy Disc");
}
