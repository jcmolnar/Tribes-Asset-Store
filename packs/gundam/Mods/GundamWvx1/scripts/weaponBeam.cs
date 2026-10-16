//destruction beam, earth alliance,M
$InvList[PsiLaser] = 1;
$RemoteInvList[PsiLaser] = 1;
$AutoUse[PsiLaser] = True;
$WeaponAmmo[PsiLaser] = "";
$VehicleInvList[PsiLaser] = 1;

addWeapon(PsiLaser);

LaserData PsiLaserBolt
{
   laserBitmapName   = "mort0000.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.024;
   baseDamageType    = $PsiDamageType;
   beamTime          = 0.7;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

ItemImageData PsiLaserImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
      mountRotation = 
  {
   0, -3.0, 0 }
  ;

      weaponType = 0; // Single Shot
	projectileType = PsiLaserBolt;
	reloadTime = 1.0;
	fireTime = 0.1;
	minEnergy = 19;
	maxEnergy = 70;

	accuFire = true;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PsiLaser
{
   heading = $InvHead[ihWet];
	description = "Destruction Beam";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = PsiLaserImage;
	price = 500;
	showWeaponBar = true;
};

function PsiLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Destruction Beam: <f2>This is a powerfull laser rifle like weapon. A fully charged beam from this gun can destroy almost all Gundams.");
}

