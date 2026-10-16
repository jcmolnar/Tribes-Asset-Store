//Shock Rifle, Terran, L-M
$InvList[ShockRifle] = 1;
$RemoteInvList[ShockRifle] = 1;
$AutoUse[ShockRifle] = True;
$VehicleInvList[ShockRifle] = 1;
$InvList[ShockRifleAmmo] = 1;
$RemoteInvList[ShockRifleAmmo] = 1;
$VehicleInvList[ShockRifleAmmo] = 1;
$SellAmmo[ShockRifleAmmo] = 10;
$WeaponAmmo[ShockRifle] = ShockRifleAmmo;

addWeapon(ShockRifle);
addAmmo(ShockRifle, ShockRifleAmmo, 10);

LaserData ASMDLaser
{
   laserBitmapName   = "repairAdd.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.0;
   baseDamageType    = $PsiDamageType;
   beamTime          = 0.5;
   detachFromShooter = false;
//   hitSoundId        = SoundLaserHit;
};

BulletData ASMDRocket 
{
  bulletShapeName = "mortar.dts";
  explosionTag  = blasterExp;
  damageClass = 0;
  damageValue = 0.9;
  damageType = $DeathDamageType;
  muzzleVelocity = 1000;
  totalTime = 0.6;
  liveTime = 0.6;
  inheritedVelocityScale = 0.0;
  isVisible = False;
};

BulletData ASMDBall
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag  = DebrisExpMedium;
  damageClass = 1;
  damageValue = 1.0;
  damageType = $DeathDamageType;
  explosionRadius = 10.0;
  kickBackStrength = 80.0;
  muzzleVelocity = 80.0;
  totalTime = 2.0;
  liveTime = 2.0;
  inheritedVelocityScale = 0.5;
  isVisible = True;
};

ItemData ShockRifleAmmo 
{
  description = "Shock Rifle Charges";
  className = "Ammo";
  shapeFile = "plasammo";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData ShockRifleImage
{
   shapeFile  = "Sniper";
	mountPoint = 0;
        mountRotation = 
        {
        0.0, 1.57, 0.0 }//{+up -down, rolling, +left -right}
        ;
      weaponType = 0; // Single Shot
	projectileType = Undefined;
	reloadTime = 1.0;
	fireTime = 1.5;
        ammoType = ShockRifleAmmo;

	accuFire = true;

	sfxFire = SoundTeleport;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ShockRifle
{
   heading = $InvHead[ihWea];
	description = "Shock Rifle";
	className = "Weapon";
   shapeFile  = "Sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ShockRifleImage;
	price = 500;
	showWeaponBar = true;
};

function ShockRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Shock Rifle: <f2>Fires either a concentrated beam of energy or glowing balls of energy.");
}

function ShockRifleImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[ShockRifle]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.SROpt == 0)
			{
				Player::decItemCount(%player,$WeaponAmmo[ShockRifle],1);
				Projectile::spawnProjectile("ASMDRocket",%trans,%player,%vel);
				Projectile::spawnProjectile("ASMDLaser",%trans,%player,%vel);
			}
			else if (%playerId.SROpt == 1)
			{
				Player::decItemCount(%player,$WeaponAmmo[ShockRifle],1);
				Projectile::spawnProjectile("ASMDBall",%trans,%player,%vel);
			}
		}
}
