//Irradiation Blast, terran, M
$InvList[Shotgun] = 1;
$InvList[ShotgunAmmo] = 1;
$RemoteInvList[Shotgun] = 1;
$RemoteInvList[ShotgunAmmo] = 1;
$VehicleInvList[Shotgun] = 1;
$VehicleInvList[ShotgunAmmo] = 1;
$SellAmmo[ShotgunAmmo] = 5;
$WeaponAmmo[Shotgun] = ShotgunAmmo;
$AutoUse[Shotgun] = False;

addWeapon(Shotgun);
addAmmo(Shotgun, ShotgunAmmo, 20);


//======================================================================== Shotgun Blast

BulletData Irradiation
{
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = debrisExpSmall;
   expRandCycle       = 2;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 10.0;
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;
   aimDeflection      = 0.009;
   muzzleVelocity     = 150.0;
   totalTime          = 1;
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod     = 1;
};

//======================================================================== Boom Stick
ItemData ShotgunAmmo
{
	description = "Irradiation Packets";
	className = "Ammo";
    heading = $InvHead[ihAmm];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ShotgunImage 
{
	shapeFile = "shotgun";
    mountPoint = 0;

	ammoType = ShotgunAmmo;
	projectileType = "Undefined";
	weaponType = 0; // Single Shot
	reloadTime = 2.0;
	fireTime = 1.0;
	minEnergy = 5;
	maxEnergy = 6;
                        
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireDisc;
	sfxReload   = SoundMortarReload;
   
};

ItemData Shotgun
{
    description = "Irradiation Blast";
	shapeFile = "shotgun";
	hudIcon = "blaster";
	heading = $InvHead[ihWea];
    className = "Weapon";
    shadowDetailMask = 4;
    imageType = ShotgunImage;
	showWeaponBar = true;
    price = 500;
};


function ShotgunImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
	 if(%AmmoCount) 
	 {
         %random = (floor(getRandom() * 3));
         if (%random == 0)
	 {
			 Player::decItemCount(%player, $WeaponAmmo[Shotgun]);
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
	 }
	 else if (%random == 1)
	 {
			 Player::decItemCount(%player, $WeaponAmmo[Shotgun]);
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
         }
	 else if (%random == 2)
	 {
			 Player::decItemCount(%player, $WeaponAmmo[Shotgun]);
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
         }
	 else if (%random == 3)
	 {
			 Player::decItemCount(%player, $WeaponAmmo[Shotgun]);
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation",%trans,%player,%vel);
         }
	 return;
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");
}

function Shotgun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Irradiation Blast: <f2>Fires concentrated clouds of energy that erupt in a violent explosion.");
}
