//--------------------------------------

addToInv(PerGenPack,1,1);

setArmorItemMax(PerGenPack,0,0,0,0,1,1,1, 0, 0,0,0,0);

//--------------------------------------

ItemImageData PerGenPackImage2
{
        shapeFile = "discammo";
        weaponType = 2;  // Sustained

        mountPoint = 2;
        mountOffset = { 0, 0.05, 0.1 };

        firstPerson = false;
};

ItemData PerGenPack2
{
        description = "Personal Generator";
        shapeFile = "discammo";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = PerGenPackImage2;
        price = 250;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;
};

ItemImageData PerGenPackImage3
{
        shapeFile = "discammo";
        weaponType = 2;  // Sustained

        mountPoint = 2;
        mountOffset = { 0, 0.05, -0.1 };

        firstPerson = false;
};

ItemData PerGenPack3
{
        description = "Personal Generator";
        shapeFile = "discammo";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = PerGenPackImage3;
        price = 250;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;
};

ItemImageData PerGenPackImage
{
        shapeFile = "discammo";
        weaponType = 2;  // Sustained

        mountPoint = 2;
        mountOffset = { 0, 0.05, 0 };

        mass = 3.0;
        minEnergy = -5;
        maxEnergy = -15;
        firstPerson = false;
};

ItemData PerGenPack
{
        description = "Personal Generator";
        shapeFile = "discammo";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = PerGenPackImage;
        price = 250;
        hudIcon = "energypack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

$MountMSG[PerGenPack] = "<JC><F2>Personal Generator <F0>- <F1>Greatly increase energy recharge rate but the wieght restricts movement.";

function PerGenPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
}

function PerGenPack::onMount(%player,%item)
{
        Player::trigger(%player,$BackpackSlot,true);
        Player::mountItem(%player,PerGenPack2,$ExtraSlotC);
        Player::mountItem(%player,PerGenPack3,$ExtraSlotD);
}

function PerGenPack::onUnmount(%player,%item)
{
        Player::unMountItem(%player,$ExtraSlotC);
        Player::unMountItem(%player,$ExtraSlotD);
        %weapon = Player::getMountedItem(%player,$WeaponSlot);
        if (%weapon == LaserRifle || %weapon == ChainLaser || %weapon == BeamCannon)
                Player::unmountItem(%player,$WeaponSlot);
}


//--------------------------------------
