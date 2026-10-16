//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Long Rifle
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[LongRifle] = 1;
$RemoteInvList[LongRifle] = 1;
$AutoUse[LongRifle] = False;
$WeaponAmmo[LongRifle] = LongAmmo;
$SellAmmo[LongAmmo] = 15;
$InvList[LongAmmo] = 1;
$RemoteInvList[LongAmmo] = 1;

addWeapon(LongRifle);
addAmmo(LongRifle, LongAmmo, 5);


ItemData LongAmmo 
{
  description = "Long Rifle Ammo";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData LongRifleImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = LongAmmo;
  projectileType = LongRound;
  accuFire = true;
  reloadTime = 1.0;
  fireTime = 0.3;
  lightType = 3;
  lightRadius = 2;
  lightTime = 2;
  lightColor = 
  {
    1.0, 0, 0 }
  ;
  sfxFire = SoundPackFail;
  sfxReload = SoundPickupAmmo;
  sfxActivate = SoundPickupWeapon;
};


ItemData LongRifle 
{
  description = "Long Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWel];
  shadowDetailMask = 4;
  imageType = LongRifleImage;
  price = 475;
  showWeaponBar = true;
};

function LongRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Long Rifle: A long distance weapon. Not as potent as the Sniper Rifle, but explosive bullets are worth it's while.");
}