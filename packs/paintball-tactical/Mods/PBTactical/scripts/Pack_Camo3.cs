ItemImageData 	Camo3Image
{
        shapeFile = "plant2";
        mountPoint = 2;
        mountOffset = { 0, 0.1, -0.9 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData Camo3
{
        description = "Jungle Camo";
        shapeFile = "plant2";
        className = "Backpack";
      heading = $InvHead[ihCam];
        imageType = Camo3Image;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "fear";
        showWeaponBar = true;
        hiliteOnActive = true;
};


//INvo STUFF
$ItemMax[larmor, Camo3] = 1;
$ItemMax[lfemale, Camo3] = 1;
$InvList[Camo3] = 1;