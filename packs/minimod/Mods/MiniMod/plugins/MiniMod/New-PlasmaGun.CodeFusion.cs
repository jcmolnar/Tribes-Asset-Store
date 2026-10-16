$Plasma::Options = true;

ExplosionData plasmaExp
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};
BulletData PlasmaVelocityBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 440.0;
   totalTime          = 0.1875;
   liveTime           = 0.125;
   lightRange         = 0.1875;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};
BulletData PlasmaDistanceBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 27.5;
   totalTime          = 12.0;
   liveTime           = 8.0;
   lightRange         = 12.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};
//======================================================================== Plasma Bolt Multi

BulletData PlasmaBoltMulti
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.20;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.5;

   muzzleVelocity     = 275.0;
   totalTime          = 3.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid

BulletData PlasmaBoltRapid
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.20;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 180.0;
   totalTime          = 3.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid2

BulletData PlasmaBoltRapid2
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.20;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 110.0;
   totalTime          = 3.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = "PlasmaAmmo";
	projectileType = "Undefined";
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function PlasmaGunImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);


			if (%playerId.Plasma == 0)
			{
				Projectile::spawnProjectile("PlasmaBolt",%trans,%player,%vel);
			}
			else if (%playerId.Plasma == 1)
			{
				Projectile::spawnProjectile("PlasmaVelocityBolt",%trans,%player,%vel);
			}
			else if (%playerId.Plasma == 2)
			{
				Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
				Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,(%vel + 25));
				Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,(%vel - 25));
			}
			else if (%playerId.Plasma == 3)
			{
				Projectile::spawnProjectile("PlasmaDistanceBolt",%trans,%player,%vel);
			}
		}	//=== End standard plasma fire.
}


ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};


ItemImageData PlasmaGun2Image
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = "PlasmaAmmo";
	projectileType = "PlasmaBoltRapid";
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.25;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};


ItemData PlasmaGun2
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGun2Image;
	price = 175;
	showWeaponBar = true;
};


ItemImageData PlasmaGun3Image
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = "PlasmaAmmo";
	projectileType = "PlasmaVelocityBolt";
	accuFire = true;
	reloadTime = 0.005;
	fireTime = 0.025;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};


ItemData PlasmaGun3
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGun3Image;
	price = 175;
	showWeaponBar = true;
};


