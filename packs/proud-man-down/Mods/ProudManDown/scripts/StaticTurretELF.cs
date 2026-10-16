//--------------------------------------

GrenadeData TurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = 	CannonShellExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 650.0;
   maxLevelFlightDist = 5000;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";

soundId = SoundWindPast; // This makes the bullet hiss
			 // if it passes by your head.
			 // Adds to the realism of the
			 // bullet.  --Deadtaco
};

//--------------------------------------

TurretData ELFTurret
{
maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 2.0;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = TurretShell;
	explosionId = grenadeExp;
	description = "Turret";

	fireSound        = bigExplosion3;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

};

function ELFTurret::onCollision (%this, %object)
{
	if (getObjectType (%object) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%client = Player::getClient(%object);
		if(Client::getControlObject(%client) == %object)
		{
			echo("Client " @ %client @ " taking control of turret #" @ %this);
			Client::sendMessage(%client,0,"Controlling Turret. Press 'C' again to cease control.");
			Client::getOwnedObject(%client).CommandTag = 1;
			Client::takeControl(%client, %this);
			%this.Disabled = true;
			Client::getOwnedObject(%client).CommandTag = "";
		}
	}
}

function ELFTurret::Reenable(%this)
{
        %this.disabled = false;
}

function ELFTurretImage::onFire(%player, %slot) 
{		
                GameBase::playSound(%player,bigExplosion2,0);
}
//-------------------------------------