//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Flamer
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Flamer] = 1;
$RemoteInvList[Flamer] = 1;
$WeaponAmmo[Flamer] = "";
$AutoUse[Flamer] = False;

addWeapon(Flamer);

BulletData FlamerBolt 
{
  bulletShapeName = "tumult_small.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.3;
  damageType = $PlasmaDamageType;
  explosionRadius = 3.0;
  muzzleVelocity = 30.0;
  totalTime = 0.55;
  liveTime = 0.55;
  lightRange = 6.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};
ItemImageData FlamerImage 
{
  shapeFile = "mortar";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.05;
  fireTime = 0.05;
  minEnergy = 5;
  maxEnergy = 7;
  projectileType = FlamerBolt;
  accuFire = true;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};
ItemData Flamer 
{
  heading = $InvHead[ihWea];
  description = "Flamer";
  className = "Weapon";
  shapeFile = "GrenadeL";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = FlamerImage;
  price = 385;
  showWeaponBar = true;
};

function Flamer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Flamer: This is a man's best friend. Napalm is superheated and spouted forth as a flaming stream. Would you like yours regular or X-TRA crispy?");
}
