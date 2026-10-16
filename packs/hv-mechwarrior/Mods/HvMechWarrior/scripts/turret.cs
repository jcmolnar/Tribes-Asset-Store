//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

//++++++++++++++++++++++++++++++++++++++++++++++++
TurretData ArtyTurret
{
	maxDamage = 2.0;//++++++++++++
	maxEnergy = 50;
	minGunEnergy = 48;
	maxGunEnergy = 40;
	reloadDelay = 4.0;
	fireSound = bigExplosion1;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
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
	description = "Long Tom";
};
function ArtyTurret::onAdd(%this)
{
	schedule("ArtyTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.020;
}
function ArtyTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ArtyTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		%pos = GameBase::getPosition(%this);
		%rot = GameBase::getRotation(%this);
		%rot2 = %rot;
		%rot2 = GameBase::setRotation(%this,%rotation);
		 Projectile::spawnProjectile("MortarShell",%trans,%this,%vel);
}

function ArtyTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function ArtyTurret::onPower(%this,%power,%generator) {}
function ArtyTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6);
	GameBase::setActive(%this,true);
}
function ArtyTurret::onFire(%this)
 {
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		%pos = GameBase::getPosition(%this);
		%rot = GameBase::getRotation(%this);
		%rot2 = %rot;
		%rot2 = GameBase::setRotation(%this,%rotation);
		 Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
 } 

//-----------------------------------------------------------
TurretData PlasmaTurret
{
	maxDamage = 2.0;
	maxEnergy = 200; //150;
	minGunEnergy = 50;
	maxGunEnergy = 10;
	reloadDelay = 2.25;
	fireSound = SoundFireFlierRocket;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 150;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = PPCBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "PPC Turret";
};

//-------------------------------------------------------------------------------		 
TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 25;
	maxGunEnergy = 0.5;
	reloadDelay = 0.15;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = FlamerShell;
	explosionId = LargeShockwave;
	description = "Flamer Turret";

//	fireSound        = SoundFireFlierRocket;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

};

//----------------------------------------------------
TurretData RocketTurret
{
	maxDamage = 1.0;//+++++++++
	maxEnergy = 100;
	minGunEnergy = 40; //10;+++++++++++
	maxGunEnergy = 35; //15;++++++++++
	range = 200; //150;+++++++++++++
//	gunRange = 150;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = ArrowIVTMissile; //STR2MissileT;++++++++++++
	reloadDelay = 3.5; //0.3;+++++++++++++++
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "ArrowIV Turret"; //"Streak Turret";+++++++++++++
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,15); //14+++++++
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
	maxDamage = 2.0;//++++++++++++
	maxEnergy = 50;
	minGunEnergy = 48;
	maxGunEnergy = 40;
	reloadDelay = 4.0;
	fireSound = bigExplosion1;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
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
	description = "Long Tom";
};
																			 
//--------------------------------------------
TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "chainturret"; //"indoorgun";++++++++
	projectileType = Ultra20Bullet;
	maxDamage = 1.5;
	maxEnergy = 100;
	minGunEnergy = 1; //20;+++++++
	maxGunEnergy = 1.5; //3;++++++
	reloadDelay = 0.065; //0.08;+++++++++++
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrisMediumExplosion;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Ultra-AC20 Turret";
};

//--------------------------------------------
TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.5;//+++++++++
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
		%this.shieldStrength = 0.02; //0.03;+++++++++
		GameBase::setRechargeRate(%this,8); //10+++++++++++++++
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
		%this.shieldStrength = 0.02; //0.03;+++++++
		GameBase::setRechargeRate(%this,8); //10++++++++++++++
		GameBase::setActive(%this,true);
	}
}

function Turret::onDisabled(%this)
{
if(GameBase::isPowered(%this))//++++added disable warning++++++++
	{
//	%violated = GameBase::getMapName(%this);
//	%playerTeam = GameBase::getTeam(%this);
//	TeamMessages(1, %playerTeam, "-WARNING- Network reports " @ %violated @ " has been disabled~waccess_denied.wav");
//	TeamMessages(1, 0, "-WARNING- Network reports " @ %violated @ " has been disabled~waccess_denied.wav");
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	}
else
	{ 
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	}
}

function Turret::onDestroyed(%this)
{
%playerTeam = GameBase::getTeam(%this);//++++
%violated = GameBase::getMapName(%this);//++++
TeamMessages(1, %playerTeam, "-WARNING- Network reports " @ %violated @ " has been destroyed~waccess_denied.wav");//++++

%playerClient = GameBase::getControlClient(%this.lastDamageObject);
if(%playerClient != -1)
	%clientName = Client::getName(%playerClient);
	$hvPlayerCl = %playerClient;
$hvTurretTeam = GameBase::getTeam(%this);//++++

//   messageAll(0, "message test. PlayerClient:" @ %playerClient @ " hvObject:" @ %hvObject @ " clientName:" @ %clientName @ "");//++++
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
//	Turret::objectiveDestroyed(%this);//++++++++++ unknown command +++++++++++
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
	StaticShape::objectiveDestroyed(%this);
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
if (%type == $ExplosionDamageType) HV_SensorJam(%damagedClient, %this, %shooterClient);//++++++++++++
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1; //1;++++++++
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
//		%name = GameBase::getDataName(%this);//++++
//		if(%name != DeployableTurret && %name != CameraTurret )//++++
//			%TDS = $Server::TeamDamageScale;//++++
		if (%type == $LaserDamageType)//++++++++++++
			{
			%TDS = 3;//++++
			}
		else
			{
			%TDS = 0.1; //1;++++
			}
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
//{ //thanks to Ren2.0 for some of this code++++
//if (getObjectType (%object) == "Player")
//	{
//	if($lapTime[%client] == 0)
//		{
//		%client = Player::getClient(%object);
		//Player::mountObject (%object, %this);
//		Client::getOwnedObject(%client).CommandTag = 1; 
//		Client::sendMessage(%client,0,"Manually controlling turret"); 
//		Client::takeControl(%client, %this); 
//		GameBase::SetPosition(%object,GameBase::GetPosition(%this));
//		$lapTime[%client] = 20;
//		return;
//		}
//	else
//		{
//		$lapTime[%client] -= 2;
//		return; 
//		}
//	}
//}

function Turret2::onCollision2 (%this, %object) 
{ 
if(getObjectType (%object) == "Player") 
{ 
%armor = Player::getArmor(%object); 
if ( (Player::getMountedItem(%object,$BackpackSlot) == Laptop) ) 
{ 
%name = GameBase::getDataName(%this); 
if(%name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name == DeployableRail || %name == MortarTurret) 
{ 
%client = Player::getClient(%object); 
if($lapTime[%client] == 0) 
{ 
if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) 
{ 
Client::getOwnedObject(%client).CommandTag = 1; 
Client::sendMessage(%client,0,"Re-programming turret"); 
GameBase::setTeam (%this,GameBase::getTeam (%client)); 
Client::takeControl(%client, %this); 
if(%name == DeployablePlasma || %name == DeployableVulcan || %name == DeployableRail ) 
GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
return; 
} 
} 
else 
Client::sendMessage(%client,0,"Turret is recharging."); 
} 
} 
} 
if(getObjectType (%object) == "Player") 
{ 
%armor = Player::getArmor(%object); 
if (%armor != "darmor") 
{ 
if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) 
{ 
%client = Player::getClient(%object); 
if($lapTime[%client] == 0) 
{ 
%name = GameBase::getDataName(%this); 
if(%name == DeployablePlasma || %name == DeployableVulcan || %name == PlasmaTurret || %name == DeployableRail) 
{ 
if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) 
{ 
Client::getOwnedObject(%client).CommandTag = 1; 
Client::sendMessage(%client,0,"Manually controlling turret"); 
Client::takeControl(%client, %this); 
GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
return; 
} 
} 
} 
else 
Client::sendMessage(%client,0,"Turret is recharging."); 
} 
else 
Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav"); 
} 
else 
Client::sendMessage(%client,0,"Can not manually command turrets in this class."); 
} 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData MedLasTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MedLaserTurretShell;
	maxDamage = 1.0;
	maxEnergy = 60;
	minGunEnergy = 40; //20
	maxGunEnergy = 5;
	reloadDelay = 2.0; //1.5
	speed = 5.0;
	speedModifier = 1.0;
	range = 135;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Medium Laser Turret";
};
function MedLasTurret::onAdd(%this)
{
	schedule("MedLasTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.01;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Medium Laser Turret");
	}
}
function MedLasTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MedLasPack"]--;
}
function MedLasTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
function MedLasTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MedLasTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function MedLasTurret::onPower(%this,%power,%generator) {}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = Ultra20Bullet;
	accuFire = false;
	maxDamage = 1.5;
	maxEnergy = 100;
	minGunEnergy = 1; //20;+++++++
	maxGunEnergy = 1.5; //3;++++++
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.065; //0.08;++++++++++++
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrisMediumExplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Ultra-AC20 Turret";
	damageSkinData = "objectDamageSkins";
};
function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Ultra-AC20 Turret");
	}
}
function DeployableTurret::onDestroyed(%this)
{
//%playerTeam = GameBase::getTeam(%this);//++++
//%violated = GameBase::getMapName(%this);//++++
//TeamMessages(1, %playerTeam, "-WARNING- Network reports " @ %violated @ " has been destroyed~waccess_denied.wav");//++++

//%owner = GameBase::getOwnerClient(%this);
//Client::sendMessage(Player::getClient(%owner),  "-WARNING- Network reports your " @ $HVturretName[%new] @ " has been destroyed~waccess_denied.wav");//++++Not working++++

//Client::sendMessage(Player::getClient(%owner),  "-WARNING- "@%owner@", Network reports your " @ %violated @ " has been destroyed~waccess_denied.wav");//++++screwwy message order++++

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}
function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}

//++++++++++++++++++++++++++++++++++++++++++++
TurretData LRM5Turret
{
	maxDamage = 1.0;//+++++++++
	maxEnergy = 100;
	minGunEnergy = 40; //10;+++++++++++
	maxGunEnergy = 35; //15;++++++++++
	range = 200; //150;+++++++++++++
//	gunRange = 150;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = ArrowIVTMissile; //STR2MissileT;++++++++++++
	reloadDelay = 3.5; //0.3;+++++++++++++++
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "ArrowIV Turret"; //"Streak Turret";+++++++++++++
};

function LRM5Turret::onAdd(%this)
{
	schedule("LRM5Turret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "ArrowIV Turret");
	}
}
function LRM5Turret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LRM5Pack"]--;
}
function LRM5Turret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6); //5+++++
	GameBase::setActive(%this,true);
}
function LRM5Turret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
function LRM5Turret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}
// Override base class just in case.
function LRM5Turret::onPower(%this,%power,%generator) {}
function LRM5Turret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData FlamerTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 25;
	maxGunEnergy = 0.5;
	reloadDelay = 0.15;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = FlamerShell;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	explosionId = LargeShockwave;
	description = "Flamer Turret";

//	fireSound        = SoundFireFlierRocket;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

};
function FlamerTurret::onAdd(%this)
{
	schedule("FlamerTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flamer Turret");
	}
}
function FlamerTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlamerPack"]--;
}
function FlamerTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6);
	GameBase::setActive(%this,true);
}
function FlamerTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function FlamerTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function FlamerTurret::onPower(%this,%power,%generator) {}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData PPCTurret
{
	maxDamage = 2.0;
	maxEnergy = 200; //150;
	minGunEnergy = 50;
	maxGunEnergy = 10;
	reloadDelay = 2.25;
	fireSound = SoundFireFlierRocket;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	whirSound = SoundPlasmaTurretTurn;
	range = 150;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = PPCBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "PPC Turret";
};

function PPCTurret::onAdd(%this)
{
	schedule("PPCTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.020; //0.010;+++++++
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "PPC Turret");
	}
}
function PPCTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
function PPCTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function PPCTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PPCPack"]--;
//	StaticShape::objectiveDestroyed(%this);//+++++++++++ removed: unknown command +++++++++++
//   messageAll(0, "message test. This:" @ %this @ "");//++++
}

// Override base class just in case.
function PPCTurret::onPower(%this,%power,%generator) {}
function PPCTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6); //5++++++++++++++
	GameBase::setActive(%this,true);
}

//++++++++++++++++++++++++++++++++++++++++++++
TurretData LongTom
{
	maxDamage = 2.0;//++++++++++++
	maxEnergy = 50;
	minGunEnergy = 48;
	maxGunEnergy = 40;
	reloadDelay = 4;
	fireSound = bigExplosion1;
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
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Long Tom";
};

function LongTom::onAdd(%this)
{
	schedule("LongTom::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.020;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Long Tom");
	}
}
function LongTom::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LongTom::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LongTom::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LongTomPack"]--;
}

// Override base class just in case.
function LongTom::onPower(%this,%power,%generator) {}
function LongTom::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6);
	GameBase::setActive(%this,true);
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData DeployableFlak
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FlakShell;
	maxDamage = 1.5;
	maxEnergy = 200;
	minGunEnergy = 20; //50;++++
	maxGunEnergy = 12; //6;++++
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.2; //0.8;++++++++
	speed = 4.0;
	speedModifier = 1.5;
	range = 250;
	visibleToSensor = true;
	shadowDetailMask = 8;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
//	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = flashExpMedium;
	description = "Thumper AAA";
	damageSkinData = "objectDamageSkins";
};

function DeployableFlak::onAdd(%this)
{
	schedule("DeployableFlak::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flak Turret");
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
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "STR2Pack"]--;
}
// Override base class just in case.
function DeployableFlak::onPower(%this,%power,%generator) {}
function DeployableFlak::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6);
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
//function DeployableFlak::onCollision (%this, %object)
//{
//	if (getObjectType (%object) == "Player")
//		{
//			Player::setMountObject (%object, %this, 0);
//		}
//}