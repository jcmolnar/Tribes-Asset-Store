//- Place Holder file, eventually will house terminal structures
StaticShapeData Term_Sales
{
	description = "Sales Terminal";
	shapeFile = "mainpad";
	className = "Terminal";
	visibleToSensor = false;
	sequenceSound[0] = { "activate", SoundActivatePDA };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundUseCommandStation };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_generator";
	visibleToSensor = true;
	castLOS = true;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};

StaticShapeData Term_Market
{
	description = "Market Terminal";
	shapeFile = "vehi_pur_pnl";
	className = "Terminal";
	visibleToSensor = false;
	sequenceSound[0] = { "activate", SoundChainTurretOn };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundChainTurretOff };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_generator";
	visibleToSensor = true;
	castLOS = true;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};
