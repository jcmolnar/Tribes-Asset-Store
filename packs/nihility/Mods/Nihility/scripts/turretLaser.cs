//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[LaserPack] = 1;

$ItemMax[larmor, LaserPack] = 0;	//Seraph
$ItemMax[lfemale, LaserPack] = 0;	//Seraph
$ItemMax[earmor, LaserPack] = 1;	//Slave
$ItemMax[efemale, LaserPack] = 1;	//Slave
$ItemMax[marmor, LaserPack] = 0;	//Pawn
$ItemMax[aarmor, LaserPack] = 0;	//Navigator
$ItemMax[darmor, LaserPack] = 0;	//Atomizer
$ItemMax[barmor, LaserPack] = 0;	//Paladin

$TeamItemMax[LaserPack] = 20;

function deployLaserPack::Initialize()
{	$TeamItemCount[0 @ LaserPack] = 0;
	$TeamItemCount[1 @ LaserPack] = 0;
	$TeamItemCount[2 @ LaserPack] = 0;
	$TeamItemCount[3 @ LaserPack] = 0;
	$TeamItemCount[4 @ LaserPack] = 0;
	$TeamItemCount[5 @ LaserPack] = 0;
	$TeamItemCount[6 @ LaserPack] = 0;
	$TeamItemCount[7 @ LaserPack] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

TurretData DeployableLaser
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SniperLaser;
	maxDamage = 0.75;
	maxEnergy = 35;
	minGunEnergy = 10;
	maxGunEnergy = 60;
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
	if (GameBase::getMapName(%this) == "") {
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

// Override base class just in case.
function DeployableLaser::onPower(%this,%power,%generator) {}
function DeployableLaser::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


ItemImageData TargetPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData LaserPack
{
	description = "Laser Turret";
	shapeFile = "ammopack";
	className = "Backpack";
   heading = "gDeployable Turrets";
	imageType = TargetPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserPack::onDeploy(%player,%item,%pos)
{
	if (LaserPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function LaserPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",DeployableLaser,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                              Client::setOwnedObject(%client, %camera);
                              Client::setOwnedObject(%client, %player);
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;echo("MSG: ",%client," deployed a Laser Turret"); 
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else																						  
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}