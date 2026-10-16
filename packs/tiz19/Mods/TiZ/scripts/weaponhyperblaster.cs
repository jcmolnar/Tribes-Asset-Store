//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Las Gun : Modded from hyper balster..no wher near same
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[HyperB] = 1;
$RemoteInvList[HyperB] = 1;
$AutoUse[HyperB] = False;
$WeaponAmmo[HyperB] = "";

addWeapon(HyperB);

LaserData LasBolt
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.019;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};


ItemImageData HyperBImage
{
   shapeFile  = "sniper";
	mountPoint = 0;

      weaponType = 0; // Single Shot
	projectileType = LasBolt;
	reloadTime = 0.5;
	fireTime = 0.05;
	minEnergy = 20;
	maxEnergy = 90;

	accuFire = true;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HyperB
{
   heading = $InvHead[ihWea];
	description = "Laser Rifle";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HyperBImage;
	price = 85;
	showWeaponBar = true;
};

function HyperB::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Laser Rifle: Used in VERY tight spaces, i.e. where you cannot move anywhere but forwards and backwards. The Laser rifle is sometimes used as a sniper weapon, and it not, is almost as strong as the sniper rifle.");
}
