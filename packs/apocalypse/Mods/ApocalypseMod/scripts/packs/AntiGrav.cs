//----------------------------------------------------------------------------

addToInv(AntiGravPack,1,1);

setArmorItemMax(AntiGravPack,0,0,0,0,1,1,1, 0, 0,0,0,0);

//----------------------------------------------------------------------------

ItemImageData AntiGravPackImage
{
        shapeFile = "mortarpack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.2 };
        mountRotation = { 0, 3.14, 0 };

        mass = -9;
        weaponType = 2;  // Sustained
        minEnergy = -1;  // Energy used/sec for sustained weapons
        maxEnergy = 1;  // Energy used/sec for sustained weapons
        sfxFire = SoundDiscSpin;
        firstPerson = false;
};

ItemData AntiGravPack
{
        description = "Anti-Grav Pack";
        shapeFile = "mortarpack";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = AntiGravPackImage;
        price = 500;
        hudIcon = "fear";
        showWeaponBar = true;
        hiliteOnActive = true;
};

$MountMSG[AntiGravPack] = "<JC><F2>Anti-Grav Pack <F0>- <F1>Reduces your wieght improving your movement abilities.";

function AntiGravPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
}

function AntiGravPack::onMount(%player, %item)
{
        Player::trigger(%player,$BackpackSlot,true);
}

//--------------------------------------
