//Flame Thrower
$InvList[Fireball] = 1;
$RemoteInvList[Fireball] = 1;
$VehicleInvList[Fireball] = 1;
$AutoUse[Fireball] = True;
$Use[Fireball] = True;
$WeaponAmmo[Fireball] = "";

addWeapon(Fireball);

BulletData FireballShot
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = clawexp;

   damageClass        = 1;
   damageValue        = 0.75;
   damageType         = $EnergyDamageType;
   explosionRadius    = 3.0;
   aimDeflection      = 0.01;
   muzzleVelocity     = 30.0;
   totalTime          = 0.45;
   liveTime           = 0.45;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

//   soundId = SoundJetLight;
};


ItemImageData FireballImage
{
   shapeFile  = "cougar";
	mountPoint = 0;
        mountOffset = {0.0, 0.0, 0.2 };
	weaponType = 0; // Single Shot
	reloadTime = 1.5;
	fireTime = 0.01;
	minEnergy = 20;
	maxEnergy = 50;

	projectileType = Undefined;
	accuFire = true;

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fireball
{
   heading = $InvHead[ihWet];
	description = "Flame Thrower";
	className = "Weapon";
   shapeFile  = "cougar";
	hudIcon = "chaingun";
	shadowDetailMask = 4;
	imageType = FireballImage;
	price = 485;
	showWeaponBar = true;
};

function Fireball::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Flame Thrower: <f2>The Flamethrower is a devistating close range weapon, it has the ability to burn people into small puddles.");
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
