$ItemMax[armormSniper, SMRPack] = 0;
$ItemMax[armorfSniper, SMRPack] = 0;
$ItemMax[armormScout, SMRPack] = 0;
$ItemMax[armormMercenary, SMRPack] = 0;      // line 800
$ItemMax[armorfMercenary, SMRPack] = 0;
$ItemMax[armormBurster, SMRPack] = 0;
$ItemMax[armorCyborg, SMRPack] = 1;
$ItemMax[armorfScout, SMRPack] = 0;
$ItemMax[armorfBurster, SMRPack] = 0;
$ItemMax[armormSpy, SMRPack] = 0;
$ItemMax[armorfSpy, SMRPack] = 0;
$ItemMax[armormEngineer, SMRPack] = 0;
$ItemMax[armorfEngineer, SMRPack] = 0;
$ItemMax[armormAlien, SMRPack] = 0;
$ItemMax[armorfAlien, SMRPack] = 0;
$ItemMax[dmarmor, SMRPack] = 1;
$ItemMax[dmfemale, SMRPack] = 1;
$ItemMax[armormLoader, SMRPack] = 0;
$ItemMax[armorfLoader, SMRPack] = 0;
$ItemMax[armormSprint, SMRPack] = 0;
$ItemMax[armorfSprint, SMRPack] = 0;


$InvList[SMRPack] = 1;
$RemoteInvList[SMRPack] = 1;

addAmmo(SMRPack, SMRAmmo, 1);

RocketData SMRMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "dustplume.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

ItemImageData SMRPackImage 
{
  shapeFile = "mortargun";
  mountPoint = 2;
  mountOffset = { -0.4, 0.1, 0.4 };
  mountRotation = { 0.2, 0, 0 };
  weaponType = 0;
  ammoType = SMRAmmo;
  projectileType = SMRMissile;
  accuFire = true;
  reloadTime = 5.0;
  fireTime = 0.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundMissileTurretFire;
  sfxReload = SoundMortarReload;
};

ItemData SMRAmmo
{
  description = "Auto-Rockets";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "rocket";
  shadowDetailMask = 4;
  price = 30;
};

ItemData SMRPack 
{
  description = "Auto-Rocket Cannon";
  shapeFile = "mortargun";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = SMRPackImage;
  price = 350;
  hudIcon = "mortar";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function SMRPackImage::onActivate(%player,%imageSlot) 
{
  schedule("use(\"backpack\");", 0.5);
}

function SMRPackImage::onDeactivate(%player,%imageSlot) 
{
  Player::trigger(%player,$BackpackSlot,false);
}
