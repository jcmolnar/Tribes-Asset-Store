// This is a MiniMod Plugin.
// This plugin is the GuardDog (Spotter) Turret from the hvTactical mod.
// Ported by PeterT.
MiniMod::MonitorFile(start, "WatchdogTurret.CodeFusion.cs", "Watchdog Turret Plugin");
MiniMod::Turbo::Class(WatchdogPack, 9);


LaserData WatchdogLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.001; //0.010;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.8;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

$TeamItemMax[WatchdogPack] = 4;

ItemImageData WatchdogImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData WatchdogPack
{
	description = "Watchdog";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = WatchdogImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function WatchdogPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function WatchdogPack::onDeploy(%player,%item,%pos)
{
	if (WatchdogPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function WatchdogPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",DeployableWatchdog,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Watchdog#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Watchdog deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "WatchdogPack"]++;
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

$InvList[WatchdogPack] = 1;
$RemoteInvList[WatchdogPack] = 1;

TurretData DeployableWatchdog
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = WatchdogLaser;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;//4.0
	speedModifier = 1.5;//1.5
	range = 200;
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
	description = "Watchdog";
	damageSkinData = "objectDamageSkins";
};

function DeployableWatchdog::onAdd(%this)
{
	schedule("DeployableWatchdog::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Watchdog");
	}
}

function DeployableWatchdog::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableWatchdog::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableWatchdog::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "WatchdogPack"]--;
}

// Override base class just in case.
function DeployableWatchdog::onPower(%this,%power,%generator) {}
function DeployableWatchdog::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

MiniMod::MonitorFile(stop, "WatchdogTurret.CodeFusion.cs", "Watchdog Turret Plugin");
