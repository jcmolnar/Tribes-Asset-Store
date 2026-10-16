//Tractor Beam, Earth Alliance, H
$InvList[Gravi] = 1;
$RemoteInvList[Gravi] = 1;
$AutoUse[Gravi] = True;
$WeaponAmmo[Gravi] = "";
$VehicleInvList[Gravi] = 1;

addWeapon(Gravi);

RocketData GraviShot
{
   bulletShapeName  = "tracer.dts";
   explosionTag     = Shockwave;
   collisionRadius  = 0.1;
   mass             = 0.1;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $PsiDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = -999.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 999.0;
   totalTime        = 4.0;
   liveTime         = 4.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailString = "paint.dts";
   smokeDist   = 1;
};

ItemImageData GraviImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
      mountRotation = 
  {
   0, 2.0, 0 }
  ;

       
	weaponType = 0; // Single Shot
	projectileType = GraviShot;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.01;
        damageClass = 0;
        damageValue = 0.05;
	minEnergy = 49;
	maxEnergy = 50;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Gravi
{
	description = "Tractor Beam";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "energyRifle";
   heading = $InvHead[ihWet];
	shadowDetailMask = 4;
	imageType = GraviImage;
	price = 950;
	showWeaponBar = true;
};

function Gravi::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Tractor Beam: <f2>Attract enemies. For a gnasty combo, use the Tractor Beam to get your enemy close to you then destroy him with an Energy Sword. ");
}
