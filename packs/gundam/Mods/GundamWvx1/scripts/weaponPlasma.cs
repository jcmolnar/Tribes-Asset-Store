$InvList[PlasMeta] = 1;
$RemoteInvList[PlasMeta] = 1;
$VehicleInvList[PlasMeta] = 1;
$AutoUse[PlasMeta] = True;
$WeaponAmmo[PlasMeta] = "";

addWeapon(PlasMeta);

RocketData PlasIC
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.4;
   baseDamageType   = $PsiDamageType;

   explosionRadius  = 50.0;
   kickBackStrength = 100.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 2.0;
   totalTime        = 20.0;
   liveTime         = 20.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 5.0 };
   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "laserhit.dts";
   smokeDist = 0.6;
};

RocketData PlasNC
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 10.0;
   baseDamageType   = $PsiDamageType;

   explosionRadius  = 25.0;
   kickBackStrength = 500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 2.0;
   totalTime        = 20.0;
   liveTime         = 20.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 5.0 };
   inheritedVelocityScale = 0.5;
   TrailType = 2;
   trailString = "plasmatrail.dts";
   smokeDist = 1.0;
};

ItemImageData PlasMetaImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      mountRotation = 
  {
   0, -3.0, 0 }
  ;
	weaponType = 0; // Single Shot
	projectileType = Undefined;
	accuFire = true;
	reloadTime = 1.7;
	fireTime = 1.0;
	minEnergy = 60;
	maxEnergy = 70;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PlasMeta
{
	description = "Ultra Canon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "energyRifle";
   heading = $InvHead[ihWet];
	shadowDetailMask = 4;
	imageType = PlasMetaImage;
	price = 1000;
	showWeaponBar = true;
};

function PlasMeta::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Ultra Canon: <f2>The Earth Alliance's secret weapon. Its realy powerfull, but since its not completed, it some times get out of controls.");
}


function PlasMetaImage::onFire(%player, %slot) 
  {
         if (floor(getRandom() * 24) == 0)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
            Bottomprint(%client, "-WARNING- OUT OF CONTROL");
                        Projectile::spawnProjectile("PlasNC",%trans,%player,%vel);
	 }
	 else
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("PlasIC",%trans,%player,%vel);
         }
	 return;
  }
