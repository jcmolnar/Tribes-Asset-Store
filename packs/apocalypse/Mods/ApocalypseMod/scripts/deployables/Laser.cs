//--------------------------------------

addToInv(LaserPack,1,1);

setArmorItemMax(LaserPack,0,0,0,0,1,0,1, 0, 0,0,0,0);

$TeamItemMax[LaserPack] = 6;

dataReinit(LaserPack);
$TCK[DeployableLaser] = true;
$PlayCtrl[DeployableLaser] = true;
//--------------------------------------

ItemImageData LaserPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData LaserPack
{
        description = "Laser Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = $InvCatTurrets;
        imageType = LaserPackImage;
        shadowDetailMask = 4;
        mass = 0.5;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function LaserPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function LaserPack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,3,"LAND",20,20,10,10,10,10,1,false,DeployableLaser,"Turret",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------

TurretData DeployableLaser
{
        className = "Turret";
        shapeFile = "camera";
        projectileType = sniperLaser;
        maxDamage = 0.5;
        maxEnergy = 40;
        minGunEnergy = 10;
        maxGunEnergy = 40;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 1.5;
        speed = 4.0;
        speedModifier = 1.5;
        range = 100;
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
        description = "Laser Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableLaser::onAdd(%this)
{
        schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Laser Turret");
}

function DeployableLaser::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaser::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableLaser::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
}

// Override base class just in case.
function DeployableLaser::onPower(%this,%power,%generator) {}
function DeployableLaser::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------
