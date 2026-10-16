
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Laser Rifle (LaserRifle)
//  By Dynamix
//
//  Alliance version by Mjolnir, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[LaserRifle] = 1;
$RemoteInvList[LaserRifle] = 1;
$AutoUse[LaserRifle] = True;
$WeaponAmmo[LaserRifle] = "";

addWeapon(LaserRifle);

LaserData sniperLaser 
{
  laserBitmapName = "plasmabolt.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.013;
  baseDamageType = $LaserDamageType;
  beamTime = 1.3;
  lightRange = 2.0;
  lightColor = { 1.0, 0.25, 0.25 } ;
  detachFromShooter = false;
  hitSoundId = SoundLaserHit;
};

ItemImageData LaserRifleImage 
{
  shapeFile = "grenadeL";
  mountPoint = 0;
  weaponType = 0;
  projectileType = SniperLaser;
  accuFire = true;
  reloadTime = 13.5;
  minEnergy = 120;
  maxEnergy = 140;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = { 1, 0, 0 };
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundLaserCannonLoop;
};

ItemData LaserRifle 
{
  description = "Laser Cannon";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "sniper";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = LaserRifleImage;
  price = 2000;
  showWeaponBar = true;
};

function LaserRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Laser Cannon");
}

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack || Player::getMountedItem(%player,$BackpackSlot) == LaserPack)
		Weapon::onUse(%player,%item);
         
	else 
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use a Laser Cannon."); }

