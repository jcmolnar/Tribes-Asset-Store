$InvList[TranqGun] = 1;
$InvList[TranqAmmo] = 1;
$RemoteInvList[TranqGun] = 1;
$RemoteInvList[TranqAmmo] = 1;
$AutoUse[TranqGun] = True;
$SellAmmo[TranqAmmo] = 2;
$WeaponAmmo[TranqGun] = TranqAmmo;

addWeapon(TranqGun);
addAmmo(TranqGun, TranqAmmo, 5);

ItemData TranqAmmo 
{
  description = "Poison Dart";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData TranqGunImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = TranqAmmo;
  projectileType = TranqDart;
  accuFire = true;
  reloadTime = 1.5;
  fireTime = 0;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundFireChainGun;
  sfxActivate = SoundPickUpWeapon;
};

ItemData TranqGun 
{
  description = "Poison Dart Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "blaster";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = TranqGunImage;
  price = 475;
  showWeaponBar = true;
};

function TranqGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Dart Rifle");
}
