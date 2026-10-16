//spore beam, zurg,M
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
   shapeFile  = "plasmabolt";
	mountPoint = 0;

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
   heading = $InvHead[ihPsi];
	description = "Spore Beam";
	className = "Weapon";
   shapeFile  = "plasmabolt";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = PsiLaserImage;
	price = 500;
	showWeaponBar = true;
};

function PsiLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Spore beam: <f2>focuses the energies of the spore colonies into a metamorphic beam.");
}
