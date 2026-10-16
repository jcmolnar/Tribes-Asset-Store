//------------------------------------------------------------------------
StaticShapeData FencePostSml
{
	shapeFile = "anten_small";
	className = "FencePost";
	debrisId = defaultDebrisSmall;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 1;
	visibleToSensor = true;
	castLOS = true;
	explosionId = flashExpMedium;
	description = "Small Fence Post";
};

//------------------------------------------------------------------------
StaticShapeData FencePostMed
{
	shapeFile = "anten_med";
	className = "FencePost";
	debrisId = flashDebrisSmall;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 1;
	visibleToSensor = true;
	castLOS = true;
	explosionId = flashExpMedium;
	description = "Medium Fence Post";
};

//------------------------------------------------------------------------
StaticShapeData FencePostLrg
{
	shapeFile = "anten_lrg";
	className = "FencePost";
	debrisId = defaultDebrisSmall;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 1;
	visibleToSensor = true;
	castLOS = true;
	explosionId = debrisExpMedium;
	description = "Large Fence Post";
};

//------------------------------------------------------------------------
TriggerData PropBoxTrigger
{
	className = "Trigger";
	rate = 1.0;
};
