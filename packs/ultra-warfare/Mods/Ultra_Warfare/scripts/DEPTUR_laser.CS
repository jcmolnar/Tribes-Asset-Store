//================================================================
//DepLaser Turret
//================================================================
$InvList[DepLaserPack] = 1;
$RemoteInvList[DepLaserPack] = 1;
//====================================================
$DamageScale[larmor, $DepturLaserDamageType] = 3.0;
$DamageScale[lfemale, $DepturLaserDamageType] = 3.0;
$DamageScale[marmor, $DepturLaserDamageType] = 3.0;
$DamageScale[mfemale, $DepturLaserDamageType] = 3.0;
$DamageScale[harmor, $DepturLaserDamageType] = 3.0;
//================================================================	
$ItemMax[larmor, DepLaserPack] = 0;
$ItemMax[lfemale, DepLaserPack] = 0;
$ItemMax[marmor, DepLaserPack] = 0;
$ItemMax[mfemale, DepLaserPack] = 0;
$ItemMax[harmor, DepLaserPack] = 1;
//================================================================
$TeamItemMax[DepLaserPack] = 3;
//================================================================
SoundData SoundDepturLaser
{
   wavFileName = "tur_depLaser.wav";
   profile = Profile3dMedium;
};
//================================================================
ExplosionData SmallLaserBlast
{
   shapeName = "flash_small.dts";
   soundId   = laserExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3;

   timeZero = 0.250;
   timeOne  = 0.650;

  
   colors[0]  = { 3.0, 0.0, 0.0 };
   colors[1]  = { 3.0, 0.0, 0.0 };
   colors[2]  = { 3.0, 0.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
//============================================================
RocketData DepturLaserproj
{ 
   bulletShapeName = "proj_laser_red.dts"; 
   explosionTag = smalllaserblast; 
   collisionRadius = 0.0; 
   mass = 0.75; 
   damageClass = 0; 
   damageValue = 7; 
   damageType = $DepturLaserDamageType; 
   explosionRadius = 3.5; 
   kickBackStrength = 100; 
   muzzleVelocity = 1000; 
   terminalVelocity = 1000; 
   acceleration = 100; 
   totalTime = 3; 
   liveTime = 5; 
   lightRange = 5; 
   lightColor = { 3, 0.25, 0.25 }; 
   inheritedVelocityScale = 3; 
   trailType = 2; 
   trailString = "rsmoke.dts"; 
   smokeDist = 7.0; 
	soundId = SoundWhizLaser;  
};
//================================================================
ItemImageData DepLaserPackImage
{
        shapeFile = "tpack_Laser";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData DepLaserPack
{
        description = "Laser Turret";
        shapeFile = "tpack_Laser";
        className = "Backpack";
   heading = "LTurrets";
        imageType = DepLaserPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DepLaserPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DepLaserPack::onDeploy(%player,%item,%pos)
{
        if (DepLaserPack::deployShape(%player,%item)) {
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

function DepLaserPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableLaser",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DeployableLaser",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("tpack_Laser","Turret",DeployableLaser,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Laser Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "DepLaserPack"]++;
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
TurretData DeployableLaser
 {
 className = "Turret";
 shapeFile = "deptur_Laser";
 projectileType = DepturLaserproj;
 maxDamage = 10.0;
 maxEnergy = 250;
 minGunEnergy = 7;
 maxGunEnergy = 7;
 sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
 reloadDelay = 5.0;
 speed = 2.0;
 speedModifier = 2.0;
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
 fireSound = SoundDepturLaser;
 activationSound = SoundPlasmaTurretOn;
 deactivateSound = SoundPlasmaTurretOff;
 whirSound = SoundPlasmaTurretTurn;
 explosionId = flashExpMedium;
 description = "Deployable Laser Turret";
 damageSkinData = "objectDamageSkins";
 };
 function DeployableLaser::onAdd(%this) { schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
 GameBase::setRechargeRate(%this,20); %this.shieldStrength = 0.01;
 if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Laser Turret");
 } }
 function DeployableLaser::deploy(%this) { GameBase::playSequence(%this,1,"deploy");
 }
 function DeployableLaser::onEndSequence(%this,%thread) { GameBase::setActive(%this,true);
 }
 function DeployableLaser::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this);
 %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0);
 Turret::onDeactivate(%this); Turret::objectiveDestroyed(%this);
 CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
 $TeamItemCount[GameBase::getTeam(%this) @ "DepLaserPack"]--;
 }
 function DeployableLaser::onPower(%this,%power,%generator) {}
 function DeployableLaser::onEnabled(%this) { GameBase::setRechargeRate(%this,20);
 GameBase::setActive(%this,true);
 }