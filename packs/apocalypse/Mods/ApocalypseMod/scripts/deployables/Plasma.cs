//--------------------------------------

addToInv(PlasmaPack,1,1);

setArmorItemMax(PlasmaPack,0,0,0,1,1,1,1, 0, 0,0,0,0);

$TeamItemMax[PlasmaPack] = 8;

dataReinit(PlasmaPack);
$TCK[DeployablePlasma] = true;
$PlayCtrl[DeployablePlasma] = true;
//--------------------------------------

ItemImageData PlasmaPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData PlasmaPack
{
        description = "Plasma Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = $InvCatTurrets;
        imageType = PlasmaPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function PlasmaPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function PlasmaPack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,4,"LAND",30,30,20,10,10,10,4,false,DeployablePlasma,"Turret",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------

TurretData DeployablePlasma
{
        className = "Turret";
        shapeFile = "remoteturret";
        projectileType = PlasmaBolt;
        maxDamage = 0.75;
        maxEnergy = 70;
        minGunEnergy = 7;
        maxGunEnergy = 10;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.75;
        speed = 4.0;
        speedModifier = 1.5;
        range = 50;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundFirePlasma;
        activationSound = SoundEnergyTurretOn;
        deactivateSound = SoundEnergyTurretOff;
        explosionId = flashExpMedium;
        description = "Plasma Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployablePlasma::onAdd(%this)
{
        schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Plasma Turret");
}

function DeployablePlasma::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployablePlasma::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployablePlasma::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "PlasmaPack"]--;
}

// Override base class just in case.
function DeployablePlasma::onPower(%this,%power,%generator) {}
function DeployablePlasma::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------
