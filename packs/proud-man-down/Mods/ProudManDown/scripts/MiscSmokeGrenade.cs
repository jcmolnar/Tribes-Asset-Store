//--------------------------------------

$SellAmmo[SmokeGrenade] = 1;
$AmmoPackMax[SmokeGrenade] = 1;
$AmmoPackItems[1] = SmokeGrenade;

//--------------------------------------

$InvList[SmokeGrenade] = 1;
$RemoteInvList[SmokeGrenade] = 1;

//--------------------------------------
GrenadeData ExpFire
{
   bulletShapeName    = "fiery.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 5.0;
   density = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 10.0;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 1.0;
   totalTime          = 0.6;
   liveTime           = 0.6;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";

};

GrenadeData ExpFire2
{
   bulletShapeName    = "fiery.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 5.0;
   density = 5.0;
   elasticity         = 1.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 10.0;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.3;
   liveTime           = 0.3;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";

};

GrenadeData Burner
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 5.0;
   density = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.32;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.01;
   totalTime          = 15.0;
   liveTime           = 0.8;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmabolt.dts";

};

GrenadeData Burner1
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = mineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 5.0;
   density = 5.0;
   elasticity         = 1.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.32;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.01;
   totalTime          = 15.0;
   liveTime           = 0.8;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";

};

ItemData SmokeGrenade
{
   description = "Satchel Charge";
   shapeFile = "AmmoPack";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function SmokeGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","SmokeHandgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 8.0;
		}
	}
}
//--------------------------------------

MineData SmokeHandgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.0;
	friction = 100.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "AmmoPack";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 20.0;
	damageValue = 10.0;
	damageType = $ExplosionDamageType;
	kickBackStrength = 100;
	triggerRadius = 3.0;
	maxDamage = 0.1;
};

function SmokeHandgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",10.0,%this);
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

function SmokeHandGrenade::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("ExpFire",%trans,%this,0);
		 Projectile::spawnProjectile("ExpFire2",%trans,%this,0);
		 Projectile::spawnProjectile("Burner",%trans,%this,0);
		 Projectile::spawnProjectile("Burner1",%trans,%this,0);
}