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
	speed = 4.0;
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
	range = 80;
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
	speed = 4.0;
	speedModifier = 4.0;
	projectileType = TurretMissile;
//	reloadDelay = 1.0;
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
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
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
	range = 150;
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
	speedModifier = 4.0;
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
	speed = 8.0;
	speedModifier = 1.0;
	range = 35;
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


//--------------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = SniperLaser;
	maxDamage = 0.85;
	maxEnergy = 640;
	minGunEnergy = 45;
	maxGunEnergy = 45;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2;
	speed = 5.0;
	speedModifier = 1.5;
	range = 170;
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
	explosionId = flashExpMedium;
	description = "Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Laser Turret");
	}
}

function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//--------------------------------------------

TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
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

TurretData RealObeliskOfLight
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = ObeliskBeam;
	maxDamage = 5;
	maxEnergy = 90;
	minGunEnergy = 80;
	maxGunEnergy = 80;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 200; //100;
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 2;
//	mapIcon = "M_turret";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound = SoundLaserHit;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "";
	damageSkinData = "objectDamageSkins";
};

function RealObeliskOfLight::onAdd(%this)
{
	schedule("RealObeliskOfLight::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	playSound(SoundBuzz,GameBase::getPosition(%this));
}

function RealObeliskOfLight::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RealObeliskOfLight::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RealObeliskOfLight::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function RealObeliskOfLight::onPower(%this,%power,%generator) {}
function RealObeliskOfLight::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
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
	staticshape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $EMPDamageType)
	{
		staticshape::objectiveDestroyed(%this);
		GameBase::setRechargeRate(%this,0);
	}

	if(%type == $BlasterDamageType)
	{
		%energy = GameBase::getEnergy(%this);
 		%energy -= 5;
		GameBase::setEnergy(%this,%energy); 
	}

	if(%type == $ShotgunDamageType)
	{
		%energy = GameBase::getEnergy(%this);
 		%energy -= 10;
		GameBase::setEnergy(%this,%energy); 
	}

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

function Turret::onDismount (%this, %object) 
{ 
} 

function Turret::onCollision (%this, %object) { 

	if(%this.reddd) return;

	%client = Player::getClient(%object); 

	if(%client.possessing || %client.possessed) return;

	%name = GameBase::getDataName(%this);

	if(getObjectType(%object) == "Player") {

		%lllll = (Player::getMountedItem(%object,$BackpackSlot) == Laptop);	

		if ((Player::getLastContactCount(%object) > 0) || (%this.pushedTurret == 1) || %lllll) { 

		%armor = Player::getArmor(%object); 
		if (%lllll) { 
			if(%name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name == DeployableRail || %name == DeployableLaser || %name == DeployableWatchdog || %name == DeployableElf || DeployableMiniPlasma || %name == DeployableShock || %name == LELFTurret || %name == DeployableTTurret || %name == DeployableTurret || %name == DeployableAA) {  
				if(GameBase::getTeam(%object) != GameBase::getTeam(%this)) { 
					if(GameBase::getDamageState(%this) == "Enabled") {
						if(%client.lapTime == 0) { 
							if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) { 
								Client::sendMessage(%client,0,"Re-programming turret...~wDryfire1.wav"); 
								if(%armor == "spyarmor" || %armor == "spyfemale") {
schedule("checkReProgTurret("@%client@","@%this@","@GameBase::getTeam(%this)@","@%client.ScoreDeaths@");", 16);
								} else {
schedule("checkReProgTurret("@%client@","@%this@","@GameBase::getTeam(%this)@","@%client.ScoreDeaths@");", 8);
								}
								GameBase::setTeam(%this,-1); 			
								Player::unmountItem(%object,$BackpackSlot);
								Player::decItemCount(%object,Laptop);
							}
						} else Client::sendMessage(%client,0,"Internal command systems recharging..."); 
					} else { Client::sendMessage(%client,0,"Turret is disabled."); return; }
				}
			}
		}
	
		%armor = Player::getArmor(%object); 
		if(%name == PlasmaTurret || %name == PulseTurret || %name == AntiTurret || %name == FusionTurret) {
			if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) { 
				if(GameBase::getDamageState(%this) == "Enabled") {
					if (%armor != "MECH" && %armor != "harmor" && %armor != "mearmor") { 
						if(%client.lapTime == 0) { 
							if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) {
								%pl = Client::getOwnedObject(%client);
								%pl.CommandTag = 1;
								if(Client::takeControl(%client, %this)) {
									Player::trigger(%pl, $WeaponSlot, false);
									Client::sendMessage(%client,0,"Manually controlling turret"); 
									Item::setVelocity(%object, "0 0 0");
									GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
								}
								return; 
							} 					
						} else Client::sendMessage(%client,0,"Internal command systems recharging..."); 
						} else Client::sendMessage(%client,0,"Can not manually command turrets in this class."); 
					} else { Client::sendMessage(%client,0,"Turret is disabled."); } 
				} else Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav"); 
			
		}


	} else {
		%this.pushedTurret = 1;
		schedule(%this @ ".pushedTurret = 0;",1.5,%this);
	}
	}
}

function LaptopDrain(%clientId, %player) {
	if(%clientId.lapTime == 0) {
		%pl = Client::getOwnedObject(%clientId);
		schedule((%pl)@".CommandTag = \"\";", 5);
		%pl.noCom = true;
		schedule((%pl)@".noCom = \"\";", 7);
		%clientId.lapTime = 8;
		checkPlayerLaptop(%clientId, %player); 
	} else 
		%clientId.lapTime = 8;
} 

function checkPlayerLaptop(%clientId, %player)
{
	if(%clientId.lapTime > 0) { 
		%clientId.lapTime -= 4; 
		schedule("checkPlayerLaptop(" @ %clientId @ ", " @ %player @ ");",4,%player); 
	}
}


