//vespene laser, toss, M
$InvList[PLasGun] = 1;
$RemoteInvList[PLasGun] = 1;
$AutoUse[PLasGun] = True;
$WeaponAmmo[PLasGun] = "";
$VehicleInvList[PLasGun] = 1;

addWeapon(PLasGun);

LaserData PSlaser
{
   laserBitmapName   = "grn_blink1.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.028;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.7;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

ItemImageData PLasGunImage
{
   shapeFile  = "energygun";
	mountPoint = 0;
        mountRotation = 
        {
         0, -1.5, 0 }
        ;
      weaponType = 0; // Single Shot
	projectileType = PSlaser;
	reloadTime = 0.3;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 10;

	accuFire = true;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PLasGun
{
   heading = $InvHead[ihWet];
	description = "Vespene Laser";
	className = "Weapon";
   shapeFile  = "invent_remote";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = PLasGunImage;
	price = 500;
	showWeaponBar = true;
};

function PLasGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Vespene Laser: <f2>Cuts a bloody swathe through enemies with a rapid fire Vespene laser.");
}
