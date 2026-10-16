//--------------------------------------

addToInv(FreezePack,1,1);

setArmorItemMax(FreezePack,0,0,0,0,1,0,0, 0, 0,0,0,0);

$TeamItemMax[FreezePack] = 4;

dataReinit(FreezePack);
$TCK[DeployableFreeze] = true;
$PlayCtrl[DeployableFreeze] = true;
//--------------------------------------
BulletData FreezeBullet
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = energyExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.125;
   damageType         = $FrostDamageType;

   muzzleVelocity     = 75.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------

ItemImageData FreezePackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData FreezePack
{
        description = "Frost Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = $InvCatTurrets;
        imageType = FreezePackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function FreezePack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function FreezePack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,4,"LAND",30,30,20,10,10,10,3,true,DeployableFreeze,"Turret",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------

TurretData DeployableFreeze
{
        className = "Turret";
        shapeFile = "indoorgun";
        projectileType = FreezeBullet;
        maxDamage = 0.75;
        maxEnergy = 70;
        minGunEnergy = 7;
        maxGunEnergy = 10;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.75;
        speed = 4.0;
        speedModifier = 1.5;
        range = 75;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundFireDisc;
        activationSound = SoundEnergyTurretOn;
        deactivateSound = SoundEnergyTurretOff;
        explosionId = flashExpMedium;
        description = "Frost Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableFreeze::onAdd(%this)
{
        schedule("DeployableFreeze::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Frost Turret");
}

function DeployableFreeze::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableFreeze::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableFreeze::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "FreezePack"]--;
}

// Override base class just in case.
function DeployableFreeze::onPower(%this,%power,%generator) {}
function DeployableFreeze::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------
