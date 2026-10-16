ItemImageData 	Camo2Image
{
        shapeFile = "tree2";
        mountPoint = 2;
        mountOffset = { 0, 0.2, -1.7 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData Camo2
{
        description = "Forest Camo";
        shapeFile = "tree2";
        className = "Backpack";
      heading = $InvHead[ihCam];
        imageType = Camo2Image;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "fear";
        showWeaponBar = true;
        hiliteOnActive = true;
};


//INvo STUFF
$ItemMax[larmor, Camo2] = 1;
$ItemMax[lfemale, Camo2] = 1;
$InvList[Camo2] = 1;