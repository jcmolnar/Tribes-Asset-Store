//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Las Blaster: Modded from Rapid Fire Laser(al_renegades)
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[DeathLaser] = 1;
$RemoteInvList[DeathLaser] = 1;
$AutoUse[DeathLaser] = False;
$WeaponAmmo[DeathLaser] = "";
AddWeapon(DeathLaser);

LaserData DeathLaserBeam
{
  laserBitmapName = "laserpulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.015;
  baseDamageType = $LaserDamageType;
  beamTime = 0.1;
  lightRange = 4.0;
  lightColor = { 2, 0, 0 } ;
  detachFromShooter = false;
};

ItemImageData DeathLaserImage 
{
  shapeFile = "chaingun";
  mountPoint = 0;
  weaponType = 1;
  projectileType = DeathLaserBeam;
  accuFire = true;
  minEnergy = 1;
  maxEnergy = 2;
  reloadTime = 0.05;
  spinUpTime = 0.5;
  spinDownTime = 3;
  fireTime = 0.05;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 2, 0, 0 };
  sfxFire = SoundFireChaingun;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DeathLaser
{
  description = "Las Blaster";
  className = "Weapon";
  shapeFile = "chaingun";
  hudIcon = "sniper";
  heading = $InvHead[ihWel];
  shadowDetailMask = 4;
  imageType = DeathLaserImage;
  price = 500;
  showWeaponBar = true;
};

function DeathLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Las Blaster: An eldar weapon, this gun is not potent, but can kill any target in seconds, with a persistant aim.");
}