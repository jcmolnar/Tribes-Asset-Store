//Damage Types
exec("miscellany\\damageTypes.cs");

//Effects Projectiles & Such
//----------------------------------------------------------------------------

GrenadeData EmpEffectBomb
{
   bulletShapeName    = "enex.dts";
   explosionTag       = empExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass 	      = 5.0;
   elasticity	      = 0.1;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.3;
   damageType	      = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime	      = 0.01;	 // special meaning for grenades...
   liveTime	      = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName		  = "enex.dts";
};

//----------------------------------------------------------------------------

GrenadeData FireEffectBomb
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = fireExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass 	      = 5.0;
   elasticity	      = 0.1;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.3;
   damageType	      = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime	      = 0.01;	 // special meaning for grenades...
   liveTime	      = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName		  = "plasmatrail.dts";
};

//----------------------------------------------------------------------------

GrenadeData SmokeEffectBomb
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = fireExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass 	      = 5.0;
   elasticity	      = 0.1;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.3;
   damageType	      = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime	      = 0.01;	 // special meaning for grenades...
   liveTime	      = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName		  = "rsmoke.dts";
};

//----------------------------------------------------------------------------

GrenadeData DustEffectBomb
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = earthExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass 	      = 1.0;
   elasticity	      = 0.45;

   damageClass	      = 1;
   damageValue	      = 0;
   damageType	      = $NullDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime	      = 0.01;	 // special meaning for grenades...
   liveTime	      = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;

   smokeName		  = "dustplume.dts";
};

//----------------------------------------------------------------------------

MineData ShockwaveEffectBomb
{
	className = "Mine";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = windExp;
	explosionRadius = 1;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ShockwaveEffectBomb::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1);
}

//----------------------------------------------------------------------------

MineData EmpEffectBomb2
{
	className = "Mine";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = turretExp;
	explosionRadius = 1;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function EmpEffectBomb2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1);
}


//----------------------------------------------------------------------------

MineData FireEffectBomb2
{
	className = "Mine";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = plasmaExp0;
	explosionRadius = 1;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function FireEffectBomb2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1);
}

//----------------------------------------------------------------------------

MineData ShockwaveEffectBomb2
{
	className = "Mine";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 1;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ShockwaveEffectBomb2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1);
}

//--------------------------------------
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

