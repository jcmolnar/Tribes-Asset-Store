//glave wurm, zurg, H
$InvList[Gravi] = 1;
$RemoteInvList[Gravi] = 1;
$AutoUse[Gravi] = True;
$WeaponAmmo[Gravi] = "";
$VehicleInvList[Gravi] = 1;

addWeapon(Gravi);

GrenadeData GraviBomb
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.25;
  damageClass = 1;
  damageValue = 1.8;
  damageType = $PsiDamageType;
  explosionRadius = 25.0;
  kickBackStrength = -300.0;
  maxLevelFlightDist = 275;
  totalTime = 20.0;
  liveTime = 0.5;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokename = "dustplume.dts";
  smokeDist = 3.0;
};

RocketData GraviShot
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = Shockwave;
   collisionRadius  = 0.0;
   mass             = 0.2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $PsiDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = -250.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 4.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailString = "paint.dts";
   smokeDist   = 2;
};

ItemImageData GraviImage
{
	shapeFile = "camera";
	mountPoint = 0;
//        mountOffset = 
//        {
//        0.0, -0.5, 0.2 }
//        ;
	weaponType = 0; // Single Shot
	projectileType = "Undefined";
	accuFire = true;
	reloadTime = 1;
	fireTime = 3;
        damageClass = 1;
        damageValue = 0.05;
	minEnergy = 0;
	maxEnergy = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Gravi
{
	description = "Glave Wurm";
	className = "Weapon";
	shapeFile = "camera";
	hudIcon = "energyRifle";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = GraviImage;
	price = 800;
	showWeaponBar = true;
};

function Gravi::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Glave Wurm: <f2>This weapon launches a small alien wurm cocoon that is highly volatile... and if disturbed will explode in foreign and poisonous fumes and cause corrosive damage to armor and flesh.");
}

function GraviImage::onFire(%player, %slot) 
{
 %energy = GameBase::getEnergy(%player);
	 if (%energy > 10)
	 {
		%client = GameBase::getOwnerClient(%player);
		%curren = GameBase::getEnergy(%player) - 10;
		GameBase::setEnergy(%player,%curren);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
                        Projectile::spawnProjectile("GraviBomb",%trans,%player,%vel);
	}
        else Client::sendMessage(Player::getClient(%player),1, "Not enough energy to create cocoon.");
        Player::setItemState(%player,$WeaponSlot,"reload");
}
