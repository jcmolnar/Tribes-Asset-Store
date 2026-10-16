ItemImageData cactuscamoimage
{

	shapeFile = "cactus3";
	mountPoint = 2;
	mountOffset = { -0.0, 0.2, -1.5 };
	mountRotation = { 0, -0.1, 0 };

};

ItemData cactuscamo
{
	
	description = "cant see me";
	shapeFile = "sensor_small";
	imageType = cactuscamoImage;
	showInventory = false;
	shadowDetailMask = 4;
	
};


ItemImageData plantcamoimage
{

	shapeFile = "plant2";
	mountPoint = 2;
	mountOffset = { 0.1, 0.15, -1.15 };
	mountRotation = { 0, -0.1, 0.1 };

};

ItemData plantcamo
{
	
	description = "cant see me.";
	shapeFile = "plant2";
	imageType = plantcamoImage;
	showInventory = false;
	shadowDetailMask = 4;
	
};
