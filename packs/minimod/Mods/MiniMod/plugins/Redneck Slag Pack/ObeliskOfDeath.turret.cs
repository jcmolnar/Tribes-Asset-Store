// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Death" (Anti-matter Turret) from
// the Redneck Slag Pack mod. Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    ObeliskOfDeath.ArmorData.cs
//    ObeliskOfDeath.baseProjData.cs
//    ObeliskOfDeath.item.cs
//    ObeliskOfDeath.reinitData.cs
//    Obelisk Of Light.staticshape.cs
//    ObeliskOfDeath.station.cs
//    ObeliskOfDeath.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableAntiMatterTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = AntiMatterShot;
	maxDamage = 4.0;
	maxEnergy = 100;
	minGunEnergy = 0;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10;
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
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	explosionId = flashExpMedium;
	description = "Anti Matter Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableAntiMatterTurret::onAdd(%this)
{
	schedule("DeployableAntiMatterTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Chain Turret");
	}
}

function DeployableAntiMatterTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableAntiMatterTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableAntiMatterTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AntiMatterTurretPack"]--;
	$RSP::AntiMatterTurretID[$RSP::AntiMatterPoleID[%this]] = 0;
}
// Override base class just in case.
function DeployableAntiMatterTurret::onPower(%this,%power,%generator) {}

function DeployableAntiMatterTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}

