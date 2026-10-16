// This is a MiniMod Plugin.
// This plugin is the Death of Bots.
// Note: Code is based off of PeterT's Watchdog Turret plugin.
// Ported by Dewy then modified further by PeterT.

MiniMod::MonitorFile(start, "Death of Bots.CodeFusion.cs", "''Death of Bots'' Turret Plugin");

LaserData DoBLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.151;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.25;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

$TeamItemMax[DoBPack] = 1;

ItemImageData DoBImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DoBPack
{
	description = "Death of Bots";
	shapeFile = "indoorgun";
	className = "Backpack";
   heading = "dDeployables";
	imageType = DoBImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DoBPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DoBPack::onDeploy(%player,%item,%pos)
{
	if (DoBPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DoBPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",DeployableDoB,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Death of Bots#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Death of Bots deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "DoBPack"]++;
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

MiniMod::Turbo::Class(DoBPack, 12);

$InvList[DoBPack] = 1;
$RemoteInvList[DoBPack] = 0;

TurretData DeployableDoB
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = DoBLaser;
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
	description = "Death of Bots";
	damageSkinData = "objectDamageSkins";
};

function DeployableDoB::onAdd(%this)
{
	schedule("DeployableDissection::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "DoB");
	}
}

function DeployableDoB::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDoB::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDoB::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DoBPack"]--;
}

// Override base class just in case.
function DeployableDoB::onPower(%this,%power,%generator) {}
function DeployableDoB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

MiniMod::MonitorFile(stop, "Death of Bots.CodeFusion.cs", "''Death of Bots'' Turret Plugin");


