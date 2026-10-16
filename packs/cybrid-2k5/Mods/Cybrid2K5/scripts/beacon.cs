// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

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
   echo("Beacon  onDestroyed");
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}
