//--------------------------------------

$InvList[TurretPack] = 1;
$RemoteInvList[TurretPack] = 1;


//--------------------------------------

$TeamItemMax[TurretPack] = 10;

//--------------------------------------

RocketData MuzzleFlash
{	
	bulletShapeName = "rsmoke.dts";
	explosionTag = SmokeyExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 3.8;
	kickBackStrength = 1.7;
	muzzleVelocity = 50.9;		//75
	terminalVelocity = 5.0;
	acceleration = 59.0;
	totalTime = 0.2;
   	liveTime = 0.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 33.5;
};

BulletData MGBullet
{
   bulletShapeName    = "tracer.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0050;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 9.0;
   tracerLength       = 9.0;

soundId = SoundWindGust; // This makes the bullet hiss
			 // if it passes by your head.
			 // Adds to the realism of the
			 // bullet.  --Deadtaco

};

ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "MG42";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//--------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = ARBullet;
	maxDamage = 8.65;
	maxEnergy = 50.6;
	minGunEnergy = 0.1;
	maxGunEnergy = 0.5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.02;
	speed = 1.0;
	speedModifier = 1.0;
	range = 0;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 50.0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = MachineGunFire;
	explosionId = flashExpMedium;
	description = "MG42";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
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

function DeployableTurret::onCollision (%this, %object)
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

function DeployableTurret::Reenable(%this)
{
        %this.disabled = false;
}

function DeployableTurret::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
                GameBase::playSound(%player,debrisLargeExplosion,0);
}
//--------------------------------------

$DamageScale[DeployableTurret, $ImpactDamageType] = 0.0;
$DamageScale[DeployableTurret, $BulletDamageType] = 0.0;
$DamageScale[DeployableTurret, $PlasmaDamageType] = 0.0;
$DamageScale[DeployableTurret, $EnergyDamageType] = 0.0;
$DamageScale[DeployableTurret, $ExplosionDamageType] = 1.0;
$DamageScale[DeployableTurret, $ShrapnelDamageType] = 1.0;
$DamageScale[DeployableTurret, $DebrisDamageType] = 1.0;
$DamageScale[DeployableTurret, $MissileDamageType] = 1.0;
$DamageScale[DeployableTurret, $LaserDamageType] = 0.0;
$DamageScale[DeployableTurret, $MortarDamageType] = 1.0;
$DamageScale[DeployableTurret, $BlasterDamageType] = 0.0;
$DamageScale[DeployableTurret, $ElectricityDamageType] = 0.0;
$DamageScale[DeployableTurret, $MineDamageType]        = 1.0;