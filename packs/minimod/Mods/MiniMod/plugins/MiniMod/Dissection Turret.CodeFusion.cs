// This is a MiniMod Plugin.
// This plugin is the Dissection Turret from the MiniMod.
// Note: Code is based off of PeterT's Watchdog Turret plugin.
// Ported by Dewy.

MiniMod::MonitorFile(start, "Dissection Turret.CodeFusion.cs", "Dissection Turret Plugin");

LaserData DissectionLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.151;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.25;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

$TeamItemMax[DissectionPack] = 1;

ItemImageData DissectionImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DissectionPack
{
	description = "Dissection Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = DissectionImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DissectionPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DissectionPack::onDeploy(%player,%item,%pos)
{
	if (DissectionPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DissectionPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
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
					%camera = newObject("Camera","Turret",DeployableDissection,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Dissection#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Dissection Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "DissectionPack"]++;
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


MiniMod::Turbo::Class(DissectionPack, 10);

$InvList[DissectionPack] = 1; //Dissection Turret
$RemoteInvList[DissectionPack] = 0; //Dissection Turret

TurretData DeployableDissection
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = DissectionLaser;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;//4.0
	speedModifier = 1.5;//1.5
	range = 150;
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
	description = "Dissection Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableDissection::onAdd(%this)
{
	schedule("DeployableDissection::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Watchdog");
	}
}

function DeployableDissection::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDissection::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDissection::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DissectionPack"]--;
}

// Override base class just in case.
function DeployableDissection::onPower(%this,%power,%generator) {}
function DeployableDissection::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


MiniMod::MonitorFile(stop, "Dissection Turret.CodeFusion.cs", "Dissection Turret Plugin");
