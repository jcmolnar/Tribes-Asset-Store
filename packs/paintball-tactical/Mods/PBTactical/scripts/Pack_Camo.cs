ItemImageData 	CamoImage
{
        shapeFile = "cactus2";
        mountPoint = 2;
        mountOffset = { 0, 0.2, -1.7 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData Camo
{
        description = "Desert Camo";
        shapeFile = "cactus2";
        className = "Backpack";
      heading = $InvHead[ihCam];
        imageType = CamoImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "fear";
        showWeaponBar = true;
        hiliteOnActive = true;
};


//INvo STUFF
$ItemMax[larmor, Camo] = 1;
$ItemMax[lfemale, Camo] = 1;
$InvList[Camo] = 1;