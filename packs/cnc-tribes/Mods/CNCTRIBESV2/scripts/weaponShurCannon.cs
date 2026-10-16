
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Shuriken Cannon
//  By <[DC]>Paladin/(C<Paladin>K)
//
//  Alliance version by Mjolnir, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[ShurCannon] = 1;
$InvList[ShurAmmo] = 1;
$RemoteInvList[ShurCannon] = 1;
$RemoteInvList[ShurAmmo] = 1;
$SellAmmo[ShurAmmo] = 5;
$WeaponAmmo[ShurCannon] = ShurAmmo;
$AutoUse[ShurCannon] = False;

addWeapon(ShurCannon);
addAmmo(ShurCannon, ShurAmmo, 2);

BulletData HShuriken
{
   bulletShapeName    = "discb.dts";
   explosionTag       = bulletExp0;

   damageClass        = 0;
   damageValue        = 0.45;
   damageType         = $ShurikenDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 4.0;
   liveTime           = 4.0;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

ItemData ShurAmmo 
{
  description = "Heavy Shuriken";
  className = "Ammo";
  shapeFile = "discammo";
  heading = xAmmunition;
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData ShurCannonImage 
{
  shapeFile = "GrenadeL";
  mountPoint = 0;
  weaponType = 3;
  ammoType = ShurAmmo;
  projectileType = HShuriken;
  accuFire = true;
  reloadTime = 0.1;
  fireTime = 0.1;
  spinUpTime = 0.35;
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
};

ItemData ShurCannon 
{
  description = "Shuriken Cannon";
  className = "Weapon";
  shapeFile = "GrenadeL";
  hudIcon = "disk";
  heading = $InvHead[ihWel];
  shadowDetailMask = 4;
  imageType = ShurCannonImage;
  price = 18;
  showWeaponBar = true;
};

function ShurCannon::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Shuriken Cannon: Far more powerful than it's smaller counterpart, this weapon is a truly lethal addition to the eldar weapons arsenal.");
}