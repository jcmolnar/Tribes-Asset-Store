//--------------------------------------

addToInv(DiscPack,1,1);

setArmorItemMax(DiscPack,0,0,0,1,1,1,1, 0, 0,0,0,0);

$TeamItemMax[DiscPack] = 8;

dataReinit(DiscPack);
$TCK[DeployableDisc] = true;
$PlayCtrl[DeployableDisc] = true;
//--------------------------------------
RocketData FDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.25;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = 75.0;

   muzzleVelocity   = 120.0;
   terminalVelocity = 160.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------

ItemImageData DiscPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData DiscPack
{
        description = "Disc Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = $InvCatTurrets;
        imageType = DiscPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DiscPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DiscPack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,4,"LAND",30,30,20,10,10,10,3,false,DeployableDisc,"Turret",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------

TurretData DeployableDisc
{
        className = "Turret";
        shapeFile = "indoorgun";
        projectileType = FDiscShell;
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
        description = "Disc Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableDisc::onAdd(%this)
{
        schedule("DeployableDisc::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Disc Turret");
}

function DeployableDisc::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableDisc::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableDisc::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "DiscPack"]--;
}

// Override base class just in case.
function DeployableDisc::onPower(%this,%power,%generator) {}
function DeployableDisc::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------
