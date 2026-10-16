//--------------------------------------

addToInv(MGunPack,1,1);

setArmorItemMax(MGunPack,0,0,0,0,1,0,0, 0, 0,0,0,0);

$TeamItemMax[MGunPack] = 4;

dataReinit(MGunPack);
$TCK[DeployableMGun] = true;
$PlayCtrl[DeployableMGun] = true;
//--------------------------------------
BulletData MachinegunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0075;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------

ItemImageData MGunPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData MGunPack
{
        description = "Machine Gun Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = $InvCatTurrets;
        imageType = MGunPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function MGunPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function MGunPack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,4,"LAND",50,50,25,10,10,10,2,true,DeployableMGun,"Turret",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------

TurretData DeployableMGun
{
        className = "Turret";
        shapeFile = "hellfiregun";
        projectileType = MachinegunBullet;
        maxDamage = 1.0;
        maxEnergy = 200;
        minGunEnergy = 15;
        maxGunEnergy = 20;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.3;
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
        shieldShapeName = "shield_medium";
        sfxFire = SoundFireChaingun2;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        explosionId = flashExpMedium;
        description = "Machine Gun Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableMGun::onAdd(%this)
{
        schedule("DeployableMGun::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.03;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Machine Gun Turret");
}

function DeployableMGun::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableMGun::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableMGun::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "MGunPack"]--;
}

// Override base class just in case.
function DeployableMGun::onPower(%this,%power,%generator) {}
function DeployableMGun::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------
