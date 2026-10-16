//dark swarm, zurg, M
$InvList[Fireball] = 1;
$RemoteInvList[Fireball] = 1;
$VehicleInvList[Fireball] = 1;
$AutoUse[Fireball] = True;
$Use[Fireball] = True;
$WeaponAmmo[Fireball] = "";

addWeapon(Fireball);

BulletData FireballShot
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   damageClass        = 1;
   damageValue        = 0.13;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   aimDeflection      = 0.005;
   muzzleVelocity     = 30.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.0;
   isVisible          = True;
};

BulletData FireballShot1
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   damageClass        = 1;
   damageValue        = 0.13;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   aimDeflection      = 0.005;
   muzzleVelocity     = 50.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};

BulletData FireballShot2
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   damageClass        = 1;
   damageValue        = 0.13;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   aimDeflection      = 0.005;
   muzzleVelocity     = 20.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};

BulletData FireballShot3
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   damageClass        = 1;
   damageValue        = 0.13;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   aimDeflection      = 0.005;
   muzzleVelocity     = 25.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};


BulletData FireballShot4
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   damageClass        = 1;
   damageValue        = 0.13;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   aimDeflection      = 0.005;
   muzzleVelocity     = 15.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};

BulletData FireballShot5
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   damageClass        = 1;
   damageValue        = 0.13;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   aimDeflection      = 0.005;
   muzzleVelocity     = 10.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};

ItemImageData FireballImage
{
   shapeFile  = "fusionbolt";
	mountPoint = 0;
        mountOffset = 
        {
        0.5, 0.0, 0.3 }
        ;
	weaponType = 0; // Single Shot
	reloadTime = 2.0;
	fireTime = 1.5;
	minEnergy = 10;
	maxEnergy = 20;

	projectileType = Undefined;
	accuFire = true;

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fireball
{
   heading = $InvHead[ihPsi];
	description = "Dark Swarm";
	className = "Weapon";
   shapeFile  = "fusionbolt";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FireballImage;
	price = 485;
	showWeaponBar = true;
};

function Fireball::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Dark Swarm: <f2>This ability will cough forth tons of insects that will eat away at each other and anything they can see, causing disease.");
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
                        Projectile::spawnProjectile("FireballShot1",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot2",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot3",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot4",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot5",%trans,%player,%vel);
	}
	//else
		//Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

//}
