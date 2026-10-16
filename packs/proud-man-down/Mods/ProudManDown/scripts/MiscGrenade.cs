//--------------------------------------

$SellAmmo[Grenade] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackItems[4] = Grenade;

//--------------------------------------

$InvList[Grenade] = 1;
$RemoteInvList[Grenade] = 1;

//--------------------------------------
BulletData ShrapnelBit
{
   bulletShapeName    = "tracer.dts";
   explosionTag       = ShrapExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.2;
   damageType         = $BulletDamageType;

   aimDeflection      = 73.7;
   muzzleVelocity     = 625.0;
   totalTime          = 0.30;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;

soundId = SoundWindGust;

};

GrenadeData DirtThrow
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = ShrapExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 8.0;
   density = 8.0;
   elasticity         = 1.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 5.5;
   liveTime           = 0.9;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";

};

GrenadeData DirtThrow2
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = ShrapExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 8.0;
   density = 8.0;
   elasticity         = 1.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 5.5;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";

};

GrenadeData DirtThrow3
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = ShrapExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 8.0;
   density = 8.0;
   elasticity         = 1.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 5.5;
   liveTime           = 0.8;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";

};

GrenadeData DirtThrow4
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = ShrapExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 8.0;
   density = 8.0;
   elasticity         = 1.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 5.5;
   liveTime           = 0.4;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";

};

GrenadeData DirtThrow5
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = ShrapExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 8.0;
   density = 8.0;
   elasticity         = 1.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 5.5;
   liveTime           = 0.4;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";

};

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,8 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 3.0;
                		GameBase::playSound(%player,SoundThrowItem,0);
			Player::setAnimation(%player, 21);
		}
	}
}

//--------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.0;
	friction = 100.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = GrenadeExp;
	explosionRadius = 15.0;
	damageValue = 4.0;
	damageType = $DebrisDamageType;
	kickBackStrength = 100.0;
	triggerRadius = 3.0;
	maxDamage = 0.1;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HandGrenade::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
                GameBase::playSound(%player,bigExplosion3,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("ShrapnelBit",%trans,%this,0);
		 Projectile::spawnProjectile("DirtThrow",%trans,%this,0);
		 Projectile::spawnProjectile("DirtThrow2",%trans,%this,0);
		 Projectile::spawnProjectile("DirtThrow3",%trans,%this,0);
		 Projectile::spawnProjectile("DirtThrow4",%trans,%this,0);
		 Projectile::spawnProjectile("DirtThrow5",%trans,%this,0);
}