//--------------------------------------

addToInv(BlastWallPack,1,1);

setArmorItemMax(BlastWallPack,0,0,0,1,1,1,1, 0, 0,0,0,0);

$TeamItemMax[BlastWallPack] = 8;

dataReinit(BlastWallPack);
$TCK[DeployableBlastWall] = true;
$PlayCtrl[DeployableBlastWall] = false;
//--------------------------------------

ItemImageData FFDoorPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData FFDoorPack
{
        description = "Force Field Door";
        shapeFile = "AmmoPack";
        className = "Backpack";
   heading = $InvCatDeployables;
        imageType = FFDoorPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function FFDoorPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function FFDoorPack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,3,"LAND",1,1,1,1,1,1,1,true,ForceFieldDoor,"StaticShape",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------
StaticShapeData ForceFieldDoor
{
        className = "ForceField";
        damageSkinData = "objectDamageSkins";
        shapeFile = "forcefield_5x5";
        maxDamage = 4.5;
        maxEnergy = 200;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "Force Field Door";
};

function ForceFieldDoor::onDestroyed(%this)
{
        StaticShape::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "FFDoorPack"]--;
}

function ForceFieldDoor::openDoor(%this)
{
        GameBase::startfadeout(%this);
        %pos=GameBase::getPosition(%this);
        %pos=Vector::add(%pos,"0 0 1000");
        GameBase::setPosition(%this,%pos);
        schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
        schedule("ForceFieldDoorShape::closeDoor("@%this@");",2);
}

function ForceFieldDoor::closeDoor(%this)
{
        %pos=GameBase::getPosition(%this);
        %pos=Vector::add(%pos,"0 0 -1000");
        GameBase::setPosition(%this,%pos);
        GameBase::startfadein(%this);
        schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

