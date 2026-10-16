//Optical flares, medic, made by Ecliptici, blinding code in player.cs by Matthias
$InvList[FCan] = 1;
$InvList[FCanAmmo] = 1;
$RemoteInvList[FCan] = 1;
$RemoteInvList[FCanAmmo] = 1;
$VehicleInvList[FCan] = 1;
$VehicleInvList[FCanAmmo] = 1;
$AutoUse[FCan] = False;
$SellAmmo[FCanAmmo] = 5;
$WeaponAmmo[FCan] = FCanAmmo;

addWeapon(FCan);
addAmmo(FCan, FCanAmmo, 2);

GrenadeData FCanShell 
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = fcanExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 3.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.0;
  damageType = $BlindDamageType;
  explosionRadius = 25.0;
  kickBackStrength = -150.0;
  maxLevelFlightDist = 200;
  totalTime = 5.0;
  liveTime = 1.6;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "flash_small.dts";
};

GrenadeData FCanBShell 
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = fcanbExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 3.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.75;
  damageType = $MortarDamageType;
  explosionRadius = 12.0;
  kickBackStrength = 300.0;
  maxLevelFlightDist = 200;
  totalTime = 5.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "flash_medium.dts";
};

ItemData FCanAmmo 
{
  description = "Flash Grenades";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData FCanImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = FCanAmmo;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 1.0;
  fireTime = 1.5;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 1, 0, 0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundDiscReload;
};

ItemData FCan 
{
  description = "Optical Flares";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = FCanImage;
  price = 525;
  showWeaponBar = true;
};

function FCanImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[FCan]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[FCan],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("FCanShell",%trans,%player,%vel);
                        Projectile::spawnProjectile("FCanBShell",%trans,%player,%vel);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}

function FCan::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Flash Grenade Launcher: <f2>A medical device originally used to illuminate the battlefield, now modified to fire multiple high explosive flash grenades, as well as blind people for a short time.");
}
