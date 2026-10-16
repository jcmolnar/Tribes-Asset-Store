//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Fusion Gun: Modded from Ion Gun
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[IonGun] = 1;
$RemoteInvList[IonGun] = 1;
$AutoUse[IonGun] = False;
$WeaponAmmo[IonGun] = "";

addWeapon(IonGun);

ItemImageData IonGunImage
{
  shapeFile = "GrenadeL";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0;
  fireTime = 0.5;
  minEnergy = 19;
  maxEnergy = 20;
  projectileType = IonBolt;
  accuFire = false;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData IonGun 
{
  heading = $InvHead[ihWel];
  description = "Fusion Gun";
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
  Bottomprint(%client, "Fusion Gun: Eldar technology at its finest. A particle beam weapon, with area damage.");
}
