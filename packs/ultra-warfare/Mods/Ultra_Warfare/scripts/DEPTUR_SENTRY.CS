//================================================================
//Sentry Turret
//================================================================
$InvList[TurretPack] = 1;
$RemoteInvList[TurretPack] = 1;
//=====================================================
$DamageScale[larmor, $DepturSentryDamageType] = 0.15;
$DamageScale[lfemale, $DepturSentryDamageType] = 0.15;
$DamageScale[marmor, $DepturSentryDamageType] = 0.15;
$DamageScale[mfemale, $DepturSentryDamageType] = 0.15;
$DamageScale[harmor, $DepturSentryDamageType] = 0.15;
//================================================================	
$ItemMax[larmor, TurretPack] = 0;
$ItemMax[lfemale, TurretPack] = 0;
$ItemMax[marmor, TurretPack] = 0;
$ItemMax[mfemale, TurretPack] = 0;
$ItemMax[harmor, TurretPack] = 1;
//================================================================
$TeamItemMax[TurretPack] = 1;
//================================================================
SoundData SoundTurSentry
{
   wavFileName = "tur_sentry.wav";
   profile = Profile3dMed;
};
//====================================================================
ExplosionData sentryblast
{
   shapeName = "tumult_small.dts";
   soundId   = laserExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2;

   timeZero = 0.250;
   timeOne  = 0.650;
	
//                red, grn, blu
   colors[0]  = { 3.0, 0.0, 0.0 };
   colors[1]  = { 3.0, 0.0, 0.0 };
   colors[2]  = { 3.0, 0.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
 };

//=============================================================
RocketData TurretSentryproj
{
   bulletShapeName = "proj_laser_red.dts";
   explosionTag    = sentryblast;

   collisionRadius = 0.0;
   mass            = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5;
   damageType       = $DepturSentryDamageType;

   muzzleVelocity   = 200.0;
   terminalVelocity = 400.0;
   acceleration     = 100.0;
   explosionRadius  = 3;

   totalTime        = 3.0;
   liveTime         = 3.0;

lightRange        = 4.0;
   lightColor        = { 3.0, 0.25, 0.25 };
   isVisible          = True;
   inheritedVelocityScale = 1.0;
   soundId = SoundWhizLaser; 
  };
//================================================================
ItemImageData TurretPackImage
{
        shapeFile = "tpack_sentry";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData TurretPack
{
        description = "Sentry Turret";
        shapeFile = "tpack_sentry";
        className = "Backpack";
   heading = "LTurrets";
        imageType = TurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function TurretPack::onDeploy(%player,%item,%pos)
{
        if (TurretPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function CountObjects(%set,%name,%num)
{
        %count = 0;
        for(%i=0;%i<%num;%i++) {
                %obj=Group::getObject(%set,%i);
                if(GameBase::getDataName(Group::getObject(%set,%i)) == %name)
                        %count++;
        }
        return %count;
}

function TurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableTurret",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DeployableTurret",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("tpack_sentry","Turret",DeployableTurret,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Sentry Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

function checkDeployArea(%client,%pos)
{
          %set=newObject("set",SimSet);
        %num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
        if(!%num) {
                deleteObject(%set);
                return 1;
        }
        else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") {
                %obj = Group::getObject(%set,0);
                if(Player::getClient(%obj) == %client)
                        Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
                else
                        Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
        }
        else
                Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

        deleteObject(%set);
        return 0;


}


//================================================================
TurretData DeployableTurret
 {
 className = "Turret";
 shapeFile = "deptur_sentry";
 projectileType = TurretSentryproj;
 maxDamage = 7.0;
 maxEnergy = 250;
 minGunEnergy = 1;
 maxGunEnergy = 5;
 sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
 reloadDelay = 0.5;
 speed = 3.0;
 speedModifier = 3.0;
 range = 200;
 visibleToSensor = true;
 shadowDetailMask = 4;
 dopplerVelocity = 0;
 castLOS = true;
 supression = false;
 mapFilter = 2;
 mapIcon = "M_turret";
 debrisId = flashDebrisMedium;
 shieldShapeName = "shield";
 fireSound = SoundTurSentry;
 activationSound = SoundPlasmaTurretOn;
 deactivateSound = SoundPlasmaTurretOff;
 whirSound = SoundPlasmaTurretTurn;
 explosionId = flashExpMedium;
 description = "Sentry Turret";
 damageSkinData = "objectDamageSkins";
 };
 function DeployableTurret::onAdd(%this) { schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
 GameBase::setRechargeRate(%this,20); %this.shieldStrength = 0.01;
 if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Sentry Turret");
 } }
 function DeployableTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy");
 }
 function DeployableTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true);
 }
 function DeployableTurret::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this);
 %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0);
 Turret::onDeactivate(%this); Turret::objectiveDestroyed(%this);
 CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
 $TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
 }
 function DeployableTurret::onPower(%this,%power,%generator) {}
 function DeployableTurret::onEnabled(%this) { GameBase::setRechargeRate(%this,20);
 GameBase::setActive(%this,true);
 }