//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
        maxDamage = 1.0;
        maxEnergy = 200;
        minGunEnergy = 75;
        maxGunEnergy = 6;
        reloadDelay = 0.8;
        fireSound = SoundPlasmaTurretFire;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 100;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "hellfiregun";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = FusionBolt;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Plasma Turret";
};

TurretData ELFTurret
{
        maxDamage = 1.0;
        maxEnergy = 150;
        minGunEnergy = 50;
        maxGunEnergy = 5;
        range = 40;
        visibleToSensor = true;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = defaultDebrisMedium;
        className = "ELF Turret";
        shapeFile = "chainturret";
        shieldShapeName = "shield";
        speed = 5.0;
        speedModifier = 1.5;
        projectileType = turretCharge;
        reloadDelay = 0.3;
        explosionId = LargeShockwave;
        description = "ELF Turret";

        fireSound        = SoundGeneratorPower;
        activationSound  = SoundChainTurretOn;
        deactivateSound  = SoundChainTurretOff;
        damageSkinData   = "objectDamageSkins";
        shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

TurretData RocketTurret
{
        maxDamage = 0.75;
        maxEnergy = 100;
        minGunEnergy = 60;
        maxGunEnergy = 60;
        range = 150;
        gunRange = 300;
        visibleToSensor = true;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = defaultDebrisLarge;
        className = "Turret";
        shapeFile = "missileturret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = TurretMissile;
//        reloadDelay = 3.5;
        fireSound = SoundMissileTurretFire;
        activationSound = SoundMissileTurretOn;
        deactivateSound = SoundMissileTurretOff;
//        whirSound = SoundMissileTurretTurn;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        targetableFovRatio = 0.5;
        explosionId = LargeShockwave;
        description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
        if (%power) {
                %this.shieldStrength = 0.03;
                GameBase::setRechargeRate(%this,14);
        }
        else {
                %this.shieldStrength = 0;
                GameBase::setRechargeRate(%this,0);
                Turret::checkOperator(%this);
        }
        GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//--------------------------------------------

TurretData MortarTurret
{
        maxDamage = 1.0;
        maxEnergy = 45;
        minGunEnergy = 45;
        maxGunEnergy = 100;
        reloadDelay = 2.0;
        fireSound = SoundMortarTurretFire;
        activationSound = SoundMortarTurretOn;
        deactivateSound = SoundMortarTurretOff;
        whirSound = SoundMortarTurretTurn;
        range = 0;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "mortar_turret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = MortarTurretShell;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Mortar Turret";
};

//--------------------------------------------

TurretData IndoorTurret
{
        className = "Turret";
        shapeFile = "indoorgun";
        projectileType = MiniFusionBolt;
        maxDamage = 2.5;
        maxEnergy = 60;
        minGunEnergy = 20;
        maxGunEnergy = 6;
        reloadDelay = 0.4;
        speed = 5.0;
        speedModifier = 1.0;
        range = 25;
        visibleToSensor = true;
        dopplerVelocity = 2;
        castLOS = true;
        supression = false;
        supressable = false;
        pinger = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = defaultDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundEnergyTurretFire;
        activationSound = SoundEnergyTurretOn;
        deactivateSound = SoundEnergyTurretOff;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = debrisExpMedium;
        description = "Indoor Turret";

};


//--------------------------------------------

TurretData DeployableTurret
{
        className = "Turret";
        shapeFile = "remoteturret";
        projectileType = IonBolt;
        maxDamage = 0.65;
        maxEnergy = 60;
        minGunEnergy = 6;
        maxGunEnergy = 5;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.4;
        speed = 4.0;
        speedModifier = 1.5;
        range = 55;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundRemoteTurretFire;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId = flashExpMedium;
        description = "Remote Ion Turret";
        damageSkinData = "objectDamageSkins";
};
function DeployableTurret::onAdd(%this)
{
        schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0.005;
        if (GameBase::getMapName(%this) == "")
        {
                GameBase::setMapName (%this, "Remote Turret");
        }
}
function DeployableTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}
function DeployableTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}
function DeployableTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}
function DeployableTurret::onPower(%this,%power,%generator)
{
}
function DeployableTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------------------

TurretData CameraTurret
{
        className = "Turret";
        shapeFile = "camera";
        maxDamage = 0.25;
        maxEnergy = 10;
        speed = 20;
        speedModifier = 1.0;
        range = 50;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        visibleToSensor = true;
        shadowDetailMask = 4;
        castLOS = true;
        supression = false;
        supressable = false;
        mapFilter = 2;
        mapIcon = "M_camera";
        debrisId = defaultDebrisSmall;
        FOV = 0.707;
        pinger = false;
        explosionId = debrisExpMedium;
        description = "Camera";
};

function CameraTurret::onAdd(%this)
{
        schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Camera");
        }
}

function CameraTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function CameraTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function CameraTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
}

//=========================This is section where NDG Renegades adds Turrets =========================

//----------------------------------- Deployable Plasma Turret ---------------------------------
TurretData DeployablePlasma
{
        className = "Turret";
        shapeFile = "hellfiregun";
        projectileType = FusionBolt;
        maxDamage = 1.0;
        maxEnergy = 200;
        minGunEnergy = 75;
        maxGunEnergy = 6;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.8;
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
        fireSound = SoundPlasmaTurretFire;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        explosionId = flashExpMedium;
        description = "Deployable Plasma Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployablePlasma::onAdd(%this)
{
        schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Plasma Turret");
        }
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
          $TeamItemCount[GameBase::getTeam(%this) @ "DepPlasTurretPack"]--;
}

// Override base class just in case.
function DeployablePlasma::onPower(%this,%power,%generator) {}
function DeployablePlasma::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//-------------------------------- Deployable Rocket -----------------------------
TurretData DeployableRocket
{
        className = "Turret";
        shapeFile = "missileturret";
        projectileType = TurretMissile;
        maxDamage = 1.0;
        maxEnergy = 100;
        minGunEnergy = 60;
        maxGunEnergy = 60;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//        reloadDelay = 3.5;
        speed = 2.0;
        speedModifier = 2.0;
        range = 150;
        gunRange = 300;
        visibleToSensor = true;
        shadowDetailMask = 8;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield_medium";
        fireSound = SoundMissileTurretFire;
        activationSound = SoundMissileTurretOn;
        deactivateSound = SoundMissileTurretOff;
        explosionId = flashExpMedium;
        description = "Deployable Rocket Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableRocket::onAdd(%this)
{
        schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,15);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Rocket Turret");
        }
}

function DeployableRocket::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableRocket::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "DepRockTurretPack"]--;
}

// Override base class just in case.

function DeployableRocket::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

function DeployableRocket::onPower(%this,%power,%generator)
{
        if (%power) {
                %this.shieldStrength = 0.03;
                GameBase::setRechargeRate(%this,14);
        }
        else {
                %this.shieldStrength = 0;
                GameBase::setRechargeRate(%this,0);
                Turret::checkOperator(%this);
        }
        GameBase::setActive(%this,%power);
}

function DeployableRocket::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//---------------------------------------------Point Defense Turret -----------------------------------------------

TurretData PointRocket
{
        className = "Turret";
        shapeFile = "mortar_turret";
        projectileType = PointMissile;
        maxDamage = 1.0;
        maxEnergy = 40;
        minGunEnergy = 30;
        maxGunEnergy = 30;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//        reloadDelay = 3.5;
        speed = 2.0;
        speedModifier = 2.0;
        range = 75;
        gunRange = 100;
        visibleToSensor = true;
        shadowDetailMask = 8;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundMissileTurretFire;
        activationSound = SoundMissileTurretOn;
        deactivateSound = SoundMissileTurretOff;
        explosionId = flashExpMedium;
        description = "Deployable Rocket Turret";
        damageSkinData = "objectDamageSkins";
};

function PointRocket::onAdd(%this)
{
        schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Rocket Turret");
        }
}

function PointRocket::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function PointRocket::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function PointRocket::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "PointDefTurretPack"]--;
}

// Override base class just in case.
function PointRocket::onPower(%this,%power,%generator) {}
function PointRocket::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//-------------------------------------Deployable ChainGun Turret ---------------------------------
TurretData DeployableChainTurret
{
        className = "Turret";
        shapeFile = "remoteturret";
        projectileType = ChainGunBullet;
        maxDamage = 0.65;
        maxEnergy = 60;
        minGunEnergy = 6;
        maxGunEnergy = 8;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.3;
        speed = 4.0;
        speedModifier = 1.5;
        range = 55;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundFireMortar;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId = flashExpMedium;
        description = "Remote Chain Turret";
        damageSkinData = "objectDamageSkins";
};
function DeployableChainTurret::onAdd(%this)
{
        schedule("DeployableChainTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0.005;
        if (GameBase::getMapName(%this) == "")
        {
                GameBase::setMapName (%this, "Remote Chain Turret");
        }
}
function DeployableChainTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}
function DeployableChainTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}
function DeployableChainTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}
function DeployableChainTurret::onPower(%this,%power,%generator)
{
}
function DeployableChainTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//-------------------------------------- Deployable Mortar Turret --------------------------------
TurretData DeployableMortar
{
        className = "Turret";
        shapeFile = "mortar_turret";
        projectileType = MortarTurretShell;
        maxDamage = 1.0;
        maxEnergy = 45;
        minGunEnergy = 45;
        maxGunEnergy = 100;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 2.0;
        speed = 2.0;
        speedModifier = 1.5;
        range = 0;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundMortarTurretFire;
        activationSound = SoundMortarTurretOn;
        deactivateSound = SoundMortarTurretOff;
        whirSound = SoundMortarTurretTurn;
        explosionId = LargeShockwave;
        description = "Remote Mortar Turret";
        damageSkinData = "objectDamageSkins";
};
function DeployableMortar::onAdd(%this)
{
        schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,7);
        %this.shieldStrength = 0.005;
        if (GameBase::getMapName(%this) == "")
        {
                GameBase::setMapName (%this, "Mortar Turret");
        }
}
function DeployableMortar::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}
function DeployableMortar::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}
function DeployableMortar::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--;
}
function DeployableMortar::onPower(%this,%power,%generator)
{
}
function DeployableMortar::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,7);
        GameBase::setActive(%this,true);
}

// --------------------------------------------------- Laser Turret ---------------------------------
TurretData DeployableLaser
{
        className = "Turret";
        shapeFile = "camera";
        projectileType = TurretLaser;
        maxDamage = 0.75;
        maxEnergy = 75;
        minGunEnergy = 10;
        maxGunEnergy = 55;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 10.0;
        speed = 4.0;
        speedModifier = 1.5;
        range = 125;
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
        description = "Remote Laser Turret";
        damageSkinData = "objectDamageSkins";
};
function DeployableLaser::onAdd(%this)
{
        schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "")
        {
                GameBase::setMapName (%this, "Remote Laser Turret");
        }
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
function DeployableLaser::onPower(%this,%power,%generator)
{
}
function DeployableLaser::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

// -----------------------------------  CIWS Turret -----------------------------------
TurretData DeployableCIWS
{
        className = "Turret";
        shapeFile = "chainturret";
        projectileType = TurretBullet;
        maxDamage = 1.0;
        maxEnergy = 100;
        minGunEnergy = 4;
        maxGunEnergy = 5;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//        reloadDelay = 0.05;
        speed = 4.0;
        speedModifier = 1.5;
        range = 150;
        gunRange = 300;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundPlasmaTurretFire;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        explosionId = flashExpMedium;
        description = "C.I.W.S. AA Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableCIWS::onAdd(%this)
{
        schedule("DeployableCIWS::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "C.I.W.S. Turret");
        }
}

function DeployableCIWS::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableCIWS::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableCIWS::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "CIWSTurretPack"]--;
}

// Override base class just in case.

function DeployableCIWS::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

function DeployableCIWS::onPower(%this,%power,%generator)
{
        if (%power) {
                %this.shieldStrength = 0.03;
                GameBase::setRechargeRate(%this,14);
        }
        else {
                %this.shieldStrength = 0;
                GameBase::setRechargeRate(%this,0);
                Turret::checkOperator(%this);
        }
        GameBase::setActive(%this,%power);
}

function DeployableCIWS::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//----------------------------------- Deployable Holo-Plasma Turret ---------------------------------
TurretData DeployableHoloPlasma
{
        className = "Turret";
        shapeFile = "hellfiregun";
        projectileType = HoloFusionBolt;
        maxDamage = 1.0;
        maxEnergy = 200;
        minGunEnergy = 75;
        maxGunEnergy = 6;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.8;
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
        fireSound = SoundPlasmaTurretFire;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        explosionId = flashExpMedium;
        description = "Deployable Plasma Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableHoloPlasma::onAdd(%this)
{
        schedule("DeployableHoloPlasma::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Plasma Turret");
        }
}

function DeployableHoloPlasma::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableHoloPlasma::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableHoloPlasma::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "DepHoloPlasPack"]--;
}

// Override base class just in case.
function DeployableHoloPlasma::onPower(%this,%power,%generator) {}
function DeployableHoloPlasma::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//-------------------------------- Deployable Holo Rocket -----------------------------
TurretData DeployableHoloRocket
{
        className = "Turret";
        shapeFile = "missileturret";
        projectileType = TurretHoloMissile;
        maxDamage = 1.0;
        maxEnergy = 100;
        minGunEnergy = 60;
        maxGunEnergy = 60;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//        reloadDelay = 3.5;
        speed = 2.0;
        speedModifier = 2.0;
        range = 150;
        gunRange = 300;
        visibleToSensor = true;
        shadowDetailMask = 8;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundMissileTurretFire;
        activationSound = SoundMissileTurretOn;
        deactivateSound = SoundMissileTurretOff;
        explosionId = flashExpMedium;
        description = "Deployable Rocket Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableHoloRocket::onAdd(%this)
{
        schedule("DeployableHoloRocket::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Rocket Turret");
        }
}

function DeployableHoloRocket::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableHoloRocket::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableHoloRocket::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "DepHoloRockPack"]--;
}

// Override base class just in case.

function DeployableHoloRocket::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

function DeployableHoloRocket::onPower(%this,%power,%generator)
{
        if (%power) {
                %this.shieldStrength = 0.03;
                GameBase::setRechargeRate(%this,14);
        }
        else {
                %this.shieldStrength = 0;
                GameBase::setRechargeRate(%this,0);
                Turret::checkOperator(%this);
        }
        GameBase::setActive(%this,%power);
}

function DeployableHoloRocket::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//----------------------------------- Deployable Rail Turret ---------------------------------
TurretData DeployableRail
{
        className = "Turret";
        shapeFile = "hellfiregun";
        projectileType = RailLaser;
        maxDamage = 1.0;
        maxEnergy = 150;
        minGunEnergy = 100;
        maxGunEnergy = 150;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 8.0;
        speed = 4.0;
        speedModifier = 1.5;
        range = 0;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundMissileTurretFire;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        explosionId = flashExpMedium;
        description = "Deployable Rail Turret";
        damageSkinData = "objectDamageSkins";
};

function DeployableRail::onAdd(%this)
{
        schedule("DeployableRail::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Rail Turret");
        }
}

function DeployableRail::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableRail::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableRail::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "DepRailTurretPack"]--;
}

// Override base class just in case.
function DeployableRail::onPower(%this,%power,%generator) {}
function DeployableRail::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//=========================== deployable Shock Turret =========================

TurretData DeployableShock
{
        maxDamage = 1.5;
        maxEnergy = 110;
        minGunEnergy = 15;
        maxGunEnergy = 20;
        reloadDelay = 2.0;
        fireSound = SoundMortarTurretFire;
        activationSound = SoundMortarTurretOn;
        deactivateSound = SoundMortarTurretOff;
        whirSound = SoundMortarTurretTurn;
        range = 30;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "indoorgun";
        shieldShapeName = "shield_medium";
        speed = 5.0;
        speedModifier = 1.50;
        projectileType = ShockShell;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Shock Turret";
};
function DeployableShock::onAdd(%this)
{
        schedule("DeployableShock::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,6);
        %this.shieldStrength = 0.010;
        if (GameBase::getMapName(%this) == "")
        {
                GameBase::setMapName (%this, "Remote Shock Turret");
        }
}
function DeployableShock::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}
function DeployableShock::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}
function DeployableShock::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--;
}
function DeployableShock::onPower(%this,%power,%generator)
{
}
function DeployableShock::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//-------------------------------- Engineering Camera ------------------------------
TurretData DeployableMini
{
        className = "Turret";
        shapeFile = "camera";
        projectileType = HyperBolt;
        maxDamage = 0.40;
        maxEnergy = 60;
        minGunEnergy = 6;
        maxGunEnergy = 5;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.25;
        speed = 4.0;
        speedModifier = 1.5;
        range = 30;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound = SoundRemoteTurretFire;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId = flashExpMedium;
        description = "Remote Camera";
        damageSkinData = "objectDamageSkins";
};
function DeployableMini::onAdd(%this)
{
        schedule("DeployableMini::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "")
        {
                GameBase::setMapName (%this, "Blaster Turret");
        }
}
function DeployableMini::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}
function DeployableMini::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}
function DeployableMini::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
}
function DeployableMini::onPower(%this,%power,%generator)
{
}
function DeployableMini::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

//--------------------------------- Satchel Charge ---------------------------------------
TurretData DeployableSatchel
{
        className = "Turret";
        shapeFile = "camera";
        projectileType = SatchelShell;
        maxDamage = 0.4;
        maxEnergy = 75;
        minGunEnergy = 10;
        maxGunEnergy = 60;
        sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 10.0;
        speed = 4.0;
        speedModifier = 1.5;
        range = 0;
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
        explosionId = rocketExp;
        description = "Satchel Charge";
        damageSkinData = "objectDamageSkins";

};
function DeployableSatchel::onAdd(%this)
{
        schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,0);
        %this.shieldStrength = 0;
        if (GameBase::getMapName(%this) == "")
        {
                GameBase::setMapName (%this, "Satchel Charge");
        }
}
function DeployableSatchel::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}
function DeployableSatchel::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}
function DeployableSatchel::onDestroyed(%this)
{
        StaticShape::objectiveDestroyed(%this);
        %this.shieldStrength = 0;
        GameBase::setRechargeRate(%this,0);
        Turret::onDeactivate(%this);
        Turret::objectiveDestroyed(%this);
        CalcRadiusDamage(%this,$MortarDamageType,30,0.2,25,20,20,1.5,0.5,200,100);
        $TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--;
}
function DeployableSatchel::onPower(%this,%power,%generator)
{
}
function DeployableSatchel::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}


//========================= Back to base Turret Functions ==============================

//---------------------------------------------------

function Turret::onAdd(%this)
{
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Turret");
        }
}

function Turret::onActivate(%this)
{
        GameBase::playSequence(%this,0,power);
}

function Turret::onDeactivate(%this)
{
        GameBase::stopSequence(%this,0);
        Turret::checkOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
        if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this)))
                Turret::checkOperator(%this);

}

function Turret::checkOperator(%this)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1) {
           %pl = Client::getOwnedObject(%cl);
                Player::setMountObject(%pl, -1,0);
           Client::setControlObject(%cl, %pl);
   }
        Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
        if (%power) {
                %this.shieldStrength = 0.03;
                GameBase::setRechargeRate(%this,10);
        }
        else {
                %this.shieldStrength = 0;
                GameBase::setRechargeRate(%this,0);
                Turret::checkOperator(%this);
        }
        GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
        if (GameBase::isPowered(%this)) {
                %this.shieldStrength = 0.03;
                GameBase::setRechargeRate(%this,10);
                GameBase::setActive(%this,true);
        }
}

function Turret::onDisabled(%this)
{
        %this.shieldStrength = 0;
        GameBase::setRechargeRate(%this,0);
        Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this)
{
        StaticShape::objectiveDestroyed(%this);
        %this.shieldStrength = 0;
        GameBase::setRechargeRate(%this,0);
        Turret::onDeactivate(%this);
        Turret::objectiveDestroyed(%this);
        calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40,
                0.1, 200, 100);
}


function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
if(%type == $FlashDamageType)
        EnergyDrain(%this);
if(%this.objectiveLine)
        %this.lastDamageTeam = GameBase::getTeam(%object);
%TDS= 1;
if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
        {
        %name = GameBase::getDataName(%this);
        if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != DeployableMortar && %name != DeployableHoloPlasma && %name != DeployableHoloRocket && %name != DeployableCIWS && %name != PointRocket && %name != DeployablePlasma && %name != DeployableLaser && %name != DeployableRocket && %name != DeployableChainTurret && %name != DeployableRail && %name != DeployableShock && %name != DeployableMini && %name != DeploySatchel && %name != SatchelPack) %TDS = $Server::TeamDamageScale;
        }
StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}




function Turret::onControl (%this, %object)
{
        %client = Player::getClient(%object);
        Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function Turret::onDismount (%this, %object)
{
        %client = Player::getClient(%object);
        Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

//function Turret::onCollision (%this, %object)
//{
//        if (getObjectType (%object) == "Player")
//                {
//                        Player::mountObject (%object, %this);
//                }
//}

function Turret::onCollision (%this, %object)
{
        if(getObjectType(%object) != "Player")
        {
                return;
        }
        if(Player::isDead(%object))
        {
                return;
        }
        %c = Player::getClient(%object);
        %client = Player::getClient(%object);
        %playerTeam = GameBase::getTeam(%object);
        %teleTeam = GameBase::getTeam(%this);
        if(%this.disabled == true)
        {
                Client::SendMessage(%c,0,"Turret is recharging");
                return;
        }
        if(%teleTeam != %playerTeam)
        {
                if( ((Player::getArmor(%object) == "sparmor") || (Player::getArmor(%object) == "spfemale")) && (Player::getMountedItem(%object,$BackpackSlot) == Laptop) )
                {
                        %name = GameBase::getDataName(%this);
                        if(%name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name ==DeployableRail || %name == MortarTurret)
                        {
                                if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object))
                                {
                                        Client::getOwnedObject(%client).CommandTag = 1;
                                        Client::sendMessage(%client,0,"Re-programming turret");
                                        GameBase::setTeam (%this,GameBase::getTeam (%client));
                                        Client::takeControl(%client, %this);
                                        %this.Disabled = true;
                                        Client::getOwnedObject(%client).CommandTag = "";
                                        if(%name == DeployablePlasma || %name ==  DeployableRail ) GameBase::SetPosition(%object,GameBase::GetPosition(%this));
                                        return;
                                }
                        }
                }
                Client::SendMessage(%c,0,"Wrong Team");
                return;
        }
        if((Player::getArmor(%obj) == "harmor") || (Player::getArmor(%obj) == "darmor"))
        {
                Client::SendMessage(%c,0,"Cannot manually control turrets in this character class");
                return;
        }
        else
        {
                %name = GameBase::getDataName(%this);
                if(%name == DeployableRail)
                {
                        if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object))
                        {
                                Client::getOwnedObject(%client).CommandTag = 1;
                                Client::sendMessage(%client,0,"Manually controlling turret");
                                Client::takeControl(%client, %this);
                                GameBase::SetPosition(%object,GameBase::GetPosition(%this));
                                %this.Disabled = true;
                                Client::getOwnedObject(%client).CommandTag = "";
                                return;
                        }
                }
        }
}
function Turret::Reenable(%this)
{
        %this.disabled = false;
}
function LaptopDrain(%clientId, %player)
{
        Player::unmountItem(%player,$WeaponSlot);
        if($lapTime[%clientId] == 0)
        {
                Client::getOwnedObject(%clientId).CommandTag = "";
                GameBase::setEnergy(%player,0);
                GameBase::setRechargeRate(%player,0);
                $lapTime[%clientId] = 14;
                checkPlayerLaptop(%clientId, %player);
        }
        else $lapTime[%clientId] = 14;
}
function checkPlayerLaptop(%clientId, %player)
{
        if($lapTime[%clientId] > 0)
        {
                $lapTime[%clientId] -= 2;
                schedule("checkPlayerLaptop(" @ %clientId @ ", " @ %player @ ");",2,%player);
        }
        else
        {
                GameBase::setRechargeRate(%player,8);
        }
}