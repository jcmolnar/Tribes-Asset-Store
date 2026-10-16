// Used to index beacons as they are loaded
// This counter will increment as each beacon core is loaded into memory,
// providing us a with a table of beacon cores that we can search through, if necessary.
$BeaconInitCounter = 0;	

StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 0.1;
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

