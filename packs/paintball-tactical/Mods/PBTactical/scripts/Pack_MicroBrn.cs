ItemImageData 	MicroBrnImage
{
        shapeFile = "breath";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = true;
	lightType = 1;   // Constant
	lightRadius = 1.0;
shadowDetailMask = 9999;
	lightColor = { 5.0, 2.5, 0.8};
};

ItemData MicroBrn
{
        description = "Micro Mesh Brown";
        shapeFile = "breath";
        className = "Backpack";
      heading = $InvHead[ihCam];
        imageType = MicroBrnImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "fear";
        showWeaponBar = true;
        hiliteOnActive = true;
};


//INvo STUFF
$ItemMax[larmor, MicroBrn] = 1;
$ItemMax[lfemale, MicroBrn] = 1;
$InvList[MicroBrn] = 1;