$ItemMax[narmor, ChaingunTurretPack] = 0;
$ItemMax[nfemale, ChaingunTurretPack] = 0;
$ItemMax[aarmor, ChaingunTurretPack] = 0;
$ItemMax[afemale, ChaingunTurretPack] = 0;
$ItemMax[darmor, ChaingunTurretPack] = 0;
$ItemMax[sarmor, ChaingunTurretPack] = 1;
$ItemMax[warmor, ChaingunTurretPack] = 0;
$ItemMax[wfemale, ChaingunTurretPack] = 0;
$ItemMax[barmor, ChaingunTurretPack] = 1;
$ItemMax[bfemale, ChaingunTurretPack] = 1;
$ItemMax[avarmor, ChaingunTurretPack] = 0;

$InvList[ChaingunTurretPack] = 1;
$RemoteInvList[ChaingunTurretPack] = 1;

BulletData ChaingunTurretBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

$TeamItemMax[ChaingunTurretPack] = 3;

ItemImageData ChaingunTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ChaingunTurretPack
{
        description = "Chaingun Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "fDeployables";
        imageType = ChaingunTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
        price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ChaingunTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ChaingunTurretPack::onDeploy(%player,%item,%pos)
{
        if (ChaingunTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function ChaingunTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
			%obj = getObjectType($los::object);
	    			%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}

                              %turret = newObject("remoteTurret","Turret",DeployableChaingun,true);
                              addToSet("MissionCleanup", %turret);
		  GameBase::setTeam(%turret,GameBase::getTeam(%player));
		  GameBase::setPosition(%turret,$los::position);
		  GameBase::setRotation(%turret,%rot);
                              Gamebase::setMapName(%turret,"RMT Chaingun#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                              Client::sendMessage(%client,0,"Remote Chaingun Turret deployed");
		  playSound(SoundPickupBackpack,$los::position);
                              $TeamItemCount[GameBase::getTeam(%player) @ "ChaingunTurretPack"]++;
                              echo("MSG: ",%client," deployed a Remote Chaingun Turret");
					//	Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret);
					Client::setOwnedObject(%client, %player);
					return true;
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
TurretData DeployableChaingun
{
	className = "Turret";
	shapeFile = "remoteturret";
        projectileType = ChaingunTurretBullet;
	maxDamage = 0.65;
        maxEnergy = 30;
        minGunEnergy = 5;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.2;
	speed = 4.0;
	speedModifier = 1.5;
        range = 25;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = SoundPickupAmmo;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Remote Chaingun";
	damageSkinData = "objectDamageSkins";
};

function DeployableChaingun::onAdd(%this)
{
        schedule("DeployableChaingun::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Remote Chaingun");
	}
}

function DeployableChaingun::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableChaingun::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableChaingun::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "ChaingunTurretPack"]--;
}

// Override base class just in case.
function DeployableChaingun::onPower(%this,%power,%generator) {}
function DeployableChaingun::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}

