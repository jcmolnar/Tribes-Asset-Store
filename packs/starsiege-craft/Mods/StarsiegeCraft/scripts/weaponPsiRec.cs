//Psionic receptive, toss, L
$InvList[LongRifle] = 1;
$RemoteInvList[LongRifle] = 1;
$VehicleInvList[LongRifle] = 1;
$VehicleInvList[LongAmmo] = 1;
$AutoUse[LongRifle] = False;
$WeaponAmmo[LongRifle] = LongAmmo;
$SellAmmo[LongAmmo] = 15;
$InvList[LongAmmo] = 1;
$RemoteInvList[LongAmmo] = 1;

addWeapon(LongRifle);
addAmmo(LongRifle, LongAmmo, 5);

RocketData pulsesnipe
{
  bulletShapeName = "discb.dts";
  explosionTag = EnergyExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 0;
  explosionRadius = 6.0;
  damageValue = 1;
  damageType = $SniperDamageType;
  kickBackStrength = 100.0;
  muzzleVelocity = 2000.0;
  terminalVelocity = 2000.0;
  acceleration = 9.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 1.0;
};

RocketData pulsedisc
{
  bulletShapeName = "discb.dts";
  explosionTag = RocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  explosionRadius = 12.0;
  damageValue = 0.6;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 100.0;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  acceleration = 5.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailWidth = 0.5;
  trailLength = 30.0;
};

GrenadeData pulsegren
{
  bulletShapeName = "discb.dts";
  explosionTag = RocketExp;
  ownerGraceMS = 250;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  explosionRadius = 15.0;
  damageValue = 0.7;
  damageType = $ShrapnelDamageType;
  elasticity = 0.2;
  maxLevelFlightDist = 150;
  collideWithOwner = True;
  kickBackStrength = 100.0;
  totalTime = 4.0;
  liveTime = 1.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 1.0;
  projSpecialTime = 0.05;
  smokeName = "MFlame.dts";
  smokeDist = 0.8;
};

ItemData LongAmmo 
{
  description = "Psionic Receptives";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData LongRifleImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = LongAmmo;
  projectileType = Undefined;
  accuFire = true;
  reloadTime = 1.2;
  fireTime = 1.0;
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
  description = "Psionic Receptive";
  className = "Weapon";
  shapeFile = "Sniper";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = LongRifleImage;
  price = 675;
  showWeaponBar = true;
};

function LongRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Psionic Receptive: <f2>a versatile weapon, with multiple modes of fire 'Tab menu'.");
}

function LongRifleImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[LongRifle]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[LongRifle],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);


			if (%playerId.PROpt == 0)
			{
				Projectile::spawnProjectile("pulsedisc",%trans,%player,%vel);
			}
			else if (%playerId.PROpt == 1)
			{
				Projectile::spawnProjectile("pulsegren",%trans,%player,%vel);
			}
			else if (%playerId.PROpt == 2)
			{
				Projectile::spawnProjectile("pulsesnipe",%trans,%player,%vel);
			}
		}
}
