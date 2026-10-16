$InvList[AlienLaser] = 1;       //This gun was made off of War40k's Bright Lance.
$RemoteInvList[AlienLaser] = 1;
$AutoUse[AlienLaser] = False;
$WeaponAmmo[AlienLaser] = "";

addWeapon(AlienLaser);

LaserData AlienRay
{
   laserBitmapName   = "warp.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.010;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.5;
   lightRange        = 1.0;
   lightColor        = { 0.0, 1.25, 1.25 };
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

ItemImageData AlienLaserImage
{
      shapeFile  = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 360.0, 0 };
      weaponType = 0; // Single Shot
	projectileType = AlienRay;
	reloadTime = 0.9;
	fireTime = 0.1;
	minEnergy = 25;
	maxEnergy = 25;
      accuFire = true;
      sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AlienLaser
{
   heading = $InvHead[ihWea];
	description = "Alien Laser";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = AlienLaserImage;
	price = 550;
	showWeaponBar = true;
};

function AlienLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Alien Laser");
}

function AlienLaser::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack || Player::getMountedItem(%player,$BackpackSlot) == LaserPack)
		Weapon::onUse(%player,%item);
         
	else 
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use an Alien Laser."); }