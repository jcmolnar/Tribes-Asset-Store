//=====================================
GrenadeData GrenadeShell {
   bulletShapeName = "grenade.dts";
   explosionTag = grenadeExp;
   collideWithOwner = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;
   damageClass        = 1;
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

//=====================================
GrenadeData MortarShell {
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//=====================================
GrenadeData MortarTurretShell {
	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 400;
	collisionRadius = 1.0;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1;
	damageValue = 1.32;
	damageType = $MortarDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 400;
	totalTime = 1000.0;
	liveTime = 2.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";
};

//=====================================