//==========================================
//All modules created should be in this file
//==========================================

//======================================
//Grenade Modules
//======================================

//--------------------------------------
//Napalm Module
//--------------------------------------

addToInv(GrenNapMod,1,1);

setArmorItemMax(GrenNapMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[GrenNapMod] = GrenadeLauncher;
//------------------------------------

ItemImageData GrenNapModImage
{
   shapeFile  = "mortar";
        mountPoint = 0;
        mountOffset = { 0.0, 0.0, -0.2 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData GrenNapMod
{
        description = "Napalm Module";
        className = "Module";
        shapeFile = "mortar";
   heading = $InvCatModule[Gre];
        shadowDetailMask = 4;
        imageType = GrenNapModImage;
        price = 25;
        showWeaponBar = false;
        showinventory = true;
};

function GrenNapMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,GrenadeLauncher] = 2;
}

function GrenNapMod::onDrop(%player,%item)
{
        %item = Item::onDrop(%player,%item);
        %client = Player::getClient(%player);
        $WeapMode[%client,GrenadeLauncher] = 1;
        if(Player::getMountedItem(%player,$WeaponSlot) == GrenadeLauncher)
                Player::unmountItem(%player,$ExtraSlotA);
}
//--------------------------------------
//EMP Module
//--------------------------------------

addToInv(GrenEmpMod,1,1);

setArmorItemMax(GrenEmpMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[GrenEmpMod] = GrenadeLauncher;
//------------------------------------

ItemImageData GrenEmpModImage
{
   shapeFile  = "discb";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData GrenEmpMod
{
        description = "EMP Module";
        className = "Module";
        shapeFile = "discb";
   heading = $InvCatModule[Gre];
        shadowDetailMask = 4;
        imageType = GrenEmpModImage;
        price = 25;
        showWeaponBar = false;
        showinventory = true;
};

function GrenEmpMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,GrenadeLauncher] = 3;
}

function GrenEmpMod::onDrop(%player,%item)
{
        %item = Item::onDrop(%player,%item);
        %client = Player::getClient(%player);
        $WeapMode[%client,GrenadeLauncher] = 1;
        if(Player::getMountedItem(%player,$WeaponSlot) == GrenadeLauncher)
                Player::unmountItem(%player,$ExtraSlotA);
}
//======================================
//Mortar Modules
//======================================

//--------------------------------------
//Implosion Module
//--------------------------------------

addToInv(MortImpMod,1,1);

setArmorItemMax(MortImpMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[MortImpMod] = Mortar;
//------------------------------------

ItemImageData MortImpModImage
{
   shapeFile  = "jetPack";
        mountPoint = 0;
        mountOffset = { 0.0, 0.1, 0.0 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData MortImpMod
{
        description = "Implosion Module";
        className = "Module";
        shapeFile = "jetPack";
   heading = $InvCatModule[Mor];
        shadowDetailMask = 4;
        imageType = MortImpModImage;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};

function MortImpMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,Mortar] = 2;
        $WeapMode[%client,RangerMortar] = 2;
}

function MortImpMod::onDrop(%player,%item)
{
        %item = Item::onDrop(%player,%item);
        %client = Player::getClient(%player);
        $WeapMode[%client,Mortar] = 1;
        $WeapMode[%client,RangerMortar] = 1;
        if(Player::getMountedItem(%player,$WeaponSlot) == Mortar || Player::getMountedItem(%player,$WeaponSlot) == RangerMortar)
                Player::unmountItem(%player,$ExtraSlotA);
}
//======================================
//Apocalypse Cannon Modules
//======================================

//--------------------------------------
//Scatter Bomb Module
//--------------------------------------

addToInv(ApocScaMod,1,1);

setArmorItemMax(ApocScaMod,0,0,0,0,0,0,1, 0, 0,0,0,0);

$ModuleWep[ApocScaMod] = ApocGun;
//------------------------------------

ItemImageData ApocScaModImage
{
   shapeFile  = "sensor_small";
        mountPoint = 0;
        mountRotation = { 0, 1.57, 0 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData ApocScaMod
{
        description = "Scatter Bomb Module";
        className = "Module";
        shapeFile = "sensor_small";
   heading = $InvCatModule[Apo];
        shadowDetailMask = 4;
        imageType = ApocScaModImage;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};

ItemImageData ApocScaMod2Image
{
   shapeFile  = "sensor_small";
        mountPoint = 0;
        mountRotation = { 0, -1.57, 0 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData ApocScaMod2
{
        description = "Scatter Bomb Module";
        className = "Module";
        shapeFile = "sensor_small";
   heading = $InvCatModule[Apo];
        shadowDetailMask = 4;
        imageType = ApocScaMod2Image;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};
function ApocScaMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,ApocGun] = 2;
}

function ApocScaMod::onDrop(%player,%item)
{
        %item = Item::onDrop(%player,%item);
        %client = Player::getClient(%player);
        $WeapMode[%client,ApocGun] = 1;
        if(Player::getMountedItem(%player,$WeaponSlot) == ApocGun) {
                Player::unmountItem(%player,$ExtraSlotA);
                Player::unmountItem(%player,$ExtraSlotB);
        }
}
//======================================
//Flame Thrower Modules
//======================================

//--------------------------------------
//Spark Module
//--------------------------------------

addToInv(FlamSpaMod,1,1);

setArmorItemMax(FlamSpaMod,0,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[FlamSpaMod] = FlameThrower;
//------------------------------------

ItemImageData FlamSpaModImage
{
   shapeFile  = "force";
        mountPoint = 0;
        mountRotation = { 0, 1.57, 0 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData FlamSpaMod
{
        description = "Ignitor";
        className = "Module";
        shapeFile = "force";
   heading = $InvCatModule[Fla];
        shadowDetailMask = 4;
        imageType = FlamSpaModImage;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};

function FlamSpaMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        if($WeapMode[%client,FlameThrower] == 1 || $WeapMode[%client,FlameThrower] < 1 || $WeapMode[%client,FlameThrower] == "")
                $WeapMode[%client,FlameThrower] = 2;
        else if($WeapMode[%client,FlameThrower] == 2 || $WeapMode[%client,FlameThrower] > $FireModes[FlameThrower])
                $WeapMode[%client,FlameThrower] = 1;
}

function FlamSpaMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == FlameThrower && Player::getItemCount(%client,FlameThrower) != 0 && Player::getItemCount(%client,FlamSpaMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop ignitor use ignitor to switch modes ~wC_BuySell.wav");
}
//======================================
//Force Modules
//======================================

//--------------------------------------
//Gravity Module
//--------------------------------------

addToInv(ForcImpMod,1,1);

setArmorItemMax(ForcImpMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ForcImpMod] = RepulseGun;
//------------------------------------

ItemImageData ForcImpModImage
{
   shapeFile  = "grenadeL";
        mountPoint = 0;
        mountOffset = { 0.0, 0.0, 0.1 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData ForcImpMod
{
        description = "Gravity Module";
        className = "Module";
        shapeFile = "grenadeL";
   heading = $InvCatModule[For];
        shadowDetailMask = 4;
        imageType = ForcImpModImage;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};

function ForcImpMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,RepulseGun] = 2;
}

function ForcImpMod::onDrop(%player,%item)
{
        %item = Item::onDrop(%player,%item);
        %client = Player::getClient(%player);
        $WeapMode[%client,RepulseGun] = 1;
        if(Player::getMountedItem(%player,$WeaponSlot) == RepulseGun)
                Player::unmountItem(%player,$ExtraSlotB);
}
//======================================
//Shotgun Chokes
//======================================

//--------------------------------------
//Full Choke
//--------------------------------------

addToInv(ShotFulMod,1,1);

setArmorItemMax(ShotFulMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ShotFulMod] = Shotgun;
//------------------------------------

ItemData ShotFulMod
{
        description = "Full Choke";
        className = "Module";
        shapeFile = "force";
   heading = $InvCatModule[Sho];
        shadowDetailMask = 4;
        price = 10;
        showWeaponBar = false;
        showinventory = true;
};

function ShotFulMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,Shotgun] = 1;
}

function ShotFulMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == Shotgun && Player::getItemCount(%client,Shotgun) != 0 && Player::getItemCount(%client,ShotImpMod) == 0 && Player::getItemCount(%client,ShotModMod) == 0 && Player::getItemCount(%client,ShotSktMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop choke ~wC_BuySell.wav");
}
//--------------------------------------
//Improved Choke
//--------------------------------------

addToInv(ShotImpMod,1,1);

setArmorItemMax(ShotImpMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ShotImpMod] = Shotgun;
//------------------------------------

ItemData ShotImpMod
{
        description = "Improved Choke";
        className = "Module";
        shapeFile = "force";
   heading = $InvCatModule[Sho];
        shadowDetailMask = 4;
        price = 10;
        showWeaponBar = false;
        showinventory = true;
};

function ShotImpMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,Shotgun] = 2;
}

function ShotImpMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == Shotgun && Player::getItemCount(%client,Shotgun) != 0 && Player::getItemCount(%client,ShotFulMod) == 0 && Player::getItemCount(%client,ShotModMod) == 0 && Player::getItemCount(%client,ShotSktMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop choke ~wC_BuySell.wav");
}
//--------------------------------------
//Modified Choke
//--------------------------------------

addToInv(ShotModMod,1,1);

setArmorItemMax(ShotModMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ShotModMod] = Shotgun;
//------------------------------------

ItemData ShotModMod
{
        description = "Modified Choke";
        className = "Module";
        shapeFile = "force";
   heading = $InvCatModule[Sho];
        shadowDetailMask = 4;
        price = 10;
        showWeaponBar = false;
        showinventory = true;
};

function ShotModMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,Shotgun] = 3;
}

function ShotModMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == Shotgun && Player::getItemCount(%client,Shotgun) != 0 && Player::getItemCount(%client,ShotFulMod) == 0 && Player::getItemCount(%client,ShotImpMod) == 0 && Player::getItemCount(%client,ShotSktMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop choke ~wC_BuySell.wav");
}
//--------------------------------------
//Skeet Choke
//--------------------------------------

addToInv(ShotSktMod,1,1);

setArmorItemMax(ShotSktMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ShotSktMod] = Shotgun;
//------------------------------------

ItemData ShotSktMod
{
        description = "Skeet Choke";
        className = "Module";
        shapeFile = "force";
   heading = $InvCatModule[Sho];
        shadowDetailMask = 4;
        price = 10;
        showWeaponBar = false;
        showinventory = true;
};

function ShotSktMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,Shotgun] = 4;
}

function ShotSktMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == Shotgun && Player::getItemCount(%client,Shotgun) != 0 && Player::getItemCount(%client,ShotFulMod) == 0 && Player::getItemCount(%client,ShotImpMod) == 0 && Player::getItemCount(%client,ShotModMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop choke ~wC_BuySell.wav");
}
//======================================
//Elemental Cores
//======================================

//--------------------------------------
//Fire Core
//--------------------------------------

addToInv(ElemFirMod,1,1);

setArmorItemMax(ElemFirMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ElemFirMod] = ElementPack;
//------------------------------------

ItemImageData ElemFirModImage
{
   shapeFile  = "plasmaex";
        mountPoint = 2;

        weaponType = 2;  // Sustained
        minEnergy = 0;
        maxEnergy = 0;
        firstPerson = false;
};

ItemData ElemFirMod
{
        description = "Fire Core";
        className = "Module";
        shapeFile = "plasmaex";
   heading = $InvCatModule[Ele];
        shadowDetailMask = 4;
        imageType = ElemFirModImage;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};

function ElemFirMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,ElementPack] = 1;
}

function ElemFirMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == ElementPack && Player::getItemCount(%client,ElementPack) != 0 && Player::getItemCount(%client,ElemWinMod) == 0 && Player::getItemCount(%client,ElemEarMod) == 0 && Player::getItemCount(%client,ElemEleMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop elemental core ~wC_BuySell.wav");
}
//--------------------------------------
//Wind Core
//--------------------------------------

addToInv(ElemWinMod,1,1);

setArmorItemMax(ElemWinMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ElemWinMod] = ElementPack;
//------------------------------------

ItemImageData ElemWinModImage
{
   shapeFile  = "shockwave_large";
        mountPoint = 2;

        weaponType = 2;  // Sustained
        minEnergy = 0;
        maxEnergy = 0;
        mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
};

ItemData ElemWinMod
{
        description = "Wind Core";
        className = "Module";
        shapeFile = "shockwave_large";
   heading = $InvCatModule[Ele];
        shadowDetailMask = 4;
        imageType = ElemWinModImage;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};

function ElemWinMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,ElementPack] = 2;
}

function ElemWinMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == ElementPack && Player::getItemCount(%client,ElementPack) != 0 && Player::getItemCount(%client,ElemFirMod) == 0 && Player::getItemCount(%client,ElemEarMod) == 0 && Player::getItemCount(%client,ElemEleMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop elemental core ~wC_BuySell.wav");
}
//--------------------------------------
//Earth Core
//--------------------------------------

addToInv(ElemEarMod,1,1);

setArmorItemMax(ElemEarMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ElemEarMod] = ElementPack;
//------------------------------------

ItemImageData ElemEarModImage
{
   shapeFile  = "dustplume";
        mountPoint = 2;

        weaponType = 2;  // Sustained
        minEnergy = 0;
        maxEnergy = 0;
        firstPerson = false;
};

ItemData ElemEarMod
{
        description = "Earth Core";
        className = "Module";
        shapeFile = "dustplume";
   heading = $InvCatModule[Ele];
        shadowDetailMask = 4;
        imageType = ElemEarModImage;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};

function ElemEarMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,ElementPack] = 3;
}

function ElemEarMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == ElementPack && Player::getItemCount(%client,ElementPack) != 0 && Player::getItemCount(%client,ElemWinMod) == 0 && Player::getItemCount(%client,ElemFirMod) == 0 && Player::getItemCount(%client,ElemEleMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop elemental core ~wC_BuySell.wav");
}
//--------------------------------------
//Electric Core
//--------------------------------------

addToInv(ElemEleMod,1,1);

setArmorItemMax(ElemEleMod,1,1,1,1,1,1,1, 0, 0,0,0,0);

$ModuleWep[ElemEleMod] = ElementPack;
//------------------------------------

ItemImageData ElemEleModImage
{
   shapeFile  = "fusionex";
        mountPoint = 2;

        weaponType = 2;  // Sustained
        minEnergy = 0;
        maxEnergy = 0;
        firstPerson = false;
};

ItemData ElemEleMod
{
        description = "Electric Core";
        className = "Module";
        shapeFile = "fusionex";
   heading = $InvCatModule[Ele];
        shadowDetailMask = 4;
        imageType = ElemEleModImage;
        price = 50;
        showWeaponBar = false;
        showinventory = true;
};

function ElemEleMod::onUse(%player,%item)
{
        %client = Player::getClient(%player);
        $WeapMode[%client,ElementPack] = 4;
}

function ElemEleMod::onDrop(%player,%item)
{
        %client = Player::getClient(%player);
        if($ModuleWep[%item] == ElementPack && Player::getItemCount(%client,ElementPack) != 0 && Player::getItemCount(%client,ElemWinMod) == 0 && Player::getItemCount(%client,ElemEarMod) == 0 && Player::getItemCount(%client,ElemFirMod) == 0)
                Client::sendMessage(%client,0,"Cannot drop elemental core ~wC_BuySell.wav");
}

