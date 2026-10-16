$TeamItemMax[SurveyDronePack] = 8;
$InvList[SurveyDronePack] = 1;

function SurveyDronePack::Initialize()
{
  $TeamItemCount[0 @ SurveyDronePack] = 0;
  $TeamItemCount[1 @ SurveyDronePack] = 0;
  $TeamItemCount[2 @ SurveyDronePack] = 0;
  $TeamItemCount[3 @ SurveyDronePack] = 0;
  $TeamItemCount[4 @ SurveyDronePack] = 0;
  $TeamItemCount[5 @ SurveyDronePack] = 0;
  $TeamItemCount[6 @ SurveyDronePack] = 0;
  $TeamItemCount[7 @ SurveyDronePack] = 0;
}


function DeployDrone(%player,%item,%shape,%data,%name)
{
 %client = Player::getClient(%player);
 if(GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %obj = newObject(%name,%data,%shape,true);
   if($TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"] >= $TeamItemMax[%item])
    {
		centerprint(%client,"<jc>Maximum number of "@%name@"s deployed.");
		deleteObject(%obj);
		return;
	}
   addToSet("MissionCleanup",%obj);
   GameBase::setTeam(%obj,GameBase::getTeam(%player));
   GameBase::setPosition(%obj,$los::position);
   GameBase::setRotation(%obj,%rot);
   Gamebase::setMapName(%obj,%name);
   Client::sendMessage(%client,0,%name@" Deployed ");
   GameBase::startFadeIn(%obj);
   playSound(SoundPickupBackpack,$los::position);
   Client::setControlObject(%client,%obj);
   %player.vehicle = %obj;
   $TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"]++;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 return false;
}

//********************************
ItemImageData SurveyDronePackImage
{
	shapeFile = "jetpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 8;
 	maxEnergy = 9;
	firstPerson = false;
};

ItemData SurveyDronePack
{
	description = "SERV BOT";
	shapeFile = "jetpack";
	className = "Backpack";
    heading = $InvHead[ihGui];
	shadowDetailMask = 4;
	imageType = SurveyDronePackImage;
	mass = 0.5;
	price = 2000;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SurveyDronePack::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function SurveyDronePack::onDeploy(%player,%item,%pos)
{
 if(DeployDrone(%player,%item,SurveyDrone,flier,SurveyDrone)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}



//*******************
FlierData SurveyDrone
{
//	explosionId = flashExpSmall;
//	debrisId = flashDebrisSmall;
	className = "Vehicle";
    shapeFile = "camera";
    shieldShapeName = "shield_medium";
    mass = 0.1;
    drag = 1.0;
    density = 1.2;
    maxBank = 0.3;
    maxPitch = 1.15;
    maxSpeed = 60;
    minSpeed = -20;
	lift = 1.0;
	maxAlt = 50;
	maxVertical = 50;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 1.0;

	groundDamageScale = 0.001;

	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.0001;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundDiscSpin;

	visibleDriver = false;
	driverPose = 22;
	description = "Survey Drone";
};

function SurveyDrone::onCollision(%this,%object)
{
}

function SurveyDrone::jump(%this,%mom)
{
	GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function SurveyDrone::onFire(%this,%slot)
{
 %client = GameBase::getControlClient(%this);
 if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
  {
	if(GameBase::getLOSInfo(%this,3))
	 {
		%obj = getObjectType($los::object);
		if(%obj == "SimTerrain" || %obj == "InteriorShape")
		 {
		    %this.deployed = true;
			%prot = GameBase::getRotation(%this);
			%zRot = getWord(%prot,2);
			if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
			else
			{
				if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
				else %rot = Vector::getRotation($los::normal);
			}
			%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
            addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%this));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,$los::position);
			Gamebase::setMapName(%beacon,"Target Beacon");
		    Beacon::onEnabled(%beacon);
			Client::sendMessage(%client,0,"Beacon deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
			echo("MSG: Survey Drone deployed a Beacon");
			SurveyDrone::removeDrone(%this);
		}
	 }
  }
}

function SurveyDrone::removeDrone(%this)
{
 %client = GameBase::getControlClient(%this);
 %player = Client::getOwnedObject(%client);

  Player::setMountObject(%player, -1, 0);
  Client::setControlObject(%client,%player);
  %player.vehicle = "";

  Client::sendMessage(%client,0,"Drone beacon deployed successfully");
 
  $TeamItemCount[GameBase::getTeam(%this) @ "SurveyDronePack"]--;
  GameBase::startFadeOut(%this);
  GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

$DamageScale[SurveyDrone, $ImpactDamageType] = 1.0;
$DamageScale[SurveyDrone, $BulletDamageType] = 2.0;
$DamageScale[SurveyDrone, $PlasmaDamageType] = 2.0;
$DamageScale[SurveyDrone, $EnergyDamageType] = 2.0;
$DamageScale[SurveyDrone, $ExplosionDamageType] = 2.0;
$DamageScale[SurveyDrone, $ShrapnelDamageType] = 2.0;
$DamageScale[SurveyDrone, $DebrisDamageType] = 2.0;
$DamageScale[SurveyDrone, $MissileDamageType] = 2.0;
$DamageScale[SurveyDrone, $LaserDamageType] = 2.0;
$DamageScale[SurveyDrone, $MortarDamageType] = 2.0;
$DamageScale[SurveyDrone, $BlasterDamageType] = 2.0;
$DamageScale[SurveyDrone, $ElectricityDamageType] = 2.0;
$DamageScale[SurveyDrone, $MineDamageType]        = 2.0;
$DamageScale[SurveyDrone, $DrainDamageType]        = 2.0;
