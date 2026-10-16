//NUCLEAR BOOMBOOM
$InvList[GNuke] = 1;
$InvList[NukeAmmo] = 1;
$RemoteInvList[GNuke] = 1;
$RemoteInvList[NukeAmmo] = 1;
$VehicleInvList[GNuke] = 1;
$VehicleInvList[NukeAmmo] = 1;
$AutoUse[GNuke] = False;
$SellAmmo[NukeAmmo] = 1;
$WeaponAmmo[GNuke] = NukeAmmo;

addWeapon(GNuke);
addAmmo(GNuke, NukeAmmo, 1);

LaserData NukePointer
{
   laserBitmapName   = "repairadd.bmp";
   hitName           = "shotgunex.dts";
   damageConversion  = 0.0;
   baseDamageType    = $PsiDamageType;
   beamTime          = 5.0;
   detachFromShooter = false;
};

GrenadeData GhostNuke
{
  bulletShapeName = "mortar.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 80;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 2;
  damageType = $MeltaDamageType;
  explosionRadius = 70;
  kickBackStrength = 800;
  maxLevelFlightDist = 0;
  totalTime = 15.0;
  liveTime = 0.1;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0;
  smokeName = "shockwave_large.dts";
  smokeDist = 1;
};

GrenadeData GhostNuke2
{
  bulletShapeName = "liqcyl.dts";
  explosionTag = LargeShockwave;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 80;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 2;
  damageType = $MeltaDamageType;
  explosionRadius = 50;
  kickBackStrength = 800;
  maxLevelFlightDist = 0;
  totalTime = 15.0;
  liveTime = 0.1;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0;
  smokeName = "plasmaex.dts";
  smokeDist = 1;
};

ItemData NukeAmmo 
{
  description = "Tactical Nukes";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData GNukeImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
   mountOffset = 
   {
   0.0, 0, 0 }
   ;
   mountRotation = 
   {
   0.0, 3.14, 0 }
   ;
  weaponType = 0;
  ammoType = NukeAmmo;
  projectileType = "Undefined";
  accuFire = false;
  reloadTime = 2;
  fireTime = 4;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData GNuke 
{
  description = "Ghost Nuclear System";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = GNukeImage;
  price = 1000;
  showWeaponBar = true;
};

function GNuke::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Ghost Nuclear Missile Targeting System: <f2>To use this devastating tactical nuclear targetting system, first aim at the target location, then fire, and for 8 seconds remain completely still, allowing the missiles to lock onto the location.");
}

function verifyNuke(%player, %slot)
{
	     %vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1000))
		{
			 $Nukepos2[%player] = $los::position;
                           if($Nukepos[%player] == $Nukepos2[%player])
                           {
                           %highpos = Vector::add($Nukepos2[%player], "0 0 100");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("GhostNuke",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("GhostNuke2",%newtrans,%player,%vel);
                           Client::sendMessage(Player::getClient(%player), 1,"Nuclear missile fired and locked onto area.  Clear out from the explosion area immediately!");
                                return;
                           }
                           else 
                           {
                           Client::sendMessage(Player::getClient(%player), 1,"Nuclear warhead lost due to inconstant targetting.");
                           %random = (floor(getRandom() * 150));
                           %random2 = (floor(getRandom() * 150));
                           %trans = GameBase::getMuzzleTransform(%player);
                           %pos = GameBase::getPosition(%player);
                           %highpos = Vector::add(%pos, %random @ " " @ %random2 @ " 100");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("GhostNuke",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("GhostNuke2",%newtrans,%player,%vel);
                                return;
                           }
		}
                else Client::sendMessage(Player::getClient(%player), 1,"Nuclear warhead lost due to inconstant targetting.");
                           %random = (floor(getRandom() * 200)-100);
                           %random2 = (floor(getRandom() * 200)-100);
                           %trans = GameBase::getMuzzleTransform(%player);
                           %pos = GameBase::getPosition(%player);
                           %highpos = Vector::add(%pos, %random @ " " @ %random2 @ " 100");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("GhostNuke",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("GhostNuke2",%newtrans,%player,%vel);
           return;
}

function GNukeImage::onFire(%player, %slot)
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[GNuke]);
	 if(%AmmoCount > 0) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[GNuke],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

                        Projectile::spawnProjectile("NukePointer",%trans,%player,%vel);
		if(GameBase::getLOSInfo(%player,1000))
		{
                       %object = getObjectType($los::object);
			if(%object == "Player" || %object == "Flier")
                         {
                         Client::sendMessage(Player::getClient(%player), 0,"Can not target nuclear system on objects.  Mark a spot on the terrain or a building instead.");
			 }
			 else
			 {
			 $Nukepos[%player] = $los::position;
                         Client::sendMessage(Player::getClient(%player), 1,"Target area located, keep the laser pointing at this specific area to ensure the nuclear warhead arrives at the destination.");
                         schedule("verifyNuke(" @ %player @ ");",5,%player);
			 }
		}
                else Client::sendMessage(Player::getClient(%player), 0,"Nothing to target in desired area.");
	}
	else if(%AmmoCount == 0) Client::sendMessage(Player::getClient(%player), 0,"No Missiles to launch.");
}
