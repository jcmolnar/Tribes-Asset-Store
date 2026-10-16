//================================================================
//Rocket Turret
//================================================================
$InvList[RocketPack] = 1;
$RemoteInvList[RocketPack] = 1;
//=================================================
$DamageScale[larmor, $DepturRocketDamageType] = 1.0;
$DamageScale[lfemale, $DepturRocketDamageType] = 1.0;
$DamageScale[marmor, $DepturRocketDamageType] = 1.0;
$DamageScale[mfemale, $DepturRocketDamageType] = 1.0;
$DamageScale[harmor, $DepturRocketDamageType] = 1.0;
//================================================================	
$ItemMax[larmor, RocketPack] = 0;
$ItemMax[lfemale, RocketPack] = 0;
$ItemMax[marmor, RocketPack] = 0;
$ItemMax[mfemale, RocketPack] = 0;
$ItemMax[harmor, RocketPack] = 1;
//================================================================
$TeamItemMax[RocketPack] = 1;
//================================================================
SoundData SoundTurSlayer
{
   wavFileName = "wpn_slayer.wav";
   profile = Profile3dMed;
};
//================================================================
SeekingMissileData Turretslayerproj
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = SlayerExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 3.0;
   damageType = $DepturRocketDamageType;
   explosionRadius = 10;
   kickBackStrength = 100;
   
   muzzleVelocity = 100.0;
   
   terminalVelocity = 100.0;
   acceleration = 5.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 3;
   
   trailType = 2; 
   trailString = "laserhit.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   soundId = SoundWhizSlayer;
}; 


//================================================================

ItemImageData RocketPackImage
{
        shapeFile = "deptur_rocket";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData RocketPack
{
        description = "Rocket Turret";
        shapeFile = "deptur_rocket";
        className = "Backpack";
   heading = "LTurrets";
        imageType = RocketPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function RocketPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function RocketPack::onDeploy(%player,%item,%pos)
{
        if (RocketPack::deployShape(%player,%item)) {
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

function RocketPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableRocket",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DeployableRocket",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("deptur_rocket","Turret",DeployableRocket,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Rocket Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
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
TurretData DeployableRocket
{
	className = "Turret";
	shapeFile = "deptur_rocket";
	projectileType = Turretslayerproj;
	maxDamage = 10;
	maxEnergy = 250;
	minGunEnergy = 5;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 3;
	speed = 1.5;
	speedModifier = 1.5;
	range = 250;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	pinger = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundTurSlayer;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Slayer Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableRocket::onAdd(%this)
{
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "DeployableRocket");
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
  	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
	GameBase::setDamageLevel(%this.cyl, 0.6);
}

// Override base class just in case.
function DeployableRocket::onPower(%this,%power,%generator) {}
function DeployableRocket::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

