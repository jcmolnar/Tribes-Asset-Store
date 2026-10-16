//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[TurretPack] = 1;

$ItemMax[larmor, TurretPack] = 0;	//Seraph
$ItemMax[lfemale, TurretPack] = 0;	//Seraph
$ItemMax[earmor, TurretPack] = 1;	//Slave
$ItemMax[efemale, TurretPack] = 1;	//Slave
$ItemMax[marmor, TurretPack] = 0;	//Pawn
$ItemMax[aarmor, TurretPack] = 0;	//Navigator
$ItemMax[darmor, TurretPack] = 0;	//Atomizer
$ItemMax[barmor, TurretPack] = 0;	//Paladin

$TeamItemMax[TurretPack] = 20;

function deployTurretPack::Initialize()
{	$TeamItemCount[0 @ TurretPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

TurretData DeployableTurret 
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = IonBolt;
	maxDamage = 1.0;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] =
	{
		"deploy", SoundActivateMotionSensor
	};
	reloadDelay = 0.3;
	speed = 4.0;
	speedModifier = 1.5;
	range = 155;
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

ItemImageData TurretPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
}; 

ItemData TurretPack 
{ 
description = "Ion Turret"; 
shapeFile = "remoteturret"; 
className = "Backpack"; 
heading = "gDeployable Turrets"; 
imageType = TurretPackImage; 
shadowDetailMask = 4; 
mass = 2.0; 
elasticity = 0.2; 
price = 300; 
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

function TurretPack::deployShape(%player,%item)
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
 	                                              



				%turret = newObject("remoteTurret","Turret",DeployableTurret,true); 
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"RMT Ion Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
                              Client::setOwnedObject(%client, %turret);
                              Client::setOwnedObject(%client, %player);
					Client::sendMessage(%client,0,"Ion Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "TurretPack"]++;echo("MSG: ",%client," deployed an Ion Turret"); 
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else																						  
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}

