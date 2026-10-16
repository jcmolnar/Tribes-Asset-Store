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
   laserBitmapName   = "discglow1.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.015;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 1.0;
   lightColor        = { 0.0, 0.0, 1.25 };

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
	fireTime = 0.1;
	minEnergy = 9;
	maxEnergy = 18;

	accuFire = true;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HyperB
{
   heading = $InvHead[ihWea];
	description = "Las Gun";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HyperBImage;
	price = 285;
	showWeaponBar = true;
};

function HyperB::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Las Gun: A standard infantry weapon. A good all around weapon.");
}
