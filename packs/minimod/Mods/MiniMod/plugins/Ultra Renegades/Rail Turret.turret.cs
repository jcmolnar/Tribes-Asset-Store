// This is a MiniMod plugin
// This is the Rail Turret From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.

TurretData DeployableRail
{
className = "Turret";
shapeFile = "hellfiregun";
projectileType = railLaser;
maxDamage = 4.0;
maxEnergy = 155;
minGunEnergy = 100;
maxGunEnergy = 150;
sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
reloadDelay = 5.0;
speed = 4.0;
speedModifier = 1.5;
range = 125;
visibleToSensor = true;
shadowDetailMask = 4;
dopplerVelocity = 0;
castLOS = true;
supression = false;
mapFilter = 2;
mapIcon = "M_turret";
debrisId = flashDebrisMedium;
shieldShapeName = "shield";
fireSound = SoundMissileTurretFire;
activationSound = SoundPlasmaTurretOn;
deactivateSound = SoundPlasmaTurretOff;
whirSound = SoundPlasmaTurretTurn;
explosionId = flashExpMedium;
description = "Rail Turret";
damageSkinData = "objectDamageSkins";
};

function DeployableRail::onAdd(%this)
{
schedule("DeployableRail::deploy(" @ %this @ ");",1,%this);
GameBase::setRechargeRate(%this,20);
%this.shieldStrength = 0.01;
if (GameBase::getMapName(%this) == "")
	{
	GameBase::setMapName (%this, "Rail Turret");
	}
}

function DeployableRail::deploy(%this)
{
GameBase::playSequence(%this,1,"deploy");
}

function DeployableRail::onEndSequence(%this,%thread)
{
GameBase::setActive(%this,true);
}

function DeployableRail::onDestroyed(%this)
{
StaticShape::objectiveDestroyed(%this);
%this.shieldStrength = 0;
GameBase::setRechargeRate(%this,0);
Turret::onDeactivate(%this);
Turret::objectiveDestroyed(%this);
CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
$TeamItemCount[GameBase::getTeam(%this) @ "RailTurret"]--;
}

function DeployableRail::onPower(%this,%power,%generator)
{
}

function DeployableRail::onEnabled(%this)
{
GameBase::setRechargeRate(%this,5);
GameBase::setActive(%this,true);
} 
