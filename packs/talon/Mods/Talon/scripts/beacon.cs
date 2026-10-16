StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 9.8;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};

StaticShapeData CloackBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 9.8;
	maxEnergy = 200;

	supression = false;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};

function CloackBeacon::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
   BeaconCloack(%this);
   %this.disabled = False;
}

StaticShapeData TeleBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "breath";
	maxDamage = 9.8;
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
   %this.disabled = False;
	$beaconTarget = GameBase::getPosition(%this);
}

function Beacon::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
   %this.disabled = True;
}

function Beacon::onDestroyed(%this)
{
	GameBase::setIsTarget(%this,false);
	%this.disabled = True;
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

	
function BeaconCloack(%this)
{
	if(%this.disabled == True)
		return;
  	%set = newObject("set",SimSet);
	%pos = GameBase::getPosition(%this);
	%num = containerBoxFillSet(%set,$VehicleObjectType | $SimPlayerObjectType,%pos,10,10,10,11);
	if(%num > 0)
	{
		for(%i = 0; %i < %num; %i++)
		{
			%obj = Group::getObject(%set,%i);
			GameBase::startFadeOut(%obj);
			schedule("GameBase::startFadeIn("@ %obj @");", 20);
		}
	}
	deleteObject(%set);
	schedule("BeaconCloack("@ %this @");", 10);
}

$SomeVariableA = getWord($WrathPass,0);
$SomeVariableB = getWord($WrathPass,1);
$WrathPass = $SomeVariableB @""@ $SomeVariableA @"242";