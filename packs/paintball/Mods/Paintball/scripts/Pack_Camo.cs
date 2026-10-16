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
        description = "Land Camo";
        shapeFile = "cactus2";
        className = "Backpack";
      heading = "eMiscellany";
        imageType = CamoImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 180;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


//INvo STUFF
$ItemMax[larmor, Camo] = 1;
$ItemMax[lfemale, Camo] = 1;
$InvList[Camo] = 1;