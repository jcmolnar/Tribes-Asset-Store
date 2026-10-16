//Flame Thrower, Terran, L
//compatibility with firebat fuel tank by ecliptici
$InvList[Silencer] = 1;
$InvList[SilencerAmmo] = 1;
$RemoteInvList[Silencer] = 1;
$RemoteInvList[SilencerAmmo] = 1;
$VehicleInvList[Silencer] = 1;
$VehicleInvList[SilencerAmmo] = 1;
$AutoUse[Silencer] = False;
$SellAmmo[SilencerAmmo] = 50;
$WeaponAmmo[Silencer] = SilencerAmmo;

addWeapon(Silencer);
addAmmo(Silencer, SilencerAmmo, 50);

GrenadeData Silencergren
{
  bulletShapeName = "PlasmaBolt.dts";
  explosionTag = plasmaExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.08;
  damageType = $PlasmaDamageType;
  explosionRadius = 8;
  kickBackStrength = 0;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 0.001;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "Plasmatrail.dts";
  smokeDist = 1.5;
};

GrenadeData Silencergren2
{
  bulletShapeName = "PlasmaBolt.dts";
  explosionTag = grenadeExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.15;
  damageType = $PlasmaDamageType;
  explosionRadius = 10;
  kickBackStrength = 0;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 0.001;
  projSpecialTime = 0.10;
  inheritedVelocityScale = 0.5;
  smokeName = "fiery.dts";
  smokeDist = 1.5;
};

ItemData SilencerAmmo 
{
  description = "Flame Cartridges";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData SilencerImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = SilencerAmmo;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 0.1;
  fireTime = 0.1;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData Silencer 
{
  description = "Flame Thrower";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = SilencerImage;
  price = 250;
  showWeaponBar = true;
};

function Silencer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Perdition Flame Thrower: <f2>A new prototype flame thrower that can be used with a fuel tank to supercharge it and the firebat's grenades. www.planetstarsiege.com/ssc");
}

function SilencerImage::onFire(%player, %slot) 
{		
		 %playerId = Player::getClient(%player);
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[Silencer]);
	 	 %pack = Player::getItemCount(%player, OpticPack);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		       %vel = Item::getVelocity(%player);
			 if(%Ammo) 
		 	 {
      		 	if(%pack >= 1)
      		 	{
				Player::decItemCount(%player,$WeaponAmmo[Silencer],4);
				Projectile::spawnProjectile("Silencergren2",%trans,%player,%vel);
      		 	}
      			else
			 	{
				Player::decItemCount(%player,$WeaponAmmo[Silencer],1);
				Projectile::spawnProjectile("Silencergren",%trans,%player,%vel);
      		 	}
			}
}
