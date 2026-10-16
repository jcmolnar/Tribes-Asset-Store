//--------------------------------------

addToInv(MissilePack,1,1);

setArmorItemMax(MissilePack,0,0,0,0,1,1,1, 0, 0,0,0,0);

$TeamItemMax[MissilePack] = 8;

dataReinit(MissilePack);
$TCK[DeployableMissile] = true;
$PlayCtrl[DeployableMissile] = true;
//--------------------------------------
RocketData DRocketShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.0;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;

   totalTime        = 8.0;
   liveTime         = 9.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

ItemImageData MissilePackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData MissilePack
{
        description = "Rocket Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = $InvCatTurrets;
        imageType = MissilePackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function MissilePack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function MissilePack::onDeploy(%player,%item,%pos)
{
        if (Item::universalDeploy(%player,%item,4,"LAND",50,50,25,10,10,10,2,true,DeployableMissile,"Turret",true))
                Player::decItemCount(%player,%item);
}

//--------------------------------------

TurretData DeployableMissile
{
        className = "Turret";
        shapeFile = "mortar_turret";
        projectileType = DRocketShell;
        maxDamage = 0.75;
        maxEnergy = 120;
        minGunEnergy = 20;
        maxGunEnergy = 30;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 1.75;
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
        shieldShapeName = "shield_medium";
        fireSound = bigExplosion1;
        activationSound = SoundEnergyTurretOn;
        deactivateSound = SoundEnergyTurretOff;
        explosionId = flashExpMedium;
        description = "Rocket Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableMissile::onAdd(%this)
{
        schedule("DeployableMissile::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.02;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Rocket Turret");
}

function DeployableMissile::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableMissile::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableMissile::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "MissilePack"]--;
}

// Override base class just in case.
function DeployableMissile::onPower(%this,%power,%generator) {}
function DeployableMissile::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------
