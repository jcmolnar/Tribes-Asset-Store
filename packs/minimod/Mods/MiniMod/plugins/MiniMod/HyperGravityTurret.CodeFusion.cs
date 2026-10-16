MiniMod::MonitorFile(start, "HyperGravityTurret.CodeFusion.cs", "Hyper-Gravity Turret Plugin");

LightningData HGravCharge
{
   bitmapName       = "repairAdd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 150.0;
   coneAngle        = 40.0; //40
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.01;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.05;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function HGravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = -15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}

MiniMod::Turbo::Class(HGravTurretPack, 10);

$TeamItemMax[HGravTurretPack] = 4;

ItemImageData HGravTurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData HGravTurretPack
{
	description = "Hyper-Grav Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = HGravTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HGravTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function HGravTurretPack::onDeploy(%player,%item,%pos)
{
	if (HGravTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function HGravTurretPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",DeployableHGravTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Hyper-Grav Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Hyper-Grav Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "HGravTurretPack"]++;
                              Client::setOwnedObject(%client, %camera);
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

$InvList[HGravTurretPack] = 1;
$RemoteInvList[HGravTurretPack] = 1;

TurretData DeployableHGravTurret
{
	className = "Turret";
	shapeFile = "camera";
        projectileType = HGravCharge;
	maxDamage = 0.65;
        maxEnergy = 30;
        minGunEnergy = 5;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.0;
	speed = 4.0;
	speedModifier = 1.5;
        range = 50;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = SoundPickupAmmo;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Hyper-Grav Turret";
	damageSkinData = "objectDamageSkins";

   isSustained     = true;
   firingTimeMS    = 5000;
   energyRate      = 1.0;
};

function DeployableHGravTurret::onAdd(%this)
{
        schedule("DeployableHGravTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Hyper-Grav Turret");
	}
}

function DeployableHGravTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableHGravTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableHGravTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "HGravTurretPack"]--;
}

// Override base class just in case.
function DeployableHGravTurret::onPower(%this,%power,%generator) {}
function DeployableHGravTurret::onEnabled(%this) 
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}	


MiniMod::MonitorFile(stop, "HyperGravityTurret.CodeFusion.cs", "Hyper-Gravity Turret Plugin");
