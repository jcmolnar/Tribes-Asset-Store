ItemImageData 	MicroBlkImage
{
        shapeFile = "breath";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = true;
};

ItemData MicroBlk
{
        description = "Micro Mesh Black";
        shapeFile = "breath";
        className = "Backpack";
      heading = $InvHead[ihCam];
        imageType = MicroBlkImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "fear";
        showWeaponBar = true;
        hiliteOnActive = true;
};



//INvo STUFF
$ItemMax[larmor, MicroBlk] = 1;
$ItemMax[lfemale, MicroBlk] = 1;
$InvList[MicroBlk] = 1;