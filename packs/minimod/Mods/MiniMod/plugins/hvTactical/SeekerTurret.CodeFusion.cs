// This is a MiniMod Plugin.
// This plugin is based on the Watchdog (Spotter) Turret from
// the hvTactical mod. It was initially ported by PeterT and
// then adapted by Epsilon into something quite different.

MiniMod::MonitorFile(start, "SeekerTurret.CodeFusion.cs", "Seeker Turret Plugin");
MiniMod::Turbo::Class(SeekerPack, 24);
MiniMod::Turbo::Class(SeekerPack, 29);

LaserData SeekerLaser
{
   bulletShapeName    = "mortar.dts"; 
   hitName           = "laserhit.dts";

   damageConversion  = 0.22; //0.02;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.6;//0.70;

   lightRange        = 5.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

$TeamItemMax[SeekerPack] = 1;

ItemImageData SeekerImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SeekerPack
{
	description = "Seeker";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = SeekerImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SeekerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SeekerPack::onDeploy(%player,%item,%pos)
{
	if (SeekerPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function SeekerPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				// Try to stick it straight up or down, otherwise
				// just use the surface normal
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
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",DeployableSeeker,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Seeker#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Seeker deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "SeekerPack"]++;
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
$InvList[SeekerPack] = 1;
$RemoteInvList[SeekerPack] = 0;

TurretData DeployableSeeker
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = SeekerLaser;
	maxDamage = 2.50;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 0.5;//0.5
	speedModifier = 1.0;//1.0
	range = 300;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;//0;
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
	description = "Seeker";
	damageSkinData = "objectDamageSkins";
};

function DeployableSeeker::onAdd(%this)
{
	schedule("DeployableSeeker::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Seeker");
	}
}

function DeployableSeeker::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSeeker::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableSeeker::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SeekerPack"]--;
}

// Override base class just in case.
function DeployableSeeker::onPower(%this,%power,%generator) {}
function DeployableSeeker::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


MiniMod::MonitorFile(stop, "SeekerTurret.CodeFusion.cs", "Seeker Turret Plugin");
