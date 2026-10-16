//psionic storm, toss, H
$InvList[Demogun] = 1;
$RemoteInvList[Demogun] = 1;
$AutoUse[Demogun] = False;
$WeaponAmmo[Demogun] = "";
$VehicleInvList[Demogun] = 1;

addWeapon(Demogun);

BulletData DemoBurst
{
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = TurretExp;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 13.0;
   damageValue        = 0.17;
   damageType         = $ReaperDamageType;
   aimDeflection      = 0.0035;
   muzzleVelocity     = 600.0;
   totalTime          = 0.8;
   liveTime           = 0.8;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
};

BulletData DemoBurst2
{
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = TurretExp;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 10.0;
   damageValue        = 0.22;
   damageType         = $ReaperDamageType;
   aimDeflection      = 0.0035;
   muzzleVelocity     = 600.0;
   totalTime          = 0.8;
   liveTime           = 0.8;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
};

ItemImageData DemoGunImage 
{
  shapeFile = "lflame";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 1.5;
  fireTime = 2.0;
  minEnergy = 9;
  maxEnergy = 10;
  projectileType = "Undefined";
  accuFire = false;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DemoGun 
{
  heading = $InvHead[ihWet];
  description = "Psionic Storm";
  className = "Weapon";
  shapeFile = "lflame";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = DemoGunImage;
  price = 550;
  showWeaponBar = true;
};

function DemoGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Psionic Storm: <f2>This weapon focuses time-space ripples into a storm of raw psychic energy that tears apart the minds of others");
}

function DemoGunImage::onFire(%player, %slot) 
{
 %energy = GameBase::getEnergy(%player);
	 if (%energy > 11)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %curren = GameBase::getEnergy(%player) - 10;
		 GameBase::setEnergy(%player,%curren);
		 %trans = GameBase::getMuzzleTransform(%player);
	         %vel = Item::getVelocity(%player);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst2",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst2",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst2",%trans,%player,%vel);
	}
	else
        {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	         %vel = Item::getVelocity(%player);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
        }
}
