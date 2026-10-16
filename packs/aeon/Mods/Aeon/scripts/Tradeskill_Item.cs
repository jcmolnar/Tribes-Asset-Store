//- Place Holder file, eventually will house tradeskill structures
StaticShapeData Term_Combine
{
	description = "Combination Terminal";
	shapeFile = "ammounit_remote";
	className = "Terminal";
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundAmmoStationPower };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_station";
	visibleToSensor = true;
	castLOS = true;
	supression = false;
	supressable = false;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};