//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Boltgun: modded from magnum
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Silencer] = 1;
$InvList[SilencerAmmo] = 1;
$RemoteInvList[Silencer] = 1;
$RemoteInvList[SilencerAmmo] = 1;
$AutoUse[Silencer] = False;
$SellAmmo[SilencerAmmo] = 25;
$WeaponAmmo[Silencer] = SilencerAmmo;

addWeapon(Silencer);
addAmmo(Silencer, SilencerAmmo, 5);

RocketData SilencerBullet 
{
  bulletShapeName = "rocket.dts";
  explosionTag = debrisExpSmall;
  expRandCycle = 1;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.1;
  damageType = $BulletDamageType;
  explosionRadius = 3.5;
  kickBackStrength = 0.0;
  muzzleVelocity = 165.0;
  terminalVelocity = 2000.0;
  acceleration = 100.0;
  totalTime = 3.5;
  liveTime = 3.5;
  lightRange = 5.0;
  lightColor = { 0.0, 0.0, 0.0 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "rsmoke.dts";
  smokeDist = 0.0;
  soundId = SoundJetHeavy;
};

ItemData SilencerAmmo 
{
  description = "Bolter Rounds";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData SilencerImage 
{
  shapeFile = "handg";
  mountPoint = 0;
  weaponType = 0;
  MountOffset = { 0.0, 0.0, -0.05 };
  ammoType = SilencerAmmo;
  projectileType = "Undefined";
  accuFire = true;
  reloadTime = 0.1;
  fireTime = 0.05;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 0, 0, 0 };
  sfxFire = SoundFireBlaster;
  sfxActivate = SoundPickUpWeapon;
};

function SilencerImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[Silencer]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[Silencer],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);


			if (%playerId.isgod == 1)
			{
				Projectile::spawnProjectile("SilencerBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("BolterInferno",%trans,%player,%vel);
				Projectile::spawnProjectile("BolterSlug",%trans,%player,%vel);
				Projectile::spawnProjectile("BolterHellfire",%trans,%player,%vel);
				Projectile::spawnProjectile("BolterKraken",%trans,%player,%vel);
			}
			else if (%playerId.BOpt == 0)
			{
				Projectile::spawnProjectile("SilencerBullet",%trans,%player,%vel);
			}
			else if (%playerId.BOpt == 1)
			{
				Projectile::spawnProjectile("BolterInferno",%trans,%player,%vel);
			 Player::decItemCount(%player,$WeaponAmmo[Silencer],1);
			}
			else if (%playerId.BOpt == 2)
			{
				Projectile::spawnProjectile("BolterSlug",%trans,%player,%vel);
			 Player::decItemCount(%player,$WeaponAmmo[Silencer],1);
			}
			else if (%playerId.BOpt == 3)
			{
				Projectile::spawnProjectile("BolterHellfire",%trans,%player,%vel);
			 Player::decItemCount(%player,$WeaponAmmo[Silencer],1);
			}
			else if (%playerId.BOpt == 4)
			{
				Projectile::spawnProjectile("BolterKraken",%trans,%player,%vel);
			 Player::decItemCount(%player,$WeaponAmmo[Silencer],1);
			}
		}
}

ItemData Silencer 
{
  description = "Boltgun";
  className = "Weapon";
  shapeFile = "handg";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWma];
  shadowDetailMask = 4;
  imageType = SilencerImage;
  price = 375;
  showWeaponBar = true;
};

function Silencer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Bolt Gun: The standard issue weapon of the space marines. A worthy weapon against any foe.");
}


//--=-=-==-=-=-=-=-=-=-NE WBOLTER AMMO VARIANTS

//Bolter "Inferno" Round(incendiary)

BulletData BolterInferno 
{
  bulletShapeName = "rocket.dts";
  explosionTag = FireExp;
  expRandCycle = 1;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.05;
  damageType = $PlasmaDamageType;
  aimDeflection = 0.003;
  muzzleVelocity = 425.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
};

//Bolter Slug Round(bullet)

BulletData BolterSlug 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.05;
  damageType = $ShrapnelDamageType;
  aimDeflection = 0.003;
  muzzleVelocity = 425.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
};

//Bolter "Hellfire" Rounds(acid)

BulletData BolterHellfire 
{
  bulletShapeName = "bullet.dts";
  explosionTag = flashExpSmall;
  expRandCycle = 1;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.05;
  damageType = $AcidDamageType;
  aimDeflection = 0.003;
  muzzleVelocity = 425.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
};

//Bolter "Kraken" Rounds(armor piercing)

BulletData BolterKraken 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 1;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.13;
  damageType = $KrakenDamageType;
  aimDeflection = 0.003;
  muzzleVelocity = 425.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
};