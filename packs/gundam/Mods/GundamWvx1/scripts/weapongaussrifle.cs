//Machine Gun
$InvList[HyperB] = 1;
$RemoteInvList[HyperB] = 1;
$VehicleInvList[HyperB] = 1;
$AutoUse[HyperB] = False;
$InvList[HyperBAmmo] = 1;
$RemoteInvList[HyperBAmmo] = 1;
$VehicleInvList[HyperBAmmo] = 1;
$SellAmmo[HyperBAmmo] = 100;
$WeaponAmmo[HyperB] = HyperBAmmo;

addWeapon(HyperB);
addAmmo(HyperB, HyperBAmmo, 100);

BulletData LasBolt
{
   bulletShapeName   = "bullet.dts";
   explosionTag      = bulletexp1;
   expRandCycle      = 4;
   damageType        = 0;
   damageValue       = 0.1;
   bulletholeIndex   = 0;
   baseDamageType    = $ShellDamageType;
   damageType        = $ShellDamageType;
   aimDeflection     = 0.002;
   liveTime          = 0.4;
   totalTime         = 0.4;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   muzzleVelocity    = 800.0;
   terminalVelocity  = 800.0;
   acceleration      = 20.0;
   inheritedVelocityScale = 0.2;
   detachFromShooter = false;
};

GrenadeData GRgren
{
  bulletShapeName = "bullet.dts";
  explosionTag = debrisExpSmall;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.2;
  damageType = $ShrapnelDamageType;
  explosionRadius = 8;
  kickBackStrength = 150.0;
  maxLevelFlightDist = 150;
  totalTime = 30.0;
  liveTime = 0.2;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
//  smokeName = "shield.dts";
  smokeDist = 25.0;
};

ItemData HyperBAmmo 
{
  description = "Machine Gun Bullets";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData HyperBImage
{
   shapeFile  = "chaingun";
	mountPoint = 0;
      mountRotation = 
  {
   0, 1.0, 0 }
  ;

        spinUpTime = 0.4;
        spinDownTime = 1.5;
        weaponType = 0;
	projectileType = Undefined;
	ammoType = HyperBAmmo;
	reloadTime = 0.01;
	fireTime = 0.001;
	minEnergy = 0.2;
	maxEnergy = 1;

	accuFire = false;
        sfxSpinUp = SoundSpinUp;
//	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HyperB
{
   heading = $InvHead[ihWet];
	description = "Machine Gun";
	className = "Weapon";
   shapeFile  = "chaingun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HyperBImage;
	price = 800;
	showWeaponBar = true;
};

function HyperB::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Machine Gun: <f2>An old type of chain gun that was upgraded to be more powerfull.");
}

function HyperBImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[HyperB]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.GROpt == 0)
			{
				Player::decItemCount(%player,$WeaponAmmo[HyperB],2);
				Projectile::spawnProjectile("LasBolt",%trans,%player,%vel);
				Projectile::spawnProjectile("LasBolt",%trans,%player,%vel);
				GameBase::playSound(%player, SoundLaserHit, 0);
			}
			else if (%playerId.GROpt == 1)
			{
				Player::decItemCount(%player,$WeaponAmmo[HyperB],8);
				Projectile::spawnProjectile("GRgren",%trans,%player,%vel);
				GameBase::playSound(%player, DebrisMediumExplosion, 0);
			}
			else if (%playerId.GROpt == 2)
			{
				Projectile::spawnProjectile("LasBolt",%trans,%player,%vel);
				Projectile::spawnProjectile("LasBolt",%trans,%player,%vel);
				Projectile::spawnProjectile("GRgren",%trans,%player,%vel);
				Player::decItemCount(%player,$WeaponAmmo[HyperB],10);
				GameBase::playSound(%player, DebrisSmallExplosion, 0);
			}
		}
}
