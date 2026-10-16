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
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};
																						 
TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
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
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
//	reloadDelay = 3.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundRemoteTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,14);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5 && !Player::isAiControlled(%target))
      return "True";
   else
      return "False";
}

//--------------------------------------------

TurretData MortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 2.0;
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
	speed = 2.0;
	speedModifier = 2.0;
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
	maxDamage = 2.5;
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
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";

};

//--------------------------------------------------
TurretData DepPlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 100;
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
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};

function DepPlasmaTurret::onAdd(%this)
{
	schedule("DepPlasmaTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.03;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Plasma Turret");
	}
}

function DepPlasmaTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DepPlasmaTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function DepPlasmaTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasPack"]--;
}

function DepPlasmaTurret::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",PlasPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundChainTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "PlasPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already Undeploying.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}

// Override base class just in case.
function DepPlasmaTurret::onPower(%this,%power,%generator) {}
function DepPlasmaTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
//--------------------------------------------

TurretData DeployableVulcTurret
{
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 10;
	maxGunEnergy = 6;
	reloadDelay = 0.3;
	fireSound = shockExplosion;
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
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = VulcBullet;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Vulcan Turret";
};

function DeployableVulcTurret::onAdd(%this)
{
	schedule("DeployableVulcTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.03;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Vulcan Turret");
	}
}

function DeployableVulcTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DeployableVulcTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function DeployableVulcTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "VulcPack"]--;
}

function DeployableVulcTurret::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",VulcPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundChainTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "VulcPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already UnDeploying.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}

// Override base class just in case.
function DeployableVulcTurret::onPower(%this,%power,%generator) {}
function DeployableVulcTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//------------------------------------------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFusionBolt;
	maxDamage = 0.65;
	maxEnergy = 40;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.03;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

function DeployableTurret::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",TurretPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundEnergyTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "TurretPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already UnDeploying.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

TurretData DepStutterTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = StutterBullet;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.9;
	speed = 4.0;
	speedModifier = 1.5;
	range = 25;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = shockExplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Stutter Turret";
	damageSkinData = "objectDamageSkins";
};

function DepStutterTurret::onAdd(%this)
{
	schedule("DepStutterTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Stutter Turret");
	}
}

function DepStutterTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DepStutterTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function DepStutterTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "StutPack"]--;
}

function DepStutterTurret::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",StutPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundEnergyTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "StutPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already UnDeploying.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}
// Override base class just in case.
function DepStutterTurret::onPower(%this,%power,%generator) {}
function DepStutterTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
//--------------------------------------------
TurretData DeployableRocTurret
{
	maxDamage = 0.75;
	maxEnergy = 90;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 150;
	gunRange = 250;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
//	reloadDelay = 3.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundRemoteTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function DeployableRocTurret::onAdd(%this)
{
	schedule("DeployableRocTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.03;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Rocket Turret");
	}
}

function DeployableRocTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DeployableRocTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function DeployableRocTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DepRocketPack"]--;
}

function DeployableRocTurret::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",DepRocketPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundChainTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "DepRocketPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already UnDeploying.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}
// Override base class just in case.
function DeployableRocTurret::onPower(%this,%power,%generator) {}
function DeployableRocTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5 && !Player::isAiControlled(%target))
      return "True";
   else
      return "False";
}
function DeployableRocTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	
//-------------------------------------------------
TurretData DeployableShockwv
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = ShockwvShell;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.0;
	speed = 9.0;
	speedModifier = 1.5;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireMortar;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Shockwave Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableShockwv::onAdd(%this)
{
	schedule("DeployableShockwv::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.05;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Shockwave Turret");
	}
}

function DeployableShockwv::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DeployableShockwv::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function DeployableShockwv::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShockwvPack"]--;
}

function DeployableShockwv::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",ShockwvPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundEnergyTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "ShockwvPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already UnDeploying.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}
// Override base class just in case.
function DeployableShockwv::onPower(%this,%power,%generator) {}
function DeployableShockwv::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------

TurretData DaHammerTurret
{
	maxDamage = 1.0;
	maxEnergy = 65;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 200;
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
	speed = 1.0;
	speedModifier = 2.0;
	projectileType = AnnRocket;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Annihilator Turret";
};

function DaHammerTurret::onAdd(%this)
{
	schedule("DaHammerTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.06;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Annihilator Turret");
	}
}

function DaHammerTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DaHammerTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function DaHammerTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "AhnPack"]--;
}

function DaHammerTurret::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",AhnPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundChainTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "AhnPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already UnDeploying.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}
// Override base class just in case.
function DaHammerTurret::onPower(%this,%power,%generator) {}
function DaHammerTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	
//--------------------------------------------
TurretData DeployableSLaser
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = LaserTurretSmall;
	maxDamage = 0.65;
	maxEnergy = 80;
	minGunEnergy = 6;
	maxGunEnergy = 8;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.4;
	speed = 6.0;
	speedModifier = 1.5;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableSLaser::onAdd(%this)
{
	schedule("DeployableSLaser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.03;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Laser Turret");
	}
}

function DeployableSLaser::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DeployableSLaser::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function DeployableSLaser::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
}

function DeployableSLaser::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",LaserPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundEnergyTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "LaserPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already UnDeployed.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}
// Override base class just in case.
function DeployableSLaser::onPower(%this,%power,%generator) {}
function DeployableSLaser::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------
TurretData HolyBolt	   //<-- Ideas gathered from HaVoC - No code was copied. -Clu
{			 
	maxDamage = 1.0;
	maxEnergy = 50;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 300;
	visibleToSensor = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	//mapFilter = 2;
	//mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 10.0;
	speedModifier = 1.5;
	projectileType = holyCharge;
	reloadDelay = 0.5;
	explosionId = LargeShockwave;
	description = " ";

	//fireSound        = SoundGeneratorPower;
	//activationSound  = SoundChainTurretOn;
	//deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

function HolyBolt::onAdd(%this)
{
	schedule("HolyBolt::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
}

function HolyBolt::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSLaser::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

function HolyBolt::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function HolyBolt::onPower(%this,%power,%generator) {}
function HolyBolt::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//----------------------------------------------
TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 100;
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
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Camera");
	}
}

function CameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function CameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
}

function CameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
}	

function CameraTurret::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"stutter Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",CameraPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundEnergyTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "CameraPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already UnDeployed.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged turrets.");
			}
			else
			Client::sendMessage(%clientId,0,"Turret has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"Turret is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy turrets.");
}
}
//---------------------------------------------------

function Turret::onAdd(%this)
{
	if (GameBase::getMapName(%this) == "") {
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
   if(%cl != -1) {
   	%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
	   Client::setControlObject(%cl, %pl);
		%cl.safet = false;
 		%pl.CommandTag = ""; 
   }
	Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
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
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != DeployableTurret && %name != CameraTurret )	
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function Turret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

//function Turret::onCollision (%this, %object)
//{
	//if (getObjectType (%object) == "Player")
		//{
		//	Player::mountObject (%object, %this);
		//}
//}
