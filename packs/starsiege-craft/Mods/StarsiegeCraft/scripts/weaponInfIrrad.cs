//Irradiation Blast, terran, M
$InvList[Shotgun2] = 1;
//$InvList[Shotgun2Ammo] = 1;
$RemoteInvList[Shotgun2] = 1;
//$RemoteInvList[Shotgun2Ammo] = 1;
$VehicleInvList[Shotgun2] = 1;
//$VehicleInvList[Shotgun2Ammo] = 1;
//$SellAmmo[Shotgun2Ammo] = 5;
$WeaponAmmo[Shotgun2] = ShotgunAmmo;
$AutoUse[Shotgun2] = False;

addWeapon(Shotgun2);
//addAmmo(Shotgun2, Shotgun2Ammo, 20);


//======================================================================== Shotgun2 Blast

BulletData Irradiation2
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   expRandCycle       = 2;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 8.0;
   damageValue        = 0.1;
   damageType         = $PsiDamageType;
   aimDeflection      = 0.009;
   muzzleVelocity     = 150.0;
   totalTime          = 1;
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod     = 1;
};

BulletData Irradiation3
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   expRandCycle       = 2;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 10.0;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;
   aimDeflection      = 0.009;
   muzzleVelocity     = 150.0;
   totalTime          = 1;
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod     = 1;
};

//======================================================================== Boom Stick

ItemImageData Shotgun2Image 
{
	shapeFile = "Shotgun";
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

ItemData Shotgun2
{
    description = "Infested Irrad";
	shapeFile = "Shotgun";
	hudIcon = "blaster";
	heading = $InvHead[ihPsi];
    className = "Weapon";
    shadowDetailMask = 4;
    imageType = Shotgun2Image;
	showWeaponBar = true;
    price = 500;
};


function Shotgun2Image::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun2]);
	 if(%AmmoCount) 
	 {
         %random = (floor(getRandom() * 3));
         if (%random == 0)
	 {
			 Player::decItemCount(%player, $WeaponAmmo[Shotgun2]);
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("Irradiation3",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
	 }
	 else if (%random == 1)
	 {
			 Player::decItemCount(%player, $WeaponAmmo[Shotgun2]);
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("Irradiation3",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
         }
	 else if (%random == 2)
	 {
			 Player::decItemCount(%player, $WeaponAmmo[Shotgun2]);
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("Irradiation3",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
         }
	 else if (%random == 3)
	 {
			 Player::decItemCount(%player, $WeaponAmmo[Shotgun2]);
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("Irradiation3",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
                        Projectile::spawnProjectile("Irradiation2",%trans,%player,%vel);
         }
	 return;
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");
}

function Shotgun2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Infested Irradiation Blast: <f2>Fires concentrated clouds of energy that erupt in a violent explosion.");
}
