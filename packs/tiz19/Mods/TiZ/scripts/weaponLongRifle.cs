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
  description = "Scorpion Rifle Ammo";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData LongRifleImage 
{
  shapeFile = "chaingun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = LongAmmo;
  projectileType = LongRound;
  accuFire = true;
  reloadTime = 0.09;
  fireTime = 0.01;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = 
  {
    1.0, 0, 0 }
  ;
  sfxFire = SoundFireBlaster;
  sfxActivate = SoundPickUpWeapon;
};


ItemData LongRifle 
{
  description = "Scorpion Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = LongRifleImage;
  price = 475;
  showWeaponBar = true;
};

function LongRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Scorpion Rifle: A modified version of the Sniper Rifle. The Scorpion Rifle fires rapid fire sniper bullets, making it able to take out turrets, force fields, or heavy armor.");
}