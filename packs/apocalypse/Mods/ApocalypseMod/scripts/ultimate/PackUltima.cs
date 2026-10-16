//==========================================
//Testing Pack
//==========================================

addToInv(UltimaPack,1,1);

setArmorItemMax(UltimaPack,0,0,0,0,0,0,0, 1, 0,0,0,0);

//--------------------------------------

ItemImageData UltimaPackImage
{
        shapeFile = "mortargun";

        mountPoint = 2;
        mountOffset = { 0, -0.1, 0.2 };
        mountRotation = { -1.57, 0, 3.14 };

        mass = -5;
        weaponType = 2;  // Sustained
        minEnergy = -3;
        maxEnergy = -9;
        firstPerson = false;
};

ItemData UltimaPack
{
        description = "Ultima Pack";
        shapeFile = "mortargun";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = UltimaPackImage;
        price = 150;
        hudIcon = "backpack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

$MountMSG[UltimaPack] = "<JC><F2>Ultima Pack <F0>- <F1>Increase energy recharge rate, reduces your wieght improving your movement abilities, and converts damage.";

function UltimaPack::onMount(%player, %item)
{
        Player::trigger(%player,$BackpackSlot,true);
        %player.apdrop = true;
}

function UltimaPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
}

function UltimaPack::onUnmount(%player,%item)
{
        %weapon = Player::getMountedItem(%player,$WeaponSlot);
        if (%weapon == LaserRifle || %weapon == ChainLaser || %weapon == BeamCannon)
                Player::unmountItem(%player,$WeaponSlot);
}


function UltimaPack::onDrop(%player, %item)
{
        if($matchStarted) {
                %item = Item::onDrop(%player,%item);
                for(%i = 0; %i < $APINum ; %i = %i +1) {
                        %numPack = 0;
                        %ammoItem = $AmmoPackItems[%i];
                        %maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
                        %pCount = Player::getItemCount(%player, %ammoItem);
                        if(%pCount > %maxnum) {
                                %numPack = %pCount - %maxnum;
                                Player::decItemCount(%player,%ammoItem,%numPack);
                        }
                        $NumInAP[%item,%ammoItem] = %numPack;
                }
        }
}

function UltimaPack::onCollision(%this,%object)
{
        if (getObjectType(%object) == "Player") {
                %item = Item::getItemData(%this);
                %count = Player::getItemCount(%object,%item);
                if (Item::giveItem(%object,%item,Item::getCount(%this))) {
                        Item::playPickupSound(%this);
                        checkPacksAmmo(%object, %this);
                        Item::respawn(%this);
                }
        }
}
