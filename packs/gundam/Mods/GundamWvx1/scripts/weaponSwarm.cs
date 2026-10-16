//Irradiator, earth alliance, L-M
$InvList[Fireball] = 1;
$RemoteInvList[Fireball] = 1;
$VehicleInvList[Fireball] = 1;
$AutoUse[Fireball] = True;
$Use[Fireball] = True;
$WeaponAmmo[Fireball] = "";

addWeapon(Fireball);

BulletData FireballShot
{
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;

   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $missileDamageType;
   explosionRadius    = 20.0;
   aimDeflection      = 0.01;
   kickBackStrength   = 15.0;
   muzzleVelocity     = 80.0;
   totalTime          = 2.45;
   liveTime           = 2.45;
   lightRange         = 3.0;
   lightColor         = { 0, 0, 6 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

//   soundId = SoundJetLight;
};


ItemImageData FireballImage
{
   shapeFile  = "chaingun";
	mountPoint = 0;
    
	weaponType = 1;
	reloadTime = 0.2;
      spinUpTime = 0.5;
      spinDownTime = 1.0;
	fireTime = 0.4;
	minEnergy = 5;
	maxEnergy = 10;

	projectileType = Undefined;
	accuFire = true;

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fireball
{
   heading = $InvHead[ihWet];
	description = "Irradiator";
	className = "Weapon";
   shapeFile  = "chaingun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FireballImage;
	price = 485;
	showWeaponBar = true;
};

function Fireball::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Eradicator: <f2>This gun rapiditly fires highly explosive enrgy discs.");
}

function FireballImage::onFire(%player, %slot) 
//{
 //%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Zap]);
	 //if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 //Player::decItemCount(%player,$WeaponAmmo[Zap],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
	}
	//else
		//Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

//}
