//--------------------------------------

BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = ARBullet;
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 0.3;
	maxGunEnergy = 1.0;
	reloadDelay = 0;
	speed = 4.0;
	speedModifier = 0.7;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrisSmallExplosion;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = grenadeExp;
	description = "Indoor Turret";

};

function IndoorTurret::onCollision (%this, %object)
{
	if (getObjectType (%object) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%client = Player::getClient(%object);
		if(Client::getControlObject(%client) == %object)
		{
			echo("Client " @ %client @ " taking control of turret #" @ %this);
			Client::sendMessage(%client,0,"Controlling MachineGun. Press 'C' again to cease control.");
			Client::getOwnedObject(%client).CommandTag = 1;
			Client::takeControl(%client, %this);
			%this.Disabled = true;
			Client::getOwnedObject(%client).CommandTag = "";
		}
	}
}

function IndoorTurret::Reenable(%this)
{
        %this.disabled = false;
}
//--------------------------------------