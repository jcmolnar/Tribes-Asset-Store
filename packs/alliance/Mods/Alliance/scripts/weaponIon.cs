
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Ion Rifle (IonGun)
//  By Renegades
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[IonGun] = 1;
$RemoteInvList[IonGun] = 1;
$AutoUse[IonGun] = True;
$WeaponAmmo[IonGun] = "";

addWeapon(IonGun);

ItemImageData IonGunImage
{
  shapeFile = "GrenadeL";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0;
  fireTime = 0.3;
  minEnergy = 19;
  maxEnergy = 20;
  projectileType = IonBolt;
  accuFire = true;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData IonGun 
{
  heading = $InvHead[ihWea];
  description = "Ion Rifle";
  className = "Weapon";
  shapeFile = "GrenadeL";
  hudIcon = "targetlaser";
  shadowDetailMask = 4;
  imageType = IonGunImage;
  price = 250;
  showWeaponBar = true;
};

function IonGun::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Ion Rifle.  Shoots ion blasts at target.");
}

