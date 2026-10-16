//Double Flame Thrower, Terran, M
$InvList[TwoFlame] = 1;
$InvList[TwoFlameAmmo] = 1;
$RemoteInvList[TwoFlame] = 1;
$RemoteInvList[TwoFlameAmmo] = 1;
$VehicleInvList[TwoFlame] = 1;
$VehicleInvList[TwoFlameAmmo] = 1;
$AutoUse[TwoFlame] = False;
$SellAmmo[TwoFlameAmmo] = 50;
$WeaponAmmo[TwoFlame] = TwoFlameAmmo;

addWeapon(TwoFlame);
addAmmo(TwoFlame, TwoFlameAmmo, 50);

GrenadeData Doublegren
{
  bulletShapeName = "PlasmaBolt.dts";
  explosionTag = plasmaExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.05;
  damageType = $FlamerDamageType;
  explosionRadius = 15;
  kickBackStrength = 0;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 0.001;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "Plasmatrail.dts";
  smokeDist = 5;
};

ItemData TwoFlameAmmo 
{
  description = "Flame Units";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData TwoFlameImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
   mountOffset = 
   {
   -0.7, 0.0, 0.0 }
   ;
   mountRotation = 
   {
   0.0, 0, 0 }
   ;
  weaponType = 0;
  ammoType = TwoFlameAmmo;
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

ItemData TwoFlame
{
  description = "Double Flame Thrower";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = TwoFlameImage;
  price = 300;
  showWeaponBar = true;
};

function TwoFlameImage::onFire(%player,%item) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[TwoFlame]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[TwoFlame],2);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
                       // Projectile::spawnProjectile("Silencergren",%trans-7,%player,%vel);
                        Projectile::spawnProjectile("Doublegren",%trans,%player,%vel);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of flames");
}

function TwoFlame::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Double Flame Thrower: <f2>Two flamers mounted together for double the fun. SSC site: http://www.tribes-universe.com/StarSiegeCraft");
  Player::mountItem(%player,Silencer,4);
//  Player::mountItem(%player,TwoFlame,$WeaponSlot);
  Weapon::onMount(%player,%item);
  Weapon::onUse(%player,%item);
}

function TwoFlame::onDrop(%player,%item) 
{
  Player::unmountItem(%player,4);
  Player::unmountItem(%player,TwoFlame,$WeaponSlot);
}

function TwoFlame::onUnMount(%player,%item)
{
  Player::unmountItem(%player,4);
  Player::unmountItem(%player,TwoFlame,$WeaponSlot);
  Item::onUnMount(%player,%item);
}
