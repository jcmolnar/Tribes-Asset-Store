//----Taken From Mini mod--

$TeamItemMax[AGravPack] = 3;
$InvList[AGravPack] = 1;
$RemoteInvList[AGravPack] = 1;

$CanAlwaysTeamDestroy[DeployAntiGravityTurret] = 1;

function deployAntiGravityTurret::Initialize()
{
  $TeamItemCount[0 @ AGravPack] = 0;
  $TeamItemCount[1 @ AGravPack] = 0;
  $TeamItemCount[2 @ AGravPack] = 0;
  $TeamItemCount[3 @ AGravPack] = 0;
  $TeamItemCount[4 @ AGravPack] = 0;
  $TeamItemCount[5 @ AGravPack] = 0;
  $TeamItemCount[6 @ AGravPack] = 0;
  $TeamItemCount[7 @ AGravPack] = 0;
}

LightningData snareCharge
{
   bitmapName       = "lightningNew.bmp";

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

function snareCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = 15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}

ItemImageData AGravImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData AGravPack
{
	description = "Anti-Grav Turret";
	shapeFile = "camera";
	className = "Backpack";
      heading = $InvHead[ihDWe];
	imageType = AGravImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AGravPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AGravPack::onDeploy(%player,%item,%pos)
{
	if (AGravPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AGravPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",DeployableSnare,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Anti-Grav Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Anti-Grav Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "AGravPack"]++;
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


TurretData DeployableSnare
{
	className = "Turret";
	shapeFile = "camera";
        projectileType = snareCharge;
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
        description = "Anti-Grav Turret";
	damageSkinData = "objectDamageSkins";

   isSustained     = true;
   firingTimeMS    = 5000;
   energyRate      = 1.0;
};

function DeployableSnare::onAdd(%this)
{
        schedule("DeployableSnare::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Anti-Grav Turret");
	}
}

function DeployableSnare::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSnare::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableSnare::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AGravPack"]--;
}

// Override base class just in case.
function DeployableSnare::onPower(%this,%power,%generator) {}
function DeployableSnare::onEnabled(%this) 
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}	