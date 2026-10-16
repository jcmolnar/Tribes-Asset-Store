//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Psi Beam
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[PsiLaser] = 1;
$RemoteInvList[PsiLaser] = 1;
$AutoUse[PsiLaser] = True;
$WeaponAmmo[PsiLaser] = "";

addWeapon(PsiLaser);

LaserData PsiLaserBolt
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.013;
   baseDamageType    = $PsiDamageType;

   beamTime          = 1.0;

   lightRange        = 1.0;
   lightColor        = { 0.0, 1.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};


ItemImageData PsiLaserImage
{
   shapeFile  = "sensor_small";
	mountPoint = 0;

      weaponType = 0; // Single Shot
	projectileType = PsiLaserBolt;
	reloadTime = 1.3;
	fireTime = 0.1;
	minEnergy = 79;
	maxEnergy = 80;

	accuFire = true;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PsiLaser
{
   heading = $InvHead[ihPsi];
	description = "Beam";
	className = "Weapon";
   shapeFile  = "sensor_small";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = PsiLaserImage;
	price = 2100;
	showWeaponBar = true;
};

function PsiLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "This psionic beam acts as an effective long range weapon. Drains a lot of Psy, however.");
}

