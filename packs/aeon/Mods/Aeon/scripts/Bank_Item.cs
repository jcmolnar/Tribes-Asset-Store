//- Place Holder file, eventually will house Bank structures
StaticShapeData Term_Bank
{
	description = "Bank Terminal";
	shapeFile = "ammounit";
	className = "Terminal";
	sequenceSound[0] = { "activate", SoundActivateAmmoStation };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_station";
	visibleToSensor = true;
	castLOS = true;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};
