StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "force";
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
//   echo("Beacon  onEnabled");
   GameBase::setIsTarget(%this,true);
}

function Beacon::onDisabled(%this)
{
//   echo("Beacon  onDisabled");
   GameBase::setIsTarget(%this,false);
}

function Beacon::onDestroyed(%this)
{
//   echo("Beacon  onDestroyed");
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}
