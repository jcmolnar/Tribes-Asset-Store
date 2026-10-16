//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Chaos Stream
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Stream] = 1;
$RemoteInvList[Stream] = 1;
$WeaponAmmo[Stream] = "";
$AutoUse[Stream] = True;

addWeapon(Stream);

BulletData StreamBolt 
{
  bulletShapeName = "mortartrail.dts";
  explosionTag = PlasmaExp;
  damageClass = 1;
  damageValue = 0.08;
  damageType = $PsiDamageType;
  explosionRadius = 8.0;
  muzzleVelocity = 30.0;
  totalTime = 4.5;
  liveTime = 4.5;
  lightRange = 1.0;
  lightColor = { 0, 2, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};
ItemImageData StreamImage 
{
  shapeFile = "sensor_small";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.05;
  fireTime = 0.05;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = StreamBolt;
  accuFire = true;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};
ItemData Stream 
{
  heading = $InvHead[ihPsi];
  description = "Destructor";
  className = "Weapon";
  shapeFile = "sensor_small";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = StreamImage;
  price = 985;
  showWeaponBar = true;
};

function Stream::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "This power shoots a solid stream of chaotic energy forth, easily killing most targets.");
}

