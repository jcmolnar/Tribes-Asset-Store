//- Place Holder file, eventually will house knowledge structures
StaticShapeData Term_CheckOut
{
	description = "Library Terminal";
	shapeFile = "Inventory_Sta";
	className = "Terminal";
	visibleToSensor = false;
	sequenceSound[0] = { "activate", SoundActivateCommandStation };
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

//------------------------------------------------------------------------
ItemData Book
{
	description = "Book";
	shapeFile = "display_three";
	className = "Books";
	heading = "cTools";
	//imageType = "";
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 0;
	showWeaponBar = false;
	hiliteOnActive = false;
};