//--------------------------------------

addToInv(BlastWallPack,1,1);

setArmorItemMax(BlastWallPack,0,0,0,1,1,1,1, 0, 0,0,0,0);

$TeamItemMax[BlastWallPack] = 8;

dataReinit(BlastWallPack);
$TCK[DeployableBlastWall] = true;
$PlayCtrl[DeployableBlastWall] = false;
//--------------------------------------

ItemImageData BlastWallPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData BlastWallPack
{
        description = "Blast Wall";
        shapeFile = "AmmoPack";
        className = "Backpack";
   heading = $InvCatDeployables;
        imageType = BlastWallPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastWallPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function BlastWallPack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,3,"LAND",1,1,1,1,1,1,1,true,BlastWall,"StaticShape",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------
StaticShapeData BlastWall
{
        shapeFile = "newdoor5";
        maxDamage = 20.0;
        debrisId = defaultDebrisLarge;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        damageSkinData = "objectDamageSkins";
        description = "Blast Wall";
};

function BlastWall::onDestroyed(%this)
{
        StaticShape::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;
}

