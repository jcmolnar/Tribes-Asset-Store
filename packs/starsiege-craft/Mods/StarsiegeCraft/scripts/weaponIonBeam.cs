//Ion Cannon, Toss, H
$InvList[IonBeam] = 1;
$RemoteInvList[IonBeam] = 1;
$AutoUse[IonBeam] = True;
$VehicleInvList[IonBeam] = 1;
$InvList[IonBeamAmmo] = 1;
$RemoteInvList[IonBeamAmmo] = 1;
$VehicleInvList[IonBeamAmmo] = 1;
$SellAmmo[IonBeamAmmo] = 10;
$WeaponAmmo[IonBeam] = IonBeamAmmo;

addWeapon(IonBeam);
addAmmo(IonBeam, IonBeamAmmo, 10);

LaserData IonBeamBolt
{
   laserBitmapName   = "forcefield.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.0;
   baseDamageType    = $PsiDamageType;
   beamTime          = 0.5;
   detachFromShooter = true;
//   hitSoundId        = SoundLaserHit;
};

BulletData IonBeamRocket 
{
  bulletShapeName = "mortar.dts";
  explosionTag  = rocketExp;
  damageClass = 1;
  damageValue = 1.4;
  damageType = $DeathDamageType;
  explosionRadius = 13.0;
  muzzleVelocity = 800.0;
  totalTime = 0.4;
  liveTime = 0.4;
  inheritedVelocityScale = 0.0;
  isVisible = False;
};

ItemData IonBeamAmmo 
{
  description = "Ion Beam Charges";
  className = "Ammo";
  shapeFile = "liqcyl";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData IonBeamImage
{
   shapeFile  = "Sniper";
	mountPoint = 0;

      weaponType = 0; // Single Shot
	projectileType = "Undefined";
	reloadTime = 2.0;
	fireTime = 1.0;
        ammoType = IonBeamAmmo;

	accuFire = false;

	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData IonBeam
{
   heading = $InvHead[ihWet];
	description = "Ion Cannon";
	className = "Weapon";
   shapeFile  = "Sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = IonBeamImage;
	price = 500;
	showWeaponBar = true;
};

function IonBeam::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Ion Cannon: <f2>Fires a highly concentrative ion beam that explodes on contact.");
}

function IonBeamImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[IonBeam]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[IonBeam],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

                        Projectile::spawnProjectile("IonBeamRocket",%trans,%player,%vel);
                        Projectile::spawnProjectile("IonBeamBolt",%trans,%player,%vel);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}
