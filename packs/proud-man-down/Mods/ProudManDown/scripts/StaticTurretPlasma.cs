//--------------------------------------
RocketData AAShell
{	
	bulletShapeName = "tracer.dts";
	explosionTag = AAExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 3.15;
	damageType = $MissileDamageType;
	explosionRadius = 4;
	kickBackStrength = 0.0;
	muzzleVelocity = 300.0;
	terminalVelocity = 300.0;
	acceleration = 5.0;
	totalTime = 1.0;
	liveTime = 1.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundWindGust;
};

//--------------------------------------

TurretData PlasmaTurret
{
	className = "Turret";
	shapeFile = "hellfiregun";
        projectileType = AAShell;
	maxDamage = 3.5;
        maxEnergy = 0;
        minGunEnergy = 0;
        maxGunEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.4;
        range = 0;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = debrisSmallExplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = grenadeExp;
        description = "Anti-Aircraft Gun";
	damageSkinData = "objectDamageSkins";
};

function PlasmaTurret::onCollision (%this, %object)
{
	if (getObjectType (%object) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%client = Player::getClient(%object);
		if(Client::getControlObject(%client) == %object)
		{
			echo("Client " @ %client @ " taking control of turret #" @ %this);
			Client::sendMessage(%client,0,"Controlling Anti-Aircraft Gun. Press 'C' again to cease control.");
			Client::getOwnedObject(%client).CommandTag = 1;
			Client::takeControl(%client, %this);
			%this.Disabled = true;
			Client::getOwnedObject(%client).CommandTag = "";
		}
	}
}

function PlasmaTurret::Reenable(%this)
{
        %this.disabled = false;
}


//-------------------------------------