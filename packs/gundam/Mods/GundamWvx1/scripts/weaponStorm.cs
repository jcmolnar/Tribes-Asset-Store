//Storm Canon, Colony Rebels, H
$InvList[Demogun] = 1;
$RemoteInvList[Demogun] = 1;
$AutoUse[Demogun] = False;
$WeaponAmmo[Demogun] = "";
$VehicleInvList[Demogun] = 1;

addWeapon(Demogun);

BulletData DemoBurst
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = TurretExp;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 15.0;
   damageValue        = 0.9;
   damageType         = $ReaperDamageType;
   aimDeflection      = 0.003;
   muzzleVelocity     = 300.0;
   totalTime          = 5;
   liveTime           = 5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;
   
};

ItemImageData DemoGunImage 
{
  shapeFile = "grenadeL";
  mountPoint = 0;
  mountRotation = 
  {
   0, -3.0, 0 }
  ;
  weaponType = 0;
  reloadTime = 1.5;
  fireTime = 2.0;
  minEnergy = 29;
  maxEnergy = 30;
  projectileType = Undefined;
  accuFire = false;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DemoGun 
{
  heading = $InvHead[ihWet];
  description = "Storm Canon";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = DemoGunImage;
  price = 550;
  showWeaponBar = true;
};

function DemoGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Storm Canon: <f2>This weapon shoots anti mater based beams.");
}

function DemoGunImage::onFire(%player, %slot) 
//{
 //%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Zap]);
	 //if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 //Player::decItemCount(%player,$WeaponAmmo[Zap],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
	}
	//else
		//Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

//}
