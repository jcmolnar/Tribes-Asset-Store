//--------------------------------------

addToInv(FusionPack,1,1);

setArmorItemMax(FusionPack,0,0,0,0,1,0,1, 0, 0,0,0,0);

$TeamItemMax[FusionPack] = 6;

dataReinit(FusionPack);
$TCK[DeployableFusion] = true;
$PlayCtrl[DeployableFusion] = true;
//--------------------------------------

ItemImageData FusionPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.0;
        firstPerson = false;
};

ItemData FusionPack
{
        description = "Fusion Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = $InvCatTurrets;
        imageType = FusionPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function FusionPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function FusionPack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,3,"LAND",20,20,10,10,10,10,1,true,DeployableFusion,"Turret",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------

TurretData DeployableFusion
{
        className = "Turret";
        shapeFile = "remoteturret";
        projectileType = FRifleBolt;
        maxDamage = 0.75;
        maxEnergy = 80;
        minGunEnergy = 12;
        maxGunEnergy = 17;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 1.0;
        speed = 4.0;
        speedModifier = 1.5;
        range = 65;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundFireLaser;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId = flashExpMedium;
        description = "Fusion Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableFusion::onAdd(%this)
{
        schedule("DeployableFusion::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Fusion Turret");
}

function DeployableFusion::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableFusion::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableFusion::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "FusionPack"]--;
}

// Override base class just in case.
function DeployableFusion::onPower(%this,%power,%generator) {}
function DeployableFusion::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------
