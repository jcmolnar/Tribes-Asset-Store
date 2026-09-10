//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	reloadDelay = 0.8;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 100;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "bullet";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "SAM Launcher";
};

function Plasmaturret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}


function PlasmaTurret::onDestroyed(%this)
{

// ----------------

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);

	 for(%i = 1; %i < 15; %i++)
	 {
	
	%rndx = (getRandom() * 4) - 4;
	%rndy = (getRandom() * 4) - 4;
	%rndz =(getRandom() * 15) - 5;
	Projectile::spawnProjectile("TurretPart",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);

	 }
		%client = GameBase::getControlClient(%this);
		Turret::onDestroyed(%this);
		GameBase::applyDamage(%client,$flamedamagetype,1000.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);

		



// ----------------


}
																						 
TurretData ELFTurret	   
{			 
	className = "Turret";
	shapeFile = "chainturret";
        projectileType = ELFTurretBullet;
	maxDamage = 1.0;
        maxEnergy = 150;
        minGunEnergy = 50;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
        range = 60;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";

        fireSound = SoundDturretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Guardian IV";
	shadowDetailMask = 8;
	damageSkinData = "objectDamageSkins";
};

TurretData RocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 150;
	gunRange = 300;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "bullet";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
//	reloadDelay = 3.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
//	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power)
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,14);
	}
	else
	{
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function RocketTurret::onDestroyed(%this)
{

// ----------------

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);

	 for(%i = 1; %i < 15; %i++)
	 {
	
	%rndx = (getRandom() * 4) - 4;
	%rndy = (getRandom() * 4) - 4;
	%rndz =(getRandom() * 15) - 5;
	Projectile::spawnProjectile("TurretPart",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);

	 }
// ----------------


}

//--------------------------------------------

TurretData MortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 1.5;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
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
	speed = 4.0;
	speedModifier = 1.5;
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Mortar Turret";
};
																						 
//--------------------------------------------

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 1.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 25;
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
	fireSound = turretExplosion;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Motion Turret";

};


//--------------------------------------------


TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 1.0;
	maxEnergy = 10;
	shieldShapeName = "shield";
	speed = 20;
	speedModifier = 1.0;
	range = 300;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Camera";
};

function CameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Camera");
	}
}

function CameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function CameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function CameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
}	

//---------------------------------------------------

// Defense Turret - A modification of a modified mod - Deadtaco


TurretData DeployableChaingun
{
	className = "Turret";
	shapeFile = "remoteturret";
        projectileType = ChaingunTurretBullet;
	maxDamage = 0.65;
        maxEnergy = 30;
        minGunEnergy = 10;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.081;
	speed = 4.0;
	speedModifier = 1.5;
        range = 60;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = SoundDturretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Defense Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableChaingun::onAdd(%this)
{
        schedule("DeployableChaingun::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "")
	{
                GameBase::setMapName (%this, "Defense Turret");
	}
}

function DeployableChaingun::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableChaingun::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableChaingun::onCollision (%this, %object)
{
	return;
	if (getObjectType (%object) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%client = Player::getClient(%object);
		if(Client::getControlObject(%client) == %object)
		{
			echo("Client " @ %client @ " taking control of turret #" @ %this);
			Client::sendMessage(%client,0,"Controlling Turret. Press 'C' and move backwards, then C again to cease control.");
			Client::getOwnedObject(%client).CommandTag = 1;
			Client::takeControl(%client, %this);
			%this.Disabled = true;
			Client::getOwnedObject(%client).CommandTag = "";
		}
	}
}

function DeployableChaingun::Reenable(%this)
{
        %this.disabled = false;
}

function DeployableChaingun::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "ChaingunTurretPack"]--;

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);

	 for(%i = 1; %i < 8; %i++)
	 {
	
	%rndx = (getRandom() * 3) - 3;
	%rndy = (getRandom() * 3) - 3;
	%rndz =(getRandom() * 10) - 5;
	Projectile::spawnProjectile("TurretPart",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);

	 }



}

// Override base class just in case.
function DeployableChaingun::onPower(%this,%power,%generator)
{
}

function DeployableChaingun::onEnabled(%this) 
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}	
//---------------------------------------------------

// -- Belly Gun Turret - Attaches to flying vehicles

TurretData BellyGunTurret
{
	className = "Turret";
	shapeFile = "camera";
        projectileType = BellygunBullet;
	maxDamage = 0.35;
        maxEnergy = 30;
        minGunEnergy = 5;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
        range = 80;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = SoundDturretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Belly Gun";
	damageSkinData = "objectDamageSkins";
};

function BellyGunTurret::onAdd(%this)
{
        schedule("BellyGunTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "")
	{
                GameBase::setMapName (%this, "Belly Gun");
	}
}

function BellyGunTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function BellyGunTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function BellyGunTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "ChaingunTurretPack"]--;

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);



}

// Override base class just in case.
function DeployableChaingun::onPower(%this,%power,%generator)
{
}

function DeployableChaingun::onEnabled(%this) 
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}	
//---------------------------------------------------









// Seeker Turret - based upon hvTactical's Watchdog but modified by Epsilon

TurretData DeployableSeeker
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = ClaymoreProj;
	maxDamage = 0.10;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.03;
	speed = 10.1;//0.5
	speedModifier = 1.0;//1.0
	range = 10;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;//0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	// fireSound = debrisMediumExplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Claymore";
	damageSkinData = "objectDamageSkins";
};

function DeployableSeeker::onAdd(%this)
{
	schedule("DeployableSeeker::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,50);
	%this.shieldStrength = 0.0;//0.0
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Claymore");
	}
}

function DeployableSeeker::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSeeker::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableSeeker::onDestroyed(%this)
{

// ----------------

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("ClaymoreProj",%trans,%this,0);
		 Projectile::spawnProjectile("ClaymoreProj",%trans,%this,0);
		 Projectile::spawnProjectile("ClaymoreProj",%trans,%this,0);
		 Projectile::spawnProjectile("ClaymoreProj",%trans,%this,0);
// ----------------




	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SeekerPack"]--;
}

// Override base class just in case.
function DeployableSeeker::onPower(%this,%power,%generator)
{
}

function DeployableSeeker::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//---------------------------------------------------

// Flak Turret - nasty deadtaco weaponry

TurretData DeployableFlak
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FlakShell;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 50;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
	speedModifier = 1.5;
	range = 300;
	visibleToSensor = true;
	shadowDetailMask = 8;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	targetableFovRatio = 0.5;

	explosionId = flashExpMedium;
	description = "AA Cannon";
	damageSkinData = "objectDamageSkins";
};

function DeployableFlak::onAdd(%this)
{
	schedule("DeployableFlak::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Anti Aircraft Gun");
	}
}

function DeployableFlak::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFlak::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFlak::onDestroyed(%this)
{

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);

	 for(%i = 1; %i < 15; %i++)
	 {
	
	%rndx = (getRandom() * 4) - 4;
	%rndy = (getRandom() * 4) - 4;
	%rndz =(getRandom() * 15) - 5;
	Projectile::spawnProjectile("TurretPart",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);

	 }


	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlakPack"]--;
}

// Override base class just in case.
function DeployableFlak::onPower(%this,%power,%generator)
{
}

function DeployableFlak::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//below, makes Flak Turret track air targets only, now turned on
function DeployableFlak::verifyTarget(%this,%target)
{
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
		return "True";
	else
		return "False";
}

//---------------------------------------------------


// Satchel Charge - ripped from Shifter

TurretData DeployableSatchel
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SatchelShell;
	maxDamage = 0.4;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10.0;
	speed = 4.0;
	speedModifier = 1.5;
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
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = rocketExp;
	description = "Satchel Charge";
	damageSkinData = "objectDamageSkins";
};

function DeployableSatchel::onAdd(%this)
{
	schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "Satchel Charge");
	}
}

function DeployableSatchel::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSatchel::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableSatchel::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	//calcRadiusDamage(%this, $SatchelDamageType, 20.0, 1.5, 25, 9, 3, 0.40,0.1, 200, 100); 
	CalcRadiusDamage(%this,$SatchelDamageType,30,0.2,25,20,20,1.5,0.5,200,100);

  	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--;
}

// Override base class just in case.
function DeployableSatchel::onPower(%this,%power,%generator)
{
}

function DeployableSatchel::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//---------------------------------------------------


//

TurretData UtilityDevice
{
	className = "Turret";
	shapeFile = "sensor_small";
	maxDamage = 0.2;
	maxEnergy = 200;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supression = false;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisSmall;
	shieldShapeName = "shield";
	explosionId = flashExpSmall;
	description = "Utility Device";
	damageSkinData = "objectDamageSkins";
};

function UtilityDevice::onAdd(%this)
{
	schedule("UtilityDevice::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Utility Device");
	}
}

function UtilityDevice::deploy(%this)
{
	GameBase::setActive(%this,true);
}

function UtilityDevice::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function UtilityDevice::onDisabled(%this) 
{
	GameBase::setActive(%this,false);
}	

function UtilityDevice::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($UtilityDeviceConfig[%this] < 4 || $UtilityDeviceConfig[%this] == 8)
		%value *= 10;
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function UtilityDevice::onCollision(%this, %object)
{
	%TargetTeam = GameBase::getTeam(%object);
	%thisTeam = GameBase::getTeam(%this);
	if(%targetTeam == %thisTeam)
	{
		%stranger = Player::getClient(%object);
		%armor = Player::getArmor(%stranger);
		if(%armor == "earmor" || %armor == "efemale")
		{
			GameBase::setActive(%this,false);

			if($UtilityDeviceConfig[%this] == 5)
			{
			 
			}

			if($UtilityDeviceConfig[%this] == 8)
			{
				if (Player::getmounteditem(%object, $BackPackSlot) == "-1")
				{
					%item = "UtilityPack";
					$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
					Player::setItemcount (%stranger, %item, 1);
					Player::mountItem(%stranger,%item,$BackpackSlot);
					Item::playPickupSound(%this);
					deleteObject(%this);
					Client::sendMessage(%stranger,3,"Utility Device picked up.");
					return 1;
				}
				else
					$UtilityDeviceConfig[%this] = 1; 
			}
			else
				$UtilityDeviceConfig[%this]++;
				schedule("playSound(SoundBeaconUse,GameBase::getPosition(" @ %this @ "));",0.1);
			if($UtilityDeviceConfig[%this] == 1)
				  Client::sendMessage(%stranger,3,"Set to PowerDrain Mode");
			else if($UtilityDeviceConfig[%this] == 3)
				{  
				$UtilityDeviceConfig[%this] = 4;	  
				Client::sendMessage(%stranger,3,"Set to Powerdrain Mode");
				}
			else if($UtilityDeviceConfig[%this] == 2)
				  Client::sendMessage(%stranger,3,"Set to hack Mode (makes enemy stuff yours)");
			else if($UtilityDeviceConfig[%this] == 4)
				  Client::sendMessage(%stranger,3,"Set to Repair Mode");
			else if($UtilityDeviceConfig[%this] == 5)
				{  
				$UtilityDeviceConfig[%this] = 1;	  
				Client::sendMessage(%stranger,3,"Set to Repair Mode");
				}
			else if($UtilityDeviceConfig[%this] == 6)
				  Client::sendMessage(%stranger,3,"Set to Slow Mode (slows badguys)");
			else if($UtilityDeviceConfig[%this] == 7)
				  Client::sendMessage(%stranger,3,"Set to Gravity Mode (slows badguys)");
			else if($UtilityDeviceConfig[%this] == 8)
				  Client::sendMessage(%stranger,3,"Set to Bug Mode (listen in on the enemy)");
			GameBase::setActive(%this,true);
		}
		else
			Client::sendMessage(%stranger,3,"Only Engineers can configure the Utility Device~wC_BuySell.wav");
	}
}

//Deadtaco's 'suckme' function to raise and lower a player by any value (fake gravity)

function SuckMe(%player, %vel)
{

%myVelocity = Item::getVelocity(%player);
%Xvel = GetWord(%myVelocity, 0) * 0.95;
%yvel = GetWord(%myVelocity, 1) * 0.95;
%zvel = GetWord(%myVelocity, 2) * 0.95;
Item::setVelocity(%player, %xvel @ " " @ %yvel @ " " @ %zvel);

}

function SLowMe(%player, %vel)
{

%myVelocity = Item::getVelocity(%player);
%Xvel = GetWord(%myVelocity, 0) * 0.90;
%yvel = GetWord(%myVelocity, 1) * 0.90;
%zvel = GetWord(%myVelocity, 2);

%zvel = %zvel + %vel;
Item::setVelocity(%player, %xvel @ " " @ %yvel @ " " @ %zvel);

}

//Deadtaco's radiation sound maker
function radiateMe(%obj)
{
	 for(%i = 1; %i < 9; %i++)
	 {
	
	%rnd = getRandom() * 0.4;
	schedule("playSound(SoundRadiate,GameBase::getPosition(" @ %obj @ "));",%rnd);

	 }

}


function UtilityDevice::onDeactivate(%this)
{
	Turret::onDisabled(%this);
	UtilityDevice::removeSet(%this);
}

function UtilityDevice::onDestroyed(%this)
{
  	$TeamItemCount[GameBase::getTeam(%this) @ "UtilityPack"]--;
	if(%this.set)
		UtilityDevice::removeSet(%this);
	StaticShape::objectiveDestroyed(%this);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
}

function UtilityDevice::removeSet(%this)
{
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
		%obj = Group::getObject(%this.set, %i);
		if ($UtilityDeviceConfig[%this] == 4)	// repair mode
		{
			if (%obj.autorepair != 0)
			{
				if (getObjectType(%obj) == "Player")
					%rate = GameBase::getAutoRepairRate(%obj) - 0.00;
				else
					%rate = GameBase::getAutoRepairRate(%obj) - 0.01;
				if(%rate < 0)
					%rate = 0;
				GameBase::setAutoRepairRate(%obj,%rate);
				%obj.autorepair = 0;
			}
		}
		else if ($UtilityDeviceConfig[%this] == 2)	// subvert mode
		{
			if(%obj.hacked != 0 && getNumTeams() >= 2)
			{
				GameBase::setTeam(%obj, %obj.realteam);
				%obj.hacked = 0;
			}
		}
		else if ($UtilityDeviceConfig[%this] == 3)	// saboteur mode
		{
			// don't do anything - simply stop doing more damage
		}
		else if ($UtilityDeviceConfig[%this] == 5)	// generator mode
		{
			if (%obj.pwrboosted != 0)
			{
				if (getObjectType(%obj) == "Player")
				{
					%rate = GameBase::getRechargeRate(%obj);
					%shieldboost = 0.0;
				}
				else
				{
					%rate = GameBase::getRechargeRate(%obj) + 10;
					%shieldboost = 0.00;
				}
				%obj.shieldStrength -= %shieldboost;
				if (%obj.shieldStrength < 0)
					%obj.shieldStrength = 0;
				if($empTime[%obj] <= 0)
					GameBase::setRechargeRate(%obj,%rate);
				else
				{
					if (getObjectType(%obj) != "Player")
						%obj.realrecharge -= 5;
				}
				%obj.pwrboosted = 0;
			}
		}
		else if ($UtilityDeviceConfig[%this] == 1)	// blackout mode
		{
			if (%obj.zapped != 0)
			{
				if ($empTime[%obj] <= 0)
					GameBase::setRechargeRate(%obj,%obj.realchargerate);
				else
				{
					if (getObjectType(%obj) != "Player")
						%obj.realrecharge = %obj.realchargerate;
				}
				%obj.zapped = 0;
			}
		}
		else if ($UtilityDeviceConfig[%this] == 6)	// Lift mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
			  SuckMe(%obj, 1.00);
			}

		}
		else if ($UtilityDeviceConfig[%this] == 8)	// bug mode
		{
			// don't do anything - simply stop bugging
		}
		else if ($UtilityDeviceConfig[%this] == 7)	// Push mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) && %obj != %this)
			{
				SlowMe(%obj, -1.50);
			}
		}
	}
	if ($UtilityDeviceConfig[%this] == 8)	// bug mode
	{
		for(%i=0; %i < getNumTeams(); %i++)
		{
			$MessagesBugged[GameBase::getTeam(%this),%i] = 0;
		}
	}
	deleteObject(%this.set);
}

// Override base class just in case.
function UtilityDevice::onPower(%this,%power,%generator)
{
}

function UtilityDevice::onActivate(%this) 
{

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //affects people, things, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 10, 10, 10,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%client = GameBase::getControlClient(%obj);
		if ($UtilityDeviceConfig[%this] == 4)	// repair mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
			{
				//don't repair enemies or the device itself
			}
			else
			{
				if (getObjectType(%obj) == "Player")
					%rate = GameBase::getAutoRepairRate(%obj) + 0.0;
				else
					%rate = GameBase::getAutoRepairRate(%obj) + 0.01;
				GameBase::setAutoRepairRate(%obj,%rate);
				%obj.autorepair = 1;
			}
		}
		else if ($UtilityDeviceConfig[%this] == 2)	// subvert mode
		{
			if(getObjectType(%obj) != "Player" && GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if(getNumTeams() >= 2)
				{
					%team = GameBase::getTeam(%obj);
					%obj.realteam = %team;
					%obj.hacked = 1;
					GameBase::setTeam(%obj, GameBase::getTeam(%this));
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 3)	// saboteur mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if (getObjectType(%obj) == "Player")
				{
					if(!Player::isDead(%player)) 
					{
						%armor = Player::getArmor(%obj);
						%dlevel = GameBase::getDamageLevel(%obj) + 0.001;
						Player::setDamageFlash(Player::getClient(%obj),0.1);
						if (%dlevel > %armor.maxDamage)
							%dlevel = %armor.maxDamage;
						GameBase::setDamageLevel(%obj,%dlevel);
						bottomprint(Player::getClient(%obj), "<jc><f4>\nYou are taking damage from radiation!  \n<f5>Find the radiating device and destroy it!\n", 1); 
						playSound(SoundRadiate,GameBase::getPosition(%obj));
						radiateMe(%this);
	
					}
					else
					{
						%client = GameBase::getOwnerClient(%obj);
						playNextAnim(%client);	
						Client::onKilled(%client, $UtilityDeviceOwnedBy[%this], $PoisonDamageType);
						messageall(0, Client::getName(%client) @ " died of radiation poisoning.");
					}
				}
				else
				{
					%name = GameBase::getDataName(%obj);
					%dlevel = GameBase::getDamageLevel(%obj) + 0.001;
					if (%dlevel > %name.maxDamage)
						%dlevel = %name.maxDamage;
					GameBase::setDamageLevel(%obj,%dlevel);
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 5)	// generator mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
			{
				//don't boost enemies or the device itself
			}
			else
			{
				if ($empTime[%obj] <= 0)
				{
					if (getObjectType(%obj) == "Player")
					{
						%rate = GameBase::getRechargeRate(%obj) + 0.5;
						%shieldboost = 0.00;
					}
					else
					{
						%rate = GameBase::getRechargeRate(%obj) + 5;
						%shieldboost = 0.03;
					}
					GameBase::setRechargeRate(%obj,%rate);
					if (%obj.shieldStrength < 0)
						%obj.shieldStrength = 0;
					%obj.shieldStrength += %shieldboost;
					%obj.pwrboosted = 1;
				}
				%name = GameBase::getDataName(%obj);
				if(%name == DeployableInvStation || %name == DeployableAmmoStation || %name == BotStation)
				{
					if(%obj.energy < (%obj.maxEnergy - 2))
						%obj.energy += 2;
					else
						%obj.energy = %obj.maxEnergy;
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 1)	// blackout mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if ($empTime[%obj] <= 0)
				{
					%obj.realchargerate = GameBase::getRechargeRate(%obj);
					if (getObjectType(%obj) == "Player")
					{
						GameBase::setRechargeRate(%obj,-25);
					}
					else
					{
						GameBase::setRechargeRate(%obj, 0);
						GameBase::setEnergy(%obj, 0);
					}
					%obj.zapped = 1;
				}
				%name = GameBase::getDataName(%obj);
				if(%name == DeployableInvStation || %name == DeployableAmmoStation || %name == BotStation)
				{
					if(%obj.energy > 2)
						%obj.energy -= 2;
					else
						%obj.energy = 0;
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 6)	// lift mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
			  SuckMe(%obj, 1.00);
			}

		}
		else if ($UtilityDeviceConfig[%this] == 8)	// bug mode
		{
			if(getObjectType(%obj) != "Player" && GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if (GameBase::getDamageState(%obj) == "Enabled") 
					$MessagesBugged[GameBase::getTeam(%this),GameBase::getTeam(%obj)] = 1;
			}
		}
		else if ($UtilityDeviceConfig[%this] == 7)	// decloak mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				SlowMe(%obj, -1.50);
			}
		}
	}

	%this.set = %Set;

	schedule("UtilityDevice::checkUtilityDevice(" @ %this @ ");", 0.05, %this);

}	

function UtilityDevice::checkUtilityDevice(%this)
{

	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //repairs people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 30, 30, 30,0);
	%num = Group::objectCount(%Set);
	if ($UtilityDeviceConfig[%this] == 7)	// bug mode
	{
		for(%i=0; %i < getNumTeams(); %i++)
		{
			$MessagesBugged[Client::getTeam(%this),%i] = 0;
		}
	}
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if ($UtilityDeviceConfig[%this] == 4)	// repair mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
			{
				//don't repair enemies or the device itself
			}
			else
			{
				if(%obj.autorepair == 0)
				{
					if (getObjectType(%obj) == "Player")
						%rate = GameBase::getAutoRepairRate(%obj) + 0.00;
					else
						%rate = GameBase::getAutoRepairRate(%obj) + 0.01;
					GameBase::setAutoRepairRate(%obj,%rate);
				}
				%obj.autorepair = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
			}
		}
		else if ($UtilityDeviceConfig[%this] == 2)	// subvert mode
		{
			if(getObjectType(%obj) != "Player")
			{
				if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
				{
					if(%obj.hacked == 0)
					{
						if(getNumTeams() >= 2)
						{
							%team = GameBase::getTeam(%obj);
							%obj.realteam = %team;
							GameBase::setTeam(%obj, GameBase::getTeam(%this));
						}
					}
					%obj.hacked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
				}
				else if (%obj.hacked > 0)
					%obj.hacked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
			}
		}
		else if ($UtilityDeviceConfig[%this] == 3)	// saboteur mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if (getObjectType(%obj) == "Player")
				{
					if(!Player::isDead(%player)) 
					{
						%armor = Player::getArmor(%obj);
						%dlevel = GameBase::getDamageLevel(%obj) + 0.001;
						Player::setDamageFlash(Player::getClient(%obj),0.1);
						if (%dlevel > %armor.maxDamage)
							%dlevel = %armor.maxDamage;
						GameBase::setDamageLevel(%obj,%dlevel);
						bottomprint(Player::getClient(%obj), "<jc><f4>\nYou are taking damage from radiation!  \n<f5>Find the radiating device and destroy it!\n", 1); 
						radiateMe(%this);
						playSound(SoundRadiate,GameBase::getPosition(%obj));

					}
					else
					{
						%client = GameBase::getOwnerClient(%obj);
						playNextAnim(%client);	
						Client::onKilled(%client, $UtilityDeviceOwnedBy[%this], $PoisonDamageType);
						messageall(0, Client::getName(%client) @ " died of radiation poisoning.");
					}
				}
				else
				{
					%name = GameBase::getDataName(%obj);
					%dlevel = GameBase::getDamageLevel(%obj) + 0.001;
					if (%dlevel > %name.maxDamage)
						%dlevel = %name.maxDamage;
					GameBase::setDamageLevel(%obj,%dlevel);
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 5)	// generator mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
			{
				//don't boost enemies or the device itself
			}
			else
			{
				if (%obj.pwrboosted > 0)
				{
					if ($empTime[%obj] > 0)
					{
						if (getObjectType(%obj) == "Player")
						{
							%obj.realrecharge -= 0;
							%shieldboost = 0.00;
						}
						else
							%shieldboost = 0.03;
						%obj.shieldStrength -= %shieldboost;
						if (%obj.shieldStrength < 0)
							%obj.shieldStrength = 0;
						%obj.pwrboosted = 0;
					}
					else
						%obj.pwrboosted = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set;
				}
				else
				{
					if ($empTime[%obj] <= 0)
					{
						if (getObjectType(%obj) == "Player")
						{
							%rate = GameBase::getRechargeRate(%obj) + 0;
							%shieldboost = 0.00;
						}
						else
						{
							%rate = GameBase::getRechargeRate(%obj) + 5;
							%shieldboost = 0.03;
						}
						GameBase::setRechargeRate(%obj,%rate);
						if (%obj.shieldStrength < 0)
							%obj.shieldStrength = 0;
						%obj.shieldStrength += %shieldboost;
						%obj.pwrboosted = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set;
					}
				}
				%name = GameBase::getDataName(%obj);
				if(%name == DeployableInvStation || %name == DeployableAmmoStation || %name == BotStation)
				{
					if(%obj.energy < (%obj.maxEnergy - 2))
						%obj.energy += 2;
					else
						%obj.energy = %obj.maxEnergy;
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 1)	// blackout mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if (%obj.zapped > 0)
				{
					if ($empTime[%obj] > 0)
					{
						if (getObjectType(%obj) != "Player")
							%obj.realrecharge = %obj.realchargerate;
						%obj.zapped = 0;
					}
					else
						%obj.zapped = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set;
				}
				else
				{
					if ($empTime[%obj] <= 0)
					{
						%obj.realchargerate = GameBase::getRechargeRate(%obj);
						if (getObjectType(%obj) == "Player")
						{
							GameBase::setRechargeRate(%obj,-25);
						}
						else
						{
							GameBase::setRechargeRate(%obj, 0);
							GameBase::setEnergy(%obj, 0);
						}
						%obj.zapped = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set;
					}
				}
				%name = GameBase::getDataName(%obj);
				if(%name == DeployableInvStation || %name == DeployableAmmoStation || %name == BotStation)
				{
					if(%obj.energy > 2)
						%obj.energy -= 2;
					else
						%obj.energy = 0;
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 6)	// lift mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
			  SuckMe(%obj, 1.00);
			}
		}
		else if ($UtilityDeviceConfig[%this] == 8)	// bug mode
		{
			if(getObjectType(%obj) != "Player" && GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if (GameBase::getDamageState(%obj) == "Enabled") 
					$MessagesBugged[GameBase::getTeam(%this),GameBase::getTeam(%obj)] = 1;
			}
		}
		else if ($UtilityDeviceConfig[%this] == 7)	// decloak mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				SlowMe(%obj, -1.50);
			}
		}
	}


	%num = Group::objectCount(%this.set);

	for(%j; %j < %num; %j++)
	{
		%obj = Group::getObject(%this.set, %j);
		if ($UtilityDeviceConfig[%this] == 4)		// repair mode
		{
			if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				//don't bother checking the other team or the device itself; they're not affected
			}
			else if(%obj.autorepair != (%this.evenodd + 1) && %obj.autorepair != 0) //if different then new set
			{
				if (getObjectType(%obj) == "Player")
					%rate = GameBase::getAutoRepairRate(%obj) - 0.00;
				else
					%rate = GameBase::getAutoRepairRate(%obj) - 0.01;
				if(%rate < 0)
					%rate = 0;
				GameBase::setAutoRepairRate(%obj,%rate);
				%obj.autorepair = 0;
			}
		}
		else if ($UtilityDeviceConfig[%this] == 2)	// subvert mode
		{
			if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this) || getObjectType(%obj) == "Player")
			{
				//don't bother checking players, the other team or the device itself; they won't be in the set
			}
			else if(%obj.hacked != (%this.evenodd + 1) && %obj.hacked != 0) //if different then new set
			{
				if(getNumTeams() >= 2)
				{
					GameBase::setTeam(%obj, %obj.realteam);
					%obj.hacked = 0;
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 3)	// saboteur mode
		{
			// don't do anything - simply stop doing more damage
		}
		else if ($UtilityDeviceConfig[%this] == 5)	// generator mode
		{
			if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				//don't bother checking the other team or the device itself; they're not affected
			}
			else if(%obj.pwrboosted != (%this.evenodd + 1) && %obj.pwrboosted != 0) //if different then new set
			{
				if ($empTime[%obj] <= 0)
				{
					if (getObjectType(%obj) == "Player")
					{
						%rate = GameBase::getRechargeRate(%obj) - 0;
						%shieldboost = 0.00;
					}
					else
					{
						%rate = GameBase::getRechargeRate(%obj) - 5;
						%shieldboost = 0.03;
					}
					%obj.shieldStrength -= %shieldboost;
					if (%obj.shieldStrength < 0)
						%obj.shieldStrength = 0;
					GameBase::setRechargeRate(%obj,%rate);
					%obj.pwrboosted = 0;
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 1)	// blackout mode
		{
			if(GameBase::getTeam(%obj) == GameBase::getTeam(%this))
			{
				//don't bother checking the device's team; they're not affected
			}
			else if(%obj.zapped != (%this.evenodd + 1) && %obj.zapped != 0) //if different then new set
			{
				if ($empTime[%obj] <= 0)
				{
					GameBase::setRechargeRate(%obj,%obj.realchargerate);
					%obj.zapped = 0;
				}
			}
		}
		else if ($UtilityDeviceConfig[%this] == 6)	// lift mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
			  SuckMe(%obj, 1.00);
			}
		}
		else if ($UtilityDeviceConfig[%this] == 8)	// bug mode
		{
			// don't do anything - simply stop bugging
		}
		else if ($UtilityDeviceConfig[%this] == 7)	// decloak mode
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				SlowMe(%obj, -1.50);
			}
		}
	}

	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set

	schedule("UtilityDevice::checkUtilityDevice(" @ %this @ ");", 0.5, %this); //then recheck in 2 seconds
}

//=============================================================================================================================

//=============================================================================================================================

TurretData DeployableIon
{
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 25;
	maxGunEnergy = 100;
	reloadDelay = 20.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 10;
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
	// projectileType = ArtilleryShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Mobile Artillery";
};
																						 
function DeployableIon::onAdd(%this)
{
	schedule("DeployableIon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,4.0);
	%this.shieldStrength = 0.000;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Mobile Artillery");
	}
}

function DeployableIon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableIon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableIon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "IonPack"]--;
}

// Override base class just in case.
function DeployableIon::onPower(%this,%power,%generator)
{
}

function DeployableIon::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,4);
	GameBase::setActive(%this,true);
}	

function DeployableIon::onFire(%this, %slot)
{
 	%AmmoCount = GameBase::getEnergy(%this);
	// messageall(0, %ammocount);
		 if (%AmmoCount >= 35)
		 {
		 GameBase::setEnergy(%this, 0);
		 playSound(SoundTomTom,GameBase::getPosition(%this));
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

		 Projectile::spawnProjectile("ArtyShell",%trans,%this,"0 0 5");
		 Projectile::spawnProjectile("ArtyShell",%trans,%this,"8 10 0");
		 Projectile::spawnProjectile("ArtyShell",%trans,%this,"-8 10 0");
		 // Projectile::spawnProjectile("ArtyShell",%trans,%this,"10 -10 0");
		 // Projectile::spawnProjectile("ArtyShell",%trans,%this,"-10 -10 0");
		 // Projectile::spawnProjectile("ArtyShell",%trans,%this,"5 10 10");
		 // Projectile::spawnProjectile("ArtyShell",%trans,%this,"10 10 -10");
		 // Projectile::spawnProjectile("ArtyShell",%trans,%this,"-10 -8 10");
		 // Projectile::spawnProjectile("ArtyShell",%trans,%this,"10 -10 10");
		 
		}
}

function DeployableIon::onCollision (%this, %object)
{
	if (getObjectType (%object) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%client = Player::getClient(%object);
		if(Client::getControlObject(%client) == %object)
		{
			echo("Client " @ %client @ " taking control of turret #" @ %this);
			Client::sendMessage(%client,0,"Controlling Artillery. Press 'C' and move backwards, then C again to cease control.");
			Client::getOwnedObject(%client).CommandTag = 1;
			Client::takeControl(%client, %this);
			%this.Disabled = true;
			Client::getOwnedObject(%client).CommandTag = "";
		}
	}
}

function DeployableIon::Reenable(%this)
{
        %this.disabled = false;
}

//=============================================================================================================================

TurretData DeployableAoe
{
	maxDamage = 100.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 13;
	visibleToSensor = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	className = "SensorTurret";
	shapeFile = "breath";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	reloadDelay = 0.3;
	description = "";
	fireSound = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;
	isSustained = true;
	firingTimeMS = 750;
	energyRate = 30.0;
};

function DeployableAoe::onAdd(%this)
{
	schedule("DeployableAoe::deploy(" @ %this @ ");",1,%this);
	GameBase::startFadeout(%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
}

function DeployableAoe::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	GameBase::setActive(%this,true);
}

function DeployableAoe::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableAoe::onDestroyed(%this)
{
	GameBase::setActive(%this,false);
	Turret::onDestroyed(%this);
	deleteobject(%this);
}

function DeployableAoe::onPower(%this,%power,%generator)
{
}

function DeployableAoe::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//=============================================================================================================================

function Turret::onAdd(%this)
{
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Turret");
	}
}

function Turret::onActivate(%this)
{
	GameBase::playSequence(%this,0,power);
}

function Turret::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
	if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) 
		Turret::checkOperator(%this);

}

function Turret::checkOperator(%this)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
		Client::setControlObject(%cl, %pl);
	}
	Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
	if (%power)
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else
	{
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
	if (GameBase::isPowered(%this))
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
}

function Turret::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
		%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);
		if(%name != CameraTurret && %name != FlameTurret && (String::findSubStr(%name, "Deployable") < 0))	
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this @ ". Press 'C' again to cease control.");
}

function Turret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this @ ". Have a nice day!");
}

function MortarTurret::onCollision (%this, %object)
{
	if (getObjectType (%object) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%client = Player::getClient(%object);
		if(Client::getControlObject(%client) == %object)
		{
			echo("Client " @ %client @ " taking control of turret #" @ %this);
			Client::sendMessage(%client,0,"Controlling Mortar Turret. Press 'C' again to cease control.");
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
