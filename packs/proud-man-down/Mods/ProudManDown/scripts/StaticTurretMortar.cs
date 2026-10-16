//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = MortarShellExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 350;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "breath.dts";

soundId = SoundWindPast; // This makes the bullet hiss
			 // if it passes by your head.
			 // Adds to the realism of the
			 // bullet.  --Deadtaco
};

//--------------------------------------

TurretData MortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 2.0;
	fireSound = SoundFireGrenade;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = grenadeExp;
	description = "Mortar";
};

function MortarTurret::onCollision (%this, %object)
{
	if (getObjectType (%object) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%client = Player::getClient(%object);
		if(Client::getControlObject(%client) == %object)
		{
			echo("Client " @ %client @ " taking control of turret #" @ %this);
			Client::sendMessage(%client,0,"Controlling Mortar. Press 'C' again to cease control.");
			Client::getOwnedObject(%client).CommandTag = 1;
			Client::takeControl(%client, %this);
			%this.Disabled = true;
			Client::getOwnedObject(%client).CommandTag = "";
		}
	}
}

function MortarTurret::Reenable(%this)
{
        %this.disabled = false;
}


//--------------------------------------