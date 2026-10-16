StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 1.1;
	maxEnergy = 200;

   	castLOS = true;
   	supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 
function Beacon::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function Beacon::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
}

function Beacon::onDestroyed(%this)
{
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

//TurretData DefaultBeacon //DeployableRocket
//{
//	className = "Beacon";
//	shapeFile = "sensor_small";
//	projectileType = EMPShock;
//	maxDamage = 0.65;
//	maxEnergy = 60;
//	minGunEnergy = 25;
//	maxGunEnergy = 25;
//	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//	reloadDelay = 3.5;
//	speed = 2.0;
//	speedModifier = 1.0;
//	range = 150;
//	visibleToSensor = true;
//	shadowDetailMask = 4;
//	dopplerVelocity = 0;
//	castLOS = true;
//	supression = false;
//	mapFilter = 2;
//	mapIcon = "M_turret";
//	debrisId = flashDebrisMedium;
//	shieldShapeName = "shield";
//	fireSound = SoundMissileTurretFire;
//	activationSound = SoundRemoteTurretOn;
//	deactivateSound = SoundRemoteTurretOff;
//	explosionId = flashExpMedium;
//	description = "HunterSeeker";
//	damageSkinData = "objectDamageSkins";
//};

//function Beacon::verifyTarget(%this,%target)
//{
//   //bottomprintall("Verifying Target",1);
//   //if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
//   %target = Player::GetClient(%target);
//   //if ($lbot==0)
//   //{
//   	lbot(%target,%this);
//   	//$lbot=1;
//   	Beacon::onDestroyed(%this);
//   	GameBase::setActive(%this,false);
//   	//Gamebase::applyDamage(%this,4,1,"0 0 0","0 0 0",0,%this);
//   //}
//   //return "True";
//   //else
//   deleteobject(%this);
//   return "False";
//}

//function DefaultBeacon::Onfire()
//{
//	bottomprintall("DefaultBeacon Firing at Target",1);
//}

//function Beacon::Onfire()
//{
//	bottomprintall("Beacon Firing at Target",1);
//}

//function Beacon::onAdd(%this)
//{
//	schedule("Beacon::deploy(" @ %this @ ");",1,%this);
//	GameBase::setRechargeRate(%this,5);
//	%this.shieldStrength = 0.0125;
//	if (GameBase::getMapName(%this) == "") {
//		GameBase::setMapName (%this, "HunterSeeker");
//	}
//}

function Beacon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function Beacon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

//function Beacon::onDestroyed(%this)
//{
//	Turret::onDestroyed(%this);
//  	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
//}

// Override base class just in case.

function Beacon::onPower(%this,%power,%generator) {}
//function Beacon::onEnabled(%this) 
//{
//	GameBase::setRechargeRate(%this,5);
//	GameBase::setActive(%this,true);
//}	