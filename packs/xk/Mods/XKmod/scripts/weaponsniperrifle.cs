$InvList[SniperRifle] = 1;
$RemoteInvList[SniperRifle] = 1;
$AutoUse[SniperRifle] = True;
$WeaponAmmo[SniperRifle] = SniperAmmo;
$SellAmmo[SniperAmmo] = 15;
$InvList[SniperAmmo] = 1;
$RemoteInvList[SniperAmmo] = 1;

addWeapon(SniperRifle);
addAmmo(SniperRifle, SniperAmmo, 5);

ItemData SniperAmmo 
{
  description = "Sniper Bullet";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData SniperRifleImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = SniperAmmo;
  projectileType = SniperRound;
  accuFire = true;
  reloadTime = 1.5;
  fireTime = 0;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = 
  {
    1.0, 0, 0 }
  ;
  sfxFire = SoundFireChainGun;
  sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
  description = "Sniper Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = SniperRifleImage;
  price = 375;
  showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Sniper Rifle");
}
