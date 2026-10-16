//Hyper Needle Spray, Used by Medics
$InvList[HypN] = 1;
$RemoteInvList[HypN] = 1;
$VehicleInvList[HypN] = 1;
$VehicleInvList[HypNAmmo] = 1;
$AutoUse[HypN] = False;
$WeaponAmmo[HypN] = HypNAmmo;
$SellAmmo[HypNAmmo] = 15;
$InvList[HypNAmmo] = 1;
$RemoteInvList[HypNAmmo] = 1;

addWeapon(HypN);
addAmmo(HypN, HypNAmmo, 4);

BulletData HypNNeedle
{
   bulletShapeName    = "paint.dts";
   explosionTag       = bulletExpToxin;

   damageClass        = 1;
   damageValue        = 0.1;
   damageType         = $DeathDamageType;
   explosionRadius    = 8.0;
   aimDeflection      = 0.006;
   muzzleVelocity     = 200;
   totalTime          = 3;
   liveTime           = 3;
   inheritedVelocityScale = 0.3;
   isVisible          = True;
   rotationPeriod     = 0.1;
};

ItemData HypNAmmo 
{
  description = "Spray Syringes";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 4;
};

ItemImageData HypNImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
        mountRotation = 
        {
        0.0, 1.57, 0.0 }//{+up -down, rolling, +left -right}
        ;
  weaponType = 0;
  ammoType = HypNAmmo;
  projectileType = "Undefined";
  accuFire = false;
  reloadTime = 1.0;
  fireTime = 0.1;
  lightType = 3;
  lightRadius = 0;
  lightTime = 0;
  lightColor = 
  {
    0.0, 0, 0 }
  ;
  sfxReload = SoundDiscReload;
  sfxFire = SoundJetLight;
  sfxActivate = SoundPickUpWeapon;
};

ItemData HypN 
{
  description = "Purge Spray";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "energyRifle";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = HypNImage;
  price = 350;
  showWeaponBar = true;
};

function HypNImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[HypN]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[HypN],5);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("HypNNeedle",%trans,%player,%vel,team-1);
                        Projectile::spawnProjectile("HypNNeedle",%trans,%player,%vel,team-1);
                        Projectile::spawnProjectile("HypNNeedle",%trans,%player,%vel,team-1);
                        Projectile::spawnProjectile("HypNNeedle",%trans,%player,%vel,team-1);
                        Projectile::spawnProjectile("HypNNeedle",%trans,%player,%vel,team-1);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}

function HypN::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Hypodermic Spray: <f2>A spray of energy agents forms a lethal rain.");
}