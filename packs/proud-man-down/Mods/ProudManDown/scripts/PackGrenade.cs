//--------------------------------------

$InvList[GrenadePack] = 1;
$RemoteInvList[GrenadePack] = 1;

//--------------------------------------


ItemImageData GrenadePackImage
{
        shapeFile = "grenade";
        mountPoint = 2;
        weaponType = 2;  // Sustained
        maxEnergy = 0;  // Energy used/sec for sustained weapons
        minEnergy = 0;
        mountOffset = { -0.1, 0.35, 0.15 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData GrenadePack
{
        description = "Grenade";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "fBackpacks";
        shadowDetailMask = 4;
        imageType = GrenadePackImage;
        price = 100;
        hudIcon = "grenade";
        showWeaponBar = true;
        hiliteOnActive = true;
};