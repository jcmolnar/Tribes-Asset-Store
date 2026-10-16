//--------------------------------------

addToInv(MelfPack,1,1);

setArmorItemMax(MelfPack,0,0,0,0,1,0,0, 0, 0,0,0,0);

$TeamItemMax[MelfPack] = 5;

dataReinit(MelfPack);
$TCK[DeployableELF] = true;
$PlayCtrl[DeployableELF] = true;
//--------------------------------------

ItemImageData MelfPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData MelfPack
{
        description = "Mini ELF Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = $InvCatTurrets;
        imageType = MelfPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function MelfPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function MelfPack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,4,"LAND",30,30,20,10,10,10,3,false,DeployableELF,"Turret",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------

TurretData DeployableELF
{
        className = "ELF Turret";
        shapeFile = "indoorgun";
        projectileType = turretCharge;
        maxDamage = 1.0;
        maxEnergy = 150;
        minGunEnergy = 50;
        maxGunEnergy = 5;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.3;
        speed = 5.0;
        speedModifier = 1.5;
        range = 40;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundGeneratorPower;
        activationSound  = SoundChainTurretOn;
        deactivateSound  = SoundChainTurretOff;
        explosionId = flashExpMedium;
        description = "Mini ELF Turret";
        damageSkinData = "objectDamageSkins";

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

function DeployableELF::onAdd(%this)
{
        schedule("DeployableELF::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0.02;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Mini ELF Turret");
}

function DeployableELF::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableELF::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableELF::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "MelfPack"]--;
}

// Override base class just in case.
function DeployableELF::onPower(%this,%power,%generator) {}
function DeployableELF::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------
