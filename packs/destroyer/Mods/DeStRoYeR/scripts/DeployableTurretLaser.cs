$ItemMax[narmor, LaserPack] = 0;
$ItemMax[aarmor, LaserPack] = 0;
$ItemMax[darmor, LaserPack] = 0;
$ItemMax[warmor, LaserPack] = 0;
$ItemMax[barmor, LaserPack] = 1;
$ItemMax[avarmor, LaserPack] = 0;
$ItemMax[nfemale, LaserPack] = 0;
$ItemMax[afemale, LaserPack] = 0;
$ItemMax[sarmor, LaserPack] = 1;
$ItemMax[wfemale, LaserPack] = 0;
$ItemMax[bfemale, LaserPack] = 1;

$InvList[LaserPack] = 1;
$RemoteInvList[LaserPack] = 1;

$TeamItemMax[LaserPack] = 6;

ItemImageData LaserPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LaserPack
{
	description = "Laser Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "fDeployables";
	imageType = CameraPackImage;
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
					$TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}
	TurretData DeployableLaser
	{
		className = "Turret";
		shapeFile = "camera";
		projectileType = SniperLaser;
		maxDamage = 0.75;
		maxEnergy = 75;
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

