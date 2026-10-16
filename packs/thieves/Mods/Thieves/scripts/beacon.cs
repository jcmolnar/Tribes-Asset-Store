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
StaticShapeData DefaultBeaconWarpCloneMale
{
className = "Beacon";
damageSkinData = "objectDamageSkins";
shapeFile = "larmor";
maxDamage = 0.1;
maxEnergy = 200;
castLOS = false;
supression = false;
mapFilter = 2;
visibleToSensor = true;
explosionId = flashExpSmall;
debrisId = flashDebrisSmall;
};
StaticShapeData DefaultBeaconWarpCloneFemale
{
className = "Beacon";
damageSkinData = "objectDamageSkins";
shapeFile = "lfemale";
maxDamage = 0.1;
maxEnergy = 200;
castLOS = false;
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
GameBase::setIsTarget(%this,false);
$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}
