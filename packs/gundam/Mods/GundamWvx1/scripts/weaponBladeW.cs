//Laser Sword 

$InvList[ShurCannon] = 1;
//$InvList[ShurAmmo] = 1;
$RemoteInvList[ShurCannon] = 1;
$VehicleInvList[ShurCannon] = 1;
$AutoUse[ShurCannon] = True;

addWeapon(ShurCannon);
//addAmmo(ShurCannon, ShurAmmo, 2);

BulletData HShuriken
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = bulletexp2;
  collisionRadius = 0.0;
  mass = 2.0;
  aimDeflection = 0.007;
  damageClass = 0;
  damageValue = 0.7;
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

//ItemData ShurAmmo 
//{
//  description = "Heavy Shuriken";
//  className = "Ammo";
//  shapeFile = "discammo";
//  heading = $InvHead[IhAmm];
//  shadowDetailMask = 4;
//  price = 2;
//};

ItemImageData ShurCannonImage 
{
  shapeFile = "zap";
  mountPoint = 0;
  mountRotation = 
  {
   -0.5, 0, 0 }
  ;
  weaponType = 0;
  minEnergy = 10;
  maxEnergy = 15;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 0.2;
  fireTime = 0.2;
  spinUpTime = 0.35;
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
};

ItemData ShurCannon 
{
  description = "Laser Sword";
  className = "Weapon";
  shapeFile = "zap";
  hudIcon = "disk";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = ShurCannonImage;
  price = 700;
  showWeaponBar = true;
};

function ShurCannonImage::onFire(%player, %slot) 
//{
 //%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[ShurCannon]);
	 //if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 //Player::decItemCount(%player,$WeaponAmmo[ShurCannon],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
			Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
			Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
			//Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
			//Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
			//Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
			//Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
			//Projectile::spawnProjectile("HShuriken",%trans,%player,%vel);
	}
	//else
		//Client::sendMessage(Player::getClient(%player), 0,"Out Of Shuriken");

//}
function ShurCannon::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Laser Sword: <f2>Powerfull melee weapon.");
}