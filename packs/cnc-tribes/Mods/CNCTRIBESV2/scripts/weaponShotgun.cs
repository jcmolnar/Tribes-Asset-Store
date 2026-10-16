//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Shotgun: modded from special_v1
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Shotgun] = 1;
$InvList[ShurAmmo] = 1;
$RemoteInvList[Shotgun] = 1;
$RemoteInvList[ShotgunAmmo] = 1;
$SellAmmo[ShotgunAmmo] = 5;
$WeaponAmmo[Shotgun] = ShotgunAmmo;
$AutoUse[Shotgun] = False;

addWeapon(Shotgun);
addAmmo(Shotgun, ShotgunAmmo, 2);


//======================================================================== Shotgun Blast

BulletData ShotgunBlast
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.07;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $ShellDamageType;

   aimDeflection      = 0.029;
   muzzleVelocity     = 200.0;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 2.0;
   tracerLength       = 30;
   soundId = SoundJetLight;
   
};

//======================================================================== Boom Stick
ItemData ShotgunAmmo
{
	description = "Shotgun Shells";
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
	reloadTime = 0.5;
	fireTime = 1.1;
	minEnergy = 5;
	maxEnergy = 6;
                        
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireMortar;
	sfxReload   = SoundMortarReload;
   
};

ItemData Shotgun
{
    description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "blaster";
	heading = $InvHead[ihWma];
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
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);			
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}

function Shotgun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Shotgun: Useless at long range, but up close and personal, it's truly a force to be reckoned with.");
}
